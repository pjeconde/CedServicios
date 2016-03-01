<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ArticuloBaja.aspx.cs" Inherits="CedServicios.Site.ArticuloBaja" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table style="padding-left:10px">
        <tr>
            <td align="center" colspan="2" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Baja/Anul.baja de Artículo"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-right:5px; padding-top: 20px; text-align: right">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                    ControlToValidate="CUITTextBox" ErrorMessage="CUIT" SetFocusOnError="True" ValidationExpression="[0-9]{11}">
                    <asp:Label ID="Label1" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CUITTextBox"
                    ErrorMessage="CUIT" SetFocusOnError="True">
                    <asp:Label ID="Label2" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label3" runat="server" Text="Artículo perteneciente al CUIT"></asp:Label>
            </td>
            <td style="padding-top:20px; text-align: left">
                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="padding-right:5px; padding-top:5px; text-align: right">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="IdTextBox"
                    ErrorMessage="Id" SetFocusOnError="True">
                    <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label9" runat="server" Text="Id."></asp:Label>
            </td>
            <td style="padding-top:5px; text-align: left">
                <asp:TextBox ID="IdTextBox" runat="server" MaxLength="20" TabIndex="2" Width="100px"></asp:TextBox>
            </td>        
        </tr>
        <tr>
            <td colspan="2" style="padding-top:5px">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height:1px; background-color:#cccccc">
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:5px">
            </td>
        </tr>
        <tr>
            <td style="padding-right:5px; padding-top:2px; text-align: right">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DescrTextBox"
                    ErrorMessage="Descripción" SetFocusOnError="True">
                    <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
            </td>
            <td style="padding-top:2px; text-align: left">
                <asp:TextBox ID="DescrTextBox" runat="server" MaxLength="100" TabIndex="3" Width="300px" TextMode="MultiLine"></asp:TextBox>
            </td>        
        </tr>
        <tr>
	        <td style="padding-right:5px; padding-top:5px; text-align: right">
		        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
			        ControlToValidate="GTINTextBox" ErrorMessage="GTIN" SetFocusOnError="True" ValidationExpression="[0-9]{20}">
			        <asp:Label ID="Label49" runat="server" SkinID="IndicadorValidacion"></asp:Label>
		        </asp:RegularExpressionValidator>
		        <asp:Label ID="Label11" runat="server" Text="GTIN"></asp:Label>
	        </td>
            <td style="padding-top:5px; text-align: left">
		        <asp:TextBox ID="GTINTextBox" runat="server" MaxLength="20" TabIndex="4"
                    ToolTip="(opcional) Código estándar GSI global de identificación de productos. Se utiliza para comercio internacional. Es un campo numérico de 20 caracteres."
			        Width="150px"></asp:TextBox>
            </td>									
        </tr>
        <tr>
	        <td style="padding-right:5px; padding-top:5px; text-align: right">
		        <asp:Label ID="Label18" runat="server" Text="Unidad de medida"></asp:Label>
	        </td>
			<td style="padding-top:5px;; text-align: left">
				<asp:DropDownList ID="UnidadDropDownList" runat="server" TabIndex="5" 
                    Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			</td>
        </tr>
        <tr>
	        <td style="padding-right:5px; padding-top:5px; text-align: right">
		        <asp:Label ID="Label4" runat="server" Text="Indicacion Exento/Gravado"></asp:Label>
	        </td>
			<td style="padding-top:5px; text-align: left">
				<asp:DropDownList ID="IndicacionExentoGravadoDropDownList" runat="server" TabIndex="6" 
                    Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			</td>
        </tr>
        <tr>
	        <td style="padding-right:5px; padding-top:5px; text-align: right">
		        <asp:Label ID="Label5" runat="server" Text="Alícuota I.V.A."></asp:Label>
	        </td>
			<td style="padding-top:5px; text-align: left">
				<asp:DropDownList ID="AlicuotaIVADropDownList" runat="server" TabIndex="7" 
                    Width="300px" DataValueField="Codigo" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
			</td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="height: 24px; padding-top:20px; text-align: left">
                <asp:Button ID="AceptarButton" runat="server" TabIndex="504" Text="Aceptar" onclick="AceptarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="505" Text="Cancelar" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2" style="padding-top:20px; text-align: center">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
