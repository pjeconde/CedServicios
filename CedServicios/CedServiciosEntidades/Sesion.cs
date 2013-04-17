using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Sesion : ICloneable
    {
		private string cnnStr;
		private Usuario usuario;
        private Cuit cuit;
        private UN uN;
        private List<Cuit> cuitsDelUsuario;
        private List<Cliente> clientesDelCuit;
        private List<string> opcionesHabilitadas;
        private DateTime fechaInicio;

        public Sesion()
        {
            usuario = new Usuario();
            cuit = new Cuit();
            uN = new UN();
            cuitsDelUsuario = new List<Cuit>();
            clientesDelCuit = new List<Cliente>();
            opcionesHabilitadas = new List<string>();
            fechaInicio = DateTime.Now;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
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
        public List<Cliente> ClientesDelCuit
        {
            get
            {
                return clientesDelCuit;
            }
            set
            {
                clientesDelCuit = value;
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
        public DateTime FechaInicio
        {
            get
            {
                return fechaInicio;
            }
            set
            {
                fechaInicio = value;
            }
        }
    }
}