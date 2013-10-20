<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica010.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica010" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Administrador del CUIT"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Para poder ser administrador del CUIT, primero debo solicitar permiso al responsable del CUIT (opción: Administración --> CUIT --> Solicitud permiso de administrador de CUIT)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="LabelAyuda" Text="Una vez que el responsable autoriza mi solicitud (un mail me avisará cuando esto ocurra), ya estaré en condiciones de administrar el CUIT." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="El administrador del CUIT es quien puede modificar sus datos y también autorizar la creación de nuevas Unidades de Negocio (sucursales)." ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
