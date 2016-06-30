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
        public List<Entidades.ListaPrecio> ListasPrecioVenta
        {
            set
            {
                ViewState["ListasPrecioVenta"] = value;
                IdListaPrecioVentaDropDownList.DataSource = value;
                IdListaPrecioVentaDropDownList.DataBind();
            }
            get
            {
                return (List<Entidades.ListaPrecio>)ViewState["ListasPrecioVenta"];
            }
        }
        public List<Entidades.ListaPrecio> ListasPrecioCompra
        {
            set
            {
                ViewState["ListasPrecioCompra"] = value;
                IdListaPrecioCompraDropDownList.DataSource = value;
                IdListaPrecioCompraDropDownList.DataBind();
            }
            get
            {
                return (List<Entidades.ListaPrecio>)ViewState["ListasPrecioCompra"];
            }
        }
        public string IdListaPrecioVenta
        {
            get
            {
                return IdListaPrecioVentaDropDownList.SelectedValue;
            }
            set
            {
                IdListaPrecioVentaDropDownList.SelectedValue = value;
            }
        }
        public string IdListaPrecioCompra
        {
            get
            {
                return IdListaPrecioCompraDropDownList.SelectedValue;
            }
            set
            {
                IdListaPrecioCompraDropDownList.SelectedValue = value;
            }
        }
        public bool Enabled
        {
            set
            {
                IdListaPrecioVentaDropDownList.Enabled = value;
                IdListaPrecioCompraDropDownList.Enabled = value;
            }
        }
    }
}