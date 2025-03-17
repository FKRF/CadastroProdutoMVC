using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroProdutoMVC.Model;
using Org.BouncyCastle.Utilities.IO;

namespace CadastroProdutoMVC.Controller
{
    
    internal class ProdutoController
    {
        private ProdutoRepositorio _produtoRepositorio;
        
        public ProdutoController()
        {
            _produtoRepositorio = new ProdutoRepositorio();
        }
        public void AdicionarProduto(Produto produto)
        {
            produto.Validar();
            bool produtoAdicionado = _produtoRepositorio.AdicionarProduto(produto);
            if (!produtoAdicionado)
                throw new InvalidOperationException("O produto não pode ser adicionado");
        }
        public void AlterarProduto(Produto produto)
        {
            if (PesquisarPorCodigo(produto.Codigo) == null)
                throw new ArgumentNullException("O produto não pode ser nulo");
            produto.Validar();
            bool produtoAlterado = _produtoRepositorio.AlterarProduto(produto);
            if (!produtoAlterado)
                throw new InvalidOperationException("O produto não pode ser alterado");
        }
        public void ExcluirProduto(int codigo)
        {
            bool produtoExcluido = _produtoRepositorio.ExcluirProduto(codigo);
            if (!produtoExcluido)
                throw new InvalidOperationException("O produto não pode ser excluído");
        }
        public Produto PesquisarPorCodigo(int codigo)
        {
            if(codigo <= 0)
            {
                throw new ArgumentOutOfRangeException("Código do produto inválido");
            }
            Produto produto = _produtoRepositorio.BuscarPorCodigo(codigo);
            if(produto == null)
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }
            return produto;
        }
        public List<Produto> PesquisarPorNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new KeyNotFoundException("Nome do produto em branco!");
            }
            List<Produto> produtos = _produtoRepositorio.BuscarPorNome(nome);
            if (!produtos.Any())
            {
                throw new KeyNotFoundException("Produto não encontrado");
            }
            return produtos;
        }
        public List<Produto> ConsultarTodosPaginado(int offset, int limit)
        {
            try
            {
                if (limit > 0)
                    return _produtoRepositorio.ConsultarTodosPaginado(offset, limit);
                else
                    throw new ArgumentException("O limite deve ser maior que zero!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar produtos: " + ex.Message);
            }
        }

    }
}
