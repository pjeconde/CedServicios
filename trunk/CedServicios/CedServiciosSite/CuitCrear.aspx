<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="CuitCrear.aspx.cs" Inherits="CedServicios.Site.CuitCrear" Theme="CedServicios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="domicilio" Src="~/Controles/Domicilio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contacto" Src="~/Controles/Contacto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivos" Src="~/Controles/DatosImpositivos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatorios" Src="~/Controles/DatosIdentificatorios.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Alta de CUIT"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top: 20px">
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
            <td align="left" style="padding-top:20px">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                    Width="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <hr noshade="noshade" size="1" color="#cccccc" />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:2px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RazonSocialTextBox"
                    ErrorMessage="Raz.Soc." SetFocusOnError="True">
                    <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label9" runat="server" Text="Razón Social"></asp:Label>
            </td>
            <td align="left" style="padding-top:2px">
                <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="2" Width="300px"></asp:TextBox>
            </td>        
        </tr>
        <uc1:domicilio ID="Domicilio" runat="server"/>
        <uc1:contacto ID="Contacto" runat="server" />
        <uc1:datosImpositivos ID="DatosImpositivos" runat="server" />
        <uc1:datosIdentificatorios ID="DatosIdentificatorios" runat="server" />
        <tr>
	        <td align="right" style="padding-right:5px; padding-top:5px">
		        <asp:Label ID="Label18" runat="server" Text="¿Cómo nos conoció?"></asp:Label>
	        </td>
			<td align="left" style="padding-top:5px">
				<asp:DropDownList ID="MedioDropDownList" runat="server" TabIndex="501" Width="216px" DataValueField="Id" DataTextField="Descr">
				</asp:DropDownList>
			</td>
        </tr>
        <tr>
	        <td align="right" style="padding-right:5px; padding-top:5px">
		        <asp:Label ID="Label5" runat="server" Text="Servicios"></asp:Label>
	        </td>
			<td align="left" style="padding-top:5px">
                <asp:CheckBox ID="eFactCheckBox" runat="server" AutoPostBack="true" Text="Factura electrónica" Checked="true" TabIndex="502" />
                <asp:CheckBox ID="resTurCheckBox" runat="server" AutoPostBack="true" Text="Reservas turísticas" Checked="false" TabIndex="503" Visible="false"/>
			</td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px" valign="top">
                <asp:Label ID="Label11" runat="server" Text="Destinos de comprobantes<br>(para servicio de<br>factura electrónica)"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" valign="top">
                            <asp:CheckBox ID="DestinoComprobanteITFCheckBox" runat="server" AutoPostBack="true" Text="Interbanking (Interfacturas)" Checked="true" TabIndex="504"/>
                        </td>
                        <td align="left" valign="middle" style="padding-left:5px">
                            <asp:Label ID="Label12" runat="server" Text="--> Nro.serie certif.:"></asp:Label>
                        </td>
                        <td align="left" valign="top" style="padding-left:5px">
                            <asp:TextBox ID="NroSerieCertifITFTextBox" runat="server" MaxLength="256" TabIndex="505" Width="120px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <asp:CheckBox ID="DestinoComprobanteAFIPCheckBox" runat="server" AutoPostBack="true" Text="A.F.I.P." Checked="true" TabIndex="506" />
                        </td>
                        <td align="left" valign="middle" style="padding-left:5px" colspan="2">
                            <asp:Label ID="Label4" runat="server" Text="-->"></asp:Label>
                            <asp:CheckBox ID="UsaCertificadoAFIPPropioCheckBox" runat="server" AutoPostBack="true" TextAlign="Left" Text="Usa certificado propio" Checked="false" TabIndex="507" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top:5px">
            </td>
            <td align="left" style="padding-top:5px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                <asp:Button ID="AceptarButton" runat="server" TabIndex="508" Text="Aceptar" onclick="AceptarButton_Click" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="509" Text="Cancelar" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
</asp:Content>