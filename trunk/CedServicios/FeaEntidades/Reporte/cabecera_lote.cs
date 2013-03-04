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
	public partial class cabecera_lote
	{
        private string nombre_claseField = "<cabecera_lote>";
        
        private long id_loteField;

		private long cuit_canalField;

		private string cod_interno_canalField;

		private long cuit_vendedorField;

		private int cantidad_regField;

		private int presta_servField;

        [FileHelpers.FieldConverter(FileHelpers.ConverterKind.Boolean, "1", "0")]
		private bool presta_servFieldSpecified;

		private string fecha_envio_loteField;

		private int punto_de_ventaField;

		private string resultadoField;

		private string motivoField;
        
        private string no_disponibleField;

        private bool no_disponibleFieldSpecified;

        private string gestionar_afipField;

        private bool gestionar_afipFieldSpecified;
        
		/// <comentarios/>
		public long id_lote
		{
			get
			{
				return this.id_loteField;
			}
			set
			{
				this.id_loteField = value;
			}
		}

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
		public long cuit_canal
		{
			get
			{
				return this.cuit_canalField;
			}
			set
			{
				this.cuit_canalField = value;
			}
		}

		/// <comentarios/>
		public string cod_interno_canal
		{
			get
			{
				return this.cod_interno_canalField;
			}
			set
			{
				this.cod_interno_canalField = value;
			}
		}

		/// <comentarios/>
		public long cuit_vendedor
		{
			get
			{
				return this.cuit_vendedorField;
			}
			set
			{
				this.cuit_vendedorField = value;
			}
		}

		/// <comentarios/>
		public int cantidad_reg
		{
			get
			{
				return this.cantidad_regField;
			}
			set
			{
				this.cantidad_regField = value;
			}
		}

		/// <comentarios/>
		public int presta_serv
		{
			get
			{
				return this.presta_servField;
			}
			set
			{
				this.presta_servField = value;
			}
		}

		/// <comentarios/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool presta_servSpecified
		{
			get
			{
				return this.presta_servFieldSpecified;
			}
			set
			{
				this.presta_servFieldSpecified = value;
			}
		}

		/// <comentarios/>
		public string fecha_envio_lote
		{
			get
			{
				return this.fecha_envio_loteField;
			}
			set
			{
				this.fecha_envio_loteField = value;
			}
		}

		/// <comentarios/>
		public int punto_de_venta
		{
			get
			{
				return this.punto_de_ventaField;
			}
			set
			{
				this.punto_de_ventaField = value;
			}
		}

		/// <comentarios/>
		public string resultado
		{
			get
			{
				return this.resultadoField;
			}
			set
			{
				this.resultadoField = value;
			}
		}

		/// <comentarios/>
		public string motivo
		{
			get
			{
				return this.motivoField;
			}
			set
			{
				this.motivoField = value;
			}
		}

        /// <comentarios/>
        public string no_disponible
        {
            get
            {
                return this.no_disponibleField;
            }
            set
            {
                this.no_disponibleField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool no_disponibleSpecified
        {
            get
            {
                return this.no_disponibleFieldSpecified;
            }
            set
            {
                this.no_disponibleFieldSpecified = value;
            }
        }

        /// <comentarios/>
        public string gestionar_afip
        {
            get
            {
                return this.gestionar_afipField;
            }
            set
            {
                this.gestionar_afipField = value;
            }
        }

        /// <comentarios/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool gestionar_afipSpecified
        {
            get
            {
                return this.gestionar_afipFieldSpecified;
            }
            set
            {
                this.gestionar_afipFieldSpecified = value;
            }
        }
	}
}
