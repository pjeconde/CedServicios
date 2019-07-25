<%@ Page Title="" Language="C#" MasterPageFile="~/CedServicios.Master" AutoEventWireup="true" CodeBehind="ExploradorComprobanteRG.aspx.cs" Culture="en-GB" UICulture="en-GB" Inherits="CedServicios.Site.ExploradorComprobanteRG" Theme="CedServicios" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceDefault" runat="server">
    <style type="text/css">
    .popover
    {
    	min-width: 500px;
    }
    </style>
    <script type="text/javascript">
       $('#popoverButton').popover({
           placement: "bottom"
       });
    </script>
    <section id="features" class="features sections2">
        <div class="container">
            <div class="row">
                <div class="main_features_content2">
                    <div class="head_title text-center">
                        <h2><asp:Label ID="TituloPaginaLabel" runat="server" SkinID="TituloPagina" Text="Consulta de Comprobantes (para ITF.RG.AFIP)"></asp:Label>
                        </h2>
                    </div>
                </div>
             </div>
        </div>
        <asp:UpdatePanel ID="ExploradorUpdatePanel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div class="container">
            <asp:Panel ID="Panel0" runat="server" DefaultButton="BuscarButton" align="left">
                <div class="row">
                    <div class="col-lg-6 col-md-6 padding-top-20 text-left">
                         <div class="input-group text-left" style="background-color:white; height:25px">
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Persona (cliente/proveedor):&nbsp;</span>
                            <asp:DropDownList ID="ClienteDropDownList" runat="server" CssClass="form-control TextoChico" Height="25px" DataValueField="Orden" DataTextField="RazonSocial"></asp:DropDownList>
                        </div>
                    </div>                      
                    <div class="col-lg-6 col-md-6 padding-top-20">
                        <div class="input-group text-left" style="background-color:white; height:25px">
                            <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Naturaleza del comprobante:&nbsp;</span>
                            <asp:DropDownList ID="NaturalezaComprobanteDropDownList" runat="server" CssClass="form-control TextoChico" Height="25px" DataValueField="Id" DataTextField="Descr" AutoPostBack="true" OnSelectedIndexChanged="VerificarEstadosPosibles_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-md-6 padding-top-20">  
                        <asp:Panel ID="DetallePanel" runat="server">
                            <div class="input-group text-left" style="background-color:white; height:25px">
                                <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Detalle:&nbsp;</span>
                                <asp:TextBox ID="DetalleTextBox" runat="server" MaxLength="50" CssClass="form-control TextoChico" Height="25px"></asp:TextBox>
                                <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white; width:40px">
                                    <a href="javascript:void(0)" role="button" class="popover-test" data-html="true" title="FILTRO DE BUSQUEDA (DETALLE)" data-content="(ej.: 'autom' para seleccionar sólo comprobantes generados automaticamente)"><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                                </span>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="col-lg-6 col-md-6 padding-top-20">  
                        <asp:UpdatePanel ID="fechasUpdatePanel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:Panel ID="PeriodoEmisionPanel" runat="server">
                                <div class="input-group" style="background-color:white; height:25px; float:left">
                                    <span class="input-group-addon" style="padding: 0px 0px 0px 0px; background-color: white;">&nbsp;Emisión:&nbsp;desde&nbsp;</span>
                                    <asp:TextBox ID="FechaDesdeTextBox" runat="server" CausesValidation="true" CssClass="form-control TextoRegular" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="80px" Height="25px" TabIndex="304"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="FechaDesdeCalendarExtender" runat="server" CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                                        TargetControlID="FechaDesdeTextBox" Format="yyyyMMdd" PopupButtonID="FechaDesdeLinkButton" >
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:LinkButton ID="FechaDesdeLinkButton" runat="server" CssClass="form-control no-padding" Width="25px" Height="25px"  
                                        AutoPostBack="true" ToolTip="Multiselección de Estados">
                                        <span class="glyphicon glyphicon-calendar gi-1x" style="padding: 3px;"></span>
                                    </asp:LinkButton></span>
                                    <asp:Label runat="server" ID="hastaLabel" CssClass="form-control TextoMediano text-center" Width="80px" Height="25px" Text="&nbsp;&nbsp;hasta&nbsp;&nbsp;"></asp:Label>
                                    <asp:TextBox ID="FechaHastaTextBox" runat="server" CausesValidation="true" CssClass="form-control TextoRegular" ToolTip="Ingresar fecha en formato: año, mes, día (AAAAMMDD).  Ej: 20040324" Width="80px" Height="25px" TabIndex="304"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="FechaHastaCalendarExtender" runat="server" CssClass="MyCalendar" OnClientShown="onCalendar1Shown"
                                        TargetControlID="FechaHastaTextBox" Format="yyyyMMdd" PopupButtonID="FechaHastaLinkButton" >
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:LinkButton ID="FechaHastaLinkButton" runat="server" CssClass="form-control no-padding" Width="25px" Height="25px"  
                                        AutoPostBack="true" ToolTip="Multiselección de Estados">
                                        <span class="glyphicon glyphicon-calendar" style="padding: 3px"></span>
                                    </asp:LinkButton></span>
                                    <span class="dropdown" style="padding: 5px 0px 0px 10px">
                                        <a class="dropdown-toggle" data-toggle="dropdown">Predefinidas
                                            <span class="caret"></span>
                                        </a>
                                        <ul class="dropdown-menu">
                                            <li><asp:LinkButton class="dropdown-item" id="MesActual" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Mes Actual"></asp:LinkButton></li>
                                            <li><asp:LinkButton class="dropdown-item" id="MesAnterior" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Mes Anterior"></asp:LinkButton></li>
                                            <li><asp:LinkButton class="dropdown-item" id="TresMesesUltimos" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Ultimos Tres Meses"></asp:LinkButton></li>
                                            <li><asp:LinkButton class="dropdown-item" id="TresMesesAnteriores" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Tres Meses Anteriores"></asp:LinkButton></li>
                                            <li class="divider"></li>
                                            <li><asp:LinkButton class="dropdown-item" id="AnualActual" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Año Actual"></asp:LinkButton></li>
                                            <li><asp:LinkButton class="dropdown-item" id="AnualAnterior" runat="server" OnClick="FechasPredefinidasLinkButton_Click" Text="Año Anterior"></asp:LinkButton></li>
                                        </ul>
                                    </span>
                                </div>
                        </asp:Panel>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 text-center">
                        <asp:Button ID="BuscarButton" runat="server" class="btn btn-default btn-sm" TabIndex="8" Text="Buscar" onclick="BuscarButton_Click" />
                        <asp:Button ID="SalirButton" runat="server" class="btn btn-default btn-sm" CausesValidation="false" TabIndex="9" Text="Cancelar" onclick="SalirButton_Click" />
                        <asp:Button ID="DescargarButton" runat="server" class="btn btn-default btn-sm" TabIndex="10" Text="Descargar Interfaz RG.3685" onclick="DescargarButton_Click" />
                        <a href="#" role="button" class="popover-test" data-html="true" data-trigger="focus" title="FILTROS DE BUSQUEDA" data-content="Si no selecciona ningún filtro, buscará todos los comprobantes que estén dentro del rango de fechas del período de emisión.<br><br>El botón de 'Descargar Interfaz RG.3685' se habilita cuando se encuentren comprobantes vigentes en la busqueda."><span class="glyphicon glyphicon-info-sign gi-1x" style="vertical-align:middle"></span></a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 text-center padding-top-20">  
                        <asp:Label ID="MensajeLabel" runat="server" SkinID="MensajePagina" Text=""></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 text-center">
                        <asp:UpdateProgress ID="ExploradorUpdatePanelProgress" runat="server" AssociatedUpdatePanelID="ExploradorUpdatePanel" DisplayAfter="0">
                            <ProgressTemplate>
                                <asp:Image ID="ExploradorComprobanteImage" runat="server" Height="18px" ImageUrl="~/Imagenes/301.gif">
                                </asp:Image>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:Panel ID="GrillaComprobantesPanel" runat="server" Width="100%" ScrollBars="Auto">
                        <asp:GridView ID="ComprobantesGridView" runat="server" AlternatingRowStyle-BackColor="#d3d3d3" AutoGenerateColumns="false" OnRowCommand="ComprobantesGridView_RowCommand" OnRowDataBound="ComprobantesGridView_RowDataBound" CssClass="grilla" GridLines="None" Width="100%" HorizontalAlign="Center">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="VerLinkButton" runat="server" CommandName="Consulta" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">Ver</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DescrNaturalezaComprobante" HeaderText="Naturaleza" SortExpression="DescrNaturalezaComprobante">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DescrTipoComprobante" HeaderText="Tipo" SortExpression="DescrTipoComprobante">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NroPuntoVtaFORMATEADO" HeaderText="P.V." SortExpression="NroPuntoVtaFORMATEADO">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NroFORMATEADO" HeaderText="Nro." SortExpression="NroFORMATEADO">
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
                                <asp:BoundField DataField="Fecha" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha" SortExpression="Fecha">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
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
                                <asp:BoundField DataField="Estado" HeaderText="Estado" SortExpression="Estado">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdDestinoComprobante" HeaderText="Canal" SortExpression="IdDestinoComprobante">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="left" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaVto" DataFormatString="{0:dd/MM/yy}" HeaderText="Fecha Vto" SortExpression="FechaVto">
                                    <headerstyle horizontalalign="left" wrap="False" />
                                    <itemstyle horizontalalign="center" wrap="False" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NroLote" HeaderText="Nro.Lote" SortExpression="NroLote">
                                    <headerstyle horizontalalign="center" wrap="False" />
                                    <itemstyle horizontalalign="right" wrap="False" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 text-center padding-top-20">
                        <asp:label ID="ResultadosLabel" runat="server" Text="Resultados: "></asp:label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 text-center padding-top-20">
                        <asp:TextBox ID="ResultadosTextBox" runat="server" Text="" TextMode="MultiLine" Width="100%" Rows="10" Height="100%"></asp:TextBox>
                    </div>
                </div>
            </asp:Panel>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
    </section>
    <style type="text/css">
        textarea
        {
            resize: none;
        }
    </style>
</asp:Content>
