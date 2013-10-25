<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="MensajeUsuarioDemo.aspx.cs" Inherits="CedServicios.Site.MensajeUsuarioDemo" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Usuario DEMO"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text="Este usuario no puede agregar, modificar o eliminar datos.<br/>Solo sirve para simular la carga de un comprobante electrónico."></asp:Label>
                <br />
                <br />
                <asp:Button ID="BotonContinuarBack" runat="server" Text="Continuar.." OnClientClick="JavaScript: window.history.back(1); return false;" />
                <asp:Button ID="BotonContinuar" runat="server" Text="Continuar" OnClick="BotonContinuar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
