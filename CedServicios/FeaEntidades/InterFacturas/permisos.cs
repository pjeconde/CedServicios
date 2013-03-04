using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas
{
	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://lote.schemas.cfe.ib.com.ar/")]
	[FileHelpers.DelimitedRecord("|")]
	public partial class permisos
	{
        private string nombre_claseField = "<permisos>";

        private string id_permisoField;

        private int destino_mercaderiaField;

        [FileHelpers.FieldIgnored()]
		private string descripcion_destino_mercaderiaField;

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
		public string id_permiso
		{
			get
			{
				return this.id_permisoField;
			}
			set
			{
				this.id_permisoField = value;
			}
		}

        /// <comentarios/>
		public int destino_mercaderia
		{
			get
			{
				return this.destino_mercaderiaField;
			}
			set
			{
				this.destino_mercaderiaField = value;
			}
		}

		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public string descripcion_destino_mercaderia
		{
			get
			{
				return this.descripcion_destino_mercaderiaField;
			}
			set
			{
				this.descripcion_destino_mercaderiaField = value;
			}
		}

    }
}
