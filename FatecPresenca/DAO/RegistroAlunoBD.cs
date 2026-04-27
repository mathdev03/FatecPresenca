using FatecPresenca.Models;
using Microsoft.Win32;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.DAO
{
    internal class RegistroAlunoBD
    {
        private readonly Conexao _db;

        public RegistroAlunoBD()
        {
            _db = new Conexao();
        }

        public bool inserir(RegistroPresenca presenca)
        {
            using (var conn = _db.getConexao())
            {
                string query = @"INSERT INTO registropresenca(
                        RP_AlunoID,
                        RP_EventoID,
                        RP_HorarioEntrada,
                        RP_DataEvento,
                        RP_Status,
                        RP_TotalPassagens)
                    VALUES(
                        @AlunoId,
                        @EventoId,
                        @EntradaHorario,
                        @DataEvento,
                        @Status,
                        @TotalPassagens)";

                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@AlunoId", presenca.AlunoId);
                    cmd.Parameters.AddWithValue("@EventoId", presenca.EventoId);
                    cmd.Parameters.AddWithValue("@EntradaHorario",
                        presenca.HorarioEntrada.HasValue ? (object)presenca.HorarioEntrada.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@DataEvento", presenca.DataEvento.Date);
                    cmd.Parameters.AddWithValue("@Status", presenca.Status.ToString());
                    cmd.Parameters.AddWithValue("@TotalPassagens", presenca.TotalPassagens);

                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        public bool atualizar(RegistroPresenca presenca)
        {
            using (var conn = _db.getConexao())
            {
                string query = @"
                    UPDATE registropresenca
                    SET RP_HorarioSaida = @HorarioSaida,
                        RP_TotalPassagens = @TotalPassagens,
                        RP_Status = @Status,
                        RP_DataAlteracao = NOW()
                    WHERE RP_id = @id";

                conn.Open();

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", presenca.Id);
                    cmd.Parameters.AddWithValue("@HorarioSaida",
                       presenca.HorarioSaida.HasValue ? (object)presenca.HorarioSaida.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", presenca.Status.ToString());
                    cmd.Parameters.AddWithValue("@TotalPassagens", presenca.TotalPassagens);

                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        public RegistroPresenca buscarPorAlunoEvento(int alunoid, int eventoid)
        {
            try
            {
                using (var conn = _db.getConexao())
                {
                    var query = @"
                    SELECT * FROM registropresenca
                    WHERE RP_AlunoID = @aluno AND
                          RP_EventoID = @evento
                    ";

                    conn.Open();

                    using (var comand = new MySqlCommand(query, conn))
                    {
                        comand.Parameters.AddWithValue("@aluno", alunoid);
                        comand.Parameters.AddWithValue("@evento", eventoid);

                        using (var leitura = comand.ExecuteReader())
                        {
                            if (leitura.Read())
                            {
                                return MapearRegistro(leitura);
                            }
                        }
                    }
                }
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }
            

            return null;
        }


        private RegistroPresenca MapearRegistro(MySqlDataReader leitura)
        {
            int id = !leitura.IsDBNull(leitura.GetOrdinal("RP_id")) ? leitura.GetInt32("RP_id") : 0;

            var registro = new RegistroPresenca(
                    leitura.GetInt32("RP_AlunoID"),
                    leitura.GetInt32("RP_EventoID"),
                    leitura.GetDateTime("RP_DataEvento").Date,
                    id
                );

            // Status
            StatusPresenca status = Enum.Parse<StatusPresenca>(leitura.GetString("RP_Status"));

            if (!leitura.IsDBNull(leitura.GetOrdinal("RP_HorarioEntrada")))
                registro.RegistrarEntrada(
                    leitura.GetTimeOnly("RP_HorarioEntrada"),
                    status
                );

            if (!leitura.IsDBNull(leitura.GetOrdinal("RP_HorarioSaida")))
                registro.RegistrarSaida(leitura.GetTimeOnly("RP_HorarioSaida"));

            return registro;
        }
    }
}
