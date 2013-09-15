<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorUsuario.aspx.cs" Inherits="CedServicios.Site.ExploradorUsuario" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Usuarios"></asp:Label>
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
                <td style="width:500px">
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Nombre:
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="240px"></asp:TextBox>
                </td>        
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Email:
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="2" ToolTip="" Width="480px"></asp:TextBox>
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
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" PostBackUrl="~/Default.aspx" />
                </td>
            </tr>
        <tr>
            <td colspan="3" style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" BackImageUrl="" BackColor="White">
                        <cc1:PagingGridView ID="UsuarioPagingGridView" runat="server" OnPageIndexChanging="UsuarioPagingGridView_PageIndexChanging"
                            OnRowDataBound="UsuarioPagingGridView_RowDataBound" 
                            FooterStyle-ForeColor="Brown"
                            OnRowEditing="UsuarioPagingGridView_RowEditing" OnRowCancelingEdit="UsuarioPagingGridView_RowCancelingEdit"
                            OnRowUpdating="UsuarioPagingGridView_RowUpdating" 
                            OnSorting="UsuarioPagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" 
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
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                        </cc1:PagingGridView>
                    </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
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
