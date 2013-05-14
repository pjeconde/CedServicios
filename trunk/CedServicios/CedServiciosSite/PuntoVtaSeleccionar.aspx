<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PuntoVtaSeleccionar.aspx.cs" Inherits="CedServicios.Site.PuntoVtaSeleccionar" theme="CedServicios"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
            <tr>
                <td align="center" colspan="2" style="padding-top: 20px">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="? de Punto de Venta"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 5px; padding-top: 20px">
                    <asp:Label ID="Label19" runat="server" Text="CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top: 20px">
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                        Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:5px; height:25px;">
                    <asp:Label ID="Label5" runat="server" Text="Unidad de Negocio"></asp:Label>
                </td>
                <td align="left" style="padding-top:5px; height:25px;">
                    <asp:DropDownList ID="IdUNDropDownList" runat="server" TabIndex="2" Width="183px" DataValueField="Id" DataTextField="Descr" ></asp:DropDownList>
                </td>
            </tr>        
            <tr>
                <td>
                </td>
                <td align="left" style="height: 24px; padding-top: 20px">
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="5" Text="Cancelar" PostBackUrl="~/Default.aspx" />
                </td>
            </tr>
            <tr>
                <td style="padding-top:20px;" colspan="2">
                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="PuntosVtaGridView" runat="server"
                            AutoGenerateColumns="false" onrowcommand="PuntosVtaGridView_RowCommand" OnRowDataBound="PuntosVtaGridView_RowDataBound" CssClass="grilla" GridLines="None">
                            <Columns>
                                <asp:ButtonField HeaderText="Punto Vta." Text="Seleccionar" CommandName="Seleccionar" ButtonType="Link" ItemStyle-ForeColor="Blue" ItemStyle-Width="90px">
                                </asp:ButtonField>
                                <asp:BoundField DataField="IdFormateado" HeaderText="Id" SortExpression="IdFormateado" ItemStyle-Width="80px">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdTipoPuntoVta" HeaderText="Tipo" SortExpression="IdTipoPuntoVta" ItemStyle-Width="150px">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="padding-bottom: 30px; padding-top: 20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
