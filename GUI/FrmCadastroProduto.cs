using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnumsCompartilhados;

namespace GUI
{

    public partial class FrmCadastroProduto : Form
    {
        public string foto = "";


        public FrmCadastroProduto()
        {
            void AplicaEventos()
            {
                AplicaEventosMonetaria(tbValorPago);
                AplicaEventosMonetaria(tbValorVenda);
                AplicaEventosDouble(tbQuantidade);
            }
            InitializeComponent();
            AplicaEventos();

        }

        public Operacao operacao;
        public ModeloProduto modeloProdutoPosPesquisa = new();
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

            modeloProdutoPosPesquisa = new ModeloProduto();
            tbCodigo.Clear();
            tbNome.Clear();
            tbDescricao.Clear();
            tbQuantidade.Clear();
            tbValorPago.Clear();
            tbValorVenda.Clear();
            tbQuantidade.Text = double.Parse("0.00").ToString();
            tbValorPago.Text = double.Parse("0.00").ToString("C2");
            tbValorVenda.Text = double.Parse("0.00").ToString("C2");
            foto = "";
            pbImagem.Image = null;


            atualizaComboBoxCategoria();
            atualizaComboBoxSubCategoria();




        }

       
        public Image ArrayBitsParaImagem(ModeloProduto modelo)
        {
            try
            {
                MemoryStream ms = new(modelo.ProFoto);
                Image image = Image.FromStream(ms);

                return image;
            }
            catch
            {
                return null;
            }
        }

