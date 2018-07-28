using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class BusquedaPerfil : db
    {
        public BusquedaPerfil(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public List<Entidades.BusquedaPerfil> LeerLista()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdBusquedaPerfil, DescrBusquedaPerfil from BusquedaPerfil where Estado='Vigente' order by DescrBusquedaPerfil");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.BusquedaPerfil> lista = new List<Entidades.BusquedaPerfil>();
            if (dt.Rows.Count != 0)
            {
                Entidades.BusquedaPerfil elem = new Entidades.BusquedaPerfil();
                elem.IdBusquedaPerfil = "";
                elem.DescrBusquedaPerfil = "";
                lista.Add(elem);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    elem = new Entidades.BusquedaPerfil();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.BusquedaPerfil Hasta)
        {
            Hasta.IdBusquedaPerfil = Convert.ToString(Desde["IdBusquedaPerfil"]);
            Hasta.DescrBusquedaPerfil = Convert.ToString(Desde["DescrBusquedaPerfil"]);
        }
    }
}