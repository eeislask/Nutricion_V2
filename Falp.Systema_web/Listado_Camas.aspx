<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listado_Camas.aspx.cs" Inherits="Falp.Systema_web.Listado_Camas" %>
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


        function ShowPopup2(message) {
            $(function () {
                $("#dialog").html(message);
                $("#dialog").dialog({
                    title: "Mensaje",
                    width: "400px",
                    height: 150,
                    buttons: {

                        LiberarCama: function () {

                            __doPostBack('<%= btnliberar_cama.ClientID %>', ''); 

                        },
                        VerPedido: function () {
                            __doPostBack('<%= btnver_pedido.ClientID %>', ''); 

                        },
                        Cancelar: function () {
                            $(this).dialog('close');

                        }
                    },
                    modal: true
                });
                $("#dialog").parent().appendTo($("form:first"));
            });
        };




        function ShowPopup1(message) {
            $(function () {
                $("#dialog1").html(message);
                $("#dialog1").dialog({
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
                <asp:Label ID="Label10" runat="server" Text="SALIR :" ></asp:Label>  <asp:ImageButton ID="btn_salir" ImageUrl="~/Imagenes/Botones/cerrar.png" runat="server"   Width="20px" Height="20px" ToolTip="Salir del Sistema"       />
            </div>
              
         </div>
         </div>
       <div class="contenedor2">
          <div  class="contenido">
             <div  class="listado_cama">

                <div  class="Titulo">
                  Listado Cama
                </div>


                  <div class="grilla">
                        <div class="pos">
                            <asp:Label ID="cant" runat="server"></asp:Label>
                        </div>
                        <asp:GridView ID="grillacama" runat="server" AllowPaging="True" OnPageIndexChanging="grillacama_PageIndexChanging"
                        DataKeyNames="_Cod_paciente,_Cod_cama"   onrowdatabound="grillacama_RowDataBound"
                           CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" CellPadding="4" 
                             GridLines="Both" PageSize="1200" >
                            <Columns>
                             <asp:TemplateField HeaderText="Ico" HeaderStyle-Width="3%">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_IM1" ImageUrl="~/Imagenes/Imagenes/cam.png" runat="server"
                                            Width="16px" Height="16px" ToolTip="Ver Ficha Usuario"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="_Num_cama" HeaderText="Cod Cama" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="_Nom_paciente" HeaderText="Nombre Paciente" HeaderStyle-Width="45%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  />
     
                                  <asp:TemplateField HeaderText="Estado" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>

                                        <asp:Image ID="img_estado" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ir" HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_estado" ImageUrl="~/Imagenes/Botones/click.png" runat="server"
                                            Width="16px" Height="16px" ToolTip="Buscar Paciente" OnClick="buscar_paciente"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                         
                            </Columns>
                  
                        </asp:GridView>

                        <br />
                      <asp:Image ID="img_estado" runat="server" ImageUrl="~/Imagenes/Botones/error.png" /> <asp:Label ID="Label1" runat="server" Text=" Pedido no  Registrado" ></asp:Label> <br />  <asp:Image ID="Image1" runat="server" ImageUrl="~/Imagenes/Botones/incompleto.png" /><asp:Label ID="Label2" runat="server" Text=" Pedido Registrado, pero  sin asignacion de alimentos" ></asp:Label>  <br /><asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/Botones/ok.png" /> <asp:Label ID="Label3" runat="server" Text=" Pedido Registrado Completo" ></asp:Label>
                
                    </div>


              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="dialog" style="display: none">

                   <asp:Button ID="btnliberar_cama" Text="refresh" runat="server" onclick="btn_liberar_cama" />
               <asp:Button ID="btnver_pedido" Text="refresh" runat="server" onclick="btnver_pedidos" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div id="dialog1" style="display: none">

      
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
         




         
             </div>
          </div>







      </div>

    </form>
</body>
</html>