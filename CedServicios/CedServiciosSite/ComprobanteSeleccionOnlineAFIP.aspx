<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprobanteSeleccionOnlineAFIP.aspx.cs" Inherits="CedServicios.Site.ComprobanteSeleccionOnlineAFIP" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes (online AFIP)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="padding-top:10px">
                Información Ticket AFIP.
            </td>
        </tr> 
        <tr>
            <td align="left" colspan="2" style="padding-top:10px">
                <asp:TextBox ID="TicketInfoTextBox" runat="server" Width="100%" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>      
        <tr>
            <td align="left" colspan="2" style="padding-top:10px">
                Para consultar los Tipo de Comprobantes y el Ult. Nro. Lote disponible en AFIP no es necesario ingresar ningún dato.
            </td>
        </tr>        
        <tr>
            <td colspan="2" style="padding-top:10px">
                <asp:Button ID="ConsultarTipoComprobantesButton" runat="server"
                    OnClick="ConsultarTipoComprobantesAFIPButton_Click" Text="Consultar los Tipos de Comprobantes en AFIP"
                    ToolTip="Consultar los Tipos de Comprobantes en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:10px">
                <asp:Button ID="ConsultarUltNroLoteAFIPButton" runat="server"
                    OnClick="ConsultarUltNroLoteAFIPButton_Click" Text="Consultar el último número de lote en AFIP"
                    ToolTip="Consultar el Ult. Nro. Lote en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:10px">
                <asp:Button ID="ConsultarDocTipoButton" runat="server"
                    OnClick="ConsultarDocTipoAFIPButton_Click" Text="Consultar los Tipo de documentos válidos en AFIP (FEv1)"
                    ToolTip="Consultar los Tipos de Documentos válidos en AFIP (FEv1)."
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:20px">
                Tipo Comprobante:
            </td>
            <td align="left" style="padding-top:20px; padding-left:5px">
                <asp:DropDownList ID="TipoComprobanteDropDownList" runat="server" AutoPostBack="True" SkinID="DropDownListTipoComprobante" ToolTip="">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:10px">
                Nro. Comprobante:
            </td>
            <td align="left" style="padding-top:10px; padding-left:5px">
                <asp:TextBox ID="NroComprobanteTextBox" runat="server" ToolTip="">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:10px">
                Punto de Venta:
            </td>
            <td align="left" style="padding-top:10px; padding-left:5px">
                <asp:DropDownList ID="PtoVtaConsultaDropDownList" runat="server" AutoPostBack="True" SkinID="ddlch" ToolTip="">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="padding-top:20px">
                Para consultar el CAE deberá ingresar el Punto de Venta, Tipo y Número de Comprobante.
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:10px">
                <asp:Button ID="ConsultarLoteAFIPButton" runat="server"
                    OnClick="ConsultarLoteAFIPButton_Click" Text="Consultar lote en AFIP"
                    ToolTip="Consultar el comprobante en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="padding-top:20px">
                Para consultar el Ultimo Nro. de comprobante deberá ingresar el Punto de Venta y el Tipo de Comprobante.
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:10px">
                <asp:Button ID="ConsultarUltNroComprobanteAFIPButton" runat="server"
                    OnClick="ConsultarUltNroComprobanteAFIPButton_Click" Text="Consultar el último número de comprobante en AFIP"
                    ToolTip="Consultar el Ult. Nro. Comprobante en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:10px">
                Cuit del emisor:
            </td>
            <td align="left" style="padding-top:10px; padding-left:5px">
                <asp:TextBox ID="CuitEmisorTextBox" runat="server" ToolTip="">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:10px">
                Fecha Emisión:
            </td>
            <td align="left" style="padding-top:10px; padding-left:5px">
                <asp:TextBox ID="FecEmisionTextBox" runat="server" ToolTip="">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:10px">
                Nro. CAE:
            </td>
            <td align="left" style="padding-top:10px; padding-left:5px">
                <asp:TextBox ID="NroCAETextBox" runat="server" ToolTip="Informar el número de CAE">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top:10px">
                Importe Total:
            </td>
            <td align="left" style="padding-top:10px; padding-left:5px">
                <asp:TextBox ID="ImporteTotalTextBox" runat="server" 
                    ToolTip="Informar el Importe total del comprobante" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="padding-top:10px">
                Para validar el CAE tambíen deberá ingresar el Punto de Venta, Tipo y Número de Comprobante.
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:10px">
                <asp:Button ID="ConsultarCAEAFIPButton" runat="server"
                    OnClick="ConsultarCAEAFIPButton_Click" Text="Validar el CAE en AFIP"
                    ToolTip="Validar el CAE en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
