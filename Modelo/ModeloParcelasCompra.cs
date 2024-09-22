using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloParcelasCompra
    {
        private int      pco_cod         ;
        private double   pco_valor       ;
        private DateTime? pco_datapagto   ;
        private DateTime? pco_datavecto   ;
        private int      com_cod         ;


        public int      PcoCod       { get { return pco_cod        ; } set { pco_cod           = value; } } 
        public double   PcoValor     { get { return pco_valor      ; } set { pco_valor         = value; } }
        public DateTime? PcoDataPagto { get { return pco_datapagto  ;}  set { pco_datapagto     = value; } }
        public DateTime? PcoDataVecto { get { return pco_datavecto  ; } set { pco_datavecto     = value; } }
        public int      ComCod       { get { return com_cod        ; } set { com_cod           = value; }}

        public ModeloParcelasCompra()
        {
            PcoCod          = 0;
            PcoValor        = 0;
            PcoDataPagto    = null;
            PcoDataVecto    = null;
            ComCod          = 0;

        }

        public ModeloParcelasCompra New()
        {
            return new ModeloParcelasCompra();
        }

    }
}
