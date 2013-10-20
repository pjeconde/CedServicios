<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica012.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica012" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Crear una nueva Unidad de Negocio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Para poder operar con una nueva Unidad de Negocio (sucursal), que pertenezca a un CUIT que ya está operando en el sitio, primero debo crearla (opción: Administración --> Unidad de Negocio --> Alta )." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="LabelAyuda" Text="Si soy administrador del CUIT, la nueva Unidad de Negocio queda operativa." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="Si no soy administrador del CUIT, el alta de esta nueva Unidad de Negocio queda sujeta a la aprobación del administrador de CUIT." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label5" runat="server" SkinID="LabelAyuda" Text="Una vez que él autoriza mi solicitud (un mail me avisará cuando esto ocurra), la nueva Unidad de Negocio queda operativa." ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
