﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorCV.aspx.cs" Inherits="CedServicios.Site.ExploradorCV" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de CVs"></asp:Label>
                            </h2>
                            <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="text-center">
                        <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="50%" placeholder="Nombre"></asp:TextBox>
                    </div>
                    <div class="text-center">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                        <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation ="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                    </div>
                    <div class="text-center padding-top-20">
                        <asp:Panel ID="Panel1" runat="server" BorderStyle="None"
                            BorderWidth="1px" ScrollBars="Auto" BackImageUrl="" BackColor="White">
                            <cc1:PagingGridView ID="CVPagingGridView" runat="server" OnPageIndexChanging="CVPagingGridView_PageIndexChanging"
                                OnRowDataBound="CVPagingGridView_RowDataBound" 
                                OnSorting="CVPagingGridView_Sorting"
                                FooterStyle-ForeColor="Brown"
                                AllowPaging="True" 
                                AllowSorting="True" CssClass="grilla" 
                                AutoGenerateColumns="false" OnRowCommand="CVPagingGridView_RowCommand"
                                DataKeyNames="" BorderStyle="None">
                                <Columns>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                        <HeaderStyle Wrap="False" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Abrir" runat="server" CausesValidation="false" CommandName="Abrir" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Abrir" Width="50px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                        <HeaderStyle Wrap="False" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" Width="50px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre del archivo" SortExpression="Nombre" HeaderStyle-Width="100%" ReadOnly="true">
                                        <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerSettings Mode="NumericFirstLast" />
                                <PagerStyle HorizontalAlign = "Center" CssClass="GridPager" />
                            </cc1:PagingGridView>
                        </asp:Panel>
                    </div>
                    <div class="text-center padding-top-20">
                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    </div>
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
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Nombre:
                </td>
                <td align="left">
                    <asp:Label ID="NombreLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Fecha Creación:
                </td>
                <td align="left">
                    <asp:Label ID="FechaLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Tamaño:
                </td>
                <td align="left">
                    <asp:Label ID="PesoLabel" runat="server"></asp:Label>
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
