<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="CuitTreeView.aspx.cs" Inherits="CedServicios.Site.CuitTreeView" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px;">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Consulta de CUIT(s)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:TreeView ID="TituloCuitsTreeView" runat="server">
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:TreeView ID="CuitsTreeView" runat="server" 
                    onselectednodechanged="CuitsTreeView_SelectedNodeChanged">
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" Text="Salir" PostBackUrl="~/Default.aspx"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
