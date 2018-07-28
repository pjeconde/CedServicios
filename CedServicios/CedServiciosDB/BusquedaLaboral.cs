using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class BusquedaLaboral : db
    {
        public BusquedaLaboral(Entidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public void Leer(Entidades.BusquedaLaboral BusquedaLaboral)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select BusquedaLaboral.Email, BusquedaLaboral.Nombre, BusquedaLaboral.NombreArchCV, BusquedaLaboral.IdBusquedaPerfil, BusquedaPerfil.DescrBusquedaPerfil, BusquedaLaboral.FechaAlta, BusquedaLaboral.Suscribe, BusquedaLaboral.Comentario, BusquedaLaboral.Estado ");
            a.Append("from BusquedaLaboral ");
            a.Append("join BusquedaPerfil on BusquedaLaboral.IdBusquedaPerfil=BusquedaPerfil.IdBusquedaPerfil ");
            a.Append("where BusquedaLaboral.Email='" + BusquedaLaboral.Email + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CedServicios.EX.Validaciones.ElementoInexistente("Email " + BusquedaLaboral.Email);
            }
            else
            {
                Copiar(dt.Rows[0], BusquedaLaboral);
            }
        }
        public List<Entidades.BusquedaLaboral> LeerLista()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select BusquedaLaboral.Email, BusquedaLaboral.Nombre, BusquedaLaboral.NombreArchCV, BusquedaLaboral.IdBusquedaPerfil, BusquedaPerfil.DescrBusquedaPerfil, BusquedaLaboral.FechaAlta, BusquedaLaboral.Suscribe, BusquedaLaboral.Comentario, BusquedaLaboral.Estado ");
            a.Append("from BusquedaLaboral ");
            a.Append("join BusquedaPerfil on BusquedaLaboral.IdBusquedaPerfil=BusquedaPerfil.IdBusquedaPerfil ");
            a.Append("order by Email");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.BusquedaLaboral> lista = new List<Entidades.BusquedaLaboral>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.BusquedaLaboral elem = new Entidades.BusquedaLaboral();
                    Copiar(dt.Rows[i], elem);
                    lista.Add(elem);
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.BusquedaLaboral Hasta)
        {
            Hasta.Email = Convert.ToString(Desde["Email"]);
            Hasta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.NombreArchCV = Convert.ToString(Desde["NombreArchCV"]);
            Hasta.BusquedaPerfil.IdBusquedaPerfil = Convert.ToString(Desde["IdBusquedaPerfil"]);
            Hasta.BusquedaPerfil.DescrBusquedaPerfil = Convert.ToString(Desde["DescrBusquedaPerfil"]);
            Hasta.FechaAlta = Convert.ToDateTime(Desde["FechaAlta"]);
            Hasta.Suscribe = Convert.ToBoolean(Desde["Suscribe"]);
            Hasta.Comentario = Convert.ToString(Desde["Comentario"]);
            Hasta.Estado = Convert.ToString(Desde["Estado"]);
        }

        public void Crear(Entidades.BusquedaLaboral BusquedaLaboral)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("Insert BusquedaLaboral (Email, Nombre, NombreArchCV, IdBusquedaPerfil, FechaAlta, Suscribe, Comentario, Estado) values (");
            a.Append("'" + BusquedaLaboral.Email + "', ");
            a.Append("'" + BusquedaLaboral.Nombre + "', ");
            a.Append("'" + BusquedaLaboral.NombreArchCV + "', ");
            a.Append("'" + BusquedaLaboral.BusquedaPerfil.IdBusquedaPerfil + "', ");
            a.Append("GetDate(), ");
            if (BusquedaLaboral.Suscribe)
            {
                a.Append("1, ");
            }
            else
            {
                a.Append("0, ");
            }
            a.Append("'" + BusquedaLaboral.Comentario + "', ");
            a.Append("'" + BusquedaLaboral.Estado + "') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.BusquedaLaboral Desde, Entidades.BusquedaLaboral Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update BusquedaLaboral set ");
            a.Append("Nombre='" + Hasta.Nombre + "', ");
            a.Append("NombreArchCV='" + Hasta.NombreArchCV + "', ");
            a.Append("IdBusquedaPerfil='" + Hasta.BusquedaPerfil.IdBusquedaPerfil + "', ");
            a.Append("Suscribe=" + Hasta.Suscribe + ", ");
            a.Append("Comentario=" + Hasta.Comentario + ", ");
            a.Append("Estado='" + Hasta.Estado + "' ");
            a.AppendLine("where BusquedaLaboral.Email='" + Hasta.Email + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void ModificarCV(Entidades.BusquedaLaboral Desde, Entidades.BusquedaLaboral Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update BusquedaLaboral set ");
            a.Append("NombreArchCV='" + Hasta.NombreArchCV + "', ");
            a.Append("IdBusquedaPerfil='" + Hasta.BusquedaPerfil.IdBusquedaPerfil + "' ");
            a.AppendLine("where BusquedaLaboral.Email='" + Hasta.Email + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void ModificarSuscripcion(Entidades.BusquedaLaboral Desde, Entidades.BusquedaLaboral Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update BusquedaLaboral set ");
            a.Append("Suscribe='" + Hasta.NombreArchCV + "', ");
            a.Append("IdBusquedaPerfil='" + Hasta.BusquedaPerfil.IdBusquedaPerfil + "' ");
            a.AppendLine("where BusquedaLaboral.Email='" + Hasta.Email + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public List<Entidades.BusquedaLaboral> ListaPaging(int IndicePagina, string OrderBy, string SessionID, List<Entidades.BusquedaLaboral> BusquedaLaboralLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #BusquedaLaboral" + SessionID + "( ");
            a.Append("[Email] [varchar](128) NOT NULL, ");
            a.Append("[Nombre] [varchar](50) NOT NULL, ");
            a.Append("[NombreArchCV] [varchar](128) NOT NULL, ");
            a.Append("[IdBusquedaPerfil] [varchar](15) NOT NULL, ");
            a.Append("[DescrBusquedaPerfil] [varchar](128) NOT NULL, ");
            a.Append("[FechaAlta] [DateTime] NOT NULL, ");
            a.Append("[Suscribe] [bit] NOT NULL, ");
            a.Append("[Comentario] [varchar](256) NOT NULL, ");
            a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("CONSTRAINT [PK_BusquedaLaboral" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[Email] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (Entidades.BusquedaLaboral BL in BusquedaLaboralLista)
            {
                a.Append("Insert #BusquedaLaboral" + SessionID + " values ('" + BL.Email + "', '");
                a.Append(BL.Nombre + "', '");
                a.Append(BL.NombreArchCV + "', '");
                a.Append(BL.BusquedaPerfil.IdBusquedaPerfil + "', '");
                a.Append(BL.BusquedaPerfil.DescrBusquedaPerfil + "', '");
                a.Append(BL.FechaAlta + "', ");
                if (BL.Suscribe)
                {
                    a.Append("1, '");
                }
                else
                {
                    a.Append("0, '");
                }
                a.Append(BL.Comentario + "', '");
                a.Append(BL.Estado + "')");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Email, Nombre, NombreArchCV, IdBusquedaPerfil, DescrBusquedaPerfil, FechaAlta, Suscribe, Comentario, Estado ");
            a.Append("from #BusquedaLaboral" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #BusquedaLaboral" + SessionID);
            if (OrderBy.Trim().ToUpper() == "EMAIL" || OrderBy.Trim().ToUpper() == "EMAIL DESC" || OrderBy.Trim().ToUpper() == "EMAIL ASC")
            {
                OrderBy = "#BusquedaLaboral" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "NOMBRE" || OrderBy.Trim().ToUpper() == "NOMBRE DESC" || OrderBy.Trim().ToUpper() == "NOMBRE ASC")
            {
                OrderBy = "#BusquedaLaboral" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "NOMBREARCHCV" || OrderBy.Trim().ToUpper() == "NOMBREARCHCV DESC" || OrderBy.Trim().ToUpper() == "NOMBREARCHCV ASC")
            {
                OrderBy = "#BusquedaLaboral" + SessionID + "." + OrderBy.Replace("NOMBREARCHCV", "NOMBREARCHCV");
            }
            if (OrderBy.Trim().ToUpper() == "ESTADO" || OrderBy.Trim().ToUpper() == "ESTADO DESC" || OrderBy.Trim().ToUpper() == "ESTADO ASC")
            {
                OrderBy = "#BusquedaLaboral" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * sesion.Usuario.CantidadFilasXPagina), OrderBy, (IndicePagina * sesion.Usuario.CantidadFilasXPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.BusquedaLaboral> lista = new List<Entidades.BusquedaLaboral>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.BusquedaLaboral bl = new Entidades.BusquedaLaboral();
                    Copiar(dt.Rows[i], bl);
                    lista.Add(bl);
                }
            }
            return lista;
        }
        public List<Entidades.BusquedaLaboral> ListaSegunFiltros(string Email, string Nombre, string IdBusquedaPerfil, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select BusquedaLaboral.Email, BusquedaLaboral.Nombre, BusquedaLaboral.NombreArchCV, BusquedaLaboral.IdBusquedaPerfil, BusquedaPerfil.DescrBusquedaPerfil, BusquedaLaboral.FechaAlta, BusquedaLaboral.Suscribe, BusquedaLaboral.Comentario, BusquedaLaboral.Estado ");
            a.Append("from BusquedaLaboral ");
            a.Append("join BusquedaPerfil on BusquedaLaboral.IdBusquedaPerfil=BusquedaPerfil.IdBusquedaPerfil ");
            a.AppendLine("where 1=1 ");
            if (Email != String.Empty) a.AppendLine("and Email like '%" + Email + "%' ");
            if (Nombre != String.Empty) a.AppendLine("and Nombre like '%" + Nombre + "%' ");
            if (IdBusquedaPerfil != String.Empty) a.AppendLine("and IdBusquedaPerfil like '%" + IdBusquedaPerfil + "%' ");
            if (Estado != String.Empty) a.AppendLine("and Estado = '" + Estado + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.BusquedaLaboral> lista = new List<Entidades.BusquedaLaboral>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.BusquedaLaboral bl = new Entidades.BusquedaLaboral();
                    Copiar(dt.Rows[i], bl);
                    lista.Add(bl);
                }
            }
            return lista;
        }
    }
}
