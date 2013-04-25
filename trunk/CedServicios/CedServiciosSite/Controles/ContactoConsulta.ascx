<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContactoConsulta.ascx.cs" Inherits="CedServicios.Site.Controles.ContactoConsulta" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!-- Nombre contacto -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top: 3px">
		<asp:Label ID="Label8" runat="server" Text="Nombre Contacto"></asp:Label>
	</td>
	<td align="left" style="padding-top: 3px">
		<asp:TextBox ID="NombreContactoTextBox" runat="server" MaxLength="25" TabIndex="12"
			Width="400px"></asp:TextBox>
	</td>
</tr>
<!-- Mail Contacto -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top: 3px">
		<asp:Label ID="Label9" runat="server" Text="Email Contacto"></asp:Label>
	</td>
	<td align="left" style="padding-top: 3px">
		<asp:TextBox ID="EmailContactoTextBox" runat="server" MaxLength="60" TabIndex="13"
			ToolTip="Muy importante! Los mails serán enviados a esta casilla de correo. Verifique su correcto ingreso."
			Width="400px"></asp:TextBox>
	</td>
</tr>
<!-- Teléfono contacto -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top: 3px">
		<asp:Label ID="Label10" runat="server" Text="Teléfono Contacto"></asp:Label>
	</td>
	<td align="left" style="padding-top: 3px">
		<asp:TextBox ID="TelefonoContactoTextBox" runat="server" MaxLength="50" TabIndex="14"
			Width="400px"></asp:TextBox>
	</td>
</tr>
