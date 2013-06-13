<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ConfiguracionModificar.aspx.cs" Inherits="CedServicios.Site.ConfiguracionModificar" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Modificación datos de Configuración"></asp:Label>
            </td>
        </tr>
        <tr>
			<td align="left" style="padding-right:10px; padding-top:20px">
                <asp:Label ID="Label1" runat="server" Text="CUIT / UN predefinidos" ></asp:Label>
			</td>
	        <td align="left" style="padding-right:5px; padding-top:20px">
                <asp:TextBox ID="CUITTextBox" runat="server" Width="86px" Text="ninguno" Enabled="false" ></asp:TextBox>
	        </td>
			<td align="left" valign="top" style="padding-top:20px">
                <asp:Label ID="Label3" runat="server" Text="/ " ></asp:Label>
                <asp:TextBox ID="DescrUNTextBox" runat="server" Width="100px" Text="ninguno" Enabled="false" ></asp:TextBox>
                <asp:TextBox ID="IdUNTextBox" runat="server" Visible="false" ></asp:TextBox>
                <asp:Button ID="PredefinirCUITyUNactualesButton" runat="server" TabIndex="1" Text="Establecer CUIT / UN actuales como predefinidos" onclick="PredefinirCUITyUNactualesButton_Click" />
			</td>
        </tr>
        <tr>
			<td align="left" rowspan="3" valign="top" style="padding-right:5px; padding-top:20px">
		        <asp:Label ID="Label2" runat="server" Text="Imágen del usuario" ></asp:Label>
			</td>
	        <td align="left" rowspan="3" style="padding-right:5px; padding-top:20px" width="90px">
                <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="Imagenes/Interrogacion.jpg" Width="90px" />
	        </td>
			<td align="left" valign="top" style="padding-top:20px">
		        <asp:Label ID="Label4" runat="server" Text="(usar archivos: jpg, jpeg, png o gif)" ></asp:Label>
			</td>
        </tr>
        <tr>
	        <td align="left" style="padding-top:5px">
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Seleccione la imagen del usuario" Width="296px" size="31" TabIndex="1" />
			</td>
        </tr>
        <tr>
	        <td align="left" style="padding-top:5px">
                <asp:Button ID="SubirImagenButton" runat="server" TabIndex="2" Text="Subir imagen seleccionada" Width="296px" onclick="SubirImagenButton_Click" />
			</td>
        </tr>
        <tr>
            <td>
            </td>
	        <td align="left" style="padding-top:5px">
                <asp:Button ID="BorrarImagenButton" runat="server" TabIndex="3" Text="Borrar" Width="92px" onclick="BorrarImagenButton_Click" />
			</td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" Text="Salir" TabIndex="4" PostBackUrl="~/Default.aspx"/>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
