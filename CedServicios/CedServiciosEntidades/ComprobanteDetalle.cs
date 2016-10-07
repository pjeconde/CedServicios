using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class ComprobanteDetalle
    {
        private ItemDetalle item;
        private Articulo articulo;
        private Rubro rubro;
        private double cantidad;
        private double precioUnitario;
        private double importe;
        private string idUbicacion;
        private string indicadorExentoGravado;
        private string detalle;

        public ComprobanteDetalle()
        {
            item = new ItemDetalle();
            articulo = new Articulo();
            rubro = new Rubro();
        }
        public ItemDetalle Item
        {
            set
            {
                item = value;
            }
            get
            {
                return item;
            }
        }
        public Articulo Articulo
        {
            set
            {
                articulo = value;
            }
            get
            {
                return articulo;
            }
        }
        public Rubro Rubro
        {
            set
            {
                rubro = value;
            }
            get
            {
                return rubro;
            }
        }
        public double Cantidad
        {
            set
            {
                cantidad = value;
            }
            get
            {
                return cantidad;
            }
        }
        public double PrecioUnitario
        {
            set
            {
                precioUnitario = value;
            }
            get
            {
                return precioUnitario;
            }
        }
        public double Importe
        {
            set
            {
                importe = value;
            }
            get
            {
                return importe;
            }
        }
        public string IdUbicacion
        {
            set
            {
                idUbicacion = value;
            }
            get
            {
                return idUbicacion;
            }
        }
        public string IndicadorExentoGravado
        {
            set
            {
                indicadorExentoGravado = value;
            }
            get
            {
                return indicadorExentoGravado;
            }
        }
        public string Detalle
        {
            set
            {
                detalle = value;
            }
            get
            {
                return detalle;
            }
        }
        public string DescrRubro
        {
            get
            {
                return rubro.Descr;
            }
        }
        public string Debe
        {
            get
            {
                if (importe > 0)
                    return importe.ToString();
                else
                    return string.Empty;
            }
        }
        public string Haber
        {
            get
            {
                if (importe < 0)
                    return (-importe).ToString();
                else
                    return string.Empty;
            }
        }
    }
}