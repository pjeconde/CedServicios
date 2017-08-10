using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    [System.SerializableAttribute()]
    public partial class linea : FeaEntidades.InterFacturas.linea
    {
        private short codigo_TurismoField;

        public linea() : base()
        {
        }

        public short codigo_Turismo
        {
            get
            {
                return this.codigo_TurismoField;
            }
            set
            {
                this.codigo_TurismoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string codigoTurismoDescripcion
        {
            get
            {
                if (codigo_Turismo != null && !codigo_Turismo.Equals(string.Empty))
                {
                    List<CodigosTurismo.CodigoTurismo> lct = CodigosTurismo.CodigoTurismo.Lista();
                    foreach (CodigosTurismo.CodigoTurismo ct in lct)
                    {
                        short auxCodigoTurismo = Convert.ToInt16(codigo_Turismo);
                        if (ct.Codigo.Equals(auxCodigoTurismo))
                        {
                            return ct.Descr;
                        }
                    }
                    return string.Empty;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
