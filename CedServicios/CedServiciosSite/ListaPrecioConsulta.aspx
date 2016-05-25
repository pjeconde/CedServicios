<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ListaPrecioConsulta.aspx.cs" Inherits="CedServicios.Site.ListaPrecioConsulta" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <script type="text/javascript">
        function ShowModalListaPrecio() {
            $('#ModalListaPrecio').modal('show');
            return true;
        };
    </script>
    <div class="container">
    <div class="row">
    <div class="col-lg-12 col-md-12">
    <table align="center">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Listas de Precios"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px;">
                <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto">
                    <asp:GridView ID="ListasPrecioGridView" runat="server"
                        AutoGenerateColumns="false" OnRowCommand="ListasPrecioGridView_RowCommand" OnRowDataBound="ListasPrecioGridView_RowDataBound" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Lista de Precio">
                                <ItemTemplate>
                                    <asp:Button ID="TargetControlButton" runat="server" style="Display:none;" Text="Button" />
                                    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="ListaPrecioPanel" TargetControlID="TargetControlButton" BackgroundCssClass="modalBackground" runat="server" />
                                    <asp:LinkButton ID="VerLinkButton" CommandName="Ver" runat="server">Ver detalle</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Descr" HeaderText="descripción" SortExpression="Descr">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="height: 24px; padding-top:20px; text-align: center">
                <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="505" Text="Salir" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td style="padding-top:20px; text-align: center">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
            </td>
        </tr>
    </table>
    <div id="ModalListaPrecio" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        &times;</button>
                    <h4 class="modal-title">
                        <asp:Label ID="Label1" runat="server" SkinID="TituloPagina" Text="Consulta de Listas de Precios"></asp:Label></h4>
                </div>
                <div class="modal-body">
                     <table style="width: 100%">
                        <tr>
                            <td style="padding-right:5px; padding-top: 20px; text-align: right">
                                <asp:Label ID="Label4" runat="server" Text="Lista de Precio perteneciente al CUIT"></asp:Label>
                            </td>
                            <td style="padding-top:20px; text-align: left">
                                <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right:5px; padding-top:5px; text-align: right">
                                <asp:Label ID="Label9" runat="server" Text="Id."></asp:Label>
                            </td>
                            <td style="padding-top:5px; text-align: left">
                                <asp:TextBox ID="IdTextBox" runat="server" MaxLength="20" TabIndex="2" Width="100px"></asp:TextBox>
                            </td>        
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr noshade="noshade" size="1" color="#cccccc" />
                            </td>
                        </tr>
                        <tr>
                            <td style="padding-right:5px; padding-top:2px; text-align: right">
                                <asp:Label ID="Label10" runat="server" Text="Descripción"></asp:Label>
                            </td>
                            <td style="padding-top:2px; text-align: left">
                                <asp:TextBox ID="DescrTextBox" runat="server" MaxLength="100" TabIndex="3" Width="300px" TextMode="MultiLine"></asp:TextBox>
                            </td>        
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="ListaPrecioPanel" runat="server" CssClass="ModalWindow">
       
    </asp:Panel>
    </div>
    </div>
    </div>
</asp:Content>

