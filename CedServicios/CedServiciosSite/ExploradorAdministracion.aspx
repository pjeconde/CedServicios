<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorAdministracion.aspx.cs" Inherits="CedServicios.Site.ExploradorAdministracion" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
    <div class="container">
        <div class="row">
            <div class="main_features_content2">
                <div class="head_title">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Administración del Site"></asp:Label>
                        </h2>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12 col-md-12">
                Aplicación Start:
                <asp:Label ID="AplicationStartLabel" runat="server"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12">        
                Contador de Visitas:
                <asp:Label ID="ContadorVisitasLabel" runat="server"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12">        
                Visitantes Activos:
                <asp:Label ID="VisitantesLabel" runat="server"></asp:Label>
             </div>
             <div class="col-lg-12 col-md-12">        
                Sesiones Activas:
                <asp:Label ID="SesionesActivasLabel" runat="server"></asp:Label>
             </div>
         </div>
         <div class="row">   
             <div class="col-lg-12 col-md-12 padding-top-20">        
                <asp:Button ID="RefrescarButton" runat="server" TabIndex="8" Text="Refrescar" OnClick="RefrescarButton_Click"
                    OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
             </div>
             <div class="col-lg-12 col-md-12 padding-top-20">        
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </div>
        </div>
    </div>
    </section>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
