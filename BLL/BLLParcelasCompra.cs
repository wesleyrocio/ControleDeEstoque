using DAL;
using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLParcelasCompra
    {
        private DALConexao conexao;
        public BLLParcelasCompra(DALConexao cx)
        {
            this.conexao = cx;

        }
        private void validacoesGerais(ModeloParcelasCompra modelo)
        {

            if (modelo.PcoValor <= 0)
            {
                throw new Exception("é necessário informar um valor");
            }

            if ((!modelo.PcoDataVecto.HasValue) && (modelo.PcoDataVecto < DateTime.Now))
            {
                throw new Exception("Data de Vencimento nula ou inválida");
            }
            
            if (modelo.ComCod <= 0)
            {
                throw new Exception("É necessário uma compra vinculada ao item");
            }


        }
        public void Incluir(ModeloParcelasCompra modelo)
        {
            try
            {
                validacoesGerais(modelo);
                var dalParcelasCompra = new DALParcelasCompra(conexao);
                dalParcelasCompra.Incluir(modelo);
            }
            catch (Exception e)
            {

                throw new Exception("Fala ao Incluir Parcela \b Detalhes:"+e.Message);
            }
                    

        }
        public void Alterar(ModeloParcelasCompra modelo)
        {
            throw new NotImplementedException();
        }

        public void Incluir(ColecaoParcelasCompra colecao)
        {
            try
            {
                var dalParcelasCompra = new DALParcelasCompra(conexao);
                Excluir(colecao[0].ComCod);
                foreach (var modelo in colecao)
                {
                    validacoesGerais(modelo);
                    dalParcelasCompra.Incluir(modelo);
                }
            }
            catch (Exception e)
            {

                throw new Exception("Fala ao Incluir Parcela \b Detalhes:" + e.Message);
            }

        }

        public void Excluir(int codCompra)
        {
            try
            {
                var dalParcelasCompra = new DALParcelasCompra(conexao);
                dalParcelasCompra.Excluir(codCompra);
            }
            catch (Exception e)
            {

                throw new Exception("Fala ao Excluir Parcela \b Detalhes:" + e.Message);
            }
        }


        public DataTable Localizar(int valor, ParcelasCompraPesquisaPor enumPesquisarPor = ParcelasCompraPesquisaPor.compra, TipoPesquisa tipoPesquisa = TipoPesquisa.exata)
        {
            try
            {
                var DALobj = new DALParcelasCompra(conexao);
                return DALobj.Localizar(valor, enumPesquisarPor, tipoPesquisa);
            }
            catch (Exception e)
            {

                throw new Exception("Fala ao localizar parcela \b Detalhes:" + e.Message);
            }
           
        }
        public ColecaoParcelasCompra LocalizarListaItens(int codCompra)
        {
            try
            {
                var parcelasCompra = new DALParcelasCompra(conexao);
                var colecao = parcelasCompra.LocalizarListaItens(codCompra);
                return colecao;
            }
            catch (Exception e)
            {

                throw new Exception("Fala ao localizar parcela \b Detalhes:" + e.Message);
            }


            
        }

        public ModeloParcelasCompra CarregarModelo(int codigo)
        {
            var DALobj = new DALParcelasCompra(conexao);
            return DALobj.CarregaModelo(codigo);
        }
    }
}
