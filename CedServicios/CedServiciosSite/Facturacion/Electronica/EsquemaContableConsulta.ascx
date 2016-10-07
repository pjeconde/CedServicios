<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EsquemaContableConsulta.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.EsquemaContableConsulta" %>

<table style="width: 1282px">
	<tr>
		<td style="height:10px">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			ESQUEMA CONTABLE
		</td>
	</tr>
	<tr>
		<td style="height:10px">
		</td>
	</tr>
	<tr>
		<td style="text-align: center; font-weight: normal;">
			<asp:UpdatePanel ID="esquemaContableUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
				<ContentTemplate>
					<asp:GridView ID="esquemaContableGridView" runat="server" AutoGenerateColumns="False" BorderColor="gray"
						BorderStyle="Solid" BorderWidth="1px" EnableViewState="true" Font-Bold="false" GridLines="Both" HorizontalAlign="Center"
						ShowFooter="true" ShowHeader="True" ToolTip="El separador de decimales a utilizar es el punto">
						<Columns>
							<asp:TemplateField HeaderText="Rubro">
								<ItemTemplate>
									<asp:Label ID="lbldescrRubro" runat="server" Text='<%# Eval("DescrRubro") %>' Width="250px"></asp:Label>
								</ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
								<ItemStyle HorizontalAlign="Left" Width="350px" />
								<FooterStyle HorizontalAlign="Left" Width="350px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Debe">
								<ItemTemplate>
									<asp:Label ID="lbldebe" runat="server" Width="100px" Text='<%# Eval("Debe") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" Width="100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Haber">
								<ItemTemplate>
									<asp:Label ID="lblhaber" runat="server" Width="100px" Text='<%# Eval("Haber") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" Width="100px" />
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</ContentTemplate>
			</asp:UpdatePanel>
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
			<asp:UpdateProgress ID="esquemaContableUpdateProgress" runat="server" AssociatedUpdatePanelID="esquemaContableUpdatePanel"
				DisplayAfter="0">
				<ProgressTemplate>
					<asp:Image ID="esquemaContableImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
					</asp:Image>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</td>
	</tr>
</table>
