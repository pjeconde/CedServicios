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
            a.Append("select Cuit.Cuit, Cuit.RazonSocial, Cuit.Calle, Cuit.Nro, Cuit.Piso, Cuit.Depto, Cuit.Sector, Cuit.Torre, Cuit.Manzana, Cuit.Localidad, Cuit.IdProvincia, Cuit.DescrProvincia, Cuit.CodPost, Cuit.NombreContacto, Cuit.EmailContacto, Cuit.TelefonoContacto, Cuit.IdCondIVA, Cuit.DescrCondIVA, Cuit.NroIngBrutos, Cuit.IdCondIngBrutos, Cuit.DescrCondIngBrutos, Cuit.GLN, Cuit.FechaInicioActividades, Cuit.CodigoInterno, Cuit.IdMedio, Cuit.IdWF, Cuit.Estado, Cuit.UltActualiz, Medio.Descr as DescrMedio ");
            a.Append("from Cuit, Medio ");
            a.Append("where Cuit.Cuit='" + Cuit.Nro + "' and Cuit.IdMedio=Medio.IdMedio ");
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
        }
    }
}
