<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListaPrecioDefaultPersona.ascx.cs" Inherits="CedServicios.Site.Controles.ListaPrecioDefaultPersona" %>

<tr>
    <td valign="top" style="padding-right:5px; padding-top:6px; text-align:right">
        <asp:Label ID="IdListaPrecioLabel" runat="server" Text="Lista de Precios predefinida"></asp:Label>
    </td>
    <td align="left" style="padding-top:6px">
		<asp:DropDownList ID="IdListaPrecioDropDownList" runat="server" TabIndex="502" Width="183px" DataValueField="Id" DataTextField="Descr">
		</asp:DropDownList>
    </td>
</tr>
