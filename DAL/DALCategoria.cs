using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;

namespace DAL
{
    public class DALCategoria
    {
        private DALConexao conexao;
        public DALCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into categoria(cat_nome) values (@nome); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.CatNome);

            conexao.Conectar();
            modelo.CatCod=Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update categoria set cat_nome=@nome where cat_cod=@codigo;";
            cmd.Parameters.AddWithValue("@nome"  , modelo.CatNome);
            cmd.Parameters.AddWithValue("@codigo", modelo.CatCod);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from categoria where cat_cod=@codigo;";           
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar()   ;
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {
            string[] ssql = new string[(int)TipoPesquisa.aproximada + 1];
            string sql = "select * from categoria where cat_nome";

            ssql[(int)TipoPesquisa.exata] = sql + " = '" + valor + "'";
            ssql[(int)TipoPesquisa.aproximada] = sql + " like '%" + valor + "%'";            

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(ssql[(int)tipoPesquisa], conexao.StringConexao);
            da.Fill(dt);
            return dt;
        }

        public ModeloCategoria CarregarModelo(int codigo)
        {
            var modelo = ModeloCategoria.New();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from categoria where cat_cod=@codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader dr = cmd.ExecuteReader();
            if (!dr.HasRows) { return modelo; }
            dr.Read();
            modelo.CatCod   = Convert.ToInt32( dr["cat_cod"] );
            modelo.CatNome =  Convert.ToString(dr["cat_nome"]);
            conexao.Desconectar();
            return modelo;

        }

        public ModeloCategoria CarregarModeloCategoriaEsubCategorias(int codigo) 
        {
           var modelo = CarregarModelo(codigo);
           var dalSubCategoria = new DALSubCategoria(conexao);
           DataTable dt=dalSubCategoria.FiltrarPorCategoria(codigo);          
         
            /* 

              foreach(DataRow linha in dt.Rows)
             {
                  var subcategoria = new ModeloSubCategoria();
                  subcategoria.ScatCod =  Convert.ToInt32 (linha["scat_cod"] );
                  subcategoria.ScatNome=  Convert.ToString(linha["scat_nome"]);
                  modelo.SubCategorias.Add(subcategoria);
             }
              conexao.Desconectar();*/
     /*       var subcategorias = (from row in dt.AsEnumerable()
                                  select new ModeloSubCategoria
                                 {
                                     ScatCod = row.Field<int>("scat_cod"),
                                     ScatNome = row.Field<string>("scat_nome")
                                 }).ToList();*/

            var subcategorias = dt.AsEnumerable().Select(row => new ModeloSubCategoria
            {
                ScatCod  = row.Field<int>("scat_cod"),
                ScatNome = row.Field<string>("scat_nome")
            }).ToList();


            modelo.SubCategorias=subcategorias;            
          
            return modelo;
        }
    }

}
