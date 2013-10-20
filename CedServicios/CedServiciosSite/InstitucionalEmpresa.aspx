<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalEmpresa.aspx.cs" Inherits="CedServicios.Site.InstitucionalEmpresa" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top: 20px">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Empresa"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="TextoMediano" Text="Nuestra empresa fue fundada en el año 1980 por un grupo de profesionales 
                    con el objetivo de cubrir las necesidades informáticas que el mercado requería en ese momento."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label3" runat="server" SkinID="TextoMediano" Text="Hoy en día, con más de 25 años de experiencia, estamos en condiciones de brindarle a Ud. una solución integrada 
                    para la gestión, control y desarrollo de negocios."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label4" runat="server" SkinID="TextoMediano" Text="Contamos no solo con personal altamente capacitado, 
                sino con el know how necesario adquirido a través de cientos de 
                implantaciones en las diversas áreas empresariales."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label5" runat="server" SkinID="TextoMediano" Text="Esta conjunción de elementos nos permite satisfacer a nuestros clientes 
                en tiempo y forma, permitiendo que obtengan la mejor tasa de retorno de la inversión."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <b>
                    <asp:Label ID="Label6" runat="server" Text="Desarrollos de sistemas a medida: "></asp:Label>
                </b>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label7" runat="server" SkinID="TextoMediano" Text="Productos desarrollados acordes a las necesidades del cliente, para empresas que se ven limitadas por las capacidades del software enlatado."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <b>
                    <asp:Label ID="Label8" runat="server" Text="Servicio de Software Factory: "></asp:Label>
                </b>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="Nos permite brindar a nuestros clientes, equipos de desarrollo especializados en la construcción de determinados tipos de aplicaciones."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <b>
                    <asp:Label ID="Label10" runat="server" Text="Soluciones llave en mano: "></asp:Label>
                </b>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="Soluciones probadas, creadas especialmente para el área comercial y financiera."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 24px; padding-top: 20px">
                <asp:Button ID="SolucionesButton" runat="server" TabIndex="1" Text="Soluciones" onclick="SolucionesButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="RefeComButton" runat="server" CausesValidation="false" TabIndex="2" Text="Referencias Comerciales" onclick="RefeComButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="ContactoButton" runat="server" CausesValidation="false" TabIndex="3" Text="Contacto" onclick="ContactoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="4" Text="Salir" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
