<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorConfiguracion.aspx.cs" Inherits="CedServicios.Site.ExploradorConfiguracion" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
     <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Configuraciones"></asp:Label>
                            </h2>
                            <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20">
	                <asp:TextBox ID="IdUNTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100%" placeholder="Unidad de Negocio"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 text-left padding-top-20">
                    <asp:TextBox ID="CuitTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="100%" placeholder="CUIT"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20">
                    <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="128" TabIndex="2" ToolTip="" Width="100%" placeholder="Id.Usuario"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 padding-top-20">
                    <asp:TextBox ID="IdItemConfigTextBox" runat="server" MaxLength="128" TabIndex="2" ToolTip="" Width="100%" placeholder="Id.Item Config"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 text-left padding-top-20">
                    Id.Tipo Permiso:<asp:DropDownList ID="IdTipoPermisoDropDownList" runat="server" TabIndex="3" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center padding-top-20" >
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="None"
                        BorderWidth="1px" ScrollBars="Auto" BackImageUrl="" BackColor="White">
                        <cc1:PagingGridView ID="ConfiguracionPagingGridView" runat="server" OnPageIndexChanging="ConfiguracionPagingGridView_PageIndexChanging"
                            OnRowDataBound="ConfiguracionPagingGridView_RowDataBound" 
                            FooterStyle-ForeColor="Brown" HorizontalAlign="Center"
                            OnSorting="ConfiguracionPagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" CssClass="grilla"
                            AutoGenerateColumns="false" OnRowCommand="ConfiguracionPagingGridView_RowCommand"
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
                                <asp:BoundField DataField="IdUN" HeaderText="IdUN" SortExpression="IdUN" ReadOnly="true" 
                                    HeaderStyle-Width="80px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" SortExpression="IdUsuario" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TipoPermisoId" HeaderText="TipoPermisoId" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TipoPermisoDescr" HeaderText="TipoPermisoDescr" SortExpression="TipoPermisoDescr" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdItemConfig" HeaderText="IdItemConfig" SortExpression="" HeaderStyle-Width="200px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="" HeaderStyle-Width="200px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign = "Center" CssClass="GridPager" />
                        </cc1:PagingGridView>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-left padding-top-20" >
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
                <td align="left" style="padding-top:5px; padding-right:5px; padding-left:5px">
                    Id.UN:
                </td>
                <td align="left" style="padding-top:5px;">
                    <asp:Label ID="IdUNLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Id.Usuario:
                </td>
                <td align="left">
                    <asp:Label ID="IdUsuarioLabel" runat="server"></asp:Label>
                </td>
            </tr>          
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Id. TipoPermiso:
                </td>
                <td align="left">
                    <asp:Label ID="TipoPermisoIdLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Descr TipoPermiso:
                </td>
                <td align="left">
                    <asp:Label ID="TipoPermisoDescrLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right: 5px; padding-left: 5px">
                    Id. Item Config:
                </td>
                <td align="left">
                    <asp:Label ID="IdItemConfigLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right: 5px; padding-left: 5px">
                    Valor:
                </td>
                <td align="left">
                    <asp:Label ID="ValorLabel" runat="server"></asp:Label>
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
