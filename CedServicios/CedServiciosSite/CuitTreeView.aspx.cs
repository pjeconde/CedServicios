using System;
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
                                TreeNode nodoPuntoVta = new TreeNode(sesion.CuitsDelUsuario[i].UNs[j].PuntosVta[h].Nro.ToString("0000") + " (" + sesion.CuitsDelUsuario[i].UNs[j].PuntosVta[h].IdTipoPuntoVta + ")");
                                nodoPuntoVta.Value = sesion.CuitsDelUsuario[i].UNs[j].PuntosVta[h].Nro.ToString();
                                nodoUN.ChildNodes.Add(nodoPuntoVta);
                            }
                        }
                        else
                        {
                            TreeNode nodoPuntoVta = new TreeNode("(no hay Puntos de Venta definidos)");
                            nodoPuntoVta.Value = String.Empty;
                            nodoUN.ChildNodes.Add(nodoPuntoVta);
                        }
                    }
                    CuitsTreeView.Nodes.Add(nodoCuit);
                }

                Domicilio.ListaProvincia = FeaEntidades.CodigosProvincia.CodigoProvincia.Lista();
                DatosImpositivos.ListaCondIVA = FeaEntidades.CondicionesIVA.CondicionIVA.Lista();
                DatosImpositivos.ListaCondIngBrutos = FeaEntidades.CondicionesIB.CondicionIB.Lista();
                MedioDropDownList.DataSource = RN.Medio.Lista(sesion);
                DataBind();
                ViewState["Sesion"] = sesion.Clone();
            }
        }
        protected void CuitsTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {
            Entidades.Sesion sesion = (Entidades.Sesion)ViewState["Sesion"];
            Entidades.Cuit cuit = new Entidades.Cuit();
            Entidades.UN uN = new Entidades.UN();
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
                    break;
            }
            ModalPopupExtender1.Show();
        }

        protected void SalirButton_Click(object sender, EventArgs e)
        {
            CuitsTreeView.SelectedNode.Selected = false;
        }
    }
}