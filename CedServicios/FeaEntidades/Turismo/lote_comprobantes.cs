using System;
using System.Collections.Generic;
using System.Text;
using FileHelpers;
//using FileHelpers.RunTime; 

namespace FeaEntidades.Turismo
{
	/// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://lote.schemas.cfe.ib.com.ar/", IsNullable = false)]
    [FileHelpers.DelimitedRecord("|")]
    public partial class lote_comprobantes
	{

		private comprobante[] comprobanteField=new comprobante[100];

		/// <comentarios/>
		[System.Xml.Serialization.XmlElementAttribute("comprobante")]
		public comprobante[] comprobante
		{
			get
			{
				return this.comprobanteField;
			}
			set
			{
				this.comprobanteField = value;
			}
		}
	}

}
