namespace CadastroProdutoMVC.View
{
    partial class FrmBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCodigo = new Label();
            lblNome = new Label();
            lblPreco = new Label();
            lblCusto = new Label();
            txtCodigo = new TextBox();
            txtNome = new TextBox();
            txtPreco = new TextBox();
            txtCusto = new TextBox();
            btnSalvar = new Button();
            btnSair = new Button();
            SuspendLayout();
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(46, 18);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(46, 15);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Código";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(253, 18);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 1;
            lblNome.Text = "Nome";
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(427, 18);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(37, 15);
            lblPreco.TabIndex = 2;
            lblPreco.Text = "Preço";
            // 
            // lblCusto
            // 
            lblCusto.AutoSize = true;
            lblCusto.Location = new Point(587, 18);
            lblCusto.Name = "lblCusto";
            lblCusto.Size = new Size(38, 15);
            lblCusto.TabIndex = 3;
            lblCusto.Text = "Custo";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(28, 55);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 4;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(230, 55);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 5;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(422, 55);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(100, 23);
            txtPreco.TabIndex = 6;
            // 
            // txtCusto
            // 
            txtCusto.Location = new Point(587, 55);
            txtCusto.Name = "txtCusto";
            txtCusto.Size = new Size(100, 23);
            txtCusto.TabIndex = 7;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(571, 396);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(75, 23);
            btnSalvar.TabIndex = 8;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(712, 396);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(75, 23);
            btnSair.TabIndex = 9;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // FrmBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSair);
            Controls.Add(btnSalvar);
            Controls.Add(txtCusto);
            Controls.Add(txtPreco);
            Controls.Add(txtNome);
            Controls.Add(txtCodigo);
            Controls.Add(lblCusto);
            Controls.Add(lblPreco);
            Controls.Add(lblNome);
            Controls.Add(lblCodigo);
            Name = "FrmBase";
            Text = "FrmBase";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigo;
        private Label lblNome;
        private Label lblPreco;
        private Label lblCusto;
        private TextBox txtCodigo;
        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtCusto;
        private Button btnSalvar;
        private Button btnSair;
    }
}