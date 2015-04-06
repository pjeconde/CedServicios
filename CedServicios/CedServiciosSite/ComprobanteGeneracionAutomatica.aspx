<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ComprobanteGeneracionAutomatica.aspx.cs" Inherits="CedServicios.Site.ComprobanteGeneracionAutomatica" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <asp:Panel ID="Panel0" runat="server" DefaultButton="BuscarButton">
        <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px">
            <tr>
                <td align="center" colspan="3" style="padding-top:20px; padding-bottom:20px">
                    <asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Generación automática de Comprobantes (contratos)"></asp:Label>
                    <asp:TextBox ID="ElementoTextBox" runat="server" Visible="false"> </asp:TextBox>
                    <asp:TextBox ID="TratamientoTextBox" runat="server" Visible="false"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Persona (cliente/proveedor):
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:DropDownList ID="ClienteDropDownList" runat="server" Width="400px" DataValueField="Orden" DataTextField="RazonSocial"></asp:DropDownList>
                </td>
                <td style="width:550px">
                </td>
            </tr>
            <tr>
                <td align="left" style="padding-right:5px; padding-top:5px">
                    Moneda:
                </td>
                <td align="left" style="padding-top:5px">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:DropDownList ID="MonedaDropDownList" runat="server" Width="200px" OnSelectedIndexChanged="MonedaDropDownList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </td>
                            <td style="padding-left:10px">
                                <asp:Label ID="Tipo_de_cambioLabel" runat="server" Text="Tipo de cambio:" Visible="false"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Tipo_de_cambioTextBox" runat="server" SkinID="TextoBoxFEAVendedorDetCh" Text="1.00" ToolTip="El separador de decimales a utilizar es el punto" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width:550px">
                </td>
            </tr>
            <tr>
	            <td align="left" style="padding-right:5px; padding-top:5px">
                    Fecha de emisión:
	            </td>
			    <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="FechaTextBox" runat="server" CausesValidation="true" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="90px" TabIndex="304"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="FechaCalendarExtender" runat="server"  CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                        TargetControlID="FechaTextBox" Format="yyyyMMdd" PopupButtonID="FechaImage" >
                    </ajaxToolkit:CalendarExtender>
                    <asp:Image runat="server" ID="FechaImage" ImageUrl="~/Imagenes/Calendar.gif" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="height: 24px; padding-top:10px" valign="top">
                    <asp:Button ID="BuscarButton" runat="server" Text="Leer contratos para seleccionar" onclick="BuscarButton_Click" Width="278px" />
                    <asp:Button ID="SalirButton" runat="server" Text="Cancelar" onclick="SalirButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="height:24px" valign="top">
                    <asp:Button ID="GenerarComprobantesButton" runat="server" Text="Generar Comprobantes para los Contratos seleccionados" onclick="GenerarComprobantesButton_Click" Visible="false" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" colspan="2" style="padding-top:20px; padding-bottom:10px">
                    <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="ComprobantesGridView" runat="server" AutoGenerateColumns="false" CssClass="grilla" GridLines="None">
                        <Columns>
                            <asp:TemplateField HeaderText="Seleccionado<br/>para su emisión">
                                <ItemTemplate>
                                    <asp:CheckBox ID="SeleccionContratoCheckBox" runat="server" Checked="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DescrTipoComprobante" HeaderText="Tipo" SortExpression="DescrTipoComprobante">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NroPuntoVtaFORMATEADO" HeaderText="P.V." SortExpression="NroPuntoVtaFORMATEADO">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nro" HeaderText="Nº Contrato" SortExpression="Nro">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescrTipoDoc" HeaderText="T.Doc" SortExpression="DescrTipoDoc">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NroDoc" HeaderText="Nro.Doc." SortExpression="NroDoc">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RazonSocial" HeaderText="Razon Social" SortExpression="RazonSocial">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FechaProximaEmision" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha emi." SortExpression="FechaProximaEmision">
                                <headerstyle horizontalalign="left" wrap="False" />
                                <itemstyle horizontalalign="center" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:0.00}" SortExpression="Importe">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Moneda" HeaderText="Mon" SortExpression="Moneda">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ImporteMoneda" HeaderText="Imp.Mon" DataFormatString="{0:0.00}" SortExpression="ImporteMoneda">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TipoCambio" HeaderText="Cambio" DataFormatString="{0:0.0000}" SortExpression="TipoCambio">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="right" wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IdDestinoComprobante" HeaderText="Canal" SortExpression="IdDestinoComprobante">
                                <headerstyle horizontalalign="center" wrap="False" />
                                <itemstyle horizontalalign="left" wrap="False" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
