<%@ Page Language="C#" Theme="CedServicios" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="FacturaElectronicaTYC.aspx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.FacturaElectronicaTYC"  %>

<asp:Content ID="Content2" runat="Server" ContentPlaceHolderID="ContentPlaceDefault">
    <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="height: 500px;
        width: 800px; text-align: left;">
        <tr>
            <td style="height: 10px" valign="top">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; width: 700px" valign="top">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width: 21px; height: 20px;">
                            <asp:Image ID="Image2" runat="server" AlternateText="o" ImageUrl="~/Imagenes/CajaBrownPeru.ico" />
                        </td>
                        <td style="height: 20px;">
                            <asp:Label ID="LabelTitFacturaElectronica" runat="server" SkinID="TituloPagina" Text="Factura Electrónica"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td style="width: 15px; height: 10px">
                        </td>
                        <td style="">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15px; height: 21px">
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" SkinID="TituloColor1Mediano" Text="Términos y Condiciones"></asp:Label>
                            <br />
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label1" runat="server" SkinID="TextoMediano" Text='Los siguientes términos y condiciones generales regularán expresamente las relaciones surgidas entre este Portal www.cedeira.com.ar de Cedeira Software Factory S.R.L ( en adelante "NUESTRA EMPRESA" ) y Usted (en adelante el "USUARIO o USUARIOS") en virtud de las cuales NUESTRA EMPRESA le brinda servicios de generación de comprobantes electrónicos en un archivo de formato XML, ya sea que se trate de nuevos USUARIOS o aquellos vinculados a través de cualquier acuerdo previo que pudiera existir entre las partes. Este acuerdo sustituye cualquier otra comunicación previa oral o de otro tipo, que haya habido entre las partes. '></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="height: 5px">
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label4" runat="server" SkinID="TextoMediano" Text="La utilización del Portal www.cedeira.com.ar atribuye la condición de USUARIO del Portal, sea persona física o jurídica, e implica la aceptación plena y sin reservas de todas y cada una de las disposiciones incluídas en estos términos y condiciones que se detallan a continuación."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="">
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label6" runat="server" SkinID="TituloColor1Mediano" Text="NUESTRA EMPRESA:"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label3" runat="server" SkinID="TituloColor1Mediano" Text="1."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="No asume ninguna responsabilidad por la utilización de los presentes modelos de carga de comprobantes, ya que sólo los ofrece a modo de simplificar las tareas en la carga de la información del comprobante electrónico que solicita Interfacturas. "></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label5" runat="server" SkinID="TituloColor1Mediano" Text="2."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="No asume responsabilidad alguna sobre los datos de los comprobantes que usted envíe a Interfacturas. La información generada desde este sitio web, puede ser modificada por usted."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label7" runat="server" SkinID="TituloColor1Mediano" Text="3."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label13" runat="server" SkinID="TextoMediano" Text="Se reserva el derecho unilateral de suspender temporalmente o de terminar definitivamente la prestación del servicio a través del Portal. "></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label10" runat="server" SkinID="TituloColor1Mediano" Text="4."></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Se reserva el derecho de modificar unilateralmente y en cualquier momento el sistema de acceso al servicio."></asp:Label></td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label12" runat="server" SkinID="TituloColor1Mediano" Text="5."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label16" runat="server" SkinID="TextoMediano" Text="No garantiza que el sitio web vaya a funcionar en forma constante, fiable y correctamente, sin retrasos o interrupciones, por lo que no se hace responsable de los daños y prejuicios que puedan derivarse de los posibles fallos en disponibilidad y continuidad técnica del sitio web."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label14" runat="server" SkinID="TituloColor1Mediano" Text="6."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label15" runat="server" SkinID="TextoMediano" Text="No presenta ninguna garantía, explicita o implícitamente, acerca de la utilización de este servicio."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="width: 15px; height: 21px" valign="top">
                                                    <asp:Label ID="Label17" runat="server" SkinID="TituloColor1Mediano" Text="7."></asp:Label></td>
                                                <td style="">
                                                    <asp:Label ID="Label18" runat="server" SkinID="TextoMediano" Text="No será responsable por cualquier daño y/o perjuicio y/o beneficio dejado de obtener por el usuario o cualquier otro tercero causados directa o indirectamente por la conexión y/o utilización y/o acceso al sitio web www.cedeira.com.ar o a páginas enlazadas a él."></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="">
                                            <tr>
                                                <td style="height: 5px">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label20" runat="server" SkinID="TituloColor1Mediano" Text="Ley aplicable y jurisdicción competente"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="height: 5px">
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 21px">
                                    </td>
                                    <td style="">
                                        <asp:Label ID="Label22" runat="server" SkinID="TextoMediano" Text="El USUARIO acepta que la legislación aplicable al funcionamiento de este servicio es la argentina y se somete a la jurisdicción de los juzgados y tribunales de la Ciudad Autónoma de Buenos Aires para la resolución de las divergencias que se deriven de la interpretación o aplicación de este clausulado."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="width: 2px">
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 715px">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="width: 700px">
                                        <asp:Panel ID="PanelAceptaTYC" runat="server" Height="69px" Width="700px">
                                            <table style="">
                                                <tr>
                                                    <td style="height: 21px; width: 15px;">
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxAceptarTYC" runat="server" Font-Bold="True" ForeColor="Green"
                                                            Text="Acepta los términos y condiciones" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <table style="">
                                                <tr>
                                                    <td style="width: 15px;">
                                                    </td>
                                                    <td style="height: 48px">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="">
                                                            <tr>
                                                                <td style="width: 80px; height: 24px;">
                                                                    <asp:Button ID="ButtonAceptar" runat="server" OnClick="ButtonAceptar_Click" Text="Confirmar" />
                                                                </td>
                                                                <td style="height: 24px">
                                                                    <asp:Button ID="ButtonRechazar" runat="server" PostBackUrl="~/FacturaElectronica.aspx"
                                                                        Text="Rechazar" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="width: 258px">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="width: 258px">
                                        <table style="">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label19" runat="server" Font-Bold="true" ForeColor="red" Text="»"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:HyperLink ID="HyperLinkVolverPagAnt" runat="server" NavigateUrl="~/Facturacion/Electronica/FacturaElectronicaTYC.aspx"
                                                        SkinID="LinkMedianoClaro">Volver</asp:HyperLink>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table style="">
                                <tr>
                                    <td style="width: 15px; height: 15px">
                                    </td>
                                    <td style="">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
