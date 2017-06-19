<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="Generar_Pedido.aspx.cs" Inherits="Falp.Oficial.Generar_Pedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">
    $(function validation1() {

        var combo1 = document.getElementById("<%=cboregimen.ClientID%>")
        if (combo1.value == null || combo1.value == "0") {
            alert("Por favor, seleccionar el Regimen ");
            document.getElementById("<%=cboregimen.ClientID%>").style.border = "2px solid red";

            return false;
        }
        else {
            document.getElementById("<%=cboregimen.ClientID%>").style.border = "";
        }


        var combo2 = document.getElementById("<%=cboaislamiento.ClientID%>")
        if (combo2.value == null || combo2.value == "0") {
            alert("Por favor, seleccionar el Aislamiento ");
            document.getElementById("<%=cboaislamiento.ClientID%>").style.border = "2px solid red";

            return false;
        }
        else {
            document.getElementById("<%=cboaislamiento.ClientID%>").style.border = "";
        }

        var combo3 = document.getElementById("<%=cbobandeja.ClientID%>")
        if (combo3.value == null || combo3.value == "0") {
            alert("Por favor, seleccionar el Bandeja ");
            document.getElementById("<%=cbobandeja.ClientID%>").style.border = "2px solid red";

            return false;
        }
        else {
            document.getElementById("<%=cbobandeja.ClientID%>").style.border = "";
        }


        return true;

      


    });

    function desayuno() {
        $('#btn_desayuno').modal();
    }
  
   

</script>

<script type="text/javascript">
    if (history.forward(1)) {
        history.replace(history.forward(1));
    }
