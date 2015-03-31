using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class NaturalezaComprobante : db
    {
        public NaturalezaComprobante(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.NaturalezaComprobante> LeerLista(Entidades.Enum.Elemento Elemento)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select NaturalezaComprobante.IdNaturalezaComprobante, NaturalezaComprobante.DescrNaturalezaComprobante from NaturalezaComprobante ");
            if (Elemento == Entidades.Enum.Elemento.Comprobante)
                a.Append(" where NaturalezaComprobante.IdNaturalezaComprobante<>'VentaContrato' ");
            else
                a.Append(" where NaturalezaComprobante.IdNaturalezaComprobante='VentaContrato' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.NaturalezaComprobante> lista = new List<Entidades.NaturalezaComprobante>();
            if (dt.Rows.Count != 0)
            {
                if (Elemento == Entidades.Enum.Elemento.Comprobante)
                {
                    Entidades.NaturalezaComprobante elem = new Entidades.NaturalezaComprobante();
                    elem.Id = String.Empty;
                    elem.Descr = "--- Todas ---";
                    lista.Add(elem);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.NaturalezaComprobante elem = new Entidades.NaturalezaComprobante();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.NaturalezaComprobante Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdNaturalezaComprobante"]);
            Hasta.Descr = Convert.ToString(Desde["DescrNaturalezaComprobante"]);
        }
    }
}