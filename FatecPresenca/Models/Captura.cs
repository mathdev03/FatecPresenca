using FatecPresenca.Presenca;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Models
{
    internal class Captura
    {
        private int qualidade;
        private Bitmap image;
        private List<Template> templates = new List<Template>();
        private FTRScan dispositivo;

        private List<int> idAtualizado = new List<int>();

        public Captura()
        {

        }

        public Captura(List<Template> listas)
        {
            this.templates = listas;
        }

        public bool pegar(int idUser, int finger)
        {
            dispositivo = new FTRScan();

            if (!dispositivo.OpenDevice()) return true;

            MessageBox.Show("Registrando....");

            dispositivo.RegisterBiometric(finger);

            image = dispositivo.getImage();
            qualidade = dispositivo.getQuality();

            Template template = new Template(dispositivo.getTemplate(), idUser, finger, qualidade);

            if (template.getQualidade() == 0) return true;

            dispositivo.CloseDevice();

            templates.Add(template);

            return false;
        }

        public bool atualizar(int finger)
        {
            dispositivo = new FTRScan();

            // Pega a digital
            if (!dispositivo.OpenDevice()) return true;

            MessageBox.Show("Registrando....");

            dispositivo.RegisterBiometric(finger);

            image = dispositivo.getImage();
            qualidade = dispositivo.getQuality();

            // Pega os templates não atualizados!
            var existente = templates.FirstOrDefault(t => !idAtualizado.Contains(t.getId()));

            int id = existente.getId();
            int idUser = existente.getIdUser();

            var templateNovo = new Template(id, dispositivo.getTemplate(), idUser, finger, qualidade);

            dispositivo.CloseDevice();

            if (templateNovo.getQualidade() == 0) return true;


            // Substitui o templates!
            int index = templates.IndexOf(existente);
            if (index != -1)
            {
                templates[index] = templateNovo;
                idAtualizado.Add(id);
            };

            return false;
        }

        public bool verificar() {
            dispositivo = new FTRScan();

            if (!dispositivo.OpenDevice()) return true;

            MessageBox.Show("Verificando...");

            List<int> numeros = new List<int>();

            foreach (var t in templates)
            {
                float num = dispositivo.VerifyBiometric(t.getTemplate(), t.getFinger());

                //Thread.Sleep(2000);

                if (num < 146)
                {
                    numeros.Add(0);
                }
                else numeros.Add(1);
            }

            int uns = numeros.Count(n => n == 1);
            int zeros = numeros.Count(n => n == 0);

            return !(uns > zeros);
        }

        public async Task<List<Template>> identificar(List<Template> templates, CancellationTokenSource c = default)
        {
            List<Template> temps = new List<Template>();
            dispositivo = new FTRScan();

            if (!dispositivo.OpenDevice()) return null;

            MessageBox.Show("Identificando!");


            if (await dispositivo.takeBiometricIdentify(c))
            {
                foreach (var t in templates)
                {
                    var count = dispositivo.IdentifyBiometric(t.getTemplate());

                    if (count > 180)
                    {
                        temps.Add(t);
                    }
                }
            }

            return temps;
        }


        public List<Template> getTemplates() {

            if (templates.Count < 3) {
                MessageBox.Show("Insira todas as digitais!", "Aviso");
                return null;
            }

            return templates;
        }
        public Bitmap getImagem() => image;
        public int getQualidade() => qualidade;
    }
}
