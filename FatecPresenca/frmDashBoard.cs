using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using FatecPresenca.Presenca;
using FatecPresenca.Presenter;
using System.Diagnostics.Eventing.Reader;

namespace FatecPresenca
{
    public partial class frmDashBoard : Form, DashboardView
    {
        public event EventHandler CarregarEvento;
        public event EventHandler AbrirEventos;
        public event EventHandler AbrirPresenca;
        public event EventHandler ClicarRegistrar;
        public event EventHandler ClicarSair;
        public event EventHandler TickHorario;
        public event EventHandler<int>? EventoSelecionado;

        private readonly DashboardPresenter _presenter;

        public string NomeEvento { set => lblNomeEvento.Text = value; }
        public string Data { set => lblData.Text = value; }
        public string HorarioInicio { set => lblHorarioInicio.Text = value; }
        public string HorarioFinal { set => lblHorarioFinal.Text = value; }
        public string HorarioAtual { set => lblHorarioAtual.Text = value; }
        public string StatusRegistroText { set => lblStatusRegistro.Text = value; }
        public Color StatusRegistroForeColor { set => lblStatusRegistro.ForeColor = value; }
        public int EventoId { get { 
                if(cmbEventos.SelectedItem is Evento evento)
                    return (int)evento.Id;
                return 0;
            } }

        public frmDashBoard()
        {
            InitializeComponent();

            //this.ForeColor = Color.White;
            msMenu.ForeColor = Color.Black;

            lblHorarioAtual.Text = DateTime.Now.ToString("HH:mm");
            dgvDadosRegistro.Columns.Clear();

            _presenter = new DashboardPresenter(this);

            this.Load += (_, _) => CarregarEvento?.Invoke(this, EventArgs.Empty);
            eventoToolStripMenuItem.Click += (_, _) => AbrirEventos?.Invoke(this, EventArgs.Empty);
            presençaToolStripMenuItem.Click += (_, _) => AbrirPresenca?.Invoke(this, EventArgs.Empty);
            btnRegistrar.Click += (_, _) => ClicarRegistrar?.Invoke(this, EventArgs.Empty);
            btnSair.Click += (_, _) => ClicarSair?.Invoke(this, EventArgs.Empty);
            tmrHorarioAtual.Tick += (_, _) => TickHorario?.Invoke(this, EventArgs.Empty);

            // Escolhendo os eventos
            cmbEventos.SelectedIndexChanged += (s, e) =>
            {
                if (cmbEventos.SelectedItem is EventoDTO dto)
                {
                    EventoSelecionado?.Invoke(this, dto.id);
                }
            };
        }

        public void MostrarMensagem(string mensagem)
        {
            MessageBox.Show(mensagem);
        }

        public void AbrirFormRegistro(int idEvento)
        {
            var dialog = new frmRegistro(idEvento);
            var servicoRegistro = new ServicoRegistro();
            var servicoIdentificarAluno = new ServicoIdentificarAluno();
            var servicoAluno = new ServicoAluno();

            var registroPresenter = new RegistroPresenter(dialog, servicoRegistro, servicoIdentificarAluno, servicoAluno);
            dialog.ShowDialog();
        }

        public void ObterEventos(List<EventoDTO> ev)
        {

            cmbEventos.DataSource = ev;
            cmbEventos.DisplayMember = "Nome";
            cmbEventos.ValueMember = "id";
        }

        public void TabelaAlunos(IEnumerable<DashboardDTO> dto)
        {
            dgvDadosRegistro.DataSource = null;
            dgvDadosRegistro.DataSource = dto;
        }

        public void FecharForm()
        {
            this.Close();
        }

        private void eventoToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void presençaToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void btnRegistrar_Click(object sender, EventArgs e) { }
        private void btnSair_Click(object sender, EventArgs e) { }
        private void tmrHorarioAtual_Tick(object sender, EventArgs e) { }
    }
}
