using DAL;
using EnumsCompartilhados;
using Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLCompra
    {
        private DALConexao conexao;
        public BLLCompra(DALConexao cx)
        {
            this.conexao = cx;

        }
        private void validacoesGerais(ModeloCompra modelo)
        {


            if (modelo.Fornecedor.ForCod == 0)
            {
                throw new Exception("Fornecedor é obrigatório");
            }

            if (modelo.TipoPagamento.TpaCod==0)
            {
                throw new Exception("Tipo de Pagamento é obrigatório");
            }
            if (modelo.ComData==DateTime.MinValue)
            {
                throw new Exception("Data da compra é obrigatório");
            }
            if (modelo.ComNfiscal == 0)
            {
                throw new Exception("Nota fiscal é obrigatório");
            }
            if (modelo.ComNparcelas == 0)
            {
                throw new Exception("Número de parcelas é obrigatório");
            }

            if (modelo.ComTotal <= 0)
            {
                throw new Exception("Valor Total é obrigatório");
            }

        }
        public void Incluir(ModeloCompra modelo)
        {
            validacoesGerais(modelo);
            var DALobj = new DALCompra(conexao);
            var bllItensCompra = new BLLItensCompra(conexao);
            var bllParcelasCompra = new BLLParcelasCompra(conexao);
            
            DALobj.Incluir(modelo);
            
            bllItensCompra.UpSert(modelo.ListaItens);
        
            bllParcelasCompra.Incluir(modelo.Parcelas);


        }
        public void Alterar(ModeloCompra modelo)
        {
            if (modelo.ComCod <= 0)
            {
                throw new Exception("O código do Compra é obrigatório");
            }
            validacoesGerais(modelo);

            var DALobj = new DALCompra(conexao);
            var ItensCompra = new BLLItensCompra(conexao);
            var ParcelasCompra = new BLLParcelasCompra(conexao);
          
            DALobj.Alterar(modelo);
           
            ItensCompra.UpSert(modelo.ListaItens);
            ItensCompra.Excluir(modelo.ListaItensDelete);
            
          //  ParcelasCompra.Excluir(modelo.ComCod);
            ParcelasCompra.Incluir(modelo.Parcelas);
        }
       
        public void Excluir(ModeloCompra modelo)
        {
            var DALCompra = new DALCompra(conexao);
            var ItensCompra = new BLLItensCompra(conexao);
            var ParcelasCompra = new BLLParcelasCompra(conexao);


            ParcelasCompra.Excluir(modelo.ComCod);
            ItensCompra.Excluir(modelo.ListaItens);
            DALCompra.Excluir(modelo.ComCod);

        }
        public DataTable Localizar(string[] valor, CompraPesquisarPor enumPesquisarPor = CompraPesquisarPor.nomeFornecedor, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {
            DALCompra DALobj = new DALCompra(conexao);
            return DALobj.Localizar(valor, enumPesquisarPor, tipoPesquisa);
        }

        public ModeloCompra CarregarModelo(int codigo)
        {
         
            DALCompra DALobj = new DALCompra(conexao);
            return DALobj.CarregaModelo(codigo);
        }

    }
}
