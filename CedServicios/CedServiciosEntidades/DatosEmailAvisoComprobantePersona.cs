using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class DatosEmailAvisoComprobantePersona
    {
        protected bool activo;
        protected string de;
        protected string cco;
        protected string asunto;
        protected string cuerpo;
        protected List<DestinatarioFrecuente> destinatariosFrecuentes;

        public DatosEmailAvisoComprobantePersona()
        {
            destinatariosFrecuentes = new List<DestinatarioFrecuente>();
        }

        public DatosEmailAvisoComprobantePersona(bool Activo, string De, string Cco, string Asunto, string Cuerpo, List<DestinatarioFrecuente> DestinatariosFrecuentes)
        {
            activo = Activo;
            de = De;
            cco = Cco;
            asunto = Asunto;
            cuerpo = Cuerpo;
            destinatariosFrecuentes = DestinatariosFrecuentes;
        }

        public bool Activo
        {
            set
            {
                activo = value;
            }
            get
            {
                return activo;
            }
        }
        public string De
        {
            set
            {
                de = value;
            }
            get
            {
                return de;
            }
        }
        public string Cco
        {
            set
            {
                cco = value;
            }
            get
            {
                return cco;
            }
        }
        public string Asunto
        {
            set
            {
                asunto = value;
            }
            get
            {
                return asunto;
            }
        }
        public string Cuerpo
        {
            set
            {
                cuerpo = value;
            }
            get
            {
                return cuerpo;
            }
        }
        public List<DestinatarioFrecuente> DestinatariosFrecuentes
        {
            set
            {
                destinatariosFrecuentes = value;
            }
            get
            {
                return destinatariosFrecuentes;
            }
        }
    }
}
