using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class PermisoLog : Permiso
    {
        protected DateTime fecha;
        protected string evento;

        public PermisoLog() : base()
        {
        }

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
        public string Evento
        {
            set
            {
                evento = value;
            }
            get
            {
                return evento;
            }
        }
    }
}
