﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site
{
    public partial class CuitTreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string a = HttpContext.Current.Request.Url.Query.ToString();
                string nivelAContraer = null;
                switch (a.Replace("?", String.Empty))
                {
                    case "Cuit":
                        TituloLabel.Text = "Consulta de CUIT(s)";
                        nivelAContraer = "0";
                        break;
                    case "UN":
                        TituloLabel.Text = "Consulta de Unidad(es) de Negocio";
                        nivelAContraer = "1";
                        break;
                    case "PuntoVta":
                        TituloLabel.Text = "Consulta de Punto(s) de Venta";
                        break;
                }
                TituloCuitsTreeView.Enabled = false;
                TituloCuitsTreeView.Nodes.Add(new TreeNode("CUIT"));
                TituloCuitsTreeView.Nodes[TituloCuitsTreeView.Nodes.Count - 1].ChildNodes.Add(new TreeNode("Unidad de Negocio"));
                TituloCuitsTreeView.Nodes[TituloCuitsTreeView.Nodes.Count - 1].ChildNodes[TituloCuitsTreeView.Nodes[TituloCuitsTreeView.Nodes.Count - 1].ChildNodes.Count - 1].ChildNodes.Add(new TreeNode("Punto de Venta (Tipo de Punto de Venta)"));

                Entidades.Sesion sesion = (Entidades.Sesion)Session["Sesion"];
                RN.Cuit.CompletarUNsYPuntosVta(sesion.CuitsDelUsuario, sesion);
                for (int i = 0; i<sesion.CuitsDelUsuario.Count; i++)
                {
                    TreeNode nodoCuit = new TreeNode(sesion.CuitsDelUsuario[i].Nro);
                    for (int j = 0; j < sesion.CuitsDelUsuario[i].UNs.Count; j++)
                    {
                        TreeNode nodoUN = new TreeNode(sesion.CuitsDelUsuario[i].UNs[j].Descr);
                        nodoUN.Value = sesion.CuitsDelUsuario[i].UNs[j].Id.ToString();
                        nodoCuit.ChildNodes.Add(nodoUN);
                        if (sesion.CuitsDelUsuario[i].UNs[j].PuntosVta.Count > 0)
                        {
                            for (int h = 0; h < sesion.CuitsDelUsuario[i].UNs[j].PuntosVta.Count; h++)
                            {
                                TreeNode nodoPuntoVta = new TreeNode(sesion.CuitsDelUsuario[i].UNs[j].PuntosVta[h].Descr);
                                nodoPuntoVta.Value = sesion.CuitsDelUsuario[i].UNs[j].PuntosVta[h].Nro.ToString();
                                nodoUN.ChildNodes.Add(nodoPuntoVta);
                            }
                        }
                        else
                        {
                            TreeNode nodoPuntoVta = new TreeNode("(no hay Puntos de Venta definidos)");
                            nodoPuntoVta.Value = "0";
                            nodoUN.ChildNodes.Add(nodoPuntoVta);
                        }
                    }
                    CuitsTreeView.Nodes.Add(nodoCuit);
                }
                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                MedioDropDownList.DataSource = RN.Medio.Lista(sesion);
                PuntoVtaPanel_IdUNDropDownList.DataSource = RN.UN.ListaVigentesPorCuit(sesion.Cuit, sesion);
                IdTipoPuntoVtaDropDownList.DataSource = RN.TipoPuntoVta.Lista(sesion);
                IdMetodoGeneracionNumeracionLoteDropDownList.DataSource = RN.MetodoGeneracionNumeracionLote.Lista(sesion);
                DataBind();
                if (nivelAContraer != null)
                {
                    for (int i = 0; i < CuitsTreeView.Nodes.Count; i++)
                    {
                        if (nivelAContraer == "0")
                        {
                            CuitsTreeView.Nodes[i].Collapse();
                        }
                        else
                        {
                            for (int j = 0; j < CuitsTreeView.Nodes[i].ChildNodes.Count; j++)
                            {
                                CuitsTreeView.Nodes[i].ChildNodes[j].Collapse();
                            }
                        }
                    }
                }
                ViewState["Sesion"] = sesion.Clone();
            }
        }
        protected void CuitsTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {
            MensajeLabel.Text = String.Empty;
            Entidades.Sesion sesion = (Entidades.Sesion)ViewState["Sesion"];
            Entidades.Cuit cuit = new Entidades.Cuit();
            Entidades.UN uN = new Entidades.UN();
            Entidades.PuntoVta puntoVta= new Entidades.PuntoVta();
            int idPuntoVta = 0;
            switch (CuitsTreeView.SelectedNode.Depth)
            {
                case 0:
                    cuit = sesion.CuitsDelUsuario.Find(delegate(Entidades.Cuit p)
                    {
                        return p.Nro == CuitsTreeView.SelectedNode.Value;
                    });
                    break;
                case 1:
                    cuit = sesion.CuitsDelUsuario.Find(delegate(Entidades.Cuit p)
                    {
                        return p.Nro == CuitsTreeView.SelectedNode.Parent.Value;
                    });
                    uN = cuit.TraerUN(Convert.ToInt32(CuitsTreeView.SelectedNode.Value));
                    break;
                case 2:
                    cuit = sesion.CuitsDelUsuario.Find(delegate(Entidades.Cuit p)
                    {
                        return p.Nro == CuitsTreeView.SelectedNode.Parent.Parent.Value;
                    });
                    uN = cuit.TraerUN(Convert.ToInt32(CuitsTreeView.SelectedNode.Parent.Value));
                    idPuntoVta = Convert.ToInt32(CuitsTreeView.SelectedNode.Value);
                    if (idPuntoVta != 0)
                    {
                        puntoVta = uN.PuntosVta.Find(delegate(Entidades.PuntoVta p)
                        {
                            return p.Nro == idPuntoVta;
                        });
                    }
                    else
                    {
                        MensajeLabel.Text = "Consulta inválida";
                        return;
                    }
                    break;
            }
            switch (CuitsTreeView.SelectedNode.Depth)
            {
                case 0:
                    ModalPopupExtender1.PopupControlID = "CuitPanel";
                    ModalPopupExtender1.PopupDragHandleControlID = "CuitPanel";
                    CuitPanel_CUITTextBox.Text = cuit.Nro;
                    RazonSocialTextBox.Text = cuit.RazonSocial;
                    Domicilio.Calle = cuit.Domicilio.Calle;
                    Domicilio.Nro = cuit.Domicilio.Nro;
                    Domicilio.Piso = cuit.Domicilio.Piso;
                    Domicilio.Depto = cuit.Domicilio.Depto;
                    Domicilio.Manzana = cuit.Domicilio.Manzana;
                    Domicilio.Sector = cuit.Domicilio.Sector;
                    Domicilio.Torre = cuit.Domicilio.Torre;
                    Domicilio.Localidad = cuit.Domicilio.Localidad;
                    Domicilio.IdProvincia = cuit.Domicilio.Provincia.Id;
                    Domicilio.CodPost = cuit.Domicilio.CodPost;
                    Contacto.Nombre = cuit.Contacto.Nombre;
                    Contacto.Email = cuit.Contacto.Email;
                    Contacto.Telefono = cuit.Contacto.Telefono;
                    DatosImpositivos.IdCondIVA = cuit.DatosImpositivos.IdCondIVA;
                    DatosImpositivos.IdCondIngBrutos = cuit.DatosImpositivos.IdCondIngBrutos;
                    DatosImpositivos.NroIngBrutos = cuit.DatosImpositivos.NroIngBrutos;
                    DatosImpositivos.FechaInicioActividades = cuit.DatosImpositivos.FechaInicioActividades;
                    DatosIdentificatorios.GLN = cuit.DatosIdentificatorios.GLN;
                    DatosIdentificatorios.CodigoInterno = cuit.DatosIdentificatorios.CodigoInterno;
                    MedioDropDownList.SelectedValue = cuit.Medio.Id;

                    CuitPanel_CUITTextBox.Enabled = false;
                    RazonSocialTextBox.Enabled = false;
                    Domicilio.Enabled = false;
                    Contacto.Enabled = false;
                    DatosImpositivos.Enabled = false;
                    DatosIdentificatorios.Enabled = false;
                    MedioDropDownList.Enabled = false;

                    break;
                case 1:
                    ModalPopupExtender1.PopupControlID = "UNPanel";
                    ModalPopupExtender1.PopupDragHandleControlID = "UNPanel";
                    UNPanel_CUITTextBox.Text = uN.Cuit;
                    IdUNTextBox.Text = uN.Id.ToString();
                    DescrUNTextBox.Text = uN.Descr;

                    UNPanel_CUITTextBox.Enabled = false;
                    IdUNTextBox.Enabled = false;
                    DescrUNTextBox.Enabled = false;

                    break;
                case 2:
                    ModalPopupExtender1.PopupControlID = "PuntoVtaPanel";
                    ModalPopupExtender1.PopupDragHandleControlID = "PuntoVtaPanel";
                    PuntoVtaPanel_CUITTextBox.Text = uN.Cuit;
                    PuntoVtaPanel_IdUNDropDownList.SelectedValue = uN.Id.ToString();
                    NroTextBox.Text = puntoVta.Nro.ToString("0000");
                    IdTipoPuntoVtaDropDownList.SelectedValue = puntoVta.IdTipoPuntoVta;
                    IdMetodoGeneracionNumeracionLoteDropDownList.SelectedValue = puntoVta.IdMetodoGeneracionNumeracionLote;
                    UltNroLoteTextBox.Text = puntoVta.UltNroLote.ToString();
                    UsaDatosCuitCheckBox.Checked = !puntoVta.UsaSetPropioDeDatosCuit;
                    UsaDatosCuitCheckBox_CheckedChanged(UsaDatosCuitCheckBox, new EventArgs());
                    if (UsaDatosCuitCheckBox.Checked)
                    {
                        PuntoVtaPanel_Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                        PuntoVtaPanel_DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                        PuntoVtaPanel_DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                        DataBind();
                        PuntoVtaPanel_Domicilio.Calle = cuit.Domicilio.Calle;
                        PuntoVtaPanel_Domicilio.Nro = cuit.Domicilio.Nro;
                        PuntoVtaPanel_Domicilio.Piso = cuit.Domicilio.Piso;
                        PuntoVtaPanel_Domicilio.Depto = cuit.Domicilio.Depto;
                        PuntoVtaPanel_Domicilio.Manzana = cuit.Domicilio.Manzana;
                        PuntoVtaPanel_Domicilio.Sector = cuit.Domicilio.Sector;
                        PuntoVtaPanel_Domicilio.Torre = cuit.Domicilio.Torre;
                        PuntoVtaPanel_Domicilio.Localidad = cuit.Domicilio.Localidad;
                        PuntoVtaPanel_Domicilio.IdProvincia = cuit.Domicilio.Provincia.Id;
                        PuntoVtaPanel_Domicilio.CodPost = cuit.Domicilio.CodPost;
                        PuntoVtaPanel_Contacto.Nombre = cuit.Contacto.Nombre;
                        PuntoVtaPanel_Contacto.Email = cuit.Contacto.Email;
                        PuntoVtaPanel_Contacto.Telefono = cuit.Contacto.Telefono;
                        PuntoVtaPanel_DatosImpositivos.IdCondIVA = cuit.DatosImpositivos.IdCondIVA;
                        PuntoVtaPanel_DatosImpositivos.IdCondIngBrutos = cuit.DatosImpositivos.IdCondIngBrutos;
                        PuntoVtaPanel_DatosImpositivos.NroIngBrutos = cuit.DatosImpositivos.NroIngBrutos;
                        PuntoVtaPanel_DatosImpositivos.FechaInicioActividades = cuit.DatosImpositivos.FechaInicioActividades;
                        PuntoVtaPanel_DatosIdentificatorios.GLN = cuit.DatosIdentificatorios.GLN;
                        PuntoVtaPanel_DatosIdentificatorios.CodigoInterno = cuit.DatosIdentificatorios.CodigoInterno;
                    }

                    PuntoVtaPanel_CUITTextBox.Enabled = false;
                    PuntoVtaPanel_IdUNDropDownList.Enabled = false;
                    NroTextBox.Enabled = false;
                    IdTipoPuntoVtaDropDownList.Enabled = false;
                    IdMetodoGeneracionNumeracionLoteDropDownList.Enabled = false;
                    UltNroLoteTextBox.Enabled = false;
                    UsaDatosCuitCheckBox.Enabled = false;
                    PuntoVtaPanel_Domicilio.Enabled = false;
                    PuntoVtaPanel_Contacto.Enabled = false;
                    PuntoVtaPanel_DatosImpositivos.Enabled = false;
                    PuntoVtaPanel_DatosIdentificatorios.Enabled = false;
                    break;
            }
            ModalPopupExtender1.Show();
        }
        protected void SalirButton_Click(object sender, EventArgs e)
        {
            CuitsTreeView.SelectedNode.Selected = false;
        }
        protected void UsaDatosCuitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PuntoVtaPanel_Domicilio.Visible = !UsaDatosCuitCheckBox.Checked;
            PuntoVtaPanel_Contacto.Visible = !UsaDatosCuitCheckBox.Checked;
            PuntoVtaPanel_DatosImpositivos.Visible = !UsaDatosCuitCheckBox.Checked;
            PuntoVtaPanel_DatosIdentificatorios.Visible = !UsaDatosCuitCheckBox.Checked;
        }
    }
}