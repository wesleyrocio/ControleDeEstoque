using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{

    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void AbreForm(Form form)
        {
            form.ShowDialog();
            form.Dispose();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroCategoria frmCadastroCategoria = new FrmCadastroCategoria();
            AbreForm(frmCadastroCategoria);
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaCategoria frmConsultaCategoria = new FrmConsultaCategoria();
            AbreForm(frmConsultaCategoria);
        }

        private void subCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroSubCategoria frmCadastroSubCategoria = new FrmCadastroSubCategoria();
            AbreForm(frmCadastroSubCategoria);
        }

        private void subCategoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaSubCategoria frmConsultaSubCategoria = new FrmConsultaSubCategoria();
            AbreForm(frmConsultaSubCategoria);
        }

        private void unidadeDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroUndMedida frmCadastroUndMedida = new FrmCadastroUndMedida();
            AbreForm(frmCadastroUndMedida);
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadastroProduto frmCadastroProduto = new FrmCadastroProduto();
            AbreForm(frmCadastroProduto);
        }

        private void configuraçãoDoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmConficuracaoBancoDeDados = new FrmConfiguracaoBancoDados();
            AbreForm(frmConficuracaoBancoDeDados);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            setarConexao();
        }

        private void setarConexao()
        {
            /*  try
              {
                  DadosDaConexao.LerArquivoConexao();
              }
              catch (Exception)
              {

                  MessageBox.Show("Falha ao ler os dados do arquivo de configuração do Banco de Dados: ConfiguracaoBanco");
                  return;
              }
              DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
              if (!cx.testaConexao())
              {
                  MessageBox.Show("Falha na Conexão!");
              }*/
            try
            {
                var cx = new DALConexao();
                cx.setarConexao();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }

        }

        private void backupDoBancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmBackupBancoDeDados = new FrmBackupBancoDeDados();
            AbreForm(frmBackupBancoDeDados);


        }

        private void tipoDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmTipoPagamento = new FrmCadastroTipoPagamento();
            AbreForm(frmTipoPagamento);
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCadastroCliente = new FrmCadastroCliente();
            AbreForm(frmCadastroCliente);
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frmCadastroFornecedor = new FrmCadastroFornecedor();
            AbreForm(frmCadastroFornecedor);
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FrmMovimentacaoCompra();
            AbreForm(form);
        }
    }
}
