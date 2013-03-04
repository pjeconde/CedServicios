using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Reporte
{
	/// <comentarios/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
	[FileHelpers.DelimitedRecord("|")]
	public partial class informacion_comprobante
	{
        private string nombre_claseField = "<informacion_comprobante>";

		private int tipo_de_comprobanteField;

		private long numero_comprobanteField;

		private int punto_de_ventaField;

		private string fecha_emisionField;

		private string fecha_vencimientoField;

		private string fecha_serv_desdeField;

		private string fecha_serv_hastaField;

		private string condicion_de_pagoField;
        
        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
		private bool condicion_de_pagoFieldSpecified;

		private string iva_computableField;

		private string codigo_operacionField;

		private string caeField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool caeFieldSpecified;

		private string fecha_vencimiento_caeField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool fecha_vencimiento_caeFieldSpecified;

        private string fecha_obtencion_caeField;
        
        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool fecha_obtencion_caeFieldSpecified;

		private string resultadoField;

		private string motivoField;

		private string es_detalle_encriptadoField;

		//[FileHelpers.FieldConverter(typeof(FeaEntidades.Converters.informacion_comprobanteReferenciasConverter))]
		//[FileHelpers.FieldNullValue(new informacion_comprobanteReferencias[0])]
		[FileHelpers.FieldIgnored()]
		private informacion_comprobanteReferencias[] referenciasField = new informacion_comprobanteReferencias[10];

        [FileHelpers.FieldIgnored()]
        private informacion_exportacion informacion_exportacionField;

		private int codigo_conceptoField;

		[FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
		private bool codigo_conceptoFieldSpecified;

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public string nombre_clase
        {
            get
            {
                return nombre_claseField;
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
		public string fecha_serv_desde
		{
			get
			{
				return this.fecha_serv_desdeField;
			}
			set
			{
				this.fecha_serv_desdeField = value;
			}
		}

		/// <comentarios/>
		public string fecha_serv_hasta
		{
			get
			{
				return this.fecha_serv_hastaField;
			}
			set
			{
				this.fecha_serv_hastaField = value;
			}
		}

		/// <comentarios/>
		public string condicion_de_pago
		{
			get
			{
				return this.condicion_de_pagoField;
			}
			set
			{
				this.condicion_de_pagoField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool condicion_de_pagoSpecified
		{
			get
			{
				return this.condicion_de_pagoFieldSpecified;
			}
			set
			{
				this.condicion_de_pagoFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public string iva_computable
		{
			get
			{
				return this.iva_computableField;
			}
			set
			{
				this.iva_computableField = value;
			}
		}

		/// <comentarios/>
		public string codigo_operacion
		{
			get
			{
				return this.codigo_operacionField;
			}
			set
			{
				this.codigo_operacionField = value;
			}
		}

		/// <comentarios/>
		public string cae
		{
			get
			{
				return this.caeField;
			}
			set
			{
				this.caeField = value;
			}
		}

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool caeSpecified
        {
            get
            {
                return this.caeFieldSpecified;
            }
            set
            {
                this.caeFieldSpecified = value;
            }
        }

		/// <comentarios/>
		public string fecha_vencimiento_cae
		{
			get
			{
				return this.fecha_vencimiento_caeField;
			}
			set
			{
				this.fecha_vencimiento_caeField = value;
			}
		}

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fecha_vencimiento_caeSpecified
        {
            get
            {
                return this.fecha_vencimiento_caeFieldSpecified;
            }
            set
            {
                this.fecha_vencimiento_caeFieldSpecified = value;
            }
        }

		/// <comentarios/>
		public string fecha_obtencion_cae
		{
			get
			{
				return this.fecha_obtencion_caeField;
			}
			set
			{
				this.fecha_obtencion_caeField = value;
			}
		}

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fecha_obtencion_caeSpecified
        {
            get
            {
                return this.fecha_obtencion_caeFieldSpecified;
            }
            set
            {
                this.fecha_obtencion_caeFieldSpecified = value;
            }
        }

		/// <comentarios/>
		public string resultado
		{
			get
			{
				return this.resultadoField;
			}
			set
			{
				this.resultadoField = value;
			}
		}

		/// <comentarios/>
		public string motivo
		{
			get
			{
				return this.motivoField;
			}
			set
			{
				this.motivoField = value;
			}
		}

		/// <comentarios/>
		public string es_detalle_encriptado
		{
			get
			{
				return this.es_detalle_encriptadoField;
			}
			set
			{
				this.es_detalle_encriptadoField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlElementAttribute("referencias")]
		public informacion_comprobanteReferencias[] referencias
		{
			get
			{
				return this.referenciasField;
			}
			set
			{
				this.referenciasField = value;
			}
		}
        
        /// <comentarios/>
        public informacion_exportacion informacion_exportacion
        {
            get
            {
                return this.informacion_exportacionField;
            }
            set
            {
                this.informacion_exportacionField = value;
            }
        }

		 /// <comentarios/>
        public int codigo_concepto
        {
            get
            {
                return this.codigo_conceptoField;
            }

            set
            {
                this.codigo_conceptoField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool codigo_conceptoSpecified
        {
            get
            {
                return this.codigo_conceptoFieldSpecified;
            }
            set
            {
                this.codigo_conceptoFieldSpecified = value;
            }
        }

	}
}
