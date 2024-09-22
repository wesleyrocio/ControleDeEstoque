﻿using EnumsCompartilhados;
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

            verificaTransacao(cmd);
            AdicionaParametros(modelo, cmd);
            modelo.PcoCod = Convert.ToInt32(cmd.ExecuteScalar());
        }
        public void Alterar(ModeloParcelasCompra modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update fornecedor    set " +
                "pco_valor     = @PcoValor        , " +
                "pco_datapagto = @PcoDataPagto    , " +
                "pco_datavecto = @PcoDataVecto    , " +
                "com_cod       = @ComCod            " +
                "where pco_cod = @PcoCod          ;";
           
            verificaTransacao(cmd);
            AdicionaParametros(modelo, cmd);
            cmd.ExecuteNonQuery();

        }

        private void verificaTransacao(SqlCommand cmd)
        {
            if (conexao.TansasaoAtiva)
            {
                cmd.Transaction = conexao.Transacao;
            }
            else
            {
                conexao.Conectar();
            }
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

        public void UpSert(ColecaoParcelasCompra colecao)
        {
            foreach (var item in colecao)
            {
                if (item.PcoCod == 0)
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
            cmd.CommandText = "delete from parcelacompra where pco_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);


            cmd.ExecuteNonQuery();

        }

        private static string[] populaPesquisarPor()
        {
            string[] pesquisarPor = new string[(Enum.GetNames(typeof(ParcelasCompraPesquisaPor)).Length)];
            pesquisarPor[(int)ParcelasCompraPesquisaPor.codigo] = "pco_cod";            
            pesquisarPor[(int)ParcelasCompraPesquisaPor.compra] = "com_cod";


            return pesquisarPor;
        }
        public DataTable Localizar(string valor, ParcelasCompraPesquisaPor enumPesquisarPor = ParcelasCompraPesquisaPor.compra, TipoPesquisa tipoPesquisa = TipoPesquisa.exata)
        {
            if (tipoPesquisa == TipoPesquisa.aproximada) { valor = "%" + valor + "%"; }
            if (valor == "") { valor = "%%%"; }
            if (enumPesquisarPor == ParcelasCompraPesquisaPor.codigo) { tipoPesquisa = TipoPesquisa.exata; }

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
            DataTable dataTable = Localizar(codCompra.ToString());
            preencheModeloColecaoComDataTable(colecao, dataTable);
            return colecao;


        }

        public static void preencheModeloColecaoComDataTable(ColecaoParcelasCompra colecao, DataTable dt)
        {
            colecao = dt.AsEnumerable().Select(row => new ModeloParcelasCompra
            {
                PcoCod       = Convert.ToInt32   (row ["pco_cod"       ]),
                PcoValor     = Convert.ToDouble  (row ["pco_valor"     ]),
                PcoDataPagto = Convert.ToDateTime(row ["pco_datapagto" ]),
                PcoDataVecto = Convert.ToDateTime(row ["pco_datavecto" ]),
               ComCod        = Convert.ToInt32   (row ["com_cod"       ])

            }).ToList() as ColecaoParcelasCompra;
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
