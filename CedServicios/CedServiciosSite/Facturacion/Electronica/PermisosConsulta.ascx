<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermisosConsulta.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.PermisosConsulta" %>
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
			PERMISOS DE EXPORTACIÓN
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
		</td>
	</tr>
	<tr>
		<td style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:UpdatePanel ID="permisosUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
				</Triggers>
				<ContentTemplate>
					<asp:GridView ID="permisosGridView" runat="server" AutoGenerateColumns="False" BorderColor="gray"
						BorderStyle="Solid" BorderWidth="1px" EditRowStyle-ForeColor="#071F70" EmptyDataRowStyle-ForeColor="#071F70"
						EnableViewState="true" Font-Bold="false" ForeColor="#071F70" GridLines="Both" 
						PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
						ShowFooter="true" ShowHeader="True" ToolTip="El número de permiso debe ser un número entero"
						Width="100%">
						<Columns>
							<asp:TemplateField HeaderText="Número de permiso">
								<ItemTemplate>
									<asp:Label ID="lbldato_de_permiso" runat="server" Text='<%# Eval("id_permiso") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<HeaderStyle Font-Bold="False" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Destino mercadería">
								<ItemTemplate>
									<asp:Label ID="lblcodigo_de_permiso" runat="server" Text='<%# Eval("descripcion_destino_mercaderia") %>'
										Width="320px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Left" Width="320px" />
								<HeaderStyle Font-Bold="False" />
							</asp:TemplateField>
						</Columns>
						<EmptyDataRowStyle ForeColor="#071F70" />
						<RowStyle ForeColor="#071F70" />
						<EditRowStyle ForeColor="#071F70" />
						<SelectedRowStyle ForeColor="#071F70" />
						<PagerStyle ForeColor="#071F70" />
						<HeaderStyle ForeColor="Brown" />
					</asp:GridView>
				</ContentTemplate>
			</asp:UpdatePanel>
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
			<asp:UpdateProgress ID="permisosUpdateProgress" runat="server" AssociatedUpdatePanelID="permisosUpdatePanel"
				DisplayAfter="0">
				<ProgressTemplate>
					<asp:Image ID="permisosImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
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
<br />
