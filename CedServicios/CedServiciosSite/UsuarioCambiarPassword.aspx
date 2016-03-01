<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioCambiarPassword.aspx.cs" Inherits="CedServicios.Site.UsuarioCambiarPassword" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="AceptarButton">
        <table align="center" class="TextoComun">
            <tr>
                <td colspan="2" style="padding-top:20px; text-align: center">
                    <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Cambio de Contraseña de Usuario"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-top:20px; text-align: center">
                    <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Para realizar el cambio de la Contraseña de su cuenta eFact, ingrese los datos que se solicitan a continuación:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top:10px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PasswordTextBox"
                        ErrorMessage="Contraseña actual" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PasswordTextBox"
                        ErrorMessage="Contraseña actual" SetFocusOnError="True">
                        <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label15" runat="server" Text="Contraseña actual"></asp:Label>
                </td>
                <td align="left" style="padding-top:10px">
                    <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                        TabIndex="1" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top: 5px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                        ErrorMessage="Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                        ErrorMessage="Contraseña nueva" SetFocusOnError="True">
                        <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label1" runat="server" Text="Contraseña nueva"></asp:Label>
                </td>
                <td align="left" style="padding-right: 10px; padding-top: 5px">
                    <asp:TextBox ID="PasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                        TabIndex="2" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 10px; padding-top: 5px">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                        ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                        <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                        ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True">
                        <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                    </asp:RequiredFieldValidator>
                    <asp:Label ID="Label2" runat="server" Text="Confirmación de Contraseña nueva"></asp:Label>
                </td>
                <td align="left" style="padding-right:10px; padding-top: 5px">
                    <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged"
                        TabIndex="3" TextMode="Password" Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="AceptarButton" runat="server" OnClick="AceptarButton_Click" TabIndex="4"
                        Text="Aceptar" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" onclick="SalirButton_Click" TabIndex="5" Text="Cancelar" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="padding-top:20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
    </div>
    </div>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
