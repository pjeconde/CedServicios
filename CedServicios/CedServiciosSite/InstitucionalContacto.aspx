<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="InstitucionalContacto.aspx.cs" Inherits="CedServicios.Site.InstitucionalContacto" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table style="padding-left:10px" >
        <tr>
            <td colspan="4" style="padding-top: 20px; text-align: center">
                <span class="glyphicon glyphicon-pencil gi-1-5x"></span>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Contacto"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4" style="padding-top:20px">
                <asp:Label ID="CorreoElectronicoLabel" runat="server" Text="Correo electrónico: "></asp:Label>
                <asp:HyperLink ID="eMailInfoHyperLink" runat="server" NavigateUrl='mailto:contacto@cedeira.com.ar'>contacto@cedeira.com.ar</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top: 10px">
                <asp:Label ID="FormularioElectronicoLabel" runat="server" Font-Bold="true" SkinID="TituloMediano" Text="Formulario electrónico:"></asp:Label>
            </td>
            <td align="right" style="padding-top: 10px; padding-right: 5px">
                <asp:Label ID="MotivoLabel" runat="server" Text="Motivo"></asp:Label>
            </td>
            <td align="left" colspan="2" style="padding-top: 10px">
                <asp:RadioButton ID="FactElectronicaRadioButton" runat="server" Checked="false" GroupName="Motivo" Text="Factura electrónica" />
                <asp:RadioButton ID="OtrosRadioButton" runat="server" Checked="true" GroupName="Motivo" Text="Otro" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right" style="width: 60px; padding-top: 3px; padding-right: 5px">
                <asp:Label ID="NombreLabel" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td align="left" colspan="2" style="padding-top: 3px">
                <asp:TextBox ID="NombreTextBox" runat="server" TabIndex="1" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right" style="padding-top: 3px; padding-right: 5px">
                <asp:Label ID="TelefonoLabel" runat="server" Text="Teléfono"></asp:Label>
            </td>
            <td align="left" colspan="2" style="padding-top: 3px">
                <asp:TextBox ID="TelefonoTextBox" runat="server" TabIndex="2" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right" style="padding-top: 3px; padding-right: 5px">
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            </td>
            <td align="left" colspan="2" style="padding-top: 3px">
                <asp:TextBox ID="EmailTextBox" runat="server" TabIndex="3" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top: 3px" valign="bottom">
                <asp:Image ID="CaptchaImage" runat="server" AlternateText="" Height="60px" Width="150px" />
            </td>
            <td align="right" style="padding-top: 3px; padding-right: 5px">
                <asp:Label ID="Label2" runat="server" Text="Mensaje"></asp:Label>
            </td>
            <td align="left" colspan="2" style="padding-top: 3px">
                <asp:TextBox ID="MensajeTextBox" runat="server" Height="100px" TabIndex="4" TextMode="MultiLine" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top: 3px" valign="top">
                <asp:Button ID="NuevaClaveCaptchaButton" runat="server" OnClick="NuevaClaveCaptchaButton_Click" Text="Nueva Clave" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            </td>
            <td align="right" style="padding-top: 3px; padding-right: 5px">
                <asp:Label ID="ClaveLabel" runat="server" Text="Clave"></asp:Label>
            </td>
            <td align="left" style="width: 80px; padding-top: 3px">
                <asp:TextBox ID="CaptchaTextBox" runat="server" TabIndex="5" Width="80px"></asp:TextBox>
            </td>
            <td align="left" style="padding-top: 3px; padding-left: 3px; width: 280px">
                <asp:Label ID="CaseSensitiveLabel" runat="server" ForeColor="gray" Text="(no se distinguen mayúsculas de minúsculas)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td align="left" style="padding-top: 10px">
                <asp:Button ID="EnviarButton" runat="server" OnClick="EnviarButton_Click" TabIndex="6" Text="Enviar" Width="80px" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            </td>
            <td align="right" style="padding-top: 10px; padding-right: 2px">
                <asp:Button ID="BorrarDatosButton" runat="server" OnClick="BorrarDatosButton_Click" Text="Borrar Datos" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="padding-bottom: 30px; padding-top: 20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
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
