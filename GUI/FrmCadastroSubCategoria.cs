using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnumsCompartilhados;

namespace GUI
{

    public partial class FrmCadastroSubCategoria : Form
    {

        public Operacao operacao;
        public FrmCadastroSubCategoria()
        {
            InitializeComponent();

        }

        public void alteraBotoes(FormEstado op)
        {

            isHabilitarTodosBotoes(false);
            switch (op)
            {
                case FormEstado.branco:
                    buttonInserir.Enabled = true;
                    buttonLocalizar.Enabled = true;
                    break;
                case FormEstado.edicao:
                    pnDados.Enabled = true;
                    buttonSalvar.Enabled = true;
                    buttonCancelar.Enabled = true;
                    cbCatCod.Enabled = true;
                    break;
                case FormEstado.posconsulta:
                    buttonAlterar.Enabled = true;
                    buttonExcluir.Enabled = true;
                    buttonCancelar.Enabled = true;
                    break;
            }



        }
        private void isHabilitarTodosBotoes(bool isHabilitarTodos)
        {
            pnDados.Enabled = isHabilitarTodos;
            buttonInserir.Enabled = isHabilitarTodos;
            buttonAlterar.Enabled = isHabilitarTodos;
            buttonLocalizar.Enabled = isHabilitarTodos;
            buttonExcluir.Enabled = isHabilitarTodos;
            buttonCancelar.Enabled = isHabilitarTodos;
            buttonSalvar.Enabled = isHabilitarTodos;
            cbCatCod.Enabled = isHabilitarTodos;
        }
        private void Cancelar()
        {

            switch (operacao)
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
        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void limparCampos()
        {
            tbScatCod.Clear();
            tbNome.Clear();
            cbCatCod.SelectedItem = -1;
        }

        private void atualizaComboBoxCategoria()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);
            cbCatCod.DataSource = bll.Localizar("%");
            cbCatCod.DisplayMember = "cat_nome";
            cbCatCod.ValueMember = "cat_cod";
        }


        private void buttonInserir_Click(object sender, EventArgs e)
        {
            operacao = Operacao.inserir;
            limparCampos();
            alteraBotoes(FormEstado.edicao);
        }

        private void FrmCadastroSubCategoria_Load(object sender, EventArgs e)
        {
            alteraBotoes(FormEstado.branco);
            atualizaComboBoxCategoria();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            operacao = Operacao.alterar;
            alteraBotoes(FormEstado.edicao);
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Salvar();

        }
        private void Salvar()
        {
            ModeloSubCategoria modelo = new ModeloSubCategoria();

            if (cbCatCod.SelectedIndex == -1)
            {
                MessageBox.Show("É necessário selecionar uma Categoria", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (operacao)
            {
                case Operacao.inserir:
                    modelo.ScatNome = tbNome.Text;
                    modelo.Categoria.CatCod = Convert.ToInt32(cbCatCod.SelectedValue);
                    Inserir(modelo);
                    break;
                case Operacao.alterar:
                    modelo.ScatCod = int.Parse(tbScatCod.Text);
                    modelo.ScatNome = tbNome.Text.Trim();
                    modelo.Categoria.CatCod = Convert.ToInt32(cbCatCod.SelectedValue);
                    Alterar(modelo);
                    break;
                default:
                    return;
            }
            limparCampos();
            alteraBotoes(FormEstado.branco);

        }

        private void Inserir(ModeloSubCategoria modelo)
        {
            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLSubCategoria bll = new BLLSubCategoria(cx);
                bll.Incluir(modelo);
                MessageBox.Show("Cadastro efetuado. Código:" + modelo.ScatCod);
            }
            catch (Exception erro)
            {

                MessageBox.Show("Não foi possível incluir registro. Detalhes:" + erro.Message);
            }


        }
        private void Alterar(ModeloSubCategoria modelo)
        {
            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLSubCategoria bll = new BLLSubCategoria(cx);
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
        private void Localizar()
        {
            FrmConsultaSubCategoria frmConsultaSubCategoria = new FrmConsultaSubCategoria();
            frmConsultaSubCategoria.ShowDialog();
            if (frmConsultaSubCategoria.codigo <= 0)
            {
                limparCampos();
                alteraBotoes(FormEstado.branco);
                frmConsultaSubCategoria.Dispose();
                return;
            }
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLSubCategoria bll = new BLLSubCategoria(cx);
            ModeloSubCategoria modelo = bll.CarregarModelo(frmConsultaSubCategoria.codigo);
            tbScatCod.Text = modelo.ScatCod.ToString();
            tbNome.Text = modelo.ScatNome.ToString();
            cbCatCod.SelectedValue = modelo.Categoria.CatCod.ToString();

            frmConsultaSubCategoria.Dispose();
            operacao = Operacao.localizar;
            alteraBotoes(FormEstado.posconsulta);

        }

        private void Excluir(int codigo)
        {


            DialogResult d = MessageBox.Show("Deseja Excluir?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.No) return;

            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLSubCategoria bll = new BLLSubCategoria(cx);
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

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            operacao = Operacao.excluir;
            Excluir(Convert.ToInt32(tbScatCod.Text));
        }

        private void buttonLocalizar_Click(object sender, EventArgs e)
        {
            Localizar();
        }

        private void FrmCadastroSubCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }

        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            var frmCadastroCategoria = new FrmCadastroCategoria();
            frmCadastroCategoria.ShowDialog();
            atualizaComboBoxCategoria();
            frmCadastroCategoria.Dispose();

        }
    }
}
