<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="SessionTimeout.aspx.cs" Inherits="CedServicios.Site.SessionTimeout" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
        <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px; width:100%">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Tiempo de sesión expirado"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text="Para seguir trabajando, haga click en 'Iniciar sesión'."></asp:Label>
            </td>
        </tr>
        </table>
    </div>
    </div>
    </div>
</asp:Content>
