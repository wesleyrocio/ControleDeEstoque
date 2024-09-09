using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public struct DadosDaConexaoStruct()
    {
        public string tipoAutenticacao = "";
        public string servidor = "";
        public string banco = "";
        public string usuario = "";
        public string senha = "";

        public string StringDeConexao
        {

            get
            {
               
                if (tipoAutenticacao == "Windows")
                {
                    return @"Data Source=" + servidor + "; Initial Catalog=" + banco + "; Integrated Security=True";
                }
                else
                {
                    return @"Data Source=" + servidor + "; Initial Catalog=" + banco + "; User ID=" + usuario + "; Password=" + senha;
                }

            }
        }
    }
}
