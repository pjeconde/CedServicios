﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class UsuarioOlvidoPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PasswordNuevaTextBox.Attributes.Add("value", PasswordNuevaTextBox.Text);
            ConfirmacionPasswordNuevaTextBox.Attributes.Add("value", ConfirmacionPasswordNuevaTextBox.Text);
            if (!IsPostBack)
            {
                IdUsuarioTextBox.Focus();
            }
        }
        protected void TextBox_TextChanged(object sender, EventArgs e)
        {
            MsgErrorLabel.Text = String.Empty;
        }
        protected void SolicitarPreguntaButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdUsuarioTextBox.Text == String.Empty)
                {
                    MsgErrorLabel.Text = "Id.Usuario no informado.";
                }
                else
                {
                    if (EmailTextBox.Text == String.Empty)
                    {
                        MsgErrorLabel.Text = "Email no informado.";
                    }
                    else
                    {
                        Entidades.Usuario usuario = new Entidades.Usuario();
                        usuario.Id = IdUsuarioTextBox.Text;
                        RN.Usuario.Leer(usuario, (Entidades.Sesion)Session["Sesion"]);
                        if (usuario.Email.ToLower() != EmailTextBox.Text.ToLower())
                        {
                            MsgErrorLabel.Text = "No hay ninguna cuenta en la que el Id.Usuario y el Email ingresados estén relacionados.";
                        }
                        else
                        {
                            MsgErrorLabel.Text = "";
                            IdUsuarioTextBox.Enabled = false;
                            EmailTextBox.Enabled = false;
                            SolicitarPreguntaButton.Enabled = false;
                            PreguntaLabel.Text = "¿" + usuario.Pregunta + "?";
                            ViewState["respuesta"] = usuario.Respuesta;
                            RespuestaTextBox.Enabled = true;
                            SolicitarNuevaPasswordButton.Enabled = true;
                            RespuestaTextBox.Focus();
                        }
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (EX.Validaciones.ElementoInexistente)
            {
                MsgErrorLabel.Text = "No hay ninguna cuenta con el Id.Usuario solicitado.";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
        protected void SolicitarNuevaPasswordButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (RespuestaTextBox.Text == String.Empty)
                {
                    MsgErrorLabel.Text = "Respuesta no informada.";
                }
                else
                {
                    if (RespuestaTextBox.Text.ToLower() != ViewState["respuesta"].ToString().ToLower())
                    {
                        MsgErrorLabel.Text = "Respuesta incorrecta.";
                    }
                    else
                    {
                        MsgErrorLabel.Text = "";
                        RespuestaTextBox.Enabled = false;
                        SolicitarNuevaPasswordButton.Enabled = false;
                        PasswordNuevaTextBox.Enabled = true;
                        ConfirmacionPasswordNuevaTextBox.Enabled = true;
                        AceptarButton.Enabled = true;
                        PasswordNuevaTextBox.Focus();
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (EX.Validaciones.ElementoInexistente)
            {
                MsgErrorLabel.Text = "No hay ninguna cuenta con el Id.Usuario solicitado.";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
        protected void AceptarButton_Click(object sender, EventArgs e)
        {
            try
            {
                MsgErrorLabel.Text = String.Empty;
                Entidades.Usuario usuario = new Entidades.Usuario();
                usuario.Id = IdUsuarioTextBox.Text;
                RN.Usuario.Leer(usuario, (Entidades.Sesion)Session["Sesion"]);
                usuario.Password = PasswordNuevaTextBox.Text + "X";
                RN.Usuario.CambiarPassword(usuario, usuario.Password, PasswordNuevaTextBox.Text, ConfirmacionPasswordNuevaTextBox.Text, (Entidades.Sesion)Session["Sesion"]);
                PasswordNuevaTextBox.Enabled = false;
                ConfirmacionPasswordNuevaTextBox.Enabled = false;
                AceptarButton.Visible = false;
                CancelarButton.Visible = false;
                MsgErrorLabel.Text = "La Contraseña fue registrada satisfactoriamente.<br />Para iniciar una sesión de trabajo, deberá identificarse en la página de inicio.";
            }
            catch (System.Threading.ThreadAbortException)
            {
                Trace.Warn("Thread abortado");
            }
            catch (EX.Usuario.PasswordNoMatch)
            {
                MsgErrorLabel.Text = "Contraseña actual incorrecta";
            }
            catch (EX.Usuario.PasswordYConfirmacionNoCoincidente)
            {
                MsgErrorLabel.Text = "La Contraseña nueva no coincide con su Confirmación";
            }
            catch (Exception ex)
            {
                MsgErrorLabel.Text = EX.Funciones.Detalle(ex);
            }
        }
    }
}