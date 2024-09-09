namespace GUI
{
    partial class FrmCadastroSubCategoria
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
            label3 = new Label();
            cbCatCod = new ComboBox();
            tbNome = new TextBox();
            tbScatCod = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnAddCategoria = new Button();
            pnBotoes.SuspendLayout();
            pnDados.SuspendLayout();
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
            pnBotoes.TabIndex = 1;
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
            pnDados.Controls.Add(btnAddCategoria);
            pnDados.Controls.Add(label3);
            pnDados.Controls.Add(cbCatCod);
            pnDados.Controls.Add(tbNome);
            pnDados.Controls.Add(tbScatCod);
            pnDados.Controls.Add(label2);
            pnDados.Controls.Add(label1);
            pnDados.Location = new Point(12, 6);
            pnDados.Name = "pnDados";
            pnDados.Size = new Size(758, 417);
            pnDados.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 161);
            label3.Name = "label3";
            label3.Size = new Size(140, 20);
            label3.TabIndex = 8;
            label3.Text = "Nome da Categoria";
            // 
            // cbCatCod
            // 
            cbCatCod.FormattingEnabled = true;
            cbCatCod.Location = new Point(18, 184);
            cbCatCod.Name = "cbCatCod";
            cbCatCod.Size = new Size(358, 28);
            cbCatCod.TabIndex = 3;
            // 
            // tbNome
            // 
            tbNome.Location = new Point(18, 120);
            tbNome.Name = "tbNome";
            tbNome.Size = new Size(714, 27);
            tbNome.TabIndex = 7;
            // 
            // tbScatCod
            // 
            tbScatCod.Location = new Point(18, 56);
            tbScatCod.Name = "tbScatCod";
            tbScatCod.ReadOnly = true;
            tbScatCod.Size = new Size(125, 27);
            tbScatCod.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 96);
            label2.Name = "label2";
            label2.Size = new Size(169, 20);
            label2.TabIndex = 5;
            label2.Text = "Nome da Sub Categoria";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 33);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 4;
            label1.Text = "Código";
            // 
            // btnAddCategoria
            // 
            btnAddCategoria.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddCategoria.Location = new Point(382, 184);
            btnAddCategoria.Name = "btnAddCategoria";
            btnAddCategoria.Size = new Size(46, 28);
            btnAddCategoria.TabIndex = 9;
            btnAddCategoria.Text = "+";
            btnAddCategoria.UseVisualStyleBackColor = true;
            btnAddCategoria.Click += btnAddCategoria_Click;
            // 
            // FrmCadastroSubCategoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(pnBotoes);
            Controls.Add(pnDados);
            Name = "FrmCadastroSubCategoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Sub Categoria";
            Load += FrmCadastroSubCategoria_Load;
            KeyDown += FrmCadastroSubCategoria_KeyDown;
            pnBotoes.ResumeLayout(false);
            pnDados.ResumeLayout(false);
            pnDados.PerformLayout();
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
        private TextBox tbNome;
        private TextBox tbScatCod;
        private Label label2;
        private Label label1;
        private Label label3;
        private ComboBox cbCatCod;
        private Button btnAddCategoria;
    }
}