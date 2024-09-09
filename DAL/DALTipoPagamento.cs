using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;

namespace DAL
{
    public class DALTipoPagamento
    {
        private DALConexao conexao;
        public DALTipoPagamento(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloTipoPagamento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into tipopagamento(tpa_nome) values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.TpaNome);

            conexao.Conectar();
            modelo.TpaCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloTipoPagamento modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update tipopagamento set tpa_nome=@nome where tpa_cod=@codigo;";
            cmd.Parameters.AddWithValue("@nome", modelo.TpaNome);
            cmd.Parameters.AddWithValue("@codigo", modelo.TpaCod);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from tipopagamento where tpa_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {
                      
            string[] ssql = new string[(int)TipoPesquisa.aproximada+1];
            string sql = "select * from tipopagamento where tpa_nome";

            ssql[(int)TipoPesquisa.exata] =      sql + " = '" + valor + "'";
            ssql[(int)TipoPesquisa.aproximada] = sql + " like '%" + valor + "%'";   

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql[(int)tipoPesquisa], conexao.StringConexao);
            da.Fill(dt);
            return dt;
        }

        public ModeloTipoPagamento LocalizaTipoPagamento(string valor)
        {
            var modelo = new ModeloTipoPagamento();
            DataTable dt = new DataTable();
            dt = Localizar(valor, TipoPesquisa.exata);

            if (dt.Rows.Count <= 0)
            {
                modelo.TpaCod  = 0;
                modelo.TpaNome = "";
                return modelo;
            }
            modelo.TpaCod  = Convert.ToInt32(dt.Rows[0]["tpa_cod"].ToString());
            modelo.TpaNome = dt.Rows[0]["tpa_nome"].ToString();

            return modelo;

        }

        public void Desconectar()
        {
            conexao.Desconectar();
        }


        public ModeloTipoPagamento CarregaModeloTipoPagamento(int codigo)
        {
            var modelo = new ModeloTipoPagamento();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from tipopagamento where tpa_cod=@codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows) { return modelo; }
            dr.Read();
            preencherModeloComDataReader(modelo, dr);
            conexao.Desconectar();
            return modelo;

        }

        public static void preencherModeloComDataReader(ModeloTipoPagamento modelo, SqlDataReader dr)
        {
            modelo.TpaCod  = Convert.ToInt32(dr["tpa_cod"]);
            modelo.TpaNome = Convert.ToString(dr["tpa_nome"]);
        }
    }
}
