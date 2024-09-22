using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;
using System.Reflection;

namespace DAL
{
    public class DALCliente
    {


        private string[] pesquisarPor = populaPesquisarPor();
        private DALConexao conexao;
        public DALCliente(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModeloCliente modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into cliente(" +
                " cli_nome		, " +
                " cli_cpfcnpj	, " +
                " cli_rgie		, " +
                " cli_rsocial	, " +
                " cli_tipo		, " +
                " cli_cep		, " +
                " cli_endereco	, " +
                " cli_bairro	, " +
                " cli_fone		, " +
                " cli_cel		, " +
                " cli_email		, " +
                " cli_endnumero	, " +
                " cli_cidade	, " +
                " cli_estado      " +
                ") values (" +
                 "@CliNome      , " +
                 "@CliCpfCnpj   , " +
                 "@CliRgIe      , " +
                 "@CliRsocial   , " +
                 "@CliTipo      , " +
                 "@CliCep       , " +
                 "@CliEndereco  , " +
                 "@CliBairro    , " +
                 "@CliFone      , " +
                 "@CliCel       , " +
                 "@CliEmail     , " +
                 "@CliEndNumero , " +
                 "@CliCidade    ," +
                 "@CliEstado      " +
                 "); select @@IDENTITY;";

            DALUtil.AdicionaParametros(modelo, cmd);
            conexao.Conectar();
            modelo.CliCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }
        public void Alterar(ModeloCliente modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update cliente    set " +
                "cli_nome		=@CliNome          ," +
                "cli_cpfcnpj	=@CliCpfCnpj       ," +
                "cli_rgie		=@CliRgIe          ," +
                "cli_rsocial	=@CliRsocial       ," +
                "cli_tipo		=@CliTipo          ," +
                "cli_cep		=@CliCep           ," +
                "cli_endereco   =@CliEndereco      ," +
                "cli_bairro	    =@CliBairro        ," +
                "cli_fone	    =@CliFone          ," +
                "cli_cel		=@CliCel           ," +
                "cli_email	    =@CliEmail          ," +
                "cli_endnumero  =@CliEndNumero      ," +
                "cli_cidade	    =@CliCidade        ," +
                "cli_estado     =@CliEstado          " +
                "where cli_cod = @CliCod           ;";

            DALUtil.AdicionaParametros(modelo, cmd);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from cliente where cli_cod=@codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(string valor, ClientePesquisarPor enumPesquisarPor = ClientePesquisarPor.nome, TipoPesquisa tipoPesquisa = TipoPesquisa.aproximada)
        {     
            if (tipoPesquisa == TipoPesquisa.aproximada) { valor = "%" + valor + "%"; }
            if (valor == "") { valor = "%%%"; }
            if (enumPesquisarPor == ClientePesquisarPor.codigo) { tipoPesquisa = TipoPesquisa.exata; }

            string sql = "select *   from cliente where " +
            pesquisarPor[(int)enumPesquisarPor] + DALConstantes.operador[(int)tipoPesquisa] + " @Valor";

            return DALUtil.BuscaResultadoDataTable([valor], sql, conexao);
        }
        private static string[] populaPesquisarPor()
        {
            string[] pesquisarPor = new string[(Enum.GetNames(typeof(ClientePesquisarPor)).Length)];
            pesquisarPor[(int)ClientePesquisarPor.codigo]  = "cli_cod";
            pesquisarPor[(int)ClientePesquisarPor.nome]    = "cli_nome ";
            pesquisarPor[(int)ClientePesquisarPor.cpfcnpj] = "cli_cpfcnpj ";
            pesquisarPor[(int)ClientePesquisarPor.email]   = "cli_email ";
            pesquisarPor[(int)ClientePesquisarPor.cidade]  = "cli_cidade ";
            pesquisarPor[(int)ClientePesquisarPor.estado]  = "cli_email ";
            return pesquisarPor;
        }
        private static void preencheModelocomDataReader(ModeloCliente modelo, SqlDataReader reg)
        {
            modelo.CliCod             = Convert.ToInt32 (reg["cli_cod"]);
            modelo.CliNome            = Convert.ToString(reg["cli_nome"]);
            modelo.CliCpfCnpj         = Convert.ToString(reg["cli_cpfcnpj"]);
            modelo.CliRgIe            = Convert.ToString(reg["cli_rgie"]);
            modelo.CliRsocial         = Convert.ToString(reg["cli_rsocial"]);
            modelo.CliTipo            = Convert.ToString(reg["cli_tipo"]);
            modelo.CliCep             = Convert.ToString(reg["cli_cep"]);
            modelo.CliEndereco        = Convert.ToString(reg["cli_endereco"]);
            modelo.CliBairro          = Convert.ToString(reg["cli_bairro"]);
            modelo.CliFone            = Convert.ToString(reg["cli_fone"]);
            modelo.CliCel             = Convert.ToString(reg["cli_cel"]);
            modelo.CliEmail           = Convert.ToString(reg["cli_email"]);
            modelo.CliEndNumero       = Convert.ToString(reg["cli_endnumero"]);
            modelo.CliCidade          = Convert.ToString(reg["cli_cidade"]);
            modelo.CliEstado          = Convert.ToString(reg["cli_estado"]);
        }
        public ModeloCliente CarregaModelo(int codigo)
        {

            string sql = "select  * from cliente where cli_cod=@Valor";
            ModeloCliente modelo = new ModeloCliente();
            SqlDataReader reg = DALUtil.buscaResultadoDataReader(codigo, sql, conexao);

            if (!reg.HasRows) { return modelo; }
            reg.Read();
            preencheModelocomDataReader(modelo, reg);

            conexao.Desconectar();
            return modelo;

        }

    }
}
