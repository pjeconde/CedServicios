<%@ Page Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioCrear.aspx.cs" Inherits="CedServicios.Site.UsuarioCrear" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table align="center" style="height: 500px; width: 800px">
        <tr>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" class="TextoComun" style="width: 100%;">
                    <tr>
                        <td align="center" style="padding-left:10px; padding-top:20px" valign="top">
                            <asp:Label ID="Label5" runat="server" SkinID="TituloPagina" Text="Creación de cuenta"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 10px">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2" style="padding-left:32px; padding-top:20px">
                            <!-- @@@ OBJETOS ESPECIFICOS DE LA PAGINA @@@-->
                            <table id="Table1" border="0" cellpadding="0" cellspacing="0" width="600">
                                <tr>
                                    <td align="right" colspan="2" style="width: 300px; padding-right:5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="NombreTextBox"
                                            ErrorMessage="Nombre y Apellido" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label7" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NombreTextBox"
                                            ErrorMessage="Nombre y Apellido" SetFocusOnError="True">
                                            <asp:Label ID="Label8" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="NombreLabel" runat="server" Text="Nombre y Apellido"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:TextBox ID="NombreTextBox" runat="server" MaxLength="50" TabIndex="1" Width="360px"></asp:TextBox>
                                    </td>
                                    <td style="width: 200px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TelefonoTextBox"
                                            ErrorMessage="Teléfono" SetFocusOnError="True" ValidationExpression="[0-9\-]*">
                                            <asp:Label ID="Label9" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:Label ID="TelefonoLabel" runat="server" Text="Teléfono"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:TextBox ID="TelefonoTextBox" runat="server" MaxLength="50" TabIndex="2" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email" SetFocusOnError="True" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                            <asp:Label ID="Label11" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="EmailTextBox"
                                            ErrorMessage="Email" SetFocusOnError="True">
                                            <asp:Label ID="Label12" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:TextBox ID="EmailTextBox" runat="server" MaxLength="128" TabIndex="3" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td colspan="2" style="color: Gray">
                                        (muy importante: la confirmaciòn de la Cuenta se hace, vía mail, a esta dirección)
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
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
                                    <td align="left" style="padding-top:5px">
                                        <asp:TextBox ID="IdUsuarioTextBox" runat="server" MaxLength="50" TabIndex="4" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left" colspan="2" style="padding-left: 5px; padding-top:5px; width: 330px">
                                        <asp:Button ID="ComprobarDisponibilidadButton" runat="server" CausesValidation="false"
                                            OnClick="ComprobarDisponibilidadButton_Click" Text="¿Esta disponible?" ToolTip="Comprobar la disponibilidad del Id.Usuario ingresado"
                                            Width="120px" />
                                        <asp:Label ID="ResultadoComprobarDisponibilidadLabel" runat="server" Font-Bold="True"
                                            Font-Size="12px" Text="" Width="200px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="PasswordTextBox"
                                            ErrorMessage="Contraseña" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label15" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PasswordTextBox"
                                            ErrorMessage="Contraseña" SetFocusOnError="True">
                                            <asp:Label ID="Label16" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="PasswordLabel" runat="server" Text="Contraseña"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:5px">
                                        <asp:TextBox ID="PasswordTextBox" runat="server" MaxLength="50" TabIndex="5" TextMode="Password"
                                            Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left" rowspan="2" style="padding-left: 5px; padding-top:5px" valign="middle">
                                        <asp:Label ID="Label4" runat="server" ForeColor="Gray" Text="(si olvida su Contraseña, utilizaremos la Pregunta de seguridad)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="ConfirmacionPasswordTextBox"
                                            ErrorMessage="Confirmacion de Contraseña" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label17" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ConfirmacionPasswordTextBox"
                                            ErrorMessage="Confirmacion de Contraseña" SetFocusOnError="True">
                                            <asp:Label ID="Label18" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="ConfirmacionPasswordLabel" runat="server" Text="Confirmación de Contraseña"></asp:Label>
                                    </td>
                                    <td align="left" style="padding-top:5px">
                                        <asp:TextBox ID="ConfirmacionPasswordTextBox" runat="server" MaxLength="50" TabIndex="6"
                                            TextMode="Password" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="PreguntaTextBox"
                                            ErrorMessage="Pregunta de seguridad" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label19" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="PreguntaTextBox"
                                            ErrorMessage="Pregunta de seguridad" SetFocusOnError="True">
                                            <asp:Label ID="Label20" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="PreguntaLabel" runat="server" Text="Pregunta de seguridad"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="¿"></asp:Label>
                                        <asp:TextBox ID="PreguntaTextBox" runat="server" MaxLength="256" TabIndex="7" Width="334px"></asp:TextBox>
                                        <asp:Label ID="Label6" runat="server" Font-Bold="true" Text="?"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2" style="padding-top:5px; padding-right: 5px">
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
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:TextBox ID="RespuestaTextBox" runat="server" MaxLength="256" TabIndex="8" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top:5px; width: 150px" valign="bottom">
                                        <asp:Label ID="Label3" runat="server" Text="" Width="150px"></asp:Label>
                                        <asp:Image ID="CaptchaImage" runat="server" AlternateText="" Height="60px" Width="150px" />
                                    </td>
                                    <td align="right" style="padding-top:5px; padding-right: 5px">
                                        <asp:Label ID="CondicionesLabel" runat="server" Text="Términos y Condiciones del servicio"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" style="padding-top:5px">
                                        <asp:TextBox ID="CondicionesTextBox" runat="server" Font-Size="XX-Small" Height="100px"
                                            ReadOnly="true" TextMode="MultiLine" Width="360px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="padding-top:5px" valign="top">
                                        <asp:Button ID="NuevaClaveCaptchaButton" runat="server" CausesValidation="false"
                                            OnClick="NuevaClaveCaptchaButton_Click" Text="Nueva Clave" />
                                    </td>
                                    <td align="right" style="padding-top:5px; padding-right: 5px; width: 150px">
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="CaptchaTextBox"
                                            ErrorMessage="Clave" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                            <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="CaptchaTextBox"
                                            ErrorMessage="Clave" SetFocusOnError="True">
                                            <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                        </asp:RequiredFieldValidator>
                                        <asp:Label ID="ClaveLabel" runat="server" Text="Clave"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 80px; padding-top:5px">
                                        <asp:TextBox ID="CaptchaTextBox" runat="server" MaxLength="20" TabIndex="10" Width="100px"></asp:TextBox>
                                    </td>
                                    <td align="left" style="padding-top:5px; padding-left: 5px">
                                        <asp:Label ID="CaseSensitiveLabel" runat="server" ForeColor="gray" Text="(no se distinguen mayúsculas de minúsculas)"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="4" style="padding-top: 10px">
                                        <asp:Label ID="CrearCuentaLabel" runat="server" Text="Al hacer clic en el botón 'Crear cuenta', estará aceptando los Términos y Condiciones del servicio."></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td align="left" style="padding-top: 10px">
                                        <asp:Button ID="CrearCuentaButton" runat="server" OnClick="CrearCuentaButton_Click"
                                            TabIndex="10" Text="Crear cuenta" Width="100px" />
                                    </td>
                                    <td align="right" style="padding-top: 10px">
                                        <asp:Button ID="CancelarButton" runat="server" CausesValidation="false" PostBackUrl="~/UsuarioLogin.aspx"
                                            Text="Cancelar" Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                    </td>
                                    <td align="center" colspan="2" style="padding-bottom:30px; padding-top: 20px">
                                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                        <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                                    </td>
                                </tr>
                            </table>
                            <!-- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@-->
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 30px" valign="top">
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
</asp:Content>