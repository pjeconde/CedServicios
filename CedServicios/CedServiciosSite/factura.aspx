<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="factura.aspx.cs" Inherits="CedServicios.Site.factura" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>
<!--[if IE 8]><html class="no-js lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]>
<!--><html class="no-js" lang="en"><!--<![endif]-->
<head>
	<!-- Basic Page Needs ================================================== -->
	<meta charset="utf-8">
	<title>Cedeira Software Factory</title>
	<meta name="description" content="">
	<meta name="author" content="">

	<!-- Mobile Specific Metas ================================================== -->
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
	
	<!-- CSS ================================================== -->
	<link rel="stylesheet" href="css/base.css"/>
	<link rel="stylesheet" href="css/skeleton.css"/>
	<link rel="stylesheet" href="css/layout.css"/>
	<link rel="stylesheet" href="css/settings.css"/>
	<link rel="stylesheet" href="css/font-awesome.css" />
	<link rel="stylesheet" href="css/owl.carousel.css"/>
	<link rel="stylesheet" href="css/retina.css"/>
	<link rel="stylesheet" href="css/colorbox.css"/>
	<link rel="stylesheet" href="css/animsition.min.css"/>
	<link rel="stylesheet" type="text/css" href="css/custom.css" >
	<link rel="alternate stylesheet" type="text/css" href="css/colors/color-gold.css" title="1">	
		
	<!-- Favicons ================================================== -->
	<link rel="shortcut icon" href="favicon.png">
	<link rel="apple-touch-icon" href="apple-touch-icon.png">
	<link rel="apple-touch-icon" sizes="72x72" href="apple-touch-icon-72x72.png">
	<link rel="apple-touch-icon" sizes="114x114" href="apple-touch-icon-114x114.png">
