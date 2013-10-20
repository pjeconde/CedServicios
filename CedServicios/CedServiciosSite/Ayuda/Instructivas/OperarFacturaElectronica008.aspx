<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica008.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica008" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label3" runat="server" SkinID="TituloPagina" Text="Me sumo a un grupo que ya está operando en el sitio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label7" runat="server" SkinID="LabelAyuda" Text="¿ De qué manera me sumo al grupo que ya está operando en el sitio ?" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="&#8226; Quiero poder" ></asp:Label>
                <asp:LinkButton ID="LinkButton2" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica009.aspx">
                    ingresar comprobantes
                </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label1" runat="server" SkinID="LabelAyuda" Text="&#8226; Quiero ser" ></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica010.aspx">
                    administrador del CUIT
                </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="&#8226; Quiero ser" ></asp:Label>
                <asp:LinkButton ID="LinkButton3" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica011.aspx">
                    administrador de la Unidad de Negocio
                </asp:LinkButton>
                <asp:Label ID="Label6" runat="server" SkinID="LabelAyuda" Text="(sucursal)" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label5" runat="server" SkinID="LabelAyuda" Text="&#8226; Quiero" ></asp:Label>
                <asp:LinkButton ID="LinkButton4" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica012.aspx">
                    crear una nueva Unidad de Negocio
                </asp:LinkButton>
                <asp:Label ID="Label8" runat="server" SkinID="LabelAyuda" Text="(sucursal) para el CUIT" ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
