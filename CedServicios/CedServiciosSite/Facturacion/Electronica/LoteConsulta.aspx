<%@ Page AutoEventWireup="true" Theme="CedServicios" Buffer="true" CodeBehind="LoteConsulta.aspx.cs" 
Culture="en-GB" Inherits="CedServicios.Site.Facturacion.Electronica.LoteConsulta" Language="C#"  
MaintainScrollPositionOnPostback="true" MasterPageFile="~/CedServicios.Master" Title="Consulta de Factura Electrónica (Interfacturas - AFIP)" 
UICulture="en-GB" EnableEventValidation="false" ValidateRequest="false"%>

<%@ Register Src="~/Facturacion/Electronica/DetalleConsulta.ascx" TagName="DetalleConsulta" TagPrefix="uc9" %>
<%@ Register Src="Extensiones/Comerciales.ascx" TagName="Comerciales" TagPrefix="uc3" %>
<%@ Register Src="~/Facturacion/Electronica/PermisosConsulta.ascx" TagName="PermisosConsulta" TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Facturacion/Electronica/ImpuestosConsulta.ascx" TagName="ImpuestosGlobales" TagPrefix="uc8" %>
<%@ Register Src="~/Facturacion/Electronica/DescuentosConsulta.ascx" TagName="DescuentosGlobales" TagPrefix="DescUC" %>
<asp:Content ID="XMLContent" runat="Server" ContentPlaceHolderID="ContentPlaceDefault">
    <table border="0" cellpadding="0" cellspacing="0" class="TextComunSinPosicion" style="width: 800px;
        text-align: left;">
        <tr>
            <td style="height: 10px;" valign="top">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 800px;">
                    <tr>
                        <td style="width: 9px;">
                        </td>
                        <td colspan="3" valign="top">
                            <!-- @@@ TITULO DE LA PAGINA @@@-->
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td valign="middle">
                                                    <asp:Image ID="Image1" runat="server" AlternateText="+" ImageUrl="~/Imagenes/CajaBrownPeru.ico">
                                                    </asp:Image>
                                                </td>
                                                <td valign="middle">
                                                    <asp:Label ID="Label2" runat="server" SkinID="TituloPagina" 
                                                        Text="Consulta de Factura Electrónica"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 782px; vertical-align: middle; text-align: center;"
                                        valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TextoResaltado" style="text-align: center;">
                                                    LEER UN COMPROBANTE</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                        <tr>
                                                            <td style="padding-top: 5px">
                                                                <asp:FileUpload ID="XMLFileUpload" runat="server" Height="25px" ToolTip="Cargar los datos de un archivo XML.">
                                                                </asp:FileUpload>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding-top: 5px">
                                                                <asp:Button ID="FileUploadButton" runat="server" BackColor="peachpuff" BorderColor="brown"
                                                                    BorderStyle="Solid" BorderWidth="1px" CausesValidation="false" Font-Bold="true"
                                                                    ForeColor="brown" Height="25px" OnClick="FileUploadButton_Click" 
                                                                    Text="Completar datos automáticamente desde archivo xml seleccionado" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 9px;">
                        </td>
                        <td align="center" style="width: 782px; vertical-align: middle; text-align: center;"
                            valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                            <tr>
                                                <td rowspan="3" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="3" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="width: 370px">
                                                            </td>
                                                            <td class="bgFEAC" style="width: 40px; height: 10px;">
                                                            </td>
                                                            <td style="width: 370px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <!-- TIPO DE COMPROBANTE -->
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                        <tr>
                                                            <td align="center" class="TextoResaltado" style="width: 240px">
                                                                INFORMACIÓN VENDEDOR<br />
                                                            </td>
                                                            <td style="width: 300px">
                                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 300px">
                                                                    <tr>
                                                                        <td rowspan="2" style="width: 1px; background-color: Gray;">
                                                                        </td>
                                                                        <td colspan="3" style="height: 1px; background-color: Gray;">
                                                                        </td>
                                                                        <td rowspan="2" style="width: 1px; background-color: Gray;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 9px;">
                                                                        </td>
                                                                        <td style="width: 280px">
                                                                            <table border="0" cellpadding="0" cellspacing="0" style="background-color: White;">
                                                                                <tr>
                                                                                    <td class="TC00S" style="text-align: center; width: 280px">
                                                                                        Tipo de comprobante
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 280px">
                                                                                        <asp:UpdatePanel ID="Tipo_De_ComprobanteUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                                            UpdateMode="Conditional">
                                                                                            <Triggers>
                                                                                                <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                                                            </Triggers>
                                                                                            <ContentTemplate>
                                                                                                <asp:DropDownList ID="Tipo_De_ComprobanteDropDownList" Enabled="false" runat="server" SkinID="DropDownListCompradorGr" OnSelectedIndexChanged="Tipo_De_ComprobanteDropDownList_SelectedIndexChanged" AutoPostBack="true">
                                                                                                </asp:DropDownList>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 5px">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 9px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5" style="height: 1px; background-color: Gray;">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="center" style="width: 240px; color: #A52A2A" valign="middle">
                                                                Comprobante electrónico en
                                                                <asp:UpdatePanel ID="monedaUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                                                    UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="MonedaComprobanteDropDownList" Enabled="false" runat="server" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="MonedaComprobanteDropDownList_SelectedIndexChanged"
                                                                            SkinID="ddlgrc">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <asp:Label ID="MonedaComprobanteExclusivoPremiumLabel" runat="server" Font-Size="X-Small"
                                                                    ForeColor="Brown"></asp:Label>
                                                                <asp:UpdateProgress ID="monedaUpdateProgress" runat="server" AssociatedUpdatePanelID="monedaUpdatePanel"
                                                                    DisplayAfter="0">
                                                                    <ProgressTemplate>
                                                                        <asp:Image ID="monedaImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
                                                                        </asp:Image>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <!-- DATOS DEL VENDEDOR -->
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                        <tr>
                                                            <td style="width: 370px;">
                                                            </td>
                                                            <td class="bgFEAC" rowspan="15" style="width: 40px; background-repeat: repeat-y;">
                                                            </td>
                                                            <td style="width: 370px;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3" style="height: 10px;">
                                                            </td>
                                                            <td colspan="3">
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Razon Social / Comprobante -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Razon_Social_VendedorTextBox"
                                                                                ErrorMessage="razón social" SetFocusOnError="True">* </asp:RequiredFieldValidator>Razón
                                                                            social:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Razon_Social_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="ptoVentaUpdatePanel" runat="server" UpdateMode="Conditional"
                                                                    ChildrenAsTriggers="true">
                                                                    <ContentTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td class="TC00S">
                                                                                    Punto de venta:
                                                                                </td>
                                                                                <td style="padding-left:5px">
                                                                                    <asp:DropDownList ID="PuntoVtaDropDownList" Enabled="false" runat="server" AutoPostBack="True" SkinID="ddlch" 
                                                                                    onselectedindexchanged="PuntoVtaDropDownList_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td class="TC50B">
                                                                                    <asp:Label ID="TipoPtoVentaLabel" runat="server"></asp:Label>
                                                                                    <asp:RadioButton ID="Version1RadioButton" runat="server" GroupName="Version" Text="V.1"
                                                                                        AutoPostBack="true" Visible="false" OnCheckedChanged="Version1RadioButton_CheckedChanged" Checked="True">
                                                                                    </asp:RadioButton>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:UpdateProgress ID="ptoVentaUpdateProgress" runat="server" AssociatedUpdatePanelID="ptoVentaUpdatePanel" DisplayAfter="0">
                                                                                        <ProgressTemplate>
                                                                                            <asp:Image ID="ptoVentaImage" runat="server" Height="18px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
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
                                                        <!-- Datos del Vendedor: Calle -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Calle:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Domicilio_Calle_VendedorTextBox" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            <asp:RegularExpressionValidator ID="Numero_comprobanteRegularExpressionValidator"
                                                                                runat="server" ControlToValidate="Numero_ComprobanteTextBox" ErrorMessage="error de formateo en número de comprobante"
                                                                                SetFocusOnError="True" ValidationExpression="[0-9]+">* </asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="Numero_ComprobanteRequiredFieldValidator" runat="server"
                                                                                ControlToValidate="Numero_ComprobanteTextBox" ErrorMessage="número de comprobante"
                                                                                SetFocusOnError="True">* </asp:RequiredFieldValidator>Número de comprobante:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Numero_ComprobanteTextBox" Enabled="false" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                                ToolTip="Debe ser correlativo al último ingresado por Punto de Venta y Tipo de Comprobante. No es necesario ingresar ceros a la izquierda. Si su factura es p.ej.0002-00000005, puede ingresar 5.">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Nro.Calle, Piso y Dpto  / Fecha Emision -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <!--80 + 40 + 60 + 40 + 80 + 40 padding = 370px -->
                                                                        <td class="TC01S" style="padding-right:5px">
                                                                            Nro.:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Domicilio_Numero_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="TC03S" style="padding-right:5px">
                                                                            Piso:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Domicilio_Piso_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="TC01S" style="padding-right:5px">
                                                                            Depto:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Domicilio_Depto_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <div>
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td class="TC00S">
                                                                                Fecha de emisión:
                                                                            </td>
                                                                            <td style="padding-left: 4px; padding-top: 5px;">
                                                                                <asp:TextBox ID="FechaEmisionDatePickerWebUserControl" ReadOnly="true" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                                <asp:Image runat="server" ID="ImageCalendarFechaEmision" ImageUrl="~/Imagenes/Calendar.gif" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Sector, Torre y Manzana -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <!-- 80 + 40 + 60 + 40 + 80 + 40 padding = 370px -->
                                                                        <td class="TC01S" style="padding-right:5px">
                                                                            Sector:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Domicilio_Sector_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="TC03S" style="padding-right:5px">
                                                                            Torre:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Domicilio_Torre_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td class="TC01S" style="padding-right:5px">
                                                                            Manzana:
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="Domicilio_Manzana_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Código interno:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Codigo_Interno_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                                ToolTip="<Opcional> Código utilizado para identificar al vendedor dentro de una empresa/organización. (Ej. Cod. de cliente, Proveedor, etc.)">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Localidad -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Localidad:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Localidad_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
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
                                                                                    <asp:DropDownList ID="TipoExpDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Provincia -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Provincia:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:DropDownList ID="Provincia_VendedorDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                                                                                    <asp:DropDownList ID="PaisDestinoExpDropDownList" Enabled="false" runat="server" OnSelectedIndexChanged="PaisDestinoExpDropDownList_SelectedIndexChanged"
                                                                                        SkinID="ddln" AutoPostBack="true">
                                                                                    </asp:DropDownList>
                                                                                    <asp:UpdateProgress ID="PaisDestinoUpdateProgress" runat="server" AssociatedUpdatePanelID="PaisDestinoExpUpdatePanel"
                                                                                        DisplayAfter="0">
                                                                                        <ProgressTemplate>
                                                                                            <asp:Image ID="PaisDestinoImage" runat="server" Height="18px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
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
                                                        <!-- Datos del Vendedor: Código Postal -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Código Postal:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Cp_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
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
                                                                                    <asp:DropDownList ID="IdiomaDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: GLN -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            GLN:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="GLN_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                                ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
                                                                                    <asp:DropDownList ID="IncotermsDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Nombre contacto -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Nombre contacto:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Contacto_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            CUIT:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Cuit_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Mail Contacto / CUIT -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            E-Mail Contacto:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Email_VendedorTextBox" ReadOnly="true" runat="server" AutoCompleteType="Email" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Condición IB:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:DropDownList ID="Condicion_Ingresos_Brutos_VendedorDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: Teléfono contacto -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Teléfono contacto:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="Telefono_VendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Número IB:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:TextBox ID="NroIBVendedorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                                ToolTip="Formatos válidos: XXXXXXX-XX o XX-XXXXXXXX-X o XXX-XXXXXX-X">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <!-- Datos del Vendedor: IVA / Inicio de actividades -->
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            IVA:
                                                                        </td>
                                                                        <td class="TC10S">
                                                                            <asp:DropDownList ID="Condicion_IVA_VendedorDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="TC00S">
                                                                            Inicio de actividades:
                                                                        </td>
                                                                        <td align="left" style="padding-left: 4px; padding-top: 5px;" valign="top">
                                                                            <asp:TextBox ID="InicioDeActividadesVendedorDatePickerWebUserControl" ReadOnly="true" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                            <asp:Image runat="server" ID="ImageCalendarInicioDeActividadesVendedor" ImageUrl="~/Imagenes/Calendar.gif" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 10px;">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table border="0" cellpadding="0" cellspacing="0">
                                <!-- DATOS DEL LOTE -->
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="LoteUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Version1RadioButton" EventName="CheckedChanged">
                                                </asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList" EventName="TextChanged">
                                                </asp:AsyncPostBackTrigger>
                                                <asp:PostBackTrigger ControlID="FileUploadButton"></asp:PostBackTrigger>
                                            </Triggers>
                                            <ContentTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                                    <tr>
                                                        <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                        </td>
                                                        <td colspan="1" style="height: 1px; background-color: Gray;">
                                                        </td>
                                                        <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: center; height: 10px;">
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
                                                                    <td class="TC00S" colspan="2">
                                                                        <asp:Label ID="LabelTipoNumeracionLote" Text="Tipo de numeración:" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td class="TC00S">
                                                                        <asp:TextBox ID="TipoNumeracionLote" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="El tipo de númeración del lote se define a nivel de Punto de Venta. Solamente para el tipo 'Ninguno' estará habilitado el ingreso manual del Número de Lote.">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center; height: 5px;">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                    </td>
                                                                    <td class="TC00S">
                                                                        Nro. de lote:
                                                                    </td>
                                                                    <td class="TC00S">
                                                                        <asp:TextBox ID="Id_LoteTextbox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="Este número, que no necesariamente tiene que ser correlativo y consecutivo, siempre debe ser mayor al último número de lote procesado en Interfacturas. Este número NO SE PUEDE REPETIR.">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                    <td class="TC01S">
                                                                        Cuit canal:
                                                                    </td>
                                                                    <td class="TC01S" style="padding-left: 5px">
                                                                        <asp:TextBox ID="Cuit_CanalTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetCh">30690783521</asp:TextBox>
                                                                    </td>
                                                                    <td class="TC00S">
                                                                        <asp:Label ID="Presta_ServLabel" Text="Presta servicios:" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td class="TC02S" style="text-align: left;">
                                                                        <asp:CheckBox ID="Presta_ServCheckBox" Enabled="false" runat="server"></asp:CheckBox>
                                                                    </td>
                                                                    <td style="width: 5px;">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center; height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                        </td>
                                                        <td colspan="1" style="height: 1px; background-color: Gray;">
                                                        </td>
                                                        <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <!-- DATOS DEL COMPRADOR -->
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="compradorUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                            UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="PaisDestinoExpDropDownList"></asp:AsyncPostBackTrigger>
                                            </Triggers>
                                            <ContentTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                                    <tr>
                                                        <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                        </td>
                                                        <td colspan="3" style="height: 1px; background-color: Gray;">
                                                        </td>
                                                        <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="text-align: center; height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TextoResaltado" colspan="3" style="text-align: center">
                                                            INFORMACIÓN COMPRADOR
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="text-align: center; height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td style="text-align:center;">
                                                                        <asp:UpdateProgress ID="compradorUpdateProgress" runat="server" AssociatedUpdatePanelID="compradorUpdatePanel"
                                                                            DisplayAfter="0">
                                                                            <ProgressTemplate>
                                                                                <asp:Image ID="compradorImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
                                                                                </asp:Image>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        GLN:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="GLN_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="<Opcional> Código estándar para identificar locaciones o empresas (Global location number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres.">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Código interno:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Codigo_Interno_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="<Opcional> Código utilizado para identificar al comprador dentro de una empresa/organización. (Ej. Cod. de cliente, Proveedor, etc.)">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Tipo de documento:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:DropDownList ID="Codigo_Doc_Identificatorio_CompradorDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Nro. de documento:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Nro_Doc_Identificatorio_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                        </asp:TextBox>
                                                                        <asp:DropDownList ID="Nro_Doc_Identificatorio_CompradorDropDownList" Enabled="false" runat="server" SkinID="ddln" Visible="false" CausesValidation="false">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Denominación:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Denominacion_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="Razón Social y Nombre del comprador">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Calle:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Domicilio_Calle_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
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
                                                                                    <asp:TextBox ID="Domicilio_Numero_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td class="TC03S" style="padding-right: 5px">
                                                                                    Piso:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="Domicilio_Piso_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td class="TC01S" style="padding-right: 5px">
                                                                                    Depto:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="Domicilio_Depto_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="6" style="height: 5px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="TC01S" style="padding-right: 5px">
                                                                                    Sector:
                                                                                </td>
                                                                                <td style="padding-right: 5px">
                                                                                    <asp:TextBox ID="Domicilio_Sector_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td class="TC03S" style="padding-right: 5px">
                                                                                    Torre:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="Domicilio_Torre_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                                <td class="TC01S" style="padding-right: 5px">
                                                                                    Manzana:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="Domicilio_Manzana_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDetChCh">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        e-mail para aviso:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="EmailAvisoVisualizacionTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="A esta dirección se enviará un email de aviso para que el destinatario pueda visualizar el comprobante">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class="bgFEAC" rowspan="2" style="width: 40px; background-repeat: repeat-y;">
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Localidad:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Localidad_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Provincia:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:DropDownList ID="Provincia_CompradorDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Código Postal:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Cp_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Contacto:
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
                                                                        <asp:TextBox ID="Email_CompradorTextBox" ReadOnly="true" runat="server" AutoCompleteType="Email"
                                                                            SkinID="TextoBoxFEAVendedorDet">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Teléfono contacto:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Telefono_CompradorTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Inicio de actividades:
                                                                    </td>
                                                                    <td style="padding-left: 6px; padding-top: 5px;">
                                                                        <asp:TextBox ID="InicioDeActividadesCompradorDatePickerWebUserControl" ReadOnly="true" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                        <asp:Image runat="server" ID="ImageCalendarInicioDeActividadesComprador" ImageUrl="~/Imagenes/Calendar.gif" />
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
                                                                        Contraseña para aviso:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="PasswordAvisoVisualizacionTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="Para poder acceder al contenido del comprobante, se solicitará al destinatario el ingreso de esta contraseña">
                                                                        </asp:TextBox>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3" valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td style="height: 10px;">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" style="height: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DEL COMPROBANTE -->
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="InfoComproUpdatePanel" runat="server" ChildrenAsTriggers="true"
                                            UpdateMode="Conditional">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Version1RadioButton" EventName="CheckedChanged">
                                                </asp:AsyncPostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList" EventName="TextChanged">
                                                </asp:AsyncPostBackTrigger>
                                                <asp:PostBackTrigger ControlID="FileUploadButton"></asp:PostBackTrigger>
                                                <asp:AsyncPostBackTrigger ControlID="Tipo_De_ComprobanteDropDownList" EventName="SelectedIndexChanged"/>
                                            </Triggers>
                                            <ContentTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                                    <tr>
                                                        <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                        </td>
                                                        <td colspan="3" style="height: 1px; background-color: Gray;">
                                                        </td>
                                                        <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="text-align: center; height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TextoResaltado" colspan="3" style="text-align: center;">
                                                            INFORMACIÓN COMPROBANTE
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TextoResaltado" colspan="3" style="text-align: center; height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 360px">
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Fecha de vencimiento:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="FechaVencimientoDatePickerWebUserControl" ReadOnly="true" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                        <asp:Image runat="server" ID="ImageCalendarFechaVencimiento" ImageUrl="~/Imagenes/Calendar.gif" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        IVA computable:
                                                                    </td>
                                                                    <td style="text-align:left; padding-left:5px; padding-top:5px">
                                                                        <asp:DropDownList ID="IVAcomputableDropDownList" Enabled="false" runat="server" SkinID="ddlch">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        <asp:Label ID="CodigoOperacionLabel" runat="server" Text="Código de operación:" Visible="true"></asp:Label>
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:DropDownList ID="CodigoOperacionDropDownList" Enabled="false" runat="server" SkinID="ddln">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        <asp:Label ID="CodigoConceptoLabel" runat="server" Text="Código de concepto:" Visible="false"></asp:Label>
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:DropDownList ID="CodigoConceptoDropDownList" Enabled="false" runat="server" Visible="false" SkinID="ddln">
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class="bgFEAC" rowspan="5" style="width: 40px; background-repeat: repeat-y;">
                                                        </td>
                                                        <td align="left" valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 370px">
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        <asp:Label ID="FechaInicioServLabel" runat="server" Text="Fecha inicio servicio:"></asp:Label>
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="FechaServDesdeDatePickerWebUserControl" ReadOnly="true" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                        <asp:Image runat="server" ID="ImageCalendarFechaServDesde" ImageUrl="~/Imagenes/Calendar.gif" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        <asp:Label ID="FechaHstServLabel" runat="server" Text="Fecha finalización servicio:">
                                                                        </asp:Label>
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="FechaServHastaDatePickerWebUserControl" ReadOnly="true" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                        <asp:Image runat="server" ID="ImageCalendarFechaServHasta" ImageUrl="~/Imagenes/Calendar.gif" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S">
                                                                        Condición de pago:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Condicion_De_PagoTextBox" ReadOnly="true" runat="server" BorderStyle="NotSet" ForeColor="#071F70"
                                                                            Style="width: 170px; resize: none; text-align:left" TextMode="MultiLine">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="TextoResaltado" colspan="3" style="text-align: center; height: 10px;">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="5" style="height: 1px; background-color: Gray;">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <!-- CODIGOS DE REFERENCIAS -->
                                <tr>
                                    <td class="TextoResaltado" style="text-align: center">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                            <tr>
                                                <td rowspan="8" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="8" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
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
                                                                BorderColor="gray" BorderStyle="Solid" BorderWidth="1px" EditRowStyle-ForeColor="#071F70"
                                                                EmptyDataRowStyle-ForeColor="#071F70" EnableViewState="true" Font-Bold="false"
                                                                ForeColor="#071F70" GridLines="Both" HeaderStyle-ForeColor="#A52A2A" 
                                                                PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
                                                                ShowFooter="true" ShowHeader="True" ToolTip="El dato de referencia debe ser un número entero"
                                                                Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="C&#243;digo de referencia">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcodigo_de_referencia" runat="server" Text='<%# Eval("descripcioncodigo_de_referencia") %>'
                                                                                Width="320px"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="320px" />
                                                                        <FooterStyle HorizontalAlign="Left" Width="320px" />
                                                                        <HeaderStyle Font-Bold="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Número de referencia">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <HeaderStyle Font-Bold="False" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataRowStyle ForeColor="#071F70" />
                                                                <RowStyle ForeColor="#071F70" />
                                                                <EditRowStyle ForeColor="#071F70" />
                                                                <SelectedRowStyle ForeColor="#071F70" />
                                                                <PagerStyle ForeColor="#071F70" />
                                                                <HeaderStyle ForeColor="Brown" />
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
                                                            <asp:Image ID="referenciasImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
                                                            </asp:Image>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="8" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="8" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <!-- PERMISOS EXPO-->
                                <tr>
                                    <td class="TextoResaltado" style="height: 19px; text-align: center">
                                        <uc2:PermisosConsulta ID="PermisosExpo" runat="server"></uc2:PermisosConsulta>
                                    </td>
                                </tr>
                                <!-- DATOS COMERCIALES-->
                                <tr>
                                    <td class="TextoResaltado" style="height: 19px; text-align: center">
                                        <uc3:Comerciales ID="DatosComerciales" runat="server"></uc3:Comerciales>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; height: 10px;">
                                    </td>
                                </tr>
                                <!-- DATOS DEL DETALLE -->
                                <tr>
                                    <td class="TextoResaltado" style="text-align: center">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                            <tr>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="1" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="6" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
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
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px">
                                                        <tr>
                                                            <td class="TC00S">
                                                                Comentarios:
                                                            </td>
                                                            <td class="TextoLabelFEADescrLarga" style="padding: 5px;">
                                                                <asp:TextBox ID="ComentariosTextBox" ReadOnly="true" runat="server" Height="100px" SkinID="TextoBoxFEADescrGr"
                                                                    TextMode="MultiLine">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="text-align: center; height: 10px;">
                                                            </td>
                                                        </tr>
                                                        <uc9:DetalleConsulta ID="DetalleLinea" runat="server"></uc9:DetalleConsulta>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DE DESCUENTOS GLOBALES -->
                                <tr>
                                    <td class="TextoResaltado" style="text-align: center">
                                        <DescUC:DescuentosGlobales ID="DescuentosGlobales" runat="server"></DescUC:DescuentosGlobales>
                                        <br />
                                    </td>
                                </tr>
                                <!-- DATOS DE IMPUESTOS GLOBALES -->
                                <tr>
                                    <td class="TextoResaltado" style="text-align: center">
                                        <uc8:ImpuestosGlobales ID="ImpuestosGlobales" runat="server"></uc8:ImpuestosGlobales>
                                    </td>
                                </tr>
                                <!-- DATOS DE RESUMEN FINAL -->
                                <tr>
                                    <td style="text-align: center">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
                                            <tr>
                                                <td rowspan="5" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="3" style="height: 1px; background-color: Gray;">
                                                </td>
                                                <td rowspan="5" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center; height: 10px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TextoResaltado" colspan="3" style="text-align: center">
                                                    RESUMEN FINAL
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="TextoResaltado" colspan="2" style="text-align: right;">
                                                </td>
                                                <td align="right" class="TextoResaltado" style="padding-right: 15px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding-bottom: 35px; padding-left: 5px; width: 180px"
                                                    valign="middle">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="border-color: Gray; border-width: 1px;
                                                        border-style: solid" width="180px">
                                                        <tr>
                                                            <td class="TC01S" style="padding: 5px; text-align: left; width: 180px">
                                                                Si ya solicitó la CAE a la AFIP, ingrésela aqui:
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC01S" style="padding-left: 5px; padding: 5px; text-align: left;
                                                                width: 180px">
                                                                CAE:<asp:TextBox ID="CAETextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet" ToolTip="<Opcional> MUY IMPORTANTE! Solo si YA TIENE GENERADO EL C.A.E., debe ingresar este dato. Si omite esta información, se generará una nueva factura ante la AFIP o bien se retornará un error por comprobante ya ingresado."
                                                                    Width="100px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC01S" style="padding: 5px; text-align: left; width: 180px">
                                                                Fecha de vencimiento CAE:
                                                                <asp:TextBox ID="FechaCAEVencimientoDatePickerWebUserControl" ReadOnly="true" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                <asp:Image runat="server" ID="ImageCalendarFechaCAEVencimiento" ImageUrl="~/Imagenes/Calendar.gif" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC01S" style="padding: 5px; text-align: left; width: 180px">
                                                                Fecha de obtención CAE:
                                                                <asp:TextBox ID="FechaCAEObtencionDatePickerWebUserControl" ReadOnly="true" runat="server" SkinID="FechaFact"></asp:TextBox>
                                                                <asp:Image runat="server" ID="ImageCalendarFechaCAEObtencion" ImageUrl="~/Imagenes/Calendar.gif" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC01S" style="padding: 5px; text-align: left; width: 180px">
                                                                Resultado:<asp:TextBox ID="ResultadoTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    Width="100px">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="TC01S" style="padding: 5px; text-align: left; width: 180px">
                                                                Motivo:<asp:TextBox ID="MotivoTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                    Width="100px">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
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
                                                                    <td class="TC00S" style="width: 390px">
                                                                        Importe total neto gravado:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Importe_Total_Neto_Gravado_ResumenTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S" style="width: 390px">
                                                                        Importe total de conceptos que no integren el precio neto gravado:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Importe_Total_Concepto_No_Gravado_ResumenTextBox" ReadOnly="true" runat="server"
                                                                            SkinID="TextoBoxFEAVendedorDet" ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S" style="width: 390px">
                                                                        Importe de operaciones exentas:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Importe_Operaciones_Exentas_ResumenTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S" style="width: 390px">
                                                                        IVA Responsable inscripto:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Impuesto_Liq_ResumenTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
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
                                                                        <asp:TextBox ID="Impuesto_Liq_Rni_ResumenTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="<Obligatorio> En el caso que no informe este campo, debe ingresar 0 (cero).El separador de decimales a utilizar es el punto">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S" style="width: 390px">
                                                                        Importe total impuestos municipales:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Importe_Total_Impuestos_Municipales_ResumenTextBox" ReadOnly="true" runat="server"
                                                                            SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S" style="width: 390px">
                                                                        Importe total impuestos nacionales:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Importe_Total_Impuestos_Nacionales_ResumenTextBox" ReadOnly="true" runat="server"
                                                                            SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S" style="width: 390px">
                                                                        Importe total ingresos brutos:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Importe_Total_Ingresos_Brutos_ResumenTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="El separador de decimales a utilizar es el punto">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S" style="width: 390px">
                                                                        Importe total impuestos internos:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Importe_Total_Impuestos_Internos_ResumenTextBox" ReadOnly="true" runat="server"
                                                                            SkinID="TextoBoxFEAVendedorDet" ToolTip="El separador de decimales a utilizar es el punto">
                                                                        </asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="TC00S" style="width: 390px">
                                                                        Importe total:
                                                                    </td>
                                                                    <td class="TC10S">
                                                                        <asp:TextBox ID="Importe_Total_Factura_ResumenTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
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
                                                                        <asp:TextBox ID="Tipo_de_cambioTextBox" ReadOnly="true" runat="server" SkinID="TextoBoxFEAVendedorDet"
                                                                            ToolTip="<Obligatorio para moneda extranjera> El separador de decimales a utilizar es el punto"
                                                                            Visible="true">
                                                                        </asp:TextBox>
                                                                        <asp:UpdateProgress ID="tipoCambioUpdateProgress" runat="server" DisplayAfter="0">
                                                                            <ProgressTemplate>
                                                                                <asp:Image ID="tipoCambioImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
                                                                                </asp:Image>
                                                                            </ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 46px">
                                                                        <br />
                                                                    </td>
                                                                    <td style="height: 46px">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="3" style="width: 1px; background-color: Gray;">
                                                </td>
                                                <td colspan="3" style="height: 1px;">
                                                </td>
                                                <td rowspan="3" style="width: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 780px; padding: 5px;">
                                                        <tr>
                                                            <td class="TC00S">
                                                                Observaciones:
                                                            </td>
                                                            <td class="TextoLabelFEADescrLarga">
                                                                <asp:TextBox ID="Observaciones_ResumenTextBox" ReadOnly="true" runat="server" Height="100px" SkinID="TextoBoxFEADescrGr"
                                                                    TextMode="MultiLine">
                                                                </asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="5" style="height: 1px; background-color: Gray;">
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; width: 100%">
                                        <table border="0" cellpadding="2" cellspacing="2" style="width: 780px">
                                            <tr>
                                                <td style="width: 100%; padding-right: 3px" colspan="2">
                                                    <asp:Button ID="PDFButton" runat="server" BackColor="#FFFFCC" BorderColor="brown"
                                                        BorderStyle="Solid" BorderWidth="1px" CausesValidation="true" Font-Bold="true"
                                                        ForeColor="brown" Height="60px" OnClick="PDFButton_Click" 
                                                        Text="Previsualizar comprobante" Width="100%" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%">
                                                    <asp:Button ID="ConsultarLoteIBKButton" runat="server" BackColor="#B4E4E4" BorderColor="brown"
                                                        BorderStyle="Solid" BorderWidth="1px" CausesValidation="false" Font-Bold="true"
                                                        ForeColor="brown" Height="60px" OnClick="ConsultarLoteIBKButton_Click" Text="Consultar lote a Interfacturas"
                                                        ToolTip="Consultar el comprobante en Interfacturas. Es un servicio On-Line para el cual se requiere un certificado de autenticación."
                                                        Width="100%" />
                                                        <cc1:ModalPopupExtender ID="ModalPopupExtender2" 
                                                        PopupControlID="PopupConsultaITF" TargetControlID="ConsultarLoteIBKButton" 
                                                        BackgroundCssClass="modalBackground" runat="server" 
                                                        onload="ModalPopupExtender2_Load" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; height: 10px;">
                                        Agradeceríamos a los usuarios del sitio que nos informen sobre dudas, posibles omisiones
                                        y/o errores y que nos envíen las correcciones o sugerencias por correo electrónico
                                        a través de
                                        <asp:HyperLink ID="contactoHyperLink" runat="server" NavigateUrl="~/Default.aspx">este formulario</asp:HyperLink>.
                                        Es de suma importancia conocer su opinión. Muchas gracias.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="text-align: center; width: 780px;">
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div id="PopupConsultaITF" class="ModalWindow">
        <table width="100%" style="padding:20px;">
            <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="LabelConsultaITF" runat="server" 
                        Text="Desea consultar el comprobante de forma On-Line en Interfacturas ?" 
                        SkinID="TextoMediano"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-top: 20px">
                    <asp:Button ID="AceptarConsultaITF" runat="server" Text="Aceptar" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="this.disabled = true;ctl00$ContentPlaceDefault$CancelarConsultaITF.disabled = true;" OnClick="AceptarConsultaITFButton_Click" />
                </td>
                 <td align="center" style="width: 20px">
                </td>
                <td align="left" style="padding-top: 20px">
                    <asp:Button ID="CancelarConsultaITF" runat="server" Text="Cancelar" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="this.disabled = true;ctl00$ContentPlaceDefault$AceptarConsultaITF.disabled = true;" OnClick="CancelarConsultaITFButton_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
