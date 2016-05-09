<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosEmailAvisoComprobantePersona.ascx.cs" Inherits="CedServicios.Site.Controles.DatosEmailAvisoComprobantePersona" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<tr>
    <td colspan="2" style="padding-top:5px">
    </td>
</tr>
<tr>
    <td valign="top" style="padding-right:5px; text-align:right">
        <asp:Label ID="DatosEmailAvisoComprobantePersonaLabel" runat="server" Text="Datos para envio de mail de aviso<br />de <b>Generación automática</b><br />de comprobantes"></asp:Label>
        &nbsp;<a href="#" role="button" class="popover-test" data-html="true" data-placement="top" title="INFORMACIÓN ENVÍO MAIL DE AVISO" data-content="<b>Habilitado:</b> si está chequeado se habilita el envío de mail (a nivel de Contrato).<br /><br /><b>Destinatario:</b> se elige uno de entre los “Destinatarios frecuentes” definidos a nivel de Persona (cliente).<br /><br /><b>Asunto:</b>  título del mail aviso.
        <br /><br /><b>Cuerpo:</b> cuerpo del mail de aviso.<br />Tanto el Asunto como el Cuerpo arrancan, como valores “default”, con el texto ingresado a nivel de Persona (cliente), pero permite hacer los ajustes específicos que exige el Contrato.<br />También se pueden incluir ciertas Palabras reservadas que serán reemplazadas por valores concretos correspondientes al comprobante que se está emitiendo (ver “Palabras reservadas del Cuerpo”)."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit"></span></a>
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
                <td>
                </td>
                <td align="left" style="padding-top: 5px";>
                    <div style="text-align: right">
                        Palabras reservadas del Cuerpo&nbsp;<a href="#" role="button" runat="server" class="" data-toggle="modal" data-target="#myModalLarge" id="AyudaGrilla" visible="true"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                    <div id="myModalLarge" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                        <div class="modal-dialog" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <h4 class="modal-title" id="H1">CUERPO DEL MAIL. USO DE PALABRAS RESERVADAS</h4>
                                </div>
                                <div class="modal-body">
                                    <h4>Se pueden utilzar las siguientes palabras reservadas:</h4>
                                        <ul>
                                            <li>@RAZONSOCIAL               Ej.: EMPRESA S.A</li>
                                            <li>@TIPOYNROCOMPROBANTE       Ej.: Factura A Nº 0041-00000055</li>
                                            <li>@MONEDAEIMPORTETOTAL       Ej.: $ 30.976,00</li>
                                            <li>@PERIODODELSERVICIO        Ej.: 01/04/2016 al 30/04/2016</li>
                                            <li>@MESDELSERVICIO            Ej.: Abril de 2016</li>
                                            <li>@FECHAVTO                  Ej.: 14/04/2016</li>
                                            <li>@TAB                       (Inserta una marca de tabulación para indentar el texto)</li>
                                        </ul>
                                        Estas palabras reservadas serán reemplazadas por los valores concretos que correspondan al comprobante que se está emitiendo.  La última es sólo un tabulador.
                                        <hr>
                                    <h4>Modelo de ejemplo para el cuerpo del mail:</h4>
                                        <p>
                                        Sres.<br />
                                        @RAZONSOCIAL<br />
                                        <br />
                                        At.  Juan Perez / Mariano Moreno<br />
                                        <br />
                                        Adjuntamos el comprobante cuyo detalle consignamos a continuación:<br />
                                        <br />
                                        @TAB@TIPOYNROCOMPROBANTE<br />
                                        @TABImporte: @MONEDAEIMPORTETOTAL<br />
                                        @TABCorrespondiente a: Abono mensual de mantenimiento de Facturación Electrónica versión Interfaz TXT.<br />
                                        @TABPeríodo del servicio: @PERIODODELSERVICIO (@MESDELSERVICIO)<br />
                                        @TABFecha de vencimiento: @FECHAVTO<br />
                                        <br />
                                        Puede ser abonada, por transferencia electrónica o depósito bancario, en la siguiente cuenta:<br />
                                        <br />
                                        @TABCta. Cte. Pesos Nº 2512-0 175-1 Banco Galicia (CBU 00701750-20000002512011)<br />
                                        @TABTitular: CEDEIRA SOFTWARE FACTORY S.R.L.<br />
                                        @TABCUIT: 30-71001506-2<br />
                                        <br />
                                        Una vez realizada la operación, agradeceremos que nos confirmen el pago por esta vía.<br />
                                        <br />
                                        Desde ya muchas gracias.<br />
                                        <br />
                                        DPTO DE ADMINISTRACIÓN.<br />
                                        </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                                </div>
                            </div><!-- /.modal-content -->
                        </div><!-- /.modal-dialog -->
                    </div><!
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
