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

namespace FatecPresenca.Eventos
{
    public partial class frmAlterarEvento : Form
    {
        Evento ev;
        bool excluir = false;

        public frmAlterarEvento(int idEvento, bool exclusao)
        {
            InitializeComponent();

            verificarExclusao(exclusao);

            carregarEvento(idEvento);
        }


        private void verificarExclusao(bool ex) {
            if (!ex) return;

            lblTituloJanela.Text = "EXCLUIR EVENTO";
            btnAlterar.Text = "Excluir";

            txtTitulo.Enabled = false;
            txtDescricao.Enabled = false;
            mtxDataInicio.Enabled = false;
            mtxDataFinal.Enabled = false;
            mtxHorarioInicio.Enabled = false;
            mtxHorarioFinal.Enabled = false;
            mtxEntradaInicio.Enabled = false;
            mtxEntradaFinal.Enabled = false;
            mtxSaidaInicio.Enabled = false;
            mtxSaidaFinal.Enabled = false;

            excluir = true;
        }

        private void carregarEvento(int id) {
            EventoBD bd = new EventoBD();

            ev = bd.buscarEvento(id);

            txtTitulo.Text = ev.Nome;
            txtDescricao.Text = ev.Descricao;
            mtxDataInicio.Text = ev.Periodo.inicio.ToString("dd/MM/yyyy");
            mtxDataFinal.Text = ev.Periodo.fim.ToString("dd/MM/yyyy");
            mtxHorarioInicio.Text = ev.Periodo.inicio.ToString("HH:mm");
            mtxHorarioFinal.Text = ev.Periodo.fim.ToString("HH:mm");

            mtxEntradaInicio.Text = ev.Janela.EntradaInicio.ToString("HH:mm");
            mtxEntradaFinal.Text = ev.Janela.EntradaFim.ToString("HH:mm");
            mtxSaidaInicio.Text = ev.Janela.SaidaInicio.ToString("HH:mm");
            mtxSaidaFinal.Text = ev.Janela.SaidaFim.ToString("HH:mm");
        }

        private DateTime conseguirData(string data, string hora)
        {
            DateTime.TryParseExact(data, "dd/MM/yyyy",
                null, System.Globalization.DateTimeStyles.None, out DateTime soData);

            DateTime.TryParseExact(hora, "HH:mm",
                null, System.Globalization.DateTimeStyles.None, out DateTime soHora);

            return soData.Date + soHora.TimeOfDay;
        }

        private TimeOnly conseguirHorario(string hora)
        {
            TimeOnly.TryParseExact(hora, "HH:mm",
                null, System.Globalization.DateTimeStyles.None, out TimeOnly soHora);

            return soHora;
        }

        private void AlterarDados()
        {
            try
            {
                var novoPeriodo = new PeriodoEvento(
                    inicio: conseguirData(mtxDataInicio.Text, mtxHorarioInicio.Text),
                    fim: conseguirData(mtxDataFinal.Text, mtxHorarioFinal.Text)
                );

                var novaJanela = new JanelaPresenca(
                    entradaInicio: conseguirHorario(mtxEntradaInicio.Text),
                    entradaFim: conseguirHorario(mtxEntradaFinal.Text),
                    saidaInicio: conseguirHorario(mtxSaidaInicio.Text),
                    saidaFim: conseguirHorario(mtxSaidaFinal.Text)
                );


                var novoEvento = new Evento(
                    nome: txtTitulo.Text,
                    descricao: txtDescricao.Text,
                    novoPeriodo,
                    novaJanela,
                    id: ev.Id
                    );

                EventoBD db = new EventoBD();
                db.alterarEvento(novoEvento);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("Alterado com sucesso!");

            this.Close();
        }

        private void excluirDados()
        {
            if (MessageBox.Show("Deseja realmente excluir evento?", "QUESTÃO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;


            try
            {
                EventoBD bd = new EventoBD();

                bd.excluirEvento(ev.Id);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

            if (excluir) { 
                excluirDados();
                return;
            }

            AlterarDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
