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

namespace GUI
{
    public partial class FrmConsultaFornecedor : Form
    {
        public int codigo = 0;
        public FrmConsultaFornecedor()
        {
            InitializeComponent();
            AtribuiEventos();

        }

        private void AtribuiEventos()
        {
            rbCNPJ.CheckedChanged += RadioButtonCheckedChanged;
            rbEmail.CheckedChanged += RadioButtonCheckedChanged;
            rbFornecedor.CheckedChanged += RadioButtonCheckedChanged;
            rbRazaoSocial.CheckedChanged += RadioButtonCheckedChanged;
        }


        private DataTable Localizar()
        {
            FornecedorPesquisarPor pesquisarPor = SetaPesquisaPeloCheckBox();

            var cx = new DALConexao(DadosDaConexao.StringDeConexao);
            var bll = new BLLFornecedor(cx);
            return bll.Localizar(textBoxPesquisa.Text, pesquisarPor);
        }

        private FornecedorPesquisarPor SetaPesquisaPeloCheckBox()
        {
            var pesquisarPor = FornecedorPesquisarPor.nome;
            if (rbFornecedor.Checked == true)
            {
                pesquisarPor = FornecedorPesquisarPor.nome;
                lbBusca.Text = "Fornecedor";
            }
            if (rbRazaoSocial.Checked == true)
            {
                pesquisarPor = FornecedorPesquisarPor.razaoSocial;
                lbBusca.Text = "Razão Social";
            }
            if (rbCNPJ.Checked == true)
            {
                pesquisarPor = FornecedorPesquisarPor.cnpj;
                lbBusca.Text = "CNPJ";
            }
            if (rbEmail.Checked == true)
            {
                pesquisarPor = FornecedorPesquisarPor.email;
                lbBusca.Text = "e-mail";
            }

            return pesquisarPor;
        }

        private void SetInicial()
        {
            dgvDados.Columns["for_cod"].HeaderText = "Código";
            dgvDados.Columns["for_cod"].Width = 58;
            dgvDados.Columns["for_nome"].HeaderText = "Nome";
            dgvDados.Columns["for_nome"].Width = 300;
            dgvDados.Columns["for_rsocial"].HeaderText = "Razão Social";
            dgvDados.Columns["for_rsocial"].Width = 300;
            dgvDados.Columns["for_ie"].Visible = false;
            dgvDados.Columns["for_cnpj"].HeaderText = "CNPJ";
            dgvDados.Columns["for_cnpj"].Width = 100;
            dgvDados.Columns["for_cep"].Visible = false;
            dgvDados.Columns["for_endereco"].Visible = false;
            dgvDados.Columns["for_bairro"].Visible = false;
            dgvDados.Columns["for_fone"].Visible = false;
            dgvDados.Columns["for_cel"].HeaderText = "Celular";
            dgvDados.Columns["for_cel"].Width = 80;
            dgvDados.Columns["for_email"].HeaderText = "e-mail";
            dgvDados.Columns["for_email"].Width = 80;
            dgvDados.Columns["for_endnumero"].Visible = false;
            dgvDados.Columns["for_cidade"].Visible = false;
            dgvDados.Columns["for_estado"].Visible = false;

        }

        private void FrmConsultaFornecedor_Load(object sender, EventArgs e)
        {
            dgvDados.DataSource = Localizar();
            SetInicial();
        }

        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            SetaPesquisaPeloCheckBox();
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            dgvDados.DataSource = Localizar();
        }

        private void dgvDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
            this.Close();
        }
    }
}
