<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorNovedad.aspx.cs" Inherits="CedServicios.Site.ExploradorNovedad" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Novedades"></asp:Label>
            </td>
        </tr>
        <asp:Panel ID="PanelBuscar" runat="server" ScrollBars="Auto" Visible="false">
        <tr>
	        <td align="left" style="padding-right:5px; padding-top:20px">
                <asp:Label ID="TextoLabel" Text="Nombre del archivo:" runat="server"></asp:Label>
	        </td>
			<td align="left" style="padding-top:20px">
				<asp:TextBox ID="TextoTextBox" runat="server" MaxLength="50" TabIndex="1" Width="114px"></asp:TextBox>
			</td>
            <td style="width:500px">
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
        </asp:Panel>
        <tr>
            <td colspan="3" style="padding-top:20px">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="NovedadGridView" runat="server" 
                        AutoGenerateColumns="false" OnRowCommand="NovedadGridView_RowCommand" OnRowDataBound="NovedadGridView_RowDataBound" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:ButtonField HeaderText="" Text="Ver" CommandName="Ver" ButtonType="Link" ItemStyle-ForeColor="Blue">
                            </asp:ButtonField>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
