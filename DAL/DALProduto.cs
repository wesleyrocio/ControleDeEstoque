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
    public class DALProduto
    {
       
        private DALConexao conexao;
        public DALProduto(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloProduto modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into produto(" +
                "pro_nome, " +
                "pro_descricao, " +
                "pro_foto, " +
                "pro_valorpago, " +
                "pro_valorvenda, " +
                "pro_qtde, " +
                "umed_cod, " +
                "cat_cod, " +
                "scat_cod " +
                ") values (" +
                 "@pro_nome,      " +
                 "@pro_descricao, " +
                 "@pro_foto,      " +
                 "@pro_valorpago, " +
                 "@pro_valorvenda," +
                 "@pro_qtde,      " +
                 "@umed_cod,      " +
                 "@cat_cod,       " +
                 "@scat_cod       " +
                 "); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@pro_nome"       ,modelo.ProNome);
            cmd.Parameters.AddWithValue("@pro_descricao"  ,modelo.ProDescricao );
            cmd.Parameters.Add("@pro_foto"       ,SqlDbType.Image     );
            if(modelo.ProFoto == null)
            {
                cmd.Parameters["@pro_foto"].Value=DBNull.Value;
            }
            else
            {
                cmd.Parameters["@pro_foto"].Value = modelo.ProFoto;
            }
          

            cmd.Parameters.AddWithValue("@pro_valorpago"  ,modelo.ProValorpago );
            cmd.Parameters.AddWithValue("@pro_valorvenda" ,modelo.ProValorVenda);
            cmd.Parameters.AddWithValue("@pro_qtde"       ,modelo.ProQtde      );
            cmd.Parameters.AddWithValue("@umed_cod"       ,modelo.UnidadeDeMedida.UmedCod);
            cmd.Parameters.AddWithValue("@cat_cod"        ,modelo.Categoria.CatCod       );
            cmd.Parameters.AddWithValue("@scat_cod"       ,modelo.SubCategoria.ScatCod   );


            conexao.Conectar();
            modelo.ProCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloProduto modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update produto set " +
                "pro_nome      =@pro_nome          ," +
                "pro_descricao =@pro_descricao     ," +
                "pro_foto      =@pro_foto          ," +
                "pro_valorpago =@pro_valorpago     ," +
                "pro_valorvenda=@pro_valorvenda    ," +
                "pro_qtde      =@pro_qtde          ," +
                "umed_cod      =@umed_cod          ," +
                "cat_cod       =@cat_cod           ," +
                "scat_cod      =@scat_cod           " +         
                "where pro_cod =@pro_cod;";
           
            cmd.Parameters.AddWithValue("@pro_cod", modelo.ProCod);
            cmd.Parameters.AddWithValue("@pro_nome", modelo.ProNome);
            cmd.Parameters.AddWithValue("@pro_descricao", modelo.ProDescricao);
            cmd.Parameters.Add("@pro_foto", SqlDbType.Image);
            if (modelo.ProFoto == null)
            {
                cmd.Parameters["@pro_foto"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@pro_foto"].Value = modelo.ProFoto;
            }
            cmd.Parameters.AddWithValue("@pro_valorpago", modelo.ProValorpago);
            cmd.Parameters.AddWithValue("@pro_valorvenda", modelo.ProValorVenda);
            cmd.Parameters.AddWithValue("@pro_qtde", modelo.ProQtde);
            cmd.Parameters.AddWithValue("@umed_cod", modelo.UnidadeDeMedida.UmedCod);
            cmd.Parameters.AddWithValue("@cat_cod", modelo.Categoria.CatCod);
            cmd.Parameters.AddWithValue("@scat_cod", modelo.SubCategoria.ScatCod);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from produto where cat_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor, ProdutoPesquisarPor enumPesquisarPor=ProdutoPesquisarPor.nome, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {
            string[] pesquisarPor = new string[Enum.GetNames(typeof(ProdutoPesquisarPor)).Length];

            string[] operador = { " = ", " LIKE " };

            if (tipoPesquisa == TipoPesquisa.aproximada) { valor = "%" + valor + "%"; }
            if (valor=="") { valor = "%%%"; }
            if (enumPesquisarPor == ProdutoPesquisarPor.codigo) { tipoPesquisa=TipoPesquisa.exata;}

            pesquisarPor[(int)ProdutoPesquisarPor.codigo] =      " where p.pro_cod  " + operador[(int)tipoPesquisa] + " @Valor";
            pesquisarPor[(int)ProdutoPesquisarPor.nome] =        " where p.pro_nome " + operador[(int)tipoPesquisa] + " @Valor";
            pesquisarPor[(int)ProdutoPesquisarPor.categoria] =   " where cat_nome    " + operador[(int)tipoPesquisa] + " @Valor";
            pesquisarPor[(int)ProdutoPesquisarPor.subcategoria]= " where scat_nome   " + operador[(int)tipoPesquisa] + " @Valor";

            string sql = "" +
            "select" +
            "           p.pro_cod," +
            "           p.pro_nome,       " +
            "			p.pro_descricao,  " +
            "			p.pro_foto,       " +
            "			p.pro_valorpago,  " +
            "			p.pro_valorvenda, " +
            "			p.pro_qtde,       " +
            "			p.umed_cod,       " +
            "			u.umed_nome,      " +
            "			p.cat_cod ,       " +
            "			c.cat_nome,       " +
            "			p.scat_cod,       " +
            "			s.scat_nome	  " +
            "  from produto p             " +
            "    inner join undmedida u on p.umed_cod=u.umed_cod    " +
            "    inner join categoria c on p.cat_cod=c.cat_cod      " +
            "    inner join subcategoria s on p.scat_cod=s.scat_cod " +
            pesquisarPor[(int)enumPesquisarPor];
           

           
            var cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Valor",valor);
         
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conexao.Desconectar();
            return dt;
        }

        public ModeloProduto CarregaModeloProduto(int codigo)
        {
            ModeloProduto modelo = new ModeloProduto();
            SqlCommand cmd = new SqlCommand();
            string sql =""+
            "select     " +
            "           p.pro_cod," +
            "           p.pro_nome,       " +
            "			p.pro_descricao,  " +
            "			p.pro_foto,       " +
            "			p.pro_valorpago,  " +
            "			p.pro_valorvenda, " +
            "			p.pro_qtde,       " +
            "			p.umed_cod,       " +
            "			u.umed_nome ,      " +
            "			p.cat_cod ,       " +
            "			c.cat_nome  ,       " +
            "			p.scat_cod,       " +
            "			s.scat_nome 	  " +        
            "  from produto p             " +
            "    inner join undmedida u on p.umed_cod=u.umed_cod    " +
            "    inner join categoria c on p.cat_cod=c.cat_cod      " +
            "    inner join subcategoria s on p.scat_cod=s.scat_cod " +
            "     where pro_cod=@codigo                             " ;

            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            SqlDataReader reg = cmd.ExecuteReader();
            if (!reg.HasRows) { return modelo; }
          
            
            reg.Read();
            modelo.ProCod       =          Convert.ToInt32( reg["pro_cod"]);
            modelo.ProNome      =          Convert.ToString(reg["pro_nome"])     ;
            modelo.ProDescricao =          Convert.ToString(reg["pro_descricao"])    ;
            try
            {
                modelo.ProFoto = (byte[])reg["pro_foto"];
            }
            catch { 
            }            
            modelo.ProValorpago =               Convert.ToDouble(reg["pro_valorpago"]);
            modelo.ProValorVenda =              Convert.ToDouble(reg["pro_valorvenda"]);
            modelo.ProQtde =                    Convert.ToDouble(reg["pro_qtde"]);
            modelo.UnidadeDeMedida.UmedCod  =   Convert.ToInt32( reg["umed_cod"]);
            modelo.UnidadeDeMedida.UmedNome =   Convert.ToString(reg["umed_nome"]);
            modelo.Categoria.CatCod =           Convert.ToInt32( reg["cat_cod"]);
            modelo.Categoria.CatNome =          Convert.ToString(reg["cat_nome"]);
            modelo.SubCategoria.ScatCod =       Convert.ToInt32( reg["scat_cod"]);           
            modelo.SubCategoria.ScatNome =      Convert.ToString(reg["scat_nome"]);
            conexao.Desconectar();
            return modelo;

        }
      
    }
}

