<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UNCrear.aspx.cs" Inherits="CedServicios.Site.UNCrear" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Alta de Unidad de Negocio"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top: 20px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="CUITTextBox" ErrorMessage="CUIT" SetFocusOnError="True" ValidationExpression="[0-9]{11}">
                    <asp:Label ID="Label1" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CUITTextBox"
                    ErrorMessage="CUIT" SetFocusOnError="True">
                    <asp:Label ID="Label2" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label3" runat="server" Text="CUIT"></asp:Label>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                    Width="80px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:10px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="IdUNTextBox"
                    ErrorMessage="Id" SetFocusOnError="True">
                    <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label6" runat="server" Text="Id."></asp:Label>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:TextBox ID="IdUNTextBox" runat="server" MaxLength="20" TabIndex="2" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:5px; padding-top:10px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DescrUNTextBox"
                    ErrorMessage="Descr" SetFocusOnError="True">
                    <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label9" runat="server" Text="Descripción"></asp:Label>
            </td>
            <td align="left" style="padding-top:20px">
                <asp:TextBox ID="DescrUNTextBox" runat="server" MaxLength="50" TabIndex="3" Width="300px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top:20px">
                <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="4"
                    Text="Aceptar" />
                <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" OnClick="CancelarButton_Click"
                    TabIndex="5" Text="Cancelar" />
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
