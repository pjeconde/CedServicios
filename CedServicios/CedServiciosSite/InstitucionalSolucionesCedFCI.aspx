<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalSolucionesCedFCI.aspx.cs" Inherits="CedServicios.Site.InstitucionalSolucionesCedFCI" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px; width:1000px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Sistema de Administración de Fondos Comunes de Inversión"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 10px">
                El sistema de Administración de FCIs es una herramienta de <b>administración</b>
                de las carteras de inversión de los fondos y de <b>cálculo</b> de los valores de
                cuotaparte.
            </td>
        </tr>
        <tr>
            <td align="left">
                Lleva la <b>contabilidad</b> y facilita el cumplimiento de las <b>normas</b> establecidas
                por el <b>organismo de fiscalización</b> y de los <b>reglamentos de gestión</b>.
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top: 20px">
                <asp:Image ID="Image2" runat="server" ImageUrl="Imagenes/CedFCI-EsquemaProceso.jpg" />
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 20px; font-size: 14px; font-weight: bold">
                Beneficios de la solución
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                • <b>Calcula los valores de cuotaparte</b> de las clases emitidas para todos los fondos, en forma automática.
            </td>
        </tr>
        <tr>
            <td align="left">
                • <b>Facilita el ingreso de novedades</b> (operaciones, cierres de cambio, precios, tasas de cuentas remuneradas, suscripciones y rescates, etc).
            </td>
        </tr>
        <tr>
            <td align="left">
                • <b>Facilita la configuración de datos básicos</b> (fondos, clases, fees de administración, plan de cuentas, especies, entidades, monedas, etc).
            </td>
        </tr>
        <tr>
            <td align="left">
                • Provee un repositorio único, para facilitar la <b>administración centralizada</b>, pero, manteniendo la <b>independencia de cada fondo</b>.
            </td>
        </tr>
        <tr>
            <td align="left">
                • Confiere una mayor <b>uniformidad</b> en el tratamiento de la información de todos los fondos.
            </td>
        </tr>
        <tr>
            <td align="left">
                • Guarda un <b>registro respaldatorio</b>, absolutamente pormenorizado, <b>de cada ValorCP</b> calculado.
            </td>
        </tr>
        <tr>
            <td align="left">
                • <b>Reduce la carga operativa</b>, y el riesgo de cometer errores de transcripción, al disponer de opciones automáticas de captura de precios de especies de TVs y de SyRs, y de publicación de ValorCPs, en el Sistema de Títulos.
            </td>
        </tr>
        <tr>
            <td align="left">
                • Mantiene toda la <b>información histórica</b>, sin descuidar la performance de acceso a datos operativos.
            </td>
        </tr>
        <tr>
            <td align="left">
                • Registra toda la actividad de los usuarios y de los administradores de seguridad en <b>Logs de auditoria</b>.
            </td>
        </tr>
        <tr>
            <td align="left">
                • <b>Workflow parametrizable</b>: que soporta todas las acciones sobre el proceso, operaciones, precios, cierres de cambio, etc.; en el que se define la cantidad y jerarquía de funcionarios intervinientes y si exige control por oposición.
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 20px; font-size: 14px; font-weight: bold">
                Características principales
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 15px">
                <table border="0" cellpadding="5px" cellspacing="0" style="border-style: solid; border-width: 1px;
                    border-color: #CD853F">
                    <tr>
                        <td align="center" style="width: 80px; border-style: solid; border-width: 1px; border-color: #CD853F"
                            valign="middle">
                            Tablero<br />
                            de<br />
                            control
                        </td>
                        <td style="border-style: solid; border-width: 1px; border-color: #CD853F" valign="top">
                            El Tablero de control es el front-end principal de la aplicación.&nbsp;&nbsp;&nbsp;En
                            él se destacan tres paneles.&nbsp;&nbsp;&nbsp;El panel de <b>Proceso diario</b>
                            sirve para guiar al usuario en el trabajo diario (permite saber rapidamente en qué
                            estado está el proceso, cuál es el próximo paso que debe darse y cuáles son las
                            tareas pendientes, en términos de cálculo de valores de cuotaparte).&nbsp;&nbsp;&nbsp;El
                            panel de <b>Opciones</b> permite acceder a todas las funcionalidades del sistema
                            (para ver más detalles, descargue la presentación).&nbsp;&nbsp;&nbsp;El panel de
                            <b>Notificaciones</b> sirve para desplegar avisos del sistema (se hace visible sólo
                            cuando es imprescindible).
                        </td>
                        <td style="border-style: solid; border-width: 1px; border-color: #CD853F; width: 200px">
                            <asp:Image ID="Image5" runat="server" ImageAlign="Right" ImageUrl="Imagenes/CedFCI-Tablero_ch.jpg"
                                Width="200px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="border-style: solid; border-width: 1px; border-color: #CD853F"
                            valign="middle">
                            Proceso<br />
                            diario
                        </td>
                        <td colspan="2" style="border-style: solid; border-width: 1px; border-color: #CD853F">
                            Representa una guía para la actividad diaria, en términos de:<br />
                            <br />
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top">
                                        •</td>
                                    <td style="padding-left: 5px">
                                        <b>Incorporación de novedades</b> (operaciones, cierres de cambio, precios, tasas
                                        de cuentas remuneradas, suscripciones y rescates de cuotapartes).
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        •</td>
                                    <td style="padding-left: 5px">
                                        <b>Revalúo de carteras</b> (devengado de intereses de colocaciones a plazo y sobre
                                        saldos de cuentas remuneradas, revalúo de titulos valores, ajustes por diferencia
                                        de cambio).
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        •</td>
                                    <td style="padding-left: 5px">
                                        Cálculo / liquidación de <b>honorarios administrativos</b> de las sociedades Gerente
                                        y Depositaria.
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        •</td>
                                    <td style="padding-left: 5px">
                                        Cálculo de los <b>valores de cuotaparte</b> de la(s) clase(s) emitida(s) para cada
                                        fondo.
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        •</td>
                                    <td style="padding-left: 5px">
                                        Incorporación de <b>Suscripciones y Rescates</b> valorizados.
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        •</td>
                                    <td style="padding-left: 5px">
                                        Confirmación y <b>publicación</b> de los valores de cuotapartes calculados.
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        •</td>
                                    <td style="padding-left: 5px">
                                        <b>Cierre diario</b> (que desencadena también el proceso de Apertura del siguiente
                                        día hábil y, cuando corresponde, los procesos de Cierre de Ejercicio y Depuración).
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        •</td>
                                    <td style="padding-left: 5px">
                                        En el proceso de <b>Apertura</b>, con el que arranca cada nuevo día, se liquidan
                                        los vencimientos pendientes, de pago o cobro, en forma automática (Ej.: rescates
                                        a pagar, compra de acciones a pagar, venta de acciones a cobrar).
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="border-style: solid; border-width: 1px; border-color: #CD853F"
                            valign="middle">
                            Incorporación<br />
                            de<br />
                            novedades
                        </td>
                        <td colspan="2" style="border-style: solid; border-width: 1px; border-color: #CD853F">
                            <b>Operaciones</b><br />
                            El sistema permite el ingreso de operaciones (aquellas que surgen de las decisiones
                            tomadas por los administradores de las carteras de los fondos). Todas las operaciones
                            contienen tanto información operativa como contable.<br />
                            Hay un workflow parametrizable, mediante el cuál se establece el esquema de permisos
                            (de usuarios) necesarios para la invocación de cada evento: alta, autorización,
                            anulación, etc. Asimismo se puede definir qué eventos exigen control por oposición.
                            Este mismo esquema se aplica, cada uno con su propia configuración, a: Cierres de
                            Cambio, Precios, Tasas y opciones de Proceso.
                            <br />
                            <b>Cierres de cambio</b><br />
                            A los efectos de la conversión de importes entre distintas monedas (del fondo, de
                            la cuenta, en moneda local, etc.), el sistema permite el ingreso de cierres de cambio
                            de las monedas extranjeras que se consignen. Registra un cierre por moneda y por
                            día, que es el que usa para hacer los ajustes por diferencia de cambio.
                            <br />
                            <b>Precios</b><br />
                            A los efectos de la valorización de las tenencias de títulos valores a precio de
                            realización, el sistema permite el ingreso de precios de las especies que se consignen.
                            Registra un precio por especie y por día, que es el que usa para hacer el revalúo
                            de estos activos. También dispone de una opción para una captura automática de precios,
                            desde un servicio de Reuters. Esta captura se podrá realizar en distintas etapas
                            (ver Etapas de captura) de acuerdo a la disponibilidad de precios a lo largo del
                            día (Bolsa de Buenos Aires, Bolsa de New York, MAE, etc).
                            <br />
                            <b>Tasas de cuentas remuneradas</b><br />
                            A los efectos del cálculo de los intereses devengados, sobre los saldos de las cuentas
                            remuneradas, el sistema permite el ingreso de las distintas tasas de interés vigentes,
                            para cada período, para cada cuenta remunerada.
                            <br />
                            <b>Suscripciones y rescates de fondos</b><br />
                            Para registrar el impacto que las suscripciones y rescates, tienen sobre los patrimonios
                            de los fondos, el sistema debe disponer del detalle de operaciones de SyR del día.
                            Esta información la obtiene, mediante una interfaz, desde el Sistema de Títulos
                            (Sociedad Depositaria).<br />
                            Considerando el hecho de que esta información no está disponible, en todo momento,
                            en su estado definitivo, el sistema admite la posibilidad de obtener datos provisorios
                            y, por último, realizará una lectura definitiva.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="border-style: solid; border-width: 1px; border-color: #CD853F"
                            valign="middle">
                            Consultas<br />
                            y<br />
                            Reportes
                        </td>
                        <td colspan="2" style="border-style: solid; border-width: 1px; border-color: #CD853F">
                            <b>Valores CPs</b><br />
                            El reporte de valores de cuotaparte, muestra los valores calculados para cada clase
                            de cada fondo solicitado. También permite obtener un detalle mayor, llamado “Determinación
                            de valor de cuotaparte”.
                            <br />
                            <b>Cartera</b> (Posición)<br />
                            En el reporte de Cartera se muestra el saldo de cada cuenta, en moneda del fondo
                            y en moneda local, de cada fondo solicitado. En algunos productos de inversión (plazos
                            fijos, cauciones, tenencia de titulos valores, cuentas bancarias, vencimientos a
                            pagar o cobrar) se incluye una apertura más detallada.
                            <br />
                            <b>Tenencia de Titulos Valores</b><br />
                            En el reporte de Tenencia de Títulos Valores se muestran todas las especies que
                            forman parte de la cartera de un fondo. Se consignan: la cantidad de valores nominales,
                            el precio, el importe total, el costo promedio ponderado y la participación de la
                            especie, tanto en el total de los títulos valores como en el patrimonio completo
                            del fondo.
                            <br />
                            <b>Variación de ValorCPs</b><br />
                            Determina diariamente la variación porcentual del valor de cuotaparte respecto del
                            día hábil anterior y del primer día hábil del mes. Advierte cuando la variación
                            está por encima del tope definido.
                            <br />
                            <b>Detalle de Plazos Fijos y Cauciones</b><br />
                            Muestra el detalle específico de los plazos fijos y cauciones, vigentes a la fecha
                            solicitada, en la cartera de los fondos.
                            <br />
                            <b>Cash Flow</b><br />
                            Permite establecer el flujo de caja, de cada fondo solicitado, en el período seleccionado.
                            Es la proyección financiera de ingresos y egresos del fondo, a lo largo del período
                            solicitado. Los conceptos de ingresos / egresos, no son fijos sino que se parametrizan,
                            asi como también los rubros tributarios de dichos conceptos.
                            <br />
                            <b>Contables</b> (Balance de Saldos, Diario, Mayor)<br />
                            Permite la emisión de informes contables para cada fondo. Conserva toda la información
                            histórica, pero los datos del ejercicio actual se encuentran en una "partición"
                            propia para permitir que la actividad operativa diaria sea más performante.
                            <br />
                            <b>Auditoria</b> (Log de actividad)<br />
                            Permite a los auditores acceder al Log de actividad de los usuarios. Esta actividad
                            es registrada, automáticamente por el sistema, cada vez que un usuario desencadena
                            un evento relacionado a: Operaciones, Cierres de cambio, Precios, Proceso y Tasas
                            de cuentas remuneradas. El sistema registra, en cada uno de estos casos, la siguiente
                            información: fecha y hora del evento, identificación del usuario, el comentario
                            que se haya ingresado, la identificación del evento y del estado resultante de dicho
                            evento.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="border-style: solid; border-width: 1px; border-color: #CD853F"
                            valign="middle">
                            Gráficos
                        </td>
                        <td colspan="2" style="border-style: solid; border-width: 1px; border-color: #CD853F">
                            <b>Evolución de ValorCPs</b><br />
                            Permite percibir, de una manera mas rápida e intuitiva, la evolución, a lo largo
                            del tiempo, del valor de cuotaparte de los fondos. Se puede optar por graficar:
                            a) los valores de cuotaparte, b) las variaciones porcentuales diarias de los valores
                            de cuotaparte. Y, en ambos casos, elegir uno o más fondos.
                            <br />
                            <b>Evolución del Patrimonio Neto</b><br />
                            Permite percibir la evolución, a lo largo del tiempo, del Patrimonio Neto de uno
                            o más fondos. Se puede solicitar tanto en pesos como en dólares.
                            <br />
                            <b>Composición de Cartera</b><br />
                            Muestra la composición de la cartera de un fondo a través de conceptos de agrupamiento
                            definidos a tal efecto.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="border-style: solid; border-width: 1px; border-color: #CD853F"
                            valign="middle">
                            Configuración<br />
                            de<br />
                            datos básicos
                        </td>
                        <td colspan="2" style="border-style: solid; border-width: 1px; border-color: #CD853F">
                            <b>FCIs</b><br />
                            Es la definición de cuáles son los fondos que se administran, qué clases de cuotapartes
                            se han emitido para cada fondo, cuáles son los fees de administración (vigentes
                            a cada momento) y cuáles son sus calificaciones de riesgo. Tambien se consignan
                            datos inherentes al proceso de cálculo de cuotapartes (etapa de cálculo, tipo de
                            precio), a la generación de interfaces y a la contabilidad.<br />
                            En cualquier momento se pueden agregar nuevos fondos o dar de baja fondos vigentes.
                            <br />
                            <b>Especies de Titulos Valores</b><br />
                            Es la definición de las especies que podrán invocarse a la hora de registrar operaciones
                            de Titulos Valores. Se consigna información de identificación y de clasificación,
                            se especifica el mercado relevante y también datos inherentes a la generación de
                            interfaces.
                            <br />
                            <b>Etapas de cálculo</b><br />
                            En el proceso de revaluo de carteras y cálculo de valor de cuotaparte, algunos fondos
                            pueden ser tratados antes que otros, de acuerdo a la disponibilidad de información.
                            A los efectos de organizar esta tarea repetitiva, se pueden establecer etapas de
                            cálculo. Cada fondo será tratado en la etapa que se haya definido (ver FCIs).
                            <br />
                            <b>Etapas de captura de precios</b><br />
                            Se puede definir en qué momento el sistema estará en condiciones de capturar qué
                            precios. Esto se llama etapa de captura. Ejemplo: 1) cierre de la Bolsa de Buenos
                            Aires, 2) Cierre de la Bolsa de New York, 3) Cierre del Mercado Abierto Electrónico,
                            etc.
                            <br />
                            <b>Plan de cuentas</b><br />
                            Se define un plan de cuentas único, en el que habrá cuentas de uso general y otras
                            de uso exclusivo para cada fondo. Representa una definición de naturaleza contable
                            y, más importante aún, en términos de instrumentos de inversión.<br />
                            Como el sistema no conoce el plan de cuentas, pero deberá estar en condiciones de
                            generar operaciónes automáticas, será necesario establecer algunas relaciones (entre
                            cuentas) y algunas referencias (a conceptos simbólicos que el sistema maneja).
                            <br />
                            <b>Alícuotas</b><br />
                            Se pueden modificar todas las alícuotas que el sistema tendrá en cuenta a la hora
                            de la generación de operaciones. Ejemplos: 1) impuesto al valor agregado, 2) gastos
                            por compra / venta de titulos valores.
                            <br />
                            <b>Alarmas</b><br />
                            Se pueden fijar límites para que el sistema sepa cuándo emitir ciertos avisos. Ejemplos:
                            1) tope de variación diaria de Valor de cuotaparte, 2) tope de vida promedio.
                            <br />
                            <b>Entidades, Mercados, Monedas, etc.</b><br />
                            Todos los elementos accesorios que ayuden a describir/definir: fondos, cuentas,
                            especies, cierres de cambio, precios, operaciones; tienen un front-end de ingreso
                            para que el usuario pueda ingresarlos y mantenerlos.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="border-style: solid; border-width: 1px; border-color: #CD853F"
                            valign="middle">
                            Interfaces
                        </td>
                        <td colspan="2" style="border-style: solid; border-width: 1px; border-color: #CD853F">
                            Genera las interfaces para la CAFCI (diaria, semanal y mensual), para la CNV y para
                            el copiado de libros contables.
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="border-style: solid; border-width: 1px; border-color: #CD853F"
                            valign="middle">
                            Tecnología
                        </td>
                        <td colspan="2" style="border-style: solid; border-width: 1px; border-color: #CD853F">
                            • Cliente/Servidor en tres capas<br />
                            • Workflow basado en datos<br />
                            • Desarrollado en c# (WinForms)<br />
                            • Instalador MSI con control de versión<br />
                            • Motor de base de datos relacional
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 10px">
                <asp:HyperLink ID="CedSTpresentacionHyperLink" runat="server" NavigateUrl="~/Descarga.aspx?archivo=Cedeira-SistAdminFCIs.pdf"
                    SkinID="LinkMedianoClaro">Descargar presentación</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 24px; padding-top: 20px">
                <asp:Button ID="SolucionesButton" runat="server" TabIndex="1" Text="Soluciones" onclick="SolucionesButton_Click" />
                <asp:Button ID="RefeComButton" runat="server" CausesValidation="false" TabIndex="1" Text="Referencias Comerciales" onclick="RefeComButton_Click" />
                <asp:Button ID="EmpresaButton" runat="server" TabIndex="1" Text="Empresa" onclick="EmpresaButton_Click" />
                <asp:Button ID="ContactoButton" runat="server" CausesValidation="false" TabIndex="3" Text="Contacto" onclick="ContactoButton_Click"  />
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-bottom: 30px; padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
