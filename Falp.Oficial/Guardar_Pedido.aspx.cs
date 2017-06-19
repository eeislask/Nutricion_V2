using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Data;

namespace Falp.Oficial
{
    public partial class Guardar_Pedido : System.Web.UI.Page
    {
        #region Variables

        string user = "";
        static string cod_cama = "";
        static string cod_paciente = "";
        static string cod_pedido = "";
        static string nom_paciente = "";
        static string cod_alimento = "";
        static int cod_estado_alimento = 0;

        static int cod_regimen  = 0;
        static int cod_aislamiento = 0;
        static int cod_bandeja = 0;


        static int cod_tipo_comida = 0;
        DataTable dtalimentos = new DataTable();
        DataTable dtextra = new DataTable();
        DataTable dtextra_extra = new DataTable();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();
                    txtalimento.Text = Session["Tipo_Alimento"].ToString();
                  
                    txtnombre2.Value = Session["Nom_Paciente"].ToString();
                    cod_pedido = Session["_Cod_pedido"].ToString();
                    cod_bandeja = Convert.ToInt32(Session["Bandeja"].ToString());
                    cod_aislamiento=Convert.ToInt32(Session["Aislamiento"].ToString());
                    cod_regimen = Convert.ToInt32(Session["Regimen"].ToString());
       
