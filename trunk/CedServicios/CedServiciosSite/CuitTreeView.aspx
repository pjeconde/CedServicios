<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="CuitTreeView.aspx.cs" Inherits="CedServicios.Site.CuitTreeView" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="uc1" TagName="domicilioConsulta" Src="~/Controles/DomicilioConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="contactoConsulta" Src="~/Controles/ContactoConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosImpositivosConsulta" Src="~/Controles/DatosImpositivosConsulta.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datosIdentificatoriosConsulta" Src="~/Controles/DatosIdentificatoriosConsulta.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" style="padding-left:10px;">
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="TituloLabel" runat="server" SkinID="TituloPagina" Text="Consulta de CUIT(s)"></asp:Label>
                <asp:Label ID="TargetControlIDdelModalPopupExtender1" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:20px">
                <asp:TreeView ID="TituloCuitsTreeView" runat="server">
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td align="left" style="padding-top:10px">
                <asp:TreeView ID="CuitsTreeView" runat="server" 
                    onselectednodechanged="CuitsTreeView_SelectedNodeChanged">
                </asp:TreeView>
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Button ID="SalirButton" runat="server" Text="Salir" onclick="SalirButton_Click" />
            </td>
        </tr>
        <tr>
            <td align="center" style="padding-top:20px">
                <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
    PopupControlID="CuitPanel"
    PopupDragHandleControlID="CuitPanel"
    TargetControlID="TargetControlIDdelModalPopupExtender1"
    BackgroundCssClass="modalBackground"
    BehaviorID="mdlPopup" />
    <asp:Panel ID="CuitPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="TituloCuitLabel" runat="server" Text="Consulta de CUIT" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top: 20px">
                    <asp:Label ID="Label3" runat="server" Text="CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:TextBox ID="CuitPanel_CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                        Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr noshade="noshade" size="1" color="#cccccc" />
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:2px">
                    <asp:Label ID="Label9" runat="server" Text="Razón Social"></asp:Label>
                </td>
                <td align="left" style="padding-top:2px">
                    <asp:TextBox ID="RazonSocialTextBox" runat="server" MaxLength="50" TabIndex="3" Width="300px"></asp:TextBox>
                </td>        
            </tr>
            <uc1:domicilioConsulta ID="Domicilio" runat="server"/>
            <uc1:contactoConsulta ID="Contacto" runat="server" />
            <uc1:datosImpositivosConsulta ID="DatosImpositivos" runat="server" />
            <uc1:datosIdentificatoriosConsulta ID="DatosIdentificatorios" runat="server" />
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:5px">
		            <asp:Label ID="Label18" runat="server" Text="¿ Cómo nos conoció ?"></asp:Label>
	            </td>
			    <td align="left" style="padding-top:5px">
				    <asp:DropDownList ID="MedioDropDownList" runat="server" TabIndex="18" Width="216px" DataValueField="Id" DataTextField="Descr">
				    </asp:DropDownList>
			    </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 5px; padding-top:5px" valign="top">
                    <asp:Label ID="Label11" runat="server" Text="Destinos de comprobantes"></asp:Label>
                </td>
                <td align="left" style="padding-top:5px">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" valign="top">
                                <asp:CheckBox ID="DestinoComprobanteITFCheckBox" runat="server" AutoPostBack="true" Text="Interbanking (Interfacturas)" Checked="true" TabIndex="501"/>
                            </td>
                            <td align="left" valign="middle" style="padding-left:5px">
                                <asp:Label ID="Label12" runat="server" Text="--> Nro.serie certif.:"></asp:Label>
                            </td>
                            <td align="left" valign="top" style="padding-left:5px">
                                <asp:TextBox ID="NroSerieCertifITFTextBox" runat="server" MaxLength="256" TabIndex="502" Width="120px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <asp:CheckBox ID="DestinoComprobanteAFIPCheckBox" runat="server" AutoPostBack="true" Text="A.F.I.P." Checked="true" TabIndex="503" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="SalirCuitButton" runat="server" Text="Salir" onclick="SalirCuitButton_Click"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="UNPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="TituloUNLabel" runat="server" Text="Consulta de Unidad de Negocio" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top: 20px">
                    <asp:Label ID="Label1" runat="server" Text="CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:TextBox ID="UNPanel_CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                        Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:5px">
                    <asp:Label ID="Label6" runat="server" Text="Id."></asp:Label>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="IdUNTextBox" runat="server" MaxLength="20" TabIndex="2" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr noshade="noshade" size="1" color="#cccccc" />
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:2px">
                    <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
                </td>
                <td align="left" style="padding-top:2px">
                    <asp:TextBox ID="DescrUNTextBox" runat="server" MaxLength="50" TabIndex="3" Width="300px"></asp:TextBox>
                </td>        
            </tr>
            <tr>
                <td>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="SalirUNButton" runat="server" Text="Salir" onclick="SalirUNButton_Click"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PuntoVtaPanel" runat="server" CssClass="ModalWindow">
        <table width="100%">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="TituloPuntoVtaLabel" runat="server" Text="Consulta de Punto de Venta" SkinID="TituloPagina"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 5px; padding-top: 20px">
                    <asp:Label ID="Label19" runat="server" Text="CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top: 20px">
                    <asp:TextBox ID="PuntoVtaPanel_CUITTextBox" runat="server" MaxLength="11" TabIndex="1" ToolTip="Debe ingresar sólo números."
                        Width="80px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 5px; padding-top:5px">
                    <asp:Label ID="Label4" runat="server" Text="Nro. de Punto de Venta"></asp:Label>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="NroTextBox" runat="server" MaxLength="4" TabIndex="2" ToolTip="Debe ingresar sólo números."
                        Width="40px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <hr noshade="noshade" size="1" color="#cccccc" />
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right:5px; padding-top:2px; height:25px;">
                    <asp:Label ID="Label13" runat="server" Text="Unidad de Negocio"></asp:Label>
                </td>
                <td align="left" style="padding-top:2px; height:25px;">
                    <asp:DropDownList ID="PuntoVtaPanel_IdUNDropDownList" runat="server" TabIndex="3" Width="183px" DataValueField="Id" DataTextField="Descr" >
                    </asp:DropDownList>
                </td>
            </tr> 
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:5px">
		            <asp:Label ID="Label14" runat="server" Text="Tipo Punto de Venta"></asp:Label>
	            </td>
			    <td align="left" style="padding-top:5px">
				    <asp:DropDownList ID="IdTipoPuntoVtaDropDownList" runat="server" TabIndex="18" Width="216px" DataValueField="Id" DataTextField="Descr">
				    </asp:DropDownList>
			    </td>
            </tr>
            <tr>
	            <td align="right" style="padding-right:5px; padding-top:5px">
		            <asp:Label ID="Label7" runat="server" Text="Método de numeración de lotes"></asp:Label>
	            </td>
			    <td align="left" style="padding-top:5px">
				    <asp:DropDownList ID="IdMetodoGeneracionNumeracionLoteDropDownList" runat="server" TabIndex="18" Width="650px" DataValueField="Id" DataTextField="Descr">
				    </asp:DropDownList>
			    </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 5px; padding-top:5px">
                    <asp:Label ID="Label8" runat="server" Text="Último nro. de lote"></asp:Label>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:TextBox ID="UltNroLoteTextBox" runat="server" MaxLength="10" TabIndex="3" ToolTip="Debe ingresar sólo números."
                        Width="120px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="padding-right: 5px; padding-top:5px">
                    <asp:Label ID="Label10" runat="server" Text="Usa datos CUIT"></asp:Label>
                </td>
                <td align="left" style="padding-top:5px">
                    <asp:CheckBox ID="UsaDatosCuitCheckBox" runat="server" 
                        Checked="true" AutoPostBack="true"
                        oncheckedchanged="UsaDatosCuitCheckBox_CheckedChanged" />
                    <asp:Label ID="Label5" runat="server" Text="( se refiere a Domicilio, Contacto y Datos Impositivos e Identificatorios )"></asp:Label>

                </td>
            </tr>
            <uc1:domicilioConsulta ID="PuntoVtaPanel_Domicilio" runat="server" />
            <uc1:contactoConsulta ID="PuntoVtaPanel_Contacto" runat="server" />
            <uc1:datosImpositivosConsulta ID="PuntoVtaPanel_DatosImpositivos" runat="server" />
            <uc1:datosIdentificatoriosConsulta ID="PuntoVtaPanel_DatosIdentificatorios" runat="server" />
            <tr>
                <td>
                </td>
                <td align="left" style="padding-top:20px">
                    <asp:Button ID="SalirPuntoVtaButton" runat="server" Text="Salir" onclick="SalirPuntoVtaButton_Click"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
