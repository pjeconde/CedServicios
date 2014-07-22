using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CedServicios.Site.Controles
{
    public partial class ContactoConsulta : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string Nombre
        {
            get
            {
                return NombreContactoTextBox.Text;
            }
            set
            {
                NombreContactoTextBox.Text = value;
            }
        }
        public string Email
        {
            get
            {
                return EmailContactoTextBox.Text;
            }
            set
            {
                EmailContactoTextBox.Text = value;
            }
        }
        public string Telefono
        {
            get
            {
                return TelefonoContactoTextBox.Text;
            }
            set
            {
                TelefonoContactoTextBox.Text = value;
            }
        }
        public bool Enabled
        {
            set
            {
                NombreContactoTextBox.Enabled = value;
                EmailContactoTextBox.Enabled = value;
                TelefonoContactoTextBox.Enabled = value;
            }
        }
    }
}