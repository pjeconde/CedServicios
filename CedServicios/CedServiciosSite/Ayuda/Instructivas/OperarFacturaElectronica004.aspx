<%@ Page Title="" Language="C#" MasterPageFile="~/CedServiciosAyuda.master" AutoEventWireup="true" CodeBehind="OperarFacturaElectronica004.aspx.cs" Inherits="CedServicios.Site.Ayuda.Instructivas.OperarFacturaElectronica004" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceAyuda" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Puntos de Venta"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label2" runat="server" SkinID="LabelAyuda" Text="Para crear un nuevo Punto de Venta, elegir la opción: Administración --> Punto de Venta --> Alta." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" SkinID="LabelAyuda" Text="El punto de venta queda relacionado al CUIT y UN (unidad de negocio) que estén seleccionados en ese momento (ver CUIT y UN seleccionados en el ángulo superior derecho)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label4" runat="server" SkinID="LabelAyuda" Text="Los datos imprescindibles, para crear un nuevo Punto de Venta, son:" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label6" runat="server" SkinID="LabelAyuda" Text="&#8226; Número: es el que se ha declarado ante la AFIP." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label7" runat="server" SkinID="LabelAyuda" Text="&#8226; Tipo: los valores posibles son Común, Exportación, Bono Fiscal y RG2904." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label8" runat="server" SkinID="LabelAyuda" Text="&#8226; Método de numeración de lotes(*): puede ser Autonumerador, TimeStamp (es decir que se compone con valores de fecha y hora) o Ninguno (el usuario define el número de lote cuando ingresa cada comprobante)." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label9" runat="server" SkinID="LabelAyuda" Text="&#8226; Último nro de lote: se ingresa sólo cuando el Método sea Autonumerador." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:5px">
                <asp:Label ID="Label5" runat="server" SkinID="LabelAyuda" Text="&#8226; Datos de Domicilio, de Contacto, Impositivos o Identificatorios: se ingresa sólo en el caso que deban diferir de los ya establecidos a nivel CUIT." ></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:Label ID="Label11" runat="server" SkinID="LabelAyuda" Text="(*) el lote es la unidad de envio de información tanto a la AFIP como a InterBanking, en nuestro caso: &quot;lote&quot; es igual a &quot;comprobante&quot;." ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>








