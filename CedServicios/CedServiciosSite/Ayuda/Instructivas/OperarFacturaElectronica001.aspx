<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica001.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica001" Theme="CedServicios" %>

<asp:Content ID="Content1" Visible="true" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table>
        <tr>
            <td align="center">
                <asp:Label ID="Label3" runat="server" SkinID="TituloPagina" Text="¿Cómo empiezo a operar con facturas electrónicas?"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:LinkButton ID="LinkButton1" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica002.aspx">
                    &#8226; Voy a ingresar comprobantes de un CUIT que todavia no opera en el sitio
                </asp:LinkButton>
            </td> 
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:LinkButton ID="LinkButton2" runat="server" SkinID="LinkButtonAyuda" PostBackUrl="~/Ayuda/Instructivas/OperarFacturaElectronica008.aspx">
                    &#8226; Me sumo a un grupo que ya está operando en el sitio
                </asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>