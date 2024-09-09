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
    public partial class FrmConsultaUndMedida : Form
    {
        public int codigo = 0;
        public FrmConsultaUndMedida()
        {
            InitializeComponent();
        }
        private void SetInicial()
        {
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 60;
            dgvDados.Columns[1].HeaderText = "Unidade de Medida";
            dgvDados.Columns[1].Width = 630;
        }
        private void Localizar()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLUndMedida bll = new BLLUndMedida(cx);
            dgvDados.DataSource = bll.Localizar(textBoxCategoria.Text, TipoPesquisa.aproximada);
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            Localizar();
        }



        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) { return; }
            codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
            this.Close();

        }

        private void FrmConsultaUndMedida_Load(object sender, EventArgs e)
        {
            Localizar();
            SetInicial();
        }

    
    }
}
