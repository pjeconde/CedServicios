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
    }
}