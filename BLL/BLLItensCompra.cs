using DAL;
using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLItensCompra
    {
        private DALConexao conexao;
        public BLLItensCompra(DALConexao cx)
        {
            this.conexao = cx;

        }
        private void validacoesGerais(ModeloItensCompra modelo)
        {

            if (modelo.Produto.ProCod <= 0)
            {
                throw new Exception("Fornecedor é obrigatório");
            }

            if (modelo.ItcQtde <= 0)
            {
                throw new Exception("É necessário ao menos uma unidade");
            }
            if (modelo.Compra.ComCod<=0)
            {
                throw new Exception("O Item precisa estar vinculádo a uma Compra (código da compra inválido)");
            }
            if (modelo.ItcValor <= 0)
            {
                throw new Exception("Valor do ítem inválido!");
            }
            

        }
        public void Incluir(ColecaoItensCompra colecao)
        {

            foreach (var modelo in colecao)
            {
                validacoesGerais(modelo);
            }
            
            var dalItensCompra = new DALItensCompra(conexao);
            dalItensCompra.UpSert(colecao);

        }
        public void Alterar(ColecaoItensCompra colecao)
        {
            foreach (var modelo in colecao)
            {
                if (modelo.ItcCod <= 0)
                {
                    throw new Exception("O código do item é nulo ou inválido");
                }
                validacoesGerais(modelo);
            }
            var dalItensCompra = new DALItensCompra(conexao);
            dalItensCompra.UpSert(colecao);
        }     
        
        public void UpSert(ColecaoItensCompra colecao)
        {
            var dalItensCompra = new DALItensCompra(conexao);
            foreach (var modelo in colecao)
            {
                if (modelo.ItcCod <= 0)
                {                              
                    validacoesGerais(modelo);
                    dalItensCompra.Incluir(modelo);
                }
                else
                {
                    validacoesGerais(modelo);
                    dalItensCompra.Alterar(modelo);
                }
            }
          

        }

        public void Excluir(ColecaoItensCompra colecao)
        {           
            var dalItensCompra = new DALItensCompra(conexao); 
            dalItensCompra.Excluir(colecao);
        }

        public void Excluir(int codigo)
        {
            var dalItensCompra = new DALItensCompra(conexao);
            dalItensCompra.Excluir(codigo);
        }


        public DataTable Localizar(string valor, ItensCompraPesquisaPor enumPesquisarPor = ItensCompraPesquisaPor.compra, TipoPesquisa tipoPesquisa = TipoPesquisa.exata)
        {
            var DALobj = new DALItensCompra(conexao);
            return DALobj.Localizar(valor, enumPesquisarPor, tipoPesquisa);
        }
        public  ColecaoItensCompra LocalizarListaItens(int codCompra)
        {
            var dalItensCompra = new DALItensCompra(conexao);
            var colecao = dalItensCompra.LocalizarListaItens(codCompra);
            return colecao;
        }

        public ModeloItensCompra CarregarModelo(int codigo)
        {
            var DALobj = new DALItensCompra(conexao);
            return DALobj.CarregaModelo(codigo);
        }
       

    }
}
