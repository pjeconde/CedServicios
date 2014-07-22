using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class DatosImpositivos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public int IdCondIVA
        {
            get
            {
                return Convert.ToInt32(CondIVADropDownList.SelectedValue);
            }
            set
            {
                CondIVADropDownList.SelectedValue = value.ToString();
            }
        }
        public string DescrCondIVA
        {
            get
            {
                return CondIVADropDownList.SelectedItem.Text;
            }
        }
        public int IdCondIngBrutos
        {
            get
            {
                return Convert.ToInt32(CondIngBrutosDropDownList.SelectedValue);
            }
            set
            {
                CondIngBrutosDropDownList.SelectedValue = value.ToString();
            }
        }
        public string DescrCondIngBrutos
        {
            get
            {
                return CondIngBrutosDropDownList.SelectedItem.Text;
            }
        }
        public string NroIngBrutos
        {
            get
            {
                return NroIngBrutosTextBox.Text;
            }
            set
            {
                NroIngBrutosTextBox.Text = value;
            }
        }
        public DateTime FechaInicioActividades
        {
            get
            {
                return new DateTime(Convert.ToInt32(FechaInicioActividadesTextBox.Text.Substring(0, 4)), Convert.ToInt32(FechaInicioActividadesTextBox.Text.Substring(4, 2)),Convert.ToInt32(FechaInicioActividadesTextBox.Text.Substring(6, 2)));
            }
            set
            {
                FechaInicioActividadesTextBox.Text = value.ToString("yyyyMMdd");
            }
        }
        public List<FeaEntidades.CondicionesIVA.CondicionIVA> ListaCondIVA
        {
            set
            {
                CondIVADropDownList.DataSource = value;
                CondIVADropDownList.DataBind();
            }
        }
        public List<FeaEntidades.CondicionesIB.CondicionIB> ListaCondIngBrutos
        {
            set
            {
                CondIngBrutosDropDownList.DataSource = value;
                CondIngBrutosDropDownList.DataBind();
            }
        }
        public bool Enabled
        {
            set
            {
                CondIVADropDownList.Enabled = value;
                CondIngBrutosDropDownList.Enabled = value;
                NroIngBrutosTextBox.Enabled = value;
                FechaInicioActividadesTextBox.Enabled = value;
                FechaInicioActividadesImage.Visible = value;
            }
        }
    }
}