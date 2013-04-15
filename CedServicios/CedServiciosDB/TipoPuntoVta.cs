using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class TipoPuntoVta : db
    {
        public TipoPuntoVta(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.TipoPuntoVta> LeerLista()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdTipoPuntoVta from TipoPuntoVta ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.TipoPuntoVta> lista = new List<Entidades.TipoPuntoVta>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.TipoPuntoVta elem = new Entidades.TipoPuntoVta();
                    elem.Id = Convert.ToString(dt.Rows[i]["IdTipoPuntoVta"]);
                    lista.Add(elem);
                }
            }
            return lista;
        }
    }
}