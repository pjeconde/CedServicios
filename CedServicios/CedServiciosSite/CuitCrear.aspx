<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="CuitCrear.aspx.cs" Inherits="CedServicios.Site.CuitCrear" Theme="CedServicios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="domicilio" Src="~/Controles/Domicilio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contacto" Src="~/Controles/Contacto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivos" Src="~/Controles/DatosImpositivos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatorios" Src="~/Controles/DatosIdentificatorios.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table align="center">
        <tr>
            <td colspan="2" style="padding-top:20px; text-align: center">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Alta de CUIT"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-right:5px; padding-top: 20px; text-align: right">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="CUITTextBox" ErrorMessage="CUIT" SetFocusOnError="True" ValidationExpression="[0-9]{11}">
                    <asp:Label ID="Label1" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CUITTextBox"
                    ErrorMessage="CUIT" SetFocusOnError="True">
                    <asp:Label ID="Label2" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label3" runat="server" Text="CUIT"></asp:Label>
            </td>
            <td style="padding-top:20px; text-align: left">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                &nbsp;<a href="#" id="example" role="button" class="popover-test" data-html="true" title="DATOS DEL VENDEDOR" data-content="En esta página se registran todos los datos de la persona que emitirá comprobantes de venta."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit"></span></a>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr noshade="noshade" size="1" color="#cccccc" />
            </td>
        </tr>
        <tr>
            <td style="padding-right:5px; padding-top:2px; text-align: right">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RazonSocialTextBox"
                    ErrorMessage="Raz.Soc." SetFocusOnError="True">
                    <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label9" runat="server" Text="Razón Social"></asp:Label>
            </td>
            <td style="padding-top:2px; text-align: left">
                <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="2" Width="400px"></asp:TextBox>
            </td>        
        </tr>
        <uc1:domicilio ID="Domicilio" runat="server"/>
        <uc1:contacto ID="Contacto" runat="server" />
        <uc1:datosImpositivos ID="DatosImpositivos" runat="server" />
        <uc1:datosIdentificatorios ID="DatosIdentificatorios" runat="server" />
        <tr>
	        <td style="padding-right:5px; padding-top:5px; text-align: right">
		        <asp:Label ID="Label18" runat="server" Text="¿Cómo nos conoció?"></asp:Label>
	        </td>
			<td style="padding-top:5px; text-align: left">
				<asp:DropDownList ID="MedioDropDownList" runat="server" TabIndex="501" Width="216px" DataValueField="Id" DataTextField="Descr">
				</asp:DropDownList>
			</td>
        </tr>
        <tr>
	        <td style="padding-right:5px; padding-top:5px; text-align: right">
		        <asp:Label ID="Label5" runat="server" Text="Servicios"></asp:Label>
	        </td>
			<td style="padding-top:5px; text-align: left">
                <asp:CheckBox ID="eFactCheckBox" runat="server" AutoPostBack="true" Text="&nbsp;Factura electrónica" Checked="true" TabIndex="502" />
                <asp:CheckBox ID="resTurCheckBox" runat="server" AutoPostBack="true" Text="Reservas turísticas" Checked="false" TabIndex="503" Visible="false"/>
			</td>
        </tr>
        <tr>
            <td style="padding-right: 5px; padding-top:5px; text-align: right; vertical-align: top">
                <asp:Label ID="Label11" runat="server" Text="Destinos de comprobantes<br>(para servicio de<br>factura electrónica)"></asp:Label>
            </td>
            <td style="padding-top:10px; text-align: left">
                <table>
                    <tr>
                        <td style="text-align: left; vertical-align: top">
                            <asp:CheckBox ID="DestinoComprobanteITFCheckBox" runat="server" AutoPostBack="true" Text="&nbsp;Interfacturas" Checked="true" TabIndex="504"/>&nbsp;<a href="#" role="button" class="popover-test" data-html="true" title="INTERFACTURAS (INTERBANKING)" data-content="Marque este campo si gestionará el CAE a través de Interfacturas, en forma ONLINE.<br/><br/>Si solo genera archivos XML para subir en el Sitio Web de Interfacturas de forma manual, no debe marcar esta casilla."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit"></span></a>
                        </td>
                        <td style="text-align: left; vertical-align: top; padding-left:40px">
                            <span class="glyphicon glyphicon-menu-right" aria-hidden="true"></span>&nbsp;<font style="font-family: Sans-Serif"><b>Nro.serie certif.:</b></font>
                            <asp:TextBox ID="NroSerieCertifITFTextBox" runat="server" MaxLength="256" TabIndex="505" Width="100px"></asp:TextBox>&nbsp;<asp:Literal runat="server" ID="AyudaNroSerieCertif" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top:5px; vertical-align: top">
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; vertical-align: top"">
                            <asp:CheckBox ID="DestinoComprobanteAFIPCheckBox" runat="server" AutoPostBack="true" Text="&nbsp;A.F.I.P." Checked="true" TabIndex="506" />&nbsp;<a href="#" role="button" class="popover-test" data-html="true" title="A.F.I.P." data-content="Marque este campo si gestionará el CAE a través de la AFIP, en forma ONLINE."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit"></span></a>
                        </td>
                        <td style="text-align: left; vertical-align: middle; padding-left:40px">
                                 <font style="font-family: Sans-Serif"><span class="glyphicon glyphicon-menu-right" aria-hidden="true"></span>&nbsp;<asp:CheckBox ID="UsaCertificadoAFIPPropioCheckBox" runat="server" AutoPostBack="true"  TextAlign="Left" Text="Usa certificado propio&nbsp;" Checked="false" TabIndex="507" /></font>
                                 &nbsp;<a href="#" role="button" class="popover-test" data-html="true" title="USA CERTIFICADO PROPIO?" data-content="Marque esta casilla únicamente si:<br>
                                Genera el CAE con la AFIP y tiene Certificado Digital propio generado en la AFIP.<br><br>( Si genera el CAE con AFIP pero utiliza el Certificado de Cedeira SF SRL, luego de haber delegado, no marque esta casilla )"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit"></span></a>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="padding-right: 5px; padding-top:5px; text-align: right">
            </td>
            <td style="padding-top:5px; text-align: left">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="height: 24px; padding-top:20px; text-align: left">
                <asp:Button ID="AceptarButton" runat="server" TabIndex="508" Text="Aceptar" onclick="AceptarButton_Click" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="509" Text="Cancelar" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:20px; text-align: center">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
</asp:Content>