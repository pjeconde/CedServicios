<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioConfirmacion.aspx.cs" Inherits="CedServicios.Site.UsuarioConfirmacion" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="padding-left:10px; text-align: left;">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Confirmación de creación de cuenta"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
