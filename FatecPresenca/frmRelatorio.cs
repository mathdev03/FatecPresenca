using FatecPresenca.Models;
using FatecPresenca.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatecPresenca
{
    public partial class frmRelatorio : Form, RelatorioView
    {
        public event EventHandler? CarregarEvento;
        public event EventHandler? ClicarSair;
        public event EventHandler<string>? TextoPesquisaAlterado;
        public event EventHandler<int>? EventoSelecionado;
        public event EventHandler<string>? EventoDataSelecionado;

        private readonly RelatorioPresenter _presenter;

        public string TotalAluno { set => lblStatusAlunos.Text = value; }
        public string TotalAlunoPresente { set => lblContagemPresentes.Text = value; }
        public string TotalAlunoAusente { set => lblContagemAusentes.Text = value; }
        public int EventoId
        {
            get
            {
                if (cmbEvento.SelectedItem is Evento evento)
                    return (int)evento.Id;
                return 0;
            }
        }

        public frmRelatorio()
        {
            InitializeComponent();

            _presenter = new RelatorioPresenter(this);
            dgvDadosRegistro.Columns.Clear();


            this.Load += (_, _) => CarregarEvento?.Invoke(this, EventArgs.Empty);
            btnConcluir.Click += (_, _) => ClicarSair?.Invoke(this, EventArgs.Empty);
            cmbEvento.SelectedIndexChanged += (s, e) =>
            {
                if (cmbEvento.SelectedItem is RelatorioEventoDTO dto)
                {
                    EventoSelecionado?.Invoke(this, dto.Id);
                }
            };
            cmbDataEvento.SelectedIndexChanged += (s, e) =>
            {
                if (cmbDataEvento.SelectedItem is RelatorioEventoDataDTO dto)
                {
                    EventoDataSelecionado?.Invoke(this, dto.data);
                }
            };
            txtPesquisar.TextChanged += (_, _) => TextoPesquisaAlterado?.Invoke(this, txtPesquisar.Text);
        }

        public void obterEventos(List<RelatorioEventoDTO> dto)
        {
            cmbEvento.DataSource = dto;
            cmbEvento.DisplayMember = "Nome";
            cmbEvento.ValueMember = "id";
        }

        public void obterEventosData(List<RelatorioEventoDataDTO> dto)
        {
            cmbDataEvento.DataSource = dto;
            cmbDataEvento.DisplayMember = "data";
            cmbDataEvento.ValueMember = "data";
        }

        public void tabelaAlunos(List<RelatorioDTO> dto)
        {
            dgvDadosRegistro.DataSource = null;
            dgvDadosRegistro.DataSource = dto;
        }

        public void FecharForm()
        {
            this.Close();
        }
    }
}
