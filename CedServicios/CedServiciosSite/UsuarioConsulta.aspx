<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioConsulta.aspx.cs" Inherits="CedServicios.Site.UsuarioConsulta" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Permisos del usuario"></asp:Label>
                        </h2>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 text-center padding-top-20">
                    <asp:Image ID="Image1" runat="server" BorderStyle="Solid" BorderWidth="1px" BorderColor="#cccccc" ImageUrl="Imagenes/Interrogacion.jpg" Width="90px" />
	            </div>
                <div class="col-lg-12 col-md-12 text-center padding-top-20">
                    <asp:Label ID="DatosPersonalesLabel" runat="server"></asp:Label>
                </div>
                <div class="col-lg-12 col-md-12 text-center padding-top-20">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" HorizontalAlign="Center">
                        <asp:GridView ID="PermisosGridView" runat="server" CssClass="grilla" HorizontalAlign="Center" 
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
                </div>
                <div class="col-lg-12 col-md-12 text-center padding-top-20">
                    <asp:Button ID="ConfiguracionModificarButton" runat="server" class="btn btn-default btn-sm" Text="Modificar" TabIndex="1" PostBackUrl="~/ConfiguracionModificar.aspx"/>
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" Text="Salir" TabIndex="2" onclick="SalirButton_Click"/>    
                </div>
                <div class="col-lg-12 col-md-12 text-center padding-top-20">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
