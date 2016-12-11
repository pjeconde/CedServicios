<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprasXArticuloFiltros.aspx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Reportes.ComprasXArticuloFiltros" Theme="CedServicios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <style>
        label {
            font-weight: normal;
        }
    </style>
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
        <asp:Panel ID="Panel0" runat="server" DefaultButton="BuscarButton" align="left">
            <table align="center">
                <tr>
                    <td colspan="3" style="padding-top:20px; padding-bottom:20px; text-align:center">
                        <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Ventas por artículo"></asp:Label>
                
                    </td>
                </tr>
                <tr>
	                <td style="padding-right:5px; padding-top:5px; text-align: left">
                        Período:
	                </td>
			        <td style="padding-top:5px; text-align:left">
                        desde&nbsp;
                        <asp:TextBox ID="FechaDesdeTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                        <cc1:CalendarExtender ID="FechaDesdeCalendarExtender" runat="server" CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                            TargetControlID="FechaDesdeTextBox" Format="yyyyMMdd" PopupButtonID="FechaDesdeImage" >
                        </cc1:CalendarExtender>
                        <asp:Image runat="server" ID="FechaDesdeImage" ImageUrl="~/Imagenes/Calendar.gif" />
                        &nbsp;&nbsp;hasta&nbsp;
                        <asp:TextBox ID="FechaHastaTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                        <cc1:CalendarExtender ID="FechaHastaCalendarExtender" runat="server" CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                            TargetControlID="FechaHastaTextBox" Format="yyyyMMdd" PopupButtonID="FechaHastaImage" >
                        </cc1:CalendarExtender>
                        <asp:Image runat="server" ID="FechaHastaImage" ImageUrl="~/Imagenes/Calendar.gif" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Visualizar:&nbsp;
                    </td>
                    <td style="padding-top:5px; vertical-align:middle">
                        <asp:CheckBox ID="FechaYHoraCheckBox" runat="server" Text="&nbsp;Fecha y Hora de generación del reporte" AutoPostBack="false"/>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="padding-top:5px; vertical-align:middle">
                        <asp:CheckBox ID="DetalleComprobanteCheckBox" runat="server" Text="&nbsp;Detalle de comprobantes" Checked="true" AutoPostBack="true" OnCheckedChanged="VerTodosLosArticulosCheckBox_Click"/>&nbsp;&nbsp;<asp:CheckBox ID="VerTodosLosArticulosCheckBox" runat="server" Text="&nbsp;Ver todos los artículos" Checked="false" Enabled="false" AutoPostBack="false"/>
                    </td>
                </tr>
                 <tr>
                    <td style="padding-right:5px; padding-top:5px; text-align: left">
                        Exportar:
                    </td>
                    <td style="padding-top:5px; text-align: left">
                        <asp:DropDownList ID="FormatosRptExportarDropDownList" runat="server" Width="100px" DataValueField="Id" DataTextField="Descr"></asp:DropDownList>
                    </td>        
                </tr>
                <tr>
                   <td colspan="2" style="padding-top:5px; vertical-align: top; text-align: center">
                        <asp:Button ID="BuscarButton" class="btn btn-default btn-sm" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" />
                        <asp:Button ID="SalirButton" class="btn btn-default btn-sm" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                        <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTROS DE BUSQUEDA" data-content="Si no selecciona ningún filtro, buscará todos los comprobantes que estén dentro del rango de fechas que figura por defecto."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding-top:20px; padding-bottom:10px; text-align: center">
                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </div>
    </div>
</asp:Content>
