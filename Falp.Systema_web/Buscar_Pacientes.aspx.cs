using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falp.Entidades;
using Falp.Capa_Negocios;
using System.ComponentModel;

namespace Falp.Systema_web
{
    public partial class Buscar_Pacientes : System.Web.UI.Page
    {
        #region Variables
        string user = "";
        string paciente = "";
       static int pedido = 0;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();
                    paciente = Session["_Cod_paciente"].ToString();
                    nombre.Text = user.ToUpper();
                    Cargar_tipo_busqueda();
                    Cargar_tipo_documento();
                    pedido=validar_pedido();
                    if (paciente.Equals("") || pedido.Equals(0))
                    {
                        deshabilitar();
                    }
                    else
                    {
                        habilitar();

                        Pacientes pac = new PacientesNE().Cargar_paciente(paciente);
                        txtficha.Value = Convert.ToString(pac._Ficha);
                        txtfolio.Value = Convert.ToString(pac._Folio);
                        cbotipo_doc.SelectedIndex = Convert.ToInt32(pac._Tipo_doc);
                        txtnum_doc.Value = Convert.ToString(pac._Num_doc);
                        txtnombre.Value = Convert.ToString(pac._Nombres);
                        btn_limpiar_busqueda.Visible = false;
                        btn_tipo_buscar.Visible = false;
                  
                    }

                    Session["_Cod_pedido"] = Convert.ToString(pedido);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                    Session["Usuario"] = "";
                }

            }

        }

        #region metodo generales

        void habilitar()
        {
            txtfiltro.MaxLength = 0;
            cbotipo_busqueda.Enabled = false;
            btn_limpiar.Visible = false;
            btn_next.Visible = true;
        }

          void deshabilitar()
        {
            btnguardar.Visible = false;
            btn_limpiar.Visible = false;
            btn_next.Visible = false;
            txtficha.Disabled = false;
            cbotipo_doc.Enabled = false;
        }

        #endregion

        #region Cargar Combobox

          protected void  Cargar_tipo_busqueda()
         {
             try
             {

                 List<Utilidades>  lista_tipo_busqueda = new UtilidadesNE().Cargartipo_bus();
                 cbotipo_busqueda.DataSource = lista_tipo_busqueda;
                 cbotipo_busqueda.DataTextField = "_Nom_tipo_bus";
                 cbotipo_busqueda.DataValueField = "_Cod_tipo_bus";
                 cbotipo_busqueda.DataBind();
                 cbotipo_busqueda.Items.Insert(0, new ListItem("Seleccionar", "0"));
             }

             catch (Exception ex)
             {

                 System.Console.Write(ex.Message);
             }
         }

        protected void Cargar_tipo_documento()
        {
            try
            {

                List<Utilidades> lista_tipo_doc = new UtilidadesNE().Cargartipo_doc();
                cbotipo_doc.DataSource = lista_tipo_doc;
                cbotipo_doc.DataTextField = "_Nom_tipo_doc";
                cbotipo_doc.DataValueField = "_Cod_tipo_doc";
                cbotipo_doc.DataBind();
                cbotipo_doc.Items.Insert(0, new ListItem("Seleccionar", "0"));

                cbotipo_doc2.DataSource = lista_tipo_doc;
                cbotipo_doc2.DataTextField = "_Nom_tipo_doc";
                cbotipo_doc2.DataValueField = "_Cod_tipo_doc";
                cbotipo_doc2.DataBind();
                cbotipo_doc2.Items.Insert(0, new ListItem("Seleccionar", "0"));
            }

            catch (Exception ex)
            {
                List<Utilidades> lista_tipo_doc = new UtilidadesNE().Cargartipo_doc();
                System.Console.Write(ex.Message);
            }
        }


        #endregion


        #region Validaciones

        protected int  validar_pedido()
        {
            int var = 0;
            int var2 = 0;

            if (paciente=="" || paciente==null)
            {
                var2 = 0;
            }
            else
            {
                var2 =Convert.ToInt32(paciente);
            }
            int cod_paciente = Convert.ToInt32(var2);
            Pedidos ped = new PedidosNE().Cargar_pedidos2(cod_paciente);
            var = ped._Id;
            return var;
        }

        #endregion


        #region Limpiar

        void limpiar_formulario()
        {
              txtficha.Value = "";
                txtfolio.Value = "";
                cbotipo_doc.SelectedIndex = 0;
                txtnum_doc.Value = "";
                txtnombre.Value = "";
        }


        #endregion 


        #region Botones

        protected void btnbuscar(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            int id = 0;
            string tipo = cbotipo_busqueda.SelectedValue; 
            string filtro = Request.Form["txtfiltro"];

            Pacientes pac = new PacientesNE().Cargar_paciente(Convert.ToInt32(tipo),filtro);
            id = pac._Id_pac;
            if (id > 0)
            {
                txtficha.Value = Convert.ToString(pac._Ficha);
                txtfolio.Value = Convert.ToString(pac._Folio);
                cbotipo_doc.SelectedIndex = Convert.ToInt32(pac._Tipo_doc);
                txtnum_doc.Value = Convert.ToString(pac._Num_doc);
                txtnombre.Value = Convert.ToString(pac._Nombres);
                Session["_Cod_paciente"] = pac._Id_pac;
                habilitar();
                cbotipo_doc.Enabled = false;

            }
            else
            {
              limpiar_formulario();
                string res = "Estimado Usuario, El Paciente no se encontro en la Base de datos, Desea Registrarlo ?";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup2('" + res + "');", true);
            }
        }

        protected void btn_salir(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnsiguiente(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            cbotipo_busqueda.SelectedIndex = 0;
            txtfiltro.Value = "";
            Response.Redirect("Generar_Pedido.aspx");
        }

        protected void btncancelar(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Generar_Pedido.aspx");
        }

        protected void btncancelar1(object sender, System.Web.UI.ImageClickEventArgs e)
        {
           limpiar_formulario();
        }
        protected void btn_listado(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Listado_Camas.aspx");
        }

        protected void btn_registrar_paciente(object sender, EventArgs e)
        {

            //string res = "Estimado Usuario, Ingrese la informaciòn del Paciente ";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup1();", true);
        }

        protected void btn_guardar(object sender, EventArgs e)
        {

           string ficha= Request.Form["txtficha2"];
           string folio = Request.Form["txtfolio2"];
           string tipo_doc = cbotipo_doc2.SelectedValue;
           string num_doc = Request.Form["txtnum_doc2"];
           string nombres = Request.Form["txtnombres2"];


           string msg = new PacientesNE().Registrar_Paciente(ficha, folio, tipo_doc, num_doc, nombres);

           if (Convert.ToInt32(msg)>0)
           {
               string res = "Estimado Usuario, La Paciente se ha registrado correctamente";
               ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + res + "');", true);

               txtficha.Value = ficha;
               txtfolio.Value = folio;
               cbotipo_doc.SelectedIndex = Convert.ToInt32(tipo_doc);
               txtnum_doc.Value = num_doc;
               txtnombre.Value = nombres;
               cbotipo_busqueda.SelectedIndex = 0;
               txtfiltro.Value = "";
               Session["_Cod_paciente"]=msg;
               habilitar();

           }
           else
           {
               string res = "Estimado Usuario, error al registrar el paciente";
               ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + res + "');", true);
           }
        }
      

        #endregion

    }
}