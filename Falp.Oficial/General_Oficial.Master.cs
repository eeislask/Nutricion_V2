using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.Web.UI.WebControls;

namespace Falp.Oficial
{
    public partial class General_Oficial : System.Web.UI.MasterPage
    {

        #region Variables

        string user = "";
        List<Cama_Pacientes> lista_estadistico = new List<Cama_Pacientes>();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();
                  
                    nombre.Text = user.ToUpper();
                    Cargar_grilla();
                }
                else
                {
                    Response.Redirect("index.aspx");
                    Session["Usuario"] = "";
                }

            }
        }


        protected void salir(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
            Session["Usuario"] = "";


        }

        void Cargar_grilla()
        {

            Cama_PacienteNE var = new Cama_PacienteNE();

            lista_estadistico = var.Listadoestadistico();

            grillacama.DataSource = lista_estadistico;
            grillacama.DataBind();

        }

        protected void grillacama_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillacama.PageIndex = e.NewPageIndex;
            grillacama.DataBind();
            Cargar_grilla();


        }
    }
}