</head>
<body>
    
    <form id="form1" runat="server" visible="true">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
	</form>
    <!-- Primary Page Layout ================================================== -->
	<div class="animsition">

		
    <!-- MENU ================================================== -->	
	<div class="header-top">
		<header class="cd-main-header">
			<a class="cd-logo animsition-link" href="index.html"><img src="images/logo.svg" alt="Cedeira"></a>

			<ul class="cd-header-buttons">
				
				<li><a class="cd-nav-trigger" href="#cd-primary-nav"><span></span></a></li>
			</ul> <!-- cd-header-buttons -->
		</header>
        <nav class="cd-nav">
            <ul id="cd-primary-nav" class="cd-primary-nav is-fixed">
                <li>
                    <a href="about-1.html">Quiénes somos</a>
                </li>
                <li class="has-children">
                    <a href="#">Servicios</a>
                    <ul class="cd-nav-gallery servicios is-hidden">
                        <li>
                            <div class="services-boxes-1">
                                <div class="icon-box">&#xf1b3;</div>
                                <h6><a href="desarrollos.html">DESARROLLOS A MEDIDA</a></h6>
                            </div>
                        </li>
                        <li>
                            <div class="services-boxes-1">
                                <div class="icon-box">&#xf085;</div>
                                <h6><a href="sf.html">SOFTWARE FACTORY</a></h6>
                            </div>
                        </li>
                        <li>
                            <div class="services-boxes-1">
                                <div class="icon-box">&#xf0ed;</div>
                                <h6><a href="factura.aspx">FACTURA ELECTRONICA</a></h6>
                            </div>
                        </li>
                        <li>
                            <div class="services-boxes-1">
                                <div class="icon-box">&#xf0c0;</div>
                                <h6>
                                    <a href="personalit.html">PERSONAL IT</a>
                                    <ul class="menumini">
                                        <li><a href="personalitR.html">Recruiting</a></li>
                                        <li><a href="personalitO.html">Outsourcing</a></li>
                                    </ul>
                                </h6>
                            </div>
                        </li>
                    </ul>
                </li>
                <li class="has-children">
                    <a href="#">Productos</a>
                    <ul class="cd-nav-gallery is-hidden">
                        <li>
                            <a class="cd-nav-item animsition-link" href="transferencias.html">
                                <img src="images/portfolio/1.jpg" alt="Product Image">
                                <h3>Sistema de Transferencias "implementación BCRA"</h3>
                            </a>
                        </li>
                        <li>
                            <a class="cd-nav-item animsition-link" href="contenidos.html">
                                <img src="images/portfolio/2.jpg" alt="Product Image">
                                <h3>Sistema de Administración y Presentación de Contenidos</h3>
                            </a>
                        </li>
                        <li>
                            <a class="cd-nav-item animsition-link" href="tasas.html">
                                <img src="images/portfolio/3.jpg" alt="Product Image">
                                <h3>Sistema de Carga Centralizada de Tasas</h3>
                            </a>
                        </li>
                        <li>
                            <a class="cd-nav-item animsition-link" href="fondos.html">
                                <img src="images/portfolio/4.jpg" alt="Product Image">
                                <h3>Sistema de Administración de Fondos Comunes de Inversión</h3>
                            </a>
                        </li>
                        <li>
                            <a class="cd-nav-item animsition-link" href="inversiones.html">
                                <img src="images/portfolio/5.jpg" alt="Product Image">
                                <h3>Plataforma de inversiones</h3>
                            </a>
                        </li>
                        <li>
                            <a class="cd-nav-item animsition-link" href="stock.html">
                                <img src="images/portfolio/6.jpg" alt="Product Image">
                                <h3>Gestión de Stock de Servicios y Tarjetas</h3>
                            </a>
                        </li>
                    </ul>
                </li>
                <li>
                    <a href="tech.html" class="animsition-link">Tecnología</a>
                </li>
                <li>
                    <a href="index.html#scroll-link-4" class="animsition-link">clientes</a>
                </li>
                <li>
                    <a href="contact.html" class="animsition-link">Contacto</a>
                </li>
                <li>
                    <a href="factura.aspx" class="animsition-link">Ingresar</a>
                </li>
            </ul>
            <!-- primary-nav -->
        </nav>
        <!-- cd-nav -->
    </div>
	
	<main class="cd-main-content">
	
	<!-- TOP SECTION ================================================== -->
	
		<section class="section parallax-section parallax-section-padding-top-bottom-home">
		
			<div class="parallax-factura"></div>
		
			<div class="container">
				<div class="sixteen columns">
					<div class="section-title left">
						<div class="subtitle left big">Información sobre</div>
						<h1>Facturación electrónica</h1>
						
					</div>
				</div>
			</div>
				
		</section>	
		
	    <section class="section" id="scroll-link">
			<div class="call-to-action-2">
				<div class="container">
					<div class="sixteen columns">
						<h6>Este sitio le permite generar Facturas Electrónicas propias para gestionar el CAE a través de AFIP o InterFacturas (la red de facturas electrónicas de InterBanking).</h6>
					</div>
				</div>
			</div>
		</section>	

        <!-- LOGIN SECTION ================================================== -->
        <section runat="server" id="formlogin" class="section footer-1 section-padding-top-bottom" style="background: #3bb2df">
            <div class="container" style="text-align: center">
                <div class="sixteen columns">
                    <div class="section-title">
                        <h3>Login</h3>
                    </div>
                </div>
                <div class="clear"></div>
                <form name="ajax-form" id="ajax-form" method="post">
                    <div class="eight columns">
                        <label for="">
                            <span class="error" id="err-name">Usuario</span>
                        </label>
                        <input name="UsuarioTextBox" id="UsuarioTextBox" type="text" placeholder="Usuario">
                    </div>
                    <div class="eight columns">
                        <label for="">
                            <span class="error" id="err-email">Contraseña</span>
                        </label>
                        <input type="password" autocomplete="off" name="PasswordTextBox" id="PasswordTextBox" placeholder="Contraseña">
                    </div>
                    <div class="sixteen columns">
                        <div id="button-con">
                            <button class="send_message" id="LoginButton" name="LoginButton" value="LoginButton">LOGIN</button>
                            <%--<button runat="server" class="send_message" id="LoginButton" onclick="javascript:LlamadaButton('LoginButton', '')">LOGIN</button>--%>
                        </div>
                    </div>
                    <div class="sixteen columns">
                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text="&nbsp;"></asp:Label>
                    </div>
                    <div class="sixteen columns">
                        <p style="text-align: center"><a href="UsuarioCrear.aspx">Crear una nueva cuenta </a>- <a href="UsuarioOlvidoId.aspx">¿Olvidó su Id.Usuario?</a> - <a href="UsuarioOlvidoPassword.aspx">¿Olvidó su Contraseña?</a></p>
                    </div>
                    <div class="clear"></div>
                </form>
                <div class="clear"></div>
            </div>
        </section>
        
        <!-- LOGIN SECTION ================================================== -->
        <section runat="server" id="formLoginActivo" class="section footer-1 section-padding-top-bottom" style="background: #3bb2df" visible="false">
            <div class="container" style="text-align: center">
                <div class="sixteen columns">
                    <div class="section-title" style="padding:0">
                        <h3>Login</h3>
                    </div>
                </div>
                <div class="sixteen columns" style="">
                    <asp:Label ID="MensajeSesionActivaLabel" runat="server" SkinID="MensajePagina" ForeColor="White" Text="La sesión esta activa."></asp:Label>
                </div>
                <div class="row" style="display: inline-block; padding:0; margin:0">
                    <div class="four columns" style="display: inline-block; vertical-align:top">
                        <button class="send_message" id="ContinuarButton" onclick="window.open('default.aspx', '_self');">CONTINUAR OPERANDO</button>
                        <button class="send_message" id="SalirButton" onclick="window.open('factura.aspx?login=salir', '_self');">SALIR</button>
                    </div>
                </div>
            </div>
        </section>

		<!-- INFORMACION ================================================== -->	
	    <section class="section grey-section section-padding-top-bottom">
            <div class="container">
                <div class="twelve columns">
                    <div class="section-title">
                        <h3>INFORMACION</h3>
                    </div>
                </div>
                <div class="six columns">
                    <div class="cd-product cd-container">
                        <div class="right" data-scroll-reveal="enter left move 200px over 1s after 0.3s">
                            <img src="images/factura.jpg" alt="Software Factory">
                        </div>
                        <!-- .cd-product-wrapper -->
                    </div>
                    <!-- .cd-product -->
                </div>
                <div class="six columns">
                    <div class="" data-scroll-reveal="enter right move 200px over 1s after 0.3s" data-scroll-reveal-id="2" data-scroll-reveal-initialized="true" data-scroll-reveal-complete="true">
                        <p>
                            Si Ud. ya cuenta con un sistema de facturación, o utiliza una planilla Excel como herramienta de facturación y desea integrarlo al Régimen de Factura Electrónica, podemos ofrecerles diversas soluciones.

