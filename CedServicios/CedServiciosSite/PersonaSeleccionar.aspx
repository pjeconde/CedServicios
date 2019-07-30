<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="PersonaSeleccionar.aspx.cs" Inherits="CedServicios.Site.PersonaSeleccionar" Theme="CedServicios" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register TagPrefix="uc1" TagName="domicilio" Src="~/Controles/Domicilio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contacto" Src="~/Controles/Contacto.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivos" Src="~/Controles/DatosImpositivos.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatorios" Src="~/Controles/DatosIdentificatorios.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <style>
        label {font-weight: normal;}
    </style>
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="? de Persona"></asp:Label>
                        </h2>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <asp:Label ID="Label3" runat="server" Text="Persona(s) perteneciente(s) al CUIT"></asp:Label>
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-top-20">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label10" runat="server" Text="Ver:"></asp:Label>&nbsp;&nbsp;
                    <asp:RadioButton ID="ClienteRadioButton" Text="Clientes" GroupName="TipoPersona" runat="server" />&nbsp;
                    <asp:RadioButton ID="ProveedorRadioButton" Text="Proveedores" GroupName="TipoPersona" runat="server" />&nbsp;
                    <asp:RadioButton ID="AmbosRadioButton" Text="Ambos" GroupName="TipoPersona" Checked="true" runat="server" />&nbsp;
			    </div>
                <div class="col-lg-6 col-md-6 col-sm-6 padding-top-20">
                    <asp:RadioButton ID="TodosRadioButton" Text="Todos" GroupName="Filtro" runat="server" AutoPostBack="true" oncheckedchanged="FiltroButton_CheckedChanged" />
                    &nbsp;o&nbsp;&nbsp;<asp:RadioButton ID="FiltradosRadioButton" Text="Filtrados por:" GroupName="Filtro" Checked="true" runat="server" AutoPostBack="true" oncheckedchanged="FiltroButton_CheckedChanged" />
                </div>
	            <div class="col-lg-6 col-md-6 col-sm-6 text-left padding-top-20">
                    <asp:RadioButton ID="TipoDocRadioButton" runat="server" AutoPostBack="true" Text="Tipo y Nro. de Documento" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1" />
				    <asp:DropDownList ID="TipoDocDropDownList" runat="server" TabIndex="4" Width="216px" DataValueField="Codigo" DataTextField="Descr"></asp:DropDownList>
                    <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="5" ToolTip="Debe ingresar sólo números." Width="80px"></asp:TextBox>
	            </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 text-left">
                    <asp:RadioButton ID="RazonSocialRadioButton" runat="server" AutoPostBack="true" Text="Razón Social" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2" />
                    <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="6" Width="300px"></asp:TextBox>
                </div>
            </div>
			<div class="row">
                <div class="col-lg-6 col-md-6 col-sm-6">
                </div>
                <div class="col-lg-6 col-md-6 col-sm-6 text-left">
                    <asp:RadioButton ID="IdClienteRadioButton" runat="server" AutoPostBack="true" Text="Id.Persona" GroupName="TipoBusqueda" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="3"/>
                    <asp:TextBox ID="IdPersonaTextBox" runat="server" MaxLength="50" TabIndex="7" Width="300px"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:Panel ID="Panel2" runat="server" DefaultButton="BuscarButton" Width="100%">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                        <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 padding-top-20">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="ClientesGridView" runat="server" HorizontalAlign="Center" 
                            AutoGenerateColumns="false" onrowcommand="ClientesGridView_RowCommand" OnRowDataBound="ClientesGridView_RowDataBound" CssClass="grilla" GridLines="None" CaptionAlign="Bottom">
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
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
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
