<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprobanteSeleccionArchivoXML.aspx.cs" Inherits="CedServicios.Site.ComprobanteSeleccionArchivoXML" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table align="center">
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
                <asp:Button ID="FileUploadButton" class="btn btn-default btn-sm" runat="server" OnClick="FileUploadButton_Click" Text="Completar datos automáticamente desde archivo xml seleccionado" Width="75%"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
</asp:Content>
