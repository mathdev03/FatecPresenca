using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatecPresenca.Models
{
    internal class Template
    {
        private int id;
        private int idUser;
        private byte[] template;
        private int finger;
        private int qualidade;

        public Template(byte[] template, int idUser, int finger, int qualidade) {

            if (verificarQualidade(qualidade)) {
                MessageBox.Show("Qualidade Baixa! Tente novamente", "Aviso");
                return;
            }
            this.template = template;
            this.idUser = idUser;
            this.finger = finger;
            this.qualidade = qualidade; 
        }

        public Template(int id, byte[] template, int idUser, int finger, int qualidade)
        {
            if (verificarQualidade(qualidade))
            {
                MessageBox.Show("Qualidade Baixa! Tente novamente", "Aviso");
                return;
            }
            this.id = id;
            this.template = template;
            this.idUser = idUser;
            this.finger = finger;
            this.qualidade = qualidade;
        }

        private bool verificarQualidade(int qualidade) {
            if (qualidade < 0 && qualidade > 100) return true;
            if(qualidade <= 20) return true;

            return false;
        }


        public int getId() => id;
        public byte[] getTemplate() => template;

        public int getIdUser() => idUser;

        public int getFinger() => finger;

        public int getQualidade() => qualidade;
    }
}
