using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.ComponentModel;
using System.Collections;
using System.Data;

namespace Falp.Systema_web
{
    public partial class Generar_Pedido : System.Web.UI.Page
    {
        
        #region Variables
        static string user = "";
        static string cod_cama = "";
        static string cod_paciente = "";
        static string cod_pedido = "0";

        DataTable dtnutrientes = new DataTable();
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
          if (IsPostBack == false)
            {
                
                if (Session["Usuario"] != null)
                {
                   
                    user = Session["Usuario"].ToString();
                    nombre.Text = user.ToUpper();
                    cod_cama = Session["_Cod_cama"].ToString();
                    cod_paciente = Session["_Cod_paciente"].ToString();
                    cod_pedido = Session["_Cod_pedido"].ToString();


                    
                        Cargar_grilla();
                        GetData();


                        Cargar_tipo_consistencia();
                        Cargar_tipo_digestabilidad();
                        Cargar_tipo_aporte_nutrientes();
                        Cargar_tipo_volumen();
                        Cargar_tipo_temperatura();
                        Cargar_tipo_sales();
                        Cargar_tipo_otros();

                        if (Convert.ToInt32(cod_pedido)>0)
                        {
                            Pedidos ped = new PedidosNE().Cargar_pedidos(Convert.ToInt32(cod_pedido));

                            cbotipo_consistencia.SelectedIndex=ped._Cod_tipo_consistencia;
                            cbotipo_digestabilidad.SelectedIndex = ped._Cod_tipo_digestabilidad;
                            cbotipo_aporte_nutrientes.SelectedIndex = ped._Cod_tipo_aporte_nutrientes;
                            cbotipo_volumen.SelectedIndex = ped._Cod_tipo_volumen;
                            cbotipo_temperatura.SelectedIndex = ped._Cod_tipo_temperatura;
                            cbotipo_sales.SelectedIndex = ped._Cod_tipo_sales;
                            cbotipo_otros.SelectedIndex = ped._Cod_tipo_otros;
                            txtdiagnostico.Value = ped._Diagnostico;
                            txtamnesis.Value = ped._Amnesis_alim;
                            txtobservacion.Value = ped._Observaciones;

                            List<Utilidades> lista_tipo_nutrientes = new UtilidadesNE().Cargartipo_nutrientes_pedido(Convert.ToInt32(cod_pedido));
                            /*  transformar  una lista en datatable*/
                            dtnutrientes = ConvertToDataTable(lista_tipo_nutrientes);
                            Session["tabla_nutrientes"] = dtnutrientes;

                            foreach (DataRow row in dtnutrientes.Rows)
                            {
                                if (row["_Est_tipo_nutrientes"].ToString().Equals("S"))
                                {
                                    string cod = row["_Cod_tipo_nutrientes"].ToString();
                                    mostar_nutrientes(cod);
                                }
                            }
                        }
                  
                   

                }
                else
                {
                    Response.Redirect("Login.aspx");
                    Session["Usuario"] = "";
                }
              

            }

        }

     

      protected void   mostar_nutrientes(string cod)
      {

          foreach (GridViewRow gvrow in grillanutrientes.Rows)
          {
              string codigo;

              codigo = grillanutrientes.DataKeys[gvrow.RowIndex]["_Cod_tipo_nutrientes"].ToString();

              if (codigo.Equals(cod))
              {
                  CheckBox chkSelect = (gvrow.Cells[0].FindControl("chk") as CheckBox);
                  chkSelect.Checked = true;
              }
          }

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
        #region  grilla

        void Cargar_grilla()
        {
            
                List<Utilidades> lista_tipo_nutrientes = new UtilidadesNE().Cargartipo_nutrientes();
                grillanutrientes.DataSource = lista_tipo_nutrientes;
                grillanutrientes.DataBind();
           
          

          
        }

        protected void grillanutrientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillanutrientes.PageIndex = e.NewPageIndex;
            grillanutrientes.DataBind();
            Cargar_grilla();
            SetData();

        }


