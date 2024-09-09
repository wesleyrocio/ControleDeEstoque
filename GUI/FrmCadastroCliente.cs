using BLL;
using DAL;
using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Ferramentas;


namespace GUI
{
    public partial class FrmCadastroCliente : Form
    {
        protected enum Campo { cpfCnpj, email, cep, telefone, celular}
        public Operacao operacao;
        static class SetarPessoa
        {
            static public FrmCadastroCliente form;
            static public PessoaTipo tipo { get; set; }
            protected record tipoPessoaRecord(bool RazaoSocialVisivel, string Nome, string RgIe, string CpfCnpj);

            static tipoPessoaRecord rJuridico = new tipoPessoaRecord(true, "Nome Fantasia", "I.E.", "CNPJ");
            static tipoPessoaRecord rFisico = new tipoPessoaRecord(false, "Nome", "RG", "CPF");
            static public void alteraComponentes()
            {

                tipoPessoaRecord rPessoa;
                if (tipo == PessoaTipo.fisica) { rPessoa = rFisico; } else { rPessoa = rJuridico; };

                form.lbRazaoSocial.Visible = rPessoa.RazaoSocialVisivel;
                form.tbRazaoSocial.Visible = rPessoa.RazaoSocialVisivel;
                form.lbNome.Text = rPessoa.Nome;
                form.lbRgIe.Text = rPessoa.RgIe;
                form.lbCpfCnpj.Text = rPessoa.CpfCnpj;
                if (tipo == PessoaTipo.fisica)
                { form.rbFisica.Checked = true; }
                else
                { form.rbJuridica.Checked = true; }
            }
            static public void alteraComponentes(PessoaTipo value)
            {
                tipo = value;
                alteraComponentes();
            }
          }
        class Control
        {
            static public FrmCadastroCliente form;
            static public void preencheCamposComModelo(ModeloCliente modelo)
            {


                void ConfigPessoaTipo()
                {
                    if (modelo.CliTipo.ToLower() == PessoaTipo.fisica.ToString())
                    {
                        form.rbFisica.Checked = true;
                        SetarPessoa.tipo = PessoaTipo.fisica;
                        SetarPessoa.alteraComponentes();
                    }
                    else
                    {

                        form.rbJuridica.Checked = true;
                        SetarPessoa.tipo = PessoaTipo.juridica;
                        SetarPessoa.alteraComponentes();
                    }

                }

                ConfigPessoaTipo();
                form.tbCodigo.Text = modelo.CliCod.ToString();
                form.tbNome.Text = modelo.CliNome;
                form.tbCpfCnpj.Text = modelo.CliCpfCnpj;
                form.tbRgIe.Text = modelo.CliRgIe;
                form.tbRazaoSocial.Text = modelo.CliRsocial;
                form.tbCep.Text = modelo.CliCep;
                form.tbRua.Text = modelo.CliEndereco;
                form.tbBairro.Text = modelo.CliBairro;
                form.tbTelefone.Text = modelo.CliFone;
                form.tbCelular.Text = modelo.CliCel;
                form.tbEmail.Text = modelo.CliEmail;
                form.tbNumero.Text = modelo.CliEndNumero;
                form.tbCidade.Text = modelo.CliCidade;
                form.tbEstado.Text = modelo.CliEstado;


            }
            static public void preencheModeloComCampos(ModeloCliente modelo)
            {

                int.TryParse(form.tbCodigo.Text, out int codigo);
                modelo.CliCod = codigo;
                modelo.CliNome = form.tbNome.Text.Trim();
                modelo.CliCpfCnpj = form.tbCpfCnpj.Text.ApenasNumeros().Trim();
                modelo.CliRgIe = form.tbRgIe.Text.Trim();
                modelo.CliRsocial = form.tbRazaoSocial.Text.Trim().ApenasNumeros();
                modelo.CliCep = form.tbCep.Text.Trim().ApenasNumeros();
                modelo.CliEndereco = form.tbRua.Text.Trim();
                modelo.CliBairro = form.tbBairro.Text.Trim();
                modelo.CliFone = form.tbTelefone.Text.Trim().ApenasNumeros();
                modelo.CliCel = form.tbCelular.Text.Trim().ApenasNumeros();
                modelo.CliEmail = form.tbEmail.Text.Trim();
                modelo.CliEndNumero = form.tbNumero.Text.Trim();
                modelo.CliCidade = form.tbCidade.Text.Trim();
                modelo.CliEstado = form.tbEstado.Text.Trim();
                modelo.CliTipo = SetarPessoa.tipo.ToString();
            }
            static public void alteraBotoes(FormEstado op)
            {

                isHabilitarTodosBotoes(false);
                switch (op)
                {
                    case FormEstado.branco:
                        form.buttonInserir.Enabled = true;
                        form.buttonLocalizar.Enabled = true;
                        break;
                    case FormEstado.edicao:
                        form.pnDados.Enabled = true;
                        form.buttonSalvar.Enabled = true;
                        form.buttonCancelar.Enabled = true;
                        break;
                    case FormEstado.posconsulta:
                        form.buttonAlterar.Enabled = true;
                        form.buttonExcluir.Enabled = true;
                        form.buttonCancelar.Enabled = true;
                        break;

                }

            }

