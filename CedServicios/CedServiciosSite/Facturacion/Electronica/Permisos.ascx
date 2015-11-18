<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Permisos.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Permisos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table style="width: 1282px">
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
			<asp:UpdatePanel ID="permisosUpdatePanel" runat="server" ChildrenAsTriggers="true"
				UpdateMode="Conditional">
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
				</Triggers>
				<ContentTemplate>
					<asp:GridView ID="permisosGridView" runat="server" AutoGenerateColumns="False" BorderColor="gray"
						BorderStyle="Solid" BorderWidth="1px" CssClass="gridview" HorizontalAlign="Center" 
						EnableViewState="true" Font-Bold="false" GridLines="Both"
						OnRowCancelingEdit="permisosGridView_RowCancelingEdit"
						OnRowCommand="permisosGridView_RowCommand" OnRowDeleted="permisosGridView_RowDeleted"
						OnRowDeleting="permisosGridView_RowDeleting" OnRowEditing="permisosGridView_RowEditing"
						OnRowUpdated="permisosGridView_RowUpdated" OnRowUpdating="permisosGridView_RowUpdating"
						ShowFooter="true" ShowHeader="True" ToolTip="El número de permiso debe ser un número entero"
						Width="1260px">
						<Columns>
							<asp:TemplateField HeaderText="Número de permiso">
								<ItemTemplate>
									<asp:Label ID="lbldato_de_permiso" runat="server" Text='<%# Eval("id_permiso") %>'></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtdato_de_permiso" runat="server" Text='<%# Eval("id_permiso") %>'
										Width="75%"></asp:TextBox>
									<cc1:MaskedEditExtender ID="txtdato_de_permisoEditExpoMaskedEditExtender" runat="server"
										ClearMaskOnLostFocus="true" Enabled="true" Mask="99999LL??999999L" MaskType="None"
										PromptCharacter="?" TargetControlID="txtdato_de_permiso">
									</cc1:MaskedEditExtender>
									<asp:RequiredFieldValidator ID="txtdato_de_permisoEditItemRequiredFieldValidator"
										runat="server" ControlToValidate="txtdato_de_permiso" ErrorMessage="número de permiso en edición no informado"
										SetFocusOnError="True" ValidationGroup="PermisosEditItem">*</asp:RequiredFieldValidator>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtdato_de_permiso" runat="server" Text='' Width="75%"></asp:TextBox>
									<cc1:MaskedEditExtender ID="txtdato_de_permisoFooterExpoMaskedEditExtender" runat="server"
										ClearMaskOnLostFocus="true" Enabled="true" Mask="99999LL??999999L" MaskType="None"
										PromptCharacter="?" TargetControlID="txtdato_de_permiso">
									</cc1:MaskedEditExtender>
									<asp:RequiredFieldValidator ID="txtdato_de_permisoFooterRequiredFieldValidator" runat="server"
										ControlToValidate="txtdato_de_permiso" ErrorMessage="Número de permiso a agregar no informado"
										SetFocusOnError="True" ValidationGroup="PermisosFooter">*</asp:RequiredFieldValidator>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Destino mercadería">
								<ItemTemplate>
									<asp:Label ID="lblcodigo_de_permiso" runat="server" Text='<%# Eval("descripcion_destino_mercaderia") %>'
										Width="320px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlcodigo_de_permisoEdit" runat="server" Width="300px">
									</asp:DropDownList><asp:RequiredFieldValidator ID="ddlcodigo_de_permisoEditItemRequiredFieldValidator"
										runat="server" ControlToValidate="ddlcodigo_de_permisoEdit" ErrorMessage="Destino de mercadería en edición no informado"
										SetFocusOnError="True" ValidationGroup="PermisosEditItem">*</asp:RequiredFieldValidator>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlcodigo_de_permiso" runat="server" Width="300px">
									</asp:DropDownList><asp:RequiredFieldValidator ID="ddldescripcionFooterRequiredFieldValidator"
										runat="server" ControlToValidate="ddlcodigo_de_permiso" ErrorMessage="Destino de mercadería a agregar no informado"
										SetFocusOnError="True" ValidationGroup="PermisosFooter">*</asp:RequiredFieldValidator>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Left" Width="320px" />
								<FooterStyle HorizontalAlign="Left" Width="320px" />
							</asp:TemplateField>
							<asp:CommandField CancelText="Cancelar" EditText="Editar" HeaderText="Edici&#243;n"
								ShowEditButton="True" UpdateText="Actualizar" ValidationGroup="PermisosEditItem">
								<ItemStyle HorizontalAlign="Center" />
							</asp:CommandField>
							<asp:TemplateField HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
								<ItemTemplate>
									<asp:LinkButton ID="linkDeletepermisos" runat="server" CausesValidation="false" CommandName="Delete">Borrar</asp:LinkButton>
								</ItemTemplate>
								<FooterTemplate>
									<asp:LinkButton ID="linkAddpermisos" runat="server" CausesValidation="true" CommandName="Addpermisos"
										ValidationGroup="PermisosFooter">Agregar</asp:LinkButton>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Center" />
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
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:ValidationSummary ID="PermisosEditValidationSummary" runat="server" BorderColor="Gray"
				BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				ShowMessageBox="True" ValidationGroup="PermisosEditItem"></asp:ValidationSummary>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:ValidationSummary ID="PermisosFooterValidationSummary" runat="server" BorderColor="Gray"
				BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				ShowMessageBox="True" ValidationGroup="PermisosFooter"></asp:ValidationSummary>
		</td>
	</tr>
</table>
