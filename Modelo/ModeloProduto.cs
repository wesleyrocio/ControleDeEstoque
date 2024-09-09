using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Modelo
{
    public class ModeloProduto : ModeloInterfaceEntidades
    {
        private int    pro_cod       ;
        private string pro_nome      ;
        private string pro_descricao ;
        private byte[] pro_foto      ;
      

        private double pro_valorpago ;
        private double pro_valorvenda;
        private double pro_qtde      ;
       

        public int     ProCod         { get { return pro_cod; } set { pro_cod = value; } }
        public string  ProNome        { get { return pro_nome;       } set { pro_nome = value; } }
        public string  ProDescricao   { get { return pro_descricao;  } set { pro_descricao = value; } }

        public byte[] ProFoto       {   get { return pro_foto; }       set { pro_foto = value; }        }

        public double  ProValorpago   { get {  return pro_valorpago; } set { pro_valorpago = value;    } }
        public double  ProValorVenda  { get { return pro_valorvenda; } set { pro_valorvenda = value;  } } 
        public double  ProQtde        { get { return pro_qtde;       } set { pro_qtde = value; } }
        public ModeloUndMedida UnidadeDeMedida { get; set; }
        public ModeloCategoria Categoria { get; set; }
        public ModeloSubCategoria SubCategoria { get; set; }    
      /*  public int     CatCod         {  get { return cat_cod;       } set {  cat_cod = value; } }    
        public int     ScatCod        { get {return scat_cod;        } set {  scat_cod = value; } }
       
        public string CatNome { get { return cat_nome; } set { cat_nome = value; } }
        public string ScatNome { get { return scat_nome; } set { scat_nome = value; } }*/

       

        public ModeloProduto()
        {
            ProNome = "";
            ProDescricao = "";
            ProValorpago = 0;
            ProValorVenda = 0;           
            ProQtde = 0;

            UnidadeDeMedida = new ModeloUndMedida();
            UnidadeDeMedida.UmedCod = 0;
            UnidadeDeMedida.UmedNome = "";

            Categoria = new ModeloCategoria();
            Categoria.CatCod = 0;
            Categoria.CatNome = "";

            SubCategoria = new ModeloSubCategoria();
            SubCategoria.ScatCod = 0;    
            SubCategoria.ScatNome = "";
        }

        public ModeloProduto(string _pro_nome,
                     string _pro_descricao,
                     string _pro_foto,
                     double _pro_valorpago,
                     double _pro_valorvenda,
                     double _pro_qtde,
                     int _umed_cod,
                     int _cat_cod,
                     int _scat_cod)
        {
            ProNome = _pro_nome;
            ProDescricao = _pro_descricao;
            this.CarregarImagem(_pro_foto);
            ProValorpago = _pro_valorpago;
            ProValorVenda = _pro_valorvenda;
            ProQtde = _pro_qtde;
            UnidadeDeMedida.UmedCod = _umed_cod;
            Categoria.CatCod     = _cat_cod;
            SubCategoria.ScatCod = _scat_cod;

        }

        public ModeloProduto(string _pro_nome,
                       string _pro_descricao,
                       byte[] _pro_foto,
                       double _pro_valorpago,
                       double _pro_valorvenda,
                       double _pro_qtde,
                       int _umed_cod,
                       int _cat_cod,
                       int _scat_cod)
        {
            ProNome = _pro_nome;
            ProDescricao = _pro_descricao;
            this.ProFoto = _pro_foto;
            ProValorpago = _pro_valorpago;
            ProValorVenda = _pro_valorvenda;
            ProQtde = _pro_qtde;
            UnidadeDeMedida.UmedCod = _umed_cod;
            Categoria.CatCod = _cat_cod;
            SubCategoria.ScatCod = _scat_cod;

        }
        public void CarregarImagem(String imgCaminho)
        {
            try
            {
                if (string.IsNullOrEmpty(imgCaminho)) return;
                FileInfo arqImagem = new FileInfo(imgCaminho);
                FileStream fs = new FileStream(imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);

                this.ProFoto = new byte[Convert.ToInt32(arqImagem.Length)];
                int iBytesRead = fs.Read(this.ProFoto, 0, Convert.ToInt32(arqImagem.Length));
            }
            catch (Exception e)
            {

                throw new Exception(e.Message.ToString());
            }
          


        }

















    }
}
