using BLL;
using DAL;
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
    public partial class FrmConsultaProduto : Form
    {
        public int codigo;
        public FrmConsultaProduto()
        {
            InitializeComponent();
            
        }
        private void SetInicial()
        {
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 58;
            dgvDados.Columns[1].HeaderText = "Produto";
            dgvDados.Columns[1].Width = 318;
            dgvDados.Columns[2].Visible = false;
            dgvDados.Columns[3].Visible = false;
            dgvDados.Columns[4].HeaderText = "Valor Pago";
            dgvDados.Columns[4].Width = 70;
            dgvDados.Columns[4].DefaultCellStyle.Format = "C2";
            dgvDados.Columns[5].HeaderText = "Valor Venda";
            dgvDados.Columns[5].Width = 70;
            dgvDados.Columns[5].DefaultCellStyle.Format = "C2";
            dgvDados.Columns[6].HeaderText = "Quantidade";
            dgvDados.Columns[6].Width = 50;
            dgvDados.Columns[7].Visible = false;
            dgvDados.Columns[8].HeaderText = "Und Medida";
            dgvDados.Columns[8].Width = 80;
            dgvDados.Columns[9].Visible = false;
            dgvDados.Columns[10].Width = 80;
            dgvDados.Columns[10].HeaderText = "Categoria";
            dgvDados.Columns[11].Visible = false;
            dgvDados.Columns[12].Width = 80;
            dgvDados.Columns[12].HeaderText = "Sub Categoria";

        }
        private DataTable Localizar()
        {
            ProdutoPesquisarPor pesquisarPor = SetaPesquisaPeloCheckBox();

            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLProduto bll = new BLLProduto(cx);
            return bll.Localizar(textBoxProduto.Text, pesquisarPor);
        }

        private ProdutoPesquisarPor SetaPesquisaPeloCheckBox()
        {
            ProdutoPesquisarPor pesquisarPor = ProdutoPesquisarPor.nome;
            if (rbProduto.Checked == true) pesquisarPor      = ProdutoPesquisarPor.nome;
            if (rbCategoria.Checked == true) pesquisarPor    = ProdutoPesquisarPor.categoria;
            if (rbSubCategoria.Checked == true) pesquisarPor = ProdutoPesquisarPor.subcategoria;
            return pesquisarPor;
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

        private void FrmConsultaProduto_Load(object sender, EventArgs e)
        {
            dgvDados.DataSource = Localizar();
            SetInicial();
        }
    }
}
