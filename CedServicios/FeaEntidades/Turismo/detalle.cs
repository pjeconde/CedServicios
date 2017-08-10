using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    [System.SerializableAttribute()]
    public partial class detalle 
    {
        private string comentariosField;
        private linea[] lineaField;

        public detalle() : base()
        {
            lineaField = new linea[1000];
        }

        [System.Xml.Serialization.XmlElementAttribute("linea")]
        public new linea[] linea
        {
            get
            {
                return this.lineaField;
            }
            set
            {
                this.lineaField = value;
            }
        }

        public string comentarios
        {
            get
            {
                return this.comentariosField;
            }
            set
            {
                this.comentariosField = value;
            }
        }
    }
}
