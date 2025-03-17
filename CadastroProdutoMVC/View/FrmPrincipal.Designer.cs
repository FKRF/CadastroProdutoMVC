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
            btnSair = new Button();
            txtPesquisa = new TextBox();
            btnPesquisar = new Button();
            btnAdicionar = new Button();
            btnAlterar = new Button();
            Excluir = new Button();
            lViewProdutos = new ListView();
            SuspendLayout();
            // 
            // btnSair
            // 
            btnSair.Location = new Point(700, 395);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(75, 23);
            btnSair.TabIndex = 0;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += BtnSair_Click;
            // 
            // txtPesquisa
            // 
            txtPesquisa.Location = new Point(72, 39);
            txtPesquisa.Name = "txtPesquisa";
            txtPesquisa.Size = new Size(289, 23);
            txtPesquisa.TabIndex = 1;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Location = new Point(409, 39);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(75, 23);
            btnPesquisar.TabIndex = 2;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.UseVisualStyleBackColor = true;
            btnPesquisar.Click += BtnPesquisar_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(97, 395);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(75, 23);
            btnAdicionar.TabIndex = 3;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += BtnAdicionar_Click;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(270, 395);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(75, 23);
            btnAlterar.TabIndex = 4;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            btnAlterar.Click += BtnAlterar_Click;
            // 
            // Excluir
            // 
            Excluir.Location = new Point(443, 395);
            Excluir.Name = "Excluir";
            Excluir.Size = new Size(75, 23);
            Excluir.TabIndex = 5;
            Excluir.Text = "Excluir";
            Excluir.UseVisualStyleBackColor = true;
            Excluir.Click += Excluir_Click;
            // 
            // lViewProdutos
            // 
            lViewProdutos.Location = new Point(85, 133);
            lViewProdutos.Name = "lViewProdutos";
            lViewProdutos.Size = new Size(121, 97);
            lViewProdutos.TabIndex = 6;
            lViewProdutos.UseCompatibleStateImageBehavior = false;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lViewProdutos);
            Controls.Add(Excluir);
            Controls.Add(btnAlterar);
            Controls.Add(btnAdicionar);
            Controls.Add(btnPesquisar);
            Controls.Add(txtPesquisa);
            Controls.Add(btnSair);
            Name = "FrmPrincipal";
            Text = "Tela inicial";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSair;
        private TextBox txtPesquisa;
        private Button btnPesquisar;
        private Button btnAdicionar;
        private Button btnAlterar;
        private Button Excluir;
        private ListView lViewProdutos;
    }
}
