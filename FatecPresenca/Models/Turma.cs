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

namespace FatecPresenca.Models
{
    internal class Turma
    {
        private List<Aluno> alunos = new List<Aluno>();

        public Turma(List<Aluno> alunos)
        {
            this.alunos = alunos;
        }

        public void adicionarAluno(Aluno aluno)
        {
            if(!verificarCampoVazio(aluno)) return;
            if (verificarDadosDuplicados(aluno)) return;

            alunos.Add(aluno);
        }

        public Aluno alterarAluno(Aluno aluno, Aluno alunoNovo)
        {
            if (!verificarCampoVazio(alunoNovo)) return aluno;

            Aluno alunoAtual = identificarAluno(aluno);
            if (alunoAtual == null) return aluno;
            if (verificarDadosDuplicados(alunoNovo, alunoAtual)) return aluno;

            alunos.Remove(alunoAtual);
            alunos.Add(alunoNovo);
            return alunoNovo;
        }

        public void removerAluno(Aluno aluno)
        {
            aluno = identificarAluno(aluno);
            if (!verificarCampoVazio(aluno)) return;

            alunos.Remove(aluno);
        }

        public async void verificarDuplicatas()
        {
            AlunoBD db = new AlunoBD();
            List<Aluno> cadastrados = await db.pegarAlunos();

            if (cadastrados.Count == 0) {

                MessageBox.Show("Não possui dados no bd!", "Messagem");
                return;                    
             }

            List<Aluno> naoCadastrados = alunos
                .Where(al => !cadastrados
                    .Any(db => db.getEmail() == al.getEmail()))
                .ToList();

            alunos = naoCadastrados;
        }

        public Aluno identificarAluno(Aluno aluno)
        {
            aluno = alunos.FirstOrDefault(a => a.getNome() ==
            aluno.getNome() && a.getEmail() == aluno.getEmail());

            if (aluno == null) {
                MessageBox.Show("Aluno não identificado!");
                return aluno;
            }

            return aluno;
        }

        private bool verificarCampoVazio(Aluno aluno)
        {
            if (aluno == null)
            {
                MessageBox.Show("Nenhum Aluno selecionado!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(aluno.getNome()) || 
                string.IsNullOrEmpty(aluno.getEmail()))
            {
                MessageBox.Show("Campos vazio!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool verificarDadosDuplicados(Aluno alunoNovo, Aluno alunoAtual = null)
        {
            bool duplicado = alunos.Any(a =>
                a != alunoAtual &&
                (a.getEmail().Equals(alunoNovo.getEmail(), StringComparison.OrdinalIgnoreCase) ||
                 a.getNome().Equals(alunoNovo.getNome(), StringComparison.OrdinalIgnoreCase)));

            if (duplicado)
            {
                MessageBox.Show("Nome ou e-mail já cadastrado em outro aluno na turma!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                        using (var stream = System.IO.File.Open(ofd.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                        {
                            // Usa a biblioteca ExcelDataReader
                            using (var reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet(new ExcelDataReader.ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (data) => new ExcelDataReader.ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true // Vai usar a primeira linha da planilha como cabeçalho (espera colunas 'Nome' e 'Email')
                                    }
                                });

                                // Pega a primeira "aba" (planilha) do Excel
                                System.Data.DataTable dataTable = result.Tables[0];
                                int alunosAdicionados = 0;

                                // Lê linha por linha do excel a partir da segunda linha (dados)
                                foreach (System.Data.DataRow row in dataTable.Rows)
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
