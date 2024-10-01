using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Modelo.ModeloParcelasCompra;

namespace DAL
{
    public class DALParcelasCompra
    {

        private string[] pesquisarPor = populaPesquisarPor();
        private DALConexao conexao;
        public DALParcelasCompra(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloParcelasCompra modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into parcelascompra(" +
                " pco_valor     , " +
                " pco_datapagto , " +
                " pco_datavecto , " +
                " com_cod         " +
                ") values        (" +
                 "@PcoValor      , " +
                 "@PcoDataPagto ,  " +
                 "@PcoDataVecto ,  " +
                 "@ComCod          " +

                 "); select @@IDENTITY;";

            DALUtil.VerificaTransacao(cmd, conexao);
            AdicionaParametros(modelo, cmd);
            modelo.PcoCod = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public void Alterar(ModeloParcelasCompra modelo)
        {
            throw new NotImplementedException();

        }
     

        private void AdicionaParametros(ModeloParcelasCompra modelo, SqlCommand cmd)
        {
            cmd.Parameters.Add("@PcoDataVecto", SqlDbType.DateTime);
            cmd.Parameters.Add("@PcoDataPagto", SqlDbType.DateTime);

            cmd.Parameters.AddWithValue("@PcoCod",         modelo.PcoCod         );
            cmd.Parameters.AddWithValue("@PcoValor",       modelo.PcoValor       );

            if (modelo.PcoDataPagto == null)
            {
                cmd.Parameters["@PcoDataPagto"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@PcoDataPagto"].Value = modelo.PcoDataPagto;
            }

            if (modelo.PcoDataVecto == null)
            {
                cmd.Parameters["@PcoDataVecto"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@PcoDataVecto"].Value = modelo.PcoDataVecto;
            }            
            cmd.Parameters.AddWithValue("@ComCod",         modelo.ComCod         );
        }

        public void Incluir(ColecaoParcelasCompra colecao)
        {
            foreach (var item in colecao)
            {           
                    Incluir(item);         

            }
        }
        public void Excluir(int codCompra)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from parcelascompra where com_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codCompra);
            DALUtil.VerificaTransacao(cmd, conexao);
            cmd.ExecuteNonQuery();
        }
  

        private static string[] populaPesquisarPor()
        {
            string[] pesquisarPor = new string[(Enum.GetNames(typeof(ParcelasCompraPesquisaPor)).Length)];
            pesquisarPor[(int)ParcelasCompraPesquisaPor.codigo] = "pco_cod";            
            pesquisarPor[(int)ParcelasCompraPesquisaPor.compra] = "com_cod";


            return pesquisarPor;
        }
        public DataTable Localizar(int valor, ParcelasCompraPesquisaPor enumPesquisarPor = ParcelasCompraPesquisaPor.compra, TipoPesquisa tipoPesquisa = TipoPesquisa.exata)
        {
           // if (tipoPesquisa == TipoPesquisa.aproximada) { valor = "%" + valor + "%"; }
           // if (valor == "") { valor = "%%%"; }
            if (enumPesquisarPor == ParcelasCompraPesquisaPor.codigo) 
            { 
                tipoPesquisa = TipoPesquisa.exata;
            }

            string sql = "select   " +
                "pco_cod      ," +
                "pco_valor    ," +
                "pco_datapagto," +
                "pco_datavecto," +
                "com_cod       " +
                "from parcelascompra where " +
            pesquisarPor[(int)enumPesquisarPor] + DALConstantes.operador[(int)tipoPesquisa] + " @Valor";

            int[] valorInt = { Convert.ToInt32(valor) };
            return DALUtil.BuscaResultadoDataTable(valorInt, sql, conexao);
        }

        public static void preencheModelocomDataReader(ModeloParcelasCompra modelo, SqlDataReader reg)
        {
            modelo.PcoCod       =     Convert.ToInt32 (  reg ["pco_cod"      ]);
            modelo.PcoValor     =     Convert.ToDouble(  reg ["pco_valor"     ]);
            modelo.PcoDataPagto =     Convert.ToDateTime(reg ["pco_datapagto" ]);
            modelo.PcoDataVecto =     Convert.ToDateTime(reg ["pco_datavecto" ]);
            modelo.ComCod       =     Convert.ToInt32(   reg ["com_cod"       ]);

        }

        public ColecaoParcelasCompra LocalizarListaItens(int codCompra)
        {
            var colecao = new ColecaoParcelasCompra();
            DataTable dataTable = Localizar(codCompra);
            preencheModeloColecaoComDataTable(colecao, dataTable);
            return colecao;


        }

        public static void preencheModeloColecaoComDataTable(ColecaoParcelasCompra colecao, DataTable dt)
        {
            //colecao = dt.AsEnumerable().Select(row => new ModeloParcelasCompra
            //{
            //    PcoCod = Convert.ToInt32(row["pco_cod"]),
            //    PcoValor = Convert.ToDouble(row["pco_valor"]),
            //    PcoDataPagto = Convert.ToDateTime(row["pco_datapagto"]),
            //    PcoDataVecto = Convert.ToDateTime(row["pco_datavecto"]),
            //    ComCod = Convert.ToInt32(row["com_cod"])

            //}).ToList() as ColecaoParcelasCompra;

            foreach (DataRow row in dt.Rows)
            {
                var parcela = new ModeloParcelasCompra();
                parcela.ComCod = Convert.ToInt32(row["com_cod"]);
                parcela.PcoCod       = Convert.ToInt32   (row ["pco_cod"       ]);
                parcela.PcoValor     = Convert.ToDouble  (row ["pco_valor"     ]);             

                parcela.PcoDataPagto = (row["pco_datapagto"]  == DBNull.Value) ? null : Convert.ToDateTime(row ["pco_datapagto" ]);
                parcela.PcoDataVecto = (row["pco_datavecto"]  == DBNull.Value) ? null : Convert.ToDateTime(row ["pco_datavecto" ]);
                colecao.Add(parcela);
            }

        }
        public ModeloParcelasCompra CarregaModelo(int codigo)
        {

            string sql = "select  * from parcelascompra where pco_cod=@Valor";
            var modelo = new ModeloParcelasCompra();
            SqlDataReader reg = DALUtil.buscaResultadoDataReader(codigo, sql, conexao);

            if (!reg.HasRows) { return modelo; }
            reg.Read();
            preencheModelocomDataReader(modelo, reg);


            return modelo;

        }





































    }
}
