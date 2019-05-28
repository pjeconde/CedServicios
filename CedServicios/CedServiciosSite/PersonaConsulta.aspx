<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PersonaConsulta.aspx.cs" Inherits="CedServicios.Site.PersonaConsulta" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="uc1" TagName="domicilioConsulta" Src="~/Controles/DomicilioConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contactoConsulta" Src="~/Controles/ContactoConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivosConsulta" Src="~/Controles/DatosImpositivosConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatoriosConsulta" Src="~/Controles/DatosIdentificatoriosConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosEmailAvisoComprobantePersona" Src="~/Controles/DatosEmailAvisoComprobantePersona.ascx" %>
<%@ Register TagPrefix="uc1" TagName="listaPrecioDefaultPersona" Src="~/Controles/ListaPrecioDefaultPersona.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Personas"></asp:Label>
                        </h2>
                    </div>
                </div>
             </div>
             <div class="row">
                <div class="col-lg-12 col-md-12">
                    <asp:Panel ID="GrillaComprobantes" runat="server" Width="100%" ScrollBars="Auto">
                        <asp:GridView ID="ClientesGridView" runat="server" Width="100%"
                            AutoGenerateColumns="false" onrowcommand="ClientesGridView_RowCommand" OnRowDataBound="ClientesGridView_RowDataBound" CssClass="grilla" GridLines="None">
                            <Columns>
                                <asp:TemplateField HeaderText="Persona">
                                    <ItemTemplate>
                                        <asp:Button ID="TargetControlButton" runat="server" style="Display:none" Text="Button" />
                                        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="ClientePanel" TargetControlID="TargetControlButton" BackgroundCssClass="modalBackground" runat="server" />
                                        <asp:LinkButton ID="VerLinkButton" CommandName="Ver" runat="server">Ver</asp:LinkButton>
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
                                <asp:BoundField DataField="IdPersona" HeaderText="Id.Persona" SortExpression="IdPersona">
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
                                <asp:BoundField DataField="DescrTipoPersona" HeaderText="Tipo de Persona" SortExpression="DescrTipoPersona" >
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </div>
                <div class="col-lg-12 col-md-12 text">
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="505" Text="Salir" onclick="SalirButton_Click" />
                </div>
                <div class="col-lg-12 col-md-12 text padding-top-20">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
                </div>
            </div>
        </div>
    </section>
    <asp:Panel ID="ClientePanel" runat="server" CssClass="ModalWindow" ScrollBars="Vertical" Height="98%">
        <div class="container">
        <div class="row">
        <div class="col-lg-12 col-md-12">
        <table width="100%" align="center">
            <tr>
                <td align="center" colspan="2" style="padding-top:20px">
                    <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Consulta de Persona"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top: 20px">
                   <asp:Label ID="Label5" runat="server" Text="Persona perteneciente al CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" Text="Tipo de Persona:"></asp:Label>
                    <asp:RadioButton ID="ClienteRadioButton" Text="Cliente" GroupName="TipoPersona" runat="server" Enabled="false" />
                    <asp:RadioButton ID="ProveedorRadioButton" Text="Proveedor" GroupName="TipoPersona" runat="server" Enabled="false" />
                    <asp:RadioButton ID="AmbosRadioButton" Text="Ambos" GroupName="TipoPersona" runat="server" Enabled="false" />
                </td>
            </tr>
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:5px">
		            <asp:Label ID="Label18" runat="server" Text="Tipo y Nro. de Documento"></asp:Label>
	            </td>
			    <td align="left" style="padding-top:5px">
				    <asp:DropDownList ID="TipoDocDropDownList" runat="server" TabIndex="2" 
                        Width="100px" DataValueField="Codigo" DataTextField="Descr" 
                        ToolTip="Para personas del exterior seleccione 'CUITPais'" ></asp:DropDownList>
                    <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="3" ToolTip="Debe ingresar sólo números." Width="90px" ></asp:TextBox>
                    <asp:DropDownList ID="DestinosCuitDropDownList" runat="server" TabIndex="3" Width="306px" DataValueField="Codigo" DataTextField="Descr" Visible="false" ></asp:DropDownList>
			    </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:5px">
                    <asp:Label ID="Label8" runat="server" Text="Id.Persona"></asp:Label>
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
                    <asp:Label ID="Label9" runat="server" Text="Razón Social"></asp:Label>
                </td>
                <td align="left" style="padding-top:2px">
                    <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="5" Width="300px"></asp:TextBox>
                </td>        
            </tr>
            <uc1:domicilioConsulta ID="Domicilio" runat="server"/>
            <uc1:contactoConsulta ID="Contacto" runat="server" />
            <uc1:datosImpositivosConsulta ID="DatosImpositivos" runat="server" />
            <uc1:datosIdentificatoriosConsulta ID="DatosIdentificatorios" runat="server" />
            <uc1:datosEmailAvisoComprobantePersona ID="DatosEmailAvisoComprobantePersona" runat="server" />
            <tr>
                <td colspan="2" style="padding-top:3px">
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px">
                    <asp:Label ID="Label38" runat="server" Text="Envío de <b>aviso</b> automático"></asp:Label><br />
                    <asp:Label ID="Label46" runat="server" Text="<b>para visualización</b> del comprobante"></asp:Label><br />
                <asp:Label ID="Label4" runat="server" Text="(desde INTERFACTURAS)"></asp:Label>
                </td>
                <td style="border-style:solid; border-color:Gray; border-width:1px">
                    <table>
                        <tr>
                            <td style="padding-right:5px; padding-top:3px; text-align: right">
                                <asp:Label ID="Label45" runat="server" Text="Email"></asp:Label>
                            </td>
                            <td style="padding-top:3px; text-align: left">
                                <asp:TextBox ID="EmailAvisoVisualizacionTextBox" runat="server" MaxLength="60" TabIndex="501"
                                    ToolTip="A esta dirección se enviará un email de aviso para que el destinatario pueda visualizar el comprobante"
                                    Width="315px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-left:5px; padding-right:5px; padding-top:3px; text-align: right">
                                <asp:Label ID="Label42" runat="server" Text="Contraseña"></asp:Label>
                            </td>
                            <td style="padding-top:3px; text-align: left">
                                <asp:TextBox ID="PasswordAvisoVisualizacionTextBox" runat="server" MaxLength="25" TabIndex="502"
                                    ToolTip="Para poder acceder al contenido del comprobante, se solicitará al destinatario el ingreso de esta contraseña"
                                    Width="100px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <uc1:listaPrecioDefaultPersona ID="ListaPrecioDefaultPersona" runat="server" />
            <tr>
                <td>
                </td>
                <td align="left" style="padding-top:10px">
                    <asp:Button ID="SalirClientePanelButton" runat="server" Text="Salir" />
                </td>
            </tr>
        </table>
        </div>
        </div>
        </div>
    </asp:Panel>
</asp:Content>