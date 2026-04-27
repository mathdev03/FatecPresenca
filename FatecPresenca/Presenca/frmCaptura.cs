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
    public partial class frmCaptura : Form
    {
        public event EventHandler<EventoTemporario> dadosTemplate;

        public class EventoTemporario
        {
            public int qualidade { get; set; }

            public byte[] template { get; set; }
            public Bitmap image { get; set; }
        }

        private int qualidade = 0, finger = 0, escolha = 0;
        private Bitmap image = null;
        private byte[] template = null;
        private string nome = string.Empty;

        public frmCaptura(int escolha, int finger)
        {
            InitializeComponent();

            this.finger = finger;
            this.escolha = escolha;
        }

        public frmCaptura(int finger, int escolha, string nome)
        {
            this.finger = finger;
            this.escolha = escolha;
            this.nome = nome;
        }

        private void Registro()
        {
            FTRScan scan = new FTRScan();

            if (!scan.OpenDevice())
            {
                MessageBox.Show("Dispositivo não ligado!", "Erro ao ligar");
                return;
            }

            //lblStatus.Text = "ESPERE...";
            scan.RegisterBiometric(finger);

            qualidade = scan.getQuality();
            template = scan.getTemplate();
            image = scan.getImage();

            scan.CloseDevice();
        }

        private void Verificar()
        {
            
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (dadosTemplate == null) return;

            var data = new EventoTemporario
            {
                qualidade = this.qualidade,
                template = this.template,
                image = this.image
            };

            dadosTemplate(this, data);
        }

        private async void frmCaptura_Shown(object sender, EventArgs e)
        {
            await assicronizarDados();
            this.Close();
        }

        private async Task assicronizarDados()
        {
            switch (escolha)
            {
                case 1:
                    await Task.Run(() => Registro());
                    break;
            }
        }
    }
}