            static public void isHabilitarTodosBotoes(bool isHabilitarTodos)
            {
                form.pnDados.Enabled = isHabilitarTodos;
                foreach (Button botao in form.pnBotoes.Controls.OfType<Button>())
                {
                    botao.Enabled = isHabilitarTodos;

                }
                /*
                buttonInserir.Enabled = isHabilitarTodos;
                buttonAlterar.Enabled = isHabilitarTodos;
                buttonLocalizar.Enabled = isHabilitarTodos;
                buttonExcluir.Enabled = isHabilitarTodos;
                buttonCancelar.Enabled = isHabilitarTodos;
                buttonSalvar.Enabled = isHabilitarTodos;*/
            }
            static public void Cancelar()
            {
                switch (form.operacao)
                {
                    case Operacao.localizar:
                        alteraBotoes(FormEstado.branco);
                        limparCampos();
                        break;
                    case Operacao.alterar:
                        alteraBotoes(FormEstado.edicao);
                        break;
                    default:
                        alteraBotoes(FormEstado.branco);
                        limparCampos();
                        break;
                }
            }

            static public void Salvar()
            {
                var modelo = new ModeloCliente();

                if (form.operacao == Operacao.inserir)
                {
                    preencheModeloComCampos(modelo);
                    Inserir(modelo);

                }
                else if (form.operacao == Operacao.alterar)
                {
                    preencheModeloComCampos(modelo);
                    Update(modelo);

                }
                limparCampos();
                alteraBotoes(FormEstado.branco);
            }
            static public void Alterar()
            {
                form.operacao = Operacao.alterar;
                alteraBotoes(FormEstado.edicao);
            }
            static public void Excluir()
            {
                form.operacao = Operacao.excluir;
                Deletar(Convert.ToInt32(form.tbCodigo.Text));
            }

            static public void limparCampos()
            {
                foreach (TextBox txbox in form.pnDados.Controls.OfType<TextBox>())
                {
                    txbox.Clear();

                }                
                SetarPessoa.alteraComponentes(PessoaTipo.fisica);             

            }
            static public void InserirFormulario()
            {
                form.operacao = Operacao.inserir;
                limparCampos();
                alteraBotoes(FormEstado.edicao);
            }
            static public void Inserir(ModeloCliente modelo)
            {
                try
                {
                    var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    var bll = new BLLCliente(cx);
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado. Código:" + modelo.CliCod);

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Não foi possível incluir registro. Detalhes:" + erro.Message);
                }
            }

            static public void Update(ModeloCliente modelo)
            {

                try
                {
                    var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    var bll = new BLLCliente(cx);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro alterado");
                    alteraBotoes(FormEstado.posconsulta);

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Não foi possível alterar registro. Detalhes:" + erro.Message);
                    alteraBotoes(FormEstado.edicao);
                }

            }

