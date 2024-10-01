using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloParcelasVenda
    {
        private int pve_cod;
        private double pve_valor;
        private DateTime? pve_datapagto;
        private DateTime? pve_datavecto;
        private int ven_cod;


        public int PveCod { get { return pve_cod; } set { pve_cod = value; } }
        public double PveValor { get { return pve_valor; } set { pve_valor = value; } }
        public DateTime? PveDataPagto { get { return pve_datapagto; } set { pve_datapagto = value; } }
        public DateTime? PveDataVecto { get { return pve_datavecto; } set { pve_datavecto = value; } }
        public int VenCod { get { return ven_cod; } set { ven_cod = value; } }

        public ModeloParcelasVenda()
        {
            PveCod = 0;
            PveValor = 0;
            PveDataPagto = null;
            PveDataVecto = null;
            VenCod = 0;

        }

        public ModeloParcelasVenda New()
        {
            return new ModeloParcelasVenda();
        }

    }
}
