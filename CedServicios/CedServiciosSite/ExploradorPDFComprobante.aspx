<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorPDFComprobante.aspx.cs" Inherits="CedServicios.Site.ExploradorPDFComprobante" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <asp:Panel ID="Panel0" runat="server" DefaultButton="BuscarButton" align="left">
        <table align="center">
            <tr>
                <td colspan="2" 
                    style="padding-top:20px; padding-bottom:20px; text-align:center">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de PDFs de Comprobantes"></asp:Label>
                </td>
            </tr>
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
                </td>
            </tr>
            <tr>
                <td colspan="2" 
                    style="padding-top:20px; padding-bottom:10px; text-align: center">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: left; padding-bottom: 5px;">
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
                                                pero descarta los siguientes campos que usted deberá ingresar para geenrar un 
                                                nuevo comprobante.
                                                <p />
                                                <ul>
                                                    <li>Numero de comprobante</li>
                                                    <li>Fecha de emision</li>
                                                    <li>Fecha de servicio inicio y fin</li>
                                                    <li>Fecha de vencimiento</li>
                                                    <li>Nro de lote</li>
                                                    <li>Nº de CAE</li>
                                                    <li>Fecha obtencion de CAE</li>
                                                    <li>Fecha vencimiento de CAE</li>
                                                </ul>
                                            </p>
                                            </hr>
                                            </hr>
                                            </hr>
                                            </hr>
                                            </hr>
                                            </hr>
                                        </p>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div><!-- /.modal-content -->
                        </div><!-- /.modal-dialog -->
                    </div><!
                </td>
            </tr>
            <tr>
                <td colspan="2" style="">
                    <asp:GridView ID="PDFsGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowCommand="PDFsGridView_RowCommand" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="VerLinkButton" runat="server" CommandName="Consulta" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Ver</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Descr" HeaderText="PDF Comprobante" SortExpression="Descr">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Path" HeaderText="Path" SortExpression="Path" Visible="false">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaCreacion" HeaderText="Creación" SortExpression="FechaCreacion">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
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
