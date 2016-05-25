using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class ListaPrecioDefaultPersona : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public List<Entidades.ListaPrecio> ListasPrecio
        {
            set
            {
                ViewState["ListasPrecio"] = value;
                IdListaPrecioDropDownList.DataSource = value;
                IdListaPrecioDropDownList.DataBind();
            }
            get
            {
                return (List<Entidades.ListaPrecio>)ViewState["ListasPrecio"];
            }
        }
        public string IdListaPrecio
        {
            get
            {
                return IdListaPrecioDropDownList.SelectedValue;
            }
            set
            {
                IdListaPrecioDropDownList.SelectedValue = value;
            }
        }
        public bool Enabled
        {
            set
            {
                IdListaPrecioDropDownList.Enabled = value;
            }
        }
    }
}