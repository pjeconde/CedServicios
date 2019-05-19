<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorArticulo.aspx.cs" Inherits="CedServicios.Site.ExploradorArticulo" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Artículos"></asp:Label>
                            </h2>
                            <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20">
                    <asp:TextBox ID="CuitTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="100%" placeholder="CUIT"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 padding-top-20 text-left">
                    <asp:TextBox ID="IdArticuloTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100%" placeholder="Id.Artículo"></asp:TextBox>
                </div>
	        </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20">
                    <asp:TextBox ID="DescrArticuloTextBox" runat="server" MaxLength="128" TabIndex="2" ToolTip="" Width="100%" placeholder="Descr.Artículo"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 padding-top-20 text-left">
                    Estado:<asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="3" Width="200px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-top-20 text-center">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="None"
                        BorderWidth="1px" ScrollBars="Auto" BackColor="White">
                        <cc1:PagingGridView ID="ArticuloPagingGridView" runat="server" OnPageIndexChanging="ArticuloPagingGridView_PageIndexChanging"
                            OnRowDataBound="ArticuloPagingGridView_RowDataBound" 
                            FooterStyle-ForeColor="Brown"
                            OnSorting="ArticuloPagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" CssClass="grilla" 
                            AutoGenerateColumns="false" OnRowCommand="ArticuloPagingGridView_RowCommand"
                            DataKeyNames="" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" ReadOnly="true" 
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descr" HeaderText="Descr" SortExpression="Descr" HeaderStyle-Width="300px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GTIN" HeaderText="GTIN" SortExpression="" HeaderStyle-Width="180px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnidadId" HeaderText="UnidadId" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnidadDescr" HeaderText="UnidadDescr" SortExpression="" HeaderStyle-Width="180px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IndicacionExentoGravado" HeaderText="ExentoGravado" SortExpression="" HeaderStyle-Width="80px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AlicuotaIVA" HeaderText="Alic.IVA" SortExpression="" HeaderStyle-Width="80px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
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
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </section>

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="TargetControlIDdelModalPopupExtender1"
    PopupControlID="ConfirmacionPanel"
    BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="ConfirmacionPanel"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="ConfirmacionPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:Label ID="TituloConfirmacionLabel" runat="server" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-top:20px; padding-right:5px; padding-left:5px">
                    Cuit:
                </td>
                <td align="left" style="padding-top:20px;">
                    <asp:Label ID="CuitLabel" runat="server"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Id.Artículo:
                </td>
                <td align="left" style="padding-top:5px;">
                    <asp:Label ID="IdArticuloLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Descr Artículo:
                </td>
                <td align="left" style="width: 500px">
                    <asp:Label ID="DescrArticuloLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right: 5px; padding-left: 5px">
                    Id.Unidad:
                </td>
                <td align="left">
                    <asp:Label ID="IdUnidadLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right: 5px; padding-left: 5px">
                    Descr Unidad:
                </td>
                <td align="left">
                    <asp:Label ID="DescrUnidadLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right: 5px; padding-left: 5px">
                    Indicacion Exento Gravado:
                </td>
                <td align="left">
                    <asp:Label ID="IndicacionExentoGravadoLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right: 5px; padding-left: 5px">
                    Alicuota IVA:
                </td>
                <td align="left">
                    <asp:Label ID="AlicuotaIVALabel" runat="server"></asp:Label>
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
            <tr>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
