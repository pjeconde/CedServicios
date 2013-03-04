using System;
using System.Collections.Generic;
using System.Text;
namespace FeaEntidades.UnidadesMedidaExpo
{
    public class UnidadMedidaExpo
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

        public static List<UnidadMedidaExpo> Lista()
        {
            List<UnidadMedidaExpo> lista = new List<UnidadMedidaExpo>();
            lista.Add(new Miligramos());
            lista.Add(new Gramos());
            lista.Add(new Kilogramos());
            lista.Add(new Toneladas());
            lista.Add(new Quilates());
            lista.Add(new Mililitros());
            lista.Add(new Litros());
            lista.Add(new CmCubicos());
            lista.Add(new Milimetros());
            lista.Add(new Centimetros());
            lista.Add(new Kilometros());
            lista.Add(new Unidades());
            lista.Add(new Pares());
            lista.Add(new Docenas());
            lista.Add(new Millares());
            lista.Add(new Packs());
            lista.Add(new Hormas());
            lista.Add(new Metros());
            lista.Add(new MetrosCuadrados());
            lista.Add(new MetrosCubicos());
            lista.Add(new Kwh1000());
            lista.Add(new Bonificacion());
            lista.Add(new OtrasUnidades());
            lista.Add(new MmCubicos());
            lista.Add(new Hectolitros());
            lista.Add(new JgoPqtMazoNaipes());
            lista.Add(new DamCubicos());
            lista.Add(new HmCubicos());
            lista.Add(new KmCubicos());
            lista.Add(new Microgramos());
            lista.Add(new Nanogramos());
            lista.Add(new Picogramos());
            lista.Add(new Curie());
            lista.Add(new Milicurie());
            lista.Add(new Microcurie());
            lista.Add(new Uiacthor());
            lista.Add(new Muiacthor());
            lista.Add(new KgBase());
            lista.Add(new Gruesa());
            lista.Add(new KgBruto());
            lista.Add(new Uiactant());
            lista.Add(new Muiactant());
            lista.Add(new Uiactig());
            lista.Add(new Muiactig());
            lista.Add(new KgActivo());
            lista.Add(new GramoActivo());
            lista.Add(new GramoBase());
            return lista;
        }
    }
}
