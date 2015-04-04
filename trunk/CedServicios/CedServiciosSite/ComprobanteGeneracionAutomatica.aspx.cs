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
                    Entidades.Comprobante comprobante = ((List<Entidades.Comprobante>)ViewState["Comprobantes"])[i];

                    FeaEntidades.InterFacturas.lote_comprobantes lote = new FeaEntidades.InterFacturas.lote_comprobantes();
                    #region Obtención del lote desde el comprobante
                    System.Xml.Serialization.XmlSerializer x;
                    byte[] bytes;
                    System.IO.MemoryStream ms;
                    x = new System.Xml.Serialization.XmlSerializer(lote.GetType());
                    bytes = new byte[comprobante.Request.Length * sizeof(char)];
                    System.Buffer.BlockCopy(comprobante.Request.ToCharArray(), 0, bytes, 0, bytes.Length);
                    ms = new System.IO.MemoryStream(bytes);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    lote = (FeaEntidades.InterFacturas.lote_comprobantes)x.Deserialize(ms);
                    #endregion

                    while (Convert.ToInt32(comprobante.FechaProximaEmision.ToString("yyyyMMdd")) <= Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")))
                    {
                        #region Generar nuevo comprobante
                        lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision = FechaTextBox.Text;
                        lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento = DateTime.ParseExact(FechaTextBox.Text, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture).AddDays(comprobante.CantidadDiasFechaVto).ToString("yyyyMMdd");
                        lote.cabecera_lote.DestinoComprobante = comprobante.IdDestinoComprobante;
                        RN.Comprobante.Registrar(lote, null, "Venta", comprobante.IdDestinoComprobante, "PteConf", "No Aplica", new DateTime(9999, 12, 31), 0, 0, 0, sesion);
                        #endregion
                        try
                        {
                            listaErrores.Add("Timeout en web service AFIP");
                            switch (comprobante.IdDestinoComprobante)
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
                            switch (comprobante.PeriodicidadEmision)
                            {
                                case "Mensual":
                                    comprobante.FechaProximaEmision = comprobante.FechaProximaEmision.AddMonths(1);
                                    break;
                                case "Trimestral":
                                    comprobante.FechaProximaEmision = comprobante.FechaProximaEmision.AddMonths(3);
                                    break;
                                case "Anual":
                                    comprobante.FechaProximaEmision = comprobante.FechaProximaEmision.AddYears(1);
                                    break;
                            }
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            #region Registrar error en la transmisión del comprobante
                            listaErrores.Add(ex.Message);
                            #endregion
                            #region Eliminar comprobante generado
                            #endregion
                            comprobante.FechaProximaEmision = new DateTime(9999, 12, 31); //para forzar el salto al próximo contrato
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
