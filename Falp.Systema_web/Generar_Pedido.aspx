<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Generar_Pedido.aspx.cs" Inherits="Falp.Systema_web.Generar_Pedido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Generar Pedido</title>
    <link href="Css/Estilo.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            row.style.backgroundColor = "white";
                        }
                        else {
                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
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
                <asp:Label ID="Label10" runat="server" Text="SALIR :" ></asp:Label>  <asp:ImageButton ID="ImageButton3" ImageUrl="~/Imagenes/Botones/cerrar.png" runat="server"   Width="20px" Height="20px" ToolTip="Salir del Sistema"       />
            </div>
              
         </div>
         </div>
       <div class="contenedor2">
          <div  class="contenido">
             <div  class="formulario">

                <div  class="Titulo">
                  Generar Pedido
                </div>

             

               
                  <div  class="bloque">
                      <label> <asp:Label ID="lab1" runat="server" Text="Tipo Consistencia" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_consistencia" CssClass="tex" runat="server">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
                  <div  class="bloque">
                      <label> <asp:Label ID="Label1" runat="server" Text="Tipo Digestabilidad" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_digestabilidad" CssClass="tex" runat="server">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
                  <div  class="bloque">
                      <label> <asp:Label ID="Label8" runat="server" Text="Tipo Aporte Nutrientes" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_aporte_nutrientes" CssClass="tex" runat="server">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
  
                  <div  class="bloque">
                      <label> <asp:Label ID="Label11" runat="server" Text="Tipo Volumen" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_volumen" CssClass="tex" runat="server">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
                  <div  class="bloque">
                      <label> <asp:Label ID="Label12" runat="server" Text="Tipo Temperatura" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_temperatura" CssClass="tex" runat="server">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
                  <div  class="bloque">
                      <label> <asp:Label ID="Label13" runat="server" Text="Tipo Sales" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_sales" CssClass="tex" runat="server">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
                  <div  class="bloque">
                      <label> <asp:Label ID="Label14" runat="server" Text="Otros" ></asp:Label>  </label>     <asp:DropDownList ID="cbotipo_otros" CssClass="tex" runat="server">  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>

               
               
         <div class="grilla">
                        <asp:GridView ID="grillanutrientes" runat="server" AllowPaging="True" OnPageIndexChanging="grillanutrientes_PageIndexChanging"
                           CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" CellPadding="4" 
                             GridLines="Both" PageSize="30"   DataKeyNames="_Cod_tipo_nutrientes" >
                            <Columns>
                             <asp:TemplateField>
                                <HeaderTemplate >
                                    <asp:CheckBox ID="chkAll" runat="server"  onclick = "checkAll(this);"  TextAlign="Left" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" onclick = "Check_Click(this)"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                              
                                <asp:BoundField DataField="_Nom_tipo_nutrientes" HeaderText="Seleccionar Nutrientes" HeaderStyle-Width="80%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />

                            </Columns>
                  
                        </asp:GridView>
                    </div>



                 

         
             </div> <!-- formulario -->

                <div  class="formulario">

                <div  class="Titulo">
                  Detalle Pedido
                </div>
                
                <br /><br />

                  <div  class="bloque2">
                    <label> <asp:Label ID="Label2" runat="server" Text="Diagnostico" ></asp:Label> </label> <textarea id="txtdiagnostico"  name="txtdiagnostico"   runat="server" placeholder="Diagnostico"  class="tex2"  />
                </div>
                  <div  class="bloque2">
                    <label> <asp:Label ID="Label3" runat="server" Text="Amnesis " ></asp:Label> </label> <textarea id="txtamnesis"  name="txtamnesis"   runat="server" placeholder="Amnesis"  class="tex2"  />
                </div>

                  <div  class="bloque2">
                    <label> <asp:Label ID="Label4" runat="server" Text="Observacion" ></asp:Label> </label> <textarea id="txtobservacion"  name="txtobservacion" type="text"  runat="server" placeholder="Observacion"  class="tex2"  />
                </div>


                  <div class="pos">

                   <asp:ImageButton ID="ImageButton1" ImageUrl="~/Imagenes/Botones/atras.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Limpiar" OnClick="btnatras" />
                       <asp:ImageButton ID="ImageButton5" ImageUrl="~/Imagenes/Botones/refrescar.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Limpiar" OnClick="btncancelar" />
                        <asp:ImageButton ID="ImageButton6" ImageUrl="~/Imagenes/Botones/siguiente.png" runat="server"
                    Width="40px" Height="40px" ToolTip="Limpiar" OnClick="btnsiguiente" />
                
                </div>


                 </div> <!-- formulario -->
          </div>


      </div>
      <asp:Label ID="hfCount" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>