using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferramentas
{
    public class BuscaEndereco
    {
        static public String cep = "";
        static public String cidade = "";
        static public String estado = "";
        static public String endereco = "";
        static public String bairro = "";

        public static Boolean verificaCEP(String CEP)
        {
            bool flag = false;
            try
            { 
               // DataTable dataTable = new DataTable();
                DataSet ds = new DataSet();
                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", CEP);
                ds.ReadXml(xml);
                //dataTable.ReadXml(xml);
                //endereco = dataTable.Rows[0]["logradouro"].ToString();
                //bairro = dataTable.Rows[0]["bairro"].ToString();
                //cidade = dataTable.Rows[0]["cidade"].ToString();
                //estado = dataTable.Rows[0]["uf"].ToString();



                endereco = ds.Tables[0].Rows[0]["logradouro"].ToString();
                bairro = ds.Tables[0].Rows[0]["bairro"].ToString();
                cidade = ds.Tables[0].Rows[0]["cidade"].ToString();
                estado = ds.Tables[0].Rows[0]["uf"].ToString();
                cep = CEP;
                flag = true;
            }
            catch (Exception ex)
            {
                endereco = "";
                bairro = "";
                cidade = "";
                estado = "";
                cep = "";
            }
            return flag;
        }
    }
}
