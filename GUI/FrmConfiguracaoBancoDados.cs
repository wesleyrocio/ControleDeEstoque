using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using DAL;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;

namespace GUI
{
    public partial class FrmConfiguracaoBancoDados : Form
    {
       

        public struct ConfiguracaoTemporaria()
        {
            public string tipoAutenticacao="";
            public string servidor="";
            public string banco="";
            public string usuario="";
            public string senha="";
        }
        public FrmConfiguracaoBancoDados()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            criarAlteraArquivo();
        }
        private void criarAlteraArquivo()
        {
            try
            {
                if (cbAutentificacao.SelectedIndex == 0)
                {
                    tbSenha.Text = " ";
                    tbUsuario.Text = " ";

                }
                var arquivo = new StreamWriter("ConfiguracaoBanco.txt", false);
                arquivo.WriteLine(cbAutentificacao.Text.Trim());
                arquivo.WriteLine(tbServidor.Text             );
                arquivo.WriteLine(tbBancoDeDados.Text         );
                arquivo.WriteLine(tbUsuario.Text              );
                arquivo.WriteLine(tbSenha.Text                );
                MessageBox.Show("Dados salvos!");
                arquivo.Close();

            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbSenha.Focus();
            if (tbSenha.PasswordChar == '*') { tbSenha.PasswordChar = default; } else { tbSenha.PasswordChar = '*'; }
        }



        private void AplicaEventosSemAcento(TextBox txt)
        {
            txt.KeyPress += filtroSemAcento;

        }
        private void FrmConfiguracaoBancoDados_Load(object sender, EventArgs e)
        {

            AplicaEventosSemAcento(tbBancoDeDados);
            AplicaEventosSemAcento(tbServidor);
            AplicaEventosSemAcento(tbUsuario);


            carregaDadosDoArquivo();



        }



        private void filtroSemAcento(object sender, KeyPressEventArgs e)
        {
            // Permite apenas letras, números e alguns caracteres especiais (ajuste conforme necessário)
            /*  if ((char.IsLetterOrDigit(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsPunctuation(e.KeyChar)) && !char.IsSymbol(e.KeyChar))
              {
                  OnKeyPress(e);
              }
              else
              {
                  e.Handled = true;
              }*/

            // char[] comAcentos = { 'Ä','Å','Á','Â','À','Ã','ä','á','â','à','ã','É','Ê','Ë','È','é','ê','ë','è','Í','Î','Ï','Ì','í','î','ï','ì','Ö','Ó','Ô','Ò','Õ','ö','ó','ô','ò','õ','Ü','Ú','Û','ü','ú','û','ù','Ç','ç' };
            string Acentos = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç´";
            char[] comAcentos = Acentos.ToCharArray();

            if (((!char.IsLetterOrDigit(e.KeyChar)) && e.KeyChar != ' ' && e.KeyChar != '\b') || comAcentos.Contains(e.KeyChar) || char.IsSymbol(e.KeyChar))
            {
                {

                    e.Handled = true;
                }
            }
        }

        private void tbServidor_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbServidor_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void tbSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                {

                    e.Handled = true;
                }
            }
        }
        private void carregaDadosDoArquivo()
        {
            try
            {
                var arquivo = new StreamReader("ConfiguracaoBanco.txt");
                cbAutentificacao.Text = arquivo.ReadLine();
                tbServidor.Text = arquivo.ReadLine();
                tbBancoDeDados.Text = arquivo.ReadLine();
                if (cbAutentificacao.Text != "Windows")
                {
                    tbUsuario.Text = arquivo.ReadLine();
                    tbSenha.Text = arquivo.ReadLine();
                    panelUsuarioSenha.Visible = true;
                }
                else
                {
                    panelUsuarioSenha.Visible = false;
                }
                arquivo.Close();


            }
            catch
            {

                // MessageBox.Show(erro.Message);
            }

        }
        private void cbAutentificacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelUsuarioSenha.Visible = true;
            if (cbAutentificacao.SelectedIndex == 0)
            {
                panelUsuarioSenha.Visible = false;
            }
        }
        private DadosDaConexaoStruct SalvaConfiguracaoAntiga()
        {
            var tempDados = new DadosDaConexaoStruct();
            tempDados.tipoAutenticacao = DadosDaConexao.tipoAutenticacao;
            tempDados.servidor = DadosDaConexao.servidor;
            tempDados.banco = DadosDaConexao.banco;
            tempDados.usuario = DadosDaConexao.usuario;
            tempDados.senha = DadosDaConexao.senha;
            return tempDados;

        }

        private void ConfiguracaoDaConexaoComStruct(DadosDaConexaoStruct tempDados)
        {
            DadosDaConexao.tipoAutenticacao = tempDados.tipoAutenticacao;
            DadosDaConexao.servidor = tempDados.servidor;
            DadosDaConexao.banco = tempDados.banco;
            DadosDaConexao.usuario = tempDados.usuario;
            DadosDaConexao.senha = tempDados.senha;
        }

        private DadosDaConexaoStruct SetarDadosConexaoComFormulario() 
        {
            var DadosNovos = new DadosDaConexaoStruct();
            DadosNovos.tipoAutenticacao = cbAutentificacao.Text.Trim();
            DadosNovos.servidor = tbServidor.Text;
            DadosNovos.banco = tbBancoDeDados.Text;
            DadosNovos.usuario = tbUsuario.Text;
            DadosNovos.senha = tbSenha.Text;
            return DadosNovos;
        }
        private void btTestar_Click(object sender, EventArgs e)
        {            
            var DadosAntigos = SalvaConfiguracaoAntiga();
           
            try
            {
                
                var DadosNovos=SetarDadosConexaoComFormulario();
                DALConexao cx = new DALConexao(DadosNovos.StringDeConexao);
                if (cx.testaConexao())
                {
                    DialogResult result = MessageBox.Show("Conectado com sucesso!\n Deseja alterar a conexão padrao imediatamente?", "Confirmação", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes) 
                    {
                        ConfiguracaoDaConexaoComStruct(DadosNovos); 
                    }
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show("Falha ao se conectar, confira os dados\n Detalhes"+ee.Message);
                ConfiguracaoDaConexaoComStruct(DadosAntigos);
            }

        }
    }
}
