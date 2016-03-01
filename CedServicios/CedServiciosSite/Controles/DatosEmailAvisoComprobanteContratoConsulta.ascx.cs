using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class DatosEmailAvisoComprobanteContratoConsulta : System.Web.UI.UserControl
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
                IdDestinatarioFrecuenteTextBox.Text = value.DestinatarioFrecuente.Id;
                IdDestinatarioFrecuenteTextBox.ToolTip = "Para: " + value.DestinatarioFrecuente.Para;
                AsuntoTextBox.Text = value.Asunto;
                CuerpoTextBox.Text = value.Cuerpo;
            }
        }
    }
}