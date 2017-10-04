<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosImpositivos.ascx.cs" Inherits="CedServicios.Site.Controles.DatosImpositivos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!-- CondIVA -->
<tr>
	<td style="padding-right:5px; padding-right: 5px; padding-top:5px; text-align:right">
		<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CondIVADropDownList" ErrorMessage="Cond.IVA" SetFocusOnError="True" InitialValue="0">
			<asp:Label ID="Label28" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		</asp:RequiredFieldValidator>
		<asp:Label ID="Label11" runat="server" Text="Cond.IVA"></asp:Label>
	</td>
	<td style="padding-top:5px; text-align:left">
		<asp:DropDownList ID="CondIVADropDownList" runat="server" TabIndex="301" Width="255px" DataValueField="Codigo" DataTextField="Descr">
		</asp:DropDownList>
	</td>
</tr>
<!-- NroIngBrutos y CondIngBrutos -->
<tr>
	<td style="padding-left: 10px; padding-right: 5px; padding-top:5px; text-align:right">
		<asp:Label ID="Label18" runat="server" Text="Cond.Ing.Brutos"></asp:Label>
	</td>
	<td style="padding-top:5px; text-align:left">
		<table>
			<tr>
				<td style="text-align: left">
					<asp:DropDownList ID="CondIngBrutosDropDownList" runat="server" TabIndex="302" Width="183px" DataValueField="Codigo" DataTextField="Descr">
					</asp:DropDownList>
				</td>
	            <td style="padding-left: 15px; padding-right: 5px; text-align: right">
		            <asp:Label ID="Label20" runat="server" Text="Nro.Ing.Brutos"></asp:Label>
	            </td>
				<td>
					<asp:TextBox ID="NroIngBrutosTextBox" runat="server" MaxLength="13" TabIndex="303"
						ToolTip="Para convenio multilateral deberá ingresar el CUIT" Width="90px"></asp:TextBox>&nbsp;<a href="#" role="button" class="popover-test" data-html="true" title="NRO. DE INGRESOS BRUTOS" data-content="Fórmatos válidos son:<br />XXXXXXX-XX<br />XX-XXXXXXXX-X<br />XXX-XXXXXX-X<br />Donde X puede ser un número de 0 a 9<br /><br />Si es CONVENIO MULTILATERAL debe informar el CUIT sin guiones.<br />XXXXXXXXXXX<br /><br />(Seg. COMISIÓN ARBITRAL CONVENIO Resolución General 3/2015 del 15/07/2015 )<br /><br />"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align: inherit"></span></a>
				</td>
			</tr>
		</table>
	</td>
</tr>
<!-- FechaInicioActividades  -->
<tr>
	<td style="padding-left: 10px; padding-right: 5px; padding-top:5px; text-align:right">
		<asp:RequiredFieldValidator ID="FechaInicioActividadesRequiredFieldValidator" runat="server"
			ControlToValidate="FechaInicioActividadesTextBox" ErrorMessage="Fecha de inicio de actividades"
			SetFocusOnError="True">* </asp:RequiredFieldValidator>
        <asp:Label ID="Label22" runat="server" Text="Fecha de inicio de actividades"></asp:Label>
	</td>
	<td style="padding-top:5px; text-align:left">
        <asp:TextBox ID="FechaInicioActividadesTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha de incio de actividades de la empresa, en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="70px" TabIndex="304"></asp:TextBox>
        <cc1:CalendarExtender ID="FechaInicioActividadesCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
            TargetControlID="FechaInicioActividadesTextBox" Format="yyyyMMdd" PopupButtonID="FechaInicioActividadesImage" >
        </cc1:CalendarExtender>
        <asp:ImageButton runat="server" CausesValidation="false" ID="FechaInicioActividadesImage" ImageUrl="~/Imagenes/Calendar.gif" />
    </td>
</tr>

