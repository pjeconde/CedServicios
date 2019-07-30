<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorCuit.aspx.cs" Inherits="CedServicios.Site.ExploradorCuit" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="CedServiciosWebForms" Namespace="CedServicios.WebForms" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Explorador de CUITs"></asp:Label>
                        </h2>
                        <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-lg-9 col-md-9 text-center padding-top-20">
			        <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="2" ToolTip="" Width="100%" placeholder="Razon Social"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-3 text-center padding-top-20">
                    <asp:TextBox ID="NroTextBox" runat="server" MaxLength="50" TabIndex="1" Width="100%" placeholder="Cuit"></asp:TextBox>
                </div>
                <div class="col-lg-9 col-md-3 text-center padding-top-20">
                    <asp:TextBox ID="LocalidadTextBox" runat="server" MaxLength="128" TabIndex="4" ToolTip="" Width="100%" placeholder="Localidad"></asp:TextBox>                    
                </div>
                <div class="col-lg-3 col-md-9 text-left padding-top-20">
                    Estado:<asp:DropDownList ID="EstadoDropDownList" runat="server" TabIndex="3" Width="" DataValueField="Id" DataTextField="Descr" AutoPostBack="true"  placeholder="Estado"></asp:DropDownList>
                </div>
                <div class="col-lg-12 col-md-12 text-center">
                    <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" OnClientClick="this.disabled = true; BorrarMensaje()" UseSubmitBehavior="false" />
                    <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                </div>
                <div class="col-lg-12 text-center padding-top-20">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="None"
                        BorderWidth="1px" ScrollBars="Auto" BackColor="White">
                        <cc1:PagingGridView ID="CuitPagingGridView" runat="server" OnPageIndexChanging="CuitPagingGridView_PageIndexChanging"
                            OnRowDataBound="CuitPagingGridView_RowDataBound" 
                            FooterStyle-ForeColor="Brown" 
                            OnSorting="CuitPagingGridView_Sorting" AllowPaging="True" 
                            AllowSorting="True" CssClass="grilla" 
                            AutoGenerateColumns="false" OnRowCommand="CuitPagingGridView_RowCommand"
                            DataKeyNames="" BorderStyle="None">
                            <Columns>
                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="None">
                                    <HeaderStyle Wrap="False" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Ver" runat="server" CausesValidation="false" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="<%# ((GridViewRow) Container).RowIndex %>" Text="Detalle" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Nro" HeaderText="Nro" SortExpression="Nro" ReadOnly="true" 
                                    HeaderStyle-Width="100px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial" HeaderStyle-Width="300px" ReadOnly="true">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="false" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="true" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioCalle" HeaderText="Calle" SortExpression="" HeaderStyle-Width="250px" ReadOnly="true">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioNro" HeaderText="Nro" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="60px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioPiso" HeaderText="Piso" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="60px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioDepto" HeaderText="Depto" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="60px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioLocalidad" HeaderText="Localidad" SortExpression="DomicilioLocalidad" ReadOnly="true" 
                                    HeaderStyle-Width="180px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DomicilioDescrProvincia" HeaderText="Provincia" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="120px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DatosImpositivosDescrCondIVA" HeaderText="CondIVA" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="200px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DatosImpositivosDescrCondIngBrutos" HeaderText="CondIngBrutos" SortExpression="" ReadOnly="true" 
                                    HeaderStyle-Width="200px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado" ReadOnly="true" 
                                    HeaderStyle-Width="80px">
                                    <HeaderStyle Wrap="False" />
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="True" BorderStyle="None" />
                                </asp:BoundField>
                            </Columns>
                            <PagerSettings Mode="NumericFirstLast" />
                            <PagerStyle HorizontalAlign = "Center" CssClass="GridPager" />
                        </cc1:PagingGridView>
                    </asp:Panel>
                </div>
                <div class="col-lg-12 text-center padding-top-20">
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
                    Cuit:
                </td>
                <td align="left" style="padding-top:20px;">
                    <asp:Label ID="NroLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Razon Social:
                </td>
                <td align="left">
                    <asp:Label ID="RazonSocialLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Calle:
                </td>
                <td align="left">
                    <asp:Label ID="DomicilioCalleLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Nro:
                </td>
                <td align="left">
                    <asp:Label ID="DomicilioNroLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Piso:
                </td>
                <td align="left">
                    <asp:Label ID="DomicilioPisoLabel" runat="server"></asp:Label>
                </td>
            </tr>           
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Depto:
                </td>
                <td align="left">
                    <asp:Label ID="DomicilioDeptoLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Localidad:
                </td>
                <td align="left">
                    <asp:Label ID="DomicilioLocalidadLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Provincia:
                </td>
                <td align="left">
                    <asp:Label ID="DomicilioDescrProvinciaLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Cond.IVA:
                </td>
                <td align="left">
                    <asp:Label ID="DatosImpositivosDescrCondIVALabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Cond.IngBrutos:
                </td>
                <td align="left">
                    <asp:Label ID="DatosImpositivosDescrCondIngBrutosLabel" runat="server"></asp:Label>
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
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Destino Comprobante AFIP:
                </td>
                <td align="left">
                    <asp:Label ID="DestinoComprobanteAFIPLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Usa Certificado Propio AFIP:
                </td>
                <td align="left">
                    <asp:Label ID="UsaCertificadoPropioAFIPLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Destino Comprobante ITF:
                </td>
                <td align="left">
                    <asp:Label ID="DestinoComprobanteITFLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-left:5px">
                    Nro.Serie Certif. ITF:
                </td>
                <td align="left">
                    <asp:Label ID="NroSerieCertifITFLabel" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="CancelarButton" runat="server" Text="Salir" />
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
