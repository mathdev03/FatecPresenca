using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Presenter.Alunos;
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
    public partial class frmInserirAluno : Form, InserirAlunoView
    {
        public event EventHandler<DataGridViewCellEventArgs>? SelecionarLinha;
        public event EventHandler? InserirAluno;
        public event EventHandler? AlterarAluno;
        public event EventHandler? DeletarAluno;
        public event EventHandler? CadastrarAlunos;
        public event EventHandler? ImportarExcel;
        public event EventHandler? LimparCampos;
        public event EventHandler? Cancelar;
        public event EventHandler<string>? PesquisarAluno;

        private readonly InserirAlunoPresenter _presenter;

        public string Nome
        {
            get => txtNome.Text;
            set => txtNome.Text = value;
        }

        public string Email
        {
            get => txtEmail.Text;
            set => txtEmail.Text = value;
        }

        public int LinhaSelecionada { get; private set; }

        public frmInserirAluno()
        {

            InitializeComponent();

            _presenter = new InserirAlunoPresenter(this);

            btnInserir.Click += (_, _) => InserirAluno?.Invoke(this, EventArgs.Empty);
            btnAlterar.Click += (_, _) => AlterarAluno?.Invoke(this, EventArgs.Empty);
            btnDeletar.Click += (_, _) => DeletarAluno?.Invoke(this, EventArgs.Empty);
            btnCadastrar.Click += (_, _) => CadastrarAlunos?.Invoke(this, EventArgs.Empty);
            btnImportarDados.Click += (_, _) => ImportarExcel?.Invoke(this, EventArgs.Empty);
            btnLimpar.Click += (_, _) => LimparCampos?.Invoke(this, EventArgs.Empty);
            btnCancelar.Click += (_, _) => Cancelar?.Invoke(this, EventArgs.Empty);
            txtPesquisar.TextChanged += (_, _) => PesquisarAluno?.Invoke(this, txtPesquisar.Text);

            dgvDadosRegistro.CellClick += (_, e) => SelecionarLinha?.Invoke(this, e);
        }

        public string ObterNomeLinha(int linha)
        {
            return dgvDadosRegistro.Rows[linha].Cells[0].Value?.ToString();
        }

        public string ObterEmailLinha(int linha)
        {
            return dgvDadosRegistro.Rows[linha].Cells[1].Value?.ToString();
        }

        public void LimparGrid()
        {
            dgvDadosRegistro.Rows.Clear();
        }

        public void AdicionarLinha(string nome, string email)
        {
            DataGridViewRow linhas = new DataGridViewRow();
            linhas.CreateCells(dgvDadosRegistro);
            linhas.Cells[0].Value = nome;
            linhas.Cells[1].Value = email;
            dgvDadosRegistro.Rows.Add(linhas);
        }

        public void FiltrarAlunos(string termo)
        {
            var pesquisa = termo.ToLower();

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

        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Mensagem");
        }

        public void Fechar()
        {
            this.Close();
        }



        private void btnCancelar_Click(object sender, EventArgs e) { }
        private void btnInserir_Click(object sender, EventArgs e) { }
        private void btnAlterar_Click(object sender, EventArgs e) { }
        private void dgvDadosRegistro_CellClick(object sender, DataGridViewCellEventArgs e) { }
        private void btnLimpar_Click(object sender, EventArgs e) { }
        private void txtPesquisar_TextChanged(object sender, EventArgs e) { }
        private void btnDeletar_Click(object sender, EventArgs e) { }
        private void btnCadastrar_Click(object sender, EventArgs e) { }
        private void btnVerificarDados_Click(object sender, EventArgs e) { }
        private void btnExportarDados_Click(object sender, EventArgs e) { }
    }
}
