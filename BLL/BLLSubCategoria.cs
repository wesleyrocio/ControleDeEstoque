using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;

namespace BLL
{
    public class BLLSubCategoria
    {
        private DALConexao conexao;
        public BLLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }
        public bool verificaExisteNome(ModeloSubCategoria modelo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
           
            var dt = DALobj.Localizar(modelo.ScatNome.Trim(), TipoPesquisa.exata);
            if (dt.Rows.Count > 0 && dt.Rows[0]["cat_cod"].ToString() != modelo.ScatCod.ToString())
                return true;
            return false;
        }
        public void Incluir(ModeloSubCategoria modelo)
        {
            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatório");
            }
            if (modelo.Categoria.CatCod <= 0) 
            {
                throw new Exception("O código é obrigatório");
            }
            if (verificaExisteNome(modelo))
            {
                throw new Exception("Sub Categoria Existente no Banco de Dados!");
            }

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloSubCategoria modelo)
        {
            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da sub categoria é obrigatório");
            }

            if (modelo.Categoria.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O código da sub categoria é obrigatório");
            }
            if (verificaExisteNome(modelo))
            {
                throw new Exception("Sub Categoria Existente no Banco de Dados!");
            }

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string valor)
        {

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable FiltrarPorCategoria(int categoria)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.FiltrarPorCategoria(categoria);
        }
        public ModeloSubCategoria CarregarModelo(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.CarregaModeloSubCategoria(codigo);
        }
    }
}
