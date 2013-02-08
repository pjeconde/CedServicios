using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class CedServicios : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Menu1.Items.Clear();
            Menu1.Orientation = Orientation.Horizontal;
            Menu1.Enabled = true;
            Menu1.Visible = true;
            MenuItem mItem = new MenuItem("CUIT", "CUIT");
            Menu1.Items.Add(mItem);
            Menu1.Items[Menu1.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("Alta de CUIT", "Alta de CUIT");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Solicitud permiso de administrador de CUIT", "Solicitud permiso de administrador de CUIT");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Modificación datos CUIT", "Modificación datos CUIT");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Unidad de Negocio", "Unidad de Negocio");
            Menu1.Items.Add(mItem);
            Menu1.Items[Menu1.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("Alta de UN", "Alta de UN");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Solicitud permiso de administrador de UN", "Solicitud permiso de administrador de UN");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Solicitud permiso de operador de servicio de una UN existente", "Solicitud permiso de operador de servicio de una UN existente");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Modificación datos UN", "Modificación datos UN");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Puntos de Venta", "Puntos de Venta");
            Menu1.Items.Add(mItem);

            mItem = new MenuItem("Clientes", "Clientes");
            Menu1.Items.Add(mItem);

            mItem = new MenuItem("Artículos", "Artículos");
            Menu1.Items.Add(mItem);

            mItem = new MenuItem("Facturación", "Facturación");
            Menu1.Items.Add(mItem);

            mItem = new MenuItem("Autorizaciones", "Autorizaciones");
            Menu1.Items.Add(mItem);
            mItem = new MenuItem("Explorador de Autorizaciones pendientes", "Explorador de Autorizaciones pendientes");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de Autorizaciones", "Explorador de Autorizaciones");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Administración Site", "Administración Site");
            Menu1.Items.Add(mItem);
            mItem = new MenuItem("Explorador de Usuarios", "Explorador de Usuarios");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de CUITs", "Explorador de CUITs");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de UNs", "Explorador de UNs");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de Puntos de Venta", "Explorador de Puntos de Venta");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de Clientes", "Explorador de Clientes");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de Articulos", "Explorador de Artículos");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de Permisos", "Explorador de Permisos");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de Configuraciones", "Explorador de Configuraciones");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);
            mItem = new MenuItem("Explorador de Logs", "Explorador de Logs");
            Menu1.Items[Menu1.Items.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Configuración", "Configuración");
            Menu1.Items.Add(mItem);

            mItem = new MenuItem("Cerrar sesión", "Cerrar sesión");
            Menu1.Items.Add(mItem);

            string buscarItem = "Unidad de Negocio/Alta de UN";
            MenuItem mItemFind = Menu1.FindItem(buscarItem);
            mItemFind.Selectable = false;

        }
    }
}