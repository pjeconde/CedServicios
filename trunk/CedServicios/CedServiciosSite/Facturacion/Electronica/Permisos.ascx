<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Permisos.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Permisos" %>
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
			PERMISOS DE EXPORTACI�N
		</td>
	</tr>
	<tr>
		<td style="text-align: center; height: 10px;">
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
						BorderStyle="Solid" BorderWidth="1px" EditRowStyle-ForeColor="#071F70" EmptyDataRowStyle-ForeColor="#071F70"
						EnableViewState="true" Font-Bold="false" ForeColor="#071F70" GridLines="Both"
						HeaderStyle-ForeColor="#A52A2A" OnRowCancelingEdit="permisosGridView_RowCancelingEdit"
						OnRowCommand="permisosGridView_RowCommand" OnRowDeleted="permisosGridView_RowDeleted"
						OnRowDeleting="permisosGridView_RowDeleting" OnRowEditing="permisosGridView_RowEditing"
						OnRowUpdated="permisosGridView_RowUpdated" OnRowUpdating="permisosGridView_RowUpdating"
						PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
						ShowFooter="true" ShowHeader="True" ToolTip="El n�mero de permiso debe ser un n�mero entero"
						Width="100%">
						<Columns>
							<asp:TemplateField HeaderText="N�mero de permiso">
								<ItemTemplate>
									<asp:Label ID="lbldato_de_permiso" runat="server" Text='<%# Eval("id_permiso") %>'></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtdato_de_permiso" runat="server" Text='<%# Eval("id_permiso") %>'
										Width="75%" style="Color:#071F70"></asp:TextBox>
									<cc1:MaskedEditExtender ID="txtdato_de_permisoEditExpoMaskedEditExtender" runat="server"
										ClearMaskOnLostFocus="true" Enabled="true" Mask="99999LL??999999L" MaskType="None"
										PromptCharacter="?" TargetControlID="txtdato_de_permiso">
									</cc1:MaskedEditExtender>
									<asp:RequiredFieldValidator ID="txtdato_de_permisoEditItemRequiredFieldValidator"
										runat="server" ControlToValidate="txtdato_de_permiso" ErrorMessage="n�mero de permiso en edici�n no informado"
										SetFocusOnError="True" ValidationGroup="PermisosEditItem">*</asp:RequiredFieldValidator>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtdato_de_permiso" runat="server" Text='' Width="75%" style="Color:#071F70"></asp:TextBox>
									<cc1:MaskedEditExtender ID="txtdato_de_permisoFooterExpoMaskedEditExtender" runat="server"
										ClearMaskOnLostFocus="true" Enabled="true" Mask="99999LL??999999L" MaskType="None"
										PromptCharacter="?" TargetControlID="txtdato_de_permiso">
									</cc1:MaskedEditExtender>
									<asp:RequiredFieldValidator ID="txtdato_de_permisoFooterRequiredFieldValidator" runat="server"
										ControlToValidate="txtdato_de_permiso" ErrorMessage="N�mero de permiso a agregar no informado"
										SetFocusOnError="True" ValidationGroup="PermisosFooter">*</asp:RequiredFieldValidator>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<HeaderStyle Font-Bold="False" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Destino mercader�a">
								<ItemTemplate>
									<asp:Label ID="lblcodigo_de_permiso" runat="server" Text='<%# Eval("descripcion_destino_mercaderia") %>'
										Width="320px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlcodigo_de_permisoEdit" runat="server" Width="300px" style="Color:#071F70">
									</asp:DropDownList><asp:RequiredFieldValidator ID="ddlcodigo_de_permisoEditItemRequiredFieldValidator"
										runat="server" ControlToValidate="ddlcodigo_de_permisoEdit" ErrorMessage="Destino de mercader�a en edici�n no informado"
										SetFocusOnError="True" ValidationGroup="PermisosEditItem">*</asp:RequiredFieldValidator>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlcodigo_de_permiso" runat="server" Width="300px" style="Color:#071F70">
									</asp:DropDownList><asp:RequiredFieldValidator ID="ddldescripcionFooterRequiredFieldValidator"
										runat="server" ControlToValidate="ddlcodigo_de_permiso" ErrorMessage="Destino de mercader�a a agregar no informado"
										SetFocusOnError="True" ValidationGroup="PermisosFooter">*</asp:RequiredFieldValidator>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Left" Width="320px" />
								<FooterStyle HorizontalAlign="Left" Width="320px" />
								<HeaderStyle Font-Bold="False" />
							</asp:TemplateField>
							<asp:CommandField CancelText="Cancelar" EditText="Editar" HeaderText="Edici&#243;n"
								ShowEditButton="True" UpdateText="Actualizar" ValidationGroup="PermisosEditItem">
								<ItemStyle HorizontalAlign="Center" />
								<HeaderStyle Font-Bold="False" />
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
								<HeaderStyle Font-Bold="False" />
							</asp:TemplateField>
						</Columns>
						<EmptyDataRowStyle ForeColor="#071F70" />
                        <FooterStyle ForeColor="#071F70" />
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
