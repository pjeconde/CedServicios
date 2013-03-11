<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioCambiarPassword.aspx.cs" Inherits="CedServicios.Site.UsuarioCambiarPassword" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 800px; text-align: left;">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td style="padding-left: 10px" valign="top" align="center">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="height: 20px;">
                                        <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Cambio de Contraseña de Usuario"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 21px">
                                    </td>
                                    <td align="left" style="padding-top: 10px;">
                                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Para realizar el cambio de la Contraseña de su cuenta eFact, ingrese los datos que se solicitan a continuación:"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                    <tr>
                        <td align="center" style="padding-top: 20px">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="right" style="padding-right: 10px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PasswordTextBox"
                                            ErrorMessage="Contraseña actual" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PasswordTextBox"
                                            ErrorMessage="Contraseña actual" SetFocusOnError="True">
                                            <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label15" runat="server" Text="Contraseña actual"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                                            TabIndex="1" TextMode="Password" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 10px; padding-top: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                                            ErrorMessage="Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                                            ErrorMessage="Contraseña nueva" SetFocusOnError="True">
                                            <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label1" runat="server" Text="Contraseña nueva"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-right: 10px; padding-top: 5px">
                                        <asp:TextBox ID="PasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                                            TabIndex="2" TextMode="Password" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="padding-right: 10px; padding-top: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                                            ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                                            ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True">
                                            <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="Label2" runat="server" Text="Confirmación de Contraseña nueva"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-right: 10px; padding-top: 5px">
                                        <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                                            TabIndex="3" TextMode="Password" Width="120px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left" style="padding-top: 5px">
                                        <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="4"
                                            Text="Aceptar" />
                                    </td>
                                    <td align="left" style="padding-top: 5px; padding-left: 5px">
                                        <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/Default.aspx"
                                            TabIndex="5" Text="Cancelar" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top: 10px">
                            <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                        </td>
                    </tr>
                    <!-- @@@ @@@-->
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
</asp:Content>
