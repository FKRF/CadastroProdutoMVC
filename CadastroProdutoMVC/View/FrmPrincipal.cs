using CadastroProdutoMVC.Controller;
using CadastroProdutoMVC.Model;

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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string codigoProdutoTexto = txtPesquisa.Text;
            if (int.TryParse(codigoProdutoTexto, out int codigoProduto))
            {
                try
                {
                    Produto produto = _produtoController.PesquisarPorCodigo(codigoProduto);
                    
                    lViewProdutos.Items.Clear();
                    ListViewItem item = new ListViewItem(produto.Codigo.ToString());
                    item.SubItems.Add(produto.Nome);
                    item.SubItems.Add(produto.Preco.ToString());
                    item.SubItems.Add(produto.Foto);
                    item.SubItems.Add(produto.Custo.ToString());
                    lViewProdutos.Items.Add(item);
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
            else
                MessageBox.Show("Insira um código válido!");
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }

        private void Excluir_Click(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {

        }
        private void DesenharListView()
        {
            lViewProdutos.View = System.Windows.Forms.View.Details;
            lViewProdutos.GridLines = true;
            lViewProdutos.Clear();

            lViewProdutos.Columns.Add("Código", 60);
            lViewProdutos.Columns.Add("Nome", 180);
            lViewProdutos.Columns.Add("Preço", 60);
            lViewProdutos.Columns.Add("Foto", 150);
            lViewProdutos.Columns.Add("Custo", 80);
            lViewProdutos.Width = lViewProdutos.Columns[0].Width + lViewProdutos.Columns[1].Width +
                lViewProdutos.Columns[2].Width + lViewProdutos.Columns[3].Width +
                lViewProdutos.Columns[4].Width;
        }
    }
}
