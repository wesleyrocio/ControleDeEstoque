using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FrmModeloDeFormularioDeCadastro : Form
    {
        
        public FrmModeloDeFormularioDeCadastro()
        {
            InitializeComponent();
        }


        public string operacao = "";
        public void alteraBotoes(int op)
        {
            isHabilitarTodosBotoes(false);
            switch (op) 
            {
                case 1:
                    buttonInserir.Enabled   = true;
                    buttonLocalizar.Enabled = true;
                    break;
                case 2:
                    pnDados.Enabled        = true;
                    buttonSalvar.Enabled   = true;
                    buttonCancelar.Enabled = true;
                    break;
                case 3:
                    buttonAlterar.Enabled  = true;
                    buttonExcluir.Enabled  = true;
                    buttonCancelar.Enabled = true;
                    break;
            }

        }
        private void isHabilitarTodosBotoes(bool isHabilitarTodos) 
        {
            pnDados.Enabled          = isHabilitarTodos;
            buttonInserir.Enabled    = isHabilitarTodos;
            buttonAlterar.Enabled    = isHabilitarTodos;
            buttonLocalizar.Enabled  = isHabilitarTodos;
            buttonExcluir.Enabled    = isHabilitarTodos;
            buttonCancelar.Enabled   = isHabilitarTodos;
        }
    }
}
