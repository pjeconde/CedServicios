using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Sesion
    {
		private string cnnStr;
		private Usuario usuario;
        private Cuit cuit;
        private UN uN;
        private List<Cuit> cuitsDelUsuario;
        private List<UN> uNsDelCuit;
        private List<string> opcionesHabilitadas;

        public Sesion()
        {
            usuario = new Usuario();
            cuit = new Cuit();
            uN = new UN();
            cuitsDelUsuario = new List<Cuit>();
            uNsDelCuit = new List<UN>();
            opcionesHabilitadas = new List<string>();
        }

		public string CnnStr
		{
			get
			{
				return cnnStr;
			}
			set
			{
				cnnStr = value;
			}
		}
        public Usuario Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }
        public Cuit Cuit
        {
            get
            {
                return cuit;
            }
            set
            {
                cuit = value;
            }
        }
        public UN UN
        {
            get
            {
                return uN;
            }
            set
            {
                uN = value;
            }
        }
        public List<Cuit> CuitsDelUsuario
        {
            get
            {
                return cuitsDelUsuario;
            }
            set
            {
                cuitsDelUsuario = value;
            }
        }
        public List<UN> UNsDelCuit
        {
            get
            {
                return uNsDelCuit;
            }
            set
            {
                uNsDelCuit = value;
            }
        }
        public List<string> OpcionesHabilitadas
        {
            get
            {
                return opcionesHabilitadas;
            }
            set
            {
                opcionesHabilitadas = value;
            }
        }
    }
}