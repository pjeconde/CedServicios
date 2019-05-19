<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorPermiso.aspx.cs" Inherits="CedServicios.Site.ExploradorPermiso" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Permisos"></asp:Label>
                            </h2>
                            <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20">
				    <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100%" placeholder="Id.Usuario"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 padding-top-20 text-left">
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="2" ToolTip="Debe ingresar sólo números." Width="100%" placeholder="CUIT"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20 text-left">
                    Estado:<asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="3" Width="" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
                </div>
                <div class="col-lg-6 col-md-6  padding-top-20 text-left">
                    Tipo de Permiso:<asp:DropDownList ID="IdTipoPermisoDropDownList" runat="server" TabIndex="3" Width="" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
                </div>        
                <div class="col-lg-12 col-md-12 text-left padding-top-20" >
                    <asp:RadioButtonList ID="VerPermisosDeRadioButtonList" runat="server">
                        <asp:ListItem Text="Cuits" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="UNs"></asp:ListItem>
                        <asp:ListItem Text="Usuarios"></asp:ListItem>
                        <asp:ListItem Text="Todos"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="col-lg-12 col-md-12">
                    <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-top-20">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="PermisosGridView" runat="server" HorizontalAlign="Center" 
                        AutoGenerateColumns="false" OnRowCommand="PermisosGridView_RowCommand" OnRowDataBound="PermisosGridView_RowDataBound" 
                        CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:ButtonField HeaderText="" Text="Cambiar estado" CommandName="CambiarEstado" ButtonType="Link" ItemStyle-ForeColor="Blue">
                            </asp:ButtonField>
                            <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" SortExpression="IdUsuario">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdUN" HeaderText="IdUN" SortExpression="IdUN">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdTipoPermiso" HeaderText="IdTipoPermiso" SortExpression="IdTipoPermiso">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaFinVigencia" DataFormatString="{0:dd/MM/yyyy}" HeaderText="FechaFinVigencia" SortExpression="FechaFinVigencia">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdUsuarioSolicitante" HeaderText="Solicitante" SortExpression="IdUsuarioSolicitante">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12">
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
                    Usuario:
                </td>
                <td align="left" style="padding-top:20px; padding-right:5px; padding-left:5px">
                    <asp:Label ID="UsuarioLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    CUIT:
                </td>
                <td align="left">
                    <asp:Label ID="CuitLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Unidad de Negocio:
                </td>
                <td align="left">
                    <asp:Label ID="UNLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Tipo de Permiso:
                </td>
                <td align="left">
                    <asp:Label ID="IdTipoPermisoLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Origen:
                </td>
                <td align="left">
                    <asp:Label ID="AccionLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Fecha fin vigencia:
                </td>
                <td align="left">
                    <asp:Label ID="FechaFinVigenciaLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Usuario solicitante:
                </td>
                <td align="left">
                    <asp:Label ID="UsuarioSolicitanteLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Estado:
                </td>
                <td align="left">
                    <asp:Label ID="EstadoLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="CambiarEstadoButton" runat="server" Text="Confirmar" onclick="CambiarEstadoButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                </td>
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
