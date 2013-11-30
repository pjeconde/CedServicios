using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class InicioSesion
    {
        private DateTime fecha;
        private string idUsuario;
        private string iP;

        public DateTime Fecha
        {
            set
            {
                fecha = value;
            }
            get
            {
                return fecha;
            }
        }
        public string IdUsuario
        {
            set
            {
                idUsuario = value;
            }
            get
            {
                return idUsuario;
            }
        }
        public string IP
        {
            set
            {
                iP = value;
            }
            get
            {
                return iP;
            }
        }
    }
}
