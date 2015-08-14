<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Contacto.ascx.cs" Inherits="CedServicios.Site.Controles.Contacto" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!-- Nombre contacto -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top: 3px">
		<asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
			ControlToValidate="NombreContactoTextBox" ErrorMessage="Nombre Contacto" SetFocusOnError="True"
			ValidationExpression="[A-Za-z\- ,.0-9]*">
			<asp:Label ID="Label39" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="NombreContactoRequiredFieldValidator" runat="server" ControlToValidate="NombreContactoTextBox"
			ErrorMessage="Nombre Contacto" SetFocusOnError="True">
			<asp:Label ID="Label40" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RequiredFieldValidator>
		<asp:Label ID="Label8" runat="server" Text="Nombre Contacto"></asp:Label>
	</td>
	<td align="left" style="padding-top: 3px">
		<asp:TextBox ID="NombreContactoTextBox" runat="server" MaxLength="25" TabIndex="201"
			Width="400px"></asp:TextBox>
	</td>
</tr>
<!-- Mail Contacto -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top: 3px">
		<asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
			ControlToValidate="EmailContactoTextBox" ErrorMessage="Email Contacto" SetFocusOnError="True"
			ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
			<asp:Label ID="Label41" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="EmailContactoRequiredFieldValidator" runat="server" ControlToValidate="EmailContactoTextBox"
			ErrorMessage="Email Contacto" SetFocusOnError="True">
			<asp:Label ID="Label42" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RequiredFieldValidator>
		<asp:Label ID="Label9" runat="server" Text="Email Contacto"></asp:Label>
	</td>
	<td align="left" style="padding-top: 3px">
		<asp:TextBox ID="EmailContactoTextBox" runat="server" MaxLength="60" TabIndex="202"
			ToolTip="Muy importante! Todos los archivos XML serán enviados a esta casilla de correo. Verifique su correcto ingreso."
			Width="400px"></asp:TextBox>
	</td>
</tr>
<!-- Teléfono contacto -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top: 3px">
		<asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
			ControlToValidate="TelefonoContactoTextBox" ErrorMessage="Teléfono Contacto"
			SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
			<asp:Label ID="Label43" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RegularExpressionValidator>
		<asp:Label ID="Label10" runat="server" Text="Teléfono Contacto"></asp:Label>
	</td>
	<td align="left" style="padding-top: 3px">
		<asp:TextBox ID="TelefonoContactoTextBox" runat="server" MaxLength="50" TabIndex="203"
			Width="400px"></asp:TextBox>
	</td>
</tr>
