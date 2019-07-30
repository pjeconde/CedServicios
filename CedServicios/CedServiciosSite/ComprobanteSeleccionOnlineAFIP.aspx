<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprobanteSeleccionOnlineAFIP.aspx.cs" Inherits="CedServicios.Site.ComprobanteSeleccionOnlineAFIP" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "Comprobantes";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
                //alert("VAR:" + tabName);
            });
        });
    </script>
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
        <table align="center" style="width: 100%">
            <tr>
                <td colspan="2" style="padding-top:20px; text-align: center">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes (online AFIP)"></asp:Label>
                    <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
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
                <td align="center" colspan="2" style="padding-top:20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </td>
            </tr>
        </table>
         <asp:HiddenField ID="TabName" runat="server" />
        <div id="Tabs">
            <!-- Nav tabs -->
            <ul class="nav nav-tabs">
                <li id="tab1" class="nav-item active"><a href="#Comprob" data-toggle="tab">
                    <h4>Comprobantes</h4>
                </a></li>
                <li id="tab2" class="nav-item"><a href="#ConsultaCAE" data-toggle="tab">
                    <h4>Consultar CAE</h4>
                </a></li>
                <li id="tab3" class="nav-item"><a href="#Parametros" data-toggle="tab">
                    <h4>Tablas o Parametros</h4>
                </a></li>
                <li id="tab4" class="nav-item"><a href="#DatosFiscales" data-toggle="tab">
                    <h4>Datos Fiscales</h4>
                </a></li>
            </ul>
            <!-- Tab panes -->
            <div class="tab-content">
                <div id="Comprob" role="tabpanel" class="tab-pane fade in active text-left">
                    <table class="">
                        <tbody>
                            <tr>
                                <td style="padding: 10px">
                                    <h4>Buscar Ult. Nro. de Comprobante</h4>
                                    <table>
                                    <tr>
                                        <td style="padding-top: 20px; text-align: right">
                                            Tipo Comprobante:
                                        </td>
                                        <td style="padding-top: 20px; padding-left: 5px; text-align: left">
                                            <asp:DropDownList ID="TipoComprobanteUltNroCompDropDownList" runat="server" AutoPostBack="false"                                               SkinID="DropDownListTipoComprobante" ToolTip="">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 10px; text-align: right">
                                            Punto de Venta:
                                        </td>
                                        <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                            <asp:DropDownList ID="PtoVtaConsultaUltNroCompDropDownList" runat="server" AutoPostBack="false"
                                                SkinID="ddln" ToolTip="">
                                            </asp:DropDownList>
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
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table class="">
                        <tbody>
                            <tr>
                                <td style="padding: 10px">
                                    <h4>Buscar un comprobante</h4>
                                    <table>
                                    <tr>
                                        <td style="padding-top: 20px; text-align: right">
                                            Tipo Comprobante:
                                        </td>
                                        <td style="padding-top: 20px; padding-left: 5px; text-align: left">
                                            <asp:DropDownList ID="TipoComprobanteDropDownList" runat="server" AutoPostBack="True"
                                                SkinID="DropDownListTipoComprobante" ToolTip="">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 10px; text-align: right">
                                            Nro. Comprobante:
                                        </td>
                                        <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                            <asp:TextBox ID="NroComprobanteTextBox" runat="server" ToolTip="">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 10px; text-align: right">
                                            Punto de Venta:
                                        </td>
                                        <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                            <asp:DropDownList ID="PtoVtaConsultaDropDownList" runat="server" AutoPostBack="True"
                                                SkinID="ddln" ToolTip="">
                                            </asp:DropDownList>
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
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="ConsultaCAE" role="tabpanel" class="tab-pane fade text-left">
                    <table class="">
                        <tbody>
                            <tr>
                                <td style="padding: 10px">
                                    <table>
                                        <tr>
                                            <td style="padding-top: 20px; text-align: right">
                                                Tipo Comprobante:
                                            </td>
                                            <td style="padding-top: 20px; padding-left: 5px; text-align: left">
                                                <asp:DropDownList ID="TipoComprobanteValidarCAEDropDownList" runat="server" AutoPostBack="false"
                                                    SkinID="DropDownListTipoComprobante" ToolTip="">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 10px; text-align: right">
                                                Nro. Comprobante:
                                            </td>
                                            <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                                <asp:TextBox ID="NroComprobanteValidarCAETextBox" runat="server" ToolTip="">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 10px; text-align: right">
                                                Punto de Venta:
                                            </td>
                                            <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                                <asp:DropDownList ID="PtoVtaConsultaValidarCAEDropDownList" runat="server" AutoPostBack="false"
                                                    SkinID="ddln" ToolTip="">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 10px; text-align: right">
                                                Cuit del emisor:
                                            </td>
                                            <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                                <asp:TextBox ID="CuitEmisorTextBox" runat="server" ToolTip="">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 10px; text-align: right">
                                                Fecha Emisión:
                                            </td>
                                            <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                                <asp:TextBox ID="FecEmisionTextBox" runat="server" ToolTip="">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 10px; text-align: right">
                                                Nro. CAE:
                                            </td>
                                            <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                                <asp:TextBox ID="NroCAETextBox" runat="server" ToolTip="Informar el número de CAE">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-top: 10px; text-align: right">
                                                Importe Total:
                                            </td>
                                            <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                                <asp:TextBox ID="ImporteTotalTextBox" runat="server" ToolTip="Informar el Importe total del comprobante"
                                                    Enabled="False"></asp:TextBox>
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
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="Parametros" role="tabpanel" class="tab-pane fade text-left">
                    <table class="">
                        <tbody>
                            <tr>
                                <td style="padding: 10px">
                                    <table>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                RG.2485 (Común)
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarTipoComprobantesButton" runat="server" OnClick="ConsultarTipoComprobantesAFIPButton_Click"
                                                    Text="Consultar los Tipos de Comprobantes en AFIP" ToolTip="Consultar los Tipos de Comprobantes en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarUltNroLoteAFIPButton" runat="server" OnClick="ConsultarUltNroLoteAFIPButton_Click"
                                                    Text="Consultar el último número de lote en AFIP" ToolTip="Consultar el Ult. Nro. Lote en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarDocTipoButton" runat="server" OnClick="ConsultarDocTipoAFIPButton_Click"
                                                    Text="Consultar los Tipo de documentos válidos en AFIP (FEv1)" ToolTip="Consultar los Tipos de Documentos válidos en AFIP (FEv1)."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarTiposOpcionalesButton" runat="server" OnClick="ConsultarTiposOpcionalesAFIPButton_Click"
                                                    Text="Consultar los Tipos de opcionales válidos en AFIP (FEv1)" ToolTip="Consultar los Tipos de Opcionales válidos en AFIP (FEv1)."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 20px">
                                                Exportación
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="Button1" runat="server" OnClick="ConsultarTipoComprobantesAFIPEXPOButton_Click"
                                                    Text="Consultar los Tipos de Comprobantes en AFIP" ToolTip="Consultar los Tipos de Comprobantes en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="Button2" runat="server" OnClick="ConsultarTiposDeExportacionAFIPEXPOButton_Click"
                                                    Text="Consultar los Tipos de Exportación posibles en AFIP" ToolTip="Consultar los Tipos de Exportación en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="Button5" runat="server" OnClick="ConsultarUnidadesDeMedidaAFIPEXPOButton_Click"
                                                    Text="Consultar las Unidades de Medida de exportación en AFIP" ToolTip="Consultar las Unidades de Medida de Exportación en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="Button6" runat="server" OnClick="ConsultarIncotermsAFIPEXPOButton_Click"
                                                    Text="Consultar los Tipos de Incoterms en AFIP" ToolTip="Consultar los Tipos de Incoterms habilitados en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="Button3" runat="server" OnClick="ConsultarDST_CuitAFIPEXPOButton_click"
                                                    Text="Consultar los Destinos Cuit en AFIP " ToolTip="Consultar los Destinos Cuit en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="Button4" runat="server" OnClick="ConsultarDST_PaisAFIPEXPOButton_click"
                                                    Text="Consultar los Destinos Pais en AFIP" ToolTip="Consultar los Destinos Pais en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                         <tr>
                                            <td colspan="2" style="padding-top: 20px">
                                                Factura T - Turistas
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarFormasDePagoCTButton" runat="server" OnClick="ConsultarFormasDePagoCTButton_Click"
                                                    Text="Consultar los Medios de Pago" ToolTip="Consultar los medios de pago de factura T. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarTiposComprobantesCTButton" runat="server" OnClick="ConsultarTiposComprobantesCTButton_Click"
                                                    Text="Consultar los Tipos de Comprobantes" ToolTip="Consultar los tipos de comprobantes habilitados. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarTiposDocumentoCTButton" runat="server" OnClick="ConsultarTiposDocumentoCTButton_Click"
                                                    Text="Consultar los Tipos de Documento" ToolTip="Consultar los tipos de documentos habilitados. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarTiposDeIVACTButton" runat="server" OnClick="ConsultarTiposDeIVACTButton_Click"
                                                    Text="Consultar los Tipos de IVA" ToolTip="Consultar los tipos de IVA. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarTiposTributoCTButton" runat="server" OnClick="ConsultarTiposDeTributosCTButton_Click"
                                                    Text="Consultar los Tipos de Tributos" ToolTip="Consultar los tipos de tributos. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarRelacionEmisorReceptorCTButton" runat="server" OnClick="ConsultarRelacionEmisorReceptorCTButton_Click"
                                                    Text="Consultar Relacion Emisor / Receptor" ToolTip="Consultar eelacion Emisor / Receptor. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarPaisesCTButton" runat="server" OnClick="ConsultarPaisesCTButton_Click"
                                                    Text="Consultar los Paises" ToolTip="Consultar paises habilitados. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarMonedasCTButton" runat="server" OnClick="ConsultarMonedasCTButton_Click"
                                                    Text="Consultar las Monedas" ToolTip="Consultar monedas habilitadas. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarCondicionesIVACTAButton" runat="server" OnClick="ConsultarCondicionesIVACTButton_Click"
                                                    Text="Consultar Condiciones de IVA" ToolTip="Consultar Condiciones de IVA. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarTiposDeTarjetasCTButton" runat="server" OnClick="ConsultarTiposDeTarjetasCTButton_Click"
                                                    Text="Consultar Tipos de Tarjetas" ToolTip="Consultar los tipos de tarjetas. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarNovedadesCTButton" runat="server" OnClick="ConsultarNovedadesCTButton_Click"
                                                    Text="Consultar Novedades" ToolTip="Consultar novedades. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarTiposDeCuentasCTButton" runat="server" OnClick="ConsultarTiposDeCuentasCTButton_Click"
                                                    Text="Consultar Tipos de Cuentas" ToolTip="Consultar tipos de cuentas. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarAFIPTiposItemCTButton" runat="server" OnClick="ConsultarAFIPTiposItemCTButton_Click"
                                                    Text="Consultar Tipos de Item" ToolTip="Consultar los tipos de item. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarAFIPCodigosItemTurismoCTButton" runat="server" OnClick="ConsultarAFIPCodigosItemTurismoCTButton_Click"
                                                    Text="Consultar Códigos de Item Turismo" ToolTip="Consultar los codigos de item turismo. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="Button7" runat="server" OnClick="ConsultarAFIPCuitPaisesCTButton_Click"
                                                    Text="Consultar Cuit Paises" ToolTip="Consultar los codigos de Cuit Paises. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="DatosFiscales" role="tabpanel" class="tab-pane fade text-left">
                    <table class="">
                        <tbody>
                            <tr>
                                <td style="padding: 10px">
                                    <h4>Buscar datos fiscales del contribuyente</h4>
                                    <table>
                                        <tr>
                                            <td style="padding-top: 10px; text-align: right">
                                                Cuit a consultar:
                                            </td>
                                            <td style="padding-top: 10px; padding-left: 5px; text-align: left">
                                                <asp:TextBox ID="CuitAConsultarTextBox" runat="server" ToolTip="">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-top: 10px">
                                                <asp:Button ID="ConsultarDatosFiscalesButton" runat="server" OnClick="ConsultarDatosFiscalesButton_Click"
                                                    Text="Obtener Datos Fiscales" ToolTip="Obtener Datos Fiscales de un CUIT. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                    Width="100%" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <asp:TextBox ID="InfoRespuestaTextBox" runat="server" Width="100%" TextMode="MultiLine" Visible="false"></asp:TextBox>
    </div>
    </div>
    </div>
    
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="TargetControlIDdelModalPopupExtender1"
    PopupControlID="ConfirmacionPanel"
    BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="ConfirmacionPanel"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="ConfirmacionPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:Label ID="TituloConfirmacionLabel" runat="server" SkinID="TituloPagina" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-top:20px;">
                    <asp:Label ID="DetalleLabel" runat="server"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td align="left" style="padding-top:20px;">
                    <asp:TextBox ID="DetalleTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>  
            <tr>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
