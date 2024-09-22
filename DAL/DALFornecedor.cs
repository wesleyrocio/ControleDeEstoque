using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALFornecedor
    {

        private string[] pesquisarPor = populaPesquisarPor();
        private DALConexao conexao;
        public DALFornecedor(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloFornecedor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into fornecedor(" +                
                " for_nome      , " +
                " for_rsocial	, " +
                " for_ie		, " +
                " for_cnpj	    , " +
                " for_cep		, " +
                " for_endereco	, " +
                " for_bairro	, " +
                " for_fone		, " +
                " for_cel		, " +
                " for_email	    , " +
                " for_endnumero , " +
                " for_cidade	, " +
                " for_estado     " +
                ") values (" +
                 "@ForNome     , " +
                 "@ForRsocial  , " +
                 "@ForIe       , " +
                 "@ForCnpj     , " +
                 "@ForCep      , " +
                 "@ForEndereco , " +
                 "@ForBairro   , " +
                 "@ForFone     , " +
                 "@ForCel      , " +
                 "@ForEmail    , " +
                 "@ForEndNumero, " +
                 "@ForCidade   , " +
                 "@ForEstado   " +                
                 "); select @@IDENTITY;";

            DALUtil.AdicionaParametros(modelo, cmd);
            conexao.Conectar();
            modelo.ForCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloFornecedor modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update fornecedor    set " +
                "for_nome       =@ForNome         ," +
                "for_rsocial	=@ForRsocial      ," +
                "for_ie		    =@ForIe           ," +
                "for_cnpj	    =@ForCnpj         ," +
                "for_cep		=@ForCep          ," +
                "for_endereco	=@ForEndereco     ," +
                "for_bairro	    =@ForBairro       ," +
                "for_fone		=@ForFone         ," +
                "for_cel		=@ForCel          ," +
                "for_email	    =@ForEmail        ," +
                "for_endnumero  =@ForEndNumero    ," +
                "for_cidade	    =@ForCidade       ," +
                "for_estado	    =@ForEstado       ," +
                "where for_cod  =@ForCod          ;";

            DALUtil.AdicionaParametros(modelo, cmd);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from fornecedor where for_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor, FornecedorPesquisarPor enumPesquisarPor = FornecedorPesquisarPor.nome, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {
            if (tipoPesquisa == TipoPesquisa.aproximada) { valor = "%" + valor + "%"; }
            if (valor == "") { valor = "%%%"; }
            if (enumPesquisarPor == FornecedorPesquisarPor.codigo) { tipoPesquisa = TipoPesquisa.exata; }

            string sql = "select   " +
                "" +
                "for_cod        ," +
                "for_nome       ," +
                "for_rsocial	," +
                "for_ie		    ," +
                "for_cnpj	    ," +
                "for_cep		," +
                "for_endereco	," +
                "for_bairro	    ," +
                "for_fone		," +
                "for_cel		," +
                "for_email	    ," +
                "for_endnumero  ," +
                "for_cidade	    ," +
                "for_estado	     " +
                "from fornecedor where " +
            pesquisarPor[(int)enumPesquisarPor] + DALConstantes.operador[(int)tipoPesquisa] + " @Valor";


            return DALUtil.BuscaResultadoDataTable([valor], sql, conexao);
        }
        private static string[] populaPesquisarPor()
        {
            string[] pesquisarPor = new string[(Enum.GetNames(typeof(FornecedorPesquisarPor)).Length)];
            pesquisarPor[(int)FornecedorPesquisarPor.codigo]        = "for_cod";
            pesquisarPor[(int)FornecedorPesquisarPor.nome]          = "for_nome";
            pesquisarPor[(int)FornecedorPesquisarPor.cnpj]          = "for_cnpj";
            pesquisarPor[(int)FornecedorPesquisarPor.razaoSocial]   = "for_rsocial";
            pesquisarPor[(int)FornecedorPesquisarPor.email]         = "for_email";

            return pesquisarPor;
        }
        public static void preencheModelocomDataReader(ModeloFornecedor modelo, SqlDataReader reg)
        {
            modelo.ForCod           = Convert.ToInt32 (reg["for_cod"]);
            modelo.ForNome          = Convert.ToString(reg["for_nome"]);
            modelo.ForRsocial       = Convert.ToString(reg["for_rsocial"]);
            modelo.ForIe            = Convert.ToString(reg["for_ie"]);
            modelo.ForCnpj          = Convert.ToString(reg["for_cnpj"]);
            modelo.ForCep           = Convert.ToString(reg["for_cep"]);
            modelo.ForEndereco      = Convert.ToString(reg["for_endereco"]);
            modelo.ForBairro        = Convert.ToString(reg["for_bairro"]);
            modelo.ForFone          = Convert.ToString(reg["for_fone"]);
            modelo.ForCel           = Convert.ToString(reg["for_cel"]);
            modelo.ForEmail         = Convert.ToString(reg["for_email"]);
            modelo.ForEndNumero     = Convert.ToString(reg["for_endnumero"]);
            modelo.ForCidade        = Convert.ToString(reg["for_cidade"]);
            modelo.ForEstado        = Convert.ToString(reg["for_estado"]);
          
        }
        public ModeloFornecedor CarregaModelo(int codigo)
        {

            string sql = "select  * from fornecedor where for_cod=@Valor";
            ModeloFornecedor modelo = new ModeloFornecedor();
            SqlDataReader reg = DALUtil.buscaResultadoDataReader(codigo, sql, conexao);

            if (!reg.HasRows) { return modelo; }
            reg.Read();
            preencheModelocomDataReader(modelo, reg);

            conexao.Desconectar();
            return modelo;

        }

    }
}
