<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CedServicios.Site.Default" Theme="CedServicios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" Visible="true" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <asp:Button ID="PruebaButton" runat="server" Text="Prueba" onclick="PruebaButton_Click"/>
    <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    PopupControlID="MensajePopup"
    PopupDragHandleControlID="MensajePopup" 
    TargetControlID="TargetControlIDdelModalPopupExtender1"
    BackgroundCssClass="modalBackground"
    BehaviorID="mdlPopup">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="MensajePopup" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td align="center">
                    <asp:Label ID="MensajePopupLabel" runat="server" Text="xxxxxxxxxx" SkinID="TextoMediano"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" style="padding-top:20px">
                    <asp:Button ID="SalirPuntoVtaButton" runat="server" Text="Continuar" 
                        onclick="SalirButton_Click"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>