        private void preencheCamposComModelo(ModeloProduto modelo)
        {
            tbCodigo.Text = modelo.ProCod.ToString();
            tbNome.Text = modelo.ProNome;
            tbDescricao.Text = modelo.ProDescricao;
            tbValorPago.Text = modelo.ProValorpago.ToString();
            tbValorVenda.Text = modelo.ProValorVenda.ToString();
            tbQuantidade.Text = modelo.ProQtde.ToString();
            cbCategoria.SelectedValue = modelo.Categoria.CatCod;
            cbSubCategoria.SelectedValue = modelo.SubCategoria.ScatCod;
            pbImagem.Image = ArrayBitsParaImagem(modelo);
            atualizaComboBoxSubCategoria();
            cbUndMedida.SelectedValue = modelo.UnidadeDeMedida.UmedCod;
        }
        private void preencheModeloComCampos(ModeloProduto modelo)
        {        

            int.TryParse(tbCodigo.Text, out int codigo);
            modelo.ProNome = tbNome.Text.Trim();
            modelo.ProCod = codigo;
            modelo.ProDescricao = tbDescricao.Text.Trim();
            modelo.ProValorpago = Convert.ToDouble(trocaVirgulaPonto(tbValorPago.Text));
            modelo.ProValorVenda = Convert.ToDouble(trocaVirgulaPonto(tbValorVenda.Text));
            modelo.ProQtde = Convert.ToDouble(trocaVirgulaPonto(tbQuantidade.Text));
            modelo.Categoria.CatCod = Convert.ToInt32(cbCategoria.SelectedValue);
            modelo.SubCategoria.ScatCod = Convert.ToInt32(cbSubCategoria.SelectedValue);
            modelo.UnidadeDeMedida.UmedCod = Convert.ToInt32(cbUndMedida.SelectedValue);
            if (foto != "Original")
            {
                modelo.CarregarImagem(foto);
            }
            else
            {
                modelo.ProFoto = modeloProdutoPosPesquisa.ProFoto;
            }
        }
        private void atualizaComboBoxCategoria()
        {

            var colecaoCategoria = new ColecaoCategoria();
            var cx = new DALConexao(DadosDaConexao.StringDeConexao);
            var bll = new BLLCategoria(cx);

            colecaoCategoria = bll.preencherColecao();
            cbCategoria.DataSource = colecaoCategoria;
            cbCategoria.DisplayMember = "CatNome";
            cbCategoria.ValueMember = "CatCod";
            cbCategoria.AutoCompleteMode   = AutoCompleteMode.Suggest;
            cbCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;

            //ModeloCategoria cat = colecaoCategoria.FirstOrDefault(c => c.CatCod == 1); 
        }
        private void atualizaComboBoxSubCategoria()
        {
            //  cbSubCategoria.Enabled = true;
            cbSubCategoria.Text = "";
            ModeloCategoria categoriaSelecionada = (ModeloCategoria)cbCategoria.SelectedItem;
            if (categoriaSelecionada == null) return;
            cbSubCategoria.DataSource = categoriaSelecionada.SubCategorias;
            cbSubCategoria.DisplayMember = "ScatNome";
            cbSubCategoria.ValueMember = "scatCod";
            cbSubCategoria.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbSubCategoria.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        private void atualizaComboBoxUndMedida()
        {
            cbUndMedida.Enabled = true;
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLUndMedida bll = new BLLUndMedida(cx);
            cbUndMedida.DataSource = bll.Localizar("%");
            cbUndMedida.DisplayMember = "umed_nome";
            cbUndMedida.ValueMember = "umed_cod";
        }

        private bool ValidaComboBox()
        {
            if (cbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("É necessário selecionar uma Categoria", "Categoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbUndMedida.SelectedIndex == -1)
            {
                MessageBox.Show("É necessário selecionar uma Unidade de Medida", "Unidade de Medida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cbSubCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("É necessário selecionar uma SubCategoria", "Sub Categoria", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Salvar()
        {
            var modelo = new ModeloProduto();

            if (!ValidaComboBox()) return;

            switch (operacao)
            {
                case Operacao.inserir:
                    preencheModeloComCampos(modelo);
                    Inserir(modelo);
                    break;
                case Operacao.alterar:
                    preencheModeloComCampos(modelo);
                    try
                    {
                        Alterar(modelo);
                    }
                    catch
                    {

                        alteraBotoes(FormEstado.edicao);
                        return;
                    }

                    break;
                default:
                    return;
            }
            limparCampos();
            alteraBotoes(FormEstado.branco);

        }


        private void Inserir(ModeloProduto modelo)
        {

            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                var bll = new BLLProduto(cx);
                bll.Incluir(modelo);
                MessageBox.Show("Cadastro efetuado. Código:" + modelo.ProCod);
            }
            catch (Exception erro)
            {

                MessageBox.Show("Não foi possível incluir registro. Detalhes:" + erro.Message);
            }
        }

        private void Alterar(ModeloProduto modelo)
        {
            try
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                var bll = new BLLProduto(cx);
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
                BLLProduto bll = new BLLProduto(cx);
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
            var frmConsultaProduto = new FrmConsultaProduto();
            frmConsultaProduto.ShowDialog();
            if (frmConsultaProduto.codigo <= 0)
            {
                limparCampos();
                alteraBotoes(FormEstado.branco);
                frmConsultaProduto.Dispose();
                return;
            }
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLProduto bll = new BLLProduto(cx);
            ModeloProduto modelo = bll.CarregarModelo(frmConsultaProduto.codigo);
            modeloProdutoPosPesquisa = modelo;
            foto = "Original";
            preencheCamposComModelo(modelo);
            frmConsultaProduto.Dispose();
            operacao = Operacao.localizar;
            alteraBotoes(FormEstado.posconsulta);
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
                    alteraBotoes(FormEstado.posconsulta);
                    preencheCamposComModelo(modeloProdutoPosPesquisa);
                    break;
                default:
                    alteraBotoes(FormEstado.branco);
                    limparCampos();
                    break;
            }
        }
        public void SomaMultipicacao(int x, int y, out int resultSoma, out int resultMultiplicacao)
        {
            resultSoma = x + y;
            resultMultiplicacao = x * y;

        }



        private void buttonInserir_Click(object sender, EventArgs e)
        {
            operacao = Operacao.inserir;
            limparCampos();
            alteraBotoes(FormEstado.edicao);
        }

        private void buttonLocalizar_Click(object sender, EventArgs e)
        {
            Localizar();
        }

        private void buttonAlterar_Click(object sender, EventArgs e)
        {
            operacao = Operacao.alterar;
            alteraBotoes(FormEstado.edicao);
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            operacao = Operacao.excluir;
            Excluir(Convert.ToInt32(tbCodigo.Text));
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btCarregarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            if (string.IsNullOrEmpty(od.FileName)) return;
            this.foto = od.FileName;
            pbImagem.Load(this.foto);

        }

        private void btRemoverFoto_Click(object sender, EventArgs e)
        {
            this.foto = "";
            pbImagem.Image = null;
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            atualizaComboBoxCategoria();
            atualizaComboBoxSubCategoria();
            atualizaComboBoxUndMedida();

            alteraBotoes(FormEstado.branco);
        }

        private void FrmProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
            }

        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbCategoria.SelectedValue) <= 0) return;
            }
            catch
            {

                return;
            }

