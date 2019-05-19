<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorAutorizacionLog.aspx.cs" Inherits="CedServicios.Site.ExploradorAutorizacionLog" Theme="CedServicios" %>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Autorizaciones (histórico)"></asp:Label>
                        </h2>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 text-center padding-top-20">
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
                </div>
                <div class="col-lg-12 col-md-12 text-center padding-top-20">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
