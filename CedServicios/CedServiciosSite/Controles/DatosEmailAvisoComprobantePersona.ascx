<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosEmailAvisoComprobantePersona.ascx.cs" Inherits="CedServicios.Site.Controles.DatosEmailAvisoComprobantePersona" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<tr>
    <td colspan="2" style="padding-top:5px">
    </td>
</tr>
<tr>
    <td valign="top" style="padding-right:5px; text-align:right">
        <asp:Label ID="DatosEmailAvisoComprobantePersonaLabel" runat="server" Text="Datos para envio de mail de aviso<br />de <b>Generación automática</b><br />de comprobantes"></asp:Label>
    </td>
    <td style="border-style:solid; border-color:Gray; border-width:1px">
        <table>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:3px; width:100px">
                    <asp:Label ID="ActivoLabel" runat="server" Text="Habilitado"></asp:Label>
                </td>
                <td align="left" style="padding-top:3px">
                    <asp:CheckBox ID="ActivoCheckBox" runat="server" Checked="false" TabIndex="502" />
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                    <asp:Label ID="DeLabel" runat="server" Text="De"></asp:Label>
                </td>
                <td align="left" style="padding-top:3px">
                    <asp:TextBox ID="DeTextBox" runat="server" MaxLength="512" TabIndex="503"
                        ToolTip="Ingrese el remitente del mail de aviso"
                        Width="627px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" style="padding-left:5px; padding-right:5px; padding-top:3px">
                    Destinatarios frecuentes
                </td>
                <td align="left" style="padding-top:3px">
                    <asp:Panel ID="DestinatariosFrecuentesPanel" runat="server">
                        <table>
	                        <tr>
		                        <td style="text-align: center; font-weight: normal;">
			                        <asp:UpdatePanel ID="destinatariosFrecuentesUpdatePanel" runat="server" ChildrenAsTriggers="true"
				                        UpdateMode="Conditional">
				                        <ContentTemplate>
					                        <asp:GridView ID="destinatariosFrecuentesGridView" runat="server" AutoGenerateColumns="False"
						                        BorderColor="gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
						                        EnableViewState="true" Font-Bold="false" CssClass="gridview" 
						                        GridLines="Both" OnRowCancelingEdit="destinatariosFrecuentesGridView_RowCancelingEdit"
						                        OnRowCommand="destinatariosFrecuentesGridView_RowCommand" OnRowDeleted="destinatariosFrecuentesGridView_RowDeleted"
						                        OnRowDeleting="destinatariosFrecuentesGridView_RowDeleting" OnRowEditing="destinatariosFrecuentesGridView_RowEditing"
						                        OnRowUpdated="destinatariosFrecuentesGridView_RowUpdated" OnRowUpdating="destinatariosFrecuentesGridView_RowUpdating"
                                                onRowDataBound="destinatariosFrecuentesGridView_RowDataBound"
						                        ShowFooter="true" ShowHeader="True" ToolTip="El separador de decimales a utilizar es el punto">
						                        <Columns>
							                        <asp:TemplateField HeaderText="Id">
								                        <ItemTemplate>
									                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
								                        </ItemTemplate>
								                        <EditItemTemplate>
									                        <asp:TextBox ID="txtid" runat="server" Text='<%# Eval("Id") %>'
										                        Width="100px" MaxLength="15"></asp:TextBox>
									                        <asp:RequiredFieldValidator ID="txtidEditItemRequiredFieldValidator" runat="server"
										                        ControlToValidate="txtid" ErrorMessage="'Id', del destinatario frecuente en edición, no informado"
										                        SetFocusOnError="True" ValidationGroup="DestinatariosFrecuentesEditItem">*</asp:RequiredFieldValidator>
								                        </EditItemTemplate>
								                        <FooterTemplate>
									                        <asp:TextBox ID="txtid" runat="server" Text='' Width="100px" MaxLength="15"></asp:TextBox>
									                        <asp:RequiredFieldValidator ID="txtidFooterRequiredFieldValidator" runat="server"
										                        ControlToValidate="txtid" ErrorMessage="'Id', del destinatario frecuente a agregar, no informado"
										                        SetFocusOnError="True" ValidationGroup="DestinatariosFrecuentesFooter">*</asp:RequiredFieldValidator>
								                        </FooterTemplate>
								                        <ItemStyle HorizontalAlign="Left" />
								                        <FooterStyle HorizontalAlign="Left" />
								                        <HeaderStyle Width="100px" />
							                        </asp:TemplateField>
							                        <asp:TemplateField HeaderText="Para">
								                        <ItemTemplate>
									                        <asp:Label ID="lblpara" runat="server" Text='<%# Eval("Para") %>'></asp:Label>
								                        </ItemTemplate>
								                        <EditItemTemplate>
									                        <asp:TextBox ID="txtpara" runat="server" Text='<%# Eval("Para") %>'
										                        Width="200px" TextMode="MultiLine" MaxLength="512"></asp:TextBox>
									                        <asp:RequiredFieldValidator ID="txtparaEditItemRequiredFieldValidator" runat="server"
										                        ControlToValidate="txtpara" ErrorMessage="'Para', del destinatario frecuente en edición, no informado"
										                        SetFocusOnError="True" ValidationGroup="DestinatariosFrecuentesEditItem">*</asp:RequiredFieldValidator>
								                        </EditItemTemplate>
								                        <FooterTemplate>
									                        <asp:TextBox ID="txtpara" runat="server" Text='' Width="200px" TextMode="MultiLine" MaxLength="512"></asp:TextBox>
									                        <asp:RequiredFieldValidator ID="txtparaFooterRequiredFieldValidator" runat="server"
										                        ControlToValidate="txtpara" ErrorMessage="'Para', del destinatario frecuente a agregar, no informado"
										                        SetFocusOnError="True" ValidationGroup="DestinatariosFrecuentesFooter">*</asp:RequiredFieldValidator>
								                        </FooterTemplate>
								                        <ItemStyle HorizontalAlign="Left" />
								                        <FooterStyle HorizontalAlign="Left" />
								                        <HeaderStyle Width="200px" />
							                        </asp:TemplateField>
							                        <asp:TemplateField HeaderText="Cc">
								                        <ItemTemplate>
									                        <asp:Label ID="lblcc" runat="server" Text='<%# Eval("Cc") %>'></asp:Label>
								                        </ItemTemplate>
								                        <EditItemTemplate>
									                        <asp:TextBox ID="txtcc" runat="server" Text='<%# Eval("Cc") %>'
										                        Width="200px" TextMode="MultiLine" MaxLength="512"></asp:TextBox>
								                        </EditItemTemplate>
								                        <FooterTemplate>
									                        <asp:TextBox ID="txtcc" runat="server" Text='' Width="200px" TextMode="MultiLine" MaxLength="512"></asp:TextBox>
								                        </FooterTemplate>
								                        <ItemStyle HorizontalAlign="Left" />
								                        <FooterStyle HorizontalAlign="Left" />
								                        <HeaderStyle Width="200px" />
							                        </asp:TemplateField>
							                        <asp:CommandField CancelText="Cancelar" CausesValidation="true" EditText="Editar"
								                        HeaderText="Acciones" ShowEditButton="True"
								                        UpdateText="Actualizar" ValidationGroup="DestinatariosFrecuentesEditItem">
								                        <ItemStyle HorizontalAlign="Center" Width="50px" />
								                        <HeaderStyle Width="50px" />
							                        </asp:CommandField>
							                        <asp:TemplateField HeaderText="">
								                        <ItemTemplate>
									                        <asp:LinkButton ID="linkDeleteDestinatariosFrecuentes" runat="server" CausesValidation="false"
										                        CommandName="Delete">Borrar</asp:LinkButton>
								                        </ItemTemplate>
								                        <FooterTemplate>
									                        <asp:LinkButton ID="linkAddDestinatariosFrecuentes" runat="server" CausesValidation="true" CommandName="AdddestinatariosFrecuentes"
										                        ValidationGroup="DestinatariosFrecuentesFooter">Agregar</asp:LinkButton>
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
			                        <asp:UpdateProgress ID="destinatariosFrecuentesUpdateProgress" runat="server" AssociatedUpdatePanelID="destinatariosFrecuentesUpdatePanel"
				                        DisplayAfter="0">
				                        <ProgressTemplate>
					                        <asp:Image ID="destinatariosFrecuentesImage" runat="server" Height="25px" ImageUrl="~/Imagenes/301.gif">
					                        </asp:Image>
				                        </ProgressTemplate>
			                        </asp:UpdateProgress>
		                        </td>
	                        </tr>
	                        <tr>
		                        <td style="text-align: center; padding: 3px; font-weight: normal;">
			                        <asp:ValidationSummary ID="DestinatariosFrecuentesEditValidationSummary" runat="server"
				                        BorderColor="Gray" BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				                        ShowMessageBox="True" ValidationGroup="DestinatariosFrecuentesEditItem"></asp:ValidationSummary>
		                        </td>
	                        </tr>
	                        <tr>
		                        <td style="text-align: center; padding: 3px; font-weight: normal;">
			                        <asp:ValidationSummary ID="DestinatariosFrecuentesFooterValidationSummary" runat="server"
				                        BorderColor="Gray" BorderWidth="1px" HeaderText="Hay que ingresar o corregir los siguientes campos:"
				                        ShowMessageBox="True" ValidationGroup="DestinatariosFrecuentesFooter"></asp:ValidationSummary>
		                        </td>
	                        </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                    <asp:Label ID="CcoLabel1" runat="server" Text="Cco"></asp:Label>
                </td>
                <td align="left" style="padding-top:3px">
                    <asp:TextBox ID="CcoTextBox" runat="server" MaxLength="512" TabIndex="503"
                        Width="627px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                    <asp:Label ID="AsuntoLabel" runat="server" Text="Asunto"></asp:Label>
                </td>
                <td align="left" style="padding-top:3px">
                    <asp:TextBox ID="AsuntoTextBox" runat="server" MaxLength="256" TabIndex="503" Width="627px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                    <asp:Label ID="CuerpoLabel" runat="server" Text="Cuerpo"></asp:Label>
                </td>
                <td align="left" style="padding-top:3px">
                    <asp:TextBox ID="CuerpoTextBox" runat="server" MaxLength="2048" TabIndex="503" Width="627px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="justify" style="padding-left:5px; padding-right:5px; padding-top:5px; font-size:xx-small" colspan="2">
                    En la generación automática de comprobantes, que se hace a partir de la definición de Contratos, se enviará un mail de aviso al que se le adjuntará el comprobante generado.
                </td>
            </tr>
        </table>
    </td>
</tr>
