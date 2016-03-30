<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorPDFComprobante.aspx.cs" Inherits="CedServicios.Site.ExploradorPDFComprobante" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <asp:Panel ID="Panel0" runat="server" DefaultButton="BuscarButton" align="left">
        <table align="center">
            <tr>
                <td colspan="2" 
                    style="padding-top:20px; padding-bottom:20px; text-align:center">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de PDFs de Comprobantes"></asp:Label>
                </td>
            </tr>
            <asp:Panel ID="PeriodoEmisionPanel" runat="server">
            <tr>
	            <td style="padding-right:5px; padding-top:5px; text-align: left">
                    Período de emisión: desde&nbsp;
	            </td>
			    <td style="padding-top:5px; text-align:left">
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
                <td style="padding-top:5px; vertical-align: top; text-align: left">
                    <asp:Button ID="BuscarButton" class="btn btn-default btn-sm" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" />
                    <asp:Button ID="SalirButton" class="btn btn-default btn-sm" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="padding-top:20px; padding-bottom:10px; text-align: center">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:GridView ID="PDFsGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowCommand="PDFsGridView_RowCommand" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DescargarLinkButton" runat="server" CommandName="Descargar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Descargar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Descr" HeaderText="PDF Comprobante" SortExpression="Descr">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Path" HeaderText="Path" SortExpression="Path" Visible="false">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaCreacion" HeaderText="Creación" SortExpression="FechaCreacion">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
    </div>
    </div>
</asp:Content>
