<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="Autorizacion.aspx.cs" Inherits="CedServicios.Site.Autorizacion" Theme="CedServicios" %>

<asp:Content ID="Content14" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Solicitud de autorización"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:20px">
                <asp:Label ID="IdTipoPermisoLabel" runat="server" Text="Permiso de"></asp:Label>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:DropDownList ID="IdTipoPermisoDropDownList" runat="server" TabIndex="2" Width="300px" DataValueField="Id" DataTextField="Descr" Enabled="false" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top: 5px">
                <asp:Label ID="IdUsuarioLabel" runat="server" Text="solicitado para"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:DropDownList ID="IdUsuarioDropDownList" runat="server" TabIndex="2" Width="300px" DataValueField="Id" DataTextField="Nombre" Enabled="false" >
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:5px">
                <asp:Label ID="CUITLabel" runat="server" Text="CUIT"></asp:Label>
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="CUITTextBox" runat="server" Width="80px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:2px">
                <asp:Label ID="IdUNLabel" runat="server" Text="Unid.Neg."></asp:Label>
            </td>
            <td align="left" style="padding-top:2px">
                <asp:DropDownList ID="IdUNDropDownList" runat="server" TabIndex="2" Width="300px" DataValueField="Id" DataTextField="Descr" Enabled="false" >
                </asp:DropDownList>
            </td>        
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:2px">
                <asp:Label ID="IdUsuarioAutorizadorLabel" runat="server" Text="Autorizador"></asp:Label>
            </td>
            <td align="left" style="padding-top:2px">
                <asp:DropDownList ID="IdUsuarioAutorizadorDropDownList" runat="server" TabIndex="2" Width="300px" DataValueField="Id" DataTextField="Nombre" Enabled="false"  >
                </asp:DropDownList>
            </td>        
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                <asp:Button ID="AutorizarButton" runat="server" OnClick="AutorizarButton_Click" TabIndex="1" Text="Autorizar" />
                <asp:Button ID="RechazarButton" runat="server" OnClick="RechazarButton_Click" TabIndex="2" Text="Rechazar" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="3" Text="Cancelar" PostBackUrl="~/Default.aspx" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary">
                </asp:ValidationSummary>
            </td>
        </tr>
    </table>
</asp:Content>
