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
                CondIVADropDownList.DataBind();
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
                CondIngBrutosDropDownList.DataBind();
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
                NroIngBrutosTextBox.DataBind();
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
                FechaInicioActividadesTextBox.DataBind();
            }
        }
        public List<FeaEntidades.CondicionesIVA.CondicionIVA> ListaCondIVA
        {
            set
            {
                CondIVADropDownList.DataSource = value;
            }
        }
        public List<FeaEntidades.CondicionesIB.CondicionIB> ListaCondIngBrutos
        {
            set
            {
                CondIngBrutosDropDownList.DataSource = value;
            }
        }
    }
}