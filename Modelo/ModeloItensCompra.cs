using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    //public class produto
    //{
    //    public string ProNome;
    //    public int ProCod;
    //}
    public class ModeloItensCompra
    {
        public class produto
        {
            public string ProNome { get; set; } = "";
            public int ProCod { get; set; } = 0;
        }

        public class compra
        {
            public double ComValor { get; set; } = 0;
            public int    ComCod { get; set; }= 0;
        }

        private int       itc_cod    ;
        private double    itc_qtde   ;
        private double    itc_valor  ;
        private double    _total;
       
        private produto _produto;
        private compra _compra; 


        public int     ItcCod  { get { return itc_cod       ; } set { itc_cod          = value; } }
        public Double  ItcValor { get { return itc_valor     ; } set { itc_valor        = value; } }
        public double  ItcQtde  { get { return itc_qtde      ; } set { itc_qtde         = value; } }
        

        public produto Produto { get { return _produto ; }  set { _produto = value; } }
        public compra  Compra { get { return _compra; } set { _compra = value; } }

        public double Total { get { return itc_qtde * itc_valor; } }

        public ModeloItensCompra() 
        {

            itc_cod   = 0;
            itc_qtde  = 0;
            itc_valor = 0;  
            _total = 0;
          
            _produto = new produto();
            Produto.ProCod = 0;
            Produto.ProNome = "";

            _compra = new compra();
            Compra.ComCod = 0;
            Compra.ComValor = 0;


        }

 
    }
}
