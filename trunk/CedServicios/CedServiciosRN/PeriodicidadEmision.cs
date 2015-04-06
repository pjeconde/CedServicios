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
                lista.Add(new Entidades.PeriodicidadEmision("Mensual-A", "Mensual(adelantado)"));
                lista.Add(new Entidades.PeriodicidadEmision("Mensual-V", "Mensual(vencido)"));
                lista.Add(new Entidades.PeriodicidadEmision("Trimestral-A", "Trimestral(adelantado)"));
                lista.Add(new Entidades.PeriodicidadEmision("Trimestral-V", "Trimestral(vencido)"));
                lista.Add(new Entidades.PeriodicidadEmision("Anual-A", "Anual(adelantado)"));
                lista.Add(new Entidades.PeriodicidadEmision("Anual-V", "Anual(vencido)"));
            }
            else
            {
                lista.Add(new Entidades.PeriodicidadEmision("No Aplica", "No Aplica"));
            }
            return lista;
        }

    }
}
