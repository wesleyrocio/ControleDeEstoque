using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloVenda
    {

        private int ven_cod;
        private DateTime? ven_data;
        private int ven_nfiscal;
        private double ven_total;
        private int ven_nparcelas;
        private string ven_status;
        private ModeloFornecedor _fornecedor;
        private ModeloTipoPagamento _tipoPagamento;
        private ColecaoItensVenda _colecaoItensVenda;
        private ColecaoItensVenda _colecaoItensVendaDelete;
        private ColecaoParcelasVenda _colecaoParcelasVenda;


        public int VenCod { get { return ven_cod; } set { ven_cod = value; } }
        public DateTime? VenData { get { return ven_data; } set { ven_data = value; } }
        public int VenNfiscal { get { return ven_nfiscal; } set { ven_nfiscal = value; } }
        public double VenTotal { get { return ven_total; } set { ven_total = value; } }
        public int VenNparcelas { get { return ven_nparcelas; } set { ven_nparcelas = value; } }
        public string VenStatus { get { return ven_status; } set { ven_status = value; } }
        public ModeloFornecedor Fornecedor { get { return _fornecedor; } set { _fornecedor = value; } }
        public ModeloTipoPagamento TipoPagamento { get { return _tipoPagamento; } set { _tipoPagamento = value; } }

        public ColecaoItensVenda ListaItens { get { return _colecaoItensVenda; } set { _colecaoItensVenda = value; } }

        public ColecaoItensVenda ListaItensDelete { get { return _colecaoItensVendaDelete; } set { _colecaoItensVendaDelete = value; } }



        public ColecaoParcelasVenda Parcelas { get { return _colecaoParcelasVenda; } set { _colecaoParcelasVenda = value; } }
        public ModeloVenda()
        {
            VenCod = 0;
            VenData = null;
            VenNfiscal = 0;
            VenTotal = 0;
            VenNparcelas = 0;
            VenStatus = "";
            Fornecedor = new ModeloFornecedor();
            TipoPagamento = new ModeloTipoPagamento();
            ListaItens = new ColecaoItensVenda();
            ListaItensDelete = new ColecaoItensVenda();
        }

    }
}
