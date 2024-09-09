using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumsCompartilhados;


namespace BLL
{
    public class BLLUndMedida
    {
        private DALConexao conexao;      
        public BLLUndMedida(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloUndMedida modelo)
        {
            if (modelo.UmedNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Unidade de Medida é obrigatório");
            }

            if (verificaExisteNome(modelo))
            {
                throw new Exception("Categoria Existente no Banco de Dados!");
            }
            DALUndMedida DALobj = new DALUndMedida(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloUndMedida modelo)
        {
            if (modelo.UmedNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Unidade de Medida é obrigatório");
            }

            if (modelo.UmedCod <= 0)
            {
                throw new Exception("O código da Unidade de Medida é obrigatório");
            }
            if (verificaExisteNome(modelo))
            {
                throw new Exception("Categoria Existente no Banco de Dados!");
            }

            DALUndMedida DALobj = new DALUndMedida(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            DALUndMedida DALobj = new DALUndMedida(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string valor, TipoPesquisa tipoPesquisa=TipoPesquisa.aproximada)
        {

            DALUndMedida DALobj = new DALUndMedida(conexao);
            return DALobj.Localizar(valor);
        }

        public ModeloUndMedida LocalizaUndMedida(string valor)
        {
            ModeloUndMedida modelo = new ModeloUndMedida();
            DALUndMedida DALobj = new DALUndMedida(conexao);

            modelo=DALobj.LocalizaUndMedida(valor);

            return modelo;
        }
        public ModeloUndMedida CarregarModelo(int codigo)
        {
            DALUndMedida DALobj = new DALUndMedida(conexao);
            return DALobj.CarregaModeloUndMedida(codigo);
        }

        public void Desconectar()
        {
            conexao.Desconectar();
        }
        public bool verificaExisteNome(ModeloUndMedida modelo)
        {
            DALUndMedida DALobj = new DALUndMedida(conexao);
           
            var dt = DALobj.Localizar(modelo.UmedNome.Trim(), TipoPesquisa.exata);
            if (dt.Rows.Count > 0 && dt.Rows[0]["umed_cod"].ToString() != modelo.UmedCod.ToString())
                return true;
            return false;
        }
    }
}
