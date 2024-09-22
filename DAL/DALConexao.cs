using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;

namespace DAL
{

    public class DALConexao
    {
        private string _stringConexao;
        private SqlConnection _conexao;
        private SqlTransaction _transacao;
        private bool _transacaoAtiva = false;

        public bool TansasaoAtiva { get { return _transacaoAtiva; } }
        public SqlTransaction Transacao {get {return _transacao;} }


        public void IniciarTransacao()
        {
            if (_conexao.State != ConnectionState.Open)
            {
                throw new Exception("Não é possível iniciar uma nova transação. A conexão não está aberta.");
            }

            //_conexao.Open();
            

            // Inicia a transação
            _transacao = _conexao.BeginTransaction();
            _transacaoAtiva = true;
        }
        public void Commit()
        {
            if (!_transacaoAtiva)
            {
                throw new Exception("Não há transação ativa para ser finalizada.");
            }

            _transacao.Commit();
            _transacao = null;
            _transacaoAtiva = false;
        }

        public void Rollback()
        {
            if (!_transacaoAtiva)
            {
                throw new Exception("Não há transação ativa para ser cancelada.");
            }

            _transacao.Rollback();
            _transacao = null;
            _transacaoAtiva = false;
        }



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
