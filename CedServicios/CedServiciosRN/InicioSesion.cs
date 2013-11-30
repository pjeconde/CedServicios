using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class InicioSesion
    {
        public static void Registrar(Entidades.InicioSesion InicioSesion, Entidades.Sesion Sesion)
        {
            DB.InicioSesion db = new DB.InicioSesion(Sesion);
            db.Registrar(InicioSesion);
        }
    }
}
