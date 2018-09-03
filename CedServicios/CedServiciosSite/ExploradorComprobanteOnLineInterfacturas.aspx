<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorComprobanteOnLineInterfacturas.aspx.cs" Inherits="CedServicios.Site.ExploradorComprobanteOnLineInterfacturas" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes (online Interfacturas)"></asp:Label>
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
                Persona (cliente/proveedor):
            </td>
            <td align="left" style="padding-top:5px">
                <asp:DropDownList ID="ClienteDropDownList" runat="server" TabIndex="3" Width="400px" DataValueField="Orden" DataTextField="RazonSocial" AutoPostBack="true" ></asp:DropDownList>
            </td>        
            <td style="width:550px">
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                &nbsp;</td>
            <td align="left" style="padding-top:5px">
                
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
            <td colspan="3" style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="ComprobantesGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowCommand="ComprobantesGridView_RowCommand" OnRowDataBound="ComprobantesGridView_RowDataBound" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:ButtonField HeaderText="" Text="Consulta On-Line" CommandName="ConsultaOnLine" ButtonType="Link" ItemStyle-ForeColor="Blue" ControlStyle-Width="100">
                            </asp:ButtonField>
                            <asp:BoundField DataField="denominacion_comprador" HeaderText="Nombre Comprador" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="denominacion_vendedor" HeaderText="Nombre Vendedor" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tipo_doc_comprador" HeaderText="Tipo Doc Comprador" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="doc_comprador" HeaderText="Doc Comprador" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tipo_de_comprobante" HeaderText="Tipo Comprob" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numero_comprobante" HeaderText="Nro. Comprob" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="resultado" HeaderText="Resultado" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="punto_de_venta" HeaderText="PuntoVta" SortExpression="">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="importe_total" HeaderText="Importe Total" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="estado" HeaderText="Estado" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha_emision" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Emision" SortExpression="">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id_Lote" HeaderText="Nro.Lote" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
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
    </div>
    </div>
    </div>
</asp:Content>
