using BLL;
using DAL;
using EnumsCompartilhados;
using Ferramentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmConsultaCliente : Form
    {
        public FrmConsultaCliente()
        {
            InitializeComponent();
        }
        public int codigo;
        private DataTable Localizar()
        {
            ClientePesquisarPor pesquisarPor = SetaPesquisaPeloCheckBox();

            var cx = new DALConexao(DadosDaConexao.StringDeConexao);
            var bll = new BLLCliente(cx);
            return bll.Localizar(textBoxPesquisa.Text, pesquisarPor);
        }

        private ClientePesquisarPor SetaPesquisaPeloCheckBox()
        {
            ClientePesquisarPor pesquisarPor = ClientePesquisarPor.nome;
            if (rbCliente.Checked == true) pesquisarPor = ClientePesquisarPor.nome;
            if (rbCPFCNPJ.Checked == true) pesquisarPor = ClientePesquisarPor.cpfcnpj;
            if (rbEmail.Checked == true)   pesquisarPor = ClientePesquisarPor.email;
            return pesquisarPor;
        }

        private void SetInicial()
        {
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 58;
            dgvDados.Columns[1].HeaderText = "Cliente";
            dgvDados.Columns[1].Width = 318;
            dgvDados.Columns[2].HeaderText = "CPF/CNPJ";
            dgvDados.Columns[2].Width = 100;
            dgvDados.Columns[3].Visible = false;
            dgvDados.Columns[4].Visible = false;
            dgvDados.Columns[5].HeaderText = "Tipo";
            dgvDados.Columns[5].Width = 50;

            dgvDados.Columns[6].Visible = false;
            dgvDados.Columns[7].Visible = false;
            dgvDados.Columns[8].Visible = false;
            dgvDados.Columns[9].Visible = false;

            dgvDados.Columns[10].Width = 80;
            dgvDados.Columns[10].HeaderText = "Celular";

            dgvDados.Columns[11].Width = 80;
            dgvDados.Columns[11].HeaderText = "e-mail";
            dgvDados.Columns[12].Visible = false;
            dgvDados.Columns[13].Visible = false;
            dgvDados.Columns[14].Visible = false;


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

        private void dgvDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgvDados.Columns[2].Index) // CPFCNPJ
            {
                string tipoPessoa = dgvDados.Rows[e.RowIndex].Cells[5].Value.ToString(); // Tipo
                if (tipoPessoa == "fisica")
                {
                    e.Value = Mascara.CPF(e.Value.ToString());
                }
                else if (tipoPessoa == "juridica")
                {
                    e.Value = Mascara.CNPJ(e.Value.ToString());
                }
            }
        }

   

        private void buttonPesquisar_Click_1(object sender, EventArgs e)
        {
            dgvDados.DataSource = Localizar();
        }

        private void FrmConsultaCliente_Load(object sender, EventArgs e)
        {
            dgvDados.DataSource = Localizar();
            SetInicial();
        }
    }
}
