<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalEmpresa.aspx.cs" Inherits="CedServicios.Site.InstitucionalEmpresa" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
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
            <asp:Button ID="SolucionesButton" runat="server" TabIndex="1" Text="Soluciones" onclick="SolucionesButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            <asp:Button ID="RefeComButton" runat="server" CausesValidation="false" TabIndex="2" Text="Referencias Comerciales" onclick="RefeComButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            <asp:Button ID="ContactoButton" runat="server" CausesValidation="false" TabIndex="3" Text="Contacto" onclick="ContactoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="4" Text="Salir" onclick="SalirButton_Click" />
        </p>
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