                    cod_tipo_comida=Convert.ToInt32(Session["Cod_Tipo_Alimento"].ToString());
                    Cargar_tipo_distribucion();
                    btn_extra_extra1.Visible = false;
                    btn_select_ext1.Visible = false;
                    cod_estado_alimento = 0;
                    Cargar_tipo_consistencia();
                    Cargar_tipo_digestabilidad();
                    Cargar_tipo_dulzor();
                    Cargar_tipo_lactosa();
                    Cargar_tipo_sal();
                    Cargar_tipo_temperatura();
                    Cargar_tipo_volumen();
                }
                else
                {
                    Response.Redirect("index.aspx");
                    Session["Usuario"] = "";
                }

            }
  
        }

        protected void volver(object sender, EventArgs e)
        {
            Response.Redirect("Generar_Pedido.aspx");
            Session["Tipo_Alimento"] = string.Empty;
        }

        protected void agregar(object sender, EventArgs e)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { agregar_alimentos(); });", true);
        }


        protected void Cargar_tipo_distribucion()
        {
            try
            {
                
                List<Utilidades> lista_tipo_distribucion = new UtilidadesNE().Cargartipo_distribucion(cod_tipo_comida);
                cbotipo_distribucion.DataSource = lista_tipo_distribucion;
                cbotipo_distribucion.DataTextField = "_Nom_tipo_distribucion";
                cbotipo_distribucion.DataValueField = "_Cod_tipo_distribucion";
                cbotipo_distribucion.DataBind();
                cbotipo_distribucion.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_consistencia()
        {
            try
            {

                List<Utilidades> lista_tipo_consistencia = new UtilidadesNE().Cargartipo_consistencia();
                cboconsistencia.DataSource = lista_tipo_consistencia;
                cboconsistencia.DataTextField = "_Nom_tipo_consistencia";
                cboconsistencia.DataValueField = "_Cod_tipo_consistencia";
                cboconsistencia.DataBind();
                cbotipo_distribucion.Items.Insert(0, new ListItem("Seleccionar", "0"));
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
                cbodigestabilidad.DataSource = lista_tipo_digestabilidad;
                cbodigestabilidad.DataTextField = "_Nom_tipo_digestabilidad";
                cbodigestabilidad.DataValueField = "_Cod_tipo_digestabilidad";
                cbodigestabilidad.DataBind();
                cbodigestabilidad.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }


        protected void Cargar_tipo_sal()
        {
            try
            {

                List<Utilidades> lista_tipo_sales = new UtilidadesNE().Cargartipo_sales();
                cbotipo_sal.DataSource = lista_tipo_sales;
                cbotipo_sal.DataTextField = "_Nom_tipo_sales";
                cbotipo_sal.DataValueField = "_Cod_tipo_sales";
                cbotipo_sal.DataBind();
                cbotipo_sal.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }


    


        protected void Cargar_tipo_dulzor()
        {
            try
            {

                List<Utilidades> lista_tipo_dulzor = new UtilidadesNE().Cargartipo_dulzor();
                cbodulzor.DataSource = lista_tipo_dulzor;
                cbodulzor.DataTextField = "_Nom_dulzor";
                cbodulzor.DataValueField = "_Cod_dulzor";
                cbodulzor.DataBind();
                cbodulzor.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }




        protected void Cargar_tipo_lactosa()
        {
            try
            {

                List<Utilidades> lista_tipo_lactosa = new UtilidadesNE().Cargartipo_lactosa();
                cbolactosa.DataSource = lista_tipo_lactosa;
                cbolactosa.DataTextField = "_Nom_lactosa";
                cbolactosa.DataValueField = "_Cod_lactosa";
                cbolactosa.DataBind();
                cbolactosa.Items.Insert(0, new ListItem("Seleccionar", "0"));
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

                List<Utilidades> lista_tipo_termperatura = new UtilidadesNE().Cargartipo_temperatura();
                cbotemperatura.DataSource = lista_tipo_termperatura;
                cbotemperatura.DataTextField = "_Nom_tipo_temperatura";
                cbotemperatura.DataValueField = "_Cod_tipo_temperatura";
                cbotemperatura.DataBind();
                cbotemperatura.Items.Insert(0, new ListItem("Seleccionar", "0"));
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
                cbovolumen.DataSource = lista_tipo_volumen;
                cbovolumen.DataTextField = "_Nom_tipo_volumen";
                cbovolumen.DataValueField = "_Cod_tipo_volumen";
                cbovolumen.DataBind();
                cbovolumen.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }


        #region  grilla


        void Cargar_grilla_extra_extra()
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");

            int cod_tipo_distribucion = Convert.ToInt32(cbotipo_distribucion.SelectedValue);
            List<Utilidades> lista_alimentos_menu_extra_extra = new UtilidadesNE().Cargar_alimentos_menu_extra_extra(cod_tipo_distribucion);

            dtextra_extra = ConvertToDataTable(lista_alimentos_menu_extra_extra);
            /* Session["tabla_alimentos"] = dtalimentos;
             grillaalimentos.DataSource = lista_alimentos_menu_extra;
             grillaalimentos.DataBind();*/

            if (dtalimentos.Rows.Count > 0)
            {
                // msg1.Text = "";
            }

        }


        void Cargar_grilla_extra()
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");

            int cod_tipo_distribucion = Convert.ToInt32(cbotipo_distribucion.SelectedValue);
            List<Utilidades> lista_alimentos_menu_extra = new UtilidadesNE().Cargar_alimentos_menu_extra(fecha, cod_tipo_comida, cod_tipo_distribucion);

            dtextra = ConvertToDataTable(lista_alimentos_menu_extra);
           /* Session["tabla_alimentos"] = dtalimentos;
            grillaalimentos.DataSource = lista_alimentos_menu_extra;
            grillaalimentos.DataBind();*/

            if (dtalimentos.Rows.Count > 0)
            {
                // msg1.Text = "";
            }

        }

        void Cargar_grilla()
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");

            int cod_tipo_distribucion = Convert.ToInt32(cbotipo_distribucion.SelectedValue);
            List<Utilidades> lista_alimentos_menu = new UtilidadesNE().Cargar_alimentos_menu(fecha, cod_tipo_comida, cod_tipo_distribucion);

            dtalimentos = ConvertToDataTable(lista_alimentos_menu);
            Session["tabla_alimentos"] = dtalimentos;
            grillaalimentos.DataSource = lista_alimentos_menu;
            grillaalimentos.DataBind();

            if (dtalimentos.Rows.Count > 0)
            {
               // msg1.Text = "";
            }

        }

        void Cargar_grilla_pedidos()
        {
            //string fecha = txtfecha.Text;
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            int cod_tipo_distribucion = Convert.ToInt32(cbotipo_distribucion.SelectedValue);
            List<Pedidos> lista_alimentos_menu = new PedidosNE().Cargar_alimentos_pedidos(fecha, cod_tipo_comida, cod_tipo_distribucion, cod_pedido);

            dtalimentos = ConvertToDataTable(lista_alimentos_menu);
            Session["tabla_alimentos"] = dtalimentos;
            grillaalimentos.DataSource = lista_alimentos_menu;
            grillaalimentos.DataBind();

            if (dtalimentos.Rows.Count > 0)
            {
               // msg1.Text = "";
            }
         //   btn_guardar1.Visible = true;
            cbotipo_alimento.Enabled = true;
         /*   txtcantidad.Enabled = true;
            btn_add.Visible = true;*/
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

        protected void grillaalimentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grillaalimentos.PageIndex = e.NewPageIndex;
            grillaalimentos.DataBind();
            Cargar_grilla();


        }
        #endregion 


        protected void cbotipo_distribucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_tipo_alimento();
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");

            int cod_tipo_distribucion = Convert.ToInt32(cbotipo_distribucion.SelectedValue);

            int val = new PedidosNE().Validar_alimento_pedido(fecha, cod_tipo_comida, cod_tipo_distribucion, cod_pedido);

            if (val.Equals(0))
            {
                 Cargar_grilla();
                Cargar_grilla_extra();


                if (dtextra.Rows.Count > 0)
                {
                    btn_select_ext1.Visible = true;
                    btn_extra_extra1.Visible = false;

                    grillaalimentos.DataSource = dtextra;
                    grillaalimentos.DataBind();
                }
                else
                {
                    btn_select_ext1.Visible = false;
                    btn_extra_extra1.Visible = true;

                }
            }
            else
            {
                Cargar_grilla_pedidos();
            }

        }

        protected void Cargar_tipo_alimento()
        {
            try
            {

                int cod_tipo_distribucion = Convert.ToInt32(cbotipo_distribucion.SelectedValue);
                List<Utilidades> lista_tipo_alimento = new UtilidadesNE().Cargartipo_alimento(cod_tipo_distribucion);
                cbotipo_alimento.DataSource = lista_tipo_alimento;
                cbotipo_alimento.DataTextField = "_Nom_tipo_alimento";
                cbotipo_alimento.DataValueField = "_Cod_tipo_alimento";
                cbotipo_alimento.DataBind();
                cbotipo_alimento.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void select_alimento(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            dtalimentos = (DataTable)Session["tabla_alimentos"];
            int cont = buscar_estado();
            if (cont > 0)
            {
                ImageButton btndetails = sender as ImageButton;
                GridViewRow row = (GridViewRow)btndetails.NamingContainer;

                cod_alimento = grillaalimentos.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString().Replace("&nbsp;", "");
                txtdistribucion.Value = cbotipo_distribucion.SelectedItem.ToString();
                txtalimento1.Value = row.Cells[1].Text.Trim();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "LaunchServerSide", "$(function() { info(); });", true);
               
            }
       
           
          
           
        }

        protected int buscar_estado()
        {
            int cont = 0;
            dtalimentos = (DataTable)Session["tabla_alimentos"];
            foreach (DataRow row in dtalimentos.Rows)
            {
                if (row["_Estado"].ToString() == "S" || row["_Estado"].ToString() == "" || row["_Estado"].ToString() == null)
                {
                    cont++;
                }

            }

            return cont;

        }

        protected void btn_select_alimento(object sender, EventArgs e)
        {
            cambiar_vigencia();
        }

        protected void btn_select_extra(object sender, EventArgs e)
        {
            dtalimentos.Clear();
            dtalimentos.AcceptChanges();
            grillaalimentos.DataSource = dtalimentos;
            grillaalimentos.DataBind();

            Session["tabla_alimentos"] = dtalimentos;
            Cargar_grilla_extra();


            if (dtextra.Rows.Count > 0)
            {
                btn_select_ext1.Visible = true;
                btn_extra_extra1.Visible = false;

                grillaalimentos.DataSource = dtextra;
                Session["tabla_alimentos"] = dtextra;
                grillaalimentos.DataBind();
            }
            else
            {
                btn_select_ext1.Visible = false;
                btn_extra_extra1.Visible = true;

            }

            cod_estado_alimento = 2;
        }

        protected void btn_select_extra_extra(object sender, EventArgs e)
        {
            dtalimentos.Clear();
            dtalimentos.AcceptChanges();
            grillaalimentos.DataSource = dtalimentos;
            grillaalimentos.DataBind();

            Session["tabla_alimentos"] = dtalimentos;
            Cargar_grilla_extra_extra();


            if (dtextra_extra.Rows.Count > 0)
            {
                btn_select_ext1.Visible = false;
                btn_extra_extra1.Visible = false;

                grillaalimentos.DataSource = dtextra_extra;
                Session["tabla_alimentos"] = dtextra_extra;
                grillaalimentos.DataBind();
            }

            cod_estado_alimento = 3;
         
        }

        protected void mostar_grilla()
        {
            dtalimentos = (DataTable)Session["tabla_alimentos"];

            // foreach (DataRow rx in dt1.Select("_Nom_concepto = '" + concepto2.Text.Trim() + "'"))
            foreach (DataRow rx in dtalimentos.Select("_Cod_tipo_alimento <> '" + cod_alimento + "'"))
            //con_concepto2
            {
                rx.Delete();

            }
            dtalimentos.AcceptChanges();

            Session["tabla_alimentos"] = dtalimentos;
            grillaalimentos.DataSource = dtalimentos;
            grillaalimentos.DataBind();


        }

        protected void cambiar_vigencia()
        {

            dtalimentos = (DataTable)Session["tabla_alimentos"];
            foreach (DataRow row in dtalimentos.Rows)
            {
                if (row["_Cod_tipo_alimento"].ToString() == cod_alimento)
                {
                    if (cod_estado_alimento == 0)
                    {
                        row["_Vigencia"] = "S";
                        row["_Estado"] = "SM";
                        cbotipo_distribucion.Enabled = false;
                        btn_select_ext1.Visible = false;
                        btn_extra_extra1.Visible = false;

                    }
                    else
                    {
                        if (cod_estado_alimento == 2)
                        {
                            row["_Vigencia"] = "S";
                            row["_Estado"] = "SE";
                            cbotipo_distribucion.Enabled = false;
                            btn_select_ext1.Visible = false;                     
                            btn_extra_extra1.Visible = false;
                        }

                        else
                        {
                            row["_Vigencia"] = "S";
                            row["_Estado"] = "SEE";
                            cbotipo_distribucion.Enabled = false;
                            btn_select_ext1.Visible = false;
                            btn_extra_extra1.Visible = false;

                        }

                    }
                }
                else
                {


                }

            }
            Session["tabla_alimentos"] = dtalimentos;
            mostar_grilla();
            grillaalimentos.Enabled = true;
            cbotipo_alimento.Enabled = true;

        }
    }
}