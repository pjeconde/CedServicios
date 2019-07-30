<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PersonaConsultaConFiltros.aspx.cs" Inherits="CedServicios.Site.PersonaConsultaConFiltros" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <style type="text/css">
    .popover
    {
    	min-width: 500px;
    }
    </style>
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Personas"></asp:Label>
                            </h2>
                            <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-6 padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:25px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Razon Social:&nbsp;</span>
                        <asp:TextBox ID="RazSocTextBox" runat="server" MaxLength="50" TabIndex="2" CssClass="form-control" ToolTip="" Height="25px" Width="100%" placeholder="Ingrese parte de la razón social"></asp:TextBox>
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:40px">
                            <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA (RAZON SOCIAL)" data-content="Puede ingresar parte de la Razón Social para realizar las búsqueda."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                        </span>
                    </div>
                </div>
                <div class="col-lg-4 col-md-6 padding-top-20">
                    <div class="input-group text-left" style="background-color:white; height:25px">
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Nro. Doc:&nbsp;</span>
                        <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="2" CssClass="form-control" ToolTip="" Height="25px" Width="100%" placeholder="Ingrese parte del número de documento"></asp:TextBox>
                        <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:40px">
                            <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA (NUMERO DE DOCUMENTO)" data-content="Puede ingresar parte del número de documento para realizar las búsqueda."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
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
                    <cc1:PagingGridView ID="ClientePagingGridView" runat="server" OnPageIndexChanging="ClientePagingGridView_PageIndexChanging"
                        OnRowDataBound="ClientePagingGridView_RowDataBound" HorizontalAlign="Center" 
                        FooterStyle-ForeColor="Brown" OnRowEditing="ClientePagingGridView_RowEditing" OnRowCancelingEdit="ClientePagingGridView_RowCancelingEdit"
                        OnRowUpdating="ClientePagingGridView_RowUpdating" 
                        OnSorting="ClientePagingGridView_Sorting" AllowPaging="True" 
                        AllowSorting="True" CssClass="grilla" AlternatingRowStyle-BackColor="#d3d3d3" 
                        AutoGenerateColumns="false" OnRowCommand="ClientePagingGridView_RowCommand"
                        OnSelectedIndexChanged="ClientePagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="ClientePagingGridView_SelectedIndexChanging" BorderStyle="None">
                        <Columns>
                            <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                <HeaderStyle Wrap="False" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" ReadOnly="true" 
                                HeaderStyle-Width="180px">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentoTipoDescr" HeaderText="TipoDoc" SortExpression="DocumentoTipoDescr" HeaderStyle-Width="200px" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DocumentoNro" HeaderText="NroDoc" SortExpression="DocumentoNro" HeaderStyle-Width="100px" ReadOnly="true">
                                <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="RazonSocial" HeaderStyle-Width="400px" ReadOnly="true">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DomicilioCalle" HeaderText="Calle" SortExpression="DomicilioCalle" HeaderStyle-Width="240px" ReadOnly="true">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DomicilioNro" HeaderText="Nro" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DomicilioPiso" HeaderText="Piso" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DomicilioDepto" HeaderText="Depto" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DomicilioLocalidad" HeaderText="Localidad" SortExpression="" HeaderStyle-Width="240px" ReadOnly="true">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DomicilioCodPost" HeaderText="CodPost" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ContactoNombre" HeaderText="NombreContacto" SortExpression="" ReadOnly="true" HeaderStyle-Width="220px"> 
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ContactoTelefono" HeaderText="Telefono" SortExpression="" HeaderStyle-Width="120px" ReadOnly="true">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ContactoEmail" HeaderText="Email" SortExpression="" ReadOnly="true" 
                                HeaderStyle-Width="150px">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true" 
                                HeaderStyle-Width="100px">
                                <HeaderStyle Wrap="False" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle HorizontalAlign = "Center" CssClass="GridPager" />
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
                                            <table width="100%">
                                                <tr>
                                                    <td align="left" style="padding-top:20px; padding-right:5px; padding-left:5px">
                                                        CUIT:
                                                    </td>
                                                    <td align="left" style="padding-top:20px;">
                                                        <asp:Label ID="CUITLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>           
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Razón Social:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="RazSocLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Tipo.Doc:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="TipoDocLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>             
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Nro.Doc:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="NroDocLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>           
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Calle:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="CalleLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>           
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Nro:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="NroLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>           
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Piso:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="PisoLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Depto:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="DeptoLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Localidad:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="LocalidadLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Cod.Post:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="CodPostLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Contacto:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="ContactoLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        EsCliente:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="ClienteLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Es Proveedor:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="ProveedorLabel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                                        Estado Actual:
                                                    </td>
                                                    <td align="left">
                                                        <asp:Label ID="EstadoLabel" runat="server"></asp:Label>
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
