<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorComprobante.aspx.cs" Culture="en-GB" UICulture="en-GB" Inherits="CedServicios.Site.ExploradorComprobante" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <asp:Panel ID="Panel0" runat="server" DefaultButton="BuscarButton" align="left">
        <table align="center">
            <tr>
                <td colspan="3" style="padding-top:20px; padding-bottom:20px; text-align:center">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes"></asp:Label>
                    <asp:TextBox ID="ElementoTextBox" runat="server" Visible="false"> </asp:TextBox>
                    <asp:TextBox ID="TratamientoTextBox" runat="server" Visible="false"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-right:5px; padding-top:5px; text-align:left; width: 180px">
                    Persona (cliente/proveedor):
                </td>
                <td style="padding-top:5px; text-align: left; width: 450px">
                    <asp:DropDownList ID="ClienteDropDownList" runat="server" Width="400px" DataValueField="Orden" DataTextField="RazonSocial"></asp:DropDownList>
                </td>
                <td rowspan="3" style="padding-top:5px; padding-left: 10px; vertical-align: top; text-align: left; max-width: 400px">
                    <asp:Panel ID="EstadosPanel" runat="server">
                        <table style="max-width: 400px">
                            <tr>
                                <td>
                                    Estado(s):&nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="EstadoVigenteCheckBox" runat="server" Text="Vigente" AutoPostBack="false"/>
                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:CheckBox ID="EstadoPteEnvioCheckBox" runat="server" Text="Pendiente de envio (AFIP/ITF)" AutoPostBack="false"/>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:CheckBox ID="EstadoDeBajaCheckBox" runat="server" Text="De baja" AutoPostBack="false"/>
                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:CheckBox ID="EstadoPteConfCheckBox" runat="server" Text="Pendiente de confirmación" AutoPostBack="false"/>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:CheckBox ID="EstadoRechCheckBox" runat="server" Text="Rechazado" AutoPostBack="false"/>
                                </td>
                                <td style="padding-left: 10px;">
                                    <asp:CheckBox ID="EstadoPteAutorizCheckBox" runat="server" Text="Pendiente de autorización" AutoPostBack="false"/>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="padding-right:5px; padding-top:5px; text-align: left">
                    Naturaleza del comprobante:
                </td>
                <td style="padding-top:5px; text-align: left">
                    <asp:DropDownList ID="NaturalezaComprobanteDropDownList" runat="server" Width="400px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" OnSelectedIndexChanged="VerificarEstadosPosibles_SelectedIndexChanged"></asp:DropDownList>
                </td>        
            </tr>
            <asp:Panel ID="DetallePanel" runat="server">
            <tr>
	            <td style="padding-right:5px; padding-top:5px; vertical-align: top; text-align: left">
                    Detalle:
	            </td>
			    <td colspan="1" style="padding-top:5px; width:400px; text-align: left">
				    <asp:TextBox ID="DetalleTextBox" runat="server" MaxLength="50"></asp:TextBox>
                    (ej.: "autom" para seleccionar sólo comprobantes generados automaticamente)
			    </td>
            </tr>
            </asp:Panel>
            <asp:Panel ID="PeriodoEmisionPanel" runat="server">
            <tr>
	            <td style="padding-right:5px; padding-top:5px; text-align: left">
                    Período de emisión:
	            </td>
			    <td style="padding-top:5px; text-align:left">
                    desde&nbsp;
                    <asp:TextBox ID="FechaDesdeTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="FechaDesdeCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                        TargetControlID="FechaDesdeTextBox" Format="yyyyMMdd" PopupButtonID="FechaDesdeImage" >
                    </ajaxToolkit:CalendarExtender>
                    <asp:Image runat="server" ID="FechaDesdeImage" ImageUrl="~/Imagenes/Calendar.gif" />
                    &nbsp;&nbsp;hasta&nbsp;
                    <asp:TextBox ID="FechaHastaTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="FechaHastaCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                        TargetControlID="FechaHastaTextBox" Format="yyyyMMdd" PopupButtonID="FechaHastaImage" >
                    </ajaxToolkit:CalendarExtender>
                    <asp:Image runat="server" ID="FechaHastaImage" ImageUrl="~/Imagenes/Calendar.gif" />
                </td>
            </tr>
            </asp:Panel>
            <tr>
                <td>
                </td>
                <td style="padding-top:5px; vertical-align: top; text-align: left">
                    <asp:Button ID="BuscarButton" class="btn btn-default btn-sm" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" />
                    <asp:Button ID="SalirButton" class="btn btn-default btn-sm" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                    <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTROS DE BUSQUEDA" data-content="Si no selecciona ningún filtro, buscará todos los comprobantes que estén dentro del rango de fechas del período de emisión.<br><a href='Imagenes/Ayuda/PeriodoEmision.png' target='_blank'><br/><img src='Imagenes/Ayuda/PeriodoEmision.png' style='width:100%'/></a>"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                </td>
            </tr>
            <tr>
                <td colspan="3" 
                    style="padding-top:20px; padding-bottom:10px; text-align: center">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: left; padding-bottom: 5px;">
                    <div style="text-align: right;">
                        <a href="#" role="button" runat="server" class="" data-toggle="modal" data-target="#myModalLarge" id="AyudaGrilla" visible="false"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>&nbsp;
                    </div>
                    <div id="myModalLarge" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="H1">GRILLA CONSULTA DE COMPROBANTES</h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <h4>Dispone de una columna "Acción" que permite realizar las siguientes tareas:</h4>
                                        <p>
                                        </p>
                                        <a href="Imagenes/Ayuda/ConsultaComprobante-Acciones.png" target="_blank">
                                        <img src="Imagenes/Ayuda/ConsultaComprobante-Acciones.png" style="width: auto" />
                                        </a>
                                        <br />
                                        <h4>
                                            Actualizar estado (Interfacturas/AFIP)</h4>
                                        <p>
                                            Actualiza un comprobante en estado &quot;Pendiente de Confirmación&quot; o &quot;Pendiente de 
                                            envío (AFIP/ITF)&quot; o “Pendiente de confirmación” a estado &quot;Vigente&quot;, para los 
                                            siguientes casos:<br />
                                            <br />
                                            1) Gestión del CAE ONLINE aprobado por la AFIP.<br /> 2) Gestión del CAE ONLINE 
                                            aprobado por Interfacturas.<br />
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
                                            <hr>
                                            <h4>
                                                Consultar (Interfacturas)</h4>
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
                                            <hr>
                                            <h4>
                                                Viewer PDF (Interfacturas)</h4>
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
                                            <hr>
                                            <h4>
                                                Descargar XML (Interfacturas)</h4>
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
                                            <hr>
                                            <h4>
                                                Descargar XML</h4>
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
                                            <hr>
                                            <h4>
                                                Descargar PDF</h4>
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
                                            <hr>
                                            <h4>
                                                Clonar comprobante</h4>
                                            <p>
                                                La clonación de comprobante obtiene todos los datos del comprobante original, 
                                                pero descarta los siguientes campos que usted deberá ingresar para generar un 
                                                nuevo comprobante.
                                                <p />
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
                                                <p>
                                                    Además, serán actualizados los datos del vendedor según corresponda. En primer 
                                                    medida, se tomaran los datos del vendedor registrados para el punto de venta que 
                                                    figura en el comprobante que usted ha seleccionado para clonar, siempre y 
                                                    cuando, en la definición del punto de venta, figure desmarcada la casilla de 
                                                    &quot;Usa datos CUIT&quot;. De lo contrario, se tomaran los datos del vendedor que se 
                                                    encuentran registrados a nivel de CUIT.
                                                    <p />
                                                </p>
                                                <p>
                                                </p>
                                            </p>
                                            </hr>
                                            </hr>
                                            </hr>
                                            </hr>
                                            </hr>
                                            </hr>
                                            <p>
                                            </p>
                                            <p>
                                            </p>
                                        </p>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div><!-- /.modal-content -->
                        </div><!-- /.modal-dialog -->
                    </div><!
                </td>
            </tr>
            <tr>
                <td colspan="3" style="">
                    <asp:GridView ID="ComprobantesGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowCommand="ComprobantesGridView_RowCommand" OnRowDataBound="ComprobantesGridView_RowDataBound" CssClass="grilla" GridLines="None">
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
                                    <asp:LinkButton ID="EnvioLinkButton" runat="server" CommandName="Envio" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Envio</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="ModificacionLinkButton" runat="server" CommandName="Modificacion" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Modificación</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DescrNaturalezaComprobante" HeaderText="Naturaleza" SortExpression="DescrNaturalezaComprobante">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescrTipoComprobante" HeaderText="Tipo" SortExpression="DescrTipoComprobante">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NroPuntoVtaFORMATEADO" HeaderText="P.V." SortExpression="NroPuntoVtaFORMATEADO">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NroFORMATEADO" HeaderText="Nro." SortExpression="NroFORMATEADO">
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
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
    </div>
    </div>
</asp:Content>
