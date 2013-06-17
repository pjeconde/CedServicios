using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}