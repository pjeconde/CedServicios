<%@ Control Language="C#" AutoEventWireup="true" Codebehind="ReferenciasCTAFIPConsulta.ascx.cs" Inherits="CedServicios.Site.Facturacion.Electronica.ReferenciasCTAFIPConsulta" %>
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
						ShowFooter="true" ShowHeader="True" ToolTip="El dato de referencia debe ser un número entero"
						Width="1260px">
						<Columns>
                            <asp:TemplateField HeaderText="C&#243;digo de referencia">
                                <ItemTemplate>
                                    <asp:Label ID="lblcodigo_de_referencia" runat="server" Text='<%# Eval("descripcioncodigo_de_referencia") %>'
                                        Width="620px"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Left" Width="620px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Número de referencia">
                                <ItemTemplate>
                                    <asp:Label ID="lbldato_de_referencia" runat="server" Text='<%# Eval("dato_de_referencia") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" />
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
</table>