            static public void Deletar(int codigo)
            {

                DialogResult d = MessageBox.Show("Deseja Excluir?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (d == DialogResult.No) return;

                try
                {
                    DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    var bll = new BLLCliente(cx);
                    bll.Excluir(codigo);
                    MessageBox.Show("Registro Excluido");
                    limparCampos();
                    alteraBotoes(FormEstado.branco);
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Não foi possível excluir registro! \n O registro está sendo utilizado em outro local. Detalhes:" + erro.Message);
                }

            }

            static public void Localizar()
            {
                var frmConsultaCliente = new FrmConsultaCliente();
                frmConsultaCliente.ShowDialog();
                if (frmConsultaCliente.codigo <= 0)
                {
                    limparCampos();
                    alteraBotoes(FormEstado.branco);
                    frmConsultaCliente.Dispose();
                    return;
                }
                var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                var bll = new BLLCliente(cx);
                var modelo = bll.CarregarModelo(frmConsultaCliente.codigo);
                preencheCamposComModelo(modelo);
                frmConsultaCliente.Dispose();
                form.operacao = Operacao.localizar;
                alteraBotoes(FormEstado.posconsulta);
            }

            static public void preencheCamposEnderecoCEP()
            {
                if (!BuscaEndereco.verificaCEP(form.tbCep.Text)) return;
                form.tbBairro.Text = BuscaEndereco.bairro;
                form.Text = BuscaEndereco.endereco;
                form.tbCidade.Text = BuscaEndereco.cidade;
                form.tbEstado.Text = BuscaEndereco.estado;
            }
            static public bool setarComponenteValidacao(bool valor, Label label)
            {
                label.Visible = !valor;
                form.buttonSalvar.Enabled = valor;
                return valor;
            }

            static public void aplicaMascara(Campo campo)
            {
                switch (campo)
                {
                    case Campo.cpfCnpj:
                        if (form.rbFisica.Checked)
                        {
                            form.tbCpfCnpj.Text = Mascara.CPF(form.tbCpfCnpj.Text);
                        }
                        else
                        {
                            form.tbCpfCnpj.Text = Mascara.CNPJ(form.tbCpfCnpj.Text);
                        }
                        form.tbCpfCnpj.SelectionStart = form.tbCpfCnpj.Text.Length;
                        break;
                    case Campo.email:
                        break;
                    case Campo.cep:
                        form.tbCep.Text = Mascara.CEP(form.tbCep.Text);
                        form.tbCep.SelectionStart = form.tbCep.Text.Length;
                        break;
                    case Campo.telefone:
                        form.tbTelefone.Text = Mascara.Telefone(form.tbTelefone.Text);
                        form.tbTelefone.SelectionStart = form.tbTelefone.Text.Length;
                        break;
                    case Campo.celular:
                        form.tbCelular.Text = Mascara.Celular(form.tbCelular.Text);
                        form.tbCelular.SelectionStart = form.tbCelular.Text.Length;
                        break;
                }
            }

            static public bool aplicaValidacao(Campo campo)
            {
                switch (campo)
                {
                    case Campo.cpfCnpj:
                        return setarComponenteValidacao(verificaDocumentoCPFeCNPJ(), form.lbValorInvalido);

                    case Campo.email:
                        return setarComponenteValidacao(Validacao.IsEmailValido(form.tbEmail.Text), form.lbEmailInvalido);

                    case Campo.cep:

                        return true;
                    case Campo.telefone:

                        return true;
                    case Campo.celular:

                        return true;
                    default:
                        return true;
                }
            }
            static public bool verificaDocumentoCPFeCNPJ()
            {


                Control.setarComponenteValidacao(true, form.lbValorInvalido);
                if (form.rbFisica.Checked)
                {
                    return Control.setarComponenteValidacao(Validacao.IsCpf(form.tbCpfCnpj.Text), form.lbValorInvalido);
                }
                else
                {
                    return Control.setarComponenteValidacao(Validacao.IsCnpj(form.tbCpfCnpj.Text), form.lbValorInvalido);
                }
            }
            static public bool verificaEmail()
            {
                return !(form.buttonSalvar.Enabled = form.lbEmailInvalido.Visible = !Validacao.IsEmailValido(form.tbEmail.Text));
            }

          
        }

        public FrmCadastroCliente()
        {
            InitializeComponent();
            SetarPessoa.form = this;
            SetarPessoa.tipo = PessoaTipo.fisica;
            SetarPessoa.alteraComponentes();
            Control.form = this;


        }     

        protected void rbFisica_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbFisica.Checked) return;
            SetarPessoa.tipo = PessoaTipo.fisica;
            SetarPessoa.alteraComponentes();
        }

        protected void rbJuridica_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbJuridica.Checked) return;
            SetarPessoa.tipo = PessoaTipo.juridica;
            SetarPessoa.alteraComponentes();
        }

        protected void tbCidade_Leave(object sender, EventArgs e)
        {

        }

        protected void tbCep_Leave(object sender, EventArgs e)
        {
            Control.preencheCamposEnderecoCEP();

        }     

        protected void tbCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            //preencheCamposEnderecoCEP();
        }

        protected void buttonLocalizar_Click(object sender, EventArgs e)
        {
            Control.Localizar();
        }

        protected void buttonInserir_Click(object sender, EventArgs e)
        {
           Control.InserirFormulario();
        }

        protected void buttonAlterar_Click(object sender, EventArgs e)
        {
            Control.Alterar();
        }

        protected void buttonExcluir_Click(object sender, EventArgs e)
        {
            Control.Excluir();
        }

        protected void buttonSalvar_Click(object sender, EventArgs e)
        {
            Control.Salvar();
        }

        protected void buttonCancelar_Click(object sender, EventArgs e)
        {
            Control.Cancelar();
        }

        protected void FrmCadastroCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        protected void FrmCadastroCliente_Load(object sender, EventArgs e)
        {
            tbNome.Focus();
            Control.alteraBotoes(FormEstado.branco);
        }
        protected void tbCpfCnpj_KeyDown(object sender, KeyEventArgs e)
        {

        }

        protected void tbCpfCnpj_TextChanged(object sender, EventArgs e)
        {
            Control.aplicaMascara(Campo.cpfCnpj);
        }

        protected void tbCpfCnpj_Leave_1(object sender, EventArgs e)
        {
            Control.aplicaValidacao(Campo.cpfCnpj);
        }

        protected void tbEmail_Leave(object sender, EventArgs e)
        {
            Control.aplicaValidacao(Campo.email);

        }

        protected void tbTelefone_TextChanged(object sender, EventArgs e)
        {
            Control.aplicaMascara(Campo.telefone);
        }

        protected void tbCelular_TextChanged(object sender, EventArgs e)
        {
            Control.aplicaMascara(Campo.celular);
        }

        protected void tbCep_TextChanged(object sender, EventArgs e)
        {
     
            Control.aplicaMascara(Campo.cep);
        }

      
    }
}
