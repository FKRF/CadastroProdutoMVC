using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutoMVC.Helpers
{
    public static class ListViewHelper
    {
        private static int ultimaColuna = -1;
        private static SortOrder ultimaOrdem = SortOrder.Ascending;

        public class ListViewItemComparer : IComparer
        {
            private int coluna;
            private SortOrder ordem;

            public ListViewItemComparer(int coluna, SortOrder ordem)
            {
                this.coluna = coluna;
                this.ordem = ordem;
            }

            public int Compare(object x, object y)
            {
                ListViewItem itemX = x as ListViewItem;
                ListViewItem itemY = y as ListViewItem;

                string valorX = itemX.SubItems[coluna].Text;
                string valorY = itemY.SubItems[coluna].Text;
                int resultado;

                if (decimal.TryParse(valorX, out decimal numX) && decimal.TryParse(valorY, out decimal numY))
                {
                    resultado = numX.CompareTo(numY);
                }
                else
                {
                    resultado = string.Compare(valorX, valorY);
                }

                return ordem == SortOrder.Descending ? -resultado : resultado;
            }
        }

        public static void OrdenarListView(ListView listView, int coluna)
        {
            // Se for a mesma coluna, alterna a ordem
            if (coluna == ultimaColuna)
            {
                ultimaOrdem = (ultimaOrdem == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                ultimaColuna = coluna;
                ultimaOrdem = SortOrder.Ascending;
            }

            listView.ListViewItemSorter = new ListViewItemComparer(coluna, ultimaOrdem);
            listView.Sort();
        }
    }

}
