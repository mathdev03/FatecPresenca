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
using System.Windows.Forms.VisualStyles;
using static FatecPresenca.Presenca.frmCaptura;

/*
 13/03/2026 - Fiz assincronização com um form temporário para pegar templates dos alunos...
 não só isso! Também fiz uma classe publica para obter o evento de pegar os dados do template para depois
 salvar facilmente.
 
 */

namespace FatecPresenca.Presenca
{
    public partial class frmBiometria : Form
    {
        Captura captura = new Captura();
        private Aluno aluno;
        private int finger = 0;
        private bool update = false;

        public frmBiometria(string id)
        {
            InitializeComponent();

            lblStatus.Text = "Não Coletado";
            btnCapturaDois.Enabled = false;
            btnCapturaTres.Enabled = false;
            btnCadastrar.Enabled = false;
            btnVerificar.Enabled = false;

            lblQualidadeUm.Text = "0%";
            lblQualidadeDois.Text = "0%";
            lblQualidadeTres.Text = "0%";

            TemplateBD db = new TemplateBD();

            var listas = db.buscarTemplate(Convert.ToInt32(id));

            if (listas != null)
            {
                lblStatus.Text = "Coletado";

                captura = new Captura(listas);
                btnCadastrar.Text = "Recadastrar";
                update = true;
                btnVerificar.Enabled = true;
            }

            pegarAluno(Convert.ToInt32(id));
        }

        private async void pegarAluno(int id)
        {
            AlunoBD db = new AlunoBD();

            aluno = await db.buscarAluno(id);

            lblNomeAluno.Text = aluno.getNome();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int escolherFinger()
        {
            if (cmbPosicaoDedo.SelectedIndex == -1)
            {
                MessageBox.Show("Dedo não selecionado!");
                return 0;
            }

            string dedo = cmbPosicaoDedo.SelectedItem.ToString();

            return dedo switch
            {
                "Polegar Direito" => 1,
                "Indicador Direito" => 2,
                "Anelar Direito" => 3,
                "Médio Direito" => 4,
                "Minimo Direito" => 5,
                "Polegar Esquerdo" => 6,
                "Indicador Esquerdo" => 7,
                "Anelar Esquerdo" => 8,
                "Médio Esquerdo" => 9,
                "Minimo Esquerdo" => 10,
                _ => 0
            };
        }

        private void btnCapturaUm_Click(object sender, EventArgs e)
        {
            finger = escolherFinger();
            if (finger == 0) return;
            if (update)
            {
                if (captura.atualizar(finger)) return;
                btnVerificar.Enabled = false;
            }
            else
            {
                if (captura.pegar(aluno.getId(), finger)) return;
            }

            lblQualidadeUm.Text = $"{captura.getQualidade()}%";
            picCapturaUm.Image = captura.getImagem();
            btnCapturaUm.Enabled = false;
            btnCapturaDois.Enabled = true;
        }

        private void btnCapturaDois_Click(object sender, EventArgs e)
        {
            finger = escolherFinger();
            if (finger == 0) return;

            if (update)
            {
                if (captura.atualizar(finger)) return;
            }
            else
            {
                if (captura.pegar(aluno.getId(), finger)) return;
            }

            lblQualidadeDois.Text = $"{captura.getQualidade()}%";
            picCapturaDois.Image = captura.getImagem();
            btnCapturaDois.Enabled = false;
            btnCapturaTres.Enabled = true;
        }

        private void btnCapturaTres_Click(object sender, EventArgs e)
        {
            finger = escolherFinger();
            if (finger == 0) return;

            if (update)
            {
                if (captura.atualizar(finger)) return;
            }
            else
            {
                if (captura.pegar(aluno.getId(), finger)) return;
            }

            lblQualidadeTres.Text = $"{captura.getQualidade()}%";
            picCapturaTres.Image = captura.getImagem();
            btnCapturaTres.Enabled = false;
            btnCadastrar.Enabled = true;
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            var lista = captura.getTemplates();

            TemplateBD bd = new TemplateBD();

            if (update)
            {
                if (!bd.alterarTemplate(lista)) MessageBox.Show("Digtais atualizados!", "Aviso");
                this.Close();
                return;
            }

            int entradas = await bd.inserirTemplates(lista);
            MessageBox.Show("Digtais cadastrados");
            this.Close();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            if (captura.verificar()) return;
            MessageBox.Show("Verificado com Sucesso!", "AVISO");
        }
    }
}
