using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class DestinatarioFrecuente
    {
        protected string id;
        protected string para;
        protected string cc;

        public DestinatarioFrecuente()
        {
        }

        public DestinatarioFrecuente(string Id, string Para, string Cc)
        {
            id = Id;
            para = Para;
            cc = Cc;
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
        public string Para
        {
            set
            {
                para = value;
            }
            get
            {
                return para;
            }
        }
        public string Cc
        {
            set
            {
                cc = value;
            }
            get
            {
                return cc;
            }
        }
    }
}
