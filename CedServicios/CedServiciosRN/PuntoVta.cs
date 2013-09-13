using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class PuntoVta
    {
        public static List<Entidades.PuntoVta> ListaPorUN(Entidades.Sesion Sesion)
        {
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            return db.ListaPorUN();
        }
        public static void Crear(Entidades.PuntoVta PuntoVta, Entidades.Sesion Sesion)
        {
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            PuntoVta.WF.Estado = "Vigente";
            db.Crear(PuntoVta);
        }
        public static void Modificar(Entidades.PuntoVta PuntoVtaDesde, Entidades.PuntoVta PuntoVtaHasta, Entidades.Sesion Sesion)
        {
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            db.Modificar(PuntoVtaDesde, PuntoVtaHasta);
        }
        public static void CambiarEstado(Entidades.PuntoVta PuntoVta, string Estado, Entidades.Sesion Sesion)
        {
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            db.CambiarEstado(PuntoVta, Estado);
            PuntoVta.WF.Estado = Estado;
        }
        public static Entidades.PuntoVta ObternerCopia(Entidades.PuntoVta Desde)
        {
            Entidades.PuntoVta hasta = new Entidades.PuntoVta();
            hasta.Contacto.Nombre = Desde.Contacto.Nombre;
            hasta.Contacto.Telefono = Desde.Contacto.Telefono;
            hasta.Contacto.Email = Desde.Contacto.Email;
            hasta.Cuit = Desde.Cuit;
            hasta.DatosIdentificatorios.GLN = Desde.DatosIdentificatorios.GLN;
            hasta.DatosIdentificatorios.CodigoInterno = Desde.DatosIdentificatorios.CodigoInterno;
            hasta.DatosImpositivos.DescrCondIngBrutos = Desde.DatosImpositivos.DescrCondIngBrutos;
            hasta.DatosImpositivos.DescrCondIVA = Desde.DatosImpositivos.DescrCondIVA;
            hasta.DatosImpositivos.FechaInicioActividades = Desde.DatosImpositivos.FechaInicioActividades;
            hasta.DatosImpositivos.IdCondIngBrutos = Desde.DatosImpositivos.IdCondIngBrutos;
            hasta.DatosImpositivos.IdCondIVA = Desde.DatosImpositivos.IdCondIVA;
            hasta.DatosImpositivos.NroIngBrutos = Desde.DatosImpositivos.NroIngBrutos;
            hasta.Domicilio.Calle = Desde.Domicilio.Calle;
            hasta.Domicilio.CodPost = Desde.Domicilio.CodPost;
            hasta.Domicilio.Depto = Desde.Domicilio.Depto;
            hasta.Domicilio.Localidad = Desde.Domicilio.Localidad;
            hasta.Domicilio.Manzana = Desde.Domicilio.Manzana;
            hasta.Domicilio.Nro = Desde.Domicilio.Nro;
            hasta.Domicilio.Piso = Desde.Domicilio.Piso;
            hasta.Domicilio.Provincia.Id = Desde.Domicilio.Provincia.Id;
            hasta.Domicilio.Provincia.Descr = Desde.Domicilio.Provincia.Descr;
            hasta.Domicilio.Sector = Desde.Domicilio.Sector;
            hasta.Domicilio.Torre = Desde.Domicilio.Torre;
            hasta.IdMetodoGeneracionNumeracionLote = Desde.IdMetodoGeneracionNumeracionLote;
            hasta.IdTipoPuntoVta = Desde.IdTipoPuntoVta;
            hasta.IdUN = Desde.IdUN;
            hasta.Nro = Desde.Nro;
            hasta.UltActualiz = Desde.UltActualiz;
            hasta.UltNroLote = Desde.UltNroLote;
            hasta.UsaSetPropioDeDatosCuit = Desde.UsaSetPropioDeDatosCuit;
            hasta.WF.Id = Desde.WF.Id;
            hasta.WF.Estado = Desde.WF.Estado;
            return hasta;
        }
        public static void GenerarNuevoNroLote(Entidades.PuntoVta PuntoVta, Entidades.Sesion Sesion)
        {
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            db.GenerarNuevoNroLote(PuntoVta);
        }
        public static List<Entidades.PuntoVta> ListaSegunFiltros(string Cuit, string IdUN, string Nro, string Estado, Entidades.Sesion Sesion)
        {
            DB.PuntoVta PuntoVta = new DB.PuntoVta(Sesion);
            return PuntoVta.ListaSegunFiltros(Cuit, IdUN, Nro, Estado);
        }
        public static List<Entidades.PuntoVta> ListaPaging(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, string Cuit, string IdUN, string Nro, string Estado, string SessionID, Entidades.Sesion Sesion)
        {
            List<Entidades.PuntoVta> listaPuntoVta = new List<Entidades.PuntoVta>();
            DB.PuntoVta db = new DB.PuntoVta(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "Cuit asc, NroPuntoVta asc ";
            }
            listaPuntoVta = db.ListaSegunFiltros(Cuit, IdUN, Nro, Estado);
            int cantidadFilas = listaPuntoVta.Count;
            CantidadFilas = cantidadFilas;
            return db.ListaPaging(IndicePagina, TamañoPagina, OrderBy, SessionID, listaPuntoVta);
        }
    }
}
