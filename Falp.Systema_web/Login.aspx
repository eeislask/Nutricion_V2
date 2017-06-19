<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Falp.Systema_web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login Nutriciòn</title>
        <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <link href="Css/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="Css/dialog.css" rel="stylesheet" type="text/css" />

     
    <script type="text/javascript">

      function ShowPopup1(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Mensaje",
                    width: "400px",
                    height: "150",
                    buttons: {

                        Aceptar: function () {
                            $(this).dialog('close');
                           

                        }
                    },
                    modal: true
                });
                $("#dialog").parent().appendTo($("form:first"));
            });
        };
        </Script>

</head>
<body>
    <form id="form1" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="contenedor1">
    	<div class="header">
           <div class="Logo">
         
               <img src="Imagenes/Login/falp.png" width="60px" height="60px"  />
                <div class="subsistema"></div>
            </div>
    	    <div class="Titulo">
    		    <h1>Sistema Nutriciòn</h1> </div>
            
            <div class="sesion">             
                <asp:Label ID="Label5" runat="server" Text="USUARIO :" ></asp:Label>
                <asp:Label ID="nombre" runat="server" ></asp:Label><br />
                <asp:Label ID="Label10" runat="server" Text="SALIR :" ></asp:Label>  <asp:ImageButton ID="ImageButton3" ImageUrl="~/Imagenes/Botones/cerrar.png" runat="server"   Width="20px" Height="20px" ToolTip="Salir del Sistema"       />
            </div>
              
         </div>
         </div>
       <div class="contenedor2">
          <div  class="contenido">
             <div  class="for_login">

                <div  class="Titulo">
                  Login 
                </div>

                <div  class="img">
                <center>
                    <img src="Imagenes/Login/log_trans.png" width="150px" height="150px" alt="login"  />
                   
                    </center>
                </div>

               
                  <div  class="bloque">
                      <label> <asp:Label ID="lab1" runat="server" Text="Usuario" ></asp:Label>  </label>  <input id="txtusuario" name="txtusuario" type="text" runat="server" placeholder="Nombre"  class="tex"   />
                </div>
               
                  <div  class="bloque">
                    <label> <asp:Label ID="Label1" runat="server" Text="Password" ></asp:Label> </label> <input id="txtpassword"  name="txtpassword" type="password" runat="server" placeholder="Password"  class="tex"  />
                </div>

                <div class="pos">

                   <asp:ImageButton ID="ImageButton1" ImageUrl="~/Imagenes/Botones/ingresar.png" runat="server"
                    Width="48px" Height="48px" ToolTip="Acceder al Sistema" OnClick="ingresar" />
                       <asp:ImageButton ID="ImageButton2" ImageUrl="~/Imagenes/Botones/actualizar.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Limpiar" OnClick="cancelar" />
                
                </div>



                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div id="dialog" style="display: none">
                 
      
               </div>
            </ContentTemplate>
        </asp:UpdatePanel>
         
         
             </div>
          </div>







      </div>

    </form>
</body>
</html>

