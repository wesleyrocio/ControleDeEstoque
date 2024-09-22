using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DAL
{
    public class DALCompra
    {
        private string[] pesquisarPor = populaPesquisarPor();
        private DALConexao conexao;
        public DALCompra(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCompra modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into Compra(" +
                "com_data      , " +
                "com_nfiscal   , " +
                "com_total     , " +
                "com_nparcelas , " +
                "com_status    , " +
                "for_cod       , " +
                "tpa_cod         " +
              
                ") values (" +
                 "@ComData      , " +
                 "@ComNfiscal   , " +
                 "@ComTotal     , " +
                 "@ComNparcelas , " +
                 "@ComStatus    , " +
                 "@ForCod       , " +
                 "@TpaCod         " +
                 "); select @@IDENTITY;";

            AdicionaParametros(modelo, cmd);
            if (conexao.TansasaoAtiva)
            {
                cmd.Transaction = conexao.Transacao;
            }
            else
            {
                conexao.Conectar();
            }

            modelo.ComCod = Convert.ToInt32(cmd.ExecuteScalar());
        
            modelo.ListaItens.ForEach(item => item.Compra.ComCod = modelo.ComCod);
            modelo.Parcelas.ForEach(parcela => parcela.ComCod = modelo.ComCod);

            //var dalItensCompra = new DALItensCompra(conexao);
            //dalItensCompra.UpSert(modelo.ListaItens);
            //var dalParcelasCompra = new DALParcelasCompra(conexao);
            //dalParcelasCompra.UpSert(modelo.Parcelas);


        }

        private void AdicionaParametros(ModeloCompra modelo, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ComCod"        , modelo.ComCod               );
            cmd.Parameters.Add("@ComData", SqlDbType.DateTime);
            cmd.Parameters["@ComData"].Value = modelo.ComData;
            cmd.Parameters.AddWithValue("@ComNfiscal"    , modelo.ComNfiscal           );
            cmd.Parameters.AddWithValue("@ComTotal"      , modelo.ComTotal             );
            cmd.Parameters.AddWithValue("@ComNparcelas"  , modelo.ComNparcelas         );
            cmd.Parameters.AddWithValue("@ComStatus"     , modelo.ComStatus            );
            cmd.Parameters.AddWithValue("@ForCod"        , modelo.Fornecedor.ForCod    );
            cmd.Parameters.AddWithValue("@TpaCod"        , modelo.TipoPagamento.TpaCod );        
        }

        public void Alterar(ModeloCompra modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update compra    set " +
                "com_data      = @ComData        ," +
                "com_nfiscal   = @ComNfiscal     ," +
                "com_total     = @ComTotal       ," +
                "com_nparcelas = @ComNparcelas   ," +
                "com_status    = @ComStatus      ," +
                "for_cod       = @ForCod         ," +
                "tpa_cod       = @TpaCod          " +               
                "where com_cod = @ComCod          ;";

            AdicionaParametros(modelo, cmd);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from compra where com_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string[] valor, CompraPesquisarPor enumPesquisarPor = CompraPesquisarPor.nomeFornecedor, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {
            string sql = DefinePesquisa(valor, enumPesquisarPor,  tipoPesquisa);
            DataTable dt = new DataTable();

            switch (enumPesquisarPor)
            {
                case CompraPesquisarPor.codTipoPagamento:
                case CompraPesquisarPor.codFornecedor:
                case CompraPesquisarPor.notaFiscal:
                case CompraPesquisarPor.numeroParcelas:
                case CompraPesquisarPor.codigo:
                    {
                        int[] valorConvert = new int[valor.Length];
                        valorConvert[0] = Convert.ToInt32(valor[0]);
                        if (valor.Length > 1) valorConvert[1] = Convert.ToInt32(valor[1]);
                        dt = DALUtil.BuscaResultadoDataTable(valorConvert, sql, conexao);
                        break;                       
                    }
                case CompraPesquisarPor.data:
                    {
                        DateTime[] valorConvert = new DateTime[valor.Length];
                        valorConvert[0] = Convert.ToDateTime(valor[0]);
                        if (valor.Length>1) valorConvert[1] = Convert.ToDateTime(valor[1]);
                        dt = DALUtil.BuscaResultadoDataTable(valorConvert, sql, conexao);
                        break;
                    }
                case CompraPesquisarPor.nomeTipoPagamento:
                case CompraPesquisarPor.nomeFornecedor:
                case CompraPesquisarPor.status:
                    {
                        var valorConvert = Convert.ToString(valor[0]);
                        dt = DALUtil.BuscaResultadoDataTable([valorConvert], sql, conexao);
                        break;
                    }
                case CompraPesquisarPor.total:
                    {
                        Double[] valorConvert = new Double[valor.Length];
                        valorConvert[0] = Convert.ToDouble(valor[0]);
                        if (valor.Length > 1) valorConvert[1] = Convert.ToDouble(valor[1]);
                        dt = DALUtil.BuscaResultadoDataTable(valorConvert, sql, conexao);
                        break;
                      
                    }
            }

            return dt;

        }

        private string DefinePesquisa(string[] valor, CompraPesquisarPor enumPesquisarPor,  TipoPesquisa tipoPesquisa)
        {
    
            
            
            if (tipoPesquisa == TipoPesquisa.aproximada) { valor[0] = "%" + valor[0] + "%"; }          
            if (valor[0] == "") { valor[0] = "%%%"; }

            if (enumPesquisarPor == CompraPesquisarPor.codigo) { tipoPesquisa = TipoPesquisa.exata; }

            string sql = "" +
                "select * from compra                                      " +
                "inner join fornecedor ON compra.for_cod=fornecedor.for_cod       " +
                "inner join tipopagamento ON compra.tpa_cod=tipopagamento.tpa_cod " +
                "where " +
            pesquisarPor[(int)enumPesquisarPor] + DALConstantes.operador[(int)tipoPesquisa] + " @Valor ";
            if (tipoPesquisa == TipoPesquisa.intervalo) {
                sql += " and @Valor02";
            }
            
            
            return sql;
        }

        private static string[] populaPesquisarPor()
        {

            

            string[] pesquisarPor = new string[(Enum.GetNames(typeof(CompraPesquisarPor)).Length)];
            pesquisarPor[(int)CompraPesquisarPor.codigo             ] = "com_cod"                ;
            pesquisarPor[(int)CompraPesquisarPor.data               ] = "com_data"               ;
            pesquisarPor[(int)CompraPesquisarPor.notaFiscal         ] = "com_nfiscal"            ;
            pesquisarPor[(int)CompraPesquisarPor.numeroParcelas     ] = "com_nparcelas"          ;
            pesquisarPor[(int)CompraPesquisarPor.status             ] = "com_status"             ;
            pesquisarPor[(int)CompraPesquisarPor.codFornecedor      ] = "compra.for_cod"         ;
            pesquisarPor[(int)CompraPesquisarPor.nomeFornecedor     ] = "fornecedor.for_nome"    ;
            pesquisarPor[(int)CompraPesquisarPor.codTipoPagamento   ] = "compra.tpa_cod"         ;
            pesquisarPor[(int)CompraPesquisarPor.nomeTipoPagamento  ] = "tipopagamento.tpa_nome" ;
            return pesquisarPor;
        }
        private static void preencheModelocomDataReader(ModeloCompra modelo, SqlDataReader reg)
        {
            modelo.ComCod                 = Convert.ToInt32    (reg["com_cod"]);
            modelo.ComData                = Convert.ToDateTime (reg["com_data"]);
            modelo.ComNfiscal             = Convert.ToInt32    (reg["com_nfiscal"]);
            modelo.ComTotal               = Convert.ToDouble   (reg["com_total"]);
            modelo.ComNparcelas           = Convert.ToInt32    (reg["com_nparcelas"]);
            modelo.ComStatus              = Convert.ToString   (reg["com_status"]);
            
            DALFornecedor.preencheModelocomDataReader(modelo.Fornecedor, reg);
            DALTipoPagamento.preencherModeloComDataReader(modelo.TipoPagamento, reg);          
          
            
        }
        public ModeloCompra CarregaModelo(int codigo)
        {

            string sql = DefinePesquisa([codigo.ToString()], CompraPesquisarPor.codigo,TipoPesquisa.exata ); 
            ModeloCompra modelo = new ModeloCompra();
            SqlDataReader reg = DALUtil.buscaResultadoDataReader(codigo, sql, conexao);

            if (!reg.HasRows) { return modelo; }
            reg.Read();
            preencheModelocomDataReader(modelo, reg);

            conexao.Desconectar();
            return modelo;

        }
    }
}
