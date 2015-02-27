<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetalleConsulta.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.DetalleConsulta" %>
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
						BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" 
						ShowFooter="True" ToolTip="Recuerde que al ingresar importes con decimales el separador a utilizar es el punto" 
                        Width="100%">
						<Columns>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="200px" HeaderText="Descripción del artículo">
								<ItemTemplate>
									<asp:TextBox ID="lbldescripcion" runat="server" ReadOnly="true" Text='<%# Eval("descripcion") %>' Style="width: 170px; resize: none; text-align:left"
										TextMode="multiLine" Width="200px">
									</asp:TextBox>
								</ItemTemplate>
								<HeaderStyle Width="200px" />
								<ItemStyle HorizontalAlign="left" />
								<FooterStyle HorizontalAlign="left" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Gravado / Exento / No gravado">
								<ItemTemplate>
									<asp:Label ID="lbl_indicacion_exento_gravado" runat="server" Text='<%# Eval("indicacion_exento_gravado") %>'
										Width="130px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Center" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="100px" HeaderText="Cantidad">
								<ItemTemplate>
									<asp:Label ID="lblcantidad" runat="server" Text='<%# Eval("cantidad") %>' Width="100px"></asp:Label>
								</ItemTemplate>
								<HeaderStyle Width="100px" />
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Precio unitario">
								<ItemTemplate>
									<asp:Label ID="lblprecio_unitario" runat="server" Text='<%# Eval("precio_unitario") %>'
										Width="100px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Importe">
								<ItemTemplate>
									<asp:Label ID="lblimporte_total_articulo" runat="server" Text='<%# Eval("importe_total_articulo") %>'
										Width="100px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="50px" HeaderText="Alic.IVA %">
								<ItemTemplate>
									<asp:Label ID="lbl_alicuota_articulo" runat="server" Text='<%# GetAlicuotaIVA((double)Eval("alicuota_iva"))  %>'
										Width="50px"></asp:Label>
								</ItemTemplate>
								<HeaderStyle Width="50px" />
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Importe IVA">
								<ItemTemplate>
									<asp:Label ID="lbl_importe_alicuota_articulo" runat="server" Text='<%# Eval("importe_iva") %>'
										Width="100px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Right" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Unidad">
								<ItemTemplate>
									<asp:Label ID="lbl_unidad" runat="server" Text='<%# Eval("unidadDescripcion") %>'
										Width="220px"></asp:Label>
								</ItemTemplate>
								<ItemStyle HorizontalAlign="Left" />
							</asp:TemplateField>
                            <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px" HeaderText="GTIN">
                                <ItemTemplate>
                                    <asp:Label ID="lblGTIN" runat="server" Text='<%# Eval("GTIN") %>' Width="150px"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px" HeaderText="Código Producto Vendedor">
								<ItemTemplate>
									<asp:Label ID="lblcpvendedor" runat="server" Text='<%# Eval("codigo_producto_vendedor") %>'
										Width="150px"></asp:Label>
								</ItemTemplate>
								<HeaderStyle Width="150px" />
								<ItemStyle HorizontalAlign="Left" />
							</asp:TemplateField>
							<asp:TemplateField HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px" HeaderText="Código Producto Comprador (Nomenclador)">
								<ItemTemplate>
									<asp:Label ID="lblcpcomprador" runat="server" Text='<%# Eval("codigo_producto_comprador") %>'
										Width="150px"></asp:Label>
								</ItemTemplate>
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
