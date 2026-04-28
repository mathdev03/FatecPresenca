using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using FatecPresenca.Presenca;
using FatecPresenca.Presenter;
using System.Diagnostics.Eventing.Reader;

namespace FatecPresenca
{
    public partial class frmDashBoard : Form
    {
        Evento evento;


        public frmDashBoard()
        {
            InitializeComponent();

            // Colors Windows Forms Default
            this.ForeColor = Color.White;
            msMenu.ForeColor = Color.Black;


            // Windows Forms config default
            lblHorárioAtual.Text = DateTime.Now.ToString("HH:mm");

            EventoAtual();
        }

        private void EventoAtual()
        {
            EventoBD bd = new EventoBD();

            var lista = bd.carregarEventos();

            foreach (var e in lista) {
                if (e.EstaEmAndamento()) {
                    evento = e;
                    break;
                }
            }

            if (evento == null) return;

            lblNomeEvento.Text = evento.Nome;
            lblData.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void eventoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEventos evento = new frmEventos();
            evento.ShowDialog();
        }

        private void presençaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresenca presenca = new frmPresenca();
            presenca.ShowDialog();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (evento == null)
            {
                MessageBox.Show("Nenhum evento em andamento!");
                return;
            }



            frmRegistro dialog = new frmRegistro(evento.Id);
            ServicoRegistro registro = new ServicoRegistro();
            ServicoIdentificarAluno aluno = new ServicoIdentificarAluno();
            var presenter = new RegistroPresenter(dialog, registro, aluno);
            dialog.ShowDialog();
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tmrHorarioAtual_Tick(object sender, EventArgs e)
        {
            lblHorárioAtual.Text = DateTime.Now.ToString("HH:mm");

            if (evento == null) return;

            if (!evento.PodeRegistrar()) 
            { 
                lblStatusRegistro.Text = "REGISTRO FECHADO";
                lblStatusRegistro.ForeColor = Color.Red;
            }
        }

        private void lblHorarioInicio_Click(object sender, EventArgs e)
        {

        }
    }
}
