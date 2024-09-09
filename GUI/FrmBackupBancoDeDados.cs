using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Ferramentas;

namespace GUI
{
    public partial class FrmBackupBancoDeDados : Form
    {
        public FrmBackupBancoDeDados()
        {
            InitializeComponent();
        }



        

        private void btnBackup_Click(object sender, EventArgs e)
        {

            try
            {

                ConfiguraConexao(out string nomeBanco, out string conexao);
                LocalBackup(out string local);
                SQLServerBackup.BackupDataBase(conexao, nomeBanco, local);
                MessageBox.Show("Backup realizado com sucesso!!!");

            }
            catch (Exception er)
            {
                MessageBox.Show("Não é possível realizar o Backup\n Detalhes:" + er.Message);

            }
        }

        private bool LocalBackup(out string local)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Backup Files | *.bak";
            sfd.ShowDialog();
            local = sfd.FileName;
            if (sfd.FileName == "")
            {
                MessageBox.Show("Não é possível realizar o Backup");

                return false;
            }
            
            return true;
        }

        private bool AbreRestore(out string local)
        {
            var sfd = new OpenFileDialog();
            sfd.Filter = "Backup Files | *.bak";
            sfd.ShowDialog();
            local = sfd.FileName;
            if (sfd.FileName == "")
            {
                MessageBox.Show("Não é possível realizar o Restore");

                return false;
            }

            return true;
        }

        private static void ConfiguraConexao(out string nomeBanco, out string conexao)
        {
            nomeBanco = DadosDaConexao.banco;
            conexao = new DadosDaConexaoStruct()
            {
                tipoAutenticacao = "Windows",
                servidor = DadosDaConexao.servidor,
                usuario = DadosDaConexao.usuario,
                senha = DadosDaConexao.senha,
                banco = "master"
            }.StringDeConexao;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {

                ConfiguraConexao(out string nomeBanco, out string conexao);
                AbreRestore(out string local);
                SQLServerBackup.RestauraDatabase(conexao, nomeBanco, local);
                MessageBox.Show("Restore realizado com sucesso!!!");

            }
            catch (Exception er)
            {
                MessageBox.Show("Não é possível realizar o Restore\n Detalhes:" + er.Message);

            }

        }
    }
}
