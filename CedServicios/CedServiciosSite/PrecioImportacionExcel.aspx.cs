using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.IO;
using FileHelpers;
using FileHelpers.DataLink;

namespace CedServicios.Site
{
    [DelimitedRecord("|")]
    public class ProductosExcel
    {
        public string IdArticulo;
        public string DescrArticulo;
        public string Lista1;
        public string Lista2;
        public string Lista3;
        public string Lista4;
        public string Lista5;
        public string Lista6;
        public string Lista7;
        public string Lista8;
        public string Lista9;
        public string Lista10;
    }

    public partial class PrecioImportacionExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                CUITTextBox.Text = sesion.Cuit.Nro;
                CUITTextBox.Enabled = false;
            }
        }

        protected void FileUploadButton_Click(object sender, EventArgs e)
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                //ActualizarEstadoPanel.Visible = false;
                //DescargarPDFPanel.Visible = false;
                if (((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Su sesión ha caducado por inactividad. Por favor vuelva a loguearse."), false);
                }
                else
                {
                    if (XMLFileUpload.HasFile)
                    {
                        try
                        {
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(XMLFileUpload.FileBytes);
                            FileStream file = new FileStream(Server.MapPath("Temp\\ExcelAProcesar.xls"), FileMode.Create, FileAccess.Write);
                            ms.WriteTo(file);
                            file.Close();
                            ms.Close();
                            LeerExcel();
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Problemas para procesar la planilla excel de precios. Mensaje: " + ex.Message), false);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Debe seleccionar un archivo"), false);
                        return;
                    }
                }
            }
        }
        private void LeerExcel()
        {
            try
            {
                //Leer cabecera del excel 
                ExcelStorage provider = new ExcelStorage(typeof(ProductosExcel));
                provider.StartRow = 1;
                provider.StartColumn = 1;
                provider.FileName = Server.MapPath("Temp\\ExcelAProcesar.xls");
                ProductosExcel[] resCab = (ProductosExcel[])provider.ExtractRecords();

                List<Entidades.ListaPrecio> listasPrecio = new List<Entidades.ListaPrecio>();
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                
                if (resCab.Length > 1)
                {
                    MensajeLabel.Text = "Proceso cancelado: La cabecera del archivo excel debe tener un solo renglón.";
                    return;
                }
                if (resCab[0].Lista1 == null || resCab[0].Lista1.Trim().Equals(string.Empty))
                {
                    MensajeLabel.Text = "Proceso cancelado: No está informada la primer lista de precios en la planilla excel.";
                    return;
                }
                else
                {
                    try
                    {
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista1.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista2.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista3.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista4.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista5.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista6.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista7.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista8.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista9.Trim()));
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista10.Trim()));
                    }
                    catch
                    {
                    }
                }

                if (listasPrecio.Count == 0)
                {
                    MensajeLabel.Text = "Proceso cancelado: No hay ninguna Lista de precios definida.";
                    return;
                }
                else
                {
                    ViewState["ListasPrecio"] = listasPrecio;
                    //Leer detalle del excel
                    provider = new ExcelStorage(typeof(ProductosExcel));
                    provider.StartRow = 3;
                    provider.StartColumn = 1;
                    provider.FileName = Server.MapPath("Temp\\ExcelAProcesar.xls");
                    ProductosExcel[] resDet = (ProductosExcel[])provider.ExtractRecords();
                    //Completar la Matriz de Precios
                    CrearYCompletarMatrizDePrecios(listasPrecio, resDet);
                }

                //Actualizar los precios de la MatrizDePrecios
                DataTable dt = (DataTable)ViewState["MatrizDePrecios"];
                List<Entidades.ListaPrecio> listasPrecioNew = (List<Entidades.ListaPrecio>)ViewState["ListasPrecio"];
                RN.Precio.ImpactarMatriz(listasPrecioNew, dt, sesion);
                MensajeLabel.Enabled = true;
                MensajeLabel.Text = "PROCESO CONCLUIDO SATISFACTORIAMENTE.\n";
                string listasImp = "Listas importadas: ";
                foreach (Entidades.ListaPrecio lp in listasPrecio)
                {
                    if (listasImp != "Listas importadas: ")
                    {
                        listasImp += ", ";
                    }
                    listasImp += lp.Id;
                }
                MensajeLabel.Text += listasImp + "\n";
                MensajeLabel.Text += "Cantidad total de artículos: " + dt.Rows.Count;
                MensajeLabel.Enabled = false;
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }

        }

        private void CrearYCompletarMatrizDePrecios(List<Entidades.ListaPrecio> llp, ProductosExcel[] resDet)
        {
            DataTable matrizDePrecios = new DataTable("MatrizDePrecios");
            matrizDePrecios.Columns.Add(new DataColumn("IdArticulo", typeof(string)));
            matrizDePrecios.Columns.Add(new DataColumn("DescrArticulo", typeof(string)));
            foreach (Entidades.ListaPrecio lp in llp)
            {
                matrizDePrecios.Columns.Add(new DataColumn(lp.Id, typeof(string)));
            }
            for (int i = 0; i < resDet.Length; i++)
            {
                
                DataRow dr = matrizDePrecios.NewRow(); 
                dr[0] = resDet[i].IdArticulo;
                dr[1] = resDet[i].DescrArticulo;
                if (llp.Count >= 1)
                {
                    dr[2] = resDet[i].Lista1;
                }
                if (llp.Count >= 2)
                {
                    dr[3] = resDet[i].Lista2;
                }
                if (llp.Count >= 3)
                {
                    dr[4] = resDet[i].Lista3;
                }
                if (llp.Count >= 4)
                {
                    dr[5] = resDet[i].Lista4;
                }
                if (llp.Count >= 5)
                {
                    dr[6] = resDet[i].Lista5;
                }
                if (llp.Count >= 6)
                {
                    dr[7] = resDet[i].Lista6;
                }
                if (llp.Count >= 7)
                {
                    dr[8] = resDet[i].Lista7;
                }
                if (llp.Count >= 8)
                {
                    dr[9] = resDet[i].Lista8;
                }
                if (llp.Count >= 9)
                {
                    dr[10] = resDet[i].Lista9;
                }
                if (llp.Count >= 10)
                {
                    dr[11] = resDet[i].Lista10;
                }
                matrizDePrecios.Rows.Add(dr);
            }
            ViewState["MatrizDePrecios"] = matrizDePrecios;
        }
    }
}