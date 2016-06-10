<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="VentasXArticuloWebForm.aspx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Reportes.VentasXArticuloWebForm" Theme="CedServicios" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
        <p style="text-align: center">
        <asp:Button ID="SalirButton" class="btn btn-default btn-sm" runat="server" CausesValidation="false" TabIndex="9" Text="Cerrar" onclick="SalirButton_Click" />
        <input type="button" class="btn btn-default btn-sm" value="Volver atrás" name="Volver" onclick="history.back()" />
        </p>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        <br />
    </div>
    </div>
    </div>
</asp:Content>

