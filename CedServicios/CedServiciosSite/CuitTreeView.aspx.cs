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
                    CuitsTreeView.Nodes.Add(new TreeNode(sesion.CuitsDelUsuario[i].Nro));
                    for (int j = 0; j < sesion.CuitsDelUsuario[i].UNs.Count; j++)
                    {
                        CuitsTreeView.Nodes[CuitsTreeView.Nodes.Count - 1].ChildNodes.Add(new TreeNode(sesion.CuitsDelUsuario[i].UNs[j].Descr));
                        CuitsTreeView.Nodes[CuitsTreeView.Nodes.Count - 1].ChildNodes[CuitsTreeView.Nodes[CuitsTreeView.Nodes.Count - 1].ChildNodes.Count - 1].Value = sesion.CuitsDelUsuario[i].UNs[j].Id.ToString();
                        for (int h = 0; h < sesion.CuitsDelUsuario[i].UNs[j].PuntosVta.Count; h++)
                        {
                            CuitsTreeView.Nodes[CuitsTreeView.Nodes.Count - 1].ChildNodes[CuitsTreeView.Nodes[CuitsTreeView.Nodes.Count - 1].ChildNodes.Count - 1].ChildNodes.Add(new TreeNode(sesion.CuitsDelUsuario[i].UNs[j].PuntosVta[h].Nro.ToString("0000") + " (" + sesion.CuitsDelUsuario[i].UNs[j].PuntosVta[h].IdTipoPuntoVta + ")"));
                        }
                    }
                }
            }
        }
        protected void CuitsTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {
            switch (CuitsTreeView.SelectedNode.Depth)
            {
                case 0:
                    MensajeLabel.Text = "CUIT " + CuitsTreeView.SelectedNode.Value;
                    break;
                case 1:
                    MensajeLabel.Text = "UN " + CuitsTreeView.SelectedNode.Value;
                    break;
                case 2:
                    MensajeLabel.Text = "PuntoVta " + CuitsTreeView.SelectedNode.Value;
                    break;
            }
        }
    }
}