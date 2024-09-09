namespace GUI
{
    partial class FrmCadastroProduto
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
            pnBotoes = new Panel();
            buttonCancelar = new Button();
            buttonSalvar = new Button();
            buttonExcluir = new Button();
            buttonAlterar = new Button();
            buttonLocalizar = new Button();
            buttonInserir = new Button();
            pnDados = new Panel();
            pnFoto = new Panel();
            label10 = new Label();
            panel1 = new Panel();
            pbImagem = new PictureBox();
            btRemoverFoto = new Button();
            btCarregarFoto = new Button();
            pnCampos = new Panel();
            tbValorVenda = new TextBox();
            btnAddUndMedida = new Button();
            btnAddSubCategoria = new Button();
            btnAddCategoria = new Button();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbSubCategoria = new ComboBox();
            cbCategoria = new ComboBox();
            cbUndMedida = new ComboBox();
            tbValorPago = new TextBox();
            tbQuantidade = new TextBox();
            tbDescricao = new TextBox();
            tbNome = new TextBox();
            tbCodigo = new TextBox();
            label1 = new Label();
            pnBotoes.SuspendLayout();
            pnDados.SuspendLayout();
            pnFoto.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagem).BeginInit();
            pnCampos.SuspendLayout();
            SuspendLayout();
            // 
            // pnBotoes
            // 
            pnBotoes.Controls.Add(buttonCancelar);
            pnBotoes.Controls.Add(buttonSalvar);
            pnBotoes.Controls.Add(buttonExcluir);
            pnBotoes.Controls.Add(buttonAlterar);
            pnBotoes.Controls.Add(buttonLocalizar);
            pnBotoes.Controls.Add(buttonInserir);
            pnBotoes.Location = new Point(12, 429);
            pnBotoes.Name = "pnBotoes";
            pnBotoes.Size = new Size(758, 117);
            pnBotoes.TabIndex = 11;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            buttonCancelar.Image = Properties.Resources.Cancelar;
            buttonCancelar.ImageAlign = ContentAlignment.TopCenter;
            buttonCancelar.Location = new Point(598, 14);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(100, 92);
            buttonCancelar.TabIndex = 17;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.TextAlign = ContentAlignment.BottomCenter;
            buttonCancelar.UseVisualStyleBackColor = true;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // buttonSalvar
            // 
            buttonSalvar.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            buttonSalvar.Image = Properties.Resources.Salvar1_fw;
            buttonSalvar.ImageAlign = ContentAlignment.TopCenter;
            buttonSalvar.Location = new Point(492, 14);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new Size(100, 92);
            buttonSalvar.TabIndex = 16;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.TextAlign = ContentAlignment.BottomCenter;
            buttonSalvar.UseVisualStyleBackColor = true;
            buttonSalvar.Click += buttonSalvar_Click;
            // 
            // buttonExcluir
            // 
            buttonExcluir.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            buttonExcluir.Image = Properties.Resources.Excluir;
            buttonExcluir.ImageAlign = ContentAlignment.TopCenter;
            buttonExcluir.Location = new Point(384, 14);
            buttonExcluir.Name = "buttonExcluir";
            buttonExcluir.Size = new Size(100, 92);
            buttonExcluir.TabIndex = 15;
            buttonExcluir.Text = "Excluir";
            buttonExcluir.TextAlign = ContentAlignment.BottomCenter;
            buttonExcluir.UseVisualStyleBackColor = true;
            buttonExcluir.Click += buttonExcluir_Click;
            // 
            // buttonAlterar
            // 
            buttonAlterar.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            buttonAlterar.Image = Properties.Resources.Alterar;
            buttonAlterar.ImageAlign = ContentAlignment.TopCenter;
            buttonAlterar.Location = new Point(276, 14);
            buttonAlterar.Name = "buttonAlterar";
            buttonAlterar.Size = new Size(100, 92);
            buttonAlterar.TabIndex = 14;
            buttonAlterar.Text = "Alterar";
            buttonAlterar.TextAlign = ContentAlignment.BottomCenter;
            buttonAlterar.UseVisualStyleBackColor = true;
            buttonAlterar.Click += buttonAlterar_Click;
            // 
            // buttonLocalizar
            // 
            buttonLocalizar.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            buttonLocalizar.Image = Properties.Resources.localizar_fw;
            buttonLocalizar.ImageAlign = ContentAlignment.TopCenter;
            buttonLocalizar.Location = new Point(168, 14);
            buttonLocalizar.Name = "buttonLocalizar";
            buttonLocalizar.Size = new Size(100, 92);
            buttonLocalizar.TabIndex = 13;
            buttonLocalizar.Text = "Localizar";
            buttonLocalizar.TextAlign = ContentAlignment.BottomCenter;
            buttonLocalizar.UseVisualStyleBackColor = true;
            buttonLocalizar.Click += buttonLocalizar_Click;
            // 
            // buttonInserir
            // 
            buttonInserir.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonInserir.Image = Properties.Resources.Novo;
            buttonInserir.ImageAlign = ContentAlignment.TopCenter;
            buttonInserir.Location = new Point(60, 14);
            buttonInserir.Name = "buttonInserir";
            buttonInserir.Size = new Size(100, 92);
            buttonInserir.TabIndex = 12;
            buttonInserir.Text = "Inserir";
            buttonInserir.TextAlign = ContentAlignment.BottomCenter;
            buttonInserir.UseVisualStyleBackColor = true;
            buttonInserir.Click += buttonInserir_Click;
            // 
            // pnDados
            // 
            pnDados.Controls.Add(pnFoto);
            pnDados.Controls.Add(pnCampos);
            pnDados.Location = new Point(12, 6);
            pnDados.Name = "pnDados";
            pnDados.Size = new Size(758, 417);
            pnDados.TabIndex = 2;
            // 
            // pnFoto
            // 
            pnFoto.BorderStyle = BorderStyle.FixedSingle;
            pnFoto.Controls.Add(label10);
            pnFoto.Controls.Add(panel1);
            pnFoto.Controls.Add(btRemoverFoto);
            pnFoto.Controls.Add(btCarregarFoto);
            pnFoto.Dock = DockStyle.Right;
            pnFoto.Location = new Point(490, 0);
            pnFoto.Name = "pnFoto";
            pnFoto.Size = new Size(268, 417);
            pnFoto.TabIndex = 10;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 2);
            label10.Name = "label10";
            label10.Size = new Size(39, 20);
            label10.TabIndex = 0;
            label10.Text = "Foto";
            // 
            // panel1
            // 
            panel1.Controls.Add(pbImagem);
            panel1.Location = new Point(3, 25);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 286);
            panel1.TabIndex = 3;
            // 
            // pbImagem
            // 
            pbImagem.Dock = DockStyle.Fill;
            pbImagem.Location = new Point(0, 0);
            pbImagem.Name = "pbImagem";
            pbImagem.Size = new Size(260, 286);
            pbImagem.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagem.TabIndex = 0;
            pbImagem.TabStop = false;
            // 
            // btRemoverFoto
            // 
            btRemoverFoto.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btRemoverFoto.Image = Properties.Resources.Excluir;
            btRemoverFoto.Location = new Point(136, 317);
            btRemoverFoto.Name = "btRemoverFoto";
            btRemoverFoto.Size = new Size(131, 92);
            btRemoverFoto.TabIndex = 2;
            btRemoverFoto.Text = "Remover Foto";
            btRemoverFoto.TextAlign = ContentAlignment.BottomCenter;
            btRemoverFoto.UseVisualStyleBackColor = true;
            btRemoverFoto.Click += btRemoverFoto_Click;
            // 
            // btCarregarFoto
            // 
            btCarregarFoto.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btCarregarFoto.Image = Properties.Resources.Novo;
            btCarregarFoto.Location = new Point(3, 317);
            btCarregarFoto.Name = "btCarregarFoto";
            btCarregarFoto.Size = new Size(131, 92);
            btCarregarFoto.TabIndex = 1;
            btCarregarFoto.Text = "Carregar";
            btCarregarFoto.TextAlign = ContentAlignment.BottomCenter;
            btCarregarFoto.UseVisualStyleBackColor = true;
            btCarregarFoto.Click += btCarregarFoto_Click;
            // 
            // pnCampos
            // 
            pnCampos.Controls.Add(tbValorVenda);
            pnCampos.Controls.Add(btnAddUndMedida);
            pnCampos.Controls.Add(btnAddSubCategoria);
            pnCampos.Controls.Add(btnAddCategoria);
            pnCampos.Controls.Add(label9);
            pnCampos.Controls.Add(label8);
            pnCampos.Controls.Add(label7);
            pnCampos.Controls.Add(label6);
            pnCampos.Controls.Add(label5);
            pnCampos.Controls.Add(label4);
            pnCampos.Controls.Add(label3);
            pnCampos.Controls.Add(label2);
            pnCampos.Controls.Add(cbSubCategoria);
            pnCampos.Controls.Add(cbCategoria);
            pnCampos.Controls.Add(cbUndMedida);
            pnCampos.Controls.Add(tbValorPago);
            pnCampos.Controls.Add(tbQuantidade);
            pnCampos.Controls.Add(tbDescricao);
            pnCampos.Controls.Add(tbNome);
            pnCampos.Controls.Add(tbCodigo);
            pnCampos.Controls.Add(label1);
            pnCampos.Dock = DockStyle.Left;
            pnCampos.Location = new Point(0, 0);
            pnCampos.Name = "pnCampos";
            pnCampos.Size = new Size(484, 417);
            pnCampos.TabIndex = 0;
            // 
            // tbValorVenda
            // 
            tbValorVenda.Location = new Point(245, 262);
            tbValorVenda.Name = "tbValorVenda";
            tbValorVenda.RightToLeft = RightToLeft.No;
            tbValorVenda.Size = new Size(229, 27);
            tbValorVenda.TabIndex = 23;
            tbValorVenda.Text = "0,00";
            tbValorVenda.TextAlign = HorizontalAlignment.Right;
            // 
            // btnAddUndMedida
            // 
            btnAddUndMedida.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddUndMedida.Location = new Point(448, 325);
            btnAddUndMedida.Name = "btnAddUndMedida";
            btnAddUndMedida.Size = new Size(26, 28);
            btnAddUndMedida.TabIndex = 22;
            btnAddUndMedida.Text = "+";
            btnAddUndMedida.UseVisualStyleBackColor = true;
            btnAddUndMedida.Click += btnAddUndMedida_Click;
            // 
            // btnAddSubCategoria
            // 
            btnAddSubCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddSubCategoria.Location = new Point(448, 382);
            btnAddSubCategoria.Name = "btnAddSubCategoria";
            btnAddSubCategoria.Size = new Size(26, 28);
            btnAddSubCategoria.TabIndex = 21;
            btnAddSubCategoria.Text = "+";
            btnAddSubCategoria.UseVisualStyleBackColor = true;
            btnAddSubCategoria.Click += btnAddSubCategoria_Click;
            // 
            // btnAddCategoria
            // 
            btnAddCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCategoria.Location = new Point(212, 382);
            btnAddCategoria.Name = "btnAddCategoria";
            btnAddCategoria.Size = new Size(26, 28);
            btnAddCategoria.TabIndex = 20;
            btnAddCategoria.Text = "+";
            btnAddCategoria.UseVisualStyleBackColor = true;
            btnAddCategoria.Click += btnAddCategoria_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(245, 359);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 19;
            label9.Text = "SubCategoria";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 359);
            label8.Name = "label8";
            label8.Size = new Size(74, 20);
            label8.TabIndex = 2;
            label8.Text = "Categoria";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(245, 301);
            label7.Name = "label7";
            label7.Size = new Size(141, 20);
            label7.TabIndex = 17;
            label7.Text = "Unidade de Medida";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(245, 239);
            label6.Name = "label6";
            label6.Size = new Size(109, 20);
            label6.TabIndex = 16;
            label6.Text = "Valor de Venda";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 239);
            label5.Name = "label5";
            label5.Size = new Size(80, 20);
            label5.TabIndex = 15;
            label5.Text = "Valor Pago";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 301);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 14;
            label4.Text = "Quantidade";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 114);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 13;
            label3.Text = "Descrição";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 57);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 12;
            label2.Text = "Nome";
            // 
            // cbSubCategoria
            // 
            cbSubCategoria.FormattingEnabled = true;
            cbSubCategoria.Location = new Point(245, 382);
            cbSubCategoria.Name = "cbSubCategoria";
            cbSubCategoria.Size = new Size(201, 28);
            cbSubCategoria.TabIndex = 9;
            // 
            // cbCategoria
            // 
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(10, 382);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(201, 28);
            cbCategoria.TabIndex = 8;
            cbCategoria.SelectedIndexChanged += cbCategoria_SelectedIndexChanged;
            // 
            // cbUndMedida
            // 
            cbUndMedida.FormattingEnabled = true;
            cbUndMedida.Location = new Point(245, 324);
            cbUndMedida.Name = "cbUndMedida";
            cbUndMedida.Size = new Size(201, 28);
            cbUndMedida.TabIndex = 7;
            // 
            // tbValorPago
            // 
            tbValorPago.Location = new Point(10, 262);
            tbValorPago.Name = "tbValorPago";
            tbValorPago.RightToLeft = RightToLeft.No;
            tbValorPago.Size = new Size(229, 27);
            tbValorPago.TabIndex = 5;
            tbValorPago.Text = "0,00";
            tbValorPago.TextAlign = HorizontalAlignment.Right;
            // 
            // tbQuantidade
            // 
            tbQuantidade.Location = new Point(10, 325);
            tbQuantidade.Name = "tbQuantidade";
            tbQuantidade.RightToLeft = RightToLeft.No;
            tbQuantidade.Size = new Size(229, 27);
            tbQuantidade.TabIndex = 4;
            tbQuantidade.Text = "0,00";
            tbQuantidade.TextAlign = HorizontalAlignment.Right;
            // 
            // tbDescricao
            // 
            tbDescricao.Location = new Point(9, 138);
            tbDescricao.Multiline = true;
            tbDescricao.Name = "tbDescricao";
            tbDescricao.Size = new Size(464, 93);
            tbDescricao.TabIndex = 3;
            // 
            // tbNome
            // 
            tbNome.Location = new Point(9, 82);
            tbNome.Name = "tbNome";
            tbNome.Size = new Size(464, 27);
            tbNome.TabIndex = 2;
            // 
            // tbCodigo
            // 
            tbCodigo.Location = new Point(9, 26);
            tbCodigo.Name = "tbCodigo";
            tbCodigo.ReadOnly = true;
            tbCodigo.Size = new Size(125, 27);
            tbCodigo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 3);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 7;
            label1.Text = "Código";
            // 
            // FrmCadastroProduto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(pnBotoes);
            Controls.Add(pnDados);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmCadastroProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Produto";
            Load += FrmProduto_Load;
            KeyDown += FrmProduto_KeyDown;
            pnBotoes.ResumeLayout(false);
            pnDados.ResumeLayout(false);
            pnFoto.ResumeLayout(false);
            pnFoto.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbImagem).EndInit();
            pnCampos.ResumeLayout(false);
            pnCampos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        protected Panel pnBotoes;
        protected Button buttonCancelar;
        protected Button buttonSalvar;
        protected Button buttonExcluir;
        protected Button buttonAlterar;
        protected Button buttonLocalizar;
        protected Button buttonInserir;
        protected Panel pnDados;
        private Panel pnFoto;
        private Panel pnCampos;
        private Label label3;
        private Label label2;
        private ComboBox cbSubCategoria;
        private ComboBox cbCategoria;
        private ComboBox cbUndMedida;
        private TextBox tbValorPago;
        private TextBox tbQuantidade;
        private TextBox tbDescricao;
        private TextBox tbNome;
        private TextBox tbCodigo;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private Label label8;
        private Button btRemoverFoto;
        private Button btCarregarFoto;
        private Label label10;
        private Panel panel1;
        private PictureBox pbImagem;
        private Button btnAddSubCategoria;
        private Button btnAddCategoria;
        private Button btnAddUndMedida;
        private TextBox tbValorVenda;
    }
}