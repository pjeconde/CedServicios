using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas
{
    /// <comentarios/>
    [Serializable]
    public class comprobante_listado
    {

        private long cuit_vendedorField;

        private string razon_socialField;

        private string fecha_emisionField;

        private string fecha_vencimientoField;

        private double valor_total_facturaField;

        private int tipo_de_comprobanteField;

        private long numero_comprobanteField;

        private int punto_de_ventaField;

        private bool requiere_vinculacionField;

        private bool requiere_vinculacionFieldSpecified;

        private string estado_timestampField;

        private string fecha_timestampField;

        /// <comentarios/>
        public long cuit_vendedor
        {
            get
            {
                return this.cuit_vendedorField;
            }
            set
            {
                this.cuit_vendedorField = value;
            }
        }

        /// <comentarios/>
        public string razon_social
        {
            get
            {
                return this.razon_socialField;
            }
            set
            {
                this.razon_socialField = value;
            }
        }

        /// <comentarios/>
        public string fecha_emision
        {
            get
            {
                return this.fecha_emisionField;
            }
            set
            {
                this.fecha_emisionField = value;
            }
        }

        /// <comentarios/>
        public string fecha_vencimiento
        {
            get
            {
                return this.fecha_vencimientoField;
            }
            set
            {
                this.fecha_vencimientoField = value;
            }
        }

        /// <comentarios/>
        public double valor_total_factura
        {
            get
            {
                return this.valor_total_facturaField;
            }
            set
            {
                this.valor_total_facturaField = value;
            }
        }

        /// <comentarios/>
        public int tipo_de_comprobante
        {
            get
            {
                return this.tipo_de_comprobanteField;
            }
            set
            {
                this.tipo_de_comprobanteField = value;
            }
        }

        /// <comentarios/>
        public long numero_comprobante
        {
            get
            {
                return this.numero_comprobanteField;
            }
            set
            {
                this.numero_comprobanteField = value;
            }
        }

        /// <comentarios/>
        public int punto_de_venta
        {
            get
            {
                return this.punto_de_ventaField;
            }
            set
            {
                this.punto_de_ventaField = value;
            }
        }

        /// <comentarios/>
        public bool requiere_vinculacion
        {
            get
            {
                return this.requiere_vinculacionField;
            }
            set
            {
                this.requiere_vinculacionField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool requiere_vinculacionSpecified
        {
            get
            {
                return this.requiere_vinculacionFieldSpecified;
            }
            set
            {
                this.requiere_vinculacionFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string estado_timestamp
        {
            get
            {
                return this.estado_timestampField;
            }
            set
            {
                this.estado_timestampField = value;
            }
        }

        /// <comentarios/>
        public string fecha_timestamp
        {
            get
            {
                return this.fecha_timestampField;
            }
            set
            {
                this.fecha_timestampField = value;
            }
        }
    }
}
