<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ArticuloSeleccionar.aspx.cs" Inherits="CedServicios.Site.ArticuloSeleccionar" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <asp:Panel ID="Panel2" runat="server" DefaultButton="BuscarButton">
        <table align="center">
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="? de Artículo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" style="padding-top:20px" colspan="3">
                    <asp:Label ID="Label3" runat="server" Text="Articulo(s) perteneciente(s) al CUIT"></asp:Label>
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                </td>
            </tr>
            <tr>
			    <td style="padding-top:20px; padding-right:30px">
                    <asp:Label ID="Label10" runat="server" Text="Ver artículos"></asp:Label>
			    </td>
                <td align="left" style="padding-top:20px; padding-right:30px">
                    <asp:RadioButton ID="FiltradosRadioButton" Text="Filtrados por:" GroupName="Filtro" Checked="true" runat="server" AutoPostBack="true" oncheckedchanged="FiltroButton_CheckedChanged" />
                </td>
	            <td align="left" style="padding-top:20px">
                    <asp:RadioButton ID="IdRadioButton" runat="server" AutoPostBack="true" Text="Id." GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1" />
                    <asp:TextBox ID="IdTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px"></asp:TextBox>
	            </td>
            </tr>
            <tr>
			    <td>
			    </td>
			    <td>
			    </td>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    <asp:RadioButton ID="DescrRadioButton" runat="server" AutoPostBack="true" Text="Descripción" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2" />
                    <asp:TextBox ID="DescrTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
			    <td>
			    </td>
                <td align="left">
                    <asp:RadioButton ID="TodosRadioButton" Text="Todos" GroupName="Filtro" runat="server" AutoPostBack="true" oncheckedchanged="FiltroButton_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td align="center" style="height: 24px; padding-top:20px" colspan="3">
                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="padding-top:20px;" colspan="3">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="ArticulosGridView" runat="server"
                            AutoGenerateColumns="false" onrowcommand="ArticulosGridView_RowCommand" OnRowDataBound="ArticulosGridView_RowDataBound" CssClass="grilla" GridLines="None" CaptionAlign="Bottom">
                            <Columns>
                                <asp:ButtonField HeaderText="Artículo" Text="Seleccionar" CommandName="Seleccionar" ButtonType="Link" ItemStyle-ForeColor="Blue" ItemStyle-Width="90px">
                                </asp:ButtonField>
                                <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" Visible="false">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descr" HeaderText="descripción" SortExpression="Descr">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnidadDescr" HeaderText="Unidad de medida" SortExpression="UnidadDescr">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IndicacionExentoGravado" HeaderText="Exento/Gravado/No gravado" SortExpression="IndicacionExentoGravado">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AlicuotaIVA" HeaderText="Alicuota IVA (%)" SortExpression="AlicuotaIVA">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
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
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
    </div>
    </div>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
