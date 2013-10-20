<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica005.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica005" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Artículos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Para crear un nuevo Artículo, elegir la opción: Artículos --> Alta." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="LabelAyuda" Text="El artículo queda relacionado al CUIT que esté seleccionado en ese momento (ver CUIT en el ángulo superior derecho)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="Los datos imprescindibles para crear un nuevo Artículo son:" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label6" runat="server" SkinID="LabelAyuda" Text="&#8226; Id: es un código único que lo identificará." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label7" runat="server" SkinID="LabelAyuda" Text="&#8226; Descripción." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label8" runat="server" SkinID="LabelAyuda" Text="&#8226; GTIN: es el código de barras." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label9" runat="server" SkinID="LabelAyuda" Text="&#8226; Unidad de medida." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label10" runat="server" SkinID="LabelAyuda" Text="&#8226; Indicación Exento/Gravado (se refiere al I.V.A.)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label11" runat="server" SkinID="LabelAyuda" Text="&#8226; Alícuota I.V.A." ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
