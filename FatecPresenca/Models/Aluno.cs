using FatecPresenca.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FatecPresenca.Models
{
    internal class Aluno
    {
        private int id;
        private string nome;
        private string email;

        // Cadastro
        public Aluno(string nome, string email)
        {
            if (!verificarEmail(email)) {
                MessageBox.Show("Email inválido!", "Aviso!");
                return;
            }

            this.nome = nome;
            this.email = email;
        }

        // Identificação/Alteração/Exclusão
        public Aluno(int id, string nome, string email)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
        }

        private bool verificarEmail(string email) {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public string getNome()
        {
            return nome;
        }

        public string getEmail()
        {
            return email;
        }

        public int getId() { return id; }
    }
}
