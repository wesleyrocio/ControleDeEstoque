namespace GUI
{
    partial class FrmModeloDeFormularioDeCadastro
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
            pnDados = new Panel();
            pnBotoes = new Panel();
            buttonCancelar = new Button();
            buttonSalvar = new Button();
            buttonExcluir = new Button();
            buttonAlterar = new Button();
            buttonLocalizar = new Button();
            buttonInserir = new Button();
            pnBotoes.SuspendLayout();
            SuspendLayout();
            // 
            // pnDados
            // 
            pnDados.Location = new Point(12, 12);
            pnDados.Name = "pnDados";
            pnDados.Size = new Size(758, 417);
            pnDados.TabIndex = 0;
            // 
            // pnBotoes
            // 
            pnBotoes.Controls.Add(buttonCancelar);
            pnBotoes.Controls.Add(buttonSalvar);
            pnBotoes.Controls.Add(buttonExcluir);
            pnBotoes.Controls.Add(buttonAlterar);
            pnBotoes.Controls.Add(buttonLocalizar);
            pnBotoes.Controls.Add(buttonInserir);
            pnBotoes.Location = new Point(12, 435);
            pnBotoes.Name = "pnBotoes";
            pnBotoes.Size = new Size(758, 117);
            pnBotoes.TabIndex = 0;
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
            // 
            // FrmModeloDeFormularioDeCadastro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 552);
            Controls.Add(pnBotoes);
            Controls.Add(pnDados);
            Name = "FrmModeloDeFormularioDeCadastro";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Modelo de Formulário de Cadastro (altere esse texto)";
            pnBotoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        protected Panel pnDados;
        protected Panel pnBotoes;
        protected Button buttonCancelar;
        protected Button buttonSalvar;
        protected Button buttonExcluir;
        protected Button buttonAlterar;
        protected Button buttonLocalizar;
        protected Button buttonInserir;
    }
}