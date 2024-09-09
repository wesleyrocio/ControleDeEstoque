using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloTipoPagamento : ModeloInterfaceEntidades
    {
        private int tpa_cod = 0;
        private string tpa_nome = "";
        public int TpaCod { get { return tpa_cod; } set { tpa_cod = value; } }
        public string TpaNome { get { return tpa_nome; } set { tpa_nome = value; } }      

        public ModeloTipoPagamento()
        {
           
            TpaCod = 0;
            TpaNome = "";
        }
        public ModeloTipoPagamento(int tpacod, string tpanome)
        {          
            TpaCod = tpacod;
            TpaNome = tpanome;
        }
    }
}
