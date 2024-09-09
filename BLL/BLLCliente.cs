using DAL;
using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferramentas;

namespace BLL
{
    public class BLLCliente
    {
        private DALConexao conexao;
        public BLLCliente(DALConexao cx)
        {
            this.conexao = cx;

        }
        public void Incluir(ModeloCliente modelo)
        {

            if (modelo.CliNome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }
            if (modelo.CliCep.Trim().Length == 0)
            {
                throw new Exception("O nome CEP é obrigatório");
            }
            if (modelo.CliEndereco.Trim().Length == 0)
            {
                throw new Exception("O Endereço é obrigatório");
            }
            if (modelo.CliBairro.Trim().Length == 0)
            {
                throw new Exception("O Bairro é obrigatório");
            }
            if (modelo.CliCel.Trim().Length == 0)
            {
                throw new Exception("O Celular é obrigatório");
            }
            if (modelo.CliEmail.Trim().Length == 0)
            {
                throw new Exception("O Celular é obrigatório");
            }
            if (modelo.CliCidade.Trim().Length == 0)
            {
                throw new Exception("O campo Cidade é obrigatório");
            }
            if (modelo.CliEstado.Trim().Length == 0)
            {
                throw new Exception("O campo Estado é obrigatório");
            }

            if (verificaExisteNome(modelo)) 
            {
                throw new Exception("Cliente já existe no banco de dados!");
            }
            if (modelo.CliTipo.Trim() == "fisica" && !Validacao.IsCpf(modelo.CliCpfCnpj.Trim()))
            {
                throw new Exception("CPF Inválido ou inexistente");
            }
            if (modelo.CliTipo.Trim() == "juridica" && !Validacao.IsCnpj(modelo.CliCpfCnpj.Trim()))
            {
                throw new Exception("CPF Inválido ou inexistente");
            }



            DALCliente DALmodelo = new DALCliente(conexao);
            DALmodelo.Incluir(modelo);
        }
       
        public void Alterar(ModeloCliente modelo)
        {
            if (modelo.CliCod <= 0)
            {
                throw new Exception("O código do cliente é obrigatório");
            }
            if (modelo.CliNome.Trim().Length == 0)
            {
                throw new Exception("O nome do cliente é obrigatório");
            }
            if (modelo.CliCep.Trim().Length == 0)
            {
                throw new Exception("O nome CEP é obrigatório");
            }
            if (modelo.CliEndereco.Trim().Length == 0)
            {
                throw new Exception("O Endereço é obrigatório");
            }
            if (modelo.CliBairro.Trim().Length == 0)
            {
                throw new Exception("O Bairro é obrigatório");
            }
            if (modelo.CliCel.Trim().Length == 0)
            {
                throw new Exception("O Celular é obrigatório");
            }
            if (modelo.CliEmail.Trim().Length == 0)
            {
                throw new Exception("O Celular é obrigatório");
            }
            if (modelo.CliCidade.Trim().Length == 0)
            {
                throw new Exception("O campo Cidade é obrigatório");
            }
            if (modelo.CliEstado.Trim().Length == 0)
            {
                throw new Exception("O campo Estado é obrigatório");
            }
            if (verificaExisteNome(modelo))
            {
                throw new Exception("Cliente já existe no banco de dados!");
            }
            if (modelo.CliTipo == "fisica"&&Validacao.IsCpf(modelo.CliCpfCnpj)) { }


            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Alterar(modelo);
        }
        public bool verificaExisteNome(ModeloCliente modelo)
        {
           
            DataTable dt = new DataTable();
            DALCliente DALobj = new DALCliente(conexao);          

            dt = DALobj.Localizar(modelo.CliNome.Trim(), ClientePesquisarPor.nome, TipoPesquisa.exata);
            if (dt.Rows.Count > 0 && dt.Rows[0]["cli_cod"].ToString() != modelo.CliCod.ToString())
                return true;
            return false;
        }
        public void Excluir(int codigo)
        {
            DALCliente DALobj = new DALCliente(conexao);
            DALobj.Excluir(codigo);

        }
        public DataTable Localizar(string valor, ClientePesquisarPor enumPesquisarPor = ClientePesquisarPor.nome)
        {

            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.Localizar(valor, enumPesquisarPor);
        }
        public ModeloCliente CarregarModelo(int codigo)
        {
            DALCliente DALobj = new DALCliente(conexao);
            return DALobj.CarregaModelo(codigo);
        }


    }
}
