﻿<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="SessionTimeout.aspx.cs" Inherits="CedServicios.Site.SessionTimeout" Theme="CedServicios" %>

<!DOCTYPE html>
<!--[if IE 8]><html class="no-js lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]>
<!--><html class="no-js" lang="en"><!--<![endif]-->
<head runat="server">

	<!-- Basic Page Needs
  ================================================== -->
	<meta charset="utf-8">
	<title>Cedeira Software Factory</title>
	<meta name="description" content="">
	<meta name="author" content="">

	<!-- Mobile Specific Metas
  ================================================== -->
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
	
	<!-- CSS
  ================================================== -->
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
		
	<!-- Favicons
	================================================== -->
	<link rel="shortcut icon" href="favicon.png">
	<link rel="apple-touch-icon" href="apple-touch-icon.png">
	<link rel="apple-touch-icon" sizes="72x72" href="apple-touch-icon-72x72.png">
	<link rel="apple-touch-icon" sizes="114x114" href="apple-touch-icon-114x114.png">
	
</head>
<body>
	
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
                                    <div class="icon-box">&#xf0c0;</div>
                                    <h6><a href="personalit.html">PERSONAL IT</a></h6>
                                </div>
                            </li>
                            <li>
                                <div class="services-boxes-1">
                                    <div class="icon-box">&#xf0ed;</div>
                                    <h6><a href="factura.aspx">FACTURA ELECTRONICA</a></h6>
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
                            <a class="cd-nav-item animsition-link" href="emiral.html">
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
        <form id="form1" runat="server" visible="true">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>

	    <!-- TOP SECTION ================================================== -->
	    <section class="section parallax-section parallax-section-padding-top-bottom-home">
                <div class="parallax-factura"></div>
			    <div class="container">
				    <div class="sixteen columns">
					    <div class="section-title left">
						    <h1>Tiempo de sesión expirado</h1>
                            <div class="subtitle left big"></div>
					    </div>
				    </div>
			    </div>
        </section>

        <section class="section white-section">
            <div class="container">
            <div class="row">
            <div class="col-lg-12 col-md-12">
                <p style="text-align:center; padding-top: 20px; padding-bottom:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text="Para seguir trabajando, haga click en 'Ingresar'."></asp:Label>
                </p>
            </div>
            </div>
            </div>
        </section>
        </form>

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

                        <div id="ajaxsuccess" style="color:white">Enviado con éxito!</div>
                    </div>
                </div>
            </div>
        </section>

        <!-- FATFOOTER ================================================== -->
        <section class="section darkgrey-section section-padding-top-bottom" id="fatfooter">
            <div class="container">
                <div class="four columns" data-scroll-reveal="enter left move 200px over 0.5s after 0.8s" data-scroll-reveal-id="1" data-scroll-reveal-initialized="true" data-scroll-reveal-complete="true">
                    <h6><a href="about-1.html" class="animsition-link">QUIENES SOMOS</a></h6>
                    <h6><a href="tech.html" class="animsition-link">TECNOLOGIA</a></h6>
                    <h6><a href="index.html#scroll-link-4" class="animsition-link">CLIENTES</a></h6>
                    <h6><a href="contact.html" class="animsition-link">CONTACTO</a></h6>
                </div>
                <div class="four columns" data-scroll-reveal="enter left move 200px over 0.5s after 0.3s" data-scroll-reveal-id="2" data-scroll-reveal-initialized="true" data-scroll-reveal-complete="true">
                    <h6>SERVICIOS</h6>
                    <ul class="circle"><li><a href="desarrollos.html" class="animsition-link">DESARROLLOS A MEDIDA</a></li><li><a href="sf.html" class="animsition-link">SOFTWARE FACTORY</a></li><li><a href="factura.aspx" class="animsition-link">FACTURA ELECTRONICA</a></li></ul>
                </div>
                <div class="four columns" data-scroll-reveal="enter right move 200px over 0.5s after 0.3s" data-scroll-reveal-id="3" data-scroll-reveal-initialized="true" data-scroll-reveal-complete="true">
                    <h6>PRODUCTOS</h6>
                    <ul class="circle">
                        <li>
                            <a href="transferencias.html" class="animsition-link">
                                Sistema de Transferencias
                                "implementación BCRA"
                            </a>
                        </li>
                        <li><a href="contenidos.html" class="animsition-link">Sistema de Administración y Presentación de Contenidos</a></li>
                        <li><a href="tasas.html" class="animsition-link">Sistema de Carga Centralizada de Tasas</a></p>
                        <li><a href="fondos.html" class="animsition-link">Sistema de Administración de Fondos Comunes de Inversión</a></li>
                        <li><a href="inversiones.html" class="animsition-link">Plataforma de Inversiones</a></li>
                        <li><a href="stock.html" class="animsition-link">Gestión de Stock de Servicios y Tarjetas	</a></li>
                    </ul>
                </div>
                <div class="four columns" data-scroll-reveal="enter right move 200px over 0.5s after 0.8s" data-scroll-reveal-id="4" data-scroll-reveal-initialized="true" data-scroll-reveal-complete="true">
                    <h6><a href="busquedas.aspx" class="animsition-link">BUSQUEDAS LABORALES</a></h6>
                    <p style="text-transform: none">Si desea recibir infomación sobre novedades de busquedas laborales puede dejarnos su email.</p>
                    <div class="sixteen columns">
                        <div id=""><button class="send_message" id="" onclick="window.open('busquedas.aspx', '_self');">SUSCRIBIRSE</button></div>
                    </div>
                    <div class="clear"></div>
                </div>
            </div>
        </section>

        <!-- TERMINOS ================================================== -->
        <section class="section footer-bottom">
            <div class="container" style="text-align: center">
                <div class="sixteen columns">
                    <p><a href="terminos.html">Términos y condiciones </a> - <a href="politicas.html">Políticas de privacidad</a></p>
                </div>
            </div>
        </section>
    </main>		

	<div class="scroll-to-top">&#xf106;</div>

	</div>

	<!-- JAVASCRIPT ================================================== -->
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
    <script type="text/javascript" src="js/custom-index.js"></script> 
    <script type="text/javascript" src="js/contact.js"></script>
    <!-- End Document ================================================== -->
</body>
</html>
