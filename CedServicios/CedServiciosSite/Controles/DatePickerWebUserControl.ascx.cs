using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace CedServicios.Site.Controles
{
    [ValidationPropertyAttribute("CalendarDateString")]
    public partial class DatePickerWebUserControl : System.Web.UI.UserControl
    {
        private const string DateFormat = "yyyyMMdd";

        protected void Page_Load(object sender, EventArgs e)
        {
            // links to CSS and JS files in "cal" subdirectory
            litJS.Text = "<script language=\"javascript\" src='" + ResolveUrl("cal/popcalendar.js") + "' type=\"text/javascript\"></script>";

            string scriptStr = "javascript:return popUpCalendar(this, '" + ResolveUrl("cal") + "/', document.getElementById('" + getClientID() + @"'), '" + DateFormat + "')";
            imgCalendar.Attributes.Add("onclick", scriptStr);
        }
        public string getClientID()
        {
            return txt_Date.ClientID;
        }

        [Category("Appearance")]
        [Description("CSS class name applied to the text box.")]
        [Browsable(true)]
        public string TextCssClass
        {
            get { return txt_Date.CssClass; }
            set { txt_Date.CssClass = value; }
        }
        public bool ReadOnly
        {
            get { return txt_Date.ReadOnly; }
            set { txt_Date.ReadOnly = value; }
        }
        public override void Focus()
        {
            txt_Date.Focus();
        }
        /// <summary>
        /// Gets or sets the content of the textbox which represents a date.
        /// </summary>
        [Bindable(true, BindingDirection.TwoWay)]
        [Browsable(true)]
        public string CalendarDateString
        {
            get
            {
                return txt_Date.Text;
            }
            set
            {
                txt_Date.Text = value;
                DateTime date;
                if (DateTime.TryParseExact(value, DateFormat, null, System.Globalization.DateTimeStyles.None, out date))
                {
                    if (date.Date == DateTime.MaxValue.Date)
                    {
                        txt_Date.Text = "";
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a DateTime representation of the currently selected date.
        /// </summary>
        [Bindable(true, BindingDirection.TwoWay)]
        [Browsable(true)]
        public DateTime CalendarDate
        {
            get
            {
                DateTime date;
                if (DateTime.TryParseExact(txt_Date.Text, DateFormat, null, System.Globalization.DateTimeStyles.None, out date))
                {
                    return date;
                }
                return DateTime.MaxValue;
            }
            set
            {
                txt_Date.Text = value.ToString(DateFormat);
            }
        }
    }
}