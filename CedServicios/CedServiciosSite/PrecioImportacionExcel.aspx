<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" Culture="en-GB" UICulture="en-GB" CodeBehind="PrecioImportacionExcel.aspx.cs" Inherits="CedServicios.Site.PrecioImportacionExcel" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <table align="center">
                    <tr>
                        <td style="padding-top:20px; text-align: center">
                            <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Importar Precios desde archivo Excel"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right:5px; padding-top: 20px; text-align:center">
                             <asp:Label ID="Label3" runat="server" Text="Listas de Precios pertenecientes al CUIT"></asp:Label>
                            <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" Width="90px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top:5px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height:1px; background-color:#cccccc">
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top:5px; padding-left:10px; padding-top:25px">
                            <asp:FileUpload ID="XMLFileUpload" runat="server" Height="25px" Width="100%" size="100" ToolTip="Importar precios desde un archivo Excel"> 
                            </asp:FileUpload>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top: 5px">
                            <asp:Button ID="FileUploadButton" runat="server" CausesValidation="false" OnClick="FileUploadButton_Click" Text="Importar precios desde el archivo seleccionado" Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="padding-top:20px">
                            Resultado:
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:textbox ID="MensajeLabel" runat="server" Text="" TextMode="MultiLine" style="width: 100%; min-height: 100px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>