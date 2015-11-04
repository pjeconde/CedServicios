<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DescuentosConsulta.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.DescuentosConsulta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table style="width: 1282px">
	<tr>
		<td style="height:10px">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			DESCUENTOS GLOBALES
		</td>
	</tr>
	<tr>
		<td style="height:10px">
		</td>
	</tr>
	<tr>
		<td style="text-align: center; font-weight: normal;">
			<asp:UpdatePanel ID="descuentosUpdatePanel" runat="server" ChildrenAsTriggers="true"
				UpdateMode="Conditional">
				<ContentTemplate>
					<asp:GridView ID="descuentosGridView" runat="server" AutoGenerateColumns="False"
						BorderColor="gray" BorderStyle="Solid" BorderWidth="1px" EnableViewState="true" Font-Bold="false"
						GridLines="Both"  HorizontalAlign="Center" ShowFooter="true" ShowHeader="True" ToolTip="El separador de decimales a utilizar es el punto"
						Width="1260px">
						<Columns>
							<asp:TemplateField HeaderText="Descripci&#243;n del descuento">
								<ItemTemplate>
									<asp:Label ID="lbldescripcion" runat="server" Text='<%# Eval("descripcion_descuento") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Left" />
								<FooterStyle HorizontalAlign="Left" />
								<HeaderStyle Width="200px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="%">
								<ItemTemplate>
									<asp:Label ID="lblporcentaje" runat="server" Text='<%# Eval("porcentaje_descuento") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="35px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Importe Dto.">
								<ItemTemplate>
									<asp:Label ID="lblimporte_descuento" runat="server" Text='<%# Eval("importe_descuento") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="G / E / N">
								<ItemTemplate>
									<asp:Label ID="lblindicacion" runat="server" Text='<%# Eval("indicacion_exento_gravado_descuento")  %>'
										Width="40px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="40px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Alícuota %">
								<ItemTemplate>
									<asp:Label ID="lblalicuota_iva" runat="server" Text='<%# GetAlicuotaIVA((double)Eval("alicuota_iva_descuento"))  %>'
										Width="65px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="65px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Importe IVA Dto.">
								<ItemTemplate>
									<asp:Label ID="lblimporte_iva" runat="server" Text='<%# Eval("importe_iva_descuento") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="80px" />
							</asp:TemplateField>
						</Columns>
					</asp:GridView>
				</ContentTemplate>
			</asp:UpdatePanel>
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
			<asp:UpdateProgress ID="descuentosUpdateProgress" runat="server" AssociatedUpdatePanelID="descuentosUpdatePanel"
				DisplayAfter="0">
				<ProgressTemplate>
					<asp:Image ID="descuentosImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
					</asp:Image>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</td>
	</tr>
</table>
