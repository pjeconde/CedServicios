<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="CedServicios.Site.Ingreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
                <asp:Panel ID="LoginPanel" runat="server" BackColor="cornsilk" BorderColor="peachpuff"
                    BorderStyle="Double" BorderWidth="3px" Width="300px">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 142px">
                        <tr>
                            <td align="center" colspan="3" style="height: 30px" valign="middle">
                                            <asp:Label ID="Label6" runat="server" Font-Size="12px" Text="Iniciar sesión"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="TextoInicioMediano" style="height: 20px; padding-left: 10px;
                                padding-right: 10px;">
                                Id.Usuario
                            </td>
                            <td align="left" style="width: 100px;">
                                <asp:TextBox ID="UsuarioTextBox" runat="server" OnTextChanged="UsuarioTextBox_TextChanged"
                                    TabIndex="1" Width="114px"></asp:TextBox>
                            </td>
                            <td align="left" rowspan="2" style="padding-right: 10px">
                                <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" TabIndex="3"
                                    Text="Acceder" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="TextoInicioMediano" style="height: 20px; padding-left: 10px;
                                padding-right: 10px; padding-top: 5px">
                                Contraseña
                            </td>
                            <td align="left" style="width: 100px; padding-right: 10px; padding-top: 5px">
                                <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="PasswordTextBox_TextChanged"
                                    TabIndex="2" TextMode="Password" Width="114px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding-top: 5px;">
                                <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text="&nbsp;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding-top: 5px; color: Blue">
                                <asp:HyperLink ID="CuentaCrearHyperLink" runat="server" NavigateUrl="~/CuentaCrear.aspx"
                                    SkinID="LinkMedianoClaro">Crear una nueva cuenta</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="color: Blue">
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/CuentaOlvidoId.aspx"
                                    SkinID="LinkMedianoClaro">¿Olvidó su Id.Usuario?</asp:HyperLink>
                                <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/CuentaOlvidoPassword.aspx"
                                    SkinID="LinkMedianoClaro">¿Olvidó su Contraseña?</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" style="padding-bottom: 8px">
                                <a href="javascript:window.external.AddFavorite('http://www.cedeira.com.ar/Inicio.aspx','Cedeira');"
                                    style="color: Blue">Agregar a favoritos</a>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
</asp:Content>
