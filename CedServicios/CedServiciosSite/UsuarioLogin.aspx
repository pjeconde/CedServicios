<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioLogin.aspx.cs" Inherits="CedServicios.Site.Ingreso" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px; padding-top:20px;">
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:20px; padding-right:20px;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Font-Size="24px" Font-Bold="false" Text="Factura electrónica" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px">
                                Entorno Multi-Cuit, Multi-Unidad de Negocio, Multi-Usuario.<br />
                                Ingrese su Factura Electrónica y genere el archivo XML para Interfacturas<br />
                                (la red de facturas electrónicas de Interbanking)<br />
                                Es gratuito, rápido, fácil y seguro.<br />
                                Soporta los siguientes tipos de Factura Electrónica:<br />
                                <br />
                                - Común (RG2485 / RG2904), <br />
                                - Bono Fiscal (Bienes de Capital) y <br />
                                - Exportación (RG2758/2010).<br />
                                <br />
                                Cargue gratis su Factura Electrónica con nuestro Servicio Web<br />
                                Facilitamos el cumplimiento del régimen normativo de la AFIP<br />
                                Podemos integrar su sistema de facturación a la red de Interfacturas.<br />
                                ¿ Usa una planilla Excel como herramienta de facturación ?<br />
                                La podemos integrar a la red de Interfacturas<br />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td valign="top">
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
                                <asp:TextBox ID="UsuarioTextBox" runat="server" OnTextChanged="UsuarioTextBox_TextChanged"
                                    TabIndex="1" Width="114px"></asp:TextBox>
                            </td>
                            <td align="left" rowspan="2" style="padding-right: 10px; padding-top:20px">
                                <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" TabIndex="3"
                                    Text="Iniciar" />
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
                                <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text="&nbsp;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding-top:20px">
                                <asp:HyperLink ID="CuentaCrearHyperLink" runat="server" NavigateUrl="~/UsuarioCrear.aspx" SkinID="LinkMedianoClaro">Crear una nueva cuenta</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding-top:5px; padding-bottom:20px">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioOlvidoId.aspx" SkinID="LinkMedianoClaro">¿Olvidó su Id.Usuario?</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/UsuarioOlvidoPassword.aspx" SkinID="LinkMedianoClaro">¿Olvidó su Contraseña?</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
