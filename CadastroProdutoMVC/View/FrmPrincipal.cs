using CadastroProdutoMVC.Controller;
using CadastroProdutoMVC.Model;
using CadastroProdutoMVC.View;
using System.Security.Cryptography;

namespace CadastroProdutoMVC
{
    public partial class FrmPrincipal : Form
    {
        ProdutoController _produtoController;
        public FrmPrincipal()
        {
            InitializeComponent();
            DesenharListView();
            _produtoController = new ProdutoController();
        }

        private void BtnPesquisar_Click(object sender, EventArgs e)
        {
            lViewProdutos.Items.Clear();
            List<Produto> produtos;
            string textoPequisa = txtPesquisa.Text;
            try
            {
                if (int.TryParse(textoPequisa, out int codigoProduto))
                {
                    var produto = (_produtoController.PesquisarPorCodigo(codigoProduto));
                    produtos = new List<Produto> { produto };
                }
                else
                {
                    produtos = _produtoController.PesquisarPorNome(textoPequisa);
                }
                
                foreach (var produto in produtos)
                {
                    ListViewItem item = new ListViewItem(produto.Codigo.ToString());
                    item.SubItems.Add(produto.Nome);
                    item.SubItems.Add(produto.Preco.ToString());
                    item.SubItems.Add(produto.Custo.ToString());
                    lViewProdutos.Items.Add(item);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado " + ex.Message);
            }
        }
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            FrmBase frmBase = new FrmBase(FrmBase.Acao.Adicionar);
            frmBase.ShowDialog();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            FrmBase frmBase = new FrmBase(FrmBase.Acao.Alterar);
            frmBase.ShowDialog();
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            FrmBase frmBase = new FrmBase(FrmBase.Acao.Excluir);
            frmBase.ShowDialog();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DesenharListView()
        {
            lViewProdutos.View = System.Windows.Forms.View.Details;
            lViewProdutos.GridLines = true;
            lViewProdutos.Clear();

            lViewProdutos.Columns.Add("Código", 60);
            lViewProdutos.Columns.Add("Nome", 180);
            lViewProdutos.Columns.Add("Preço", 60);
            lViewProdutos.Columns.Add("Custo", 80);
            lViewProdutos.Width = lViewProdutos.Columns[0].Width + lViewProdutos.Columns[1].Width +
                lViewProdutos.Columns[2].Width + lViewProdutos.Columns[3].Width;
        }
    }
}
