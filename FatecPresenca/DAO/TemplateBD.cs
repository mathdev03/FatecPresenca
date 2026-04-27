using FatecPresenca.Models;
using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.DAO
{
    internal class TemplateBD
    {
        private readonly Conexao _db;

        public TemplateBD() {
            _db = new Conexao();
        }

        public async Task<int> inserirTemplates(List<Template> templates)
        {
            string query = @"INSERT INTO templates(TE_templateCodificado, DE_dedo, DE_qualidade, DE_User) 
                    VALUES(@template, @dedo, @qualidade, @aluno)";
            int totalInseridos = 0;

            await using var conexao = _db.getConexao();
            await conexao.OpenAsync();

            await using var transacao = await conexao.BeginTransactionAsync();

            try
            {

                foreach (var temp in templates)
                {
                    await using var comando = new MySqlCommand(query, conexao, (MySqlTransaction)transacao);
                    comando.Parameters.AddWithValue("@template", temp.getTemplate());
                    comando.Parameters.AddWithValue("@dedo", temp.getFinger());
                    comando.Parameters.AddWithValue("@qualidade", temp.getQualidade());
                    comando.Parameters.AddWithValue("@aluno", temp.getIdUser());

                    totalInseridos += await comando.ExecuteNonQueryAsync();
                }

                await transacao.CommitAsync();
            }
            catch (Exception ex)
            {
                await transacao.RollbackAsync();
                MessageBox.Show(ex.Message, "Erro ao inserir");
                throw;
            }

            return totalInseridos;
        }

        public bool alterarTemplate(List<Template> templates) {
            string query = @"UPDATE templates SET TE_templateCodificado = @template
                            , DE_dedo = @dedo, DE_qualidade = @qualidade WHERE TE_id = @id";

            int totalInseridos = 0;

            using var conexao = _db.getConexao();
            conexao.Open();

            using var transacao = conexao.BeginTransaction();

            try
            {

                foreach (var temp in templates)
                {
                    using var comando = new MySqlCommand(query, conexao, (MySqlTransaction)transacao);
                    comando.Parameters.AddWithValue("@template", temp.getTemplate());
                    comando.Parameters.AddWithValue("@dedo", temp.getFinger());
                    comando.Parameters.AddWithValue("@qualidade", temp.getQualidade());
                    comando.Parameters.AddWithValue("@id", temp.getId());

                    totalInseridos += comando.ExecuteNonQuery();
                }

                transacao.Commit();
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                MessageBox.Show(ex.Message, "Erro ao inserir");
                return true;
                throw;
            }

            MessageBox.Show(totalInseridos.ToString(), "Total Inseridos!");

            return false;
        }

        public List<Template> buscarTemplate(int idUser)
        {
            string query = @"SELECT TE_id, TE_templateCodificado, DE_dedo, DE_qualidade FROM templates WHERE DE_User = @id";
            int cont = 0;
            List<Template> lista = new List<Template>();

            try
            {
                using var conexao = _db.getConexao();
                conexao.Open();

                using var comando = new MySqlCommand(query, conexao);
                comando.Parameters.AddWithValue("@id", idUser);

                using var leitura = comando.ExecuteReader();

                while (leitura.Read())
                {

                    var t = new Template(
                            leitura.GetInt32("TE_id"),
                            leitura.IsDBNull(leitura.GetOrdinal("TE_templateCodificado")) ? null : (byte[])leitura["TE_templateCodificado"],
                            idUser,
                            leitura.GetInt32("DE_dedo"),
                            leitura.GetInt32("DE_qualidade")
                        );
                    cont++;
                    lista.Add(t);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Erro ao buscar");
                return null;
            }

            if (cont <= 0) return null;
            return lista;
        }

        public List<Template> carregarTemplates()
        {
            var templates = new List<Template>();
            string query = @"SELECT 
                                TE_id,
                                TE_templateCodificado,
                                DE_dedo,
                                DE_qualidade,
                                DE_User
                            FROM templates;";

            using var conexao = _db.getConexao();

            conexao.Open();

            using var comando = new MySqlCommand(query, conexao);

            using var leitura = comando.ExecuteReader();

            while (leitura.Read()) {
                var t = new Template(
                            leitura.GetInt32("TE_id"),
                            leitura.IsDBNull(leitura.GetOrdinal("TE_templateCodificado")) ? null : (byte[])leitura["TE_templateCodificado"],
                            leitura.GetInt32("DE_User"),
                            leitura.GetInt32("DE_dedo"),
                            leitura.GetInt32("DE_qualidade")
                        );
                templates.Add(t);
            }

            return templates;
        }
    }
}
