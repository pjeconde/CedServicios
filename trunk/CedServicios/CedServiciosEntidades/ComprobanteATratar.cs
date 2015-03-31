using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class ComprobanteATratar
    {
        private Enum.TratamientoComprobante tratamiento;
        private Comprobante comprobante;
        private object consultaITF;

        //Constructor para alta de comprobante
        public ComprobanteATratar(string IdNaturalezaComprobante)
        {
            tratamiento = Enum.TratamientoComprobante.Alta;
            comprobante = new Comprobante();
            comprobante.NaturalezaComprobante.Id = IdNaturalezaComprobante;
            consultaITF = new object();
        }
        //Constructor para intervensión de comprobante existente
        public ComprobanteATratar(Enum.TratamientoComprobante Tratamiento, Comprobante Comprobante)
        {
            tratamiento = Tratamiento;
            comprobante = Comprobante;
            consultaITF = new object();
        }
        //Constructor para intervensión de consulta a ITF
        public ComprobanteATratar(Enum.TratamientoComprobante Tratamiento, object ConsultaITF)
        {
            tratamiento = Tratamiento;
            comprobante = new Comprobante();
            consultaITF = ConsultaITF;
        }

        public Enum.TratamientoComprobante Tratamiento
        {
            set
            {
                tratamiento = value;
            }
            get
            {
                return tratamiento;
            }
        }
        public Comprobante Comprobante
        {
            set
            {
                comprobante = value;
            }
            get
            {
                return comprobante;
            }
        }
        public object ConsultaITF
        {
            set
            {
                consultaITF = value;
            }
            get
            {
                return consultaITF;
            }
        }
    }
}
