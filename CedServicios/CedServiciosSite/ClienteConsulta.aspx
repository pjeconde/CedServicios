<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ClienteConsulta.aspx.cs" Inherits="CedServicios.Site.ClienteConsulta" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="uc1" TagName="domicilioConsulta" Src="~/Controles/DomicilioConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contactoConsulta" Src="~/Controles/ContactoConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivosConsulta" Src="~/Controles/DatosImpositivosConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatoriosConsulta" Src="~/Controles/DatosIdentificatoriosConsulta.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Clientes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px;">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="ClientesGridView" runat="server"
                        AutoGenerateColumns="false" onrowcommand="ClientesGridView_RowCommand" OnRowDataBound="ClientesGridView_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="TargetControlButton" runat="server" style="Display:none;" Text="Button" />
                                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="ClientePanel" TargetControlID="TargetControlButton" BackgroundCssClass="modalBackground" runat="server" />
                                    <asp:LinkButton ID="VerLinkButton" CommandName="Ver" runat="server">Ver detalle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DocumentoTipoDescr" HeaderText="Tipo Doc." SortExpression="DocumentoTipoDescr">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentoNro" HeaderText="Nro.Doc." SortExpression="DocumentoNro">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdCliente" HeaderText="Id.Cliente" SortExpression="IdCliente">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cuit" HeaderText="Pertenece a" SortExpression="Cuit">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DesambiguacionCuitPais" HeaderText="IdClienteExt" SortExpression="DesambiguacionCuitPais">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 24px; padding-top:20px">
                <asp:Button ID="Button1" runat="server" CausesValidation="false" TabIndex="505" Text="Salir" PostBackUrl="~/Default.aspx" />
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    <asp:Panel ID="ClientePanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Consulta de Cliente"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top: 20px">
               <asp:Label ID="Label5" runat="server" Text="Cliente perteneciente al CUIT"></asp:Label>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
	        <td align="right" style="padding-right:5px; padding-top:5px">
		        <asp:Label ID="Label18" runat="server" Text="Tipo y Nro. de Documento"></asp:Label>
	        </td>
			<td align="left" style="padding-top:5px">
				<asp:DropDownList ID="TipoDocDropDownList" runat="server" TabIndex="2" 
                    Width="100px" DataValueField="Codigo" DataTextField="Descr" 
                    ToolTip="Para clientes del exterior seleccione 'CUITPais'" ></asp:DropDownList>
                <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="3" ToolTip="Debe ingresar sólo números." Width="80px" ></asp:TextBox>
                <asp:DropDownList ID="DestinosCuitDropDownList" runat="server" TabIndex="3" Width="306px" DataValueField="Codigo" DataTextField="Descr" Visible="false" ></asp:DropDownList>
			</td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:5px">
                <asp:Label ID="Label9" runat="server" Text="Razón Social"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="4" Width="300px"></asp:TextBox>
            </td>        
        </tr>
            <uc1:domicilioConsulta ID="Domicilio" runat="server"/>
            <uc1:contactoConsulta ID="Contacto" runat="server" />
            <uc1:datosImpositivosConsulta ID="DatosImpositivos" runat="server" />
            <uc1:datosIdentificatoriosConsulta ID="DatosIdentificatorios" runat="server" />
        <tr>
            <td align="right" style="padding-right:5px; padding-top:5px">
                <asp:Label ID="Label8" runat="server" Text="Id.Cliente"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="IdClienteTextBox" runat="server" MaxLength="50" TabIndex="501" Width="300px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:3px;">
                <asp:Label ID="Label38" runat="server" Text="Envío de <b>aviso</b> automático"></asp:Label><br />
                <asp:Label ID="Label46" runat="server" Text="<b>para visualización</b> del comprobante"></asp:Label>
            </td>
            <td style="border-style:solid; border-color:Gray; border-width:1px">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right" style="padding-right:5px; padding-top:3px">
                            <asp:Label ID="Label45" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td align="left" style="padding-top:3px">
                            <asp:TextBox ID="EmailAvisoVisualizacionTextBox" runat="server" MaxLength="60" TabIndex="502"
                                ToolTip="A esta dirección se enviará un email de aviso para que el destinatario pueda visualizar el comprobante"
                                Width="315px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                            <asp:Label ID="Label42" runat="server" Text="Contraseña"></asp:Label>
                        </td>
                        <td align="left" style="padding-top:3px">
                            <asp:TextBox ID="PasswordAvisoVisualizacionTextBox" runat="server" MaxLength="25" TabIndex="503"
                                ToolTip="Para poder acceder al contenido del comprobante, se solicitará al destinatario el ingreso de esta contraseña"
                                Width="100px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="justify" style="padding-left:5px; padding-right:5px; padding-top:5px; font-size:xx-small" colspan="2">
                            Interfacturas enviará, a última hora del día, un aviso (con un link) para que su destinatario<br/>pueda visualizar el comprobante electrónico generado.  Esta funcionalidad puede ser usada,<br/>por ejemplo, cuando, por cuestiones de seguridad, no se quiera enviar facturas por email.
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Button ID="SalirButton" runat="server" Text="Salir" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>