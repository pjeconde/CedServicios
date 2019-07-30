<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ArticuloConsultaConFiltros.aspx.cs" Inherits="CedServicios.Site.ArticuloConsultaConFiltros" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <style type="text/css">
        .popover {
            min-width: 500px;
        }
    </style>
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Artículos"></asp:Label>
                            </h2>
                            <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-6 padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:25px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Descripción:&nbsp;</span>
                        <asp:TextBox ID="DescrTextBox" runat="server" MaxLength="50" TabIndex="2" CssClass="form-control" ToolTip="" Height="25px" Width="100%" placeholder="Ingrese parte de la descripción"></asp:TextBox>
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:40px">
                            <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA (DESCRIPCION)" data-content="Puede ingresar parte de la Descripción del artículo para realizar las búsqueda."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                        </span>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:25px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Id.Artículo:&nbsp;</span>
                        <asp:TextBox ID="IdArticuloTextBox" runat="server" MaxLength="11" TabIndex="2" CssClass="form-control" ToolTip="" Height="25px" Width="100%" placeholder="Ingrese parte de la identificación del artículo"></asp:TextBox>
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:40px">
                            <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA (ID.ARTICULO)" data-content="Puede ingresar parte de la identificación del artículo para realizar las búsqueda."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                        </span>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 text-left padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:25px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Estado:&nbsp;</span>
                        <asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="3" CssClass="form-control TextoMediano" Height="25px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" UseSubmitBehavior="true" />
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
            </div>
            <asp:UpdatePanel ID="InfoDetalleUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BuscarButton" EventName="Click">
                </asp:AsyncPostBackTrigger>
            </Triggers>
            <ContentTemplate>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-top-20" >
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center padding-top-20" >
                    <cc1:PagingGridView ID="ArticuloPagingGridView" runat="server" OnPageIndexChanging="ArticuloPagingGridView_PageIndexChanging"
                        OnRowDataBound="ArticuloPagingGridView_RowDataBound" HorizontalAlign="Center" 
                        FooterStyle-ForeColor="Brown" OnRowEditing="ArticuloPagingGridView_RowEditing" OnRowCancelingEdit="ArticuloPagingGridView_RowCancelingEdit"
                        OnRowUpdating="ArticuloPagingGridView_RowUpdating" 
                        OnSorting="ArticuloPagingGridView_Sorting" AllowPaging="True" CssClass="grilla"  
                        AllowSorting="True" AlternatingRowStyle-BackColor="#d3d3d3" 
                        AutoGenerateColumns="false" OnRowCommand="ArticuloPagingGridView_RowCommand"
                        OnSelectedIndexChanged="ArticuloPagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="ArticuloPagingGridView_SelectedIndexChanging" BorderStyle="None">
                        <Columns>
                            <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                <HeaderStyle Wrap="False" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Descr" HeaderText="descripción" SortExpression="Descr">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UnidadDescr" HeaderText="Unidad de medida" SortExpression="UnidadDescr">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IndicacionExentoGravado" HeaderText="Exento/Gravado/No gravado" SortExpression="IndicacionExentoGravado">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AlicuotaIVA" HeaderText="Alicuota IVA (%)" SortExpression="AlicuotaIVA">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="Right" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                    </cc1:PagingGridView>

                    <div id="DetalleModal" class="modal fade" tabindex="-1" role="dialog">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        ×</button>
                                    <h3 id="H3">
                                        <asp:Label ID="TituloConfirmacionLabel" runat="server" SkinID="TituloPagina"></asp:Label></h3>
                                </div>
                                <div class="modal-body">
                                    <div class="panel">
                                        <div class="panel-body" style="max-height: 400px; overflow-y: scroll;">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding-right:5px; padding-top: 20px; text-align: right">
                                                        <asp:Label ID="Label4" runat="server" Text="Artículo perteneciente al CUIT"></asp:Label>
                                                    </td>
                                                    <td style="padding-top:20px; text-align: left">
                                                        <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-right:5px; padding-top:5px; text-align: right">
                                                        <asp:Label ID="Label9" runat="server" Text="Id."></asp:Label>
                                                    </td>
                                                    <td style="padding-top:5px; text-align: left">
                                                        <asp:TextBox ID="IdTextBox" runat="server" MaxLength="20" TabIndex="2" Width="100px"></asp:TextBox>
                                                    </td>        
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <hr noshade="noshade" size="1" color="#cccccc" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-right:5px; padding-top:2px; text-align: right">
                                                        <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
                                                    </td>
                                                    <td style="padding-top:2px; text-align: left">
                                                        <asp:TextBox ID="TextBox1" runat="server" MaxLength="100" TabIndex="3" Width="300px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>        
                                                </tr>
                                                <tr>
	                                                <td style="padding-right:5px; padding-top:5px; text-align: right">
		                                                <asp:Label ID="Label11" runat="server" Text="GTIN"></asp:Label>
	                                                </td>
                                                    <td style="padding-top:5px; text-align: left">
		                                                <asp:TextBox ID="GTINTextBox" runat="server" MaxLength="20" TabIndex="4"
                                                            ToolTip="(opcional) Código estándar GSI global de identificación de productos. Se utiliza para comercio internacional. Es un campo numérico de 20 caracteres."
			                                                Width="150px"></asp:TextBox>
                                                    </td>									
                                                </tr>
                                                <tr>
	                                                <td style="padding-right:5px; padding-top:5px; text-align: right">
		                                                <asp:Label ID="Label18" runat="server" Text="Unidad de medida"></asp:Label>
	                                                </td>
			                                        <td style="padding-top:5px; text-align: left">
				                                        <asp:DropDownList ID="UnidadDropDownList" runat="server" TabIndex="5" 
                                                            Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			                                        </td>
                                                </tr>
                                                <tr>
	                                                <td style="padding-right:5px; padding-top:5px; text-align: right">
		                                                <asp:Label ID="Label5" runat="server" Text="Indicacion Exento/Gravado"></asp:Label>
	                                                </td>
			                                        <td style="padding-top:5px; text-align: left">
				                                        <asp:DropDownList ID="IndicacionExentoGravadoDropDownList" runat="server" TabIndex="6" 
                                                            Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			                                        </td>
                                                </tr>
                                                <tr>
	                                                <td style="padding-right:5px; padding-top:5px; text-align: right">
		                                                <asp:Label ID="Label6" runat="server" Text="Alícuota I.V.A."></asp:Label>
	                                                </td>
			                                        <td style="padding-top:5px; text-align: left">
				                                        <asp:DropDownList ID="AlicuotaIVADropDownList" runat="server" TabIndex="7" 
                                                            Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			                                        </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button ID="CancelarButton"  data-dismiss="modal" class="btn btn-default" runat="server" title="Salir">Salir</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </section>
</asp:Content>