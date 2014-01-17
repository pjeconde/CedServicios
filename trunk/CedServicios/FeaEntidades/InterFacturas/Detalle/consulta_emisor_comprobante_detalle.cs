using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas.Detalle
{
    /// <comentarios/>
    /// 	/// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
    public class consulta_emisor_comprobante_detalle
    {
        private long cuit_canalField;                       //11
        private string cod_interno_canalField;
        private long cuit_vendedorField;                    //11
        private int punto_de_ventaField;                    //4
        private int tipo_de_comprobanteField;               //2
        private long numero_comprobanteField;               //8
        private long id_LoteField;
        private bool id_LoteFieldSpecified;
        private string estadoField;                         //valores posibles: 
                                                            //      'PR' / 'RA' / 'CA' / 'CO' / 'ET' 
        private bool estadoFieldSpecified;

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
        public long id_Lote
        {
            get
            {
                return this.id_LoteField;
            }
            set
            {
                this.id_LoteField = value;
            }
        }
        
        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool id_LoteSpecified
        {
            get
            {
                return this.id_LoteFieldSpecified;
            }
            set
            {
                this.id_LoteFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool estadoSpecified
        {
            get
            {
                return this.estadoFieldSpecified;
            }
            set
            {
                this.estadoFieldSpecified = value;
            }
        }
    }
}
