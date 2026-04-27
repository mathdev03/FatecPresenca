using FatecPresenca.DAO;
using FatecPresenca.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatecPresenca.Presenca
{
    public partial class frmInserirAluno : Form
    {
        Turma turma = new Turma(new List<Aluno>());

        Aluno alunoEscolhido;
        int identLinha;

        public frmInserirAluno()
        {

            InitializeComponent();
        }

        private void recarregarLista()
        {
            dgvDadosRegistro.Rows.Clear();

            turma.getListaAluno().ForEach(al =>
            {
                DataGridViewRow linhas = new DataGridViewRow();
                linhas.CreateCells(dgvDadosRegistro);
                linhas.Cells[0].Value = al.getNome();
                linhas.Cells[1].Value = al.getEmail();
                dgvDadosRegistro.Rows.Add(linhas);
            });
        }


        // Dados forms

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.ToUpper();
            string email = txtEmail.Text;

            var aluno = new Aluno(nome, email);
            turma.adicionarAluno(aluno);

            recarregarLista();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text.ToUpper();
            string email = txtEmail.Text;

            var aluno = new Aluno(nome, email);

            alunoEscolhido = turma.alterarAluno(alunoEscolhido, aluno);

            recarregarLista();
        }

        private void dgvDadosRegistro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            //Identificar aluno
            identLinha = e.RowIndex;
            DataGridViewRow linha = dgvDadosRegistro?.Rows[identLinha];
            string email = linha.Cells[1].Value?.ToString();
            string nome = linha.Cells[0].Value?.ToString();

            alunoEscolhido = new Aluno(nome, email);

            txtNome.Text = nome;
            txtEmail.Text = email;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtEmail.Text = "";
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = txtPesquisar.Text.ToLower();

            foreach (DataGridViewRow linha in dgvDadosRegistro.Rows)
            {
                bool encontrado = false;

                foreach (DataGridViewCell celulas in linha.Cells)
                {
                    if (celulas.Value != null &&
                        celulas.Value.ToString().ToLower().Contains(pesquisa))
                    {
                        encontrado = true;
                        break;
                    }
                }

                linha.Visible = encontrado;
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            turma.removerAluno(alunoEscolhido);

            alunoEscolhido = null;
            btnLimpar_Click(null, null);
            recarregarLista();
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            AlunoBD db = new AlunoBD();

            int dados = await db.iserirAluno(turma.getListaAluno());

            MessageBox.Show(dados.ToString(), "Total de Alunos Inseridos!");
            this.Close();
        }

        private void btnVerificarDados_Click(object sender, EventArgs e)
        {
            turma.verificarDuplicatas();

            recarregarLista();
        }

        private void btnExportarDados_Click(object sender, EventArgs e)
        {
            turma.ImportarAlunosDoExcel();

            recarregarLista();
        }
    }
}
