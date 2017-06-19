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

namespace Falp.Oficial
{
    public partial class Listado_Camas : System.Web.UI.Page
    {
        #region Variables

       static string user = "";
        string rut = "";
        int cod_servicio = 0;
        int cod_estado = 0;
        static string cod_pedido = "";
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
                    Cargar_grilla();
                    Cargar_estado();
                    Cargar_servicio();

                }
                else
                {
                    Response.Redirect("index.aspx");
                    Session["Usuario"] = "";
                }

            }
            btn_lib.Visible = false;
        }
        #region  grilla

        void Cargar_grilla()
        {
         
            Cama_PacienteNE var = new Cama_PacienteNE();

            lista_cama_paciente = var.ListadoCamaPacientes(rut,cod_servicio,cod_estado);

            grillacama.DataSource = lista_cama_paciente;
            grillacama.DataBind();

             txtcantidad.Text=lista_cama_paciente.Count().ToString();
  

        }

        protected void grillacama_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillacama.PageIndex = e.NewPageIndex;
            grillacama.DataBind();
            Cargar_grilla();          

        }

        #endregion


        protected void Cargar_servicio()
        {
            try
            {

                List<Utilidades> lista_servicio = new UtilidadesNE().Cargarservicio();
                cboservicio.DataSource = lista_servicio;
                cboservicio.DataTextField = "_Nom_servicio";
                cboservicio.DataValueField = "_Cod_servicio";
                cboservicio.DataBind();
                cboservicio.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_estado()
        {
            try
            {

                List<Utilidades> lista_estado = new UtilidadesNE().Cargarestado();
                cboestado.DataSource = lista_estado;
                cboestado.DataTextField = "_Nom_estado";
                cboestado.DataValueField = "_Cod_estado";
                cboestado.DataBind();
                cboestado.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void buscar(object sender, EventArgs e)
        {
            rut = Request.Form["txtrut"].Trim().Replace(",","");
            cod_servicio = Convert.ToInt32(cboservicio.SelectedValue);
            cod_estado = Convert.ToInt32(cboestado.SelectedValue);
            Cargar_grilla();
        }

        protected void ingresar(object sender, EventArgs e)
        {
            Button btndetails = sender as Button;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;

            txtcama1.Value = row.Cells[3].Text.Trim();
            txthabitacion1.Value = row.Cells[4].Text.Trim();
            txtnombre1.Value = row.Cells[7].Text.Trim().Replace("&#209;", "Ñ");

            cod_paciente = grillacama.DataKeys[row.RowIndex]["_Id_pac"].ToString().Replace("&nbsp;", "");
            cod_cama = grillacama.DataKeys[row.RowIndex]["_Id"].ToString().Replace("&nbsp;", "");
            Session["Cod_Paciente"] = grillacama.DataKeys[row.RowIndex]["_Id_pac"].ToString().Replace("&nbsp;", "");
            Session["Cama"] = row.Cells[3].Text.Trim().Replace("&nbsp;", "");
            Session["Habitacion"] = row.Cells[4].Text.Trim().Replace("&nbsp;", "");
            Session["Nom_Paciente"] = row.Cells[7].Text.Trim().Replace("&nbsp;", "").Replace("&#209;", "Ñ");
            Session["Nom_Servicio"] = row.Cells[8].Text.Trim().Replace("&nbsp;", "");



            txtcama2.Value = row.Cells[3].Text.Trim();
            txthabitacion2.Value = row.Cells[4].Text.Trim();
            txtnombre2.Value = row.Cells[7].Text.Trim().Replace("&#209;", "Ñ");

            txtcama3.Value = row.Cells[3].Text.Trim();
            txthabitacion3.Value = row.Cells[4].Text.Trim();
            txtnombre3.Value = row.Cells[7].Text.Trim().Replace("&#209;", "Ñ");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { informacion(); });", true);

        }

        protected void Btn_liberar_cama(object sender, EventArgs e)
        {
         

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { liberar_cama(); });", true);

        }

        protected void Btn_generar_pedido(object sender, EventArgs e)
        {
            if (txtnombre1.Value != "")
            {
                btn_registrar.Visible = false;
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { generar_pedido(); });", true);

        }

        protected void Btn_detalle_pedido(object sender, EventArgs e)
        {
            Button btndetails = sender as Button;
            GridViewRow row = (GridViewRow)btndetails.NamingContainer;

            txtcama.Value = row.Cells[3].Text.Trim();
            txthabitacion.Value = row.Cells[4].Text.Trim();
            txtnombre.Value = row.Cells[7].Text.Trim().Replace("&#209;", "Ñ");
             txtservicio.Value= row.Cells[8].Text.Trim();
            

           /* Session["_Cod_paciente"] = grillacama.DataKeys[row.RowIndex]["_Cod_paciente"].ToString().Replace("&nbsp;", "");
            cod_paciente = grillacama.DataKeys[row.RowIndex]["_Cod_paciente"].ToString().Replace("&nbsp;", "");
            Session["_Cod_cama"] = grillacama.DataKeys[row.RowIndex]["_Cod_cama"].ToString().Replace("&nbsp;", "");
            cod_cama = grillacama.DataKeys[row.RowIndex]["_Cod_cama"].ToString().Replace("&nbsp;", "");*/

         

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { detalle_pedido(); });", true);

        }


        protected void Btn_registrar_paciente(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { registrar_paciente(); });", true);

        }

        protected void Btn_envia_generar_ped(object sender, EventArgs e)
        {
            cod_pedido = validar_pedido().ToString();
            if (cod_pedido.Equals("") || cod_pedido.Equals("0"))
            {

                string msg = new PedidosNE().Registrar_Pedido(user, cod_cama, cod_paciente);

                Session["_Cod_pedido"] = msg;
            }
            else
            {
                Session["_Cod_pedido"] = cod_pedido;
            }
          

            Response.Redirect("Generar_Pedido.aspx");

        }

        protected int validar_pedido()
        {
            int var = 0;
            int var2 = 0;

            if (cod_paciente == "" || cod_paciente == null)
            {
                var2 = 0;
                Pedidos ped = new PedidosNE().Cargar_pedidos2(var2);
                var = ped._Id;
                return var;
            }
            else
            {
                Pedidos ped = new PedidosNE().Cargar_pedidos2(Convert.ToInt32(cod_paciente));
                var = ped._Id;
                return var;
            }
           // int cod_paciente = Convert.ToInt32(var2);
         
        }
    }
}