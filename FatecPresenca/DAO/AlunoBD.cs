using FatecPresenca.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FatecPresenca.DAO
{
    internal class AlunoBD
    {
        private readonly Conexao _db;

        public AlunoBD()
        {
            _db = new Conexao();
        }

        public async Task<int> iserirAluno(List<Aluno> alunos)
        {
            string query = @"INSERT INTO aluno(AL_nome, AL_email) VALUES(@aluno, @email)";
            int totalInseridos = 0;

            await using var conexao = _db.getConexao();
            await conexao.OpenAsync();

            await using var transacao = await conexao.BeginTransactionAsync();

            try
            {
                foreach (var al in alunos)
                {
                    await using var comando = new MySqlCommand(query, conexao, (MySqlTransaction)transacao);
                    comando.Parameters.AddWithValue("@aluno", al.nome);
                    comando.Parameters.AddWithValue("@email", al.email);

                    totalInseridos += await comando.ExecuteNonQueryAsync();
                }

                await transacao.CommitAsync();
            }
            catch (Exception ex) { 
                await transacao.RollbackAsync();
                MessageBox.Show(ex.Message, "Erro ao inserir");
                throw;
            }

            return totalInseridos;
        }

        public async Task<bool> alterarAluno(Aluno aluno)
        {
            string query = @"UPDATE aluno SET AL_nome = @nome, AL_email = @email WHERE AL_id = @id";

            try
            {
                await using var conexao = _db.getConexao();
                await conexao.OpenAsync();

                await using var comando = new MySqlCommand(query, conexao);

                comando.Parameters.AddWithValue("@nome", aluno.nome);
                comando.Parameters.AddWithValue("@email", aluno.email);
                comando.Parameters.AddWithValue("@id", aluno.id);

                int linhasAfetadas = await comando.ExecuteNonQueryAsync();

                return linhasAfetadas > 0;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Erro ao alterar o aluno");
            }

            return false;
        }

        public async Task<bool> deletarAluno(int id)
        {
            string query = @"DELETE FROM aluno WHERE AL_id = @id";

            try
            {
                await using var conexao = _db.getConexao();
                await conexao.OpenAsync();

                await using var comando = new MySqlCommand(query, conexao);

                comando.Parameters.AddWithValue("@id", id);

                int linhasAfetadas = await comando.ExecuteNonQueryAsync();

                return linhasAfetadas > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao alterar o aluno");
            }

            return false;
        }

        public async Task<List<Aluno>> pegarAlunos()
        {
            var alunos = new List<Aluno>();
            string query = @"SELECT AL_id, AL_nome, AL_email FROM aluno";

            try
            {
                await using var conexao = _db.getConexao();
                await conexao.OpenAsync();

                await using var comando = new MySqlCommand(query, conexao);

                await using var leitura = await comando.ExecuteReaderAsync();

                while (await leitura.ReadAsync())
                {
                    string id = leitura["AL_id"]?.ToString();
                    string nome = leitura["AL_nome"]?.ToString();
                    string email = leitura["AL_email"]?.ToString();

                    var aluno = new Aluno(nome, email, Convert.ToInt32(id));

                    alunos.Add(aluno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao pegar Alunos");
            }

            return alunos;
        }

        public async Task<Aluno> buscarAluno(int id)
        {
            string query = @"SELECT AL_nome, AL_email FROM aluno WHERE AL_id = @id";

            try
            {
                await using var conexao = _db.getConexao();
                await conexao.OpenAsync();

                await using var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@id", id);

                await using var leitura = await comando.ExecuteReaderAsync();

                if (await leitura.ReadAsync())
                {
                    return new Aluno(
                        leitura.GetString("AL_nome"),
                        leitura.GetString("AL_email"),
                        id
                        );
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao buscar aluno");
            }

            return null;
        }
    }
}
