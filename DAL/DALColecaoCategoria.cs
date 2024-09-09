 using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;

namespace DAL
{
    public class DALColecaoCategoria
    {
        private DALConexao conexao;

        public DALColecaoCategoria(DALConexao conexao)
        {
            this.conexao = conexao;
        }
        public ColecaoCategoria preencherColecao()
        {
        
            string sql = ""+
            "select scat_cod, scat_nome, sub.cat_cod as 'catcod', cat.cat_nome as 'catnome' " +
                                  "from subcategoria sub " +
                                  "inner join categoria cat on sub.cat_cod=cat.cat_cod";


            ColecaoCategoria colecao = new ColecaoCategoria();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conexao.StringConexao);
            da.Fill(dt);
            /*
              int codigoCategoriaAtual;
              int contador = 0;
              DataRow linha;
              while (contador<dt.Rows.Count-1) 
              {
                  linha=dt.Rows[contador];
                  var categoria = new ModeloCategoria();
                  codigoCategoriaAtual = Convert.ToInt32(linha["catcod"]);
                  categoria.CatCod = Convert.ToInt32(linha["catcod"]);
                  categoria.CatNome = Convert.ToString(linha["catnome"]);
                  while ((Convert.ToInt32(linha["catcod"])==codigoCategoriaAtual)&&contador<dt.Rows.Count-1)
                  {

                      var subcategoria = new ModeloSubCategoria();
                      subcategoria.ScatCod= Convert.ToInt32(linha["scat_cod"]);
                      subcategoria.ScatNome= Convert.ToString(linha["scat_nome"]);
                      categoria.SubCategorias.Add(subcategoria);
                      contador++;
                      linha = dt.Rows[contador];
                  }
                  colecao.Add(categoria);               
              }
              return colecao;
            */
            // ModeloCategoria cate = colecao.Find(p => p.CatCod == 4);

            var categoriasAgrupadas = dt.AsEnumerable()
            .GroupBy(row => new
            {          
                CatCod = row.Field<int>("catcod"),
                CatNome = row.Field<string>("catnome")
            })
            .Select(grupo => new ModeloCategoria
            {
                CatCod = grupo.Key.CatCod,
                CatNome = grupo.Key.CatNome,
                SubCategorias = grupo.Select(row => new ModeloSubCategoria
                {
                   
                    ScatCod = row.Field<int>("scat_cod"),
                    ScatNome = row.Field<string>("scat_nome")
                }).ToList()
            })
            .OrderBy(x => x.CatNome).ToList();

            // Adiciona as categorias agrupadas na coleção
            foreach (var categoria in categoriasAgrupadas)
            {
                colecao.Add(categoria);
            }

            return colecao;

    

        }
     
    }
}
