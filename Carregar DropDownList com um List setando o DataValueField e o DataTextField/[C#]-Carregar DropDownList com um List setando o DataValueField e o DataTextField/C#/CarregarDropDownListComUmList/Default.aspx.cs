using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarregarDropDownListComUmList
{
    public partial class Default : System.Web.UI.Page
    {  
        //Classe Estado e suas propriedades
        public class Estado
        {
            public int Id { get; set; }
            public string NomeEstado { get; set; }
        }         

        //Método que retorna um List<Estado>
        private List<Estado> RetornaLista()
        {
            //Instância da Lista
           List<Estado> lista = new List<Estado>();

            //Crio novo Estado e adciono á lista
            Estado estado1 = new Estado();
            estado1.Id = 1;
            estado1.NomeEstado = "Brasília";
            lista.Add(estado1);

            //Crio novo Estado e adciono á lista
            Estado estado2 = new Estado();
            estado2.Id = 2;
            estado2.NomeEstado = "Minas Gerais";
            lista.Add(estado2);

            //Crio novo Estado e adciono á lista
            Estado estado3 = new Estado();
            estado3.Id = 3;
            estado3.NomeEstado = "Espírito Santo";
            lista.Add(estado3);

            //retorno a lista
            return lista;
        }

        //método que carrega o DropDownLIst
        private void CarregaDropDownList()
        {
            //seto a lista retornada pelo método acima
            //como o Datasource do DropDownList
            ddlEstado.DataSource = RetornaLista();
            //Indico que o DataValueField é a 
            //propriedade Id da classe Estado
            ddlEstado.DataValueField = "Id";
            //Indico que o DataTextField é a 
            //propriedade NomeEstado da classe Estado
            ddlEstado.DataTextField = "NomeEstado"; 
            //Bindo o DropDownList
            ddlEstado.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Se não for PostBack
            if (!Page.IsPostBack)
            {
                //Carrego o DropDownList atravéz do método
                CarregaDropDownList();
            }
        }
    }
}