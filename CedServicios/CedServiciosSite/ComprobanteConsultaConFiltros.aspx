<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprobanteConsultaConFiltros.aspx.cs" Culture="en-GB" UICulture="en-GB" Inherits="CedServicios.Site.ComprobanteConsultaConFiltros" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <style type="text/css">
    .popover
    {
    	min-width: 500px;
    }
    </style>
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes"></asp:Label>
                        </h2>
                        <asp:TextBox ID="ElementoTextBox" runat="server" Visible="false"> </asp:TextBox>
                        <asp:TextBox ID="TratamientoTextBox" runat="server" Visible="false"> </asp:TextBox>
                    </div>
                </div>
             </div>
        </div>
        <div class="container">
            <asp:UpdatePanel ID="DetalleUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:Panel ID="Panel0" runat="server" DefaultButton="BuscarButton" align="left">
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20 text-left">
                        <div class="input-group text-left" style="background-color:white; height:25px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Persona (cliente/proveedor):&nbsp;</span>
                        <asp:DropDownList ID="ClienteDropDownList" runat="server" CssClass="form-control TextoChico" Height="25px" DataValueField="Orden" DataTextField="RazonSocialCuitIdPersona" AutoPostBack="true" OnSelectedIndexChanged="Personas_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>                      
                <div class="col-lg-6 col-md-6 padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:25px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Naturaleza del comprobante:&nbsp;</span>
                        <asp:DropDownList ID="NaturalezaComprobanteDropDownList" runat="server" CssClass="form-control TextoChico" Height="25px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" OnSelectedIndexChanged="VerificarEstadosPosibles_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20">  
                    <asp:Panel ID="DetallePanel" runat="server">
                        <div class="input-group text-left" style="background-color:white; height:25px">
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Detalle:&nbsp;</span>
                            <asp:TextBox ID="DetalleTextBox" runat="server" MaxLength="50" CssClass="form-control TextoChico" Height="25px"></asp:TextBox>
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:40px;">
                                <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA (DETALLE)" data-content="(ej.: 'autom' para seleccionar sólo comprobantes generados automaticamente)"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                            </span>
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-lg-6 col-md-6 padding-top-20">  
                    <asp:Panel ID="PeriodoEmisionPanel" runat="server">
                        <div class="input-group" style="background-color:white; height:25px; float:left">
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; height: 25px;">&nbsp;Emisión:&nbsp;</span>
                            <asp:TextBox ID="FechaDesdeTextBox" runat="server" CausesValidation="true" CssClass="form-control TextoRegular" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="80px" Height="25px" TabIndex="304"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="FechaDesdeCalendarExtender" runat="server" CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                                TargetControlID="FechaDesdeTextBox" Format="yyyyMMdd" PopupButtonID="FechaDesdeLinkButton" >
                            </ajaxToolkit:CalendarExtender>
                            <asp:LinkButton ID="FechaDesdeLinkButton" runat="server" CssClass="form-control no-padding" Width="25px" Height="25px"  
                                AutoPostBack="true" ToolTip="Multiselección de Estados">
                                <span class="glyphicon glyphicon-calendar gi-1x" style="padding: 3px;"></span>
                            </asp:LinkButton>
                            <asp:Label runat="server" ID="hastaLabel" CssClass="form-control TextoMediano text-center" Width="60px" Height="25px" Text="&nbsp;&nbsp;hasta&nbsp;&nbsp;"></asp:Label>
                            <asp:TextBox ID="FechaHastaTextBox" runat="server" CausesValidation="true" CssClass="form-control TextoRegular" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="80px" Height="25px" TabIndex="304"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="FechaHastaCalendarExtender" runat="server" CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                                TargetControlID="FechaHastaTextBox" Format="yyyyMMdd" PopupButtonID="FechaHastaLinkButton" >
                            </ajaxToolkit:CalendarExtender>
                            <asp:LinkButton ID="FechaHastaLinkButton" runat="server" CssClass="form-control no-padding" Width="25px" Height="25px"  
                                AutoPostBack="true" ToolTip="Multiselección de Estados">
                                <span class="glyphicon glyphicon-calendar" style="padding: 3px"></span>
                            </asp:LinkButton>
                            <span class=" dropdown" style="padding-left: 2%; height:25px; z-index:1;">
                                <a class="dropdown" data-toggle="dropdown" style="text-align:left;"><span style="font-size: 10pt">Predefinidas</span>
                                    <span class="caret"></span>
                                </a>
                                <ul class="dropdown-menu" style="z-index:1;">
                                    <li><asp:LinkButton class="dropdown-item" id="MesActual" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Mes Actual"></asp:LinkButton></li>
                                    <li><asp:LinkButton class="dropdown-item" id="MesAnterior" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Mes Anterior"></asp:LinkButton></li>
                                    <li><asp:LinkButton class="dropdown-item" id="TresMesesUltimos" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Ultimos Tres Meses"></asp:LinkButton></li>
                                    <li><asp:LinkButton class="dropdown-item" id="TresMesesAnteriores" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Tres Meses Anteriores"></asp:LinkButton></li>
                                    <li class="divider"></li>
                                    <li><asp:LinkButton class="dropdown-item" id="AnualActual" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Año Actual"></asp:LinkButton></li>
                                    <li><asp:LinkButton class="dropdown-item" id="AnualAnterior" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Año Anterior"></asp:LinkButton></li>
                                    <li><asp:LinkButton class="dropdown-item" id="DesdeSiempre" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Desde Siempre"></asp:LinkButton></li>
                                </ul>
                            </span>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div runat="server" Id="EstadosVenta" class="col-lg-6 col-md-6 col-sm-6 text-left padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:25px;">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Estado(s) Ventas:&nbsp;</span>
                        <asp:DropDownList ID="EstadoDropDownList" CssClass="form-control TextoChico" runat="server" Height="25px"
                            DataValueField="Id" DataTextField="Descr" AutoPostBack="true" OnSelectedIndexChanged="AbrirFiltroEstadoLinkButton_Click">
                        </asp:DropDownList>
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:60px">
                            <asp:LinkButton ID="AbrirFiltroEstadoLinkButton" runat="server" CssClass="" Width="40px" Height="20px"  
                            AutoPostBack="true" OnClick="AbrirFiltroEstadoLinkButton_Click" ToolTip="Multiselección de Estados">
                            <span class="glyphicon glyphicon-filter" style="padding: 2px"></span>
                            </asp:LinkButton>
                            <a href="javascript:void(0)" id="popoverButton" style="padding-right:10px" role="button" style="width:200px" placement="bottom" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA</br>(ESTADOS COMPROBANTES de VENTA)" data-content="Esta multiselección de estados de los comprobantes de VENTA, estará disponible según la selección realizada en el combo de Naturaleza del Comprobante.">
                            <span class="glyphicon glyphicon-info-sign" style="padding: 2px"></span>
                            </a>
                        </span>
                    </div>
                </div>
                <div runat="server" Id="EstadosCompra" class="col-lg-6 col-md-6 col-sm-6 text-left padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:20px;">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white">&nbsp;Estado(s) Compras / Ventas(tradic.):&nbsp;</span>
                        <asp:DropDownList ID="EstadoComprasDropDownList" CssClass="form-control TextoChico" runat="server" Height="25px" style="z-index:0;" 
                            DataValueField="Id" DataTextField="Descr" AutoPostBack="true" OnSelectedIndexChanged="AbrirFiltroEstadoComprasLinkButton_Click">
                        </asp:DropDownList>
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white"><asp:LinkButton ID="LinkButton1" runat="server" CssClass="" Width="40px" Height="20px"  
                            AutoPostBack="true" OnClick="AbrirFiltroEstadoComprasLinkButton_Click" ToolTip="Multiselección de Estados">
                            <span class="glyphicon glyphicon-filter" style="padding: 2px"></span>
                        </asp:LinkButton></span>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:20px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white">&nbsp;Tipos Comprobante:&nbsp;</span>
                        <asp:DropDownList ID="TiposComprobanteDropDownList" CssClass="form-control TextoChico" runat="server" Height="25px" style="z-index:0;"
                            DataValueField="Id" DataTextField="Descr" AutoPostBack="true" OnSelectedIndexChanged="AbrirFiltroTiposComprobanteLinkButton_Click">
                        </asp:DropDownList>
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white"><asp:LinkButton ID="LinkButton2" runat="server" CssClass="" Width="40px" Height="20px"  
                            AutoPostBack="true" OnClick="AbrirFiltroTiposComprobanteLinkButton_Click" ToolTip="Multiselección de Estados">
                            <span class="glyphicon glyphicon-filter" style="padding: 2px"></span>
                        </asp:LinkButton></span>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:20px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white">&nbsp;Ordenar por: &nbsp;</span>
                        <asp:DropDownList ID="OrderByDropDownList" runat="server" Height="25px" style="z-index:0;" CssClass="form-control TextoChico" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" OnSelectedIndexChanged="Ordenar_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 padding-top-20">  
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="input-group text-left" style="background-color:white; height:25px">
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Pto.Vta:&nbsp;</span>
                            <asp:TextBox ID="PuntoDeVentaTextBox" runat="server" MaxLength="50" CssClass="form-control TextoChico" Height="25px"></asp:TextBox>
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:40px;">
                                <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA (PUNTO DE VENTA)" data-content="(debe ser un número que no supere los 5 dígitos)"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                            </span>
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; border-bottom-color: white; border-top-color: white; width:40px;">
                            </span>
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;NºComp.:&nbsp;</span>
                            <asp:TextBox ID="NumeroDeComprobanteTextBox" runat="server" MaxLength="50" CssClass="form-control TextoChico" Height="25px"></asp:TextBox>
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:40px;">
                                <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA (NÚMERO DE COMPROBANTE)" data-content="(debe ser un número que no supere los 9 dígitos)"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                            </span>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:Button ID="BuscarButton" class="btn btn-default btn-sm" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" />
                    <asp:Button ID="SalirButton" class="btn btn-default btn-sm" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                    <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" data-placement="top" data-trigger="hover" title="FILTROS DE BUSQUEDA" data-content="Si no selecciona ningún filtro, buscará todos los comprobantes que estén dentro del rango de fechas del período de emisión, con los filtros por defecto.<br><a href='Imagenes/Ayuda/PeriodoEmision.png' target='_blank'><br/><img src='Imagenes/Ayuda/PeriodoEmision.png' style='width:100%'/></a>" style="padding-top:30px"><span class="glyphicon glyphicon-info-sign gi-1x"></span></a>
                </div>
            </div>
            </asp:Panel>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center padding-top-20">  
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:UpdateProgress ID="ExploradorUpdatePanelProgress" runat="server" AssociatedUpdatePanelID="DetalleUpdatePanel" DisplayAfter="0">
                        <ProgressTemplate>
                            <asp:Image ID="ExploradorComprobanteImage" runat="server" Height="18px" ImageUrl="~/Imagenes/301.gif">
                            </asp:Image>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Panel ID="GrillaComprobantesPanel" runat="server" Width="100%" ScrollBars="Auto">
                        <asp:Panel ID="AyudaConsultaComprobantesPanel" runat="server" Width="100%" ScrollBars="Auto">
                            <div style="text-align: center; padding: 5px;">
                                <a href="#" role="button" runat="server" class="" data-toggle="modal" data-target="#myModalLarge" id="AyudaGrilla" visible="false"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span><span class="gi-1x" style="vertical-align:middle">&nbsp;Acciones posibles de la Grilla.</span></p></a>&nbsp;
                            </div>
                            <div id="myModalLarge" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" id="H1">GRILLA CONSULTA DE COMPROBANTES</h4>
                                        </div>
                                        <div class="modal-body">
                                            <h4>Dispone de una columna "Acción" que permite realizar las siguientes tareas:</h4>
                                            <a href="Imagenes/Ayuda/ConsultaComprobante-Acciones.png" target="_blank">
                                            <img src="Imagenes/Ayuda/ConsultaComprobante-Acciones.png" alt="Acciones" style="width: auto" />
                                            </a>
                                            <hr />

                                            <h4>Actualizar estado (Interfacturas/AFIP)</h4>
                                            Actualiza un comprobante en estado &quot;Pendiente de Confirmación&quot; o &quot;Pendiente de 
                                            envío (AFIP/ITF)&quot; o “Pendiente de confirmación” a estado &quot;Vigente&quot;, para los 
                                            siguientes casos:<br />
                                            <br />
                                            1) Gestión del CAE ONLINE aprobado por la AFIP.<br /> 2) Gestión del CAE ONLINE 
                                            aprobado por Interfacturas.<br />
                                            <br />
                                            <p>
                                            Una vez cambiado el estado, se completan en el comprobante los siguientes datos:<br />
                                            <a class="tooltip-test" data-placement="bottom" href="#" 
                                                title="El C.A.E. (Código de Autorización Electrónico) es un número (formato similar al C.A.I.) que otorga la AFIP al autorizar la emisión de un comprobante por web service, aplicativo RECE o por el servicio por clave fiscal 'Comprobantes en linea' ('facturas electrónicas'). Sin CAE, la factura no tiene validez fiscal.">
                                            CAE</a>, Fecha de Obtención y Vencimiento del CAE, y el Resultado.<br /><br /> 
                                            Si el comprobante fue rechazado por la AFIP / Interfacturas, no se actualizará 
                                            el estado. En dicho caso deberá corregir la información necesaria hasta que 
                                            luego del envío, se acepte el comprobante.
                                            </p>
                                            Requisitos:
                                            <ul>
                                                <li>Estar utilizando los servicios OnLine.</li>
                                                <li>El comprobante no debe estar en estado “Vigente” o “De baja” o “Rechazado”.</li>
                                                <li>Solo para comprobantes de Venta electrónica.</li>
                                            </ul>
                                            <hr />

                                            <h4>Consultar (Interfacturas)</h4>
                                            <p>
                                            Visualiza el comprobante obteniendo toda la información en línea directamente de 
                                            Interfacturas. Se puede utilizar para consultar el <a class="tooltip-test" 
                                                data-placement="bottom" href="#" 
                                                title="El C.A.E. (Código de Autorización Electrónico) es un número (formato similar al C.A.I.) que otorga la AFIP al autorizar la emisión de un comprobante por web service, aplicativo RECE o por el servicio por clave fiscal 'Comprobantes en linea' ('facturas electrónicas'). Sin CAE, la factura no tiene validez fiscal.">
                                            CAE</a> o el motivo del rechazo de la AFIP.
                                            </p>
                                            Requisitos:
                                            <ul>
                                                <li>Estar utilizando los servicios OnLine.</li>
                                                <li>El comprobante debe haberse creado con el Canal Interfacturas. Si la gestión del 
                                                    CAE la realizó contra los servicios de la AFIP, no podrà consultar con esta 
                                                    opción.</li>
                                                <li>Solo para comprobantes de Venta electrónica.</li>
                                            </ul>
                                            <hr />

                                            <h4>Viewer PDF (Interfacturas)</h4>
                                            <p>
                                            Permite visualizar el comprobante en formato <kbd>PDF</kbd> en otra solapa de su 
                                            navegador ( Browser ), utilizando el servicio OnLine de Interfacturas.
                                            </p>
                                            Requisitos:
                                            <ul>
                                                <li>Estar utilizando los servicios OnLine de Interfacturas.</li>
                                                <li>El comprobante debe haberse creado con el Canal Interfacturas.</li>
                                                <li>Solo para comprobantes de Venta electrónica.</li>
                                            </ul>
                                            <hr />

                                            <h4>Descargar XML (Interfacturas)</h4>
                                            <p>
                                            Descarga un archivo XML, similar al obtenido en el sitio de Interfacturas, con 
                                            el CAE incluído.
                                            </p>
                                            Requisitos:
                                            <ul>
                                                <li>El comprobante debe estar con estado Vigente.</li>
                                                <li>utilizando los servicios OnLine de Interfacturas.</li>
                                                <li>Solo para comprobantes de Venta electrónica.</li>
                                            </ul>
                                            <hr />

                                            <h4>Descargar XML</h4>
                                            <p>
                                                Descarga un archivo XML ( sin el <a class="tooltip-test" data-placement="bottom" 
                                                    href="#" 
                                                    title="El C.A.E. (Código de Autorización Electrónico) es un número (formato similar al C.A.I.) que otorga la AFIP al autorizar la emisión de un comprobante por web service, aplicativo RECE o por el servicio por clave fiscal 'Comprobantes en linea' ('facturas electrónicas'). Sin CAE, la factura no tiene validez fiscal.">
                                                CAE</a> ), similar al que descarga luego del ingreso de una factura,
                                                <a href="Imagenes/Ayuda/AltaLote-Acciones.png" target="_blank">
                                                <img alt="Acciones" 
                                                src="Imagenes/Ayuda/AltaLote-Acciones.png" style="width: auto" />
                                                </a>para ser subido (UpLoad) en forma manual en en el sitio de Interfacturas, 
                                                para obtener el CAE.
                                            </p>
                                            Requisitos:
                                            <ul>
                                                <li>El comprobante debe estar con estado “Pendiente de envío (AFIP/ITF)”.</li>
                                                <li>Solo para comprobantes de Venta electrónica.</li>
                                            </ul>
                                            <hr />

                                            <h4>Descargar PDF</h4>
                                            <p>
                                                Descarga el comprobante en formato <kbd>PDF</kbd>, listo para enviar a su 
                                                cliente.
                                            </p>
                                            Requisito:
                                            <ul>
                                                <li>El comprobante debe estar con estado Vigente ( con el <a class="tooltip-test" 
                                                        data-placement="top" href="#" 
                                                        title="El C.A.E. (Código de Autorización Electrónico) es un número (formato similar al C.A.I.) que otorga la AFIP al autorizar la emisión de un comprobante por web service, aplicativo RECE o por el servicio por clave fiscal 'Comprobantes en linea' ('facturas electrónicas'). Sin CAE, la factura no tiene validez fiscal.">
                                                    CAE</a> generado ).</li>
                                            </ul>
                                            <hr />

                                            <h4>Clonar comprobante</h4>
                                            <p>
                                            La clonación de comprobante obtiene todos los datos del comprobante original, 
                                            pero descarta los siguientes campos que usted deberá ingresar para generar un 
                                            nuevo comprobante.
                                            </p>
                                            <ul>
                                                <li>Número de comprobante</li>
                                                <li>Fecha de emisión</li>
                                                <li>Fecha de servicio inicio y fin</li>
                                                <li>Fecha de vencimiento</li>
                                                <li>Nro de lote</li>
                                                <li>Nº de CAE</li>
                                                <li>Fecha obtencion de CAE</li>
                                                <li>Fecha vencimiento de CAE</li>
                                            </ul>
                                            <br />    
                                            Además, serán actualizados los datos del vendedor según corresponda. En primer 
                                            medida, se tomaran los datos del vendedor registrados para el punto de venta que 
                                            figura en el comprobante que usted ha seleccionado para clonar, siempre y 
                                            cuando, en la definición del punto de venta, figure desmarcada la casilla de 
                                            &quot;Usa datos CUIT&quot;. De lo contrario, se tomaran los datos del vendedor que se 
                                            encuentran registrados a nivel de CUIT.
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div><!-- /.modal-content -->
                                </div><!-- /.modal-dialog -->
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="AyudaModifComprobantesPanel" runat="server" Width="100%" ScrollBars="Auto">
                            <div style="text-align: left; padding: 5px;">
                                <a href="#" role="button" runat="server" class="" data-toggle="modal" data-target="#myModalLargeModif" id="AyudaGrillaModif" visible="false"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>&nbsp;
                            </div>
                            <div id="myModalLargeModif" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" id="H1">GRILLA MODIFICACIÓN DE COMPROBANTES</h4>
                                        </div>
                                        <div class="modal-body">
                                            <h4>Dispone de una columna para seleccionar y modificar los datos de los comprobantes.</h4>
                                            <p style="text-align:left">
                                            Los comprobantes habilitados para realizar una modificación son los siguientes:
                                            </p>
                                            <p style="text-align:left">
                                                <b>Ventas tradicionales</b> &quot;Vigentes&quot;<br />
                                                <b>Ventas electrónicas</b> &quot;No Vigentes&quot; por ejemplo "Ptes de Envío (AFIP/ITF)" o “Pendiente de confirmación”<br />
                                                <b>Compras</b> &quot;Vigentes&quot;<br />
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div><!-- /.modal-content -->
                                </div><!-- /.modal-dialog -->
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="AyudaBajaYAnulBajaPanel" runat="server" Width="100%" ScrollBars="Auto">
                            <div style="text-align: left; padding: 5px;">
                                <a href="#" role="button" runat="server" class="" data-toggle="modal" data-target="#myModalLargeBaja" id="AyudaGrillaBaja" visible="false"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>&nbsp;
                            </div>
                            <div id="myModalLargeBaja" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" id="H1">GRILLA BAJA/ANUL.BAJA DE COMPROBANTES</h4>
                                        </div>
                                        <div class="modal-body">
                                            <p style="text-align:left">
                                                <h4 style="text-align:left">Dispone de dos columnas para seleccionar alguno de los comprobantes de la lista y realizar las siguientes tareas:</h4>
                                            </p>
                                            <p style="text-align:left">
                                            La primera columna permite realizar la <b>Baja o la Anulación de la Baja</b> según el estado actual del comprobante. No se permitirá la Baja de comprobantes que hayan sido enviados y aceptados por la AFIP/ITF.
                                            </p>
                                            <p style="text-align:left">
                                            La segunda columna permite realizar la <b>Baja Física</b> del comprobante siempre y cuando este en un estado de Baja. No se permitirá la Baja Física de comprobantes que hayan sido enviados y aceptados por la AFIP/ITF.
                                            </p>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                        </div>
                                    </div><!-- /.modal-content -->
                                </div><!-- /.modal-dialog -->
                            </div>
                        </asp:Panel>
                        <cc1:PagingGridView ID="ComprobantePagingGridView" runat="server" OnPageIndexChanging="ComprobantePagingGridView_PageIndexChanging"
                            OnRowDataBound="ComprobantePagingGridView_RowDataBound" HorizontalAlign="Center" 
                            FooterStyle-ForeColor="Brown" OnRowEditing="ComprobantePagingGridView_RowEditing" OnRowCancelingEdit="ComprobantePagingGridView_RowCancelingEdit"
                            OnRowUpdating="ComprobantePagingGridView_RowUpdating" 
                            OnSorting="ComprobantePagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" CssClass="grilla" AlternatingRowStyle-BackColor="#d3d3d3" 
                            AutoGenerateColumns="false" OnRowCommand="ComprobantePagingGridView_RowCommand"
                            OnSelectedIndexChanged="ComprobantePagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="ComprobantePagingGridView_SelectedIndexChanging" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="VerLinkButton" runat="server" CommandName="Consulta" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Ver</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BajaAnulBajaLinkButton" runat="server" CommandName="Baja/Anul.baja" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Baja/Anul.baja</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BajaFisicaLinkButton" runat="server" CommandName="BajaFisica" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Baja Fisica</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="EnvioLinkButton" runat="server" CommandName="Envio" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Envio</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ModificacionLinkButton" runat="server" CommandName="Modificacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Modificación</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DescrNaturalezaComprobante" HeaderText="Natur." SortExpression="DescrNaturalezaComprobante">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescrTipoComprobante" HeaderText="Tipo" SortExpression="DescrTipoComprobante">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NroPuntoVtaFORMATEADO" HeaderText="P.V." SortExpression="NroPuntoVta">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NroFORMATEADO" HeaderText="Nro." SortExpression="NroComprobante">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescrTipoDoc" HeaderText="T.Doc" SortExpression="DescrTipoDoc">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NroDoc" HeaderText="Nro.Doc." SortExpression="NroDoc">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdPersona" HeaderText="Id.Pers" SortExpression="IdPersona">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha" SortExpression="Fecha">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaProximaEmision" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha emi." SortExpression="FechaProximaEmision">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:0.00}" SortExpression="Importe">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Moneda" HeaderText="Mon" SortExpression="Moneda">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ImporteMoneda" HeaderText="Imp.Mon" DataFormatString="{0:0.00}" SortExpression="ImporteMoneda">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TipoCambio" HeaderText="Cambio" DataFormatString="{0:0.0000}" SortExpression="TipoCambio">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdDestinoComprobante" HeaderText="Canal" SortExpression="IdDestinoComprobante">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaVto" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha Vto" SortExpression="FechaVto">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NroLote" HeaderText="Nro.Lote" SortExpression="NroLote">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="right" wrap="False" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
		                                <asp:DropDownList ID="AccionDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="AccionDropDownList_SelectedIndexChanged" EnableViewState="false">
			                                <asp:ListItem Value="" Text="--- elegir acción ---"></asp:ListItem>
			                                <asp:ListItem Value="ActualizarOnLine" Text="Actualizar estado (Interfacturas/AFIP)"></asp:ListItem>
			                                <asp:ListItem Value="ConsultarInterfacturas" Text="Consultar (Interfacturas)"></asp:ListItem>
			                                <asp:ListItem Value="PDF-Viewer" Text="Viewer PDF (InterFacturas)"></asp:ListItem>
			                                <asp:ListItem Value="XMLOnLine" Text="Descargar XML (InterFacturas)"></asp:ListItem>
                                            <asp:ListItem Value="XMLLocal" Text="Descargar XML"></asp:ListItem>
			                                <asp:ListItem Value="PDF" Text="Descargar PDF"></asp:ListItem>
			                                <asp:ListItem Value="XML-ClonarAlta" Text="Clonar comprobante"></asp:ListItem>
		                                </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign = "Center" CssClass="GridPager" />
                        </cc1:PagingGridView>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center">
                    <div id="filtroEstadoModal" class="modal fade" tabindex="-1" role="dialog">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        ×</button>
                                    <h3 id="H3">
                                        Multiselección de Estados</h3>
                                </div>
                                <div class="modal-body">
                                    <div class="panel">
                                        <div class="panel-body" style="max-height: 400px; overflow-y: scroll;">
                                            <asp:GridView AutoGenerateColumns="false" ID="EstadoGridView" runat="server" Visible="true"
                                                ShowHeader="false" HorizontalAlign="Left">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="IncluirCheckBox" runat="server" Checked='<%#DataBinder.Eval(Container.DataItem, "Incluir")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Id")%>
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Descr")%>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="izquierda" Wrap="false" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" id="AceptarFiltroEstadoButton" runat="server" class="btn btn-default" onserverclick="ValidaryAsignarCamposFiltroLinkButton_Click">
                                        Aceptar</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="filtroEstadoComprasModal" class="modal fade" tabindex="-1" role="dialog">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        ×</button>
                                    <h3 id="H3">
                                        Multiselección de Estados</h3>
                                </div>
                                <div class="modal-body">
                                    <div class="panel">
                                        <div class="panel-body" style="max-height: 400px; overflow-y: scroll;">
                                            <asp:GridView AutoGenerateColumns="false" ID="EstadoComprasGridView" runat="server" Visible="true"
                                                ShowHeader="false" HorizontalAlign="Left">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="IncluirCheckBox" runat="server" Checked='<%#DataBinder.Eval(Container.DataItem, "Incluir")%>' />
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Id")%>
                                                        </ItemTemplate>
                                                        <ItemStyle />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem, "Descr")%>
                                                        </ItemTemplate>
                                                        <ItemStyle CssClass="izquierda" Wrap="false" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" id="Button1" runat="server" class="btn btn-default" onserverclick="ValidaryAsignarCamposFiltroLinkButton_Click">
                                        Aceptar</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div id="filtroTiposComprobanteModal" class="modal fade" tabindex="-1" role="dialog">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        ×</button>
                                    <h3 id="H3">
                                        Multiselección de Tipos de Comprobante</h3>
                                </div>
                                <div class="modal-body">
                                    <div class="panel">
                                        <div class="panel-body" style="max-height: 50px; text-align: left">
                                            <div class="row">
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                    <asp:LinkButton ID="MarcarTodoTipoComprobanteLinkButton" runat="server" CssClass="" Width="25px" Height="25px"  
                                                        AutoPostBack="true" ToolTip="Marcar todos los tipos de comprobantes" OnClick="MarcarTodoTipoComprobanteLinkButton_Click">
                                                        <span class="glyphicon glyphicon-check" style="padding: 3px;"><asp:Label runat="server" ID="Label1" CssClass="TextoMediano" Width="120px" Text="&nbsp;&nbsp;Marcar Todo&nbsp;&nbsp;"></asp:Label></span> 
                                                    </asp:LinkButton></span>
                                                </div>
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                    <asp:LinkButton ID="DesMarcarTodoTipoComprobanteLinkButton" runat="server" CssClass="" Width="25px" Height="25px"  
                                                        AutoPostBack="true" ToolTip="Marcar todos los tipos de comprobantes" OnClick="DesMarcarTodoTipoComprobanteLinkButton_Click">
                                                        <span class="glyphicon glyphicon-unchecked" style="padding: 3px;"><asp:Label runat="server" ID="Label2" CssClass="TextoMediano" Width="120px" Text="&nbsp;&nbsp;Desmarcar Todo&nbsp;&nbsp;"></asp:Label></span> 
                                                    </asp:LinkButton></span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="panel-body" style="max-height: 400px; overflow-y: scroll;">
                                            <div class="row">
                                                <asp:GridView AutoGenerateColumns="false" ID="TiposComprobanteGridView" runat="server" Visible="true"
                                                    ShowHeader="false" HorizontalAlign="Left">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="IncluirCheckBox" runat="server" Checked='<%#DataBinder.Eval(Container.DataItem, "Incluir")%>' />
                                                            </ItemTemplate>
                                                            <ItemStyle />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Codigo")%>
                                                            </ItemTemplate>
                                                            <ItemStyle />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "Descr")%>
                                                            </ItemTemplate>
                                                            <ItemStyle CssClass="izquierda" Wrap="false" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button data-dismiss="modal" id="Button2" runat="server" class="btn btn-default" onserverclick="ValidaryAsignarCamposFiltroTipoCompLinkButton_Click">
                                        Aceptar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>
