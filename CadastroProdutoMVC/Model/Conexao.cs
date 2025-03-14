using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CadastroProdutoMVC.Model
{
    internal class Conexao
    {
        private string _stringConexao = @"Server=localhost;Database=loja;User Id=root;Password=Solius@123";
        public Conexao()
        {

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
