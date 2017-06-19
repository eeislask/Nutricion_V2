using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Falp.Oficial
{
    public partial class Home1 : System.Web.UI.Page
    {

        #region Variables

        string user = "";

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session["Usuario"] != null)
                {

                    user = Session["Usuario"].ToString();
                    txtusuario.Text = user.ToUpper();
                    //nombre.Text = user.ToUpper();

                }
                else
                {
                    Response.Redirect("Login.aspx");
                    Session["Usuario"] = "";
                }

            }
        }

        protected void ingresar(object sender, EventArgs e)
        {
            Response.Redirect("Listado_Camas.aspx");

        }



    }
}