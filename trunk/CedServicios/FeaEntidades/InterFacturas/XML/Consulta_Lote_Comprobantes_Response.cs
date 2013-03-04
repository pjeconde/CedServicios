using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace FeaEntidades.InterFacturas.XML
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
	public class consulta_lote_comprobantes_response
	{
		private consulta_lote_response consulta_lote_responseField;

		public consulta_lote_response consulta_lote_response
		{
			get
			{
				return consulta_lote_responseField;
			}
			set
			{
				consulta_lote_responseField = value;
			}
		}
	}
}
