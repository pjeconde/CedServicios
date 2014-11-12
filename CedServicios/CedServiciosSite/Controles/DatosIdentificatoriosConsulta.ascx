<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosIdentificatoriosConsulta.ascx.cs" Inherits="CedServicios.Site.Controles.DatosIdentificatoriosConsulta" %>

<!-- GLN -->
<tr>
	<td align="right" style="padding-right:5px; padding-top:5px">
		<asp:Label ID="Label7" runat="server" Text="GLN"></asp:Label>
	</td>
    <td align="left" style="padding-top:5px">
		<asp:TextBox ID="GLNTextBox" runat="server" MaxLength="13" TabIndex="19"
            ToolTip="(opcional) Código estándar para identificar locaciones o empresas (Global Location Number) del comprador o vendedor. Se utiliza para comercio internacional. Es un campo numérico de 13 caracteres."
			Width="100px"></asp:TextBox>
        <!-- CodigoInterno -->
        &nbsp;
		<asp:Label ID="Label21" runat="server" Text="Código interno"></asp:Label>
		<asp:TextBox ID="CodigoInternoTextBox" runat="server" MaxLength="20" TabIndex="20"
			ToolTip="(opcional) Código utilizado para identificar al vendedor dentro de la empresa / organización. (ej.: Código de Cliente, Proveedor, etc.)"
			Width="100px"></asp:TextBox>
    </td>									
</tr>
