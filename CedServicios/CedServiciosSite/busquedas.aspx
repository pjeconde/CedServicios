<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="busquedas.aspx.cs" Inherits="CedServicios.Site.busquedas" %>

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
		
	<!-- Favicons ================================================== -->
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
				
				<li >
					<a href="about-1.html" >Quiénes somos</a>
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
					<a href="#" >Productos</a>
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
			</ul> <!-- primary-nav -->
		</nav> <!-- cd-nav -->
	</div>
	
	<main class="cd-main-content">
	
	    <!-- TOP SECTION ================================================== -->
		<section class="section parallax-section parallax-section-padding-top-bottom-home">
			<div class="parallax-busquedas"></div>
			<div class="container">
				<div class="sixteen columns">
					<div class="section-title left">
						<div class="subtitle left big">Nuestras</div>
						<h1>Búsquedas laborales</h1>
						
					</div>
				</div>
			</div>
				
		</section>	
	
        <section class="section grey-section section-padding-top-bottom">
	        <div class="container">
                <!-- BUSQUEDA 1 ================================================== -->		
	            <div class="eight columns" data-scroll-reveal="enter left move 200px over 1s after 0.3s" data-scroll-reveal-id="1" data-scroll-reveal-initialized="true" data-scroll-reveal-complete="true">
                    <div class="services-boxes-1 team-box-1">
                        <div class="icon-box">&#xf007;</div>
                        <h6>WEB DEVELOPERS SENIOR</h6>
                        <div class="team-box-1-text-in white-section">
                            <h6 style="color: #3bb2df">DESCRIPCIÓN:</h6>

                            <p style="text-align: left">
                                Para importante entidad bancaria seleccionaremos desarrolladores web con conocimientos y experiencia mayor a 5 años con las herramientas de Microsoft: Visual Studio 2010 o superior, C#.NET, ASP.NET, Frameworks 4.0 o superior, Javascript y T-SQL.
            Otros conocientos como Crystal Reports, AJAX, Aplicaciones de consola y Servicios de Windows seran teniedos en cuenta.
                            </p>

                            <p style="text-align: left">
                                Valoraremos aquellas personas que demuestren responsabilidad y compromiso como así también las que estén dispuestas al aprendizaje continuo. 
            La empresa ofrece muy buenas condiciones de contratación, excelente clima laboral y grandes posibilidades de desarrollo dentro del grupo.
                            </p>
                            <h6 style="color: #3bb2df">REQUISITOS:</h6>
                            <p style="text-align: left">
                                • Indicar remuneracion bruta pretendida.<br>
                                • Lugar de residencia: Capital Federal, GBA.<br>
                                • Educación: Universitario, Graduado, En curso.<br>
                                • Idioma: Inglés Intermedio.
                            </p>

                            <p style="text-align: left"><i class="icon-footer"></i><a href="mailto:rrhh@cedeira.com.ar" title="">rrhh@cedeira.com.ar</a></p>

                        </div>
                    </div>
                </div>
					
                <!-- BUSQUEDA 2
                 ================================================== -->	
					
                <div class="eight columns" data-scroll-reveal="enter left move 200px over 1s after 0.3s" data-scroll-reveal-id="1" data-scroll-reveal-initialized="true" data-scroll-reveal-complete="true">
			        <div class="services-boxes-1 team-box-1">
			        <div class="icon-box">&#xf007;</div>
			        <h6>WEB DEVELOPERS SEMI SENIOR</h6>
			        <div class="team-box-1-text-in white-section">
                        <h6 style="color: #3bb2df">DESCRIPCIÓN:</h6>

                        <p style="text-align: left">
                            Para importante entidad bancaria seleccionaremos desarrolladores web con conocimientos y experiencia mayor a 3 años con las herramientas de Microsoft: Visual Studio 2010 o superior, C#.NET, ASP.NET, Frameworks 4.0 o superior y T-SQL.
                        </p>
                        <p style="text-align: left">
                            Valoraremos aquellas personas que demuestren responsabilidad y compromiso como así también las que estén dispuestas al aprendizaje continuo. 
        La empresa ofrece muy buenas condiciones de contratación, excelente clima laboral y grandes posibilidades de desarrollo dentro del grupo.
                        </p>
                        <h6 style="color: #3bb2df">REQUISITOS:</h6>
                        <p style="text-align: left">
                            • Indicar remuneracion bruta pretendida.<br>
                            • Lugar de residencia: Capital Federal, GBA.<br>
                            • Educación: Universitario, Graduado, En curso.<br>
                            • Idioma: Inglés Intermedio.
                        </p>

                        <p style="text-align: left"><i class="icon-footer"></i><a href="mailto:rrhh@cedeira.com.ar" title="">rrhh@cedeira.com.ar</a></p>

                    </div>
                    </div>
		            </div>
            </div>
		</section>
		
        <!-- SUBIR CV
        ================================================== -->			
        <section class="section footer-1 section-padding-top-bottom" style="background: #3bb2df">						
			<div class="container" style="text-align: center">
				<div class="sixteen columns">
					<div class="section-title">
						<h3>ENVIAR CV</h3>
					</div>
				</div>			
				<div class="clear"></div>				
				<form runat="server" name="Busqueda" id="Busqueda" method="post">
                    <div class="row">
                        <div class="twelve columns">
                            <label for='EmailCV'>Email</label>
                            <input type="email" name="EmailCV" id="EmailCV" placeholder="Email" value='<%= EmailValue %>' style="width:100%">
                            <label for='NombreCV'>Nombre</label>
                            <input type="text" name="NombreCV" id="NombreCV" placeholder="" value='<%= NombreValue %>' style="width:100%">
                            <label for='IdBusquedaPerfilDropDownList'>Seleccione su Perfil</label>
                            <asp:DropDownList ID="IdBusquedaPerfilDropDownList" class="form-control" runat="server" TabIndex="1" name="IdBusquedaPerfil" placeholder="Perfil" DataValueField="IdBusquedaPerfil" DataTextField="DescrBusquedaPerfil" Visible="true" Width="100%" Height="30px"></asp:DropDownList>
                            <p>
                                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Seleccionar archivo CV" Width="100%" TabIndex="2" CssClass="button button-2" />
                                <asp:Button ID="SubirCVButton" runat="server" TabIndex="3" Text="Subir el CV" Width="100%" OnClick="SubirCVButton_Click" class="button-1" />
                            </p>
                        </div>
                    </div>
				</form>	
				<div class="clear"></div>
			</div>
	    </section>		
	    <div id="indexpie"></div>
	</main>		

	<div class="scroll-to-top">&#xf106;</div>

	<!-- JAVASCRIPT
    ================================================== -->
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
    <script>
        $(function () {
            $("#indexpie").load("indexPie.html");
        });
    </script>	  
<!-- End Document
================================================== -->
</body>
</html>