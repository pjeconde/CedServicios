<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="UsuarioCambiarPassword.aspx.cs" Inherits="CedServicios.Site.UsuarioCambiarPassword" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Cambio de Contraseña de Usuario"></asp:Label>
                        </h2>
                        <asp:Label ID="Label8" runat="server" SkinID="TextoMediano" Text="Para realizar el cambio de la Contraseña de su cuenta eFact, ingrese los datos que se solicitan a continuación:"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="AceptarButton">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 text-center">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PasswordTextBox"
                                    ErrorMessage="Contraseña actual" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                    <asp:Label ID="Label23" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PasswordTextBox"
                                    ErrorMessage="Contraseña actual" SetFocusOnError="True">
                                    <asp:Label ID="Label24" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="PasswordTextBox" runat="server" OnTextChanged="TextBox_TextChanged" TabIndex="1" TextMode="Password" Width="200px" placeholder="Contraseña actual"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 text-center padding-top-20">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                                    ErrorMessage="Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                    <asp:Label ID="Label3" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordNuevaTextBox"
                                    ErrorMessage="Contraseña nueva" SetFocusOnError="True">
                                    <asp:Label ID="Label4" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="PasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged" TabIndex="2" TextMode="Password" Width="200px" placeholder="Contraseña nueva"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 text-center padding-top-20">
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                                    ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True" ValidationExpression="[A-Za-z\- ,.0-9]*">
                                    <asp:Label ID="Label5" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmacionPasswordNuevaTextBox"
                                    ErrorMessage="Confirmación de Contraseña nueva" SetFocusOnError="True">
                                    <asp:Label ID="Label6" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                                </asp:RequiredFieldValidator>
                                <asp:TextBox ID="ConfirmacionPasswordNuevaTextBox" runat="server" OnTextChanged="TextBox_TextChanged" TabIndex="3" TextMode="Password" Width="200px" placeholder="Confirmación de Contraseña nueva"></asp:TextBox>
                            </div>
                        </div>                        
                        <div class="row">
                            <div class="col-lg-12 col-md-12 text-center">
                                <asp:Button ID="AceptarButton" runat="server" class="btn btn-default btn-sm" OnClick="AceptarButton_Click" TabIndex="4"
                                    Text="Aceptar" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                                <asp:Button ID="CancelarButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" onclick="SalirButton_Click" TabIndex="5" Text="Cancelar" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 text-center padding-top-20">                                    
                                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary" />
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </section>

    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
