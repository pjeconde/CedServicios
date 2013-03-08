<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Excepciones.aspx.cs" Inherits="CedServicios.Site.Excepciones.Excepciones" MasterPageFile="~/CedServicios.Master" %>

<asp:Content ID="ExContent" runat="Server" ContentPlaceHolderID="ContentPlaceDefault">
    <form id="form1" runat="server">
    <div>

    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; padding-top: 10px">
        <tr>
            <td style="padding-left: 10px" valign="top">
                <!-- @@@ TITULO DE LA PAGINA @@@-->
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 21px; height: 20px;">
                            *
                        </td>
                        <td style="height: 20px;">
                            <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Notificación de excepción">
                            </asp:Label>
                        </td>
                    </tr>
                </table>
                <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@-->
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 10px; padding-left: 32px">
                <asp:Label ID="ExLabel" runat="server" SkinID="MensajePagina"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </form>
</asp:Content>
