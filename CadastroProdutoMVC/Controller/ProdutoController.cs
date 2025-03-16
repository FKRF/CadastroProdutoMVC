using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadastroProdutoMVC.Model;

namespace CadastroProdutoMVC.Controller
{
    
    internal class ProdutoController
    {
        private ProdutoRepositorio _produtoRepositorio;
        
        public ProdutoController()
        {
            _produtoRepositorio = new ProdutoRepositorio();
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
        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
                throw new ArgumentNullException("O produto não pode ser nulo");
            if(produto.Nome == string.Empty)
                throw new ArgumentException("O nome do produto não pode estar vazio");
            if(produto.Preco <= 0)
                throw new ArgumentOutOfRangeException("O preço do produto tem de ser maior que zero");
            if (produto.Custo <= 0)
                throw new ArgumentOutOfRangeException("O custo do produto tem de ser maior que zero");
            bool produtoAdicionado = _produtoRepositorio.AdicionarProduto(produto);
            if (!produtoAdicionado)
                throw new InvalidOperationException("O produto não pode ser adicionado");
        }
        public void AlterarProduto(Produto produto)
        {
            if(PesquisarPorCodigo(produto.Codigo) == null)
                throw new ArgumentNullException("O produto não pode ser nulo");
            if (produto.Nome == string.Empty)
                throw new ArgumentException("O nome do produto não pode estar vazio");
            if (produto.Preco <= 0)
                throw new ArgumentOutOfRangeException("O preço do produto tem de ser maior que zero");
            if (produto.Custo <= 0)
                throw new ArgumentOutOfRangeException("O custo do produto tem de ser maior que zero");
            bool produtoAlterado = _produtoRepositorio.AlterarProduto(produto);
            if (!produtoAlterado)
                throw new InvalidOperationException("O produto não pode ser adicionado");
        }

    }
}
