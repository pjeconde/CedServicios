<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorPermiso.aspx.cs" Inherits="CedServicios.Site.ExploradorPermiso" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="4" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Permisos"></asp:Label>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
            <tr>
	            <td align="left" style="padding-right:5px; padding-top:20px">
                    Id.Usuario:
	            </td>
			    <td align="left" style="padding-top:20px">
				    <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="1" Width="114px"></asp:TextBox>
			    </td>
                <td align="left" style="padding-left:30px; padding-top:20px">
                    Ver permisos de:
                </td>
                <td align="left" valign="top" style="width:300px; padding-left:5px; padding-top:20px" rowspan="4">
                    <asp:RadioButtonList ID="VerPermisosDeRadioButtonList" runat="server" >
                        <asp:ListItem Text="Cuits" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="UNs"></asp:ListItem>
                        <asp:ListItem Text="Usuarios"></asp:ListItem>
                        <asp:ListItem Text="Todos"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>

            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    CUIT:
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="2" ToolTip="Debe ingresar sólo números." Width="80px"></asp:TextBox>
                </td>        
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Tipo de Permiso:
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:DropDownList ID="IdTipoPermisoDropDownList" runat="server" TabIndex="3" Width="200px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
                </td>        
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Estado:
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="3" Width="200px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
                </td>        
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="height: 24px; padding-top:20px">
                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </td>
            </tr>
        <tr>
            <td colspan="4" style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="PermisosGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowCommand="PermisosGridView_RowCommand" OnRowDataBound="PermisosGridView_RowDataBound" CssClass="grilla" GridLines="None">
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
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="padding-top:20px">
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
