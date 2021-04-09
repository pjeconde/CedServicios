using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    public class Opcional
    {
        private string idField;
        private string valorField;
        private string errorDescrField;

        public Opcional()
        {
            idField = "";
            valorField = "";
            errorDescrField = "";
        }

        public string Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
        /// <remarks/>
        public string Valor
        {
            get
            {
                return this.valorField;
            }
            set
            {
                this.valorField = value;
            }
        }
        public string ErrorDescr
        {
            get
            {
                return this.errorDescrField;
            }
            set
            {
                this.errorDescrField = value;
            }
        }
    }
}
