<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ArticuloSeleccionar.aspx.cs" Inherits="CedServicios.Site.ArticuloSeleccionar" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <style>
        label {font-weight: normal;}
    </style>
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="? de Artículo"></asp:Label>
                        </h2>
                    </div>
                </div>
            </div>
            <asp:Panel ID="Panel2" runat="server" DefaultButton="BuscarButton">
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <asp:Label ID="Label3" runat="server" Text="Articulo(s) perteneciente(s) al CUIT"></asp:Label>
                    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                </div>        
            </div>
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4 padding-top-20">
			        <asp:Label ID="Label10" runat="server" Text="Ver artículos"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="TodosRadioButton" Text="Todos" GroupName="Filtro" runat="server" AutoPostBack="true" CssClass="RBespacios" oncheckedchanged="FiltroButton_CheckedChanged" />&nbsp;o&nbsp;
                    <asp:RadioButton ID="FiltradosRadioButton" Text="Filtrados por:" GroupName="Filtro" Checked="true" runat="server" AutoPostBack="true" CssClass="RBespacios" oncheckedchanged="FiltroButton_CheckedChanged" />
	            </div>
                <div class="col-lg-8 col-md-8 col-sm-8 padding-top-20" style="text-align: left">
                    <asp:RadioButton ID="IdRadioButton" runat="server" AutoPostBack="true" Text="Id." GroupName="TipoBusqueda" CssClass="RBespacios" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="1" />
                    <asp:TextBox ID="IdTextBox" runat="server" MaxLength="50" TabIndex="6" Width="50%"></asp:TextBox>
                </div>
            </div> 
            <div class="row">
                <div class="col-lg-4 col-md-4 col-sm-4">
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8" style="text-align: left">
                    <asp:RadioButton ID="DescrRadioButton" runat="server" AutoPostBack="true" Text="Descripción" GroupName="TipoBusqueda" CssClass="RBespacios" oncheckedchanged="TipoBusquedaRadioButton_CheckedChanged" TabIndex="2" />
                    <asp:TextBox ID="DescrTextBox" runat="server" MaxLength="50" TabIndex="6" Width="50%"></asp:TextBox>
                </div>
           </div>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <asp:Button ID="BuscarButton" runat="server" TabIndex="8" class="btn btn-default btn-sm" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" TabIndex="9" CausesValidation="false" class="btn btn-default btn-sm" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
            </div>  
            </asp:Panel>
            <div class="row">
                <div class="col-lg-12 col-md-12">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                        <asp:GridView ID="ArticulosGridView" runat="server"
                            AutoGenerateColumns="false" onrowcommand="ArticulosGridView_RowCommand" OnRowDataBound="ArticulosGridView_RowDataBound" CssClass="grilla" GridLines="None" CaptionAlign="Bottom">
                            <Columns>
                                <asp:ButtonField HeaderText="Artículo" Text="Seleccionar" CommandName="Seleccionar" ButtonType="Link" ItemStyle-ForeColor="Blue" ItemStyle-Width="90px">
                                </asp:ButtonField>
                                <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" Visible="false">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descr" HeaderText="descripción" SortExpression="Descr">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnidadDescr" HeaderText="Unidad de medida" SortExpression="UnidadDescr">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IndicacionExentoGravado" HeaderText="Exento/Gravado/No gravado" SortExpression="IndicacionExentoGravado">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AlicuotaIVA" HeaderText="Alicuota IVA (%)" SortExpression="AlicuotaIVA">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
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
