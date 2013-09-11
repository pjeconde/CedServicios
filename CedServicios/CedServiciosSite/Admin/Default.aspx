<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CedServicios.Site.Admin.Default" %>

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
            <td align="center">
                <asp:Label ID="lblAppEstat" runat="server" Font-Bold="True" Text="Página del Administrador para Mantenimiento"></asp:Label><br />
                <br />
                <asp:HyperLink runat="server" ID="myOnline" NavigateUrl="~/Admin/SettingsRulesConfiguration.aspx"
                    Text="Configurar estado de la aplicación" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
