using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Rubro : db
    {
        public Rubro(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public void LeerEsquemaContable(Entidades.EsquemaContable EsquemaContable)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select EsquemaContable.IdRubro, Rubro.DescrRubro, EsquemaContable.Signo from EsquemaContable, Rubro where EsquemaContable.IdTipoComprobante=" + EsquemaContable.TipoComprobante.Id.ToString() + " and EsquemaContable.IdNaturalezaComprobante='" + EsquemaContable.NaturalezaComprobante.Id + "' and EsquemaContable.Concepto='" + EsquemaContable.Concepto + "'and EsquemaContable.IdRubro=Rubro.IdRubro ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                EsquemaContable.Rubro.Id = Convert.ToString(dt.Rows[0]["IdRubro"]);
                EsquemaContable.Rubro.Descr = Convert.ToString(dt.Rows[0]["DescrRubro"]);
                EsquemaContable.Signo = Convert.ToInt32(dt.Rows[0]["Signo"]);
            }
            else
            {
                throw new CedServicios.EX.Validaciones.ElementoInexistente("Esquema contable para " + EsquemaContable.TipoComprobante.Descr + ", de " + EsquemaContable.NaturalezaComprobante.Id + " (concepto: " + EsquemaContable.Concepto + "), ");
            }
        }
    }
}
