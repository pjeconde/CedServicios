using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class PDF
    {
        private string path;
        private string descr;
        private string fechaCreacion;
        private string nombreArchivo;

        public PDF(string Path, string Descr, string FechaCreacion, string NombreArchivo)
        {
            path = Path;
            descr = Descr;
            fechaCreacion = FechaCreacion;
            nombreArchivo = NombreArchivo;
        }

        public string Path
        {
            set
            {
                path = value;
            }
            get
            {
                return path;
            }
        }
        public string Descr
        {
            set
            {
                descr = value;
            }
            get
            {
                return descr;
            }
        }
        public string FechaCreacion
        {
            set
            {
                fechaCreacion = value;
            }
            get
            {
                return fechaCreacion;
            }
        }
        public string NombreArchivo
        {
            set
            {
                nombreArchivo = value;
            }
            get
            {
                return nombreArchivo;
            }
        }
    }
}