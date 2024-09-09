using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexao
    {
           public static string tipoAutenticacao  = "Windows";
           public static string servidor            = @"PCWESLEY\SQLEXPRESS";
           public static string banco               = "ControleDeEstoque";
           public static string usuario             = "";
           public static string senha               = "";
           public static string StringDeConexao {        

               get
               {
                   // return @"Data Source=PCWESLEY\SQLEXPRESS;Initial Catalog=ControleDeEstoque;Integrated Security=True;TrustServerCertificate=True";
                   // return @"Data Source=PCWESLEY\SQLEXPRESS;Initial Catalog=ControleDeEstoque; Password=senha1234";
                   if (tipoAutenticacao == "Windows")
                   {
                       return @"Data Source="+servidor+"; Initial Catalog="+banco+"; Integrated Security=True";
                   }
                   else
                   {
                       return @"Data Source="+servidor+"; Initial Catalog="+banco+"; User ID="+usuario+"; Password="+senha;
                   }

               } 
           }

           public static void LerArquivoConexao() 
           {
               var arquivo = new StreamReader("ConfiguracaoBanco.txt");
               tipoAutenticacao = arquivo.ReadLine();
               servidor = arquivo.ReadLine();
               banco = arquivo.ReadLine();
               if (tipoAutenticacao.Trim() != "Windows")
               {
                   usuario = arquivo.ReadLine();
                   senha = arquivo.ReadLine();
               }
               else
               {
                  usuario = "";
                  senha = "";
               }
               arquivo.Close();
           }
         
      
    }
}
