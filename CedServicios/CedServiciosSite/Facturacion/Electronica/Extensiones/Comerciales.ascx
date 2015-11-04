<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comerciales.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Extensiones.Comerciales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table border="0" cellpadding="0" cellspacing="0" style="width:1282px">
	<tr>
		<td style="text-align: center; height: 10px;">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			DATOS COMERCIALES
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
		</td>
	</tr>
	<tr>
		<td style="text-align:center; font-weight:normal; width:1280px;">
			<asp:TextBox ID="DatosComericalesTextBox" runat="server" Style="width:1260px; resize:none" TextMode="MultiLine"></asp:TextBox>
			<cc1:filteredtextboxextender id="DatosComFilteredTextBoxExtender" runat="server" targetcontrolid="DatosComericalesTextBox" 
			FilterType="Custom" FilterMode="InvalidChars"  InvalidChars="<>"></cc1:filteredtextboxextender>
		</td>
	</tr>
</table>
