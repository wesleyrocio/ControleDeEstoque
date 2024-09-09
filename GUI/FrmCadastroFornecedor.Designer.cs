namespace GUI
{
    partial class FrmCadastroFornecedor
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
            lbEmailInvalido = new Label();
            lbValorInvalido = new Label();
            tbNumero = new TextBox();
            lbNumero = new Label();
            tbCelular = new TextBox();
            lbCelular = new Label();
            tbTelefone = new TextBox();
            lbTelefone = new Label();
            tbEmail = new TextBox();
            lbEmail = new Label();
            tbBairro = new TextBox();
            lbBairro = new Label();
            tbRua = new TextBox();
            lbRua = new Label();
            tbCidade = new TextBox();
            lbCidade = new Label();
            tbEstado = new TextBox();
            lbEstado = new Label();
            tbCep = new TextBox();
            lbCep = new Label();
            tbRgIe = new TextBox();
            lbRgIe = new Label();
            tbCpfCnpj = new TextBox();
            lbCpfCnpj = new Label();
            tbRazaoSocial = new TextBox();
            lbRazaoSocial = new Label();
            tbNome = new TextBox();
            tbCodigo = new TextBox();
            lbNome = new Label();
            label1 = new Label();
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
            pnBotoes.TabIndex = 5;
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
            pnDados.Controls.Add(lbEmailInvalido);
            pnDados.Controls.Add(lbValorInvalido);
            pnDados.Controls.Add(tbNumero);
            pnDados.Controls.Add(lbNumero);
            pnDados.Controls.Add(tbCelular);
            pnDados.Controls.Add(lbCelular);
            pnDados.Controls.Add(tbTelefone);
            pnDados.Controls.Add(lbTelefone);
            pnDados.Controls.Add(tbEmail);
            pnDados.Controls.Add(lbEmail);
            pnDados.Controls.Add(tbBairro);
            pnDados.Controls.Add(lbBairro);
            pnDados.Controls.Add(tbRua);
            pnDados.Controls.Add(lbRua);
            pnDados.Controls.Add(tbCidade);
            pnDados.Controls.Add(lbCidade);
            pnDados.Controls.Add(tbEstado);
            pnDados.Controls.Add(lbEstado);
            pnDados.Controls.Add(tbCep);
            pnDados.Controls.Add(lbCep);
            pnDados.Controls.Add(tbRgIe);
            pnDados.Controls.Add(lbRgIe);
            pnDados.Controls.Add(tbCpfCnpj);
            pnDados.Controls.Add(lbCpfCnpj);
            pnDados.Controls.Add(tbRazaoSocial);
            pnDados.Controls.Add(lbRazaoSocial);
            pnDados.Controls.Add(tbNome);
            pnDados.Controls.Add(tbCodigo);
            pnDados.Controls.Add(lbNome);
            pnDados.Controls.Add(label1);
            pnDados.Location = new Point(12, 6);
            pnDados.Name = "pnDados";
            pnDados.Size = new Size(758, 417);
            pnDados.TabIndex = 4;
            // 
            // lbEmailInvalido
            // 
            lbEmailInvalido.AutoSize = true;
            lbEmailInvalido.ForeColor = Color.Red;
            lbEmailInvalido.Location = new Point(657, 303);
            lbEmailInvalido.Name = "lbEmailInvalido";
            lbEmailInvalido.Size = new Size(75, 20);
            lbEmailInvalido.TabIndex = 30;
            lbEmailInvalido.Text = "INVÁLIDO";
            lbEmailInvalido.Visible = false;
            // 
            // lbValorInvalido
            // 
            lbValorInvalido.AutoSize = true;
            lbValorInvalido.ForeColor = Color.Red;
            lbValorInvalido.Location = new Point(85, 181);
            lbValorInvalido.Name = "lbValorInvalido";
            lbValorInvalido.Size = new Size(75, 20);
            lbValorInvalido.TabIndex = 29;
            lbValorInvalido.Text = "INVÁLIDO";
            lbValorInvalido.Visible = false;
            // 
            // tbNumero
            // 
            tbNumero.Location = new Point(644, 267);
            tbNumero.Name = "tbNumero";
            tbNumero.Size = new Size(88, 27);
            tbNumero.TabIndex = 28;
            // 
            // lbNumero
            // 
            lbNumero.AutoSize = true;
            lbNumero.Location = new Point(644, 244);
            lbNumero.Name = "lbNumero";
            lbNumero.Size = new Size(63, 20);
            lbNumero.TabIndex = 27;
            lbNumero.Text = "Número";
            // 
            // tbCelular
            // 
            tbCelular.Location = new Point(381, 387);
            tbCelular.Name = "tbCelular";
            tbCelular.Size = new Size(351, 27);
            tbCelular.TabIndex = 26;
            tbCelular.TextChanged += tbCelular_TextChanged;
            tbCelular.Leave += tbCelular_Leave;
            // 
            // lbCelular
            // 
            lbCelular.AutoSize = true;
            lbCelular.Location = new Point(381, 364);
            lbCelular.Name = "lbCelular";
            lbCelular.Size = new Size(55, 20);
            lbCelular.TabIndex = 25;
            lbCelular.Text = "Celular";
            // 
            // tbTelefone
            // 
            tbTelefone.Location = new Point(18, 387);
            tbTelefone.Name = "tbTelefone";
            tbTelefone.Size = new Size(351, 27);
            tbTelefone.TabIndex = 24;
            tbTelefone.TextChanged += tbTelefone_TextChanged;
            // 
            // lbTelefone
            // 
            lbTelefone.AutoSize = true;
            lbTelefone.Location = new Point(18, 364);
            lbTelefone.Name = "lbTelefone";
            lbTelefone.Size = new Size(66, 20);
            lbTelefone.TabIndex = 23;
            lbTelefone.Text = "Telefone";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(381, 326);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(351, 27);
            tbEmail.TabIndex = 22;
            tbEmail.Leave += tbEmail_Leave;
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.Location = new Point(381, 303);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(52, 20);
            lbEmail.TabIndex = 21;
            lbEmail.Text = "e-mail";
            // 
            // tbBairro
            // 
            tbBairro.Location = new Point(18, 326);
            tbBairro.Name = "tbBairro";
            tbBairro.Size = new Size(351, 27);
            tbBairro.TabIndex = 20;
            // 
            // lbBairro
            // 
            lbBairro.AutoSize = true;
            lbBairro.Location = new Point(18, 303);
            lbBairro.Name = "lbBairro";
            lbBairro.Size = new Size(49, 20);
            lbBairro.TabIndex = 19;
            lbBairro.Text = "Bairro";
            // 
            // tbRua
            // 
            tbRua.Location = new Point(18, 267);
            tbRua.Name = "tbRua";
            tbRua.Size = new Size(620, 27);
            tbRua.TabIndex = 18;
            // 
            // lbRua
            // 
            lbRua.AutoSize = true;
            lbRua.Location = new Point(18, 244);
            lbRua.Name = "lbRua";
            lbRua.Size = new Size(34, 20);
            lbRua.TabIndex = 17;
            lbRua.Text = "Rua";
            // 
            // tbCidade
            // 
            tbCidade.Location = new Point(544, 204);
            tbCidade.Name = "tbCidade";
            tbCidade.Size = new Size(188, 27);
            tbCidade.TabIndex = 16;
            // 
            // lbCidade
            // 
            lbCidade.AutoSize = true;
            lbCidade.Location = new Point(544, 181);
            lbCidade.Name = "lbCidade";
            lbCidade.Size = new Size(56, 20);
            lbCidade.TabIndex = 15;
            lbCidade.Text = "Cidade";
            // 
            // tbEstado
            // 
            tbEstado.Location = new Point(426, 204);
            tbEstado.Name = "tbEstado";
            tbEstado.Size = new Size(112, 27);
            tbEstado.TabIndex = 14;
            // 
            // lbEstado
            // 
            lbEstado.AutoSize = true;
            lbEstado.Location = new Point(426, 181);
            lbEstado.Name = "lbEstado";
            lbEstado.Size = new Size(54, 20);
            lbEstado.TabIndex = 13;
            lbEstado.Text = "Estado";
            // 
            // tbCep
            // 
            tbCep.Location = new Point(316, 204);
            tbCep.Name = "tbCep";
            tbCep.Size = new Size(104, 27);
            tbCep.TabIndex = 12;
            tbCep.TextChanged += tbCep_TextChanged;
            // 
            // lbCep
            // 
            lbCep.AutoSize = true;
            lbCep.Location = new Point(316, 181);
            lbCep.Name = "lbCep";
            lbCep.Size = new Size(34, 20);
            lbCep.TabIndex = 11;
            lbCep.Text = "CEP";
            // 
            // tbRgIe
            // 
            tbRgIe.Location = new Point(168, 204);
            tbRgIe.Name = "tbRgIe";
            tbRgIe.Size = new Size(142, 27);
            tbRgIe.TabIndex = 10;
            // 
            // lbRgIe
            // 
            lbRgIe.AutoSize = true;
            lbRgIe.Location = new Point(168, 181);
            lbRgIe.Name = "lbRgIe";
            lbRgIe.Size = new Size(127, 20);
            lbRgIe.TabIndex = 9;
            lbRgIe.Text = "Inscrição Estadual";
            // 
            // tbCpfCnpj
            // 
            tbCpfCnpj.Location = new Point(18, 204);
            tbCpfCnpj.Name = "tbCpfCnpj";
            tbCpfCnpj.Size = new Size(142, 27);
            tbCpfCnpj.TabIndex = 8;
            tbCpfCnpj.TextChanged += tbCpfCnpj_TextChanged;
            // 
            // lbCpfCnpj
            // 
            lbCpfCnpj.AutoSize = true;
            lbCpfCnpj.Location = new Point(18, 181);
            lbCpfCnpj.Name = "lbCpfCnpj";
            lbCpfCnpj.Size = new Size(41, 20);
            lbCpfCnpj.TabIndex = 7;
            lbCpfCnpj.Text = "CNPJ";
            // 
            // tbRazaoSocial
            // 
            tbRazaoSocial.Location = new Point(18, 141);
            tbRazaoSocial.Name = "tbRazaoSocial";
            tbRazaoSocial.Size = new Size(714, 27);
            tbRazaoSocial.TabIndex = 6;
            // 
            // lbRazaoSocial
            // 
            lbRazaoSocial.AutoSize = true;
            lbRazaoSocial.Location = new Point(18, 118);
            lbRazaoSocial.Name = "lbRazaoSocial";
            lbRazaoSocial.Size = new Size(94, 20);
            lbRazaoSocial.TabIndex = 5;
            lbRazaoSocial.Text = "Razão Social";
            // 
            // tbNome
            // 
            tbNome.Location = new Point(18, 83);
            tbNome.Name = "tbNome";
            tbNome.Size = new Size(714, 27);
            tbNome.TabIndex = 3;
            // 
            // tbCodigo
            // 
            tbCodigo.Enabled = false;
            tbCodigo.Location = new Point(18, 30);
            tbCodigo.Name = "tbCodigo";
            tbCodigo.ReadOnly = true;
            tbCodigo.Size = new Size(125, 27);
            tbCodigo.TabIndex = 1;
            tbCodigo.Text = "0";
            // 
            // lbNome
            // 
            lbNome.AutoSize = true;
            lbNome.Location = new Point(18, 60);
            lbNome.Name = "lbNome";
            lbNome.Size = new Size(107, 20);
            lbNome.TabIndex = 2;
            lbNome.Text = "Nome Fantasia";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 7);
            label1.Name = "label1";
            label1.Size = new Size(58, 20);
            label1.TabIndex = 0;
            label1.Text = "Código";
            // 
            // FrmCadastroFornecedor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(pnBotoes);
            Controls.Add(pnDados);
            Name = "FrmCadastroFornecedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro Fornecedor";
            Load += FrmCadastroFornecedor_Load;
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
        private Label lbEmailInvalido;
        private Label lbValorInvalido;
        private TextBox tbNumero;
        private Label lbNumero;
        private TextBox tbCelular;
        private Label lbCelular;
        private TextBox tbTelefone;
        private Label lbTelefone;
        private TextBox tbEmail;
        private Label lbEmail;
        private TextBox tbBairro;
        private Label lbBairro;
        private TextBox tbRua;
        private Label lbRua;
        private TextBox tbCidade;
        private Label lbCidade;
        private TextBox tbEstado;
        private Label lbEstado;
        private TextBox tbCep;
        private Label lbCep;
        private TextBox tbRgIe;
        private Label lbRgIe;
        private TextBox tbCpfCnpj;
        private Label lbCpfCnpj;
        private TextBox tbRazaoSocial;
        private Label lbRazaoSocial;
        private TextBox tbNome;
        private TextBox tbCodigo;
        private Label lbNome;
        private Label label1;
    }
}