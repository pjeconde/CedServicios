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
        protected bool incluir;

        public Estado()
        {
        }

        public Estado(string IdEstado, string DescrEstado, bool Incluir)
        {
            id = IdEstado;
            descr = DescrEstado;
            incluir = Incluir;
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
        public bool Incluir
        {
            set
            {
                incluir = value;
            }
            get
            {
                return incluir;
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
            incluir = true;
        }
    }
    [Serializable]
    public class EstadoPteAutoriz : Estado
    {
        public EstadoPteAutoriz()
        {
            id = "PteAutoriz";
            descr = "Pendiente de autorización";
            incluir = true;
        }
    }

    [Serializable]
    public class EstadoPteEnvio : Estado
    {
        public EstadoPteEnvio()
        {
            id = "PteEnvio";
            descr = "Pendiente de envio (AFIP/ITF)";
            incluir = true;
        }
    }
    [Serializable]
    public class EstadoPteConf : Estado
    {
        public EstadoPteConf()
        {
            id = "PteConf";
            descr = "Pendiente de confirmación";
            incluir = true;
        }
    }
    [Serializable]
    public class EstadoDeBaja : Estado
    {
        public EstadoDeBaja()
        {
            id = "DeBaja";
            descr = "De baja";
            incluir = true;
        }
    }
    [Serializable]
    public class EstadoRech : Estado
    {
        public EstadoRech()
        {
            id = "Rechazado";
            descr = "Rechazado";
            incluir = true;
        }
    }
}