            atualizaComboBoxSubCategoria();
        }


        private void AplicaEventosMonetaria(TextBox txt)
        {
            txt.KeyPress += ApenasValorNumerico;
            txt.Leave    += RetornaMascaraMonetaria;
            txt.Enter    += TirarMascara;
        }
        private void AplicaEventosDouble(TextBox txt)
        {
            txt.KeyPress += ApenasValorNumerico;
            txt.Leave    += RetornaMascaraDouble;
            txt.Enter    += TirarMascara;
        }
        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            string textoAtual=  txt.Text;
            int posicaoVirgula = textoAtual.IndexOf(',');
            int maximoCasasDecimais = 2;
            if(txt.Name== "tbQuantidade") { maximoCasasDecimais = 4; }



            if (!char.IsDigit(e.KeyChar) &&
                !e.KeyChar.Equals(Convert.ToChar(Keys.Back)) &&
                !e.KeyChar.Equals(Convert.ToChar(Keys.Delete)) &&
                !e.Equals(',') &&!e.Equals('.')
                )
            {
                e.Handled = true;
            }
          
            if (e.KeyChar.Equals(Convert.ToChar(Keys.Back)) ||
                e.KeyChar.Equals(Convert.ToChar(Keys.Delete))) { return; }
           
            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
              
                if(textoAtual.Length<=0) 
                {
                    e.Handled = true;
                    return;
                }               
                e.Handled = (textoAtual.Contains(','));
            
               
            }
            if (textoAtual.Contains(",") && textoAtual.Substring(posicaoVirgula + 1).Length >= maximoCasasDecimais )
            {
                e.Handled = true;
            }
        }
        private void RetornaMascaraMonetaria(object sender, EventArgs e)
        {

            TextBox txt = (TextBox)sender;
            try
            {
                Double d = Convert.ToDouble(txt.Text);
            }
            catch
            {
                txt.Text = "0.00";

            }

            txt.Text = double.Parse(txt.Text).ToString("C2");
        }
        private void RetornaMascaraDouble(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;




             if (!txt.Text.Contains(","))
            {
                txt.Text += ",00";
            }
            else
            {
                if (txt.Text.IndexOf(",") == txt.Text.Length - 1)
                {
                    txt.Text += "00";
                }
            }

            try
            {
                Double d = Convert.ToDouble(txt.Text.Replace(",", "."));
            }
            catch
            {
                txt.Text = "0,00";

            }

        }
        private void TirarMascara(Object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = txt.Text.Replace("R$", "").Trim();
            if (txt.Text == "0,00" || txt.Text == "0") { txt.Text = ""; }


        }

        private void LimpaCampoNumerico(object sender, EventArgs e)
        {
            TextBox tB = (TextBox)sender;
            if (tB.Text == "0,00") { tB.Text = ""; }
        }

        private string trocaVirgulaPonto(string txt)
        {
            string texto;

            if (txt.Trim().Length <= 0) { txt = "0"; }
            txt = txt.Replace("R$", "").Trim();
            texto = txt.Replace(",", ".").Trim();
            return txt;

        }
       
        private void btnAddUndMedida_Click(object sender, EventArgs e)
        {
            var frmCadastroUndMedida = new FrmCadastroUndMedida();
            frmCadastroUndMedida.ShowDialog();
            atualizaComboBoxUndMedida();
            frmCadastroUndMedida.Dispose();

        }

        private void btnAddCategoria_Click(object sender, EventArgs e)
        {
            var frmCadastroCategoria = new FrmCadastroCategoria();
            frmCadastroCategoria.ShowDialog();
            atualizaComboBoxCategoria();
            frmCadastroCategoria.Dispose();
        }

        private void btnAddSubCategoria_Click(object sender, EventArgs e)
        {
            var frmCadastroSubCategoria = new FrmCadastroSubCategoria();
            frmCadastroSubCategoria.ShowDialog();
            atualizaComboBoxCategoria();
            atualizaComboBoxSubCategoria();
            frmCadastroSubCategoria.Dispose();
        }
    }
}
