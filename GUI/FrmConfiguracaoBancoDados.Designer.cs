namespace GUI
{
    partial class FrmConfiguracaoBancoDados
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
            tbServidor = new TextBox();
            tbBancoDeDados = new TextBox();
            label2 = new Label();
            tbUsuario = new TextBox();
            label3 = new Label();
            tbSenha = new TextBox();
            label4 = new Label();
            btSalvar = new Button();
            panelCampos = new Panel();
            label5 = new Label();
            cbAutentificacao = new ComboBox();
            panelUsuarioSenha = new Panel();
            button1 = new Button();
            panelBotoes = new Panel();
            btTestar = new Button();
            panelCampos.SuspendLayout();
            panelUsuarioSenha.SuspendLayout();
            panelBotoes.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 43);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 0;
            label1.Text = "Servidor";
            // 
            // tbServidor
            // 
            tbServidor.Location = new Point(202, 66);
            tbServidor.Name = "tbServidor";
            tbServidor.Size = new Size(365, 27);
            tbServidor.TabIndex = 1;
            tbServidor.KeyDown += tbServidor_KeyDown;
            tbServidor.KeyUp += tbServidor_KeyUp;
            // 
            // tbBancoDeDados
            // 
            tbBancoDeDados.Location = new Point(202, 136);
            tbBancoDeDados.Name = "tbBancoDeDados";
            tbBancoDeDados.Size = new Size(365, 27);
            tbBancoDeDados.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(202, 113);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 2;
            label2.Text = "Banco de Dados";
            // 
            // tbUsuario
            // 
            tbUsuario.Location = new Point(17, 31);
            tbUsuario.Name = "tbUsuario";
            tbUsuario.Size = new Size(365, 27);
            tbUsuario.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 8);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 4;
            label3.Text = "Usuário";
            // 
            // tbSenha
            // 
            tbSenha.Location = new Point(17, 101);
            tbSenha.Name = "tbSenha";
            tbSenha.PasswordChar = '*';
            tbSenha.Size = new Size(365, 27);
            tbSenha.TabIndex = 7;
            tbSenha.KeyPress += tbSenha_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 78);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 6;
            label4.Text = "Senha";
            // 
            // btSalvar
            // 
            btSalvar.Location = new Point(651, 0);
            btSalvar.Name = "btSalvar";
            btSalvar.Size = new Size(94, 72);
            btSalvar.TabIndex = 8;
            btSalvar.Text = "Salvar";
            btSalvar.UseVisualStyleBackColor = true;
            btSalvar.Click += btSalvar_Click;
            // 
            // panelCampos
            // 
            panelCampos.Controls.Add(label5);
            panelCampos.Controls.Add(cbAutentificacao);
            panelCampos.Controls.Add(panelUsuarioSenha);
            panelCampos.Controls.Add(label1);
            panelCampos.Controls.Add(tbServidor);
            panelCampos.Controls.Add(label2);
            panelCampos.Controls.Add(tbBancoDeDados);
            panelCampos.Dock = DockStyle.Fill;
            panelCampos.ForeColor = SystemColors.ActiveCaptionText;
            panelCampos.Location = new Point(0, 0);
            panelCampos.Name = "panelCampos";
            panelCampos.Size = new Size(782, 553);
            panelCampos.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(202, 179);
            label5.Name = "label5";
            label5.Size = new Size(105, 20);
            label5.TabIndex = 11;
            label5.Text = "Autentificação";
            // 
            // cbAutentificacao
            // 
            cbAutentificacao.FormattingEnabled = true;
            cbAutentificacao.Items.AddRange(new object[] { "Windows", "Usuário e Senha" });
            cbAutentificacao.Location = new Point(202, 202);
            cbAutentificacao.Name = "cbAutentificacao";
            cbAutentificacao.Size = new Size(365, 28);
            cbAutentificacao.TabIndex = 10;
            cbAutentificacao.SelectedIndexChanged += cbAutentificacao_SelectedIndexChanged;
            // 
            // panelUsuarioSenha
            // 
            panelUsuarioSenha.Controls.Add(tbSenha);
            panelUsuarioSenha.Controls.Add(button1);
            panelUsuarioSenha.Controls.Add(label3);
            panelUsuarioSenha.Controls.Add(tbUsuario);
            panelUsuarioSenha.Controls.Add(label4);
            panelUsuarioSenha.Location = new Point(185, 276);
            panelUsuarioSenha.Name = "panelUsuarioSenha";
            panelUsuarioSenha.Size = new Size(443, 170);
            panelUsuarioSenha.TabIndex = 9;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.AppWorkspace;
            button1.Font = new Font("Webdings", 24F, FontStyle.Regular, GraphicsUnit.Point, 2);
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(388, 99);
            button1.Name = "button1";
            button1.Size = new Size(48, 41);
            button1.TabIndex = 8;
            button1.Text = "$";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panelBotoes
            // 
            panelBotoes.Controls.Add(btTestar);
            panelBotoes.Controls.Add(btSalvar);
            panelBotoes.Dock = DockStyle.Bottom;
            panelBotoes.Location = new Point(0, 478);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Size = new Size(782, 75);
            panelBotoes.TabIndex = 10;
            // 
            // btTestar
            // 
            btTestar.Location = new Point(551, 0);
            btTestar.Name = "btTestar";
            btTestar.Size = new Size(94, 72);
            btTestar.TabIndex = 9;
            btTestar.Text = "Testar";
            btTestar.UseVisualStyleBackColor = true;
            btTestar.Click += btTestar_Click;
            // 
            // FrmConfiguracaoBancoDados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(panelBotoes);
            Controls.Add(panelCampos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmConfiguracaoBancoDados";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuração do Banco de Dados";
            Load += FrmConfiguracaoBancoDados_Load;
            panelCampos.ResumeLayout(false);
            panelCampos.PerformLayout();
            panelUsuarioSenha.ResumeLayout(false);
            panelUsuarioSenha.PerformLayout();
            panelBotoes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox tbServidor;
        private TextBox tbBancoDeDados;
        private Label label2;
        private TextBox tbUsuario;
        private Label label3;
        private TextBox tbSenha;
        private Label label4;
        private Button btSalvar;
        private Panel panelCampos;
        private Panel panelBotoes;
        private Button button1;
        private Panel panelUsuarioSenha;
        private Label label5;
        private ComboBox cbAutentificacao;
        private Button btTestar;
    }
}