</script>

    <link href="https://gitcdn.github.io/bootstrap-toggle/2.2.2/css/bootstrap-toggle.min.css" rel="stylesheet"  />
    <script src="https://gitcdn.github.io/bootstrap-toggle/2.2.2/js/bootstrap-toggle.min.js" type="text/javascript"></script>
    <div class="Subtitulo_1">
        <div class="row">
            <div class="col-sm-6">
                <div class="form-group">
                    <h3>  Generar Pedido <asp:Label ID="txtpedido" runat="server" ></asp:Label> </h3> 
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
             
                   <asp:ImageButton ID="btn_guardar1" ImageUrl="~/Imagenes/Botones/menu.png" runat="server"
                    Width="42px" Height="42px" ToolTip="Regresar a Listado de Pacientes"  />
                   
                </div>
            </div>
        
        </div>
    </div>
    <br />


         <div class="row">
                <div class="col-md-5">
                 <div class="panel panel-success">
                    <div class="panel-heading">Opciones Alimentaciòn</div>
                    <div class="panel-body" style="width: 100%">

                    <div class="col-md-6 ">
                  <div class="radio"> <label><asp:RadioButton ID="codayuno"  runat="server" GroupName="opc_alim" AutoPostBack="true"  CausesValidation="true"    OnCheckedChanged="opc_alim_CheckedChanged" />Ayuno</label></div>
                  <div class="radio"> <label><asp:RadioButton ID="codalimento_oral"  runat="server" GroupName="opc_alim" AutoPostBack="true" CausesValidation="true"  OnCheckedChanged="opc_alim_CheckedChanged"  />Alimentaciòn Oral</label></div>
                     </div>

                    <div class="col-md-6 ">
                     <div class="radio"> <label><asp:RadioButton ID="nutricion_oral"  runat="server" GroupName="opc_alim"  CausesValidation="true"  AutoPostBack="true"  OnCheckedChanged="opc_alim_CheckedChanged" />Nutriciòn Enteral</label></div>
                  <div class="radio"> <label><asp:RadioButton ID="nutricion_parental"  runat="server" GroupName="opc_alim"   CausesValidation="true"  AutoPostBack="true" OnCheckedChanged="opc_alim_CheckedChanged" />Nutriciòn Parental</label></div>
                 
                    </div>
                   
                    </div>
                    </div>

                </div>

                 <div class="col-md-7 ">
                  <div class="panel panel-success">
                    <div class="panel-heading">Detalle</div>
                    <div class="panel-body" style="width: 100%">
                          <div class="col-sm-4">
                        <div class="form-group">
                        <label>Regimen</label>
                            <asp:DropDownList ID="cboregimen" CssClass="form-control" runat="server"  OnSelectedIndexChanged="cboregimen_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                        <label>Aislamiento</label>

                             <asp:DropDownList ID="cboaislamiento" CssClass="form-control" runat="server"  OnSelectedIndexChanged="cboaislamiento_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="form-group">
                        <label>Bandeja</label>
                         <asp:DropDownList ID="cbobandeja" CssClass="form-control" runat="server"  OnSelectedIndexChanged="cbobandeja_SelectedIndexChanged" AutoPostBack="true"
                                    CausesValidation="true">
                                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            </asp:DropDownList>
                           
                        </div>
                    </div>

                    </div>
                    </div>


                </div>
           </div>
     
  
    <div class="panel panel-success">
        <div class="panel-heading">
            Alimnetacion Oral</div>
        <div class="panel-body" style="width: 100%">
            <div class="row">
                <div class="col-md-4 ">
                    <div class="panel panel-info">
                        <div class="panel-heading">Desayuno o Once</div>
                        <div class="panel-body" style="width: 100%">

                   
                            <div class="col-xs-6">
                             <center>   <img src="Imagenes/Almuerzos/desa_1.jpg" class="img-responsive img-radio" width="160px" height="100px">
                   
                                    <h5>
                                        Desayuno</h5>
                                    <asp:Button ID="btndesayuno" class="btn btn-danger" runat="server" Text="Off" OnClick="Btn_desayuno" OnClientClick="return validation1();" /></center>
                            </div>
                
                            <div class="col-xs-6">
                             <center>   <img src="Imagenes/Almuerzos/desa_1.jpg" class="img-responsive img-radio" width="160px" height="120px">
                              
                                    <h5>
                                        Once</h5>
                                    <asp:Button ID="btnonce" class="btn btn-danger" runat="server" Text="Off" OnClick="Btn_once" OnClientClick="return validation1();" /></center>
                            </div>

                            
                        </div>
                    </div>
                </div>
                <div class="col-md-4 ">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Colaciones</div>
                        <div class="panel-body" style="width: 100%">
                            <div class="col-xs-6">
                              <center>   <img src="Imagenes/Almuerzos/cola_1.jpg" class="img-responsive img-radio" width="160px" height="100px">
                               
                                    <h5>
                                        Mañana</h5>
                                    <asp:Button ID="btncolacionman" class="btn btn-danger" runat="server" Text="Off"  OnClick="Btn_colacion_man" OnClientClick="return validation1();" /></center> <br /> 
                            </div>
                            <div class="col-xs-6">
                             <center>   <img src="Imagenes/Almuerzos/cola_1.jpg" class="img-responsive img-radio" width="160px" height="100px">
                              
                                    <h5>
                                        Tarde</h5>
                                    <asp:Button ID="btncolaciontar" class="btn btn-danger" runat="server" Text="Off"  OnClick="Btn_colacion_tar" OnClientClick="return validation1();" /></center> <br /> 
                            </div>
                           
                            <div class="col-xs-6">
                              <center>   <img src="Imagenes/Almuerzos/cola_1.jpg" class="img-responsive img-radio" width="160px" height="100px">
                               
                                    <h5>
                                        Nocturna</h5>
                                    <asp:Button ID="btncolacionnoc" class="btn btn-danger" runat="server" Text="Off"  OnClick="Btn_colacion_noc" OnClientClick="return validation1();" /></center>
                            </div>
                            <div class="col-xs-6">
                              <center>  <img src="Imagenes/Almuerzos/hidri_1.jpg" class="img-responsive img-radio"  width="160px" height="100px">
                                
                                    <h5>
                                        Hibricos</h5>
                                    <asp:Button ID="btnhidricos" class="btn btn-danger" runat="server" Text="Off" OnClick="Btn_hidricos" OnClientClick="return validation1();" /></center>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 ">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            Almuerzo Cena</div>
                        <div class="panel-body" style="width: 100%">
                            <div class="col-xs-6">
                               <center>  <img src="Imagenes/Almuerzos/almu_1.jpg" class="img-responsive img-radio" width="160px" height="100px">
                               
                                    <h5>
                                        Almuerzo</h5>
                                    <asp:Button ID="btn_almuerzos" class="btn btn-danger" runat="server" Text="Off" OnClick="Btn_almuerzo1" OnClientClick="return validation1();" /></center>
                            </div>
                            <div class="col-xs-6">
                              <center>   <img src="Imagenes/Almuerzos/almu_1.jpg" class="img-responsive img-radio" width="160px" height="100px">
                                
                                    <h5>
                                        Cena</h5>
                                    <asp:Button ID="btncena" class="btn btn-danger" runat="server" Text="Off" OnClick="Btn_cena" OnClientClick="return validation1();" /></center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



           <div class="modal fade" id="btn_desayuno" tabindex="-1" role="dialog" aria-labelledby="contactLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="panel-title" id="H1"><span class="glyphicon glyphicon-info-sign"></span> Estimado Usuario</h4>
                    </div>
                   
                    <div class="modal-body" style="padding: 5px; ">
                         
                                <h4>¿Esta seguro  que desea  ingresar este alimento? </h4> 
                                
                           <div class="col-sm-12">
                        <div class="form-group">
                        <label>Tipo Alimento </label>
                        
                           <input type="text" class="form-control" id="txtalimento1"  runat="server" placeholder="Cama" name="txtalimento1" readonly />
                                        
                        </div>
                    </div>

                     <div class="col-sm-12">
                        <div class="form-group">
                        <label>Paciente</label>
                         <input type="text" class="form-control" id="txtpaciente2"  runat="server" placeholder="Cama" name="txtpaciente2" readonly />

                        </div>
                     </div>
                                
                                             

                        </div>  
                        <div class="panel-footer" style="margin-bottom:-14px;">
                        <center>
                         <asp:Button ID="Button5"  CssClass="btn btn-info" runat="server" Text="Aceptar" OnClick="desayuno" />
                     <button type="button" class="btn btn-danger" data-dismiss="modal" aria-hidden="true">Cancelar</button>
                      
                          </center>
                        </div>
                    </div>
                </div>
            </div>


</asp:Content>
