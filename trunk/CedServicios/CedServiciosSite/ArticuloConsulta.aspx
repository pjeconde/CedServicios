<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ArticuloConsulta.aspx.cs" Inherits="CedServicios.Site.ArticuloConsulta" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Artículos"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px;">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="ArticulosGridView" runat="server"
                        AutoGenerateColumns="false" onrowcommand="ArticulosGridView_RowCommand" OnRowDataBound="ArticulosGridView_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="TargetControlButton" runat="server" style="Display:none;" Text="Button" />
                                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="ArticuloPanel" TargetControlID="TargetControlButton" BackgroundCssClass="modalBackground" runat="server" />
                                    <asp:LinkButton ID="VerLinkButton" CommandName="Ver" runat="server">Ver detalle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center" style="height: 24px; padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="505" Text="Salir" PostBackUrl="~/Default.aspx" />
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    <asp:Panel ID="ArticuloPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td align="center" colspan="2" style="padding-top:20px">
                    <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Consulta de Artículo"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top: 20px">
                    <asp:Label ID="Label4" runat="server" Text="Artículo perteneciente al CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:5px">
                    <asp:Label ID="Label9" runat="server" Text="Id."></asp:Label>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="IdTextBox" runat="server" MaxLength="20" TabIndex="2" Width="100px"></asp:TextBox>
                </td>        
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:5px">
                    <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="DescrTextBox" runat="server" MaxLength="100" TabIndex="3" Width="300px"></asp:TextBox>
                </td>        
            </tr>
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:5px">
		            <asp:Label ID="Label11" runat="server" Text="GTIN"></asp:Label>
	            </td>
                <td align="left" style="padding-top:5px">
		            <asp:TextBox ID="GTINTextBox" runat="server" MaxLength="20" TabIndex="4"
                        ToolTip="(opcional) Código estándar GSI global de identificación de productos. Se utiliza para comercio internacional. Es un campo numérico de 20 caracteres."
			            Width="150px"></asp:TextBox>
                </td>									
            </tr>
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:5px">
		            <asp:Label ID="Label18" runat="server" Text="Unidad de medida"></asp:Label>
	            </td>
			    <td align="left" style="padding-top:5px">
				    <asp:DropDownList ID="UnidadDropDownList" runat="server" TabIndex="5" 
                        Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			    </td>
            </tr>
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:5px">
		            <asp:Label ID="Label5" runat="server" Text="Indicacion Exento/Gravado"></asp:Label>
	            </td>
			    <td align="left" style="padding-top:5px">
				    <asp:DropDownList ID="IndicacionExentoGravadoDropDownList" runat="server" TabIndex="6" 
                        Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			    </td>
            </tr>
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:5px">
		            <asp:Label ID="Label6" runat="server" Text="Alícuota I.V.A."></asp:Label>
	            </td>
			    <td align="left" style="padding-top:5px">
				    <asp:DropDownList ID="AlicuotaIVADropDownList" runat="server" TabIndex="7" 
                        Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			    </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Button ID="Button1" runat="server" Text="Salir" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
