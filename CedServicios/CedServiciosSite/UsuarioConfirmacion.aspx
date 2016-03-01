<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioConfirmacion.aspx.cs" Inherits="CedServicios.Site.UsuarioConfirmacion" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table align="center" class="TextoComun">
        <tr>
            <td style="padding-top:20px; text-align: center">
                <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Confirmación de creación de cuenta"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px; text-align: center">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
</asp:Content>
