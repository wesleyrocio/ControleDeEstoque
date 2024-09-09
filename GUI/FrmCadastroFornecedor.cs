using BLL;
using DAL;
using EnumsCompartilhados;
using Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmCadastroFornecedor : Form
    {
        public FrmCadastroFornecedor()
        {
            InitializeComponent();
            Control.form = this;
            DefineEventos();

        }



        protected enum Campo { cpfCnpj, email, cep, telefone, celular }
        public Operacao operacao;

        class Control
        {
            static public FrmCadastroFornecedor form;
            static public void preencheCamposComModelo(ModeloFornecedor modelo)
            {
                form.tbCodigo.Text = modelo.ForCod.ToString();
                form.tbNome.Text = modelo.ForNome;
                form.tbCpfCnpj.Text = modelo.ForCnpj;
                form.tbRgIe.Text = modelo.ForIe;
                form.tbRazaoSocial.Text = modelo.ForRsocial;
                form.tbCep.Text = modelo.ForCep;
                form.tbRua.Text = modelo.ForEndereco;
                form.tbBairro.Text = modelo.ForBairro;
                form.tbTelefone.Text = modelo.ForFone;
                form.tbCelular.Text = modelo.ForCel;
                form.tbEmail.Text = modelo.ForEmail;
                form.tbNumero.Text = modelo.ForEndNumero;
                form.tbCidade.Text = modelo.ForCidade;
                form.tbEstado.Text = modelo.ForEstado;
            }

            static public void Load(object sender, EventArgs e)
            {
                form.tbNome.Focus();
                Control.alteraBotoes(FormEstado.branco);
            }

            static public void Tabulacao(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    form.SelectNextControl(form.ActiveControl, !e.Shift, true, true, true);
                }

            }
            static public void preencheModeloComCampos(ModeloFornecedor modelo)
            {

                int.TryParse(form.tbCodigo.Text, out int codigo);
                modelo.ForCod = codigo;
                modelo.ForNome = form.tbNome.Text.Trim();
                modelo.ForCnpj = form.tbCpfCnpj.Text.ApenasNumeros().Trim();
                modelo.ForIe = form.tbRgIe.Text.Trim();
                modelo.ForRsocial = form.tbRazaoSocial.Text.Trim();
                modelo.ForCep = form.tbCep.Text.Trim().ApenasNumeros();
                modelo.ForEndereco = form.tbRua.Text.Trim();
                modelo.ForBairro = form.tbBairro.Text.Trim();
                modelo.ForFone = form.tbTelefone.Text.Trim().ApenasNumeros();
                modelo.ForCel = form.tbCelular.Text.Trim().ApenasNumeros();
                modelo.ForEmail = form.tbEmail.Text.Trim();
                modelo.ForEndNumero = form.tbNumero.Text.Trim();
                modelo.ForCidade = form.tbCidade.Text.Trim();
                modelo.ForEstado = form.tbEstado.Text.Trim();

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
                var modelo = new ModeloFornecedor();

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


            }
            static public void InserirFormulario()
            {
                form.operacao = Operacao.inserir;
                limparCampos();
                alteraBotoes(FormEstado.edicao);
            }
            static public void Inserir(ModeloFornecedor modelo)
            {
                try
                {
                    var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    var bll = new BLLFornecedor(cx);
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado. Código:" + modelo.ForCod);

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Não foi possível incluir registro. Detalhes:" + erro.Message);
                }
            }

            static public void Update(ModeloFornecedor modelo)
            {

                try
                {
                    var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    var bll = new BLLFornecedor(cx);
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
                    var bll = new BLLFornecedor(cx);
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
                var frmConsultaFornecedor = new FrmConsultaFornecedor();
                frmConsultaFornecedor.ShowDialog();
                if (frmConsultaFornecedor.codigo <= 0)
                {
                    limparCampos();
                    alteraBotoes(FormEstado.branco);
                    frmConsultaFornecedor.Dispose();
                    return;
                }
                var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                var bll = new BLLFornecedor(cx);
                var modelo = bll.CarregarModelo(frmConsultaFornecedor.codigo);
                preencheCamposComModelo(modelo);
                frmConsultaFornecedor.Dispose();
                form.operacao = Operacao.localizar;
                alteraBotoes(FormEstado.posconsulta);
            }

            static public void preencheCamposEnderecoCEP()
            {
                if (!BuscaEndereco.verificaCEP(form.tbCep.Text)) return;
                form.tbBairro.Text = BuscaEndereco.bairro;
                form.tbRua.Text    = BuscaEndereco.endereco;
                form.tbCidade.Text = BuscaEndereco.cidade;
                form.tbEstado.Text = BuscaEndereco.estado;
            }


            static public void aplicaMascara(Campo campo)
            {
                switch (campo)
                {
                    case Campo.cpfCnpj:
                        form.tbCpfCnpj.Text = Mascara.CNPJ(form.tbCpfCnpj.Text);
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
                        return setarComponenteValidacao(Validacao.IsCnpj(form.tbCpfCnpj.Text), form.lbValorInvalido);

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

            static public bool setarComponenteValidacao(bool valor, Label label)
            {
                label.Visible = !valor;
                form.buttonSalvar.Enabled = valor;
                return valor;
            }

            static public bool verificaEmail()
            {
                return !(form.buttonSalvar.Enabled = form.lbEmailInvalido.Visible = !Validacao.IsEmailValido(form.tbEmail.Text));
            }


        }

        private void FrmCadastroFornecedor_Load(object sender, EventArgs e)
        {
            tbNome.Focus();
            Control.alteraBotoes(FormEstado.branco);
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            Control.InserirFormulario();
        }

        private void buttonLocalizar_Click(object sender, EventArgs e)
        {
            Control.Localizar();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            Control.Alterar();
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            Control.Excluir();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Control.Salvar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Control.Cancelar();
        }

        private void tbCpfCnpj_TextChanged(object sender, EventArgs e)
        {
            Control.aplicaMascara(Campo.cpfCnpj);
        }

       

        private void tbEmail_Leave(object sender, EventArgs e)
        {
            Control.aplicaValidacao(Campo.email);
        }

        private void tbTelefone_TextChanged(object sender, EventArgs e)
        {
            Control.aplicaMascara(Campo.telefone);
        }

        private void tbCelular_Leave(object sender, EventArgs e)
        {
            Control.aplicaMascara(Campo.telefone);
        }
        private void tbCep_TextChanged(object sender, EventArgs e)
        {
            Control.aplicaMascara(Campo.cep);
        }
        private void LeaveTextBox(object sender, EventArgs e)
        {
            if (!(sender is TextBox)) return;
            TextBox componente=(TextBox) sender;
            string nome = componente.Name;
            switch (nome)
            {
                case "tbTelefone":
                    Control.aplicaMascara(Campo.telefone);
                    break;
                case "tbCelular":
                    Control.aplicaMascara(Campo.telefone);
                    break;
                case "tbCep":
                    Control.preencheCamposEnderecoCEP();
                    break;
                case "tbEmail":
                    Control.aplicaValidacao(Campo.email);
                    break;
                case "tbCpfCnpj":
                    Control.aplicaValidacao(Campo.cpfCnpj);
                    break;
            }

        }
        private void DefineEventos()
        {
            this.Load         += Control.Load;
            this.KeyDown      += Control.Tabulacao;

            tbCelular.Leave     += LeaveTextBox;
            tbTelefone.Leave    += LeaveTextBox;
            tbEmail.Leave       += LeaveTextBox;
            tbCep.Leave         += LeaveTextBox;
            tbCpfCnpj.Leave     += LeaveTextBox;
        }

        private void tbCelular_TextChanged(object sender, EventArgs e)
        {
            Control.aplicaMascara(Campo.celular);

        }
    }
}
