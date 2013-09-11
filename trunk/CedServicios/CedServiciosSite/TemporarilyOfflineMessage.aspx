<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemporarilyOfflineMessage.aspx.cs" Inherits="CedServicios.Site.TemporarilyOfflineMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="font-family: Arial;">
    <div>
        <table style="width: 100%">
            <tr>
                <td align="center">
                    <h1>
                        El Sistema está temporalmente no disponible</h1>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <p>
                        Disculpenos, pero el sitio está temporalmente fuera de servicio. <br /> 
                        Por favor trate de ingresar posteriormente.<br />
                        Si tiene alguna consulta urgente, por favor, contacte a soporte técnico de nuestra empresa.
                    </p>
                    <p>
                        <asp:Label runat="server" ID="OfflineMessage" style="font-weight:bold;"></asp:Label>
                    </p>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
