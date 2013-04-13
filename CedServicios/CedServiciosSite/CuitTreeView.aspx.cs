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
            }
        }
        protected void CuitsTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {
            //MensajeLabel.Text = CuitsTreeView.SelectedNode.Value;
            switch (CuitsTreeView.SelectedNode.Depth)
            {
                case 0:
                    ModalPopupExtender1.PopupControlID = "CuitPanel";
                    ModalPopupExtender1.PopupDragHandleControlID = "CuitPanel";
                    break;
                case 1:
                    ModalPopupExtender1.PopupControlID = "UNPanel";
                    ModalPopupExtender1.PopupDragHandleControlID = "UNPanel";
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