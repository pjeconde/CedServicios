using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace CedServicios.DB
{
    public class Configuracion : db
    {
        public Configuracion(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Crear(Entidades.Configuracion Configuracion)
        {
            Ejecutar(CrearHandler(Configuracion), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Leer(Entidades.Configuracion Configuracion)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select IdUsuario, Cuit, IdUN, IdTipoPermiso, IdItemConfig, Valor from Configuracion ");
            a.AppendLine("where IdUsuario='" + Configuracion.IdUsuario + "' ");
            a.AppendLine("and Cuit='" + Configuracion.Cuit + "' ");
            a.AppendLine("and IdUN=" + Configuracion.IdUN + " ");
            a.AppendLine("and IdTipoPermiso='" + Configuracion.TipoPermisoId + "' ");
            a.AppendLine("and IdItemConfig='" + Configuracion.IdItemConfig + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
            if (dt.Rows.Count != 0) CopiarLeer(dt.Rows[0], Configuracion);
        }
        private void CopiarLeer(DataRow Desde, Entidades.Configuracion Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.IdUN = Convert.ToInt32(Desde["IdUN"]);
            Hasta.IdUsuario = Convert.ToString(Desde["IdUsuario"]);
            Hasta.TipoPermiso.Id = Convert.ToString(Desde["IdTipoPermiso"]);
            Hasta.IdItemConfig = Convert.ToString(Desde["IdItemConfig"]);
            Hasta.Valor = Convert.ToString(Desde["Valor"]);
        }
        public void ModificarValor(Entidades.Configuracion Configuracion)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("update Configuracion ");
            a.AppendLine("set Valor='" + Configuracion.Valor + "' ");
            a.AppendLine("where IdUsuario='" + Configuracion.IdUsuario + "' ");
            a.AppendLine("and Cuit='" + Configuracion.Cuit + "' ");
            a.AppendLine("and IdUN=" + Configuracion.IdUN + " ");
            a.AppendLine("and IdTipoPermiso='" + Configuracion.TipoPermisoId + "' ");
            a.AppendLine("and IdItemConfig='" + Configuracion.IdItemConfig + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CrearFechaOKeFactTyC(Entidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("insert Configuracion (IdUsuario, Cuit, IdUN, IdTipoPermiso, IdItemConfig, Valor) values ('" + Usuario.Id + "', '', '', '', 'FechaOKeFactTyC', convert(varchar(8), getdate(), 112)) ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void ElimninarCUITUNpredef(string IdUsuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("delete Configuracion where IdItemConfig='CUITUNpredef' and IdUsuario='" + IdUsuario + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void ElimninarCantidadFilasXPagina(string IdUsuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("delete Configuracion where IdItemConfig='CantidadFilasXPagina' and IdUsuario='" + IdUsuario + "' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public static string CrearHandler(Entidades.Configuracion Configuracion)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("insert Configuracion (IdUsuario, Cuit, IdUN, IdTipoPermiso, IdItemConfig, Valor) values ('" + Configuracion.IdUsuario + "', '" + Configuracion.Cuit + "', '" + Configuracion.IdUN.ToString() + "', '" + Configuracion.TipoPermiso.Id + "', '" + Configuracion.IdItemConfig + "', '" + Configuracion.Valor + "') ");
            return a.ToString();
        }
        public static string ElimninarNroSerieCertifHandler(Entidades.Cuit Cuit)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("delete Configuracion where Cuit='" + Cuit.Nro + "' and IdItemConfig like 'NroSerieCertif%' ");
            return a.ToString();
        }
        private void Copiar(DataRow Desde, Entidades.Configuracion Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.IdUN = Convert.ToInt32(Desde["IdUN"]);
            Hasta.IdUsuario = Convert.ToString(Desde["IdUsuario"]);
            Hasta.TipoPermiso.Id = Convert.ToString(Desde["IdTipoPermiso"]);
            Hasta.TipoPermiso.Descr = Convert.ToString(Desde["DescrTipoPermiso"]);
            Hasta.IdItemConfig = Convert.ToString(Desde["IdItemConfig"]);
            Hasta.Valor = Convert.ToString(Desde["Valor"]);
        }
        public List<Entidades.Configuracion> ListaSegunFiltros(string Cuit, string IdUN, string IdUsuario, string IdTipoPermiso, string IdItemConfig)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select Configuracion.IdUsuario, Configuracion.Cuit, Configuracion.IdUN, Configuracion.IdTipoPermiso, tp.DescrTipoPermiso, Configuracion.IdItemConfig, Configuracion.Valor ");
            a.AppendLine("from Configuracion ");
            a.AppendLine("left outer join TipoPermiso tp on Configuracion.IdTipoPermiso=tp.IdTipoPermiso ");
            a.AppendLine("where 1=1 ");
            if (Cuit != String.Empty) a.AppendLine("and Cuit like '%" + Cuit + "%' ");
            if (IdUN != String.Empty) a.AppendLine("and IdUN like '%" + IdUN + "%' ");
            if (IdUsuario != String.Empty) a.AppendLine("and IdUsuario like '%" + IdUsuario + "%' ");
            if (IdTipoPermiso != String.Empty) a.AppendLine("and Configuracion.IdTipoPermiso = '" + IdTipoPermiso + "' ");
            if (IdItemConfig != String.Empty) a.AppendLine("and IdItemConfig like '%" + IdItemConfig + "%' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Configuracion> lista = new List<Entidades.Configuracion>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Configuracion Configuracion = new Entidades.Configuracion();
                    Copiar(dt.Rows[i], Configuracion);
                    lista.Add(Configuracion);
                }
            }
            return lista;
        }
        public List<Entidades.Configuracion> ListaPaging(int IndicePagina, string OrderBy, string SessionID, List<Entidades.Configuracion> ConfiguracionLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Configuracion" + SessionID + "( ");
            a.Append("[IdUsuario] [varchar](50) NOT NULL, ");
            a.Append("[Cuit] [varchar](11) NOT NULL, ");
            a.Append("[IdUN] [int] NOT NULL, ");
            a.Append("[IdTipoPermiso] [varchar](15) NOT NULL, ");
            a.Append("[DescrTipoPermiso] [varchar](50) NOT NULL, ");
            a.Append("[IdItemConfig] [varchar](50) NOT NULL, ");
            a.Append("[Valor] [varchar](256) NOT NULL, ");
            a.Append("CONSTRAINT [PK_Configuracion" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[IdUsuario] ASC, ");
            a.Append("[Cuit] ASC, ");
            a.Append("[IdUN] ASC, ");
            a.Append("[IdTipoPermiso], ");
            a.Append("[IdItemConfig] ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.AppendLine(") ON [PRIMARY] ");
            foreach (Entidades.Configuracion Configuracion in ConfiguracionLista)
            {
                a.Append("Insert #Configuracion" + SessionID + " values ('" + Configuracion.IdUsuario + "', '");
                a.Append(Configuracion.Cuit + "', ");
                a.Append(Configuracion.IdUN + ", '");
                a.Append(Configuracion.TipoPermisoId + "', '");
                a.Append(Configuracion.TipoPermisoDescr + "', '");
                a.Append(Configuracion.IdItemConfig + "', '");
                a.AppendLine(Configuracion.Valor + "')");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("IdUsuario, Cuit, IdUN, IdTipoPermiso, DescrTipoPermiso, IdItemConfig, Valor ");
            a.Append("from #Configuracion" + SessionID + " ");
            a.AppendLine("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.AppendLine("DROP TABLE #Configuracion" + SessionID);
            if (OrderBy.Trim().ToUpper() == "IDUSUARIO" || OrderBy.Trim().ToUpper() == "IDUSUARIO DESC" || OrderBy.Trim().ToUpper() == "IDUSUARIO ASC")
            {
                OrderBy = "#Configuracion" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "CUIT" || OrderBy.Trim().ToUpper() == "CUIT DESC" || OrderBy.Trim().ToUpper() == "CUIT ASC")
            {
                OrderBy = "#Configuracion" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "IDUN" || OrderBy.Trim().ToUpper() == "IDUN DESC" || OrderBy.Trim().ToUpper() == "IDUN ASC")
            {
                OrderBy = "#Configuracion" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "TIPOPERMISODESCR" || OrderBy.Trim().ToUpper() == "TIPOPERMISODESCR DESC" || OrderBy.Trim().ToUpper() == "TIPOPERMISODESCR ASC")
            {
                OrderBy = "#Configuracion" + SessionID + "." + OrderBy.Replace("TipoPermisoDescr", "DescrTipoPermiso");
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * sesion.Usuario.CantidadFilasXPagina), OrderBy, (IndicePagina * sesion.Usuario.CantidadFilasXPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Configuracion> lista = new List<Entidades.Configuracion>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Configuracion Configuracion = new Entidades.Configuracion();
                    Copiar(dt.Rows[i], Configuracion);
                    lista.Add(Configuracion);
                }
            }
            return lista;
        }
    }
}