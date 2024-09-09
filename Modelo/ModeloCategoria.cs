using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCategoria:ModeloInterfaceEntidades
    {
        private int    cat_cod=0;
        private string cat_nome="";
        public int    CatCod {  get { return cat_cod; } set {cat_cod=value; } }
        public string CatNome { get { return cat_nome; } set { cat_nome = value; } }

        public List<ModeloSubCategoria> SubCategorias { get; set; }    

      
        public ModeloCategoria()
        {            
            SubCategorias = new List<ModeloSubCategoria>();
            CatCod = 0;
            CatNome = "";
        }
        public ModeloCategoria(int catcod, string snome)
        {
            SubCategorias = new List<ModeloSubCategoria>();
            CatCod = catcod;            
            CatNome = snome;
        }
        public static ModeloCategoria New() { return new ModeloCategoria(); }



    }
}
