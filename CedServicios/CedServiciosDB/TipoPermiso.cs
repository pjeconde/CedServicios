using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class TipoPermiso : db
    {
        public TipoPermiso(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(Entidades.TipoPermiso TipoPermiso)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select TipoPermiso.IdTipoPermiso, TipoPermiso.DescrTipoPermiso from TipoPermiso where TipoPermiso.IdTipoPermiso='" + TipoPermiso.Id + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CedServicios.EX.Validaciones.ElementoInexistente("Servicio " + TipoPermiso.Id);
            }
            else
            {
                Copiar(dt.Rows[0], TipoPermiso);
            }
        }
        public List<Entidades.TipoPermiso> LeerListaPorUN(Entidades.UN UN)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Permiso.IdTipoPermiso, TipoPermiso.DescrTipoPermiso ");
            a.Append("from Permiso, TipoPermiso ");
            a.Append("where Permiso.Cuit='" + UN.Cuit + "' and Permiso.IdUN=" + UN.Id + " ");
            a.Append("and Permiso.IdTipoPermiso not in ('AdminSITE', 'AdminCUIT', 'AdminUN', 'UsoCUITxUN') ");
            a.Append("and Permiso.Estado='Vigente' and Permiso.IdTipoPermiso=TipoPermiso.IdTipoPermiso ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.TipoPermiso> lista = new List<Entidades.TipoPermiso>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.TipoPermiso elem = new Entidades.TipoPermiso();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.TipoPermiso Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdTipoPermiso"]);
            Hasta.Descr = Convert.ToString(Desde["DescrTipoPermiso"]);
        }
    }
}