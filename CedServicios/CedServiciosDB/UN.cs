using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class UN : db
    {
        public UN(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.UN> LeerListaUNsPorCuit()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("/* UNs de AdminUNs */ ");
            a.Append("select IdUN from Permiso where IdTipoPermiso='AdminUN' and idUsuario='" + sesion.Usuario.Id + "' and Cuit='" + sesion.Cuit.Nro + "' and Estado='Vigente' ");
            a.Append("UNION ");
            a.Append("/* UNs de operadores de servicios de UNs*/ ");
            a.Append("select distinct IdUN from Permiso where IdTipoPermiso not in ('AdminUN', 'AdminCUIT', 'AdminSITE', 'UsoCUITxUN') and idUsuario='" + sesion.Usuario.Id + "' and Cuit='" + sesion.Cuit.Nro + "' and Estado='Vigente' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.UN> lista = new List<Entidades.UN>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.UN uN = new Entidades.UN();
                    uN.Cuit = sesion.Cuit.Nro;
                    uN.Id = Convert.ToString(dt.Rows[i]["IdUN"]);
                    Leer(uN);
                    lista.Add(uN);
                }
            }
            return lista;
        }
        public void Leer(Entidades.UN UN)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select UN.Cuit, UN.IdUN, UN.DescrUN, UN.IdWF, UN.Estado, UN.UltActualiz ");
            a.Append("from UN ");
            a.Append("where UN.Cuit='" + UN.Cuit + "' and UN.IdUN='" + UN.Id + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CedServicios.EX.Validaciones.ElementoInexistente("UN " + UN.Id + " del Cuit " + UN.Cuit);
            }
            else
            {
                Copiar(dt.Rows[0], UN);
            }
        }
        private void Copiar(DataRow Desde, Entidades.UN Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Id = Convert.ToString(Desde["IdUN"]);
            Hasta.Descr = Convert.ToString(Desde["DescrUN"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
        }
    }
}
