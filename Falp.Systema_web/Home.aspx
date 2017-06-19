<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Falp.Systema_web.Home" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Home Nutriciòn</title>
    <link href="Css/Estilo.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="contenedor1">
    	<div class="header">
           <div class="Logo">
         
               <img src="Imagenes/Login/falp.png" width="65px" height="65px" />
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
                  Bienvenido
                </div>

                <div  class="img">
                <center>
                    <img src="Imagenes/Imagenes/user.png" width="150px" height="150px" alt="login"  />
         
                    </center>
                </div>

               
                  <div  class="bloque">
                      <label> <asp:Label ID="lab1" runat="server" Text="Usuario" ></asp:Label>  </label>  <input id="txtusuario" type="text" runat="server" placeholder="Nombre"  class="tex"  readonly="true"  />
                </div>
               
                

                <div class="pos">
                  <asp:ImageButton ID="ImageButton1" ImageUrl="~/Imagenes/Botones/click.png" runat="server"
                    Width="48px" Height="48px" ToolTip="Acceder al Sistema" OnClick="ingresar" />
                
                </div>




         
         
             </div>
          </div>







      </div>

    </form>
</body>
</html>

