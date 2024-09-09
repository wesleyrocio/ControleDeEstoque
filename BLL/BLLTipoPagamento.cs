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
    public class BLLTipoPagamento
    {
        private DALConexao conexao;

        public BLLTipoPagamento(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloTipoPagamento modelo)
        {
            if (modelo.TpaNome.Trim().Length == 0)
            {
                throw new Exception("O nome do Tipo de Pagamento é obrigatório");
            }
            if (verificaExisteNome(modelo))
            {
                throw new Exception("Tipo de Pagamento Existente no Banco de Dados!");
            }
            var DALobj = new DALTipoPagamento(conexao);
            DALobj.Incluir(modelo);
        }
        public void Alterar(ModeloTipoPagamento modelo)
        {
            if (modelo.TpaNome.Trim().Length == 0)
            {
                throw new Exception("O nome da Tipo de Pagamento é obrigatório");
            }

            if (modelo.TpaCod <= 0)
            {
                throw new Exception("O código do Tipo de Pagamento é obrigatório");
            }

            if (verificaExisteNome(modelo))
            {
                throw new Exception("Tipo de Pagamento Existente no Banco de Dados!");
            }

            var DALobj = new DALTipoPagamento(conexao);
            DALobj.Alterar(modelo);
        }
        public void Excluir(int codigo)
        {
            var DALobj = new DALTipoPagamento(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string valor, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {

            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            return DALobj.Localizar(valor);
        }

        public ModeloTipoPagamento LocalizaTipoPagamento(string valor)
        {
            ModeloTipoPagamento modelo = new ModeloTipoPagamento();
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);

            modelo = DALobj.LocalizaTipoPagamento(valor);

            return modelo;
        }
        public ModeloTipoPagamento CarregarModelo(int codigo)
        {
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
            return DALobj.CarregaModeloTipoPagamento(codigo);
        }
        public bool verificaExisteNome(ModeloTipoPagamento modelo)
        {
            DALTipoPagamento DALobj = new DALTipoPagamento(conexao);
           
            var dt = DALobj.Localizar(modelo.TpaNome.Trim(), TipoPesquisa.exata);
            if (dt.Rows.Count > 0 && dt.Rows[0]["tpa_cod"].ToString() != modelo.TpaCod.ToString())
                return true;
            return false;
        }
        public void Desconectar()
        {
            conexao.Desconectar();
        }
    }
}
