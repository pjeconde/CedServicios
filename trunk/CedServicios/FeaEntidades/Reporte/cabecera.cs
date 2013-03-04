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
	public partial class cabecera
	{

		private informacion_comprobante informacion_comprobanteField;

		private informacion_vendedor informacion_vendedorField;

		private informacion_comprador informacion_compradorField;

		/// <comentarios/>
		public informacion_comprobante informacion_comprobante
		{
			get
			{
				return this.informacion_comprobanteField;
			}
			set
			{
				this.informacion_comprobanteField = value;
			}
		}

		/// <comentarios/>
		public informacion_vendedor informacion_vendedor
		{
			get
			{
				return this.informacion_vendedorField;
			}
			set
			{
				this.informacion_vendedorField = value;
			}
		}

		/// <comentarios/>
		public informacion_comprador informacion_comprador
		{
			get
			{
				return this.informacion_compradorField;
			}
			set
			{
				this.informacion_compradorField = value;
			}
		}
	}
}
