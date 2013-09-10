<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprobanteSeleccionArchivoXML.aspx.cs" Inherits="CedServicios.Site.ComprobanteSeleccionArchivoXML" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes (archivo XML)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px">
                <asp:FileUpload ID="XMLFileUpload" runat="server" Height="25px" Width="760px" size="100" ToolTip="Cargar los datos de un archivo XML.">
                </asp:FileUpload>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px">
                <asp:Button ID="FileUploadButton" runat="server" OnClick="FileUploadButton_Click" Text="Completar datos automáticamente desde archivo xml seleccionado" />
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
