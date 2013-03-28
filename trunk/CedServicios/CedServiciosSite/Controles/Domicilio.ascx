<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Domicilio.ascx.cs" Inherits="CedServicios.Site.Controles.Domicilio" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!-- Calle, Nro, Piso y Depto -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top:5px">
		<cc1:FilteredTextBoxExtender ID="CalleFilteredTextBoxExtender" runat="server"  FilterType="Custom" InvalidChars="'" FilterMode="InvalidChars" TargetControlID="CalleTextBox">
		</cc1:FilteredTextBoxExtender>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CalleTextBox"
			ErrorMessage="Calle" SetFocusOnError="True">
			<asp:Label ID="Label26" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RequiredFieldValidator>
		<asp:Label ID="Label3" runat="server" Text="Calle"></asp:Label>
	</td>
	<td style="padding-top:5px">
		<table border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td align="left">
					<asp:TextBox ID="CalleTextBox" runat="server" MaxLength="30" TabIndex="2" Width="150px"></asp:TextBox>
				</td>
				<td align="right" style="padding-left: 5px;">
					<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="NroTextBox"
						ErrorMessage="Nro" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
						<asp:Label ID="Label27" runat="server" SkinID="IndicadorValidacion"></asp:Label>
					</asp:RegularExpressionValidator>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="NroTextBox"
						ErrorMessage="Nro" SetFocusOnError="True">
						<asp:Label ID="Label28" runat="server" SkinID="IndicadorValidacion"></asp:Label>
					</asp:RequiredFieldValidator>
					<asp:Label ID="Label12" runat="server" Text="Nro"></asp:Label>
				</td>
				<td align="left" style="padding-left: 5px;">
					<asp:TextBox ID="NroTextBox" runat="server" MaxLength="6" TabIndex="3" Width="40px"></asp:TextBox>
				</td>
				<td align="right" style="padding-left: 5px">
					<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="PisoTextBox"
						ErrorMessage="Piso" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
						<asp:Label ID="Label29" runat="server" SkinID="IndicadorValidacion"></asp:Label>
					</asp:RegularExpressionValidator>
					<asp:Label ID="Label13" runat="server" Text="Piso"></asp:Label>
				</td>
				<td align="left" style="padding-left: 5px">
					<asp:TextBox ID="PisoTextBox" runat="server" MaxLength="5" TabIndex="4" Width="25px"></asp:TextBox>
				</td>
				<td align="right" style="padding-left: 5px">
					<asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="DeptoTextBox"
						ErrorMessage="Depto" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
						<asp:Label ID="Label31" runat="server" SkinID="IndicadorValidacion"></asp:Label>
					</asp:RegularExpressionValidator>
					<asp:Label ID="Label14" runat="server" Text="Depto"></asp:Label>
				</td>
				<td align="left" style="padding-left: 5px">
					<asp:TextBox ID="DeptoTextBox" runat="server" MaxLength="5" TabIndex="5" Width="25px"></asp:TextBox>
				</td>
			</tr>
		</table>
	</td>
</tr>
<!-- Sector, Torre y Manzana -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top:5px">
		<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="SectorTextBox"
			ErrorMessage="Sector" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
			<asp:Label ID="Label32" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RegularExpressionValidator>
		<asp:Label ID="Label15" runat="server" Text="Sector"></asp:Label>
	</td>
	<td align="left" style="padding-top:5px">
		<table border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td>
					<asp:TextBox ID="SectorTextBox" runat="server" MaxLength="5" TabIndex="6" Width="120px"></asp:TextBox>
				</td>
				<td align="right" style="width: 40px">
					<asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TorreTextBox"
						ErrorMessage="Torre" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
						<asp:Label ID="Label33" runat="server" SkinID="IndicadorValidacion"></asp:Label>
					</asp:RegularExpressionValidator>
					<asp:Label ID="Label16" runat="server" Text="Torre"></asp:Label>
				</td>
				<td style="padding-left: 5px">
					<asp:TextBox ID="TorreTextBox" runat="server" MaxLength="5" TabIndex="7" Width="55px"></asp:TextBox>
				</td>
				<td align="right" style="width:70px">
					<asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="ManzanaTextBox"
						ErrorMessage="Manzana" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
						<asp:Label ID="Label34" runat="server" SkinID="IndicadorValidacion"></asp:Label>
					</asp:RegularExpressionValidator>
					<asp:Label ID="Label17" runat="server" Text="Manzana"></asp:Label>
				</td>
				<td style="padding-left: 5px">
					<asp:TextBox ID="ManzanaTextBox" runat="server" MaxLength="5" TabIndex="8" Width="67px"></asp:TextBox>
				</td>
			</tr>
		</table>
	</td>
</tr>
<!-- Localidad -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top:5px">
		<asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="LocalidadTextBox"
			ErrorMessage="Localidad" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
			<asp:Label ID="Label35" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="LocalidadTextBox"
			ErrorMessage="Localidad" SetFocusOnError="True">
			<asp:Label ID="Label36" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RequiredFieldValidator>
		<asp:Label ID="Label4" runat="server" Text="Localidad"></asp:Label>
	</td>
	<td align="left" style="padding-top:5px">
		<asp:TextBox ID="LocalidadTextBox" runat="server" MaxLength="25" TabIndex="9" Width="400px"></asp:TextBox>
	</td>
</tr>
<!-- Provincia y Código postal -->
<tr>
	<td align="right" style="padding-right: 5px; padding-top:5px; height: 25px;">
		<asp:Label ID="Label5" runat="server" Text="Provincia"></asp:Label>
	</td>
	<td align="left" style="height: 25px; padding-top:5px">
		<table border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td>
					<asp:DropDownList ID="ProvinciaDropDownList" runat="server" TabIndex="10" Width="183px" DataValueField="Codigo" DataTextField="Descr">
					</asp:DropDownList>
				</td>
				<td align="right" style="padding-left: 14px; padding-right: 5px">
					<asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
						ControlToValidate="CodPostTextBox" ErrorMessage="Codigo Postal" SetFocusOnError="True"
						ValidationExpression="[A-Za-z\- ,.0-9]*">
						<asp:Label ID="Label37" runat="server" SkinID="IndicadorValidacion"></asp:Label>
					</asp:RegularExpressionValidator>
					<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="CodPostTextBox"
						ErrorMessage="Codigo Postal" SetFocusOnError="True">
						<asp:Label ID="Label38" runat="server" SkinID="IndicadorValidacion"></asp:Label>
					</asp:RequiredFieldValidator>
					<asp:Label ID="Label6" runat="server" Text="Código Postal"></asp:Label>
				</td>
				<td align="left">
					<asp:TextBox ID="CodPostTextBox" runat="server" MaxLength="8" TabIndex="11" Width="80px"></asp:TextBox>
				</td>
			</tr>
		</table>
	</td>
</tr>