<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosImpositivosConsulta.ascx.cs" Inherits="CedServicios.Site.Controles.DatosImpositivosConsulta" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!-- CondIVA -->
<tr>
	<td style="padding-right:5px; padding-right: 5px; padding-top: 5px; text-align: right">
		<asp:Label ID="Label11" runat="server" Text="Cond.IVA"></asp:Label>
	</td>
	<td style="padding-top:5px; text-align: left">
		<asp:DropDownList ID="CondIVADropDownList" runat="server" TabIndex="16" Width="255px" DataValueField="Codigo" DataTextField="Descr">
		</asp:DropDownList>
	</td>
</tr>
<!-- NroIngBrutos y CondIngBrutos -->
<tr>
	<td style="padding-left: 10px; padding-right: 5px; padding-top: 5px; text-align: right">
		<asp:Label ID="Label18" runat="server" Text="Cond.Ing.Brutos"></asp:Label>
	</td>
	<td style="padding-top:5px; text-align: left">
		<table>
			<tr>
				<td align="left">
					<asp:DropDownList ID="CondIngBrutosDropDownList" runat="server" TabIndex="18" Width="183px" DataValueField="Codigo" DataTextField="Descr">
					</asp:DropDownList>
				</td>
	            <td align="right" style="padding-left: 15px; padding-right: 5px;">
		            <asp:Label ID="Label20" runat="server" Text="Nro.Ing.Brutos"></asp:Label>
	            </td>
				<td>
					<asp:TextBox ID="NroIngBrutosTextBox" runat="server" MaxLength="13" TabIndex="17"
						ToolTip="Ingresar con el siguiente formato: 9999999-99" Width="80px"></asp:TextBox>
				</td>
			</tr>
		</table>
	</td>
</tr>
<!-- FechaInicioActividades  -->
<tr>
	<td style="padding-left: 10px; padding-right: 5px; padding-top: 5px; text-align: right">
        <asp:Label ID="Label22" runat="server" Text="Fecha de inicio de actividades"></asp:Label>
	</td>
	<td style="padding-top: 5px; text-align: left">
        <asp:TextBox ID="FechaInicioActividadesTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="70px"></asp:TextBox>
    </td>
</tr>

