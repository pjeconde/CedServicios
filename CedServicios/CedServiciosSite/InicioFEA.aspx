<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InicioFEA.aspx.cs" Inherits="CedServicios.Site.InicioFEA" Theme="CedServicios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" Visible="true" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
<div id="panFEA" runat="server">
<section id="features" class="features sections2">
    <div class="container">
        <div class="row">
            <div class="main_features_content2">
                <div class="head_title">
                    <h2>Información sobre facturación electrónica</h2>
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
                                &#8226; Común (RG.2485 / RG.2904), <br />
                                &#8226; Bono Fiscal (Bienes de Capital), <br />
                                &#8226; Exportación (RG.2758/2010) y <br />
                                &#8226; Turismo (RG.3971).<br />
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
                                    NavigateUrl="~/InicioFEA.aspx?valor=panFEA3">Actividades alcanzadas por el Régimen de Factura Electrónica</asp:HyperLink>
                                |
                                <asp:HyperLink ID="HyperLink6" runat="server" 
                                    NavigateUrl="~/InicioFEA.aspx?valor=panFEA2">Preguntas frecuentes</asp:HyperLink>
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
                                        <div role="tabpanel" class="tab-pane fade in active text-left" id="Comprobantes">
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
                                                                <li>Facturas clase “T”.</li>
                                                                <li>Notas de crédito y notas de débito clase “A”, “A” con la leyenda “PAGO EN C.B.U.
                                                                    INFORMADA” y/o “M”. </li>
                                                                <li>Notas de crédito y notas de débito clase “B”.</li>
                                                                <li>Notas de crédito y notas de débito clase “C”.</li>
                                                                <li>Notas de crédito y notas de débito clase “E”.</li>
                                                                <li>Notas de crédito y notas de débito clase “T”.</li>
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
                                        <div role="tabpanel" class="tab-pane fade text-left" id="Sujetos">
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
                                        <div role="tabpanel" class="tab-pane fade text-left" id="IncorporacionAlRegimen">
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
    </div>
</section>
</div>
<div id="panFEA2" runat="server">
<section id="features2" class="features sections2">
    <div class="container">
        <div class="row">
            <div class="main_features_content2">
                <div class="head_title">
                    <h2>Información sobre Facturación Electrónica</h2>
                    <br />
                    <asp:Label ID="Label10" runat="server" SkinID="TituloPagina" Text="Preguntas frecuentes"></asp:Label>
                </div>
                <div class="col-lg-12 col-md-12">
                    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="¿Qué es factura electrónica?" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Es un documento comercial en formato electrónico que reemplaza al documento físico tradicional (papel).
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px">
                                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="¿Cómo adquiere validez la factura electrónica?" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                El C.A.E. es el código de autorización electrónico, que otorga la AFIP a cada documento para darle validez. Un documento con C.A.E. indica que fue autorizado por la AFIP. A través de InterFacturas no tiene que preocuparse por realizar la gestión de C.A.E. ya que se realiza de forma automática.
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px">
                                <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="¿Se podrá utilizar la factura tradicional (en papel) alternativamente a la factura electrónica?" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                La resolución R.G. 2485/08, en su artículo 4 establece los comprobantes excluidos del régimen de factura electrónica.
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px">
                                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="¿Cuáles son las características de los comprobantes electrónicos?" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                * Poseen efectos fiscales frente a terceros si el documento electrónico contiene el Código de Autorización Electrónico “CAE”, asignado por la AFIP. * Son identificados con un punto de venta específico, distinto a los utilizados para la emisión de comprobantes manuales o a través de controlador fiscal. * Deben tener correlatividad numérica.
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px">
                                <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="¿Cuáles son las características de los comprobantes electrónicos?" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Los sujetos que hubieran efectuado la comunicación con la fecha a partir de la cual comenzarán a emitir los comprobantes electrónicos originales, se encuentran obligados a cumplir, para todas las actividades, con lo dispuesto en: 1. El Título I de la Resolución General Nº 1361, sus modificatorias y complementarias, referido a la emisión y almacenamiento de duplicados electrónicos de comprobantes. 2. El Título II de la citada resolución general, respecto del almacenamiento electrónico de registraciones. Fuente: Art.9 RG 2485/08
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px">
                                <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="¿En qué plazo debe ser puesta a disposición la factura electrónica?" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Dentro de los 10 días corridos contados desde la asignación del 'C.A.E.'.  Fuente: Art.30 RG 2485/08
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:10px">
                                <asp:Label ID="Label8" runat="server" Font-Bold="true" Text="¿Cómo pongo, la factura electrónica, a disposición de mis clientes?" ForeColor="#e8906e"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                Interfacturas pone a su disposición el sitio Web para que sus clientes se registren y puedan visualizar sus facturas electrónicas. Para mayor información consulte
                                <asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="http://www.interfacturas.com.ar/" Target="_blank">aqui</asp:HyperLink>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-top:20px">
                                <asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Para más información visite:" ForeColor="#e8906e"></asp:Label>&nbsp
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.afip.gov.ar/efactura/" Target="_blank">AFIP-Factura Electrónica / Comprobantes en Línea</asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</section>
</div>
<div id="panFEA3" runat="server">
<section id="features3" class="features sections2">
    <div class="container">
        <div class="row">
            <div class="main_features_content2">
                <div class="head_title">
                    <h2>Información sobre Facturación Electrónica</h2>
                    <br />
                    <asp:Label ID="Label11" runat="server" SkinID="TituloPagina" Text="Actividades Alcanzadas"></asp:Label>
                </div>
                <div class="col-lg-12 col-md-12">
                    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
                        <tr>
                            <td align="center" style="vertical-align:top">
                                •&nbsp
                            </td>
                            <td align="left" style="">
                                Servicios profesionales (abogados, contadores, escribanos, arquitectos, licenciados en sistemas, en administración, entre otros) con montos anuales de operaciones iguales o mayores a 600.000,- $).
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Servicios de Informática y desarrolladores de software.
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Planes de salud con abono de cuota mensual
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Transmisión de televisión por cable y/o satelital
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Acceso a Internet con abono mensual
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Servicios de telefonía móvil
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Transporte de caudales y/o otros objetos de valor
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Seguridad (incluye instalación de alarmas, monitoreo vigilancia etc.)
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Limpieza
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Prestación de servicios de publicidad y conexos
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Servicios de construcción, infraestructura del transporte y telepeaje, ámbito de la Pcia. de Bs. As. y Ciudad Autónoma de Bs. As.
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                •&nbsp
                            </td>
                            <td align="left">
                                Fabricantes de bienes de capital que sean beneficiarios del Bono Fiscal.
                            </td>
                        </tr>
                    </table> 
                </div>
            </div>
        </div>
    </div>
</section>
</div>

</asp:Content>
