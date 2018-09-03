<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprobanteSeleccionOnlineInterfacturas.aspx.cs" Inherits="CedServicios.Site.ComprobanteSeleccionOnlineInterfacturas" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobante (online Interfacturas)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:20px">
                Nro. de lote:
            </td>
            <td align="left" style="padding-top:20px; padding-left:5px">
                <asp:TextBox ID="NroLoteConsultaTextBox" runat="server" ToolTip="">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:10px">
                Punto de Venta:
            </td>
            <td align="left" style="padding-top:10px; padding-left:5px">
                <asp:DropDownList ID="PtoVtaConsultaDropDownList" runat="server" AutoPostBack="True" SkinID="ddlch" ToolTip="">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:10px">
                Cuit:
            </td>
            <td align="left" style="padding-top:10px; padding-left:5px">
                <asp:TextBox ID="CuitConsultaTextBox" ReadOnly="true" runat="server" ToolTip="Cuit del Vendedor.">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:20px">
                <asp:Button ID="ConsultarLoteIBKButton" runat="server"
                    OnClick="ConsultarLoteIBKButton_Click" Text="Consultar lote en Interfacturas"
                    ToolTip="Consultar el comprobante en Interfacturas. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
</asp:Content>
