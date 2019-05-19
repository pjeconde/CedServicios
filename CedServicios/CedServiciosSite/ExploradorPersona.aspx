<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorPersona.aspx.cs" Inherits="CedServicios.Site.ExploradorPersona" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title">
                        <div class="head_title text-center">
                            <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de Personas"></asp:Label>
                            </h2>
                            <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20">
                    <asp:TextBox ID="RazSocTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="100%" placeholder="Razon Social"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 padding-top-20">
				    <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" Width="100%" placeholder="CUIT Vendedor"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-md-6 padding-top-20">
                    <asp:TextBox ID="NroDocTextBox" runat="server" MaxLength="11" TabIndex="2" ToolTip="" Width="100%" placeholder="Nro. Doc"></asp:TextBox>
                </div>
                <div class="col-lg-6 col-md-6 text-left padding-top-20">
                    Estado:<asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="3" Width="200px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" ></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center" >
                    <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-center padding-top-20" >
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="None"
                        BorderWidth="1px" ScrollBars="Auto" BackColor="White">
                        <cc1:PagingGridView ID="ClientePagingGridView" runat="server" OnPageIndexChanging="ClientePagingGridView_PageIndexChanging"
                            OnRowDataBound="ClientePagingGridView_RowDataBound" HorizontalAlign="Center" 
                            FooterStyle-ForeColor="Brown" OnRowEditing="ClientePagingGridView_RowEditing" OnRowCancelingEdit="ClientePagingGridView_RowCancelingEdit"
                            OnRowUpdating="ClientePagingGridView_RowUpdating" 
                            OnSorting="ClientePagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" CssClass="grilla"  
                            AutoGenerateColumns="false" OnRowCommand="ClientePagingGridView_RowCommand"
                            OnSelectedIndexChanged="ClientePagingGridView_SelectedIndexChanged" OnSelectedIndexChanging="ClientePagingGridView_SelectedIndexChanging"
                            DataKeyNames="" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cuit" HeaderText="Cuit" SortExpression="Cuit" ReadOnly="true" 
                                    HeaderStyle-Width="180px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DocumentoTipoDescr" HeaderText="TipoDoc" SortExpression="DocumentoTipoDescr" HeaderStyle-Width="200px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DocumentoNro" HeaderText="NroDoc" SortExpression="DocumentoNro" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="RazonSocial" HeaderStyle-Width="400px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioCalle" HeaderText="Calle" SortExpression="DomicilioCalle" HeaderStyle-Width="240px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioNro" HeaderText="Nro" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioPiso" HeaderText="Piso" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioDepto" HeaderText="Depto" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioLocalidad" HeaderText="Localidad" SortExpression="" HeaderStyle-Width="240px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioCodPost" HeaderText="CodPost" SortExpression="" HeaderStyle-Width="100px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ContactoNombre" HeaderText="NombreContacto" SortExpression="" ReadOnly="true" HeaderStyle-Width="220px"> 
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ContactoTelefono" HeaderText="Telefono" SortExpression="" HeaderStyle-Width="120px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ContactoEmail" HeaderText="Email" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="150px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true" 
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign = "Center" CssClass="GridPager" />
                        </cc1:PagingGridView>
                    </asp:Panel>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 text-left padding-top-20" >
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </section>

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    TargetControlID="TargetControlIDdelModalPopupExtender1"
    PopupControlID="ConfirmacionPanel"
    BackgroundCssClass="modalBackground"
    PopupDragHandleControlID="ConfirmacionPanel"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="ConfirmacionPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td colspan="2">
                    <asp:Label ID="TituloConfirmacionLabel" runat="server" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-top:20px; padding-right:5px; padding-left:5px">
                    CUIT:
                </td>
                <td align="left" style="padding-top:20px;">
                    <asp:Label ID="CUITLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Razón Social:
                </td>
                <td align="left">
                    <asp:Label ID="RazSocLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Tipo.Doc:
                </td>
                <td align="left">
                    <asp:Label ID="TipoDocLabel" runat="server"></asp:Label>
                </td>
            </tr>             
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Nro.Doc:
                </td>
                <td align="left">
                    <asp:Label ID="NroDocLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Calle:
                </td>
                <td align="left">
                    <asp:Label ID="CalleLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Nro:
                </td>
                <td align="left">
                    <asp:Label ID="NroLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Piso:
                </td>
                <td align="left">
                    <asp:Label ID="PisoLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Depto:
                </td>
                <td align="left">
                    <asp:Label ID="DeptoLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Localidad:
                </td>
                <td align="left">
                    <asp:Label ID="LocalidadLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Cod.Post:
                </td>
                <td align="left">
                    <asp:Label ID="CodPostLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Estado Actual:
                </td>
                <td align="left">
                    <asp:Label ID="EstadoLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="CancelarButton" runat="server" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <script type="text/javascript">
        function BorrarMensaje() {
            {
                document.getElementById('<%=MensajeLabel.ClientID%>').innerHTML = '';
            }
        }
    </script>
</asp:Content>
