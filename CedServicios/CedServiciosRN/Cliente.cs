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
        public static List<Entidades.Cliente> ListaPorCuityTipoyNroDoc(string Cuit, Entidades.Documento Documento, Entidades.Sesion Sesion)
        {
            DB.Cliente db = new DB.Cliente(Sesion);
            return db.ListaPorCuityTipoyNroDoc(Cuit, Documento);
        }
        public static List<Entidades.Cliente> ListaPorCuityRazonSocial(string Cuit, string Razonsocial, Entidades.Sesion Sesion)
        {
            DB.Cliente db = new DB.Cliente(Sesion);
            return db.ListaPorCuityRazonSocial(Cuit, Razonsocial);
        }
        public static List<Entidades.Cliente> ListaPorCuityIdCliente(string Cuit, string IdCliente, Entidades.Sesion Sesion)
        {
            DB.Cliente db = new DB.Cliente(Sesion);
            return db.ListaPorCuityIdCliente(Cuit, IdCliente);
        }
        public static void Leer(Entidades.Cliente cliente, Entidades.Sesion Sesion)
        {
            DB.Cliente comprador = new DB.Cliente(Sesion);
            comprador.Leer(cliente);  
        }
        public static void Crear(Entidades.Cliente Cliente, Entidades.Sesion Sesion)
        {
            DB.Cliente db = new DB.Cliente(Sesion);
            Cliente.WF.Estado = "Vigente";
            db.Crear(Cliente);
        }
    }
}