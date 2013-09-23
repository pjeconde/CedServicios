<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="LogDetalleConsultaXIdLog.aspx.cs" Inherits="CedServicios.Site.LogDetalleConsultaXIdLog" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta Detalle del Log. "></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="height: 24px; padding-top:20px">
                <input type="button" value="Volver atrás" name="Volver" onclick="history.back()" />
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px;">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="LogDetalleGridView" runat="server" AutoGenerateColumns="false" onrowcommand="LogDetalleGridView_RowCommand" OnRowDataBound="LogDetalleGridView_RowDataBound" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="VerLinkButton" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" runat="server">Ver XML</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="IdLog" HeaderText="IdLog" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoDetalle" HeaderText="TipoDetalle" SortExpression="">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" VerticalAlign="Top" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Detalle" HeaderText="Detalle" SortExpression="" HeaderStyle-Width="1200px">
                                <headerstyle horizontalalign="left" wrap="false" />
                                <itemstyle horizontalalign="left" wrap="true" />
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
</asp:Content>