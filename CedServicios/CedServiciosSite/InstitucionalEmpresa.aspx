<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalEmpresa.aspx.cs" Inherits="CedServicios.Site.InstitucionalEmpresa" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container-fluid">
    <div class="row text-center">
        <div class="col-lg-12">
        <p>
            <br />
            <span class="glyphicon glyphicon-home gi-1-5x"></span>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Empresa"></asp:Label>
        </p>
        <p>
            Nuestra empresa fue fundada en el año 1980 por un grupo de profesionales con el objetivo de cubrir las necesidades informáticas que el mercado requería en ese momento.<br /> 
            Hoy en día, con más de 35 años de experiencia, estamos en condiciones de brindarle a Ud. una solución integrada para la gestión, control y desarrollo de negocios.<br /><br />
            Contamos no solo con personal altamente capacitado, sino con el <i>'know how'</i> adquirido a través de cientos de implementaciones en las diversas áreas empresariales.<br />Esta conjunción de elementos nos permite satisfacer a nuestros clientes en tiempo y forma, permitiendo que obtengan la mejor tasa de retorno de la inversión.
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
