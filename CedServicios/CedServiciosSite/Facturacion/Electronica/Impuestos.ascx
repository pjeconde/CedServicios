<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Impuestos.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Impuestos" %>

		<table border="0" cellpadding="0" cellspacing="0" style="width:782px; background-color:#fff8dc">
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
					IMPUESTOS GLOBALES
				</td>
			</tr>
			<tr>
				<td style="text-align: center; height: 10px;">
				</td>
			</tr>
			<tr>
				<td style="text-align: center; padding: 3px; font-weight: normal;">
					<asp:UpdatePanel ID="impuestosUpdatePanel" runat="server" ChildrenAsTriggers="true"
						UpdateMode="Conditional">
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="CalcularTotalesButton"></asp:AsyncPostBackTrigger>
						</Triggers>
						<ContentTemplate>
							<asp:GridView ID="impuestosGridView" runat="server" AutoGenerateColumns="False" BorderColor="gray"
								BorderStyle="Solid" BorderWidth="1px" EditRowStyle-ForeColor="#071F70" EmptyDataRowStyle-ForeColor="#071F70"
								EnableViewState="true" Font-Bold="false" ForeColor="#071F70" GridLines="Both"
								HeaderStyle-ForeColor="#A52A2A" OnRowCancelingEdit="impuestosGridView_RowCancelingEdit"
								OnRowCommand="impuestosGridView_RowCommand" OnRowDeleted="impuestosGridView_RowDeleted"
								OnRowDeleting="impuestosGridView_RowDeleting" OnRowEditing="impuestosGridView_RowEditing"
								OnRowUpdated="impuestosGridView_RowUpdated" OnRowUpdating="impuestosGridView_RowUpdating"
								PagerStyle-ForeColor="#071F70" RowStyle-ForeColor="#071F70" SelectedRowStyle-ForeColor="#071F70"
								ShowFooter="true" ShowHeader="True" ToolTip="El separador de decimales a utilizar es el punto"
								Width="100%">
								<Columns>
									<asp:TemplateField HeaderText="C&#243;digo del impuesto">
										<ItemTemplate>
											<asp:Label ID="lblcodigo_impuesto" runat="server" Text='<%# Eval("descripcion") %>'
												Width="250px"></asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:DropDownList ID="ddlcodigo_impuestoEdit" runat="server" Width="250px">
											</asp:DropDownList>
										</EditItemTemplate>
										<FooterTemplate>
											<asp:DropDownList ID="ddlcodigo_impuesto" runat="server" Width="250px">
											</asp:DropDownList>
										</FooterTemplate>
										<ItemStyle HorizontalAlign="Left" Width="250px" />
										<FooterStyle HorizontalAlign="Left" Width="250px" />
										<HeaderStyle Font-Bold="False" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Importe total">
										<ItemTemplate>
											<asp:Label ID="lblimporte_impuesto" runat="server" Width="60px" Text='<%# Eval("importe_impuesto") %>'></asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox ID="txtimporte_impuesto" runat="server" Text='<%# Eval("importe_impuesto") %>'
												Width="40px"></asp:TextBox>
											<asp:RegularExpressionValidator ID="txtimporte_impuestoEditItemRegularExpressionValidator"
												runat="server" ControlToValidate="txtimporte_impuesto" ErrorMessage="Importe total impuesto global en edición mal formateado"
												SetFocusOnError="true" ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="ImpuestosGlobalesEditItem">*</asp:RegularExpressionValidator>
											<asp:RequiredFieldValidator ID="txtimporte_impuestoEditItemRequiredFieldValidator"
												runat="server" ControlToValidate="txtimporte_impuesto" ErrorMessage="Importe total impuesto global en edición no informado"
												SetFocusOnError="True" ValidationGroup="ImpuestosGlobalesEditItem">*</asp:RequiredFieldValidator>
										</EditItemTemplate>
										<FooterTemplate>
											<asp:TextBox ID="txtimporte_impuesto" runat="server" Text='' Width="40px"></asp:TextBox>
											<asp:RegularExpressionValidator ID="txtimporte_impuestoFooterRegularExpressionValidator"
												runat="server" ControlToValidate="txtimporte_impuesto" ErrorMessage="Importe total impuesto global a agregar mal formateado"
												SetFocusOnError="true" ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="ImpuestosGlobalesFooter">*</asp:RegularExpressionValidator>
											<asp:RequiredFieldValidator ID="txtimporte_impuestoFooterRequiredFieldValidator"
												runat="server" ControlToValidate="txtimporte_impuesto" ErrorMessage="Importe total impuesto global a agregar no informado"
												SetFocusOnError="True" ValidationGroup="ImpuestosGlobalesFooter">*</asp:RequiredFieldValidator>
										</FooterTemplate>
										<ItemStyle HorizontalAlign="Right" Width="60px" />
										<HeaderStyle Font-Bold="False" HorizontalAlign="Center" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Jurisdicción">
										<ItemTemplate>
											<asp:Label ID="lbljurisdiccion" runat="server" Text='<%# GetJurisdiccion((int)Eval("codigo_jurisdiccion")) %>'
												Width="160px"></asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:DropDownList ID="ddljurisdiccionEdit" runat="server" Width="160px">
											</asp:DropDownList>
										</EditItemTemplate>
										<FooterTemplate>
											<asp:DropDownList ID="ddljurisdiccion" runat="server" Width="160px">
											</asp:DropDownList>
										</FooterTemplate>
										<ItemStyle HorizontalAlign="Left" Width="160px" />
										<FooterStyle HorizontalAlign="Left" Width="160px" />
										<HeaderStyle Font-Bold="False" />
									</asp:TemplateField>
									<asp:TemplateField HeaderText="Alícuota %">
										<ItemTemplate>
											<asp:Label ID="lblalicuota" runat="server" Width="50px" Text='<%# GetAlicuota((double)Eval("porcentaje_impuesto")) %>'></asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:TextBox ID="txtalicuota" runat="server" Text='<%# Eval("porcentaje_impuesto") %>'
												Width="30px"></asp:TextBox>
											<asp:RegularExpressionValidator ID="txtalicuotaEditItemRegularExpressionValidator"
												runat="server" ControlToValidate="txtalicuota" ErrorMessage="Alícuota del impuesto global en edición mal formateada"
												SetFocusOnError="true" ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="ImpuestosGlobalesEditItem">*</asp:RegularExpressionValidator>
										</EditItemTemplate>
										<FooterTemplate>
											<asp:TextBox ID="txtalicuota" runat="server" Text='' Width="30px"></asp:TextBox>
											<asp:RegularExpressionValidator ID="txtalicuotaFooterRegularExpressionValidator"
												runat="server" ControlToValidate="txtalicuota" ErrorMessage="Alícuota de impuesto global a agregar mal formateada"
												SetFocusOnError="true" ValidationExpression="[0-9]+(\.[0-9]+)?" ValidationGroup="ImpuestosGlobalesFooter">*</asp:RegularExpressionValidator>
										</FooterTemplate>
										<ItemStyle HorizontalAlign="Right"  Width="50px"/>
										<HeaderStyle Font-Bold="False" Width="50px" />
									</asp:TemplateField>
									<asp:CommandField CancelText="Cancelar" EditText="Editar" HeaderText="Edici&#243;n"
										ShowEditButton="True" UpdateText="Actualizar" ValidationGroup="ImpuestosGlobalesEditItem">
										<ItemStyle HorizontalAlign="Center" Width="80px" />
										<HeaderStyle Font-Bold="False" Width="80px" />
									</asp:CommandField>
									<asp:TemplateField HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
										<ItemTemplate>
											<asp:LinkButton ID="linkDeleteImpuesto" runat="server" CausesValidation="false" CommandName="Delete" Width="100px">Borrar</asp:LinkButton>
										</ItemTemplate>
										<FooterTemplate>
											<asp:LinkButton ID="linkAddImpuesto" runat="server" CausesValidation="true" CommandName="AddImpuestoGlobal"
												ValidationGroup="ImpuestosGlobalesFooter" Width="100px">Agregar</asp:LinkButton>
										</FooterTemplate>
										<ItemStyle HorizontalAlign="Center" Width="100px" />
										<HeaderStyle Font-Bold="False" Width="100px" />
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
					<asp:UpdateProgress ID="impuestosUpdateProgress" runat="server" AssociatedUpdatePanelID="impuestosUpdatePanel"
						DisplayAfter="0">
						<ProgressTemplate>
							<asp:Image ID="impuestosImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
							</asp:Image>
						</ProgressTemplate>
					</asp:UpdateProgress>
				</td>
			</tr>
			<tr>
				<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
					<asp:ValidationSummary ID="ImpuestoEditItemValidationSummary" runat="server" BorderColor="Gray"
						BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
						ShowMessageBox="True" ValidationGroup="ImpuestosGlobalesEditItem"></asp:ValidationSummary>
				</td>
			</tr>
			<tr>
				<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
					<asp:ValidationSummary ID="ImpuestoFooterValidationSummary" runat="server" BorderColor="Gray"
						BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
						ShowMessageBox="True" ValidationGroup="ImpuestosGlobalesFooter"></asp:ValidationSummary>
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

