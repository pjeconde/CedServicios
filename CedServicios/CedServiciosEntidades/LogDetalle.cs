using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class LogDetalle
    {
        private int id;
        private int idLog;
        private string tipoDetalle;
        private string detalle;

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
        public int IdLog
        {
            set
            {
                idLog = value;
            }
            get
            {
                return idLog;
            }
        }
        public string TipoDetalle
        {
            set
            {
                tipoDetalle = value;
            }
            get
            {
                return tipoDetalle;
            }
        }
        public string Detalle
        {
            set
            {
                detalle = value;
            }
            get
            {
                return detalle;
            }
        }
    }
}