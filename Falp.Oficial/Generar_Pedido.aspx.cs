using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.Web.UI.WebControls;
using System.Data;
using System.ComponentModel;

namespace Falp.Oficial
{
    public partial class Generar_Pedido : System.Web.UI.Page
    {

        #region Variables

        static string cod_alimento = "";
        static string cod_pedido = "";
        DataTable dt_listado_comida = new DataTable();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

             
                     
                     txtpaciente2.Value = Session["Nom_Paciente"].ToString();
                    
                     cod_pedido = Session["_Cod_pedido"].ToString();
                     Cargar_bandeja();
                     Cargar_regimen();
                     Cargar_aislamiento();

                     buscar_alimento_activos();
                

                }
                else
                {
                    Response.Redirect("index.aspx");
                    Session["Usuario"] = "";
                }

            }
        }

        void buscar_alimento_activos()
        {
            List<Utilidades> lista_comida = new UtilidadesNE().Cargaralimentos_pedido(Convert.ToInt32(cod_pedido));
            dt_listado_comida = ConvertToDataTable(lista_comida);
            Session["tabla_comidas"] = dt_listado_comida;
        }


        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

         int  validar_comida(int codigo)
        {
            int res = 0;
             dt_listado_comida =  (DataTable)Session["tabla_comidas"];
            foreach (DataRow row in dt_listado_comida.Rows)
            {
                if (row["_Cod_tipo_comida"].ToString() == codigo.ToString())
                {
                    res = 1;
   
                }
              
            }
            Session["tabla_nutrientes"] = dt_listado_comida;
            return res;

        }
       
    

             protected void desayuno(object sender, EventArgs e)
             {

                 if (Session["Tipo_Alimento"].ToString() == "DESAYUNO")
                 {
                      int val=validar_comida(2);
                      if ( val == 1)
                     {
                         Session["Cod_Tipo_Alimento"] = 2;
                         btndesayuno.Text = "On";

                         btndesayuno.Attributes["class"] = "btn btn-success";
                         Response.Redirect("Guardar_Pedido.aspx");

                     }
                     else
                     {
                         btndesayuno.Text = "Off";
                         btndesayuno.Attributes["class"] = "btn btn-danger";
                         Session["Cod_Tipo_Alimento"] = 2;
                         Response.Redirect("Guardar_Pedido.aspx");
                     }
                   }
                 else
                 {
                     if (Session["Tipo_Alimento"].ToString() == "ONCE")
                     {
                         int val = validar_comida(4);
                         if (val == 1)
                         {
                             Session["Cod_Tipo_Alimento"] = 4;
                             btnonce.Text = "On";

                             btnonce.Attributes["class"] = "btn btn-success";
                             Response.Redirect("Guardar_Pedido.aspx");

                         }
                         else
                         {
                             btnonce.Text = "Off";
                             btnonce.Attributes["class"] = "btn btn-danger";
                             Session["Cod_Tipo_Alimento"] = 4;
                             Response.Redirect("Guardar_Pedido.aspx");
                         }
                     }
                     else
                     {
                         if (Session["Tipo_Alimento"].ToString() == "COLACION MAÑANA")
                         {
                             int val = validar_comida(1);
                             if (val == 1)
                             {
                                 Session["Cod_Tipo_Alimento"] = 1;
                                 btncolacionman.Text = "On";

                                 btncolacionman.Attributes["class"] = "btn btn-success";
                                 Response.Redirect("Guardar_Pedido.aspx");

                             }
                             else
                             {
                                 Session["Cod_Tipo_Alimento"] = 1;
                                 btncolacionman.Text = "Off";
                                 btncolacionman.Attributes["class"] = "btn btn-danger";
                                 Response.Redirect("Guardar_Pedido.aspx");
                             }
                         }
                         else
                         {
                             if (Session["Tipo_Alimento"].ToString() == "COLACION TARDE")
                             {
                                 int val = validar_comida(6);
                                 if (val == 1)
                                 {
                                     Session["Cod_Tipo_Alimento"] = 6;
                                     btncolaciontar.Text = "On";

                                     btncolaciontar.Attributes["class"] = "btn btn-success";
                                     Response.Redirect("Guardar_Pedido.aspx");

                                 }
                                 else
                                 {
                                     Session["Cod_Tipo_Alimento"] = 6;
                                     btncolaciontar.Text = "Off";
                                     btncolaciontar.Attributes["class"] = "btn btn-danger";
                                     Response.Redirect("Guardar_Pedido.aspx");
                                 }
                             }
                             else
                             {
                                 if (Session["Tipo_Alimento"].ToString() == "COLACION NOCTURNA")
                                 {
                                     int val = validar_comida(7);
                                     if (val == 1)
                                     {
                                         Session["Cod_Tipo_Alimento"] = 7;
                                         btncolacionnoc.Text = "On";

                                         btncolacionnoc.Attributes["class"] = "btn btn-success";
                                         Response.Redirect("Guardar_Pedido.aspx");

                                     }
                                     else
                                     {
                                         Session["Cod_Tipo_Alimento"] = 7;
                                         btncolacionnoc.Text = "Off";
                                         btncolacionnoc.Attributes["class"] = "btn btn-danger";
                                         Response.Redirect("Guardar_Pedido.aspx");
                                     }
                                 }
                                 else
                                 {
                                     if (Session["Tipo_Alimento"].ToString() == "HIDRICOS")
                                     {
                                         int val = validar_comida(8);
                                         if (val == 1)
                                         {
                                             Session["Cod_Tipo_Alimento"] = 8;
                                             btnhidricos.Text = "On";

                                             btncolaciontar.Attributes["class"] = "btn btn-success";
                                             Response.Redirect("Guardar_Pedido.aspx");

                                         }
                                         else
                                         {
                                             Session["Cod_Tipo_Alimento"] = 8;
                                             btnhidricos.Text = "Off";
                                             btnhidricos.Attributes["class"] = "btn btn-danger";
                                             Response.Redirect("Guardar_Pedido.aspx");
                                         }
                                     }
                                     else
                                     {
                                         if (Session["Tipo_Alimento"].ToString() == "ALMUERZO")
                                         {
                                             int val = validar_comida(3);
                                             if (val == 1)
                                             {
                                                 Session["Cod_Tipo_Alimento"] = 3;
                                                 btn_almuerzos.Text = "On";

                                                 btn_almuerzos.Attributes["class"] = "btn btn-success";
                                                 Response.Redirect("Guardar_Pedido.aspx");

                                             }
                                             else
                                             {
                                                 Session["Cod_Tipo_Alimento"] = 3;
                                                 btn_almuerzos.Text = "Off";
                                                 btn_almuerzos.Attributes["class"] = "btn btn-danger";
                                                 Response.Redirect("Guardar_Pedido.aspx");
                                             }
                                         }
                                         else
                                         {
                                             if (Session["Tipo_Alimento"].ToString() == "CENA")
                                             {
                                                 int val = validar_comida(5);
                                                 if (val == 1)
                                                 {
                                                     Session["Cod_Tipo_Alimento"] = 5;
                                                     btncena.Text = "On";

                                                     btncena.Attributes["class"] = "btn btn-success";
                                                     Response.Redirect("Guardar_Pedido.aspx");

                                                 }
                                                 else
                                                 {
                                                     Session["Cod_Tipo_Alimento"] = 5;
                                                     btncena.Text = "Off";
                                                     btncena.Attributes["class"] = "btn btn-danger";
                                                     Response.Redirect("Guardar_Pedido.aspx");
                                                 }
                                             }
                                             else
                                             {
                                                 if (Session["Tipo_Alimento"].ToString() == "ONCE")
                                                 {
                                                     int val = validar_comida(4);
                                                     if (val == 1)
                                                     {
                                                         Session["Cod_Tipo_Alimento"] = 4;
                                                         btnonce.Text = "On";

                                                         btnonce.Attributes["class"] = "btn btn-success";
                                                         Response.Redirect("Guardar_Pedido.aspx");

                                                     }
                                                     else
                                                     {
                                                         Session["Cod_Tipo_Alimento"] = 4;
                                                         btnonce.Text = "Off";
                                                         btnonce.Attributes["class"] = "btn btn-danger";
                                                         Response.Redirect("Guardar_Pedido.aspx");
                                                     }
                                                 }
                                                 else
                                                 {


                                                 }

                                             }

                                         }

                                     }

                                 }

                             }

                         }

                     }

                 }
               
             }

             protected void Btn_desayuno(object sender, EventArgs e)
             {
                 if (cboregimen.SelectedValue != "0" && cboaislamiento.SelectedValue != "0" && cbobandeja.SelectedValue != "0")
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { desayuno(); });", true);
                     Session["Tipo_Alimento"] = "DESAYUNO";
                     txtalimento1.Value = Session["Tipo_Alimento"].ToString();
                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { validation1(); });", true);
                 }


             }

             protected void Btn_once(object sender, EventArgs e)
             {
                  if (cboregimen.SelectedValue != "0" && cboaislamiento.SelectedValue != "0" && cbobandeja.SelectedValue != "0")
                 {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { desayuno(); });", true);
                 Session["Tipo_Alimento"] = "ONCE";
                 txtalimento1.Value = Session["Tipo_Alimento"].ToString();
                 }
                  else
                  {
                      ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { validation1(); });", true);
                  }

             }

             protected void Btn_colacion_man(object sender, EventArgs e)
             {
                  if (cboregimen.SelectedValue != "0" && cboaislamiento.SelectedValue != "0" && cbobandeja.SelectedValue != "0")
                 {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { desayuno(); });", true);
                 Session["Tipo_Alimento"] = "COLACION MAÑANA";
                 txtalimento1.Value = Session["Tipo_Alimento"].ToString();

                    }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { validation1(); });", true);
                 }
             }

             protected void Btn_colacion_tar(object sender, EventArgs e)
             {

                if (cboregimen.SelectedValue != "0" && cboaislamiento.SelectedValue != "0" && cbobandeja.SelectedValue != "0")
                 {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { desayuno(); });", true);
                 Session["Tipo_Alimento"] = "COLACION TARDE";
                 txtalimento1.Value = Session["Tipo_Alimento"].ToString();
                   }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { validation1(); });", true);
                 }
             }


             protected void Btn_almuerzo1(object sender, EventArgs e)
             {
                if (cboregimen.SelectedValue != "0" && cboaislamiento.SelectedValue != "0" && cbobandeja.SelectedValue != "0")
                 {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { desayuno(); });", true);
           
                 Session["Tipo_Alimento"] = "ALMUERZO";
                 txtalimento1.Value = Session["Tipo_Alimento"].ToString();
    }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { validation1(); });", true);
                 }


             }

             protected void Btn_cena(object sender, EventArgs e)
             {
                 
                 if (cboregimen.SelectedValue != "0" && cboaislamiento.SelectedValue != "0" && cbobandeja.SelectedValue != "0")
                 {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { desayuno(); });", true);
           
                 Session["Tipo_Alimento"] = "CENA";
                 txtalimento1.Value = Session["Tipo_Alimento"].ToString();
    }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { validation1(); });", true);
                 }

             }

             protected void Btn_colacion_noc(object sender, EventArgs e)
             {
                if (cboregimen.SelectedValue != "0" && cboaislamiento.SelectedValue != "0" && cbobandeja.SelectedValue != "0")
                 {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { desayuno(); });", true);
                 Session["Tipo_Alimento"] = "COLACION NOCTURNA";
                 txtalimento1.Value = Session["Tipo_Alimento"].ToString();
               }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { validation1(); });", true);
                 }

             }

             protected void Btn_hidricos(object sender, EventArgs e)
             {
                 if (cboregimen.SelectedValue != "0" && cboaislamiento.SelectedValue != "0" && cbobandeja.SelectedValue != "0")
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { desayuno(); });", true);

                 Session["Tipo_Alimento"] = "HIDRICOS";
                 txtalimento1.Value = Session["Tipo_Alimento"].ToString();
             }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { validation1(); });", true);
                 }

             }




             protected void Cargar_regimen()
             {
                 try
                 {
                     List<Utilidades> lista_regimen = new UtilidadesNE().Cargarregimen();
                     cboregimen.DataSource = lista_regimen;
                     cboregimen.DataTextField = "_Nom_regimen";
                     cboregimen.DataValueField = "_Cod_regimen";
                     cboregimen.DataBind();
                     cboregimen.Items.Insert(0, new ListItem("Seleccionar", "0"));
                 }

                 catch (Exception ex)
                 {
                     System.Console.Write(ex.Message);
                 }
             }



             protected void Cargar_bandeja()
             {
                 try
                 {

                     List<Utilidades> lista_bandeja = new UtilidadesNE().Cargarbandeja();
                     cbobandeja.DataSource = lista_bandeja;
                     cbobandeja.DataTextField = "_Nom_bandeja";
                     cbobandeja.DataValueField = "_Cod_bandeja";
                     cbobandeja.DataBind();
                     cbobandeja.Items.Insert(0, new ListItem("Seleccionar", "0"));
                 }

                 catch (Exception ex)
                 {

                     System.Console.Write(ex.Message);
                 }
             }

             protected void cbobandeja_SelectedIndexChanged(object sender, EventArgs e)
             {
                 Session["Bandeja"] = cbobandeja.SelectedValue.ToString();
             }

             protected void cboaislamiento_SelectedIndexChanged(object sender, EventArgs e)
             {
                 Session["Aislamiento"] = cboaislamiento.SelectedValue.ToString();
             }

             protected void cboregimen_SelectedIndexChanged(object sender, EventArgs e)
             {
                 Session["Regimen"] = cboregimen.SelectedValue.ToString();
             }

             protected void Cargar_aislamiento()
             {
                 try
                 {

                     List<Utilidades> lista_aislamiento = new UtilidadesNE().Cargaraislamiento();
                     cboaislamiento.DataSource = lista_aislamiento;
                     cboaislamiento.DataTextField = "_Nom_aislamiento";
                     cboaislamiento.DataValueField = "_Cod_aislamiento";
                     cboaislamiento.DataBind();
                     cboaislamiento.Items.Insert(0, new ListItem("Seleccionar", "0"));
                 }

                 catch (Exception ex)
                 {

                     System.Console.Write(ex.Message);
                 }
             }

             protected void opc_alim_CheckedChanged(object sender, System.EventArgs e)
             {
                 if (codayuno.Checked == true)
                 {
                     habilitar_almuerzos();
                 }
                 else
                 {
                     if (codalimento_oral.Checked == true)
                     {
                         habilitar_almuerzos();
                     }
                     else
                     {
                         if (nutricion_oral.Checked == true)
                         {
                             desabilitar_almuerzos();
                         }
                         else
                         {
                             if (nutricion_parental.Checked == true)
                             {
                                 desabilitar_almuerzos();
                             }
                             else
                             {

                             }
                         }
                     }
                 }
             }


             void desabilitar_almuerzos()
             {
                 btn_almuerzos.Visible=false;
                 btncena.Visible=false;
                 btncolacionman.Visible=false;
                 btncolacionnoc.Visible=false;
                 btncolaciontar.Visible=false;
                 btndesayuno.Visible=false;
                 btnonce.Visible = false;
                 btnhidricos.Visible=false;
             }

             void habilitar_almuerzos()
             {
                 btn_almuerzos.Visible = true;
                 btncena.Visible = true;
                 btncolacionman.Visible = true;
                 btncolacionnoc.Visible = true;
                 btncolaciontar.Visible = true;
                 btndesayuno.Visible = true;
                 btnonce.Visible = true;
                 btnhidricos.Visible = true;
             }

       

      

         
    }
}