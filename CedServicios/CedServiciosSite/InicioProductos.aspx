<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InicioProductos.aspx.cs" Inherits="CedServicios.Site.InicioProductos" Theme="CedServicios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" Visible="true" ContentPlaceHolderID="ContentPlaceDefault" runat="server">

<section id="HeaderProductos" class="features" style="background-color:white">
    <div class="container">
        <div class="row">
            <div class="main_features_content2">
            </div>
        </div>
    </div>
</section>
<div id="panCedST" runat="server">
    <section id="featuresCedST" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12">
                        <div class="single_features_left text-left">
                            <h3 style="text-align: center">Sistema de Transferencias</h3>
                            <br />
                            <p>Es un sistema diseñado para centralizar la administración de transferencias.
                            En línea con el BCRA, concentra el 100% de las operaciones, tanto enviadas como recibidas, en un único repositorio, para realizar un control eficiente y una óptima gestión operativa. 
                            </p>
                            <p>
                            Facilita las tareas a través de la <b><i>automatización de los procesos</i></b> de ingreso, envío, recepción, distribución y conciliación, entre otros. Contempla todas las operatorias, acorde a las normativas, y se encuentra <b><i>integrado al Sistema de Medios de Pago (Mep)</i></b> del BCRA.
                            </p>
                            <br />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="single_features_left text-center">
                            <img src="Imagenes/CedST-EsquemaMEP.jpg" alt=""/>
                            <br />
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12">
                        <div class="single_features_left text-center">
                            <h4 style="text-align: center">Tablero de Control</h4>
                            <p style="text-align: left">
                            Los tableros de control permiten visualizar, en qué sector, y en qué estado, se encuentran todas las transferencias del día y pendientes de días anteriores.  Cada sector puede identificar rápidamente las operaciones pendientes de intervención.
                            <br />
                            No solo se podrán visualizar las cantidades de operaciones realizadas, sino también los totales expresados en importes, discriminados por moneda. 
                            </p>
                            <br />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12">
                        <div class="single_features_left text-center">
                            <img src="Imagenes/Productos/CedST/CedST-Tablero.jpg" alt="" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12">
                        <div class="single_features_left text-center">
                            <img src="Imagenes/Productos/CedST/CedST-Tablero2.jpg" alt="" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12 padding-top-40">
                        <div class="single_features_left text-left">
                            <h4 style="text-align: center">Beneficios de la solución </h4>
                            <p style="text-align: center">Con la puesta en marcha del Sistema de Transferencias, la entidad se beneficia en los siguientes aspectos. 
                            </p>
                            <table>
                                <tr style="padding-bottom: 10px">
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Se dispone de toda la información histórica (Mep elimina las operaciones durante el proceso de cierre diario). </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Se incorporan las Transferencias Recibidas (Mep no procesa transferencias recibidas). </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Incluye un esquema de autorización de operaciones flexible, en el que se puede personalizar: cantidad y jerarquía de funcionarios intervinientes por sector, autorización por escala de montos y control por oposición (Mep no contempla un tercer nivel de supervisión para las operaciones de riesgo y no controla montos). </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Conectividad con otras aplicaciones: se incluyen servicios y componentes para interactuar, en línea, con otros sistemas (Mep carece de estas prestaciones). </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Reducción de la carga operativa del sector que administra las transferencias: </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top""> </td>
                                    <td> 
                                        <table>
                                            <tr>
                                                <td style="width:15px; vertical-align:top">•</td><td> Mep enviadas </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15px; vertical-align:top"></td><td> Las operaciones se ingresan y autorizan, en los sectores de origen. Acotando la intervención del sector administrador, a aspectos de tesorería; se eliminan los controles manuales (de firmas, del origen e integridad de la información en faxes, mails, cartas, entre otros). </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15px; vertical-align:top">•</td><td> Mep recibidas </td>
                                            </tr>
                                            <tr>
                                                <td style="width:15px; vertical-align:top"></td><td> Mediante la automatización del proceso de distribución a los sectores de destino. </td>
                                            </tr>
                                        </table>                                  
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Sistematización de la notificación de recepción o envío de transferencias. Los sectores perciben estas novedades en tiempo real a través de la aplicación. </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Uniformidad en el tratamiento de la información: todos los sectores hablan el mismo idioma.  </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Logs de auditoría: se registra toda la actividad de los usuarios y de los administradores de seguridad.  </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Se preserva la seguridad, integridad y confidencialidad de todas las transferencias. </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Seguimiento de transferencias: cada sector puede realizar el seguimiento permanente de una transferencia en particular o tener una visión global a través de indicadores generales del estado de las operaciones. </td>
                                </tr>
                                <tr>
                                    <td style="width:15px; vertical-align:top"><b>•</b></td><td> Actualización automática de operatorias: el sistema actualiza, en forma automática, la estructura de datos de cada operatoria, sincronizando las novedades que se incorporen a MepTransaccional. De esta manera, se evita la modificación del sistema ante los cambios que incorpore el BCRA. </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12 padding-top-40">
                        <div class="single_features_left text-left">
                            <h4 style="text-align: center">Administración de las Transferencias</h4>
                            <p>La aplicación soporta transferencias enviadas y recibidas. Además, incluye un nuevo concepto: las transferencias esperadas, que permite, a los distintos sectores, declarar las transferencias pendientes de recepción, para automatizar su distribución.
                            </p>
                        </div>
                    </div>
                    <div class="col-sm-12 padding-top-20">
                        <div class="single_features_left text-center">
                            <img src="Imagenes/Productos/CedST/CedST-Esperadas.jpg" alt=""  />
                        </div>
                    </div>
                    <div class="col-sm-12 padding-top-40">
                        <div class="single_features_left text-left">
                            <p>
                                Permite el ingreso manual de las operatorias, y tambíen dispone de un módulo para el envío automático desde otras aplicaciones. A medida que el BCRA agrega o modifica alguna operatoria, el sistema dinámicamente se entera de las novedades, y habilita automáticamnete la nueva funcionalidad.
                            </p>
                        </div>
                    </div>
                    <div class="col-sm-12 padding-top-20"">
                        <div class="single_features_left text-center">
                            <img src="Imagenes/Productos/CedST/CedST-Nueva.jpg" alt=""  />
                        </div>
                    </div>
                    <div class="col-sm-12 padding-top-40">
                        <div class="single_features_left text-left">
                            <p>
                               El sistema dispone de un Visor de Captura para monitorear la correcta incorporación de las transferencias y un Visor de Busquedas para el ágil manejo de la información histórica. 
                            </p>
                        </div>
                    </div>
                    <div class="col-sm-12 padding-top-20">
                        <div class="single_features_left text-center">
                            <img src="Imagenes/Productos/CedST/CedST-CapturaRecibidas.jpg" alt=""  />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
