<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="CuitCambiarLogotipo.aspx.cs" Inherits="CedServicios.Site.CuitCambiarLogotipo" Theme="CedServicios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="domicilio" Src="~/Controles/Domicilio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contacto" Src="~/Controles/Contacto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivos" Src="~/Controles/DatosImpositivos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatorios" Src="~/Controles/DatosIdentificatorios.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Cambio del logotipo de CUIT"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top: 20px">
                <asp:Label ID="Label3" runat="server" Text="CUIT"></asp:Label>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                    Width="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
	        <td align="right" valign="top" style="padding-right:5px; padding-top:5px">
		        <asp:Label ID="Label4" runat="server" Text="Logotipo<br />para<br />comprobantes<br />(archivos bmp de 106x500 pixels)" ></asp:Label>
	        </td>
			<td align="left" style="padding-top:5px">
                <asp:Image ID="LogotipoImage" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="Imagenes/Interrogacion106x500.bmp"
                Width="500px" Height="106px" />
			</td>
        </tr>
        <tr>
	        <td align="right" style="padding-right:5px; padding-top:5px">
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Seleccione la imagen que se usará como logotipo en los comprobantes" TabIndex="502" />
	        </td>
			<td align="left" style="padding-top:5px">
                <asp:Button ID="SubirImagenButton" runat="server" TabIndex="503" Text="Subir imagen seleccionada" onclick="SubirImagenButton_Click" />
                <asp:Button ID="BorrarImagenButton" runat="server" TabIndex="504" Text="Borrar imagen actual" onclick="BorrarImagenButton_Click" />
			</td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="506" Text="Salir" PostBackUrl="~/Default.aspx" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary">
                </asp:ValidationSummary>
            </td>
        </tr>
    </table>
</asp:Content>
