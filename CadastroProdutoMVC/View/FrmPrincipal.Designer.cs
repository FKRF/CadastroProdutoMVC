namespace CadastroProdutoMVC
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtPesquisa = new TextBox();
            lViewProdutos = new ListView();
            progressBarLView = new ProgressBar();
            SuspendLayout();
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(72, 39);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(289, 23);
            txtPesquisa.TabIndex = 1;
            // 
            // lViewProdutos
            // 
            lViewProdutos.Location = new Point(72, 92);
            lViewProdutos.Name = "lViewProdutos";
            lViewProdutos.Size = new Size(121, 97);
            lViewProdutos.TabIndex = 6;
            lViewProdutos.UseCompatibleStateImageBehavior = false;
            // 
            // progressBarLView
            // 
            progressBarLView.Location = new Point(354, 202);
            progressBarLView.Name = "progressBarLView";
            progressBarLView.Size = new Size(100, 23);
            progressBarLView.Style = ProgressBarStyle.Marquee;
            progressBarLView.TabIndex = 8;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBarLView);
            Controls.Add(lViewProdutos);
            Controls.Add(txtPesquisa);
            Name = "FrmPrincipal";
            Text = "Tela inicial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtPesquisa;
        private ListView lViewProdutos;
        private ProgressBar progressBarLView;
    }
}
