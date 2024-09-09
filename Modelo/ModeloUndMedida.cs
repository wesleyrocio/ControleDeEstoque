using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloUndMedida : ModeloInterfaceEntidades
    {
        private int umed_cod;
        private string umed_nome;

        public int UmedCod { get { return umed_cod; } set { umed_cod = value; } }
        public string UmedNome { get { return umed_nome; } set { umed_nome = value; } }  
        
        public ModeloUndMedida() 
        {
            umed_cod = 0;
            umed_nome = "";
        }

        public ModeloUndMedida(int umedCod, string umedNome)
        {            
            UmedCod = umedCod;
            UmedNome = umedNome;
        }   
    }
}
