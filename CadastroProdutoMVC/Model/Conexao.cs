using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace CadastroProdutoMVC.Model
{
    internal class Conexao
    {
        private string _stringConexao = @"Server=localhost;Database=loja;User Id=root;Password=Solius@123";
        public Conexao()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            // Obter a string de conexão do arquivo JSON
            _stringConexao = configuration.GetConnectionString("DefaultConnection");

            // Obter a senha do banco de dados a partir de uma variável de ambiente
            //string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD_POO2");

            if (string.IsNullOrEmpty(dbPassword))
            {
                MessageBox.Show("A senha do banco de dados não foi definida como variável de ambiente.");
                return;
            }

            // Substituir o placeholder pela senha real
            //_stringConexao = _stringConexao.Replace("{DB_PASSWORD}", dbPassword);
            _stringConexao = _stringConexao.Replace("{DB_PASSWORD_POO2}", dbPassword);
        }
        public MySqlConnection AbrirConexao()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(_stringConexao);
            mySqlConnection.Open();
            return mySqlConnection;
        }
        public void FecharConexao(MySqlConnection mySqlConnection)
        {
            mySqlConnection.Close();
        }

    }
}
