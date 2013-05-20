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
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("insert Configuracion (IdUsuario, Cuit, IdUN, IdTipoPermiso, IdItemConfig, Valor) values ('" + Configuracion.IdUsuario + "', '" + Configuracion.Cuit + "', '" + Configuracion.IdUN + "', '" + Configuracion.TipoPermiso.Id + "', '" + Configuracion.IdItemConfig + "', '" + Configuracion.Valor + "') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void ElimninarNroSerieCertif(Entidades.Cuit Cuit)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("delete Configuracion where Cuit='" + Cuit.Nro + "' and IdItemConfig like 'NroSerieCertif%' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
    }
}