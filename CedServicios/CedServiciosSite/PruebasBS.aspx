<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PruebasBS.aspx.cs" Inherits="CedServicios.Site.PruebasBS" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    
    <div class="row">
        <div class="col-lg-12" style="background-color: Gray">
            ...
        </div>
    </div>
    
    <div class="row bg-info">
        <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModalLarge">
            modal demo 1
        </button>
        <div id="myModalLarge" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
              <div class="modal-content">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                  <h4 class="modal-title" id="H1">Modal title</h4>
                </div>
                <div class="modal-body">
                  <h4>Text in a modal</h4>
                  <p>Duis mollis, est non commodo luctus, nisi erat porttitor ligula.</p>

                  <h4>Popover in a modal</h4>
                  <p>This <a href="#" role="button" class="btn btn-default popover-test" title="A Title" data-content="And here's some amazing content. It's very engaging. right?">button</a> should trigger a popover on click.</p>

                  <h4>Tooltips in a modal</h4>
                  <p><a href="#" class="tooltip-test" title="Tooltip">This link</a> and <a href="#" class="tooltip-test" title="Tooltip">that link</a> should have tooltips on hover.</p>

                  <hr>

                  <h4>Overflowing text to show scroll behavior</h4>
                  <p>Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.</p>
                  <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.</p>
                  <p>Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.</p>
                  <p>Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.</p>
                  <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.</p>
                  <p>Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.</p>
                  <p>Cras mattis consectetur purus sit amet fermentum. Cras justo odio, dapibus ac facilisis in, egestas eget quam. Morbi leo risus, porta ac consectetur ac, vestibulum at eros.</p>
                  <p>Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Vivamus sagittis lacus vel augue laoreet rutrum faucibus dolor auctor.</p>
                  <p>Aenean lacinia bibendum nulla sed consectetur. Praesent commodo cursus magna, vel scelerisque nisl consectetur et. Donec sed odio dui. Donec ullamcorper nulla non metus auctor fringilla.</p>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                  <button type="button" class="btn btn-primary">Save changes</button>
                </div>

              </div><!-- /.modal-content -->
            </div><!-- /.modal-dialog -->
        </div><!

        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#myModal">
            modal demo 2
        </button>
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">
                            Modal title</h4>
                    </div>
                    <div class="modal-body">
                        ...
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                        <button type="button" class="btn btn-primary">
                            Save changes</button>
                    </div>
                </div>
            </div>
        </div>

        <button type="button" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#Prueba1">
            modal demo 3
        </button>
        <div id="Prueba1" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    Buenos dias !!!<br /> 
                    Contamos con personal altamente capacitado.
                </div>
            </div>
        </div>
   </div>  

    <div class="container-fluid">
    <div class="row">
        <div class="col-lg-12">
        <p>
            <br />
            <span class="glyphicon glyphicon-home"></span> <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Empresa"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" SkinID="TextoMediano" Text="Nuestra empresa fue fundada en el año 1980 por un grupo de profesionales con el objetivo de cubrir las necesidades informáticas que el mercado requería en ese momento.<br /> 
                Hoy en día, con más de 25 años de experiencia, estamos en condiciones de brindarle a Ud. una solución integrada para la gestión, control y desarrollo de negocios.<br /><br />
                Contamos no solo con personal altamente capacitado, sino con el know how necesario adquirido a través de cientos de implantaciones en las diversas áreas empresariales.<br />Esta conjunción de elementos nos permite satisfacer a nuestros clientes en tiempo y forma, permitiendo que obtengan la mejor tasa de retorno de la inversión.">
            </asp:Label>
        </p>
        <p>
            <div class="row">
              <div class="col-sm-6 col-md-4">
                <div class="thumbnail">
                  <img src="Imagenes/Empresa/SoftwareAMedida.jpg" alt="..."/>
                  <div class="caption">
                    <h3>Desarrollo de Sistemas a medida</h3>
                    <p>Producto desarrollado acorde a las necesidades del cliente y de su negocio. Para empresas que se ven limitadas por las capacidades del software enlatado.</p>
                    <p><a href="#" class="btn btn-primary" role="button">Ver más</a>
                  </div>
                </div>
              </div>
            </div>
            <b><asp:Label ID="Label6" runat="server" Text="Desarrollos de sistemas a medida: "></asp:Label></b>
            <asp:Label ID="Label7" runat="server" SkinID="TextoMediano" Text="Productos desarrollados acordes a las necesidades del cliente, para empresas que se ven limitadas por las capacidades del software enlatado."></asp:Label>
        </p>
        <p>
            <b><asp:Label ID="Label8" runat="server" Text="Servicio de Software Factory: "></asp:Label></b>
            <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="Nos permite brindar a nuestros clientes, equipos de desarrollo especializados en la construcción de determinados tipos de aplicaciones."></asp:Label>
        </p>
        <p>
            <b>
            <asp:Label ID="Label10" runat="server" Text="Soluciones llave en mano: "></asp:Label>
            </b>
            <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="Soluciones probadas, creadas especialmente para el área comercial y financiera."></asp:Label>
        </p>            
        <p>
            <asp:Button ID="SolucionesButton" runat="server" CssClass="btn btn-primary" TabIndex="1" Text="Soluciones" onclick="SolucionesButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            <asp:Button ID="RefeComButton" runat="server" CssClass="btn btn-primary" CausesValidation="false" TabIndex="2" Text="Referencias Comerciales" onclick="RefeComButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            <asp:Button ID="ContactoButton" runat="server" CssClass="btn btn-primary" CausesValidation="false" TabIndex="3" Text="Contacto" onclick="ContactoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            <asp:Button ID="SalirButton" runat="server" CssClass="btn btn-primary" CausesValidation="false" TabIndex="4" Text="Salir" onclick="SalirButton_Click" />        </p>
        <p>
            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
        </p>
        </div>
    </div>
    </div>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
