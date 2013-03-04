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
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
    [FileHelpers.DelimitedRecord("|")]
    public partial class comprobante
	{

		private cabecera cabeceraField;

		private detalle detalleField;

		private resumen resumenField;

		private extensiones extensionesField;

		[FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
		private bool extensionesFieldSpecified;


		/// <comentarios/>
		public cabecera cabecera
		{
			get
			{
				return this.cabeceraField;
			}
			set
			{
				this.cabeceraField = value;
			}
		}

		/// <comentarios/>
		public detalle detalle
		{
			get
			{
				return this.detalleField;
			}
			set
			{
				this.detalleField = value;
			}
		}

		/// <comentarios/>
		public resumen resumen
		{
			get
			{
				return this.resumenField;
			}
			set
			{
				this.resumenField = value;
			}
		}

		/// <comentarios/>
		public extensiones extensiones
		{
			get
			{
				return this.extensionesField;
			}
			set
			{
				this.extensionesField = value;
			}
		}
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool extensionesSpecified
		{
			get
			{
				return this.extensionesFieldSpecified;
			}
			set
			{
				this.extensionesFieldSpecified = value;
			}
		}
	}

}
