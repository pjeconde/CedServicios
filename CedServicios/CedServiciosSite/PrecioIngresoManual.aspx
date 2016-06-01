<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" Culture="en-GB" UICulture="en-GB" CodeBehind="PrecioIngresoManual.aspx.cs" Inherits="CedServicios.Site.PrecioIngresoManual" Theme="CedServicios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-12 col-md-12">
                <table align="center">
                    <tr>
                        <td colspan="2" style="padding-top:20px; text-align: center">
                            <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Ingreso Manual de Precios"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-right:5px; padding-top: 20px; text-align:right">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="CUITTextBox" ErrorMessage="CUIT" SetFocusOnError="True" ValidationExpression="[0-9]{11}">
                                <asp:Label ID="Label1" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="CUITTextBox"
                                ErrorMessage="CUIT" SetFocusOnError="True">
                                <asp:Label ID="Label2" runat="server" SkinID="IndicadorValidacion"></asp:Label>
                            </asp:RequiredFieldValidator>
                            <asp:Label ID="Label3" runat="server" Text="Listas de Precios pertenecientes al CUIT"></asp:Label>
                        </td>
                        <td style="padding-top:20px; text-align: left">
                            <asp:TextBox ID="CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números." Width="90px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top:5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:1px; background-color:#cccccc">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top:5px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td style="height: 24px; padding-top:20px; text-align: left">
                            <asp:Button ID="AceptarButton" runat="server" TabIndex="504" Text="Aceptar" onclick="AceptarButton_Click" />
                            <asp:Button ID="SalirButton" runat="server" CausesValidation="false" TabIndex="505" Text="Cancelar" onclick="SalirButton_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top:10px; padding-bottom:10px; text-align: center">
                            <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                            <asp:ValidationSummary ID="MensajeValidationSummary" runat="server" SkinID="MensajeValidationSummary"></asp:ValidationSummary>
                        </td>
                    </tr>
	                <tr>
		                <td colspan="2" style="text-align: center; font-weight: normal;">
			                <asp:UpdatePanel ID="preciosUpdatePanel" runat="server" ChildrenAsTriggers="true"
				                UpdateMode="Conditional">
				                <ContentTemplate>
					                <asp:GridView ID="preciosGridView" runat="server" AutoGenerateColumns="true" AutoGenerateEditButton="true"
						                BorderColor="gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center"
						                EnableViewState="true" Font-Bold="false" CssClass="gridview" 
						                GridLines="Both" OnRowCancelingEdit="preciosGridView_RowCancelingEdit"
						                OnRowCommand="preciosGridView_RowCommand" OnRowEditing="preciosGridView_RowEditing"
						                OnRowUpdated="preciosGridView_RowUpdated" OnRowUpdating="preciosGridView_RowUpdating"
                                        OnRowDataBound="preciosGridView_RowDataBound"
						                ShowFooter="false" ShowHeader="True" ToolTip="El separador de decimales a utilizar es el punto"
                                        DataKeyNames="IdArticulo, DescrArticulo">
                                        <HeaderStyle Font-Bold="True" />
					                </asp:GridView>
				                </ContentTemplate>
			                </asp:UpdatePanel>
		                </td>
	                </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

