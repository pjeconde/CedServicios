<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioOlvidoId.aspx.cs" Inherits="CedServicios.Site.UsuarioOlvidoId" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <!-- @@@ TITULO DE LA PAGINA @@@-->
        <tr>
            <td colspan="3" align="center" style="padding-top:20px";>
                <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="¿ Olvidó el Id.Usuario de su cuenta ?"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left" style="padding-top:10px;">
                <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Si no recuerda el Id.Usuario de su cuenta, ingrese el eMail, que registró en el momento de creación de su cuenta."></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left" style="padding-top:10px;">
                <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="Le enviaremos su Id.Cuenta por correo electrónico, a esa dirección."></asp:Label>
            </td>
        </tr>
        <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
        <tr>
            <td align="right" style="padding-top:5px; padding-right: 5px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EmailTextBox"
                    ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                    <asp:Label ID="Label11" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox"
                    ErrorMessage="Email" SetFocusOnError="True">
                    <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td align="left" colspan="2" style="padding-top:5px">
                <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="3" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="4"
                    Text="Solicitar Id.Usuario" />
            </td>
            <td align="right" style="padding-top:20px">
                <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/UsuarioLogin.aspx"
                    TabIndex="5" Text="Cancelar" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="padding-top:20px">
                <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
            </td>
        </tr>
        <!-- @@@ @@@-->
    </table>
</asp:Content>
