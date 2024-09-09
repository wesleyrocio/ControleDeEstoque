using DAL;
using EnumsCompartilhados;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLLmodelo
    {
        public void Incluir<T>(T modelo);


        public bool verificaExisteNome<T>(T modelo);

        public void Alterar<T>(T modelo);
        public void Excluir(int codigo);

        public DataTable Localizar(string valor);

        public T CarregarModelo<T>(int codigo);
        
    }
}
