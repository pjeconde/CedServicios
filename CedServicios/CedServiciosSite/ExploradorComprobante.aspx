<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorComprobante.aspx.cs" Inherits="CedServicios.Site.ExploradorComprobante" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <asp:Panel ID="Panel0" runat="server" DefaultButton="BuscarButton">
        <table style="border:0; padding-left:10px">
            <tr>
                <td colspan="3" style="padding-top:20px; padding-bottom:20px; text-align:center">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes"></asp:Label>
                    <asp:TextBox ID="ElementoTextBox" runat="server" Visible="false"> </asp:TextBox>
                    <asp:TextBox ID="TratamientoTextBox" runat="server" Visible="false"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-right:5px; padding-top:5px; text-align:left;">
                    Persona (cliente/proveedor):
                </td>
                <td style="padding-top:5px; text-align: left;">
                    <asp:DropDownList ID="ClienteDropDownList" runat="server" Width="400px" DataValueField="Orden" DataTextField="RazonSocial"></asp:DropDownList>
                </td>
                <td rowspan="3" style="padding-top:5px; padding-left: 10px; vertical-align: top; text-align: left">
                    <asp:Panel ID="EstadosPanel" runat="server">
                        <table style="border: 0;">
                            <tr>
                                <td>
                                    Estado(s):&nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="EstadoVigenteCheckBox" runat="server" Text="Vigente" AutoPostBack="false"/>
                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:CheckBox ID="EstadoPteEnvioCheckBox" runat="server" Text="Pendiente de envio (AFIP/ITF)" AutoPostBack="false"/>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:CheckBox ID="EstadoDeBajaCheckBox" runat="server" Text="De baja" AutoPostBack="false"/>
                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:CheckBox ID="EstadoPteConfCheckBox" runat="server" Text="Pendiente de confirmación" AutoPostBack="false"/>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:CheckBox ID="EstadoRechCheckBox" runat="server" Text="Rechazado" AutoPostBack="false"/>
                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:CheckBox ID="EstadoPteAutorizCheckBox" runat="server" Text="Pendiente de autorización" AutoPostBack="false"/>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td style="width:550px">
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Naturaleza del comprobante:
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:DropDownList ID="NaturalezaComprobanteDropDownList" runat="server" Width="400px" DataValueField="Id" DataTextField="Descr"></asp:DropDownList>
                </td>        
            </tr>
            <asp:Panel ID="DetallePanel" runat="server">
            <tr>
	            <td align="left" style="padding-right:5px; padding-top:5px">
                    Detalle:
	            </td>
			    <td align="left" colspan="1" style="padding-top:5px; width:400px">
				    <asp:TextBox ID="DetalleTextBox" runat="server" MaxLength="50"></asp:TextBox>
                    (ej.: "autom" para seleccionar sólo comprobantes generados automaticamente)
			    </td>
            </tr>
            </asp:Panel>
            <asp:Panel ID="PeriodoEmisionPanel" runat="server">
            <tr>
	            <td align="left" style="padding-right:5px; padding-top:5px">
                    Período de emisión:
	            </td>
			    <td align="left" style="padding-top:5px">
                    desde&nbsp;
                    <asp:TextBox ID="FechaDesdeTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="FechaDesdeCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                        TargetControlID="FechaDesdeTextBox" Format="yyyyMMdd" PopupButtonID="FechaDesdeImage" >
                    </ajaxToolkit:CalendarExtender>
                    <asp:Image runat="server" ID="FechaDesdeImage" ImageUrl="~/Imagenes/Calendar.gif" />
                    &nbsp;&nbsp;hasta&nbsp;
                    <asp:TextBox ID="FechaHastaTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="FechaHastaCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                        TargetControlID="FechaHastaTextBox" Format="yyyyMMdd" PopupButtonID="FechaHastaImage" >
                    </ajaxToolkit:CalendarExtender>
                    <asp:Image runat="server" ID="FechaHastaImage" ImageUrl="~/Imagenes/Calendar.gif" />
                </td>
            </tr>
            </asp:Panel>
            <tr>
                <td>
                </td>
                <td align="left" style="height: 24px; padding-top:5px" valign="top">
                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" />
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4" style="padding-top:20px; padding-bottom:10px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="ComprobantesGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowCommand="ComprobantesGridView_RowCommand" OnRowDataBound="ComprobantesGridView_RowDataBound" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="VerLinkButton" runat="server" CommandName="Consulta" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Ver detalle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BajaAnulBajaLinkButton" runat="server" CommandName="Baja/Anul.baja" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Baja/Anul.baja</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="EnvioLinkButton" runat="server" CommandName="Envio" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Envio</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="ModificacionLinkButton" runat="server" CommandName="Modificacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Modificación</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DescrNaturalezaComprobante" HeaderText="Naturaleza" SortExpression="DescrNaturalezaComprobante">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescrTipoComprobante" HeaderText="Tipo" SortExpression="DescrTipoComprobante">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NroPuntoVtaFORMATEADO" HeaderText="P.V." SortExpression="NroPuntoVtaFORMATEADO">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NroFORMATEADO" HeaderText="Nro." SortExpression="NroFORMATEADO">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescrTipoDoc" HeaderText="T.Doc" SortExpression="DescrTipoDoc">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NroDoc" HeaderText="Nro.Doc." SortExpression="NroDoc">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha" SortExpression="Fecha">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaProximaEmision" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha emi." SortExpression="FechaProximaEmision">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:0.00}" SortExpression="Importe">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Moneda" HeaderText="Mon" SortExpression="Moneda">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ImporteMoneda" HeaderText="Imp.Mon" DataFormatString="{0:0.00}" SortExpression="ImporteMoneda">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoCambio" HeaderText="Cambio" DataFormatString="{0:0.0000}" SortExpression="TipoCambio">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdDestinoComprobante" HeaderText="Canal" SortExpression="IdDestinoComprobante">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaVto" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha Vto" SortExpression="FechaVto">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NroLote" HeaderText="Nro.Lote" SortExpression="NroLote">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Acción">
                                <ItemTemplate>
		                            <asp:DropDownList ID="AccionDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AccionDropDownList_SelectedIndexChanged" EnableViewState="false">
			                            <asp:ListItem Value="" Text="--- elegir acción ---"></asp:ListItem>
			                            <asp:ListItem Value="ActualizarOnLine" Text="Actualizar estado (Interfacturas/AFIP)"></asp:ListItem>
			                            <asp:ListItem Value="ConsultarInterfacturas" Text="Consultar (Interfacturas)"></asp:ListItem>
			                            <asp:ListItem Value="PDF-Viewer" Text="Viewer PDF (InterFacturas)"></asp:ListItem>
			                            <asp:ListItem Value="XMLOnLine" Text="Descargar XML (InterFacturas)"></asp:ListItem>
                                        <asp:ListItem Value="XMLLocal" Text="Descargar XML"></asp:ListItem>
			                            <asp:ListItem Value="PDF" Text="Descargar PDF"></asp:ListItem>
			                            <asp:ListItem Value="XML-ClonarAlta" Text="Clonar comprobante"></asp:ListItem>
			                            <asp:ListItem Value="ExportarRG2485" Text="Descargar interface RG2485"></asp:ListItem>
                                        <asp:ListItem Value="ExportarRG3685" Text="Descargar interface RG3685 (Prueba)"></asp:ListItem>
		                            </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
