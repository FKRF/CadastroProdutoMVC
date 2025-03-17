using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public static TextBox CriarTextBox(int x, int y, int largura, int altura, string textoPadrao = "", KeyEventHandler keyDownEvent = null)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(x, y);
            textBox.Size = new Size(largura, altura);
            textBox.Text = textoPadrao;

            if (keyDownEvent != null)
                textBox.KeyDown += keyDownEvent;

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

        public static ListView CriarListView(int x, int y, int largura, int altura, string view, bool gridLines)
        {
            ListView listView = new ListView();
            listView.Location = new System.Drawing.Point(x, y);
            listView.Size = new System.Drawing.Size(largura, altura);
            listView.GridLines = gridLines;

            if (Enum.TryParse(view, out System.Windows.Forms.View viewEnum))
                listView.View = viewEnum;
            else
                throw new ArgumentException("Modo de visualização inválido", nameof(view));
            return listView;
        }
        public static ProgressBar CriarProgressBar(int x, int y, int largura, int altura, string estilo, bool visivel)
        {
            ProgressBar bar = new ProgressBar();
            bar.Size = new System.Drawing.Size(largura, altura);
            bar.Location = new System.Drawing.Point(x, y);
            if(Enum.TryParse(estilo, out System.Windows.Forms.ProgressBarStyle estiloBar))
                bar.Style = estiloBar;
            else
                throw new ArgumentException("Modo de visualização inválido", nameof(estilo));

            bar.Visible = visivel;
            return bar;
        }
    }
}
