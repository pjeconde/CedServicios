using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Cliente
    {
        public static List<Entidades.Cliente> ListaPorCuit(Entidades.Sesion Sesion)
        {
            DB.Cliente db = new DB.Cliente(Sesion);
            return db.ListaPorCuit();
        }
        public static List<Entidades.Cliente> ListaExportacion(Entidades.Usuario Cuenta, Entidades.Sesion Sesion, bool ConSeleccionarComprador)
		{
			DB.Cliente comprador = new DB.Cliente(Sesion);
			List<Entidades.Cliente> lista = comprador.ListaPorCuit();
			lista = lista.FindAll(delegate(Entidades.Cliente c)
			{
				return c.Documento.Tipo.Equals(70) || c.RazonSocial.Equals("Seleccionar cliente");
			});
			return lista;
		}
        public static List<Entidades.Cliente> ListaSinExportacion(Entidades.Usuario Cuenta, Entidades.Sesion Sesion, bool ConSeleccionarComprador)
        {
            DB.Cliente comprador = new DB.Cliente(Sesion);
            List<Entidades.Cliente> lista = comprador.ListaPorCuit();
            lista = lista.FindAll(delegate(Entidades.Cliente c)
            {
                return !c.Documento.Tipo.Equals(70) || c.RazonSocial.Equals("Seleccionar cliente");
            });
            return lista;
        }
        public static void Leer(Entidades.Cliente cliente, Entidades.Sesion Sesion)
        {
            DB.Cliente comprador = new DB.Cliente(Sesion);
            comprador.Leer(cliente);  
        }
    }
}