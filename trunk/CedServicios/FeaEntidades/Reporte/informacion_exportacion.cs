using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Reporte
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
	[FileHelpers.DelimitedRecord("|")]
	public partial class informacion_exportacion
	{
        private string nombre_claseField = "<informacion_exportacion>";

		private int destino_comprobanteField;

        private int tipo_exportacionField;

		private string id_impositivoField;

        private string incotermsField;

        private string descripcion_incotermsField;
        
        private string permiso_existenteField;

        [FileHelpers.FieldIgnored()]
        private permisos[] permisosField = new permisos[10];

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
		public int destino_comprobante
		{
			get
			{
				return this.destino_comprobanteField;
			}
			set
			{
				this.destino_comprobanteField = value;
			}
		}

        /// <comentarios/>
		public int tipo_exportacion
		{
			get
			{
				return this.tipo_exportacionField;
			}
			set
			{
				this.tipo_exportacionField = value;
			}
		}

        /// <comentarios/>
		public string id_impositivo
		{
			get
			{
				return this.id_impositivoField;
			}
			set
			{
				this.id_impositivoField = value;
			}
		}

        /// <comentarios/>
		public string incoterms
		{
			get
			{
				return this.incotermsField;
			}
			set
			{
				this.incotermsField = value;
			}
		}

        /// <comentarios/>
        public string descripcion_incoterms
		{
			get
			{
                return this.descripcion_incotermsField;
			}
			set
			{
                this.descripcion_incotermsField = value;
			}
		}
        
        /// <comentarios/>
		public string permiso_existente
		{
			get
			{
				return this.permiso_existenteField;
			}
			set
			{
				this.permiso_existenteField = value;
			}
		}

        [System.Xml.Serialization.XmlElementAttribute("permisos")]
        public permisos[] permisos
        {
            get
            {
                return this.permisosField;
            }
            set
            {
                this.permisosField = value;
            }
        }

    }
}
