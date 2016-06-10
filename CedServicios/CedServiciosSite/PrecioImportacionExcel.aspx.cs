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
using FileHelpers.ExcelNPOIStorage;

namespace CedServicios.Site
{
    [DelimitedRecord(";")] 
    public class ProductosExcel
    {
        public string IdArticulo;
        public string DescrArticulo;
        
        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista01;
        
        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista02;
        
        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista03;

        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista04;

        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista05;

        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista06;

        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista07;
        
        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista08;
        
        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
        public string Lista09;

        [FieldOptional]
        [FieldNullValue(typeof(string), "")]
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
                            FileStream file;
                            if (FormatoCSVRadioButton.Checked)
                            {
                                if (XMLFileUpload.FileName.Substring(XMLFileUpload.FileName.Length - 4, 4) == ".csv")
                                {
                                    file = new FileStream(Server.MapPath("TempExcel\\" + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "-" + Session.SessionID + "-Precios.csv"), FileMode.Create, FileAccess.Write);
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Problemas para procesar la planilla de precios. Mensaje: La planilla tiene que ser formato ('.csv')"), false);
                                    return;
                                }
                            }
                            else
                            {
                                if (XMLFileUpload.FileName.Substring(XMLFileUpload.FileName.Length - 4, 4) == ".xls")
                                {
                                    file = new FileStream(Server.MapPath("TempExcel\\" + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "-" + Session.SessionID + "-Precios.xls"), FileMode.Create, FileAccess.Write);
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Problemas para procesar la planilla de precios. Mensaje: La planilla tiene que ser formato ('.xls')"), false);
                                    return;
                                }
                            }
                            ms.WriteTo(file);
                            file.Close();
                            ms.Close();
                            LeerExcel();
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, GetType(), "Message", Funciones.TextoScript("Problemas para procesar la planilla de precios. Mensaje: " + ex.Message), false);
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
                ProductosExcel[] resCab;
                if (FormatoCSVRadioButton.Checked)
                {
                    FileStorage provider = new FileStorage(typeof(ProductosExcel), Server.MapPath("TempExcel\\" + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "-" + Session.SessionID + "-Precios.csv"));
                    //ExcelNPOIStorage provider = new ExcelNPOIStorage(typeof(ProductosExcel));
                    //provider..StartRow = 0;
                    //provider.StartColumn = 0;
                    resCab = (ProductosExcel[])provider.ExtractRecords();
                }
                else
                {
                    ExcelNPOIStorage provider = new ExcelNPOIStorage(typeof(ProductosExcel));
                    provider.StartRow = 0;
                    provider.StartColumn = 0;
                    provider.FileName = Server.MapPath("TempExcel\\" + ((Entidades.Sesion)Session["Sesion"]).Cuit.Nro + "-" + Session.SessionID + "-Precios.xls");
                    resCab = (ProductosExcel[])provider.ExtractRecords();
                }

                List<Entidades.ListaPrecio> listasPrecio = new List<Entidades.ListaPrecio>();
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                
                //if (resCab.Length > 1)
                //{
                //    MensajeLabel.Text = "Proceso cancelado: La cabecera del archivo excel debe tener un solo renglón.";
                //    return;
                //}
                if (resCab[0].Lista01 == null || resCab[0].Lista01.Trim().Equals(string.Empty))
                {
                    MensajeLabel.Text = "Proceso cancelado: No está informada la primer lista de precios en la planilla excel.";
                    return;
                }
                else
                {
                    try
                    {
                        listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista01.Trim()));
                        if (!resCab[0].Lista02.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista02.Trim())); }
                        if (!resCab[0].Lista03.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista03.Trim())); }
                        if (!resCab[0].Lista04.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista04.Trim())); }
                        if (!resCab[0].Lista05.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista05.Trim())); }
                        if (!resCab[0].Lista06.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista06.Trim())); }
                        if (!resCab[0].Lista07.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista07.Trim())); }
                        if (!resCab[0].Lista08.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista08.Trim())); }
                        if (!resCab[0].Lista09.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista09.Trim())); }
                        if (!resCab[0].Lista10.Trim().Equals(String.Empty)) { listasPrecio.Add(new Entidades.ListaPrecio(resCab[0].Lista10.Trim())); }
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

                ViewState["ListasPrecio"] = listasPrecio;
                
                //Leer detalle del excel
                //ExcelNPOIStorage provider = new ExcelNPOIStorage(typeof(ProductosExcel));
                //provider.StartRow = 3;
                //provider.StartColumn = 1;
                //provider.FileName = Server.MapPath("Temp\\ExcelAProcesar.xlsx");
                //ProductosExcel[] resDet = (ProductosExcel[])provider.ExtractRecords();
                
                //Completar la Matriz de Precios
                CrearYCompletarMatrizDePrecios(listasPrecio, resCab);

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
            for (int i = 1; i < resDet.Length; i++)
            {
                
                DataRow dr = matrizDePrecios.NewRow(); 
                dr[0] = resDet[i].IdArticulo;
                dr[1] = resDet[i].DescrArticulo;
                if (llp.Count >= 1)
                {
                    dr[2] = resDet[i].Lista01;
                }
                if (llp.Count >= 2)
                {
                    dr[3] = resDet[i].Lista02;
                }
                if (llp.Count >= 3)
                {
                    dr[4] = resDet[i].Lista03;
                }
                if (llp.Count >= 4)
                {
                    dr[5] = resDet[i].Lista04;
                }
                if (llp.Count >= 5)
                {
                    dr[6] = resDet[i].Lista05;
                }
                if (llp.Count >= 6)
                {
                    dr[7] = resDet[i].Lista06;
                }
                if (llp.Count >= 7)
                {
                    dr[8] = resDet[i].Lista07;
                }
                if (llp.Count >= 8)
                {
                    dr[9] = resDet[i].Lista08;
                }
                if (llp.Count >= 9)
                {
                    dr[10] = resDet[i].Lista09;
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