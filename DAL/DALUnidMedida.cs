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
    public class DALUndMedida
    {        

        private DALConexao conexao;
        public DALUndMedida(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloUndMedida modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into undmedida(umed_nome) values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.UmedNome);

            conexao.Conectar();
            modelo.UmedCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloUndMedida modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update undmedida set umed_nome=@nome where umed_cod=@codigo;";
            cmd.Parameters.AddWithValue("@nome", modelo.UmedNome);
            cmd.Parameters.AddWithValue("@codigo", modelo.UmedCod);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from undmedida where umed_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor, TipoPesquisa tipoPesquisa=TipoPesquisa.aproximada)
        {
            string[] ssql = new string[(int)TipoPesquisa.aproximada + 1];
            string sql = "select * from undmedida where umed_nome";

            ssql[(int)TipoPesquisa.exata] = sql + " = '" + valor + "'";
            ssql[(int)TipoPesquisa.aproximada] = sql + " like '%" + valor + "%'"; 

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql[(int)tipoPesquisa], conexao.StringConexao);
            da.Fill(dt);
            return dt;
        }

        public ModeloUndMedida LocalizaUndMedida(string valor)
        {
            var modelo = new ModeloUndMedida();
            var dt = new DataTable();
            dt = Localizar(valor, TipoPesquisa.exata);

            if (dt.Rows.Count <= 0)
            {
                modelo.UmedCod = 0;
                modelo.UmedNome = "";
                return modelo;
            }

            modelo.UmedCod = Convert.ToInt32(dt.Rows[0]["umed_cod"].ToString());
            modelo.UmedNome = dt.Rows[0]["umed_nome"].ToString();

            return modelo;

        }

        public void Desconectar()
        {
            conexao.Desconectar();
        }


        public ModeloUndMedida CarregaModeloUndMedida(int codigo)
        {
            ModeloUndMedida modelo = new ModeloUndMedida();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from undmedida where umed_cod=@codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows) { return modelo; }
            dr.Read();
            modelo.UmedCod = Convert.ToInt32(dr["umed_cod"]);
            modelo.UmedNome = Convert.ToString(dr["umed_nome"]);
            conexao.Desconectar();
            return modelo;

        }
    }

}

