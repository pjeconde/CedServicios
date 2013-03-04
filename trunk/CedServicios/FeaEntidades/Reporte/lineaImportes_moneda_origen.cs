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
	public partial class lineaImportes_moneda_origen
	{
        private string nombre_claseField = "<lineaImportes_moneda_origen>";

		private double precio_unitarioField;

		private bool precio_unitarioFieldSpecified;

		private double importe_total_articuloField;

		private bool importe_total_articuloFieldSpecified;

		private double importe_ivaField;

		private bool importe_ivaFieldSpecified;

		private double importe_total_descuentosField;

		private bool importe_total_descuentosFieldSpecified;

		private double importe_total_impuestosField;

		private bool importe_total_impuestosFieldSpecified;

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
		public double precio_unitario
		{
			get
			{
				return this.precio_unitarioField;
			}
			set
			{
				this.precio_unitarioField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool precio_unitarioSpecified
		{
			get
			{
				return this.precio_unitarioFieldSpecified;
			}
			set
			{
				this.precio_unitarioFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_total_articulo
		{
			get
			{
				return this.importe_total_articuloField;
			}
			set
			{
				this.importe_total_articuloField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_total_articuloSpecified
		{
			get
			{
				return this.importe_total_articuloFieldSpecified;
			}
			set
			{
				this.importe_total_articuloFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_iva
		{
			get
			{
				return this.importe_ivaField;
			}
			set
			{
				this.importe_ivaField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_ivaSpecified
		{
			get
			{
				return this.importe_ivaFieldSpecified;
			}
			set
			{
				this.importe_ivaFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_total_descuentos
		{
			get
			{
				return this.importe_total_descuentosField;
			}
			set
			{
				this.importe_total_descuentosField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_total_descuentosSpecified
		{
			get
			{
				return this.importe_total_descuentosFieldSpecified;
			}
			set
			{
				this.importe_total_descuentosFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_total_impuestos
		{
			get
			{
				return this.importe_total_impuestosField;
			}
			set
			{
				this.importe_total_impuestosField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_total_impuestosSpecified
		{
			get
			{
				return this.importe_total_impuestosFieldSpecified;
			}
			set
			{
				this.importe_total_impuestosFieldSpecified = value;
			}
		}
	}

}
