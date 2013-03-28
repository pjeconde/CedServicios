using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Medio : db
    {
        public Medio(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.Medio> LeerLista()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdMedio, DescrMedio from Medio order by DescrMedio ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Medio> lista = new List<Entidades.Medio>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Medio elem = new Entidades.Medio();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.Medio Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdMedio"]);
            Hasta.Descr = Convert.ToString(Desde["DescrMedio"]);
        }
    }
}