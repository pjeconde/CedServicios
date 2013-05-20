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
            Entidades.Usuario usuario = new Entidades.Usuario();
            usuario.Id = IdCuenta;
            try
            {
                Entidades.Sesion sesionCedWeb = SesionCedWeb();
                Entidades.Cuit cuit = new Entidades.Cuit();
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
                    cuit.DatosImpositivos.NroIngBrutos = Convert.ToString(dtVendedor.Rows[0]["NroIngBrutos"]);
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
                    puntoVta.UsaSetPropioDeDatosCuit = Convert.ToString(dtPuntoDeVenta.Rows[i]["Calle"]) != String.Empty && (Convert.ToString(dtPuntoDeVenta.Rows[i]["Calle"]) != cuit.Domicilio.Calle || Convert.ToString(dtPuntoDeVenta.Rows[i]["Nro"]) != cuit.Domicilio.Nro) && cuit.Nro.IndexOf("/33234434312/30709010480/30592449524/") != 0;
                    if (puntoVta.UsaSetPropioDeDatosCuit)
                    {
                        puntoVta.Domicilio.Calle = Convert.ToString(dtPuntoDeVenta.Rows[i]["Calle"]);
                        puntoVta.Domicilio.Nro = Convert.ToString(dtPuntoDeVenta.Rows[i]["Nro"]);
                        puntoVta.Domicilio.Piso = Convert.ToString(dtPuntoDeVenta.Rows[i]["Piso"]);
                        puntoVta.Domicilio.Depto = Convert.ToString(dtPuntoDeVenta.Rows[i]["Depto"]);
                        puntoVta.Domicilio.Sector = Convert.ToString(dtPuntoDeVenta.Rows[i]["Sector"]);
                        puntoVta.Domicilio.Torre = Convert.ToString(dtPuntoDeVenta.Rows[i]["Torre"]);
                        puntoVta.Domicilio.Manzana = Convert.ToString(dtPuntoDeVenta.Rows[i]["Manzana"]);
                        puntoVta.Domicilio.Localidad = Convert.ToString(dtPuntoDeVenta.Rows[i]["Localidad"]);
                        puntoVta.Domicilio.Provincia.Id = Convert.ToString(dtPuntoDeVenta.Rows[i]["IdProvincia"]);
                        puntoVta.Domicilio.Provincia.Descr = Convert.ToString(dtPuntoDeVenta.Rows[i]["DescrProvincia"]);
                        puntoVta.Domicilio.CodPost = Convert.ToString(dtPuntoDeVenta.Rows[i]["CodPost"]);
                        //La tabla PuntoDeVenta sólo puede contener los datos de Domicilio
                        puntoVta.Contacto.Nombre = cuit.Contacto.Nombre;
                        puntoVta.Contacto.Email = cuit.Contacto.Email;
                        puntoVta.Contacto.Telefono = cuit.Contacto.Telefono;
                        puntoVta.DatosImpositivos.IdCondIVA = cuit.DatosImpositivos.IdCondIVA;
                        puntoVta.DatosImpositivos.DescrCondIVA = cuit.DatosImpositivos.DescrCondIVA;
                        puntoVta.DatosImpositivos.IdCondIngBrutos = cuit.DatosImpositivos.IdCondIngBrutos;
                        puntoVta.DatosImpositivos.DescrCondIngBrutos = cuit.DatosImpositivos.DescrCondIngBrutos;
                        puntoVta.DatosImpositivos.NroIngBrutos = cuit.DatosImpositivos.NroIngBrutos;
                        puntoVta.DatosImpositivos.FechaInicioActividades = cuit.DatosImpositivos.FechaInicioActividades;
                        puntoVta.DatosIdentificatorios.GLN = cuit.DatosIdentificatorios.GLN;
                        puntoVta.DatosIdentificatorios.CodigoInterno = cuit.DatosIdentificatorios.CodigoInterno;
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
                    }
                    puntoVta.IdMetodoGeneracionNumeracionLote = "Ninguno";
                    puntoVta.UltNroLote = 0;
                    RN.PuntoVta.Crear(puntoVta, Sesion);
                }
                //Cliente
                DataTable dtComprador = dbCedWeb.LeerComprador(IdCuenta);
                for (int j = 0; j < dtComprador.Rows.Count; j++)
                {
                    Entidades.Cliente cliente = new Entidades.Cliente();
                    cliente.Cuit = cuit.Nro;
                    cliente.Documento.Tipo.Id = Convert.ToString(dtComprador.Rows[j]["IdTipoDoc"]);
                    cliente.Documento.Tipo.Descr = Convert.ToString(dtComprador.Rows[j]["DescrTipoDoc"]);
                    cliente.Documento.Nro = Convert.ToInt64(dtComprador.Rows[j]["NroDoc"]);
                    cliente.DesambiguacionCuitPais = 0;
                    cliente.RazonSocial = Convert.ToString(dtComprador.Rows[j]["RazonSocial"]);
                    cliente.Domicilio.Calle = Convert.ToString(dtComprador.Rows[j]["Calle"]);
                    cliente.Domicilio.Nro = Convert.ToString(dtComprador.Rows[j]["Nro"]);
                    cliente.Domicilio.Piso = Convert.ToString(dtComprador.Rows[j]["Piso"]);
                    cliente.Domicilio.Depto = Convert.ToString(dtComprador.Rows[j]["Depto"]);
                    cliente.Domicilio.Sector = Convert.ToString(dtComprador.Rows[j]["Sector"]);
                    cliente.Domicilio.Torre = Convert.ToString(dtComprador.Rows[j]["Torre"]);
                    cliente.Domicilio.Manzana = Convert.ToString(dtComprador.Rows[j]["Manzana"]);
                    cliente.Domicilio.Localidad = Convert.ToString(dtComprador.Rows[j]["Localidad"]);
                    cliente.Domicilio.Provincia.Id = Convert.ToString(dtComprador.Rows[j]["IdProvincia"]);
                    cliente.Domicilio.Provincia.Descr = Convert.ToString(dtComprador.Rows[j]["DescrProvincia"]);
                    cliente.Domicilio.CodPost = Convert.ToString(dtComprador.Rows[j]["CodPost"]);
                    cliente.Contacto.Nombre = Convert.ToString(dtComprador.Rows[j]["NombreContacto"]);
                    cliente.Contacto.Email = Convert.ToString(dtComprador.Rows[j]["EmailContacto"]);
                    cliente.Contacto.Telefono = Convert.ToString(dtComprador.Rows[j]["TelefonoContacto"]);
                    cliente.DatosImpositivos.IdCondIVA = Convert.ToInt32(dtComprador.Rows[j]["IdCondIVA"]);
                    cliente.DatosImpositivos.DescrCondIVA = Convert.ToString(dtComprador.Rows[j]["DescrCondIVA"]);
                    cliente.DatosImpositivos.IdCondIngBrutos = Convert.ToInt32(dtComprador.Rows[j]["IdCondIngBrutos"]);
                    cliente.DatosImpositivos.DescrCondIngBrutos = Convert.ToString(dtComprador.Rows[j]["DescrCondIngBrutos"]);
                    cliente.DatosImpositivos.NroIngBrutos = Convert.ToString(dtComprador.Rows[j]["NroIngBrutos"]);
                    cliente.DatosImpositivos.FechaInicioActividades = Convert.ToDateTime(dtComprador.Rows[j]["FechaInicioActividades"]);
                    cliente.DatosIdentificatorios.GLN = Convert.ToInt64(dtComprador.Rows[j]["GLN"]);
                    cliente.DatosIdentificatorios.CodigoInterno = Convert.ToString(dtComprador.Rows[j]["CodigoInterno"]);
                    cliente.EmailAvisoVisualizacion = Convert.ToString(dtComprador.Rows[j]["EmailAvisoVisualizacion"]);
                    cliente.PasswordAvisoVisualizacion = Convert.ToString(dtComprador.Rows[j]["PasswordAvisoVisualizacion"]);
                    RN.Cliente.Crear(cliente, Sesion);
                }
            }
            catch (Exception ex)
            {
                AnularCopiaCuenta(usuario, Sesion);
                throw ex;
            }
            finally
            {
                Sesion.Usuario.Id = idUsuarioAux;
            }
        }
        private static void AnularCopiaCuenta(Entidades.Usuario Usuario, Entidades.Sesion Sesion)
        {
            DB.Usuario db = new DB.Usuario(Sesion);
            db.EliminarFISICAMENTEelUsuarioySusCuitsAdministrados(Usuario);
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
