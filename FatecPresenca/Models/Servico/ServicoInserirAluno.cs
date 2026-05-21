using FatecPresenca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using ExcelDataReader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Runtime.CompilerServices;

namespace FatecPresenca.Models.Servico
{
    internal class ServicoInserirAluno
    {
        private List<Aluno> alunos = new List<Aluno>();
        public Aluno aluno;

        public ServicoInserirAluno(List<Aluno> alunos)
        {
            this.alunos = alunos;
        }

        public void adicionarAluno(Aluno aluno)
        {
            if (verificarDadosDuplicados(aluno))
                throw new ArgumentException("Dados duplicados!");

            alunos.Add(aluno);
        }

        public void alterarAluno(Aluno alunoNovo)
        {
            Aluno alunoAtual = identificarAluno(aluno);
            if (alunoAtual == null)
                throw new ArgumentException("Nenhum aluno identificado!");
            if (verificarDadosDuplicados(alunoNovo, alunoAtual))
                throw new ArgumentException("Dados duplicados!");

            alunos.Remove(alunoAtual);

            aluno = alunoNovo;
            alunos.Add(alunoNovo);
        }

        public void removerAluno()
        {
            aluno = identificarAluno(aluno);

            alunos.Remove(aluno);
        }

        public Aluno identificarAluno(Aluno aluno)
        {
            if (aluno == null)
                throw new ArgumentException("Nenhum aluno encontrado!");

            aluno = alunos.FirstOrDefault(a => a.nome ==
            aluno.nome && a.email == aluno.email);

            return aluno;
        }

        private bool verificarDadosDuplicados(Aluno alunoNovo, Aluno alunoAtual = null)
        {
            bool duplicado = alunos.Any(a =>
                a != alunoAtual &&
                (a.email.Equals(alunoNovo.email, StringComparison.OrdinalIgnoreCase) ||
                 a.nome.Equals(alunoNovo.nome, StringComparison.OrdinalIgnoreCase)));

            if (duplicado)
                return true;

            return duplicado;
        }

        public void ImportarAlunosDoExcel()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Arquivos Excel|*.xls;*.xlsx" })
            {
                // Ao abrir, verifica se o usuário selecionou e deu OK
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Linha necessária nas versões novas do C# para leitura do formato de texto do Excel
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                        using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                        {
                            // Usa a biblioteca ExcelDataReader
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (data) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true // Vai usar a primeira linha da planilha como cabeçalho (espera colunas 'Nome' e 'Email')
                                    }
                                });

                                // Pega a primeira "aba" (planilha) do Excel
                                DataTable dataTable = result.Tables[0];
                                int alunosAdicionados = 0;

                                // Lê linha por linha do excel a partir da segunda linha (dados)
                                foreach (DataRow row in dataTable.Rows)
                                {
                                    // Pega das colunas obrigatórias
                                    string nome = row["Nome"]?.ToString().ToUpper();
                                    string email = row["Email"]?.ToString();

                                    // Só prossegue se os dois campos existirem
                                    if (!string.IsNullOrWhiteSpace(nome) && !string.IsNullOrWhiteSpace(email))
                                    {
                                        Aluno novoAluno = new Aluno(nome, email);

                                        // Utiliza aquela nossa ótima função para evitar colocar aluno já salvo
                                        if (!verificarDadosDuplicados(novoAluno))
                                        {
                                            alunos.Add(novoAluno);
                                            alunosAdicionados++;
                                        }
                                    }
                                }

                                MessageBox.Show($"{alunosAdicionados} alunos importados com sucesso da planilha!", "Importação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao tentar importar o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public List<Aluno> getListaAluno()
        {
            return alunos;
        }
    }
}
