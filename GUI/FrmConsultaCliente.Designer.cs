namespace GUI
{
    partial class FrmConsultaCliente
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
            rbCPFCNPJ = new RadioButton();
            rbCliente = new RadioButton();
            dgvDados = new DataGridView();
            buttonPesquisar = new Button();
            textBoxPesquisa = new TextBox();
            lbBusca = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            SuspendLayout();
            // 
            // rbEmail
            // 
            rbEmail.AutoSize = true;
            rbEmail.Location = new Point(203, 66);
            rbEmail.Name = "rbEmail";
            rbEmail.Size = new Size(73, 24);
            rbEmail.TabIndex = 21;
            rbEmail.Text = "e-mail";
            rbEmail.UseVisualStyleBackColor = true;
            // 
            // rbCPFCNPJ
            // 
            rbCPFCNPJ.AutoSize = true;
            rbCPFCNPJ.Location = new Point(95, 66);
            rbCPFCNPJ.Name = "rbCPFCNPJ";
            rbCPFCNPJ.Size = new Size(100, 24);
            rbCPFCNPJ.TabIndex = 20;
            rbCPFCNPJ.Text = "CPF / CNPJ";
            rbCPFCNPJ.UseVisualStyleBackColor = true;
            // 
            // rbCliente
            // 
            rbCliente.AutoSize = true;
            rbCliente.Checked = true;
            rbCliente.Location = new Point(12, 66);
            rbCliente.Name = "rbCliente";
            rbCliente.Size = new Size(76, 24);
            rbCliente.TabIndex = 19;
            rbCliente.TabStop = true;
            rbCliente.Text = "Cliente";
            rbCliente.UseVisualStyleBackColor = true;
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
            dgvDados.TabIndex = 18;
            dgvDados.CellFormatting += dgvDados_CellFormatting;
            dgvDados.CellMouseDoubleClick += dgvDados_CellMouseDoubleClick;
            // 
            // buttonPesquisar
            // 
            buttonPesquisar.Location = new Point(676, 33);
            buttonPesquisar.Name = "buttonPesquisar";
            buttonPesquisar.Size = new Size(94, 29);
            buttonPesquisar.TabIndex = 17;
            buttonPesquisar.Text = "Localizar";
            buttonPesquisar.UseVisualStyleBackColor = true;
            buttonPesquisar.Click += buttonPesquisar_Click_1;
            // 
            // textBoxPesquisa
            // 
            textBoxPesquisa.Location = new Point(12, 33);
            textBoxPesquisa.Name = "textBoxPesquisa";
            textBoxPesquisa.Size = new Size(658, 27);
            textBoxPesquisa.TabIndex = 16;
            // 
            // lbBusca
            // 
            lbBusca.AutoSize = true;
            lbBusca.Location = new Point(12, 10);
            lbBusca.Name = "lbBusca";
            lbBusca.Size = new Size(55, 20);
            lbBusca.TabIndex = 15;
            lbBusca.Text = "Cliente";
            // 
            // FrmConsultaCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(rbEmail);
            Controls.Add(rbCPFCNPJ);
            Controls.Add(rbCliente);
            Controls.Add(dgvDados);
            Controls.Add(buttonPesquisar);
            Controls.Add(textBoxPesquisa);
            Controls.Add(lbBusca);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmConsultaCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmConsultaCliente";
            Load += FrmConsultaCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbEmail;
        private RadioButton rbCPFCNPJ;
        private RadioButton rbCliente;
        private DataGridView dgvDados;
        private Button buttonPesquisar;
        private TextBox textBoxPesquisa;
        private Label lbBusca;
    }
}