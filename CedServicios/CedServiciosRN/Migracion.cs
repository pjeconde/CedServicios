using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.RN
{
    public class Migracion
    {
        public static void CopiarCuenta(string IdCuenta, Entidades.Sesion Sesion)
        {
            Entidades.Sesion sesionCedWeb = new Entidades.Sesion();
            sesionCedWeb.CnnStr = CnnStrCedWeb();
            Entidades.Usuario usuario = new Entidades.Usuario();
            usuario.Id = IdCuenta;
            sesionCedWeb.Usuario = usuario;
            DB.Migracion dbCedWeb = new DB.Migracion(sesionCedWeb);
            //Usuario
            DataTable dtCuenta = dbCedWeb.LeerCuenta(IdCuenta);
            //Cuit
            DataTable dtVendedor = dbCedWeb.LeerVendedor(IdCuenta);
            //PuntoVta
            DataTable dtPuntoDeVenta = dbCedWeb.LeerPuntoDeVenta(IdCuenta);
        }
        public static void CopiarTodasLasCuentas(Entidades.Sesion Sesion)
        {
        }
        private static string CnnStrCedWeb()
        {
            return "User ID=cedeira;Password=mosca290rijo;data source=ar64.toservers.com,2433;persist security info=False;initial catalog=cedeira;";
        }
    }
}
