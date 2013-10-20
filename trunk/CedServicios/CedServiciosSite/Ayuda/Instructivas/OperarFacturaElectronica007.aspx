<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica007.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica007" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="¿ Cómo ingreso comprobantes ?"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Para crear un nuevo comprobante (factura electrónica), elegir la opción: Factura Electrónica --> Alta." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label5" runat="server" SkinID="LabelAyuda" Text="Cuando se ingrese a esta opción, por primera y única vez, se mostrará una página que permitirá aceptar los términos y condiciones del servicio." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="LabelAyuda" Text="El comprobante queda relacionado al CUIT y UN (unidad de negocio) que estén seleccionados en ese momento (ver CUIT y UN seleccionados en el ángulo superior derecho)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="Los datos imprescindibles para crear un nuevo comprobante son:" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label6" runat="server" SkinID="LabelAyuda" Text="&#8226; Tipo de comprobante." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label7" runat="server" SkinID="LabelAyuda" Text="&#8226; Punto de venta." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label18" runat="server" SkinID="LabelAyuda" Text="&#8226; Número de comprobante." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label19" runat="server" SkinID="LabelAyuda" Text="&#8226; Fecha de emisión." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label8" runat="server" SkinID="LabelAyuda" Text="&#8226; Nro.de lote: si en la definición del Punto de Venta se estableció el 'Método de numeración de lotes' en 'Ninguno' ingresar manualmente.  De lo contrario hacer click en el botón 'Generar Nro.Lote' para que el sitio determine un valor en forma automática." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label9" runat="server" SkinID="LabelAyuda" Text="&#8226; INFORMACIÓN COMPRADOR: elegir, en el combo, uno de los clientes cargados previamente o ingresar manualmente los datos de un cliente nuevo." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label10" runat="server" SkinID="LabelAyuda" Text="&#8226; INFORMACIÓN COMPROBANTE: Fecha de vencimiento." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label11" runat="server" SkinID="LabelAyuda" Text="&#8226; DETALLE DE ARTÍCULOS / SERVICIOS: ingresar (y luego 'Agregar') el detalle de cada concepto (Artículo, Cantidad, Precio Unitario, etc).  Aqui se pueden elegir los artículos cargados previamente." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label12" runat="server" SkinID="LabelAyuda" Text="&#8226; RESUMEN FINAL: click en el botón 'Sugerir totales' para generar los totales del comprobante." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label20" runat="server" SkinID="LabelAyuda" Text="Por último. se podrá optar por alguna de las siguientes acciones (a través de sus respectivos botones):" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label17" runat="server" SkinID="LabelAyuda" Text="&#8226; Descargar archivo XML: descarga un archivo en formato XML, con el detalle del comprobante, que podrá 'subirse' al sitio Interfacturas." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label21" runat="server" SkinID="LabelAyuda" Text="&#8226; Enviar archivo XML a Email: envía por mail el archivo referido en el punto anterior." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label22" runat="server" SkinID="LabelAyuda" Text="&#8226; Previsualizar comprobante: muestra, en formato de impresión, el comprobante ingresado." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label23" runat="server" SkinID="LabelAyuda" Text="&#8226; Enviar lote a Interfacturas: sube, el comprobante ingresado, a Interfacturas sin necesidad de manipular archivos en formato XML.  Para tener disponible esta opción de deberá solicitar un certificado.  Pida nuestro asesoramiento para realizar esta gestión." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label24" runat="server" SkinID="LabelAyuda" Text="En breve, el sitio permitirá operar sobre la AFIP." ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
