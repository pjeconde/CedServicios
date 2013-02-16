<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioOlvidoPassword.aspx.cs" Inherits="CedServicios.Site.UsuarioOlvidoPassword" Theme="CedServicios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <!-- @@@ TITULO DE LA PAGINA @@@-->
        <tr>
            <td colspan="3" style="padding-top: 20px;">
                <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="¿ Olvidó la Contraseña de su cuenta ?"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3" align="left" style="padding-top: 20px;">
                <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Para establecer una nueva Contraseña para su cuenta eFact, siga las siguientes instrucciones:"></asp:Label>
            </td>
        </tr>
        <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
        <tr>
            <td colspan="3" style="padding-top: 10px" valign="middle" align="left">
                <asp:Label ID="Label9" runat="server" SkinID="TextoMediano" Text="1) Ingrese Id.Usuario e Email (luego haga clic en el botón 'Solicitar Pregunta de seguridad')."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top: 10px; padding-right: 5px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                    ErrorMessage="Id.Usuario" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                    <asp:Label ID="Label13" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="IdUsuarioTextBox"
                    ErrorMessage="Id.Usuario" SetFocusOnError="True">
                    <asp:Label ID="Label14" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="IdUsuarioLabel" runat="server" Text="Id.Usuario"></asp:Label>
            </td>
            <td  colspan="2" align="left" style="padding-top: 10px">
                <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 5px; padding-top: 10px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox"
                    ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                    <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="EmailTextBox"
                    ErrorMessage="Email" SetFocusOnError="True">
                    <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td colspan="2" align="left" style="padding-top: 10px">
                <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="2" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left" style="padding-top: 10px">
                <asp:Button ID="SolicitarPreguntaButton" runat="server" CausesValidation="false"
                    OnClick="SolicitarPreguntaButton_Click" TabIndex="3" Text="Solicitar Pregunta de seguridad"
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="padding-top: 10px">
                <asp:Label ID="Label10" runat="server" SkinID="TextoMediano" Text="2) Responda la Pregunta de Seguridad (luego haga clic en el botón 'Solicitar nuevo ingreso de Contraseña')."></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left" style="padding-top: 10px;">
                <asp:Label ID="PreguntaLabel" runat="server" Enabled="false" SkinID="TituloMediano"
                    Text="Pregunta de seguridad"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-top: 10px; padding-right: 5px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                    ErrorMessage="Respuesta" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                    <asp:Label ID="Label21" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="RespuestaTextBox"
                    ErrorMessage="Respuesta" SetFocusOnError="True">
                    <asp:Label ID="Label22" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="RespuestaLabel" runat="server" Text="Respuesta"></asp:Label>
            </td>
            <td colspan="2" align="left" style="padding-top: 10px">
                <asp:TextBox ID="RespuestaTextBox" runat="server" Enabled="false" MaxLength="256"
                    TabIndex="4" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left" style="padding-top: 10px">
                <asp:Button ID="SolicitarNuevaPasswordButton" runat="server" CausesValidation="false"
                    Enabled="false" OnClick="SolicitarNuevaPasswordButton_Click" TabIndex="5" Text="Solicitar nuevo ingreso de Contraseña"
                    Width="100%" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" style="padding-top: 10px">
                <asp:Label ID="Label11" runat="server" SkinID="TextoMediano" Text="3) Ingrese, y confirme, su nueva Contraseña (luego haga click en el botón 'Aceptar')."></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px; padding-top: 10px">
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
            <td colspan="2" align="left" style="padding-right: 10px; padding-top: 10px">
                <asp:TextBox ID="PasswordNuevaTextBox" runat="server" Enabled="false" OnTextChanged="TextBox_TextChanged"
                    TabIndex="6" TextMode="Password" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-right: 10px; padding-top: 10px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                    ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                    <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                    ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True">
                    <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                </asp:RequiredFieldValidator>
                <asp:Label ID="Label2" runat="server" Text="Confirmación"></asp:Label>
            </td>
            <td colspan="2" align="left" style="padding-right: 10px; padding-top: 10px">
                <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" Enabled="false"
                    OnTextChanged="TextBox_TextChanged" TabIndex="7" TextMode="Password" Width="120px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="padding-top: 10px; width: 160px">
                <asp:Button ID="AceptarButton" runat="server" Enabled="false" OnClick="AceptarButton_Click"
                    TabIndex="8" Text="Aceptar" />
            </td>
            <td align="right" style="padding-top: 10px; width: 200px">
                <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/UsuarioLogin.aspx"
                    TabIndex="9" Text="Cancelar" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center" style="padding-top: 10px;">
                <asp:Label ID="MsgErrorLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
            </td>
        </tr>
        <!-- @@@ @@@-->
    </table>
</asp:Content>
