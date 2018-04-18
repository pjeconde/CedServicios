<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InicioBusquedas.aspx.cs" Inherits="CedServicios.Site.InicioBusquedas" Theme="CedServicios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" Visible="true" ContentPlaceHolderID="ContentPlaceDefault" runat="server">

<section id="features" class="features sections2">
    <div class="container">
        <div class="row">
            <div class="main_features_content2">
                <div class="head_title">
                    <div class="head_title text-center">
                        <h2>Busquedas Laborales</h2>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="single_features_left text-left">
                        <p>
                        <img src="Imagenes/Iconos/PagPpal/rrhh.png" style="width: 75px; height: 75px" />
                        </p>
                        <h3>WEB DEVELOPERS SENIOR </h3>
                        <p>DESCRIPCIÓN:<br /> 
                        Para importante entidad bancaria seleccionaremos desarrolladores web con conocimientos y experiencia mayor a 5 años con las herramientas de Microsoft: Visual Studio 2010 o superior, C#.NET, ASP.NET, Frameworks 4.0 o superior, Javascript y T-SQL.<br/>
                        Otros conocimientos como Crystal Reports, AJAX, MVC, Angular, Aplicaciones de consola y Servicios de Windows seran teniedos en cuenta.<br/><br/> 
                        Valoraremos aquellas personas que demuestren responsabilidad y compromiso como así también las que estén dispuestas al aprendizaje continuo. <br/>La empresa ofrece muy buenas condiciones de contratación, excelente clima laboral y grandes posibilidades de desarrollo dentro del grupo. 
                        </p>
                        REQUISITOS
                        <ul class="list-unstyled">
                            <li> <span class="glyphicon glyphicon-ok"></span> Indicar remuneración bruta pretendida. </li>
                            <li> <span class="glyphicon glyphicon-ok"></span> Lugar de residencia: Capital Federal, GBA.</li>
                            <li> <span class="glyphicon glyphicon-ok"></span> Educación: Universitario, Graduado, En curso.</li>
                            <li> <span class="glyphicon glyphicon-ok"></span> Idioma: Inglés Intermedio.</li>
                        </ul>
                        <div class="features_buttom">
                            <a href="mailto:rrhh@cedeira.com.ar?Subject='Ref. WEB DEVELOPERS SENIOR'"><i class="fa fa-envelope"></i>&nbsp rrhh@cedeira.com.ar</a>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="single_features_left text-left">
                        <p>
                        <img src="Imagenes/Iconos/PagPpal/rrhh.png" style="width: 75px; height: 75px"/>
                        </p>
                        <h3>WEB DEVELOPERS SEMI-SENIORS </h3>
                        <p>DESCRIPCIÓN:<br />
                        Para importante entidad bancaria seleccionaremos desarrolladores web con conocimientos y experiencia mayor a 3 años con las herramientas de Microsoft: Visual Studio 2010 o superior, C#.NET, ASP.NET, Frameworks 4.0 o superior y T-SQL.<br/><br/> 
                        Valoraremos aquellas personas que demuestren responsabilidad y compromiso como así también las que estén dispuestas al aprendizaje continuo. <br/>La empresa ofrece muy buenas condiciones de contratación, excelente clima laboral y grandes posibilidades de desarrollo dentro del grupo. 
                        </p>
                        REQUISITOS
                        <ul class="list-unstyled">
                            <li> <span class="glyphicon glyphicon-ok"></span> Indicar remuneración bruta pretendida. </li>
                            <li> <span class="glyphicon glyphicon-ok"></span> Lugar de residencia: Capital Federal, GBA.</li>
                            <li> <span class="glyphicon glyphicon-ok"></span> Educación: Universitario, Graduado, En curso.</li>
                            <li> <span class="glyphicon glyphicon-ok"></span> Idioma: Inglés Basico.</li>
                        </ul>
                        <div class="features_buttom">
                            <a href="mailto:rrhh@cedeira.com.ar?Subject='Ref. WEB DEVELOPERS SEMI-SENIOR'"><i class="fa fa-envelope"></i>&nbsp rrhh@cedeira.com.ar</a>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <p>
                                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Seleccionar archivo CV" Width="100%" TabIndex="1" />
                                <asp:Button ID="SubirCVButton" runat="server" TabIndex="2" Text="Subir el CV" Width="100%" OnClick="SubirCVButton_Click" class="btn btn-default" />
                            </p>
                        </div>
                    </div>
                </div>
           </div>
     </div>
</section>
</asp:Content>
