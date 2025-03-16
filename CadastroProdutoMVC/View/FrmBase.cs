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
            txtCodigo.KeyDown += txtCodigo_KeyDown;
        }
        private void ConfigurarFormulario()
        {
            if(_acao == Acao.Adicionar)
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
                    if (string.IsNullOrEmpty(txtNome.Text) ||
                    string.IsNullOrEmpty(txtPreco.Text) ||
                    string.IsNullOrEmpty(txtCusto.Text))
                    {
                        MessageBox.Show("Preencha todos os campos!");
                        return;
                    }
                    Produto produto = new Produto();
                    produto.Nome = txtNome.Text;
                    produto.Preco = decimal.TryParse(txtPreco.Text, out decimal precoProduto) ? precoProduto : throw new FormatException("Preço inválido!");
                    produto.Custo = decimal.TryParse(txtCusto.Text, out decimal custoProduto) ? custoProduto : throw new FormatException("Custo inválido!");
                    _produtoController.AdicionarProduto(produto);
                    MessageBox.Show("Produto cadastrado com sucesso!");
                    Close();
                }
                else if (_acao == Acao.Alterar)
                {
                    if(_produtoAtual == null)
                    {
                        MessageBox.Show("Nenhum produto foi carregado!");
                        return;
                    }
                    _produtoAtual.Nome = txtNome.Text;
                    _produtoAtual.Preco = decimal.TryParse(txtPreco.Text, out decimal precoProduto) ? precoProduto : throw new FormatException("Preço inválido!");
                    _produtoAtual.Custo = decimal.TryParse(txtCusto.Text, out decimal custoProduto) ? custoProduto : throw new FormatException("Custo inválido!");
                    _produtoController.AlterarProduto(_produtoAtual);
                    MessageBox.Show("Produto atualizado com sucesso!");
                    Close();
                }
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
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
                    txtNome.Enabled = true;
                    txtPreco.Enabled = true;
                    txtCusto.Enabled = true;
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
        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
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
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
