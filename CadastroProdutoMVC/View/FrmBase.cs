using CadastroProdutoMVC.Controller;
using CadastroProdutoMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroProdutoMVC.View
{
    public partial class FrmBase : Form
    {
        private ProdutoController _produtoController = new ProdutoController();
        public enum Acao
        {
            Adicionar,
            Alterar,
            Excluir
        }
        private Acao _acao;
        private Produto _produtoAtual;
        public FrmBase(Acao acao)
        {
            InitializeComponent();
            _acao = acao;
            ConfigurarFormulario();
            txtCodigo.KeyDown += TxtCodigo_KeyDown;
        }
        private void ConfigurarFormulario()
        {
            txtCodigo.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtPreco.Text = string.Empty;
            txtCusto.Text = string.Empty;

            if (_acao == Acao.Adicionar)
            {
                txtCodigo.Enabled = false;
                txtNome.Enabled = true;
                txtPreco.Enabled = true;
                txtCusto.Enabled = true;
            }
            if (_acao == Acao.Alterar)
            {
                txtCodigo.Enabled = true;
                txtNome.Enabled = false;
                txtPreco.Enabled = false;
                txtCusto.Enabled = false;
            }
        }
        private void Salvar()
        {
            try
            {
                if (_acao == Acao.Adicionar)
                {
                    AdicionarProduto();
                }
                else if (_acao == Acao.Alterar)
                {
                    AlterarProduto();
                }
                else if (_acao == Acao.Excluir)
                {
                    ExcluirProduto();
                }
                Close();
            }
            catch (ArgumentException ex)
            {
                // Captura de exceções específicas (como validações)
                MessageBox.Show("Erro: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                // Captura de exceções específicas (como falha na operação)
                MessageBox.Show("Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Captura de exceções gerais
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }

        }
        private void AdicionarProduto()
        {
            Produto produto = new Produto();
            produto.Nome = txtNome.Text;
            if(!decimal.TryParse(txtPreco.Text, out decimal precoProduto))
            {
                MessageBox.Show("Preço inválido!");
                return;
            }
            if (!decimal.TryParse(txtCusto.Text, out decimal custoProduto))
            {
                MessageBox.Show("custo inválido!");
                return;
            }
            produto.Preco = precoProduto;
            produto.Custo = custoProduto;

            try
            {
                produto.Validar();
                _produtoController.AdicionarProduto(produto);
                MessageBox.Show("Produto cadastrado com sucesso!");

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
        private void AlterarProduto()
        {
            if (_produtoAtual == null)
            {
                MessageBox.Show("Nenhum produto foi carregado!");
                return;
            }

            _produtoAtual.Nome = txtNome.Text;

            if (!decimal.TryParse(txtPreco.Text, out decimal precoProduto))
            {
                MessageBox.Show("Preço inválido!");
                return;
            }
            if (!decimal.TryParse(txtCusto.Text, out decimal custoProduto))
            {
                MessageBox.Show("Custo inválido!");
                return;
            }

            _produtoAtual.Preco = precoProduto;
            _produtoAtual.Custo = custoProduto;

            try
            {
                _produtoAtual.Validar(); // Validação do modelo
                _produtoController.AlterarProduto(_produtoAtual);
                MessageBox.Show("Produto atualizado com sucesso!");
            }
            catch (ArgumentException ex)
            {
                // Exibindo mensagens de erro da validação
                MessageBox.Show("Erro de validação: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Exibindo erros inesperados
                MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
            }
        }

        private void ExcluirProduto()
        {
            if (_produtoAtual == null)
            {
                MessageBox.Show("Nenhum produto foi carregado!");
                return;
            }
            txtNome.Enabled = false;
            txtPreco.Enabled = false;
            txtCusto.Enabled = false;
            try
            {
                _produtoController.ExcluirProduto(_produtoAtual.Codigo);
                MessageBox.Show("Produto excluído com sucesso!");


            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto: " + ex.Message);
            }
            
        }
        private void BuscarProduto(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCodigo.Text, out int codigoProduto))
            {
                MessageBox.Show("O código deve ser um número válido!");
                return;
            }
            try
            {
                if (codigoProduto <= 0)
                {
                    MessageBox.Show("O código deve ser um número positivo!");
                    return;
                }
                _produtoAtual = _produtoController.PesquisarPorCodigo(codigoProduto);
                if (_produtoAtual != null)
                {
                    PreencherFormulario(_produtoAtual);
                    txtNome.Enabled = !(_acao == Acao.Excluir);
                    txtPreco.Enabled = !(_acao == Acao.Excluir);
                    txtCusto.Enabled = !(_acao == Acao.Excluir);
                }
                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Erro :" + ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado: " + ex.Message);
            }
        }
        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarProduto(sender, e);
                e.SuppressKeyPress = true; // Evita o "bip" padrão do Windows ao pressionar Enter
            }
        }
        private void PreencherFormulario(Produto produto)
        {
            txtNome.Text = produto.Nome;
            txtPreco.Text = produto.Preco.ToString();
            txtCusto.Text = produto.Custo.ToString();
        }
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
