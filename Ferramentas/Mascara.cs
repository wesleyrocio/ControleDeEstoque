using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ferramentas
{
    public class Mascara
    {
        public static string CPF(string cpf, string mascara= "###.###.###-##", string curinga = "#")
        {
          
           // string textoFormatado = Regex.Replace(cpf, @"(\d{3})(\d{3})(\d{3})(\d{2})?", "$1.$2.$3-$4");
            return addMascaraNumeros(cpf, mascara, curinga);
        }
        public static string CNPJ(string cnpj, string mascara = "##.###.###/####-##", string curinga = "#")
        {
            //string textoFormatado = $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
            return addMascaraNumeros(cnpj, mascara, curinga);
        }

        public static string Telefone(string tel, string mascara="(##) ####-####", string curinga="#")
        {
            return addMascaraNumeros(tel, mascara, curinga);
        }
        
        public static string Celular(string tel, string mascara = "(##) #####-####", string curinga = "#") 
        {
            return addMascaraNumeros(tel, mascara, curinga);
        }
        
        public static string CEP(string cep, string mascara = "#####-###", string curinga = "#")
        {
            return addMascaraNumeros(cep, mascara, curinga);
        }

        public static string Monetario(string cep, string mascara = "#.###.###,##", string curinga = "#")
        {
            return addMascaraNumeros(cep, mascara, curinga);
        }
        public static string addMascaraNumeros(string valor, string mascara, string curinga="#")
        {
            if (string.IsNullOrEmpty(valor) || string.IsNullOrEmpty(mascara))
            {
                return "";
            }


            if (valor.Length > mascara.Length)
            {
                return valor.Substring(0, mascara.Length);
            }
            int cont = 0;
            valor = valor.Trim().ApenasNumeros();


            while (cont <= valor.Length - 1)
            {
                if (mascara[cont] != '#')
                    valor = valor.Insert(cont, mascara[cont].ToString());
                cont++;
            }


          
            return valor;         
        }
        // string textoFormatado = Regex.Replace(valor, @"(\d{3})(\d{3})(\d{3})(\d{2})?", "$1.$2/$3-$4");    

    }
    public static class StringExtensions
    {
        public static string ApenasNumeros(this string valor)
        {
          
            //return Regex.Replace(valor, @"[^0-9]", "");
            string stringNumero = new string(valor.Where(char.IsDigit).ToArray());
            if (stringNumero.Length <= 0) { stringNumero = "";}
            
            return stringNumero;
        }
        public static string ApenasLetrasNumeros(this string valor)
        {
            //return Regex.Replace(valor, @"[^a-zA-Z0-9]", "");
            return new string(valor.Where(c => char.IsLetterOrDigit(c) && !char.IsPunctuation(c)).ToArray()).Trim();
        }
        public static string ApenasLetras(this string valor)
        {
            //return Regex.Replace(valor, @"[^a-zA-Z]", "");
            return new string(valor.Where(c => char.IsLetter(c) && !char.IsPunctuation(c)).ToArray()).Trim();
        }
        public static string RetiraMoeda(this string txt)
        {
            string texto;

            if (txt.Trim().Length <= 0) { txt = "0"; }
            txt = txt.Replace("R$", "").Trim();
          
            return txt;

        }

    }
}
