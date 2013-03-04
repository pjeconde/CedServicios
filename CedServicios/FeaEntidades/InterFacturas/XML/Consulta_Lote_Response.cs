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
	public class consulta_lote_response
	{
		string cuit_canalField;
		string cuit_vendedorField;
		string id_loteField;
		lote_comprobantes lote_comprobantesField;

		public string cuit_canal
		{
			get
			{
				return cuit_canalField;
			}
			set
			{
				cuit_canalField = value;
			}
		}
		
		public string cuit_vendedor
		{
			get
			{
				return cuit_vendedorField;
			}
			set
			{
				cuit_vendedorField = value;
			}
		}
	
		public string id_lote
		{
			get
			{
				return id_loteField;
			}
			set
			{
				id_loteField = value;
			}
		}

		public lote_comprobantes lote_comprobantes
		{
			get
			{
				return lote_comprobantesField;
			}
			set
			{
				lote_comprobantesField = value;
			}
		}

	}
}
