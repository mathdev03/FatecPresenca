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
    public partial class frmAlterarAluno : Form
    {
        Aluno aluno;

        public frmAlterarAluno(int idAluno)
        {
            InitializeComponent();

            pegarAluno(idAluno);
        }

        private async void pegarAluno(int id)
        {
            AlunoBD db = new AlunoBD();

            aluno = await db.buscarAluno(id);

            txtNome.Text = aluno.getNome();
            txtEmail.Text = aluno.getEmail();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAlterar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"ALUNO: {aluno.getNome()}", "Deseja realmente alterar o aluno?", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            AlunoBD bd = new AlunoBD();

            string nome = txtNome.Text.ToUpper();
            string email = txtEmail.Text;

            Aluno novoAluno = new Aluno(aluno.getId(), nome, email);

            if (!await bd.alterarAluno(novoAluno)) return;

            MessageBox.Show("Alterado com sucesso!", "Messagem");
            this.Close();
        }
    }
}
