﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica009.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica009" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Ingresar comprobantes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Para poder ingresar comprobantes, primero debo solicitar permiso al responsable del grupo (opción: Administración --> Unidad de Negocio --> Solicitud permiso de operador de servicio de una UN existente)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="LabelAyuda" Text="Una vez que el responsable autoriza mi solicitud (un mail me avisará cuando esto ocurra), ya estaré en condiciones de ingresar comprobantes." ></asp:Label>
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
                    ¿Cómo ingreso comprobantes?
                </asp:LinkButton>
            </td>
        </tr>    </table>
</asp:Content>
