<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListaPrecioDefaultPersona.ascx.cs" Inherits="CedServicios.Site.Controles.ListaPrecioDefaultPersona" %>

<tr>
    <td valign="top" style="padding-right:5px; padding-top:6px; text-align:right">
        <asp:Label ID="IdListaPrecioVentaLabel" runat="server" Text="Lista de Precios de venta predefinida"></asp:Label>
    </td>
    <td align="left" style="padding-top:6px">
		<asp:DropDownList ID="IdListaPrecioVentaDropDownList" runat="server" TabIndex="502" Width="183px" DataValueField="Id" DataTextField="Descr">
		</asp:DropDownList>
    </td>
</tr>
<tr>
    <td valign="top" style="padding-right:5px; padding-top:6px; text-align:right">
        <asp:Label ID="IdListaPrecioCompraLabel" runat="server" Text="Lista de Precios de compra predefinida"></asp:Label>
    </td>
    <td align="left" style="padding-top:6px">
		<asp:DropDownList ID="IdListaPrecioCompraDropDownList" runat="server" TabIndex="502" Width="183px" DataValueField="Id" DataTextField="Descr">
		</asp:DropDownList>
    </td>
</tr>
