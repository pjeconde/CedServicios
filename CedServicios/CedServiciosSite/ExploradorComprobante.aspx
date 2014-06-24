<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorComprobante.aspx.cs" Inherits="CedServicios.Site.ExploradorComprobante" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes"></asp:Label>
            </td>
        </tr>
        <tr>
	        <td align="left" style="padding-right:5px; padding-top:20px">
                Período de emisión:
	        </td>
			<td align="left" style="padding-top:20px">
                Desde
                <asp:TextBox ID="FechaDesdeTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="FechaDesdeCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                    TargetControlID="FechaDesdeTextBox" Format="yyyyMMdd" PopupButtonID="FechaDesdeImage" >
                </ajaxToolkit:CalendarExtender>
                <asp:Image runat="server" ID="FechaDesdeImage" ImageUrl="~/Imagenes/Calendar.gif" />
                &nbsp;&nbsp;Hasta
                <asp:TextBox ID="FechaHastaTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="FechaHastaCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                    TargetControlID="FechaHastaTextBox" Format="yyyyMMdd" PopupButtonID="FechaHastaImage" >
                </ajaxToolkit:CalendarExtender>
                <asp:Image runat="server" ID="FechaHastaImage" ImageUrl="~/Imagenes/Calendar.gif" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                Cliente:
            </td>
            <td align="left" style="padding-top:5px">
                <asp:DropDownList ID="ClienteDropDownList" runat="server" TabIndex="3" Width="400px" DataValueField="Orden" DataTextField="RazonSocial" AutoPostBack="true" ></asp:DropDownList>
            </td>        
            <td style="width:550px">
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                Sólo comprobantes vigentes:
            </td>
            <td align="left" style="padding-top:5px">
                <asp:CheckBox ID="SoloVigentesCheckBox" runat="server" Checked="false" AutoPostBack="true" TextAlign="Left" />
            </td>        
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:5px">
                <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3" style="padding-top:35px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="ComprobantesGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowCommand="ComprobantesGridView_RowCommand" OnRowDataBound="ComprobantesGridView_RowDataBound" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:TemplateField ControlStyle-Width="35">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ConsultarButton" runat="server" ToolTip="Consulta Local" CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Imagenes/Iconos/Consultar.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                            <asp:TemplateField ControlStyle-Width="35">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ConsultarOnLineButton" runat="server" ToolTip="Consultar On-Line" CommandName="ConsultarOnLine" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Imagenes/Iconos/ConsultarOnLine.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ControlStyle-Width="35">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ActualizarOnlineButton" runat="server" ToolTip="Actualizar el Estado On-Line" CommandName="ActualizarOnLine" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Imagenes/Iconos/ActualizarOnLine.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ControlStyle-Width="35">
                                <ItemTemplate>
                                    <asp:ImageButton ID="ExportarButton" runat="server" ToolTip="Exportar Interface RG.2485" CommandName="ExportarRG2485" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Imagenes/Iconos/Afip.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ControlStyle-Width="35">
                                <ItemTemplate>
                                    <asp:ImageButton ID="XMLOnLineButton" runat="server" ToolTip="Exportar XML On-Line" CommandName="XMLOnLine" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Imagenes/Iconos/XmlOnLine.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ControlStyle-Width="35">
                                <ItemTemplate>
                                    <asp:ImageButton ID="PDFButton" runat="server" ToolTip="Exportar PDF" CommandName="PDF" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Imagenes/Iconos/Pdf.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ControlStyle-Width="35">
                                <ItemTemplate>
                                    <asp:ImageButton ID="PDFButtonViewer" runat="server" ToolTip="Viewer PDF" CommandName="PDF-Viewer" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Imagenes/Iconos/PdfLupa.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ControlStyle-Width="20">
                                <ItemTemplate>
                                    <asp:ImageButton ID="XMLCopiarEnAltaPDFButton" runat="server" ToolTip="Clonar Comprobante" CommandName="XML-ClonarAlta" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ImageUrl="~/Imagenes/Iconos/ClonarAlta.png" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
