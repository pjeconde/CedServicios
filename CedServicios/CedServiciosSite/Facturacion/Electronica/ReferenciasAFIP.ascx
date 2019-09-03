<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ReferenciasAFIP.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.ReferenciasAFIP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table style="width: 1282px">
	<tr>
		<td style="height:10px">
		</td>
	</tr>
	<tr>
		<td class="TextoResaltado" style="text-align: center;">
			REFERENCIAS
		</td>
	</tr>
	<tr>
		<td style="height:10px">
        <a href="javascript:void(0)" id="A2" role="button" class="popover-test" data-html="true" title="Código de operación" style="width: 200px"
                                                        data-content="Usted podrá ingresar Referencias con un tipo de compronte AFIP igual a 'SI', solo si el tipo de comprobante que usted esta realizando es alguno de los siguientes: 2-NDA, 3-NCA, 7-NDB, 8-NCB, 12-NDC, 13-NCC, 52 o 53.">
                                                        <span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit;">
        <!-- 		
        objFEResponse.FeDetResp[i].Observaciones[j].Msg	"Debera informar Referencias AFIP solo si el tipo de comprobante que se informa es igual a 2-NDA, 3-NCA, 7-NDB, 8-NCB, 12-NDC, 13-NCC, 52 o 53"
        -->
		</td>
	</tr>
	<tr>
		<td style="text-align: center; padding: 3px; font-weight: normal;">
            <asp:UpdatePanel ID="referenciasUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                <Triggers>
					<asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
				</Triggers>
                <ContentTemplate>
					<asp:GridView ID="referenciasGridView" runat="server" 
                        AutoGenerateColumns="False" BorderColor="gray"
						BorderStyle="Solid" BorderWidth="1px" CssClass="gridview" HorizontalAlign="Center" 
						EnableViewState="true" Font-Bold="false" GridLines="Both"
						OnRowCancelingEdit="referenciasGridView_RowCancelingEdit"
						OnRowCommand="referenciasGridView_RowCommand" OnRowDeleted="referenciasGridView_RowDeleted"
						OnRowDeleting="referenciasGridView_RowDeleting" OnRowEditing="referenciasGridView_RowEditing"
						OnRowUpdated="referenciasGridView_RowUpdated" OnRowUpdating="referenciasGridView_RowUpdating"
						ShowFooter="true" ShowHeader="True" ToolTip="El dato de referencia debe ser un número entero"
						Width="1260px" onrowdatabound="referenciasGridView_RowDataBound" 
                        onrowcreated="referenciasGridView_RowCreated">
						<Columns>
                            <asp:TemplateField HeaderText="Tipo de comprobante AFIP">
                                <ItemTemplate>
                                    <asp:Label ID="lbltipo_comprobante_afip" runat="server" Text='<%# Eval("tipo_comprobante_afip") %>'
                                        Width="100px"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddltipo_comprobante_afipEdit" runat="server" OnSelectedIndexChanged="ddltipo_comprobante_afipEdit_SelectedIndexChanged" AutoPostBack="true"  Width="80px">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddltipo_comprobante_afip" runat="server" OnSelectedIndexChanged="ddltipo_comprobante_afip_SelectedIndexChanged" AutoPostBack="true" Width="80px">
                                    </asp:DropDownList>
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                <FooterStyle HorizontalAlign="Left" Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="C&#243;digo de referencia">
                                <ItemTemplate>
                                    <asp:Label ID="lblcodigo_de_referencia" runat="server" Text='<%# Eval("descripcioncodigo_de_referencia") %>'
                                        Width="620px"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlcodigo_de_referenciaEdit" runat="server" Width="600px" OnSelectedIndexChanged="ddlcodigo_de_referenciaEdit_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="ddlcodigo_de_referenciaEditItemRequiredFieldValidator"
                                        runat="server" ControlToValidate="ddlcodigo_de_referenciaEdit" ErrorMessage="Codigo de referencia en edición no informado"
                                        SetFocusOnError="True" ValidationGroup="ReferenciasEditItem">*</asp:RequiredFieldValidator>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlcodigo_de_referencia" runat="server" Width="600px" OnSelectedIndexChanged="ddlcodigo_de_referencia_SelectedIndexChanged" AutoPostBack="true">
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
                                        ClearMaskOnLostFocus="false" Enabled="false" Mask="99999-99999999" MaskType="Number"
                                        PromptCharacter="?" TargetControlID="txtdato_de_referencia">
                                    </cc1:MaskedEditExtender>
                                    <cc1:MaskedEditExtender ID="txtdato_de_referenciaEditMiPyMEsMaskedEditExtender" runat="server"
                                        ClearMaskOnLostFocus="false" Enabled="false" Mask="99999-99999999-99999999999-99999999" MaskType="Number"
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
                                    <asp:TextBox ID="txtdato_de_referencia" runat="server" Text='' Width="250px"></asp:TextBox> 
                                    <a href="javascript:void(0)" id="A2" role="button" class="popover-test" data-html="true" title="Código de operación" style="width: 280px"
                                                        data-content="Los formatos permitidos según las opciones seleccionadas son dos.<br/><br/>Uno es ?????-???????? (5 dígitos para el punto de venta y 8 dígitos para el nro. de comprobante).<br/><br/> Otro para Notas de Crédito MiPyMEs es ?????-????????-???????????-???????? (se le agrega 11 dígitos para el CUIT del vendedor y 8 dígitos formato AAAAMMDD para la fecha de emisión del comprobante referenciado).<br><br>Si la nota de crédito MiPyMEs anula una Factura de crédito MiPyMEs y ésta, no fué rechazada por el cliente, debe agregar en <b>DATOS COMERCIALES</b> el siguiente texto: <b> ANUL:N</b>
Si el comprobante fué rechazado por su proveedor, debe ingresar el texto: <b>ANUL:S</b><br><br>También puede ser libre, sin formato.">
                                                        <span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit;">
                                    <cc1:MaskedEditExtender ID="txtdato_de_referenciaFooterExpoMaskedEditExtender" runat="server"
                                        ClearMaskOnLostFocus="false" Enabled="false" Mask="99999-99999999" MaskType="Number"
                                        PromptCharacter="?" TargetControlID="txtdato_de_referencia">
                                    </cc1:MaskedEditExtender>
                                    <cc1:MaskedEditExtender ID="txtdato_de_referenciaFooterMiPyMEsMaskedEditExtender" runat="server"
                                        ClearMaskOnLostFocus="false" Enabled="false" Mask="99999-99999999-99999999999-99999999" MaskType="Number"
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
			&nbsp;</td>
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
