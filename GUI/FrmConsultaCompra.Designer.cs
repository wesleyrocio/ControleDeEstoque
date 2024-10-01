namespace GUI
{
    partial class FrmConsultaCompra
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
            dgvDados = new DataGridView();
            buttonPesquisar = new Button();
            textBoxProduto = new TextBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            rbDataCompra = new RadioButton();
            rbFornecedor = new RadioButton();
            rbTodas = new RadioButton();
            panelData = new Panel();
            dtFinal = new DateTimePicker();
            dtInicial = new DateTimePicker();
            label3 = new Label();
            label2 = new Label();
            panelFornecedor = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            groupBox1.SuspendLayout();
            panelData.SuspendLayout();
            panelFornecedor.SuspendLayout();
            SuspendLayout();
            // 
            // dgvDados
            // 
            dgvDados.AllowUserToAddRows = false;
            dgvDados.AllowUserToDeleteRows = false;
            dgvDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDados.Location = new Point(12, 206);
            dgvDados.MultiSelect = false;
            dgvDados.Name = "dgvDados";
            dgvDados.ReadOnly = true;
            dgvDados.RowHeadersWidth = 51;
            dgvDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDados.Size = new Size(758, 336);
            dgvDados.TabIndex = 18;
            dgvDados.CellMouseDoubleClick += dgvDados_CellMouseDoubleClick;
            // 
            // buttonPesquisar
            // 
            buttonPesquisar.Location = new Point(657, 126);
            buttonPesquisar.Name = "buttonPesquisar";
            buttonPesquisar.Size = new Size(106, 55);
            buttonPesquisar.TabIndex = 17;
            buttonPesquisar.Text = "Localizar";
            buttonPesquisar.UseVisualStyleBackColor = true;
            buttonPesquisar.Click += buttonPesquisar_Click;
            // 
            // textBoxProduto
            // 
            textBoxProduto.Location = new Point(17, 25);
            textBoxProduto.Name = "textBoxProduto";
            textBoxProduto.Size = new Size(283, 27);
            textBoxProduto.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 2);
            label1.Name = "label1";
            label1.Size = new Size(84, 20);
            label1.TabIndex = 15;
            label1.Text = "Fornecedor";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(rbDataCompra);
            groupBox1.Controls.Add(rbFornecedor);
            groupBox1.Controls.Add(rbTodas);
            groupBox1.Font = new Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(758, 55);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo de Consulta";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 9F);
            radioButton1.Location = new Point(595, 24);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(156, 24);
            radioButton1.TabIndex = 25;
            radioButton1.Text = "Parcelas em aberto";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbDataCompra
            // 
            rbDataCompra.AutoSize = true;
            rbDataCompra.Font = new Font("Segoe UI", 9F);
            rbDataCompra.Location = new Point(394, 24);
            rbDataCompra.Name = "rbDataCompra";
            rbDataCompra.Size = new Size(140, 24);
            rbDataCompra.TabIndex = 24;
            rbDataCompra.Text = "Data da Compra";
            rbDataCompra.UseVisualStyleBackColor = true;
            // 
            // rbFornecedor
            // 
            rbFornecedor.AutoSize = true;
            rbFornecedor.Font = new Font("Segoe UI", 9F);
            rbFornecedor.Location = new Point(228, 24);
            rbFornecedor.Name = "rbFornecedor";
            rbFornecedor.Size = new Size(105, 24);
            rbFornecedor.TabIndex = 23;
            rbFornecedor.Text = "Fornecedor";
            rbFornecedor.UseVisualStyleBackColor = true;
            // 
            // rbTodas
            // 
            rbTodas.AutoSize = true;
            rbTodas.Checked = true;
            rbTodas.Font = new Font("Segoe UI", 9F);
            rbTodas.Location = new Point(17, 24);
            rbTodas.Name = "rbTodas";
            rbTodas.Size = new Size(150, 24);
            rbTodas.TabIndex = 22;
            rbTodas.TabStop = true;
            rbTodas.Text = "Todas as Compras";
            rbTodas.UseVisualStyleBackColor = true;
            // 
            // panelData
            // 
            panelData.Controls.Add(dtFinal);
            panelData.Controls.Add(dtInicial);
            panelData.Controls.Add(label3);
            panelData.Controls.Add(label2);
            panelData.Location = new Point(12, 66);
            panelData.Name = "panelData";
            panelData.Size = new Size(758, 54);
            panelData.TabIndex = 23;
            // 
            // dtFinal
            // 
            dtFinal.Location = new Point(501, 13);
            dtFinal.Name = "dtFinal";
            dtFinal.Size = new Size(250, 27);
            dtFinal.TabIndex = 3;
            // 
            // dtInicial
            // 
            dtInicial.Location = new Point(110, 13);
            dtInicial.Name = "dtInicial";
            dtInicial.Size = new Size(250, 27);
            dtInicial.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(416, 18);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 1;
            label3.Text = "Data Final:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 18);
            label2.Name = "label2";
            label2.Size = new Size(87, 20);
            label2.TabIndex = 0;
            label2.Text = "Data Inicial:";
            // 
            // panelFornecedor
            // 
            panelFornecedor.Controls.Add(textBoxProduto);
            panelFornecedor.Controls.Add(label1);
            panelFornecedor.Location = new Point(12, 126);
            panelFornecedor.Name = "panelFornecedor";
            panelFornecedor.Size = new Size(639, 55);
            panelFornecedor.TabIndex = 24;
            // 
            // FrmConsultaCompra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(panelFornecedor);
            Controls.Add(panelData);
            Controls.Add(groupBox1);
            Controls.Add(dgvDados);
            Controls.Add(buttonPesquisar);
            Name = "FrmConsultaCompra";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ConsultaMovimentacaoCompra";
            Load += FrmConsultaCompra_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelData.ResumeLayout(false);
            panelData.PerformLayout();
            panelFornecedor.ResumeLayout(false);
            panelFornecedor.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvDados;
        private Button buttonPesquisar;
        private TextBox textBoxProduto;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton rbDataCompra;
        private RadioButton rbFornecedor;
        private RadioButton rbTodas;
        private Panel panelData;
        private DateTimePicker dtInicial;
        private Label label3;
        private Label label2;
        private DateTimePicker dtFinal;
        private Panel panelFornecedor;
    }
}