<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="CedServicios.Site.UsuarioConsulta" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Permisos del usuario"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="padding-top:20px">
                <asp:Label ID="DatosPersonalesLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="PermisosGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowDataBound="PermisosGridView_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DescrTipoPermiso" HeaderText="Permiso" SortExpression="DescrTipoPermiso">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescrUN" HeaderText="Unidad de Negocio" SortExpression="DescrUN">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
	        <td align="left" rowspan="3" style="padding-right:5px; padding-top:20px">
                <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="Imagenes/Interrogacion.jpg" Width="90px" />
	        </td>
			<td align="left" valign="top" style="padding-top:20px">
		        <asp:Label ID="Label4" runat="server" Text="Imágen del usuario<br />(usar archivos: jpg, jpeg, png o gif)" ></asp:Label>
			</td>
        </tr>
        <tr>
	        <td align="left" style="padding-top:5px">
                <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Seleccione la imagen del usuario" TabIndex="1" />
			</td>
        </tr>
        <tr>
	        <td align="left" style="padding-top:5px">
                <asp:Button ID="SubirImagenButton" runat="server" TabIndex="2" Text="Subir imagen seleccionada" onclick="SubirImagenButton_Click" />
			</td>
        </tr>
        <tr>
	        <td align="left" colspan="2" style="padding-top:5px">
                <asp:Button ID="BorrarImagenButton" runat="server" TabIndex="3" Text="Borrar" Width="92px" onclick="BorrarImagenButton_Click" />
			</td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" Text="Salir" TabIndex="4" PostBackUrl="~/Default.aspx"/>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
