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
            string idUsuarioAux = Sesion.Usuario.Id;
            try
            {
                Entidades.Sesion sesionCedWeb = SesionCedWeb();
                Entidades.Usuario usuario = new Entidades.Usuario();
                Entidades.Cuit cuit = new Entidades.Cuit();

                usuario.Id = IdCuenta;
                sesionCedWeb.Usuario = usuario;
                Sesion.Usuario.Id = IdCuenta;
                DB.Migracion dbCedWeb = new DB.Migracion(sesionCedWeb);
                //Usuario
                DataTable dtCuenta = dbCedWeb.LeerCuenta(IdCuenta);
                usuario.Id = Convert.ToString(dtCuenta.Rows[0]["IdCuenta"]);
                usuario.Nombre = Convert.ToString(dtCuenta.Rows[0]["Nombre"]);
                usuario.Telefono = Convert.ToString(dtCuenta.Rows[0]["Telefono"]);
                usuario.Email = Convert.ToString(dtCuenta.Rows[0]["Email"]);
                usuario.Password = Convert.ToString(dtCuenta.Rows[0]["Password"]);
                usuario.Pregunta = Convert.ToString(dtCuenta.Rows[0]["Pregunta"]);
                usuario.Respuesta = Convert.ToString(dtCuenta.Rows[0]["Respuesta"]);
                usuario.CantidadEnviosMail = Convert.ToInt32(dtCuenta.Rows[0]["CantidadEnviosMail"]);
                usuario.FechaUltimoReenvioMail = Convert.ToDateTime(dtCuenta.Rows[0]["FechaUltimoReenvioMail"]);
                usuario.EmailSMS = Convert.ToString(dtCuenta.Rows[0]["EmailSMS"]);
                RN.Usuario.Registrar(usuario, false, Sesion);
                RN.Usuario.Confirmar(usuario, false, false, Sesion);
                //Cuit
                DataTable dtVendedor = dbCedWeb.LeerVendedor(IdCuenta);
                if (dtVendedor.Rows.Count > 0)
                {
                    cuit.Nro = Convert.ToString(dtVendedor.Rows[0]["CUIT"]);
                    cuit.RazonSocial = Convert.ToString(dtVendedor.Rows[0]["RazonSocial"]);
                    cuit.Domicilio.Calle = Convert.ToString(dtVendedor.Rows[0]["Calle"]);
                    cuit.Domicilio.Nro = Convert.ToString(dtVendedor.Rows[0]["Nro"]);
                    cuit.Domicilio.Piso = Convert.ToString(dtVendedor.Rows[0]["Piso"]);
                    cuit.Domicilio.Depto = Convert.ToString(dtVendedor.Rows[0]["Depto"]);
                    cuit.Domicilio.Sector = Convert.ToString(dtVendedor.Rows[0]["Sector"]);
                    cuit.Domicilio.Torre = Convert.ToString(dtVendedor.Rows[0]["Torre"]);
                    cuit.Domicilio.Manzana = Convert.ToString(dtVendedor.Rows[0]["Manzana"]);
                    cuit.Domicilio.Localidad = Convert.ToString(dtVendedor.Rows[0]["Localidad"]);
                    cuit.Domicilio.Provincia.Id = Convert.ToString(dtVendedor.Rows[0]["IdProvincia"]);
                    cuit.Domicilio.Provincia.Descr = Convert.ToString(dtVendedor.Rows[0]["DescrProvincia"]);
                    cuit.Domicilio.CodPost = Convert.ToString(dtVendedor.Rows[0]["CodPost"]);
                    cuit.Contacto.Nombre = Convert.ToString(dtVendedor.Rows[0]["NombreContacto"]);
                    cuit.Contacto.Email = Convert.ToString(dtVendedor.Rows[0]["EmailContacto"]);
                    cuit.Contacto.Telefono = Convert.ToString(dtVendedor.Rows[0]["TelefonoContacto"]);
                    cuit.DatosImpositivos.IdCondIVA = Convert.ToInt32(dtVendedor.Rows[0]["IdCondIVA"]);
                    cuit.DatosImpositivos.DescrCondIVA = Convert.ToString(dtVendedor.Rows[0]["DescrCondIVA"]);
                    cuit.DatosImpositivos.IdCondIngBrutos = Convert.ToInt32(dtVendedor.Rows[0]["IdCondIngBrutos"]);
                    cuit.DatosImpositivos.DescrCondIngBrutos = Convert.ToString(dtVendedor.Rows[0]["DescrCondIngBrutos"]);
                    cuit.DatosImpositivos.FechaInicioActividades = Convert.ToDateTime(dtVendedor.Rows[0]["FechaInicioActividades"]);
                    cuit.DatosIdentificatorios.GLN = Convert.ToInt64(dtVendedor.Rows[0]["GLN"]);
                    cuit.DatosIdentificatorios.CodigoInterno = Convert.ToString(dtVendedor.Rows[0]["CodigoInterno"]);
                    cuit.Medio.Id = Convert.ToString(dtCuenta.Rows[0]["IdMedio"]);
                    cuit.NroSerieCertifAFIP = String.Empty;
                    cuit.NroSerieCertifITF = Convert.ToString(dtCuenta.Rows[0]["NroSerieCertificado"]);
                    RN.Cuit.Crear(cuit, Sesion);
                }
                //PuntoVta
                DataTable dtPuntoDeVenta = dbCedWeb.LeerPuntoDeVenta(IdCuenta);
                for (int i = 0; i < dtPuntoDeVenta.Rows.Count; i++)
                {
                    Entidades.PuntoVta puntoVta = new Entidades.PuntoVta();
                    puntoVta.Cuit = Convert.ToString(dtPuntoDeVenta.Rows[i]["CUIT"]);
                    puntoVta.Nro = Convert.ToInt32(dtPuntoDeVenta.Rows[i]["IdPuntoDeVenta"]);
                    puntoVta.IdUN = 1;
                    switch (Convert.ToString(dtPuntoDeVenta.Rows[i]["IdTipoPuntoDeVenta"]))
                    {
                        case "BFiscal":
                            puntoVta.IdTipoPuntoVta = "BonoFiscal";
                            break;
                        case "Export":
                            puntoVta.IdTipoPuntoVta = "Exportacion";
                            break;
                        default:
                            puntoVta.IdTipoPuntoVta = Convert.ToString(dtPuntoDeVenta.Rows[i]["IdTipoPuntoDeVenta"]);
                            break;
                    }
                    puntoVta.UsaSetPropioDeDatosCuit = Convert.ToString(dtPuntoDeVenta.Rows[0]["Calle"]) != String.Empty && (Convert.ToString(dtPuntoDeVenta.Rows[0]["Calle"]) != cuit.Domicilio.Calle || Convert.ToString(dtPuntoDeVenta.Rows[0]["Nro"]) != cuit.Domicilio.Nro) && cuit.Nro.IndexOf("/33234434312/30709010480/30592449524/") != 0;
                    if (puntoVta.UsaSetPropioDeDatosCuit)
                    {
                        puntoVta.Domicilio.Calle = Convert.ToString(dtPuntoDeVenta.Rows[0]["Calle"]);
                        puntoVta.Domicilio.Nro = Convert.ToString(dtPuntoDeVenta.Rows[0]["Nro"]);
                        puntoVta.Domicilio.Piso = Convert.ToString(dtPuntoDeVenta.Rows[0]["Piso"]);
                        puntoVta.Domicilio.Depto = Convert.ToString(dtPuntoDeVenta.Rows[0]["Depto"]);
                        puntoVta.Domicilio.Sector = Convert.ToString(dtPuntoDeVenta.Rows[0]["Sector"]);
                        puntoVta.Domicilio.Torre = Convert.ToString(dtPuntoDeVenta.Rows[0]["Torre"]);
                        puntoVta.Domicilio.Manzana = Convert.ToString(dtPuntoDeVenta.Rows[0]["Manzana"]);
                        puntoVta.Domicilio.Localidad = Convert.ToString(dtPuntoDeVenta.Rows[0]["Localidad"]);
                        puntoVta.Domicilio.Provincia.Id = Convert.ToString(dtPuntoDeVenta.Rows[0]["IdProvincia"]);
                        puntoVta.Domicilio.Provincia.Descr = Convert.ToString(dtPuntoDeVenta.Rows[0]["DescrProvincia"]);
                        puntoVta.Domicilio.CodPost = Convert.ToString(dtPuntoDeVenta.Rows[0]["CodPost"]);
                    }
                    else
                    {
                        puntoVta.Domicilio.Calle = String.Empty;
                        puntoVta.Domicilio.Nro = String.Empty;
                        puntoVta.Domicilio.Piso = String.Empty;
                        puntoVta.Domicilio.Depto = String.Empty;
                        puntoVta.Domicilio.Manzana = String.Empty;
                        puntoVta.Domicilio.Sector = String.Empty;
                        puntoVta.Domicilio.Torre = String.Empty;
                        puntoVta.Domicilio.Localidad = String.Empty;
                        puntoVta.Domicilio.Provincia.Id = String.Empty;
                        puntoVta.Domicilio.Provincia.Descr = String.Empty;
                        puntoVta.Domicilio.CodPost = String.Empty;
                    }
                    //La tabla PuntoDeVenta sólo puede contener los datos de Domicilio
                    puntoVta.Contacto.Nombre = String.Empty;
                    puntoVta.Contacto.Email = String.Empty;
                    puntoVta.Contacto.Telefono = String.Empty;
                    puntoVta.DatosImpositivos.IdCondIVA = 0;
                    puntoVta.DatosImpositivos.DescrCondIVA = String.Empty;
                    puntoVta.DatosImpositivos.IdCondIngBrutos = 0;
                    puntoVta.DatosImpositivos.DescrCondIngBrutos = String.Empty;
                    puntoVta.DatosImpositivos.NroIngBrutos = String.Empty;
                    puntoVta.DatosImpositivos.FechaInicioActividades = new DateTime(1900, 1, 1);
                    puntoVta.DatosIdentificatorios.GLN = 0;
                    puntoVta.DatosIdentificatorios.CodigoInterno = String.Empty;
                    puntoVta.IdMetodoGeneracionNumeracionLote = "TimeStamp";
                    puntoVta.UltNroLote = 0;
                    RN.PuntoVta.Crear(puntoVta, Sesion);
                }
            }
            finally
            {
                Sesion.Usuario.Id = idUsuarioAux;
            }
        }
        public static DataTable CuentasNoMigradas(Entidades.Sesion Sesion)
        {
            DB.Migracion db = new DB.Migracion(SesionCedWeb());
            return db.ListaCuentasNoMigradas(RN.Usuario.ListaIdUsuariosParaSQLscript(Sesion));
        }
        private static Entidades.Sesion SesionCedWeb()
        {
            Entidades.Sesion sesion = new Entidades.Sesion();
            sesion.CnnStr = CnnStrCedWeb();
            return sesion;
        }
        private static string CnnStrCedWeb()
        {
            return "User ID=cedeira;Password=mosca290rijo;data source=ar64.toservers.com,2433;persist security info=False;initial catalog=cedeira;";
        }
    }
}
