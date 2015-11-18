<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalRefeCom.aspx.cs" Inherits="CedServicios.Site.InstitucionalRefeCom" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table style="padding-left:10px">
        <tr>
            <td style="padding-top:20px; text-align: left">
                <span class="glyphicon glyphicon-briefcase gi-1-5x"></span>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Referencias Comerciales"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px; text-align: left">
                <b>Agro</b><br />
                K+S Argentina S.R.L. • ADM ARGENTINA S.A.<br /><br />

                <b>Agroindustrial</b><br />
                Asamach S.R.L. • EQUITEC S.A. • Metalúrgica Patria S.R.L. • Microservice S.T.I. S.R.L.<br /><br />

                <b>Bancos</b><br />
                Banco Galicia • Banco de Liniers Sudamericano • Banco Medefin<br /><br />

                <b>Centros Comerciales</b><br />
                Alto Palermo Shopping • Abasto de Buenos Aires • Alto Avellaneda Shopping Mall • Buenos Aires Design (Emprendimiento Recoleta S.A.)<br />
                Paseo Alcorta • Patio Bullrich • Nuevo Norte Shopping S.A. (Salta)<br /><br />

                <b>Constructoras</b><br />
                Boris Lend Lease S.A. • Alhena S.A. • Blasi y Vazquez Constructora S.A.<br /><br />

                <b>Fondos Comunes de Inversión (Administración)</b><br />
                Galicia Administradora de Fondos<br /><br />

                <b>Frigoríficos</b><br />
                AMANCAY SAICAFI<br /><br />

                <b>Hiper-Super-Mini Mercados</b><br />
                Disco S.A. • Supermercados La Gran Provisión • Casa Tía • Captar S.A. (Tarjeta de compra) • Supermercados Elefante (Mar del Plata)<br />
                Carrefour Argentina S.A • Stop (minimercados en estaciones de servicio) • Provisión El Quijote<br /><br />

                <b>Industria</b><br />
                CERAMICA ALBERDI S.A. • GRUPELEC S.A. • Integral Gráfica S.A. • Premium Gráfica • Grafo Stil S.R.L.<br /><br />

                <b>Informática</b><br />
                Extreme Connection S.A. • Ribox S.R.L.<br /><br />

                <b>Inmobiliarias</b><br />
                Fibesa S.A.<br /><br />

                <b>Obra Social</b><br />
                OPDEA Obra Soc.Pers.Direc.Emp. de la Alimentación<br /><br />

                <b>Otras</b><br />
                Rossi y Moscatelli S.A.(autopartes) • FreeHouse S.R.L. • Elías Walter Esquenazzi S.R.L.(Río IV, Cba.) • Grisell S.A.(Río IV, Cba.)<br /><br />

                <b>Publicidad</b><br />
                Delfino Magnus S.A. • Ing. Augusto Spinazzola S.C.A • Julius Vía Pública S.A. • Meca Media Group • Caled Vía Pública<br />
                y División Aeropuertos • Vía Pública Clan S.A. • Verdad Publicidad S.A. • Publipal S.R.L. • Ital-Art S.A. • Poster S.A.(Uruguay)<br /><br />

                <b>Telemarketing</b><br />
                Compra Directa • TV Compras • Clasiclips (Hogar y Ventas S.R.L.) • Editorial Video Idiomas S.R.L.<br /><br />

                <b>Transporte</b><br />
                José Fiorentino y Cía. S.R.L
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 24px; padding-top: 20px">
                <asp:Button ID="EmpresaButton" runat="server" TabIndex="1" Text="Empresa" onclick="EmpresaButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SolucionesButton" runat="server" CausesValidation="false" TabIndex="2" Text="Soluciones" onclick="SolucionesButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="ContactoButton" runat="server" CausesValidation="false"  TabIndex="3" Text="Contacto" onclick="ContactoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="4" Text="Salir" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-bottom: 30px; padding-top: 20px">
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
