using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class InicioFEA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string panel = Page.Request.QueryString["Valor"];
            panFEA.Visible = false;
            panFEA2.Visible = false;
            panFEA3.Visible = false;
            if (panel == "panFEA")
            {
                panFEA.Visible = true;
            }
            else if (panel == "panFEA2")
            {
                panFEA2.Visible = true;
            }
            else if (panel == "panFEA3")
            {
                panFEA3.Visible = true;
            }
        }
        protected void MultiCuitLinkButton_Click(object sender, EventArgs e)
        {
            Espacio.Visible = true;
            AclaracionTituloLabel.Text = "Entorno Multi-CUIT";
            AclaracionDetalleLabel.Text = "<p>Con la misma Cuenta se pueden operar uno o más CUITs.</p><br />";
        }
        protected void MultiUNLinkButton_Click(object sender, EventArgs e)
        {
            Espacio.Visible = true;
            AclaracionTituloLabel.Text = "Entorno Multi-Unidad de Negocio";
            AclaracionDetalleLabel.Text = "<p>Para cada CUIT se puede definir una o más Unidades de Negocio (*).<br /><br />(*) Concepto asimilable al de 'sucursal'</p><br />";
        }
        protected void MultiUsuarioLinkButton_Click(object sender, EventArgs e)
        {
            Espacio.Visible = true;
            AclaracionTituloLabel.Text = "Entorno Multi-Usuario";
            AclaracionDetalleLabel.Text = "<p>Uno o más usuarios pueden compartir su trabajo dentro de su propio grupo.<br />Los usuarios administradores (de CUITs y de Unidades de Negocio), serán<br />los responsables de autorizar el acceso a los usuarios operadores.</p><br />";
        }
    }
}