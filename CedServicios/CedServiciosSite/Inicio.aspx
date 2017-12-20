<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CedServicios.Site.Inicio" Theme="CedServicios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" Visible="true" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
		<div class='preloader'><div class='loaded'>&nbsp;</div></div>

        <!--Home page style-->
        <header id="home" class="home">
            <div class="overlay-fluid-block">
                <div class="container text-center">
                    <div class="row">
                        <div class="home-wrapper">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="home-content">
                                    <h1>COMPROMISO, EXPERIENCIA, CALIDAD E INNOVACIÓN</h1>
                                    <h5 style="color:White">El trabajo en equipo, el compromiso y la pasión por lo que hacemos son la clave del éxito de todos los días.</h5>
                                    <div class="row">
                                        <div class="col-md-6 col-md-offset-3 col-sm-12 col-xs-12">
                                            <div class="home-contact">
                                                <div class="input-group">
                                                    <h5 style="color:White">Estamos constantemente en búsqueda de nuevos talentos. Te invitamos a que formes parte de nuestro equipo!</h5>
                                                    <p></p>
                                                    <input type="text" class="form-control" placeholder="Enter your email address">
                                                    <input type="submit" class="form-control" value="Enviar CV">
                                                </div><!-- /input-group -->
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>			
            </div>
        </header>

        <!-- Sections -->
        <section id="features" class="features sections2">
            <div class="container">
                <div class="row">
                    <div class="main_features_content2">
                        <div class="col-sm-12 margin-top-40">
                            <h2>PRODUCTOS</h2>
                            <br />
                            <br />
                        </div>
                        <div class="col-sm-6">
                            <div class="single_features_left text-center">
                                <img src="Imagenes/CedAPC.jpg" alt="" />
                            </div>
                        </div>

                        <div class="col-sm-6">
                            <div class="single_features_left text-left">
                                <h3>Sistema de Carga Centralizada de Tasas</h3>
                                <p>Esta aplicación esta diseñada para administrar las tasas Pasivas de los Plazos Fijos de una entidad bancaria.<br />
                                   Presenta un Tablero de Control donde se pueden visualizar todas la tasas en una estructura jerárquica. Se pueden realizar cambios puntuales de una sucursal o de forma masiva. 
                                   Para esto cuenta con un sistema de fórmulas que le permite realizar los cálculos automáticos de las tasas. 
                                   Todos los cambios se impactan en los sistemas corporativos del banco.</p>
                                    <ul class="list-unstyled">
                                    <li> <span class="glyphicon glyphicon-ok"></span> Permite un control preciso de la autorización de las operaciones y registra un log detallado los cambios realizados. </li>
                                    <li> <span class="glyphicon glyphicon-ok"></span> Genera Reportes Operativos y Actas para el Directorio.<br/> </li>
                                    <li> <span class="glyphicon glyphicon-ok"></span> Exporta la información a planillas de cálculo.</li>
                                    </ul>
                                <div class="features_buttom">
                                    <a href="" class="btn btn-default">Leer detalle</a>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section><!--End of Features 2 Section -->
        <section id="features" class="features sections2">
            <div class="container">
                <div class="row">
                    <div class="main_features_content2">
                       <div class="col-sm-6">
                            <div class="single_features_left text-left">
                                <h3>Sistema de Administración y Presentación de Contenidos</h3>
                                <p>Es una herramienta, de propósitos generales, que permite automatizar procesos informáticos
                                en los que:<br />
                                1) se recolecten de datos,<br />
                                2) se calculen resultados, a partir de esos datos, y<br />
                                3) se presenten esos resultados (contenidos)&nbsp<br /></p>
                                <div class="features_buttom">
                                    <a href="" class="btn btn-default">Leer detalle</a>
                                    <br />
                                    <br />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="single_features_left text-center">
                                <img src="Imagenes/CedCCT-Tablero.jpg" alt="" style="width:600px; height:300px" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section><!--End of Features 2 Section -->

        <section id="service" class="service2 sections2 lightbg">
            <div class="container">
                <div class="row">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2>SERVICIOS</h2>
                            <p>Estos son algunos de los servicios que le brindamos a nuestros clientes</p>
                        </div>
                    </div>
                    <div class="service_content">
                        <div class="col-md-6 col-sm-6">
                            <div class="single_service2">
                                <div class="single_service_left" style="vertical-align:top">
                                    <img src="Imagenes/Iconos/PagPpal/key.png" />
                                </div>
                                <div class="single_service_right" style="vertical-align:top">
                                    <h2 style="text-align:left">Desarrollos a medida</h2>
                                    <p style="text-align:left">Desarrollamos software a medida en función de los requerimientos de las empresas, adaptamos el mismo a las necesidades operativas y comerciales para obtener un valor agregado.<br />
                                    <a href="" class="btn btn-default">Leer detalle</a></p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6 col-sm-6">
                            <div class="single_service2">
                                <div class="single_service_left" style="vertical-align:top">
                                    <img src="Imagenes/Iconos/PagPpal/Teamwork.png" />
                                </div>
                                <div class="single_service_right" style="vertical-align:top">
                                    <h2 style="text-align:left">Software Factory</h2>
                                    <p style="text-align:left">Nuestra empresa se especializa en brindar servicios de software Factory principalmente a entidades financieras cumpliendo con los estándares del mercado actual.
                                    <br /><a href="" class="btn btn-default">Leer detalle</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section><!-- End of Service2 Section -->		

        <section id="clientes" class="sections2">
            <div class="container">
                <div class="head_title text-center">
                    <h2>CLIENTES</h2>
                    <p>Creemos que la mejor manera de conocernos, es a través de nuestros clientes. Ellos son nuestro mejor aval y les agradecemos la confianza que nos han brindado.</p>
                </div>

                <div class="service_content">
                    <div class="row">
                        <img src="Imagenes/Clientes/Logo-Abasto.jpg" />
                        <img src="Imagenes/Clientes/Logo-PatioBullrich.jpg" />
                        <img src="Imagenes/Clientes/Logo-AltoAvellaneda.jpg" />
                        <img src="Imagenes/Clientes/Logo-AltoPalermo.jpg" />
                        <img src="Imagenes/Clientes/Logo-bueno-aires-desing.jpg" />
                        <img src="Imagenes/Clientes/Logo-Adm-Arg.jpg" />
                        <img src="Imagenes/Clientes/Logo-alfred-c-toepfer-international.png" />
                        <img src="Imagenes/Clientes/Logo_TV.png" />
                        <img src="Imagenes/Clientes/Logo-Disco.jpg" />
                        <img src="Imagenes/Clientes/Logo-Galicia.jpg" />
                        <img src="Imagenes/Clientes/Logo_cmsi.jpg" />
                        <img src="Imagenes/Clientes/Logo_CeraAlb.png" />
                        <img src="Imagenes/Clientes/Logo_Clan.png" />
                        <img src="Imagenes/Clientes/Logo_Formulagro.bmp" />
                        <img src="Imagenes/Clientes/Logo_Lear.png" />
                        <img src="Imagenes/Clientes/Logo_Opdea.png" />
                        <img src="Imagenes/Clientes/Logo_Orbis.png" />
                        <img src="Imagenes/Clientes/Logo_Schaeffler.png" />
                        <img src="Imagenes/Clientes/Logo_Tia.png" />
                        <img src="Imagenes/Clientes/Logo_Compo.jpg" />
                        <img src="Imagenes/Clientes/Logo_Magnus.png" />
                        <img src="Imagenes/Clientes/Logo_Carrefour_alta.jpg" />
                    </div>
                </div>
            </div>
        </section>

        <!-- Sections -->
        <section id="price" class="price sections">


            <div class="head_title text-center">
                <h1>Affordable Services Package</h1>
				<p>Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum. Duis mollis, est non commodo luctus, nisi erat porttitor ligula.</p>
            </div>
            <!-- Example row of columns -->
            <div class="cd-pricing-container cd-has-margins">
                <div class="cd-pricing-switcher">
                    <p class="fieldset">
                        <input type="radio" name="duration-2" value="monthly" id="monthly-2" checked>
                        <label for="monthly-2">Business</label>
                        <input type="radio" name="duration-2" value="yearly" id="yearly-2">
                        <label for="yearly-2">Community</label>
                        <span class="cd-switch"></span>
                    </p>
                </div> <!-- .cd-pricing-switcher -->

                <ul class="cd-pricing-list cd-bounce-invert">
                    <li>
                        <ul class="cd-pricing-wrapper">
                            <li data-type="monthly" class="is-visible">
                                <header class="cd-pricing-header">
                                    <h2>Basic</h2>

                                    <div class="cd-price">
                                        <span class="cd-currency">$</span>
                                        <span class="cd-value">30</span>
                                        <span class="cd-duration">mo</span>
                                    </div>
                                </header> <!-- .cd-pricing-header -->

                                <div class="cd-pricing-body">
                                    <ul class="cd-pricing-features">
                                        <li><em><i class="fa fa-check-circle"></i></em>20 Keyword</li>
                                        <li><em><i class="fa fa-remove"></i></em>No Time Tracking</li>
                                        <li><em><i class="fa fa-remove"></i></em>230 - Man Hour</li>
                                        <li><em><i class="fa fa-check-circle"></i></em>News Letter Available</li>

                                    </ul>
                                </div> <!-- .cd-pricing-body -->

                                <footer class="cd-pricing-footer">
                                    <a class="cd-select" href="#">Purchase</a>
                                </footer>  <!-- .cd-pricing-footer -->
                            </li>

                            <li data-type="yearly" class="is-hidden">
                                <header class="cd-pricing-header">
                                    <h2>Basic</h2>

                                    <div class="cd-price">
                                        <span class="cd-currency">$</span>
                                        <span class="cd-value">320</span>
                                        <span class="cd-duration">yr</span>
                                    </div>
                                </header> <!-- .cd-pricing-header -->

                                <div class="cd-pricing-body">
                                    <ul class="cd-pricing-features">
                                        <li><em><i class="fa fa-check-circle"></i></em>20 Keyword</li>
                                        <li><em><i class="fa fa-remove"></i></em>No Time Tracking</li>
                                        <li><em><i class="fa fa-remove"></i></em>230 - Man Hour</li>
                                        <li><em><i class="fa fa-check-circle"></i></em>News Letter Available</li>

                                    </ul>
                                </div> <!-- .cd-pricing-body -->

                                <footer class="cd-pricing-footer">
                                    <a class="cd-select" href="#">Purchase</a>
                                </footer>  <!-- .cd-pricing-footer -->
                            </li>
                        </ul> <!-- .cd-pricing-wrapper -->
                    </li>

                    <li class="cd-popular">
                        <ul class="cd-pricing-wrapper">
                            <li data-type="monthly" class="is-visible">
                                <header class="cd-pricing-header">
                                    <h2>Popular</h2>
                                    <div class="cd-price">
                                        <span class="cd-currency">$</span>
                                        <span class="cd-value">60</span>
                                        <span class="cd-duration">mo</span>
                                    </div>
                                </header> <!-- .cd-pricing-header -->

                                <div class="cd-pricing-body">
                                    <ul class="cd-pricing-features">
                                        <li><em><i class="fa fa-check-circle"></i></em>20 Keyword</li>
                                        <li><em><i class="fa fa-remove"></i></em>No Time Tracking</li>
                                        <li><em><i class="fa fa-remove"></i></em>230 - Man Hour</li>
                                        <li><em><i class="fa fa-check-circle"></i></em>News Letter Available</li>

                                    </ul>
                                </div> <!-- .cd-pricing-body -->

                                <footer class="cd-pricing-footer">
                                    <a class="cd-select" href="#">Purchase</a>
                                </footer>  <!-- .cd-pricing-footer -->
                            </li>

                            <li data-type="yearly" class="is-hidden">
                                <header class="cd-pricing-header">
                                    <h2>Popular</h2>

                                    <div class="cd-price">
                                        <span class="cd-currency">$</span>
                                        <span class="cd-value">630</span>
                                        <span class="cd-duration">yr</span>
                                    </div>
                                </header> <!-- .cd-pricing-header -->

                                <div class="cd-pricing-body">
                                    <ul class="cd-pricing-features">
                                        <li><em><i class="fa fa-check-circle"></i></em>20 Keyword</li>
                                        <li><em><i class="fa fa-remove"></i></em>No Time Tracking</li>
                                        <li><em><i class="fa fa-remove"></i></em>230 - Man Hour</li>
                                        <li><em><i class="fa fa-check-circle"></i></em>News Letter Available</li>

                                    </ul>
                                </div> <!-- .cd-pricing-body -->

                                <footer class="cd-pricing-footer">
                                    <a class="cd-select" href="#">Purchase</a>
                                </footer>  <!-- .cd-pricing-footer -->
                            </li>
                        </ul> <!-- .cd-pricing-wrapper -->
                    </li>

                    <li>
                        <ul class="cd-pricing-wrapper">
                            <li data-type="monthly" class="is-visible">
                                <header class="cd-pricing-header">
                                    <h2>Premier</h2>

                                    <div class="cd-price">
                                        <span class="cd-currency">$</span>
                                        <span class="cd-value">90</span>
                                        <span class="cd-duration">mo</span>
                                    </div>
                                </header> <!-- .cd-pricing-header -->

                                <div class="cd-pricing-body">
                                    <ul class="cd-pricing-features">
                                        <li><em><i class="fa fa-check-circle"></i></em>20 Keyword</li>
                                        <li><em><i class="fa fa-remove"></i></em>No Time Tracking</li>
                                        <li><em><i class="fa fa-remove"></i></em>230 - Man Hour</li>
                                        <li><em><i class="fa fa-check-circle"></i></em>News Letter Available</li>

                                    </ul>
                                </div> <!-- .cd-pricing-body -->

                                <footer class="cd-pricing-footer">
                                    <a class="cd-select" href="#">Purchase</a>
                                </footer>  <!-- .cd-pricing-footer -->
                            </li>

                            <li data-type="yearly" class="is-hidden">
                                <header class="cd-pricing-header">
                                    <h2>Premier</h2>

                                    <div class="cd-price">
                                        <span class="cd-currency">$</span>
                                        <span class="cd-value">950</span>
                                        <span class="cd-duration">yr</span>
                                    </div>
                                </header> <!-- .cd-pricing-header -->

                                <div class="cd-pricing-body">
                                    <ul class="cd-pricing-features">
                                        <li><em><i class="fa fa-check-circle"></i></em>20 Keyword</li>
                                        <li><em><i class="fa fa-remove"></i></em>No Time Tracking</li>
                                        <li><em><i class="fa fa-remove"></i></em>230 - Man Hour</li>
                                        <li><em><i class="fa fa-check-circle"></i></em>News Letter Available</li>

                                    </ul>
                                </div> <!-- .cd-pricing-body -->

                                <footer class="cd-pricing-footer">
                                    <a class="cd-select" href="#">Purchase</a>
                                </footer>  <!-- .cd-pricing-footer -->
                            </li>
                        </ul> <!-- .cd-pricing-wrapper -->
                    </li>
                </ul> <!-- .cd-pricing-list -->
            </div> <!-- .cd-pricing-container -->	

        </section>

        <!-- Sections -->
        <section id="business" class="portfolio sections">
            <div class="container">
                <div class="head_title text-center">
                    <h1>Our Business Analytics Platform</h1>
					<p>Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum. Duis mollis, est non commodo luctus, nisi erat porttitor ligula.</p>
                </div>

                <div class="row">
                    <div class="portfolio-wrapper text-center">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="community-edition">
                                <i class="fa fa-book"></i>
                                <div class="separator"></div>
                                <h4>Community Edition</h4>
                                <p>Visually explore your data through a free-form drag-and-drop canvas, a broad range of modern data visualizations, and an easy-to-use report authoring experience.</p>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="community-edition">
                                <i class="fa fa-bug"></i>
                                <div class="separator"></div>
                                <h4>Community Edition</h4>
                                <p>Visually explore your data through a free-form drag-and-drop canvas, a broad range of modern data visualizations, and an easy-to-use report authoring experience.</p>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="community-edition">
                                <i class="fa fa-gears"></i>
                                <div class="separator"></div>
                                <h4>Community Edition</h4>
                                <p>Visually explore your data through a free-form drag-and-drop canvas, a broad range of modern data visualizations, and an easy-to-use report authoring experience.</p>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="community-edition">
                                <i class="fa fa-external-link"></i>
                                <div class="separator"></div>
                                <h4>Community Edition</h4>
                                <p>Visually explore your data through a free-form drag-and-drop canvas, a broad range of modern data visualizations, and an easy-to-use report authoring experience.</p>
                            </div>
                        </div>

                    </div>
                </div>

                <!-- Example row of columns -->
                <div class="row">
                    <div class="portfolio-wrapper2 text-center">
                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="community-edition">
                                <i class="fa fa-coffee"></i>
                                <div class="separator"></div>
                                <h4>Community Edition</h4>
                                <p>Visually explore your data through a free-form drag-and-drop canvas, a broad range of modern data visualizations, and an easy-to-use report authoring experience.</p>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="community-edition">
                                <i class="fa fa-tree"></i>
                                <div class="separator"></div>
                                <h4>Community Edition</h4>
                                <p>Visually explore your data through a free-form drag-and-drop canvas, a broad range of modern data visualizations, and an easy-to-use report authoring experience.</p>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="community-edition">
                                <i class="fa fa-paper-plane-o"></i>
                                <div class="separator"></div>
                                <h4>Community Edition</h4>
                                <p>Visually explore your data through a free-form drag-and-drop canvas, a broad range of modern data visualizations, and an easy-to-use report authoring experience.</p>
                            </div>
                        </div>

                        <div class="col-md-3 col-sm-6 col-xs-12">
                            <div class="community-edition">
                                <i class="fa fa-folder-open"></i>
                                <div class="separator"></div>
                                <h4>Community Edition</h4>
                                <p>Visually explore your data through a free-form drag-and-drop canvas, a broad range of modern data visualizations, and an easy-to-use report authoring experience.</p>
                            </div>
                        </div>

                    </div>
                </div>
            </div> <!-- /container -->       
        </section>


        <section id="contact" class="contact sections">
            <div class="container">
                <div class="row">
                    <div class="main_contact whitebackground">
                        <div class="head_title text-center">
                            <h2>GET IN TOUCH</h2>
							<p>Fusce dapibus, tellus ac cursus commodo, tortor mauris condimentum. Duis mollis, est non commodo luctus, nisi erat porttitor ligula.</p>
                        </div>
                        <div class="contact_content">
                            <div class="col-md-6">
                                <div class="single_left_contact">
                                    <form action="#" id="formid">

                                        <div class="form-group">
                                            <input type="text" class="form-control" name="name" placeholder="first name" required="">
                                        </div>

                                        <div class="form-group">
                                            <input type="email" class="form-control" name="email" placeholder="Email" required="">
                                        </div>


                                        <div class="form-group">
                                            <textarea class="form-control" name="message" rows="8" placeholder="Message"></textarea>
                                        </div>

                                        <div class="center-content">
                                            <input type="submit" value="Submit" class="btn btn-default">
                                        </div>
                                    </form>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="single_right_contact">
                                    <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede.</p>

                                    <div class="contact_address margin-top-40">
                                        <span>1600 Pennsylvania Ave NW, Washington,</span>
                                        <span>DC 20500, United States of America.</span> 
                                        <span class="margin-top-20">T: (202) 456-1111</span> 
                                        <span>M: (202) 456-1212</span> 
                                    </div>

                                    <div class="contact_socail_bookmark">
                                        <a href=""><i class="fa fa-facebook"></i></a>
                                        <a href=""><i class="fa fa-twitter"></i></a>
                                        <a href=""><i class="fa fa-google"></i></a>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section><!-- End of Contact Section -->


        <section id="footer-menu" class="sections footer-menu">
            <div class="container">
                <div class="row">
                    <div class="footer-menu-wrapper">

                        <div class="col-md-8 col-sm-12 col-xs-12">
                            <div class="col-md-4 col-sm-6 col-xs-12">
                                <div class="menu-item">
                                    <h5>Quick Links</h5>
                                    <ul>
                                        <li>POWER BI DESKTOP</li>
                                        <li>MOBILE</li>
                                        <li>SEE ALL DOWNLOADS</li>
                                        <li>POWER BI DESKTOP</li>
                                        <li>MOBILE</li>
                                        <li>SEE ALL DOWNLOADS</li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-6 col-xs-12">
                                <div class="menu-item">
                                    <h5>Legal</h5>
                                    <ul>
                                        <li>PRIVACY & COOKIES</li>
                                        <li>TERMS OF USE</li>
                                        <li>TRADEMARKS</li>
                                    </ul>
                                </div>
                            </div>

                            <div class="col-md-4 col-sm-6 col-xs-12">
                                <div class="menu-item">
                                    <h5>Information</h5>
                                    <ul>
                                        <li>SUPPORT</li>
                                        <li>DEVELOPERS</li>
                                        <li>BLOG</li>
                                        <li>NEWSLETTER</li>
                                        <li>PYRAMID ANALYTICS</li>
                                    </ul>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-4 col-sm-6 col-xs-12">
                            <div class="menu-item">
                                <h5>Newsletter</h5>
                                <p>Insights await in your company's data. Bring them into focus with BlueLance.</p>
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="Enter your email address">
                                    <input type="submit" class="form-control" value="Use It Free">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>


        <!--Footer-->
        <footer id="footer" class="footer">
            <div class="container">
                <div class="row">
                    <div class="footer-wrapper">

                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <div class="footer-brand">
                                <img src="Imagenes/CedeiraSF-Logo.gif" alt="Logo" />
                            </div>
                        </div>

                        <div class="col-md-6 col-sm-6 col-xs-12">
                            <div class="copyright">
                                <p>Made with <i class="fa fa-heart"></i> by <a target="_blank" href="http://bootstrapthemes.co"> Bootstrap Themes </a>2016. All rights reserved.</p>

                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </footer>
		
		
		<div class="scrollup">
			<a href="#"><i class="fa fa-chevron-up"></i></a>
		</div>


        <script src="assets/js/vendor/jquery-1.11.2.min.js"></script>
        <script src="assets/js/vendor/bootstrap.min.js"></script>

        <script src="assets/js/plugins.js"></script>
        <script src="assets/js/modernizr.js"></script>
        <script src="assets/js/main.js"></script>

</asp:Content>
