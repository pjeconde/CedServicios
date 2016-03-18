<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprobanteSeleccionOnlineAFIP.aspx.cs" Inherits="CedServicios.Site.ComprobanteSeleccionOnlineAFIP" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table align="center">
        <tr>
            <td colspan="2" style="padding-top:20px; text-align: center">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes (online AFIP)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:10px; text-align: left">
                Información Ticket AFIP.
            </td>
        </tr> 
        <tr>
            <td colspan="2" style="padding-top:10px; text-align: left">
                <asp:TextBox ID="TicketInfoTextBox" runat="server" Width="100%" 
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>      
        <tr>
            <td colspan="2" style="padding-top:10px; text-align: left">
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
            <td style="padding-top:20px; text-align: right">
                Tipo Comprobante:
            </td>
            <td style="padding-top:20px; padding-left:5px; text-align: left">
                <asp:DropDownList ID="TipoComprobanteDropDownList" runat="server" AutoPostBack="True" SkinID="DropDownListTipoComprobante" ToolTip="">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="padding-top:10px; text-align: right">
                Nro. Comprobante:
            </td>
            <td style="padding-top:10px; padding-left:5px; text-align: left">
                <asp:TextBox ID="NroComprobanteTextBox" runat="server" ToolTip="">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-top:10px; text-align: right">
                Punto de Venta:
            </td>
            <td style="padding-top:10px; padding-left:5px; text-align: left">
                <asp:DropDownList ID="PtoVtaConsultaDropDownList" runat="server" AutoPostBack="True" SkinID="ddlch" ToolTip="">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:20px; text-align: left">
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
            <td colspan="2" style="padding-top:20px; text-align: left">
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
            <td style="padding-top:10px; text-align: right">
                Cuit del emisor:
            </td>
            <td style="padding-top:10px; padding-left:5px; text-align: left">
                <asp:TextBox ID="CuitEmisorTextBox" runat="server" ToolTip="">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-top:10px; text-align: right">
                Fecha Emisión:
            </td>
            <td style="padding-top:10px; padding-left:5px; text-align: left">
                <asp:TextBox ID="FecEmisionTextBox" runat="server" ToolTip="">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-top:10px; text-align: right">
                Nro. CAE:
            </td>
            <td style="padding-top:10px; padding-left:5px; text-align: left">
                <asp:TextBox ID="NroCAETextBox" runat="server" ToolTip="Informar el número de CAE">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-top:10px; text-align: right">
                Importe Total:
            </td>
            <td style="padding-top:10px; padding-left:5px; text-align: left">
                <asp:TextBox ID="ImporteTotalTextBox" runat="server" 
                    ToolTip="Informar el Importe total del comprobante" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:10px; text-align: left">
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
            <td style="padding-top:10px; text-align: right">
                Cuit a consultar:
            </td>
            <td style="padding-top:10px; padding-left:5px; text-align: left">
                <asp:TextBox ID="CuitAConsultarTextBox" runat="server" ToolTip="">
                </asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:10px">
                <asp:Button ID="ConsultarDatosFiscalesButton" runat="server"
                    OnClick="ConsultarDatosFiscalesButton_Click" Text="Obtener Datos Fiscales"
                    ToolTip="Obtener Datos Fiscales de un CUIT. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
</asp:Content>
