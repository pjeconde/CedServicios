<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ConfiguracionModificar.aspx.cs" Inherits="CedServicios.Site.ConfiguracionModificar" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Modificación datos de Configuración"></asp:Label>
                            </h2>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <table align="center"> 
                        <tr>
			                <td style="padding-right:10px; text-align: left;">
                                <asp:Label ID="Label1" runat="server" Text="CUIT / UN predefinidos" ></asp:Label>
			                </td>
	                        <td style="padding-right:5px; text-align: left">
                                <asp:TextBox ID="CUITTextBox" runat="server" Width="86px" Text="ninguno" Enabled="false" ></asp:TextBox>
	                        </td>
			                <td style="vertical-align: top; text-align: left">
                                <asp:Label ID="Label3" runat="server" Text="/ " ></asp:Label>
                                <asp:TextBox ID="DescrUNTextBox" runat="server" Width="200px" Text="ninguno" Enabled="false" ></asp:TextBox>
                                <asp:TextBox ID="IdUNTextBox" runat="server" Visible="false" ></asp:TextBox>
                                <asp:Button ID="PredefinirCUITyUNactualesButton" runat="server" TabIndex="1" Text="Establecer CUIT / UN actuales como predefinidos" onclick="PredefinirCUITyUNactualesButton_Click" />
			                </td>
                        </tr>
                        <tr>
			                <td rowspan="3" style="padding-right:5px; padding-top:20px; vertical-align: top; text-align: left">
		                        <asp:Label ID="Label2" runat="server" Text="Imágen del usuario" ></asp:Label>
			                </td>
	                        <td rowspan="3" style="padding-right:5px; padding-top:20px; width: 90px; text-align: left">
                                <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="Imagenes/Interrogacion.jpg" Width="90px" />
	                        </td>
			                <td style="padding-top:20px; vertical-align: top; text-align: left">
		                        <asp:Label ID="Label4" runat="server" Text="(usar archivos: jpg, jpeg, png o gif)" ></asp:Label>
			                </td>
                        </tr>
                        <tr>
	                        <td style="padding-top:5px; text-align: left">
                                <asp:FileUpload ID="FileUpload1" runat="server" 
                                    ToolTip="Seleccione la imagen del usuario" Width="496px" size="63" TabIndex="1" 
                                    style="margin-bottom: 0px" />
			                </td>
                        </tr>
                        <tr>
	                        <td style="padding-top:5px; text-align: left">
                                <asp:Button ID="SubirImagenButton" runat="server" TabIndex="2" Text="Subir imagen seleccionada" Width="496px" onclick="SubirImagenButton_Click" />
			                </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
	                        <td style="padding-top:5px; text-align: left">
                                <asp:Button ID="BorrarImagenButton" runat="server" TabIndex="3" Text="Borrar" Width="92px" onclick="BorrarImagenButton_Click" />
			                </td>
                        </tr>
                        <tr>
			                <td style="padding-right:10px; padding-top:20px; vertical-align: top; text-align: left">
                                <asp:Label ID="Label5" runat="server" Text="Cantidad de renglones<br/>(en grillas con paginación)" ></asp:Label>
			                </td>
	                        <td style="padding-right:5px; padding-top:20px; vertical-align: top; text-align: left">
                                <asp:TextBox ID="CantidadFilasXPaginaTextBox" runat="server" Width="86px" Enabled="true" ></asp:TextBox>
	                        </td>
	                        <td style="padding-right:5px; padding-top:20px; vertical-align: top; text-align: left">
                                <asp:Button ID="ConfirmarCantidadFilasXPaginaButton" runat="server" TabIndex="3" Text="Confirmar" onclick="ConfirmarCantidadFilasXPaginaButton_Click" />
	                        </td>
                        </tr>
                        <tr>
			                <td style="padding-right:10px; padding-top:15px; vertical-align: top; text-align: left">
                                <asp:Label ID="Label6" runat="server" Text="Mostrar Ayuda" ></asp:Label>
			                </td>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td style="padding-right: 5px; padding-top: 15px; vertical-align: top; text-align: left">
                                            <asp:CheckBox ID="MostrarAyudaComoPaginaDefaultCheckBox" runat="server" Text="&nbsp;"
                                                AutoPostBack="true" OnCheckedChanged="MostrarAyudaComoPaginaDefaultCheckBox_CheckedChanged" />
                                        </td>
                                        <td style="text-align: left; padding-top: 8px;">
                                            (como página predeterminada)
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>    
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" Text="Salir" TabIndex="4" onclick="SalirButton_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center padding-top-20">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
