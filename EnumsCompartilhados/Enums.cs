using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumsCompartilhados
{
    public enum TipoPesquisa { exata, aproximada }
    public enum ProdutoPesquisarPor
    {
        codigo = 0,
        nome = 1,
        categoria = 2,
        subcategoria = 3

    }

    public enum ClientePesquisarPor
    {
        codigo  = 0 ,
        nome    = 1 ,
        cpfcnpj = 2 ,      
        email   = 3 ,
        cidade  = 4 ,
        estado  = 5 ,
        cidadeEstado=6

    }
    public enum FornecedorPesquisarPor
    {
        codigo       , 
        nome         ,
        cnpj         , 
        razaoSocial  , 
        email
    }

    public enum CompraPesquisarPor
    {
        codigo           ,
        data             ,
        notaFiscal       ,
        numeroParcelas   ,
        status           ,
        codFornecedor    ,
        nomeFornecedo    ,
        codTipoPagamento ,
        nomeTipoPagamento


    }
    public enum Operacao { inserir, alterar, localizar, excluir, cancelar }
    public enum FormEstado { branco, edicao, posconsulta }
    public enum PessoaTipo { fisica, juridica}

    
}
