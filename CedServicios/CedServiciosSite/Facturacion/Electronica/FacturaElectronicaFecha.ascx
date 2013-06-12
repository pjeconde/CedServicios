<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacturaElectronicaFecha.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.FacturaElectronicaFecha" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:TextBox ID="FechaDatePickerWebUserControl" runat="server" CausesValidation="true" SkinID="FechaFact"></asp:TextBox>
<cc1:CalendarExtender ID="CalendarExtenderFecha" runat="server" CssClass="MyCalendar" 
    OnClientShown="onCalendar1Shown" TargetControlID="FechaDatePickerWebUserControl"
    Format="yyyyMMdd" PopupButtonID="ImageCalendarFechaEmision">
</cc1:CalendarExtender>
<asp:Image runat="server" ID="ImageCalendarFecha" ImageUrl="~/Imagenes/Calendar.gif" />


