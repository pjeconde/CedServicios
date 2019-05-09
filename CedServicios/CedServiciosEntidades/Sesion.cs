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
        private List<Persona> clientesDelCuit;
        private List<Persona> proveedoresDelCuit;
        private List<Opcion> opciones;
        private List<string> opcionesHabilitadas;
        private DateTime fechaInicio;
        private string uRLsite;
        private string administradoresSiteEmail;
        private bool estoyEnAyuda = false;
        private string ambiente;
        private bool usuarioDemo;
        private Ticket ticket;

        public Sesion()
        {
            usuario = new Usuario();
            cuit = new Cuit();
            uN = new UN();
            cuitsDelUsuario = new List<Cuit>();
            clientesDelCuit = new List<Persona>();
            proveedoresDelCuit = new List<Persona>();
            opciones = new List<Opcion>();
            opcionesHabilitadas = new List<string>();
            fechaInicio = DateTime.Now;
            usuarioDemo = false;
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
        public List<Persona> ClientesDelCuit
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
        public List<Persona> ProveedoresDelCuit
        {
            get
            {
                return proveedoresDelCuit;
            }
            set
            {
                proveedoresDelCuit = value;
            }
        }
        public List<Opcion> Opciones
        {
            get
            {
                return opciones;
            }
            set
            {
                opciones = value;
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
        public string URLsite
        {
            get
            {
                return uRLsite;
            }
            set
            {
                uRLsite = value;
            }
        }
        public string AdministradoresSiteEmail
        {
            get
            {
                return administradoresSiteEmail;
            }
            set
            {
                administradoresSiteEmail = value;
            }
        }
        public bool EstoyEnAyuda
        {
            get
            {
                return estoyEnAyuda;
            }
            set
            {
                estoyEnAyuda = value;
            }
        }
        public string Ambiente
        {
            get
            {
                return ambiente;
            }
            set
            {
                ambiente = value;
            }
        }
        public bool UsuarioDemo
        {
            get
            {
                return usuarioDemo;
            }
            set
            {
                usuarioDemo = value;
            }
        }
        public Ticket Ticket
        {
            get
            {
                return ticket;
            }
            set
            {
                ticket = value;
            }
        }
    }
}