<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="CedServicios.Site.Inicio" Theme="CedServicios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" Visible="true" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
		<div class='preloader'><div class='loaded'>&nbsp;</div></div>

        </head>
        <!--Home page style-->
        <header id="home" class="home">
            <div class="overlay-fluid-block">
                <div class="container text-center">
                    <div class="row">
                        <div class="home-wrapper">
                            <div class="col-md-10 col-md-offset-1">
                                <div class="home-content">
                                    <h2 style="color:White">COMPROMISO, EXPERIENCIA E INNOVACIÓN</h2>
                                    <br />
                                    <br />
                                    <h4 style="color:White">El trabajo en equipo, el compromiso y la pasión por lo que hacemos son la clave del éxito de todos los días.</h4>
                                    <div class="features_buttom">
                                        <a href="InicioEmpresa.aspx" class="btn btn-default">Quienes Somos</a>
                                    </div>
                                    <br />
                                    <br />
                                    <br />
                                    <h4 style="color:White">Si queres formar parte de nuestro equipo, podes ver las busquedas actuales que estamos realizando.</h4>
                                    <div class="features_buttom">
                                        <a href="InicioBusquedas.aspx" class="btn btn-default">Busquedas</a>
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
                        <div class="col-sm-12 margin-top-40 margin-bottom-40">
                            <h2>PRODUCTOS</h2>
                        </div>
                        <div class="col-sm-6 margin-bottom-20">
                            <div class="single_features_left text-center">
                                <img src="Imagenes/CedST-EsquemaMEP.jpg" alt="" style="height:300px" />
                            </div>
                        </div>
                        <div class="col-sm-6 margin-bottom-20">
                            <div class="single_features_left text-left">
                                <h3>Sistema de Transferencias<br />"implementación BCRA"</h3>
                                <p>Es un sistema diseñado para centralizar la administración de transferencias.
                                En línea con el BCRA, concentra el 100% de las operaciones, tanto enviadas como recibidas, en un único repositorio, para realizar un control eficiente y una óptima gestión operativa.<br />
                                <div class="features_buttom">
                                    <a href="InicioProductos.aspx?Valor=panCedST" class="btn btn-default">Leer detalle</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <hr />
        <section id="features" class="features sections2">
            <div class="container">
                <div class="row">
                    <div class="main_features_content2">
                       <div class="col-sm-6 margin-bottom-20">
                            <div class="single_features_left text-center">
                                <img src="Imagenes/CedAPC.jpg" alt="" />
                            </div>
                        </div>
                       <div class="col-sm-6 margin-bottom-20">
                            <div class="single_features_left text-left">
                                <h3>Sistema de Administración y Presentación de Contenidos</h3>
                                <p>Es una herramienta, de propósitos generales, que permite automatizar procesos informáticos
                                en los que:<br />
                                1) se recolecten de datos<br />
                                2) se calculan resultados a partir de esos datos<br />
                                3) se presenten los resultados en diversas interfaces y reportes informativos.&nbsp<br /></p>
                                <div class="features_buttom">
                                    <a href="InicioProductos.aspx?Valor=panCedAPC" class="btn btn-default">Leer detalle</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <hr />
        <section id="features" class="features sections2">
            <div class="container">
                <div class="row">
                    <div class="main_features_content2">
                        <div class="col-sm-6 margin-bottom-20">
                            <div class="single_features_left text-center">
                                <img src="Imagenes/CedCCT.jpg" alt="" style="width: 600px; height:300px" />
                            </div>
                            <br />
                        </div>
                        <div class="col-sm-6 margin-bottom-20">
                            <div class="single_features_left text-left">
                                <h3>Sistema de Carga Centralizada de Tasas</h3>
                                <p>Esta aplicación esta diseñada para administrar las tasas Pasivas de Plazos Fijos de entidades bancarias.<br />
                                   Presenta un Tablero de Control donde se pueden visualizar todas la tasas en una estructura jerárquica. Se pueden realizar cambios puntuales de una sucursal o de forma masiva. 
                                   Para esto cuenta con un sistema de fórmulas que le permite realizar los cálculos automáticos de las tasas. 
                                   Todos los cambios se impactan en los sistemas corporativos del banco.</p>
                                <ul class="list-unstyled">
                                    <li> <span class="glyphicon glyphicon-ok"></span> Permite un control preciso de la autorización de las operaciones y registra un log detallado los cambios realizados. </li>
                                    <li> <span class="glyphicon glyphicon-ok"></span> Genera Reportes Operativos y Actas para el Directorio.<br/> </li>
                                    <li> <span class="glyphicon glyphicon-ok"></span> Exporta la información a planillas de cálculo.</li>
                                </ul>
                                <div class="features_buttom">
                                    <a href="InicioProductos.aspx?Valor=panCedCCT" class="btn btn-default">Leer detalle</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <hr />
        <section id="features" class="features sections2">
            <div class="container">
                <div class="row">
                    <div class="main_features_content2">
                        <div class="col-sm-6 margin-bottom-20">
                            <div class="single_features_left text-center">
                                <img src="Imagenes/CedFCI-EsquemaProceso.jpg" alt="" style="height:301px"/>
                            </div>
                        </div>
                        <div class="col-sm-6 margin-bottom-20">
                            <div class="single_features_left text-left">
                                <h3>Sistema de Administración de Fondos Comunes de Inversión</h3>
                                <p>El sistema de Administración de FCIs es una herramienta de administración de las carteras de inversión de los fondos y de cálculo de los valores de cuotaparte. Lleva la contabilidad y facilita el cumplimiento de las normas establecidas por el organismo de fiscalización y de los reglamentos de gestión.</p>
                                <div class="features_buttom">
                                    <a href="InicioProductos.aspx?Valor=panCedFCI" class="btn btn-default">Leer detalle</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

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
                                    <a href="InicioDesarrolloAMedida.aspx" class="btn btn-default">Leer detalle</a></p>
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
                                    <br /><a href="InicioServicioSF.aspx" class="btn btn-default">Leer detalle</a></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        
        <!-- Service2-->
        <section id="service" class="service2 sections2 lightbg">		
            <div class="container">
                <div class="row">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2>Alianzas Estratégicas</h2>
                        </div>
                    </div>
                    <div class="service_content">
                        <div class="col-md-12 col-sm-12">
                            <div class="single_service2">
                                <div class="single_service_left" style="vertical-align:top">
                                    <img src="Imagenes/Iconos/PagPpal/partnership.png" />
                                </div>
                                <div class="single_service_right" style="vertical-align:top">
                                    <p style="text-align:left">
                                    <img src="Imagenes/Empresa/InterBanking.png" style="width:300px"/>
                                    <br />
                                    <br />
                                    A través de su alianza estratégica, Interbanking y Cedeira Software Factory han sabido potenciar sus capacidades respectivas, a efectos de brindar una solución integral para la carga, emisión, validación, almacenamiento y visualización de Facturas Electrónicas.<br />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- End of Service2 Section -->		

        <section id="clientes" class="sections2">
            <div class="container">
                <div class="head_title text-center">
                    <h2>CLIENTES</h2>
                    <p>Creemos que la mejor manera de conocernos, es a través de nuestros clientes. Ellos son nuestro mejor aval y les agradecemos la confianza que nos han brindado.</p>
                </div>

                <div class="service_content">
                    <div class="row">
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-Abasto.jpg" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-PatioBullrich.jpg" class="img-responsive center-block" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-AltoAvellaneda.jpg" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-AltoPalermo.jpg" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-bueno-aires-desing.jpg" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-Adm-Arg.jpg" class="img-responsive center-block" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-alfred-c-toepfer-international.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_TV.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-Disco.jpg" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-Galicia.jpg" class="img-responsive center-block" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_cmsi.jpg" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_CeraAlb.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Clan.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Formulagro.bmp" class="img-responsive center-block" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Lear.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Tia.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                    </div>    
                    <div class="row">
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Compo.jpg" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Carrefour_alta.jpg" class="img-responsive center-block" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Magnus.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Opdea.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                    </div>    
                    <div class="row">
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo_Orbis.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-Schaeffler.jpg" class="img-responsive center-block" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-Asamach.jpg" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6 col-md-3 padding-bottom-20">
                            <div class="grid_1_4">
                                <div class="picture">
                                    <img src="Imagenes/Clientes/Logo-MagnoConsulting.png" class="img-responsive center-block"/>
                                </div>
                            </div>
                        </div>
                    </div>    
                </div>
            </div>
        </section>

        <section id="contact" class="contact sections">
            <div class="container">
                <div class="row">
                    <div class="main_contact whitebackground">
                        <div class="head_title text-center">
                            <h2>CONTACTO</h2>
							<p>Cualquier consulta o inquietud, pueden completar el formulario y les contestaremos a la brevedad.</p>
                        </div>
                        <div class="contact_content">
                            <div class="col-md-6">
                                <div class="single_left_contact">
                                    <div class="form-group text-left">
                                        Motivo de la consulta:&nbsp; 
                                        <input type="radio" runat="server" name="optradio" id="optFea">&nbsp;Factura electrónica
                                        <input type="radio" runat="server" name="optradio" id="optOtro" checked>&nbsp;Otro motivo
                                    </div>
                                    <div class="form-group">
                                        <input type="text" class="form-control" name="NombreContacto" placeholder="Nombre" required="">
                                    </div>

                                    <div class="form-group">
                                        <input type="email" class="form-control" name="EmailContacto" placeholder="Email" required="">
                                    </div>
                                    <div class="form-group">
                                        <textarea class="form-control" name="MensajeContacto" rows="8" placeholder="Mensaje"></textarea>
                                    </div>
                                    <div class="center-content">
                                        <input type="button" id="Button1" value="Enviar" runat="server" onserverclick="Button1_Click" class="btn btn-default">
                                    </div>
                                    
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="single_right_contact">
                                    <p style="text-align:left">Facturación Electrónica: <br />
                                    <span><a href="mailto:facturaelectronica@cedeira.com.ar"><i class="fa fa-envelope"></i> facturaelectronica@cedeira.com.ar</a></span><br/>
                                    <span><a href="skype:facturaelectronica"><i class="fa fa-skype"></i> facturaelectronica</a></span>
                                    </p>
                                    <p style="text-align:left">Administración: <br />
                                    <span><a href="mailto:administracion@cedeira.com.ar"><i class="fa fa-envelope"></i> administracion@cedeira.com.ar</a></span><br/>
                                    </p>
                                    <p style="text-align:left">Recuersos Humanos: <br />
                                    <span><a href="mailto:rrhh@cedeira.com.ar"><i class="fa fa-envelope"></i> rrhh@cedeira.com.ar</a></span><br/>
                                    </p>
                                    <p style="text-align:left">Oficina Comercial: <br />
                                        <span><a href="#Contact"><i class="glyphicon glyphicon-earphone"></i> +5411 4778-1744</a></span><br/>
                                        <span><a href="mailto:info@cedeira.com.ar"><i class="fa fa-envelope"></i> info@cedeira.com.ar</a></span>
                                    </p>
                                    <p style="text-align:left">
                                        Horarios de Atención: <br />
                                        <span><a href="#Contact"><i class="fa fa-clock-o"></i> lunes a viernes de 10 a 18 hs.</a></span><br/>
                                    </p>
                                    <div class="contact_socail_bookmark text-left">
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

        <script src="assets/js/vendor/jquery-1.11.2.min.js"></script>
        <script src="assets/js/vendor/bootstrap.min.js"></script>

        <script src="assets/js/plugins.js"></script>
        <script src="assets/js/modernizr.js"></script>
        <script src="assets/js/main.js"></script>

</asp:Content>
