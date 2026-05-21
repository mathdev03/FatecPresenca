using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
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
    public partial class frmPresenca : Form
    {
        ServicoInserirAluno turma;
        int linhaSelecionado = -1;

        public frmPresenca()
        {
            InitializeComponent();

            popularLista();

        }

        private async void popularLista()
        {
            dgvDadosRegistro.Rows.Clear();

            AlunoBD db = new AlunoBD();

            turma = new ServicoInserirAluno(await db.pegarAlunos());

            turma.getListaAluno().ForEach(aluno =>
            {
                DataGridViewRow linhas = new DataGridViewRow();
                linhas.CreateCells(dgvDadosRegistro);
                linhas.Cells[0].Value = aluno.getNome();
                linhas.Cells[1].Value = aluno.getEmail();
                dgvDadosRegistro.Rows.Add(linhas);
            });
        }

        private void procurar(string dado)
        {
            foreach (DataGridViewRow linha in dgvDadosRegistro.Rows)
            {
                bool encontrado = false;

                foreach (DataGridViewCell celulas in linha.Cells)
                {
                    if (celulas.Value != null &&
                        celulas.Value.ToString().ToLower().Contains(dado.ToLower()))
                    {
                        encontrado = true;
                        break;
                    }
                }

                linha.Visible = encontrado;
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmInserirAluno insereAluno = new frmInserirAluno();
            insereAluno.ShowDialog();

            popularLista();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (linhaSelecionado == -1) return;

            string nome = dgvDadosRegistro.Rows[linhaSelecionado].Cells[0].Value?.ToString();
            string email = dgvDadosRegistro.Rows[linhaSelecionado].Cells[1].Value?.ToString();

            var aluno = turma.identificarAluno(new Aluno(nome, email));

            frmAlterarAluno alterarAluno = new frmAlterarAluno(aluno.getId());
            alterarAluno.ShowDialog();

            popularLista();
        }

        private void btnBiometria_Click(object sender, EventArgs e)
        {
            if (linhaSelecionado == -1) return;

            string nome = dgvDadosRegistro.Rows[linhaSelecionado].Cells[0].Value?.ToString();
            string email = dgvDadosRegistro.Rows[linhaSelecionado].Cells[1].Value?.ToString();

            var aluno = turma.identificarAluno(new Aluno(nome, email));

            var biometria = new frmBiometria(aluno.getId().ToString());
            biometria.ShowDialog();

        }

        private void dgvDadosRegistro_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDadosRegistro.CurrentRow == null) return;

            linhaSelecionado = dgvDadosRegistro.CurrentRow.Index;
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = txtPesquisar.Text;

            procurar(pesquisa);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (linhaSelecionado == -1) return;

            string nome = dgvDadosRegistro.Rows[linhaSelecionado].Cells[0].Value?.ToString();
            string email = dgvDadosRegistro.Rows[linhaSelecionado].Cells[1].Value?.ToString();

            var aluno = turma.identificarAluno(new Aluno(nome, email));

            frmExcluirAluno excluir = new frmExcluirAluno(aluno.getId());
            excluir.ShowDialog();

            popularLista();
        }
    }
}
