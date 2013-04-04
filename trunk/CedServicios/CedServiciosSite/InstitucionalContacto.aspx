<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalContacto.aspx.cs" Inherits="CedServicios.Site.InstitucionalContacto" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top: 20px">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Contacto"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 24px; padding-top: 20px">
                <asp:Button ID="EmpresaButton" runat="server" TabIndex="1" Text="Empresa" onclick="EmpresaButton_Click" />
                <asp:Button ID="SolucionesButton" runat="server" CausesValidation="false" TabIndex="2" Text="Soluciones" onclick="SolucionesButton_Click" />
                <asp:Button ID="RefeComButton" runat="server" CausesValidation="false" TabIndex="3" Text="Referencias Comerciales" onclick="RefeComButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-bottom: 30px; padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
