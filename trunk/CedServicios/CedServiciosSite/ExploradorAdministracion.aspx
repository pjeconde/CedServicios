<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorAdministracion.aspx.cs" Inherits="CedServicios.Site.ExploradorAdministracion" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table cellspacing="0" cellpadding="0" align="left" style="padding-left:10px; border-color: Black; border-width: 1px;">
        <tr>
            <td align="center" colspan="3" style="padding-top: 20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Administración del Site"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 20px; padding-right: 5px; vertical-align: top;">
                Aplicación Start:
            </td>
            <td align="left" style="padding-top: 20px; vertical-align: top;">
                <asp:Label ID="AplicationStartLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right: 5px; vertical-align: top;">
                Contador de Visitas:
            </td>
            <td align="left" style="vertical-align: top; vertical-align: top;">
                <asp:Label ID="ContadorVisitasLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right: 5px; vertical-align: top;">
                Visitantes Activos:
            </td>
            <td align="left" style="vertical-align: top;">
                <asp:Label ID="VisitantesLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right: 5px; vertical-align: top;">
                Sesiones Activas:
            </td>
            <td align="left" style="vertical-align: top;">
                <asp:Label ID="SesionesActivasLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="height: 24px; padding-top: 20px">
                <asp:Button ID="RefrescarButton" runat="server" TabIndex="8" Text="Refrescar" OnClick="RefrescarButton_Click"
                    OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
