

<%@ Control Language="C#" AutoEventWireup="true" Codebehind="DetalleM.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.DetalleM" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table  style="width:1282px">
	<tr>
		<td style="height: 10px;">
		</td>
	</tr>
    <tr>
		<td style="text-align: center; font-weight: normal; padding-left:10px; ">
		<asp:Panel ID="detallePanel" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="100%" ScrollBars="Auto" Wrap="true" Width="1260px" CssClass="center">
            <asp:UpdatePanel ID="detalleUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="PuntoVtaDropDownList"></asp:AsyncPostBackTrigger>
				</Triggers>
				<ContentTemplate>
					<asp:GridView ID="detalleGridView" runat="server" AutoGenerateColumns="False" BorderColor="Gray"
						BorderStyle="None" BorderWidth="0px" Font-Bold="False" CssClass="gridview" 
						OnRowCancelingEdit="detalleGridView_RowCancelingEdit"
						OnRowCommand="detalleGridView_RowCommand" OnRowDeleted="detalleGridView_RowDeleted"
						OnRowDeleting="detalleGridView_RowDeleting" OnRowEditing="detalleGridView_RowEditing"
						OnRowUpdated="detalleGridView_RowUpdated" OnRowUpdating="detalleGridView_RowUpdating"
						ShowFooter="True" ToolTip="Recuerde que al ingresar importes con decimales el separador a utilizar es el punto" 
                        Width="1260px">
						<Columns>
                            <asp:TemplateField HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Center" HeaderText=" ">
								<ItemTemplate>
									<asp:Label ID="lbl_articulosel" runat="server" Text='' Width="50px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlarticuloselEdit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlarticuloselEdit_SelectedIndexChanged" Width="50px">
									</asp:DropDownList>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlarticulosel" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlarticuloselFooter_SelectedIndexChanged" Width="50px" tooltip="Elegir artículo">
									</asp:DropDownList>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" HeaderText="Descripción del artículo">
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
								<ItemStyle HorizontalAlign="left" />
								<FooterStyle HorizontalAlign="left" />
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
								<HeaderStyle Width="100px" HorizontalAlign="Center" />
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
                            <asp:TemplateField HeaderText="Unidad">
								<ItemTemplate>
									<asp:Label ID="lbl_unidad" runat="server" Text='<%# Eval("unidadDescripcion") %>'
										Width="220px"></asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:DropDownList ID="ddlunidad" runat="server" Width="220px">
									</asp:DropDownList>
								</EditItemTemplate>
								<FooterTemplate>
									<asp:DropDownList ID="ddlunidad" runat="server" Width="220px">
									</asp:DropDownList>
								</FooterTemplate>
								<ItemStyle HorizontalAlign="Left" />
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
							<asp:CommandField CancelText="Cancelar" CausesValidation="true" EditText="Editar"
								HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="150px"
								HeaderText="Edición" ShowEditButton="True" UpdateText="Actualizar" ValidationGroup="DetalleEditItem">
								<HeaderStyle HorizontalAlign="Center" Width="150px" />
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
				    <asp:Image ID="detalleImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
				    </asp:Image>
			    </ProgressTemplate>
		    </asp:UpdateProgress>
	    </td>
    </tr>
</table>

    <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    PopupControlID="BusquedaArticuloPanel"
    PopupDragHandleControlID="BusquedaArticuloPanel" 
    TargetControlID="TargetControlIDdelModalPopupExtender1"
    BackgroundCssClass="modalBackground"
    BehaviorID="mdlPopup">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="BusquedaArticuloPanel" runat="server" DefaultButton="BuscarButton" ScrollBars="Vertical" Height="500px" CssClass="ModalWindow">
        <table align="center">
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Búsqueda de Artículo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:20px; padding-left:10px">
                    <asp:Label ID="Label3" runat="server" Text="Articulo(s) perteneciente(s) al CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                </td>
                <td style="width:500px">
                </td>
            </tr>
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:20px">
                    <asp:RadioButton ID="IdRadioButton" runat="server" AutoPostBack="true" Text="Id." GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1" TextAlign="Left" />
	            </td>
			    <td align="left" style="padding-top:20px">
                    <asp:TextBox ID="IdTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px"></asp:TextBox>
			    </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:5px">
                    <asp:RadioButton ID="DescrRadioButton" runat="server" AutoPostBack="true" Text="Descripción" Checked="true" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2" TextAlign="Left" />
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="DescrTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px" TextMode="MultiLine"></asp:TextBox>
                </td>        
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="height: 24px; padding-top:20px">
                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" />
<%--                     OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false"
--%>
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="padding-top:20px; padding-left:10px" colspan="3">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="ArticulosGridView" runat="server"
                            AutoGenerateColumns="false" onrowcommand="ArticulosGridView_RowCommand" OnRowDataBound="ArticulosGridView_RowDataBound" CssClass="grilla" GridLines="None">
                            <Columns>
                                <asp:ButtonField HeaderText="Artículo" Text="Seleccionar" CommandName="Seleccionar" ButtonType="Link" ItemStyle-ForeColor="Blue" ItemStyle-Width="90px">
                                </asp:ButtonField>
                                <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" Visible="false">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descr" HeaderText="descripción" SortExpression="Descr">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnidadDescr" HeaderText="Unidad de medida" SortExpression="UnidadDescr">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IndicacionExentoGravado" HeaderText="Exento/Gravado/No gravado" SortExpression="IndicacionExentoGravado">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AlicuotaIVA" HeaderText="Alicuota IVA (%)" SortExpression="AlicuotaIVA">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="right" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>