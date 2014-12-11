<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DescuentosConsulta.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.DescuentosConsulta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
	<tr>
		<td rowspan="8" style="width: 1px; background-color: Gray;">
		</td>
		<td colspan="1" style="height: 1px; background-color: Gray;">
		</td>
		<td rowspan="8" style="width: 1px; background-color: Gray;">
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			DESCUENTOS GLOBALES
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
		</td>
	</tr>
	<tr>
		<td style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:UpdatePanel ID="descuentosUpdatePanel" runat="server" ChildrenAsTriggers="true"
				UpdateMode="Conditional">
				<ContentTemplate>
					<asp:GridView ID="descuentosGridView" runat="server" AutoGenerateColumns="False"
						BorderColor="gray" BorderStyle="Solid" BorderWidth="1px" EditRowStyle-ForeColor="#071F70"
						EmptyDataRowStyle-ForeColor="#071F70" EnableViewState="true" Font-Bold="false"
						ForeColor="#071F70" GridLines="Both" 
						PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
						ShowFooter="true" ShowHeader="True" ToolTip="El separador de decimales a utilizar es el punto"
						Width="100%">
						<Columns>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Descripci&#243;n del descuento">
								<ItemTemplate>
									<asp:Label ID="lbldescripcion" runat="server" Text='<%# Eval("descripcion_descuento") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Left" />
								<FooterStyle HorizontalAlign="Left" />
								<HeaderStyle Width="200px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="%">
								<ItemTemplate>
									<asp:Label ID="lblporcentaje" runat="server" Text='<%# Eval("porcentaje_descuento") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="35px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Importe Dto.">
								<ItemTemplate>
									<asp:Label ID="lblimporte_descuento" runat="server" Text='<%# Eval("importe_descuento") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="G / E / N">
								<ItemTemplate>
									<asp:Label ID="lblindicacion" runat="server" Text='<%# Eval("indicacion_exento_gravado_descuento")  %>'
										Width="40px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="40px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Alícuota %">
								<ItemTemplate>
									<asp:Label ID="lblalicuota_iva" runat="server" Text='<%# GetAlicuotaIVA((double)Eval("alicuota_iva_descuento"))  %>'
										Width="65px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="65px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Importe IVA Dto.">
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
					<asp:Image ID="descuentosImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
					</asp:Image>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
		</td>
	</tr>
	<tr>
		<td rowspan="8" style="width: 1px; background-color: Gray;">
		</td>
		<td colspan="1" style="height: 1px; background-color: Gray;">
		</td>
		<td rowspan="8" style="width: 1px; background-color: Gray;">
		</td>
	</tr>
</table>
