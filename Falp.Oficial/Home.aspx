<%@ Page Title="" Language="C#" MasterPageFile="~/General_Oficial.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Falp.Oficial.Home1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="Subtitulo">
      Bienvenido, Estimado Usuario:  <asp:Label ID="txtusuario" runat="server"  ></asp:Label>
 
           <center><asp:Button ID="Button1"  CssClass="btn btn-success" runat="server" Text="Ingresar Pedido" OnClick="ingresar" />
           </center>
           </div>
          

           
          <!--start-->
        <div style="padding:1px 0;">
            <div id="thumbnail-slider">
                <div class="inner">
                    <ul>
                        <li>
                            <a class="thumb" href="Imagenes/carrusel/nut_13.jpg" />
                        </li>
                       
                        <li>
                            <a class="thumb" href="Imagenes/carrusel/nut_12.jpg" />
                        </li>
                          <li>
                            <a class="thumb" href="Imagenes/carrusel/nut_8.jpg" />
                        </li>
                           <li>
                            <a class="thumb" href="Imagenes/carrusel/nut_11.png" />
                        </li>
                         <li>
                            <a class="thumb" href="Imagenes/carrusel/nut_1.jpg" />
                        </li>
                   
                    
                    </ul>
                </div>
            </div>
        </div>




</asp:Content>
