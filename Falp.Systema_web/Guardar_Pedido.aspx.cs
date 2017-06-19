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
using System.Configuration;
using Falp.Capa_Datos;

namespace Falp.Systema_web
{
    public partial class Guardar_Pedido : System.Web.UI.Page
    {
        #region Variables
        static string user = "";
        static string cod_cama = "";
        static string cod_paciente = "";
        static string cod_pedido = "";
        static string cod_tipo_alimento = "";
        static string cod_distribucion= "";
        static int cod_estado = 0;
        static string cod_alimento = "";
        static string cod_ali = "";
        string BD = ConfigurationManager.AppSettings["BD"];
        string User = ConfigurationManager.AppSettings["Usuario"];
        string Pass = ConfigurationManager.AppSettings["Pass"];

        

        DataTable dtalimentos = new DataTable();
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
                    txtfecha.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    btn_add.Visible = false;

                    
                    desabilitado();

                    //
                    Cargar_tipo_comida();
                    msg1.Text = "No existen Registros";


                    if (!cod_pedido.Equals("") || cod_pedido.Equals("0"))
                    {
                        Pedidos ped = new PedidosNE().Cargar_pedidos(Convert.ToInt32(cod_pedido));

                        /*   cbotipo_consistencia.SelectedIndex = ped._Cod_tipo_consistencia;
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
                           /*  transformar  una lista en datatable
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
                       }*/

                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                        Session["Usuario"] = "";
                    }


                }

            }
        }

        protected void habilitado()
        {
            cbotipo_distribucion.Enabled = true;
           
       
        }

        protected void desabilitado()
        {
            cbotipo_distribucion.Enabled = false;
            cbotipo_alimento.Enabled = false;
            txtcantidad.Enabled = false;
            btn_add.Visible = false;
            btn_guardar.Visible = false;
            btn_guardar1.Visible = false;
        }

        #region  grilla

         void Cargar_grilla()
        {
            string fecha=txtfecha.Text;
            int cod_tipo_comida=Convert.ToInt32(cbotipo_comida.SelectedValue);
            int cod_tipo_distribucion=Convert.ToInt32(cbotipo_distribucion.SelectedValue);
                List<Utilidades> lista_alimentos_menu = new UtilidadesNE().Cargar_alimentos_menu(fecha,cod_tipo_comida,cod_tipo_distribucion);

                dtalimentos = ConvertToDataTable(lista_alimentos_menu);
                Session["tabla_alimentos"] = dtalimentos;
                grillaalimentos.DataSource = lista_alimentos_menu;
                grillaalimentos.DataBind();

                if (dtalimentos.Rows.Count>0)
                {
                    msg1.Text = "";
                }
           
        }

         void Cargar_grilla_pedidos()
         {
             string fecha = txtfecha.Text;
             int cod_tipo_comida = Convert.ToInt32(cbotipo_comida.SelectedValue);
             int cod_tipo_distribucion = Convert.ToInt32(cbotipo_distribucion.SelectedValue);
             List<Pedidos> lista_alimentos_menu = new PedidosNE().Cargar_alimentos_pedidos(fecha, cod_tipo_comida, cod_tipo_distribucion,cod_pedido);

             dtalimentos = ConvertToDataTable(lista_alimentos_menu);
             Session["tabla_alimentos"] = dtalimentos;
             grillaalimentos.DataSource = lista_alimentos_menu;
             grillaalimentos.DataBind();

             if (dtalimentos.Rows.Count > 0)
             {
                 msg1.Text = "";
             }
             btn_guardar1.Visible = true;
             cbotipo_alimento.Enabled = true;
             txtcantidad.Enabled = true;
             btn_add.Visible = true;
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
        
        #region Cargar Combobox

        protected void Cargar_tipo_comida()
        {
            try
            {

                List<Utilidades> lista_tipo_comida = new UtilidadesNE().Cargartipo_comida();
                cbotipo_comida.DataSource = lista_tipo_comida;
                cbotipo_comida.DataTextField = "_Nom_tipo_comida";
                cbotipo_comida.DataValueField = "_Cod_tipo_comida";
                cbotipo_comida.DataBind();
                cbotipo_comida.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {

                System.Console.Write(ex.Message);
            }
        }

        protected void Cargar_tipo_distribucion()
        {
            try
            {
                int cod_tipo_comida = Convert.ToInt32(cbotipo_comida.SelectedValue);
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

        protected void cbotipo_distribucion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_tipo_alimento();
            string fecha = txtfecha.Text;
            int cod_tipo_comida = Convert.ToInt32(cbotipo_comida.SelectedValue);
            int cod_tipo_distribucion = Convert.ToInt32(cbotipo_distribucion.SelectedValue);

            int val = new PedidosNE().Validar_alimento_pedido(fecha, cod_tipo_comida, cod_tipo_distribucion,cod_pedido);

            if (val.Equals(0))
            {
                Cargar_grilla();
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

   
        #endregion


        #region Botones

        protected void btnagregar(object sender, System.Web.UI.ImageClickEventArgs e)
        {

            agregar();

        }

        protected void agregar()
        {
            int validar=validar_alimento();
            if(validar==0)
            {
            int cont = 0;
            string res = "ok";

            dtalimentos = (DataTable)Session["tabla_alimentos"];

            DataRow Fila = dtalimentos.NewRow();
            int _id_alimento = 0;
            int  _cod_alimento = Convert.ToInt32(cbotipo_alimento.SelectedValue);
            string _nom_alimento = Convert.ToString(cbotipo_alimento.SelectedItem);
            string _vigencia = "S";
            string _estado = "A";
            int _cantidad = Convert.ToInt32(txtcantidad.Text);
            //PBuscar Tipo Tecnica

            int cod_tipo_tecnica = 0;


            Fila["_Id_tipo_alimento"] = _id_alimento;
            Fila["_Id_tipo_distribucion"] = 0;
            Fila["_Cod_tipo_distribucion"] = 0;
            Fila["_Cod_tipo_alimento"] = _cod_alimento;
            Fila["_Nom_tipo_alimento"] = _nom_alimento.ToUpper();
            Fila["_Cantidad"] = _cantidad;
            Fila["_Vigencia"] = "S";
            Fila["_Estado"] = "A";


            dtalimentos.Rows.Add(Fila);
            grillaalimentos.AutoGenerateColumns = false;

            DataView DTW = new DataView(dtalimentos, "", string.Empty, DataViewRowState.CurrentRows);
            grillaalimentos.DataSource = DTW;     
            Session["tabla_alimentos"] = dtalimentos;
            grillaalimentos.DataBind();

            string res1 = "Estimado Usuario, Esta el alimento se ha agregado correctamente ";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1('" + res1 + "');", true);
            }

            else{

                string res1 = "Estimado Usuario, Esta el alimento ya se encuentra registrado ";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1('" + res1 + "');", true);

            }

        }


        protected int validar_alimento()
        {
            int var = 0;
            dtalimentos = (DataTable)Session["tabla_alimentos"];
            int cod_ali = Convert.ToInt32(cbotipo_alimento.SelectedValue);

            foreach (DataRow rx in dtalimentos.Select("_Cod_tipo_alimento = '" + cod_ali + "'"))
            //con_concepto2
            {
               
                var = 1;

            }

            return var;
        }



        protected void select_alimento(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            dtalimentos = (DataTable)Session["tabla_alimentos"];
             int cont = buscar_estado();
             if (cont.Equals(0))
             {
                 ImageButton btndetails = sender as ImageButton;
                 GridViewRow row = (GridViewRow)btndetails.NamingContainer;

                 cod_alimento = grillaalimentos.DataKeys[row.RowIndex]["_Cod_tipo_alimento"].ToString().Replace("&nbsp;", "");

                 string res = "Estimado Usuario, Esta seguro de seleccionar este Alimento ";
                 ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup2('" + res + "');", true);
                 
             }
           
        }

        protected void btn_select_alimento(object sender, EventArgs e)
        {
            cambiar_vigencia();
            
        }

        protected void btn_salir1(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btn_listado1(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Listado_Camas.aspx");
        }

        protected void btncancelar(object sender, System.Web.UI.ImageClickEventArgs e)
        {

            cbotipo_comida.SelectedIndex = 0;
            cbotipo_comida.Enabled = true;
            txtobservacion.Value = "";
        }

        protected void btncancelar2(object sender, System.Web.UI.ImageClickEventArgs e)
        {
        
            cbotipo_distribucion.SelectedIndex = 0;
            cbotipo_alimento.SelectedIndex = 0;
            txtcantidad.Text = "";
            dtalimentos.Clear();
            Cargar_grilla();
        }

        protected void btnsiguiente(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Cargar_tipo_distribucion();
            cbotipo_comida.Enabled = false;
            habilitado();
        }

   
       protected void  mostar_grilla()
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
             btn_add.Visible = true;
           
        }

        protected void cambiar_vigencia()
        {
           
           dtalimentos= (DataTable)Session["tabla_alimentos"];
            foreach (DataRow row in dtalimentos.Rows)
            {
                if (row["_Cod_tipo_alimento"].ToString() == cod_alimento)
                {
                    row["_Vigencia"] = "S";
                    row["_Estado"] = "S";
                    cbotipo_distribucion.Enabled = false;
                }
                else
                {
                    

                }

            }
            Session["tabla_alimentos"] = dtalimentos;
            mostar_grilla();
            grillaalimentos.Enabled = true;
            cbotipo_alimento.Enabled = true;
            txtcantidad.Enabled = true;
            btn_add.Visible = true;
            btn_guardar.Visible = true;
        }

        protected void btnatras(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Generar_Pedido.aspx");
        }

        protected void btnguardar(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int cont = buscar_estado();
           
           
            if (cont > 0)
            {
                string res1 = "Estimado Usuario, Esta Seguro de Guardar Este Pedido ";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup3('" + res1 + "');", true);
            }

            else
            {

                string res1 = "Estimado Usuario, No a seleccionado nungun elemento  dentro de la grilla";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup3('" + res1 + "');", true);
            }
          


        }


        protected void btnguardar1(object sender, System.Web.UI.ImageClickEventArgs e)
        {
             modificar_detalle_alimentos();


             if (cod_alimento=="ok")
             {
                 string res1 = "Estimado Usuario, El pedido se registrado correctamente";
                 ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup4('" + res1 + "');", true);
             }
             else
             {
                 string res1 = "Estimado Usuario, error al realizar pedido";
                 ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup4('" + res1 + "');", true);
             }
              

        }

        protected int buscar_estado()
        {
            int cont = 0;
            dtalimentos = (DataTable)Session["tabla_alimentos"];
            foreach (DataRow row in dtalimentos.Rows)
            {
                if (row["_Estado"].ToString() == "S")
                {
                    cont++;
                }

            }

            return cont;

        }  

        protected void btn_confirmar_pedido(object sender, EventArgs e)
        {
            ConectarFalp conn =new  ConectarFalp (BD, User, Pass, ConectarFalp.TipoBase.Oracle);
            if (conn.Estado == ConnectionState.Closed) conn.Abrir();

            try
            {
               conn.IniciarTransaccion();
            
                    guardar_detalle_tipo_comida();
                    guardar_detalle_distribucion();
                    guardar_detalle_alimentos();

                    conn.ConfirmarTransaccion();
                    conn.Cerrar();

                    if (Convert.ToInt32(cod_alimento) > 0)
                    {
                        string res1 = "Estimado Usuario, El pedido se registrado correctamente";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup4('" + res1 + "');", true);
                    }
                    else
                    {
                        string res1 = "Estimado Usuario, error al realizar pedido";
                        ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup4('" + res1 + "');", true);
                    }

                 }
            catch (Exception ex)
            {
                string res1 = ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup4('" + res1 + "');", true);
                conn.ReversarTransaccion();
            
            }
                
             
        }

    


      

        #endregion


        #region Guardar_Pedido

       protected void guardar_detalle_tipo_comida()
       {
           int cod_tipo = Convert.ToInt32(cbotipo_comida.SelectedValue);
           int cod = Convert.ToInt32(cod_pedido);
           cod_tipo_alimento = new Menu_tipo_comidaNE().Registrar_Tipo_Comida(cod, cod_tipo, user, txtfecha.Text);

       }

       protected void guardar_detalle_distribucion()
       {
           int cod_distri = Convert.ToInt32(cbotipo_distribucion.SelectedValue);
           int cod = Convert.ToInt32(cod_tipo_alimento);
           cod_distribucion = new Menu_tipo_distribucionNE().Registrar_Tipo_Distribucion(cod, cod_distri, user, txtfecha.Text);

       }

       protected void guardar_detalle_alimentos()
       {


           dtalimentos = (DataTable)Session["tabla_alimentos"];
           foreach (DataRow row in dtalimentos.Rows)
           {
               int cod_dis = Convert.ToInt32(cod_distribucion);
               int cod_ali = Convert.ToInt32(row["_Cod_tipo_alimento"].ToString());
               int cant = Convert.ToInt32(row["_Cantidad"].ToString());
               string vig = row["_Vigencia"].ToString();
               string est = row["_Estado"].ToString();
               cod_alimento = new Menu_tipo_alimentosNE().Registrar_Tipo_Alimento(cod_dis, cod_ali, cant, vig, est, user, txtfecha.Text, cod_cama);

           }

       }

        #endregion


        #region  Modificar_Pedido


       protected void modificar_detalle_alimentos()
       {

           int cont = 0;
           int var = 0;
           dtalimentos = (DataTable)Session["tabla_alimentos"];
           foreach (DataRow row in dtalimentos.Rows)
           {

               int id_ali = Convert.ToInt32(row["_Id_tipo_alimento"].ToString());
               int cod_dis = Convert.ToInt32(row["_Id_tipo_distribucion"].ToString());
               int cod_ali = Convert.ToInt32(row["_Cod_tipo_alimento"].ToString());
               int cant = Convert.ToInt32(row["_Cantidad"].ToString());
               string vig = row["_Vigencia"].ToString();
               string est = row["_Estado"].ToString();

               if (cont == 0)
               {
                   var = cod_dis;
               }
               else
               {
                   if (cod_dis == 0)
                   {
                       cod_dis = var;
                       cod_alimento = new Menu_tipo_alimentosNE().Registrar_Tipo_Alimento(cod_dis, cod_ali, cant, vig, est, user, txtfecha.Text);
                   }
                   else
                   {
                       var = cod_dis;
                       cod_alimento = new Menu_tipo_alimentosNE().Modificar_Tipo_Alimento(cod_dis, cod_ali, cant, vig, est, user, txtfecha.Text);
                   }

               }


               cont++;
           }

       }

        #endregion 


    }
}