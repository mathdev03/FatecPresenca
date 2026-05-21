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
        public int id { get; }
        public string nome { get; }
        public string email { get; }

        // Cadastro
        public Aluno(string nome, string email, int id = 0)
        {
            if (!verificarCampoVazio(nome, email))
                throw new ArgumentException("Campos Vazios!");

            if (!verificarEmail(email))
                throw new ArgumentException("Email inválido!");

            this.id = id;
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


        private bool verificarCampoVazio(string nome, string email)
        {
            if (string.IsNullOrWhiteSpace(nome) ||
                string.IsNullOrEmpty(email))
                return false;

            return true;
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
