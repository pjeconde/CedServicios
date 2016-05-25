using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class Precio
    {
        private string cuit;
        private string idListaPrecio;
        private string idArticulo;
        private double valor;

        public Precio()
        {
        }

        public string Cuit
        {
            set
            {
                cuit = value;
            }
            get
            {
                return cuit;
            }
        }
        public string IdListaPrecio
        {
            set
            {
                idListaPrecio = value;
            }
            get
            {
                return idListaPrecio;
            }
        }
        public string IdArticulo
        {
            set
            {
                idArticulo = value;
            }
            get
            {
                return idArticulo;
            }
        }
        public double Valor
        {
            set
            {
                valor = value;
            }
            get
            {
                return valor;
            }
        }
    }
}