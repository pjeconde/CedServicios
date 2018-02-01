<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InicioFEAPrecios.aspx.cs" Inherits="CedServicios.Site.InicioFEAPrecios" Theme="CedServicios"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" Visible="true" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <!-- Sections -->
    <section id="price" class="price sections">
        <div class="head_title text-center">
            <h1>Paquete de Servicios</h1>
			<p>Elija la solución mas conveniente en función de las necesidades de su empresa.</p>
            <p>No es necesario intalar ningún tipo de software, usted podrá de manera sencilla realizar la facturación electrónica utilizando nuestro sitio web. Solo deberá realizar con su contador un alta de su punto de venta en el Sitio Web de la AFIP. Esta aplicación le permitira acceder desde cualquier dispositivo móvil, enviar comprobantes a sus clientes y consultar cualquier información historica. 
            </p>
        </div>
        <!-- Example row of columns -->
        <div class="cd-pricing-container cd-has-margins">
            <div class="cd-pricing-switcher">
                <p class="fieldset">
                    <input type="radio" name="duration-2" value="monthly" id="monthly-2" checked>
                    <label for="monthly-2">Monotributista</label>
                    <input type="radio" name="duration-2" value="yearly" id="yearly-2">
                    <label for="yearly-2">Empresa</label>
                    <span class="cd-switch"></span>
                </p>
            </div> <!-- .cd-pricing-switcher -->

            <ul class="cd-pricing-list cd-bounce-invert">
                <li>
                    <ul class="cd-pricing-wrapper">
                        <li data-type="monthly" class="is-visible">
                            <header class="cd-pricing-header">
                                <h2>Abono Trimestral</h2>

                                <div class="cd-price">
                                    <span class="cd-currency">$</span>
                                    <span class="cd-value">1500</span>
                                    <span class="cd-duration">trimestral</span>
                                </div>
                            </header> <!-- .cd-pricing-header -->

                            <div class="cd-pricing-body">
                                <ul class="cd-pricing-features">
                                    <li><em><i class="fa fa-check-circle"></i></em>Facturación electrónica AFIP</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Reportes de venta / Iva Ventas </li>
                                    <li><em><i class="fa fa-remove"></i></em>Almacenamiento de PDFs ilimitado</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Almacenamiento de PDFs (2 años)</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Soporte en linea (skype / telefónico)</li>
                                </ul>
                            </div> <!-- .cd-pricing-body -->

                            <footer class="cd-pricing-footer">
                                <a class="cd-select" href="#">Purchase</a>
                            </footer>  <!-- .cd-pricing-footer -->
                        </li>

                        <li data-type="yearly" class="is-hidden">
                            <header class="cd-pricing-header">
                                <h2>Abono Trimestral</h2>

                                <div class="cd-price">
                                    <span class="cd-currency">$</span>
                                    <span class="cd-value">3000</span>
                                    <span class="cd-duration">trimestral</span>
                                </div>
                            </header> <!-- .cd-pricing-header -->

                            <div class="cd-pricing-body">
                                <ul class="cd-pricing-features">
                                    <li><em><i class="fa fa-check-circle"></i></em>Facturación electrónica AFIP</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Reportes de venta / Iva Ventas </li>
                                    <li><em><i class="fa fa-remove"></i></em>Almacenamiento de PDFs ilimitado</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Almacenamiento de PDFs (2 años)</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Soporte en linea (skype / telefónico)</li>
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
                                <h2>Abono Semestral</h2>
                                <div class="cd-price">
                                    <span class="cd-currency">$</span>
                                    <span class="cd-value">2500</span>
                                    <span class="cd-duration">Semestral</span>
                                </div>
                            </header> <!-- .cd-pricing-header -->

                            <div class="cd-pricing-body">
                                <ul class="cd-pricing-features">
                                    <li><em><i class="fa fa-check-circle"></i></em>Facturación electrónica AFIP</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Reportes de venta / Iva Ventas </li>
                                    <li><em><i class="fa fa-remove"></i></em>Almacenamiento de PDFs ilimitado</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Almacenamiento de PDFs (3 años)</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Soporte en linea (skype / telefónico)</li>
                                </ul>
                            </div> <!-- .cd-pricing-body -->

                            <footer class="cd-pricing-footer">
                                <a class="cd-select" href="#">Purchase</a>
                            </footer>  <!-- .cd-pricing-footer -->
                        </li>

                        <li data-type="yearly" class="is-hidden">
                            <header class="cd-pricing-header">
                                <h2>Abono Semestral</h2>
                                <div class="cd-price">
                                    <span class="cd-currency">$</span>
                                    <span class="cd-value">5000</span>
                                    <span class="cd-duration">semestral</span>
                                </div>
                            </header> <!-- .cd-pricing-header -->

                            <div class="cd-pricing-body">
                                <ul class="cd-pricing-features">
                                    <li><em><i class="fa fa-check-circle"></i></em>Facturación electrónica AFIP</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Reportes de venta / Iva Ventas </li>
                                    <li><em><i class="fa fa-remove"></i></em>Almacenamiento de PDFs ilimitado</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Almacenamiento de PDFs (3 años)</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Soporte en linea (skype / telefónico)</li>
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
                                <h2>Abono Anual</h2>

                                <div class="cd-price">
                                    <span class="cd-currency">$</span>
                                    <span class="cd-value">4000</span>
                                    <span class="cd-duration">anual</span>
                                </div>
                            </header> <!-- .cd-pricing-header -->

                            <div class="cd-pricing-body">
                                <ul class="cd-pricing-features">
                                    <li><em><i class="fa fa-check-circle"></i></em>Facturación electrónica AFIP</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Reportes de venta / Iva Ventas </li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Almacenamiento de PDFs ilimitado</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Soporte en linea (skype / telefónico)</li>
                                </ul>
                            </div> <!-- .cd-pricing-body -->

                            <footer class="cd-pricing-footer">
                                <a class="cd-select" href="#">Purchase</a>
                            </footer>  <!-- .cd-pricing-footer -->
                        </li>

                        <li data-type="yearly" class="is-hidden">
                            <header class="cd-pricing-header">
                                <h2>Abono Anual</h2>

                                <div class="cd-price">
                                    <span class="cd-currency">$</span>
                                    <span class="cd-value">8000</span>
                                    <span class="cd-duration">anual</span>
                                </div>
                            </header> <!-- .cd-pricing-header -->

                            <div class="cd-pricing-body">
                                <ul class="cd-pricing-features">
                                    <li><em><i class="fa fa-check-circle"></i></em>Facturación electrónica AFIP</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Reportes de venta / Iva Ventas </li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Almacenamiento de PDFs ilimitado</li>
                                    <li><em><i class="fa fa-check-circle"></i></em>Soporte en linea (skype / telefónico)</li>
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
</asp:Content>