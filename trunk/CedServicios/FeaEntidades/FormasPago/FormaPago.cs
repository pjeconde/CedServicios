using System;
using System.Collections.Generic;
using System.Text;
namespace FeaEntidades.FormasPago
{
    public class FormaPago
    {
        private int codigo;
        private string descr;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descr
        {
            get { return descr; }
            set { descr = value; }
        }

        public static List<FormaPago> Lista()
        {
            List<FormaPago> lista = new List<FormaPago>();
            lista.Add(new Contado());
            lista.Add(new TarjetaDeCredito());
            lista.Add(new TarjetaDeDebito());
            lista.Add(new Cheque());
            lista.Add(new Ticket());
            lista.Add(new Otra());
            lista.Add(new CuentaCorriente());
            lista.Add(new Dias30());
            lista.Add(new Dias60());
            lista.Add(new Dias90());
            return lista;
        }
    }
}
