using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;

namespace CedServicios.DB
{
    public class Parametro : db
    {
        public Parametro(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public string ObtenerUsuarioSmtp()
        {
            string usuario = null ;
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select ValorStr from Parametro where IdParm='SmtpUser'");
            DataView dv = (DataView)Ejecutar(a.ToString(), TipoRetorno.DV, Transaccion.Usa, sesion.CnnStr);
            usuario = dv.Table.Rows[0].ItemArray[0].ToString();
            return usuario;
        }

        public string ObtenerContraseñaSmtp()
        {
            string contraseña = null;
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("select ValorStr from Parametro where IdParm='SmtpPs'");
            DataView dv = (DataView)Ejecutar(a.ToString(), TipoRetorno.DV, Transaccion.Usa, sesion.CnnStr);
            contraseña = dv.Table.Rows[0].ItemArray[0].ToString();
            return contraseña;
        }
    }
}
