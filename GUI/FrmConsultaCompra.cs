using BLL;
using DAL;
using EnumsCompartilhados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Modelo.ModeloItensCompra;

namespace GUI
{
    public partial class FrmConsultaCompra : Form
    {
        public int codigo;
        public FrmConsultaCompra()
        {
            InitializeComponent();
            DefineEventosRadioButton();

        }

        private void DefineEventosRadioButton()
        {
            rbTodas.CheckedChanged += rbCheckedChanged;
            rbDataCompra.CheckedChanged += rbCheckedChanged;
            rbFornecedor.CheckedChanged += rbCheckedChanged;
        }

        private void SetInicial()
        {

            panelData.Enabled = false;
            panelFornecedor.Enabled = false;

            dgvDados.AutoGenerateColumns = false;
            dgvDados.Columns["com_cod"      ].HeaderText = "Cód.";
            dgvDados.Columns["com_cod"      ].Width      = 50;
            dgvDados.Columns["com_status"   ].HeaderText = "Status";
            dgvDados.Columns["com_status"   ].Width      = 60;
            dgvDados.Columns["com_data"     ].HeaderText = "Data da Compra";
            dgvDados.Columns["com_data"     ].Width      = 105;
            dgvDados.Columns["com_nfiscal"  ].HeaderText = "nº Nota";
            dgvDados.Columns["com_nfiscal"  ].Width      = 60;
            dgvDados.Columns["com_total"    ].HeaderText = "Total";
            dgvDados.Columns["com_total"    ].Width      = 80;
            dgvDados.Columns["com_total"    ].DefaultCellStyle.Format = "C2";
            dgvDados.Columns["for_nome"     ].HeaderText = "Fornecedor";
            dgvDados.Columns["for_nome"     ].Width      = 200;
            dgvDados.Columns["com_nparcelas"].HeaderText = "Parcelas";
            dgvDados.Columns["com_nparcelas"].Width      = 80;
            dgvDados.Columns["tpa_nome"     ].HeaderText = @"tipo/pgto";
            dgvDados.Columns["tpa_nome"     ].Width      = 80;

            dgvDados.Columns["for_cod"].Visible = false;
            dgvDados.Columns["tpa_cod"].Visible = false;
            dgvDados.Columns["for_cod1"].Visible = false;
            dgvDados.Columns["tpa_cod1"].Visible = false;
            dgvDados.Columns["for_rsocial"].Visible = false;
            dgvDados.Columns["for_ie"].Visible = false;
            dgvDados.Columns["for_cnpj"].Visible = false;
            dgvDados.Columns["for_cep"].Visible = false;
            dgvDados.Columns["for_endereco"].Visible = false;
            dgvDados.Columns["for_bairro"].Visible = false;
            dgvDados.Columns["for_fone"].Visible = false;
            dgvDados.Columns["for_cel"].Visible = false;
            dgvDados.Columns["for_email"].Visible = false;
            dgvDados.Columns["for_endnumero"].Visible = false;
            dgvDados.Columns["for_cidade"].Visible = false;
            dgvDados.Columns["for_estado"].Visible = false;
            dgvDados.Columns["tpa_cod"].Visible = false;


        }
        private DataTable Localizar()
        {
            CompraPesquisarPor pesquisarPor = SetaPesquisaPeloCheckBox();
            var dt = new DataTable();

            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            var bll = new BLLCompra(cx);

            switch (pesquisarPor)
            {
                case CompraPesquisarPor.nomeFornecedor:
                    dt = bll.Localizar([textBoxProduto.Text], pesquisarPor);
                    break;
                case CompraPesquisarPor.todas:
                     dt = bll.Localizar([""], pesquisarPor);
                    break;
                case CompraPesquisarPor.data:
                    DateTime dtInicio = dtInicial.Value.Date.AddHours(0);
                    DateTime dtFim = dtFinal.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);      
                    dt = bll.Localizar([dtInicio.ToString(),dtFim.ToString()], pesquisarPor, TipoPesquisa.intervalo);
                    break;
            }
            //bll.Localizar([textBoxProduto.Text], pesquisarPor);
            return dt;
        }

        private CompraPesquisarPor SetaPesquisaPeloCheckBox()
        {
            CompraPesquisarPor pesquisarPor = CompraPesquisarPor.todas;
            if (rbFornecedor.Checked == true) pesquisarPor = CompraPesquisarPor.nomeFornecedor;
            if (rbDataCompra.Checked == true) pesquisarPor = CompraPesquisarPor.data;
            if (rbTodas.Checked == true) pesquisarPor = CompraPesquisarPor.todas;
            return pesquisarPor;
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = Localizar();
        }

        private void dgvDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells["com_cod"].Value);
            this.Close();
        }

        private void FrmConsultaCompra_Load(object sender, EventArgs e)
        {
            dgvDados.DataSource = Localizar();
            SetInicial();
        }

       
        private void rbCheckedChanged(object sender, EventArgs e)
        {
             RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                SetaPaineis(radioButton);
            }


        }

        private void SetaPaineis(RadioButton radioButton)
        {
            switch (radioButton.Name)
            {
                case "rbTodas":
                    panelData.Enabled = false;
                    panelFornecedor.Enabled = false;
                    break;
                case "rbFornecedor":
                    panelData.Enabled = false;
                    panelFornecedor.Enabled = true;
                    break;
                case "rbDataCompra":
                    panelData.Enabled = true;
                    panelFornecedor.Enabled = false;
                    break;

            }
        }
    }
}