Soporta los siguientes tipos de Factura Electrónica:
                        <ul>
                            <li>• Común (RG.2485 / RG.2904), </li>
                            <li>• Bono Fiscal (Bienes de Capital)</li>
                            <li>• Exportación (RG.2758/2010) </li>
                            <li>• Turismo (RG.3971)</li>
                        </ul>
                        </p>
                        <p>Entorno Multi-CUIT, Multi-Unidad de Negocio, Multi-Usuario.</p>

                        <p>Cargue de manera rápida, fácil y segura su Factura Electrónica con nuestro Servicio Web. Facilitamos el cumplimiento del régimen normativo de la AFIP.</p>

                        <p>Para mas detalles sugerimos que se comuniquen desde Contacto o bien escribiendonos a contacto@cedeira.com.ar </p>
                        <p>ctividades alcanzadas por el Régimen de Factura Electrónica | Preguntas frecuentes</p>


                    </div>
                </div>
            </div>
        </section>
	
        <!-- TOP SECTION ================================================== -->
		<section class="section white-section section-home-padding-top">
			<div class="container">
				<div class="sixteen columns">
					<div class="section-title left">
						<h2>Régimen General</h2>
						<div class="subtitle left"></div>
					</div>
				</div>
			</div>
				
		</section>	

	    <!-- SECTION ================================================== -->
        <section class="section grey-section section-padding-top-bottom" id="tabs">
            <div class="container">
                <div class="sixteen columns">
                    <div class="shortcodes-carousel">
                        <div id="sync-sortcodes-1" class="owl-carousel">
                            <div class="item white-section">
                                <h6>Comprobantes alcanzados</h6>
                                <ul>

                                    <li>Facturas y Recibos clase “A”, “A” con la leyenda “PAGO EN C.B.U. INFORMADA” y/o “M”.</li>
                                    <li>Facturas y Recibos clase “B”.</li>
                                    <li>Facturas y Recibos clase “C”.</li>
                                    <li>Facturas y Recibos clase “E”.</li>
                                    <li>Facturas clase “T”.</li>
                                    <li>Notas de crédito y notas de débito clase “A”, “A” con la leyenda “PAGO EN C.B.U. INFORMADA” y/o “M”.</li>
                                    <li>Notas de crédito y notas de débito clase “B”.</li>
                                    <li>Notas de crédito y notas de débito clase “C”.</li>
                                    <li>Notas de crédito y notas de débito clase “E”.</li>
                                    <li>Notas de crédito y notas de débito clase “T”.</li>
                                </ul>
                                <h6>Comprobantes excluídos</h6>
                                Quedan excluidos del presente régimen:
                                <ul>
                                    <li>
                                    Los comprobantes emitidos por aquellos sujetos que realicen operaciones que requieren un tratamiento especial en la emisión de comprobantes, según lo dispuesto en el Anexo IV de la RG 1415/03, (agentes de bolsa y de mercado abierto, concesionarios del sistema nacional de aeropuertos, servicios prestados por el uso de aeroestaciones correspondientes a vuelos de cabotaje e internacionales, distribuidores de diarios, revistas y afines, etc.).
                                    <li>
                                    Las facturas o documentos equivalentes emitidos por los sujetos indicados en el Apartado A del Anexo I de la RG 1415/03, respecto de las operaciones allí detalladas, en tanto no se encuentren en las situaciones previstas en el Apartado B del mismo Anexo I.
                                    <li>
                                    Los comprobantes y documentos fiscales emitidos mediante “Controlador Fiscal”, y las notas de crédito emitidas por medio de dicho equipamiento como documentos no fiscales homologados y/o autorizados.
                                    <li>
                                    Los documentos equivalentes emitidos por entidades o sujetos especialmente autorizados por esta Administración Federal y/o la “Liquidación Primaria de Granos”.
                                </ul>
                                <h6>Aclaración</h6>
                                La obligación de emisión de los comprobantes electrónicos, no incluye a las operaciones, no realizadas en el local, oficina o establecimiento, cuando la facturación se efectúa en el momento de la entrega de los bienes o prestación del servicio objeto de la transacción, en el domicilio del cliente o en un domicilio distinto al del emisor del comprobante.

