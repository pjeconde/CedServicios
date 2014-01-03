using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas.Listado
{
    /// <comentarios/>
    /// 	/// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
    public class consulta_emisor_comprobante_listado
    {
        private long cuit_canalField;                       //11
        private string cod_interno_canalField;
        private long cuit_vendedorField;                    //11
        private int tipo_doc_compradorField;                //2
        private bool tipo_doc_compradorFieldSpecified;
        private long doc_compradorField;                    //11
        private bool doc_compradorFieldSpecified;
        private string denominacio_compradorField;          //100
        private string fecha_emision_desdeField;
        private string fecha_emision_hastaField;
        private int punto_de_ventaField;                    //4
        private bool punto_de_ventaFieldSpecified;
        private int tipo_de_comprobanteField;               //2
        private bool tipo_de_comprobanteFieldSpecified;
        private long numero_comprobante_desdeField;         //8
        private bool numero_comprobante_desdeFieldSpecified;
        private long numero_comprobante_hastaField;         //8
        private bool numero_comprobante_hastaFieldSpecified;
        private string estadoField;                         //valores posibles: 
                                                            //      'PR' / 'RA' / 'CA' / 'CO' / 'ET' 
        private string limiteField;                         //valores posibles: 
                                                            //      'WEB', si se elige este parámetro, devuelve hasta 250 registros.
                                                            //      'SCHEMA', devuelve la cantidad de registros defineidos en el schema (10000).

        /// <comentarios/>
        public long cuit_canal
        {
            get
            {
                return this.cuit_canalField;
            }
            set
            {
                this.cuit_canalField = value;
            }
        }

        /// <comentarios/>
        public string cod_interno_canal
        {
            get
            {
                return this.cod_interno_canalField;
            }
            set
            {
                this.cod_interno_canalField = value;
            }
        }

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
        public int tipo_doc_comprador
        {
            get
            {
                return this.tipo_doc_compradorField;
            }
            set
            {
                this.tipo_doc_compradorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tipo_doc_compradorSpecified
        {
            get
            {
                return this.tipo_doc_compradorFieldSpecified;
            }
            set
            {
                this.tipo_doc_compradorFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public long doc_comprador
        {
            get
            {
                return this.doc_compradorField;
            }
            set
            {
                doc_compradorField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool doc_compradorSpecified
        {
            get
            {
                return this.doc_compradorFieldSpecified;
            }
            set
            {
                this.doc_compradorFieldSpecified = value;
            }
        }
        
        /// <comentarios/>
        public string denominacio_comprador
        {
            get
            {
                return this.denominacio_compradorField;
            }
            set
            {
                this.denominacio_compradorField = value;
            }
        }

        /// <comentarios/>
        public string fecha_emision_desde
        {
            get
            {
                return this.fecha_emision_desdeField;
            }
            set
            {
                this.fecha_emision_desdeField = value;
            }
        }

        /// <comentarios/>
        public string fecha_emision_hasta
        {
            get
            {
                return this.fecha_emision_hastaField;
            }
            set
            {
                this.fecha_emision_hastaField = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool punto_de_ventaSpecified
        {
            get
            {
                return this.punto_de_ventaFieldSpecified;
            }
            set
            {
                this.punto_de_ventaFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool tipo_de_comprobanteSpecified
        {
            get
            {
                return this.tipo_de_comprobanteFieldSpecified;
            }
            set
            {
                this.tipo_de_comprobanteFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public long numero_comprobante_desde
        {
            get
            {
                return this.numero_comprobante_desdeField;
            }
            set
            {
                this.numero_comprobante_desdeField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numero_comprobante_desdeSpecified
        {
            get
            {
                return this.numero_comprobante_desdeFieldSpecified;
            }
            set
            {
                this.numero_comprobante_desdeFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public long numero_comprobante_hasta
        {
            get
            {
                return this.numero_comprobante_hastaField;
            }
            set
            {
                this.numero_comprobante_hastaField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numero_comprobante_hastaSpecified
        {
            get
            {
                return this.numero_comprobante_hastaFieldSpecified;
            }
            set
            {
                this.numero_comprobante_hastaFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string estado
        {
            get
            {
                return this.estadoField;
            }
            set
            {
                this.estadoField = value;
            }
        }

        /// <comentarios/>
        public string limite
        {
            get
            {
                return this.limiteField;
            }
            set
            {
                this.limiteField = value;
            }
        }
    }
}
