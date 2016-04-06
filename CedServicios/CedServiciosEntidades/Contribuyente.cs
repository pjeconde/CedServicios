using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CedServicios.Entidades.AFIP
{
    [XmlRoot("contribuyente")]
    public class Contribuyente
    {
        [XmlElement("contribuyentePK")]
        public ContribuyentePK ContribuyentePK { get; set; }
        [XmlArray("categorias")]
        [XmlArrayItem("categoria", IsNullable = false)]
        public Categoria[] Categorias { get; set; }
        [XmlArray("domicilios")]
        [XmlArrayItem("domicilio", IsNullable = false)]
        public Domicilio[] Domicilios { get; set; }
        [XmlArray("impuestos")]
        [XmlArrayItem("impuesto", IsNullable = false)]
        public Impuesto[] Impuestos { get; set; }
        [XmlElement("persona")]
        public Persona Persona { get; set; }
    }
    [XmlRoot("contribuyentePK")]
    public class ContribuyentePK
    {
        [XmlElement("id")]
        public string Id { get; set; }
    }
    [XmlRoot("categoria")]
    public class Categoria
    {
        [XmlElement("categoriaPK")]
        public CategoriaPK CategoriaPK { get; set; }
        [XmlElement("esVigente")]
        public string EsVigente { get; set; }
        [XmlElement("fechaActualizacion")]
        public string FechaActualizacion { get; set; }
    }
    [XmlRoot("categoriaPK")]
    public class CategoriaPK
    {
        [XmlElement("idPersona")]
        public string IdPersona { get; set; }
        [XmlElement("idImpuesto")]
        public string IdImpuesto { get; set; }
        [XmlElement("idCategoria")]
        public string IdCategoria { get; set; }
        [XmlElement("periodo")]
        public string Periodo { get; set; }
        [XmlElement("estado")]
        public string Estado { get; set; }
    }
    [XmlRoot("domicilio")]
    public class Domicilio
    {
        [XmlElement("domicilioPK")]
        public DomicilioPK DomicilioPK { get; set; }
        [XmlElement("idEstadoDomicilio")]
        public string IdEstadoDomicilio { get; set; }
        [XmlElement("idTipoNomenclador")]
        public string IdTipoNomenclador { get; set; }
        [XmlElement("idNomenclador")]
        public string IdNomenclador { get; set; }
        [XmlElement("calle")]
        public string Calle { get; set; }
        [XmlElement("numero")]
        public string Numero { get; set; }
        [XmlElement("oficinaDeptoLocal")]
        public string OficinaDeptoLocal { get; set; }
        [XmlElement("piso")]
        public string Piso { get; set; }
        [XmlElement("codigoPostal")]
        public string CodigoPostal { get; set; }
        [XmlElement("localidad")]
        public string Localidad { get; set; }
        [XmlElement("idProvincia")]
        public string IdProvincia { get; set; }
        [XmlElement("direccion")]
        public string Direccion { get; set; }
        [XmlElement("fechaActualizacion")]
        public string FechaActualizacion { get; set; }
    }
    [XmlRoot("domicilioPK")]
    public class DomicilioPK
    {
        [XmlElement("idPersona")]
        public string IdPersona { get; set; }
        [XmlElement("idTipoDomicilio")]
        public string IdTipoDomicilio { get; set; }
        [XmlElement("orden")]
        public string Orden { get; set; }
    }
    [XmlRoot("impuesto")]
    public class Impuesto
    {
        [XmlElement("impuestoPK")]
        public ImpuestoPK ImpuestoPK { get; set; }
        [XmlElement("esVigente")]
        public string EsVigente { get; set; }
        [XmlElement("fechaInscripcion")]
        public string FechaInscripcion { get; set; }
        [XmlElement("idMotivo")]
        public string IdMotivo { get; set; }
        [XmlElement("diaPeriodo")]
        public string DiaPeriodo { get; set; }
        [XmlElement("fechaActualizacion")]
        public string FechaActualizacion { get; set; }
    }
    [XmlRoot("impuestoPK")]
    public class ImpuestoPK
    {
        [XmlElement("idPersona")]
        public string IdPersona { get; set; }
        [XmlElement("idImpuesto")]
        public string IdImpuesto { get; set; }
        [XmlElement("periodo")]
        public string Periodo { get; set; }
        [XmlElement("estado")]
        public string Estado { get; set; }
    }
    [XmlRoot("persona")]
    public class Persona
    {
        [XmlElement("personaPK")]
        public PersonaPK PersonaPK { get; set; }
        [XmlElement("tipoPersona")]
        public string TipoPersona { get; set; }
        [XmlElement("tipoId")]
        public string TipoId { get; set; }
        [XmlElement("sexo")]
        public string Sexo { get; set; }
        [XmlElement("controlAfip")]
        public string ControlAfip { get; set; }
        [XmlElement("fechaControlAfip")]
        public string FechaControlAfip { get; set; }
        [XmlElement("esImpuestoInactivo")]
        public string EsImpuestoInactivo { get; set; }
        [XmlElement("estadoId")]
        public string EstadoId { get; set; }
        [XmlElement("fechaNacimiento")]
        public string FechaNacimiento { get; set; }
        [XmlElement("idDependencia")]
        public string IdDependencia { get; set; }
        [XmlElement("idRegion")]
        public string IdRegion { get; set; }
        [XmlElement("fechaInscripcion")]
        public string FechaInscripcion { get; set; }
        [XmlElement("idActividadPrincipal")]
        public string IdActividadPrincipal { get; set; }
        [XmlElement("mesCierre")]
        public string MesCierre { get; set; }
        [XmlElement("idTipoDocumento")]
        public string IdTipoDocumento { get; set; }
        [XmlElement("nombre")]
        public string Nombre { get; set; }
        [XmlElement("apellido")]
        public string Apellido { get; set; }
        [XmlElement("documento")]
        public string Documento { get; set; }
        [XmlElement("apellidoMaterno")]
        public string ApellidoMaterno { get; set; }
        [XmlElement("idSegmento")]
        public string IdSegmento { get; set; }
        [XmlElement("fechaSegmento")]
        public string FechaSegmento { get; set; }
        [XmlElement("idMotivo")]
        public string IdMotivo { get; set; }
        [XmlElement("fechaActualizacion")]
        public string FechaActualizacion { get; set; }
        [XmlElement("descripcionCorta")]
        public string DescripcionCorta { get; set; }
        [XmlElement("nota")]
        public string Nota { get; set; }
    }
    [XmlRoot("personaPK")]
    public class PersonaPK
    {
        [XmlElement("id")]
        public string Id { get; set; }
    }
}
