<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PersonaCrear.aspx.cs" Inherits="CedServicios.Site.PersonaCrear" Theme="CedServicios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="domicilio" Src="~/Controles/Domicilio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contacto" Src="~/Controles/Contacto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivos" Src="~/Controles/DatosImpositivos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatorios" Src="~/Controles/DatosIdentificatorios.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosEmailAvisoComprobantePersona" Src="~/Controles/DatosEmailAvisoComprobantePersona.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table style="padding-left:10px">
        <tr>
            <td colspan="2" style="padding-top:20px; text-align: center">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Alta de Persona"></asp:Label>
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
                <asp:Label ID="Label3" runat="server" Text="Persona perteneciente al CUIT"></asp:Label>
            </td>
            <td style="padding-top:20px; text-align: left">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label10" runat="server" Text="Tipo de Persona:"></asp:Label>
                <asp:RadioButton ID="ClienteRadioButton" Text="Cliente" GroupName="TipoPersona" runat="server" OnCheckedChanged="TipoPersona_CheckedChanged" AutoPostBack="true" />
                <asp:RadioButton ID="ProveedorRadioButton" Text="Proveedor" GroupName="TipoPersona" runat="server" OnCheckedChanged="TipoPersona_CheckedChanged" AutoPostBack="true" />
                <asp:RadioButton ID="AmbosRadioButton" Text="Ambos" GroupName="TipoPersona" runat="server" Checked="true" oncheckedchanged="TipoPersona_CheckedChanged" AutoPostBack="true" />
            </td>
        </tr>
        <tr>
	        <td align="right" style="padding-right:5px; padding-top:5px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NroDocTextBox"
                    ErrorMessage="Nro. de Documnento" SetFocusOnError="True">
                    <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
		        <asp:Label ID="Label18" runat="server" Text="Tipo y Nro. de Documento"></asp:Label>
	        </td>
			<td align="left" style="padding-top:5px">
				<asp:DropDownList ID="TipoDocDropDownList" runat="server" TabIndex="2" 
                    Width="100px" DataValueField="Codigo" DataTextField="Descr" 
                    ToolTip="Para personas del exterior seleccione 'CUITPais'" AutoPostBack="true"
                    onselectedindexchanged="TipoDocDropDownList_SelectedIndexChanged" ></asp:DropDownList>
                <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="3" ToolTip="Debe ingresar sólo números." Width="90px" ></asp:TextBox>
                <asp:DropDownList ID="DestinosCuitDropDownList" runat="server" TabIndex="3" Width="306px" DataValueField="Codigo" DataTextField="Descr" Visible="false" ></asp:DropDownList>
                <asp:LinkButton ID="TraerDatosDeAFIPLinkButton" runat="server" SkinID="LinkButtonMediano" Text="Traer datos de AFIP" OnClick="TraerDatosDeAFIPLinkButton_Click" CausesValidation="false"></asp:LinkButton>
			</td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:5px">
                <asp:Label ID="Label7" runat="server" Text="Id.Persona"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="IdPersonaTextBox" runat="server" MaxLength="50" TabIndex="4" Width="300px"></asp:TextBox>
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
            <td align="right" style="padding-right:5px; padding-top:2px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                    ControlToValidate="RazonSocialTextBox" ErrorMessage="Razón Social" SetFocusOnError="True" ValidationExpression="[^']*$">
                    <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="RazonSocialTextBox"
                    ErrorMessage="Raz.Soc." SetFocusOnError="True">
                    <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label9" runat="server" Text="Razón Social"></asp:Label>
            </td>
            <td align="left" style="padding-top:2px">
                <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="5" Width="300px"></asp:TextBox>
            </td>        
        </tr>
        <uc1:domicilio ID="Domicilio" runat="server"/>
        <uc1:contacto ID="Contacto" runat="server" />
        <uc1:datosImpositivos ID="DatosImpositivos" runat="server" />
        <uc1:datosIdentificatorios ID="DatosIdentificatorios" runat="server" />
        <uc1:datosEmailAvisoComprobantePersona ID="DatosEmailAvisoComprobantePersona" runat="server" />
        <tr>
            <td colspan="2" style="padding-top:5px">
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" style="padding-right:5px">
                <asp:Label ID="Label38" runat="server" Text="Envío de <b>aviso</b> automático"></asp:Label><br />
                <asp:Label ID="Label46" runat="server" Text="<b>para visualización</b> del comprobante"></asp:Label><br />
                <asp:Label ID="Label4" runat="server" Text="(desde INTERFACTURAS)"></asp:Label>
            </td>
            <td style="border-style:solid; border-color:Gray; border-width:1px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right" style="padding-right:5px; padding-top:3px">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server"
                                ControlToValidate="EmailAvisoVisualizacionTextBox" ErrorMessage="Email aviso automático para visualización" SetFocusOnError="True"
                                ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                <asp:Label ID="Label44" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                            </asp:RegularExpressionValidator>
                            <asp:Label ID="Label45" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td align="left" style="padding-top:3px">
                            <asp:TextBox ID="EmailAvisoVisualizacionTextBox" runat="server" MaxLength="60" TabIndex="501"
                                ToolTip="A esta dirección se enviará un email de aviso para que el destinatario pueda visualizar el comprobante"
                                Width="315px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px; width:100px">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                ControlToValidate="PasswordAvisoVisualizacionTextBox" ErrorMessage="Contraseña aviso automático para visualización" SetFocusOnError="True"
                                ValidationExpression="[A-Za-z\- ,.0-9]*">
                                <asp:Label ID="Label40" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                            </asp:RegularExpressionValidator>
                            <asp:Label ID="Label42" runat="server" Text="Contraseña"></asp:Label>
                        </td>
                        <td align="left" style="padding-top:3px">
                            <asp:TextBox ID="PasswordAvisoVisualizacionTextBox" runat="server" MaxLength="25" TabIndex="502"
                                ToolTip="Para poder acceder al contenido del comprobante, se solicitará al destinatario el ingreso de esta contraseña"
                                Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="justify" style="padding-left:5px; padding-right:5px; padding-top:5px; font-size:xx-small" colspan="2">
                            Interfacturas enviará, a última hora del día, un aviso (con un link) para que su destinatario pueda visualizar el comprobante generado.<br />Esta funcionalidad puede ser usada, por ejemplo, cuando, por cuestiones de seguridad, no se quiera enviar facturas por email.
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                <asp:Button ID="AceptarButton" runat="server" TabIndex="503" Text="Aceptar" onclick="AceptarButton_Click" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="504" Text="Cancelar" onclick="SalirButton_Click" />
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
