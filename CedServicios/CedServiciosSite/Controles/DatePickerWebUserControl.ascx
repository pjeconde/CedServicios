<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatePickerWebUserControl.ascx.cs" Inherits="CedServicios.Site.Controles.DatePickerWebUserControl" %>

<asp:Literal ID="litJS" runat="server"></asp:Literal>
<table border="0" cellpadding="0" cellspacing="0" style="border-style: none; border-width: 0px;
    white-space: nowrap;">
    <tr>
        <td align="center" style="border-style: none; border-width: 0px; height: 30px;">
            <asp:TextBox ID="txt_Date" runat="server" Width="70"></asp:TextBox>&nbsp;</td>
        <td style="border-style: none; border-width: 0px; height: 30px;">
            <asp:Image ID="imgCalendar" runat="server" AlternateText="Calendario desplegable para ayudar a elegir fechas en formato AAAAMMDD"
                ImageUrl="~/cal/calendar.gif" /></td>
    </tr>
</table>
