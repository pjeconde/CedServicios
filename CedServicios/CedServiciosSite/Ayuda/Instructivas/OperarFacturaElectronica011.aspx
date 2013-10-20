<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica011.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica011" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Administrador de la Unidad de Negocio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Para poder ser administrador de una Unidad de Negocio, primero debo solicitar permiso al responsable de la Unidad de Negocio. (opción: Administración --> Unidad de Negocio --> Solicitud permiso de administrador de UN)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="LabelAyuda" Text="Una vez que el responsable autoriza mi solicitud (un mail me avisará cuando esto ocurra), ya estaré en condiciones de administrar la Unidad de Negocio." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="El administrador de la Unidad de Negocio es quien puede modificar sus datos y también permitir a nuevos usuarios operar con el servicio de Factura Electrónica (para que puedan ingresar comprobantes)." ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
