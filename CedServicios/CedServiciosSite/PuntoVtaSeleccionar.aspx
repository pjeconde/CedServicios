<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PuntoVtaSeleccionar.aspx.cs" Inherits="CedServicios.Site.PuntoVtaSeleccionar" theme="CedServicios"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top: 20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="? de Punto de Venta"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top: 20px">
                <asp:Label ID="Label19" runat="server" Text="CUIT"></asp:Label>
            </td>
            <td align="left" style="padding-top: 20px">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                    Width="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:5px; height:25px;">
                <asp:Label ID="Label5" runat="server" Text="Unidad de Negocio"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px; height:25px;">
                <asp:DropDownList ID="IdUNDropDownList" runat="server" TabIndex="2" Width="183px" DataValueField="Id" DataTextField="Descr" ></asp:DropDownList>
            </td>
        </tr>        
        <tr>
            <td align="right" style="padding-right:5px; padding-top:5px; height:25px;">
                <asp:Label ID="Label2" runat="server" Text="Punto de Venta"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px; height:25px;">
                <asp:DropDownList ID="PuntoVtaDropDownList" runat="server" TabIndex="3" Width="183px" DataValueField="Nro" DataTextField="Descr" ></asp:DropDownList>
            </td>
        </tr>        
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top: 20px">
                <asp:Button ID="ContinuarButton" runat="server" TabIndex="4" OnClick="ContinuarButton_Click" Text="Continuar" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="5" Text="Cancelar" PostBackUrl="~/Default.aspx" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-bottom: 30px; padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
