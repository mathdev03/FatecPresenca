using FatecPresenca.DAO;
using FatecPresenca.Models;
using FatecPresenca.Models.Servico;
using FatecPresenca.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FatecPresenca
{
    public partial class frmRegistro : Form
    {
        public int idEvento = 0;

        public event EventHandler? carregarLista;
        public event EventHandler? iniciarLeitura;
        public event EventHandler? fimLeitura;
        public event EventHandler? fecharJanela;

        public frmRegistro(int idEvento)
        {
            InitializeComponent();
            dgvDadosRegistro.Columns.Clear();
            this.idEvento = idEvento;
            this.Load += (_, _) => carregarLista?.Invoke(this, EventArgs.Empty);

            btnIniciarIdent.Click += (_, _) => iniciarLeitura?.Invoke(this, EventArgs.Empty);
            btnPararIdent.Click += (_, _) => fimLeitura?.Invoke(this, EventArgs.Empty);
            btnConcluir.Click += (_, _) => fecharJanela?.Invoke(this, EventArgs.Empty);
        }

        public void HabilitarCancelar(bool habilitado)
        {
            if (InvokeRequired)
                Invoke(() => btnPararIdent.Enabled = habilitado);
            else
                btnPararIdent.Enabled = habilitado;
        }

        public void MostrarNome(string name)
        {
            lblNomeAluno.Text = name;
        }

        public void MensagemStatus(bool status, string mensagem)
        {
            if (status)
            {
                lblStatusPresenca.Text = mensagem;
                lblStatusPresenca.ForeColor = Color.Green;
            }
            else
            {
                lblStatusPresenca.Text = mensagem;
                lblStatusPresenca.ForeColor = Color.Red;
            }
        }

        public void AtualizarTabela(IEnumerable<RegistroDTO> dados)
        {
            dgvDadosRegistro.DataSource = null;
            dgvDadosRegistro.DataSource = dados;
        }
    }
}
