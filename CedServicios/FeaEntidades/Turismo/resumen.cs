using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    [System.SerializableAttribute()]
    public partial class resumen : FeaEntidades.InterFacturas.resumen
    {
        private decimal importe_ReintegroField;
        private bool importe_ReintegroFieldSpecified;

        public resumen() : base()
        {
        }

        public decimal importe_Reintegro
        {
            get
            {
                return this.importe_ReintegroField;
            }
            set
            {
                this.importe_ReintegroField = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool importe_ReintegroSpecified
        {
            get
            {
                return this.importe_ReintegroFieldSpecified;
            }
            set
            {
                this.importe_ReintegroFieldSpecified = value;
            }
        }
    }
}
