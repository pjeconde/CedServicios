using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class Usuario
    {
        public static void Leer(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            CedServicios.DB.Usuario usuario = new  DB.Usuario(Sesion);
            usuario.Leer(Usuario);
        }
        public static void Login(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            if (Usuario.Id == String.Empty)
            {
                throw new CedServicios.EX.Validaciones.ValorNoInfo("Id.Usuario");
            }
            else
            {
                if (Usuario.Password == String.Empty)
                {
                    throw new CedServicios.EX.Validaciones.ValorNoInfo("Contraseña");
                }
                else
                {
                    string passwordIngresada = Usuario.Password;
                    Leer(Usuario, Sesion);
                    if (passwordIngresada != Usuario.Password)
                    {
                        throw new CedServicios.EX.Usuario.LoginRechazadoXPasswordInvalida();
                    }
                    //Se impide el login a cuenta pendientes de confirmacion o dadas de baja
                    //(las cuentas "Prem" suspendidas se comportan como cuentas "Free")
                    if (Usuario.WF.Estado != "Vigente")
                    {
                        throw new CedServicios.EX.Usuario.LoginRechazadoXEstadoCuenta();
                    }
                }
            }
        }
    }
}