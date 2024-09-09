using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;

namespace BLL
{
 
    public class BLLProduto
    {
        private DALConexao conexao;
        public BLLProduto(DALConexao cx)
        {
            this.conexao = cx;
            
        }
        public void Incluir(ModeloProduto modelo)
        {
           
            if (modelo.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }

            if (modelo.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição do produto é obrigatória");
            }

            if (modelo.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do produto é obrigatório");
            }

            if (modelo.ProQtde < 0)
            {
                throw new Exception("A quantidade do produto deve ser maior ou igual a zero");
            }

            if (modelo.SubCategoria.ScatCod <= 0)
            {
                throw new Exception("O código da subcategoria é obrigatório");
            }

            if (modelo.Categoria.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            if (modelo.UnidadeDeMedida.UmedCod <= 0)
            {
                throw new Exception("O código da unidade de medida é obrigatório");
            }
            if (verificaExisteNome(modelo))
            {
                throw new Exception("Produto existente no Banco de Dados!");
            }
            DALProduto DALmodelo = new DALProduto(conexao);
            DALmodelo.Incluir(modelo);
        }
        public void Alterar(ModeloProduto modelo)
        {
            if (modelo.ProCod <= 0)     
            {
                throw new Exception("O código do produto é obrigatório");
            }
            if (modelo.ProNome.Trim().Length == 0)
            {
                throw new Exception("O nome do produto é obrigatório");
            }

            if (modelo.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("A descrição do produto é obrigatória");
            }

            if (modelo.ProValorVenda <= 0)
            {
                throw new Exception("O valor de venda do produto é obrigatório");
            }

            if (modelo.ProQtde < 0)
            {
                throw new Exception("A quantidade do produto deve ser maior ou igual a zero");
            }

            if (modelo.SubCategoria.ScatCod <= 0)
            {
                throw new Exception("O código da subcategoria é obrigatório");
            }

            if (modelo.Categoria.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            if (modelo.UnidadeDeMedida.UmedCod <= 0)
            {
                throw new Exception("O código da unidade de medida é obrigatório");
            }
            if (verificaExisteNome(modelo))
            {
                throw new Exception("Produto existente no Banco de Dados!");
            }

            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Alterar(modelo);
        }
        public bool verificaExisteNome(ModeloProduto modelo)
        {
            DataTable dt = new DataTable();
            DALProduto DALobj = new DALProduto(conexao);
           
            dt = DALobj.Localizar(modelo.ProNome.Trim(), ProdutoPesquisarPor.nome, TipoPesquisa.exata);
            if (dt.Rows.Count > 0 && dt.Rows[0]["pro_cod"].ToString() != modelo.ProCod.ToString())
                return true;
            return false;
        }
    

        public void Excluir(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string valor, ProdutoPesquisarPor enumPesquisarPor = ProdutoPesquisarPor.nome)
        {

            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.Localizar(valor, enumPesquisarPor);
        }
        public ModeloProduto CarregarModelo(int codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.CarregaModeloProduto(codigo);
        }
    }
}
