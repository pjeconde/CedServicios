using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeaEntidades.Turismo
{
    [System.SerializableAttribute()]
    public partial class informacion_comprador : FeaEntidades.InterFacturas.informacion_comprador
    {
        private short codigo_PaisField;
        private string id_ImpositivoField;
        private short codigo_Relacion_Receptor_EmisorField;
        private string nro_doc_identificatorio_afipField;

        public informacion_comprador() : base()
        {
        }

        public string id_Impositivo
        {
            get
            {
                return this.id_ImpositivoField;
            }
            set
            {
                this.id_ImpositivoField = value;
            }
        }
        public short codigo_Pais
        {
            get
            {
                return this.codigo_PaisField;
            }
            set
            {
                this.codigo_PaisField = value;
            }
        }
        public short codigo_Relacion_Receptor_Emisor
        {
            get
            {
                return this.codigo_Relacion_Receptor_EmisorField;
            }
            set
            {
                this.codigo_Relacion_Receptor_EmisorField = value;
            }
        }

        public new string nro_doc_identificatorio_afip
        {
            get
            {
                return this.nro_doc_identificatorio_afipField;
            }
            set
            {
                this.nro_doc_identificatorio_afipField = value;
            }
        }
    }
}
