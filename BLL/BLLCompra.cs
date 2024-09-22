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

            DALCompra DALmodelo = new DALCompra(conexao);
            DALmodelo.Incluir(modelo);
            DALItensCompra dalItensCompra = new DALItensCompra(conexao);
            dalItensCompra.UpSert(modelo.ListaItens);
            DALParcelasCompra dalParcelasCompra = new DALParcelasCompra(conexao);
            dalParcelasCompra.UpSert(modelo.Parcelas);


        }
        public void Alterar(ModeloCompra modelo)
        {
            if (modelo.ComCod <= 0)
            {
                throw new Exception("O código do Compra é obrigatório");
            }
            validacoesGerais(modelo);

            DALCompra DALobj = new DALCompra(conexao);
            DALobj.Alterar(modelo);
        }
        public bool verificaExisteNome(ModeloCompra modelo)
        {

            //DataTable dt = new DataTable();
            //DALCompra DALobj = new DALCompra(conexao);

            //dt = DALobj.Localizar(modelo.ForNome.Trim(), CompraPesquisarPor.nome, TipoPesquisa.exata);
            //if (dt.Rows.Count > 0 && dt.Rows[0]["for_cod"].ToString() != modelo.ForCod.ToString())
            //    return true;
            return false;
        }

        public bool verificaExisteRazaoSocial(ModeloCompra modelo)
        {

            //DataTable dt = new DataTable();
            //DALCompra DALobj = new DALCompra(conexao);

            //dt = DALobj.Localizar(modelo.ForRsocial.Trim(), CompraPesquisarPor.razaoSocial, TipoPesquisa.exata);
            //if (dt.Rows.Count > 0 && dt.Rows[0]["for_cod"].ToString() != modelo.ForCod.ToString())
            //    return true;
            return false;
        }
        public void Excluir(int codigo)
        {
            DALCompra DALobj = new DALCompra(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string[] valor, CompraPesquisarPor enumPesquisarPor = CompraPesquisarPor.nomeFornecedor)
        {
            DALCompra DALobj = new DALCompra(conexao);
            return DALobj.Localizar(valor, enumPesquisarPor);
        }

        public ModeloCompra CarregarModelo(int codigo)
        {
         
            DALCompra DALobj = new DALCompra(conexao);
            return DALobj.CarregaModelo(codigo);
        }

    }
}
