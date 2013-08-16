<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorAutorizacionLog.aspx.cs" Inherits="CedServicios.Site.ExploradorAutorizacionLog" Theme="CedServicios" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Autorizaciones (histórico)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="AutorizacionesGridView" runat="server" 
                        AutoGenerateColumns="false" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Evento" HeaderText="Evento" SortExpression="Evento">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescrTipoPermiso" HeaderText="Permiso" SortExpression="DescrTipoPermiso">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" SortExpression="NombreUsuario">
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
                            <asp:BoundField DataField="TipoAccion" HeaderText="Origen" SortExpression="TipoAccion">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreUsuarioSolicitante" HeaderText="Usuario solicitante" SortExpression="NombreUsuarioSolicitante">
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
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
