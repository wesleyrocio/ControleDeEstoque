using BLL;
using DAL;
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
using EnumsCompartilhados;

namespace GUI
{
    public partial class FrmCadastroUndMedida : Form
    {
        public FrmCadastroUndMedida()
        {
            InitializeComponent();
        }


        public Operacao operacao;
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
        }
        private void limparCampos()
        {
            tbCodigo.Clear();
            tbNome.Clear();
        }

        private void preencheCamposComModelo(ModeloUndMedida modelo)
        {
            tbCodigo.Text = modelo.UmedCod.ToString();
            tbNome.Text = modelo.UmedNome;
        }

        private void preencheModeloComCampos(ModeloUndMedida modelo)
        {
            bool deucerto;

            deucerto = int.TryParse(tbCodigo.Text, out var codigo);
            modelo.UmedCod = codigo;
            modelo.UmedNome = tbNome.Text.Trim();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
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


        private void buttonInserir_Click(object sender, EventArgs e)
        {
            operacao = Operacao.inserir;
            limparCampos();
            alteraBotoes(FormEstado.edicao);
        }

        private void Inserir(ModeloUndMedida modelo)
        {
            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUndMedida bll = new BLLUndMedida(cx);
                bll.Incluir(modelo);
                MessageBox.Show("Cadastro efetuado. Código:" + modelo.UmedCod);

            }
            catch (Exception erro)
            {

                MessageBox.Show("Não foi possível incluir registro. Detalhes:" + erro.Message);
            }
        }

        private void Alterar(ModeloUndMedida modelo)
        {

            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUndMedida bll = new BLLUndMedida(cx);
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

        private void Excluir(int codigo)
        {

            DialogResult d = MessageBox.Show("Deseja Excluir?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.No) return;

            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLUndMedida bll = new BLLUndMedida(cx);
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

        private void Localizar()
        {
            FrmConsultaUndMedida frmConsultaUndMedida = new FrmConsultaUndMedida();
            frmConsultaUndMedida.ShowDialog();

            if (frmConsultaUndMedida.codigo <= 0)
            {
                limparCampos();
                alteraBotoes(FormEstado.branco);
                frmConsultaUndMedida.Dispose();
                return;
            }
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLUndMedida bll = new BLLUndMedida(cx);
            ModeloUndMedida modelo = bll.CarregarModelo(frmConsultaUndMedida.codigo);
            preencheCamposComModelo(modelo);
            frmConsultaUndMedida.Dispose();
            operacao = Operacao.localizar;
            alteraBotoes(FormEstado.posconsulta);
            bll.Desconectar();
        }

        private void VerificaIsUnidadeMedida()
        {


            if (operacao != Operacao.inserir) { return; }
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLUndMedida bll = new BLLUndMedida(cx);
            ModeloUndMedida modelo = bll.LocalizaUndMedida(tbNome.Text.Trim());
            if (modelo.UmedCod == 0) { return; }
            DialogResult d = MessageBox.Show("Esse registro já existe. Deseja altera-lo?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.No) { return; }
            operacao = Operacao.alterar;
            preencheCamposComModelo(modelo);
            bll.Desconectar();
        }

        private void tbNome_Leave(object sender, EventArgs e)
        {
            VerificaIsUnidadeMedida();
        }

        private void FrmCadastroUndMedida_Load(object sender, EventArgs e)
        {
            alteraBotoes(FormEstado.branco);
        }

        private void buttonLocalizar_Click(object sender, EventArgs e)
        {
            Localizar();
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {

            ModeloUndMedida modelo = new ModeloUndMedida();
            preencheModeloComCampos(modelo);
            if (operacao == Operacao.inserir)
            {
                Inserir(modelo);
            }
            else if (operacao == Operacao.alterar)
            {
                Alterar(modelo);
            }
            limparCampos();
            alteraBotoes(FormEstado.branco);
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            operacao = Operacao.alterar;
            alteraBotoes(FormEstado.edicao);
        }

        private void FrmCadastroUndMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
