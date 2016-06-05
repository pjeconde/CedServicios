<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" Culture="en-GB" UICulture="en-GB" CodeBehind="PrecioImportacionExcel.aspx.cs" Inherits="CedServicios.Site.PrecioImportacionExcel" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <table align="center">
                    <tr>
                        <td colspan="2" style="padding-top:20px; text-align: center">
                            <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Importar Precios desde Excel"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table style="border:0;">
                                <tr>
                                    <td style="padding-top: 5px; padding-left:10px">
                                        <asp:FileUpload ID="XMLFileUpload" runat="server" Height="25px" Width="100%" size="100" ToolTip="Cargar los datos de un archivo XML."> 
                                        </asp:FileUpload>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 5px">
                                        <asp:Button ID="FileUploadButton" runat="server" CausesValidation="false" OnClick="FileUploadButton_Click" Text="Completar datos automáticamente desde archivo xml seleccionado" Width="100%" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="padding-top:20px">
                            Resultado:
                            <asp:textbox ID="MensajeLabel" runat="server" Text="" TextMode="MultiLine" style="resize: none; width: 100%; min-height: 100px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>