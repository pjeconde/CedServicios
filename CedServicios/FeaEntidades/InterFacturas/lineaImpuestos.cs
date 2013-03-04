using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas
{
	/// <comentarios/>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
	[FileHelpers.DelimitedRecord("|")]
	public partial class lineaImpuestos
	{

		private int codigo_impuestoField;

		private string descripcion_impuestoField;

		private double porcentaje_impuestoField;

		private bool porcentaje_impuestoFieldSpecified;

		private double importe_impuestoField;

		private double importe_impuesto_moneda_origenField;

		private bool importe_impuesto_moneda_origenFieldSpecified;

		/// <comentarios/>
		public int codigo_impuesto
		{
			get
			{
				return this.codigo_impuestoField;
			}
			set
			{
				this.codigo_impuestoField = value;
			}
		}

		/// <comentarios/>
		public string descripcion_impuesto
		{
			get
			{
				return this.descripcion_impuestoField;
			}
			set
			{
				this.descripcion_impuestoField = value;
			}
		}

		/// <comentarios/>
		public double porcentaje_impuesto
		{
			get
			{
				return this.porcentaje_impuestoField;
			}
			set
			{
				this.porcentaje_impuestoField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool porcentaje_impuestoSpecified
		{
			get
			{
				return this.porcentaje_impuestoFieldSpecified;
			}
			set
			{
				this.porcentaje_impuestoFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public double importe_impuesto
		{
			get
			{
				return this.importe_impuestoField;
			}
			set
			{
				this.importe_impuestoField = value;
			}
		}

		/// <comentarios/>
		public double importe_impuesto_moneda_origen
		{
			get
			{
				return this.importe_impuesto_moneda_origenField;
			}
			set
			{
				this.importe_impuesto_moneda_origenField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool importe_impuesto_moneda_origenSpecified
		{
			get
			{
				return this.importe_impuesto_moneda_origenFieldSpecified;
			}
			set
			{
				this.importe_impuesto_moneda_origenFieldSpecified = value;
			}
		}
	}
}
