<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="CedServicios.Site.UsuarioConsulta" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12 center-block text-center">
    <%--<div class="container">
        <div class="row">
        <div class="col-lg-12 col-md-12 center-block text-center ">
            
        </div>
        </div>
        </div>--%>
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px;">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Permisos del usuario"></asp:Label>
            </td>
        </tr>
        <tr>
	        <td align="left" style="padding-right:5px; padding-top:20px">
                <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="Imagenes/Interrogacion.jpg" Width="90px" />
	        </td>
            <td align="left" style="padding-top:20px">
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
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Button ID="ConfiguracionModificarButton" runat="server" Text="Modificación datos de Configuración" TabIndex="1" PostBackUrl="~/ConfiguracionModificar.aspx"/>
                <asp:Button ID="SalirButton" runat="server" Text="Salir" TabIndex="2" onclick="SalirButton_Click"/>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
</asp:Content>
