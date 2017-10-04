<%@ Page AutoEventWireup="true" Theme="CedServicios" Buffer="true" CodeBehind="LoteCT.aspx.cs" 
    Culture="en-GB" UICulture="en-GB" Inherits="CedServicios.Site.Facturacion.Electronica.LoteCT" Language="C#" 
    MaintainScrollPositionOnPostback="true" MasterPageFile="~/CedServicios.Master"
    Title="Factura Electrónica Gratis(Interfacturas - AFIP)" EnableEventValidation="false" ValidateRequest="false"%>

<%@ Register Src="DetalleCT.ascx" TagName="DetalleCT" TagPrefix="uc4" %>
<%@ Register Src="Extensiones/Comerciales.ascx" TagName="Comerciales" TagPrefix="uc3" %>
<%@ Register Src="ReferenciasCTAFIP.ascx" TagName="ReferenciasCTAFIP" TagPrefix="uc9" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Facturacion/Electronica/ImpuestosCT.ascx" TagName="ImpuestosCTGlobales" TagPrefix="uc8" %>
<%@ Register Src="FacturaElectronicaFecha.ascx" TagName="FacturaElectronicaFecha" TagPrefix="uc1" %>

<asp:Content ID="XMLContent" runat="Server" ContentPlaceHolderID="ContentPlaceDefault">
    <script type="text/javascript">
        $(function () {
            $('[data-toggle="popover"]').popover()
        });
    </script>
    <style type="text/css">
    .popover
    {
    	width: 400px;
    }
    </style>
    <table style="border:0; width: 1300px; text-align:left; padding-left:10px">
        <tr>
            <td style="padding-top:20px; width:1282px; vertical-align:middle; text-align:center; vertical-align:top">
                
                <table style="border:0">
                    <!-- @@@ TITULO DE LA PAGINA @@@-->
                    <tr>
                        <td style="text-align: center; vertical-align: middle">
                            <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Alta de ..."></asp:Label>
                        </td>
                    </tr>
                    <!-- COMPROBANTE -->
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="InfoComproUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList" EventName="TextChanged">
                                    </asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="Tipo_De_ComprobanteDropDownList" EventName="SelectedIndexChanged"/>
                                </Triggers>
                                <ContentTemplate>
                                    <table style="width:1282px">
                                        <tr>
                                            <td class="TextoResaltado" colspan="6" style="text-align:center">
                                                <asp:Label ID="DatosComprobanteLabel" runat="server" Text="COMPROBANTE"></asp:Label>
                                                <asp:TextBox ID="IdNaturalezaComprobanteTextBox" runat="server" Visible="false"> </asp:TextBox>
                                                <asp:TextBox ID="TratamientoTextBox" runat="server" Visible="false"> </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height:10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TC00S">
                                                Punto de venta:
                                            </td>
                                            <td class="TC10S">
                                                <asp:UpdatePanel ID="ptoVentaUpdatePanel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="PuntoVtaDropDownList" runat="server" AutoPostBack="true" Enabled="false" SkinID="ddln" 
                                                        onselectedindexchanged="PuntoVtaDropDownList_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="PuntoVtaTextBox" runat="server" Enabled="true" Visible="false" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                        <asp:Label ID="TipoPtoVentaLabel" runat="server" Visible="false"></asp:Label>
                                                        <asp:UpdateProgress ID="ptoVentaUpdateProgress" runat="server" AssociatedUpdatePanelID="ptoVentaUpdatePanel" DisplayAfter="0">
                                                            <ProgressTemplate>
                                                                <asp:Image ID="ptoVentaImage" runat="server" Height="18px" ImageUrl="~/Imagenes/301.gif">
                                                                </asp:Image>
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="TC00S">
                                                Tipo de comprobante:
                                            </td>
                                            <td class="TC10S">
                                                <asp:UpdatePanel ID="Tipo_De_ComprobanteUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                    UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="Tipo_De_ComprobanteDropDownList" runat="server" SkinID="DropDownListTipoComprobante" OnSelectedIndexChanged="Tipo_De_ComprobanteDropDownList_SelectedIndexChanged" AutoPostBack="true" 
                                                        style="width:300px">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td class="TC00S">
                                                <asp:Label ID="NumeroDeLabel" runat="server" Text="Número de comprobante:" Visible="true"></asp:Label>
                                            </td>
                                            <td class="TC10S">
                                                <asp:TextBox ID="Numero_ComprobanteTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetMed" AutoCompleteType="Disabled"  MaxLength="8" 
                                                    ToolTip="Debe ser correlativo al último ingresado por Punto de Venta y Tipo de Comprobante. No es necesario ingresar ceros a la izquierda. Si su factura es p.ej.0002-00000005, puede ingresar 5."> </asp:TextBox>
                                                <asp:LinkButton ID="ProximoNroComprobanteLinkButton" runat="server" SkinID="LinkButtonChico" Text="Próximo" OnClick="ProximoNroComprobanteLinkButton_Click" Visible="false"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TC00S">
                                                Fecha de vencimiento:
                                            </td>
                                            <td class="TC10S">
                                                <asp:TextBox ID="FechaVencimientoDatePickerWebUserControl" runat="server" 
                                                    SkinID="FechaFact" MaxLength="8"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" 
                                                    CssClass="MyCalendar" Format="yyyyMMdd" 
                                                    PopupButtonID="ImageCalendarFechaVencimiento" 
                                                    TargetControlID="FechaVencimientoDatePickerWebUserControl">
                                                </cc1:CalendarExtender>
                                                <asp:ImageButton ID="ImageCalendarFechaVencimiento" runat="server" 
                                                    CausesValidation="false" ImageUrl="~/Imagenes/Calendar.gif" />
                                            </td>
                                            <td class="TC00S">
                                                Moneda:
                                            </td>
                                            <td class="TC10S">
                                                <asp:UpdatePanel ID="monedaUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                    UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="MonedaComprobanteDropDownList" runat="server" AutoPostBack="true" Enabled="false" SkinID="ddln">
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:Label ID="MonedaComprobanteExclusivoPremiumLabel" runat="server" Font-Size="X-Small"
                                                    ForeColor="Brown"></asp:Label>
                                                <asp:UpdateProgress ID="monedaUpdateProgress" runat="server" AssociatedUpdatePanelID="monedaUpdatePanel"
                                                    DisplayAfter="0">
                                                    <ProgressTemplate>
                                                        <asp:Image ID="monedaImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
                                                        </asp:Image>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </td>
                                            <td class="TC00S">
                                                <asp:Label ID="FechaEmisionLabel" runat="server" Text="Fecha de emisión:" Visible="true"></asp:Label>
                                            </td>
                                            <td class="TC10S">
                                                <asp:TextBox ID="FechaEmisionDatePickerWebUserControl" runat="server" CausesValidation="true" SkinID="FechaFact" MaxLength="8"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" BehaviorID="a2"
                                                    TargetControlID="FechaEmisionDatePickerWebUserControl"  
                                                    Format="yyyyMMdd" PopupButtonID="ImageCalendarFechaEmision">
                                                </cc1:CalendarExtender>
                                                <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarFechaEmision" ImageUrl="~/Imagenes/Calendar.gif" />
                                                <asp:Literal runat="server" ID="AyudaFechaEmision" />
                                            </td>
                                        </tr>
                                        <tr>
                                             <td class="TC00S">
                                                <asp:Label ID="FechaInicioServLabel" runat="server" 
                                                    Text="Fecha servicio inicio:"></asp:Label>
                                            </td>
                                            <td class="TC10S">
                                                <asp:TextBox ID="FechaServDesdeDatePickerWebUserControl" runat="server" 
                                                    SkinID="FechaFact" MaxLength="8"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" 
                                                    CssClass="MyCalendar" Format="yyyyMMdd" 
                                                    PopupButtonID="ImageCalendarFechaServDesde" 
                                                    TargetControlID="FechaServDesdeDatePickerWebUserControl">
                                                </cc1:CalendarExtender>
                                                <asp:ImageButton ID="ImageCalendarFechaServDesde" runat="server" 
                                                    CausesValidation="false" ImageUrl="~/Imagenes/Calendar.gif" />
                                            </td>
                                            <td class="TC00S">
                                                <asp:Label ID="FechaHstServLabel" runat="server" Text="Fecha servicio fin:">
                                                </asp:Label>
                                            </td>
                                            <td class="TC10S">
                                                <asp:TextBox ID="FechaServHastaDatePickerWebUserControl" runat="server" 
                                                    SkinID="FechaFact" MaxLength="8"></asp:TextBox>
                                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" 
                                                    CssClass="MyCalendar" Format="yyyyMMdd" 
                                                    PopupButtonID="ImageCalendarFechaServHasta" 
                                                    TargetControlID="FechaServHastaDatePickerWebUserControl">
                                                </cc1:CalendarExtender>
                                                <asp:ImageButton ID="ImageCalendarFechaServHasta" runat="server" 
                                                    CausesValidation="false" ImageUrl="~/Imagenes/Calendar.gif" />
                                            </td>
                                            <td class="TC00S">
                                                Condición de pago:
                                            </td>
                                            <td class="TC10S">
                                                <asp:TextBox ID="Condicion_De_PagoTextBox" runat="server" BorderStyle="NotSet" Style="width:300px; text-align:left">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <hr noshade="noshade" size="1" color="#cccccc" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <!-- VENDEDOR -->
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="VendedorUpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:Panel ID="pHeader" runat="server" CssClass="TextoResaltado">
                                        <asp:Label ID="lblText" runat="server" Text="VENDEDOR" />
                                        <asp:Image ID="imageCE" runat="server" ImageUrl="~/Imagenes/Iconos/icon_expand.gif" style="vertical-align:text-bottom" />
                                    </asp:Panel>
                                    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                                    <table style="width:1282px">
                                        <tr>
                                            <td colspan="5">
                                                <table style="width:100%">
                                                    <tr>
                                                        <td style="padding-top: 5px">
                                                            Elegir vendedor: 
                                                            <asp:DropDownList ID="VendedorDropDownList" runat="server" AutoPostBack="true" Enabled="false"
                                                                OnSelectedIndexChanged="VendedorDropDownList_SelectedIndexChanged" SkinID="DropDownListPersona" Visible="false">
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="IdPersonaVendedorTextBox" runat="server" Visible="false"> </asp:TextBox>
                                                            <asp:TextBox ID="DesambiguacionCuitPaisVendedorTextBox" runat="server" Visible="false"> </asp:TextBox>
                                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="vendedorUpdatePanel"
                                                                DisplayAfter="0">
                                                                <ProgressTemplate>
                                                                    <asp:Image ID="vendedorImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
                                                                    </asp:Image>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height:10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="text-align: left; vertical-align: top">
                                                <table style="width: 400px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            Razón Social:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Razon_Social_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="50"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Calle:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Domicilio_Calle_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="60"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Sector:
                                                        </td>
                                                        <td class="TC10S" style="padding-right: 5px">
                                                            <asp:TextBox ID="Domicilio_Sector_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="5"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Provincia:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:DropDownList ID="Provincia_VendedorDropDownList" runat="server" SkinID="ddln2">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Condición IB:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:DropDownList ID="Condicion_Ingresos_Brutos_VendedorDropDownList" runat="server"
                                                                SkinID="ddln2" 
                                                                onselectedindexchanged="Condicion_Ingresos_Brutos_VendedorDropDownList_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Nombre contacto:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Contacto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="25"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            GLN:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="GLN_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor."> </asp:TextBox>
                                                            <a href="javascript:void(0)" id="A3" role="button" class="popover-test" data-html="true" title="GLN" data-placement="top" 
                                                                style="width: 200px" data-content="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
                                                                <span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit;">
                                                                </span></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 30px;">
                                            </td>
                                            <td style="text-align:left; vertical-align:top">
                                                <table style="width: 400px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            CUIT:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Cuit_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Nro.:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Domicilio_Numero_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="6"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Torre:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Domicilio_Torre_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="5"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Localidad:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Localidad_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="25"> </asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="TC00S">
                                                            IB:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="NroIBVendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="Formatos válidos: XXXXXXX-XX o XX-XXXXXXXX-X o XXX-XXXXXX-X o XXXXXXXXXXX" MaxLength="13"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Teléfono contacto:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Telefono_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Código interno:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Codigo_Interno_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="20"
                                                                ToolTip="<Opcional> Código utilizado para identificar al vendedor dentro de una empresa/organización. (Ej. Código de Cliente, Proveedor, etc.)"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 30px;">
                                            </td>
                                            <td align="left" valign="top">
                                                <table style="width: 400px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            Inicio de actividades:
                                                        </td>
                                                        <td align="left" style="padding-left: 4px; padding-top: 5px;" valign="top">
                                                            <asp:TextBox ID="InicioDeActividadesVendedorDatePickerWebUserControl" runat="server" SkinID="FechaFact" MaxLength="8"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                                                OnClientShown="onCalendar1Shown" TargetControlID="InicioDeActividadesVendedorDatePickerWebUserControl"
                                                                Format="yyyyMMdd" PopupButtonID="ImageCalendarInicioDeActividadesVendedor">
                                                            </cc1:CalendarExtender>
                                                            <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarInicioDeActividadesVendedor" ImageUrl="~/Imagenes/Calendar.gif" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Piso:
                                                        </td>
                                                        <td>
                                                            <table border="0">
                                                                <tr>
                                                                    <td class="TC02SL">
                                                                        <asp:TextBox ID="Domicilio_Piso_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="5"> </asp:TextBox>
                                                                    </td>
                                                                    <td class="TC02S">
                                                                        Depto:
                                                                    </td>
                                                                    <td class="TC02SL">
                                                                        <asp:TextBox ID="Domicilio_Depto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="5"> </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Manzana:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Domicilio_Manzana_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="5"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Código Postal:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Cp_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            IVA:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:DropDownList ID="Condicion_IVA_VendedorDropDownList" runat="server" SkinID="ddln2">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            e-mail Contacto:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Email_VendedorTextBox" runat="server" AutoCompleteType="Email" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
                                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtenderVendedor" runat="server" TargetControlID="pBody" 
                                        CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText" CollapsedText="VENDEDOR" ExpandedText="VENDEDOR"  ImageControlID="imageCE" ExpandedImage="~/Imagenes/Iconos/icon_collapse.gif"
                                        CollapsedImage="~/Imagenes/Iconos/icon_expand.gif"
                                        CollapsedSize="0">
                                    </cc1:CollapsiblePanelExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <table style="width: 1282px; vertical-align: top">
                                <tr>
                                    <td style="">
                                        <hr noshade="noshade" size="1" color="#cccccc" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- COMPRADOR -->
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="compradorUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                </Triggers>
                                <ContentTemplate>
                                    <table style="width:1282px">
                                        <tr>
                                            <td style="height:10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TextoResaltado" colspan="5" style="text-align: center">
                                                COMPRADOR
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height:10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="padding-top: 5px">
                                                            Elegir comprador: 
                                                            <asp:DropDownList ID="CompradorDropDownList" runat="server" AutoPostBack="true" Enabled="false"
                                                                OnSelectedIndexChanged="CompradorDropDownList_SelectedIndexChanged" SkinID="DropDownListPersona" Visible="false">
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="IdPersonaCompradorTextBox" runat="server" Visible="false"> </asp:TextBox>
                                                            <asp:TextBox ID="DesambiguacionCuitPaisCompradorTextBox" runat="server" Visible="false" Text="0"> </asp:TextBox>
                                                            <asp:UpdateProgress ID="compradorUpdateProgress" runat="server" AssociatedUpdatePanelID="compradorUpdatePanel"
                                                                DisplayAfter="0">
                                                                <ProgressTemplate>
                                                                    <asp:Image ID="compradorImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
                                                                    </asp:Image>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height:10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align:right; vertical-align:top">
                                                <table style="width: 400px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            Denominación:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Denominacion_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="Razón Social y Nombre del comprador" MaxLength="50">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Calle:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Domicilio_Calle_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="30">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Sector:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Domicilio_Sector_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="5"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Provincia:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:DropDownList ID="Provincia_CompradorDropDownList" runat="server" SkinID="ddln">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Nombre contacto:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Contacto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="25">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            e-mail para aviso:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="EmailAvisoVisualizacionTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="60" 
                                                                ToolTip="A esta dirección se enviará un email de aviso para que el destinatario pueda visualizar el comprobante">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            GLN:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="GLN_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="13" ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor.">
                                                            </asp:TextBox>
                                                            <a href="javascript:void(0)" id="A4" role="button" class="popover-test" data-html="true"
                                                                title="GLN" data-placement="top" style="width: 200px" data-content="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
                                                                <span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit;">
                                                                </span></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Lista de Precios predefinida
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="IdListaPrecioTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" ReadOnly="true"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="bgFEAC" style="width: 30px; background-repeat: repeat-y;">
                                            </td>
                                            <td style="text-align:left; vertical-align:top">
                                                <table style="width: 400px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            Tipo de documento:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:DropDownList ID="Codigo_Doc_Identificatorio_CompradorDropDownList" AutoPostBack="true" runat="server" SkinID="ddln" 
                                                            onselectedindexchanged="Codigo_Doc_Identificatorio_CompradorDropDownList_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Nro.:
                                                        </td>
                                                        <td class="TC10S" style="padding-right: 5px">
                                                            <asp:TextBox ID="Domicilio_Numero_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="6"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Torre:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Domicilio_Torre_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="5"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Localidad:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Localidad_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="25">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            e-mail Contacto:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Email_CompradorTextBox" runat="server" AutoCompleteType="Email" MaxLength="60"
                                                                SkinID="TextoBoxFEAVendedorDet">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Contraseña para aviso:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="PasswordAvisoVisualizacionTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="Para poder acceder al contenido del comprobante, se solicitará al destinatario el ingreso de esta contraseña">
                                                            </asp:TextBox>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Código interno:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Codigo_Interno_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="20"
                                                                ToolTip="<Opcional> Código utilizado para identificar al comprador dentro de una empresa/organización. (Ej. Código de Cliente, Proveedor, etc.)">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Relación:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:DropDownList ID="CodigoRelacionReceptorEmisorDropDownList" runat="server" SkinID="ddln">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td class="bgFEAC" style="width: 30px; background-repeat: repeat-y;">
                                            </td>
                                            <td style="text-align:left; vertical-align:top">
                                                <table style="width: 400px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            Nro. de documento:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Nro_Doc_Identificatorio_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="11">
                                                            </asp:TextBox>
                                                            <asp:DropDownList ID="Nro_Doc_Identificatorio_CompradorDropDownList" runat="server" SkinID="ddln" Visible="false" CausesValidation="false">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Piso:
                                                        </td>
                                                        <td>
                                                            <table style="padding-top: 5px; text-align: right;">
                                                                <tr>
                                                                    <td class="TC02SL">
                                                                        <asp:TextBox ID="Domicilio_Piso_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="5"> </asp:TextBox>
                                                                    </td>
                                                                    <td class="TC03S" style="padding-right: 5px">
                                                                        Depto:
                                                                    </td>
                                                                    <td class="TC02SL">
                                                                        <asp:TextBox ID="Domicilio_Depto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh" MaxLength="5"> </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Manzana:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Domicilio_Manzana_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="5"> </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Código Postal:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Cp_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="8">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Teléfono contacto:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Telefono_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" MaxLength="50">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Inicio de actividades:
                                                        </td>
                                                        <td style="padding-left: 6px; padding-top: 5px;">
                                                            <asp:TextBox ID="InicioDeActividadesCompradorDatePickerWebUserControl" runat="server" SkinID="FechaFact" MaxLength="8"></asp:TextBox>
                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="InicioDeActividadesCompradorDatePickerWebUserControl"
                                                                Format="yyyyMMdd" CssClass="MyCalendar" PopupButtonID="ImageCalendarInicioDeActividadesComprador">
                                                            </cc1:CalendarExtender>
                                                            <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarInicioDeActividadesComprador" ImageUrl="~/Imagenes/Calendar.gif" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            IVA:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:DropDownList ID="Condicion_IVA_CompradorDropDownList" runat="server" SkinID="ddln">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Pais:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:DropDownList ID="CodigoPaisDropDownList" runat="server" SkinID="ddln">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <hr noshade="noshade" size="1" color="#cccccc" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <!-- REFERENCIAS -->
                    <tr>
                        <td style="text-align: center">
                            <asp:Panel ID="ReferenciasPanel" runat="server">
                                <table style="width:1282px">
                                    <tr>
                                        <td style="height:19px; text-align:center">
                                            <uc9:ReferenciasCTAFIP ID="InfoReferencias" runat="server"></uc9:ReferenciasCTAFIP>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr noshade="noshade" size="1" color="#cccccc" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <!-- DATOS COMERCIALES-->
                    <tr>
                        <td>
                            <asp:Panel ID="DatosComerialesPanel" runat="server">
                                <table style="width:1282px">
                                    <tr>
                                        <td style="height:19px; text-align:center">
                                            <uc3:Comerciales ID="DatosComerciales" runat="server"></uc3:Comerciales>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr noshade="noshade" size="1" color="#cccccc" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <!-- DETALLE DE ARTÍCULOS / SERVICIOS -->
                    <tr>
                        <td style="text-align: center">
                            <table style="width:1282px">
                                <tr>
                                    <td style="text-align: center; height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TextoResaltado" style="text-align: center;">
                                        DETALLE DE ARTÍCULOS / SERVICIOS
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TC00SL" style="padding-left:10px">
                                        Comentarios:
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 1282px; text-align:center">
                                            <tr>
                                                <td class="TextoLabelFEADescrLarga" style="text-align:center">
                                                    <asp:TextBox ID="ComentariosTextBox" runat="server" Style="width:1260px; resize:none" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc4:DetalleCT ID="DetalleLinea" runat="server"></uc4:DetalleCT>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <hr noshade="noshade" size="1" style="color:#cccccc" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- IMPUESTOS GLOBALES -->
                    <tr>
                        <td style="text-align:center">
                            <table style="width: 1282px">
                                <tr>
                                    <td>
                                        <uc8:ImpuestosCTGlobales ID="ImpuestosGlobales" runat="server"></uc8:ImpuestosCTGlobales>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <hr noshade="noshade" size="1" color="#cccccc" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- RESUMEN FINAL -->
                    <tr>
                        <td style="text-align: center">
                            <table border="0" cellpadding="0" cellspacing="0" style="width:1282px">
                                <tr>
                                    <td style="height: 10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-left:5px; width:180px" valign="top">
                                        <asp:Panel ID="CAEPanel" runat="server">
                                            <table style="border-color: Gray; border-width: 1px; border-style: solid" width="180px">
                                                <tr>
                                                    <td style="height:10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TextoResaltado" style="text-align:center">
                                                        <asp:Label ID="Label4" runat="server" Text="DATOS C.A.E."></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height:10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00SL" style="padding-left:5px">
                                                        Si ya solicitó la CAE a la AFIP, ingrésela aqui:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00SL" style="padding-left:5px">
                                                        CAE:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC10S" style="padding-right:5px">
                                                        <asp:TextBox ID="CAETextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="<Opcional> MUY IMPORTANTE! Solo si YA TIENE GENERADO EL C.A.E., debe ingresar este dato. Si omite esta información, se generará una nueva factura ante la AFIP o bien se retornará un error por comprobante ya ingresado." Width="100px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00SL" style="padding-left:5px">
                                                        Fecha de vencimiento CAE:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="FechaCAEVencimientoDatePickerWebUserControl" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="FechaCAEVencimientoDatePickerWebUserControl"
                                                            Format="yyyyMMdd" CssClass="MyCalendar" PopupButtonID="ImageCalendarFechaCAEVencimiento">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarFechaCAEVencimiento" ImageUrl="~/Imagenes/Calendar.gif" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00SL" style="padding-left:5px">
                                                        Fecha de obtención CAE:
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="FechaCAEObtencionDatePickerWebUserControl" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="FechaCAEObtencionDatePickerWebUserControl"
                                                            Format="yyyyMMdd" CssClass="MyCalendar" PopupButtonID="ImageCalendarFechaCAEObtencion">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarFechaCAEObtencion" ImageUrl="~/Imagenes/Calendar.gif" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height:10px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                    <td style="width:300px">
                                    </td>
                                    <td align="left" valign="top">
                                        <asp:UpdatePanel ID="tipoCambioUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                            OnLoad="tipoCambioUpdatePanel_Load" UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="MonedaComprobanteDropDownList"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="SugerirTotalesButton"></asp:AsyncPostBackTrigger>
                                            </Triggers>
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td class="TextoResaltado" style="width:600px; text-align:right">
                                                            RESUMEN FINAL&nbsp;
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:Button ID="SugerirTotalesButton" runat="server" CausesValidation="false" OnClick="SugerirTotalesButton_Click" Text="Sugerir totales" Width="170px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Importe total neto gravado:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Total_Neto_Gravado_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Importe total de conceptos que no integren el precio neto gravado:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Total_Concepto_No_Gravado_ResumenTextBox" runat="server"
                                                                SkinID="TextoBoxFEAVendedorDet" ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Importe de operaciones exentas:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Operaciones_Exentas_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            IVA Responsable inscripto:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Impuesto_Liq_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Impuesto liquidado a RNI o percepción a no categorizados (IVA R.G.2126):
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Impuesto_Liq_Rni_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Importe total impuestos municipales:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Total_Impuestos_Municipales_ResumenTextBox" runat="server"
                                                                SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Importe total impuestos nacionales:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Total_Impuestos_Nacionales_ResumenTextBox" runat="server"
                                                                SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Importe total impuestos provinciales:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Total_Ingresos_Brutos_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Importe total impuestos internos:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Total_Impuestos_Internos_ResumenTextBox" runat="server"
                                                                SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Reintegro Decreto 1043/2016:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Total_Reintegros_ResumenTextBox" runat="server"
                                                                SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Importe total:
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Importe_Total_Factura_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                            </asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TC00S">
                                                            <asp:Label ID="Tipo_de_cambioLabel" runat="server" Text="Tipo de cambio:" Visible="true">
                                                            </asp:Label>
                                                        </td>
                                                        <td class="TC10S">
                                                            <asp:TextBox ID="Tipo_de_cambioTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                ToolTip="<Obligatorio para moneda extranjera> El separador de decimales a utilizar es el punto"
                                                                Visible="true">
                                                            </asp:TextBox>
                                                            <asp:UpdateProgress ID="tipoCambioUpdateProgress" runat="server" DisplayAfter="0">
                                                                <ProgressTemplate>
                                                                    <asp:Image ID="tipoCambioImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
                                                                    </asp:Image>
                                                                </ProgressTemplate>
                                                            </asp:UpdateProgress>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <hr noshade="noshade" size="1" color="#cccccc" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- OBSERVACIONES -->
                    <tr>
                        <td style="text-align:center">
                            <table style="width:1282px;">
                                <tr>
                                    <td style="height:10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TextoResaltado" style="text-align:center">
                                        OBSERVACIONES
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height:10px;">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TextoLabelFEADescrLarga" style="text-align:center">
                                        <asp:TextBox ID="Observaciones_ResumenTextBox" runat="server" Style="width:1260px; resize:none" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <hr noshade="noshade" size="1" color="#cccccc" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!-- ACCIONES -->
                    <tr>
                        <td style="text-align: center">
                            <asp:Panel ID="AccionesPanel" runat="server">
                                <table style="width:1282px">
                                    <tr>
                                        <td style="height: 10px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TextoResaltado" style="text-align:center">
                                            ACCIONES
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-left:10px">
                                            <asp:Panel ID="AFIPpanel" runat="server">
                                                <table style="padding-bottom:6px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            AFIP: 
                                                        </td>
                                                        <td align="left" style="padding-left:5px">
                                                            <asp:Button ID="SubirAAFIPButton" runat="server" CausesValidation="false" OnClick="AccionSubirAAFIPButton_Click" 
                                                                Text="Enviar" ToolTip="Impactar el comprobante en AFIP. Es un servicio On-Line para el cual se requiere un certificado de autenticación." />
                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender3" 
                                                                PopupControlID="PopupEnviarAFIP" TargetControlID="SubirAAFIPButton" 
                                                                BackgroundCssClass="modalBackground" runat="server" 
                                                                onload="ModalPopupExtender3_Load" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="PrevisualizacionComprobantePanel" runat="server">
                                                <table style="padding-bottom:6px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            Previsualización comprobante: 
                                                        </td>
                                                        <td align="left" style="padding-left:5px">
                                                            <asp:Button ID="ObtenerPDFButton" runat="server" CausesValidation="true" OnClick="AccionObtenerPDFButton_Click" Text="Obtener" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="ComprobantePanel" runat="server">
                                                <table>
                                                    <tr>
                                                        <td class="TC00S">
                                                            Comprobante: 
                                                        </td>
                                                        <td align="left" style="padding-left:5px">
                                                            <asp:Button ID="GuardarComprobanteButton" runat="server" CausesValidation="true" OnClick="AccionGuardarComprobanteButton_Click" Text="Guardar" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="DescargarPDFPanel" runat="server">
                                                <table style="width: 1260px">
                                                    <tr>
                                                        <td style="width: 100%;">
                                                            <asp:Button ID="DescargarPDFButton" runat="server" Text="Descargar PDF" Width="100%" ForeColor="Brown"
                                                                CausesValidation="false" UseSubmitBehavior="false" OnClientClick="this.disabled = true;"
                                                                OnClick="DescargarPDFButton_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server">
                                                <table style="padding-bottom:6px">
                                                    <tr>
                                                        <td class="TC00S">
                                                            Cancelación ingreso: 
                                                        </td>
                                                        <td align="left" style="padding-left:5px">
                                                            <asp:Button ID="CancelarButton" runat="server" CausesValidation="true" OnClick="CancelarButton_Click" Text="Cancelar" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <hr noshade="noshade" size="1" color="#cccccc" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <!-- MENSAJE -->
                    <tr>
                        <td style="width:100%; text-align:center; padding-top:10px; padding-bottom:10px">
                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                        </td>
                    </tr>
                    <!-- OTROS -->
                    <tr>
                        <td style="text-align:center; height:10px;">
                            Agradeceríamos a los usuarios del sitio que nos informen sobre dudas, posibles omisiones
                            y/o errores y que nos envíen las correcciones o sugerencias por correo electrónico
                            a través de
                            <asp:HyperLink ID="contactoHyperLink" runat="server" NavigateUrl="~/InstitucionalContacto.aspx">este formulario</asp:HyperLink>.
                            Es de suma importancia conocer su opinión. Muchas gracias.
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="text-align: center; width: 1280;">
                            <asp:ValidationSummary ID="RequeridosValidationSummary" runat="server" BorderColor="Gray"
                                BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:" 
                                ShowMessageBox="True"></asp:ValidationSummary>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="PopupEnviarAFIP" class="ModalWindow">
        <table width="100%" style="padding:20px;">
            <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="Label3" runat="server" 
                        Text="Desea enviar el comprobante de forma On-Line a la AFIP ?"
                        SkinID="TextoMediano"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-top: 20px">
                    <asp:Button ID="AceptarEnviarAFIP" runat="server" Text="Aceptar" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="this.disabled = true;ctl00$ContentPlaceDefault$CancelarEnviarAFIP.disabled = true;" OnClick="AccionSubirAAFIPButton_Click" />
                </td>
                <td align="center" style="width: 20px">
                </td>
                <td align="left" style="padding-top: 20px">
                    <asp:Button ID="CancelarEnviarAFIP" runat="server" Text="Cancelar" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="this.disabled = true;ctl00$ContentPlaceDefault$AceptarEnviarAFIP.disabled = true;" OnClick="CancelarEnviarAFIPButton_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
