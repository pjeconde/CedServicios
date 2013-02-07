using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.Entidades
{
    [Serializable]
    public class DatosImpositivos
    {
        private int idCondIVA;
        private string descrCondIVA;
        private string nroIngBrutos;
        private int idCondIngBrutos;
        private string descrCondIngBrutos;
        private DateTime fechaInicioActividades;

        public int IdCondIVA
        {
            set
            {
                idCondIVA = value;
            }
            get
            {
                return idCondIVA;
            }
        }
        public string DescrCondIVA
        {
            set
            {
                descrCondIVA = value;
            }
            get
            {
                return descrCondIVA;
            }
        }
        public string NroIngBrutos
        {
            set
            {
                nroIngBrutos = value;
            }
            get
            {
                return nroIngBrutos;
            }
        }
        public int IdCondIngBrutos
        {
            set
            {
                idCondIngBrutos = value;
            }
            get
            {
                return idCondIngBrutos;
            }
        }
        public string DescrCondIngBrutos
        {
            set
            {
                descrCondIngBrutos = value;
            }
            get
            {
                return descrCondIngBrutos;
            }
        }
        public DateTime FechaInicioActividades
        {
            set
            {
                fechaInicioActividades = value;
            }
            get
            {
                return fechaInicioActividades;
            }
        }
    }
}
