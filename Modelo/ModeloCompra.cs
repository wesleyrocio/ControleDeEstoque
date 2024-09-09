using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCompra
    {

        int                      com_cod        ;
        DateTime                 com_data       ;
        int                      com_nfiscal    ;
        double                   com_total      ;
        int                      com_nparcelas  ;
        string                   com_status     ;
        ModeloFornecedor         _fornecedor    ;
        ModeloTipoPagamento      _tipoPagamento ;


        public int                 ComCod       { get { return  com_cod           ; } set { com_cod        = value; } }
        public DateTime            ComData      { get { return  com_data          ; } set { com_data       = value; } }
        public int                 ComNfiscal   { get { return  com_nfiscal       ; } set { com_nfiscal    = value; } }
        public double              ComTotal     { get { return  com_total         ; } set { com_total      = value; } }
        public int                 ComNparcelas { get { return  com_nparcelas     ; } set { com_nparcelas  = value; } }
        public string              ComStatus    { get { return  com_status        ; } set { com_status     = value; } }
        public ModeloFornecedor    Fornecedor          { get { return  _fornecedor    ; } set { _fornecedor    = value; } }
        public ModeloTipoPagamento TipoPagamento       { get { return  _tipoPagamento ; } set { _tipoPagamento = value; } }
        
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
        }

    }
}
