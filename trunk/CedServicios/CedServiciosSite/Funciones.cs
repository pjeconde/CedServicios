using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaptchaDotNet2.Security.Cryptography;
using System.Drawing;
using System.IO;

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
            ImageButton usuarioImageButton = ((ImageButton)usuarioContentPlaceHolder.FindControl("UsuarioImageButton"));
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

            mItem = new MenuItem("Personas(clientes/proveedores)", "Personas(clientes/proveedores)"); mItem.Selectable = false;
            menu.Items.Add(mItem);
                mItem = new MenuItem("Alta", "Alta"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Baja/Anul.baja", "Baja/Anul.baja"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Modificación", "Modificación"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Consulta", "Consulta"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Artículos", "Artículos"); mItem.Selectable = false;
            menu.Items.Add(mItem);
                mItem = new MenuItem("Alta", "Alta"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Baja/Anul.baja", "Baja/Anul.baja"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Modificación", "Modificación"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Consulta", "Consulta"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Comprobantes", "Comprobantes"); mItem.Selectable = false;
            menu.Items.Add(mItem);
                mItem = new MenuItem("Alta", "Alta"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Venta", "Venta"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                        mItem = new MenuItem("Electrónica", "Electrónica"); mItem.Selectable = false;
                        menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems[0].ChildItems.Add(mItem);
                        mItem = new MenuItem("Manual", "Manual"); mItem.Selectable = false;
                        menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems[0].ChildItems.Add(mItem);
                    mItem = new MenuItem("Compra", "Compra"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Consulta", "Consulta"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Otras Consultas", "Otras Consultas"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Online Interfacturas", "Online Interfacturas"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                        mItem = new MenuItem("Varios comprobantes", "Varios comprobantes"); mItem.Selectable = false;
                        menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems[0].ChildItems.Add(mItem);
                        mItem = new MenuItem("Un comprobante", "Un comprobante"); mItem.Selectable = false;
                        menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems[0].ChildItems.Add(mItem);
                    mItem = new MenuItem("Online AFIP", "Online AFIP"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                    mItem = new MenuItem("Archivo XML", "Archivo XML"); mItem.Selectable = false;
                    menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("TyC", "TyC"); mItem.Selectable = false; mItem.ToolTip = "Términos y Condiciones";
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

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
                mItem = new MenuItem("Comprobantes", "Comprobantes"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Usuarios", "Usuarios"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("CUITs", "CUITs"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("UNs", "UNs"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Puntos de Venta", "Puntos de Venta"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Personas", "Personas"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Articulos", "Artículos"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Permisos", "Permisos"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Configuraciones", "Configuraciones"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Logs", "Logs"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Administración", "Administración"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Ayuda", "Ayuda"); mItem.Selectable = false;
            menu.Items.Add(mItem);
                mItem = new MenuItem("Manual", "Manual"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("¿Cómo empiezo a operar con facturas electrónicas?", "¿Cómo empiezo a operar con facturas electrónicas?"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems[menu.Items[menu.Items.Count - 1].ChildItems.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Novedades", "Novedades"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);
                mItem = new MenuItem("Documentación técnica", "Documentación técnica"); mItem.Selectable = false;
                menu.Items[menu.Items.Count - 1].ChildItems.Add(mItem);

            mItem = new MenuItem("Cerrar sesión", "Cerrar sesión"); mItem.Selectable = false;
            menu.Items.Add(mItem);

            usuarioLabel.Visible = false;
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
                usuarioContentPlaceHolder.Visible = true;
                if (Sesion.Usuario.Id != null)
                {
                    usuarioLabel.Visible = true;
                    String path = Master.Server.MapPath("~/ImagenesSubidas/");
                    string[] archivos = System.IO.Directory.GetFiles(path, Sesion.Usuario.Id + ".*", System.IO.SearchOption.TopDirectoryOnly);
                    usuarioImageButton.Visible = true;
                    if (archivos.Length > 0)
                    {
                        usuarioImageButton.ImageUrl = "~/ImagenesSubidas/" + archivos[0].Replace(Master.Server.MapPath("~/ImagenesSubidas/"), String.Empty);
                    }
                    else
                    {
                        usuarioImageButton.ImageUrl = "~/Imagenes/SiluetaHombre.jpg";
                    }
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
            MenuItem menuItemRef = menu.FindItem("Administración Site|Comprobantes");
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
        public static FeaEntidades.InterFacturas.lote_comprobantes Ws2Fea(org.dyndns.cedweb.consulta.ConsultarResult lcIBK)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lcFEA = new FeaEntidades.InterFacturas.lote_comprobantes();

            lcFEA.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lcFEA.cabecera_lote.cantidad_reg = lcIBK.cabecera_lote.cantidad_reg;
            lcFEA.cabecera_lote.cod_interno_canal = lcIBK.cabecera_lote.cod_interno_canal;
            lcFEA.cabecera_lote.cuit_canal = lcIBK.cabecera_lote.cuit_canal;
            lcFEA.cabecera_lote.cuit_vendedor = lcIBK.cabecera_lote.cuit_vendedor;
            lcFEA.cabecera_lote.fecha_envio_lote = lcIBK.cabecera_lote.fecha_envio_lote;
            lcFEA.cabecera_lote.id_lote = lcIBK.cabecera_lote.id_lote;
            lcFEA.cabecera_lote.motivo = lcIBK.cabecera_lote.motivo;
            lcFEA.cabecera_lote.presta_serv = lcIBK.cabecera_lote.presta_serv;
            lcFEA.cabecera_lote.presta_servSpecified = lcIBK.cabecera_lote.presta_servSpecified;
            lcFEA.cabecera_lote.punto_de_venta = lcIBK.cabecera_lote.punto_de_venta;
            lcFEA.cabecera_lote.resultado = lcIBK.cabecera_lote.resultado;

            lcFEA.comprobante = new FeaEntidades.InterFacturas.comprobante[lcIBK.comprobante.Length];

            for (int i = 0; i < lcIBK.comprobante.Length; i++)
            {
                FeaEntidades.InterFacturas.comprobante cIBK = new FeaEntidades.InterFacturas.comprobante();

                cIBK.cabecera = new FeaEntidades.InterFacturas.cabecera();

                //Comprador
                cIBK.cabecera.informacion_comprador = new FeaEntidades.InterFacturas.informacion_comprador();
                cIBK.cabecera.informacion_comprador.codigo_doc_identificatorio = lcIBK.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.codigo_interno = lcIBK.comprobante[i].cabecera.informacion_comprador.codigo_interno;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_comprador.condicion_IVA = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_IVA;
                cIBK.cabecera.informacion_comprador.condicion_IVASpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_IVASpecified;
                cIBK.cabecera.informacion_comprador.contacto = lcIBK.comprobante[i].cabecera.informacion_comprador.contacto;
                cIBK.cabecera.informacion_comprador.cp = lcIBK.comprobante[i].cabecera.informacion_comprador.cp;
                cIBK.cabecera.informacion_comprador.denominacion = lcIBK.comprobante[i].cabecera.informacion_comprador.denominacion;
                cIBK.cabecera.informacion_comprador.domicilio_calle = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_calle;
                cIBK.cabecera.informacion_comprador.domicilio_depto = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_depto;
                cIBK.cabecera.informacion_comprador.domicilio_manzana = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_manzana;
                cIBK.cabecera.informacion_comprador.domicilio_numero = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_numero;
                cIBK.cabecera.informacion_comprador.domicilio_piso = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_piso;
                cIBK.cabecera.informacion_comprador.domicilio_sector = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_sector;
                cIBK.cabecera.informacion_comprador.domicilio_torre = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_torre;
                cIBK.cabecera.informacion_comprador.email = lcIBK.comprobante[i].cabecera.informacion_comprador.email;
                cIBK.cabecera.informacion_comprador.GLN = lcIBK.comprobante[i].cabecera.informacion_comprador.GLN;
                cIBK.cabecera.informacion_comprador.GLNSpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.GLNSpecified;
                cIBK.cabecera.informacion_comprador.inicio_de_actividades = lcIBK.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades;
                cIBK.cabecera.informacion_comprador.localidad = lcIBK.comprobante[i].cabecera.informacion_comprador.localidad;
                cIBK.cabecera.informacion_comprador.nro_doc_identificatorio = lcIBK.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.nro_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.provincia = lcIBK.comprobante[i].cabecera.informacion_comprador.provincia;
                cIBK.cabecera.informacion_comprador.telefono = lcIBK.comprobante[i].cabecera.informacion_comprador.telefono;

                //Info Comprobante
                cIBK.cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                cIBK.cabecera.informacion_comprobante.cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.cae;
                cIBK.cabecera.informacion_comprobante.caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.cae != null && cIBK.cabecera.informacion_comprobante.cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.codigo_operacion = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_operacion;
                cIBK.cabecera.informacion_comprobante.condicion_de_pago = lcIBK.comprobante[i].cabecera.informacion_comprobante.condicion_de_pago;
                cIBK.cabecera.informacion_comprobante.condicion_de_pagoSpecified = true;
                cIBK.cabecera.informacion_comprobante.es_detalle_encriptado = lcIBK.comprobante[i].cabecera.informacion_comprobante.es_detalle_encriptado;
                cIBK.cabecera.informacion_comprobante.fecha_emision = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_emision;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae != null && cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.fecha_serv_desde = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_serv_desde;
                cIBK.cabecera.informacion_comprobante.fecha_serv_hasta = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_serv_hasta;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae != null && cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.iva_computable = lcIBK.comprobante[i].cabecera.informacion_comprobante.iva_computable;
                cIBK.cabecera.informacion_comprobante.motivo = lcIBK.comprobante[i].cabecera.informacion_comprobante.motivo;
                cIBK.cabecera.informacion_comprobante.numero_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.numero_comprobante;
                cIBK.cabecera.informacion_comprobante.punto_de_venta = lcIBK.comprobante[i].cabecera.informacion_comprobante.punto_de_venta;
                cIBK.cabecera.informacion_comprobante.resultado = lcIBK.comprobante[i].cabecera.informacion_comprobante.resultado;
                cIBK.cabecera.informacion_comprobante.tipo_de_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;
                cIBK.cabecera.informacion_comprobante.codigo_concepto = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_concepto;
                cIBK.cabecera.informacion_comprobante.codigo_conceptoSpecified = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_conceptoSpecified;

                //Info Vendedor
                cIBK.cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
                cIBK.cabecera.informacion_vendedor.codigo_interno = lcIBK.comprobante[i].cabecera.informacion_vendedor.codigo_interno;
                cIBK.cabecera.informacion_vendedor.razon_social = lcIBK.comprobante[i].cabecera.informacion_vendedor.razon_social;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_vendedor.condicion_IVA = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_IVA;
                cIBK.cabecera.informacion_vendedor.condicion_IVASpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_IVASpecified;
                cIBK.cabecera.informacion_vendedor.contacto = lcIBK.comprobante[i].cabecera.informacion_vendedor.contacto;
                cIBK.cabecera.informacion_vendedor.cp = lcIBK.comprobante[i].cabecera.informacion_vendedor.cp;
                cIBK.cabecera.informacion_vendedor.cuit = lcIBK.comprobante[i].cabecera.informacion_vendedor.cuit;
                cIBK.cabecera.informacion_vendedor.domicilio_calle = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_calle;
                cIBK.cabecera.informacion_vendedor.domicilio_depto = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_depto;
                cIBK.cabecera.informacion_vendedor.domicilio_manzana = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana;
                cIBK.cabecera.informacion_vendedor.domicilio_numero = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_numero;
                cIBK.cabecera.informacion_vendedor.domicilio_piso = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_piso;
                cIBK.cabecera.informacion_vendedor.domicilio_sector = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_sector;
                cIBK.cabecera.informacion_vendedor.domicilio_torre = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_torre;
                cIBK.cabecera.informacion_vendedor.email = lcIBK.comprobante[i].cabecera.informacion_vendedor.email;
                cIBK.cabecera.informacion_vendedor.GLN = lcIBK.comprobante[i].cabecera.informacion_vendedor.GLN;
                cIBK.cabecera.informacion_vendedor.GLNSpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.GLNSpecified;
                cIBK.cabecera.informacion_vendedor.inicio_de_actividades = lcIBK.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades;
                cIBK.cabecera.informacion_vendedor.localidad = lcIBK.comprobante[i].cabecera.informacion_vendedor.localidad;
                cIBK.cabecera.informacion_vendedor.nro_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.provincia = lcIBK.comprobante[i].cabecera.informacion_vendedor.provincia;
                cIBK.cabecera.informacion_vendedor.telefono = lcIBK.comprobante[i].cabecera.informacion_vendedor.telefono;

                //Info Comprobantes de Referencia
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    cIBK.cabecera.informacion_comprobante.referencias = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias[lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias.Length];

                    for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias.Length; j++)
                    {
                        if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j] != null)
                        {
                            cIBK.cabecera.informacion_comprobante.referencias[j] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                            if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip == RN.IBK.informacion_comprobanteReferenciasTipo_comprobante_afip.S.ToString())
                            {
                                cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip = "S";
                            }
                            else if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip == RN.IBK.informacion_comprobanteReferenciasTipo_comprobante_afip.N.ToString())
                            {
                                cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip = "N";
                            }
                            cIBK.cabecera.informacion_comprobante.referencias[j].codigo_de_referencia = lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].codigo_de_referencia;
                            cIBK.cabecera.informacion_comprobante.referencias[j].dato_de_referencia = lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].dato_de_referencia;
                        }
                    }
                }

                //Info Informacion Adicional Comprobante
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante = new FeaEntidades.InterFacturas.informacion_adicional_comprobante[lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante.Length];

                    for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante.Length; j++)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j] = new FeaEntidades.InterFacturas.informacion_adicional_comprobante();
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j].tipo = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j].tipo;
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j].valor = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j].valor;
                    }
                }

                //Info Exportación
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion = new FeaEntidades.InterFacturas.informacion_exportacion();
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.id_impositivo = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.id_impositivo;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.incoterms = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms;
                    if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != null && lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != "")
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permiso_existente = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente;
                    }
                    if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos != null)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos = new FeaEntidades.InterFacturas.permisos[lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length];
                        for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length; j++)
                        {
                            if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j] != null)
                            {
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j] = new FeaEntidades.InterFacturas.permisos();
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso;
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia;
                            }
                        }
                    }
                }

                //Detalle y Lineas
                FeaEntidades.InterFacturas.detalle d = new FeaEntidades.InterFacturas.detalle();
                org.dyndns.cedweb.consulta.ConsultarResultComprobanteDetalle detalle = lcIBK.comprobante[i].detalle;
                d.linea = new FeaEntidades.InterFacturas.linea[detalle.linea.Length];
                d.comentarios = detalle.comentarios;
                for (int j = 0; j < detalle.linea.Length; j++)
                {
                    if (detalle.linea[j] != null)
                    {
                        d.linea[j] = new FeaEntidades.InterFacturas.linea();
                        d.linea[j].alicuota_iva = detalle.linea[j].alicuota_iva;
                        d.linea[j].alicuota_ivaSpecified = detalle.linea[j].alicuota_ivaSpecified;
                        d.linea[j].cantidad = detalle.linea[j].cantidad;
                        d.linea[j].cantidadSpecified = detalle.linea[j].cantidadSpecified;
                        d.linea[j].codigo_producto_comprador = detalle.linea[j].codigo_producto_comprador;
                        d.linea[j].codigo_producto_vendedor = detalle.linea[j].codigo_producto_vendedor;
                        d.linea[j].descripcion = detalle.linea[j].descripcion;

                        d.linea[j].GTIN = detalle.linea[j].GTIN;
                        d.linea[j].GTINSpecified = detalle.linea[j].GTINSpecified;
                        d.linea[j].importe_iva = detalle.linea[j].importe_iva;
                        d.linea[j].importe_ivaSpecified = detalle.linea[j].importe_ivaSpecified;
                        d.linea[j].importe_total_articulo = detalle.linea[j].importe_total_articulo;
                        d.linea[j].importe_total_descuentos = detalle.linea[j].importe_total_descuentos;
                        d.linea[j].importe_total_descuentosSpecified = detalle.linea[j].importe_total_descuentosSpecified;
                        d.linea[j].importe_total_impuestos = detalle.linea[j].importe_total_impuestos;
                        d.linea[j].importe_total_impuestosSpecified = detalle.linea[j].importe_total_impuestosSpecified;

                        if (detalle.linea[j].importes_moneda_origen != null)
                        {
                            d.linea[j].importes_moneda_origen = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
                            d.linea[j].importes_moneda_origen.importe_iva = detalle.linea[j].importes_moneda_origen.importe_iva;
                            d.linea[j].importes_moneda_origen.importe_ivaSpecified = detalle.linea[j].importes_moneda_origen.importe_ivaSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_articulo = detalle.linea[j].importes_moneda_origen.importe_total_articulo;
                            d.linea[j].importes_moneda_origen.importe_total_articuloSpecified = detalle.linea[j].importes_moneda_origen.importe_total_articuloSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_descuentos = detalle.linea[j].importes_moneda_origen.importe_total_descuentos;
                            d.linea[j].importes_moneda_origen.importe_total_descuentosSpecified = detalle.linea[j].importes_moneda_origen.importe_total_descuentosSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_impuestos = detalle.linea[j].importes_moneda_origen.importe_total_impuestos;
                            d.linea[j].importes_moneda_origen.importe_total_impuestosSpecified = detalle.linea[j].importes_moneda_origen.importe_total_impuestosSpecified;
                            d.linea[j].importes_moneda_origen.precio_unitario = detalle.linea[j].importes_moneda_origen.precio_unitario;
                            d.linea[j].importes_moneda_origen.precio_unitarioSpecified = detalle.linea[j].importes_moneda_origen.precio_unitarioSpecified;
                        }

                        if (detalle.linea[j].impuestos != null)
                        {
                            d.linea[j].impuestos = new FeaEntidades.InterFacturas.lineaImpuestos[detalle.linea[j].impuestos.Length];
                            for (int k = 0; k < d.linea[j].impuestos.Length; k++)
                            {
                                d.linea[j].impuestos[k] = new FeaEntidades.InterFacturas.lineaImpuestos();
                                d.linea[j].impuestos[k].codigo_impuesto = detalle.linea[j].impuestos[k].codigo_impuesto;
                                d.linea[j].impuestos[k].descripcion_impuesto = detalle.linea[j].impuestos[k].descripcion_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto = detalle.linea[j].impuestos[k].importe_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origen = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origen;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified;
                                d.linea[j].impuestos[k].porcentaje_impuesto = detalle.linea[j].impuestos[k].porcentaje_impuesto;
                                d.linea[j].impuestos[k].porcentaje_impuestoSpecified = detalle.linea[j].impuestos[k].porcentaje_impuestoSpecified;
                            }
                        }
                        if (detalle.linea[j].descuentos != null)
                        {
                            d.linea[j].lineaDescuentos = new FeaEntidades.InterFacturas.lineaDescuentos[detalle.linea[j].descuentos.Length];
                            for (int k = 0; k < d.linea[j].lineaDescuentos.Length; k++)
                            {
                                d.linea[j].lineaDescuentos[k] = new FeaEntidades.InterFacturas.lineaDescuentos();
                                d.linea[j].lineaDescuentos[k].descripcion_descuento = detalle.linea[j].descuentos[k].descripcion_descuento;
                                d.linea[j].lineaDescuentos[k].importe_descuento = detalle.linea[j].descuentos[k].importe_descuento;
                                d.linea[j].lineaDescuentos[k].importe_descuento_moneda_origen = detalle.linea[j].descuentos[k].importe_descuento_moneda_origen;
                                d.linea[j].lineaDescuentos[k].importe_descuento_moneda_origenSpecified = detalle.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified;
                                d.linea[j].lineaDescuentos[k].porcentaje_descuento = detalle.linea[j].descuentos[k].porcentaje_descuento;
                                d.linea[j].lineaDescuentos[k].porcentaje_descuentoSpecified = detalle.linea[j].descuentos[k].porcentaje_descuentoSpecified;
                            }
                        }
                        if (detalle.linea[j].informacion_adicional != null)
                        {
                            d.linea[j].informacion_adicional = new FeaEntidades.InterFacturas.lineaInformacion_adicional[detalle.linea[j].informacion_adicional.Length];
                            for (int k = 0; k < d.linea[j].informacion_adicional.Length; k++)
                            {
                                d.linea[j].informacion_adicional[k] = new FeaEntidades.InterFacturas.lineaInformacion_adicional();
                                d.linea[j].informacion_adicional[k].tipo = detalle.linea[j].informacion_adicional[k].tipo;
                                d.linea[j].informacion_adicional[k].valor = detalle.linea[j].informacion_adicional[k].valor;
                            }
                        }
                        d.linea[j].indicacion_exento_gravado = detalle.linea[j].indicacion_exento_gravado;
                        d.linea[j].numeroLinea = detalle.linea[j].numeroLinea;
                        d.linea[j].precio_unitario = detalle.linea[j].precio_unitario;
                        d.linea[j].precio_unitarioSpecified = detalle.linea[j].precio_unitarioSpecified;
                        d.linea[j].unidad = detalle.linea[j].unidad;
                    }
                    else
                    {
                        break;
                    }
                }
                cIBK.detalle = d;

                //Info Extensiones
                cIBK.extensiones = new FeaEntidades.InterFacturas.extensiones();
                cIBK.extensionesSpecified = false;
                if (lcIBK.comprobante[i].extensiones != null)
                {
                    cIBK.extensiones = new FeaEntidades.InterFacturas.extensiones();
                    cIBK.extensionesSpecified = true;
                    if (lcIBK.comprobante[i].extensiones.extensiones_camara_facturas != null)
                    {
                        cIBK.extensiones.extensiones_camara_facturasSpecified = true;
                        cIBK.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
                        cIBK.extensiones.extensiones_camara_facturas.clave_de_vinculacion = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion;
                        cIBK.extensiones.extensiones_camara_facturas.id_idioma = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.id_idioma;
                        cIBK.extensiones.extensiones_camara_facturas.id_template = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.id_template;
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales != null)
                    {
                        if (!lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales.Equals(string.Empty))
                        {

                            string aux = lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales.ToString();
                            if (aux.Length > 0 && aux.Substring(0, 1) == "%")
                            {
                                aux = RN.Funciones.HexToString(aux);
                            }
                            cIBK.extensiones.extensiones_datos_comerciales = aux;
                        }
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_datos_marketing != null)
                    {
                        if (!lcIBK.comprobante[i].extensiones.extensiones_datos_marketing.Equals(string.Empty))
                        {
                            string aux = lcIBK.comprobante[i].extensiones.extensiones_datos_marketing.ToString();
                            if (aux.Length > 0 && aux.Substring(0, 1) == "%")
                            {
                                aux = RN.Funciones.HexToString(aux);
                            }
                            cIBK.extensiones.extensiones_datos_marketing = aux;
                        }
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_destinatarios != null)
                    {
                        cIBK.extensiones.extensiones_destinatarios = new FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios();
                        cIBK.extensiones.extensiones_destinatarios.email = lcIBK.comprobante[i].extensiones.extensiones_destinatarios.email;
                    }
                }

                cIBK.resumen = new FeaEntidades.InterFacturas.resumen();
                cIBK.resumen.cant_alicuotas_iva = lcIBK.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lcIBK.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lcIBK.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[0];

                cIBK.resumen.cant_alicuotas_iva = lcIBK.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lcIBK.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lcIBK.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.importe_operaciones_exentas = lcIBK.comprobante[i].resumen.importe_operaciones_exentas;
                cIBK.resumen.importe_total_concepto_no_gravado = lcIBK.comprobante[i].resumen.importe_total_concepto_no_gravado;
                cIBK.resumen.importe_total_factura = lcIBK.comprobante[i].resumen.importe_total_factura;
                cIBK.resumen.importe_total_impuestos_internos = lcIBK.comprobante[i].resumen.importe_total_impuestos_internos;
                cIBK.resumen.importe_total_impuestos_internosSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_internosSpecified;
                cIBK.resumen.importe_total_impuestos_municipales = lcIBK.comprobante[i].resumen.importe_total_impuestos_municipales;
                cIBK.resumen.importe_total_impuestos_municipalesSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_municipalesSpecified;
                cIBK.resumen.importe_total_impuestos_nacionales = lcIBK.comprobante[i].resumen.importe_total_impuestos_nacionales;
                cIBK.resumen.importe_total_impuestos_nacionalesSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_nacionalesSpecified;
                cIBK.resumen.importe_total_ingresos_brutos = lcIBK.comprobante[i].resumen.importe_total_ingresos_brutos;
                cIBK.resumen.importe_total_ingresos_brutosSpecified = lcIBK.comprobante[i].resumen.importe_total_ingresos_brutosSpecified;
                cIBK.resumen.importe_total_neto_gravado = lcIBK.comprobante[i].resumen.importe_total_neto_gravado;

                if (lcIBK.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    cIBK.resumen.importes_moneda_origen = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();
                    cIBK.resumen.importes_moneda_origen.importe_operaciones_exentas = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_operaciones_exentas;
                    cIBK.resumen.importes_moneda_origen.importe_total_concepto_no_gravado = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
                    cIBK.resumen.importes_moneda_origen.importe_total_factura = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_factura;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internos = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internos;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipales = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionales = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutos = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_neto_gravado = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_neto_gravado;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq = lcIBK.comprobante[i].resumen.importes_moneda_origen.impuesto_liq;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq_rni = lcIBK.comprobante[i].resumen.importes_moneda_origen.impuesto_liq_rni;
                }

                cIBK.resumen.impuesto_liq = lcIBK.comprobante[i].resumen.impuesto_liq;
                cIBK.resumen.impuesto_liq_rni = lcIBK.comprobante[i].resumen.impuesto_liq_rni;

                if (lcIBK.comprobante[i].resumen.descuentos != null)
                {
                    cIBK.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[lcIBK.comprobante[i].resumen.descuentos.Length];
                    for (int l = 0; l < lcIBK.comprobante[i].resumen.descuentos.Length; l++)
                    {
                        if (lcIBK.comprobante[i].resumen.descuentos[l] != null)
                        {
                            cIBK.resumen.descuentos[l] = new FeaEntidades.InterFacturas.resumenDescuentos();
                            cIBK.resumen.descuentos[l].alicuota_iva_descuento = lcIBK.comprobante[i].resumen.descuentos[l].alicuota_iva_descuento;
                            cIBK.resumen.descuentos[l].alicuota_iva_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].alicuota_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].descripcion_descuento = lcIBK.comprobante[i].resumen.descuentos[l].descripcion_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origen = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origenSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuento = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origen = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].porcentaje_descuento = lcIBK.comprobante[i].resumen.descuentos[l].porcentaje_descuento;
                            cIBK.resumen.descuentos[l].porcentaje_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].porcentaje_descuentoSpecified;
                            cIBK.resumen.descuentos[l].indicacion_exento_gravado_descuento = lcIBK.comprobante[i].resumen.descuentos[l].indicacion_exento_gravado_descuento;
                        }
                    }
                }

                if (lcIBK.comprobante[i].resumen.impuestos != null)
                {
                    cIBK.resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[lcIBK.comprobante[i].resumen.impuestos.Length];
                    for (int l = 0; l < lcIBK.comprobante[i].resumen.impuestos.Length; l++)
                    {
                        if (lcIBK.comprobante[i].resumen.impuestos[l] != null)
                        {
                            cIBK.resumen.impuestos[l] = new FeaEntidades.InterFacturas.resumenImpuestos();
                            cIBK.resumen.impuestos[l].codigo_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].codigo_impuesto;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccion = lcIBK.comprobante[i].resumen.impuestos[l].codigo_jurisdiccion;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccionSpecified = lcIBK.comprobante[i].resumen.impuestos[l].codigo_jurisdiccionSpecified;
                            cIBK.resumen.impuestos[l].descripcion = lcIBK.comprobante[i].resumen.impuestos[l].descripcion;
                            cIBK.resumen.impuestos[l].importe_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origen = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origen;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origenSpecified = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origenSpecified;
                            cIBK.resumen.impuestos[l].jurisdiccion_municipal = lcIBK.comprobante[i].resumen.impuestos[l].jurisdiccion_municipal;
                            cIBK.resumen.impuestos[l].porcentaje_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].porcentaje_impuesto;
                            cIBK.resumen.impuestos[l].porcentaje_impuestoSpecified = lcIBK.comprobante[i].resumen.impuestos[l].porcentaje_impuestoSpecified;
                        }
                    }
                }
                cIBK.resumen.observaciones = lcIBK.comprobante[i].resumen.observaciones;
                cIBK.resumen.tipo_de_cambio = lcIBK.comprobante[i].resumen.tipo_de_cambio;

                lcFEA.comprobante[i] = cIBK;
            }
            return lcFEA;
        }
        public static void GrabarLogTexto(string archivo, string mensaje)
        {
            try
            {
                using (FileStream fs = File.Open(HttpContext.Current.Server.MapPath(archivo), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + "  " + mensaje);
                    }
                }
            }
            catch
            {
            }
        }
        public static string TextoScript(string Contenido)
        {
            return "<SCRIPT LANGUAGE='javascript'>alert('" + Contenido.Replace("'", "").Replace("\r\n", "  ") + "');</SCRIPT>";
        }
    }
}