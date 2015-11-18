<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosIdentificatorios.ascx.cs" Inherits="CedServicios.Site.Controles.DatosIdentificatorios" %>

<!-- GLN y CodigoInterno -->
<tr>
	<td style="padding-right:5px; padding-top:5px; text-align: right">
		<asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
			ControlToValidate="GLNTextBox" ErrorMessage="GLN" SetFocusOnError="True" ValidationExpression="[0-9]{13}">
			<asp:Label ID="Label49" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RegularExpressionValidator>
		<asp:Label ID="Label7" runat="server" Text="GLN"></asp:Label>
	</td>
    <td style="padding-top:5px; text-align: left">
		<table>
			<tr>
				<td align="left">
        	        <asp:TextBox ID="GLNTextBox" runat="server" MaxLength="13" TabIndex="401"
                    ToolTip="Código estándar para identificar locaciones o empresas (Global Location Number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres. (opcional)"
			        Width="100px"></asp:TextBox>
				</td>
	            <td align="right" style="padding-left:5px; padding-right:5px;">
		            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
			            ControlToValidate="CodigoInternoTextBox" ErrorMessage="Codigo interno" SetFocusOnError="True"
			            ValidationExpression="[A-Za-z\- ,.0-9]*">
			            <asp:Label ID="Label52" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		            </asp:RegularExpressionValidator>
		            <asp:Label ID="Label21" runat="server" Text="Código interno"></asp:Label>
	            </td>
				<td>
		            <asp:TextBox ID="CodigoInternoTextBox" runat="server" MaxLength="20" TabIndex="402"
			            ToolTip="Código utilizado para identificar a la persona dentro de la empresa / organización. Ejemplo: Código de Cliente, Proveedor, etc. (opcional)"
			            Width="100px"></asp:TextBox>
				</td>
			</tr>
		</table>
    </td>									
</tr>
