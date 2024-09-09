using DAL;
using EnumsCompartilhados;
using Ferramentas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLFornecedor
    {
        private DALConexao conexao;
        public BLLFornecedor(DALConexao cx)
        {
            this.conexao = cx;

        }
        private void validacoesGerais(ModeloFornecedor modelo)
        {           

            if (modelo.ForNome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }

            if (modelo.ForRsocial.Trim().Length == 0)
            {
                throw new Exception("Razão Social é obrigatório");
            }

            if (modelo.ForCep.Trim().Length == 0)
            {
                throw new Exception("O nome CEP é obrigatório");
            }
            if (modelo.ForEndereco.Trim().Length == 0)
            {
                throw new Exception("O Endereço é obrigatório");
            }
            if (modelo.ForBairro.Trim().Length == 0)
            {
                throw new Exception("O Bairro é obrigatório");
            }
            if (modelo.ForCel.Trim().Length == 0)
            {
                throw new Exception("O Celular é obrigatório");
            }
            if (modelo.ForEmail.Trim().Length == 0)
            {
                throw new Exception("O Celular é obrigatório");
            }
            if (modelo.ForCidade.Trim().Length == 0)
            {
                throw new Exception("O campo Cidade é obrigatório");
            }
            if (modelo.ForEstado.Trim().Length == 0)
            {
                throw new Exception("O campo Estado é obrigatório");
            }
            if (modelo.ForCnpj.Trim().Length == 0)
            {
                throw new Exception("O campo CNPJ é obrigatório");
            }

            if (!Validacao.IsCnpj(modelo.ForCnpj))
            {
                throw new Exception("CNPJ é inválido");
            }

            if (modelo.ForIe.Trim().Length == 0)
            {
                throw new Exception("O campo Inscrição Estadual é obrigatório");
            }

            if (verificaExisteNome(modelo))
            {
                throw new Exception("Nome Fantasia já existe no banco de dados!");
            }

            if (verificaExisteRazaoSocial(modelo))
            {
                throw new Exception("Razão Social já existe no banco de dados!");
            }
        }
        public void Incluir(ModeloFornecedor modelo)
        {
            validacoesGerais(modelo);

            DALFornecedor DALmodelo = new DALFornecedor(conexao);
            DALmodelo.Incluir(modelo);
        }

       

        public void Alterar(ModeloFornecedor modelo)
        {
            if (modelo.ForCod <= 0)
            {
                throw new Exception("O código do Fornecedor é obrigatório");
            }
            validacoesGerais(modelo);

            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Alterar(modelo);
        }
        public bool verificaExisteNome(ModeloFornecedor modelo)
        {

            DataTable dt = new DataTable();
            DALFornecedor DALobj = new DALFornecedor(conexao);

            dt = DALobj.Localizar(modelo.ForNome.Trim(), FornecedorPesquisarPor.nome, TipoPesquisa.exata);
            if (dt.Rows.Count > 0 && dt.Rows[0]["for_cod"].ToString() != modelo.ForCod.ToString())
                return true;
            return false;
        }

        public bool verificaExisteRazaoSocial(ModeloFornecedor modelo)
        {

            DataTable dt = new DataTable();
            DALFornecedor DALobj = new DALFornecedor(conexao);

            dt = DALobj.Localizar(modelo.ForRsocial.Trim(), FornecedorPesquisarPor.razaoSocial, TipoPesquisa.exata);
            if (dt.Rows.Count > 0 && dt.Rows[0]["for_cod"].ToString() != modelo.ForCod.ToString())
                return true;
            return false;
        }
        public void Excluir(int codigo)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string valor, FornecedorPesquisarPor enumPesquisarPor = FornecedorPesquisarPor.nome)
        {

            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.Localizar(valor, enumPesquisarPor);
        }
        public ModeloFornecedor CarregarModelo(int codigo)
        {
            DALFornecedor DALobj = new DALFornecedor(conexao);
            return DALobj.CarregaModelo(codigo);
        }

    }
}
