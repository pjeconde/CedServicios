<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="UsuarioOlvidoPassword.aspx.cs" Inherits="CedServicios.Site.UsuarioOlvidoPassword" Theme="CedServicios" %>

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
        <form id="form1" runat="server" visible="true">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>

	    <!-- TOP SECTION ================================================== -->
	    <section class="section parallax-section parallax-section-padding-top-bottom-home">
                <div class="parallax-factura"></div>
			    <div class="container">
				    <div class="sixteen columns">
					    <div class="section-title left">
						    <h1>¿Olvidó la Contraseña de su cuenta?</h1>
                            <div class="subtitle left big">Facturación electrónica</div>
					    </div>
				    </div>
			    </div>
        </section>

        <section class="section white-section">
            <div class="container">
            <div class="row">
            <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px;">
                <tr>
                    <td colspan="3" align="left" style="padding-top:20px;">
                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Para establecer una nueva Contraseña para su cuenta eFact, siga las siguientes instrucciones:"></asp:Label>
                    </td>
                </tr>
                <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                <tr>
                    <td colspan="3" style="padding-top:10px" valign="middle" align="left">
                        <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="1) Ingrese Id.Usuario e Email (luego haga clic en el botón 'Solicitar Pregunta de seguridad')."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-top:5px; padding-right: 5px">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                            ErrorMessage="Id.Usuario" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                            <asp:Label ID="Label13" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                            ErrorMessage="Id.Usuario" SetFocusOnError="True">
                            <asp:Label ID="Label14" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="IdUsuarioLabel" runat="server" Text="Id.Usuario"></asp:Label>
                    </td>
                    <td  colspan="2" align="left" style="padding-top:5px">
                        <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-right: 5px; padding-top:5px">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox"
                            ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                            <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmailTextBox"
                            ErrorMessage="Email" SetFocusOnError="True">
                            <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                    </td>
                    <td colspan="2" align="left" style="padding-top:5px">
                        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="2" Width="360px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" align="left" style="padding-top:5px">
                        <asp:Button ID="SolicitarPreguntaButton" runat="server" CausesValidation="false"
                            OnClick="SolicitarPreguntaButton_Click" TabIndex="3" Text="Solicitar Pregunta de seguridad"
                            Width="100%" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="3" style="padding-top:5px">
                        <asp:Label ID="Label10" runat="server" SkinID="TextoMediano" Text="2) Responda la Pregunta de Seguridad (luego haga clic en el botón 'Solicitar nuevo ingreso de Contraseña')."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" align="left" style="padding-top:5px;">
                        <asp:Label ID="PreguntaLabel" runat="server" Enabled="false" SkinID="TituloMediano"
                            Text="Pregunta de seguridad"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-top:5px; padding-right: 5px">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                            ErrorMessage="Respuesta" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                            <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                            ErrorMessage="Respuesta" SetFocusOnError="True">
                            <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
                    </td>
                    <td colspan="2" align="left" style="padding-top:5px">
                        <asp:TextBox ID="RespuestaTextBox" runat="server" Enabled="false" MaxLength="256"
                            TabIndex="4" Width="360px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2" align="left" style="padding-top:5px">
                        <asp:Button ID="SolicitarNuevaPasswordButton" runat="server" CausesValidation="false"
                            Enabled="false" OnClick="SolicitarNuevaPasswordButton_Click" TabIndex="5" Text="Solicitar nuevo ingreso de Contraseña"
                            Width="100%" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="3" style="padding-top:5px">
                        <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="3) Ingrese, y confirme, su nueva Contraseña (luego haga click en el botón 'Aceptar')."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-right: 10px; padding-top:5px">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                            ErrorMessage="Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                            <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                            ErrorMessage="Contraseña nueva" SetFocusOnError="True">
                            <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="Label1" runat="server" Text="Contraseña nueva"></asp:Label>
                    </td>
                    <td colspan="2" align="left" style="padding-right: 10px; padding-top:5px">
                        <asp:TextBox ID="PasswordNuevaTextBox" runat="server" Enabled="false" OnTextChanged="TextBox_TextChanged"
                            TabIndex="6" TextMode="Password" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-right: 10px; padding-top:5px">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                            ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                            <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                            ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True">
                            <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                        </asp:RequiredFieldValidator>
                        <asp:Label ID="Label2" runat="server" Text="Confirmación"></asp:Label>
                    </td>
                    <td colspan="2" align="left" style="padding-right: 10px; padding-top:5px">
                        <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" Enabled="false"
                            OnTextChanged="TextBox_TextChanged" TabIndex="7" TextMode="Password" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left" style="padding-top:20px; width: 100px">
                        <asp:Button ID="AceptarButton" runat="server" Enabled="false" OnClick="AceptarButton_Click"
                            TabIndex="8" Text="Aceptar" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    </td>
                    <td align="right" style="padding-top:20px; padding-left: 10px; width: 100px">
                        <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/factura.aspx"
                            TabIndex="9" Text="Cancelar" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center" style="padding-top:20px;">
                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                    </td>
                </tr>
                <!-- @@@ @@@-->
            </table>
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
                        Virrey Arredondo 3447, Piso 1, Of. A, CABA<br />
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
                        <form name="ajax-form" id="ajax-form" action="contact_me.php" method="post">
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

	<!-- JAVASCRIPT ================================================== -->
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
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
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
