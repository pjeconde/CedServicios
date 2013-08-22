<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosImpositivos.ascx.cs" Inherits="CedServicios.Site.Controles.DatosImpositivos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!-- CondIVA -->
<tr>
	<td align="right" style="padding-right:5px; padding-right: 5px; padding-top:5px">
		<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CondIVADropDownList" ErrorMessage="Cond.IVA" SetFocusOnError="True" InitialValue="0">
			<asp:Label ID="Label28" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RequiredFieldValidator>
		<asp:Label ID="Label11" runat="server" Text="Cond.IVA"></asp:Label>
	</td>
	<td align="left" style="padding-top:5px">
		<asp:DropDownList ID="CondIVADropDownList" runat="server" TabIndex="301" Width="255px" DataValueField="Codigo" DataTextField="Descr">
		</asp:DropDownList>
	</td>
</tr>
<!-- NroIngBrutos y CondIngBrutos -->
<tr>
	<td align="right" style="padding-left: 10px; padding-right: 5px; padding-top:5px">
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CondIngBrutosDropDownList" ErrorMessage="Cond.Ing.Brutos" SetFocusOnError="True" InitialValue="0">
			<asp:Label ID="Label1" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RequiredFieldValidator>
		<asp:Label ID="Label18" runat="server" Text="Cond.Ing.Brutos"></asp:Label>
	</td>
	<td align="left" style="padding-top:5px">
		<table border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td align="left">
					<asp:DropDownList ID="CondIngBrutosDropDownList" runat="server" TabIndex="302" Width="216px" DataValueField="Codigo" DataTextField="Descr">
					</asp:DropDownList>
				</td>
	            <td align="right" style="padding-left:5px; padding-right:5px;">
		            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
			            ControlToValidate="NroIngBrutosTextBox" ErrorMessage="Nro.Ing.Brutos" SetFocusOnError="True"
			            ValidationExpression="[0-9]{7}-[0-9]{2}|[0-9]{2}-[0-9]{8}-[0-9]{1}|[0-9]{3}-[0-9]{6}-[0-9]{1}">
			            <asp:Label ID="Label47" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		            </asp:RegularExpressionValidator>
		            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="NroIngBrutosTextBox"
			            ErrorMessage="Nro.Ing.Brutos" SetFocusOnError="True">
			            <asp:Label ID="Label48" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		            </asp:RequiredFieldValidator>
		            <asp:Label ID="Label20" runat="server" Text="Nro.Ing.Brutos"></asp:Label>
	            </td>
				<td>
					<asp:TextBox ID="NroIngBrutosTextBox" runat="server" MaxLength="13" TabIndex="303"
						ToolTip="Ingresar con el siguiente formato: 9999999-99" Width="80px"></asp:TextBox>
				</td>
			</tr>
		</table>
	</td>
</tr>
<!-- FechaInicioActividades  -->
<tr>
	<td align="right" style="padding-left: 10px; padding-right: 5px; padding-top:5px">
		<asp:RequiredFieldValidator ID="FechaInicioActividadesRequiredFieldValidator" runat="server"
			ControlToValidate="FechaInicioActividadesTextBox" ErrorMessage="Fecha de inicio de actividades"
			SetFocusOnError="True">* </asp:RequiredFieldValidator>
        <asp:Label ID="Label22" runat="server" Text="Fecha de inicio de actividades"></asp:Label>
	</td>
	<td align="left" style="padding-top:5px">
        <asp:TextBox ID="FechaInicioActividadesTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="70px" TabIndex="304"></asp:TextBox>
        <cc1:CalendarExtender ID="FechaInicioActividadesCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
            TargetControlID="FechaInicioActividadesTextBox" Format="yyyyMMdd" PopupButtonID="FechaInicioActividadesImage" >
        </cc1:CalendarExtender>
        <asp:ImageButton runat="server" CausesValidation="false" ID="FechaInicioActividadesImage" ImageUrl="~/Imagenes/Calendar.gif" />
    </td>
</tr>

