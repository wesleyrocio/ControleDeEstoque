using BLL;
using DAL;
using EnumsCompartilhados;
using Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmMovimentacaoCompra : Form
    {




        public double totalCompra = 0;
        public FrmMovimentacaoCompra()
        {
            InitializeComponent();
            Control.form = this;
            DefineEventos();
            Control.AtualizaDGVItens();
            Control.atualizaComboxNumeroParcelas();
            Control.atualizaComboxTipoPagamento();



        }
        protected enum Campo { valorUnitario, total }
        public Operacao operacao;
        public ColecaoItensCompra colecaoItens = new ColecaoItensCompra();
        public ColecaoItensCompra colecaoItensDeletados = new ColecaoItensCompra();
        public ColecaoParcelasCompra colecaoParcelas = new ColecaoParcelasCompra();
        private void DefineEventos()
        {
            this.Load += Control.Load;
            this.KeyDown += Control.Tabulacao;
            Control.AplicaEventosMonetaria(tbValorUnitario);
            Control.AplicaEventosDouble(tbQuantidade);
        }



        class Control
        {
            #region VARIAVEIS
            static public FrmMovimentacaoCompra form;
            static public ModeloFornecedor modeloFornecedor;
            static public ModeloProduto modeloProduto;
            #endregion

            #region MANIPULAÇÃO MODELOCOMPRA
            static public void preencheCamposComModelo(ModeloCompra modelo)
            {
                form.tbCodigo.Text = modelo.ComCod.ToString();
                form.dtpDataCompra.Text = modelo.ComData.ToString();
                form.tbNotaFiscal.Text = modelo.ComNfiscal.ToString();
                form.totalCompra = modelo.ComTotal;
                form.tbTotal.Text = modelo.ComTotal.ToString("C2");
                form.cbParcelas.SelectedValue = modelo.ComNparcelas;
                modeloFornecedor = modelo.Fornecedor;
                form.tbCodFornecedor.Text = modelo.Fornecedor.ForCod.ToString();
                form.lbFornecedor.Text = modelo.Fornecedor.ForNome.ToString();
                form.cbTipoPagamento.SelectedValue = modelo.TipoPagamento.TpaCod;
                form.colecaoItens = modelo.ListaItens;
                form.colecaoParcelas = modelo.Parcelas;
                AtualizaDGVItens();
                AtualizaDGVParcelas();

            }
            static public void preencheModeloComCampos(ModeloCompra modelo)
            {
                int.TryParse(form.tbCodigo.Text, out int codigo);
                int.TryParse(form.tbNotaFiscal.Text, out int notaFiscal);
                modelo.ComCod = codigo;
                modelo.ComData = Convert.ToDateTime(form.dtpDataCompra.Text);
                modelo.ComNfiscal = notaFiscal;
                modelo.ComTotal = form.totalCompra;
                modelo.ComNparcelas = Convert.ToInt32(form.cbParcelas.SelectedValue);
                modelo.ComStatus = "Ativo";
                modelo.Fornecedor = modeloFornecedor;
                modelo.TipoPagamento.TpaCod = Convert.ToInt32(form.cbTipoPagamento.SelectedValue);
                modelo.TipoPagamento.TpaNome = form.cbTipoPagamento.SelectedText;
                modelo.ListaItens = form.colecaoItens;
                modelo.Parcelas = form.colecaoParcelas;
            }
            #endregion

            #region CONTROLE DO FORMULÁRIO
            static public void alteraBotoes(FormEstado op)
            {

                isHabilitarTodosBotoes(false);
                switch (op)
                {
                    case FormEstado.branco:
                        form.buttonInserir.Enabled = true;
                        form.buttonLocalizar.Enabled = true;
                        break;

                    case FormEstado.preEdicao:
                        form.pnDados.Enabled = true;
                        form.buttonSalvar.Enabled = false;
                        form.buttonCancelar.Enabled = true;
                        break;
                    case FormEstado.edicao:
                        form.pnDados.Enabled = true;
                        form.buttonSalvar.Enabled = true;
                        form.buttonCancelar.Enabled = true;
                        form.btGerarParcelas.Enabled = true;
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
                form.btGerarParcelas.Enabled = isHabilitarTodos;

            }
            static public void limparCampos()
            {
                foreach (TextBox txbox in form.pnDados.Controls.OfType<TextBox>())
                {
                    txbox.Clear();

                }
                form.lbFornecedor.Text = "Informe o código  ou clique em localizar.";
                form.lbProduto.Text = "Informe o código  ou clique em localizar.";
                form.tbQuantidade.ReadOnly = true;
                form.tbCodFornecedor.ReadOnly = false;
                form.colecaoItens.Clear();
                form.colecaoParcelas.Clear();
                form.colecaoItensDeletados.Clear();

                AtualizaDGVParcelas();
                AtualizaDGVItens();
                form.totalCompra = 0;
                modeloFornecedor = new ModeloFornecedor();
                modeloProduto = new ModeloProduto();



            }



            static public void aplicaMascara(Campo campo)
            {
                switch (campo)
                {
                    case Campo.valorUnitario:
                        form.tbValorUnitario.Text = Mascara.Monetario(form.tbValorUnitario.Text);
                        form.tbValorUnitario.SelectionStart = form.tbValorUnitario.Text.Length;
                        break;
                    case Campo.total:
                        form.tbTotal.Text = Mascara.Monetario(form.tbTotal.Text);
                        form.tbTotal.SelectionStart = form.tbTotal.Text.Length;
                        break;

                }
            }

            static public bool aplicaValidacao(Campo campo)
            {
                /*  switch (campo)
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
                  }*/
                return true;
            }

            static public bool setarComponenteValidacao(bool valor, Label label)
            {
                label.Visible = !valor;
                form.buttonSalvar.Enabled = valor;
                return valor;
            }
            #endregion

            #region MÉTODOS BOTÕES CRUD
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
                var modelo = new ModeloCompra();

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

            static public void InserirFormulario()
            {
                form.operacao = Operacao.inserir;
                limparCampos();
                alteraBotoes(FormEstado.preEdicao);
            }
            #endregion

            #region MÉTODOS CRUD
            static public void Inserir(ModeloCompra modelo)
            {
                var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                var bll = new BLLCompra(cx);
                try
                {

                    cx.Conectar();
                    cx.IniciarTransacao();
                    bll.Incluir(modelo);
                    cx.Commit();
                    cx.Desconectar();
                    MessageBox.Show("Cadastro efetuado. Código:" + modelo.ComCod);

                }
                catch (Exception erro)
                {
                    cx.Rollback();
                    cx.Desconectar();
                    MessageBox.Show("Não foi possível incluir registro. Detalhes:" + erro.Message);
                }
            }

            static public void Update(ModeloCompra modelo)
            {

                try
                {
                    var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    var bll = new BLLCompra(cx);
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
                    var bll = new BLLCompra(cx);
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
                //var frmConsultaFornecedor = new FrmConsultaFornecedor();
                //frmConsultaFornecedor.ShowDialog();
                //if (frmConsultaFornecedor.codigo <= 0)
                //{
                //    limparCampos();
                //    alteraBotoes(FormEstado.branco);
                //    frmConsultaFornecedor.Dispose();
                //    return;
                //}
                //var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                //var bll = new BLLFornecedor(cx);
                //var modelo = bll.CarregarModelo(frmConsultaFornecedor.codigo);
                //preencheCamposComModelo(modelo);
                //frmConsultaFornecedor.Dispose();
                //form.operacao = Operacao.localizar;
                //alteraBotoes(FormEstado.posconsulta);
            }

            #endregion

            #region LOCALIZAR FORNECEDOR E PRODUTO
            static public bool LocalizaFornecedor(int codigo)
            {
                CarregaFornecedor(codigo);
                if (modeloFornecedor.ForCod <= 0)
                {
                    form.lbFornecedor.Text = "Informe o código  ou clique em localizar.";
                    return false;
                }
                form.tbCodFornecedor.Text = modeloFornecedor.ForCod.ToString();
                form.lbFornecedor.Text = modeloFornecedor.ForNome;

                return true;
            }

            private static void CarregaFornecedor(int codigo)
            {
                try
                {
                    var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    var bll = new BLLFornecedor(cx);
                    modeloFornecedor = bll.CarregarModelo(codigo);
                }
                catch (Exception)
                {

                    form.tbCodFornecedor.Clear();
                }

            }
            static public bool LocalizaProduto(int codigo)
            {
                CarregaProduto(codigo);
                if (modeloProduto.ProCod <= 0)
                {
                    form.lbProduto.Text = "Informe o código  ou clique em localizar.";
                    return false;
                }
                form.tbQuantidade.ReadOnly = false;
                form.tbCodProduto.ReadOnly = true;

                form.tbCodProduto.Text = modeloProduto.ProCod.ToString();
                form.lbProduto.Text = modeloProduto.ProNome;
                form.tbQuantidade.Text = "1";
                form.tbValorUnitario.Text = modeloProduto.ProValorpago.ToString("C2");

                return true;
            }

            public static void CarregaProduto(int codigo)
            {
                try
                {
                    var cx = new DALConexao(DadosDaConexao.StringDeConexao);
                    var bll = new BLLProduto(cx);
                    modeloProduto = bll.CarregarModelo(codigo);
                }
                catch (Exception)
                {

                    form.tbCodProduto.Clear();
                }

            }
            static public void LimpaCamposProduto()
            {
                form.tbCodProduto.Clear();
                form.tbCodProduto.ReadOnly = false;

                form.lbProduto.Text = "Informe o código do produto ou clique em localizar";
                form.tbQuantidade.Text = "1";
                form.tbQuantidade.ReadOnly = true;
                form.tbValorUnitario.Text = "0";
            }

            #endregion

            #region GRID ITENS
            static public void AdicionaProdutoGrid()
            {
                if ((form.tbCodProduto.Text.Length <= 0) ||
                                (form.tbQuantidade.Text.Length <= 0) ||
                                (form.tbValorUnitario.Text.Length <= 0))
                    return;



                var novoItem = new ModeloItensCompra();

                novoItem.ItcCod = 0;
                novoItem.Produto.ProCod = Convert.ToInt32(form.tbCodProduto.Text);
                novoItem.Produto.ProNome = form.lbProduto.Text;
                novoItem.ItcQtde = Convert.ToDouble(form.tbQuantidade.Text);
                novoItem.ItcValor = Convert.ToDouble(form.tbValorUnitario.Text.RetiraMoeda());
                novoItem.Compra.ComCod = 0;
                novoItem.Compra.ComValor = 0;

                form.totalCompra += novoItem.Total;
                form.tbTotal.Text = form.totalCompra.ToString("C2");

                form.colecaoItens.Add(novoItem);
                Control.AtualizaDGVItens();


            }

            static public void AtualizaDGVItens()
            {



                var dgvColecaoItens = form.colecaoItens.Select((item) => new
                {
                    ProCod = item.Produto.ProCod,
                    ProNome = item.Produto.ProNome,
                    ItcQtde = item.ItcQtde,
                    ItcValor = item.ItcValor,
                    Total = item.Total

                }).ToList();


                form.dgvItens.DataSource = null;
                form.dgvItens.DataSource = dgvColecaoItens;
                form.dgvItens.AutoGenerateColumns = false;
                form.dgvItens.Columns.Clear();
                form.dgvItens.Columns.Add("ProCod", "Código");
                form.dgvItens.Columns.Add("ProNome", "Nome");
                form.dgvItens.Columns.Add("ItcQtde", "Qtde");
                form.dgvItens.Columns.Add("ItcValor", "Valor");
                form.dgvItens.Columns.Add("Total", "Total");



                form.dgvItens.Columns["ProCod"].DataPropertyName = "ProCod";
                form.dgvItens.Columns["ProCod"].Width = 80;

                form.dgvItens.Columns["ProNome"].DataPropertyName = "ProNome";
                form.dgvItens.Columns["ProNome"].Width = 300;

                form.dgvItens.Columns["ItcQtde"].DataPropertyName = "ItcQtde";
                form.dgvItens.Columns["ItcQtde"].Width = 60;

                form.dgvItens.Columns["ItcValor"].DataPropertyName = "ItcValor";
                form.dgvItens.Columns["ItcValor"].Width = 80;
                form.dgvItens.Columns["ItcValor"].DefaultCellStyle.Format = "C2";

                form.dgvItens.Columns["Total"].DataPropertyName = "Total";
                form.dgvItens.Columns["Total"].Width = 80;
                form.dgvItens.Columns["Total"].DefaultCellStyle.Format = "C2";

            }
            static public bool RemoveItem(int indice)
            {
                if (indice < 0) return false;
                form.totalCompra -= form.colecaoItens[indice].Total;
                if (form.colecaoItens[indice].ItcCod != 0)
                {
                    form.colecaoItensDeletados.Add(form.colecaoItens[indice]);
                }
                form.colecaoItens.RemoveAt(indice);
                form.tbTotal.Text = form.totalCompra.ToString("C2");
                GeraParcelas();
                AtualizaDGVParcelas();
                AtualizaDGVItens();
                return true;
            }
            static public bool preencheCamposComItem(int indice)
            {
                if (indice < 0) return false;

                form.tbCodProduto.Text = form.colecaoItens[indice].Produto.ProCod.ToString();
                form.tbQuantidade.Text = form.colecaoItens[indice].ItcQtde.ToString();
                form.tbValorUnitario.Text = form.colecaoItens[indice].ItcValor.ToString("C2");
                form.totalCompra -= form.colecaoItens[indice].ItcValor;
                form.tbTotal.Text = form.totalCompra.ToString("C2");
                return true;


            }
            #endregion

            #region GRID PARCELAS

            static public void AtualizaDGVParcelas()
            {
                var dgvColecaoParcelas = form.colecaoParcelas.Select((item, index) => new
                {

                    Numero = index + 1,
                    PcoValor = item.PcoValor,
                    PcoDataVecto = item.PcoDataVecto


                }).ToList();

                //form.dgvParcelas.Rows.Clear();
                form.dgvParcelas.DataSource = dgvColecaoParcelas;
                form.dgvItens.AutoGenerateColumns = false;
                form.dgvParcelas.Columns["Numero"].DataPropertyName = "Numero";
                form.dgvParcelas.Columns["PcoValor"].DataPropertyName = "PcoValor";
                form.dgvParcelas.Columns["PcoValor"].HeaderText = "Valor";
                form.dgvParcelas.Columns["PcoValor"].DefaultCellStyle.Format = "C2";
                form.dgvParcelas.Columns["PcoDataVecto"].DataPropertyName = "PcoDataVecto";
                form.dgvParcelas.Columns["PcoDataVecto"].HeaderText = "Vencimento";



            }
            #endregion

            #region PARCELAS

            static public void GeraParcelas()
            {
                int parcelas = Convert.ToInt32(form.cbParcelas.SelectedValue);
                double valorParcela = form.totalCompra / parcelas;
                DateTime dtInicial = form.dtpDataInicialPagamento.Value;
                form.colecaoParcelas = new ColecaoParcelasCompra();
                var dt = dtInicial;

                for (int i = 0; i < parcelas; i++)
                {
                    dt = AjustarDataParcelas(dtInicial, i);

                    var parcela = new ModeloParcelasCompra()
                    {

                        PcoValor = valorParcela,
                        PcoDataVecto = dt
                    };

                    form.colecaoParcelas.Add(parcela);
                }
            }

            private static DateTime AjustarDataParcelas(DateTime dtInicial, int i)
            {
                DateTime dt = dtInicial.AddMonths(i);
                int ultimoDiaDoMes = DateTime.DaysInMonth(dt.Year, dt.Month);
                int diaAjustado = Math.Min(dtInicial.Day, ultimoDiaDoMes);

                dt = new DateTime(dt.Year, dt.Month, diaAjustado);
                return dt;
            }

            #endregion

            #region COMBOBOX
            static public void atualizaComboxTipoPagamento()
            {
                DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
                BLLTipoPagamento bll = new BLLTipoPagamento(cx);
                form.cbTipoPagamento.DataSource = bll.Localizar("%");
                form.cbTipoPagamento.DisplayMember = "tpa_nome";
                form.cbTipoPagamento.ValueMember = "tpa_cod";
            }
            static public void atualizaComboxNumeroParcelas()
            {
                Dictionary<int, string> dic = new Dictionary<int, string>();
                dic.Add(1, "1x - À vista");
                dic.Add(2, "2x - 30 e 60 dias");
                dic.Add(3, "3x - 30, 60 e 90 dias");

                form.cbParcelas.DataSource = dic.ToList();
                form.cbParcelas.DisplayMember = "Value";
                form.cbParcelas.ValueMember = "Key";
            }


            #endregion

            #region EVENTOS_CONTROL
            static public void ApenasValorNumerico(object sender, KeyPressEventArgs e)
            {
                TextBox txt = (TextBox)sender;
                string textoAtual = txt.Text;
                int posicaoVirgula = textoAtual.IndexOf(',');
                int maximoCasasDecimais = 2;
                if (txt.Name == "tbQuantidade") { maximoCasasDecimais = 4; }



                if (!char.IsDigit(e.KeyChar) &&
                    !e.KeyChar.Equals(Convert.ToChar(Keys.Back)) &&
                    !e.KeyChar.Equals(Convert.ToChar(Keys.Delete)) &&
                    !e.Equals(',') && !e.Equals('.')
                    )
                {
                    e.Handled = true;
                }

                if (e.KeyChar.Equals(Convert.ToChar(Keys.Back)) ||
                    e.KeyChar.Equals(Convert.ToChar(Keys.Delete))) { return; }

                if (e.KeyChar == ',' || e.KeyChar == '.')
                {
                    if (e.KeyChar == '.') e.KeyChar = ',';

                    if (textoAtual.Length <= 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    e.Handled = (textoAtual.Contains(','));


                }
                if (textoAtual.Contains(",") && textoAtual.Substring(posicaoVirgula + 1).Length >= maximoCasasDecimais)
                {
                    e.Handled = true;
                }
            }
            static public void RetornaMascaraMonetaria(object sender, EventArgs e)
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
            static public void RetornaMascaraDouble(object sender, EventArgs e)
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
            static public void TirarMascara(Object sender, EventArgs e)
            {
                TextBox txt = (TextBox)sender;
                txt.Text = txt.Text.Replace("R$", "").Trim();
                if (txt.Text == "0,00" || txt.Text == "0") { txt.Text = ""; }


            }

            static public void AplicaEventosMonetaria(TextBox txt)
            {
                txt.KeyPress += ApenasValorNumerico;
                txt.Leave += RetornaMascaraMonetaria;
                txt.Enter += TirarMascara;
            }
            static public void AplicaEventosDouble(TextBox txt)
            {
                txt.KeyPress += ApenasValorNumerico;
                txt.Leave += RetornaMascaraDouble;
                txt.Enter += TirarMascara;
            }
            static public void Load(object sender, EventArgs e)
            {
                form.tbNotaFiscal.Focus();
                Control.alteraBotoes(FormEstado.branco);
            }
            static public void Tabulacao(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    form.SelectNextControl(form.ActiveControl, !e.Shift, true, true, true);
                }

            }

            #endregion

        }

        #region EVENTOS_FORMULARIO
        private void FrmMovimentacaoCompra_Load(object sender, EventArgs e)
        {
            tbNotaFiscal.Focus();
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

        private void btLocalizarFornecedor_Click(object sender, EventArgs e)
        {
            var f = new FrmConsultaFornecedor();
            f.ShowDialog();
            Control.LocalizaFornecedor(f.codigo);
        }

        private void tbCodFornecedor_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCodFornecedor.Text)) tbCodFornecedor.Text = "0";
            Control.LocalizaFornecedor(Convert.ToInt32(tbCodFornecedor.Text));
        }

        private void btLocalizarProduto_Click(object sender, EventArgs e)
        {
            var f = new FrmConsultaProduto();
            f.ShowDialog();
            Control.LocalizaProduto(f.codigo);
        }

        private void tbCodProduto_Leave(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(tbCodProduto.Text)) tbCodProduto.Text = "0";
            Control.LocalizaProduto(Convert.ToInt32(tbCodProduto.Text));
        }

        private void tbValorUnitario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbTotal_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbTotal.Text))
                Control.alteraBotoes(FormEstado.edicao);
        }

        private void btAdicionarItem_Click(object sender, EventArgs e)
        {
            Control.AdicionaProdutoGrid();
            Control.LimpaCamposProduto();

        }

        private void dgvItens_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvItens.CurrentRow.Index < 0) return;
            if (MessageBox.Show("Tem Certeza de que quer delerar o item?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (!Control.RemoveItem(dgvItens.CurrentRow.Index))
                MessageBox.Show("Selecione um item para deletar!", "Ação Inválida", MessageBoxButtons.OK);
        }
        private void dgvItens_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Control.preencheCamposComItem(e.RowIndex)) Control.RemoveItem(e.RowIndex);

        }

        private void cbParcelas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void btGerarParcelas_Click(object sender, EventArgs e)
        {

            Control.GeraParcelas();
            Control.AtualizaDGVParcelas();
            Control.atualizaComboxNumeroParcelas();

        }

        #endregion

        private void buttonSalvar_Click_1(object sender, EventArgs e)
        {
            Control.Salvar();
        }
    }
}


//private static DateTime CalcularDataVencimento(DateTime dataInicial, int numeroParcela)
//{
//    int mesAAdicionar = numeroParcela % 12; // Calcula o número de meses a adicionar dentro de um ciclo anual
//    int anoAAdicionar = numeroParcela / 12; // Calcula o número de anos a adicionar para parcelas que excedem 12
//    return new DateTime(dataInicial.Year + anoAAdicionar, dataInicial.Month + mesAAdicionar, dataInicial.Day);
//}