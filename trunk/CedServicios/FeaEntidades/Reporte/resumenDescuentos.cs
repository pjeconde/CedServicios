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
	public partial class resumenDescuentos
	{
        private string nombre_claseField = "<resumenDescuentos>";

		private string descripcion_descuentoField;

		private double porcentaje_descuentoField;

		private bool porcentaje_descuentoFieldSpecified;

		private double importe_descuentoField;

		private double importe_descuento_moneda_origenField;

		private bool importe_descuento_moneda_origenFieldSpecified;

		private double alicuota_iva_descuentoField;

		private bool alicuota_iva_descuentoFieldSpecified;

		private double importe_iva_descuentoField;

		private bool importe_iva_descuentoFieldSpecified;

		private double importe_iva_descuento_moneda_origenField;

		private bool importe_iva_descuento_moneda_origenFieldSpecified;

        private string indicacion_exento_gravado_descuentoField;

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
		public string descripcion_descuento
		{
			get
			{
				return this.descripcion_descuentoField;
			}
			set
			{
				this.descripcion_descuentoField = value;
			}
		}

		/// <comentarios/>
		public double porcentaje_descuento
		{
			get
			{
				return this.porcentaje_descuentoField;
			}
			set
			{
				this.porcentaje_descuentoField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool porcentaje_descuentoSpecified
		{
			get
			{
				return this.porcentaje_descuentoFieldSpecified;
			}
			set
			{
				this.porcentaje_descuentoFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_descuento
		{
			get
			{
				return this.importe_descuentoField;
			}
			set
			{
				this.importe_descuentoField = value;
			}
		}

		/// <comentarios/>
		public double importe_descuento_moneda_origen
		{
			get
			{
				return this.importe_descuento_moneda_origenField;
			}
			set
			{
				this.importe_descuento_moneda_origenField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_descuento_moneda_origenSpecified
		{
			get
			{
				return this.importe_descuento_moneda_origenFieldSpecified;
			}
			set
			{
				this.importe_descuento_moneda_origenFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double alicuota_iva_descuento
		{
			get
			{
				return this.alicuota_iva_descuentoField;
			}
			set
			{
				this.alicuota_iva_descuentoField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool alicuota_iva_descuentoSpecified
		{
			get
			{
				return this.alicuota_iva_descuentoFieldSpecified;
			}
			set
			{
				this.alicuota_iva_descuentoFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_iva_descuento
		{
			get
			{
				return this.importe_iva_descuentoField;
			}
			set
			{
				this.importe_iva_descuentoField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_iva_descuentoSpecified
		{
			get
			{
				return this.importe_iva_descuentoFieldSpecified;
			}
			set
			{
				this.importe_iva_descuentoFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_iva_descuento_moneda_origen
		{
			get
			{
				return this.importe_iva_descuento_moneda_origenField;
			}
			set
			{
				this.importe_iva_descuento_moneda_origenField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_iva_descuento_moneda_origenSpecified
		{
			get
			{
				return this.importe_iva_descuento_moneda_origenFieldSpecified;
			}
			set
			{
				this.importe_iva_descuento_moneda_origenFieldSpecified = value;
			}
		}

        /// <comentarios/>
        public string indicacion_exento_gravado_descuento
        {
            get
            {
                return this.indicacion_exento_gravado_descuentoField;
            }
            set
            {
                this.indicacion_exento_gravado_descuentoField = value;
            }
        }
	}
}
