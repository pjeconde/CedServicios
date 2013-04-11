using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using CaptchaDotNet2.Security.Cryptography;

namespace CedServicios.Site
{
    public static class Funciones
    {
        public static void PersonalizarControlesMaster(MasterPage Master, bool RefrescaDatosUsuario, Entidades.Sesion Sesion)
        {
            if (RefrescaDatosUsuario) RN.Sesion.RefrescarDatosUsuario(Sesion.Usuario, Sesion);

            ContentPlaceHolder menuContentPlaceHolder = ((ContentPlaceHolder)Master.FindControl("MenuContentPlaceHolder"));
            Menu menu = ((Menu)menuContentPlaceHolder.FindControl("Menu"));

            ContentPlaceHolder usuarioContentPlaceHolder = ((ContentPlaceHolder)Master.FindControl("UsuarioContentPlaceHolder"));
            Label usuarioLabel = ((Label)usuarioContentPlaceHolder.FindControl("UsuarioLabel"));
            HyperLink usuarioHyperLink = ((HyperLink)usuarioContentPlaceHolder.FindControl("UsuarioHyperLink"));
            Label cUITLabel = ((Label)usuarioContentPlaceHolder.FindControl("CUITLabel"));
            DropDownList cUITDropDownList = ((DropDownList)usuarioContentPlaceHolder.FindControl("CUITDropDownList"));
            Label uNLabel = ((Label)usuarioContentPlaceHolder.FindControl("UNLabel"));
            DropDownList uNDropDownList = ((DropDownList)usuarioContentPlaceHolder.FindControl("UNDropDownList"));
            
            menu.Items.Clear();
            menu.Orientation = Orientation.Horizontal;
            menu.Enabled = true;
            menu.Visible = true;
            MenuItem mItem;
            mItem = new MenuItem("Iniciar sesión", "Iniciar sesión");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("CUIT", "CUIT");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("Alta de CUIT", "Alta de CUIT");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Solicitud permiso de administrador de CUIT", "Solicitud permiso de administrador de CUIT");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Modificación datos CUIT", "Modificación datos CUIT");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Unidad de Negocio", "Unidad de Negocio");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("Alta de Unidad de Negocio", "Alta de Unidad de Negocio");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Solicitud permiso de administrador de UN", "Solicitud permiso de administrador de UN");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Solicitud permiso de operador de servicio de una UN existente", "Solicitud permiso de operador de servicio de una UN existente");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Modificación datos UN", "Modificación datos UN");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Puntos de Venta", "Puntos de Venta");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Clientes", "Clientes");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Artículos", "Artículos");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Facturación", "Facturación");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            mItem = new MenuItem("Autorizaciones", "Autorizaciones");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Autorizaciones pendientes", "Explorador de Autorizaciones pendientes");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Autorizaciones", "Explorador de Autorizaciones");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Administración Site", "Administración Site");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Usuarios", "Explorador de Usuarios");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de CUITs", "Explorador de CUITs");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de UNs", "Explorador de UNs");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Puntos de Venta", "Explorador de Puntos de Venta");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Clientes", "Explorador de Clientes");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Articulos", "Explorador de Artículos");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Permisos", "Explorador de Permisos");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Configuraciones", "Explorador de Configuraciones");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Explorador de Logs", "Explorador de Logs");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Configuración", "Configuración");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
            mItem = new MenuItem("Cambio de Contraseña de Usuario", "Cambio de Contraseña de Usuario");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
            mItem = new MenuItem("Modificación datos de Configuración", "Modificación datos de Configuración");
            menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
            menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Cerrar sesión", "Cerrar sesión");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;

            cUITDropDownList.DataValueField = "Nro";
            cUITDropDownList.DataTextField = "Nro";
            cUITDropDownList.DataSource = new List<Entidades.Cuit>();
            cUITDropDownList.DataBind();

            uNDropDownList.DataValueField = "Id";
            uNDropDownList.DataTextField = "Descr";
            uNDropDownList.DataSource = new List<Entidades.UN>();

            menuContentPlaceHolder.Visible = false;
            usuarioContentPlaceHolder.Visible = false;
            cUITLabel.Visible = false;
            cUITDropDownList.Visible = false;
            uNLabel.Visible = false;
            uNDropDownList.Visible = false;
            if (Sesion != null)
            {
                foreach (string s in Sesion.OpcionesHabilitadas)
                {
                    MenuItem mItemFind = menu.FindItem(s);
                    if (mItemFind != null)
                    {
                        mItemFind.Selectable = true;
                    }
                }
                menuContentPlaceHolder.Visible = true;
                if (Sesion.Usuario.Id != null)
                {
                    usuarioContentPlaceHolder.Visible = true;
                    usuarioHyperLink.Text = Sesion.Usuario.Nombre.Replace(" ", "&nbsp;");
                    menu.Items[menu.Items.Count - 1].Selectable = true;
                    if (Sesion.CuitsDelUsuario.Count != 0)
                    {
                        cUITDropDownList.DataSource = Sesion.CuitsDelUsuario;
                        cUITDropDownList.DataBind();
                        if (Sesion.Cuit != null) cUITDropDownList.SelectedValue = Sesion.Cuit.Nro;
                        cUITLabel.Visible = true;
                        cUITDropDownList.Visible = true;
                    }
                    if (Sesion.UNsDelCuit.Count != 0)
                    {
                        uNDropDownList.DataSource = Sesion.UNsDelCuit;
                        uNDropDownList.DataBind();
                        if (Sesion.UN != null) uNDropDownList.SelectedValue = Sesion.UN.Id.ToString();
                        uNLabel.Visible = true;
                        uNDropDownList.Visible = true;
                    }
                }
            }
            if (Sesion.Usuario.Id == null)
            {
                for (int i = menu.Items.Count - 1; i > 0; i--)
                {
                    RemoverMenuItem(menu, menu.Items[i]);
                }
            }
            MenuItem menuItem = menu.FindItem("Iniciar sesión");
            if (menuItem != null && !menuItem.Selectable) RemoverMenuItem(menu, menuItem);
            MenuItem menuSubItem = menu.FindItem("Administración Site/Explorador de Usuarios");
            menuItem = menu.FindItem("Administración Site");
            if (menuItem != null && menuSubItem != null && !menuSubItem.Selectable) RemoverMenuItem(menu, menuItem);
        }
        public static void RemoverMenuItem(Menu Menu, MenuItem MenuItem)
        {
            for (int j = MenuItem.ChildItems.Count - 1; j >= 0; j--)
            {
                MenuItem.ChildItems.Remove(MenuItem.ChildItems[0]);
            }
            Menu.Items.Remove(MenuItem);
        }
        public static void RemoverMenuItem(Menu Menu, string IdMenuItem)
        {
            MenuItem menuItem = Menu.FindItem(IdMenuItem);
            if (menuItem != null) RemoverMenuItem(Menu, menuItem);
        }
        public static void GenerarImagenCaptcha(System.Web.SessionState.HttpSessionState Session, Image CaptchaImage, TextBox CaptchaTextBox)
        {
            string s = RandomText.Generate();
            string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Session["captcha"] = s.ToLower();
            string color = "#ffffff";
            CaptchaImage.ImageUrl = "~/Captcha.ashx?w=305&h=92&c=" + ens + "&bc=" + color;
            CaptchaTextBox.Text = String.Empty;
        }
    }
}