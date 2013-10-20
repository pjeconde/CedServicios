<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="Migracion.aspx.cs" Inherits="CedServicios.Site.Migracion" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
            <tr>
                <td align="center" style="padding-top: 20px">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Migración de Cuentas (desde CedWeb)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" style="height:24px; padding-top:20px">
                    <asp:Button ID="CopiarTodosButton" runat="server" OnClick="CopiarTodosButton_Click" TabIndex="1" Text="Copiar todas las cuentas" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="2" Text="Salir" onclick="SalirButton_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" style="padding-bottom: 30px; padding-top: 20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-top:20px;">
                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="CuentasGridView" runat="server"
                            AutoGenerateColumns="false" onrowcommand="CuentasGridView_RowCommand" OnRowDataBound="CuentasGridView_RowDataBound" CssClass="grilla" GridLines="None">
                            <Columns>
                                <asp:ButtonField HeaderText="Cuenta" Text="Copiar" CommandName="Copiar" ButtonType="Link" ItemStyle-ForeColor="Blue" >
                                </asp:ButtonField>
                                <asp:BoundField DataField="IdCuenta" HeaderText="Id" SortExpression="IdCuenta">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaAlta" HeaderText="Fecha alta" SortExpression="FechaAlta">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaUltimoComprobante" HeaderText="Fecha ult.fact." SortExpression="FechaUltimoComprobante">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CantidadComprobantes" HeaderText="qComprob" SortExpression="CantidadComprobantes">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="right" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdEstadoCuenta" HeaderText="Estado" SortExpression="IdEstadoCuenta">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
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
