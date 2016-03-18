<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ReferenciasConsulta.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.ReferenciasConsulta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table style="width: 1282px">
	<tr>
		<td style="height:10px">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			Referencias
		</td>
	</tr>
	<tr>
		<td style="height:10px">
		</td>
	</tr>
	<tr>
		<td style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:UpdatePanel ID="referenciasUpdatePanel" runat="server" ChildrenAsTriggers="true"
				UpdateMode="Conditional">
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
				</Triggers>
				<ContentTemplate>
					<asp:GridView ID="referenciasGridView" runat="server" AutoGenerateColumns="False" BorderColor="gray"
						BorderStyle="Solid" BorderWidth="1px" CssClass="gridview" HorizontalAlign="Center" 
						EnableViewState="true" Font-Bold="false" GridLines="Both"
						ShowFooter="true" ShowHeader="True" ToolTip="El dato de referencia debe ser un número entero"
						Width="1260px">
						<Columns>
                            <asp:TemplateField HeaderText="C&#243;digo de referencia">
                                <ItemTemplate>
                                    <asp:Label ID="lblcodigo_de_referencia" runat="server" Text='<%# Eval("descripcioncodigo_de_referencia") %>'
                                        Width="620px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="620px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Número de referencia">
                                <ItemTemplate>
                                    <asp:Label ID="lbldato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
						<HeaderStyle Font-Bold="True" />
					</asp:GridView>
				</ContentTemplate>
			</asp:UpdatePanel>
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
			<asp:UpdateProgress ID="referenciasUpdateProgress" runat="server" AssociatedUpdatePanelID="referenciasUpdatePanel"
				DisplayAfter="0">
				<ProgressTemplate>
					<asp:Image ID="referenciasImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
					</asp:Image>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:ValidationSummary ID="ReferenciasEditValidationSummary" runat="server" BorderColor="Gray"
				BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				ShowMessageBox="True" ValidationGroup="ReferenciasEditItem"></asp:ValidationSummary>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:ValidationSummary ID="ReferenciasFooterValidationSummary" runat="server" BorderColor="Gray"
				BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				ShowMessageBox="True" ValidationGroup="ReferenciasFooter"></asp:ValidationSummary>
		</td>
	</tr>
</table>
