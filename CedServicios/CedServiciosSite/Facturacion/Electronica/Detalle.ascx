<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Detalle.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.Detalle" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<tr>
	<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
		<asp:Panel ID="detallePanel" runat="server" BorderStyle="Ridge" Height="300px" ScrollBars="Auto"
			Width="760px" Wrap="true">
			<asp:UpdatePanel ID="detalleUpdatePanel" runat="server" UpdateMode="conditional" ChildrenAsTriggers="true">
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
				</Triggers>
				<ContentTemplate>
					<asp:GridView ID="detalleGridView" runat="server" AutoGenerateColumns="False" BorderColor="Gray"
						BorderStyle="Solid" BorderWidth="1px"
						OnRowCancelingEdit="detalleGridView_RowCancelingEdit"
						OnRowCommand="detalleGridView_RowCommand" OnRowDeleted="detalleGridView_RowDeleted"
						OnRowDeleting="detalleGridView_RowDeleting" OnRowEditing="detalleGridView_RowEditing"
						OnRowUpdated="detalleGridView_RowUpdated" OnRowUpdating="detalleGridView_RowUpdating"
						ShowFooter="True" 
                        ToolTip="Recuerde que al ingresar importes con decimales el separador a utilizar es el punto" 
                        Width="100%">
						<Columns>
                            <asp:TemplateField HeaderStyle-Width="50px" HeaderText="">
								<ItemTemplate>
									<asp:Label ID="lbl_articulosel" runat="server" Text=''
										Width="50px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlarticuloselEdit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlarticuloselEdit_SelectedIndexChanged" Width="50px">
									</asp:DropDownList>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlarticulosel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlarticuloselFooter_SelectedIndexChanged" Width="50px" tooltip="Elegir artículo">
									</asp:DropDownList>
								</FooterTemplate>
								<HeaderStyle Width="50px" />
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Width="200px" HeaderText="Descripción del artículo">
								<ItemTemplate>
									<asp:TextBox ID="lbldescripcion" runat="server" ReadOnly="true" Text='<%# Eval("descripcion") %>'
										TextMode="multiLine" Width="200px">
									</asp:TextBox>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtdescripcion" runat="server" Text='<%# Eval("descripcion") %>'
										TextMode="MultiLine" Width="200px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="DescrEditFilteredTextBoxExtender" runat="server"
										FilterMode="InvalidChars" FilterType="Custom" InvalidChars="<>" TargetControlID="txtdescripcion">
									</cc1:FilteredTextBoxExtender>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtdescripcion" runat="server" Text='' TextMode="MultiLine" Width="200px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="DescrFooterFilteredTextBoxExtender" runat="server"
										FilterMode="InvalidChars" FilterType="Custom" InvalidChars="<>" TargetControlID="txtdescripcion">
									</cc1:FilteredTextBoxExtender>
								</FooterTemplate>
								<HeaderStyle Width="200px" />
								<ItemStyle HorizontalAlign="left" />
								<FooterStyle HorizontalAlign="left" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Gravado / Exento / No gravado">
								<ItemTemplate>
									<asp:Label ID="lbl_indicacion_exento_gravado" runat="server" Text='<%# Eval("indicacion_exento_gravado") %>'
										Width="130px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlindicacion_exento_gravadoEdit" runat="server" Width="130px">
									</asp:DropDownList>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlindicacion_exento_gravado" runat="server" Width="130px">
									</asp:DropDownList>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Center" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Width="100px" HeaderText="Cantidad">
								<ItemTemplate>
									<asp:Label ID="lblcantidad" runat="server" Text='<%# Eval("cantidad") %>' Width="100px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtcantidad" runat="server" AutoPostBack="true" OnTextChanged="CalcularImporteArtEnEdicion"
										Text='<%# Eval("cantidad") %>' Width="70px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="CantEditFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" ValidChars="0123456789." TargetControlID="txtcantidad">
									</cc1:FilteredTextBoxExtender>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtcantidad" runat="server" AutoPostBack="true" OnTextChanged="CalcularImporteArtEnFooter"
										Text='' Width="70px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="CantFooterFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtcantidad" ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</FooterTemplate>
								<HeaderStyle Width="100px" />
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Precio unitario">
								<ItemTemplate>
									<asp:Label ID="lblprecio_unitario" runat="server" Text='<%# Eval("precio_unitario") %>'
										Width="100px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtprecio_unitario" runat="server" AutoPostBack="true" OnTextChanged="CalcularImporteArtEnEdicion"
										Text='<%# Eval("precio_unitario") %>' Width="70px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="PUEditFilteredTextBoxExtender" runat="server" FilterMode="ValidChars"
										FilterType="Custom" TargetControlID="txtprecio_unitario" ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtprecio_unitario" runat="server" AutoPostBack="true" OnTextChanged="CalcularImporteArtEnFooter"
										Text='' Width="70px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="PUFooterFilteredTextBoxExtender" runat="server" FilterMode="ValidChars"
										FilterType="Custom" TargetControlID="txtprecio_unitario" ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Importe">
								<ItemTemplate>
									<asp:Label ID="lblimporte_total_articulo" runat="server" Text='<%# Eval("importe_total_articulo") %>'
										Width="100px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtimporte_total_articulo" runat="server" AutoPostBack="true" OnTextChanged="CalcularImporteArtEnEdicion" Text='<%# Eval("importe_total_articulo") %>'
										Width="100px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="ImpTotEditFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtimporte_total_articulo"
										ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtimporte_total_articulo" runat="server" AutoPostBack="true" OnTextChanged="CalcularImporteArtEnFooter" Text='' Width="100px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="ImpTotFooterFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtimporte_total_articulo"
										ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Width="50px" HeaderText="Alic.IVA %">
								<ItemTemplate>
									<asp:Label ID="lbl_alicuota_articulo" runat="server" Text='<%# GetAlicuotaIVA((double)Eval("alicuota_iva"))  %>'
										Width="50px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlalicuota_articuloEdit" runat="server" AutoPostBack="true"
										OnSelectedIndexChanged="ddlalicuota_articuloEdit_SelectedIndexChanged" Width="50px">
									</asp:DropDownList>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlalicuota_articulo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlalicuota_articuloFooter_SelectedIndexChanged"
										Width="50px">
									</asp:DropDownList>
								</FooterTemplate>
								<HeaderStyle Width="50px" />
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Importe IVA">
								<ItemTemplate>
									<asp:Label ID="lbl_importe_alicuota_articulo" runat="server" Text='<%# Eval("importe_iva") %>'
										Width="100px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtimporte_alicuota_articulo" runat="server" 
										Text='<%# Eval("importe_iva") %>' Width="70px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="ImpTotAlicEditFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtimporte_alicuota_articulo"
										ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtimporte_alicuota_articulo" runat="server" Text='' Width="70px"></asp:TextBox>
									<cc1:FilteredTextBoxExtender ID="ImpTotAlicFooterFilteredTextBoxExtender" runat="server"
										FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtimporte_alicuota_articulo"
										ValidChars="0123456789.">
									</cc1:FilteredTextBoxExtender>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:CommandField CancelText="Cancelar" CausesValidation="true" EditText="Editar"
								HeaderStyle-Font-Bold="false" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px"
								HeaderText="Edición" ShowEditButton="True" UpdateText="Actualizar" ValidationGroup="DetalleEditItem">
								<HeaderStyle Font-Bold="False" HorizontalAlign="Center" Width="150px" />
								<ItemStyle HorizontalAlign="Center" Width="150px" />
							</asp:CommandField>
							<asp:TemplateField HeaderStyle-Width="150px" HeaderText="Eliminación / Incorporación">
								<ItemTemplate>
									<asp:LinkButton ID="linkDeleteDetalle" runat="server" CausesValidation="false" CommandName="Delete"
										Width="150px">Borrar</asp:LinkButton>
								</ItemTemplate>
								<FooterTemplate>
									<asp:LinkButton ID="linkAddDetalle" runat="server" CausesValidation="true" CommandName="AddDetalle"
										ValidationGroup="DetalleFooter" Width="150px">Agregar</asp:LinkButton>
								</FooterTemplate>
								<HeaderStyle Width="150px" />
								<ItemStyle HorizontalAlign="Center" />
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Unidad">
								<ItemTemplate>
									<asp:Label ID="lbl_unidad" runat="server" Text='<%# Eval("unidadDescripcion") %>'
										Width="220px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlunidadEdit" runat="server" Width="220px">
									</asp:DropDownList>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlunidad" runat="server" Width="220px">
									</asp:DropDownList>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Left" />
							</asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Width="150px" HeaderText="GTIN">
                                <ItemTemplate>
                                    <asp:Label ID="lblGTIN" runat="server" Text='<%# Eval("GTIN") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGTIN" runat="server" Text='<%# Eval("GTIN") %>' Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="GTINEditFilteredTextBoxExtender" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtGTIN" ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtGTIN" runat="server" Text='' Width="150px"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="GTINFooterFilteredTextBoxExtender" runat="server"
                                        FilterMode="ValidChars" FilterType="Custom" TargetControlID="txtGTIN" ValidChars="0123456789">
                                    </cc1:FilteredTextBoxExtender>
                                </FooterTemplate>
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
							<asp:TemplateField HeaderStyle-Width="150px" HeaderText="Código Producto Vendedor">
								<ItemTemplate>
									<asp:Label ID="lblcpvendedor" runat="server" Text='<%# Eval("codigo_producto_vendedor") %>'
										Width="150px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtcpvendedor" runat="server" Text='<%# Eval("codigo_producto_vendedor") %>'
										Width="150px"></asp:TextBox>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtcpvendedor" runat="server" Text='' Width="150px"></asp:TextBox>
								</FooterTemplate>
								<HeaderStyle Width="150px" />
								<ItemStyle HorizontalAlign="Left" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Width="150px" HeaderText="Código Producto Comprador (Nomenclador)">
								<ItemTemplate>
									<asp:Label ID="lblcpcomprador" runat="server" Text='<%# Eval("codigo_producto_comprador") %>'
										Width="150px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox ID="txtcpcomprador" runat="server" Text='<%# Eval("codigo_producto_comprador") %>'
										Width="130px"></asp:TextBox>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:TextBox ID="txtcpcomprador" runat="server" Text='' Width="130px"></asp:TextBox>
								</FooterTemplate>
								<HeaderStyle Width="150px" />
								<ItemStyle HorizontalAlign="Left" />
							</asp:TemplateField>
						</Columns>
                        <HeaderStyle Font-Bold="True" />
					</asp:GridView>
				</ContentTemplate>
			</asp:UpdatePanel>
		</asp:Panel>
	</td>
</tr>
<tr>
	<td colspan="2" style="text-align: center; padding: 3px; font-weight: normal;">
		<asp:UpdateProgress ID="detalleUpdateProgress" runat="server" AssociatedUpdatePanelID="detalleUpdatePanel"
			DisplayAfter="0">
			<ProgressTemplate>
				<asp:Image ID="detalleImage" runat="server" Height="25px" ImageUrl="~/Imagenes/CedeiraSF-icono-animado.gif">
				</asp:Image>
			</ProgressTemplate>
		</asp:UpdateProgress>
	</td>
</tr>
