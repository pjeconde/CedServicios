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
	public partial class resumen
	{
        private string nombre_claseField = "<resumen>";

		private double importe_total_neto_gravadoField;

		private double importe_total_concepto_no_gravadoField;

		private double importe_operaciones_exentasField;

		private double impuesto_liqField;

		private double impuesto_liq_rniField;

		private double importe_total_impuestos_nacionalesField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool importe_total_impuestos_nacionalesFieldSpecified;

		private double importe_total_ingresos_brutosField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool importe_total_ingresos_brutosFieldSpecified;

		private double importe_total_impuestos_municipalesField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool importe_total_impuestos_municipalesFieldSpecified;

		private double importe_total_impuestos_internosField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
		private bool importe_total_impuestos_internosFieldSpecified;

		private double importe_total_facturaField;

		private double tipo_de_cambioField;

		private string codigo_monedaField;

		private string observacionesField;

		private int cant_alicuotas_ivaField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
        private bool cant_alicuotas_ivaFieldSpecified;

		//[FileHelpers.FieldConverter(typeof(FeaEntidades.Converters.resumenImportes_moneda_origenConverter))]
		[FileHelpers.FieldIgnored()]
		private resumenImportes_moneda_origen importes_moneda_origenField;

		//[FileHelpers.FieldArrayLength(1, 1)]
		//[FileHelpers.FieldConverter(typeof(FeaEntidades.Converters.resumenDescuentosConverter))]
		[FileHelpers.FieldIgnored()]
		private resumenDescuentos[] descuentosField = new resumenDescuentos[50];

		//[FileHelpers.FieldArrayLength(1, 1)]
		//[FileHelpers.FieldConverter(typeof(FeaEntidades.Converters.resumenImpuestosConverter))]
		[FileHelpers.FieldIgnored()]
		private resumenImpuestos[] impuestosField;

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
		[System.Xml.Serialization.XmlElementAttribute("descuentos")]
		public resumenDescuentos[] descuentos
		{
			get
			{
				return this.descuentosField;
			}
			set
			{
				this.descuentosField = value;
			}
		}

		/// <comentarios/>
		public double importe_total_neto_gravado
		{
			get
			{
				return this.importe_total_neto_gravadoField;
			}
			set
			{
				this.importe_total_neto_gravadoField = value;
			}
		}

		/// <comentarios/>
		public double importe_total_concepto_no_gravado
		{
			get
			{
				return this.importe_total_concepto_no_gravadoField;
			}
			set
			{
				this.importe_total_concepto_no_gravadoField = value;
			}
		}

		/// <comentarios/>
		public double importe_operaciones_exentas
		{
			get
			{
				return this.importe_operaciones_exentasField;
			}
			set
			{
				this.importe_operaciones_exentasField = value;
			}
		}

		/// <comentarios/>
		public double impuesto_liq
		{
			get
			{
				return this.impuesto_liqField;
			}
			set
			{
				this.impuesto_liqField = value;
			}
		}

		/// <comentarios/>
		public double impuesto_liq_rni
		{
			get
			{
				return this.impuesto_liq_rniField;
			}
			set
			{
				this.impuesto_liq_rniField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlElementAttribute("impuestos")]
		public resumenImpuestos[] impuestos
		{
			get
			{
				return this.impuestosField;
			}
			set
			{
				this.impuestosField = value;
			}
		}

		/// <comentarios/>
		public double importe_total_impuestos_nacionales
		{
			get
			{
				return this.importe_total_impuestos_nacionalesField;
			}
			set
			{
				this.importe_total_impuestos_nacionalesField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_total_impuestos_nacionalesSpecified
		{
			get
			{
				return this.importe_total_impuestos_nacionalesFieldSpecified;
			}
			set
			{
				this.importe_total_impuestos_nacionalesFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_total_ingresos_brutos
		{
			get
			{
				return this.importe_total_ingresos_brutosField;
			}
			set
			{
				this.importe_total_ingresos_brutosField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_total_ingresos_brutosSpecified
		{
			get
			{
				return this.importe_total_ingresos_brutosFieldSpecified;
			}
			set
			{
				this.importe_total_ingresos_brutosFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_total_impuestos_municipales
		{
			get
			{
				return this.importe_total_impuestos_municipalesField;
			}
			set
			{
				this.importe_total_impuestos_municipalesField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_total_impuestos_municipalesSpecified
		{
			get
			{
				return this.importe_total_impuestos_municipalesFieldSpecified;
			}
			set
			{
				this.importe_total_impuestos_municipalesFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_total_impuestos_internos
		{
			get
			{
				return this.importe_total_impuestos_internosField;
			}
			set
			{
				this.importe_total_impuestos_internosField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_total_impuestos_internosSpecified
		{
			get
			{
				return this.importe_total_impuestos_internosFieldSpecified;
			}
			set
			{
				this.importe_total_impuestos_internosFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_total_factura
		{
			get
			{
				return this.importe_total_facturaField;
			}
			set
			{
				this.importe_total_facturaField = value;
			}
		}

		/// <comentarios/>
		public double tipo_de_cambio
		{
			get
			{
				return this.tipo_de_cambioField;
			}
			set
			{
				this.tipo_de_cambioField = value;
			}
		}

		/// <comentarios/>
		public string codigo_moneda
		{
			get
			{
				return this.codigo_monedaField;
			}
			set
			{
				this.codigo_monedaField = value;
			}
		}

		/// <comentarios/>
		public string observaciones
		{
			get
			{
				return this.observacionesField;
			}
			set
			{
				this.observacionesField = value;
			}
		}

		/// <comentarios/>
		public int cant_alicuotas_iva
		{
			get
			{
				return this.cant_alicuotas_ivaField;
			}
			set
			{
				this.cant_alicuotas_ivaField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool cant_alicuotas_ivaSpecified
		{
			get
			{
				return this.cant_alicuotas_ivaFieldSpecified;
			}
			set
			{
				this.cant_alicuotas_ivaFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public resumenImportes_moneda_origen importes_moneda_origen
		{
			get
			{
				return this.importes_moneda_origenField;
			}
			set
			{
				this.importes_moneda_origenField = value;
			}
		}
	}

}
