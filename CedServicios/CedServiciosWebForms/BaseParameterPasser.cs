using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CedServicios.WebForms
{
    public abstract class BaseParameterPasser
    {
        #region Atributos
        private string url = string.Empty;
        #endregion

        #region Constructores
        public BaseParameterPasser()
        {
            if (HttpContext.Current != null)
                url = HttpContext.Current.Request.Url.ToString();
        }

        public BaseParameterPasser(string Url)
        {
            this.url = Url;
        }
        #endregion

        #region Metodos
        public virtual void PassParameters()
        {
            if (HttpContext.Current != null)
                HttpContext.Current.Response.Redirect(Url);
        }
        #endregion

        #region Propiedades
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        public abstract string this[string name]
        {
            get;
            set;
        }

        public abstract ICollection Keys
        {
            get;
        }
        #endregion
    }
}
