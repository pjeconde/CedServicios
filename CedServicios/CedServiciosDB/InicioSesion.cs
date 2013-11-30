using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class InicioSesion : db
    {
        public InicioSesion(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public void Registrar(Entidades.InicioSesion InicioSesion)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("Insert InicioSesion (Fecha, IdUsuario, IP) values (");
            a.Append("getdate(), ");
            a.Append("'" + InicioSesion.IdUsuario + "', ");
            a.Append("'" + InicioSesion.IP + "' ");
            a.Append(") ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
    }
}