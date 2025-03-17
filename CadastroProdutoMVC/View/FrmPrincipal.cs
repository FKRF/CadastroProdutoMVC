using CadastroProdutoMVC.Controller;
using CadastroProdutoMVC.Helpers;
using CadastroProdutoMVC.Model;
using CadastroProdutoMVC.View;
using System.Collections;
using System.Security.Cryptography;

namespace CadastroProdutoMVC
{
    public partial class FrmPrincipal : Form
    {
        ProdutoController _produtoController;
        // Variáveis de controle da listView
        private int offset = 0;
        private const int limit = 50;
        private bool _lViewCarregando = false;
        public FrmPrincipal()
        {
            InitializeComponent();
            DesenharListView();
            _produtoController = new ProdutoController();
            lViewProdutos.MouseWheel += LviewProdutos_MouseWheel;
            lViewProdutos.ColumnClick += LViewProdutos_ColumnClick;
            progressBarLView.Visible = false;
            progressBarLView.Style = ProgressBarStyle.Marquee;
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
            lViewProdutos.Height = 250;
        }
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            MostrarTodos();
        }
        private async void MostrarTodos()
        {
            _lViewCarregando = false;
            offset = 0;
            lViewProdutos.Items.Clear();
            
            await PreencherListView();
        }
        private async Task PreencherListView()
        {
            if (_lViewCarregando) // evita chamar o método várias vezes
                return;
            _lViewCarregando = true;
            progressBarLView.Visible = true;
            
            List<Produto> produtos = await Task.Run( () => _produtoController.ConsultarTodosPaginado(offset, limit));
            if (produtos.Count == 0)
            {
                progressBarLView.Visible = false;
                _lViewCarregando = false;
                return;
            }
            foreach(var produto in produtos)
            {
                ListViewItem item = new ListViewItem(produto.Codigo.ToString());
                item.SubItems.Add(produto.Nome);
                item.SubItems.Add(produto.Preco.ToString());
                item.SubItems.Add(produto.Custo.ToString());

                lViewProdutos.Items.Add(item);
            }
            progressBarLView.Visible = false;
            offset += limit;
            _lViewCarregando = false;
        }
        private async void LviewProdutos_MouseWheel(object sender, MouseEventArgs e)
        {
            // Verifica se o usuário rolou para baixo
            if (e.Delta < 0)  // Se o valor de Delta for negativo, significa rolagem para baixo
            {
                // Verifica se a ListView atingiu o fim
                if (lViewProdutos.Items.Count > 0 && lViewProdutos.Items[lViewProdutos.Items.Count - 1].Bounds.Bottom <= lViewProdutos.ClientSize.Height)
                    await PreencherListView();
            }
        }
        private void LViewProdutos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListViewHelper.OrdenarListView(lViewProdutos, e.Column);
        }

        
    }
}
