using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Reflection;
using static Modelo.ModeloItensCompra;

namespace DAL
{
    public class DALItensCompra
    {
        private string[] pesquisarPor = populaPesquisarPor();
        private DALConexao conexao;
        public DALItensCompra(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloItensCompra modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into itenscompra(" +
                " itc_qtde	, " +
                " itc_valor	, " +
                " com_cod	, " +
                " pro_cod	  " +
          
                ") values (" +                  
                 "@ItcQtde   , " +
                 "@ItcValor  , " +
                 "@ComCod    ,  " +
                 "@ProCod      " +
              
                 "); select @@IDENTITY;";

            if (conexao.TansasaoAtiva)
            {
                cmd.Transaction = conexao.Transacao;
            }
            else
            {
                conexao.Conectar();
            }

            AdicionaParametros(modelo, cmd);           
            modelo.ItcCod = Convert.ToInt32(cmd.ExecuteScalar());     
        }
        public void Alterar(ModeloItensCompra modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update itenscompra  set " +
                "itc_qtde	=@ItcQtde       ," +
                "itc_valor	=@ItcValor      ," +
                "com_cod	=@ComCod        ," +
                "pro_cod	=@ProCod         " +              
                "where itc_cod    =  @ItcCod;";


            if (conexao.TansasaoAtiva)
            {
                cmd.Transaction = conexao.Transacao;
            }
            else
            {
                conexao.Conectar();
            }



            AdicionaParametros(modelo, cmd);  
            cmd.ExecuteNonQuery();
            
        }

        private void AdicionaParametros(ModeloItensCompra modelo,SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@ItcCod"   , modelo.ItcCod         ); 
            cmd.Parameters.AddWithValue("@ItcValor" , modelo.ItcValor       );
            cmd.Parameters.AddWithValue("@ItcQtde"  , modelo.ItcQtde        );
            cmd.Parameters.AddWithValue("@ProCod"   , modelo.Produto.ProCod );
            cmd.Parameters.AddWithValue("@ComCod"   , modelo.Compra.ComCod  );
        }

        public void UpSert(ColecaoItensCompra colecao)
        {
            foreach (var item in colecao) 
            {
                if (item.ItcCod == 0)
                {
                    Incluir(item);

                }
                else
                {
                    Alterar(item);
                }
            
            }
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from itenscompra where itc_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);

          
            cmd.ExecuteNonQuery();
           
        }

        private static string[] populaPesquisarPor()
        {
            string[] pesquisarPor = new string[(Enum.GetNames(typeof(ItensCompraPesquisaPor)).Length)];
            pesquisarPor[(int)ItensCompraPesquisaPor.codigo      ] = "itc_cod";
            pesquisarPor[(int)ItensCompraPesquisaPor.fornecedor  ] = "for_cod";
            pesquisarPor[(int)ItensCompraPesquisaPor.compra      ] = "com_cod";


            return pesquisarPor;
        }
        public DataTable Localizar(string valor, ItensCompraPesquisaPor enumPesquisarPor = ItensCompraPesquisaPor.compra, TipoPesquisa tipoPesquisa = TipoPesquisa.exata)
        {
            if (tipoPesquisa == TipoPesquisa.aproximada) { valor = "%" + valor + "%"; }
            if (valor == "") { valor = "%%%"; }
            if (enumPesquisarPor == ItensCompraPesquisaPor.codigo) { tipoPesquisa = TipoPesquisa.exata; }

            string sql = "select   " +
                "itc_cod    ," +
                "itc_qtde	," +
                "itc_valor	," +
                "com_cod	," +
                "pro_cod	 " +         
                "from itenscompra where " +
            pesquisarPor[(int)enumPesquisarPor] + DALConstantes.operador[(int)tipoPesquisa] + " @Valor";

            int[] valorInt = { Convert.ToInt32(valor) };
            return DALUtil.BuscaResultadoDataTable(valorInt, sql, conexao);
        }

        public static void preencheModelocomDataReader(ModeloItensCompra modelo, SqlDataReader reg)
        {
            modelo.ItcCod =             Convert.ToInt32 (reg["itc_cod"  ]);
            modelo.ItcQtde =            Convert.ToDouble(reg["itc_qtde" ]);                   
            modelo.ItcValor =           Convert.ToDouble(reg["itc_valor"]);
            modelo.Produto.ProCod =     Convert.ToInt32 (reg["com_cod"	]);
            modelo.Compra.ComCod =      Convert.ToInt32 (reg["pro_cod"	]);





        }

        public ColecaoItensCompra LocalizarListaItens(int codCompra)
        {
            var colecao = new ColecaoItensCompra();
            DataTable dataTable = Localizar(codCompra.ToString());
            preencheModeloColecaoComDataTable(colecao, dataTable);
            return colecao;          
        }

        public static void preencheModeloColecaoComDataTable(ColecaoItensCompra colecao, DataTable dt)
        {            
            colecao = dt.AsEnumerable().Select(row => new ModeloItensCompra
            {
                ItcCod = Convert.ToInt32(row["itc_cod"]),
                ItcQtde = Convert.ToDouble(row["itc_qtde"]),
                ItcValor = Convert.ToDouble(row["itc_valor"]),
                Produto =new produto {ProCod= Convert.ToInt32(row["pro_cod"])},
                Compra = new compra { ComCod = Convert.ToInt32(row["com_cod"])}
             
            }).ToList() as ColecaoItensCompra;   
          
            
            //foreach(DataRow row in dt.Rows)
            //{
            //    var modelo = new ModeloItensCompra();
            //    modelo.ItcCod = Convert.ToInt32(row["itc_cod"]);
            //    modelo.ItcQtde = Convert.ToDouble(row["itc_qtde"]);
            //    modelo.ItcValor = Convert.ToDouble(row["itc_valor"]);
            //    modelo.Produto.ProCod = Convert.ToInt32(row["pro_cod"]);
            //    modelo.Compra.ComCod = Convert.ToInt32(row["com_cod"]); 
            //}


        }
        public ModeloItensCompra CarregaModelo(int codigo)
        {

            string sql = "select  * from itenscompra where for_cod=@Valor";
            var modelo = new ModeloItensCompra();
            SqlDataReader reg = DALUtil.buscaResultadoDataReader(codigo, sql, conexao);

            if (!reg.HasRows) { return modelo; }
            reg.Read();
            preencheModelocomDataReader(modelo, reg);


            return modelo;

        }

    }
}
