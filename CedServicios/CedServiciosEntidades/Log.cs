using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Log
    {
        private int id;
        private int idWF;
        private DateTime fecha;
        private string idUsuario;
        private string entidad;
        private string evento;
        private string estado;
        private string comentario;
        private int cantRegLogDetalle;

        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }
        public int IdWF
        {
            set
            {
                idWF = value;
            }
            get
            {
                return idWF;
            }
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
        public string Entidad
        {
            set
            {
                entidad = value;
            }
            get
            {
                return entidad;
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
        public string Comentario
        {
            set
            {
                comentario = value;
            }
            get
            {
                return comentario;
            }
        }
        public int CantRegLogDetalle
        {
            set
            {
                cantRegLogDetalle = value;
            }
            get
            {
                return cantRegLogDetalle;
            }
        }
    }
}
