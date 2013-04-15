using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class MetodoGeneracionNumeracionLote : db
    {
        public MetodoGeneracionNumeracionLote(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.MetodoGeneracionNumeracionLote> LeerLista()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdMetodoGeneracionNumeracionLote from MetodoGeneracionNumeracionLote ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.MetodoGeneracionNumeracionLote> lista = new List<Entidades.MetodoGeneracionNumeracionLote>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.MetodoGeneracionNumeracionLote elem = new Entidades.MetodoGeneracionNumeracionLote();
                    elem.Id = Convert.ToString(dt.Rows[i]["IdMetodoGeneracionNumeracionLote"]);
                    lista.Add(elem);
                }
            }
            return lista;
        }
    }
}