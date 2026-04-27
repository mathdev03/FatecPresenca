using FatecPresenca.DAO;
using FatecPresenca.Eventos;
using FatecPresenca.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FatecPresenca
{
    public partial class frmEventos : Form
    {
        Evento evento;

        // Teste..
        private readonly BindingSource binding;
        private List<Evento> eventos;

        public frmEventos()
        {
            InitializeComponent();


            configDgv();
            recarregarLista();
        }

        private void configDgv()
        {
            //dgvDadosRegistro.AutoGenerateColumns = false;
            //dgvDadosRegistro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgvDadosRegistro.ReadOnly = true;
            //dgvDadosRegistro.AllowUserToAddRows = false;

            dgvDadosRegistro.Columns.Clear();
        }

        private void recarregarLista()
        {
            try
            {
                EventoBD bd = new EventoBD();

                eventos = bd.carregarEventos();

                var lista = eventos.Select(
                    e => new
                    {
                        e.Id,
                        Nome = e.Nome,
                        Descricao = e.Descricao,
                        DTInicio = e.Periodo.inicio.ToString("dd/MM/yyyy"),
                        DTFinal = e.Periodo.fim.ToString("dd/MM/yyyy")
                    }
                ).ToList();

                dgvDadosRegistro.DataSource = null;
                dgvDadosRegistro.DataSource = lista;

                if (dgvDadosRegistro.Columns[0] == null) return;

                dgvDadosRegistro.Columns[0].Visible = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Falha ao carregar o banco! {ex.Message}", "Aviso", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.DialogResult = DialogResult.Abort;

                if (this.InvokeRequired) this.Invoke(new Action(() => this.Close()));

                this.Close();
            }
        }

        // Não implementado!

        private void btnInserir_Click(object sender, EventArgs e)
        {
            frmInserirEvento inserir = new frmInserirEvento();
            inserir.ShowDialog();

            recarregarLista();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            frmAlterarEvento alterar = new frmAlterarEvento(evento.Id, false);
            alterar.ShowDialog();

            recarregarLista();
        }

        private void btnConcluir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Mostrar na tela as informações do evento

        private void dgvDadosRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDadosRegistro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            if (int.TryParse(dgvDadosRegistro.Rows[e.RowIndex].Cells[0].Value?.ToString(), out int idSelecionado))
            {

                Evento eventoSelecionado = eventos.FirstOrDefault(ev => ev.Id == idSelecionado);

                if (eventoSelecionado == null) return;

                // Mensagem

                evento = eventoSelecionado;

                lblNomeEvento.Text = eventoSelecionado.Nome;
                lblDescricao.Text = eventoSelecionado.Descricao;
                if (eventoSelecionado.EstaEmAndamento())
                {
                    lblStatus.Text = "Ativo";
                }
                else
                {
                    lblStatus.Text = "Inativo";
                }
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            frmAlterarEvento excluir = new frmAlterarEvento(evento.Id, true);
            excluir.ShowDialog();

            recarregarLista();
        }
    }
}
