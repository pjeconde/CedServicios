using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    public class PadronA13
    {
        public partial class persona
        {
            private string apellidoField;
            private System.Nullable<long>[] claveInactivaAsociadaField;
            private string descripcionActividadPrincipalField;
            private domicilio[] domicilioField;
            private string estadoClaveField;
            private System.DateTime fechaContratoSocialField;
            private bool fechaContratoSocialFieldSpecified;
            private System.DateTime fechaFallecimientoField;
            private bool fechaFallecimientoFieldSpecified;
            private System.DateTime fechaNacimientoField;
            private bool fechaNacimientoFieldSpecified;
            private string formaJuridicaField;
            private long idActividadPrincipalField;
            private bool idActividadPrincipalFieldSpecified;
            private long idPersonaField;
            private bool idPersonaFieldSpecified;
            private int mesCierreField;
            private bool mesCierreFieldSpecified;
            private string nombreField;
            private string numeroDocumentoField;
            private int periodoActividadPrincipalField;
            private bool periodoActividadPrincipalFieldSpecified;
            private string razonSocialField;
            private string tipoClaveField;
            private string tipoDocumentoField;
            private string tipoPersonaField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string apellido
            {
                get
                {
                    return this.apellidoField;
                }
                set
                {
                    this.apellidoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("claveInactivaAsociada", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public System.Nullable<long>[] claveInactivaAsociada
            {
                get
                {
                    return this.claveInactivaAsociadaField;
                }
                set
                {
                    this.claveInactivaAsociadaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string descripcionActividadPrincipal
            {
                get
                {
                    return this.descripcionActividadPrincipalField;
                }
                set
                {
                    this.descripcionActividadPrincipalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("domicilio", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public domicilio[] domicilio
            {
                get
                {
                    return this.domicilioField;
                }
                set
                {
                    this.domicilioField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string estadoClave
            {
                get
                {
                    return this.estadoClaveField;
                }
                set
                {
                    this.estadoClaveField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime fechaContratoSocial
            {
                get
                {
                    return this.fechaContratoSocialField;
                }
                set
                {
                    this.fechaContratoSocialField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool fechaContratoSocialSpecified
            {
                get
                {
                    return this.fechaContratoSocialFieldSpecified;
                }
                set
                {
                    this.fechaContratoSocialFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime fechaFallecimiento
            {
                get
                {
                    return this.fechaFallecimientoField;
                }
                set
                {
                    this.fechaFallecimientoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool fechaFallecimientoSpecified
            {
                get
                {
                    return this.fechaFallecimientoFieldSpecified;
                }
                set
                {
                    this.fechaFallecimientoFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime fechaNacimiento
            {
                get
                {
                    return this.fechaNacimientoField;
                }
                set
                {
                    this.fechaNacimientoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool fechaNacimientoSpecified
            {
                get
                {
                    return this.fechaNacimientoFieldSpecified;
                }
                set
                {
                    this.fechaNacimientoFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string formaJuridica
            {
                get
                {
                    return this.formaJuridicaField;
                }
                set
                {
                    this.formaJuridicaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long idActividadPrincipal
            {
                get
                {
                    return this.idActividadPrincipalField;
                }
                set
                {
                    this.idActividadPrincipalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool idActividadPrincipalSpecified
            {
                get
                {
                    return this.idActividadPrincipalFieldSpecified;
                }
                set
                {
                    this.idActividadPrincipalFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public long idPersona
            {
                get
                {
                    return this.idPersonaField;
                }
                set
                {
                    this.idPersonaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool idPersonaSpecified
            {
                get
                {
                    return this.idPersonaFieldSpecified;
                }
                set
                {
                    this.idPersonaFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int mesCierre
            {
                get
                {
                    return this.mesCierreField;
                }
                set
                {
                    this.mesCierreField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool mesCierreSpecified
            {
                get
                {
                    return this.mesCierreFieldSpecified;
                }
                set
                {
                    this.mesCierreFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string nombre
            {
                get
                {
                    return this.nombreField;
                }
                set
                {
                    this.nombreField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string numeroDocumento
            {
                get
                {
                    return this.numeroDocumentoField;
                }
                set
                {
                    this.numeroDocumentoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int periodoActividadPrincipal
            {
                get
                {
                    return this.periodoActividadPrincipalField;
                }
                set
                {
                    this.periodoActividadPrincipalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool periodoActividadPrincipalSpecified
            {
                get
                {
                    return this.periodoActividadPrincipalFieldSpecified;
                }
                set
                {
                    this.periodoActividadPrincipalFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string razonSocial
            {
                get
                {
                    return this.razonSocialField;
                }
                set
                {
                    this.razonSocialField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tipoClave
            {
                get
                {
                    return this.tipoClaveField;
                }
                set
                {
                    this.tipoClaveField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tipoDocumento
            {
                get
                {
                    return this.tipoDocumentoField;
                }
                set
                {
                    this.tipoDocumentoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tipoPersona
            {
                get
                {
                    return this.tipoPersonaField;
                }
                set
                {
                    this.tipoPersonaField = value;
                }
            }
        }

        public partial class domicilio
        {
            private string calleField;
            private string codigoPostalField;
            private string datoAdicionalField;
            private string descripcionProvinciaField;
            private string direccionField;
            private string estadoDomicilioField;
            private int idProvinciaField;
            private bool idProvinciaFieldSpecified;
            private string localidadField;
            private string manzanaField;
            private int numeroField;
            private bool numeroFieldSpecified;
            private string oficinaDptoLocalField;
            private string pisoField;
            private string sectorField;
            private string tipoDatoAdicionalField;
            private string tipoDomicilioField;
            private string torreField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string calle
            {
                get
                {
                    return this.calleField;
                }
                set
                {
                    this.calleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string codigoPostal
            {
                get
                {
                    return this.codigoPostalField;
                }
                set
                {
                    this.codigoPostalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string datoAdicional
            {
                get
                {
                    return this.datoAdicionalField;
                }
                set
                {
                    this.datoAdicionalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string descripcionProvincia
            {
                get
                {
                    return this.descripcionProvinciaField;
                }
                set
                {
                    this.descripcionProvinciaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string direccion
            {
                get
                {
                    return this.direccionField;
                }
                set
                {
                    this.direccionField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string estadoDomicilio
            {
                get
                {
                    return this.estadoDomicilioField;
                }
                set
                {
                    this.estadoDomicilioField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int idProvincia
            {
                get
                {
                    return this.idProvinciaField;
                }
                set
                {
                    this.idProvinciaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool idProvinciaSpecified
            {
                get
                {
                    return this.idProvinciaFieldSpecified;
                }
                set
                {
                    this.idProvinciaFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string localidad
            {
                get
                {
                    return this.localidadField;
                }
                set
                {
                    this.localidadField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string manzana
            {
                get
                {
                    return this.manzanaField;
                }
                set
                {
                    this.manzanaField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int numero
            {
                get
                {
                    return this.numeroField;
                }
                set
                {
                    this.numeroField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool numeroSpecified
            {
                get
                {
                    return this.numeroFieldSpecified;
                }
                set
                {
                    this.numeroFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string oficinaDptoLocal
            {
                get
                {
                    return this.oficinaDptoLocalField;
                }
                set
                {
                    this.oficinaDptoLocalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string piso
            {
                get
                {
                    return this.pisoField;
                }
                set
                {
                    this.pisoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string sector
            {
                get
                {
                    return this.sectorField;
                }
                set
                {
                    this.sectorField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tipoDatoAdicional
            {
                get
                {
                    return this.tipoDatoAdicionalField;
                }
                set
                {
                    this.tipoDatoAdicionalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tipoDomicilio
            {
                get
                {
                    return this.tipoDomicilioField;
                }
                set
                {
                    this.tipoDomicilioField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string torre
            {
                get
                {
                    return this.torreField;
                }
                set
                {
                    this.torreField = value;
                }
            }
        }
    }
}
