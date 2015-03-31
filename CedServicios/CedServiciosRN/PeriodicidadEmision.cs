using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class PeriodicidadEmision
    {
        public static List<Entidades.PeriodicidadEmision> Lista(bool ParaContrato)
        {
            List<Entidades.PeriodicidadEmision> lista = new List<Entidades.PeriodicidadEmision>();
            if (ParaContrato)
            {
                lista.Add(new Entidades.PeriodicidadEmision("Mensual", "Mensual"));
                lista.Add(new Entidades.PeriodicidadEmision("Trimestral", "Trimestral"));
                lista.Add(new Entidades.PeriodicidadEmision("Anual", "Anual"));
            }
            else
            {
                lista.Add(new Entidades.PeriodicidadEmision("No Aplica", "No Aplica"));
            }
            return lista;
        }

    }
}
