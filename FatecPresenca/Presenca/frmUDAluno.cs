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
    public partial class frmUDAluno : Form, AlunoUDView
    {
        public event EventHandler CarregarAluno;
        public event EventHandler AlterarAluno;
        public event EventHandler ExcluirAluno;
        public event EventHandler Cancelar;

        private readonly AlunoUDPresenter _presenter;
        private int _alunoId;

        public int AlunoId => _alunoId;
        public string Nome { get => txtNome.Text; set => txtNome.Text = value; }
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string Titulo { set => label.Text = value; }

        public frmUDAluno(int idAluno)
        {
            InitializeComponent();

            _alunoId = idAluno;
            _presenter = new AlunoUDPresenter(this);

            btnAlterar.Click += (_, _) => AlterarAluno?.Invoke(this, EventArgs.Empty);
            btnExcluir.Click += (_, _) => ExcluirAluno?.Invoke(this, EventArgs.Empty);
            btnCancelar.Click += (_, _) => Cancelar?.Invoke(this, EventArgs.Empty);

            this.Load += (_, _) => CarregarAluno?.Invoke(this, EventArgs.Empty);
        }

        public void HabilitarCampos(bool habilitado)
        {
            txtNome.ReadOnly = !habilitado;
            txtEmail.ReadOnly = !habilitado;
        }

        public DialogResult ConfirmarAcao(string titulo, string mensagem)
        {
            return MessageBox.Show(titulo, mensagem, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public void ExibirMensagem(string mensagem)
        {
            MessageBox.Show(mensagem, "Mensagem");
        }

        public void Fechar()
        {
            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e) { }
        private void btnExcluir_Click(object sender, EventArgs e) { }
        private void btnCancelar_Click(object sender, EventArgs e) { }
    }
}
