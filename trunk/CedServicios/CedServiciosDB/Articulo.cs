using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Articulo : db
    {
        public Articulo(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.Articulo> ListaPorCuit()
        {
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado, UltActualiz ");
                a.Append("from Articulo ");
                a.Append("where Articulo.Cuit='" + sesion.Cuit.Nro + "' ");
                a.Append("order by Articulo.DescrArticulo ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Articulo elem = new Entidades.Articulo();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.Articulo Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Id = Convert.ToString(Desde["IdArticulo"]);
            Hasta.Descr = Convert.ToString(Desde["DescrArticulo"]);
            Hasta.GTIN = Convert.ToString(Desde["GTIN"]);
            Hasta.Unidad.Id = Convert.ToString(Desde["IdUnidad"]);
            Hasta.Unidad.Descr = Convert.ToString(Desde["DescrUnidad"]);
            Hasta.IndicacionExentoGravado = Convert.ToString(Desde["IndicacionExentoGravado"]);
            Hasta.AlicuotaIVA = Convert.ToDouble(Desde["AlicuotaIVA"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
        }
        public void Crear(Entidades.Articulo Articulo)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert Articulo (Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado) values (");
            a.Append("'" + Articulo.Cuit + "', ");
            a.Append("'" + Articulo.Id + "', ");
            a.Append("'" + Articulo.Descr + "', ");
            a.Append("'" + Articulo.GTIN + "', ");
            a.Append("'" + Articulo.Unidad.Id + "', ");
            a.Append("'" + Articulo.Unidad.Descr + "', ");
            a.Append("'" + Articulo.IndicacionExentoGravado + "', ");
            a.Append(Articulo.AlicuotaIVA.ToString() + ", ");
            a.Append("@idWF, ");
            a.Append("'" + Articulo.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Articulo', 'Alta', '" + Articulo.WF.Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.Articulo Desde, Entidades.Articulo Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Articulo set ");
            a.Append("DescrArticulo='" + Hasta.Descr + "', ");
            a.Append("GTIN='" + Hasta.GTIN + "', ");
            a.Append("IdUnidad='" + Hasta.Unidad.Id + "', ");
            a.Append("DescrUnidad='" + Hasta.Unidad.Descr + "', ");
            a.Append("IndicacionExentoGravado='" + Hasta.IndicacionExentoGravado + "', ");
            a.Append("AlicuotaIVA=" + Hasta.AlicuotaIVA.ToString().Replace(",", ".") + " ");
            a.AppendLine("where Cuit='" + Hasta.Cuit + "' and IdArticulo='" + Hasta.Id + "' ");
            a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Articulo', 'Modif', '" + Hasta.WF.Estado + "', '') ");
            a.AppendLine("declare @idLog int ");
            a.AppendLine("select @idLog=@@Identity ");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(Desde) + "')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Hasta) + "')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public List<Entidades.Articulo> ListaPorCuityId(string Cuit, string IdArticulo)
        {
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado, UltActualiz ");
                a.Append("from Articulo ");
                a.Append("where Articulo.Cuit='" + Cuit + "' and Articulo.IdArticulo='" + IdArticulo + "'");
                a.Append("order by Articulo.DescrArticulo ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Articulo elem = new Entidades.Articulo();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Articulo> ListaPorCuityDescr(string Cuit, string DescrArticulo)
        {
            List<Entidades.Articulo> lista = new List<Entidades.Articulo>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado, UltActualiz ");
                a.Append("from Articulo ");
                a.Append("where Articulo.Cuit='" + Cuit + "' and Articulo.DescrArticulo like '%" + DescrArticulo + "%' ");
                a.Append("order by Articulo.DescrArticulo ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Articulo elem = new Entidades.Articulo();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
    }
}
