using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCompra
    {

        private int                      com_cod        ;
        private DateTime                 com_data       ;
        private int                      com_nfiscal    ;
        private double                   com_total      ;
        private int                      com_nparcelas  ;
        private string                   com_status     ;
        private ModeloFornecedor         _fornecedor    ;
        private ModeloTipoPagamento      _tipoPagamento ;
        private ColecaoItensCompra      _colecaoItensCompra;
        private ColecaoItensCompra      _colecaoItensCompraDelete;
        private ColecaoParcelasCompra   _colecaoParcelasCompra;


        public int                 ComCod              { get { return  com_cod           ; } set { com_cod        = value; } }
        public DateTime            ComData             { get { return  com_data          ; } set { com_data       = value; } }
        public int                 ComNfiscal          { get { return  com_nfiscal       ; } set { com_nfiscal    = value; } }
        public double              ComTotal            { get { return  com_total         ; } set { com_total      = value; } }
        public int                 ComNparcelas        { get { return  com_nparcelas     ; } set { com_nparcelas  = value; } }
        public string              ComStatus           { get { return  com_status        ; } set { com_status     = value; } }
        public ModeloFornecedor    Fornecedor          { get { return  _fornecedor       ; } set { _fornecedor    = value; } }
        public ModeloTipoPagamento TipoPagamento       { get { return  _tipoPagamento    ; } set { _tipoPagamento = value; } }
        
        public ColecaoItensCompra ListaItens           { get { return _colecaoItensCompra; } set { _colecaoItensCompra = value; } }

        public ColecaoItensCompra ListaItensDelete { get { return _colecaoItensCompraDelete; } set { _colecaoItensCompraDelete = value; } }



        public ColecaoParcelasCompra Parcelas          { get { return _colecaoParcelasCompra; } set { _colecaoParcelasCompra = value; } }  
        public ModeloCompra()
        {
            ComCod        = 0;
            ComData       = DateTime.Now;
            ComNfiscal    = 0;
            ComTotal      = 0;
            ComNparcelas  = 0;
            ComStatus     = "";
            Fornecedor    = new ModeloFornecedor();
            TipoPagamento = new ModeloTipoPagamento();
            ListaItens    = new ColecaoItensCompra();
            ListaItensDelete = new ColecaoItensCompra();
        }

    }
}
