using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmConsultaSubCategoria : Form
    {
        public int codigo = 0;
        public FrmConsultaSubCategoria()
        {
            InitializeComponent();
        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            Localizar();
        }
        private void SetInicial()
        {
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[0].Width = 58;
            dgvDados.Columns[1].HeaderText = "Sub Categoria";
            dgvDados.Columns[1].Width = 318;
            dgvDados.Columns[2].Visible = false;
            dgvDados.Columns[3].HeaderText = "Categoria";
            dgvDados.Columns[3].Width = 318;
        }
        private void Localizar()
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLSubCategoria bll = new BLLSubCategoria(cx);
            dgvDados.DataSource = bll.Localizar(textBoxCategoria.Text);
        }

        private void FrmConsultaSubCategoria_Load(object sender, EventArgs e)
        {
            Localizar();
            SetInicial();
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
            this.Close();

        }
    }
}
