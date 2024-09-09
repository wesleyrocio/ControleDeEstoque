namespace GUI
{
    partial class FrmConsultaCategoria
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
            label1 = new Label();
            textBoxCategoria = new TextBox();
            buttonPesquisar = new Button();
            dgvDados = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 0;
            label1.Text = "Categoria";
            // 
            // textBoxCategoria
            // 
            textBoxCategoria.Location = new Point(12, 32);
            textBoxCategoria.Name = "textBoxCategoria";
            textBoxCategoria.Size = new Size(658, 27);
            textBoxCategoria.TabIndex = 1;
            // 
            // buttonPesquisar
            // 
            buttonPesquisar.Location = new Point(676, 32);
            buttonPesquisar.Name = "buttonPesquisar";
            buttonPesquisar.Size = new Size(94, 29);
            buttonPesquisar.TabIndex = 2;
            buttonPesquisar.Text = "Localizar";
            buttonPesquisar.UseVisualStyleBackColor = true;
            buttonPesquisar.Click += buttonPesquisar_Click;
            // 
            // dgvDados
            // 
            dgvDados.AllowUserToAddRows = false;
            dgvDados.AllowUserToDeleteRows = false;
            dgvDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDados.Location = new Point(12, 67);
            dgvDados.MultiSelect = false;
            dgvDados.Name = "dgvDados";
            dgvDados.ReadOnly = true;
            dgvDados.RowHeadersWidth = 51;
            dgvDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDados.Size = new Size(758, 474);
            dgvDados.TabIndex = 3;
            dgvDados.CellDoubleClick += dgvDados_CellDoubleClick;
            // 
            // FrmConsultaCategoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(dgvDados);
            Controls.Add(buttonPesquisar);
            Controls.Add(textBoxCategoria);
            Controls.Add(label1);
            Name = "FrmConsultaCategoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consulta Categoria";
            Load += FrmConsultaCategoria_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxCategoria;
        private Button buttonPesquisar;
        private DataGridView dgvDados;
    }
}