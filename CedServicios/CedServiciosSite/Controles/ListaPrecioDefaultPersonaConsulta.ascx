<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListaPrecioDefaultPersonaConsulta.ascx.cs" Inherits="CedServicios.Site.Controles.ListaPrecioDefaultPersonaConsulta" %>

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
            <table>
                <tr>
                    <td align="right" style="padding-right:5px; padding-top:3px; width:100px">
                        <asp:Label ID="ActivoLabel" runat="server" Text="Habilitado"></asp:Label>
                    </td>
                    <td align="left" style="padding-top:3px">
                        <asp:CheckBox ID="ActivoCheckBox" runat="server" Checked="false" Enabled="false" TabIndex="501" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                        <asp:Label ID="DeLabel" runat="server" Text="Destinatario"></asp:Label>
                    </td>
                    <td align="left" style="padding-top:3px">
                        <asp:TextBox ID="IdDestinatarioFrecuenteTextBox" runat="server" Enabled="false" MaxLength="256" TabIndex="502" Width="627px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                        <asp:Label ID="AsuntoLabel" runat="server" Text="Asunto"></asp:Label>
                    </td>
                    <td align="left" style="padding-top:3px">
                        <asp:TextBox ID="AsuntoTextBox" runat="server" Enabled="false" MaxLength="256" TabIndex="503" Width="627px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding-left:5px; padding-right:5px; padding-top:3px">
                        <asp:Label ID="CuerpoLabel" runat="server" Text="Cuerpo"></asp:Label>
                    </td>
                    <td align="left" style="padding-top:3px">
                        <asp:TextBox ID="CuerpoTextBox" runat="server" Enabled="false" MaxLength="2048" TabIndex="504" Width="627px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
