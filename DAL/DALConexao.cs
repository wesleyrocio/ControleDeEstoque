using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;

namespace DAL
{
    public interface IDALConexao
    {
        string StringConexao { get; set; }
        SqlConnection ObjetoConexao { get; }

        void Conectar();
        void Desconectar();
        bool testaConexao();
        void setarConexao();
    }
    public class DALConexao : IDALConexao
    {
        private string        _stringConexao;
        private SqlConnection _conexao;

        public String StringConexao
        {
            get { return _stringConexao; }
            set { _stringConexao = value; }
        }

        public SqlConnection ObjetoConexao 
        {
            get { return _conexao; }
            set { _conexao = value; } 
        }

        public DALConexao(String dadosConexao)
        {
            this._conexao = new SqlConnection();
            this.StringConexao = dadosConexao;
            this._conexao.ConnectionString = dadosConexao;
        }
        public DALConexao()
        {
            this._conexao = new SqlConnection();
            this.StringConexao = DadosDaConexao.StringDeConexao;
            this._conexao.ConnectionString = DadosDaConexao.StringDeConexao;
        }
    

        public void Conexao(String dadosConexao)
        {
            this._conexao = new SqlConnection();
            this.StringConexao = dadosConexao;
            this._conexao.ConnectionString = dadosConexao;
        }

        public void Conectar()
        {
            _conexao.Open(); 
            
        }

        public void Desconectar()
        {
            _conexao.Close(); 
        }

        public bool testaConexao()
        {
            bool retorno=false;
            try
            {
                Conectar();
                Desconectar();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
              
            }
            
        }
        public void setarConexao()
        {
            try
            {
                DadosDaConexao.LerArquivoConexao();
            }
            catch (Exception e)
            {

                throw new Exception("Falha ao ler os dados do arquivo de configuração do Banco de Dados: ConfiguracaoBanco\n Detalhes:"+e.Message);
             
            }
            Conexao(DadosDaConexao.StringDeConexao);

            try
            {
                testaConexao();
            }
            catch (Exception ee)
            {

                throw new Exception(ee.Message); ;
            }
        }


    }
}
