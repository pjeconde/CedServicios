<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SettingsRulesConfiguration.aspx.cs" Inherits="CedServicios.Site.Admin.SettingsRulesConfiguration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="font-family: Arial;">
    <div>
    <table align="center">
            <tr>
                <td align="center" colspan="2">
                   <asp:Label ID="lblAppEstat" runat="server" Font-Bold="True" Text="Configurar estado de la Aplicación."></asp:Label><br />
                   <asp:HyperLink runat="server" ID="hplPrincipal"  NavigateUrl="~/Default.aspx" Text="Volver a Principal" /><br />
                   <asp:HyperLink runat="server" ID="hplMyAdmin"  NavigateUrl="~/Admin/Default.aspx" Text="Volver a Admin" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblcurEsta" runat="server" Text="Estado Actual:" />&nbsp;
                </td>
                <td align="lefth">
                    <asp:CheckBox ID="IsOffline" runat="server" Text="Offline?" TextAlign="Left" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="lblofflineMess" runat="server" Text="Mensaje Offline:" />&nbsp;
                </td>
                <td align="left">
                    <asp:TextBox ID="OfflineMessage" runat="server" Columns="60" Rows="7" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="OfflineMessage"
                        ErrorMessage="Mensaje Offline es requerido" ValidationGroup="cfg"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Button ID="Button2" runat="server" OnClientClick="showConfirm(this); return false;"
                        OnClick="UpdateButton_Click" Text="Guardar Configuración" ValidationGroup="cfg" />
                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" DisplayMode="SingleParagraph"
                        Font-Names="Verdana" Font-Size="10pt" HeaderText="&lt;div align=center&gt;&lt;u&gt;Se han encontrado los siguientes errores&lt;/u&gt;: &lt;/div&gt;"
                        ValidationGroup="cfg" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
