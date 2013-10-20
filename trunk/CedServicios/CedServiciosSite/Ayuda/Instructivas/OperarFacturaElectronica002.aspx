<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica002.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica002" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label3" runat="server" SkinID="TituloPagina" Text="Voy a ingresar comprobantes de un CUIT que todavia no opera en el sitio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label1" runat="server" SkinID="LabelAyuda" Text="Para poder ingresar comprobantes, de un CUIT que todavía no opera en el sitio, lo primero, es dar de alta el CUIT (opción: Administración --> CUIT --> Alta)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="El alta del CUIT, implica el alta de su Unidad de Negocio predeterminada." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label5" runat="server" SkinID="LabelAyuda" Text="El usuario que crea el CUIT, queda como administrador del CUIT y de la Unidad de Negocio predeterminada y también como operador del servicio de Factura Electrónica (que le permitirá ingresar comprobantes)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Después del alta de CUIT, y antes de ingresar comprobantes, es imprescindible definir " ></asp:Label>
                <asp:LinkButton ID="LinkButton3" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica004.aspx">
                    Puntos de Venta
                </asp:LinkButton>
                <asp:Label ID="Label6" runat="server" SkinID="LabelAyuda" Text=" (que quedarán relacionados tanto a un CUIT como a una Unidad de negocio)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label7" runat="server" SkinID="LabelAyuda" Text="Opcionalmente, a los efectos de facilitar y agilizar el ingreso de comprobantes, se pueden definir" ></asp:Label>
                <asp:LinkButton ID="LinkButton4" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica005.aspx">
                    Artículos
                </asp:LinkButton>
                <asp:Label ID="Label8" runat="server" SkinID="LabelAyuda" Text="y" ></asp:Label>
                <asp:LinkButton ID="LinkButton5" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica006.aspx">
                    Clientes
                </asp:LinkButton>
                <asp:Label ID="Label9" runat="server" SkinID="LabelAyuda" Text="." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:LinkButton ID="LinkButton2" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica007.aspx">
                    ¿ Cómo ingreso comprobantes ?
                </asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>




