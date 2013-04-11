using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class PuntoVta : db
    {
        public PuntoVta(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.PuntoVta> ListaPorUN()
        {
            List<Entidades.PuntoVta> lista = new List<Entidades.PuntoVta>();
            if (sesion.UN.Id != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select PuntoVta.Cuit, PuntoVta.NroPuntoVta, PuntoVta.IdUN, PuntoVta.IdTipoPuntoVta, PuntoVta.UsaSetPropioDeDatosCuit, PuntoVta.Calle, PuntoVta.Nro, PuntoVta.Piso, PuntoVta.Depto, PuntoVta.Sector, PuntoVta.Torre, PuntoVta.Manzana, PuntoVta.Localidad, PuntoVta.IdProvincia, PuntoVta.DescrProvincia, PuntoVta.CodPost, PuntoVta.NombreContacto, PuntoVta.EmailContacto, PuntoVta.TelefonoContacto, PuntoVta.IdCondIVA, PuntoVta.DescrCondIVA, PuntoVta.NroIngBrutos, PuntoVta.IdCondIngBrutos, PuntoVta.DescrCondIngBrutos, PuntoVta.GLN, PuntoVta.FechaInicioActividades, PuntoVta.CodigoInterno, PuntoVta.IdMetodoGeneracionNumeracionLote, PuntoVta.UltNroLote, PuntoVta.IdWF, PuntoVta.Estado ");
                a.Append("from PuntoVta ");
                a.Append("where PuntoVta.Cuit='" + sesion.Cuit.Nro + "' and PuntoVta.IdUN='" + sesion.UN.Id + "' ");
                a.Append("order by PuntoVta.NroPuntoVta ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.PuntoVta elem = new Entidades.PuntoVta();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.PuntoVta Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Nro = Convert.ToInt32(Desde["NroPuntoVta"]);
            Hasta.IdUN = Convert.ToInt32(Desde["IdUN"]);
            Hasta.IdTipoPuntoVta = Convert.ToString(Desde["IdTipoPuntoVta"]);
            Hasta.UsaSetPropioDeDatosCuit = Convert.ToBoolean(Desde["UsaSetPropioDeDatosCuit"]);
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
            Hasta.DatosIdentificatorios.GLN = Convert.ToInt32(Desde["GLN"]);
            Hasta.DatosIdentificatorios.CodigoInterno = Convert.ToString(Desde["CodigoInterno"]);
            Hasta.IdMetodoGeneracionNumeracionLote = Convert.ToString(Desde["IdMetodoGeneracionNumeracionLote"]);
            Hasta.UltNroLote = Convert.ToInt64(Desde["UltNroLote"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
        }
    }
}
