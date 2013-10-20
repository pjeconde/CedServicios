<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorLog.aspx.cs" Inherits="CedServicios.Site.ExploradorLog" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Logs"></asp:Label>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
	        <td align="left" style="padding-top:20px; padding-right:5px;">
                Período:
	        </td>
			<td align="left" style="padding-top:20px">
                Desde
                <asp:TextBox ID="FechaDesdeTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="70px" TabIndex="304"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="FechaDesdeCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                    TargetControlID="FechaDesdeTextBox" Format="dd/MM/yyyy" PopupButtonID="FechaDesdeImage" >
                </ajaxToolkit:CalendarExtender>
                <asp:Image runat="server" ID="FechaDesdeImage" ImageUrl="~/Imagenes/Calendar.gif" />
                &nbsp;&nbsp;Hasta
                <asp:TextBox ID="FechaHastaTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="70px" TabIndex="304"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="FechaHastaCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                    TargetControlID="FechaHastaTextBox" Format="dd/MM/yyyy" PopupButtonID="FechaHastaImage" >
                </ajaxToolkit:CalendarExtender>
                <asp:Image runat="server" ID="FechaHastaImage" ImageUrl="~/Imagenes/Calendar.gif" />&nbsp;&nbsp;(formato: "DD/MM/YYYY")
            </td>       
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                IdLog:
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="IdLogTextBox" runat="server" MaxLength="10" TabIndex="2" ToolTip="" Width="114px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                IdWF:
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="IdWFTextBox" runat="server" MaxLength="10" TabIndex="2" ToolTip="" Width="114px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                IdUsuario:
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="Usa LIKE" Width="114px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
	        <td align="left" style="padding-right:5px; padding-top:5px">
                Entidad:
	        </td>
			<td align="left" style="padding-top:5px">
				<asp:TextBox ID="EntidadTextBox" runat="server" MaxLength="15" TabIndex="1" ToolTip="Usa LIKE" Width="114px"></asp:TextBox>
			</td>
            <td style="width:500px">
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-right:5px; padding-top:5px">
                Evento:
            </td>
            <td align="left" style="padding-top:5px">
                <asp:TextBox ID="EventoTextBox" runat="server" MaxLength="15" TabIndex="2" ToolTip="Usa LIKE" Width="114px"></asp:TextBox>
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
                        <cc1:PagingGridView ID="LogPagingGridView" runat="server" OnPageIndexChanging="LogPagingGridView_PageIndexChanging"
                            OnRowDataBound="LogPagingGridView_RowDataBound" 
                            FooterStyle-ForeColor="Brown"
                            OnSorting="LogPagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" 
                            AutoGenerateColumns="false" OnRowCommand="LogPagingGridView_RowCommand"
                            DataKeyNames="" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LogDetalle" runat="server" CausesValidation="false" CommandName="LogDetalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="LogDetalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="VerEntidad" runat="server" CausesValidation="false" CommandName="VerEntidad" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="VerEntidad" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Id" HeaderText="IdLog" SortExpression="Id" HeaderStyle-Width="80px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdWF" HeaderText="IdWF" SortExpression="IdWF" HeaderStyle-Width="80px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" SortExpression="Fecha"  DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" ReadOnly="true" HeaderStyle-Width="120px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdUsuario" HeaderText="IdUsuario" SortExpression="IdUsuario" HeaderStyle-Width="120px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Entidad" HeaderText="Entidad" SortExpression="Entidad" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Evento" HeaderText="Evento" SortExpression="Evento" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true" 
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CantRegLogDetalle" HeaderText="CantRegLogDetalle" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Comentario" HeaderText="Comentario" SortExpression="" HeaderStyle-Width="300px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
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
                    IdLog:
                </td>
                <td align="left" style="padding-top:20px;">
                    <asp:Label ID="IdLogLabel" runat="server"></asp:Label>
                </td>
            </tr>  
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    IdWF:
                </td>
                <td align="left">
                    <asp:Label ID="IdWFLabel" runat="server"></asp:Label>
                </td>
            </tr> 
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Fecha:
                </td>
                <td align="left">
                    <asp:Label ID="FechaLabel" runat="server"></asp:Label>
                </td>
            </tr>          
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    IdUsuario:
                </td>
                <td align="left">
                    <asp:Label ID="IdUsuarioLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Entidad:
                </td>
                <td align="left">
                    <asp:Label ID="EntidadLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Evento:
                </td>
                <td align="left">
                    <asp:Label ID="EventoLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Comentario:
                </td>
                <td align="left">
                    <asp:Label ID="ComentarioLabel" runat="server"></asp:Label>
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
