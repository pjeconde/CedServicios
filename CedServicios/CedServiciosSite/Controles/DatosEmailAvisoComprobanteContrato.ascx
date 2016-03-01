<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosEmailAvisoComprobanteContrato.ascx.cs" Inherits="CedServicios.Site.Controles.DatosEmailAvisoComprobanteContrato" %>

<table style="width:1282px">
	<tr>
		<td style="height: 10px;">
		</td>
	</tr>
	<tr>
		<td colspan="2" class="TextoResaltado" style="text-align:center">
			DATOS EMAIL AVISO GENERACIÓN AUTOMÁTICA DE COMPROBANTE 
		</td>
	</tr>
	<tr>
		<td style="height: 10px;">
		</td>
	</tr>
    <tr>
        <td align="center">
        	<asp:UpdatePanel ID="DatosEmailAvisoComprobanteContratoUpdatePanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="CompradorDropDownList"></asp:AsyncPostBackTrigger>
				</Triggers>
				<ContentTemplate>
                    <table>
                        <tr>
                            <td align="right" style="padding-right:5px; padding-top:3px; width:100px">
                                <asp:Label ID="ActivoLabel" runat="server" Text="Habilitado"></asp:Label>
                            </td>
                            <td align="left" style="padding-top:3px">
                                <asp:CheckBox ID="ActivoCheckBox" runat="server" Checked="false" TabIndex="501" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                                <asp:Label ID="DeLabel" runat="server" Text="Destinatario"></asp:Label>
                            </td>
                            <td align="left" style="padding-top:3px">
			                    <asp:DropDownList ID="IdDestinatarioFrecuenteDropDownList" runat="server" TabIndex="502" Width="183px" DataValueField="Id" DataTextField="Id">
			                    </asp:DropDownList>
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
                                <asp:TextBox ID="CuerpoTextBox" runat="server" MaxLength="2048" TabIndex="504" Width="627px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
				</ContentTemplate>
			</asp:UpdatePanel>
        </td>
    </tr>
</table>
