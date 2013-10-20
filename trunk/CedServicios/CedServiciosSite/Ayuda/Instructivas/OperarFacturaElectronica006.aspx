<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica006.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica006" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Clientes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Para crear un nuevo Cliente, elegir la opción: Clientes --> Alta." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="LabelAyuda" Text="El cliente queda relacionado al CUIT que esté seleccionado en ese momento (ver CUIT en el ángulo superior derecho)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="Los datos imprescindibles para crear un nuevo Cliente son:" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label5" runat="server" SkinID="LabelAyuda" Text="&#8226; CUIT" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label6" runat="server" SkinID="LabelAyuda" Text="&#8226; Id. (opcional)" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label7" runat="server" SkinID="LabelAyuda" Text="&#8226; Razón Social" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label8" runat="server" SkinID="LabelAyuda" Text="&#8226; Datos de domicilio:  Calle, Nro, Piso. Depto, Sector, Torre, Manzana, Localidad, Provincia y Código Postal." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label9" runat="server" SkinID="LabelAyuda" Text="&#8226; Datos de contacto:  Nombre, Email  y Teléfono." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label10" runat="server" SkinID="LabelAyuda" Text="&#8226; Datos impositivos:  Condición de I.V.A. e Ingresos Brutos, Nro.de Ingresos Brutos y Fecha de inicio de actividades." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label11" runat="server" SkinID="LabelAyuda" Text="&#8226; Datos identificatorios: GLN y Código interno." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label12" runat="server" SkinID="LabelAyuda" Text="&#8226; Datos para el Envío de aviso automático para visualización del comprobante: Email y Contraseña." ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
