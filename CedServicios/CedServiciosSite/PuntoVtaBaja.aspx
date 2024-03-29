﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PuntoVtaBaja.aspx.cs" Inherits="CedServicios.Site.PuntoVtaBaja" Theme="CedServicios" %>
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
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Baja/Anul.baja de Punto de Venta"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-right: 5px; padding-top: 20px; text-align: right">
                <asp:Label ID="Label19" runat="server" Text="CUIT"></asp:Label>
            </td>
            <td style="padding-top: 20px; text-align: left">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                    Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-right: 5px; padding-top:5px; text-align: right">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="NroTextBox" ErrorMessage="Nro. de Punto de Venta" SetFocusOnError="True" ValidationExpression="[0-9]{0,4}">
                    <asp:Label ID="Label7" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NroTextBox"
                    ErrorMessage="Nro. de Punto de Venta" SetFocusOnError="True">
                    <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label2" runat="server" Text="Nro. de Punto de Venta"></asp:Label>
            </td>
            <td style="padding-top:5px; text-align: left">
                <asp:TextBox ID="NroTextBox" runat="server" MaxLength="4" TabIndex="2" ToolTip="Debe ingresar sólo números."
                    Width="40px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:5px">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height:1px; background-color:#cccccc">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:5px">
            </td>
        </tr>
        <tr>
            <td style="padding-right:5px; padding-top:2px; height:25px; text-align: right">
                <asp:Label ID="Label5" runat="server" Text="Unidad de Negocio"></asp:Label>
            </td>
            <td style="padding-top:2px; height:25px; text-align: left">
                <asp:DropDownList ID="IdUNDropDownList" runat="server" TabIndex="3" Width="183px" DataValueField="Id" DataTextField="Descr" >
                </asp:DropDownList>
            </td>
        </tr> 
        <tr>
	        <td style="padding-right:5px; padding-top:5px; text-align: right">
		        <asp:Label ID="Label18" runat="server" Text="Tipo Punto de Venta"></asp:Label>
	        </td>
			<td style="padding-top:5px; text-align: left">
				<asp:DropDownList ID="IdTipoPuntoVtaDropDownList" runat="server" TabIndex="18" Width="216px" DataValueField="Id" DataTextField="Descr">
				</asp:DropDownList>
			</td>
        </tr>
        <tr>
	        <td style="padding-right:5px; padding-top:5px; text-align: right">
		        <asp:Label ID="Label1" runat="server" Text="Método de numeración de lotes"></asp:Label>
	        </td>
			<td style="padding-top:5px; text-align: left">
				<asp:DropDownList ID="IdMetodoGeneracionNumeracionLoteDropDownList" runat="server" TabIndex="18" Width="650px" DataValueField="Id" DataTextField="Descr">
				</asp:DropDownList>
			</td>
        </tr>
        <tr>
            <td style="padding-right: 5px; padding-top:5px; text-align: right">
                <asp:Label ID="Label3" runat="server" Text="Último nro. de lote"></asp:Label>
            </td>
            <td style="padding-top:5px; text-align: left">
                <asp:TextBox ID="UltNroLoteTextBox" runat="server" MaxLength="14" TabIndex="3" ToolTip="Debe ingresar sólo números."
                    Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-right: 5px; padding-top:5px; text-align: right">
                <asp:Label ID="Label4" runat="server" Text="Usa datos CUIT"></asp:Label>
            </td>
            <td style="padding-top:5px; text-align: left">
                <asp:CheckBox ID="UsaDatosCuitCheckBox" runat="server" 
                    Checked="true" AutoPostBack="true"
                    oncheckedchanged="UsaDatosCuitCheckBox_CheckedChanged" />
                <asp:Label ID="Label6" runat="server" Text="( se refiere a Domicilio, Contacto y Datos Impositivos e Identificatorios )"></asp:Label>
            </td>
        </tr>
        <uc1:domicilio ID="Domicilio" runat="server" />
        <uc1:contacto ID="Contacto" runat="server" />
        <uc1:datosImpositivos ID="DatosImpositivos" runat="server" />
        <uc1:datosIdentificatorios ID="DatosIdentificatorios" runat="server" />
        <tr>
            <td>
            </td>
            <td style="height: 24px; padding-top:20px; text-align: left">
                <asp:Button ID="AceptarButton" runat="server" TabIndex="4" Text="Aceptar" onclick="AceptarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="5" Text="Cancelar" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:20px; text-align: center">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
    </div>
    </div>
    </div>
</asp:Content>
