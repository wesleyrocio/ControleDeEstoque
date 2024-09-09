namespace GUI
{
    partial class FrmConsultaUndMedida
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
            textBoxCategoria = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDados).BeginInit();
            SuspendLayout();
            // 
            // dgvDados
            // 
            dgvDados.AllowUserToAddRows = false;
            dgvDados.AllowUserToDeleteRows = false;
            dgvDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDados.Location = new Point(12, 68);
            dgvDados.MultiSelect = false;
            dgvDados.Name = "dgvDados";
            dgvDados.ReadOnly = true;
            dgvDados.RowHeadersWidth = 51;
            dgvDados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDados.Size = new Size(758, 474);
            dgvDados.TabIndex = 7;
            dgvDados.CellDoubleClick += dgvDados_CellDoubleClick;
            // 
            // buttonPesquisar
            // 
            buttonPesquisar.Location = new Point(676, 33);
            buttonPesquisar.Name = "buttonPesquisar";
            buttonPesquisar.Size = new Size(94, 29);
            buttonPesquisar.TabIndex = 6;
            buttonPesquisar.Text = "Localizar";
            buttonPesquisar.UseVisualStyleBackColor = true;
            buttonPesquisar.Click += buttonPesquisar_Click;
            // 
            // textBoxCategoria
            // 
            textBoxCategoria.Location = new Point(12, 33);
            textBoxCategoria.Name = "textBoxCategoria";
            textBoxCategoria.Size = new Size(658, 27);
            textBoxCategoria.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(141, 20);
            label1.TabIndex = 4;
            label1.Text = "Unidade de Medida";
            // 
            // FrmConsultaUndMedida
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(dgvDados);
            Controls.Add(buttonPesquisar);
            Controls.Add(textBoxCategoria);
            Controls.Add(label1);
            Name = "FrmConsultaUndMedida";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCadastroUndMedida";
            Load += FrmConsultaUndMedida_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDados).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDados;
        private Button buttonPesquisar;
        private TextBox textBoxCategoria;
        private Label label1;
    }
}