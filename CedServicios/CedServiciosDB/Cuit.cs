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
            List<Entidades.Cuit> lista = new List<Entidades.Cuit>();
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
        public void Crear(Entidades.Cuit Cuit, string PermisoAdminCUITParaUsuarioAprobadoHandler, string CrearUNHandler, string PermisoUsoCUITxUNAprobadoHandler, string PermisoAdminUNParaUsuarioAprobadoHandler, string PermisoOperServUNParaUsuarioAprobadoHandler)
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
            a.Append(CrearUNHandler);
            a.Append(PermisoUsoCUITxUNAprobadoHandler);
            a.Append(PermisoAdminUNParaUsuarioAprobadoHandler);
            a.Append(PermisoOperServUNParaUsuarioAprobadoHandler);
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
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CompletarUNsYPuntosVta(List<Entidades.Cuit> Cuits)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuit.Cuit, UN.DescrUN, UN.IdUN, isnull(PuntoVta.NroPuntoVta, convert(numeric(4), 0)) as NroPuntoVta, isnull(PuntoVta.IdTipoPuntoVta, '') as IdTipoPuntoVta from Cuit ");
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
                        Cuits[i].UNs[Cuits[i].UNs.Count - 1].PuntosVta.Add(puntoVta);
                    }
                }
            }
        }
    }
}
