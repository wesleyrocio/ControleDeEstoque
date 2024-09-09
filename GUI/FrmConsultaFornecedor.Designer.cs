namespace GUI
{
    partial class FrmConsultaFornecedor
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
            rbEmail = new RadioButton();
            rbCNPJ = new RadioButton();
            rbFornecedor = new RadioButton();
            dgvDados = new DataGridView();
            buttonPesquisar = new Button();
            textBoxPesquisa = new TextBox();
            lbBusca = new Label();
            rbRazaoSocial = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            SuspendLayout();
            // 
            // rbEmail
            // 
            rbEmail.AutoSize = true;
            rbEmail.Location = new Point(327, 66);
            rbEmail.Name = "rbEmail";
            rbEmail.Size = new Size(73, 24);
            rbEmail.TabIndex = 28;
            rbEmail.Text = "e-mail";
            rbEmail.UseVisualStyleBackColor = true;
            // 
            // rbCNPJ
            // 
            rbCNPJ.AutoSize = true;
            rbCNPJ.Location = new Point(254, 66);
            rbCNPJ.Name = "rbCNPJ";
            rbCNPJ.Size = new Size(62, 24);
            rbCNPJ.TabIndex = 27;
            rbCNPJ.Text = "CNPJ";
            rbCNPJ.UseVisualStyleBackColor = true;
            // 
            // rbFornecedor
            // 
            rbFornecedor.AutoSize = true;
            rbFornecedor.Checked = true;
            rbFornecedor.Location = new Point(12, 66);
            rbFornecedor.Name = "rbFornecedor";
            rbFornecedor.Size = new Size(105, 24);
            rbFornecedor.TabIndex = 26;
            rbFornecedor.TabStop = true;
            rbFornecedor.Text = "Fornecedor";
            rbFornecedor.UseVisualStyleBackColor = true;
            // 
            // dgvDados
            // 
            dgvDados.AllowUserToAddRows = false;
            dgvDados.AllowUserToDeleteRows = false;
            dgvDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDados.Location = new Point(12, 96);
            dgvDados.MultiSelect = false;
            dgvDados.Name = "dgvDados";
            dgvDados.ReadOnly = true;
            dgvDados.RowHeadersWidth = 51;
            dgvDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDados.Size = new Size(758, 446);
            dgvDados.TabIndex = 25;
            dgvDados.CellMouseDoubleClick += dgvDados_CellMouseDoubleClick;
            // 
            // buttonPesquisar
            // 
            buttonPesquisar.Location = new Point(676, 33);
            buttonPesquisar.Name = "buttonPesquisar";
            buttonPesquisar.Size = new Size(94, 29);
            buttonPesquisar.TabIndex = 24;
            buttonPesquisar.Text = "Localizar";
            buttonPesquisar.UseVisualStyleBackColor = true;
            buttonPesquisar.Click += buttonPesquisar_Click;
            // 
            // textBoxPesquisa
            // 
            textBoxPesquisa.Location = new Point(12, 33);
            textBoxPesquisa.Name = "textBoxPesquisa";
            textBoxPesquisa.Size = new Size(658, 27);
            textBoxPesquisa.TabIndex = 23;
            // 
            // lbBusca
            // 
            lbBusca.AutoSize = true;
            lbBusca.Location = new Point(12, 10);
            lbBusca.Name = "lbBusca";
            lbBusca.Size = new Size(50, 20);
            lbBusca.TabIndex = 22;
            lbBusca.Text = "Nome";
            // 
            // rbRazaoSocial
            // 
            rbRazaoSocial.AutoSize = true;
            rbRazaoSocial.Location = new Point(128, 66);
            rbRazaoSocial.Name = "rbRazaoSocial";
            rbRazaoSocial.Size = new Size(115, 24);
            rbRazaoSocial.TabIndex = 29;
            rbRazaoSocial.Text = "Razão Social";
            rbRazaoSocial.UseVisualStyleBackColor = true;
            // 
            // FrmConsultaFornecedor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(rbRazaoSocial);
            Controls.Add(rbEmail);
            Controls.Add(rbCNPJ);
            Controls.Add(rbFornecedor);
            Controls.Add(dgvDados);
            Controls.Add(buttonPesquisar);
            Controls.Add(textBoxPesquisa);
            Controls.Add(lbBusca);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmConsultaFornecedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmConsultaFornecedor";
            Load += FrmConsultaFornecedor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbEmail;
        private RadioButton rbCNPJ;
        private RadioButton rbFornecedor;
        private DataGridView dgvDados;
        private Button buttonPesquisar;
        private TextBox textBoxPesquisa;
        private Label lbBusca;
        private RadioButton rbRazaoSocial;
    }
}