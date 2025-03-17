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
            DesenharControls();
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

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            FrmBase frmBase = new FrmBase(FrmBase.Acao.Excluir);
            frmBase.ShowDialog();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void DesenharControls()
        {
            Button BtnPesquisar = ControlHelper.CriarButton("Pesquisar", 410, 40, 75, 25, BtnPesquisar_Click);
            Controls.Add(BtnPesquisar);
            Button BtnMostrarTodos = ControlHelper.CriarButton("Mostrar todos", 540, 100, 100, 30, BtnMostrarTodos_Click);
            Controls.Add(BtnMostrarTodos);
            Button BtnAdicionar = ControlHelper.CriarButton("Adicionar", 100, 400, 75, 25, BtnAdicionar_Click);
            Controls.Add(BtnAdicionar);
            Button BtnAlterar = ControlHelper.CriarButton("Alterar", 270, 400, 75, 25, BtnAlterar_Click);
            Controls.Add(BtnAlterar);
            Button BtnExcluir = ControlHelper.CriarButton("Excluir", 440, 400, 75, 25, BtnExcluir_Click);
            Controls.Add(BtnExcluir);
            Button BtnSair = ControlHelper.CriarButton("Sair", 700, 400, 75, 25, BtnSair_Click);
            Controls.Add(BtnSair);
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
        private void BtnMostrarTodos_Click(object sender, EventArgs e)
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
