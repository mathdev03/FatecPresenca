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
    public partial class frmExcluirAluno : Form
    {
        Aluno aluno;

        public frmExcluirAluno(int id)
        {
            InitializeComponent();

            pegarAluno(id);
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

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"ALUNO: {aluno.getNome()}", "Deseja realmente deletar o aluno?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No) return;

            AlunoBD bd = new AlunoBD();

            if (!await bd.deletarAluno(aluno.getId())) return;

            MessageBox.Show("Excluido com sucesso!", "Messagem");
            this.Close();
        }
    }
}
