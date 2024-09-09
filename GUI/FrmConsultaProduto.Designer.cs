namespace GUI
{
    partial class FrmConsultaProduto
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
            rbProduto = new RadioButton();
            rbCategoria = new RadioButton();
            rbSubCategoria = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            SuspendLayout();
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
            dgvDados.TabIndex = 11;
            dgvDados.CellMouseDoubleClick += dgvDados_CellMouseDoubleClick;
            // 
            // buttonPesquisar
            // 
            buttonPesquisar.Location = new Point(676, 33);
            buttonPesquisar.Name = "buttonPesquisar";
            buttonPesquisar.Size = new Size(94, 29);
            buttonPesquisar.TabIndex = 10;
            buttonPesquisar.Text = "Localizar";
            buttonPesquisar.UseVisualStyleBackColor = true;
            buttonPesquisar.Click += buttonPesquisar_Click;
            // 
            // textBoxProduto
            // 
            textBoxProduto.Location = new Point(12, 33);
            textBoxProduto.Name = "textBoxProduto";
            textBoxProduto.Size = new Size(658, 27);
            textBoxProduto.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 8;
            label1.Text = "Produto";
            // 
            // rbProduto
            // 
            rbProduto.AutoSize = true;
            rbProduto.Checked = true;
            rbProduto.Location = new Point(12, 66);
            rbProduto.Name = "rbProduto";
            rbProduto.Size = new Size(83, 24);
            rbProduto.TabIndex = 12;
            rbProduto.TabStop = true;
            rbProduto.Text = "Produto";
            rbProduto.UseVisualStyleBackColor = true;
            // 
            // rbCategoria
            // 
            rbCategoria.AutoSize = true;
            rbCategoria.Location = new Point(101, 66);
            rbCategoria.Name = "rbCategoria";
            rbCategoria.Size = new Size(95, 24);
            rbCategoria.TabIndex = 13;
            rbCategoria.Text = "Categoria";
            rbCategoria.UseVisualStyleBackColor = true;
            // 
            // rbSubCategoria
            // 
            rbSubCategoria.AutoSize = true;
            rbSubCategoria.Location = new Point(202, 66);
            rbSubCategoria.Name = "rbSubCategoria";
            rbSubCategoria.Size = new Size(124, 24);
            rbSubCategoria.TabIndex = 14;
            rbSubCategoria.Text = "Sub Categoria";
            rbSubCategoria.UseVisualStyleBackColor = true;
            // 
            // FrmConsultaProduto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(rbSubCategoria);
            Controls.Add(rbCategoria);
            Controls.Add(rbProduto);
            Controls.Add(dgvDados);
            Controls.Add(buttonPesquisar);
            Controls.Add(textBoxProduto);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmConsultaProduto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmConsultaProduto";
            Load += FrmConsultaProduto_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDados;
        private Button buttonPesquisar;
        private TextBox textBoxProduto;
        private Label label1;
        private RadioButton rbProduto;
        private RadioButton rbCategoria;
        private RadioButton rbSubCategoria;
    }
}