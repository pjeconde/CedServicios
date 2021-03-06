﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class SolicPermisoAdminUN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CUITTextBox.Focus();
            }
        }
        protected void SolicitarButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                if (sesion.UsuarioDemo == true)
                {
                    Response.Redirect("~/MensajeUsuarioDEMO.aspx");
                }
                Entidades.Cuit cuit = new Entidades.Cuit();
                cuit.Nro = CUITTextBox.Text;
                RN.Cuit.Leer(cuit, sesion);

                Entidades.UN un = new Entidades.UN();
                un.Cuit = cuit.Nro;
                un.Id = Convert.ToInt32(IdUNDropDownList.SelectedValue);
                RN.UN.Leer(un, sesion);

                string referenciaAAprobadores = String.Empty;
                RN.Permiso.SolicitarPermisoParaUsuario(cuit, un, out referenciaAAprobadores, sesion);
                CUITTextBox.Enabled = false;
                LeerListaUNsButton.Enabled = false;
                IdUNDropDownList.Enabled = false;
                SolicitarButton.Enabled = false;
                SalirButton.Text = "Salir";
                Funciones.PersonalizarControlesMaster(Master, true, sesion);
                if (referenciaAAprobadores != String.Empty)
                    MensajeLabel.Text = "El permiso fue enviado para su aprobación.<br />Autorizador(es): " + referenciaAAprobadores;
                else
                    MensajeLabel.Text = "El permiso fue registrado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
        protected void LeerListaUNsButton_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Cuit cuit = new Entidades.Cuit();
                cuit.Nro = CUITTextBox.Text;
                if (Funciones.SessionTimeOut(Session))
                {
                    Response.Redirect("~/SessionTimeout.aspx");
                }
                else
                {
                    Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                    RN.Cuit.Leer(cuit, sesion);
                    IdUNDropDownList.DataSource = RN.UN.ListaVigentesPorCuit(cuit, sesion);
                    DataBind();
                }
            }
            catch (Exception ex)
            {
                MensajeLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(((Entidades.Sesion)Session["Sesion"]).Usuario.PaginaDefault((Entidades.Sesion)Session["Sesion"]));
        }
    }
}