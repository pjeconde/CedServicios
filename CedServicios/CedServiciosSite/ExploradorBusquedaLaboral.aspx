<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorBusquedaLaboral.aspx.cs" Inherits="CedServicios.Site.ExploradorBusquedaLaboral" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Busqueda Laboral"></asp:Label>
                            </h2>
                            <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                 </div>
            </div>
            <div class="row" style="background-color:white;">
                <div class="col-lg-6 col-md-6 padding-bottom-20">
                    <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="100%" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 padding-bottom-20">
                    <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="2" ToolTip="" Width="100%" placeholder="Email"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-bottom-20">
                    Perfil:<asp:DropDownList ID="PerfilDropDownList" runat="server" TabIndex="3" DataValueField="IdBusquedaPerfil" DataTextField="DescrBusquedaPerfil" AutoPostBack="false" placeholder="Perfil" Width="100%"></asp:DropDownList>
                </div>
                <div class="col-lg-6 col-md-6 padding-bottom-20">
                    Estado:<asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="3" DataValueField="Id" DataTextField="Descr" AutoPostBack="false" placeholder="Estado" Width="100%"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="text-center padding-bottom-20">
                <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-bottom-20">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="None"
                        BorderWidth="1px" ScrollBars="Auto" BackImageUrl="" BackColor="White">
                        <cc1:PagingGridView ID="BLPagingGridView" runat="server" OnPageIndexChanging="BLPagingGridView_PageIndexChanging"
                            OnRowDataBound="BLPagingGridView_RowDataBound" 
                            FooterStyle-ForeColor="Brown"
                            OnSorting="BLPagingGridView_Sorting" AllowPaging="True"  
                            AllowSorting="True" EnableTheming="false" 
                            AutoGenerateColumns="false" OnRowCommand="BLPagingGridView_RowCommand"
                            DataKeyNames="" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" ReadOnly="true" 
                                    HeaderStyle-Width="200px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-Width="300px" ReadOnly="true">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BusquedaPerfil.IdBusquedaPerfil" HeaderText="Perfil" SortExpression="BusquedaPerfil.IdBusquedaPerfil" HeaderStyle-Width="250px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaAlta" HeaderText="FechaAlta" SortExpression="FechaAlta" ReadOnly="true" HeaderStyle-Width="130px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreArchCV" HeaderText="NombreArchCV" SortExpression="NombreArchCV" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true" 
                                    HeaderStyle-Width="80px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign = "Center" CssClass="GridPager" />
                        </cc1:PagingGridView>
                    </asp:Panel>
                </div>
                <div class="text-center">
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
                    Email:
                </td>
                <td align="left" style="padding-top:20px;">
                    <asp:Label ID="EmailLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Nombre:
                </td>
                <td align="left">
                    <asp:Label ID="NombreLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    NombreArchCV:
                </td>
                <td align="left">
                    <asp:Label ID="NombreArchCVLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    IdPerfil:
                </td>
                <td align="left">
                    <asp:Label ID="IdBusquedaPerfil" runat="server"></asp:Label>
                </td>
            </tr>           

            <tr>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="CancelarButton" runat="server" Text="Salir" />
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
