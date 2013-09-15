using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace CedServicios.Site
{
    public partial class Migracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RefrescarGrilla();
                    if (((DataTable)ViewState["CuentasNoMigradas"]).Rows.Count == 0)
                    {
                        MensajeLabel.Text = "No hay Cuentas para migrar";
                        CopiarTodosButton.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MensajeLabel.Text = EX.Funciones.Detalle(ex);
                }
            }
        }
        protected void CuentasGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    DataRow cuenta = ((DataTable)ViewState["CuentasNoMigradas"]).Rows[item];
                    switch (e.CommandName)
                    {
                        case "Copiar":
                            RN.Migracion.Copiar_Cuenta(cuenta["IdCuenta"].ToString(), sesion);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
            finally
            {
                RefrescarGrilla();
            }
        }
        protected void RefrescarGrilla()
        {
            if (Funciones.SessionTimeOut(Session))
            {
                Response.Redirect("~/SessionTimeout.aspx");
            }
            else
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                ViewState["CuentasNoMigradas"] = RN.Migracion.CuentasNoMigradas(sesion);
                CuentasGridView.DataSource = (DataTable)ViewState["CuentasNoMigradas"];
                CuentasGridView.DataBind();
            }
        }
        protected void CuentasGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[7].Text == "Suspend")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        protected void CopiarTodosButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    MensajeLabel.Text = RN.Migracion.CopiarTodasLasCuentas(sesion);
                    RefrescarGrilla();
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
    }
}