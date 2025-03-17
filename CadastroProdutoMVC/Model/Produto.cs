using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutoMVC.Model
{
    internal class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Custo { get; set; }
        public void Validar()
        {
            var erros = new List<string>();

            // Validação do nome
            if (string.IsNullOrWhiteSpace(Nome))
                erros.Add("O nome do produto não pode estar vazio.");
            else if (Nome.Length < 3)
                erros.Add("O nome do produto deve ter pelo menos 3 caracteres.");

            // Validação do preço
            if (!decimal.TryParse(Preco.ToString(), out _))
                erros.Add("Preço inválido.");
            else if (Preco <= 0)
                erros.Add("O preço deve ser maior que zero.");

            // Validação do custo
            if (!decimal.TryParse(Custo.ToString(), out _))
                erros.Add("Custo inválido.");
            else if (Custo < 0)
                erros.Add("O custo não pode ser negativo.");

            // Se houver erros, lançar uma exceção com todas as mensagens
            if (erros.Any())
                throw new ArgumentException(string.Join("\n", erros));
        }


    }
}
