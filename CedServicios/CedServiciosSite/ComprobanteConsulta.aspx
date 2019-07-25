<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComprobanteConsulta.aspx.cs" Inherits="CedServicios.Site.ComprobanteConsulta" Theme="CedServicios" Buffer="true"  
Culture="en-GB" UICulture="en-GB" MaintainScrollPositionOnPostback="true" Title="Consulta de Comprobante" EnableEventValidation="false" ValidateRequest="false"%>

<%@ Register Src="~/Facturacion/Electronica/DetalleConsulta.ascx" TagName="Detalle" TagPrefix="uc4" %>
<%@ Register Src="~/Facturacion/Electronica/Extensiones/Comerciales.ascx" TagName="Comerciales" TagPrefix="uc3" %>
<%@ Register Src="~/Facturacion/Electronica/PermisosConsulta.ascx" TagName="Permisos" TagPrefix="uc2" %>
<%@ Register Src="~/Facturacion/Electronica/ReferenciasConsulta.ascx" TagName="Referencias" TagPrefix="uc9" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Facturacion/Electronica/ImpuestosConsulta.ascx" TagName="ImpuestosGlobales" TagPrefix="uc8" %>
<%@ Register Src="~/Facturacion/Electronica/DescuentosConsulta.ascx" TagName="DescuentosGlobales" TagPrefix="DescUC" %>
<%@ Register Src="~/Controles/DatosEmailAvisoComprobanteContratoConsulta.ascx" TagName="DatosEmailAvisoComprobanteContratoConsulta" TagPrefix="uc5" %>
<%@ Register Src="~/Facturacion/Electronica/EsquemaContableConsulta.ascx" TagName="EsquemaContable" TagPrefix="uc10" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManagerConsulta" runat="server">
        </asp:ScriptManager>
        <div class="container">
        <div class="row">
        <div class="col-lg-12 col-md-12">
            <table style="width: 1300px; text-align:left; padding-left:10px" align="center">
                <tr>
                    <td style="padding-top:20px; width:1282px; vertical-align:top; text-align:center;">
                        <table>
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <tr>
                                <td>
                                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobante"></asp:Label>
                                </td>
                            </tr>
                            <!-- COMPROBANTE -->
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="InfoComproUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                        UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Version1RadioButton" EventName="CheckedChanged">
                                            </asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList" EventName="TextChanged">
                                            </asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="Tipo_De_ComprobanteDropDownList" EventName="SelectedIndexChanged"/>
                                        </Triggers>
                                        <ContentTemplate>
                                            <table style="width:1282px">
                                                <tr>
                                                    <td class="TextoResaltado" colspan="6" style="text-align:center; padding-top:20px">
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
                                                                <asp:DropDownList ID="PuntoVtaDropDownList" runat="server" AutoPostBack="True" Enabled="false" SkinID="ddln" 
                                                                onselectedindexchanged="PuntoVtaDropDownList_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="PuntoVtaTextBox" runat="server" Enabled="true" Visible="false" SkinID="TextoBoxFEAVendedorDetChCh"></asp:TextBox>
                                                                <asp:Label ID="TipoPtoVentaLabel" runat="server" Visible="false"></asp:Label>
                                                                <asp:RadioButton ID="Version1RadioButton" runat="server" GroupName="Version" Text="V.1"
                                                                    AutoPostBack="true" Visible="false" OnCheckedChanged="Version1RadioButton_CheckedChanged" Checked="True">
                                                                </asp:RadioButton>
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
                                                                style="width:400px">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td class="TC00S">
                                                        <asp:Label ID="NumeroDeLabel" runat="server" Text="Número de comprobante:" Visible="true"></asp:Label>
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="Numero_ComprobanteTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                            ToolTip="Debe ser correlativo al último ingresado por Punto de Venta y Tipo de Comprobante. No es necesario ingresar ceros a la izquierda. Si su factura es p.ej.0002-00000005, puede ingresar 5."> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        IVA computable:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:DropDownList ID="IVAcomputableDropDownList" runat="server" SkinID="ddlch">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="TC00S">
                                                        Moneda:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:UpdatePanel ID="monedaUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                            UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="MonedaComprobanteDropDownList" runat="server" AutoPostBack="True"
                                                                    Enabled="false" OnSelectedIndexChanged="MonedaComprobanteDropDownList_SelectedIndexChanged"
                                                                    SkinID="ddln">
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
                                                        <asp:TextBox ID="FechaEmisionDatePickerWebUserControl" runat="server" CausesValidation="true" SkinID="FechaFact"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="MyCalendar" BehaviorID="a2"
                                                            TargetControlID="FechaEmisionDatePickerWebUserControl"  
                                                            Format="yyyyMMdd" PopupButtonID="ImageCalendarFechaEmision">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarFechaEmision" ImageUrl="~/Imagenes/Calendar.gif" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        <asp:Label ID="CodigoOperacionLabel" runat="server" Text="Código de operación:" 
                                                            Visible="true"></asp:Label>
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:DropDownList ID="CodigoOperacionDropDownList" runat="server" SkinID="ddln">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="TC00S">
                                                        Fecha de vencimiento:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="FechaVencimientoDatePickerWebUserControl" runat="server" 
                                                            SkinID="FechaFact"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" 
                                                            CssClass="MyCalendar" Format="yyyyMMdd" 
                                                            PopupButtonID="ImageCalendarFechaVencimiento" 
                                                            TargetControlID="FechaVencimientoDatePickerWebUserControl">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton ID="ImageCalendarFechaVencimiento" runat="server" 
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
                                                    <td class="TC00S">
                                                        <asp:Label ID="CodigoConceptoLabel" runat="server" Text="Código de concepto:" 
                                                            Visible="false"></asp:Label>
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:DropDownList ID="CodigoConceptoDropDownList" runat="server" SkinID="ddln" 
                                                            Visible="false">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="TC00S">
                                                        <asp:Label ID="FechaInicioServLabel" runat="server" 
                                                            Text="Fecha del servicio: inicio"></asp:Label>
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="FechaServDesdeDatePickerWebUserControl" runat="server" 
                                                            SkinID="FechaFact"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" 
                                                            CssClass="MyCalendar" Format="yyyyMMdd" 
                                                            PopupButtonID="ImageCalendarFechaServDesde" 
                                                            TargetControlID="FechaServDesdeDatePickerWebUserControl">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton ID="ImageCalendarFechaServDesde" runat="server" 
                                                            CausesValidation="false" ImageUrl="~/Imagenes/Calendar.gif" />
                                                    </td>
                                                    <td class="TC00S">
                                                        <asp:Label ID="FechaHstServLabel" runat="server" Text="finaliz.">
                                                        </asp:Label>
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="FechaServHastaDatePickerWebUserControl" runat="server" 
                                                            SkinID="FechaFact"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" 
                                                            CssClass="MyCalendar" Format="yyyyMMdd" 
                                                            PopupButtonID="ImageCalendarFechaServHasta" 
                                                            TargetControlID="FechaServHastaDatePickerWebUserControl">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton ID="ImageCalendarFechaServHasta" runat="server" 
                                                            CausesValidation="false" ImageUrl="~/Imagenes/Calendar.gif" />
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
                            <!-- LOTE -->
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="LoteUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Version1RadioButton" EventName="CheckedChanged">
                                            </asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList" EventName="TextChanged">
                                            </asp:AsyncPostBackTrigger>
                                        </Triggers>
                                        <ContentTemplate>
                                            <table style="border:0; width:1282px">
                                                <tr>
                                                    <td style="text-align: center; height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TextoResaltado" style="text-align: center;">
                                                        LOTE
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center; height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
                                                        <table style="width: 1280px">
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Nº lote:
                                                                </td>
                                                                <td class="TC00S">
                                                                    <asp:TextBox ID="Id_LoteTextbox" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="Este número, que no necesariamente tiene que ser correlativo y consecutivo, siempre debe ser mayor al último número de lote procesado en Interfacturas. Este número NO SE PUEDE REPETIR.">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td class="TC00S">
                                                                    <asp:Label ID="Presta_ServLabel" Text="Presta servicios:" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="TC02S" style="text-align: left;">
                                                                    <asp:CheckBox ID="Presta_ServCheckBox" runat="server"></asp:CheckBox>
                                                                </td>
                                                                <td class="TC00S">
                                                                    <asp:Label ID="LabelTipoNumeracionLote" Text="Tipo de numeración:" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="TC00S">
                                                                    <asp:TextBox ID="TipoNumeracionLote" runat="server" SkinID="TextoBoxFEAVendedorDet" ReadOnly="true" ToolTip="El tipo de númeración del lote se define a nivel de Punto de Venta. Solamente para el tipo 'Ninguno' estará habilitado el ingreso manual del Número de Lote.">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td style="width:5px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
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
                                <asp:Panel ID="pHeader" runat="server" CssClass="TextoResaltado">
                                    <asp:Label ID="lblText" runat="server" Text="VENDEDOR" />
                                    <asp:Image ID="imageCE" runat="server" ImageUrl="~/Imagenes/Iconos/icon_expand.gif" style="vertical-align:text-bottom" />
                                </asp:Panel>
                                <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                                <table style="width:1282px">
                                    <tr>
                                        <td style="text-align:right; vertical-align:top">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 400px">
                                                <tr>
                                                    <td class="TC00S">
                                                        Razón Social:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="Razon_Social_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Calle:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="Domicilio_Calle_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Sector:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="Domicilio_Sector_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Provincia:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:DropDownList ID="Provincia_VendedorDropDownList" runat="server" SkinID="ddln">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Condición IB:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:DropDownList ID="Condicion_Ingresos_Brutos_VendedorDropDownList" runat="server"
                                                            SkinID="ddln">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Nombre contacto:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="Contacto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        GLN:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="GLN_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                            ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres."> </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="bgFEAC" style="width: 30px; background-repeat: repeat-y;">
                                        </td>
                                        <td style="text-align:left; vertical-align:top">
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 400px">
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
                                                        <asp:TextBox ID="Domicilio_Numero_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Torre:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="Domicilio_Torre_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Localidad:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="Localidad_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        IB:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="NroIBVendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                            ToolTip="Formatos válidos: XXXXXXX-XX o XX-XXXXXXXX-X o XXX-XXXXXX-X"> </asp:TextBox>
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
                                                        <asp:TextBox ID="Codigo_Interno_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                            ToolTip="<Opcional> Código utilizado para identificar al vendedor dentro de una empresa/organización. (Ej. Código de Cliente, Proveedor, etc.)"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="bgFEAC" style="width: 30px; background-repeat: repeat-y;">
                                        </td>
                                        <td align="left" style="vertical-align: top">
                                            <table style="width: 400px">
                                                <tr>
                                                    <td class="TC00S">
                                                        Inicio de actividades:
                                                    </td>
                                                    <td align="left" style="padding-left: 4px; padding-top: 5px;" valign="top">
                                                        <asp:TextBox ID="InicioDeActividadesVendedorDatePickerWebUserControl" runat="server"
                                                            SkinID="FechaFact"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                                            OnClientShown="onCalendar1Shown" TargetControlID="InicioDeActividadesVendedorDatePickerWebUserControl"
                                                            Format="yyyyMMdd" PopupButtonID="ImageCalendarInicioDeActividadesVendedor">
                                                        </cc1:CalendarExtender>
                                                        <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarInicioDeActividadesVendedor"
                                                            ImageUrl="~/Imagenes/Calendar.gif" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Piso:
                                                    </td>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="TC02SL">
                                                                    <asp:TextBox ID="Domicilio_Piso_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                </td>
                                                                <td class="TC02S">
                                                                    Depto:
                                                                </td>
                                                                <td class="TC02SL">
                                                                    <asp:TextBox ID="Domicilio_Depto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
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
                                                        <asp:TextBox ID="Domicilio_Manzana_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
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
                                                        <asp:DropDownList ID="Condicion_IVA_VendedorDropDownList" runat="server" SkinID="ddln">
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
                            </tr>
                            <tr>
                                <td style="">
                                    <hr noshade="noshade" size="1" color="#cccccc" />
                                </td>
                            </tr>
                            <!-- INFORMACIÓN EXPORTACIÓN-->
                            <tr>
                                <td style="text-align: center">
                                    <asp:UpdatePanel ID="ExportacionUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                        </Triggers>
                                        <ContentTemplate>
                                            <asp:Panel ID="ExportacionPanel" runat="server">
                                                <table style="width: 1282px">
                                                    <tr>
                                                        <td style="height:10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" class="TextoResaltado" style="text-align: center;">
                                                            INFORMACIÓN EXPORTACIÓN
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height:10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="TipoExpoUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                UpdateMode="Conditional">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <table style="border:0">
                                                                        <tr>
                                                                            <td class="TC00S">
                                                                                Tipo Exportación:
                                                                            </td>
                                                                            <td class="TC10S">
                                                                                <asp:DropDownList ID="TipoExpDropDownList" runat="server" SkinID="ddln">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 360px">
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="PaisDestinoExpUpdatePanel" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <table style="border:0;">
                                                                        <tr>
                                                                            <td class="TC00S">
                                                                                País Destino Comprobante:
                                                                            </td>
                                                                            <td class="TC10S">
                                                                                <asp:DropDownList ID="PaisDestinoExpDropDownList" runat="server" OnSelectedIndexChanged="PaisDestinoExpDropDownList_SelectedIndexChanged"
                                                                                    SkinID="ddln" AutoPostBack="true">
                                                                                </asp:DropDownList>
                                                                                <asp:UpdateProgress ID="PaisDestinoUpdateProgress" runat="server" AssociatedUpdatePanelID="PaisDestinoExpUpdatePanel"
                                                                                    DisplayAfter="0">
                                                                                    <ProgressTemplate>
                                                                                        <asp:Image ID="PaisDestinoImage" runat="server" Height="18px" ImageUrl="~/Imagenes/301.gif">
                                                                                        </asp:Image>
                                                                                    </ProgressTemplate>
                                                                                </asp:UpdateProgress>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:UpdatePanel ID="IdiomaUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                UpdateMode="Conditional">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <table style="boder:0;">
                                                                        <tr>
                                                                            <td class="TC00S">
                                                                                Idioma para exportación:
                                                                            </td>
                                                                            <td class="TC10S">
                                                                                <asp:DropDownList ID="IdiomaDropDownList" runat="server" SkinID="ddln">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width: 360px">
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="IncotermsUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                UpdateMode="Conditional">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <table style="boder:0;">
                                                                        <tr>
                                                                            <td class="TC00S">
                                                                                Incoterms para exportación:
                                                                            </td>
                                                                            <td class="TC10S">
                                                                                <asp:DropDownList ID="IncotermsDropDownList" runat="server" SkinID="ddln">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                    </tr>
                                                    <!-- PERMISOS EXPO-->
                                                    <tr>
                                                        <td colspan="3" style="height:19px; text-align:center">
                                                            <uc2:Permisos ID="PermisosExpo" runat="server"></uc2:Permisos>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <hr noshade="noshade" size="1" color="#cccccc" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <!-- COMPRADOR -->
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="compradorUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                        UpdateMode="Conditional">
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                            <asp:AsyncPostBackTrigger ControlID="PaisDestinoExpDropDownList"></asp:AsyncPostBackTrigger>
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
                                                    <td align="right" valign="top">
                                                        <table style="width: 400px">
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Denominación:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Denominacion_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="Razón Social y Nombre del comprador">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Calle:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Domicilio_Calle_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Sector:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Domicilio_Sector_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                    </asp:TextBox>
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
                                                                    <asp:TextBox ID="Contacto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    e-mail para aviso:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="EmailAvisoVisualizacionTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="A esta dirección se enviará un email de aviso para que el destinatario pueda visualizar el comprobante">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    GLN:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="GLN_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="bgFEAC" style="width: 30px; background-repeat: repeat-y;">
                                                    </td>
                                                    <td style="text-align:left; vertical-align: top">
                                                        <table style="width: 400px">
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Tipo de documento:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:DropDownList ID="Codigo_Doc_Identificatorio_CompradorDropDownList" runat="server" SkinID="ddln">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Nro.:
                                                                </td>
                                                                <td class="TC10S" style="padding-right: 5px">
                                                                    <asp:TextBox ID="Domicilio_Numero_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Torre:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Domicilio_Torre_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Localidad:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Localidad_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    e-mail Contacto:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Email_CompradorTextBox" runat="server" AutoCompleteType="Email"
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
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Código interno:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Codigo_Interno_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="<Opcional> Código utilizado para identificar al comprador dentro de una empresa/organización. (Ej. Código de Cliente, Proveedor, etc.)">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="bgFEAC" style="width: 30px; background-repeat: repeat-y;">
                                                    </td>
                                                    <td>
                                                        <table style="width: 400px">
                                                             <tr>
                                                                <td class="TC00S">
                                                                    Nro.de documento:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Nro_Doc_Identificatorio_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
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
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 5px; text-align: right;">
                                                                        <tr>
                                                                            <td class="TC02SL">
                                                                                <asp:TextBox ID="Domicilio_Piso_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC03S" style="padding-right: 5px">
                                                                                Depto:
                                                                            </td>
                                                                            <td class="TC02SL">
                                                                                <asp:TextBox ID="Domicilio_Depto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="padding-right: 5px">
                                                                    Manzana:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Domicilio_Manzana_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Código Postal:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Cp_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Teléfono contacto:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Telefono_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Inicio de actividades:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="InicioDeActividadesCompradorDatePickerWebUserControl" runat="server" SkinID="FechaFact"></asp:TextBox>
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
                                        <table style="width: 1282px">
                                            <tr>
                                                <td style="height: 19px; text-align: center">
                                                    <uc9:Referencias ID="InfoReferencias" runat="server">
                                                    </uc9:Referencias>
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
                            <!-- DATOS COMERCIALES -->
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
                                    <table style="width:1282px; border:0;">
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
                                            <td style="text-align: center">
                                                <table style="width: 1280px">
                                                    <tr>
                                                        <td class="TextoLabelFEADescrLarga" style="padding: 5px;">
                                                            <asp:TextBox ID="ComentariosTextBox" runat="server" Style="width:1260px; resize:none" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <uc4:Detalle ID="DetalleLinea" runat="server"></uc4:Detalle>
                                                </table>
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
                            <!-- DESCUENTOS GLOBALES -->
                            <tr>
                                <td style="text-align:center">
                                    <table style="width: 1282px">
                                        <tr>
                                            <td>
                                                <DescUC:DescuentosGlobales ID="DescuentosGlobales" runat="server"></DescUC:DescuentosGlobales>
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
                            <!-- IMPUESTOS GLOBALES -->
                            <tr>
                                <td style="text-align:center">
                                    <table style="width: 1282px">
                                        <tr>
                                            <td>
                                                <uc8:ImpuestosGlobales ID="ImpuestosGlobales" runat="server"></uc8:ImpuestosGlobales>
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
                                    <table style="width:1282px">
                                        <tr>
                                            <td style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:180px; vertical-align:top; text-align:center">
                                                <asp:Panel ID="DatosEmisionPanel" runat="server">
                                                    <table style="border-color: Gray; border-width: 1px; border-style: solid" width="170px">
                                                        <tr>
                                                            <td style="height:10px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TextoResaltado" style="text-align:center">
                                                                <asp:Label ID="Label1" runat="server" Text="DATOS DE EMISIÓN"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height:10px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC00SL" style="padding-left:5px">
                                                                Periodicidad:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC10S" style="padding-right:3px">
                                                                <asp:DropDownList ID="PeriodicidadEmisionDropDownList" runat="server" AutoPostBack="True" SkinID="ddln"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC00SL" style="padding-left:5px">
                                                                Destino del comprobante:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC10S" style="padding-right:3px">
                                                                <asp:DropDownList ID="IdDestinoComprobanteDropDownList" runat="server" AutoPostBack="false" SkinID="ddln"></asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC00SL" style="padding-left:5px">
                                                                Próxima fecha de emisión:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC10S">
                                                                <asp:TextBox ID="FechaProximaEmisionDatePickerWebUserControl" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="FechaProximaEmisionDatePickerWebUserControl"
                                                                    Format="yyyyMMdd" CssClass="MyCalendar" PopupButtonID="ImageCalendarFechaProximaEmision">
                                                                </cc1:CalendarExtender>
                                                                <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarFechaProximaEmision" ImageUrl="~/Imagenes/Calendar.gif" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC00SL" style="padding-left:5px">
                                                                Cant.máx.de comprobantes a emitir:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC10S">
                                                                <asp:TextBox ID="CantidadComprobantesAEmitirTextBox" runat="server" Text="0" MaxLength="3" ToolTip="Debe ingresar sólo números." Width="70px" ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC00SL" style="padding-left:5px">
                                                                Cant.de comprobantes ya emitidos:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC10S">
                                                                <asp:TextBox ID="CantidadComprobantesEmitidosTextBox" runat="server" Text="0" MaxLength="3" ToolTip="Debe ingresar sólo números." Width="70px" ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC00SL" style="padding-left:5px">
                                                                Cant.días p/cálculo de fecha vto.:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC10S">
                                                                <asp:TextBox ID="CantidadDiasFechaVtoTextBox" runat="server" Text="0" MaxLength="3" ToolTip="Debe ingresar sólo números." Width="70px" ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height:10px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                                <asp:Panel ID="CAEPanel" runat="server">
                                                    <table style="border-color: Gray; border-width: 1px; border-style: solid; width:180px">
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
                                                            <td class="TC00SL" style="padding-left:5px">
                                                                Resultado:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC01S" style="padding: 5px; text-align: left; width: 180px">
                                                                <asp:TextBox ID="ResultadoTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" Width="100px"> </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC00SL" style="padding-left:5px">
                                                                Motivo:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC01S" style="padding: 5px; text-align: left; width: 180px">
                                                                <asp:TextBox ID="MotivoTextBox" runat="server" Width="170px" TextMode="MultiLine" Style="resize: none;" Height="50px"> </asp:TextBox>
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
                                            <td style="text-align: left; vertical-align:top">
                                                <asp:UpdatePanel ID="tipoCambioUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                    OnLoad="tipoCambioUpdatePanel_Load" UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="MonedaComprobanteDropDownList"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <table style="border: 0">
                                                            <tr>
                                                                <td class="TextoResaltado" style="width:600px; text-align:right">
                                                                    RESUMEN FINAL&nbsp;
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:Button ID="TotalesButton" runat="server" CausesValidation="false" Text="Totales" Width="174px"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Importe total neto gravado:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Importe_Total_Neto_Gravado_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Importe total de conceptos que no integren el precio neto gravado:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Importe_Total_Concepto_No_Gravado_ResumenTextBox" runat="server"
                                                                        SkinID="TextoBoxFEAVendedorDet" ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Importe de operaciones exentas:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Importe_Operaciones_Exentas_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    IVA Responsable inscripto:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Impuesto_Liq_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Impuesto liquidado a RNI o percepción a no categorizados<br />
                                                                    (IVA R.G. 2126):
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Impuesto_Liq_Rni_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Importe total impuestos municipales:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Importe_Total_Impuestos_Municipales_ResumenTextBox" runat="server"
                                                                        SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Importe total impuestos nacionales:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Importe_Total_Impuestos_Nacionales_ResumenTextBox" runat="server"
                                                                        SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Importe total ingresos brutos:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Importe_Total_Ingresos_Brutos_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Importe total impuestos internos:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Importe_Total_Impuestos_Internos_ResumenTextBox" runat="server"
                                                                        SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
                                                                    Importe total:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Importe_Total_Factura_ResumenTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="TC00S" style="width: 390px">
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
                            <!-- DATOS EMAIL AVISO COMPROBANTE CONTRATO -->
                            <tr>
                                <td style="text-align:center">
                                    <asp:Panel ID="DatosEmailAvisoComprobanteContratoConsultaPanel" runat="server">
                                        <table style="width:1282px">
                                            <tr>
                                                <td>
                                                    <uc5:DatosEmailAvisoComprobanteContratoConsulta ID="DatosEmailAvisoComprobanteContratoConsulta1" runat="server"></uc5:DatosEmailAvisoComprobanteContratoConsulta>
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
                            <!-- ESQUEMA CONTABLE -->
                            <tr>
                                <td style="text-align:center">
                                    <table style="width: 1282px">
                                        <tr>
                                            <td>
                                                <uc10:EsquemaContable ID="EsquemaContable" runat="server"></uc10:EsquemaContable>
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
                                                    <asp:Panel ID="Baja_AnulBaPanel" runat="server" Visible="false">
                                                        <table style="padding-bottom:6px">
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Comprobante: 
                                                                </td>
                                                                <td align="left" style="padding-left:5px">
                                                                    <asp:Button ID="Baja_AnulBajaButton" runat="server" CausesValidation="true" OnClick="AccionBaja_AnulBajaButton_Click" Text="Baja o AnulBaja" />
                                                                </td>
                                                                <td align="left" style="padding-left:5px">
                                                                    <asp:Button ID="Baja_FisicaButton" runat="server" CausesValidation="true" OnClick="AccionBaja_FisicaButton_Click" Text="Baja Fisica" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="AFIPpanel" runat="server" Visible="false">
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
                                                    <asp:Panel ID="InterfacturasOnLinePanel" runat="server" Visible="false">
                                                        <table style="padding-bottom:6px">
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Interfacturas (on line): 
                                                                </td>
                                                                <td style="padding-left:5px; text-align:left">
                                                                    <asp:Button ID="ValidarEnInterfacturasButton" runat="server" CausesValidation="false" OnClick="AccionValidarEnInterfacturasButton_Click" 
                                                                        Text="Validar" ToolTip="Validar el comprobante en Interfacturas. Es un servicio On-Line para el cual se requiere un certificado de autenticación." />
                                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender2" 
                                                                        PopupControlID="PopupValidarITF" TargetControlID="ValidarEnInterfacturasButton" 
                                                                        BackgroundCssClass="modalBackground" runat="server" 
                                                                        onload="ModalPopupExtender1_Load" />
                                                                    <asp:Button ID="SubirAInterfacturasButton" runat="server" CausesValidation="false" OnClick="AccionSubirAInterfacturasButton_Click" 
                                                                        Text="Enviar" ToolTip="Impactar el comprobante en Interfacturas. Es un servicio On-Line para el cual se requiere un certificado de autenticación." />
                                                                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" 
                                                                        PopupControlID="PopupEnvioITF" TargetControlID="SubirAInterfacturasButton" 
                                                                        BackgroundCssClass="modalBackground" runat="server" 
                                                                        onload="ModalPopupExtender1_Load" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="DescargarPDFPanel" runat="server" Visible="false">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 760px">
                                                            <tr>
                                                                <td style="width: 100%;">
                                                                    <asp:Button ID="DescargarPDFButton" runat="server" Text="Descargar PDF" Width="100%" ForeColor="Brown"
                                                                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="this.disabled = true;"
                                                                        OnClick="AccionDescargarPDFButton_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="ActualizarEstadoPanel" runat="server" Visible="false">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 760px">
                                                            <tr>
                                                                <td style="width: 100%;">
                                                                    <asp:Button ID="ActualizarEstadoButton" runat="server" Text="Actualizar Estado" Width="100%" ForeColor="Brown"
                                                                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="this.disabled = true;"
                                                                        OnClick="AccionActualizarEstadoButton_Click" />
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
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <hr noshade="noshade" size="1" color="#cccccc" />
                                </td>
                            </tr>
                            <!-- OTROS -->
                            <tr>
                                <td style="text-align: center; width: 1280px; text-align:left">
                                    <asp:ValidationSummary ID="RequeridosValidationSummary" runat="server" BorderColor="Gray"
                                        BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:" 
                                        ShowMessageBox="True"></asp:ValidationSummary>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        </div>
        </div>
    </form>
</body>
</html>