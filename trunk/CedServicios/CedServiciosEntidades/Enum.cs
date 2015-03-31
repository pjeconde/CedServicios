using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    public class Enum
    {
        public enum TipoPersona
        {
            Cliente,
            Proveedor,
            Ambos,
        }
        public enum TratamientoComprobante
        {
            Alta,
            Baja_AnulBaja,
            Modificacion,
            Clonado,
            Consulta,
            ConsultaITF,
        }
        public enum Elemento
        {
            Comprobante,
            Contrato,
        }
    }
}
