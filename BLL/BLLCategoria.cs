using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;

namespace BLL
{
    public class BLLCategoria 
    {
        private DALConexao conexao;
        public BLLCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCategoria modelo)
        {
            if (modelo.CatNome.Trim().Length == 0) 
            {
                throw new Exception("O nome da categoria é obrigatório");
            }

            DALCategoria DALobj = new DALCategoria(conexao);
            var dt=DALobj.Localizar(modelo.CatNome, TipoPesquisa.exata);
            if (verificaExisteNome(modelo)) 
            {
                throw new Exception("Categoria Existente no Banco de Dados!");
            }

            DALobj.Incluir(modelo);
        }

        public bool verificaExisteNome(ModeloCategoria modelo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
         
            var dt = DALobj.Localizar(modelo.CatNome.Trim(), TipoPesquisa.exata);
            if (dt.Rows.Count > 0 && dt.Rows[0]["cat_cod"].ToString()!=modelo.CatCod.ToString())
                return true;
            return false;
        }
        public void Alterar(ModeloCategoria modelo)
        {
            
            if (modelo.CatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da categoria é obrigatório");
            }

            if (modelo.CatCod <= 0)
            {
                throw new Exception("O código da categoria é obrigatório");
            }

            if (verificaExisteNome(modelo))
            {
                throw new Exception("Categoria Existente no Banco de Dados!");
            }

            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string valor)
        {
            
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.Localizar(valor);
        }
        public ModeloCategoria CarregarModelo(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.CarregarModelo(codigo);
        }

        public ModeloCategoria CarregarModeloCategoriaEsubCategorias(int codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.CarregarModeloCategoriaEsubCategorias(codigo);
        }

        public ColecaoCategoria preencherColecao()
        {
            DALColecaoCategoria DALobj = new DALColecaoCategoria(conexao);
            return DALobj.preencherColecao();
        }


    }
}
