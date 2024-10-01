using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DALUtil
    {
        public static void AdicionaParametros(Object modelo, SqlCommand cmd)
        {



            foreach (PropertyInfo propriedade in modelo.GetType().GetProperties())
            {

                cmd.Parameters.AddWithValue("@" + propriedade.Name, propriedade.GetValue(modelo) == null ? DBNull.Value : propriedade.GetValue(modelo));

            }

           
        }
        public static void VerificaTransacao(SqlCommand cmd, DALConexao conexao)
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

        public static DataTable BuscaResultadoDataTable(string[] valor, string sql, DALConexao conexao)
        {
            var cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Valor", valor[0]);

            if (valor.Length > 1)
            {
                cmd.Parameters.AddWithValue("@Valor02", valor[1]);
            }

            return DataTableMotorPesquisa(conexao, cmd);
        }

        public static DataTable BuscaResultadoDataTable(double[] valor, string sql, DALConexao conexao)
        {
            var cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Valor", valor);

            if (valor.Length > 1)
            {
                cmd.Parameters.AddWithValue("@Valor02", valor[1]);
            }

            return DataTableMotorPesquisa(conexao, cmd);
        }
        public static DataTable BuscaResultadoDataTable(DateTime[] valor, string sql, DALConexao conexao)
        {
            var cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = sql;
           
            cmd.Parameters.AddWithValue("@Valor", valor[0]);

            if (valor.Length > 1)
            {
                cmd.Parameters.AddWithValue("@Valor02", valor[1]);
            }

            return DataTableMotorPesquisa(conexao, cmd);
        }
        public static DataTable BuscaResultadoDataTable(int[] valor, string sql, DALConexao conexao)
        {
            conexao.Desconectar();
            conexao.Conectar();
            var cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = sql;
           
            cmd.Parameters.AddWithValue("@Valor", valor[0]);

            if (valor.Length > 1)
            {
                cmd.Parameters.AddWithValue("@Valor02", valor[1]);
            }
            return DataTableMotorPesquisa(conexao, cmd);
        }

        private static DataTable DataTableMotorPesquisa(DALConexao conexao, SqlCommand cmd)
        {
         //   conexao.Desconectar();
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexao.Desconectar();
            return dt;
        }

        public static SqlDataReader buscaResultadoDataReader(int codigo, string sql, DALConexao conexao)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Valor", codigo);

            conexao.Conectar();
            SqlDataReader reg = cmd.ExecuteReader();
            return reg;
        }
    }
}
