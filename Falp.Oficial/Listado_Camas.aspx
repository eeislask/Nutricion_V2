<%@ Page Title="" Language="C#" MasterPageFile="~/General_Oficial.Master" AutoEventWireup="true" CodeBehind="Listado_Camas.aspx.cs" Inherits="Falp.Oficial.Listado_Camas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">

    function informacion() {
        $('#generar_pedido').modal();
    }
    function liberar_cama() {
        $('#liberar_cama').modal();
    }

    function generar_pedido() {
        $('#generar_pedido').modal();
    }

    function detalle_pedido() {
        $('#detalle_pedido').modal();
    }
    function registrar_paciente() {
        $('#registrar_paciente').modal();
    }

</script>


<script type="text/javascript">
    if (history.forward(1)) {
        history.replace(history.forward(1));
    }
</script>

<div class="Subtitulo_1">
 <h3>
                     Listado de Camas
                        
  </h3>

</div>
<br /> 
   <div class="panel panel-success">
      <div class="panel-heading">Filtro Bùsqueda</div>
      <div class="panel-body">
       <div class="row">
            <div class="col-sm-3" >
             <div class="form-group">
             <label>Rut</label>
                  <input type="text" class="form-control" id="txtrut" placeholder="Ingresar Rut" name="txtrut">
                </div>
            </div>
            <div class="col-sm-3" >
             <div class="form-group">
             <label>Servicio</label>
                  <asp:DropDownList ID="cboservicio" CssClass="form-control"   runat="server"   >  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
            </div>
            <div class="col-sm-3" >
             <div class="form-group">
             <label>Estado</label>
                 <asp:DropDownList ID="cboestado" CssClass="form-control"  runat="server" >  <asp:listitem value ="0">Seleccionar</asp:listitem></asp:DropDownList>
                </div>
            </div>
             <div class="col-sm-3" >
             <div class="form-group">
             <br /> 
                  <center><asp:Button ID="Button1"  CssClass="btn btn-success" runat="server" Text="Buscar"  OnClick="buscar" />
                   </center>
                </div>
            </div>
          </div>

  <br />

                
    <div class="panel panel-info">
          <div class="panel-heading" style="width: 100%; height: 40px; "> 
          
            <div class="col-sm-6" >
                <div class="form-group">
                  Listado
                   </div>
             </div>
             <div class="col-sm-6" >
                <div class="form-group">
                <right>
               Registros: <asp:Label ID="txtcantidad" runat="server" ></asp:Label></right>
                   </div>
               
             </div>
          
          </div>
          <div class="panel-body" style="width: 100%; height: 300px; overflow: scroll">


        
                    <asp:GridView ID="grillacama" runat="server" Width="100%" HorizontalAlign="Center" OnPageIndexChanging="grillacama_PageIndexChanging"
                        AutoGenerateColumns="false" AllowPaging="true"  GridLines="Both" PageSize="12000"
                        DataKeyNames="_Id,_Id_pac,_Correlativo,_Cod_cama,_Nom_habitacion,_Cod_servicio,_Estado_cama"  CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  CellPadding="4"  Font-Size="11px" >
                        <Columns>
                       
                                <asp:TemplateField HeaderText="Ped" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left"  >
                                    <ItemTemplate>
                                    <center><asp:Button ID="Button1"  CssClass="btn btn-success" runat="server" Text="Ped" OnClick="ingresar"    />                                    
                                    </ItemTemplate>
                                </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Det" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="left"  >
                                    <ItemTemplate>
                                        <asp:Button ID="Button2"  CssClass="btn btn-info" runat="server" Text="Det" OnClick="Btn_detalle_pedido"    /> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:BoundField DataField="_Estado" HeaderText="Estado" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="LEFT" ItemStyle-HorizontalAlign="LEFT" />
                                 <asp:BoundField DataField="_Num_cama" HeaderText="Cama" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                 <asp:BoundField DataField="_Cod_habitacion" HeaderText="Hab." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                 <asp:BoundField DataField="_Cod_nhc" HeaderText=" NHC" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                  <asp:BoundField DataField="_Num_doc" HeaderText="Ident." HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="LEFT" />
                                <asp:BoundField DataField="_Nombres" HeaderText="Nombre Pac." HeaderStyle-Width="3%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Left"  />
                                <asp:BoundField DataField="_Nom_servicio" HeaderText="Servicio" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                               
           
                        </Columns>
                    </asp:GridView>
                
            


             </div>
         </div>
    </div>
       
      </div>


       <div class="modal fade" id="info" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="panel-title" id="contactLabel"><span class="glyphicon glyphicon-info-sign"></span> Estimado Usuario</h4>
                    </div>
                   
                    <div class="modal-body" style="padding:  5px;   ">
                         
                             <h4>   ¿Que  Acciòn  desea realizar en el Paciente ? </h4>
                                   <div class="col-sm-2" >
                                     <div class="form-group">
                                     <label>Cama</label>
                                           <input type="text" class="form-control" id="txtcama1"  runat="server" placeholder="Cama" name="txtcama1" readonly />
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-2" >
                                     <div class="form-group">
                                     <label>Habitacion</label>
                                           <input type="text" class="form-control" id="txthabitacion1"  runat="server" placeholder="Habitacion" name="txthabitacion1" readonly />
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-8" >
                                     <div class="form-group">
                                     <label>Nombre</label>
                                           <input type="text" class="form-control" id="txtnombre1"  runat="server" placeholder="Servicio" name="txtnombre1" readonly />
                                        
                                        </div>
                                    </div>

                        </div>  
                        <div class="panel-footer" style="margin-bottom:-14px;">
                         <center><asp:Button ID="btn_lib"  CssClass="btn btn-info" runat="server" Text="Liberar Cama"  OnClick="Btn_liberar_cama" />
                         <asp:Button ID="Button3"  CssClass="btn btn-success" runat="server" Text="Generar Pedido"  OnClick="Btn_generar_pedido" />
                         <asp:Button ID="Button4"  CssClass="btn btn-danger" runat="server" Text="Cancelar"  />
                          </center>
                        </div>
                    </div>
                </div>
            </div>


             <div class="modal fade" id="liberar_cama" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="panel-title" id="H1"><span class="glyphicon glyphicon-info-sign"></span> Estimado Usuario</h4>
                    </div>
                   
                    <div class="modal-body" style="padding: 5px;  ">
                         
                               <h4> ¿Esta seguro de Liberar la Cama ? </h4>
                                   <div class="col-sm-2" >
                                     <div class="form-group">
                                     <label>Cama</label>
                                           <input type="text" class="form-control" id="txtcama2"  runat="server" placeholder="Cama" name="txtcama2" readonly />
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-2" >
                                     <div class="form-group">
                                     <label>Habitacion</label>
                                           <input type="text" class="form-control" id="txthabitacion2"  runat="server" placeholder="Habitacion" name="txthabitacion2" readonly />
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-8" >
                                     <div class="form-group">
                                     <label>Nombre</label>
                                           <input type="text" class="form-control" id="txtnombre2"  runat="server" placeholder="Servicio" name="txtnombre2" readonly />
                                        
                                        </div>
                                    </div>

                        </div>  
                        <div class="panel-footer" style="margin-bottom:-14px;">
                        <center>
                         <asp:Button ID="Button5"  CssClass="btn btn-info" runat="server" Text="Aceptar"  />
                         <asp:Button ID="Button7"  CssClass="btn btn-danger" runat="server" Text="Cancelar"  />
                          </center>
                        </div>
                    </div>
                </div>
            </div>


               <div class="modal fade" id="generar_pedido" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="panel-title" id="H2"><span class="glyphicon glyphicon-info-sign"></span> Estimado Usuario</h4>
                    </div>
                   
                    <div class="modal-body" style="padding: 5px;   ">
                         
                                <h4>¿Esta seguro Generar Pedido</h4>

                                   <div class="col-sm-2" >
                                     <div class="form-group">
                                     <label>Cama</label>
                                           <input type="text" class="form-control" id="txtcama3"  runat="server" placeholder="Cama" name="txtcama3" readonly>
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-2" >
                                     <div class="form-group">
                                     <label>Habitacion</label>
                                           <input type="text" class="form-control" id="txthabitacion3"  runat="server" placeholder="Habitacion" name="txthabitacion3" readonly>
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-8" >
                                     <div class="form-group">
                                     <label>Nombre</label>
                                           <input type="text" class="form-control" id="txtnombre3"  runat="server" placeholder="Servicio" name="txtnombre3" readonly>
                                        
                                        </div>
                                    </div>

                        </div>  
                        <div class="panel-footer" style="margin-bottom:-14px;">
                        <center> <asp:Button ID="btn_registrar"  CssClass="btn btn-success" runat="server" Text="Registrar" OnClick="Btn_registrar_paciente" />
                        <asp:Button ID="Button6"  CssClass="btn btn-info" runat="server" Text="Aceptar"  OnClick="Btn_envia_generar_ped" />
                         <asp:Button ID="Button8"  CssClass="btn btn-danger" runat="server" Text="Cancelar"  />
                          </center>
                        </div>
                    </div>
                </div>
            </div>

                  <div class="modal fade" id="registrar_paciente" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="panel-title" id="H4"><span class="glyphicon glyphicon-info-sign"></span> Estimado Usuario</h4>
                    </div>
                   
                    <div class="modal-body" style="padding: 5px;">
                         
                               <div class="panel panel-info">
                                 <div class="panel-heading">
                                    Buscar Paciente</div>
                                 <div class="panel-body" style="width: 100%" >

                                 <div class="row">
                                    <div class="col-sm-6" >
                                     <div class="form-group">
                                    <label>Tipo Filtro</label>
                                         <asp:DropDownList ID="DropDownList2" CssClass="form-control"   runat="server"   >  <asp:listitem value ="0">Selec. Filtro</asp:listitem></asp:DropDownList>
                                             
                                        </div>
                                    </div>
                                    <div class="col-sm-4" >
                                     <div class="form-group">
                                     <label>Filtro</label>
                                           <input type="text" class="form-control" id="Text1" placeholder="Filtro" name="txtrut">
                                        
                                        </div>
                                    </div>

                                     <div class="col-sm-2" >
                                     <div class="form-group">
                                          <br /> <br />
                                           <asp:Button ID="Button15"  CssClass="btn btn-info" runat="server" Text="Buscar"  />
                                        </div>
                                    </div>
                                    </div>
                                   
                                    

                                 </div>
                               </div>


                                 <div class="panel panel-info">
                                 <div class="panel-heading">Informaciòn Paciente</div>
                                 <div class="panel-body" style="width: 100%">

                                 <div class="col-sm-6" >
                                     <div class="form-group">
                                     <label>Ficha</label>
                                           <input type="text" class="form-control" id="Text2" placeholder="Ficha" name="txtrut">
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-6" >
                                     <div class="form-group">
                                     <label>Folio</label>
                                           <input type="text" class="form-control" id="Text3" placeholder="Folio" name="txtrut">
                                        
                                        </div>
                                    </div>

                                     <div class="col-sm-6" >
                                     <div class="form-group">
                                     <label>Tipo Docum.</label>
                                        <asp:DropDownList ID="DropDownList3" CssClass="form-control"   runat="server"   >  <asp:listitem value ="0">Seleccionar. Tipo Docum.</asp:listitem></asp:DropDownList>
                                            
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-6" >
                                     <div class="form-group">
                                     <label>Nº Docum.</label>
                                           <input type="text" class="form-control" id="Text5" placeholder="Nº Docu." name="txtrut">
                                        
                                        </div>
                                    </div>

                                    <div class="col-sm-12" >
                                     <div class="form-group">
                                     <label>Nombre Completo</label>
                                           <input type="text" class="form-control" id="Text4" placeholder="Nombre Completo" name="txtrut">
                                        
                                        </div>
                                    </div>


                                 </div>
                               </div>

                        </div>  
                        <div class="panel-footer" style="margin-bottom:-14px;">
                        <center> 
                        <asp:Button ID="Button13"  CssClass="btn btn-info" runat="server" Text="Guardar"  />
                         <asp:Button ID="Button14"  CssClass="btn btn-danger" runat="server" Text="Cancelar"  />
                          </center>
                        </div>
                    </div>
                </div>
            </div>

           <div class="modal fade" id="detalle_pedido" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="panel-title" id="H3"><span class="glyphicon glyphicon-info-sign"></span> Detallle Alimentacion del Dìa</h4>
                    </div>
                   
                    <div class="modal-body" style="padding: 5px;  height: 400px; overflow: scroll"">

                     <div class="panel panel-info">
                                 <div class="panel-heading">
                                    Antecedentes Paciente</div>
                                 <div class="panel-body" style="width: 100%; height: 200px; overflow: scroll">

                                 <div class="col-sm-2" >
                                     <div class="form-group">
                                     <label>Cama</label>
                                           <input type="text" class="form-control" id="txtcama"  runat="server" placeholder="Cama" name="txtcama" readonly>
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-2" >
                                     <div class="form-group">
                                     <label>Habitacion</label>
                                           <input type="text" class="form-control" id="txthabitacion"  runat="server" placeholder="Habitacion" name="txthabitacion" readonly>
                                        
                                        </div>
                                    </div>
                                    <div class="col-sm-8" >
                                     <div class="form-group">
                                     <label>Servicio</label>
                                           <input type="text" class="form-control" id="txtservicio"  runat="server" placeholder="Servicio" name="txtservico" readonly>
                                        
                                        </div>
                                    </div>

                                    <div class="col-sm-12" >
                                     <div class="form-group">
                                     <label>Nombre</label>
                                           <input type="text" class="form-control" id="txtnombre"  runat="server" placeholder="Nombre" name="txtnombre" readonly>
                                        
                                        </div>
                                    </div>

                                 </div>
                           </div>
                         
                           <div class="panel panel-info">
                                 <div class="panel-heading">
                                    Desayuno</div>
                                 <div class="panel-body" style="width: 100%; height: 100px; overflow: scroll">


                                 </div>
                           </div>

                             <div class="panel panel-info">
                                 <div class="panel-heading">
                                    Colaciòn Mañana</div>
                                 <div class="panel-body" style="width: 100%; height: 100px; overflow: scroll">


                                 </div>
                           </div>

                             <div class="panel panel-info">
                                 <div class="panel-heading">
                                    Almuerzo</div>
                                 <div class="panel-body" style="width: 100%; height: 100px; overflow: scroll">


                                 </div>
                           </div>


                             <div class="panel panel-info">
                                 <div class="panel-heading">
                                    Colaciòn Tarde</div>
                                 <div class="panel-body" style="width: 100%; height: 100px; overflow: scroll">


                                 </div>
                           </div>


                             <div class="panel panel-info">
                                 <div class="panel-heading">
                                   Once</div>
                                 <div class="panel-body" style="width: 100%; height: 100px; overflow: scroll">


                                 </div>
                           </div>


                             <div class="panel panel-info">
                                 <div class="panel-heading">
                                   Cena</div>
                                 <div class="panel-body" style="width: 100%; height: 100px; overflow: scroll">


                                 </div>
                           </div>


                             <div class="panel panel-info">
                                 <div class="panel-heading">
                                   Colaciòn Nocturna</div>
                                 <div class="panel-body" style="width: 100%; height: 100px; overflow: scroll">


                                 </div>
                           </div>

                             <div class="panel panel-info">
                                 <div class="panel-heading">
                                   Hidricos</div>
                                 <div class="panel-body" style="width: 100%; height: 100px; overflow: scroll">


                                 </div>
                           </div>
                             

                        </div>  
                        <div class="panel-footer" style="margin-bottom:-14px;">
                         <center><asp:Button ID="Button10"  CssClass="btn btn-info" runat="server" Text="Aceptar"  />
                         <asp:Button ID="Button11"  CssClass="btn btn-danger" runat="server" Text="Cancelar"  />
                          </center>
                        </div>
                    </div>
                </div>
            </div>
       

 
</asp:Content>
