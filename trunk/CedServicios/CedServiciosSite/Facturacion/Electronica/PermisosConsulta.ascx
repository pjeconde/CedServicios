<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PermisosConsulta.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.PermisosConsulta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 782px">
	<tr>
		<td style="height:10px">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			Permisos
		</td>
	</tr>
	<tr>
		<td style="height:10px">
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
						BorderStyle="Solid" BorderWidth="1px"
						EnableViewState="true" Font-Bold="false" GridLines="Both" 
						ShowFooter="true" ShowHeader="True" ToolTip="El número de permiso debe ser un número entero"
						Width="100%">
						<Columns>
							<asp:TemplateField HeaderText="Número de permiso">
								<ItemTemplate>
									<asp:Label ID="lbldato_de_permiso" runat="server" Text='<%# Eval("id_permiso") %>'></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Destino mercadería">
								<ItemTemplate>
									<asp:Label ID="lblcodigo_de_permiso" runat="server" Text='<%# Eval("descripcion_destino_mercaderia") %>'
										Width="320px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Left" Width="320px" />
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
			<asp:UpdateProgress ID="permisosUpdateProgress" runat="server" AssociatedUpdatePanelID="permisosUpdatePanel"
				DisplayAfter="0">
				<ProgressTemplate>
					<asp:Image ID="permisosImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
					</asp:Image>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</td>
	</tr>
</table>
