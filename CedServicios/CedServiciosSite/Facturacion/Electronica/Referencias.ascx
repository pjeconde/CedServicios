<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Referencias.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Referencias" %>
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
						OnRowCancelingEdit="referenciasGridView_RowCancelingEdit"
						OnRowCommand="referenciasGridView_RowCommand" OnRowDeleted="referenciasGridView_RowDeleted"
						OnRowDeleting="referenciasGridView_RowDeleting" OnRowEditing="referenciasGridView_RowEditing"
						OnRowUpdated="referenciasGridView_RowUpdated" OnRowUpdating="referenciasGridView_RowUpdating"
						ShowFooter="true" ShowHeader="True" ToolTip="El dato de referencia debe ser un número entero"
						Width="1260px">
						<Columns>
                            <asp:TemplateField HeaderText="C&#243;digo de referencia">
                                <ItemTemplate>
                                    <asp:Label ID="lblcodigo_de_referencia" runat="server" Text='<%# Eval("descripcioncodigo_de_referencia") %>'
                                        Width="620px"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlcodigo_de_referenciaEdit" runat="server" Width="600px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddlcodigo_de_referenciaEditItemRequiredFieldValidator"
                                        runat="server" ControlToValidate="ddlcodigo_de_referenciaEdit" ErrorMessage="Codigo de referencia en edición no informado"
                                        SetFocusOnError="True" ValidationGroup="ReferenciasEditItem">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlcodigo_de_referencia" runat="server" Width="600px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddldescripcionFooterRequiredFieldValidator" runat="server"
                                        ControlToValidate="ddlcodigo_de_referencia" ErrorMessage="Codigo de referencia a agregar no informado"
                                        SetFocusOnError="True" ValidationGroup="ReferenciasFooter">*</asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="620px" />
                                <FooterStyle HorizontalAlign="Left" Width="620px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Número de referencia">
                                <ItemTemplate>
                                    <asp:Label ID="lbldato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtdato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'
                                        Width="400px"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="txtdato_de_referenciaEditExpoMaskedEditExtender" runat="server"
                                        ClearMaskOnLostFocus="false" Enabled="false" Mask="9999-99999999" MaskType="Number"
                                        PromptCharacter="?" TargetControlID="txtdato_de_referencia">
                                    </cc1:MaskedEditExtender>
                                    <cc1:FilteredTextBoxExtender ID="txtdato_de_referenciaEditExpoFilteredTextBoxExtender"
                                        runat="server" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txtdato_de_referencia">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="txtdato_de_referenciaEditItemRequiredFieldValidator"
                                        runat="server" ControlToValidate="txtdato_de_referencia" ErrorMessage="dato de referencia en edición no informado"
                                        SetFocusOnError="True" ValidationGroup="ReferenciasEditItem">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtdato_de_referencia" runat="server" Text='' Width="75%"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="txtdato_de_referenciaFooterExpoMaskedEditExtender" runat="server"
                                        ClearMaskOnLostFocus="false" Enabled="false" Mask="9999-99999999" MaskType="Number"
                                        PromptCharacter="?" TargetControlID="txtdato_de_referencia">
                                    </cc1:MaskedEditExtender>
                                    <cc1:FilteredTextBoxExtender ID="txtdato_de_referenciaFooterExpoFilteredTextBoxExtender"
                                        runat="server" FilterMode="ValidChars" FilterType="Numbers" TargetControlID="txtdato_de_referencia">
                                    </cc1:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="txtdato_de_referenciaFooterRequiredFieldValidator"
                                        runat="server" ControlToValidate="txtdato_de_referencia" ErrorMessage="Dato de referencia a agregar no informado"
                                        SetFocusOnError="True" ValidationGroup="ReferenciasFooter">*</asp:RequiredFieldValidator>
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:CommandField CancelText="Cancelar" EditText="Editar" HeaderText="Edici&#243;n"
                                ShowEditButton="True" UpdateText="Actualizar" ValidationGroup="ReferenciasEditItem">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Eliminaci&#243;n / Incorporaci&#243;n">
                                <ItemTemplate>
                                    <asp:LinkButton ID="linkDeletereferencias" runat="server" CausesValidation="false"
                                        CommandName="Delete">Borrar</asp:LinkButton>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="linkAddreferencias" runat="server" CausesValidation="true" CommandName="Addreferencias"
                                        ValidationGroup="ReferenciasFooter">Agregar</asp:LinkButton>
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
