using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloFornecedor
    {
        private int    for_cod      ;
        private string for_nome     ;
        private string for_rsocial	;
        private string for_ie		;
        private string for_cnpj	    ;
        private string for_cep		;
        private string for_endereco	;
        private string for_bairro	;
        private string for_fone		;
        private string for_cel		;
        private string for_email	;
        private string for_endnumero;
        private string for_cidade	;
        private string for_estado   ;


        public int    ForCod        { get {return  for_cod      ;} set {for_cod          = value; } }
        public string ForNome       { get { return for_nome     ; } set {for_nome        = value; } }
        public string ForRsocial    { get { return for_rsocial	; } set {for_rsocial	 = value; } }
        public string ForIe         { get { return for_ie		; } set {for_ie	    	 = value; } }
        public string ForCnpj       { get { return for_cnpj	    ; } set {for_cnpj	     = value; } }
        public string ForCep        { get { return for_cep		; } set {for_cep		 = value; } }
        public string ForEndereco   { get { return for_endereco	; } set {for_endereco    = value; } }
        public string ForBairro     { get { return for_bairro	; } set {for_bairro	     = value; } }
        public string ForFone       { get { return for_fone		; } set {for_fone		 = value; } }
        public string ForCel        { get { return for_cel		; } set {for_cel		 = value; } }
        public string ForEmail      { get { return for_email	; } set {for_email	     = value; } }
        public string ForEndNumero  { get { return for_endnumero; } set {for_endnumero   = value; } }
        public string ForCidade     { get { return for_cidade	; } set {for_cidade	     = value; } }
        public string ForEstado     { get { return for_estado   ; } set { for_estado     = value; } }

        public ModeloFornecedor()
        {
            ForCod          = 0;
            ForNome         = "";
            ForRsocial      = "";
            ForIe           = "";
            ForCnpj         = "";
            ForCep          = "";
            ForEndereco     = "";
            ForBairro       = "";
            ForFone         = "";
            ForCel          = "";
            ForEmail        = "";
            ForEndNumero    = "";
            ForCidade       = "";
            ForEstado       = "";
        }

        public ModeloFornecedor(int    _for_cod      ,
                                string _for_nome     ,
                                string _for_rsocial	 ,
                                string _for_ie		 ,
                                string _for_cnpj	 ,  
                                string _for_cep		 ,
                                string _for_endereco ,
                                string _for_bairro	 ,
                                string _for_fone	 ,
                                string _for_cel		 ,
                                string _for_email	 ,
                                string _for_endnumero,
                                string _for_cidade	 ,
                                string _for_estado      )
        {


            ForCod       =          _for_cod         ;
            ForNome      =          _for_nome        ;
            ForRsocial   =          _for_rsocial	 ;
            ForIe         =         _for_ie	          ;
            ForCnpj      =          _for_cnpj	     ;
            ForCep       =          _for_cep		 ;
            ForEndereco  =          _for_endereco    ;
            ForBairro    =          _for_bairro	     ;
            ForFone      =          _for_fone	     ;
            ForCel       =          _for_cel		 ;
            ForEmail     =          _for_email	     ;
            ForEndNumero =          _for_endnumero   ;
            ForCidade    =          _for_cidade	     ;
            ForEstado    =          _for_estado      ;


        }
    }
}
