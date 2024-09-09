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
    public class DALSubCategoria
    {
        private DALConexao conexao;
        public DALSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloSubCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into subcategoria(scat_nome, cat_cod) values (@nome, @catcod); select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", modelo.ScatNome);
                cmd.Parameters.AddWithValue("@catcod", modelo.Categoria.CatCod);
                conexao.Conectar();
                modelo.ScatCod = Convert.ToInt32(cmd.ExecuteScalar());   
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally {  conexao.Desconectar(); }     
        }
       
        public void Alterar(ModeloSubCategoria modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "update subcategoria set scat_nome=@snome, cat_cod=@scatcod where scat_cod=@scatcod;";
                cmd.Parameters.AddWithValue("@scatcod", modelo.ScatCod);
                cmd.Parameters.AddWithValue("@snome", modelo.ScatNome);
                cmd.Parameters.AddWithValue("@catcod", modelo.Categoria.CatCod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();               

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        
        }

        public void Excluir(int codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "delete from subcategoria where scat_cod=@scod;";
                cmd.Parameters.AddWithValue("@scod", codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public DataTable Localizar(string valor, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {
            try
            {
                string sql = "select " +
                                 "scat_cod, " +
                                 "scat_nome, " +
                                 "sub.cat_cod, " +
                                 "cat.cat_nome " +
                             "from subcategoria sub " +
                             "inner join categoria cat " +
                             "on sub.cat_cod=cat.cat_cod " +
                             "where scat_nome ";            

                string[] operador =  {" = ",  "like" };
                
                string[] ssql = new string[(int)TipoPesquisa.aproximada + 1];
                ssql[(int)TipoPesquisa.exata] =      sql + operador[(int)TipoPesquisa.exata]+       "@Valor";
                ssql[(int)TipoPesquisa.aproximada] = sql + operador[(int)TipoPesquisa.aproximada] + "@Valor";

                if (tipoPesquisa == TipoPesquisa.aproximada) { valor = "%" + valor + "%"; }
                if (valor == "") { valor = "%%%";}
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = ssql[(int)tipoPesquisa];
                cmd.Parameters.AddWithValue("@Valor", valor);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable      dt = new DataTable();
                
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
        
        }

        public DataTable FiltrarPorCategoria(int categoria)
        {
            try
            {
                
                string sql = "select c.cat_cod catcod, c.cat_nome catnome, s.scat_cod scatcod, s.scat_nome scatnome " +
                "from categoria c right join subcategoria s on c.cat_cod=s.cat_cod where c.cat_cod=" + Convert.ToString(categoria);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, conexao.StringConexao);                
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            try
            {
                string sql= "select scat_cod             , " +
                               "scat_nome                , " +
                               "sub.cat_cod as 'catcod'  , " +
                               "cat.cat_nome as 'catnome ' " +
                            "from subcategoria sub         " +
                            "inner join categoria cat on sub.cat_cod=cat.cat_cod " +
                            "where scat_cod=@scod";

                var modelo = new ModeloSubCategoria();
                var cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@scod", codigo);   

                conexao.Conectar();
                SqlDataReader dr = cmd.ExecuteReader();
                if (!dr.HasRows) { return modelo; }
                dr.Read();
                modelo.ScatCod =  Convert.ToInt32( dr["scat_cod"]);
                modelo.ScatNome = Convert.ToString(dr["scat_nome"]);
                modelo.Categoria.CatNome =  Convert.ToString(dr["catnome"]);
                modelo.Categoria.CatCod =   Convert.ToInt32( dr["catcod"]);
                conexao.Desconectar();
                return modelo;

            }
            catch (Exception e)
            {
                conexao.Desconectar();
                throw new Exception(e.Message);
            }
         
         

        }
    }
}

