<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"   CodeBehind="Buscar_Pacientes.aspx.cs" Inherits="Falp.Systema_web.Buscar_Pacientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 
      <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
   
    <link href="Css/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="Css/dialog.css" rel="stylesheet" type="text/css" />
    <title>Home Nutriciòn</title>
  

    <script type="text/javascript">
        function validation1() {

            var combo1 = document.getElementById("<%=cbotipo_busqueda.ClientID%>")
            if (combo1.value == null || combo1.value == "0") {
                alert("Porfavor, seleccione el tipo busqueda correspondiente");
                document.getElementById("<%=cbotipo_busqueda.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=cbotipo_busqueda.ClientID%>").style.border = "";
            }

            var txt = document.getElementById("txtfiltro");
            if (txt.value == "" || txt.value == null) {
                alert("Porfavor, ingrese su filtro ");
                txt.style.border = "2px solid red";
                return false;
            }


            else {
                txt.style.border = "";

            }


            return true;
        }

        function validation2() {

            var txt = document.getElementById("txtficha2");
            if (txt.value == "" || txt.value == null) {
                alert("Porfavor, ingrese su ficha");
                txt.style.border = "2px solid red";
                return false;
            }


            else {
                txt.style.border = "";

            }

            var txt1 = document.getElementById("txtfolio2");
            if (txt1.value == "" || txt1.value == null) {
                alert("Porfavor, ingrese su folio");
                txt1.style.border = "2px solid red";
                return false;
            }


            else {
                txt1.style.border = "";

            }

            var combo1 = document.getElementById("<%=cbotipo_doc2.ClientID%>")
            if (combo1.value == null || combo1.value == "0") {
                alert("Porfavor, seleccione el tipo documento correspondiente");
                document.getElementById("<%=cbotipo_doc2.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=cbotipo_doc2.ClientID%>").style.border = "";
            }

            var txt3 = document.getElementById("txtnum_doc2");
            if (txt3.value == "" || txt.value == null) {
                alert("Porfavor, ingrese su Num Doc");
                txt3.style.border = "2px solid red";
                return false;
            }


            else {
                txt3.style.border = "";

            }

            var txt4 = document.getElementById("txtnombres2");
            if (txt4.value == "" || txt.value == null) {
                alert("Porfavor, ingrese su nombres completo");
                txt4.style.border = "2px solid red";
                return false;
            }


            else {
                txt4.style.border = "";

            }


            return true;
           
        }

        function ShowPopup2(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Mensaje",
                    width: "400px",
                    height: 150,
                    buttons: {

                        Si: function () {
                          
                            __doPostBack('<%= btnregistrar.ClientID %>', '');
                         
                        },

                        No: function () {
                            $(this).dialog('close');

                        }
                    },
                    modal: true
                });
                $("#dialog").parent().appendTo($("form:first"));
            });
        };




        function ShowPopup1() {
            $(function () {
                $("#dialog1").html();
                $("#dialog1").dialog({
                    title: "Mensaje",
                    resizable: false,
                    width: "450px",
                    height: 430,
                    buttons: {
                        Guardar: function () {
                            var txt = document.getElementById("txtficha2");
                            if (txt.value == "" || txt.value == null) {
                                alert("Porfavor, ingrese su ficha");
                                txt.style.border = "2px solid red";
                                return false;
                            }


                            else {
                                txt.style.border = "";

                            }

                            var txt1 = document.getElementById("txtfolio2");
                            if (txt1.value == "" || txt1.value == null) {
                                alert("Porfavor, ingrese su folio");
                                txt1.style.border = "2px solid red";
                                return false;
                            }


                            else {
                                txt1.style.border = "";

                            }

                            var combo1 = document.getElementById("<%=cbotipo_doc2.ClientID%>")
                            if (combo1.value == null || combo1.value == "0") {
                                alert("Porfavor, seleccione el tipo documento correspondiente");
                                document.getElementById("<%=cbotipo_doc2.ClientID%>").style.border = "2px solid red";
                                return false;
                            }
                            else {
                                document.getElementById("<%=cbotipo_doc2.ClientID%>").style.border = "";
                            }

                            var txt3 = document.getElementById("txtnum_doc2");
                            if (txt3.value == "" || txt.value == null) {
                                alert("Porfavor, ingrese su Num Doc");
                                txt3.style.border = "2px solid red";
                                return false;
                            }


                            else {
                                txt3.style.border = "";

                            }

                            var txt4 = document.getElementById("txtnombres2");
                            if (txt4.value == "" || txt.value == null) {
                                alert("Porfavor, ingrese su nombres completo");
                                txt4.style.border = "2px solid red";
                                return false;
                            }


                            else {
                                txt4.style.border = "";

                            }

                            __doPostBack('<%= btnguardar.ClientID %>', '');
                        },
                        Cancelar: function () {
                            $(this).dialog('close');

                        }
                    },
                    modal: true
                });
                $("#dialog1").parent().appendTo($("form:first"));
            });
        };

        function ShowPopup(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Mensaje",
                    resizable: false,
                    width: "450px",
                    height: "150",
                     position: 'center' ,
                    buttons: {

                        Aceptar: function () {
                            $(this).dialog('close');

                        }
                    },
                    modal: true
                });
                $("#dialog1").parent().appendTo($("form:first"));
            });
        };




