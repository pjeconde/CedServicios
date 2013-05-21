<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalSoluciones.aspx.cs" Inherits="CedServicios.Site.InstitucionalSoluciones" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px" colspan="2">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Soluciones"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="CedFCItituloLabel" runat="server" SkinID="TituloMediano" Text="Sistema de Administración de Fondos Comunes de Inversión"></asp:Label>
            </td>
            <td rowspan="3" style="padding-top:20px">
                <asp:Image ID="CedFCIimage" runat="server" ImageAlign="Right" ImageUrl="Imagenes/CedFCI-Tablero_ch.jpg" Width="220px" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:20px; width:650px" valign="top">
                El sistema de Administración de FCIs es una herramienta de administración de las carteras de inversión de los fondos y de cálculo de los valores de cuotaparte.
                Lleva la contabilidad y facilita el cumplimiento de las normas establecidas por el organismo de fiscalización y de los reglamentos de gestión.
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:20px; vertical-align:bottom;">
                <asp:HyperLink ID="CedFCImasInfoHyperLink" runat="server" NavigateUrl="~/InstitucionalsolucionesCedFCI.aspx" SkinID="LinkMedianoClaro">Ver más información</asp:HyperLink>
            </td>
        </tr>
        <!---------------------------------------------------------------------------------------------------------------------->
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="CedSTtituloLabel" runat="server" SkinID="TituloMediano" Text="Sistema de Transferencias ( implementación MEP )"></asp:Label>
            </td>
            <td rowspan="3" style="padding-top:10px">
                <asp:Image ID="Image1" runat="server" ImageAlign="Right" ImageUrl="Imagenes/CedST-Tablero_ch.jpg" Width="220px" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:20px; padding-top:10px" valign="top">
                Es un sistema diseñado para centralizar la administración de transferencias.
                En línea con el BCRA, concentra el 100% de las operaciones, tanto enviadas como recibidas, en un único repositorio, para realizar un control eficiente y una óptima gestión operativa.
                Facilita las tareas a través de la automatización de los procesos de: ingreso, envío, recepción, distribución y conciliación, entre otros.
                Contempla todas las operatorias, acorde a las normativas, y se encuentra integrado al Sistema de Medios de Pagos (Mep) del BCRA.
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:20px; vertical-align: bottom">
                <asp:HyperLink ID="CedSTmasInfoHyperLink" runat="server" NavigateUrl="~/InstitucionalsolucionesCedST.aspx" SkinID="LinkMedianoClaro">Ver más información</asp:HyperLink>
            </td>
        </tr>
        <!---------------------------------------------------------------------------------------------------------------------->
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label6" runat="server" SkinID="TituloMediano" Text="Sistema de Carga Centralizada de Tasas"></asp:Label>
            </td>
            <td rowspan="2" style="padding-top:10px">
                <asp:Image ID="Image11" runat="server" ImageAlign="right" ImageUrl="Imagenes/CedCCT.jpg" Width="220px" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:20px; padding-top:10px" valign="top">
                Esta aplicación permite la consulta y modificación, en línea, de todo tipo de Tasas Pasivas.<br />
                Presenta un Tablero de Control donde se pueden visualizar todas la tasas en una
                estructura jerárquica y sobre el que se pueden realizar cambios puntuales o masivos
                (actualizando las tasas en cadena, acordes a un índice o porcentaje definido, en
                más o en menos ). Todos los cambios se impactan en los sistemas corporativos del
                banco.<br />
                Permite un control preciso de la autorización de las operaciones y registra un log
                detallado para documentar los cambios realizados.<br />
                Genera Reportes Operativos y Actas para el Directorio.<br />
                También permite exportar la información a planillas de cálculo.
            </td>
        </tr>
        <!---------------------------------------------------------------------------------------------------------------------->
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="TituloMediano" Text="Sistema de Inversiones y Pagos Judiciales" ></asp:Label>
            </td>
            <td rowspan="2" style="padding-top:10px">
                <asp:Image ID="Image7" runat="server" ImageAlign="Right" ImageUrl="Imagenes/CedJU.jpg" Width="220px" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:20px; padding-top:10px" valign="top">
                Es una aplicación que contribuye a la automatización del servicio que los bancos
                prestan a los Juzgados Comerciales en los que se tramitan quiebras. El sistema permite,
                por un lado, registrar las colocaciones temporarias, de los fondos surgidos de la
                liquidación de bienes, en <b>INVERSIONES</b> a plazo fijo o en cajas de ahorro.
                Cada inversión se mantendrá siempre relacionada al Juzgado-Secretaría-Causa-Incidente
                en los que se originó.<br />
                Por otro lado, la aplicación permite, a partir de esas inversiones, realizar <b>PAGOS</b>
                a beneficiarios (acreedores) de acuerdo a las instrucciones emanadas de los Juzgados.
                Existen dos instrumentos mediantes los cuáles los juzgados ordenan los pagos:<br />
                &nbsp &nbsp 1) Oficios judiciales y<br />
                &nbsp &nbsp 2) Libranzas judiciales.<br />
                En ambos casos, los pagos se liquidan en las sucursales del banco (esta aplicación
                le brinda, a la plataforma de sucursales del banco, un servicio para validar y registrar
                pagos judiciales).<br />
                También ofrece una amplia gama de reportes, tanto para los Juzgados (y la Corte
                Suprema) como para los sectores que administran las inversiones y los pagos.
            </td>
        </tr>
        <!---------------------------------------------------------------------------------------------------------------------->
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label5" runat="server" SkinID="TituloMediano" Text="Sistema de Administración y Presentación de Contenidos" ></asp:Label>
            </td>
            <td rowspan="2" style="padding-top:10px">
                <asp:Image ID="Image9" runat="server" ImageAlign="Right" ImageUrl="Imagenes/CedAPC.jpg" Width="220px" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:20px; padding-top:10px" valign="top">
                Es una herramienta, de propósitos generales, que permite automatizar procesos informáticos
                en los que:<br />
                &nbsp &nbsp 1) se recolecten de datos,<br />
                &nbsp &nbsp 2) se calculen resultados, a partir de esos datos, y<br />
                &nbsp &nbsp 3) se presenten esos resultados (contenidos)<br />
                Ofrece, a los administradores, un entorno amigable e intuitivo para la definición
                de datos básicos, fórmulas y templates de presentación (que serán usados para la
                generación de reportes o de interfaces de salida).<br />
                Luego, asiste a los usuarios en el proceso de captura de datos (manual, desde el
                front-end propio, o automática, desde interfaces con otras aplicaciones) y en el
                proceso de cálculo y de presentación de resultados. Sólo exige una capacitación
                mínima.<br />
                El sistema contempla, y controla, el aporte de datos desde distintos sectores. Implementa
                un repositorio histórico (de datos, de resultados y registra un log con la actividad
                de los usuarios).<br />
                Una experiencia exitosa, de implementación, lo constituye el cálculo de las exigencias
                de <b>Capitales Mínimos</b>, que tienen las entidades financieras, y su consiguiente
                presentación de reportes y generación de interfaces.
            </td>
        </tr>
        <!---------------------------------------------------------------------------------------------------------------------->
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="TituloMediano" Text="Factura Electrónica (solución de conectividad)"></asp:Label>
            </td>
            <td rowspan="2" style="padding-top:10px">
                <asp:Image ID="Image5" runat="server" ImageAlign="Right" ImageUrl="Imagenes/eFact-R.jpg" Width="220px" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:20px; padding-top:10px" valign="top">
                Es un producto que permite "subir", a la red Interfacturas, los comprobantes generados
                por su sistema de facturación.<br />
                Se trata de una herramienta que:<br />
                &nbsp &nbsp 1) "captura" sus comprobantes,<br />
                &nbsp &nbsp 2) los impacta en Interfacturas (quedando la factura electrónica a disposición
                de sus<br />
                &nbsp &nbsp &nbsp &nbsp clientes o lista para ser impresa) y<br />
                &nbsp &nbsp 3) registra el resultado de ese impacto, incluyendo la confirmación
                del CAE (código de<br />
                &nbsp &nbsp &nbsp &nbsp autorización electrónico).<br />
                La forma en la que nuestro sistema capturará sus comprobantes, será personalizada,
                por nosotros, en función de las posibilidades que nos de su sistema de facturación.<br />
                También estableceremos las equivalencias entre los códigos propios, de su sistema
                de facturación, y los códigos estándar de la operatoria de Factura Electrónica.<br />
                Por último, configuraremos, a su medida, la forma en la que nuestro sistema registrará
                la respuesta del impacto.
            </td>
        </tr>
        <!---------------------------------------------------------------------------------------------------------------------->
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label8" runat="server" SkinID="TituloMediano" Text="Factura Electrónica (eFact residente versión Excel)" ></asp:Label>
            </td>
            <td rowspan="3" style="padding-top:10px">
                <asp:Image ID="Image13" runat="server" ImageAlign="Right" ImageUrl="Imagenes/eFact-R-XL.jpg" Width="220px" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:20px; padding-top:10px" valign="top">
                Es un producto que permite "subir", a la red Interfacturas, los comprobantes ingresados
                a través de una planilla Excel.<br />
                Con él se provee una planilla modelo (template).<br />
                Un programa genera, a partir de los datos ingresados en la planilla, el archivo
                XML que dará origen al comprobante electrónico
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right:20px; vertical-align: bottom">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Descarga.aspx?archivo=eFact-R-XL.zip" SkinID="LinkMedianoClaro">
                    Descargar eFact residente versión Excel 2000 o posterior
                </asp:HyperLink>
            </td>
        </tr>
        <!---------------------------------------------------------------------------------------------------------------------->
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="TituloMediano" Text="Otras soluciones relacionadas al área financiera"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:20px; padding-top:10px" valign="top">
		        Asambleas y Accionistas<br />
		        Autorización de Tasas de Sucursales<br />
		        Administración de Carteras<br />
		        Plataforma Mesa de Dinero<br />
            </td>
        </tr>
        <!---------------------------------------------------------------------------------------------------------------------->
        <tr>
            <td align="center" colspan="2" style="height: 24px; padding-top: 20px">
                <asp:Button ID="RefeComButton" runat="server" CausesValidation="false" TabIndex="1" Text="Referencias Comerciales" onclick="RefeComButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="EmpresaButton" runat="server" TabIndex="1" Text="Empresa" onclick="EmpresaButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="ContactoButton" runat="server" CausesValidation="false" TabIndex="3" Text="Contacto" onclick="ContactoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="4" Text="Salir" PostBackUrl="~/Default.aspx" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-bottom: 30px; padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
