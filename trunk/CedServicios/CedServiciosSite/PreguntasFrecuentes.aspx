<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PreguntasFrecuentes.aspx.cs" Inherits="CedServicios.Site.PreguntasFrecuentes" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Preguntas frecuentes"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="¿Qué es factura electrónica?" ForeColor="#e8906e"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                Es un documento comercial en formato electrónico que reemplaza al documento físico tradicional (papel).
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:Label ID="Label2" runat="server" Font-Bold="true" Text="¿Cómo adquiere validez la factura electrónica?" ForeColor="#e8906e"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                El C.A.E. es el código de autorización electrónico, que otorga la AFIP a cada documento para darle validez. Un documento con C.A.E. indica que fue autorizado por la AFIP. A través de InterFacturas no tiene que preocuparse por realizar la gestión de C.A.E. ya que se realiza de forma automática.
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:Label ID="Label3" runat="server" Font-Bold="true" Text="¿Se podrá utilizar la factura tradicional (en papel) alternativamente a la factura electrónica?" ForeColor="#e8906e"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                La resolución R.G. 2485/08, en su artículo 4 establece los comprobantes excluidos del régimen de factura electrónica.
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:Label ID="Label4" runat="server" Font-Bold="true" Text="¿Cuáles son las características de los comprobantes electrónicos?" ForeColor="#e8906e"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                * Poseen efectos fiscales frente a terceros si el documento electrónico contiene el Código de Autorización Electrónico “CAE”, asignado por la AFIP. * Son identificados con un punto de venta específico, distinto a los utilizados para la emisión de comprobantes manuales o a través de controlador fiscal. * Deben tener correlatividad numérica.
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:Label ID="Label5" runat="server" Font-Bold="true" Text="¿Cuáles son las características de los comprobantes electrónicos?" ForeColor="#e8906e"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                Los sujetos que hubieran efectuado la comunicación con la fecha a partir de la cual comenzarán a emitir los comprobantes electrónicos originales, se encuentran obligados a cumplir, para todas las actividades, con lo dispuesto en: 1. El Título I de la Resolución General Nº 1361, sus modificatorias y complementarias, referido a la emisión y almacenamiento de duplicados electrónicos de comprobantes. 2. El Título II de la citada resolución general, respecto del almacenamiento electrónico de registraciones. Fuente: Art.9 RG 2485/08
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="¿En qué plazo debe ser puesta a disposición la factura electrónica?" ForeColor="#e8906e"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                Dentro de los 10 días corridos contados desde la asignación del 'C.A.E.'.  Fuente: Art.30 RG 2485/08
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:Label ID="Label7" runat="server" Font-Bold="true" Text="¿Cómo pongo, la factura electrónica, a disposición de mis clientes?" ForeColor="#e8906e"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left">
                Interfacturas pone a su disposición el sitio Web para que sus clientes se registren y puedan visualizar sus facturas electrónicas. Para mayor información consulte
                <asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="http://www.interfacturas.com.ar/" Target="_blank">aqui</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label8" runat="server" Font-Bold="true" Text="Para más información visite:" ForeColor="#e8906e"></asp:Label>&nbsp
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.afip.gov.ar/efactura/" Target="_blank">AFIP-Factura Electrónica / Comprobantes en Línea</asp:HyperLink>
            </td>
        </tr>
</asp:Content>
