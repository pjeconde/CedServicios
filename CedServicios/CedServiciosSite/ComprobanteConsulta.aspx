﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ComprobanteConsulta.aspx.cs" Inherits="CedServicios.Site.ComprobanteConsulta" Theme="CedServicios" Buffer="true"  
Culture="en-GB" UICulture="en-GB" MaintainScrollPositionOnPostback="true" Title="Consulta de Comprobante" EnableEventValidation="false" ValidateRequest="false"%>

<%@ Register Src="~/Facturacion/Electronica/DetalleConsulta.ascx" TagName="Detalle" TagPrefix="uc4" %>
<%@ Register Src="~/Facturacion/Electronica/Extensiones/Comerciales.ascx" TagName="Comerciales" TagPrefix="uc3" %>
<%@ Register Src="~/Facturacion/Electronica/PermisosConsulta.ascx" TagName="Permisos" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Facturacion/Electronica/ImpuestosConsulta.ascx" TagName="ImpuestosGlobales" TagPrefix="uc8" %>
<%@ Register Src="~/Facturacion/Electronica/DescuentosConsulta.ascx" TagName="DescuentosGlobales" TagPrefix="DescUC" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="MasterScriptManager" runat="server"></asp:ScriptManager>
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 800px; text-align:left; padding-left:10px">
                <tr>
                    <td align="center" valign="top" style="padding-top:20px; width:782px; vertical-align:middle; text-align:center;">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <tr>
                                <td align="center" valign="middle">
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
                                            <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
                                                <tr>
                                                    <td class="TextoResaltado" colspan="4" style="text-align:center; padding-top:20px">
                                                        <asp:Label ID="DatosComprobanteLabel" runat="server" Text="COMPROBANTE"></asp:Label>
                                                        <asp:TextBox ID="IdNaturalezaComprobanteTextBox" runat="server" Visible="false"> </asp:TextBox>
                                                        <asp:TextBox ID="TratamientoTextBox" runat="server" Visible="false"> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height:10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TC00S">
                                                        Tipo de comprobante:
                                                    </td>
                                                    <td class="TC10S" colspan="3">
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
                                                        <asp:Label ID="NumeroDeLabel" runat="server" Text="Número de comprobante:" Visible="true"></asp:Label>
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:TextBox ID="Numero_ComprobanteTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                            ToolTip="Debe ser correlativo al último ingresado por Punto de Venta y Tipo de Comprobante. No es necesario ingresar ceros a la izquierda. Si su factura es p.ej.0002-00000005, puede ingresar 5."> </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
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
                                                        IVA computable:
                                                    </td>
                                                    <td class="TC10S">
                                                        <asp:DropDownList ID="IVAcomputableDropDownList" runat="server" SkinID="ddlch">
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
                                                    <td class="TC00S">
                                                        Condición de pago:
                                                    </td>
                                                    <td class="TC10S" colspan="3">
                                                        <asp:TextBox ID="Condicion_De_PagoTextBox" runat="server" BorderStyle="NotSet" Style="width:563px; text-align:left">
                                                        </asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
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
                                            <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
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
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
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
                                    <asp:UpdatePanel ID="VendedorUpdatePanel" runat="server">
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
                                                <tr>
                                                    <td style="height:10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" class="TextoResaltado" style="width: 240px">
                                                        VENDEDOR
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height:10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
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
                                                                <td colspan="2">
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 5px; text-align: right;">
                                                                        <tr>
                                                                            <!--80 + 40 + 60 + 40 + 80 + 40 padding = 370px -->
                                                                            <td class="TC01S" style="padding-right:5px">
                                                                                Nro.:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Numero_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC03S" style="padding-right:5px">
                                                                                Piso:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Piso_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC01S" style="padding-right:5px">
                                                                                Depto:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Depto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 5px; text-align: right;">
                                                                        <tr>
                                                                            <!-- 80 + 40 + 60 + 40 + 80 + 40 padding = 370px -->
                                                                            <td class="TC01S" style="padding-right:5px">
                                                                                Sector:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Sector_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC03S" style="padding-right:5px">
                                                                                Torre:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Torre_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC01S" style="padding-right:5px">
                                                                                Manzana:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Manzana_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh"> </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
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
                                                                    Provincia:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:DropDownList ID="Provincia_VendedorDropDownList" runat="server" SkinID="ddln">
                                                                    </asp:DropDownList>
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
                                                                    Nombre contacto:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Contacto_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"> </asp:TextBox>
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
                                                        </table>
                                                    </td>
                                                    <td class="bgFEAC" style="width: 40px; background-repeat: repeat-y;">
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
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
                                                                    Inicio de actividades:
                                                                </td>
                                                                <td align="left" style="padding-left: 4px; padding-top: 5px;" valign="top">
                                                                    <asp:TextBox ID="InicioDeActividadesVendedorDatePickerWebUserControl" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="MyCalendar"
                                                                        OnClientShown="onCalendar1Shown" TargetControlID="InicioDeActividadesVendedorDatePickerWebUserControl"
                                                                        Format="yyyyMMdd" PopupButtonID="ImageCalendarInicioDeActividadesVendedor">
                                                                    </cc1:CalendarExtender>
                                                                    <asp:ImageButton runat="server" CausesValidation="false" ID="ImageCalendarInicioDeActividadesVendedor" ImageUrl="~/Imagenes/Calendar.gif" />
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
                                                                    IB:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="NroIBVendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="Formatos válidos: XXXXXXX-XX o XX-XXXXXXXX-X o XXX-XXXXXX-X"> </asp:TextBox>
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
                                                                    GLN:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="GLN_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres."> </asp:TextBox>
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
                                                <tr>
                                                    <td colspan="3">
                                                        <hr noshade="noshade" size="1" color="#cccccc" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                                    <tr>
                                                        <td style="height:10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="TextoResaltado" style="text-align: center;">
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
                                                                    <table border="0" cellpadding="0" cellspacing="0">
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
                                                        <td>
                                                            <asp:UpdatePanel ID="PaisDestinoExpUpdatePanel" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <table border="0" cellpadding="0" cellspacing="0">
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
                                                                    <table border="0" cellpadding="0" cellspacing="0">
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
                                                        <td>
                                                            <asp:UpdatePanel ID="IncotermsUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                UpdateMode="Conditional">
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                                </Triggers>
                                                                <ContentTemplate>
                                                                    <table border="0" cellpadding="0" cellspacing="0">
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
                                                        <td colspan="2" style="height:19px; text-align:center">
                                                            <uc2:Permisos ID="PermisosExpo" runat="server"></uc2:Permisos>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
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
                                            <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
                                                <tr>
                                                    <td style="height:10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="TextoResaltado" colspan="3" style="text-align: center">
                                                        COMPRADOR
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height:10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
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
                                                                <td colspan="2">
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 5px; text-align: right;">
                                                                        <tr>
                                                                            <td class="TC01S" style="padding-right: 5px">
                                                                                Nro.:
                                                                            </td>
                                                                            <td style="padding-right: 5px">
                                                                                <asp:TextBox ID="Domicilio_Numero_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC03S" style="padding-right: 5px">
                                                                                Piso:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Piso_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC01S" style="padding-right: 5px">
                                                                                Depto:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Depto_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="padding-top: 5px; text-align: right;">
                                                                        <tr>
                                                                            <td class="TC01S" style="padding-right: 5px">
                                                                                Sector:
                                                                            </td>
                                                                            <td style="padding-right: 5px">
                                                                                <asp:TextBox ID="Domicilio_Sector_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC03S" style="padding-right: 5px">
                                                                                Torre:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Torre_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                            <td class="TC01S" style="padding-right: 5px">
                                                                                Manzana:
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="Domicilio_Manzana_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                </asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
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
                                                                    Provincia:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:DropDownList ID="Provincia_CompradorDropDownList" runat="server" SkinID="ddln">
                                                                    </asp:DropDownList>
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
                                                                    Contraseña para aviso:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="PasswordAvisoVisualizacionTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                        ToolTip="Para poder acceder al contenido del comprobante, se solicitará al destinatario el ingreso de esta contraseña">
                                                                    </asp:TextBox>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="bgFEAC" style="width: 40px; background-repeat: repeat-y;">
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
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
                                                                    Nro. de documento:
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
                                                                    Inicio de actividades:
                                                                </td>
                                                                <td style="padding-left: 6px; padding-top: 5px;">
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
                                                            <tr>
                                                                <td class="TC00S">
                                                                    GLN:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="GLN_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
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
                                                                    Teléfono contacto:
                                                                </td>
                                                                <td class="TC10S">
                                                                    <asp:TextBox ID="Telefono_CompradorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                    </asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
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
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TextoResaltado" style="text-align: center;">
                                                    REFERENCIAS
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; padding: 3px; font-weight: normal;">
                                                    <asp:UpdatePanel ID="referenciasUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                        UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="referenciasGridView" runat="server" AutoGenerateColumns="False"
                                                                BorderColor="gray" BorderStyle="Solid" BorderWidth="1px"
                                                                EnableViewState="true" Font-Bold="false"
                                                                GridLines="Both"
                                                                ShowFooter="true" ShowHeader="True" ToolTip="El dato de referencia debe ser un número entero"
                                                                Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="C&#243;digo de referencia">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcodigo_de_referencia" runat="server" Text='<%# Eval("descripcioncodigo_de_referencia") %>'
                                                                                Width="320px"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:DropDownList ID="ddlcodigo_de_referenciaEdit" runat="server" Width="300px">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="ddlcodigo_de_referenciaEditItemRequiredFieldValidator"
                                                                                runat="server" ControlToValidate="ddlcodigo_de_referenciaEdit" ErrorMessage="Codigo de referencia en edición no informado"
                                                                                SetFocusOnError="True" ValidationGroup="ReferenciasEditItem">*</asp:RequiredFieldValidator>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList ID="ddlcodigo_de_referencia" runat="server" Width="300px">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="ddldescripcionFooterRequiredFieldValidator" runat="server"
                                                                                ControlToValidate="ddlcodigo_de_referencia" ErrorMessage="Codigo de referencia a agregar no informado"
                                                                                SetFocusOnError="True" ValidationGroup="ReferenciasFooter">*</asp:RequiredFieldValidator>
                                                                        </FooterTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="320px" />
                                                                        <FooterStyle HorizontalAlign="Left" Width="320px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Número de referencia">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtdato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'
                                                                                Width="75%"></asp:TextBox>
                                                                            <cc1:MaskedEditExtender ID="txtdato_de_referenciaEditExpoMaskedEditExtender" runat="server"
                                                                                ClearMaskOnLostFocus="false" Enabled="false" Mask="9999-99999999" MaskType="Number"
                                                                                PromptCharacter="?" TargetControlID="txtdato_de_referencia">
                                                                            </cc1:MaskedEditExtender>
                                                                            <cc1:FilteredTextBoxExtender ID="txtdato_de_referenciaEditExpoFilteredTextBoxExtender"
                                                                                runat="server" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txtdato_de_referencia">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                            <asp:RequiredFieldValidator ID="txtdato_de_referenciaEditItemRequiredFieldValidator"
                                                                                runat="server" ControlToValidate="txtdato_de_referencia" ErrorMessage="dato de referencia en edición no informado"
                                                                                SetFocusOnError="True" ValidationGroup="ReferenciasEditItem">*</asp:RequiredFieldValidator>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="txtdato_de_referencia" runat="server" Text='' Width="75%"></asp:TextBox>
                                                                            <cc1:MaskedEditExtender ID="txtdato_de_referenciaFooterExpoMaskedEditExtender" runat="server"
                                                                                ClearMaskOnLostFocus="false" Enabled="false" Mask="9999-99999999" MaskType="Number"
                                                                                PromptCharacter="?" TargetControlID="txtdato_de_referencia">
                                                                            </cc1:MaskedEditExtender>
                                                                            <cc1:FilteredTextBoxExtender ID="txtdato_de_referenciaFooterExpoFilteredTextBoxExtender"
                                                                                runat="server" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txtdato_de_referencia">
                                                                            </cc1:FilteredTextBoxExtender>
                                                                            <asp:RequiredFieldValidator ID="txtdato_de_referenciaFooterRequiredFieldValidator"
                                                                                runat="server" ControlToValidate="txtdato_de_referencia" ErrorMessage="Dato de referencia a agregar no informado"
                                                                                SetFocusOnError="True" ValidationGroup="ReferenciasFooter">*</asp:RequiredFieldValidator>
                                                                        </FooterTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle Font-Bold="true" />
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                    <asp:UpdateProgress ID="referenciasUpdateProgress" runat="server" AssociatedUpdatePanelID="referenciasUpdatePanel"
                                                        DisplayAfter="0">
                                                        <ProgressTemplate>
                                                            <asp:Image ID="referenciasImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
                                                            </asp:Image>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; padding: 3px; font-weight: normal;">
                                                    <asp:ValidationSummary ID="ReferenciasEditValidationSummary" runat="server" BorderColor="Gray"
                                                        BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
                                                        ShowMessageBox="True" ValidationGroup="ReferenciasEditItem"></asp:ValidationSummary>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; padding: 3px; font-weight: normal;">
                                                    <asp:ValidationSummary ID="ReferenciasFooterValidationSummary" runat="server" BorderColor="Gray"
                                                        BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
                                                        ShowMessageBox="True" ValidationGroup="ReferenciasFooter"></asp:ValidationSummary>
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
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
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
                                    <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
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
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                    <tr>
                                                        <td class="TextoLabelFEADescrLarga" style="padding: 5px;">
                                                            <asp:TextBox ID="ComentariosTextBox" runat="server" Style="width:760px; resize:none" TextMode="MultiLine"></asp:TextBox>
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
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
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
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
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
                                    <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
                                        <tr>
                                            <td style="height: 10px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" style="padding-left:5px; width:180px" valign="top">
                                                <asp:Panel ID="DatosEmisionPanel" runat="server">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="border-color: Gray; border-width: 1px; border-style: solid" width="180px">
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
                                                    <table border="0" cellpadding="0" cellspacing="0" style="border-color: Gray; border-width: 1px; border-style: solid" width="180px">
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
                                            <td>
                                            </td>
                                            <td align="left" valign="top">
                                                <asp:UpdatePanel ID="tipoCambioUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                    OnLoad="tipoCambioUpdatePanel_Load" UpdateMode="Conditional">
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="MonedaComprobanteDropDownList"></asp:AsyncPostBackTrigger>
                                                    </Triggers>
                                                    <ContentTemplate>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td class="TextoResaltado" style="width:390px; text-align:right">
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
                                    <table border="0" cellpadding="0" cellspacing="0" style="width:782px;">
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
                                                <asp:TextBox ID="Observaciones_ResumenTextBox" runat="server" Style="width:760px" TextMode="MultiLine"></asp:TextBox>
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
                                        <table border="0" cellpadding="0" cellspacing="0" style="width:782px">
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
                                                    <asp:Panel ID="PrevisualizacionComprobantePanel" runat="server">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="padding-bottom:6px">
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Previsualización comprobante: 
                                                                </td>
                                                                <td align="left" style="padding-left:5px">
                                                                    <asp:Button ID="PDFButton" runat="server" CausesValidation="true" OnClick="PDFButton_Click" 
                                                                        Text="Obtener" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Baja_AnulBaPanel" runat="server">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="padding-bottom:6px">
                                                            <tr>
                                                                <td class="TC00S">
                                                                    Comprobante: 
                                                                </td>
                                                                <td align="left" style="padding-left:5px">
                                                                    <asp:Button ID="Baja_AnulBajaButton" runat="server" CausesValidation="true" OnClick="Baja_AnulBajaButton_Click" Text="Baja o AnulBaja" />
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
                                <td align="left" style="text-align: center; width: 780px;">
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
    </form>
</body>
</html>