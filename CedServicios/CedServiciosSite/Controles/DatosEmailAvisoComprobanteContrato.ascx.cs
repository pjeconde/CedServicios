using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class DatosEmailAvisoComprobanteContrato : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public Entidades.DatosEmailAvisoComprobanteContrato Datos
        {
            set
            {
                ViewState["datosEmailAvisoComprobanteContrato"] = value;
                ActivoCheckBox.Checked = value.Activo;
                IdDestinatarioFrecuenteDropDownList.DataSource = value.DestinatariosFrecuentes;
                IdDestinatarioFrecuenteDropDownList.DataBind();
                try
                {
                    if (value.DestinatariosFrecuentes.Count != 0) IdDestinatarioFrecuenteDropDownList.SelectedValue = value.DestinatarioFrecuente.Id;
                }
                catch
                {
                }
                AsuntoTextBox.Text = value.Asunto;
                CuerpoTextBox.Text = value.Cuerpo;
            }
            get
            {
                Entidades.DatosEmailAvisoComprobanteContrato datosEmailAvisoComprobanteContrato = ((Entidades.DatosEmailAvisoComprobanteContrato)ViewState["datosEmailAvisoComprobanteContrato"]);
                datosEmailAvisoComprobanteContrato.Activo = ActivoCheckBox.Checked;
                datosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Id = IdDestinatarioFrecuenteDropDownList.SelectedValue;
                datosEmailAvisoComprobanteContrato.Asunto = AsuntoTextBox.Text;
                datosEmailAvisoComprobanteContrato.Cuerpo = CuerpoTextBox.Text;
                return datosEmailAvisoComprobanteContrato;
            }
        }
        public bool Enabled
        {
            set
            {
                ActivoCheckBox.Enabled = value;
                IdDestinatarioFrecuenteDropDownList.Enabled = value;
                AsuntoTextBox.Enabled = value;
                CuerpoTextBox.Enabled = value;
            }
            get
            {
                return ActivoCheckBox.Enabled;
            }
        }
        protected void BindearDropDownLists()
        {
        }
    }
}