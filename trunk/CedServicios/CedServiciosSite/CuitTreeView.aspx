<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="CuitTreeView.aspx.cs" Inherits="CedServicios.Site.CuitTreeView" Theme="CedServicios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px;">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Consulta de CUIT(s)"></asp:Label>
                <asp:Label ID="TargetControlIDdelCuitModalPopupExtender" runat="server" Text=""></asp:Label>
                <asp:Label ID="TargetControlIDdelUNModalPopupExtender" runat="server" Text=""></asp:Label>
                <asp:Label ID="TargetControlIDdelPuntoVtaModalPopupExtender" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:TreeView ID="TituloCuitsTreeView" runat="server">
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:TreeView ID="CuitsTreeView" runat="server" 
                    onselectednodechanged="CuitsTreeView_SelectedNodeChanged">
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" Text="Salir" PostBackUrl="~/Default.aspx"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <ajaxToolkit:ModalPopupExtender ID="CuitModalPopupExtender" runat="server"
    TargetControlID="TargetControlIDdelCuitModalPopupExtender"
    PopupControlID="CuitPanel"
    BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="CuitPanel"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="CuitPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="TituloCuitLabel" runat="server" Text="Consulta de CUIT" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender ID="UNModalPopupExtender" runat="server"
    TargetControlID="TargetControlIDdelUNModalPopupExtender"
    PopupControlID="UNPanel"
    BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="UNPanel"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="UNPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="TituloUNLabel" runat="server" Text="Consulta de Unidad de Negocio" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>

    <ajaxToolkit:ModalPopupExtender ID="PuntoVtaModalPopupExtender" runat="server"
    TargetControlID="TargetControlIDdelPuntoVtaModalPopupExtender"
    PopupControlID="PuntoVtaPanel"
    BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="PuntoVtaPanel"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="PuntoVtaPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td>
                    <asp:Label ID="TituloPuntoVtaLabel" runat="server" Text="Consulta de Punto de Venta" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
