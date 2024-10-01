using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloItensVenda
    {
        public class produto
        {
            public string ProNome { get; set; } = "";
            public int ProCod { get; set; } = 0;
        }

        public class venda
        {
            public double ComValor { get; set; } = 0;
            public int ComCod { get; set; } = 0;
        }

        private int itv_cod;
        private double itv_qtde;
        private double itv_valor;
        private double _total;

        private produto _produto;
        private venda _venda;


        public int ItvCod { get { return itv_cod; } set { itv_cod = value; } }
        public Double ItvValor { get { return itv_valor; } set { itv_valor = value; } }
        public double ItvQtde { get { return itv_qtde; } set { itv_qtde = value; } }


        public produto Produto { get { return _produto; } set { _produto = value; } }
        public venda Venda { get { return _venda; } set { _venda = value; } }

        public double Total { get { return itv_qtde * itv_valor; } }

        public ModeloItensVenda()
        {

            itv_cod = 0;
            itv_qtde = 0;
            itv_valor = 0;
            _total = 0;

            _produto = new produto();
            Produto.ProCod = 0;
            Produto.ProNome = "";

            _venda = new venda();
            Venda.ComCod = 0;
            Venda.ComValor = 0;


        }


    }
}
