using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class ReporteActividad
    {
        public static void EnviarSiCorresponde(Entidades.Sesion Sesion)
        {
            Entidades.Configuracion ultimoMesReporteActividad = new Entidades.Configuracion("UltimoMesReporteActividad");
            DB.Configuracion db = new DB.Configuracion(Sesion);
            db.Leer(ultimoMesReporteActividad);
            DateTime Ahora = DateTime.Now;
            if (Convert.ToInt32(Ahora.ToString("yyyyMM")) > Convert.ToInt32(ultimoMesReporteActividad.Valor))
            {
                RN.EnvioCorreo.ReporteActividad(new DateTime(Convert.ToInt32(ultimoMesReporteActividad.Valor.Substring(0,4)), Convert.ToInt32(ultimoMesReporteActividad.Valor.Substring(4,2)), 1), (new DateTime(Ahora.Year, Ahora.Month, 1)).AddDays(-1), Sesion);
                ultimoMesReporteActividad.Valor = Ahora.ToString("yyyyMM");
                db.ModificarValor(ultimoMesReporteActividad);
            }
        }
    }
}
