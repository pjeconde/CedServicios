<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comerciales.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Extensiones.Comerciales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table border="0" cellpadding="0" cellspacing="0" style="width:1282px">
	<tr>
		<td style="text-align: center; height: 10px;">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			DATOS COMERCIALES <a href="javascript:void(0)" id="ADC" role="button" class="popover-test" data-html="true" title="Datos Comerciales" style="width: 480px"
                              data-content="Si el tipo de comprobante que est� autorizando es Factura de cr�dito electr�nica del tipo MiPyMEs (FCE), agregar en REFERENCIAS el texto:<br>* 'CBU:???????????????', incluyendo el CBU donde le van a acreditar el pago de su factura.<br><br>Si el tipo de comprobante que est� ingresando es MiPyMEs (FCE) y corresponde a un comprobante de d�bito o cr�dito. Tener en cuenta que:<br>* s� el comprobante detallado en REFERENCIAS se encuentra rechazado por el comprador hay que informar agregar el texto 'ANUL:S' en DATOS COMERCIALES.<br>* s� el comprobante asociado en REFERENCIAS est� aceptado por el comprador hay que informar el texto 'ANUL:N' en DATOS COMERCIALES<br><br>Aclaraci�n, las comillas no debe ingresarse en DATOS COMERCIALES. Dejar un espacio entre 'CBU:??????????????????????' y 'ANUL:?'" />
                              <span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit;"/>
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
