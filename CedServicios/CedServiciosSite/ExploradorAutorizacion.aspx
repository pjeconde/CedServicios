<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorAutorizacion.aspx.cs" Inherits="CedServicios.Site.ExploradorAutorizacion" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Autorizaciones Pendientes"></asp:Label>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="AutorizacionesGridView" runat="server" 
                        AutoGenerateColumns="false" onrowcommand="AutorizacionesGridView_RowCommand" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:ButtonField HeaderText="" Text="Autorizar" CommandName="Autorizar" ButtonType="Link">
                            </asp:ButtonField>
                            <asp:ButtonField HeaderText="" Text="Rechazar" CommandName="Rechazar" ButtonType="Link">
                            </asp:ButtonField>
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
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>

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
                <td style="padding-top:20px" align="right">
                    Permiso:
                </td>
                <td style="padding-top:20px" align="left">
                    <asp:Label ID="DescrTipoPermisoLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right">
                    Usuario:
                </td>
                <td align="left">
                    <asp:Label ID="UsuarioLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right">
                    Unidad de Negocio:
                </td>
                <td align="left">
                    <asp:Label ID="UNLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right">
                    CUIT:
                </td>
                <td align="left">
                    <asp:Label ID="CuitLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right">
                    Origen:
                </td>
                <td align="left">
                    <asp:Label ID="AccionLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right">
                    Fecha fin vigencia:
                </td>
                <td align="left">
                    <asp:Label ID="FechaFinVigenciaLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right">
                    Usuario solicitante:
                </td>
                <td align="left">
                    <asp:Label ID="UsuarioSolicitanteLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right">
                    Estado:
                </td>
                <td align="left">
                    <asp:Label ID="EstadoLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="right" style="padding-top:20px">
                    <asp:Button ID="ConfirmarButton" runat="server" Text="Confirmar" onclick="ConfirmarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
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
