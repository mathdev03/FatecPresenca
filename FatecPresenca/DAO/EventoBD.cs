using FatecPresenca.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.DAO
{
    internal class EventoBD
    {
        private readonly Conexao _db;

        public EventoBD()
        {
            _db = new Conexao();
        }

        public int inserirEvento(Evento evento)
        {
            string query = @"INSERT INTO evento(
                                EV_nome, 
                                EV_descricao, 
                                EV_periodoInicio, 
                                EV_periodoFim, 
                                EV_janelaEntradaInicio, 
                                EV_janelaEntradaFim, 
                                EV_janelaSaidaInicio, 
                                EV_janelaSaidaFim) 
                            VALUES(
                                @nome, 
                                @descricao,
                                @periodoIN, 
                                @periodoFM, 
                                @janelaEI, 
                                @janelaEF, 
                                @janelaSI, 
                                @janelaSF)";

            using var conexao = _db.getConexao();
            conexao.Open();

            using var comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@nome", evento.Nome);
            comando.Parameters.AddWithValue("@descricao", evento.Descricao);
            comando.Parameters.AddWithValue("@periodoIN", evento.Periodo.inicio);
            comando.Parameters.AddWithValue("@periodoFM", evento.Periodo.fim);
            comando.Parameters.AddWithValue("@janelaEI", evento.Janela.EntradaInicio);
            comando.Parameters.AddWithValue("@janelaEF", evento.Janela.EntradaFim);
            comando.Parameters.AddWithValue("@janelaSI", evento.Janela.SaidaInicio);
            comando.Parameters.AddWithValue("@janelaSF", evento.Janela.SaidaFim);

            if (comando.ExecuteNonQuery() == 0) throw new ArgumentException("Erro ao inserir no BD!");

            return (int) comando.LastInsertedId;
        }

        public bool alterarEvento(Evento evento)
        {
            string query = @"UPDATE evento 
                                SET EV_nome = @nome, 
                                    EV_descricao = @descricao, 
                                    EV_periodoInicio = @periodoIN, 
                                    EV_periodoFim = @periodoFM, 
                                    EV_janelaEntradaInicio = @janelaEI, 
                                    EV_janelaEntradaFim = @janelaEF, 
                                    EV_janelaSaidaInicio = @janelaSI, 
                                    EV_janelaSaidaFim = @janelaSF 
                                WHERE EV_id = @id;";

            using var conexao = _db.getConexao();
            conexao.Open();

            using var comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@nome", evento.Nome);
            comando.Parameters.AddWithValue("@descricao", evento.Descricao);
            comando.Parameters.AddWithValue("@periodoIN", evento.Periodo.inicio);
            comando.Parameters.AddWithValue("@periodoFM", evento.Periodo.fim);
            comando.Parameters.AddWithValue("@janelaEI", evento.Janela.EntradaInicio);
            comando.Parameters.AddWithValue("@janelaEF", evento.Janela.EntradaFim);
            comando.Parameters.AddWithValue("@janelaSI", evento.Janela.SaidaInicio);
            comando.Parameters.AddWithValue("@janelaSF", evento.Janela.SaidaFim);
            comando.Parameters.AddWithValue("@id", evento.Id);

            if (comando.ExecuteNonQuery() <= 0)
            {
                return true;
                throw new ArgumentException("Erro ao inserir no BD!");
            }

            return false;
        }

        public bool excluirEvento(int id) {
            string query = "DELETE FROM evento WHERE @id = EV_id";

            using var conexao = _db.getConexao();
            conexao.Open();

            using var comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@id", id);

            if (comando.ExecuteNonQuery() <= 0) throw new ArgumentException("Erro ao excluir no BD!");

            return false;
        }

        public Evento buscarEvento(int id)
        {
            string query = @"SELECT 
                                    EV_nome, 
                                    EV_descricao, 
                                    EV_periodoInicio, 
                                    EV_periodoFim, 
                                    EV_janelaEntradaInicio, 
                                    EV_janelaEntradaFim, 
                                    EV_janelaSaidaInicio, 
                                    EV_janelaSaidaFim
                                FROM evento
                                WHERE EV_id = @id;";

            using var conexao = _db.getConexao();
            conexao.Open();

            using var comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@id", id);

            using var leitura = comando.ExecuteReader();

            if (leitura.Read())
            {
                var p = new PeriodoEvento(
                        inicio: leitura.GetDateTime(leitura.GetOrdinal("EV_periodoInicio")),
                        fim: leitura.GetDateTime(leitura.GetOrdinal("EV_periodoFim"))
                    );
                var j = new JanelaPresenca(
                        entradaInicio:leitura.GetTimeOnly(leitura.GetOrdinal("EV_janelaEntradaInicio")),
                        entradaFim:leitura.GetTimeOnly(leitura.GetOrdinal("EV_janelaEntradaFim")),
                        saidaInicio: leitura.GetTimeOnly(leitura.GetOrdinal("EV_janelaSaidaInicio")),
                        saidaFim: leitura.GetTimeOnly(leitura.GetOrdinal("EV_janelaSaidaFim"))
                    );


                return new Evento(
                    nome: leitura.GetString(leitura.GetOrdinal("EV_nome")),
                    descricao: leitura.GetString(leitura.GetOrdinal("EV_descricao")),
                    periodo: p,
                    janela: j,
                    id
                    );
            }

            return null;
        }

        public List<Evento> carregarEventos()
        {
            var eventos = new List<Evento>();
            string query = @"SELECT 
                                EV_id,
                                EV_nome,
                                EV_descricao,
                                EV_periodoInicio,
                                EV_periodoFim,
                                EV_janelaEntradaInicio,
                                EV_janelaEntradaFim,
                                EV_janelaSaidaInicio,
                                EV_janelaSaidaFim
                            FROM evento;";

            using var conexao = _db.getConexao();

            conexao.Open();

            using var comando = new MySqlCommand(query, conexao);

            using var leitura = comando.ExecuteReader();

            while (leitura.Read())
            {
                int id = leitura.GetInt32(leitura.GetOrdinal("EV_id"));
                string nome = leitura.GetString(leitura.GetOrdinal("EV_nome"));
                string descricao = leitura.GetString(leitura.GetOrdinal("EV_descricao"));

                var periodoInicio = leitura.GetDateTime(leitura.GetOrdinal("EV_periodoInicio"));
                var periodoFim = leitura.GetDateTime(leitura.GetOrdinal("EV_periodoFim"));

                var periodo = new PeriodoEvento(
                        periodoInicio,
                        periodoFim
                );

                var EInicio = leitura.GetTimeOnly(leitura.GetOrdinal("EV_janelaEntradaInicio"));
                var EFim = leitura.GetTimeOnly(leitura.GetOrdinal("EV_janelaEntradaFim"));
                var SInicio = leitura.GetTimeOnly(leitura.GetOrdinal("EV_janelaSaidaInicio"));
                var SFim = leitura.GetTimeOnly(leitura.GetOrdinal("EV_janelaSaidaFim"));

                var janela = new JanelaPresenca(
                        entradaInicio: EInicio,
                        entradaFim: EFim,
                        saidaInicio: SInicio,
                        saidaFim: SFim
                );


                var evento = new Evento(
                    nome: nome,
                    descricao: descricao,
                    periodo: periodo,
                    janela: janela,
                    id: id
                );

                eventos.Add(evento);
            }

            return eventos;
        }
    }
}
