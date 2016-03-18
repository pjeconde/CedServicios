using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Ticket : db
    {
        public Ticket(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public Entidades.Ticket Leer(string Cuit, string Service)
        {
            Entidades.Ticket ticket = new Entidades.Ticket();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cuit, Service, UniqueId, GenerationTime, ExpirationTime, Sign, Token ");
                a.Append("from Ticket ");
                a.Append("where Ticket.Cuit='" + Cuit + "' and Service = '" + Service + "' ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    Copiar(dt.Rows[0], ticket);
                }
            }
            return ticket;
        }
        private void Copiar(DataRow Desde, Entidades.Ticket Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Service = Convert.ToString(Desde["Service"]);
            Hasta.UniqueId = Convert.ToString(Desde["UniqueId"]);
            Hasta.GenerationTime = Convert.ToDateTime(Desde["GenerationTime"]);
            Hasta.ExpirationTime = Convert.ToDateTime(Desde["ExpirationTime"]);
            Hasta.Sign = Convert.ToString(Desde["Sign"]);
            Hasta.Token = Convert.ToString(Desde["Token"]);
        }
        private void Crear(Entidades.Ticket Ticket)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("Insert Ticket (Cuit, Service, UniqueId, GenerationTime, ExpirationTime, Sign, Token) values (");
            a.Append("'" + Ticket.Cuit + "', ");
            a.Append("'" + Ticket.Service + "', ");
            a.Append("'" + Ticket.UniqueId + "', ");
            a.Append("'" + Ticket.GenerationTime.ToString("yyyyMMdd HH:mm:ss") + "', ");
            a.Append("'" + Ticket.ExpirationTime.ToString("yyyyMMdd HH:mm:ss") + "', ");
            a.Append("'" + Ticket.Sign + "', ");
            a.Append("'" + Ticket.Token + "')");
            Funciones.GrabarLogTexto("Consultar.txt", "SCRIPT crear Ticket: " + a.ToString());
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.Ticket Ticket)
        {
            try
            {
                Entidades.Ticket t = Leer(Ticket.Cuit, Ticket.Service);
                if (t.Cuit == null)
                {
                    Crear(Ticket);
                }
                else
                {
                    StringBuilder a = new StringBuilder(string.Empty);
                    a.Append("update Ticket set ");
                    a.Append("Service='" + Ticket.Service + "', ");
                    a.Append("UniqueId='" + Ticket.UniqueId + "', ");
                    a.Append("GenerationTime='" + Ticket.GenerationTime.ToString("yyyyMMdd HH:mm:ss") + "', ");
                    a.Append("ExpirationTime='" + Ticket.ExpirationTime.ToString("yyyyMMdd HH:mm:ss") + "', ");
                    a.Append("Sign='" + Ticket.Sign + "', ");
                    a.Append("Token='" + Ticket.Token + "' ");
                    a.AppendLine("where Cuit='" + Ticket.Cuit + "' and Service = '" + Ticket.Service + "' ");
                    Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
                }
            }
            catch (Exception ex)
            {
                Funciones.GrabarLogTexto("Consultar.txt", ex.Message + " " + ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }
    }
}
