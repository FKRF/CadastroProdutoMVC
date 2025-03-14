using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CadastroProdutoMVC.Model
{
    internal class ProdutoRepositorio
    {
        private Conexao _conexao;
        public ProdutoRepositorio()
        {
            _conexao = new Conexao();
        }
        public Produto BuscarPorCodigo(int codigo)
        {
            Produto produto = null;
            MySqlConnection mySqlConexao = _conexao.AbrirConexao();
            try
            {
                string query = @"SELECT codigo, nome, preco, foto, custo
                                FROM produtos
                                WHERE codigo = @codigo";
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConexao);
                mySqlCommand.Parameters.AddWithValue("@codigo", codigo);
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    produto = new Produto();
                    produto.Codigo = reader.GetInt32(0);
                    produto.Nome = reader.GetString(1);
                    produto.Preco = reader.GetDecimal(2);
                    produto.Foto = reader.GetString(3);
                    produto.Custo = reader.GetDecimal(4);
                }
            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                mySqlConexao.Close();
            }
            return produto;
        }
    }
}
