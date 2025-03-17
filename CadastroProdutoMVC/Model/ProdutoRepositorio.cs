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
            try
            {
                string query = @"SELECT codigo, nome, preco, custo
                                FROM produtos
                                WHERE codigo = @codigo";
                using(MySqlConnection mySqlConexao = _conexao.AbrirConexao())
                using(MySqlCommand mySqlComando = new MySqlCommand(query, mySqlConexao))
                {
                    mySqlComando.Parameters.AddWithValue("@codigo", codigo);

                    using MySqlDataReader reader = mySqlComando.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Produto()
                        {
                            Codigo = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Preco = reader.GetDecimal(2),
                            Custo = reader.GetDecimal(3)
                        };
                    }

                }
                    throw new KeyNotFoundException($"Produto com o código {codigo} não encontrado");
            }
            catch(MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados: " + ex.Message);
            }
        }
        public List<Produto> BuscarPorNome(string nome)
        {
            List<Produto> produtos = new List<Produto>();
            try
            {
                string query = @"SELECT codigo, nome, preco, custo
                                FROM produtos
                                WHERE nome LIKE CONCAT('%', @nome, '%')";
                using (MySqlConnection mySqlConexao = _conexao.AbrirConexao())
                using (MySqlCommand mySqlComando = new MySqlCommand(query, mySqlConexao))
                {
                    mySqlComando.Parameters.AddWithValue("@nome", nome);
                    using (MySqlDataReader reader = mySqlComando.ExecuteReader())
                        while (reader.Read())
                        {
                            produtos.Add(new Produto()
                            {
                                Codigo = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                Preco = reader.GetDecimal(2),
                                Custo = reader.GetDecimal(3)
                            });
                        }
                }
                
                if (produtos.Count == 0)
                    throw new KeyNotFoundException($"Nenhum produto encontrado");
                return produtos;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados: " + ex.Message);
            }
        }
        public bool AdicionarProduto(Produto produto)
        {
            try
            {
                string query = @"INSERT INTO produtos(nome, preco, custo)
                                 VALUES(@nome, @preco, @custo)";
                using (MySqlConnection mySqlConexao = _conexao.AbrirConexao())
                using (MySqlCommand mySqlComando = new MySqlCommand(query, mySqlConexao))
                {
                    mySqlComando.Parameters.AddWithValue("@nome", produto.Nome);
                    mySqlComando.Parameters.AddWithValue("@preco", produto.Preco);
                    mySqlComando.Parameters.AddWithValue("@custo", produto.Custo);
                    int linhasAfetadas = mySqlComando.ExecuteNonQuery();
                    if (linhasAfetadas > 0)
                        return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado: " + ex.Message);
            }
        }
        public bool AlterarProduto(Produto produto)
        {
            try
            {
                string query = @"UPDATE produtos
                                 SET nome = @nome, preco = @preco, custo = @custo
                                 WHERE codigo = @codigo";
                using (MySqlConnection mySqlConexao = _conexao.AbrirConexao())
                {
                    using (MySqlCommand mySqlComando = new MySqlCommand(query, mySqlConexao))
                    {
                        mySqlComando.Parameters.AddWithValue("@codigo", produto.Codigo);
                        mySqlComando.Parameters.AddWithValue("@nome", produto.Nome);
                        mySqlComando.Parameters.AddWithValue("@preco", produto.Preco);
                        mySqlComando.Parameters.AddWithValue("@custo", produto.Custo);
                        int linhasAfetadas = mySqlComando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                            return true;
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado: " + ex.Message);
            }
        }
        public bool ExcluirProduto(int codigo)
        {
            try
            {
                string query = @"DELETE FROM produtos WHERE codigo = @codigo";
                using (MySqlConnection mySqlConexao = _conexao.AbrirConexao())
                {
                    using (MySqlCommand mySqlComando = new MySqlCommand(query, mySqlConexao))
                    {
                        mySqlComando.Parameters.AddWithValue("@codigo", codigo);
                        int linhasAfetadas = mySqlComando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                            return true;
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Erro ao acessar o banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado: " + ex.Message);
            }
        }
    }
}