        private void GetData()
        {
            ArrayList arr;
            if (ViewState["SelectedRecords"] != null)
                arr = (ArrayList)ViewState["SelectedRecords"];
            else
                arr = new ArrayList();
            CheckBox chkAll = (CheckBox)grillanutrientes.HeaderRow
                                .Cells[0].FindControl("chkAll");
            for (int i = 0; i < grillanutrientes.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    if (!arr.Contains(grillanutrientes.DataKeys[i].Value))
                    {
                        arr.Add(grillanutrientes.DataKeys[i].Value);
                    }
                }
                else
                {
                    CheckBox chk = (CheckBox)grillanutrientes.Rows[i]
                                       .Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        if (!arr.Contains(grillanutrientes.DataKeys[i].Value))
                        {
                            arr.Add(grillanutrientes.DataKeys[i].Value);
                        }
                    }
                    else
                    {
                        if (arr.Contains(grillanutrientes.DataKeys[i].Value))
                        {
                            arr.Remove(grillanutrientes.DataKeys[i].Value);
                        }
                    }
                }
            }
            ViewState["SelectedRecords"] = arr;
        }

        private void SetData()
        {
            int currentCount = 0;
            CheckBox chkAll = (CheckBox)grillanutrientes.HeaderRow
                                    .Cells[0].FindControl("chkAll");
            chkAll.Checked = true;
            ArrayList arr = (ArrayList)ViewState["SelectedRecords"];
            for (int i = 0; i < grillanutrientes.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)grillanutrientes.Rows[i]
                                .Cells[0].FindControl("chk");
                if (chk != null)
                {
                    chk.Checked = arr.Contains(grillanutrientes.DataKeys[i].Value);
                    if (!chk.Checked)
                        chkAll.Checked = false;
                    else
                        currentCount++;
                }
            }
           //hfCount1.Value = (arr.Count - currentCount).ToString();
        }

        #endregion

        #region Cargar Combobox

        protected void Cargar_tipo_consistencia()
        {
            try
            {

                List<Utilidades> lista_tipo_consistencia = new UtilidadesNE().Cargartipo_consistencia();
                cbotipo_consistencia.DataSource = lista_tipo_consistencia;
                cbotipo_consistencia.DataTextField = "_Nom_tipo_consistencia";
                cbotipo_consistencia.DataValueField = "_Cod_tipo_consistencia";
                cbotipo_consistencia.DataBind();
                cbotipo_consistencia.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_digestabilidad()
        {
            try
            {

                List<Utilidades> lista_tipo_digestabilidad = new UtilidadesNE().Cargartipo_digestabilidad();
                cbotipo_digestabilidad.DataSource = lista_tipo_digestabilidad;
                cbotipo_digestabilidad.DataTextField = "_Nom_tipo_digestabilidad";
                cbotipo_digestabilidad.DataValueField = "_Cod_tipo_digestabilidad";
                cbotipo_digestabilidad.DataBind();
                cbotipo_digestabilidad.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }


        protected void Cargar_tipo_aporte_nutrientes()
        {
            try
            {

                List<Utilidades> lista_tipo_aporte_nutrientes = new UtilidadesNE().Cargartipo_aporte_nutrientes();
                cbotipo_aporte_nutrientes.DataSource = lista_tipo_aporte_nutrientes;
                cbotipo_aporte_nutrientes.DataTextField = "_Nom_tipo_aporte_nutrientes";
                cbotipo_aporte_nutrientes.DataValueField = "_Cod_tipo_aporte_nutrientes";
                cbotipo_aporte_nutrientes.DataBind();
                cbotipo_aporte_nutrientes.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_volumen()
        {
            try
            {

                List<Utilidades> lista_tipo_volumen = new UtilidadesNE().Cargartipo_volumen();
                cbotipo_volumen.DataSource = lista_tipo_volumen;
                cbotipo_volumen.DataTextField = "_Nom_tipo_volumen";
                cbotipo_volumen.DataValueField = "_Cod_tipo_volumen";
                cbotipo_volumen.DataBind();
                cbotipo_volumen.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_temperatura()
        {
            try
            {

                List<Utilidades> lista_tipo_temperatura = new UtilidadesNE().Cargartipo_temperatura();
                cbotipo_temperatura.DataSource = lista_tipo_temperatura;
                cbotipo_temperatura.DataTextField = "_Nom_tipo_temperatura";
                cbotipo_temperatura.DataValueField = "_Cod_tipo_temperatura";
                cbotipo_temperatura.DataBind();
                cbotipo_temperatura.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }


        protected void Cargar_tipo_sales()
        {
            try
            {

                List<Utilidades> lista_tipo_sales = new UtilidadesNE().Cargartipo_sales();
                cbotipo_sales.DataSource = lista_tipo_sales;
                cbotipo_sales.DataTextField = "_Nom_tipo_sales";
                cbotipo_sales.DataValueField = "_Cod_tipo_sales";
                cbotipo_sales.DataBind();
                cbotipo_sales.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_otros()
        {
            try
            {

                List<Utilidades> lista_tipo_otros = new UtilidadesNE().Cargartipo_otros();
                cbotipo_otros.DataSource = lista_tipo_otros;
                cbotipo_otros.DataTextField = "_Nom_tipo_otros";
                cbotipo_otros.DataValueField = "_Cod_tipo_otros";
                cbotipo_otros.DataBind();
                cbotipo_otros.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }




        #endregion


        #region Botones


        protected void btncancelar(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnsiguiente(object sender, System.Web.UI.ImageClickEventArgs e)
        {

            string   res_2 = new PedidosNE().Eliminar_Nutrientes(Convert.ToInt32(cod_pedido));
            string res = "";
            string consistencia = cbotipo_consistencia.SelectedValue;
            string digestabilidad = cbotipo_digestabilidad.SelectedValue;
            string aporte_nutrientes = cbotipo_aporte_nutrientes.SelectedValue;
            string volumen = cbotipo_volumen.SelectedValue;
            string temperatura = cbotipo_temperatura.SelectedValue;
            string tipo_sales = cbotipo_sales.SelectedValue;
            string tipo_otros = cbotipo_otros.SelectedValue;
            string diagnostico = Request.Form["txtdiagnostico"];
            string amnesis = Request.Form["txtamnesis"];
            string observacion = Request.Form["txtobservacion"];

            if (cod_pedido.Equals("") || cod_pedido.Equals("0"))
            {

              string msg = new PedidosNE().Registrar_Pedido(consistencia, digestabilidad, aporte_nutrientes, volumen,
                temperatura, tipo_sales, tipo_otros, diagnostico, amnesis, observacion,user,cod_cama,cod_paciente);

            Session["_Cod_pedido"] = msg;

            foreach (GridViewRow gvrow in grillanutrientes.Rows)
            {
                string codigo;

                codigo = grillanutrientes.DataKeys[gvrow.RowIndex]["_Cod_tipo_nutrientes"].ToString();
                CheckBox chkSelect = (CheckBox)gvrow.FindControl("chk");
                if (chkSelect.Checked)
                {

                     res =new PedidosNE().Registrar_Nutrientes(Convert.ToInt32(msg),codigo);
                }

            }

            }

            else{

                string msg = new PedidosNE().Modificar_Pedido(cod_pedido,consistencia, digestabilidad, aporte_nutrientes, volumen,
                temperatura, tipo_sales, tipo_otros, diagnostico, amnesis, observacion,user,cod_cama,cod_paciente);


                verificar_nutrientes();

                foreach (GridViewRow gvrow in grillanutrientes.Rows)
                {
                    string codigo;

                    codigo = grillanutrientes.DataKeys[gvrow.RowIndex]["_Cod_tipo_nutrientes"].ToString();
                    CheckBox chkSelect = (CheckBox)gvrow.FindControl("chk");
                    if (chkSelect.Checked)
                    {
                        string estado="S";
                        res = new PedidosNE().Modificar_Nutrientes(Convert.ToInt32(cod_pedido), codigo,estado);
                    }
                   


                }
       
            }

            Response.Redirect("Guardar_Pedido.aspx");
        }

        protected void verificar_nutrientes()
        {

                 foreach (GridViewRow gvrow in grillanutrientes.Rows)
               {
                string codigo;
                string id;
              //  id = grillanutrientes.DataKeys[gvrow.RowIndex]["_Id_tipo_nutrientes"].ToString();
                codigo = grillanutrientes.DataKeys[gvrow.RowIndex]["_Cod_tipo_nutrientes"].ToString();
                CheckBox chkSelect = (CheckBox)gvrow.FindControl("chk");
                if (chkSelect.Checked)
                {
   
                }
                else
                {
                    cambiar_vigencia(codigo);
                }

            }
        }

      protected void cambiar_vigencia(string codigo )
        {
            dtnutrientes =  (DataTable)Session["tabla_nutrientes"];
            foreach (DataRow row in dtnutrientes.Rows)
            {
                if (row["_Cod_tipo_nutrientes"].ToString() == codigo)
                {
                    row["_Est_tipo_nutrientes"] = "N";
                }           
            }
            Session["tabla_nutrientes"] = dtnutrientes;
        }

        protected void btnatras(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Buscar_Pacientes.aspx");
        }

        #endregion
    }
}