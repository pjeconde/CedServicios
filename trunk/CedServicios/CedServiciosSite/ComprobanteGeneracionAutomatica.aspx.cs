using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Xml;
using System.IO;
using Ionic.Zip;
using System.Diagnostics;
using System.Net;

namespace CedServicios.Site
{
    public partial class ComprobanteGeneracionAutomatica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    FechaTextBox.Text = DateTime.Today.ToString("yyyyMMdd");
                    ViewState["Personas"] = RN.Persona.ListaPorCuit(false, true, Entidades.Enum.TipoPersona.Ambos, sesion);
                    ClienteDropDownList.DataSource = (List<Entidades.Persona>)ViewState["Personas"];
                    DataBind();
                    if (ClienteDropDownList.Items.Count > 0)
                    {
                        ClienteDropDownList.SelectedValue = "0";
                        BuscarButton_Click(BuscarButton, EventArgs.Empty);
                    }
                }
            }
        }
        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                List<Entidades.Comprobante> lista = new List<Entidades.Comprobante>();
                MensajeLabel.Text = String.Empty;
                Entidades.Persona persona;
                if (ClienteDropDownList.SelectedIndex >= 0)
                {
                    persona = ((List<Entidades.Persona>)ViewState["Personas"])[ClienteDropDownList.SelectedIndex];
                }
                else
                {
                    persona = new Entidades.Persona();
                }
                List<Entidades.Estado> estados = new List<Entidades.Estado>();
                estados.Add(new Entidades.EstadoVigente());
                lista = RN.Comprobante.ListaContratosFiltrada(estados, FechaTextBox.Text, persona, sesion);
                if (lista.Count == 0)
                {
                    ComprobantesGridView.DataSource = null;
                    ComprobantesGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Contratos que satisfagan la busqueda";
                }
                else
                {
                    ComprobantesGridView.DataSource = lista;
                    ViewState["Comprobantes"] = lista;
                    ComprobantesGridView.DataBind();
                    GenerarComprobantesButton.Visible = true;
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
        protected void GenerarComprobantesButton_Click(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
            int cantidadContratosSeleccionados = 0;
            int cantidadComprobantesGenerados = 0;
            List<string> listaErrores = new List<string>();
            for (int i = 0; i < ComprobantesGridView.Rows.Count; i++)
            {
                if (((CheckBox)ComprobantesGridView.Rows[i].FindControl("SeleccionContratoCheckBox")).Checked)
                {
                    cantidadContratosSeleccionados++;
                    Entidades.Comprobante contrato = ((List<Entidades.Comprobante>)ViewState["Comprobantes"])[i];

                    FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                    #region Obtención del lote desde el comprobante
                    System.Xml.Serialization.XmlSerializer x;
                    byte[] bytes;
                    System.IO.MemoryStream ms;
                    x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                    bytes = new byte[contrato.Request.Length * sizeof(char)];
                    System.Buffer.BlockCopy(contrato.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                    ms = new System.IO.MemoryStream(bytes);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                    #endregion

                    while (Convert.ToInt32(contrato.FechaProximaEmision.ToString("yyyyMMdd")) <= Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")))
                    {
                        try
                        {
                            #region Generar nuevo comprobante
                            lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision = FechaTextBox.Text;
                            lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento = DateTime.ParseExact(FechaTextBox.Text, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddDays(contrato.CantidadDiasFechaVto).ToString("yyyyMMdd");
                            lote.cabecera_lote.DestinoComprobante = contrato.IdDestinoComprobante;
                            //Nuevo número de lote
                            if (contrato.IdDestinoComprobante == "ITF")
                            {
                                Entidades.PuntoVta puntoVta = ((Entidades.Sesion)Session["Sesion"]).UN.PuntosVta.Find(delegate(Entidades.PuntoVta pv) { return pv.Nro == contrato.NroPuntoVta; });
                                switch (puntoVta.IdMetodoGeneracionNumeracionLote)
                                {
                                    case "Autonumerador":
                                    case "TimeStamp1":
                                    case "TimeStamp2":
                                        RN.PuntoVta.GenerarNuevoNroLote(puntoVta, (Entidades.Sesion)Session["Sesion"]);
                                        lote.cabecera_lote.id_lote = puntoVta.UltNroLote;
                                        break;
                                    default:
                                        throw new Exception("El punto de venta no tiene definido un método de numeración automática de lotes.");
                                }
                            }
                            //Nuevo número de comprobante
                            Entidades.Comprobante ultimoComprobanteEmitido = new Entidades.Comprobante();
                            ultimoComprobanteEmitido.TipoComprobante.Id = contrato.TipoComprobante.Id;
                            ultimoComprobanteEmitido.NroPuntoVta = contrato.NroPuntoVta;
                            ultimoComprobanteEmitido.NaturalezaComprobante.Id = "Venta";
                            RN.Comprobante.LeerUltimoEmitido(ultimoComprobanteEmitido, sesion);
                            lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante = ultimoComprobanteEmitido.Nro + 1;

                            RN.Comprobante.Registrar(lote, null, "Venta", contrato.IdDestinoComprobante, "PteConf", "No Aplica", new DateTime(9999, 12, 31), 0, 0, 0, sesion);
                            #endregion

                            switch (contrato.IdDestinoComprobante)
                            {
                                case "AFIP":
                                    #region Transmitir comprobante a la AFIP
                                    #endregion
                                    break;
                                case "ITF":
                                    #region Transmitir comprobante a la Interfacturas
                                    #endregion
                                    break;
                            }
                            cantidadComprobantesGenerados++;
                            #region Actualizar, en el Contrato, la fecha de próxima emisión
                            switch (contrato.PeriodicidadEmision)
                            {
                                case "Mensual":
                                    contrato.FechaProximaEmision = contrato.FechaProximaEmision.AddMonths(1);
                                    break;
                                case "Trimestral":
                                    contrato.FechaProximaEmision = contrato.FechaProximaEmision.AddMonths(3);
                                    break;
                                case "Anual":
                                    contrato.FechaProximaEmision = contrato.FechaProximaEmision.AddYears(1);
                                    break;
                            }
                            RN.Comprobante.ActualizarFechaProximaEmision(contrato, sesion);
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            #region Registrar error en la transmisión del comprobante
                            string a = "Contrato " + contrato.Nro.ToString() + "(pv" + contrato.NroPuntoVta + "): " + ex.Message;
                            if (ex.InnerException != null)
                            {
                                a += "  " + ex.InnerException.Message;
                            }
                            listaErrores.Add(a);
                            #endregion
                            #region Eliminar comprobante generado
                            #endregion
                            contrato.FechaProximaEmision = new DateTime(9999, 12, 31); //para forzar el salto al próximo contrato
                        }
                    }
                }
            }
            if (cantidadContratosSeleccionados == 0)
            {
                MensajeLabel.Text = "Para la generación automática de comprobantes se debe seleccionar al menos un contrato.";
            }
            else
            {
                MensajeLabel.Text = "Cantidad de comprobantes generados: " + cantidadComprobantesGenerados + ".";
                if (listaErrores.Count > 0)
                {
                    MensajeLabel.Text += "<br />ERRORES:";
                    for (int i = 0; i < listaErrores.Count; i++)
                    {
                        MensajeLabel.Text += "<br />" + listaErrores[i];
                    }
                }
            }
            GenerarComprobantesButton.Visible = false;
        }
    }
}
