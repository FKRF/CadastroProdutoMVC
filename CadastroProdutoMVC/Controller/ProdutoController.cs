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
            if(codigo < 0)
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

    }
}
