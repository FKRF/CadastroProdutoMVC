using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutoMVC.Helpers
{
    public static class ControlHelper
    {
        public static Button CriarButton(string texto, int x, int y, int largura, int altura, EventHandler eventoClick = null)
        {
            Button button = new Button();
            button.Text = texto;
            button.Location = new Point(x, y);
            button.Size = new Size(largura, altura);
            if (eventoClick != null)
            {
                button.Click += eventoClick;
            }
            return button;
        }

        // Método para criar um TextBox
        public static TextBox CriarTextBox(int x, int y, int largura, int altura, string textoPadrao = "")
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(largura, altura);
            textBox.Text = textoPadrao;
            return textBox;
        }

        // Método para criar um Label
        public static Label CriarLabel(string texto, int x, int y, int largura, int altura)
        {
            Label label = new Label();
            label.Text = texto;
            label.Location = new Point(x, y);
            label.Size = new Size(largura, altura);
            return label;
        }

        public static Label CriarListView(string texto, int x, int y, int largura, int altura)
        {
            Label label = new Label();
            label.Text = texto;
            label.Location = new Point(x, y);
            label.Size = new Size(largura, altura);
            return label;
        }
    }
}
