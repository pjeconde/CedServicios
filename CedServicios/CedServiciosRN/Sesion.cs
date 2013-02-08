using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Sesion
    {
        public static void Cerrar(Entidades.Sesion Sesion)
        {
            Sesion.Usuario = new Entidades.Usuario();
            Sesion.Cuit = new Entidades.Cuit();
            Sesion.UN = new Entidades.UN();
            Sesion.CuitsDelUsuario = new List<Entidades.Cuit>();
            Sesion.UNsDelCuit = new List<Entidades.UN>();
        }
        public static void LeerDatosUsuario(Entidades.Sesion Sesion)
        {
            if (Sesion.Usuario.Id != String.Empty)
            {
                Sesion.CuitsDelUsuario = RN.Cuit.LeerListaCuitsPorUsuario(Sesion);
                if (Sesion.CuitsDelUsuario.Count != 0) 
                { 
                    Sesion.Cuit = Sesion.CuitsDelUsuario[0];
                    Sesion.UNsDelCuit = RN.UN.LeerListaUNsPorCuit(Sesion);
                    if (Sesion.UNsDelCuit.Count != 0)
                    {
                        Sesion.UN = Sesion.UNsDelCuit[0];
                    }
                }
            }
        }
        public static void ArmarListaDeOpcionesHabilitadas(Entidades.Sesion Sesion)
        {
            if (Sesion.Usuario.Id!=String.Empty)
            {
            }
        }
    }
}