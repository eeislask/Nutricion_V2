<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="Guardar_Pedido.aspx.cs" Inherits="Falp.Oficial.Guardar_Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function info() {
            $('#selec_alimento').modal();
        }
      

    </script>
    <script type="text/javascript">
        if (history.forward(1)) {
            history.replace(history.forward(1));
        }
    </script>
    <div class="Subtitulo_1">
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <h3>
                        GUARDAR PEDIDO  :
                          <asp:Label ID="txtalimento" runat="server" ForeColor="Red"></asp:Label> 
                    </h3>
                </div>
            </div>
       
            <div class="col-sm-2">
                <div class="form-group">
                   
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                    
                </div>
            </div>
            <div class="col-sm-2">
                <div class="form-group">
                   
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-8">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Filtro Distribuciòn</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-3">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-sm-5">
                            <label>
                                Tipo Distribuciòn</label>
                            <center>
                                <asp:DropDownList ID="cbotipo_distribucion" CssClass="form-control" runat="server"
                                    OnSelectedIndexChanged="cbotipo_distribucion_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                    <asp:ListItem Value="0">Selec. Distribucion</asp:ListItem>
                                </asp:DropDownList>
                            </center>
                            <br />
                        </div>
                        <div class="col-sm-4">
                            <br />
                            <asp:Button ID="Button6" CssClass="btn btn-info" runat="server" Text="Volver" OnClick="volver" />
                            <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Guardar" />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Ingresar Alimento</div>
                            <div class="panel-body" style="width: 100%;">
                                <div class="col-sm-6">
                                </div>
                                <div class="col-sm-3">
                                  <asp:Button ID="btn_select_ext1" CssClass="btn btn-warning" runat="server" Text="Agregar Extras"  OnClick="btn_select_extra"/>
                                    <br />
                                    <br />
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="btn_extra_extra1" CssClass="btn btn-warning" runat="server" Text="Agregar Extras-Extras"  OnClick="btn_select_extra_extra"  />
                                    <br />
                                    <br />
                                </div>
                                <div class="grilla">
                                    <asp:GridView ID="grillaalimentos" runat="server" AllowPaging="True" OnPageIndexChanging="grillaalimentos_PageIndexChanging"
                                        CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header"
                                        RowStyle-CssClass="rows" AutoGenerateColumns="False" CellPadding="4" GridLines="Both"
                                        PageSize="30" DataKeyNames="_Id_tipo_alimento,_Cod_tipo_alimento,_Vigencia" EmptyDataText="Estimado  Usuario, No existen Datos">
                                        <Columns>
                                            <asp:BoundField DataField="_Cantidad" HeaderText="Cantidad" HeaderStyle-Width="10%"
                                                HeaderStyle-HorizontalAlign="right" ItemStyle-HorizontalAlign="center" />
                                            <asp:BoundField DataField="_Nom_tipo_alimento" HeaderText="Seleccionar Alimentos"
                                                HeaderStyle-Width="60%" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="left" />
                                            <asp:BoundField DataField="_Estado" HeaderText="Estado" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="center" />
                                            <asp:TemplateField HeaderText="Selec." HeaderStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"
                                                ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btn_estado" ImageUrl="~/Imagenes/Botones/click.png" runat="server"
                                                        Width="16px" Height="16px" ToolTip="Buscar Paciente" OnClick="select_alimento" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-5">
                        </div>
                        <div class="col-sm-5">
                        </div>
                        <div class="col-sm-2">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-4">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Detalle los Componentes Del Tipo de Distribuciòn
                </div>
                <div class="panel-body" style="width: 100%; height: 400px; overflow: scroll">
                    <div class="form-group">
                        <label>
                            Consistencia</label>
                        <asp:DropDownList ID="cboconsistencia" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Selec. Consistencia</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>
                            Digestabilidad</label>
                        <asp:DropDownList ID="cbodigestabilidad" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Selec. Digestabilidad</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>
                            Dulzor</label>
                        <asp:DropDownList ID="cbodulzor" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Selec. Dulzor</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>
                            Lactosa</label>
                        <asp:DropDownList ID="cbolactosa" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Selec. Lactosa</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>
                            Sal</label>
                        <asp:DropDownList ID="cbotipo_sal" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Selec.  Sal</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>
                            Temperatura</label>
                        <asp:DropDownList ID="cbotemperatura" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Selec.  Temperatura</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>
                            Volumen</label>
                        <asp:DropDownList ID="cbovolumen" CssClass="form-control" runat="server">
                            <asp:ListItem Value="0">Selec. Volumen</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div> </div>
    <div class="modal fade" id="agregar_alimentos" tabindex="-1" role="dialog" aria-labelledby="contactLabel"
        aria-hidden="true">
        <div class="modal-dialog">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 class="panel-title" id="H3">
                        <span class="glyphicon glyphicon-info-sign"></span>Agregar Informaciòn</h4>
                </div>
                <div class="modal-body" style="padding: 5px;">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Agregar Alimento</div>
                        <div class="panel-body" style="width: 100%">
                            <div class="form-group">
                                <label>
                                    Tipo Alimentos</label>
                                <asp:DropDownList ID="DropDownList3" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Selec.  Tipo Alimento</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>
                                    Tipo Distribuciòn</label>
                                <asp:DropDownList ID="cbotipo_alimento" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Selec.  Tipo Alimento</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label>
                                    Cantidad</label>
                                <input type="text" class="form-control" id="Text4" placeholder="Cantidad" name="txtcantidad" />
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer" style="margin-bottom: -14px;">
                        <center>
                            <asp:Button ID="Button10" CssClass="btn btn-info" runat="server" Text="Guardar" />
                            <asp:Button ID="Button11" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                        </center>
                    </div>
                </div>
            </div>
        </div>
         </div>
        <div class="modal fade" id="modificar_alimentos" tabindex="-1" role="dialog" aria-labelledby="contactLabel"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                            ×</button>
                        <h4 class="panel-title" id="H1">
                            <span class="glyphicon glyphicon-info-sign"></span>Modificar Informaciòn</h4>
                    </div>
                    <div class="modal-body" style="padding: 5px; height: 200px">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                Agregar Alimento</div>
                            <div class="panel-body" style="width: 100%">
                                <div class="form-group">
                                    <label>
                                        Tipo Distribucion</label>
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Selec.  Tipo Alimento</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Tipo Alimento</label>
                                    <asp:DropDownList ID="DropDownList4" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Selec.  Tipo Alimento</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Cantidad</label>
                                    <input type="text" class="form-control" id="Text1" placeholder="Cantidad" name="txtcantidad" />
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer" style="margin-bottom: -14px;">
                            <center>
                                <asp:Button ID="Button2" CssClass="btn btn-info" runat="server" Text="Guardar" />
                                <asp:Button ID="Button3" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
                            </center>
                        </div>
                    </div>
                </div>
            </div>
            </div>
            <div class="modal fade" id="selec_alimento" tabindex="-1" role="dialog" aria-labelledby="contactLabel"
                aria-hidden="true">
                <div class="modal-dialog">
                    <div class="panel panel-success">
                        <div class="panel-heading">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×</button>
                            <h4 class="panel-title" id="H2">
                                <span class="glyphicon glyphicon-info-sign"></span>Estimado Usuario</h4>
                        </div>
                        <div class="modal-body" style="padding: 5px">
                            <h4>
                                ¿Esta seguro de seleccionar este Alimento?
                            </h4>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>
                                        Tipo Ditribuciòn</label>
                                    <input type="text" class="form-control" id="txtdistribucion" runat="server" placeholder="Cama" name="txtdistribucion" readonly />
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>
                                        Tipo Alimento</label>
                                    <input type="text" class="form-control" id="txtalimento1" runat="server" placeholder="Habitacion"  name="txtalimento1" readonly />
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="form-group">
                                    <label>
                                        Nombre Pac.</label>
                                    <input type="text" class="form-control" id="txtnombre2" runat="server" placeholder="Servicio" name="txtnombre2" readonly />
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer" style="margin-bottom: -14px;">
                            <center>
                                <asp:Button ID="Button5" CssClass="btn btn-info" runat="server" Text="Aceptar"  OnClick="btn_select_alimento" />
                              
                                <asp:Button ID="Button7" CssClass="btn btn-danger" runat="server" Text="Cancelar" />
             
                            </center>
                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
