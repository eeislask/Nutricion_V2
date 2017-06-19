using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.ComponentModel;

namespace Falp.Systema_web
{
    public partial class Listado_Camas : System.Web.UI.Page
    {
        #region Variables

        string user = "";
        static string cod_cama = "";
        static string cod_paciente = "";
        static string nom_paciente = "";

        List<Cama_Pacientes> lista_cama_paciente = new List<Cama_Pacientes>();

        #endregion

        #region DataTable
        DataTable dt_listado_cama = new DataTable();
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
                    Response.Redirect("Login.aspx");
                    Session["Usuario"] = "";
                }

            }
        }


        #region  grilla

        void Cargar_grilla()
        {

         /*   Cama_PacienteNE var = new Cama_PacienteNE();

            lista_cama_paciente = var.ListadoCamaPacientes();

            grillacama.DataSource = lista_cama_paciente;
            grillacama.DataBind();
            */
            

            
        }

        protected void grillacama_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillacama.PageIndex = e.NewPageIndex;
            grillacama.DataBind();
            Cargar_grilla();


        }

        protected void grillacama_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var estado = e.Row.DataItem as Cama_Pacientes;

                if (estado != null)
                {
                    var image = e.Row.FindControl("img_estado") as Image;


                    if (estado._Estado.Equals("") || estado._Estado.Equals("N"))
                    {
                        image.ImageUrl = "~/Imagenes/Botones/error.png";
                    }
                    else
                    {
                        if (estado._Estado.Equals("I"))
                        {
                            image.ImageUrl = "~/Imagenes/Botones/incompleto.png";
                        }
                        else
                        {
                            if (estado._Estado.Equals("C"))
                            {
                                image.ImageUrl = "~/Imagenes/Botones/ok.png";
                            }
                        }
                    }
                }
            }
        }

        #endregion


        #region Botones

        protected void buscar_paciente(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;


            Session["_Num_cama"] = row.Cells[1].Text.Trim();
            Session["_Nom_paciente"] = row.Cells[2].Text.Trim().Replace("&nbsp;", "");
           
            Session["_Cod_paciente"] = grillacama.DataKeys[row.RowIndex]["_Cod_paciente"].ToString().Replace("&nbsp;", "");
            cod_paciente = grillacama.DataKeys[row.RowIndex]["_Cod_paciente"].ToString().Replace("&nbsp;", "");
            Session["_Cod_cama"] = grillacama.DataKeys[row.RowIndex]["_Cod_cama"].ToString().Replace("&nbsp;", "");
            cod_cama = grillacama.DataKeys[row.RowIndex]["_Cod_cama"].ToString().Replace("&nbsp;", "");

         

            string res = "Estimado Usuario, que acciòn desea realizar en la cama seleccionada";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup2('" + res + "');", true);

            //  Response.Redirect("Buscar_Pacientes.aspx");

        }

        protected void buscar_salir(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
     

        protected void btnver_pedidos(object sender, EventArgs e)
        {
            Response.Redirect("Buscar_Pacientes.aspx");
        }

        protected void btn_liberar_cama(object sender, EventArgs e)
        {
            Cama_PacienteNE var = new Cama_PacienteNE();


         if(!cod_paciente.Equals(""))
         {
            string msg = var.Liberar_cama(cod_cama,cod_paciente);

            if (msg=="ok")
            {
                string res = "Estimado Usuario, La cama ha sido liberada";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1('" + res + "');", true);
                Cargar_grilla();
            }
            else
            {
                string res = "Estimado Usuario, error al liberar la cama";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1('" + res + "');", true);
            }
         }
         else
         {
             string res = "Estimado Usuario, No se puede Liberar Cama porque existe un Paciente asociado";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1('" + res + "');", true);
         }
        }

        #endregion
    }
}