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
	[FileHelpers.DelimitedRecord("|")]
	public partial class resumenImportes_moneda_origen
	{
        private string nombre_claseField = "<resumenImportes_moneda_origen>";

		private double importe_total_neto_gravadoField;

		private double importe_total_concepto_no_gravadoField;

		private double importe_operaciones_exentasField;

		private double impuesto_liqField;

		private double impuesto_liq_rniField;

		private double importe_total_impuestos_nacionalesField;

		private bool importe_total_impuestos_nacionalesFieldSpecified;

		private double importe_total_ingresos_brutosField;

		private bool importe_total_ingresos_brutosFieldSpecified;

		private double importe_total_impuestos_municipalesField;

		private bool importe_total_impuestos_municipalesFieldSpecified;

		private double importe_total_impuestos_internosField;

		private bool importe_total_impuestos_internosFieldSpecified;

		private double importe_total_facturaField;

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
	}
}
