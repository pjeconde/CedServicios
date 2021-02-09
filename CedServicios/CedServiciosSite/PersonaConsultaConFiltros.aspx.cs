﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class PersonaConsultaConFiltros : System.Web.UI.Page
    {
        List<Entidades.Persona> persona = new List<Entidades.Persona>();

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
                    EstadoDropDownList.DataSource = RN.Estado.ListaPersonas(true);
                    DataBind();
                    EstadoDropDownList.SelectedValue = String.Empty;
                }
            }
        }

        protected void ClientePagingGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                Entidades.Sesion sesion = ((Entidades.Sesion)Session["Sesion"]);
                ClientePagingGridView.PageIndex = e.NewPageIndex;
                ViewState["GridPageIndex"] = e.NewPageIndex; 
                List<Entidades.Persona> lista;
                int CantidadFilas = 0;
                lista = RN.Persona.ListaPaging(out CantidadFilas, ClientePagingGridView.PageIndex, ClientePagingGridView.OrderBy, sesion.Cuit.Nro, NroDocTextBox.Text, RazSocTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ClientePagingGridView.VirtualItemCount = CantidadFilas;
                ClientePagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                ViewState["lista"] = lista;
                ClientePagingGridView.DataSource = lista;
                ClientePagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                //CedeiraUIWebForms.Excepciones.Redireccionar(ex, "~/Excepcion.aspx");
                MensajeLabel.Text = ex.Message;
            }
        }
        protected void ClientePagingGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                DesSeleccionarFilas();
                Entidades.Sesion sesion = ((Entidades.Sesion)Session["Sesion"]);
                List<Entidades.Persona> lista = new List<Entidades.Persona>();
                int CantidadFilas = 0;
                lista = RN.Persona.ListaPaging(out CantidadFilas, ClientePagingGridView.PageIndex, ClientePagingGridView.OrderBy, sesion.Cuit.Nro, NroDocTextBox.Text, RazSocTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ViewState["lista"] = lista;
                ClientePagingGridView.DataSource = (List<Entidades.Persona>)ViewState["lista"];
                ClientePagingGridView.DataBind();
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = ex.Message;
            }
        }
        protected void ClientePagingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //Color por estado distinto a Vigente
                if (e.Row.Cells[14].Text != "Vigente")
                {
                    e.Row.ForeColor = Color.Red;
                }
            }
        }
        private void DesSeleccionarFilas()
        {
            ClientePagingGridView.SelectedIndex = -1;
        }

        protected void ClientePagingGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Entidades.Persona persona = new Entidades.Persona();
            try
            {
                int item = Convert.ToInt32(e.CommandArgument);
                List<Entidades.Persona> lista = (List<Entidades.Persona>)ViewState["lista"];
                persona = lista[item];
            }
            catch
            {
                //Selecciono algo del Header. No hago nada con el CommandArgument.
            }
            switch (e.CommandName)
            {
                case "Detalle":
                    TituloConfirmacionLabel.Text = "Consulta detallada";
                    //CancelarButton.Text = "Salir";
                    CUITLabel.Text = persona.Cuit;
                    TipoDocLabel.Text = persona.DocumentoIdTipoDoc;
                    NroDocLabel.Text = persona.DocumentoNro.ToString();
                    RazSocLabel.Text = persona.RazonSocial;
                    CalleLabel.Text = persona.Domicilio.Calle;
                    NroLabel.Text = persona.Domicilio.Nro;
                    PisoLabel.Text = persona.Domicilio.Piso;
                    DeptoLabel.Text = persona.Domicilio.Depto;
                    LocalidadLabel.Text = persona.Domicilio.Localidad;
                    CodPostLabel.Text = persona.Domicilio.CodPost;
                    EstadoLabel.Text = persona.Estado;
                    ContactoLabel.Text = persona.ContactoNombre;
                    if (ContactoLabel.Text.Length > 0 && persona.ContactoTelefono.Length > 0)
                    { ContactoLabel.Text += " " + persona.ContactoTelefono; }
                    if (ContactoLabel.Text.Length > 0 && persona.ContactoEmail.Length > 0)
                    { ContactoLabel.Text += " " + persona.ContactoEmail; }
                    if (persona.EsCliente)
                    { ClienteLabel.Text = "SI"; } else { ClienteLabel.Text = "NO"; }
                    if (persona.EsProveedor)
                    { ProveedorLabel.Text = "SI"; } else { ProveedorLabel.Text = "NO"; }
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(@"<script type='text/javascript'>");
                    sb.Append("$('#DetalleModal').modal('show');");
                    sb.Append(@"</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "DetalleScript", sb.ToString(), false);
                    break;
            }
            bindGrillaPersona();
        }
        protected void ClientePagingGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            ClientePagingGridView.EditIndex = e.NewEditIndex;
            ClientePagingGridView.DataSource = ViewState["lista"];
            ClientePagingGridView.DataBind();
        }
        protected void ClientePagingGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            ClientePagingGridView.EditIndex = -1;
            ClientePagingGridView.DataSource = ViewState["lista"];
            ClientePagingGridView.DataBind();
        }
        protected void ClientePagingGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                ClientePagingGridView.EditIndex = -1;
                ClientePagingGridView.DataSource = ViewState["lista"];
                ClientePagingGridView.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
            }
        }
        protected void ClientePagingGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void ClientePagingGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
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
                List<Entidades.Persona> lista = new List<Entidades.Persona>();
                MensajeLabel.Text = String.Empty;
                int CantidadFilas = 0;
                lista = RN.Persona.ListaPaging(out CantidadFilas, ClientePagingGridView.PageIndex, ClientePagingGridView.OrderBy, sesion.Cuit.Nro, NroDocTextBox.Text, RazSocTextBox.Text, EstadoDropDownList.SelectedValue, Session.SessionID, (Entidades.Sesion)Session["Sesion"]);
                ClientePagingGridView.VirtualItemCount = CantidadFilas;
                ClientePagingGridView.PageSize = sesion.Usuario.CantidadFilasXPagina;
                if (lista.Count == 0)
                {
                    ClientePagingGridView.DataSource = null;
                    ClientePagingGridView.DataBind();
                    MensajeLabel.Text = "No se han encontrado Personas que satisfagan la busqueda";
                }
                else
                {
                    ClientePagingGridView.DataSource = lista;
                    ViewState["lista"] = lista;
                    ClientePagingGridView.DataBind();
                }
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }

        private void bindGrillaPersona()
        {
            ClientePagingGridView.PageIndex = Convert.ToInt32(ViewState["GridPageIndex"]);
            ClientePagingGridView.DataSource = ViewState["lista"];
            ClientePagingGridView.DataBind();
        }

    }
}