</script>

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
                <asp:Label ID="Label10" runat="server" Text="SALIR :" ></asp:Label>  <asp:ImageButton ID="btn_" ImageUrl="~/Imagenes/Botones/cerrar.png" runat="server"   Width="20px" Height="20px" ToolTip="Salir del Sistema"  OnClick="btn_salir"     />
            </div>
              
         </div>
         </div>
       <div class="contenedor2">
          <div  class="contenido">
             <div  class="for_login">

                <div  class="Titulo">
                  Buscar Paciente
                </div>

             

               
                  <div  class="bloque">
                      <label> <asp:Label ID="lab1" runat="server" Text="Tipo Busqueda" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_busqueda" CssClass="tex" runat="server">  </asp:DropDownList>
                </div>
               
                  <div  class="bloque">
                    <label> <asp:Label ID="Label1" runat="server" Text="Filtro" ></asp:Label> </label> <input id="txtfiltro"  name="txtfiltro" type="text" runat="server" placeholder="Filtro"  class="tex"  />
                </div>

                <div class="pos">

                   <asp:ImageButton ID="btn_tipo_buscar" ImageUrl="~/Imagenes/Botones/buscar.png" runat="server"
                    Width="36px" Height="36px" ToolTip="Acceder al Sistema" OnClientClick="return validation1();"  OnClick="btnbuscar" />
                       <asp:ImageButton ID="btn_limpiar_busqueda" ImageUrl="~/Imagenes/Botones/refrescar.png" runat="server"
                    Width="36px" Height="36px" ToolTip="Limpiar" OnClick="btncancelar" />
                
                </div>

                 <div  class="bloque">
                    <label> <asp:Label ID="Label2" runat="server" Text="Ficha" ></asp:Label> </label> <input id="txtficha"  name="txtfolio" type="text" runat="server" placeholder="Ficha"  class="tex" readonly="true"  />
                </div>

                 <div  class="bloque">
                    <label> <asp:Label ID="Label3" runat="server" Text="Folio" ></asp:Label> </label> <input id="txtfolio"  name="txtfolio" type="text" runat="server" placeholder="Folio"  class="tex" readonly="true"   />
                </div>

               
                  <div  class="bloque">
                      <label> <asp:Label ID="Label6" runat="server" Text="Tipo Documento" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_doc" CssClass="tex" runat="server" readonly="true"  Width="150px">   <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
                  <div  class="bloque">
                    <label> <asp:Label ID="Label4" runat="server" Text="Num Documento" ></asp:Label> </label> <input id="txtnum_doc"  name="txtnum_doc" type="text" runat="server" placeholder="Num Doc."  class="tex"  readonly="true"  />
                </div>


                 <div  class="bloque">
                    <label> <asp:Label ID="Label7" runat="server" Text="Nombre Completo" ></asp:Label> </label> <input id="txtnombre"  name="txtnombre" type="text" runat="server" placeholder="Nombre Completo"  class="tex"  readonly="true"  />
                </div>


                   <div class="pos">

                    <asp:ImageButton ID="btn_atras" ImageUrl="~/Imagenes/Botones/atras.png" runat="server"
                    Width="36px" Height="36px" ToolTip="Limpiar" OnClick="btnsiguiente" />
                       <asp:ImageButton ID="btn_limpiar" ImageUrl="~/Imagenes/Botones/refrescar.png" runat="server"
                    Width="36px" Height="36px" ToolTip="Limpiar"  OnClick="btncancelar1" />
                        <asp:ImageButton ID="btn_next" ImageUrl="~/Imagenes/Botones/siguiente.png" runat="server"
                    Width="36px" Height="36px" ToolTip="Limpiar" OnClick="btnsiguiente" />
                
                </div>


                   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
              <ContentTemplate>
                <div id="dialog" style="display: none">

                     <asp:Button ID="btnregistrar" Text="refresh" runat="server" OnClientClick="return validation2();"  onclick="btn_registrar_paciente" />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                <div id="dialog1"   class="dialog1" style="display: none">


                   <div class="main">
                   <br /><br />
                                   <center>   <h1>Ingresar Datos Paciente</h1></center> 
                                         <br />
                                    <div class="bloq">
                                     <div class="bloque1">
                                            <label><asp:Label ID="Label33" runat="server" Text="Ficha:"></asp:Label></label>
                                         
                                             <input id="txtficha2"  name="txtficha2" type="text" runat="server" placeholder="Ficha"  class="tex"   />
                                   </div>
                                     <div class="bloque1">
                                            <label><asp:Label ID="Label8" runat="server" Text="Folio:"></asp:Label></label>
                                           <input id="txtfolio2"  name="txtfolio2" type="text" runat="server" placeholder="Folio"  class="tex"   />
                                   </div>

                                     <div class="bloque1">
                                            <label><asp:Label ID="Label9" runat="server" Text="Tipo Doc:"></asp:Label></label>
                                           <asp:DropDownList ID="cbotipo_doc2"  runat="server" CssClass="tex1" >   <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                                           
                                   </div>
                                     <div class="bloque1">
                                            <label><asp:Label ID="Label11" runat="server" Text="Num Doc:"></asp:Label></label>
                                           <input id="txtnum_doc2"  name="txtnum_doc2" type="text" runat="server" placeholder="Num. Doc"  class="tex"   />
                                           
                                   </div>

                                      <div class="bloque1">
                                            <label><asp:Label ID="Label12" runat="server" Text="Nombres"></asp:Label></label>
                                          <input id="txtnombres2"  name="txtnombres2" type="text" runat="server" placeholder="Nombre Completo"  class="tex"   />
                                           
                                   </div>
                                      </div>
                                </div>
                               


                     <asp:Button ID="btnguardar"  runat="server" onclick="btn_guardar"   />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

         
             </div>
          </div>


      </div>

    </form>
</body>
</html>


