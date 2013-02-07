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
        private UN un;

		public Sesion()
		{
			usuario = new Usuario();
            cuit = new Cuit();
            un = new UN();
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
		public UN Un
		{
			get
			{
				return un;
			}
			set
			{
				un = value;
			}
		}
    }
}