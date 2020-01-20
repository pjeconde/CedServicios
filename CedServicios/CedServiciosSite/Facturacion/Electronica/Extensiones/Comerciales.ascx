<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comerciales.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Extensiones.Comerciales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table border="0" cellpadding="0" cellspacing="0" style="width:1282px">
	<tr>
		<td style="text-align: center; height: 10px;">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			DATOS COMERCIALES <a href="javascript:void(0)" id="A2" role="button" class="popover-test" data-html="true" title="Código de operación" style="width: 280px"
                                                        data-content="Los formatos permitidos según las opciones seleccionadas son dos.<br/><br/>Uno es <b>?????-????????</b>(5 dígitos para el punto de venta y 8 dígitos para el nro. de comprobante).<br/><br/> Otro para Notas de Crédito MiPyMEs es <b>?????-????????-???????????-????????</b> (se le agrega 11 dígitos para el CUIT del vendedor y 8 dígitos formato AAAAMMDD para la fecha de emisión del comprobante referenciado).<br><br>Si la nota de crédito MiPyMEs anula una Factura de crédito MiPyMEs y ésta, no fué rechazada por el cliente, debe agregar en <b>DATOS COMERCIALES</b> el siguiente texto: <b> ANUL:N</b>
Si el comprobante fué rechazado por su proveedor, debe ingresar el texto: <b>ANUL:S</b><br><br>También puede ser libre, sin formato.">
                                                        <span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit;">
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
