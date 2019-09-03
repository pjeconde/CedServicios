using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Opcion
    {
        private string nombre;
        private bool habilitada;
        private string vinculo;

        public Opcion()
        {

        }
        public Opcion(string Nombre, bool Habilitada, string Vinculo)
        {
            nombre = Nombre;
            habilitada = Habilitada;
            vinculo = Vinculo;
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
        public bool Habilitada
        {
            set
            {
                habilitada = value;
            }
            get
            {
                return habilitada;
            }
        }
        public string Vinculo
        {
            set
            {
                vinculo = value;
            }
            get
            {
                return vinculo;
            }
        }
        
    }
}
