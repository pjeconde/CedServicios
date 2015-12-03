<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioLogin.aspx.cs" Inherits="CedServicios.Site.Ingreso" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <script type="text/css">
        .table th, .table td { 
            border-top: none !important; 
     }
     </script>
    <div class="container">
    <div class="row">
    <div class="col-lg-4 col-md-4" style="background-color: white">
        <div style="padding-top: 20px">
            <img alt="RG 3685" src="Imagenes/DiapositivaAll.GIF" style="max-width: 100%; height: auto" />
        </div>            
    </div>
    <div class="col-lg-4 col-md-4 text-center" style="background-color: white">
    <div class="container-fluid">  
        <div class="row"> 
            <div class="center-block">
                <table style="width: 260px; background-color: white" align="center">
                    <tr>
                        <td style="vertical-align: top; padding-top: 20px;">
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="LoginButton" BorderStyle="Solid"
                                BorderWidth="1" BorderColor="#cccccc">
                                <table style="padding-left: 10px; padding-right: 10px;">
                                    <tr>
                                        <td colspan="3" style="padding-top: 10px; text-align: center">
                                            <asp:Label ID="Label6" runat="server" SkinID="TituloPagina" Text="Iniciar sesión"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TextoInicioMediano" style="padding-right: 10px; padding-top: 20px; text-align: right">
                                            Id.Usuario
                                        </td>
                                        <td style="width: 100px; padding-top: 10px; text-align: left">
                                            <asp:TextBox ID="UsuarioTextBox" runat="server" MaxLength="50" OnTextChanged="UsuarioTextBox_TextChanged"
                                                TabIndex="1" Width="114px"></asp:TextBox>
                                        </td>
                                        <td rowspan="2" style="padding-right: 10px; padding-top: 20px; text-align: left">
                                            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" TabIndex="3"
                                                Text="Iniciar" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TextoInicioMediano" style="padding-right: 10px; padding-top: 5px; text-align: right">
                                            Contraseña
                                        </td>
                                        <td style="width: 100px; padding-right: 10px; padding-top: 5px; text-align: left">
                                            <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="PasswordTextBox_TextChanged"
                                                TabIndex="2" TextMode="Password" Width="114px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="padding-top: 10px; text-align: center">
                                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text="&nbsp;"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="padding-top: 10px; text-align: center">
                                            <asp:HyperLink ID="CuentaCrearHyperLink" runat="server" NavigateUrl="~/UsuarioCrear.aspx"
                                                SkinID="LinkMedianoClaro">Crear una nueva cuenta</asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="3" style="padding-top: 5px; padding-bottom: 0px">
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/UsuarioOlvidoId.aspx"
                                                SkinID="LinkMedianoClaro">¿Olvidó su Id.Usuario?</asp:HyperLink>
                                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/UsuarioOlvidoPassword.aspx"
                                                SkinID="LinkMedianoClaro">¿Olvidó su Contraseña?</asp:HyperLink>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <table style="padding-left: 20px; padding-right: 20px; width: 300px;">
                                                <%--; background-image: url('Imagenes/Factura-UsuarioDemo.png'); background-repeat: no-repeat--%>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding-top: 20px;">
                                                        <asp:Label ID="Label2" Width="200px" runat="server" SkinID="TituloMedianoC" Text="Para ingresar en la modalidad DEMO"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3" style="padding-top: 10px; padding-bottom: 20px">
                                                        <asp:Button ID="LoginUsuarioDEMOButton" runat="server" OnClick="LoginUsuarioDEMOButton_Click"
                                                            TabIndex="3" Text="Haga Clic Aqui" OnClientClick="this.disabled = true; BorrarMensaje()"
                                                            UseSubmitBehavior="false" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <table>
                                <tr>
                                    <td style="padding-left: 10px">
                                        <asp:HyperLink ID="EmpresaHyperLink" runat="server" NavigateUrl="~/InstitucionalEmpresa.aspx"
                                            SkinID="LinkChicoClaro">Empresa</asp:HyperLink>
                                        |
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/InstitucionalSoluciones.aspx"
                                            SkinID="LinkChicoClaro">Soluciones</asp:HyperLink>
                                        |
                                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/InstitucionalRefeCom.aspx"
                                            SkinID="LinkChicoClaro">Referencias Comerciales</asp:HyperLink>
                                        |
                                        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/InstitucionalContacto.aspx"
                                            SkinID="LinkChicoClaro">Contacto</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </div>
    <div class="col-lg-4 col-md-4" style="background-color: white">
        <div style="padding-top: 20px">
            <asp:Image ID="Image1" ImageUrl="~/Imagenes/eFact-vertical.jpg" runat="server" style="max-width: auto; height: 350px" />
        </div>
    </div>
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="background-color: white; height: 20px">
    </div>
    <div class="col-lg-12 col-md-12" style="background-color: white">
    <table style="width: auto">
        <tr>
            <td style="text-align: left">
                <asp:Label ID="Label1" runat="server" Font-Size="24px" Font-Bold="false" Text="Factura electrónica"
                    ForeColor="#e8906e"></asp:Label>
            </td>
        <tr>
        <tr>
            <td style="padding-top:10px; text-align: left">
                Este sitio le permite generar Facturas Electrónicas propias para gestionar el CAE a través de <b>Inter<font color="#006600"><i>Facturas</i></font></b>.<br />
                (la red de facturas electrónicas de <b>Inter<font color="#800000"><i>Banking</i></font></b>)<br />
                <br />
                Si Ud. ya cuenta con un sistema de facturación, o utiliza una planilla Excel como herramienta de facturación y desea integrarlo al Régimen de Factura Electrónica, podemos ofrecerles diversas soluciones.<br />
                <br />
                Soporta los siguientes tipos de Factura Electrónica:<br />
                <br />
                &#8226; Común (RG2485 / RG2904), <br />
                &#8226; Bono Fiscal (Bienes de Capital) y <br />
                &#8226; Exportación (RG2758/2010).<br />
                <br />
                Entorno 
                <asp:LinkButton ID="MultiCuitLinkButton" runat="server" TabIndex="4" Text="Multi-CUIT" class="tooltip-test" title="Con la misma Cuenta se pueden operar uno o más CUITs." onclick="MultiCuitLinkButton_Click" />, 
                <asp:LinkButton ID="MultiUNLinkButton" runat="server" TabIndex="5" Text="Multi-Unidad de Negocio" onclick="MultiUNLinkButton_Click" />, 
                <asp:LinkButton ID="MultiUsuarioLinkButton" runat="server" TabIndex="6" Text="Multi-Usuario" onclick="MultiUsuarioLinkButton_Click" />.<br /><br />
                <div id="Espacio" runat="server" visible="false">
                    <table>
                        <tr>
                            <td style="padding-top:0px">
                            </td>
                        </tr>
                    </table>
                </div>
                <table>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="AclaracionTituloLabel" runat="server" Font-Size="24px" Font-Bold="false" Text="" ForeColor="#e8906e"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="AclaracionDetalleLabel" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <p>
                    Cargue de manera rápida, fácil y segura su Factura Electrónica con nuestro Servicio Web. 
                    Facilitamos el cumplimiento del régimen normativo de la AFIP.
                </p>
                Para mas detalles sugerimos que se comuniquen desde <a href="InstitucionalContacto.aspx">Contacto</a> o bien escribiendonos a <a href="mailto:contacto@cedeira.com.ar">contacto@cedeira.com.ar</a>
                <br />
            </td>
        </tr>
        <tr>
            <td style="padding-top:5px; text-align: left">
                <asp:HyperLink ID="HyperLink5" runat="server" 
                    NavigateUrl="~/ActividadesAlcanzadas.aspx" SkinID="LinkChicoClaro">Actividades alcanzadas por el Régimen de Factura Electrónica</asp:HyperLink>
                |
                <asp:HyperLink ID="HyperLink6" runat="server" 
                    NavigateUrl="~/PreguntasFrecuentes.aspx" SkinID="LinkChicoClaro">Preguntas frecuentes</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td style="text-align:left">
                <label title="Regimen General" style="font-size: 24px; color: #e8906e; font-weight:normal; padding-top: 20px; padding-bottom: 5px">Regimen General</label>
                <div>
                    <!-- Nav tabs -->
                    <ul class="nav nav-tabs" role="tablist">
                        <li role="presentation" class="active"><a href="#Comprobantes" aria-controls="Comprobantes"
                            role="tab" data-toggle="tab">
                            <h4>
                                Comprobantes</h4>
                        </a></li>
                        <li role="presentation"><a href="#Sujetos" aria-controls="Sujetos" role="tab" data-toggle="tab">
                            <h4>
                                Sujetos</h4>
                        </a></li>
                        <li role="presentation"><a href="#IncorporacionAlRegimen" aria-controls="IncorporacionAlRegimen"
                            role="tab" data-toggle="tab">
                            <h4>
                                Incorporación al Régimen</h4>
                        </a></li>
                    </ul>
                    <!-- Tab panes -->
                    <div class="tab-content">
                        <div role="tabpanel" class="tab-pane active text-left" id="Comprobantes">
                            <table class="">
                                <tbody>
                                    <tr>
                                        <td style="padding: 10px">
                                            <h4>Comprobantes alcanzados</h4>
                                            <ul>
                                                <li>Facturas y Recibos clase “A”, “A” con la leyenda “PAGO EN C.B.U. INFORMADA” y/o
                                                    “M”.</li>
                                                <li>Facturas y Recibos clase “B”.</li>
                                                <li>Facturas y Recibos clase “C”.</li>
                                                <li>Facturas y Recibos clase “E”.</li>
                                                <li>Notas de crédito y notas de débito clase “A”, “A” con la leyenda “PAGO EN C.B.U.
                                                    INFORMADA” y/o “M”. </li>
                                                <li>Notas de crédito y notas de débito clase “B”.</li>
                                                <li>Notas de crédito y notas de débito clase “C”.</li>
                                                <li>Notas de crédito y notas de débito clase “E”.</li>
                                            </ul>
                                            <h4>
                                                Comprobantes excluídos</h4>
                                            <p>
                                                Quedan excluidos del presente régimen:</p>
                                            <ul>
                                                <li>Los comprobantes emitidos por aquellos sujetos que realicen operaciones que requieren
                                                    un tratamiento especial en la emisión de comprobantes, según lo dispuesto en el
                                                    Anexo IV de la RG 1415/03, (agentes de bolsa y de mercado abierto, concesionarios
                                                    del sistema nacional de aeropuertos, servicios prestados por el uso de aeroestaciones
                                                    correspondientes a vuelos de cabotaje e internacionales, distribuidores de diarios,
                                                    revistas y afines, etc.).</li>
                                                <li>Las facturas o documentos equivalentes emitidos por los sujetos indicados en el
                                                    Apartado A del Anexo I de la RG 1415/03, respecto de las operaciones allí detalladas,
                                                    en tanto no se encuentren en las situaciones previstas en el Apartado B del mismo
                                                    Anexo I.</li>
                                                <li>Los comprobantes y documentos fiscales emitidos mediante “Controlador Fiscal”, y
                                                    las notas de crédito emitidas por medio de dicho equipamiento como documentos no
                                                    fiscales homologados y/o autorizados.</li>
                                                <li>Los documentos equivalentes emitidos por entidades o sujetos especialmente autorizados
                                                    por esta Administración Federal y/o la “Liquidación Primaria de Granos”.</li>
                                            </ul>
                                            <h4>
                                                Aclaración</h4>
                                            <p>
                                                La obligación de emisión de los comprobantes electrónicos, no incluye a las operaciones,
                                                no realizadas en el local, oficina o establecimiento, cuando la facturación se efectúa
                                                en el momento de la entrega de los bienes o prestación del servicio objeto de la
                                                transacción, en el domicilio del cliente o en un domicilio distinto al del emisor
                                                del comprobante.</p>
                                            <p>
                                                Por ejemplo operaciones que se realicen a domicilio (ej. Plomeros) ó por ruteo.</p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div role="tabpanel" class="tab-pane text-left" id="Sujetos">
                            <table class="">
                                <tbody>
                                    <tr>
                                        <td style="padding: 10px">
                                            <h4>
                                                Sujetos obligados</h4>
                                            <p>
                                                Los siguientes sujetos se encuentran obligados a utilizar el régimen de factura
                                                electrónica:</p>
                                            <ul>
                                                <li>Sujetos Monotributistas: Quienes se encuentren inscriptos en las categorías H, I,
                                                    J, K y L. Aquellos sujetos que sean Monotributistas por los comprobantes emitidos
                                                    al Sector Público Nacional – que requieran Certificado Fiscal para Contratar con
                                                    el Estado-.</li>
                                                <li>Sujetos Responsables Inscriptos en el Impuesto al Valor Agregado: Todos</li>
                                                <li>Sujetos, cualquiera sea su condición frente al IVA, que:
                                                    <ul>
                                                        <li>desarrollen alguna de las actividades comprendidas en el Título III de la RG 3749/15</li>
                                                        <li>sean exportadores por la RG 2758.</li>
                                                        <li>sean comercializadores de Bienes Usados No Registrables (RG 3411).</li>
                                                    </ul>
                                                </li>
                                            </ul>
                                            <h4>
                                                Sujetos exceptuados</h4>
                                            <p>
                                                Quienes realicen operaciones a domicilio (ej. Plomeros) y por ruteo.</p>
                                            <h4>
                                                Sujetos excluidos</h4>
                                            <p>
                                                Quienes se encuentren obligados a utilizar Controlador Fiscal.</p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div role="tabpanel" class="tab-pane text-left" id="IncorporacionAlRegimen">
                            <table class="">
                                <tbody>
                                    <tr>
                                        <td style="padding: 10px">
                                            <h4>
                                                Contribuyentes alcanzados Regímenes Especiales</h4>
                                            <p>
                                                Los contribuyentes obligados por Regímenes Especiales a emitir comprobantes electrónicamente,
                                                en caso de corresponder, deben informar a este Organismo, con una antelación de
                                                5 días hábiles administrativos, la fecha a partir de la cual comenzarán a emitir
                                                dichos comprobantes. La comunicación se realizará mediante la página web de AFIP
                                                (www.afip.gob.ar), ingresando con clave fiscal al servicio “Regímenes de Facturación
                                                y Registración (REAR/RECE/RFI)”.</p>
                                            <p>
                                                La incorporación del contribuyente será publicada en la página web de AFIP (<a href="http://www.afip.gov.ar">www.afip.gov.ar</a>).</p>
                                            <h4>
                                                Contribuyentes alcanzados por la Resolución General N° 3749/15</h4>
                                            <p>
                                                Los contribuyentes alcanzados por la obligación de emitir sus comprobantes electrónicos
                                                no deben realizar empadronamiento para comenzar a emitir factura electrónica.</p>
                                            <h4>
                                                Aclaración</h4>
                                            <p>
                                                En todos los casos, previo a la emisión de los comprobantes, deberán habilitar él/los
                                                punto/s de venta destinados a tal efecto.</p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            width: 302px;
            height: 468px;
        }
    </style>
</asp:Content>