<div runat="server" id="panCedSTfooter">
    <section id="footerCedST" class="features lightbg padding-bottom-40 padding-top-40">
        <div class="container">
            <div class="row">
                <div class="footer-menu-wrapper">
                    <div class="col-sm-12">
                        <p>Para obtener un mayor detalle del funcionamiento de la aplicación, pueden descargar la presentación completa del producto en formato PDF...<br />
                        <a href="Descarga.aspx?archivo=Cedeira-SistTransfMEP.pdf" class="btn btn-default"> Descargar</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
<div id="panCedFCI" runat="server">
    <section id="featuresCedFCI" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12">
                        <div class="single_features_left text-left">
                            <h3 style="text-align: center">Sistema de Administración de Fondos Comunes de Inversión</h3>
                            <br />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="single_features_left text-left">
                            <p>El sistema de Administración de FCIs es una herramienta de administración de las carteras de inversión de los fondos y de cálculo de los valores de cuotaparte. Lleva la contabilidad y facilita el cumplimiento de las normas establecidas por el organismo de fiscalización y de los reglamentos de gestión. 
                            </p>
                            <h4 style="text-align: center">Beneficios de la solución </h4>
                            <p>
                            • Calcula los valores de cuotaparte de las clases emitidas para todos los fondos, en forma automática.<br /> 
                            • Facilita el ingreso de novedades (operaciones, cierres de cambio, precios, tasas de cuentas remuneradas, suscripciones y rescates, etc).<br />
                            • Facilita la configuración de datos básicos (fondos, clases, fees de administración, plan de cuentas, especies, entidades, monedas, etc).<br /> 
                            • Provee un repositorio único, para facilitar la administración centralizada, pero, manteniendo la independencia de cada fondo.<br /> 
                            • Confiere una mayor uniformidad en el tratamiento de la información de todos los fondos.<br /> 
                            • Guarda un registro respaldatorio, absolutamente pormenorizado, de cada ValorCP calculado.<br /> 
                            • Reduce la carga operativa, y el riesgo de cometer errores de transcripción, al disponer de opciones automáticas de captura de precios de especies de TVs y de SyRs, y de publicación de ValorCPs, en el Sistema de Títulos.<br /> 
                            • Mantiene toda la información histórica, sin descuidar la performance de acceso a datos operativos.<br /> 
                            • Registra toda la actividad de los usuarios y de los administradores de seguridad en Logs de auditoria.<br /> 
                            • Workflow parametrizable: que soporta todas las acciones sobre el proceso, operaciones, precios, cierres de cambio, etc.; en el que se define la cantidad y jerarquía de funcionarios intervinientes y si exige control por oposición.<br /> 
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12 padding-top-40">
                        <div class="single_features_left text-left">
                            <h4 style="text-align: center">Tablero de Control</h4>
                            <p>
                                El Tablero de control es el front-end principal de la aplicación. En él se destacan tres paneles. El panel de Proceso diario sirve para guiar al usuario en el trabajo diario (permite saber rapidamente en qué estado está el proceso, cuál es el próximo paso que debe darse y cuáles son las tareas pendientes, en términos de cálculo de valores de cuotaparte).   El panel de Opciones permite acceder a todas las funcionalidades del sistema (para ver más detalles, descargue la presentación).   El panel de Notificaciones sirve para desplegar avisos del sistema (se hace visible sólo cuando es imprescindible). 
                            </p>
                            <br />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="single_features_left text-center">
                            <img src="Imagenes/Aplicaciones/CedFCIForm.jpg" alt=""/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12 padding-top-40">
                        <div class="single_features_left text-left">
                            <h4 style="text-align: center">Proceso diario</h4>
                            <p>Representa una guía para la actividad diaria, en términos de:<br />
                            • Incorporación de novedades (operaciones, cierres de cambio, precios, tasas de cuentas remuneradas, suscripciones y rescates de cuotapartes).<br /> 
                            • Revalúo de carteras (devengado de intereses de colocaciones a plazo y sobre saldos de cuentas remuneradas, revalúo de titulos valores, ajustes por diferencia de cambio).<br /> 
                            • Cálculo / liquidación de honorarios administrativos de las sociedades Gerente y Depositaria.<br /> 
                            • Cálculo de los valores de cuotaparte de la(s) clase(s) emitida(s) para cada fondo.<br /> 
                            • Incorporación de Suscripciones y Rescates valorizados.<br /> 
                            • Confirmación y publicación de los valores de cuotapartes calculados.<br /> 
                            • Cierre diario (que desencadena también el proceso de Apertura del siguiente día hábil y, cuando corresponde, los procesos de Cierre de Ejercicio y Depuración).<br /> 
                            • En el proceso de Apertura, con el que arranca cada nuevo día, se liquidan los vencimientos pendientes, de pago o cobro, en forma automática (Ej.: rescates a pagar, compra de acciones a pagar, venta de acciones a cobrar).<br /> 
                            </p>
                            <br />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="single_features_left text-center">
                            <img src="Imagenes/Aplicaciones/CedFCIForm_ProcesoDiario.jpg" alt=""/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
