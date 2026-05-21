using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;


namespace FatecPresenca.DAO
{
    internal class Conexao
    {
        private readonly string __conexao;
        public Conexao() {

            __conexao = "Server=localhost;" +
                        "Port=3306;" +
                        "Database=fatecpresenca;" +
                        "Uid=root;" +
                        "Pwd=";
        }

        public MySqlConnection getConexao()
        {
            var conexaoConnection = new MySqlConnection(__conexao);

            //if (conexaoConnection.State == ConnectionState.Closed) 
            //    throw new ArgumentException("Conexão não aberta!");

            return conexaoConnection;
        }
    }
}
