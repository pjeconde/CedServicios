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
	public partial class detalle
	{
        private string nombre_claseField = "<detalle>";

		private string comentariosField;

		//[FileHelpers.FieldConverter(typeof(FeaEntidades.Converters.lineaConverter))]
		[FileHelpers.FieldIgnored()]
		private linea[] lineaField = new linea[1000];

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
		[System.Xml.Serialization.XmlElementAttribute("linea")]
		public linea[] linea
		{
			get
			{
				return this.lineaField;
			}
			set
			{
				this.lineaField = value;
			}
		}

		/// <comentarios/>
		public string comentarios
		{
			get
			{
				return this.comentariosField;
			}
			set
			{
				this.comentariosField = value;
			}
		}
	}

}
