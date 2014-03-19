using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaptchaDotNet2.Security.Cryptography;
using System.Drawing;

namespace CedServicios.Site
{
    public static class Funciones
    {
        public static void PersonalizarControlesMaster(MasterPage Master, bool RefrescaDatosUsuario, Entidades.Sesion Sesion)
        {
            if (RefrescaDatosUsuario) RN.Sesion.RefrescarDatosUsuario(Sesion.Usuario, Sesion);

            ContentPlaceHolder menuContentPlaceHolder = ((ContentPlaceHolder)Master.FindControl("MenuContentPlaceHolder"));
            Menu menu = ((Menu)menuContentPlaceHolder.FindControl("Menu"));

            ImageButton usuarioImageButton = ((ImageButton)Master.FindControl("UsuarioImageButton"));

            ContentPlaceHolder usuarioContentPlaceHolder = ((ContentPlaceHolder)Master.FindControl("UsuarioContentPlaceHolder"));
            Label usuarioLabel = ((Label)usuarioContentPlaceHolder.FindControl("UsuarioLabel"));
            HyperLink usuarioHyperLink = ((HyperLink)usuarioContentPlaceHolder.FindControl("UsuarioHyperLink"));
            Label cUITLabel = ((Label)usuarioContentPlaceHolder.FindControl("CUITLabel"));
            DropDownList cUITDropDownList = ((DropDownList)usuarioContentPlaceHolder.FindControl("CUITDropDownList"));
            Label uNLabel = ((Label)usuarioContentPlaceHolder.FindControl("UNLabel"));
            DropDownList uNDropDownList = ((DropDownList)usuarioContentPlaceHolder.FindControl("UNDropDownList"));
            
            menu.Items.Clear();
            menu.DynamicMenuItemStyle.HorizontalPadding = 10;
            menu.Orientation = Orientation.Horizontal;
            menu.Enabled = true;
            menu.Visible = true;
            MenuItem mItem;
            mItem = new MenuItem("Iniciar sesión", "Iniciar sesión"); mItem.Selectable = false;
            menu.Items.Add(mItem);

            mItem = new MenuItem("Clientes", "Clientes");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
                mItem = new MenuItem("Alta", "Alta");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Baja/Anul.baja", "Baja/Anul.baja");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Modificación", "Modificación");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Consulta", "Consulta");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Artículos", "Artículos");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
                mItem = new MenuItem("Alta", "Alta");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Baja/Anul.baja", "Baja/Anul.baja");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Modificación", "Modificación");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Consulta", "Consulta");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Factura Electrónica", "Factura Electrónica");
            menu.Items.Add(mItem);
                menu.Items[menu.Items.Count - 1].Selectable = false;
                mItem = new MenuItem("Alta", "Alta");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Consulta de Comprobantes (base de datos)", "Consulta de Comprobantes (base de datos)");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Consulta de Comprobantes (online Interfacturas)", "Consulta de Comprobantes (online Interfacturas)");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Consulta de Comprobante (archivo XML)", "Consulta de Comprobante (archivo XML)");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Consulta de Comprobante (online Interfacturas)", "Consulta de Comprobante (online Interfacturas)");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Términos y Condiciones", "Términos y Condiciones");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Administración", "Administración"); mItem.Selectable = false;
            menu.Items.Add(mItem);

                mItem = new MenuItem("CUIT", "CUIT"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

                    mItem = new MenuItem("Alta", "Alta"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Baja/Anul.baja", "Baja/Anul.baja"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Modificación", "Modificación"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Cambio logotipo", "Cambio logotipo"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Consulta", "Consulta"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Solicitud permiso de administrador de CUIT", "Solicitud permiso de administrador de CUIT"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);

                mItem = new MenuItem("Unidad de Negocio", "Unidad de Negocio"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

                    mItem = new MenuItem("Alta", "Alta"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Baja/Anul.baja", "Baja/Anul.baja"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Modificación", "Modificación"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Consulta", "Consulta"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Solicitud permiso de administrador de UN", "Solicitud permiso de administrador de UN"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Solicitud permiso de operador de servicio de una UN existente", "Solicitud permiso de operador de servicio de una UN existente"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);

                mItem = new MenuItem("Puntos de Venta", "Puntos de Venta"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

                    mItem = new MenuItem("Alta", "Alta"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Baja/Anul.baja", "Baja/Anul.baja"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Modificación", "Modificación"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Consulta", "Consulta"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);

                mItem = new MenuItem("Autorizaciones", "Autorizaciones"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

                    mItem = new MenuItem("Explorador de Autorizaciones pendientes", "Explorador de Autorizaciones pendientes"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Explorador de Autorizaciones (histórico)", "Explorador de Autorizaciones (histórico)"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);

                mItem = new MenuItem("Usuario", "Usuario"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

                    mItem = new MenuItem("Cambio de Contraseña", "Cambio de Contraseña"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Modificación datos de Configuración", "Modificación datos de Configuración"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Administración Site", "Administración Site"); mItem.Selectable = false;
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
                mItem = new MenuItem("Explorador de Comprobantes", "Explorador de Comprobantes");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
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
                mItem = new MenuItem("Explorador de Administración", "Explorador de Administración");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;

            mItem = new MenuItem("Ayuda", "Ayuda");
            menu.Items.Add(mItem);
            menu.Items[menu.Items.Count - 1].Selectable = false;
                mItem = new MenuItem("Manual", "Manual");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("¿Cómo empiezo a operar con facturas electrónicas?", "¿Cómo empiezo a operar con facturas electrónicas?"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Novedades", "Novedades");
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].Selectable = false;
                mItem = new MenuItem("Documentación técnica", "Documentación técnica");
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
                    String path = Master.Server.MapPath("~/ImagenesSubidas/");
                    string[] archivos = System.IO.Directory.GetFiles(path, Sesion.Usuario.Id + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    if (archivos.Length > 0)
                    {
                        usuarioImageButton.ImageUrl = "~/ImagenesSubidas/" + archivos[0].Replace(Master.Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                    }
                    else
                    {
                        usuarioImageButton.ImageUrl = "~/Imagenes/SiluetaHombre.jpg";
                    }
                    usuarioImageButton.Visible = true;
                    usuarioContentPlaceHolder.Visible = true;
                    usuarioHyperLink.Text = Sesion.Usuario.Nombre.Replace(" ", "&nbsp;");
                    menu.Items[menu.Items.Count - 1].Selectable = true;
                    if (Sesion.CuitsDelUsuario.Count != 0)
                    {
                        cUITDropDownList.DataSource = Sesion.CuitsDelUsuario;
                        cUITDropDownList.DataBind();
                        if (Sesion.Cuit != null)
                        {
                            cUITDropDownList.SelectedValue = Sesion.Cuit.Nro;
                            if (Sesion.Cuit.WF.Estado != "Vigente")
                            {
                                cUITLabel.ForeColor = Color.Red;
                            }
                            else
                            {
                                cUITLabel.ForeColor = Color.Black;
                            }
                        }
                        cUITLabel.Visible = true;
                        cUITDropDownList.Visible = true;
                    }
                    if (Sesion.Cuit.UNs.Count != 0)
                    {
                        uNDropDownList.DataSource = Sesion.Cuit.UNs;
                        uNDropDownList.DataBind();
                        if (Sesion.UN != null)
                        {
                            uNDropDownList.SelectedValue = Sesion.UN.Id.ToString();
                            if (Sesion.UN.WF.Estado != "Vigente")
                            {
                                uNLabel.ForeColor = Color.Red;
                            }
                            else
                            {
                                uNLabel.ForeColor = Color.Black;
                            }
                        }
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
            MenuItem menuItemRef = menu.FindItem("Administración Site|Explorador de Comprobantes");
            menuItem = menu.FindItem("Administración Site");
            if (menuItem != null && !menuItemRef.Selectable) RemoverMenuItem(menu, menuItem);
            Master.DataBind();
        }
        private static void RemoverMenuItem(Menu Menu, MenuItem MenuItem)
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
        public static void GenerarImagenCaptcha(System.Web.SessionState.HttpSessionState Session, System.Web.UI.WebControls.Image CaptchaImage, TextBox CaptchaTextBox)
        {
            string s = RandomText.Generate();
            string ens = Encryptor.Encrypt(s, "srgerg$%^bg", Convert.FromBase64String("srfjuoxp"));
            Session["captcha"] = s.ToLower();
            string color = "#ffffff";
            CaptchaImage.ImageUrl = "~/Captcha.ashx?w=305&h=92&c=" + ens + "&bc=" + color;
            CaptchaTextBox.Text = String.Empty;
        }
        public static bool SessionTimeOut(System.Web.SessionState.HttpSessionState Session)
        {
            return ((Entidades.Sesion)Session["Sesion"]).Usuario.Id == null;
        }
    }
}