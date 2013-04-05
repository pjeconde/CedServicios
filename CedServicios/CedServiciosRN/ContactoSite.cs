using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace CedServicios.RN
{
    public class ContactoSite
    {
        public static void Validar(Entidades.ContactoSite ContactoSite, string ClaveCatpcha, string Clave)
        {
            if (ContactoSite.Motivo == String.Empty)
            {
                throw new EX.Validaciones.ValorNoInfo("Motivo");
            }
            else
            {
                if (ContactoSite.Nombre == String.Empty)
                {
                    throw new EX.Validaciones.ValorNoInfo("Nombre");
                }
                else
                {
                    if (ContactoSite.Telefono == String.Empty)
                    {
                        throw new EX.Validaciones.ValorNoInfo("Teléfono");
                    }
                    else
                    {
                        if (ContactoSite.Email == String.Empty)
                        {
                            throw new EX.Validaciones.ValorNoInfo("Email");
                        }
                        else
                        {
                            if (!Funciones.EsEmail(ContactoSite.Email))
                            {
                                throw new EX.Validaciones.ValorInvalido("Email");
                            }
                            else
                            {
                                if (ContactoSite.Mensaje == String.Empty)
                                {
                                    throw new EX.Validaciones.ValorNoInfo("Mensaje");
                                }
                                else
                                {
                                    if (!ClaveCatpcha.Equals(Clave.ToLower()))
                                    {
                                        throw new EX.Validaciones.ValorInvalido("Clave");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Registrar(Entidades.ContactoSite ContactoSite)
        {
            StringBuilder a;
            string cuentaMailCedeira;
            if (ContactoSite.Motivo == "FactElectronica")
            {
                cuentaMailCedeira = "facturaelectronica@cedeira.com.ar";
            }
            else
            {
                cuentaMailCedeira = "info@cedeira.com.ar";
            }
            RN.EnvioCorreo.ContactoSite(ContactoSite, cuentaMailCedeira);
        }
    }
}
