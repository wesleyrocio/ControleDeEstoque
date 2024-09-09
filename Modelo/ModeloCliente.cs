using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCliente : ModeloInterfaceEntidades
    {
        private int    cli_cod      ;  
        private string cli_nome     ;
        private string cli_cpfcnpj  ;
        private string cli_rgie     ;
        private string cli_rsocial  ;
        private string cli_tipo     ;
        private string cli_cep      ;
        private string cli_endereco ;
        private string cli_bairro   ;
        private string cli_fone     ;
        private string cli_cel      ;
        private string cli_email    ;
        private string cli_endnumero;
        private string cli_cidade   ;
        private string cli_estado   ;

        public int    CliCod          { get { return cli_cod     ; } set { cli_cod        = value; } }
        public string CliNome        { get { return cli_nome      ;} set { cli_nome       = value;} }
        public string CliCpfCnpj     { get { return cli_cpfcnpj   ;} set { cli_cpfcnpj    = value;} }
        public string CliRgIe        { get { return cli_rgie      ;} set {  cli_rgie      = value;} }
        public string CliRsocial     { get { return cli_rsocial   ;} set {  cli_rsocial   = value;} }
        public string CliTipo        { get { return cli_tipo      ;} set {  cli_tipo      = value;} }
        public string CliCep         { get { return cli_cep       ;} set {  cli_cep       = value;} }
        public string CliEndereco    { get { return cli_endereco  ;} set {  cli_endereco  = value;} }
        public string CliBairro      { get { return cli_bairro    ;} set {  cli_bairro    = value;} }
        public string CliFone        { get { return cli_fone      ;} set {  cli_fone      = value;} }
        public string CliCel         { get { return cli_cel       ;} set {  cli_cel       = value;} }
        public string CliEmail       { get { return cli_email     ;} set {  cli_email     = value;} }
        public string CliEndNumero   { get { return cli_endnumero ;} set {  cli_endnumero = value;} }
        public string CliCidade      { get { return cli_cidade    ;} set {  cli_cidade    = value;} }
        public string CliEstado      { get { return cli_estado    ;} set {  cli_estado    = value;} }

        public ModeloCliente() 
        {
            CliCod          = 0;
            CliNome         = "";
            CliCpfCnpj      = "";
            CliRgIe         = "";
            CliRsocial      = "";
            CliTipo         = "";
            CliCep          = "";
            CliEndereco     = "";
            CliBairro       = "";
            CliFone         = "";
            CliCel          = "";
            CliEmail        = "";
            CliEndNumero    = "";
            CliCidade       = "";
            CliEstado       = "";
        }

        public ModeloCliente(int    _cli_cod      = 0   ,
                             string _cli_nome     = ""  ,
                             string _cli_cpfcnpj  = ""  ,  
                             string _cli_rgie     = ""  ,    
                             string _cli_rsocial  = ""  , 
                             string _cli_tipo     = ""  ,    
                             string _cli_cep      = ""  ,    
                             string _cli_endereco = ""  ,
                             string _cli_bairro   = ""  ,  
                             string _cli_fone     = ""  ,
                             string _cli_cel      = ""  ,
                             string _cli_email    = ""  ,
                             string _cli_endnumero= ""  ,
                             string _cli_cidade   = ""  ,
                             string _cli_estado   = ""  )
        {
            CliCod   =      _cli_cod;
            CliNome =       _cli_nome       ;
            CliCpfCnpj =    _cli_cpfcnpj    ;
            CliRgIe =       _cli_rgie       ;
            CliRsocial =    _cli_rsocial    ;
            CliTipo =       _cli_tipo       ;
            CliCep =        _cli_cep        ;
            CliEndereco =   _cli_endereco   ;
            CliBairro =     _cli_bairro     ;
            CliFone =       _cli_fone       ;
            CliCel =        _cli_cel        ;
            CliEmail =      _cli_email      ;
            CliEndNumero =  _cli_endnumero  ;
            CliCidade =     _cli_cidade     ;
            CliEstado =     _cli_estado;

        }    
            
            
            
            
            
            























    }
}
