<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorPuntoVta.aspx.cs" Inherits="CedServicios.Site.ExploradorPuntoVta" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Puntos de Venta"></asp:Label>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:20px">
                Cuit:
            </td>
            <td align="left" style="padding-top:20px">
                <asp:TextBox ID="CuitTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="114px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
	        <td align="left" style="padding-right:5px; padding-top:5px">
                Unidad de Negocio:
	        </td>
			<td align="left" style="padding-top:5px">
				<asp:TextBox ID="IdUNTextBox" runat="server" MaxLength="50" TabIndex="1" Width="114px"></asp:TextBox>
			</td>
            <td style="width:500px">
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                Nro. Punto de Venta:
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="NroTextBox" runat="server" MaxLength="128" TabIndex="2" ToolTip="" Width="114px"></asp:TextBox>
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
                <asp:Panel ID="Panel1" runat="server" BorderStyle="None"
                        BorderWidth="1px" Height="400px" ScrollBars="Auto" BackImageUrl="" BackColor="White">
                        <cc1:PagingGridView ID="PuntoVtaPagingGridView" runat="server" OnPageIndexChanging="PuntoVtaPagingGridView_PageIndexChanging"
                            OnRowDataBound="PuntoVtaPagingGridView_RowDataBound" 
                            FooterStyle-ForeColor="Brown"
                            OnSorting="PuntoVtaPagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" 
                            AutoGenerateColumns="false" OnRowCommand="PuntoVtaPagingGridView_RowCommand"
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
                                <asp:BoundField DataField="Nro" HeaderText="Nro.PVta" SortExpression="Nro" HeaderStyle-Width="80px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdUN" HeaderText="IdUN" SortExpression="IdUN" ReadOnly="true" 
                                    HeaderStyle-Width="80px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdTipoPuntoVta" HeaderText="IdTipoPuntoVta" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UsaSetPropioDeDatosCuit" HeaderText="UsaSetPropioDeDatosCuit" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdMetodoGeneracionNumeracionLote" HeaderText="MetodoNumeracionLote" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UltNroLote" HeaderText="UltNroLote" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
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
                    Cuit:
                </td>
                <td align="left">
                    <asp:Label ID="CuitLabel" runat="server"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Id.UN:
                </td>
                <td align="left" style="padding-top:20px;">
                    <asp:Label ID="IdUNLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Nro.PuntoVta:
                </td>
                <td align="left">
                    <asp:Label ID="NroLabel" runat="server"></asp:Label>
                </td>
            </tr>    
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    TipoPuntoVta:
                </td>
                <td align="left">
                    <asp:Label ID="IdTipoPuntoVtaLabel" runat="server"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    UsaSetPropioDeDatosCuit:
                </td>
                <td align="left">
                    <asp:Label ID="UsaSetPropioDeDatosCuitLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Método Numeración Lote:
                </td>
                <td align="left">
                    <asp:Label ID="IdMetodoGeneracionNumeracionLoteLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Ult.NroLote:
                </td>
                <td align="left">
                    <asp:Label ID="UltNroLoteLabel" runat="server"></asp:Label>
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
