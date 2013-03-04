using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.CodigosUnidad
{
	public class CodigoUnidad : IComparable
    {
        private short codigo;
        private string descr;

        public short Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descr
        {
            get { return descr; }
            set { descr = value; }
        }

        public static List<CodigoUnidad> Lista()
        {
            List<CodigoUnidad> lista = new List<CodigoUnidad>();
            lista.Add(new SinInformar());
            lista.Add(new Kilogramo());
            lista.Add(new Metros());
            lista.Add(new MetroCuadrado());
            lista.Add(new MetroCubico());
            lista.Add(new Litros());
            lista.Add(new KilowattHora());
            lista.Add(new Unidad());
            lista.Add(new Par());
            lista.Add(new Docena());
            lista.Add(new Quilate());
            lista.Add(new Millar());
            lista.Add(new MegaU());
            lista.Add(new UnidadIntActInmung());
            lista.Add(new Gramo());
            lista.Add(new Milimetro());
            lista.Add(new MilimetroCubico());
            lista.Add(new Kilometro());
            lista.Add(new Hectolitro());
            lista.Add(new MegaUnidadIntActInmung());
            lista.Add(new Centimetro());
            lista.Add(new KilogramoActivo());
            lista.Add(new GramoActivo());
            lista.Add(new GramoBase());
            lista.Add(new Uiacthor());
            lista.Add(new JuegoOPaqueteMazoDeNaipes());
            lista.Add(new Muiacthor());
            lista.Add(new CentimetroCubico());
            lista.Add(new Uiactant());
            lista.Add(new Tonelada());
            lista.Add(new DecametroCubico());
            lista.Add(new HectometroCubico());
            lista.Add(new KilometroCubico());
            lista.Add(new Microgramo());
            lista.Add(new Nanogramo());
            lista.Add(new Picogramo());
            lista.Add(new Muiactant());
            lista.Add(new Uiactig());
            lista.Add(new Miligramo());
            lista.Add(new Mililitro());
            lista.Add(new Curie());
            lista.Add(new Milicurie());
            lista.Add(new Microcurie());
            lista.Add(new UInterActHor());
            lista.Add(new MegaUInterActHor());
            lista.Add(new KilogramoBase());
            lista.Add(new Gruesa());
            lista.Add(new Muiactig());
            lista.Add(new KgBruto());
            lista.Add(new Pack());
            lista.Add(new Horma());
            lista.Add(new OtrasUnidades());
			lista.Add(new Anticipos());
			lista.Add(new Bonificacion());
			lista.Sort();
            return lista;
        }


		#region Miembros de IComparable

		int IComparable.CompareTo(object obj)
		{
			if (obj is CodigoUnidad)
			{
				CodigoUnidad dp2 = (CodigoUnidad)obj;
				return descr.CompareTo(dp2.descr);
			}
			else
			{
				throw new ArgumentException("Object no es un CodigoUnidad.");
			}
		}

		#endregion
	}
}
