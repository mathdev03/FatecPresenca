using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
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
    public partial class frmAlunos : Form, AlunosView
    {
        public event EventHandler CarregarAlunos;
        public event EventHandler InserirAluno;
        public event EventHandler UDAluno;
        public event EventHandler ExcluirAluno;
        public event EventHandler AbrirBiometria;
        public event EventHandler FecharForm;
        public event EventHandler<string> PesquisarAluno;
        public event EventHandler<int> SelecionarAluno;
        public event EventHandler MostrarAluno;

        private readonly AlunosPresenter _presenter;
        private int linhaSelecionado = -1;

        public string Nome { set => lblNome.Text = value; }
        public string Email { set => lblEmail.Text = value; }

        public int LinhaSelecionada => linhaSelecionado;

        public frmAlunos()
        {
            InitializeComponent();

            _presenter = new AlunosPresenter(this);

            dgvDadosRegistro.Columns.Clear();

            btnInserir.Click += (_, _) => InserirAluno?.Invoke(this, EventArgs.Empty);
            btnUpdateDelete.Click += (_, _) => UDAluno?.Invoke(this, EventArgs.Empty);
            btnBiometria.Click += (_, _) => AbrirBiometria?.Invoke(this, EventArgs.Empty);
            btnConcluir.Click += (_, _) => FecharForm?.Invoke(this, EventArgs.Empty);
            txtPesquisar.TextChanged += (_, _) => PesquisarAluno?.Invoke(this, txtPesquisar.Text);
            dgvDadosRegistro.SelectionChanged += (_, _) =>
            {
                if (dgvDadosRegistro.CurrentRow != null)
                {
                    linhaSelecionado = dgvDadosRegistro.CurrentRow.Index;
                }
            };
            dgvDadosRegistro.CellClick += (_, _) => MostrarAluno?.Invoke(this, EventArgs.Empty);

            this.Load += (_, _) => CarregarAlunos?.Invoke(this, EventArgs.Empty);
        }

        public string obterIdLinha(int linha)
        {
            return dgvDadosRegistro.Rows[linha].Cells[0].Value?.ToString();
        }

        public void PopularGrid(List<AlunosListDTO> dto)
        {
            dgvDadosRegistro.DataSource = null;
            dgvDadosRegistro.DataSource = dto;

            dgvDadosRegistro.Columns["Id"].Visible = false;
        }

        public void Fechar()
        {
            this.Close();
        }



        private void btnInserir_Click(object sender, EventArgs e) { }
        private void btnAlterar_Click(object sender, EventArgs e) { }
        private void btnExcluir_Click(object sender, EventArgs e) { }
        private void btnBiometria_Click(object sender, EventArgs e) { }
        private void btnConcluir_Click(object sender, EventArgs e) { }
        private void txtPesquisar_TextChanged(object sender, EventArgs e) { }
        private void dgvDadosRegistro_SelectionChanged(object sender, EventArgs e) { }
    }
}
