using System;
using System.Collections.Generic;
using System.Text;

namespace CedServicios.Entidades.FormatosRptExportar
{
    public abstract class FormatoRptExportar
    {
        protected string codigo;
        protected string descr;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descr
        {
            get { return descr; }
            set { descr = value; }
        }

        public static List<FormatoRptExportar> Lista()
        {
            List<FormatoRptExportar> lista = new List<FormatoRptExportar>();
            lista.Add(new FormatosRptExportar.SinInformar());
            lista.Add(new FormatosRptExportar.Excel());
            lista.Add(new FormatosRptExportar.PDF());
            return lista;
        }
    }
}
