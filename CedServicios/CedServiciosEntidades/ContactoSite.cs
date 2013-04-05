using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class ContactoSite : Contacto
    {
        private string motivo;
        private string mensaje;

        public ContactoSite()
        {
        }
        public string Motivo
        {
            set
            {
                motivo = value;
            }
            get
            {
                return motivo;
            }
        }
        public string Mensaje
        {
            set
            {
                mensaje = value;
            }
            get
            {
                return mensaje;
            }
        }
    }
}