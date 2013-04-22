<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ClienteSeleccionar.aspx.cs" Inherits="CedServicios.Site.ClienteSeleccionar" Theme="CedServicios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="domicilio" Src="~/Controles/Domicilio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contacto" Src="~/Controles/Contacto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivos" Src="~/Controles/DatosImpositivos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatorios" Src="~/Controles/DatosIdentificatorios.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="? de Cliente"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top: 20px">
                <asp:Label ID="Label3" runat="server" Text="Cliente perteneciente al CUIT"></asp:Label>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
	        <td align="left" style="padding-right:5px; padding-top:20px">
                <asp:RadioButton ID="TipoDocRadioButton" runat="server" AutoPostBack="true" Text="Tipo y Nro. de Documento" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged"/>
	        </td>
			<td align="left" style="padding-top:20px">
				<asp:DropDownList ID="TipoDocDropDownList" runat="server" TabIndex="2" Width="216px" DataValueField="Codigo" DataTextField="Descr"></asp:DropDownList>
                <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="3" ToolTip="Debe ingresar sólo números." Width="80px"></asp:TextBox>
			</td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                <asp:RadioButton ID="RazonSocialRadioButton" runat="server" AutoPostBack="true" Text="Razón Social" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged"/>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="4" Width="300px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                <asp:RadioButton ID="IdClienteRadioButton" runat="server" AutoPostBack="true" Text="Id.Cliente" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged"/>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="IdClienteTextBox" runat="server" MaxLength="50" TabIndex="501" Width="300px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                <asp:Button ID="BuscarButton" runat="server" TabIndex="504" Text="Buscar" onclick="BuscarButton_Click" />
                <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" TabIndex="505" Text="Cancelar" onclick="CancelarButton_Click" />
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
