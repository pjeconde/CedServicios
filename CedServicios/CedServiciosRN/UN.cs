using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class UN
    {
        public static List<Entidades.UN> ListaPorCuitParaElUsuarioLogueado(Entidades.Sesion Sesion)
        {
            CedServicios.DB.UN db = new DB.UN(Sesion);
            return db.LeerListaUNsPorCuitParaElUsuarioLogueado();
        }
        public static List<Entidades.UN> ListaVigentesPorCuit(Entidades.Cuit Cuit, Entidades.Sesion Sesion)
        {
            CedServicios.DB.UN db = new DB.UN(Sesion);
            return db.LeerListaUNsVigentesPorCuit(Cuit);
        }
        public static void Leer(Entidades.UN UN, Entidades.Sesion Sesion)
        {
            CedServicios.DB.UN db = new DB.UN(Sesion);
            db.Leer(UN);
        }
        public static void Crear(Entidades.UN UN, out string ReferenciaAAprobadores, out string EstadoPermisoUsoCUITxUN, Entidades.Sesion Sesion)
        {
            List<Entidades.Usuario> usuariosAutorizadores = new List<Entidades.Usuario>();
            string permisoUsoCUITxUNHandler = RN.Permiso.PermisoUsoCUITxUNHandler(UN, out usuariosAutorizadores, out ReferenciaAAprobadores, out EstadoPermisoUsoCUITxUN, Sesion);
            string permisoAdminUNParaUsuarioHandler = RN.Permiso.PermisoAdminUNParaUsuarioAprobadoHandler(UN, Sesion);
            DB.UN dbUN = new DB.UN(Sesion);
            UN.WF.Estado = "Vigente";   //la UN siempre queda vigente, lo que, en todo caso, puede quedar PteAutoriz
                                        //es su relación con el Cuit, que se explicita a través del Permiso UsoCuitXUN
            dbUN.Crear(UN, permisoUsoCUITxUNHandler, permisoAdminUNParaUsuarioHandler);
            if (EstadoPermisoUsoCUITxUN == "PteAutoriz")
            {
                Entidades.Permiso permiso = new Entidades.Permiso();
                permiso.TipoPermiso.Id = "UsoCUITXUN";
                permiso.UN = UN;
                RN.EnvioCorreo.SolicitudAutorizacion(RN.Permiso.DescrPermiso(permiso), Sesion.Usuario, usuariosAutorizadores);
            }
        }
        public static void Modificar(Entidades.UN UN, Entidades.Sesion Sesion)
        {
            DB.UN db = new DB.UN(Sesion);
            db.Modificar(Sesion.UN, UN);
            Sesion.UN = UN;
        }
        public static void CambiarEstado(Entidades.UN UN, string Estado, Entidades.Sesion Sesion)
        {
            DB.UN db = new DB.UN(Sesion);
            db.CambiarEstado(UN, Estado);
        }
        public static Entidades.UN ObternerCopia(Entidades.UN Desde)
        {
            Entidades.UN hasta = new Entidades.UN();
            hasta.Cuit = Desde.Cuit;
            hasta.Descr = Desde.Descr;
            hasta.Id = Desde.Id;
            for (int j = 0; j < Desde.PuntosVta.Count; j++)
            {
                Entidades.PuntoVta puntoVta = new Entidades.PuntoVta();
                puntoVta.Contacto.Nombre = Desde.PuntosVta[j].Contacto.Nombre;
                puntoVta.Contacto.Telefono = Desde.PuntosVta[j].Contacto.Telefono;
                puntoVta.Contacto.Email = Desde.PuntosVta[j].Contacto.Email;
                puntoVta.Cuit = Desde.PuntosVta[j].Cuit;
                puntoVta.DatosIdentificatorios.GLN = Desde.PuntosVta[j].DatosIdentificatorios.GLN;
                puntoVta.DatosIdentificatorios.CodigoInterno = Desde.PuntosVta[j].DatosIdentificatorios.CodigoInterno;
                puntoVta.DatosImpositivos.DescrCondIngBrutos = Desde.PuntosVta[j].DatosImpositivos.DescrCondIngBrutos;
                puntoVta.DatosImpositivos.DescrCondIVA = Desde.PuntosVta[j].DatosImpositivos.DescrCondIVA;
                puntoVta.DatosImpositivos.FechaInicioActividades = Desde.PuntosVta[j].DatosImpositivos.FechaInicioActividades;
                puntoVta.DatosImpositivos.IdCondIngBrutos = Desde.PuntosVta[j].DatosImpositivos.IdCondIngBrutos;
                puntoVta.DatosImpositivos.IdCondIVA = Desde.PuntosVta[j].DatosImpositivos.IdCondIVA;
                puntoVta.DatosImpositivos.NroIngBrutos = Desde.PuntosVta[j].DatosImpositivos.NroIngBrutos;
                puntoVta.Domicilio.Calle = Desde.PuntosVta[j].Domicilio.Calle;
                puntoVta.Domicilio.CodPost = Desde.PuntosVta[j].Domicilio.CodPost;
                puntoVta.Domicilio.Depto = Desde.PuntosVta[j].Domicilio.Depto;
                puntoVta.Domicilio.Localidad = Desde.PuntosVta[j].Domicilio.Localidad;
                puntoVta.Domicilio.Manzana = Desde.PuntosVta[j].Domicilio.Manzana;
                puntoVta.Domicilio.Nro = Desde.PuntosVta[j].Domicilio.Nro;
                puntoVta.Domicilio.Piso = Desde.PuntosVta[j].Domicilio.Piso;
                puntoVta.Domicilio.Provincia.Id = Desde.PuntosVta[j].Domicilio.Provincia.Id;
                puntoVta.Domicilio.Provincia.Descr = Desde.PuntosVta[j].Domicilio.Provincia.Descr;
                puntoVta.Domicilio.Sector = Desde.PuntosVta[j].Domicilio.Sector;
                puntoVta.Domicilio.Torre = Desde.PuntosVta[j].Domicilio.Torre;
                puntoVta.IdMetodoGeneracionNumeracionLote = Desde.PuntosVta[j].IdMetodoGeneracionNumeracionLote;
                puntoVta.IdTipoPuntoVta = Desde.PuntosVta[j].IdTipoPuntoVta;
                puntoVta.IdUN = Desde.PuntosVta[j].IdUN;
                puntoVta.Nro = Desde.PuntosVta[j].Nro;
                puntoVta.UltActualiz = Desde.PuntosVta[j].UltActualiz;
                puntoVta.UltNroLote = Desde.PuntosVta[j].UltNroLote;
                puntoVta.UsaSetPropioDeDatosCuit = Desde.PuntosVta[j].UsaSetPropioDeDatosCuit;
                puntoVta.WF.Id = Desde.PuntosVta[j].WF.Id;
                puntoVta.WF.Estado = Desde.PuntosVta[j].WF.Estado;
                hasta.PuntosVta.Add(puntoVta);
            }
            hasta.UltActualiz = Desde.UltActualiz;
            hasta.WF.Id = Desde.WF.Id;
            hasta.WF.Estado = Desde.WF.Estado;
            return hasta;
        }
        public static List<Entidades.UN> ListaSegunFiltros(string Cuit, string IdUN, string DescrUN, string Estado, Entidades.Sesion Sesion)
        {
            DB.UN UN = new DB.UN(Sesion);
            return UN.ListaSegunFiltros(Cuit, IdUN, DescrUN, Estado);
        }
        public static List<Entidades.UN> ListaPaging(out int CantidadFilas, int IndicePagina, int TamañoPagina, string OrderBy, string Cuit, string IdUN, string DescrUN, string Estado, string SessionID, Entidades.Sesion Sesion)
        {
            List<Entidades.UN> listaUN = new List<Entidades.UN>();
            DB.UN db = new DB.UN(Sesion);
            if (OrderBy.Equals(String.Empty))
            {
                OrderBy = "IdUN desc";
            }
            listaUN = db.ListaSegunFiltros(Cuit, IdUN, DescrUN, Estado);
            int cantidadFilas = listaUN.Count;
            CantidadFilas = cantidadFilas;
            return db.ListaPaging(IndicePagina, TamañoPagina, OrderBy, SessionID, listaUN);
        }
    }
}
