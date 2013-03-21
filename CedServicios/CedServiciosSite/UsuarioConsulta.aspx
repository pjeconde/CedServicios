<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="CedServicios.Site.UsuarioConsulta" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Permisos del usuario"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px; padding-left:10px">
                <asp:Label ID="DatosPersonalesLabel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px; padding-left:10px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="PermisosGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowDataBound="gvParent_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DescrTipoPermiso" HeaderText="Permiso" SortExpression="DescrTipoPermiso">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdUN" HeaderText="Unid.Neg." SortExpression="IdUN">
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
            <td align="center" style="padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" Text="Salir" PostBackUrl="~/Default.aspx"/>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
