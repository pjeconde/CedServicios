using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Estado
    {
        protected string id;
        protected string descr;

        public Estado()
        {
        }

        public Estado(string IdEstado, string DescrEstado)
        {
            id = IdEstado;
            descr = DescrEstado;
        }

        public string Id
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
    }
    [Serializable]
    public class EstadoVigente : Estado
    {
        public EstadoVigente()
        {
            id = "Vigente";
            descr = "Vigente";
        }
    }
    [Serializable]
    public class EstadoPteAutoriz : Estado
    {
        public EstadoPteAutoriz()
        {
            id = "PteAutoriz";
            descr = "Pendiente de autorización";
        }
    }
    [Serializable]
    public class EstadoPteEnvio : Estado
    {
        public EstadoPteEnvio()
        {
            id = "PteEnvio";
            descr = "Pendiente de envio (AFIP/ITF)";
        }
    }
    [Serializable]
    public class EstadoPteConf : Estado
    {
        public EstadoPteConf()
        {
            id = "PteConf";
            descr = "Pendiente de confirmación";
        }
    }
    [Serializable]
    public class EstadoDeBaja : Estado
    {
        public EstadoDeBaja()
        {
            id = "DeBaja";
            descr = "De baja";
        }
    }
    [Serializable]
    public class EstadoRech : Estado
    {
        public EstadoRech()
        {
            id = "Rech";
            descr = "Rechazado";
        }
    }
}