<div runat="server" id="panCedFCIfooter">
    <section id="footerCedST" class="features lightbg padding-bottom-40 padding-top-40">
        <div class="container">
            <div class="row">
                <div class="footer-menu-wrapper">
                    <div class="col-sm-12">
                        <p>Para obtener un mayor detalle del funcionamiento de la aplicación, pueden descargar la presentación completa del producto en formato PDF.<br />
                        <a href="Descarga.aspx?archivo=Cedeira-SistAdminFCIs.pdf" class="btn btn-default"> Descargar</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
<div id="panCedCCT" runat="server">
    <section id="featuresCedCCT" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12">
                        <div class="single_features_left text-left">
                            <h3 style="text-align: center">Sistema de Administración de Carga Centralizada de Tasas</h3>
                            <br />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="single_features_left text-left">
                            <p>
                            Esta aplicación permite la administración centralizada de las Tasas Pasivas de los bancos. Presenta un Tablero de Control donde se pueden visualizar todas la tasas en una estructura jerárquica, permitiendo agrupar la información por canal, región, zona y/o sucursales, y sobre el que se pueden realizar cambios puntuales o masivos.
                            </p>
                            <p>
                                Pernite consultar y/o modificar en línea todas las tasas. También actualizar las tasas en cadena, acordes a diferentes formulas que pueden ser previamente definidas (índices, porcentajes, sumas y restas, ratios, etc). Todos los cambios se impactan en los sistemas corporativos del banco.
                            </p>
                            <p>
                                • Calculo automático de tasas en linea o programadas para dias posteriores.<br /> 
                                • Permite un control preciso de la autorización de las operaciones.<br /> 
                                • Registra un log detallado sobre cualquier cambio realizado en la aplicación.<br />
                                • Genera Reportes Operativos y Actas para el Directorio.<br />
                                • Permite exportar la información a planillas de cálculo.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
<div id="panCedAPC" runat="server">
    <section id="featuresCedAPC" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="col-sm-12">
                        <div class="single_features_left text-left">
                            <h3 style="text-align: center">Sistema de Administración de Contenidos</h3>
                            <br />
                        </div>
                    </div>
                    <div class="col-sm-12">
                        <div class="single_features_left text-left">
                            <p>
                            Este sistema de Administración de Contenidos es una herramienta de propósitos generales, que permite automatizar procesos informáticos en los que primero se recolecten de datos, segundo se calculen resultados, a partir de esos datos se presenten los resultados en formato de contenido informatívo.
                            <br />
                            <br />
                            Ofrece, a los administradores, un entorno amigable e intuitivo para la definición de datos básicos, fórmulas y templates de presentación que serán usados para la generación de reportes o de interfaces de salida.
                            <br />
                            <br />
                            Asiste a los usuarios en el proceso de captura de datos manual, desde el front-end propio que posee la aplicación, o automática desde interfaces con otras aplicaciones. También esta totalmente asistido el proceso de cálculo y la presentación de resultados. Sólo exige una capacitación
                            mínima.
                            <br />
                            <br />
                            El sistema contempla, y controla, el aporte de datos desde distintos sectores. Implementa un repositorio histórico de datos, de resultados y registra un log con toda la actividad de los usuarios.
                            <br />
                            <br />
                            Una experiencia exitosa, de implementación, lo constituye el cálculo de las exigencias de <b>Capitales Mínimos</b>, que tienen las entidades financieras, y su consiguiente presentación de reportes y generación de interfaces.
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</div>
                

</asp:Content>