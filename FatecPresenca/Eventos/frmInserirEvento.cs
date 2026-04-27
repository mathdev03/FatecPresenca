using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FatecPresenca.DAO;
using FatecPresenca.Models;

namespace FatecPresenca.Eventos
{
    public partial class frmInserirEvento : Form
    {
        public frmInserirEvento()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnInserir_Click(object sender, EventArgs e)
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
                    novaJanela
                    );

                EventoBD db = new EventoBD();
                db.inserirEvento(novoEvento);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("Inserido com sucesso!");
            this.Close();
        }
    }
}
