<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioLogin.aspx.cs" Inherits="CedServicios.Site.Ingreso" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px; padding-top:20px;">
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:20px; padding-right:20px;">
                        <tr>
                            <td align="left">
                                <img alt="RG 3685" src="Imagenes/Diapositiva1.GIF" width="400px" height="387px" />
                                <br />
                                <br />
                                <br />
                                <asp:Label ID="Label1" runat="server" Font-Size="24px" Font-Bold="false" Text="Factura electrónica" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px; width:400px">
                                Este sitio le permite generar Facturas Electrónicas propias para gestionar el CAE a través de <b>Inter<font color="#006600"><i>Facturas</i></font></b>.<br />
                                (la red de facturas electrónicas de <b>Inter<font color="#800000"><i>Banking</i></font></b>)<br />
                                <br />
                                Si Ud. ya cuenta con un sistema de facturación, o utiliza una planilla Excel como herramienta de facturación y desea integrarlo al Régimen de Factura Electrónica, podemos ofrecerles diversas soluciones.<br />
                                <br />
                                Soporta los siguientes tipos de Factura Electrónica:<br />
                                <br />
                                &#8226; Común (RG2485 / RG2904), <br />
                                &#8226; Bono Fiscal (Bienes de Capital) y <br />
                                &#8226; Exportación (RG2758/2010).<br />
                                <br />
                                Entorno 
                                <asp:LinkButton ID="MultiCuitLinkButton" runat="server" TabIndex="4" Text="Multi-CUIT" onclick="MultiCuitLinkButton_Click" />, 
                                <asp:LinkButton ID="MultiUNLinkButton" runat="server" TabIndex="5" Text="Multi-Unidad de Negocio" onclick="MultiUNLinkButton_Click" />, 
                                <asp:LinkButton ID="MultiUsuarioLinkButton" runat="server" TabIndex="6" Text="Multi-Usuario" onclick="MultiUsuarioLinkButton_Click" />.<br />
                                Cargue de manera rápida, fácil y segura su Factura Electrónica con nuestro Servicio Web. 
                                Facilitamos el cumplimiento del régimen normativo de la AFIP.<br />
                                <br />
                                Para mas detalles sugerimos que se comuniquen desde <a href="InstitucionalContacto.aspx">Contacto</a> o bien escribiendonos a <a href="mailto:contacto@cedeira.com.ar">contacto@cedeira.com.ar</a>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:20px">
                                <asp:Label ID="AclaracionTituloLabel" runat="server" Font-Size="24px" Font-Bold="false" Text="" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px">
                                <asp:Label ID="AclaracionDetalleLabel" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton" BorderStyle="Solid" BorderWidth="1" BorderColor="#cccccc">
                                <table border="0" cellpadding="0" cellspacing="0" style="padding-left:20px; padding-right:20px;">
                                    <tr>
                                        <td align="center" colspan="3" style="padding-top:20px">
                                            <asp:Label ID="Label6" runat="server" SkinID="TituloPagina" Text="Iniciar sesión"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="TextoInicioMediano" style="padding-right: 10px; padding-top:20px">
                                            Id.Usuario
                                        </td>
                                        <td align="left" style="width: 100px; padding-top:20px">
                                            <asp:TextBox ID="UsuarioTextBox" runat="server" MaxLength="50" OnTextChanged="UsuarioTextBox_TextChanged"
                                                TabIndex="1" Width="114px"></asp:TextBox>
                                        </td>
                                        <td align="left" rowspan="2" style="padding-right: 10px; padding-top:20px">
                                            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" TabIndex="3" Text="Iniciar" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="TextoInicioMediano" style="padding-right: 10px; padding-top:5px">
                                            Contraseña
                                        </td>
                                        <td align="left" style="width: 100px; padding-right: 10px; padding-top:5px">
                                            <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="PasswordTextBox_TextChanged"
                                                TabIndex="2" TextMode="Password" Width="114px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding-top:20px;">
                                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text="&nbsp;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding-top:20px">
                                            <asp:HyperLink ID="CuentaCrearHyperLink" runat="server" NavigateUrl="~/UsuarioCrear.aspx" SkinID="LinkMedianoClaro">Crear una nueva cuenta</asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding-top:5px; padding-bottom:0px">
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioOlvidoId.aspx" SkinID="LinkMedianoClaro">¿Olvidó su Id.Usuario?</asp:HyperLink>
                                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/UsuarioOlvidoPassword.aspx" SkinID="LinkMedianoClaro">¿Olvidó su Contraseña?</asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table border="0" cellpadding="0" cellspacing="0" style="padding-left:20px; padding-right:20px; padding-top:20px; width: 300px;"> <%--; background-image: url('Imagenes/Factura-UsuarioDemo.png'); background-repeat: no-repeat--%>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding-top:10px;">
                                                        <asp:Label ID="Label2" Width="200px" runat="server" SkinID="TituloMedianoC" Text="Para ingresar en la modalidad DEMO"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding-top:10px; padding-bottom:40px">
                                                        <asp:Button ID="LoginUsuarioDEMOButton" runat="server" OnClick="LoginUsuarioDEMOButton_Click" TabIndex="3" Text="Haga Clic Aqui" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top:20px">
                            <asp:HyperLink ID="EmpresaHyperLink" runat="server" 
                                NavigateUrl="~/InstitucionalEmpresa.aspx" SkinID="LinkChicoClaro">Empresa</asp:HyperLink>
                            |
                            <asp:HyperLink ID="HyperLink1" runat="server" 
                                NavigateUrl="~/InstitucionalSoluciones.aspx" SkinID="LinkChicoClaro">Soluciones</asp:HyperLink>
                            |
                            <asp:HyperLink ID="HyperLink3" runat="server" 
                                NavigateUrl="~/InstitucionalRefeCom.aspx" SkinID="LinkChicoClaro">Referencias Comerciales</asp:HyperLink>
                            |
                            <asp:HyperLink ID="HyperLink4" runat="server" 
                                NavigateUrl="~/InstitucionalContacto.aspx" SkinID="LinkChicoClaro">Contacto</asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </td>
            <td rowspan="2" valign="top" style="padding-left:20px">
                <asp:Image ID="Image1" ImageUrl="~/Imagenes/eFact-vertical.jpg" runat="server" Width="250px" />
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:5px">
                <asp:HyperLink ID="HyperLink5" runat="server" 
                    NavigateUrl="~/ActividadesAlcanzadas.aspx" SkinID="LinkChicoClaro">Actividades alcanzadas por el Régimen de Factura Electrónica</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink6" runat="server" 
                    NavigateUrl="~/PreguntasFrecuentes.aspx" SkinID="LinkChicoClaro">Preguntas frecuentes</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-bottom:10px;">
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            width: 302px;
            height: 468px;
        }
    </style>
</asp:Content>

