using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class DatosEmailAvisoComprobantePersona : System.Web.UI.UserControl
    {
        protected enum Tratamiento { Add, Edit }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public Entidades.DatosEmailAvisoComprobantePersona Datos
        {
            set
            {
                ViewState["datosEmailAvisoComprobantePersona"] = value;
                ActivoCheckBox.Checked = value.Activo;
                DeTextBox.Text = value.De;
                destinatariosFrecuentesGridView.DataSource = value.DestinatariosFrecuentes;
                destinatariosFrecuentesGridView.DataBind();
                CcoTextBox.Text = value.Cco;
                AsuntoTextBox.Text = value.Asunto;
                CuerpoTextBox.Text = value.Cuerpo;
            }
            get
            {
                Entidades.DatosEmailAvisoComprobantePersona datosEmailAvisoComprobantePersona = ((Entidades.DatosEmailAvisoComprobantePersona)ViewState["datosEmailAvisoComprobantePersona"]);
                datosEmailAvisoComprobantePersona.Activo = ActivoCheckBox.Checked;
                datosEmailAvisoComprobantePersona.De = DeTextBox.Text;
                EliminoFilaAutomatica(datosEmailAvisoComprobantePersona);
                datosEmailAvisoComprobantePersona.Cco = CcoTextBox.Text;
                datosEmailAvisoComprobantePersona.Asunto = AsuntoTextBox.Text;
                datosEmailAvisoComprobantePersona.Cuerpo = CuerpoTextBox.Text;
                return datosEmailAvisoComprobantePersona;
            }
        }
        public bool Enabled
        {
            set
            {
                ActivoCheckBox.Enabled = value;
                DeTextBox.Enabled = value;
                destinatariosFrecuentesGridView.Enabled = value;
                CcoTextBox.Enabled = value;
                AsuntoTextBox.Enabled = value;
                CuerpoTextBox.Enabled = value;
            }
            get
            {
                return ActivoCheckBox.Enabled;
            }
        }
        protected void destinatariosFrecuentesGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            destinatariosFrecuentesGridView.EditIndex = -1;
            destinatariosFrecuentesGridView.DataSource = ((Entidades.DatosEmailAvisoComprobantePersona)ViewState["datosEmailAvisoComprobantePersona"]).DestinatariosFrecuentes;
            destinatariosFrecuentesGridView.DataBind();
            BindearDropDownLists();
        }
        protected void destinatariosFrecuentesGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AdddestinatariosFrecuentes"))
            {
                try
                {
                    Entidades.DestinatarioFrecuente destinatarioFrecuente = new Entidades.DestinatarioFrecuente();
                    destinatarioFrecuente.Id = ((TextBox)destinatariosFrecuentesGridView.FooterRow.FindControl("txtid")).Text;
                    ValidarDestinatarioFrecuenteId(Tratamiento.Add, destinatarioFrecuente.Id);
                    destinatarioFrecuente.Para = ((TextBox)destinatariosFrecuentesGridView.FooterRow.FindControl("txtpara")).Text;
                    ValidarDestinatarioFrecuentePara(Tratamiento.Add, destinatarioFrecuente.Para);
                    destinatarioFrecuente.Cc = ((TextBox)destinatariosFrecuentesGridView.FooterRow.FindControl("txtcc")).Text;
                    ValidarDestinatarioFrecuenteCc(Tratamiento.Add, destinatarioFrecuente.Cc);
                    ((Entidades.DatosEmailAvisoComprobantePersona)ViewState["datosEmailAvisoComprobantePersona"]).DestinatariosFrecuentes.Add(destinatarioFrecuente);
                    //Me fijo si elimino la fila automática
                    EliminoFilaAutomatica(((Entidades.DatosEmailAvisoComprobantePersona)ViewState["datosEmailAvisoComprobantePersona"]));
                    //Saco de edición la fila que estén modificando
                    if (!destinatariosFrecuentesGridView.EditIndex.Equals(-1))
                    {
                        destinatariosFrecuentesGridView.EditIndex = -1;
                    }

                    destinatariosFrecuentesGridView.DataSource = ((Entidades.DatosEmailAvisoComprobantePersona)ViewState["datosEmailAvisoComprobantePersona"]).DestinatariosFrecuentes;
                    destinatariosFrecuentesGridView.DataBind();
                    BindearDropDownLists();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Parent.Page, this.GetType(), "Message", "alert('" + ex.Message.ToString().Replace("'", "") + "');", true);
                }
            }
        }
        protected void EliminoFilaAutomatica(Entidades.DatosEmailAvisoComprobantePersona DatosEmailAvisoComprobantePersona)
        {
            if (DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes.Count >0 && DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes[0].Id.Equals(string.Empty))
            {
                DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes.Remove(DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes[0]);
            }
        }
        protected void destinatariosFrecuentesGridView_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", Funciones.TextoScript(e.Exception.Message), false);
                e.ExceptionHandled = true;
            }
        }
        protected void destinatariosFrecuentesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                List<Entidades.DestinatarioFrecuente> destinatariosFrecuentes = ((Entidades.DatosEmailAvisoComprobantePersona)ViewState["datosEmailAvisoComprobantePersona"]).DestinatariosFrecuentes;
                Entidades.DestinatarioFrecuente destinatarioFrecuente = destinatariosFrecuentes[e.RowIndex];
                destinatariosFrecuentes.Remove(destinatarioFrecuente);
                if (destinatariosFrecuentes.Count.Equals(0))
                {
                    destinatariosFrecuentes.Add(new Entidades.DestinatarioFrecuente(string.Empty, string.Empty, string.Empty));
                }
                destinatariosFrecuentesGridView.EditIndex = -1;
                destinatariosFrecuentesGridView.DataSource = destinatariosFrecuentes;
                destinatariosFrecuentesGridView.DataBind();
                BindearDropDownLists();
            }
            catch
            {
            }
        }
        protected void destinatariosFrecuentesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            destinatariosFrecuentesGridView.EditIndex = e.NewEditIndex;

            destinatariosFrecuentesGridView.DataSource = ((Entidades.DatosEmailAvisoComprobantePersona)ViewState["datosEmailAvisoComprobantePersona"]).DestinatariosFrecuentes;
            destinatariosFrecuentesGridView.DataBind();
            BindearDropDownLists();
        }
        protected void destinatariosFrecuentesGridView_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                ScriptManager.RegisterClientScriptBlock(this.Parent.Page, this.GetType(), "Message", "alert('" + e.Exception.Message.ToString().Replace("'", "") + "');", true);
                e.ExceptionHandled = true;
            }
        }
        protected void destinatariosFrecuentesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                List<Entidades.DestinatarioFrecuente> destinatariosFrecuentes = ((Entidades.DatosEmailAvisoComprobantePersona)ViewState["datosEmailAvisoComprobantePersona"]).DestinatariosFrecuentes;
                Entidades.DestinatarioFrecuente destinatarioFrecuente = destinatariosFrecuentes[e.RowIndex];
                string id = ((TextBox)destinatariosFrecuentesGridView.Rows[e.RowIndex].FindControl("txtid")).Text;
                ValidarDestinatarioFrecuenteId(Tratamiento.Edit, id);
                string para = ((TextBox)destinatariosFrecuentesGridView.Rows[e.RowIndex].FindControl("txtpara")).Text;
                ValidarDestinatarioFrecuentePara(Tratamiento.Edit, para);
                string cc = ((TextBox)destinatariosFrecuentesGridView.Rows[e.RowIndex].FindControl("txtcc")).Text;
                ValidarDestinatarioFrecuenteCc(Tratamiento.Edit, cc);
                destinatarioFrecuente.Id = id;
                destinatarioFrecuente.Para = para;
                destinatarioFrecuente.Cc = cc;
                destinatariosFrecuentesGridView.EditIndex = -1;
                destinatariosFrecuentesGridView.DataSource = destinatariosFrecuentes;
                destinatariosFrecuentesGridView.DataBind();
                BindearDropDownLists();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Message", Funciones.TextoScript(ex.Message), false);
            }
        }
        protected void BindearDropDownLists()
        {
        }
        protected void destinatariosFrecuentesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            GridViewRow gvr = e.Row;
            if (gvr.RowType == DataControlRowType.Header)
            {
                ((System.Web.UI.WebControls.TableRow)(gvr)).Cells[3].ColumnSpan = 2;
                ((System.Web.UI.WebControls.TableRow)(gvr)).Cells[4].Visible = false;
            }
        }
        protected void ValidarDestinatarioFrecuenteId(Tratamiento Tratamiento, string Valor)
        {
            if (Valor.Equals(string.Empty))
            {
                if (Tratamiento.ToString() == "Add")
                    throw new Exception("Destinatario frecuente no agregado: campo 'Id' sin informar");
                else
                    throw new Exception("Destinatario frecuente no actualizado: campo 'Id' sin informar");
            }
        }
        protected void ValidarDestinatarioFrecuentePara(Tratamiento Tratamiento, string Valor)
        {
            if (Valor.Equals(string.Empty))
            {
                if (Tratamiento.ToString() == "Add")
                    throw new Exception("Destinatario frecuente no agregado: campo 'Para' sin informar");
                else
                    throw new Exception("Destinatario frecuente no actualizado: campo 'Para' sin informar");
            }
            try
            {
                RN.Funciones.ValidarListaDeMails(Valor);
            }
            catch (Exception ex)
            {
                if (Tratamiento.ToString() == "Add")
                    throw new Exception("Destinatario frecuente no agregado: " + ex.Message + "º dirección de email, en campo 'Para', con formato inválido");
                else
                    throw new Exception("Destinatario frecuente no actualizado: " + ex.Message + "º dirección de email, en campo 'Para', con formato inválido");
            }
        }
        protected void ValidarDestinatarioFrecuenteCc(Tratamiento Tratamiento, string Valor)
        {
            if (!Valor.Equals(string.Empty))
            {
                try
                {
                    RN.Funciones.ValidarListaDeMails(Valor);
                }
                catch (Exception ex)
                {
                    if (Tratamiento.ToString() == "Add")
                        throw new Exception("Destinatario frecuente no agregado: " + ex.Message + "º dirección de email, en campo 'Cc', con formato inválido");
                    else
                        throw new Exception("Destinatario frecuente no actualizado: " + ex.Message + "º dirección de email, en campo 'Cc', con formato inválido");
                }
            }
        }
    }
}