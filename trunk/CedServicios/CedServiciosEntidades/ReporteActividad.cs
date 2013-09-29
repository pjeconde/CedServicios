using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class ReporteActividad
    {
        private string descrEntidad;
        private string evento;
        private string estado;
        private int cantidad;

        public string DescrEntidad
        {
            set
            {
                descrEntidad = value;
            }
            get
            {
                return descrEntidad;
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
        public string Estado
        {
            set
            {
                estado = value;
            }
            get
            {
                return estado;
            }
        }
        public int Cantidad
        {
            set
            {
                cantidad = value;
            }
            get
            {
                return cantidad;
            }
        }

    }
}
