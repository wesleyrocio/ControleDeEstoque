namespace GUI
{
    partial class FrmMovimentacaoCompra
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
            lbFornecedor = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            tbTotal = new TextBox();
            dtpDataInicialPagamento = new DateTimePicker();
            cbTipoPagamento = new ComboBox();
            cbParcelas = new ComboBox();
            label10 = new Label();
            dgvItens = new DataGridView();
            btAdicionarItem = new Button();
            tbValorUnitario = new TextBox();
            label9 = new Label();
            tbQuantidade = new TextBox();
            btLocalizarProduto = new Button();
            tbCodProduto = new TextBox();
            label7 = new Label();
            lbProduto = new Label();
            panel1 = new Panel();
            btLocalizarFornecedor = new Button();
            tbCodFornecedor = new TextBox();
            label6 = new Label();
            dtpDataCompra = new DateTimePicker();
            tbNotaFiscal = new TextBox();
            tbCodigo = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btGerarParcelas = new Button();
            lbTotalDaCompra = new Label();
            label8 = new Label();
            dgvParcelas = new DataGridView();
            label5 = new Label();
            pnBotoes.SuspendLayout();
            pnDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParcelas).BeginInit();
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
            pnBotoes.Location = new Point(13, 429);
            pnBotoes.Name = "pnBotoes";
            pnBotoes.Size = new Size(758, 117);
            pnBotoes.TabIndex = 3;
            // 
            // buttonCancelar
            // 
            buttonCancelar.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            buttonCancelar.Image = Properties.Resources.Cancelar;
            buttonCancelar.ImageAlign = ContentAlignment.TopCenter;
            buttonCancelar.Location = new Point(600, 14);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(100, 92);
            buttonCancelar.TabIndex = 5;
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
            buttonSalvar.TabIndex = 4;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.TextAlign = ContentAlignment.BottomCenter;
            buttonSalvar.UseVisualStyleBackColor = true;
            buttonSalvar.Click += buttonSalvar_Click_1;
            // 
            // buttonExcluir
            // 
            buttonExcluir.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold);
            buttonExcluir.Image = Properties.Resources.Excluir;
            buttonExcluir.ImageAlign = ContentAlignment.TopCenter;
            buttonExcluir.Location = new Point(384, 14);
            buttonExcluir.Name = "buttonExcluir";
            buttonExcluir.Size = new Size(100, 92);
            buttonExcluir.TabIndex = 3;
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
            buttonAlterar.TabIndex = 2;
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
            buttonLocalizar.TabIndex = 1;
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
            buttonInserir.TabIndex = 0;
            buttonInserir.Text = "Inserir";
            buttonInserir.TextAlign = ContentAlignment.BottomCenter;
            buttonInserir.UseVisualStyleBackColor = true;
            buttonInserir.Click += buttonInserir_Click;
            // 
            // pnDados
            // 
            pnDados.Controls.Add(lbFornecedor);
            pnDados.Controls.Add(label14);
            pnDados.Controls.Add(label13);
            pnDados.Controls.Add(label12);
            pnDados.Controls.Add(label11);
            pnDados.Controls.Add(tbTotal);
            pnDados.Controls.Add(dtpDataInicialPagamento);
            pnDados.Controls.Add(cbTipoPagamento);
            pnDados.Controls.Add(cbParcelas);
            pnDados.Controls.Add(label10);
            pnDados.Controls.Add(dgvItens);
            pnDados.Controls.Add(btAdicionarItem);
            pnDados.Controls.Add(tbValorUnitario);
            pnDados.Controls.Add(label9);
            pnDados.Controls.Add(tbQuantidade);
            pnDados.Controls.Add(btLocalizarProduto);
            pnDados.Controls.Add(tbCodProduto);
            pnDados.Controls.Add(label7);
            pnDados.Controls.Add(lbProduto);
            pnDados.Controls.Add(panel1);
            pnDados.Controls.Add(btLocalizarFornecedor);
            pnDados.Controls.Add(tbCodFornecedor);
            pnDados.Controls.Add(label6);
            pnDados.Controls.Add(dtpDataCompra);
            pnDados.Controls.Add(tbNotaFiscal);
            pnDados.Controls.Add(tbCodigo);
            pnDados.Controls.Add(label4);
            pnDados.Controls.Add(label3);
            pnDados.Controls.Add(label2);
            pnDados.Controls.Add(label1);
            pnDados.Location = new Point(13, 6);
            pnDados.Name = "pnDados";
            pnDados.Size = new Size(758, 417);
            pnDados.TabIndex = 2;
            // 
            // lbFornecedor
            // 
            lbFornecedor.AutoSize = true;
            lbFornecedor.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbFornecedor.Location = new Point(410, 95);
            lbFornecedor.Name = "lbFornecedor";
            lbFornecedor.Size = new Size(253, 17);
            lbFornecedor.TabIndex = 30;
            lbFornecedor.Text = "Informe o código  ou clique em localizar.";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(623, 363);
            label14.Name = "label14";
            label14.Size = new Size(42, 20);
            label14.TabIndex = 29;
            label14.Text = "Total";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(324, 363);
            label13.Name = "label13";
            label13.Size = new Size(185, 20);
            label13.TabIndex = 28;
            label13.Text = "Data Inicial do Pagamento";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(166, 363);
            label12.Name = "label12";
            label12.Size = new Size(118, 20);
            label12.TabIndex = 27;
            label12.Text = "Tipo Pagamento";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 363);
            label11.Name = "label11";
            label11.Size = new Size(62, 20);
            label11.TabIndex = 26;
            label11.Text = "Parcelas";
            // 
            // tbTotal
            // 
            tbTotal.Location = new Point(623, 386);
            tbTotal.Name = "tbTotal";
            tbTotal.ReadOnly = true;
            tbTotal.Size = new Size(129, 27);
            tbTotal.TabIndex = 25;
            tbTotal.TextChanged += tbTotal_TextChanged;
            // 
            // dtpDataInicialPagamento
            // 
            dtpDataInicialPagamento.Location = new Point(324, 386);
            dtpDataInicialPagamento.Name = "dtpDataInicialPagamento";
            dtpDataInicialPagamento.Size = new Size(292, 27);
            dtpDataInicialPagamento.TabIndex = 24;
            // 
            // cbTipoPagamento
            // 
            cbTipoPagamento.FormattingEnabled = true;
            cbTipoPagamento.Location = new Point(166, 386);
            cbTipoPagamento.Name = "cbTipoPagamento";
            cbTipoPagamento.Size = new Size(151, 28);
            cbTipoPagamento.TabIndex = 23;
            // 
            // cbParcelas
            // 
            cbParcelas.FormattingEnabled = true;
            cbParcelas.Location = new Point(8, 386);
            cbParcelas.Name = "cbParcelas";
            cbParcelas.Size = new Size(151, 28);
            cbParcelas.TabIndex = 22;
            cbParcelas.SelectedIndexChanged += cbParcelas_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(8, 205);
            label10.Name = "label10";
            label10.Size = new Size(113, 17);
            label10.TabIndex = 21;
            label10.Text = "Items da Compra";
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Location = new Point(8, 225);
            dgvItens.Name = "dgvItens";
            dgvItens.ReadOnly = true;
            dgvItens.RowHeadersWidth = 51;
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.Size = new Size(744, 131);
            dgvItens.TabIndex = 20;
            dgvItens.CellMouseDoubleClick += dgvItens_CellMouseDoubleClick;
            dgvItens.KeyDown += dgvItens_KeyDown;
            // 
            // btAdicionarItem
            // 
            btAdicionarItem.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btAdicionarItem.Location = new Point(724, 167);
            btAdicionarItem.Name = "btAdicionarItem";
            btAdicionarItem.Size = new Size(28, 34);
            btAdicionarItem.TabIndex = 19;
            btAdicionarItem.Text = "+";
            btAdicionarItem.UseVisualStyleBackColor = true;
            btAdicionarItem.Click += btAdicionarItem_Click;
            // 
            // tbValorUnitario
            // 
            tbValorUnitario.Location = new Point(546, 172);
            tbValorUnitario.Name = "tbValorUnitario";
            tbValorUnitario.ReadOnly = true;
            tbValorUnitario.RightToLeft = RightToLeft.Yes;
            tbValorUnitario.Size = new Size(169, 27);
            tbValorUnitario.TabIndex = 18;
            tbValorUnitario.TextChanged += tbValorUnitario_TextChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(546, 149);
            label9.Name = "label9";
            label9.Size = new Size(100, 20);
            label9.TabIndex = 17;
            label9.Text = "Valor Unitário";
            // 
            // tbQuantidade
            // 
            tbQuantidade.Location = new Point(415, 172);
            tbQuantidade.Name = "tbQuantidade";
            tbQuantidade.Size = new Size(125, 27);
            tbQuantidade.TabIndex = 16;
            // 
            // btLocalizarProduto
            // 
            btLocalizarProduto.Location = new Point(310, 170);
            btLocalizarProduto.Name = "btLocalizarProduto";
            btLocalizarProduto.Size = new Size(94, 29);
            btLocalizarProduto.TabIndex = 15;
            btLocalizarProduto.Text = "Localizar";
            btLocalizarProduto.UseVisualStyleBackColor = true;
            btLocalizarProduto.Click += btLocalizarProduto_Click;
            // 
            // tbCodProduto
            // 
            tbCodProduto.Location = new Point(8, 172);
            tbCodProduto.Name = "tbCodProduto";
            tbCodProduto.Size = new Size(296, 27);
            tbCodProduto.TabIndex = 14;
            tbCodProduto.Leave += tbCodProduto_Leave;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 149);
            label7.Name = "label7";
            label7.Size = new Size(96, 20);
            label7.TabIndex = 13;
            label7.Text = "Cod. Produto";
            // 
            // lbProduto
            // 
            lbProduto.AutoSize = true;
            lbProduto.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbProduto.Location = new Point(155, 152);
            lbProduto.Name = "lbProduto";
            lbProduto.Size = new Size(249, 17);
            lbProduto.TabIndex = 12;
            lbProduto.Text = "Informe o código ou clique em localizar.";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Location = new Point(8, 128);
            panel1.Name = "panel1";
            panel1.Size = new Size(744, 10);
            panel1.TabIndex = 11;
            // 
            // btLocalizarFornecedor
            // 
            btLocalizarFornecedor.Location = new Point(310, 91);
            btLocalizarFornecedor.Name = "btLocalizarFornecedor";
            btLocalizarFornecedor.Size = new Size(94, 29);
            btLocalizarFornecedor.TabIndex = 10;
            btLocalizarFornecedor.Text = "Localizar";
            btLocalizarFornecedor.UseVisualStyleBackColor = true;
            btLocalizarFornecedor.Click += btLocalizarFornecedor_Click;
            // 
            // tbCodFornecedor
            // 
            tbCodFornecedor.Location = new Point(8, 93);
            tbCodFornecedor.Name = "tbCodFornecedor";
            tbCodFornecedor.Size = new Size(296, 27);
            tbCodFornecedor.TabIndex = 9;
            tbCodFornecedor.Leave += tbCodFornecedor_Leave;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 70);
            label6.Name = "label6";
            label6.Size = new Size(118, 20);
            label6.TabIndex = 8;
            label6.Text = "Cod. Fornecedor";
            // 
            // dtpDataCompra
            // 
            dtpDataCompra.Location = new Point(412, 29);
            dtpDataCompra.Name = "dtpDataCompra";
            dtpDataCompra.Size = new Size(323, 27);
            dtpDataCompra.TabIndex = 7;
            // 
            // tbNotaFiscal
            // 
            tbNotaFiscal.Location = new Point(279, 29);
            tbNotaFiscal.Name = "tbNotaFiscal";
            tbNotaFiscal.Size = new Size(125, 27);
            tbNotaFiscal.TabIndex = 6;
            // 
            // tbCodigo
            // 
            tbCodigo.Enabled = false;
            tbCodigo.Location = new Point(8, 29);
            tbCodigo.Name = "tbCodigo";
            tbCodigo.Size = new Size(118, 27);
            tbCodigo.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(412, 6);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 3;
            label4.Text = "Data da Compra";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(413, 149);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 2;
            label3.Text = "Quantidade";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(279, 6);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 1;
            label2.Text = "Nota Fiscal";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 6);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Código";
            // 
            // panel2
            // 
            panel2.Controls.Add(btGerarParcelas);
            panel2.Controls.Add(lbTotalDaCompra);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(dgvParcelas);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(778, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(459, 415);
            panel2.TabIndex = 4;
            // 
            // btGerarParcelas
            // 
            btGerarParcelas.Location = new Point(12, 276);
            btGerarParcelas.Name = "btGerarParcelas";
            btGerarParcelas.Size = new Size(433, 123);
            btGerarParcelas.TabIndex = 5;
            btGerarParcelas.Text = "Gerar Parcelas";
            btGerarParcelas.UseVisualStyleBackColor = true;
            btGerarParcelas.Click += btGerarParcelas_Click;
            // 
            // lbTotalDaCompra
            // 
            lbTotalDaCompra.AutoSize = true;
            lbTotalDaCompra.Location = new Point(141, 241);
            lbTotalDaCompra.Name = "lbTotalDaCompra";
            lbTotalDaCompra.Size = new Size(36, 20);
            lbTotalDaCompra.TabIndex = 8;
            lbTotalDaCompra.Text = "0,00";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 241);
            label8.Name = "label8";
            label8.Size = new Size(123, 20);
            label8.TabIndex = 7;
            label8.Text = "Total da Compra:";
            // 
            // dgvParcelas
            // 
            dgvParcelas.AllowUserToAddRows = false;
            dgvParcelas.AllowUserToDeleteRows = false;
            dgvParcelas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParcelas.Location = new Point(12, 34);
            dgvParcelas.Name = "dgvParcelas";
            dgvParcelas.RowHeadersWidth = 51;
            dgvParcelas.Size = new Size(433, 188);
            dgvParcelas.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 6);
            label5.Name = "label5";
            label5.Size = new Size(140, 20);
            label5.TabIndex = 5;
            label5.Text = "Parcelas da Compra";
            // 
            // FrmMovimentacaoCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1249, 553);
            Controls.Add(panel2);
            Controls.Add(pnBotoes);
            Controls.Add(pnDados);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmMovimentacaoCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Compra";
            pnBotoes.ResumeLayout(false);
            pnDados.ResumeLayout(false);
            pnDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvParcelas).EndInit();
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
        private TextBox tbCodigo;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btLocalizarFornecedor;
        private TextBox tbCodFornecedor;
        private Label label6;
        private DateTimePicker dtpDataCompra;
        private TextBox tbNotaFiscal;
        private Panel panel1;
        private Button btLocalizarProduto;
        private TextBox tbCodProduto;
        private Label label7;
        private Label lbProduto;
        private Button btAdicionarItem;
        private TextBox tbValorUnitario;
        private Label label9;
        private TextBox tbQuantidade;
        private TextBox tbTotal;
        private DateTimePicker dtpDataInicialPagamento;
        private ComboBox cbTipoPagamento;
        private ComboBox cbParcelas;
        private Label label10;
        private DataGridView dgvItens;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label lbFornecedor;
        private Panel panel2;
        private Label label5;
        private DataGridView dgvParcelas;
        private Label lbTotalDaCompra;
        private Label label8;
        private Button btGerarParcelas;
    }
}