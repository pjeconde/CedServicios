using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Multiseleccion
    {
        protected string id;
        protected string descr;

        public Multiseleccion()
        {
        }

        public Multiseleccion(string Id, string Descr)
        {
            id = Id;
            descr = Descr;
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

        [Serializable]
        public class TODOS : Multiseleccion
        {
            public TODOS()
            {
                id = "TODOS";
                descr = "TODOS";
            }
        }
        public class VARIOS : Multiseleccion
        {
            public VARIOS()
            {
                id = "VARIOS";
                descr = "VARIOS";
            }
        }
        public class UNICO : Multiseleccion
        {
            public UNICO()
            {
                id = "UNICO";
                descr = "UNICO";
            }
        }
    }
}
