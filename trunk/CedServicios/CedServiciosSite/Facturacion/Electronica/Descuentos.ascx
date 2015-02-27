<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Descuentos.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Descuentos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table border="0" cellpadding="0" cellspacing="0" style="width:782px">
<%--	<tr>
		<td rowspan="8" style="width: 1px; background-color: Gray;">
		</td>
		<td colspan="1" style="height: 1px; background-color: Gray;">
		</td>
		<td rowspan="8" style="width: 1px; background-color: Gray;">
		</td>
	</tr>--%>
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
						BorderColor="gray" BorderStyle="Solid" BorderWidth="1px"
						EnableViewState="true" Font-Bold="false"
						GridLines="Both" OnRowCancelingEdit="descuentosGridView_RowCancelingEdit"
						OnRowCommand="descuentosGridView_RowCommand" OnRowDeleted="descuentosGridView_RowDeleted"
						OnRowDeleting="descuentosGridView_RowDeleting" OnRowEditing="descuentosGridView_RowEditing"
						OnRowUpdated="descuentosGridView_RowUpdated" OnRowUpdating="descuentosGridView_RowUpdating"
						ShowFooter="true" ShowHeader="True" ToolTip="El separador de decimales a utilizar es el punto"
						Width="100%">
						<Columns>
							<asp:TemplateField HeaderText="Descripci&#243;n del descuento">
								<ItemTemplate>
									<asp:Label ID="lbldescripcion" runat="server" Text='<%# Eval("descripcion_descuento") %>'></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtdescripcion" runat="server" Text='<%# Eval("descripcion_descuento") %>'
										Width="80%"></asp:TextBox>
									<asp:RequiredFieldValidator ID="txtdescripcionEditItemRequiredFieldValidator" runat="server"
										ControlToValidate="txtdescripcion" ErrorMessage="Descripción del descuento global en edición no informada"
										SetFocusOnError="True" ValidationGroup="DescuentosGlobalesEditItem">*</asp:RequiredFieldValidator>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtdescripcion" runat="server" Text='' Width="80%"></asp:TextBox>
									<asp:RequiredFieldValidator ID="txtdescripcionFooterRequiredFieldValidator" runat="server"
										ControlToValidate="txtdescripcion" ErrorMessage="Descripción del descuento global a agregar no informada"
										SetFocusOnError="True" ValidationGroup="DescuentosGlobalesFooter">*</asp:RequiredFieldValidator>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Left" />
								<FooterStyle HorizontalAlign="Left" />
								<HeaderStyle Width="200px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="%">
								<ItemTemplate>
									<asp:Label ID="lblporcentaje" runat="server" Text='<%# Eval("porcentaje_descuento") %>'></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtporcentaje" runat="server" Text='<%# Eval("porcentaje_descuento") %>'
										Width="35px" OnTextChanged="CalcularImporteDtoEdit" AutoPostBack="true"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="porcentajeEditFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtporcentaje" ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtporcentaje" runat="server" AutoPostBack="true" OnTextChanged="CalcularImporteDtoFooter"
										Text='' Width="35px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="porcentajeFooterFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtporcentaje" ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="35px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Importe Dto.">
								<ItemTemplate>
									<asp:Label ID="lblimporte_descuento" runat="server" Text='<%# Eval("importe_descuento") %>'></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtimporte_descuento" runat="server" OnTextChanged="CalcularImporteDtoEdit"
										Text='<%# Eval("importe_descuento") %>' Width="90px" AutoPostBack="true"></asp:TextBox>
									<asp:RequiredFieldValidator ID="txtimporte_descuentoEditItemRequiredFieldValidator"
										runat="server" ControlToValidate="txtimporte_descuento" ErrorMessage="Importe del descuento global en edición no informado"
										SetFocusOnError="True" ValidationGroup="DescuentosGlobalesEditItem">*</asp:RequiredFieldValidator>
									<cc1:FilteredTextBoxExtender ID="importe_descuentoEditFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtimporte_descuento"
										ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtimporte_descuento" runat="server" OnTextChanged="CalcularImporteDtoFooter"
										Text='' Width="90px" AutoPostBack="true"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="importe_descuentoFooterFilteredTextBoxExtender"
										runat="server" FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtimporte_descuento"
										ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
									<asp:RequiredFieldValidator ID="txtimporte_descuentoFooterRequiredFieldValidator"
										runat="server" ControlToValidate="txtimporte_descuento" ErrorMessage="Importe total descuento global a agregar no informado"
										SetFocusOnError="True" ValidationGroup="DescuentosGlobalesFooter">*</asp:RequiredFieldValidator>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="100px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="G / E / N">
								<ItemTemplate>
									<asp:Label ID="lblindicacion" runat="server" Text='<%# Eval("indicacion_exento_gravado_descuento")  %>'
										Width="40px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlindicacionEdit" runat="server" Width="40px">
									</asp:DropDownList>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlindicacion" runat="server" Width="40px">
									</asp:DropDownList>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="40px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Alícuota %">
								<ItemTemplate>
									<asp:Label ID="lblalicuota_iva" runat="server" Text='<%# GetAlicuotaIVA((double)Eval("alicuota_iva_descuento"))  %>'
										Width="65px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlalicuota_ivaEdit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlalicuota_ivaEdit_SelectedIndexChanged"
										Width="65px">
									</asp:DropDownList>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlalicuota_iva" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlalicuota_ivaFooter_SelectedIndexChanged"
										Width="65px">
									</asp:DropDownList>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="65px" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Importe IVA Dto.">
								<ItemTemplate>
									<asp:Label ID="lblimporte_iva" runat="server" Text='<%# Eval("importe_iva_descuento") %>'></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtimporte_iva" runat="server" Text='<%# Eval("importe_iva_descuento") %>'
										Width="80px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="importe_iva_descuentoEditFilteredTextBoxExtender"
										runat="server" FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtimporte_iva"
										ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtimporte_iva" runat="server" Text='' Width="80px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="importe_iva_descuentoFooterFilteredTextBoxExtender"
										runat="server" FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtimporte_iva"
										ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
								<FooterStyle HorizontalAlign="Right" />
								<HeaderStyle Width="80px" />
							</asp:TemplateField>
							<asp:CommandField CancelText="Cancelar" CausesValidation="true" EditText="Editar"
								HeaderText="Edici&#243;n" ShowEditButton="True"
								UpdateText="Actualizar" ValidationGroup="DescuentosGlobalesEditItem">
								<ItemStyle HorizontalAlign="Center" Width="50px" />
								<HeaderStyle Width="50px" />
							</asp:CommandField>
							<asp:TemplateField HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
								<ItemTemplate>
									<asp:LinkButton ID="linkDeletedescuentos" runat="server" CausesValidation="false"
										CommandName="Delete">Borrar</asp:LinkButton>
								</ItemTemplate>
								<FooterTemplate>
									<asp:LinkButton ID="linkAdddescuentos" runat="server" CausesValidation="true" CommandName="Adddescuentos"
										ValidationGroup="DescuentosGlobalesFooter">Agregar</asp:LinkButton>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Center" />
								<HeaderStyle Width="80px" />
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
			<asp:UpdateProgress ID="descuentosUpdateProgress" runat="server" AssociatedUpdatePanelID="descuentosUpdatePanel"
				DisplayAfter="0">
				<ProgressTemplate>
					<asp:Image ID="descuentosImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
					</asp:Image>
				</ProgressTemplate>
			</asp:UpdateProgress>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:ValidationSummary ID="DescuentosGlobalesEditValidationSummary" runat="server"
				BorderColor="Gray" BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				ShowMessageBox="True" ValidationGroup="DescuentosGlobalesEditItem"></asp:ValidationSummary>
		</td>
	</tr>
	<tr>
		<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
			<asp:ValidationSummary ID="DescuentosGlobalesFooterValidationSummary" runat="server"
				BorderColor="Gray" BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				ShowMessageBox="True" ValidationGroup="DescuentosGlobalesFooter"></asp:ValidationSummary>
		</td>
	</tr>
<%--	<tr>
		<td rowspan="8" style="width: 1px; background-color: Gray;">
		</td>
		<td colspan="1" style="height: 1px; background-color: Gray;">
		</td>
		<td rowspan="8" style="width: 1px; background-color: Gray;">
		</td>
	</tr>--%>
</table>
