using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;
using DAL;
using BLL;
using EnumsCompartilhados;

namespace GUI
{
    public partial class FrmCadastroCategoria : Form
    {
       
     
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

        private void Salvar()
        {
            ModeloCategoria modelo = new ModeloCategoria();

            if (operacao == Operacao.inserir)
            {
                modelo.CatNome = tbNome.Text;
                Inserir(modelo);

            }
            else if (operacao == Operacao.alterar)
            {
                modelo.CatCod = int.Parse(tbCodigo.Text);
                modelo.CatNome = tbNome.Text.Trim();
                Update(modelo);

            }
            limparCampos();
            alteraBotoes(FormEstado.branco);
        }
        private void Alterar()
        {
            operacao = Operacao.alterar;
            alteraBotoes(FormEstado.edicao);
        }
        private void Excluir()
        {
            operacao = Operacao.excluir;
            Deletar(Convert.ToInt32(tbCodigo.Text));
        }

        private void limparCampos()
        {
            tbCodigo.Clear();
            tbNome.Clear();
        }
        private void InserirRegistro()
        {
            operacao = Operacao.inserir;
            limparCampos();
            alteraBotoes(FormEstado.edicao);
        }
        private void Inserir(ModeloCategoria modelo)
        {
            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCategoria bll = new BLLCategoria(cx);
                bll.Incluir(modelo);
                MessageBox.Show("Cadastro efetuado. Código:" + modelo.CatCod);

            }
            catch (Exception erro)
            {

                MessageBox.Show("Não foi possível incluir registro. Detalhes:" + erro.Message);
            }
        }

        private void Update(ModeloCategoria modelo)
        {

            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCategoria bll = new BLLCategoria(cx);
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

        private void Deletar(int codigo)
        {

            DialogResult d = MessageBox.Show("Deseja Excluir?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d == DialogResult.No) return;

            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLCategoria bll = new BLLCategoria(cx);
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
            FrmConsultaCategoria frmConsultaCategoria = new FrmConsultaCategoria();
            frmConsultaCategoria.ShowDialog();
            if (frmConsultaCategoria.codigo <= 0)
            {
                limparCampos();
                alteraBotoes(FormEstado.branco);
                frmConsultaCategoria.Dispose();
                return;
            }
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);
            ModeloCategoria modelo = bll.CarregarModelo(frmConsultaCategoria.codigo);
            tbCodigo.Text = modelo.CatCod.ToString();
            tbNome.Text = modelo.CatNome.ToString();
            frmConsultaCategoria.Dispose();
            operacao = Operacao.localizar;
            alteraBotoes(FormEstado.posconsulta);
        }
        public FrmCadastroCategoria()
        {
            InitializeComponent();
            alteraBotoes(FormEstado.branco);
        }

        private void buttonInserir_Click(object sender, EventArgs e)
        {
            InserirRegistro();
        }

        


        private void buttonCancelar_Click(object sender, EventArgs e)
        {

            Cancelar();

        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

      

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            Alterar();

        }

       

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            Excluir();

        }    

      

        private void buttonLocalizar_Click(object sender, EventArgs e)
        {

            Localizar();
        }

        private void FrmCadastroCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }
        }
    }
}
