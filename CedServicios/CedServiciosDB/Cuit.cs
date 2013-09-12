using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Cuit : db
    {
        public Cuit(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.Cuit> LeerListaCuitsPorUsuario()
        {
            List<Entidades.Cuit> lista = new List<Entidades.Cuit>();
            if (sesion.Usuario.Id != null)
            {
                StringBuilder a = new StringBuilder(string.Empty);
                a.Append("/* CUITs de AdminCUITs */ ");
                a.Append("select Cuit from Permiso where IdTipoPermiso='AdminCUIT' and idUsuario='" + sesion.Usuario.Id + "' and Estado='Vigente' ");
                a.Append("UNION ");
                a.Append("/* CUITs de AdminUNs */ ");
                a.Append("select distinct Cuit from Permiso where IdTipoPermiso='AdminUN' and idUsuario='" + sesion.Usuario.Id + "' and Estado='Vigente' ");
                a.Append("UNION ");
                a.Append("/* CUITs de operadores de servicios de UNs */ ");
                a.Append("select distinct Cuit from Permiso where IdTipoPermiso not in ('AdminUN', 'AdminCUIT', 'AdminSITE', 'UsoCUITxUN') and idUsuario='" + sesion.Usuario.Id + "' and Estado='Vigente' and Cuit<>'' ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Cuit cuit = new Entidades.Cuit();
                        cuit.Nro = Convert.ToString(dt.Rows[i]["Cuit"]);
                        Leer(cuit);
                        lista.Add(cuit);
                    }
                }
            }
            return lista;
        }
        public void Leer(Entidades.Cuit Cuit)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuit.Cuit, Cuit.RazonSocial, Cuit.Calle, Cuit.Nro, Cuit.Piso, Cuit.Depto, Cuit.Sector, Cuit.Torre, Cuit.Manzana, Cuit.Localidad, Cuit.IdProvincia, Cuit.DescrProvincia, Cuit.CodPost, Cuit.NombreContacto, Cuit.EmailContacto, Cuit.TelefonoContacto, Cuit.IdCondIVA, Cuit.DescrCondIVA, Cuit.NroIngBrutos, Cuit.IdCondIngBrutos, Cuit.DescrCondIngBrutos, Cuit.GLN, Cuit.FechaInicioActividades, Cuit.CodigoInterno, Cuit.IdMedio, Cuit.IdWF, Cuit.Estado, Cuit.UltActualiz, Medio.DescrMedio, isnull(CertifAFIP.Valor, '') as NroSerieCertifAFIP, isnull(CertifITF.Valor, '') as NroSerieCertifITF ");
            a.Append("from Cuit ");
            a.Append("join Medio on Cuit.IdMedio=Medio.IdMedio ");
            a.Append("left outer join Configuracion CertifAFIP on Cuit.Cuit=CertifAFIP.Cuit and CertifAFIP.IdItemConfig='NroSerieCertifAFIP' ");
            a.Append("left outer join Configuracion CertifITF on Cuit.Cuit=CertifITF.Cuit and CertifITF.IdItemConfig='NroSerieCertifITF' ");
            a.Append("where Cuit.Cuit='" + Cuit.Nro + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CedServicios.EX.Validaciones.ElementoInexistente("Cuit " + Cuit.Nro);
            }
            else
            {
                Copiar(dt.Rows[0], Cuit);
            }
        }
        private void Copiar(DataRow Desde, Entidades.Cuit Hasta)
        {
            Hasta.Nro = Convert.ToString(Desde["Cuit"]);
            Hasta.RazonSocial = Convert.ToString(Desde["RazonSocial"]);
            Hasta.Domicilio.Calle = Convert.ToString(Desde["Calle"]);
            Hasta.Domicilio.Nro = Convert.ToString(Desde["Nro"]);
            Hasta.Domicilio.Piso = Convert.ToString(Desde["Piso"]);
            Hasta.Domicilio.Depto = Convert.ToString(Desde["Depto"]);
            Hasta.Domicilio.Sector = Convert.ToString(Desde["Sector"]);
            Hasta.Domicilio.Torre = Convert.ToString(Desde["Torre"]);
            Hasta.Domicilio.Manzana = Convert.ToString(Desde["Manzana"]);
            Hasta.Domicilio.Localidad = Convert.ToString(Desde["Localidad"]);
            Hasta.Domicilio.Provincia.Id = Convert.ToString(Desde["IdProvincia"]);
            Hasta.Domicilio.Provincia.Descr = Convert.ToString(Desde["DescrProvincia"]);
            Hasta.Domicilio.CodPost = Convert.ToString(Desde["CodPost"]);
            Hasta.Contacto.Nombre = Convert.ToString(Desde["NombreContacto"]);
            Hasta.Contacto.Email = Convert.ToString(Desde["EmailContacto"]);
            Hasta.Contacto.Telefono = Convert.ToString(Desde["TelefonoContacto"]);
            Hasta.DatosImpositivos.IdCondIVA = Convert.ToInt32(Desde["IdCondIVA"]);
            Hasta.DatosImpositivos.DescrCondIVA = Convert.ToString(Desde["DescrCondIVA"]);
            Hasta.DatosImpositivos.NroIngBrutos = Convert.ToString(Desde["NroIngBrutos"]);
            Hasta.DatosImpositivos.IdCondIngBrutos = Convert.ToInt32(Desde["IdCondIngBrutos"]);
            Hasta.DatosImpositivos.DescrCondIngBrutos = Convert.ToString(Desde["DescrCondIngBrutos"]);
            Hasta.DatosImpositivos.FechaInicioActividades = Convert.ToDateTime(Desde["FechaInicioActividades"]);
            Hasta.DatosIdentificatorios.GLN = Convert.ToInt64(Desde["GLN"]);
            Hasta.DatosIdentificatorios.CodigoInterno = Convert.ToString(Desde["CodigoInterno"]);
            Hasta.Medio.Id = Convert.ToString(Desde["IdMedio"]);
            Hasta.Medio.Descr = Convert.ToString(Desde["DescrMedio"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
            Hasta.NroSerieCertifAFIP = Convert.ToString(Desde["NroSerieCertifAFIP"]);
            Hasta.NroSerieCertifITF = Convert.ToString(Desde["NroSerieCertifITF"]);
        }
        private void CopiarListaPaging(DataRow Desde, Entidades.Cuit Hasta)
        {
            Hasta.Nro = Convert.ToString(Desde["Cuit"]);
            Hasta.RazonSocial = Convert.ToString(Desde["RazonSocial"]);
            Hasta.Domicilio.Calle = Convert.ToString(Desde["Calle"]);
            Hasta.Domicilio.Nro = Convert.ToString(Desde["Nro"]);
            Hasta.Domicilio.Piso = Convert.ToString(Desde["Piso"]);
            Hasta.Domicilio.Depto = Convert.ToString(Desde["Depto"]);
            Hasta.Domicilio.Sector = Convert.ToString(Desde["Sector"]);
            Hasta.Domicilio.Torre = Convert.ToString(Desde["Torre"]);
            Hasta.Domicilio.Manzana = Convert.ToString(Desde["Manzana"]);
            Hasta.Domicilio.Localidad = Convert.ToString(Desde["Localidad"]);
            Hasta.Domicilio.Provincia.Id = Convert.ToString(Desde["IdProvincia"]);
            Hasta.Domicilio.Provincia.Descr = Convert.ToString(Desde["DescrProvincia"]);
            Hasta.Domicilio.CodPost = Convert.ToString(Desde["CodPost"]);
            Hasta.Contacto.Nombre = Convert.ToString(Desde["NombreContacto"]);
            Hasta.Contacto.Email = Convert.ToString(Desde["EmailContacto"]);
            Hasta.Contacto.Telefono = Convert.ToString(Desde["TelefonoContacto"]);
            Hasta.DatosImpositivos.IdCondIVA = Convert.ToInt32(Desde["IdCondIVA"]);
            Hasta.DatosImpositivos.DescrCondIVA = Convert.ToString(Desde["DescrCondIVA"]);
            Hasta.DatosImpositivos.NroIngBrutos = Convert.ToString(Desde["NroIngBrutos"]);
            Hasta.DatosImpositivos.IdCondIngBrutos = Convert.ToInt32(Desde["IdCondIngBrutos"]);
            Hasta.DatosImpositivos.DescrCondIngBrutos = Convert.ToString(Desde["DescrCondIngBrutos"]);
            Hasta.DatosImpositivos.FechaInicioActividades = Convert.ToDateTime(Desde["FechaInicioActividades"]);
            Hasta.DatosIdentificatorios.GLN = Convert.ToInt64(Desde["GLN"]);
            Hasta.DatosIdentificatorios.CodigoInterno = Convert.ToString(Desde["CodigoInterno"]);
            Hasta.Medio.Id = Convert.ToString(Desde["IdMedio"]);
            Hasta.Medio.Descr = Convert.ToString(Desde["DescrMedio"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = Convert.ToString(Desde["UltActualiz"]);
            Hasta.NroSerieCertifAFIP = Convert.ToString(Desde["NroSerieCertifAFIP"]);
            Hasta.NroSerieCertifITF = Convert.ToString(Desde["NroSerieCertifITF"]);
        }

        public void Crear(Entidades.Cuit Cuit, string PermisoAdminCUITParaUsuarioAprobadoHandler, string ServxCUITAprobadoHandler, string CrearUNHandler, string PermisoUsoCUITxUNAprobadoHandler, string PermisoAdminUNParaUsuarioAprobadoHandler, string PermisoOperServUNParaUsuarioAprobadoHandler)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.AppendLine("declare @accionTipo varchar(15) ");
            a.AppendLine("set @accionTipo='AltaCUIT' ");
            a.AppendLine("declare @accionNro varchar(256) ");
            a.AppendLine("update Configuracion set @accionNro=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoAccionNro' ");
            a.Append("Insert Cuit (Cuit, RazonSocial, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, IdCondIVA, DescrCondIVA, NroIngBrutos, IdCondIngBrutos, DescrCondIngBrutos, FechaInicioActividades, GLN, CodigoInterno, IdMedio, IdWF, Estado) values (");
            a.Append("'" + Cuit.Nro + "', ");
            a.Append("'" + Cuit.RazonSocial + "', ");
            a.Append("'" + Cuit.Domicilio.Calle + "', ");
            a.Append("'" + Cuit.Domicilio.Nro + "', ");
            a.Append("'" + Cuit.Domicilio.Piso + "', ");
            a.Append("'" + Cuit.Domicilio.Depto + "', ");
            a.Append("'" + Cuit.Domicilio.Sector + "', ");
            a.Append("'" + Cuit.Domicilio.Torre + "', ");
            a.Append("'" + Cuit.Domicilio.Manzana + "', ");
            a.Append("'" + Cuit.Domicilio.Localidad + "', ");
            a.Append("'" + Cuit.Domicilio.Provincia.Id + "', ");
            a.Append("'" + Cuit.Domicilio.Provincia.Descr + "', ");
            a.Append("'" + Cuit.Domicilio.CodPost + "', ");
            a.Append("'" + Cuit.Contacto.Nombre + "', ");
            a.Append("'" + Cuit.Contacto.Email + "', ");
            a.Append("'" + Cuit.Contacto.Telefono + "', ");
            a.Append("'" + Cuit.DatosImpositivos.IdCondIVA + "', ");
            a.Append("'" + Cuit.DatosImpositivos.DescrCondIVA + "', ");
            a.Append("'" + Cuit.DatosImpositivos.NroIngBrutos + "', ");
            a.Append("'" + Cuit.DatosImpositivos.IdCondIngBrutos + "', ");
            a.Append("'" + Cuit.DatosImpositivos.DescrCondIngBrutos + "', ");
            a.Append("'" + Cuit.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd") + "', ");
            a.Append(Cuit.DatosIdentificatorios.GLN.ToString() + ", ");
            a.Append("'" + Cuit.DatosIdentificatorios.CodigoInterno + "', ");
            a.Append("'" + Cuit.Medio.Id + "', ");
            a.Append("@idWF, ");
            a.Append("'" + Cuit.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'CUIT', 'Alta', '" + Cuit.WF.Estado + "', '') ");
            a.AppendLine();
            a.Append(PermisoAdminCUITParaUsuarioAprobadoHandler);
            a.Append(ServxCUITAprobadoHandler);
            a.Append(CrearUNHandler);
            a.Append(PermisoUsoCUITxUNAprobadoHandler);
            a.Append(PermisoAdminUNParaUsuarioAprobadoHandler);
            a.Append(PermisoOperServUNParaUsuarioAprobadoHandler);
            Entidades.Configuracion configuracion = new Entidades.Configuracion();
            if (Cuit.NroSerieCertifAFIP != String.Empty)
            {
                configuracion.IdUsuario = String.Empty;
                configuracion.Cuit = Cuit.Nro;
                configuracion.IdUN = 0;
                configuracion.TipoPermiso.Id = String.Empty;
                configuracion.IdItemConfig = "NroSerieCertifAFIP";
                configuracion.Valor = Cuit.NroSerieCertifAFIP;
                a.AppendLine(DB.Configuracion.CrearHandler(configuracion));

            }
            if (Cuit.NroSerieCertifITF != String.Empty)
            {
                configuracion.IdUsuario = String.Empty;
                configuracion.Cuit = Cuit.Nro;
                configuracion.IdUN = 0;
                configuracion.TipoPermiso.Id = String.Empty;
                configuracion.IdItemConfig = "NroSerieCertifITF";
                configuracion.Valor = Cuit.NroSerieCertifITF;
                a.AppendLine(DB.Configuracion.CrearHandler(configuracion));
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.Cuit Desde, Entidades.Cuit Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuit set ");
            a.Append("RazonSocial='" + Hasta.RazonSocial + "', ");
            a.Append("Calle='" + Hasta.Domicilio.Calle + "', ");
            a.Append("Nro='" + Hasta.Domicilio.Nro + "', ");
            a.Append("Piso='" + Hasta.Domicilio.Piso + "', ");
            a.Append("Depto='" + Hasta.Domicilio.Depto + "', ");
            a.Append("Sector='" + Hasta.Domicilio.Sector + "', ");
            a.Append("Torre='" + Hasta.Domicilio.Torre + "', ");
            a.Append("Manzana='" + Hasta.Domicilio.Manzana + "', ");
            a.Append("Localidad='" + Hasta.Domicilio.Localidad + "', ");
            a.Append("IdProvincia='" + Hasta.Domicilio.Provincia.Id + "', ");
            a.Append("DescrProvincia='" + Hasta.Domicilio.Provincia.Descr + "', ");
            a.Append("CodPost='" + Hasta.Domicilio.CodPost + "', ");
            a.Append("NombreContacto='" + Hasta.Contacto.Nombre + "', ");
            a.Append("EmailContacto='" + Hasta.Contacto.Email + "', ");
            a.Append("TelefonoContacto='" + Hasta.Contacto.Telefono + "', ");
            a.Append("IdCondIVA='" + Hasta.DatosImpositivos.IdCondIVA + "', ");
            a.Append("DescrCondIVA='" + Hasta.DatosImpositivos.DescrCondIVA + "', ");
            a.Append("NroIngBrutos='" + Hasta.DatosImpositivos.NroIngBrutos + "', ");
            a.Append("IdCondIngBrutos='" + Hasta.DatosImpositivos.IdCondIngBrutos + "', ");
            a.Append("DescrCondIngBrutos='" + Hasta.DatosImpositivos.DescrCondIngBrutos + "', ");
            a.Append("FechaInicioActividades='" + Hasta.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd") + "', ");
            a.Append("GLN=" + Hasta.DatosIdentificatorios.GLN.ToString() + ", ");
            a.Append("CodigoInterno='" + Hasta.DatosIdentificatorios.CodigoInterno + "', ");
            a.Append("IdMedio='" + Hasta.Medio.Id + "' ");
            a.AppendLine("where Cuit='" + Hasta.Nro + "' ");
            a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'CUIT', 'Modif', '" + Hasta.WF.Estado + "', '') ");
            a.AppendLine("declare @idLog int ");
            a.AppendLine("select @idLog=@@Identity ");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(Desde) + "')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Hasta) + "')");
            a.AppendLine(DB.Configuracion.ElimninarNroSerieCertifHandler(Hasta));
            Entidades.Configuracion configuracion = new Entidades.Configuracion();
            if (Hasta.NroSerieCertifAFIP != String.Empty)
            {
                configuracion.IdUsuario = String.Empty;
                configuracion.Cuit = Hasta.Nro;
                configuracion.IdUN = 0;
                configuracion.TipoPermiso.Id = String.Empty;
                configuracion.IdItemConfig = "NroSerieCertifAFIP";
                configuracion.Valor = Hasta.NroSerieCertifAFIP;
                a.AppendLine(DB.Configuracion.CrearHandler(configuracion));

            }
            if (Hasta.NroSerieCertifITF != String.Empty)
            {
                configuracion.IdUsuario = String.Empty;
                configuracion.Cuit = Hasta.Nro;
                configuracion.IdUN = 0;
                configuracion.TipoPermiso.Id = String.Empty;
                configuracion.IdItemConfig = "NroSerieCertifITF";
                configuracion.Valor = Hasta.NroSerieCertifITF;
                a.AppendLine(DB.Configuracion.CrearHandler(configuracion));
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CambiarEstado(Entidades.Cuit Cuit, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cuit set ");
            a.Append("Estado='" + Estado + "' ");
            a.AppendLine("where Cuit='" + Cuit.Nro + "' ");
            string evento = (Estado == "DeBaja") ? "Baja" : "AnulBaja";
            a.AppendLine("insert Log values (" + Cuit.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Cuit', '" + evento + "', '" + Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CompletarUNsYPuntosVta(List<Entidades.Cuit> Cuits)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuit.Cuit, UN.DescrUN, UN.IdUN, UN.Estado as EstadoUN, UN.IdWF as IdWFUN, UN.UltActualiz as UltActualizUN, ");
            a.Append("isnull(PuntoVta.NroPuntoVta, convert(numeric(4), 0)) as NroPuntoVta, isnull(PuntoVta.IdTipoPuntoVta, convert(varchar(15), '')) as IdTipoPuntoVta, isnull(PuntoVta.UsaSetPropioDeDatosCuit, convert(bit, 0)) as UsaSetPropioDeDatosCuit, isnull(PuntoVta.Calle, convert(varchar(30), '')) as Calle, isnull(PuntoVta.Nro, convert(varchar(6), '')) as Nro, isnull(PuntoVta.Piso, convert(varchar(5), '')) as Piso, isnull(PuntoVta.Depto, convert(varchar(5), '')) as Depto, isnull(PuntoVta.Sector, convert(varchar(5), '')) as Sector, isnull(PuntoVta.Torre, convert(varchar(5), '')) as Torre, isnull(PuntoVta.Manzana, convert(varchar(5), '')) as Manzana, isnull(PuntoVta.Localidad, convert(varchar(25), '')) as Localidad, isnull(PuntoVta.IdProvincia, convert(varchar(2), '')) as IdProvincia, isnull(PuntoVta.DescrProvincia, convert(varchar(50), '')) as DescrProvincia, isnull(PuntoVta.CodPost, convert(varchar(8), '')) as CodPost, isnull(PuntoVta.NombreContacto, convert(varchar(25), '')) as NombreContacto, isnull(PuntoVta.EmailContacto, convert(varchar(60), '')) as EmailContacto, isnull(PuntoVta.TelefonoContacto, convert(varchar(50), '')) as TelefonoContacto,  isnull(PuntoVta.IdCondIVA, convert(numeric(2, 0), 0)) as IdCondIVA, isnull(PuntoVta.DescrCondIVA, convert(varchar(50), '')) as DescrCondIVA, isnull(PuntoVta.NroIngBrutos, convert(varchar(13), '')) as NroIngBrutos, isnull(PuntoVta.IdCondIngBrutos, convert(numeric(2, 0), 0)) as IdCondIngBrutos, isnull(PuntoVta.DescrCondIngBrutos, convert(varchar(50), '')) as DescrCondIngBrutos, isnull(PuntoVta.GLN, convert(numeric(13, 0), 0)) as GLN, isnull(PuntoVta.FechaInicioActividades, convert(datetime, '19000101')) as FechaInicioActividades, isnull(PuntoVta.CodigoInterno, convert(varchar(20), '')) as CodigoInterno, isnull(PuntoVta.IdMetodoGeneracionNumeracionLote, convert(varchar(15), '')) as IdMetodoGeneracionNumeracionLote, isnull(PuntoVta.UltNroLote, convert(numeric(14, 0), 0)) as UltNroLote, isnull(PuntoVta.IdWF, convert(int, 0)) as IdWFPuntoVta,  isnull(PuntoVta.Estado, convert(varchar(15), '')) as EstadoPuntoVta, isnull(PuntoVta.UltActualiz, convert(timestamp, 0)) as UltActualizPuntoVta ");
            a.Append("from Cuit ");
            a.Append("left outer join UN on Cuit.Cuit=UN.Cuit ");
            a.Append("left outer join PuntoVta on UN.Cuit=PuntoVta.Cuit and UN.IdUN=PuntoVta.IdUN ");
            a.Append("order by Cuit.Cuit, UN.DescrUN, PuntoVta.NroPuntoVta ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            for (int i=0; i<Cuits.Count; i++)
            {
                DataRow[] dr = dt.Select("Cuit='" + Cuits[i].Nro + "'");
                Cuits[i].UNs = new List<Entidades.UN>();
                int idUNant = 0;
                for (int j = 0; j < dr.Length; j++)
                {
                    int idUN = Convert.ToInt32(dr[j]["IdUN"]);
                    if (idUN != idUNant)
                    {
                        Entidades.UN uN = new Entidades.UN();
                        uN.Cuit = Cuits[i].Nro;
                        uN.Id = idUN;
                        uN.Descr = Convert.ToString(dr[j]["DescrUN"]);
                        uN.WF.Id = Convert.ToInt32(dr[j]["IdWFUN"]);
                        uN.WF.Estado = Convert.ToString(dr[j]["EstadoUN"]);
                        uN.UltActualiz = ByteArray2TimeStamp((byte[])dr[j]["UltActualizUN"]);
                        Cuits[i].UNs.Add(uN);
                        idUNant = idUN;
                    }
                    if (Convert.ToInt32(dr[j]["NroPuntoVta"]) != 0)
                    {
                        Entidades.PuntoVta puntoVta = new Entidades.PuntoVta();
                        puntoVta.Cuit = Convert.ToString(dr[j]["Cuit"]);
                        puntoVta.IdUN = idUN;
                        puntoVta.Nro = Convert.ToInt32(dr[j]["NroPuntoVta"]);
                        puntoVta.IdTipoPuntoVta = Convert.ToString(dr[j]["IdTipoPuntoVta"]);
                        puntoVta.UsaSetPropioDeDatosCuit = Convert.ToBoolean(dr[j]["UsaSetPropioDeDatosCuit"]);
                        puntoVta.Domicilio.Calle = Convert.ToString(dr[j]["Calle"]);
                        puntoVta.Domicilio.Nro = Convert.ToString(dr[j]["Nro"]);
                        puntoVta.Domicilio.Piso = Convert.ToString(dr[j]["Piso"]);
                        puntoVta.Domicilio.Depto = Convert.ToString(dr[j]["Depto"]);
                        puntoVta.Domicilio.Sector = Convert.ToString(dr[j]["Sector"]);
                        puntoVta.Domicilio.Torre = Convert.ToString(dr[j]["Torre"]);
                        puntoVta.Domicilio.Manzana = Convert.ToString(dr[j]["Manzana"]);
                        puntoVta.Domicilio.Localidad = Convert.ToString(dr[j]["Localidad"]);
                        puntoVta.Domicilio.Provincia.Id = Convert.ToString(dr[j]["IdProvincia"]);
                        puntoVta.Domicilio.Provincia.Descr = Convert.ToString(dr[j]["DescrProvincia"]);
                        puntoVta.Domicilio.CodPost = Convert.ToString(dr[j]["CodPost"]);
                        puntoVta.Contacto.Nombre = Convert.ToString(dr[j]["NombreContacto"]);
                        puntoVta.Contacto.Email = Convert.ToString(dr[j]["EmailContacto"]);
                        puntoVta.Contacto.Telefono = Convert.ToString(dr[j]["TelefonoContacto"]);
                        puntoVta.DatosImpositivos.IdCondIVA = Convert.ToInt32(dr[j]["IdCondIVA"]);
                        puntoVta.DatosImpositivos.DescrCondIVA = Convert.ToString(dr[j]["DescrCondIVA"]);
                        puntoVta.DatosImpositivos.NroIngBrutos = Convert.ToString(dr[j]["NroIngBrutos"]);
                        puntoVta.DatosImpositivos.IdCondIngBrutos = Convert.ToInt32(dr[j]["IdCondIngBrutos"]);
                        puntoVta.DatosImpositivos.DescrCondIngBrutos = Convert.ToString(dr[j]["DescrCondIngBrutos"]);
                        puntoVta.DatosImpositivos.FechaInicioActividades = Convert.ToDateTime(dr[j]["FechaInicioActividades"]);
                        puntoVta.DatosIdentificatorios.GLN = Convert.ToInt64(dr[j]["GLN"]);
                        puntoVta.DatosIdentificatorios.CodigoInterno = Convert.ToString(dr[j]["CodigoInterno"]);
                        puntoVta.IdMetodoGeneracionNumeracionLote = Convert.ToString(dr[j]["IdMetodoGeneracionNumeracionLote"]);
                        puntoVta.UltNroLote = Convert.ToInt64(dr[j]["UltNroLote"]);
                        puntoVta.WF.Id = Convert.ToInt32(dr[j]["IdWFPuntoVta"]);
                        puntoVta.WF.Estado = Convert.ToString(dr[j]["EstadoPuntoVta"]);
                        puntoVta.UltActualiz = ByteArray2TimeStamp((byte[])dr[j]["UltActualizPuntoVta"]);
                        Cuits[i].UNs[Cuits[i].UNs.Count - 1].PuntosVta.Add(puntoVta);
                    }
                }
            }
        }
        public List<Entidades.Cuit> ListaSegunFiltros(string Cuit, string RazonSocial, string Localidad, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuit.Cuit, Cuit.RazonSocial, Cuit.Calle, Cuit.Nro, Cuit.Piso, Cuit.Depto, Cuit.Sector, Cuit.Torre, Cuit.Manzana, Cuit.Localidad, Cuit.IdProvincia, Cuit.DescrProvincia, Cuit.CodPost, Cuit.NombreContacto, Cuit.EmailContacto, Cuit.TelefonoContacto, Cuit.IdCondIVA, Cuit.DescrCondIVA, Cuit.NroIngBrutos, Cuit.IdCondIngBrutos, Cuit.DescrCondIngBrutos, Cuit.GLN, Cuit.FechaInicioActividades, Cuit.CodigoInterno, Cuit.IdMedio, Cuit.IdWF, Cuit.Estado, Cuit.UltActualiz, Medio.DescrMedio, isnull(CertifAFIP.Valor, '') as NroSerieCertifAFIP, isnull(CertifITF.Valor, '') as NroSerieCertifITF ");
            a.Append("from Cuit ");
            a.Append("join Medio on Cuit.IdMedio=Medio.IdMedio ");
            a.Append("left outer join Configuracion CertifAFIP on Cuit.Cuit=CertifAFIP.Cuit and CertifAFIP.IdItemConfig='NroSerieCertifAFIP' ");
            a.Append("left outer join Configuracion CertifITF on Cuit.Cuit=CertifITF.Cuit and CertifITF.IdItemConfig='NroSerieCertifITF' ");
            a.AppendLine("where 1=1 ");
            if (Cuit != String.Empty) a.AppendLine("and Cuit.Cuit like '%" + Cuit + "%' ");
            if (RazonSocial != String.Empty) a.AppendLine("and RazonSocial like '%" + RazonSocial + "%' ");
            if (Localidad != String.Empty) a.AppendLine("and Localidad like '%" + Localidad + "%' ");
            if (Estado != String.Empty) a.AppendLine("and Estado = '" + Estado + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Cuit> lista = new List<Entidades.Cuit>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Cuit cuit = new Entidades.Cuit();
                    Copiar(dt.Rows[i], cuit);
                    lista.Add(cuit);
                }
            }
            return lista;
        }
        public List<Entidades.Cuit> ListaPaging(int IndicePagina, int TamañoPagina, string OrderBy, string SessionID, List<Entidades.Cuit> CuitLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Cuit" + SessionID + "( ");
            a.Append("[Cuit] [varchar](11) NOT NULL, ");
	        a.Append("[RazonSocial] [varchar](50) NOT NULL, ");
	        a.Append("[Calle] [varchar](30) NOT NULL, ");
	        a.Append("[Nro] [varchar](6) NOT NULL, ");
	        a.Append("[Piso] [varchar](5) NOT NULL, ");
	        a.Append("[Depto] [varchar](5) NOT NULL, ");
	        a.Append("[Sector] [varchar](5) NOT NULL, ");
	        a.Append("[Torre] [varchar](5) NOT NULL, ");
	        a.Append("[Manzana] [varchar](5) NOT NULL, ");
	        a.Append("[Localidad] [varchar](25) NOT NULL, ");
	        a.Append("[IdProvincia] [varchar](2) NOT NULL, ");
	        a.Append("[DescrProvincia] [varchar](50) NOT NULL, ");
	        a.Append("[CodPost] [varchar](8) NOT NULL, ");
	        a.Append("[NombreContacto] [varchar](25) NOT NULL, ");
	        a.Append("[EmailContacto] [varchar](60) NOT NULL, ");
	        a.Append("[TelefonoContacto] [varchar](50) NOT NULL, ");
	        a.Append("[IdCondIVA] [numeric](2, 0) NOT NULL, ");
	        a.Append("[DescrCondIVA] [varchar](50) NOT NULL, ");
	        a.Append("[NroIngBrutos] [varchar](13) NOT NULL, ");
	        a.Append("[IdCondIngBrutos] [numeric](2, 0) NOT NULL, ");
	        a.Append("[DescrCondIngBrutos] [varchar](50) NOT NULL, ");
	        a.Append("[GLN] [numeric](13, 0) NOT NULL, ");
	        a.Append("[FechaInicioActividades] [datetime] NOT NULL, ");
	        a.Append("[CodigoInterno] [varchar](20) NOT NULL, ");
	        a.Append("[IdMedio] [varchar](15) NOT NULL, ");
	        a.Append("[IdWF] [int] NOT NULL, ");
	        a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[UltActualiz] [varchar](18) NOT NULL, ");
            a.Append("[DescrMedio] [varchar](50) NOT NULL, ");
            a.Append("[NroSerieCertifAFIP] [varchar](50) NOT NULL, ");
            a.Append("[NroSerieCertifITF] [varchar](50) NOT NULL, ");
            a.Append("CONSTRAINT [PK_Cuit" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[Cuit] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (Entidades.Cuit Cuit in CuitLista)
            {
                a.Append("Insert #Cuit" + SessionID + " values ('" + Cuit.Nro + "', '");
                a.Append(Cuit.RazonSocial + "', '");
                a.Append(Cuit.Domicilio.Calle + "', '");
                a.Append(Cuit.Domicilio.Nro + "', '");
                a.Append(Cuit.Domicilio.Piso + "', '");
                a.Append(Cuit.Domicilio.Depto + "', '");
                a.Append(Cuit.Domicilio.Sector + "', '");
                a.Append(Cuit.Domicilio.Torre + "', '");
                a.Append(Cuit.Domicilio.Manzana + "', '");
                a.Append(Cuit.Domicilio.Localidad + "', '");
                a.Append(Cuit.Domicilio.Provincia.Id + "', '");
                a.Append(Cuit.Domicilio.Provincia.Descr + "', '");
                a.Append(Cuit.Domicilio.CodPost + "', '");
                a.Append(Cuit.Contacto.Nombre + "', '");
                a.Append(Cuit.Contacto.Email + "', '");
                a.Append(Cuit.Contacto.Telefono  + "', '");
                a.Append(Cuit.DatosImpositivos.IdCondIVA + "', '");
                a.Append(Cuit.DatosImpositivos.DescrCondIVA + "', '");
                a.Append(Cuit.DatosImpositivos.NroIngBrutos + "', '");
                a.Append(Cuit.DatosImpositivos.IdCondIngBrutos + "', '");
                a.Append(Cuit.DatosImpositivos.DescrCondIngBrutos + "', '");
                a.Append(Cuit.DatosIdentificatorios.GLN + "', '");
                a.Append(Cuit.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd") + "', '");
                a.Append(Cuit.DatosIdentificatorios.CodigoInterno + "', '");
                a.Append(Cuit.Medio.Id + "', ");
                a.Append(Cuit.WF.Id + ", '");
                a.Append(Cuit.Estado + "', ");
                a.Append(Cuit.UltActualiz + ", '");
                a.Append(Cuit.Medio.Descr + "', '");
                a.Append(Cuit.NroSerieCertifAFIP + "', '");
                a.Append(Cuit.NroSerieCertifITF + "')");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Cuit, RazonSocial, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, IdCondIVA, DescrCondIVA, NroIngBrutos, IdCondIngBrutos, DescrCondIngBrutos, GLN, FechaInicioActividades, CodigoInterno, IdMedio, ");
            a.Append("IdWF, Estado, UltActualiz, DescrMedio, NroSerieCertifAFIP, NroSerieCertifITF ");
            a.Append("from #Cuit" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #Cuit" + SessionID);
            if (OrderBy.Trim().ToUpper() == "NRO" || OrderBy.Trim().ToUpper() == "NRO DESC" || OrderBy.Trim().ToUpper() == "NRO ASC")
            {
                OrderBy = "#Cuit" + SessionID + "." + OrderBy.Replace("Nro", "Cuit");
            }
            if (OrderBy.Trim().ToUpper() == "RAZONSOCIAL" || OrderBy.Trim().ToUpper() == "RAZONSOCIAL DESC" || OrderBy.Trim().ToUpper() == "RAZONSOCIAL ASC")
            {
                OrderBy = "#Cuit" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "DOMICILIOLOCALIDAD" || OrderBy.Trim().ToUpper() == "DOMICILIOLOCALIDAD DESC" || OrderBy.Trim().ToUpper() == "DOMICILIOLOCALIDAD ASC")
            {
                OrderBy = "#Cuit" + SessionID + "." + OrderBy.Replace("DomicilioLocalidad", "Localidad"); ;
            }
            if (OrderBy.Trim().ToUpper() == "ESTADO" || OrderBy.Trim().ToUpper() == "ESTADO DESC" || OrderBy.Trim().ToUpper() == "ESTADO ASC")
            {
                OrderBy = "#Cuit" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * TamañoPagina), OrderBy, (IndicePagina * TamañoPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Cuit> lista = new List<Entidades.Cuit>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Cuit cuit = new Entidades.Cuit();
                    CopiarListaPaging(dt.Rows[i], cuit);
                    lista.Add(cuit);
                }
            }
            return lista;
        }
    }
}
