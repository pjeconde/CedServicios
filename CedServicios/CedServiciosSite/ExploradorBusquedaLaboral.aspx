<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorBusquedaLaboral.aspx.cs" Inherits="CedServicios.Site.ExploradorBusquedaLaboral" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Busqueda Laboral"></asp:Label>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
            <tr>
	            <td align="left" style="padding-right:5px; padding-top:20px">
                    Cuit:
	            </td>
			    <td align="left" style="padding-top:20px">
				    <asp:TextBox ID="NroTextBox" runat="server" MaxLength="50" TabIndex="1" Width="114px"></asp:TextBox>
			    </td>
                <td style="width:500px">
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Razon Social:
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="240px"></asp:TextBox>
                </td>        
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Localidad:
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="LocalidadTextBox" runat="server" MaxLength="128" TabIndex="2" ToolTip="" Width="240px"></asp:TextBox>
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
            <td colspan="3" style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="None"
                        BorderWidth="1px" ScrollBars="Auto" BackImageUrl="" BackColor="White">
                        <cc1:PagingGridView ID="BLPagingGridView" runat="server" OnPageIndexChanging="BLPagingGridView_PageIndexChanging"
                            OnRowDataBound="BLPagingGridView_RowDataBound" 
                            FooterStyle-ForeColor="Brown"
                            OnSorting="BLPagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" 
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
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdPerfilBusquedaLaboral" HeaderText="IdPerfilBusquedaLaboral" SortExpression="IdPerfilBusquedaLaboral" HeaderStyle-Width="250px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NombreArchCV" HeaderText="NombreArchCV" SortExpression="NombreArchCV" ReadOnly="true" 
                                    HeaderStyle-Width="60px">
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
    </div>
    </div>
    </div>

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
