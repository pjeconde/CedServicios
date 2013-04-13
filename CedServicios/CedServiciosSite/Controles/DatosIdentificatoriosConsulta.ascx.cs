using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class DatosIdentificatoriosConsulta : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public long GLN
        {
            get
            {
                return Convert.ToInt64(GLNTextBox.Text);
            }
            set
            {
                GLNTextBox.Text = value.ToString();
                GLNTextBox.DataBind();
            }
        }
        public string CodigoInterno
        {
            get
            {
                return CodigoInternoTextBox.Text;
            }
            set
            {
                CodigoInternoTextBox.Text = value;
                CodigoInternoTextBox.DataBind();
            }
        }
        public bool Enabled
        {
            set
            {
                GLNTextBox.Enabled = value;
                CodigoInternoTextBox.Enabled = value;
            }
        }
    }
}