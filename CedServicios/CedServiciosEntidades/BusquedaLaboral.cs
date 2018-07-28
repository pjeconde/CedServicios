using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class BusquedaLaboral
    {
        private string email;
        private string nombre;
        private string nombreArchCV;
        private BusquedaPerfil busquedaPerfil;
	    private DateTime fechaAlta;
	    private Boolean suscribe;
	    private string comentario;
        private string estado;

        public BusquedaLaboral()
        {
            busquedaPerfil = new BusquedaPerfil();
        }

        public string Email
        {
            set
            {
                email = value;
            }
            get
            {
                return email;
            }
        }
        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public string NombreArchCV
        {
            set
            {
                nombreArchCV = value;
            }
            get
            {
                return nombreArchCV;
            }
        }
        public BusquedaPerfil BusquedaPerfil
        {
            set
            {
                busquedaPerfil = value;
            }
            get
            {
                return busquedaPerfil;
            }
        }
        public string IdPerfilBusquedaLaboral
        {
            set
            {
                busquedaPerfil.IdBusquedaPerfil = value;
            }
            get
            {
                return busquedaPerfil.IdBusquedaPerfil;
            }
        }
        public DateTime FechaAlta
        {
            set
            {
                fechaAlta = value;
            }
            get
            {
                return fechaAlta;
            }
        }
        public Boolean Suscribe
        {
            set
            {
                suscribe = value;
            }
            get
            {
                return suscribe;
            }
        }
        public string Comentario
        {
            set
            {
                comentario = value;
            }
            get
            {
                return comentario;
            }
        }
        public string Estado
        {
            set
            {
                estado = value;
            }
            get
            {
                return estado;
            }
        }
    }
}
