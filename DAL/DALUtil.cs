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

            /* 

             cmd.Parameters.AddWithValue("@cli_cod", modelo.CliCod         );            
             cmd.Parameters.AddWithValue("@cli_nome", modelo.CliNome        );
             cmd.Parameters.AddWithValue("@cli_cpfcnpj", modelo.CliCpfCnpj     );
             cmd.Parameters.AddWithValue("@cli_rgie", modelo.CliRgIe        );
             cmd.Parameters.AddWithValue("@cli_rsocial", modelo.CliRsocial     );
             cmd.Parameters.AddWithValue("@cli_tipo", modelo.CliTipo        );
             cmd.Parameters.AddWithValue("@cli_cep", modelo.CliCep         );
             cmd.Parameters.AddWithValue("@cli_endereco", modelo.CliEndereco    );
             cmd.Parameters.AddWithValue("@cli_bairro", modelo.CliBairro      );
             cmd.Parameters.AddWithValue("@cli_fone", modelo.CliFone        );
             cmd.Parameters.AddWithValue("@cli_cel", modelo.CliCel         );
             cmd.Parameters.AddWithValue("@cli_email", modelo.CliEmail       );
             cmd.Parameters.AddWithValue("@cli_endnumero", modelo.CliEndNumero   );
             cmd.Parameters.AddWithValue("@cli_cidade", modelo.CliCidade      );
             cmd.Parameters.AddWithValue("@cli_estado", modelo.CliEstado      );*/
        }

        public static DataTable BuscaResultadoDataTable(string[] valor, string sql, DALConexao conexao)
        {
            var cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Valor", valor);
          
            if (valor.Length > 1) 
            {
                cmd.Parameters.AddWithValue("@Valor02",valor[1]);
            }           
           
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
