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
	public partial class extensiones
	{
        private string nombre_claseField = "<extensiones>";

        [FileHelpers.FieldIgnored()]
		private extensionesExtensiones_camara_facturas extensiones_camara_facturasField;
        
        [FileHelpers.FieldIgnored()]
		[FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
		private bool extensiones_camara_facturasFieldSpecified;

		private string extensiones_datos_comercialesField;

		private string extensiones_datos_marketingField;

		private string extensiones_signaturesField;

        [FileHelpers.FieldIgnored()]
        private extensionesExtensiones_destinatarios extensiones_destinatariosField;

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
		public extensionesExtensiones_camara_facturas extensiones_camara_facturas
		{
			get
			{
				return this.extensiones_camara_facturasField;
			}
			set
			{
				this.extensiones_camara_facturasField = value;
			}
		}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool extensiones_camara_facturasSpecified
		{
			get
			{
				return this.extensiones_camara_facturasFieldSpecified;
			}
			set
			{
				this.extensiones_camara_facturasFieldSpecified = value;
			}
		}


		/// <comentarios/>
		public string extensiones_datos_comerciales
		{
			get
			{
				return this.extensiones_datos_comercialesField;
			}
			set
			{
				this.extensiones_datos_comercialesField = value;
			}
		}

		/// <comentarios/>
		public string extensiones_datos_marketing
		{
			get
			{
				return this.extensiones_datos_marketingField;
			}
			set
			{
				this.extensiones_datos_marketingField = value;
			}
		}

		/// <comentarios/>
		public string extensiones_signatures
		{
			get
			{
				return this.extensiones_signaturesField;
			}
			set
			{
				this.extensiones_signaturesField = value;
			}
		}

        /// <comentarios/>
        public extensionesExtensiones_destinatarios extensiones_destinatarios
        {
            get
            {
                return this.extensiones_destinatariosField;
            }
            set
            {
                this.extensiones_destinatariosField = value;
            }
        }
	}
}