Por ejemplo operaciones que se realicen a domicilio (ej. Plomeros) ó por ruteo.</p>
                            </div>
                            <div class="item white-section">
                                <h6>Sujetos obligados</h6>
                                Los siguientes sujetos se encuentran obligados a utilizar el régimen de factura electrónica:
                                <ul>
                                    <li>
                                    Sujetos Monotributistas: Quienes se encuentren inscriptos en las categorías H, I, J, K y L. Aquellos sujetos que sean Monotributistas por los comprobantes emitidos al Sector Público Nacional – que requieran Certificado Fiscal para Contratar con el Estado-.
                                    <li>Sujetos Responsables Inscriptos en el Impuesto al Valor Agregado: Todos</li>
                                    <li>Sujetos, cualquiera sea su condición frente al IVA, que:</li>
                                    <li>desarrollen alguna de las actividades comprendidas en el Título III de la RG 3749/15</li>
                                    <li>sean exportadores por la RG 2758.</li>
                                    <li>sean comercializadores de Bienes Usados No Registrables (RG 3411</li>
                                    <li>Sujetos exceptuados</li>
                                    <li>Quienes realicen operaciones a domicilio (ej. Plomeros) y por ruteo.</li>
                                </ul>
                                <h6>Sujetos excluidos</h6>
                                Quienes se encuentren obligados a utilizar Controlador Fiscal.</p>
                            </div>
                            <div class="item white-section">
                                <h6>Contribuyentes alcanzados Regímenes Especiales</h6>
                                Los contribuyentes obligados por Regímenes Especiales a emitir comprobantes electrónicamente, en caso de corresponder, deben informar a este Organismo, con una antelación de 5 días hábiles administrativos, la fecha a partir de la cual comenzarán a emitir dichos comprobantes. La comunicación se realizará mediante la página web de AFIP (www.afip.gob.ar), ingresando con clave fiscal al servicio “Regímenes de Facturación y Registración (REAR/RECE/RFI)”.

La incorporación del contribuyente será publicada en la página web de AFIP (www.afip.gov.ar).


                                <h6>Contribuyentes alcanzados por la Resolución General N° 3749/15</h6>
                                Los contribuyentes alcanzados por la obligación de emitir sus comprobantes electrónicos no deben realizar empadronamiento para comenzar a emitir factura electrónica.


                                <h6>Aclaración</h6>
                                En todos los casos, previo a la emisión de los comprobantes, deberán habilitar él/los punto/s de venta destinados a tal efecto.
						
                            </div>
                        </div>
                        <div id="sync-sortcodes-2" class="owl-carousel">
                            <div class="item">
                                <h6>Comprobantes</h6>
                            </div>
                            <div class="item">
                                <h6>Sujetos</h6>
                            </div>
                            <div class="item">
                                <h6>Incorporación al régimen</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <!-- FOOTER ================================================== -->
        <section class="section footer-1 section-padding-top-bottom" id="scroll-link-5">
            <div class="container">

                <div class="five columns" data-scroll-reveal="enter left move 200px over 0.5s after 0.3s">
                    <a href="index.html" class="animsition-link"><div class="logo-footer"></div></a>
                    <h6><i class="icon-footer">&#xf041;</i>Argentina</h6>
                    <p style="color: #fff">
                        Torre Bellini, Esmeralda 950, Piso 19, Of. 105, CABA<br />
                        +5411 4778-1744
                    </p>
                    <p><i class="icon-footer"></i><a href="mailto:contacto@cedeira.com.ar" title="">contacto@cedeira.com.ar</a></p>
                    <p><a href="https://www.facebook.com/CedeiraSF" title="" target="_new"><i class="icon-social">&#xf082;</i></a><a href="https://twitter.com/cedeirasf" title="" target="_new"><i class="icon-social">&#xf081;</i></a><a href="https://www.linkedin.com/company/cedeirasf/" title="" target="_new"><i class="icon-social">&#xf08c;</i></a></p>
                </div>
                <div class="eleven columns" data-scroll-reveal="enter right move 200px over 0.5s after 0.3s">
                    <div class="container" style="width: 100%">
                        <div class="sixteen columns">
                            <div class="section-title">
                                <h3>En contacto</h3>
                            </div>
                        </div>
                        <div class="clear"></div>
                        <form name="ajax-form" id="ajax-form" action="mail-it.php" method="post">
                            <div class="eight columns">
                                <input name="name" id="name" type="text" placeholder="Nombre: *" />
                                <label for="name">
                                    <span class="error" id="err-name">Por favor escriba su nombre</span>
                                </label>
                            </div>
                            <div class="eight columns">
                                <input name="email" id="email" type="text" placeholder="E-Mail: *" />
                                <label for="email">
                                    <span class="error" id="err-email">Por favor escriba su email</span>
                                    <span class="error" id="err-emailvld">Formato de email inválido</span>
                                </label>

                            </div>
                            <div class="sixteen columns">

                                <textarea name="message" id="message" placeholder="Su mensaje"></textarea>
                                <label for="message"></label>
                            </div>
                            <div class="sixteen columns">
                                <div id="button-con"><button class="send_message" id="send">ENVIAR</button></div>
                            </div>
                            <div class="clear"></div>
                            <div class="error text-align-center" id="err-form">Hubo un problema con los datos del formulario, por favor verifique!</div>
                            <div class="error text-align-center" id="err-timedout">No se puede conectar al servidor. Intente nuevamente en unos momentos.</div>
                            <div class="error" id="err-state"></div>
                        </form>

                        <div class="clear"></div>

                        <div id="ajaxsuccess">Enviado con éxito!</div>
                    </div>
                </div>
            </div>
        </section>
        <div id="indexpie"></div>
	</main>		

	<div class="scroll-to-top">&#xf106;</div>

	</div>

	<!-- JAVASCRIPT
    ================================================== -->
<script type="text/javascript">
    function LlamadaButton(parametro) {
        __doPostBack('LoginButton', parametro)
    }
</script>

<script type="text/javascript" src="js/jquery-2.1.1.js"></script>
<script type="text/javascript" src="js/modernizr.custom.js"></script> 
<script type="text/javascript" src="js/jquery.mobile.custom.min.js"></script>
<script type="text/javascript" src="js/retina-1.1.0.min.js"></script>	
<script type="text/javascript" src="js/jquery.animsition.min.js"></script>
<script type="text/javascript">
(function($) { "use strict";
	$(document).ready(function() {
	  
	  $(".animsition").animsition({
	  
		inClass               :   'zoom-in-sm',
		outClass              :   'zoom-out-sm',
		inDuration            :    1500,
		outDuration           :    800,
		linkElement           :   '.animsition-link', 
		// e.g. linkElement   :   'a:not([target="_blank"]):not([href^=#])'
		loading               :    true,
		loadingParentElement  :   'body', //animsition wrapper element
		loadingClass          :   'animsition-loading',
		unSupportCss          : [ 'animation-duration',
								  '-webkit-animation-duration',
								  '-o-animation-duration'
								],
		//"unSupportCss" option allows you to disable the "animsition" in case the css property in the array is not supported by your browser. 
		//The default setting is to disable the "animsition" in a browser that does not support "animation-duration".
		
		overlay               :   false,
		
		overlayClass          :   'animsition-overlay-slide',
		overlayParentElement  :   'body'
	  });
	});  
})(jQuery);
</script>
<script type="text/javascript" src="js/jquery.themepunch.tools.min.js"></script>   
<script type="text/javascript" src="js/jquery.themepunch.revolution.min.js"></script> 
<script type="text/javascript" src="js/jquery.easing.js"></script>	
<script type="text/javascript" src="js/jquery.hidescroll.min.js"></script>	
<script type="text/javascript">
	$('.header-top').hidescroll();
</script>
<script type="text/javascript" src="js/smoothScroll.js"></script>
<script type="text/javascript" src="js/jquery.parallax-1.1.3.js"></script>
<script type="text/javascript" src="js/jquery.counterup.min.js"></script>
<script type="text/javascript" src="js/waypoints.min.js"></script>
<script type="text/javascript" src="js/scrollReveal.js"></script>
<script type="text/javascript">
(function($) { "use strict";
      window.scrollReveal = new scrollReveal();
})(jQuery);
</script>
<script type="text/javascript" src="js/owl.carousel.min.js"></script>
<script type="text/javascript"> 
(function($) { "use strict";          
			jQuery(document).ready(function() {
				var offset = 450;
				var duration = 500;
				jQuery(window).scroll(function() {
					if (jQuery(this).scrollTop() > offset) {
						jQuery('.scroll-to-top').fadeIn(duration);
					} else {
						jQuery('.scroll-to-top').fadeOut(duration);
					}
				});
				
				jQuery('.scroll-to-top').click(function(event) {
					event.preventDefault();
					jQuery('html, body').animate({scrollTop: 0}, duration);
					return false;
				})
			});
})(jQuery);
</script>


<script type="text/javascript" src="js/contact.js"></script>

<script type="text/javascript" src="js/smk-accordion.js"></script>

<script type="text/javascript" src="js/custom-tabs.js"></script> 
<script>
    $(function () {
        $("#indexpie").load("indexPie.html");
    });
</script>  
<!-- End Document
================================================== -->
</body>
</html>