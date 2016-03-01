using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class DatosEmailAvisoComprobanteContrato
    {
        protected bool activo;
        protected DestinatarioFrecuente destinatarioFrecuente;
        protected string asunto;
        protected string cuerpo;
        protected List<DestinatarioFrecuente> destinatariosFrecuentes;

        public DatosEmailAvisoComprobanteContrato()
        {
            destinatarioFrecuente = new DestinatarioFrecuente();
            destinatariosFrecuentes = new List<DestinatarioFrecuente>();
        }

        public DatosEmailAvisoComprobanteContrato(bool Activo, DestinatarioFrecuente DestinatarioFrecuente, string Asunto, string Cuerpo)
        {
            activo = Activo;
            destinatarioFrecuente = DestinatarioFrecuente;
            asunto = Asunto;
            cuerpo = Cuerpo;
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
        public DestinatarioFrecuente DestinatarioFrecuente
        {
            set
            {
                destinatarioFrecuente = value;
            }
            get
            {
                return destinatarioFrecuente;
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
