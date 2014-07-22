using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class DatosIdentificatorios : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public long GLN
        {
            get
            {
                if (GLNTextBox.Text.Equals(String.Empty))
                {
                    return Convert.ToInt64(0);
                }
                else
                {
                    return Convert.ToInt64(GLNTextBox.Text);
                }
            }
            set
            {
                if (value == 0)
                {
                    GLNTextBox.Text = String.Empty;
                }
                else
                {
                    GLNTextBox.Text = value.ToString();
                }
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