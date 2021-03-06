﻿<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorUsuario.aspx.cs" Inherits="CedServicios.Site.ExploradorUsuario" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
     <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="head_title text-center">
                    <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Usuarios"></asp:Label>
                    </h2>
                    <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 text-center padding-top-20">
				    <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100%" placeholder="Id.Usuario"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 text-center padding-top-20">
                    <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="100%" placeholder="Nombre"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 text-center padding-top-20">
                    <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="2" ToolTip="" Width="100%" placeholder="Email"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 text-left padding-top-20">
                    Estado:<asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="3" Width="200px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>    
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-bottom-20">
                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" class="btn btn-default btn-sm" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" class="btn btn-default btn-sm" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-bottom-20">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" BackColor="White">
                        <cc1:PagingGridView ID="UsuarioPagingGridView" runat="server" OnPageIndexChanging="UsuarioPagingGridView_PageIndexChanging"
                            OnRowDataBound="UsuarioPagingGridView_RowDataBound" HorizontalAlign="Center"
                            FooterStyle-ForeColor="Brown"
                            OnRowEditing="UsuarioPagingGridView_RowEditing" OnRowCancelingEdit="UsuarioPagingGridView_RowCancelingEdit"
                            OnRowUpdating="UsuarioPagingGridView_RowUpdating" 
                            OnSorting="UsuarioPagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" CssClass="grilla" 
                            AutoGenerateColumns="false" OnRowCommand="UsuarioPagingGridView_RowCommand"
                            OnSelectedIndexChanged="UsuarioPagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="UsuarioPagingGridView_SelectedIndexChanging"
                            DataKeyNames="" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" Visible="false" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton Id="CambiarEstado" runat="server" CausesValidation="false" CommandName="CambiarEstado"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Cambiar estado" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="IdUsuario" SortExpression="IdUsuario" ReadOnly="true" 
                                    HeaderStyle-Width="250px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" HeaderStyle-Width="300px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" HeaderStyle-Width="120px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EMail" HeaderText="EMail" SortExpression="EMail" ReadOnly="true" 
                                    HeaderStyle-Width="150px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EmailSMS" HeaderText="EmailSMS" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="150px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CantidadEnviosMail" HeaderText="Cant.EnviosMail" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaUltimoReenvioMail" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fec.Ult.ReenvioMail" SortExpression="FechaUltimoReenvioMail" ReadOnly="true" 
                                    HeaderStyle-Width="120px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true" 
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" Visible="true" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" Width="100px" />
                                    <ItemTemplate>
                                        <asp:LinkButton Id="ReenviarEmail" runat="server" CausesValidation="false" CommandName="ReenviarEmail"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Reenviar Email" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign = "Center" CssClass="GridPager" />
                        </cc1:PagingGridView>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-bottom-20">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </section>
    
    <div id="DetalleModal" class="modal fade" tabindex="-1" role="dialog">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        ×</button>
                    <h3 id="H3">
                        <asp:Label ID="Label1" runat="server" SkinID="TituloPagina"></asp:Label></h3>
                </div>
                <div class="modal-body">
                    <div class="panel">
                        <div class="panel-body" style="max-height: 400px; overflow-y: scroll;">
                            <table width="100%">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="TituloConfirmacionLabel" runat="server" SkinID="TituloPagina"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-top:20px; padding-right:5px; padding-left:5px">
                                        Id.Usuario:
                                    </td>
                                    <td align="left" style="padding-top:20px;">
                                        <asp:Label ID="IdUsuarioLabel" runat="server"></asp:Label>
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
                                        Telefono:
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="TelefonoLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>           
                                <tr>
                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                        Email:
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="EmailLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>           
                                <tr>
                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                        Pregunta de Seguridad:
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="PreguntaLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>           
                                <tr>
                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                        Respuesta de Seguridad:
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="RespuestaLabel" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="padding-right:5px; padding-left:5px">
                                        Clave:
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="PasswordLabel" runat="server"></asp:Label>
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
                                        <asp:Button ID="ReenviarEmailButton" runat="server" Text="Confirmar" onclick="ReenviarEmailButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                    </td>
                                    <td align="left" style="padding-top:20px">
                                        <asp:Button ID="CambiarEstadoButton" runat="server" Text="Confirmar" onclick="CambiarEstadoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button ID="Button1"  data-dismiss="modal" class="btn btn-default" runat="server" title="Salir">Salir</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
