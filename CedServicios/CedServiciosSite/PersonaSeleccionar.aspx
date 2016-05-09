<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PersonaSeleccionar.aspx.cs" Inherits="CedServicios.Site.PersonaSeleccionar" Theme="CedServicios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="domicilio" Src="~/Controles/Domicilio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contacto" Src="~/Controles/Contacto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivos" Src="~/Controles/DatosImpositivos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatorios" Src="~/Controles/DatosIdentificatorios.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
        <table style="padding-left:10px; text-align:center; width:100%;">
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="? de Persona"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top: 20px">
                    <asp:Label ID="Label3" runat="server" Text="Persona(s) perteneciente(s) al CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" Text="Tipo de Persona:"></asp:Label>
                    <asp:RadioButton ID="ClienteRadioButton" Text="Cliente" GroupName="TipoPersona" runat="server" />
                    <asp:RadioButton ID="ProveedorRadioButton" Text="Proveedor" GroupName="TipoPersona" runat="server" />
                    <asp:RadioButton ID="AmbosRadioButton" Text="Ambos" GroupName="TipoPersona" Checked="true" runat="server" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:20px">
                    <asp:RadioButton ID="TipoDocRadioButton" runat="server" AutoPostBack="true" Text="Tipo y Nro. de Documento" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1" />
	            </td>
			    <td align="left" style="padding-top:20px">
				    <asp:DropDownList ID="TipoDocDropDownList" runat="server" TabIndex="4" Width="216px" DataValueField="Codigo" DataTextField="Descr"></asp:DropDownList>
                    <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="5" ToolTip="Debe ingresar sólo números." Width="80px"></asp:TextBox>
			    </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:5px">
                    <asp:RadioButton ID="RazonSocialRadioButton" runat="server" AutoPostBack="true" Text="Razón Social" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2" />
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px"></asp:TextBox>
                </td>        
                <td>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:5px">
                    <asp:RadioButton ID="IdClienteRadioButton" runat="server" AutoPostBack="true" Text="Id.Persona" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="3"/>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="IdPersonaTextBox" runat="server" MaxLength="50" TabIndex="7" Width="300px"></asp:TextBox>
                </td>        
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="height: 24px; padding-top:20px">
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="BuscarButton" Width="100%">
                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                    </asp:Panel>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="padding-top:20px;" colspan="3">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="ClientesGridView" runat="server" 
                            AutoGenerateColumns="false" onrowcommand="ClientesGridView_RowCommand" OnRowDataBound="ClientesGridView_RowDataBound" CssClass="grilla" GridLines="None">
                            <Columns>
                                <asp:ButtonField HeaderText="Persona" Text="Seleccionar" CommandName="Seleccionar" ButtonType="Link" ItemStyle-ForeColor="Blue" ItemStyle-Width="90px">
                                </asp:ButtonField>
                                <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" Visible="false">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DocumentoTipoDescr" HeaderText="Tipo Doc." SortExpression="DocumentoTipoDescr">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DocumentoNro" HeaderText="Nro.Doc." SortExpression="DocumentoNro">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdPersona" HeaderText="Id.Persona" SortExpression="IdPersona">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DesambiguacionCuitPais" HeaderText="IdClienteExt" SortExpression="DesambiguacionCuitPais">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescrTipoPersona" HeaderText="Tipo de Persona" SortExpression="DescrTipoPersona" >
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3" style="padding-top:20px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
                </td>
            </tr>
        </table>
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
