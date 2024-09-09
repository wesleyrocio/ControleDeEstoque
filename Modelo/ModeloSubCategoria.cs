using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloSubCategoria : ModeloInterfaceEntidades
    {
        private int scat_cod;
        private string scat_nome;
       
        public int ScatCod { get { return scat_cod; } set { scat_cod = value; } }
        public string ScatNome { get { return scat_nome; } set { scat_nome = value; } }
       
        public ModeloCategoria Categoria { get; set; }


        public ModeloSubCategoria() 
        {
            ScatCod = 0;
            ScatNome = "";            
            Categoria = new ModeloCategoria();

        }

        public ModeloSubCategoria(int scatcod, int catcod, string snome, string cnome="")
        {
            ScatCod = scatcod;           
            ScatNome = snome;      
        }


    }
}
