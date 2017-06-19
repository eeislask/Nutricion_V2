<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guardar_Pedido.aspx.cs" Inherits="Falp.Systema_web.Guardar_Pedido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Guardar Pedido</title>
      <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.8.2.min.js"></script>
    <link href="Css/Estilo.css" rel="stylesheet" type="text/css" />
    <link href="Css/dialog.css" rel="stylesheet" type="text/css" />
 
    <script type="text/javascript">


        function ShowPopup2(message) {
            $(function () {
                $("#dialog1").html(message);
                $("#dialog1").dialog({
                    title: "Mensaje",
                    width: "400px",
                    height: 150,
                    buttons: {

                        Si: function () {

                            __doPostBack('<%= btnselec_alimento.ClientID %>', '');

                        },
                      
                        No: function () {
                            $(this).dialog('close');

                        }
                    },
                    modal: true
                });
                $("#dialog1").parent().appendTo($("form:first"));
            });
        };


        function ShowPopup3(message) {
            $(function () {
                $("#dialog2").html(message);
                $("#dialog2").dialog({
                    title: "Mensaje",
                    width: "400px",
                    height: 150,
                    buttons: {

                        Si: function () {

                            __doPostBack('<%= Btnconfirmar_1.ClientID %>', '');

                        },

                        No: function () {
                            $(this).dialog('close');

                        }
                    },
                    modal: true
                });
                $("#dialog2").parent().appendTo($("form:first"));
            });
        };

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

        function ShowPopup4(message) {
            $(function () {
                $("#dialog4").html(message);
                $("#dialog4").dialog({
                    title: "Mensaje",
                    width: "400px",
                    height: "150",
                    buttons: {

                        Aceptar: function () {
                            $(this).dialog('close');
                            location.href = 'Guardar_Pedido.aspx'

                        }
                    },
                    modal: true
                });
                $("#dialog4").parent().appendTo($("form:first"));
            });
        };


        function validation1() {

            var combo1 = document.getElementById("<%=cbotipo_comida.ClientID%>")
            if (combo1.value == null || combo1.value == "0") {
                alert("Porfavor, seleccione el tipo comida correspondiente");
                document.getElementById("<%=cbotipo_comida.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=cbotipo_comida.ClientID%>").style.border = "";
            }


            return true;
        }

        function validation2() {

            var combo1 = document.getElementById("<%=cbotipo_distribucion.ClientID%>")
            if (combo1.value == null || combo1.value == "0") {
                alert("Porfavor, seleccione el tipo distribucion correspondiente");
                document.getElementById("<%=cbotipo_distribucion.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=cbotipo_distribucion.ClientID%>").style.border = "";
            }

            var combo2 = document.getElementById("<%=cbotipo_alimento.ClientID%>")
            if (combo2.value == null || combo2.value == "0") {
                alert("Porfavor, seleccione el tipo alimento correspondiente");
                document.getElementById("<%=cbotipo_alimento.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=cbotipo_alimento.ClientID%>").style.border = "";
            }

            var combo3 = document.getElementById("<%=txtcantidad.ClientID%>")
            if (combo3.value == null || combo3.value == "") {
                alert("Porfavor, Ingrese Cantidad ");
                document.getElementById("<%=txtcantidad.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=txtcantidad.ClientID%>").style.border = "";
            }



            return true;
        }


        function validation3() {

            var combo1 = document.getElementById("<%=cbotipo_distribucion.ClientID%>")
            if (combo1.value == null || combo1.value == "0") {
                alert("Porfavor, seleccione el tipo distribucion correspondiente");
                document.getElementById("<%=cbotipo_distribucion.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=cbotipo_distribucion.ClientID%>").style.border = "";
            }

            var combo2 = document.getElementById("<%=cbotipo_alimento.ClientID%>")
            if (combo2.value == null || combo2.value == "0") {
                alert("Porfavor, seleccione el tipo alimento correspondiente");
                document.getElementById("<%=cbotipo_alimento.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=cbotipo_alimento.ClientID%>").style.border = "";
            }

            var combo3 = document.getElementById("<%=txtcantidad.ClientID%>")
            if (combo3.value == null || combo3.value == "") {
                alert("Porfavor, Ingrese Cantidad ");
                document.getElementById("<%=txtcantidad.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {
                document.getElementById("<%=txtcantidad.ClientID%>").style.border = "";
            }
            var cont = 0;
            var grid = document.getElementById("<%= grillaalimentos.ClientID%>");
           
            for (var i = 0; i < grid.rows.length; i++) {

            
                var str = grid.rows[i].cells[2].textContent;
                
                if(str=="S") {
                    cont++;
                  
                }
            
           }
           if (cont ==0) {
               alert("Porfavor, Debe seleccionar un Alimento de la Grilla ");
                document.getElementById("<%=grillaalimentos.ClientID%>").style.border = "2px solid red";
                return false;
            }
            else {

                if (cont == 1) {

                    document.getElementById("<%=grillaalimentos.ClientID%>").style.border = "";
                }
            }
           


            return true;
        }

    
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
                <asp:Label ID="Label10" runat="server" Text="SALIR :" ></asp:Label>  <asp:ImageButton ID="btn_sal" ImageUrl="~/Imagenes/Botones/cerrar.png" runat="server"   Width="20px" Height="20px" ToolTip="Salir del Sistema"   OnClick="btn_salir1"     />
            </div>
              
         </div>
         </div>
       <div class="contenedor2">
   
          <div  class="contenido">
               
             <div  class="formulario">
            

                <div  class="Titulo">
                  Guardar Pedido
                </div>

             

               
                  <div  class="bloque">
                      <label> <asp:Label ID="lab1" runat="server" Text="Fecha" ></asp:Label>  </label>     <asp:TextBox ID="txtfecha" runat="server" CssClass="tex2" Enabled="true"></asp:TextBox>
                </div>
                  <div  class="bloque">
                      <label> <asp:Label ID="Label1" runat="server" Text="Tipo Comida" OnSelectedIndexChanged="cbotipo_comida_SelectedIndexChanged" AutoPostBack="true" CausesValidation="true"></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_comida" CssClass="tex" runat="server" >  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>

                   <div  class="bloque2">
                    <label> <asp:Label ID="Label6" runat="server" Text="Observaciòn" ></asp:Label> </label> <textarea id="txtobservacion"  name="txtdiagnostico" type="text"  runat="server" placeholder="Observacion"  class="tex2"  />
                </div>
        

                 <div class="pos">

                
                       <asp:ImageButton ID="ImageButton4" ImageUrl="~/Imagenes/Botones/refrescar.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Limpiar" OnClick="btncancelar" />
                        <asp:ImageButton ID="ImageButton7" ImageUrl="~/Imagenes/Botones/siguiente.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Limpiar" OnClick="btnsiguiente" OnClientClick="return validation1();"  />
                
                </div>
               
       



                 

         
             </div> <!-- formulario -->

                <div  class="formulario">

                <div  class="Titulo">
                  Selecciòn Tipo Alimento
                </div>
                
                <br /><br />

                   
                 
                  <div  class="bloque">
                      <label> <asp:Label ID="Label3" runat="server" Text="Tipo Distribuciòn" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_distribucion" CssClass="tex" runat="server" OnSelectedIndexChanged="cbotipo_distribucion_SelectedIndexChanged" AutoPostBack="true" CausesValidation="true">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
                 <div  class="bloque">
                      <label> <asp:Label ID="Label4" runat="server" Text="Tipo Alimento" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_alimento" CssClass="tex" runat="server">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>


                 <div  class="bloque">
                      <label> <asp:Label ID="Label2" runat="server" Text="Cantidad" ></asp:Label>  </label>     <asp:TextBox ID="txtcantidad" runat="server" CssClass="tex3"></asp:TextBox>
                      <asp:ImageButton ID="btn_add" ImageUrl="~/Imagenes/Botones/add.png" runat="server"
                    Width="20px" Height="20px" ToolTip="Agregar Alimentos" OnClick="btnagregar" OnClientClick="return validation2();" />
                </div>
                 <div  class="Titulo">
                  Lista de Alimentos
                </div>
         
                  <div class="grilla">
                        <asp:GridView ID="grillaalimentos" runat="server" AllowPaging="True" OnPageIndexChanging="grillaalimentos_PageIndexChanging"
                           CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" CellPadding="4" 
                             GridLines="Both" PageSize="30"   DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Vigencia" >
                            <Columns>
                           

                               <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="20%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right" />

                                <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText="Seleccionar Alimentos" HeaderStyle-Width="60%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                <asp:BoundField DataField="_Estado" HeaderText="Estado" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="right" />
                                    <asp:TemplateField HeaderText="Selec." HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_estado" ImageUrl="~/Imagenes/Botones/click.png" runat="server"
                                            Width="16px" Height="16px" ToolTip="Buscar Paciente" OnClick="select_alimento"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                  
                        </asp:GridView>
                        <asp:Label ID="msg1" runat="server"  />
                    </div>
                  <div class="pos">

                    <asp:ImageButton ID="btn_listad" ImageUrl="~/Imagenes/Botones/menu.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Volver al Listado" OnClick="btn_listado1" />
                
                   <asp:ImageButton ID="btn_atras" ImageUrl="~/Imagenes/Botones/atras.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Volver Atras" OnClick="btnatras" />
                       <asp:ImageButton ID="btn_cancelar" ImageUrl="~/Imagenes/Botones/refrescar.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Limpiar" OnClick="btncancelar2" />
                        <asp:ImageButton ID="btn_guardar" ImageUrl="~/Imagenes/Botones/guardar.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Guardar Pedido" OnClick="btnguardar" />
                      <asp:ImageButton ID="btn_guardar1" ImageUrl="~/Imagenes/Botones/guardar.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Guardar Pedido" OnClick="btnguardar1" />
                
                </div>


                 </div> <!-- formulario -->

             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div id="dialog1" style="display: none">
                  <asp:Button ID="btnselec_alimento" Text="refresh" runat="server" onclick="btn_select_alimento" />
      
               </div>
            </ContentTemplate>
        </asp:UpdatePanel>

             <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div id="dialog2" style="display: none">
                  <asp:Button ID="Btnconfirmar_1" Text="Guardar" runat="server" onclick="btn_confirmar_pedido" />
          
      
               </div>
            </ContentTemplate>
        </asp:UpdatePanel>

             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="dialog" style="display: none">
                  
      
               </div>
            </ContentTemplate>
        </asp:UpdatePanel>

           <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <div id="dialog4" style="display: none">
                  
      
               </div>
            </ContentTemplate>
        </asp:UpdatePanel>
          </div>


      </div>
 
    </form>
</body>
</html>