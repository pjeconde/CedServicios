using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;
using Ionic.Zip;
using System.Diagnostics;

namespace CedServicios.RN
{
    public class Comprobante
    {
        public static List<Entidades.Comprobante> ListaContratosFiltrada(List<Entidades.Estado> Estados, string FechaEmision, Entidades.Persona Persona, string Moneda, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            return db.ListaContratosFiltrada(Estados, FechaEmision, Persona, Moneda);
        }
        public static List<Entidades.Comprobante> ListaFiltrada(List<Entidades.Estado> Estados, string FechaDesde, string FechaHasta, Entidades.Persona Persona, Entidades.NaturalezaComprobante NaturalezaComprobante, bool IncluirContratos, string Detalle, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            return db.ListaFiltrada(Estados, FechaDesde, FechaHasta, Persona, NaturalezaComprobante, IncluirContratos, Detalle);
        }
        public static void Registrar(FeaEntidades.InterFacturas.lote_comprobantes Lote, Object Response, string IdNaturalezaComprobante, string IdDestinoComprobante, string IdEstado, string PeriodicidadEmision, DateTime FechaProximaEmision, int CantidadComprobantesAEmitir, int CantidadComprobantesEmitidos, int CantidadDiasFechaVto, string Detalle, bool EmailAvisoComprobanteActivo, string IdDestinatarioFrecuente, string EmailAvisoComprobanteAsunto, string EmailAvisoComprobanteCuerpo, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            db.Registrar(Lote, Response, IdNaturalezaComprobante, IdDestinoComprobante, IdEstado, PeriodicidadEmision, FechaProximaEmision, CantidadComprobantesAEmitir, CantidadComprobantesEmitidos, CantidadDiasFechaVto, Detalle, EmailAvisoComprobanteActivo, IdDestinatarioFrecuente, EmailAvisoComprobanteAsunto, EmailAvisoComprobanteCuerpo);
        }
        public static void DarDeBaja(Entidades.Comprobante Comprobante, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            db.DarDeBaja(Comprobante);
        }
        public static void AnularBaja(Entidades.Comprobante Comprobante, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            db.AnularBaja(Comprobante);
        }
        public static void ActualizarFechaProximaEmision(Entidades.Comprobante Comprobante, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            db.ActualizarFechaProximaEmision(Comprobante);
        }
        public static void Leer(Entidades.Comprobante Comprobante, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            db.Leer(Comprobante);
        }
        public static FeaEntidades.InterFacturas.lote_comprobantes ConsultarIBK(IBK.consulta_lote_comprobantes clc, string certificado)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            lc.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lc.comprobante = new FeaEntidades.InterFacturas.comprobante[1];
            IBK.FacturaWebServiceConSchema objIBK;
			objIBK = new IBK.FacturaWebServiceConSchema();
            objIBK.Url = System.Configuration.ConfigurationManager.AppSettings["URLinterfacturas"];
            if (System.Configuration.ConfigurationManager.AppSettings["Proxy"] != null && System.Configuration.ConfigurationManager.AppSettings["Proxy"] != "")
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
                string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
                string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
                string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
            X509Store store;
            if (storeLocation == "CurrentUser")
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, certificado, true);
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                System.Threading.Thread.Sleep(1000);
                IBK.consulta_lote_comprobantes_response clcr = objIBK.getLoteFacturasConSchema(clc);
                IBK.consulta_lote_response clr;
                try
                {
                    clr = (IBK.consulta_lote_response)clcr.Item;
                    IBK.lote_comprobantes lcIBK = (IBK.lote_comprobantes)clr.Item;
                    lc = Ibk2Fea(lcIBK);
                }
                catch (InvalidCastException)
                {
                    StringBuilder errorText = new StringBuilder();
                    if (clcr.Item != null)
                    {
                        errorText.Append("Nro. de Lote: [" + clc.id_lote + "]\r\n");
                        if (clcr.Item.GetType() == typeof(IBK.consulta_lote_response))
                        {
                            clr = (IBK.consulta_lote_response)clcr.Item;
                            IBK.consulta_lote_responseErrores_consulta errores = (IBK.consulta_lote_responseErrores_consulta)clr.Item;
                            foreach (IBK.error elote in errores.error)
                            {
                                errorText.Append(elote.codigo_error + " - " + elote.descripcion_error + "\r\n");
                            }
                        }
                        else
                        {
                            IBK.consulta_lote_comprobantes_responseErrores_response clcrEr;
                            clcrEr = (IBK.consulta_lote_comprobantes_responseErrores_response)clcr.Item;
                            foreach (IBK.error elote in clcrEr.error)
                            {
                                errorText.Append(elote.codigo_error + " - " + elote.descripcion_error + "\r\n");
                            }
                        }
                    }
                    throw new Exception(errorText.ToString());
                }
                return lc;
            }
            else
            {
                throw new Exception("Su certificado no está disponible en nuestro repositorio");
            }
        }
        public static string EnviarIBK(FeaEntidades.InterFacturas.lote_comprobantes lc, string certificado)
        {
            IBK.lote_comprobantes lcIBK = new IBK.lote_comprobantes();
            lcIBK = Fea2Ibk(lc);

            IBK.FacturaWebServiceConSchema objIBK;
            objIBK = new IBK.FacturaWebServiceConSchema();
            objIBK.Url = System.Configuration.ConfigurationManager.AppSettings["URLinterfacturas"];
            if (System.Configuration.ConfigurationManager.AppSettings["Proxy"] != null && System.Configuration.ConfigurationManager.AppSettings["Proxy"] != "")
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
                string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
                string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
                string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];

                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
            X509Store store;
            if (storeLocation == "CurrentUser")
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, certificado, true);
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                System.Threading.Thread.Sleep(1000);
                IBK.lote_comprobantes_response lcr = objIBK.receiveFacturasConSchema(lcIBK);

                string resultado = string.Empty;
                if (lcr.Item.GetType() == typeof(IBK.lote_comprobantes_responseErrores_response))
                {
                    resultado = ((IBK.lote_comprobantes_responseErrores_response)lcr.Item).error[0].descripcion_error;
                }
                else if (!((IBK.lote_response)(lcr.Item)).estado.Equals("OK"))
                {
                    if (((IBK.lote_response)lcr.Item).errores_lote != null)
                    {
                        resultado += "Lote Nro.: " + ((IBK.lote_response)lcr.Item).id_lote + "  Estado: " + ((IBK.lote_response)lcr.Item).estado + "\\n";
                        foreach (IBK.error error in ((IBK.lote_response)lcr.Item).errores_lote)
                        {
                            resultado += error.codigo_error + " - " + error.descripcion_error + "\\n";
                        }
                        resultado += "\\n";
                    }
                    if (((IBK.lote_response)lcr.Item).comprobante_response != null)
                    {
                        foreach (IBK.comprobante_response cr in ((IBK.lote_response)lcr.Item).comprobante_response)
                        {
                            if (cr.errores_comprobante != null)
                            {
                                resultado += "Comprobante Nro.: " + cr.numero_comprobante + "\\n";
                                foreach (IBK.error error in cr.errores_comprobante)
                                {
                                    resultado += error.codigo_error + " - " + error.descripcion_error + "\\n";
                                }
                            }
                        }
                        resultado += "\\n";
                    }
                    throw new Exception(resultado);
                }
                else
                {
                    resultado = "Comprobante enviado satisfactoriamente a Interfacturas.";
                }
                return resultado;
            }
            else
            {
                throw new Exception("Su certificado no está disponible en nuestro repositorio");
            }
        }
        public static FeaEntidades.InterFacturas.lote_comprobantes ConsultarIBK(out IBK.error[] RespErroresLote, out IBK.error[] RespErroresComprobantes, IBK.consulta_lote_comprobantes clc, string certificado)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lc = new FeaEntidades.InterFacturas.lote_comprobantes();
            lc.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lc.comprobante = new FeaEntidades.InterFacturas.comprobante[1];
            IBK.error[] respErroresLote = new IBK.error[0];
            IBK.error[] respErroresComprobantes = new IBK.error[0];
			IBK.FacturaWebServiceConSchema objIBK;
			objIBK = new IBK.FacturaWebServiceConSchema();
            objIBK.Url = System.Configuration.ConfigurationManager.AppSettings["URLinterfacturas"];
            if (System.Configuration.ConfigurationManager.AppSettings["Proxy"] != "")
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
                string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
                string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
                string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
            X509Store store;
            if (storeLocation == "CurrentUser")
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, certificado, true);
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                System.Threading.Thread.Sleep(1000);
                IBK.consulta_lote_comprobantes_response clcr = objIBK.getLoteFacturasConSchema(clc);
                IBK.consulta_lote_response clr;
                try
                {
                    clr = (IBK.consulta_lote_response)clcr.Item;
                    IBK.lote_comprobantes lcIBK = (IBK.lote_comprobantes)clr.Item;
                    lc = Ibk2Fea(lcIBK);
                }
                catch (InvalidCastException)
                {
                    StringBuilder errorText = new StringBuilder();
                    if (clcr.Item != null)
                    {
                        errorText.Append("Lote Nro.: [" + clc.id_lote + "] \r\n");
                        if (clcr.Item.GetType() == typeof(IBK.consulta_lote_response))
                        {
                            clr = (IBK.consulta_lote_response)clcr.Item;
                            IBK.consulta_lote_responseErrores_consulta errores = (IBK.consulta_lote_responseErrores_consulta)clr.Item;
                            foreach (IBK.error elote in errores.error)
                            {
                                errorText.Append(elote.codigo_error + " - " + elote.descripcion_error + " \r\n");
                            }
                            RespErroresLote = errores.error;
                        }
                        else
                        {
                            IBK.consulta_lote_comprobantes_responseErrores_response clcrEr;
                            clcrEr = (IBK.consulta_lote_comprobantes_responseErrores_response)clcr.Item;
                            foreach (IBK.error elote in clcrEr.error)
                            {
                                errorText.Append(elote.codigo_error + " - " + elote.descripcion_error + " \r\n");
                            }
                            RespErroresComprobantes = clcrEr.error;
                        }
                    }
                    throw new Exception(errorText.ToString());
                }
                RespErroresLote = respErroresLote;
                RespErroresComprobantes = respErroresComprobantes;
                return lc;
            }
            else
            {
                throw new Exception("Su certificado no está disponible en nuestro repositorio");
            }
        }
        public static void EnviarIBK(out IBK.lote_response Lr, FeaEntidades.InterFacturas.lote_comprobantes lc, string certificado)
        {
            IBK.lote_comprobantes lcIBK = new IBK.lote_comprobantes();
            lcIBK = Fea2Ibk(lc);
			IBK.FacturaWebServiceConSchema objIBK;
			objIBK = new IBK.FacturaWebServiceConSchema();
            objIBK.Url = System.Configuration.ConfigurationManager.AppSettings["URLinterfacturas"];
            if (System.Configuration.ConfigurationManager.AppSettings["Proxy"] != null && System.Configuration.ConfigurationManager.AppSettings["Proxy"] != "")
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
                string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
                string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
                string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];
                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
            X509Store store;
            if (storeLocation == "CurrentUser")
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else 
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, certificado, true);
            if (col.Count.Equals(1))
            {
                //objIBK.RequestEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
                objIBK.ClientCertificates.Add(col[0]);
                System.Threading.Thread.Sleep(1000);
                IBK.lote_comprobantes_response lcr = objIBK.receiveFacturasConSchema(lcIBK);
                IBK.lote_response lr = new IBK.lote_response();
                try
                {
                    lr = ((IBK.lote_response)lcr.Item);
                    if (lr.estado == "OK")
                    {
                        Lr = lr;
                    }
                    else
                    {
                        Lr = lr;
                        StringBuilder errorText = new StringBuilder();
                        if (Lr.errores_lote != null)
                        {
                            errorText.Append("Lote Nro.: [" + Lr.id_lote + "] \r\n");
                            foreach (RN.IBK.error elote in Lr.errores_lote)
                            {
                                errorText.Append(elote.codigo_error + " - " + elote.descripcion_error + " \r\n");
                            }
                            errorText.Append("\r\n");
                        }
                        if (Lr.comprobante_response != null)
                        {
                            foreach (RN.IBK.comprobante_response comprobante in Lr.comprobante_response)
                            {
                                if (comprobante.errores_comprobante != null)
                                {
                                    errorText.Append("Nro. de Comprobante: [" + comprobante.numero_comprobante + "]  Punto de Venta: [" + comprobante.punto_de_venta + "]  Tipo de Comprobante: [" + comprobante.tipo_de_comprobante + "] \r\n");
                                    foreach (RN.IBK.error ecomprobante in comprobante.errores_comprobante)
                                    {
                                        errorText.Append(ecomprobante.codigo_error + " - " + ecomprobante.descripcion_error + " \r\n");
                                    }
                                }
                            }
                        }
                        throw new EX.Lote.ProblemasEnvio(errorText.ToString());
                    }
                }
                catch (InvalidCastException)
                {
                    StringBuilder errorText = new StringBuilder();
                    if (lcr.Item != null)
                    {
                        if (lcr.Item.GetType() == typeof(IBK.lote_comprobantes_responseErrores_response))
                        {
                            IBK.lote_comprobantes_responseErrores_response lcrEr = new RN.IBK.lote_comprobantes_responseErrores_response();
                            errorText.Append("Nro. de Lote: [" + lc.cabecera_lote.id_lote + "] \r\n");
                            lcrEr = (IBK.lote_comprobantes_responseErrores_response)lcr.Item;
                            foreach (IBK.error error in lcrEr.error)
                            {
                                errorText.Append(error.codigo_error + " - " + error.descripcion_error + " \r\n");
                            }
                        }
                    }
                    throw new Exception(errorText.ToString());
                }
            }
            else
            {
                throw new Exception("Su certificado no está disponible en nuestro repositorio");
            }
        }
        private static FeaEntidades.InterFacturas.lote_comprobantes Ibk2Fea(IBK.lote_comprobantes lcIBK)
        {
            FeaEntidades.InterFacturas.lote_comprobantes lcFEA = new FeaEntidades.InterFacturas.lote_comprobantes();

            lcFEA.cabecera_lote = new FeaEntidades.InterFacturas.cabecera_lote();
            lcFEA.cabecera_lote.cantidad_reg = lcIBK.cabecera_lote.cantidad_reg;
            lcFEA.cabecera_lote.cod_interno_canal = lcIBK.cabecera_lote.cod_interno_canal;
            lcFEA.cabecera_lote.cuit_canal = lcIBK.cabecera_lote.cuit_canal;
            lcFEA.cabecera_lote.cuit_vendedor = lcIBK.cabecera_lote.cuit_vendedor;
            lcFEA.cabecera_lote.fecha_envio_lote = lcIBK.cabecera_lote.fecha_envio_lote;
            lcFEA.cabecera_lote.id_lote = lcIBK.cabecera_lote.id_lote;
            lcFEA.cabecera_lote.motivo = lcIBK.cabecera_lote.motivo;
            lcFEA.cabecera_lote.presta_serv = lcIBK.cabecera_lote.presta_serv;
            lcFEA.cabecera_lote.presta_servSpecified = lcIBK.cabecera_lote.presta_servSpecified;
            lcFEA.cabecera_lote.punto_de_venta = lcIBK.cabecera_lote.punto_de_venta;
            lcFEA.cabecera_lote.resultado = lcIBK.cabecera_lote.resultado;

            lcFEA.comprobante = new FeaEntidades.InterFacturas.comprobante[lcIBK.comprobante.Length];

            for (int i = 0; i < lcIBK.comprobante.Length; i++)
            {
                FeaEntidades.InterFacturas.comprobante cIBK = new FeaEntidades.InterFacturas.comprobante();

                cIBK.cabecera = new FeaEntidades.InterFacturas.cabecera();

                //Comprador
                cIBK.cabecera.informacion_comprador = new FeaEntidades.InterFacturas.informacion_comprador();
                cIBK.cabecera.informacion_comprador.codigo_doc_identificatorio = lcIBK.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.codigo_interno = lcIBK.comprobante[i].cabecera.informacion_comprador.codigo_interno;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_comprador.condicion_IVA = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_IVA;
                cIBK.cabecera.informacion_comprador.condicion_IVASpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.condicion_IVASpecified;
                cIBK.cabecera.informacion_comprador.contacto = lcIBK.comprobante[i].cabecera.informacion_comprador.contacto;
                cIBK.cabecera.informacion_comprador.cp = lcIBK.comprobante[i].cabecera.informacion_comprador.cp;
                cIBK.cabecera.informacion_comprador.denominacion = lcIBK.comprobante[i].cabecera.informacion_comprador.denominacion;
                cIBK.cabecera.informacion_comprador.domicilio_calle = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_calle;
                cIBK.cabecera.informacion_comprador.domicilio_depto = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_depto;
                cIBK.cabecera.informacion_comprador.domicilio_manzana = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_manzana;
                cIBK.cabecera.informacion_comprador.domicilio_numero = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_numero;
                cIBK.cabecera.informacion_comprador.domicilio_piso = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_piso;
                cIBK.cabecera.informacion_comprador.domicilio_sector = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_sector;
                cIBK.cabecera.informacion_comprador.domicilio_torre = lcIBK.comprobante[i].cabecera.informacion_comprador.domicilio_torre;
                cIBK.cabecera.informacion_comprador.email = lcIBK.comprobante[i].cabecera.informacion_comprador.email;
                cIBK.cabecera.informacion_comprador.GLN = lcIBK.comprobante[i].cabecera.informacion_comprador.GLN;
                cIBK.cabecera.informacion_comprador.GLNSpecified = lcIBK.comprobante[i].cabecera.informacion_comprador.GLNSpecified;
                cIBK.cabecera.informacion_comprador.inicio_de_actividades = lcIBK.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades;
                cIBK.cabecera.informacion_comprador.localidad = lcIBK.comprobante[i].cabecera.informacion_comprador.localidad;
                cIBK.cabecera.informacion_comprador.nro_doc_identificatorio = lcIBK.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.nro_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.provincia = lcIBK.comprobante[i].cabecera.informacion_comprador.provincia;
                cIBK.cabecera.informacion_comprador.telefono = lcIBK.comprobante[i].cabecera.informacion_comprador.telefono;
                
                //Info Comprobante
                cIBK.cabecera.informacion_comprobante = new FeaEntidades.InterFacturas.informacion_comprobante();
                cIBK.cabecera.informacion_comprobante.cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.cae;
                cIBK.cabecera.informacion_comprobante.caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.cae != null && cIBK.cabecera.informacion_comprobante.cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.codigo_operacion = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_operacion;
                cIBK.cabecera.informacion_comprobante.condicion_de_pago = lcIBK.comprobante[i].cabecera.informacion_comprobante.condicion_de_pago;
                cIBK.cabecera.informacion_comprobante.condicion_de_pagoSpecified = true;
                cIBK.cabecera.informacion_comprobante.es_detalle_encriptado = lcIBK.comprobante[i].cabecera.informacion_comprobante.es_detalle_encriptado;
                cIBK.cabecera.informacion_comprobante.fecha_emision = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_emision;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae != null && cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.fecha_obtencion_caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.fecha_serv_desde = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_serv_desde;
                cIBK.cabecera.informacion_comprobante.fecha_serv_hasta = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_serv_hasta;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae = lcIBK.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = false;
                if (cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae != null && cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae != "")
                {
                    cIBK.cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
                }
                cIBK.cabecera.informacion_comprobante.iva_computable = lcIBK.comprobante[i].cabecera.informacion_comprobante.iva_computable;
                cIBK.cabecera.informacion_comprobante.motivo = lcIBK.comprobante[i].cabecera.informacion_comprobante.motivo;
                cIBK.cabecera.informacion_comprobante.numero_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.numero_comprobante;
                cIBK.cabecera.informacion_comprobante.punto_de_venta = lcIBK.comprobante[i].cabecera.informacion_comprobante.punto_de_venta;
                cIBK.cabecera.informacion_comprobante.resultado = lcIBK.comprobante[i].cabecera.informacion_comprobante.resultado;
                cIBK.cabecera.informacion_comprobante.tipo_de_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;
                cIBK.cabecera.informacion_comprobante.codigo_concepto = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_concepto;
                cIBK.cabecera.informacion_comprobante.codigo_conceptoSpecified = lcIBK.comprobante[i].cabecera.informacion_comprobante.codigo_conceptoSpecified;

                //Info Vendedor
                cIBK.cabecera.informacion_vendedor = new FeaEntidades.InterFacturas.informacion_vendedor();
                cIBK.cabecera.informacion_vendedor.codigo_interno = lcIBK.comprobante[i].cabecera.informacion_vendedor.codigo_interno;
                cIBK.cabecera.informacion_vendedor.razon_social = lcIBK.comprobante[i].cabecera.informacion_vendedor.razon_social;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_vendedor.condicion_IVA = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_IVA;
                cIBK.cabecera.informacion_vendedor.condicion_IVASpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.condicion_IVASpecified;
                cIBK.cabecera.informacion_vendedor.contacto = lcIBK.comprobante[i].cabecera.informacion_vendedor.contacto;
                cIBK.cabecera.informacion_vendedor.cp = lcIBK.comprobante[i].cabecera.informacion_vendedor.cp;
                cIBK.cabecera.informacion_vendedor.cuit = lcIBK.comprobante[i].cabecera.informacion_vendedor.cuit;
                cIBK.cabecera.informacion_vendedor.domicilio_calle = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_calle;
                cIBK.cabecera.informacion_vendedor.domicilio_depto = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_depto;
                cIBK.cabecera.informacion_vendedor.domicilio_manzana = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana;
                cIBK.cabecera.informacion_vendedor.domicilio_numero = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_numero;
                cIBK.cabecera.informacion_vendedor.domicilio_piso = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_piso;
                cIBK.cabecera.informacion_vendedor.domicilio_sector = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_sector;
                cIBK.cabecera.informacion_vendedor.domicilio_torre = lcIBK.comprobante[i].cabecera.informacion_vendedor.domicilio_torre;
                cIBK.cabecera.informacion_vendedor.email = lcIBK.comprobante[i].cabecera.informacion_vendedor.email;
                cIBK.cabecera.informacion_vendedor.GLN = lcIBK.comprobante[i].cabecera.informacion_vendedor.GLN;
                cIBK.cabecera.informacion_vendedor.GLNSpecified = lcIBK.comprobante[i].cabecera.informacion_vendedor.GLNSpecified;
                cIBK.cabecera.informacion_vendedor.inicio_de_actividades = lcIBK.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades;
                cIBK.cabecera.informacion_vendedor.localidad = lcIBK.comprobante[i].cabecera.informacion_vendedor.localidad;
                cIBK.cabecera.informacion_vendedor.nro_ingresos_brutos = lcIBK.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.provincia = lcIBK.comprobante[i].cabecera.informacion_vendedor.provincia;
                cIBK.cabecera.informacion_vendedor.telefono = lcIBK.comprobante[i].cabecera.informacion_vendedor.telefono;

                //Info Comprobantes de Referencia
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    cIBK.cabecera.informacion_comprobante.referencias = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias[lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias.Length];

                    for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias.Length; j++)
                    {
                        if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j] != null)
                        {
                            cIBK.cabecera.informacion_comprobante.referencias[j] = new FeaEntidades.InterFacturas.informacion_comprobanteReferencias();
                            if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip == RN.IBK.informacion_comprobanteReferenciasTipo_comprobante_afip.S)
                            {
                                cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip = "S";
                            }
                            else if (lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip == RN.IBK.informacion_comprobanteReferenciasTipo_comprobante_afip.N)
                            {
                                cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip = "N";
                            }
                            cIBK.cabecera.informacion_comprobante.referencias[j].codigo_de_referencia = lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].codigo_de_referencia;
                            cIBK.cabecera.informacion_comprobante.referencias[j].dato_de_referencia = lcIBK.comprobante[i].cabecera.informacion_comprobante.referencias[j].dato_de_referencia;
                        }
                    }
                }
                
                //Info Informacion Adicional Comprobante
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante = new FeaEntidades.InterFacturas.informacion_adicional_comprobante[lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante.Length];

                    for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante.Length; j++)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j] = new FeaEntidades.InterFacturas.informacion_adicional_comprobante();
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j].tipo = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j].tipo;
                        cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j].valor = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j].valor;
                    }
                }
                
                //Info Exportación
                if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion = new FeaEntidades.InterFacturas.informacion_exportacion();
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.id_impositivo = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.id_impositivo;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.incoterms = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms;
                    if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != null && lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != "")
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permiso_existente = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente;
                    }
                    if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos != null)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos = new FeaEntidades.InterFacturas.permisos[lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length];
                        for (int j = 0; j < lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length; j++)
                        {
                            if (lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j] != null)
                            {
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j] = new FeaEntidades.InterFacturas.permisos();
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso;
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia = lcIBK.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia;
                            }
                        }
                    }
                }

                //Detalle y Lineas
                FeaEntidades.InterFacturas.detalle d = new FeaEntidades.InterFacturas.detalle();
                IBK.detalle detalle = (IBK.detalle)lcIBK.comprobante[i].Item;
                d.linea = new FeaEntidades.InterFacturas.linea[detalle.linea.Length];
                d.comentarios = detalle.comentarios;
                for (int j = 0; j < detalle.linea.Length; j++)
                {
                    if (detalle.linea[j] != null)
                    {
                        d.linea[j] = new FeaEntidades.InterFacturas.linea();
                        d.linea[j].alicuota_iva = detalle.linea[j].alicuota_iva;
                        d.linea[j].alicuota_ivaSpecified = detalle.linea[j].alicuota_ivaSpecified;
                        d.linea[j].cantidad = detalle.linea[j].cantidad;
                        d.linea[j].cantidadSpecified = detalle.linea[j].cantidadSpecified;
                        d.linea[j].codigo_producto_comprador = detalle.linea[j].codigo_producto_comprador;
                        d.linea[j].codigo_producto_vendedor = detalle.linea[j].codigo_producto_vendedor;
                        d.linea[j].descripcion = detalle.linea[j].descripcion;

                        d.linea[j].GTIN = detalle.linea[j].GTIN;
                        d.linea[j].GTINSpecified = detalle.linea[j].GTINSpecified;
                        d.linea[j].importe_iva = detalle.linea[j].importe_iva;
                        d.linea[j].importe_ivaSpecified = detalle.linea[j].importe_ivaSpecified;
                        d.linea[j].importe_total_articulo = detalle.linea[j].importe_total_articulo;
                        d.linea[j].importe_total_descuentos = detalle.linea[j].importe_total_descuentos;
                        d.linea[j].importe_total_descuentosSpecified = detalle.linea[j].importe_total_descuentosSpecified;
                        d.linea[j].importe_total_impuestos = detalle.linea[j].importe_total_impuestos;
                        d.linea[j].importe_total_impuestosSpecified = detalle.linea[j].importe_total_impuestosSpecified;

                        if (detalle.linea[j].importes_moneda_origen != null)
                        {
                            d.linea[j].importes_moneda_origen = new FeaEntidades.InterFacturas.lineaImportes_moneda_origen();
                            d.linea[j].importes_moneda_origen.importe_iva = detalle.linea[j].importes_moneda_origen.importe_iva;
                            d.linea[j].importes_moneda_origen.importe_ivaSpecified = detalle.linea[j].importes_moneda_origen.importe_ivaSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_articulo = detalle.linea[j].importes_moneda_origen.importe_total_articulo;
                            d.linea[j].importes_moneda_origen.importe_total_articuloSpecified = detalle.linea[j].importes_moneda_origen.importe_total_articuloSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_descuentos = detalle.linea[j].importes_moneda_origen.importe_total_descuentos;
                            d.linea[j].importes_moneda_origen.importe_total_descuentosSpecified = detalle.linea[j].importes_moneda_origen.importe_total_descuentosSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_impuestos = detalle.linea[j].importes_moneda_origen.importe_total_impuestos;
                            d.linea[j].importes_moneda_origen.importe_total_impuestosSpecified = detalle.linea[j].importes_moneda_origen.importe_total_impuestosSpecified;
                            d.linea[j].importes_moneda_origen.precio_unitario = detalle.linea[j].importes_moneda_origen.precio_unitario;
                            d.linea[j].importes_moneda_origen.precio_unitarioSpecified = detalle.linea[j].importes_moneda_origen.precio_unitarioSpecified;
                        }

                        if (detalle.linea[j].impuestos != null)
                        {
                            d.linea[j].impuestos = new FeaEntidades.InterFacturas.lineaImpuestos[detalle.linea[j].impuestos.Length];
                            for (int k = 0; k < d.linea[j].impuestos.Length; k++)
                            {
                                d.linea[j].impuestos[k] = new FeaEntidades.InterFacturas.lineaImpuestos();
                                d.linea[j].impuestos[k].codigo_impuesto = detalle.linea[j].impuestos[k].codigo_impuesto;
                                d.linea[j].impuestos[k].descripcion_impuesto = detalle.linea[j].impuestos[k].descripcion_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto = detalle.linea[j].impuestos[k].importe_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origen = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origen;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified;
                                d.linea[j].impuestos[k].porcentaje_impuesto = detalle.linea[j].impuestos[k].porcentaje_impuesto;
                                d.linea[j].impuestos[k].porcentaje_impuestoSpecified = detalle.linea[j].impuestos[k].porcentaje_impuestoSpecified;
                            }
                        }
                        if (detalle.linea[j].descuentos != null)
                        {
                            d.linea[j].lineaDescuentos = new FeaEntidades.InterFacturas.lineaDescuentos[detalle.linea[j].descuentos.Length];
                            for (int k = 0; k < d.linea[j].lineaDescuentos.Length; k++)
                            {
                                d.linea[j].lineaDescuentos[k] = new FeaEntidades.InterFacturas.lineaDescuentos();
                                d.linea[j].lineaDescuentos[k].descripcion_descuento = detalle.linea[j].descuentos[k].descripcion_descuento;
                                d.linea[j].lineaDescuentos[k].importe_descuento = detalle.linea[j].descuentos[k].importe_descuento;
                                d.linea[j].lineaDescuentos[k].importe_descuento_moneda_origen = detalle.linea[j].descuentos[k].importe_descuento_moneda_origen;
                                d.linea[j].lineaDescuentos[k].importe_descuento_moneda_origenSpecified = detalle.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified;
                                d.linea[j].lineaDescuentos[k].porcentaje_descuento = detalle.linea[j].descuentos[k].porcentaje_descuento;
                                d.linea[j].lineaDescuentos[k].porcentaje_descuentoSpecified = detalle.linea[j].descuentos[k].porcentaje_descuentoSpecified;
                            }
                        }
                        if (detalle.linea[j].informacion_adicional != null)
                        {
                            d.linea[j].informacion_adicional = new FeaEntidades.InterFacturas.lineaInformacion_adicional[detalle.linea[j].informacion_adicional.Length];
                            for (int k = 0; k < d.linea[j].informacion_adicional.Length; k++)
                            {
                                d.linea[j].informacion_adicional[k] = new FeaEntidades.InterFacturas.lineaInformacion_adicional();
                                d.linea[j].informacion_adicional[k].tipo = detalle.linea[j].informacion_adicional[k].tipo;
                                d.linea[j].informacion_adicional[k].valor = detalle.linea[j].informacion_adicional[k].valor;
                            }
                        }
                        d.linea[j].indicacion_exento_gravado = detalle.linea[j].indicacion_exento_gravado;
                        d.linea[j].numeroLinea = detalle.linea[j].numeroLinea;
                        d.linea[j].precio_unitario = detalle.linea[j].precio_unitario;
                        d.linea[j].precio_unitarioSpecified = detalle.linea[j].precio_unitarioSpecified;
                        d.linea[j].unidad = detalle.linea[j].unidad;
                    }
                    else
                    {
                        break;
                    }
                }
                cIBK.detalle = d;

                //Info Extensiones
                cIBK.extensiones = new FeaEntidades.InterFacturas.extensiones();
                cIBK.extensionesSpecified = false;
                if (lcIBK.comprobante[i].extensiones != null)
                {
                    cIBK.extensiones = new FeaEntidades.InterFacturas.extensiones();
                    cIBK.extensionesSpecified = true;
                    if (lcIBK.comprobante[i].extensiones.extensiones_camara_facturas != null)
                    {
                        cIBK.extensiones.extensiones_camara_facturasSpecified = true;
                        cIBK.extensiones.extensiones_camara_facturas = new FeaEntidades.InterFacturas.extensionesExtensiones_camara_facturas();
                        cIBK.extensiones.extensiones_camara_facturas.clave_de_vinculacion = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion;
                        cIBK.extensiones.extensiones_camara_facturas.id_idioma = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.id_idioma;
                        cIBK.extensiones.extensiones_camara_facturas.id_template = lcIBK.comprobante[i].extensiones.extensiones_camara_facturas.id_template;
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales != null)
                    {
                        if (!lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales.Equals(string.Empty))
                        {
                            string aux = RN.Funciones.HexToString(lcIBK.comprobante[i].extensiones.extensiones_datos_comerciales.ToString());
                            cIBK.extensiones.extensiones_datos_comerciales = aux;
                        }
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_datos_marketing != null)
                    {
                        if (!lcIBK.comprobante[i].extensiones.extensiones_datos_marketing.Equals(string.Empty))
                        {
                            string aux = RN.Funciones.HexToString(lcIBK.comprobante[i].extensiones.extensiones_datos_marketing.ToString());
                            cIBK.extensiones.extensiones_datos_marketing = aux;
                        }
                    }
                    if (lcIBK.comprobante[i].extensiones.extensiones_destinatarios != null)
                    {
                        cIBK.extensiones.extensiones_destinatarios = new FeaEntidades.InterFacturas.extensionesExtensiones_destinatarios();
                        cIBK.extensiones.extensiones_destinatarios.email = lcIBK.comprobante[i].extensiones.extensiones_destinatarios.email;
                    }
                }

                cIBK.resumen = new FeaEntidades.InterFacturas.resumen();
                cIBK.resumen.cant_alicuotas_iva = lcIBK.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lcIBK.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lcIBK.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[0];

                cIBK.resumen.cant_alicuotas_iva = lcIBK.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lcIBK.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lcIBK.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.importe_operaciones_exentas = lcIBK.comprobante[i].resumen.importe_operaciones_exentas;
                cIBK.resumen.importe_total_concepto_no_gravado = lcIBK.comprobante[i].resumen.importe_total_concepto_no_gravado;
                cIBK.resumen.importe_total_factura = lcIBK.comprobante[i].resumen.importe_total_factura;
                cIBK.resumen.importe_total_impuestos_internos = lcIBK.comprobante[i].resumen.importe_total_impuestos_internos;
                cIBK.resumen.importe_total_impuestos_internosSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_internosSpecified;
                cIBK.resumen.importe_total_impuestos_municipales = lcIBK.comprobante[i].resumen.importe_total_impuestos_municipales;
                cIBK.resumen.importe_total_impuestos_municipalesSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_municipalesSpecified;
                cIBK.resumen.importe_total_impuestos_nacionales = lcIBK.comprobante[i].resumen.importe_total_impuestos_nacionales;
                cIBK.resumen.importe_total_impuestos_nacionalesSpecified = lcIBK.comprobante[i].resumen.importe_total_impuestos_nacionalesSpecified;
                cIBK.resumen.importe_total_ingresos_brutos = lcIBK.comprobante[i].resumen.importe_total_ingresos_brutos;
                cIBK.resumen.importe_total_ingresos_brutosSpecified = lcIBK.comprobante[i].resumen.importe_total_ingresos_brutosSpecified;
                cIBK.resumen.importe_total_neto_gravado = lcIBK.comprobante[i].resumen.importe_total_neto_gravado;

                if (lcIBK.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    cIBK.resumen.importes_moneda_origen = new FeaEntidades.InterFacturas.resumenImportes_moneda_origen();
                    cIBK.resumen.importes_moneda_origen.importe_operaciones_exentas = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_operaciones_exentas;
                    cIBK.resumen.importes_moneda_origen.importe_total_concepto_no_gravado = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
                    cIBK.resumen.importes_moneda_origen.importe_total_factura = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_factura;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internos = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internos;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipales = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionales = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutos = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_neto_gravado = lcIBK.comprobante[i].resumen.importes_moneda_origen.importe_total_neto_gravado;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq = lcIBK.comprobante[i].resumen.importes_moneda_origen.impuesto_liq;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq_rni = lcIBK.comprobante[i].resumen.importes_moneda_origen.impuesto_liq_rni;
                }

                cIBK.resumen.impuesto_liq = lcIBK.comprobante[i].resumen.impuesto_liq;
                cIBK.resumen.impuesto_liq_rni = lcIBK.comprobante[i].resumen.impuesto_liq_rni;

                if (lcIBK.comprobante[i].resumen.descuentos != null)
                {
                    cIBK.resumen.descuentos = new FeaEntidades.InterFacturas.resumenDescuentos[lcIBK.comprobante[i].resumen.descuentos.Length];
                    for (int l = 0; l < lcIBK.comprobante[i].resumen.descuentos.Length; l++)
                    {
                        if (lcIBK.comprobante[i].resumen.descuentos[l] != null)
                        {
                            cIBK.resumen.descuentos[l] = new FeaEntidades.InterFacturas.resumenDescuentos();
                            cIBK.resumen.descuentos[l].alicuota_iva_descuento = lcIBK.comprobante[i].resumen.descuentos[l].alicuota_iva_descuento;
                            cIBK.resumen.descuentos[l].alicuota_iva_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].alicuota_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].descripcion_descuento = lcIBK.comprobante[i].resumen.descuentos[l].descripcion_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origen = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origenSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuento = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origen = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].importe_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].porcentaje_descuento = lcIBK.comprobante[i].resumen.descuentos[l].porcentaje_descuento;
                            cIBK.resumen.descuentos[l].porcentaje_descuentoSpecified = lcIBK.comprobante[i].resumen.descuentos[l].porcentaje_descuentoSpecified;
                            cIBK.resumen.descuentos[l].indicacion_exento_gravado_descuento = lcIBK.comprobante[i].resumen.descuentos[l].indicacion_exento_gravado_descuento;
                        }
                    }
                }

                if (lcIBK.comprobante[i].resumen.impuestos != null)
                {
                    cIBK.resumen.impuestos = new FeaEntidades.InterFacturas.resumenImpuestos[lcIBK.comprobante[i].resumen.impuestos.Length];
                    for (int l = 0; l < lcIBK.comprobante[i].resumen.impuestos.Length; l++)
                    {
                        if (lcIBK.comprobante[i].resumen.impuestos[l] != null)
                        {
                            cIBK.resumen.impuestos[l] = new FeaEntidades.InterFacturas.resumenImpuestos();
                            cIBK.resumen.impuestos[l].codigo_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].codigo_impuesto;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccion = lcIBK.comprobante[i].resumen.impuestos[l].codigo_jurisdiccion;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccionSpecified = lcIBK.comprobante[i].resumen.impuestos[l].codigo_jurisdiccionSpecified;
                            cIBK.resumen.impuestos[l].descripcion = lcIBK.comprobante[i].resumen.impuestos[l].descripcion;
                            cIBK.resumen.impuestos[l].importe_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origen = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origen;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origenSpecified = lcIBK.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origenSpecified;
                            cIBK.resumen.impuestos[l].jurisdiccion_municipal = lcIBK.comprobante[i].resumen.impuestos[l].jurisdiccion_municipal;
                            cIBK.resumen.impuestos[l].porcentaje_impuesto = lcIBK.comprobante[i].resumen.impuestos[l].porcentaje_impuesto;
                            cIBK.resumen.impuestos[l].porcentaje_impuestoSpecified = lcIBK.comprobante[i].resumen.impuestos[l].porcentaje_impuestoSpecified;
                        }
                    }
                }
                cIBK.resumen.observaciones = lcIBK.comprobante[i].resumen.observaciones;
                cIBK.resumen.tipo_de_cambio = lcIBK.comprobante[i].resumen.tipo_de_cambio;

                lcFEA.comprobante[i] = cIBK;
            }
            return lcFEA;
        }
        public static IBK.lote_comprobantes Fea2Ibk(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            IBK.lote_comprobantes lcIBK = new IBK.lote_comprobantes();

            lcIBK.cabecera_lote = new IBK.cabecera_lote();
            lcIBK.cabecera_lote.cantidad_reg = lc.cabecera_lote.cantidad_reg;
            lcIBK.cabecera_lote.cod_interno_canal = lc.cabecera_lote.cod_interno_canal;
            lcIBK.cabecera_lote.cuit_canal = lc.cabecera_lote.cuit_canal;
            lcIBK.cabecera_lote.cuit_vendedor = lc.cabecera_lote.cuit_vendedor;
            lcIBK.cabecera_lote.fecha_envio_lote = lc.cabecera_lote.fecha_envio_lote;
            lcIBK.cabecera_lote.id_lote = lc.cabecera_lote.id_lote;
            lcIBK.cabecera_lote.motivo = lc.cabecera_lote.motivo;
            lcIBK.cabecera_lote.presta_serv = lc.cabecera_lote.presta_serv;
            lcIBK.cabecera_lote.presta_servSpecified = lc.cabecera_lote.presta_servSpecified;
            lcIBK.cabecera_lote.punto_de_venta = lc.cabecera_lote.punto_de_venta;
            lcIBK.cabecera_lote.resultado = lc.cabecera_lote.resultado;
            //gestionar_afip
            if (lc.cabecera_lote.gestionar_afip == "N")
            {
                lcIBK.cabecera_lote.gestionar_afip = IBK.cabecera_loteGestionar_afip.N;
            }
            else if (lc.cabecera_lote.gestionar_afip == "S")
            {
                lcIBK.cabecera_lote.gestionar_afip = IBK.cabecera_loteGestionar_afip.S;
            }
            lcIBK.cabecera_lote.gestionar_afipSpecified = lc.cabecera_lote.gestionar_afipSpecified;
            //fin gestionar_afip
            lcIBK.comprobante = new IBK.comprobante[lc.comprobante.Length];

            for (int i = 0; i < lc.comprobante.Length; i++)
            {
                if (lc.comprobante[i] == null)
                {
                    break;
                }
                IBK.comprobante cIBK = new IBK.comprobante();

                cIBK.cabecera = new IBK.cabecera();
                
                //Comprador
                cIBK.cabecera.informacion_comprador = new IBK.informacion_comprador();
                cIBK.cabecera.informacion_comprador.codigo_doc_identificatorio = lc.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.codigo_interno = lc.comprobante[i].cabecera.informacion_comprador.codigo_interno;
                if (lc.comprobante[i].cabecera.informacion_comprador.codigo_interno != null)
                {
                    cIBK.cabecera.informacion_comprador.codigo_interno = lc.comprobante[i].cabecera.informacion_comprador.codigo_interno.Trim();
                }
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutos = lc.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = lc.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_comprador.condicion_IVA = lc.comprobante[i].cabecera.informacion_comprador.condicion_IVA;
                cIBK.cabecera.informacion_comprador.condicion_IVASpecified = lc.comprobante[i].cabecera.informacion_comprador.condicion_IVASpecified;
                cIBK.cabecera.informacion_comprador.contacto = lc.comprobante[i].cabecera.informacion_comprador.contacto;
                if (lc.comprobante[i].cabecera.informacion_comprador.contacto != null)
                {
                    cIBK.cabecera.informacion_comprador.contacto = lc.comprobante[i].cabecera.informacion_comprador.contacto.Trim();
                }
                cIBK.cabecera.informacion_comprador.cp = lc.comprobante[i].cabecera.informacion_comprador.cp;
                if (lc.comprobante[i].cabecera.informacion_comprador.cp != null)
                {
                    cIBK.cabecera.informacion_comprador.cp = lc.comprobante[i].cabecera.informacion_comprador.cp.Trim();
                }
                cIBK.cabecera.informacion_comprador.denominacion = lc.comprobante[i].cabecera.informacion_comprador.denominacion;
                if (lc.comprobante[i].cabecera.informacion_comprador.denominacion != null)
                {
                    cIBK.cabecera.informacion_comprador.denominacion = lc.comprobante[i].cabecera.informacion_comprador.denominacion.Trim();
                }
                cIBK.cabecera.informacion_comprador.domicilio_calle = lc.comprobante[i].cabecera.informacion_comprador.domicilio_calle;
                if (lc.comprobante[i].cabecera.informacion_comprador.domicilio_calle != null)
                {
                    cIBK.cabecera.informacion_comprador.domicilio_calle = lc.comprobante[i].cabecera.informacion_comprador.domicilio_calle.Trim();
                }
                cIBK.cabecera.informacion_comprador.domicilio_depto = lc.comprobante[i].cabecera.informacion_comprador.domicilio_depto;
                if (lc.comprobante[i].cabecera.informacion_comprador.domicilio_depto != null)
                {
                    cIBK.cabecera.informacion_comprador.domicilio_depto = lc.comprobante[i].cabecera.informacion_comprador.domicilio_depto.Trim();
                }
                cIBK.cabecera.informacion_comprador.domicilio_manzana = lc.comprobante[i].cabecera.informacion_comprador.domicilio_manzana;
                if (lc.comprobante[i].cabecera.informacion_comprador.domicilio_manzana != null)
                {
                    cIBK.cabecera.informacion_comprador.domicilio_manzana = lc.comprobante[i].cabecera.informacion_comprador.domicilio_manzana.Trim();
                }
                cIBK.cabecera.informacion_comprador.domicilio_numero = lc.comprobante[i].cabecera.informacion_comprador.domicilio_numero;
                if (lc.comprobante[i].cabecera.informacion_comprador.domicilio_numero != null)
                {
                    cIBK.cabecera.informacion_comprador.domicilio_numero = lc.comprobante[i].cabecera.informacion_comprador.domicilio_numero.Trim();
                }
                cIBK.cabecera.informacion_comprador.domicilio_piso = lc.comprobante[i].cabecera.informacion_comprador.domicilio_piso;
                if (lc.comprobante[i].cabecera.informacion_comprador.domicilio_piso != null)
                {
                    cIBK.cabecera.informacion_comprador.domicilio_piso = lc.comprobante[i].cabecera.informacion_comprador.domicilio_piso.Trim();
                }
                cIBK.cabecera.informacion_comprador.domicilio_sector = lc.comprobante[i].cabecera.informacion_comprador.domicilio_sector;
                if (lc.comprobante[i].cabecera.informacion_comprador.domicilio_sector != null)
                {
                    cIBK.cabecera.informacion_comprador.domicilio_sector = lc.comprobante[i].cabecera.informacion_comprador.domicilio_sector.Trim();
                }
                cIBK.cabecera.informacion_comprador.domicilio_torre = lc.comprobante[i].cabecera.informacion_comprador.domicilio_torre;
                if (lc.comprobante[i].cabecera.informacion_comprador.domicilio_torre != null)
                {
                    cIBK.cabecera.informacion_comprador.domicilio_torre = lc.comprobante[i].cabecera.informacion_comprador.domicilio_torre.Trim();
                }
                cIBK.cabecera.informacion_comprador.email = lc.comprobante[i].cabecera.informacion_comprador.email;
                if (lc.comprobante[i].cabecera.informacion_comprador.email != null)
                {
                    cIBK.cabecera.informacion_comprador.email = lc.comprobante[i].cabecera.informacion_comprador.email.Trim();
                }
                cIBK.cabecera.informacion_comprador.GLN = lc.comprobante[i].cabecera.informacion_comprador.GLN;
                cIBK.cabecera.informacion_comprador.GLNSpecified = lc.comprobante[i].cabecera.informacion_comprador.GLNSpecified;
                cIBK.cabecera.informacion_comprador.inicio_de_actividades = lc.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades;
                if (lc.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades != null)
                {
                    cIBK.cabecera.informacion_comprador.inicio_de_actividades = lc.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades.Trim();
                }
                cIBK.cabecera.informacion_comprador.localidad = lc.comprobante[i].cabecera.informacion_comprador.localidad;
                if (lc.comprobante[i].cabecera.informacion_comprador.localidad != null)
                {
                    cIBK.cabecera.informacion_comprador.localidad = lc.comprobante[i].cabecera.informacion_comprador.localidad.Trim();
                }
                cIBK.cabecera.informacion_comprador.nro_doc_identificatorio = lc.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.nro_ingresos_brutos = lc.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos;
                if (lc.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos != null)
                {
                    cIBK.cabecera.informacion_comprador.nro_ingresos_brutos = lc.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos.Trim();
                }
                cIBK.cabecera.informacion_comprador.provincia = lc.comprobante[i].cabecera.informacion_comprador.provincia;
                if (lc.comprobante[i].cabecera.informacion_comprador.provincia != null)
                {
                    cIBK.cabecera.informacion_comprador.provincia = lc.comprobante[i].cabecera.informacion_comprador.provincia.Trim();
                }
                cIBK.cabecera.informacion_comprador.telefono = lc.comprobante[i].cabecera.informacion_comprador.telefono;
                if (lc.comprobante[i].cabecera.informacion_comprador.telefono != null)
                {
                    cIBK.cabecera.informacion_comprador.telefono = lc.comprobante[i].cabecera.informacion_comprador.telefono.Trim();
                }
                
                //Info Comprobante
                cIBK.cabecera.informacion_comprobante = new IBK.informacion_comprobante();
                cIBK.cabecera.informacion_comprobante.cae = lc.comprobante[i].cabecera.informacion_comprobante.cae;
                cIBK.cabecera.informacion_comprobante.codigo_operacion = lc.comprobante[i].cabecera.informacion_comprobante.codigo_operacion;
                cIBK.cabecera.informacion_comprobante.condicion_de_pago = lc.comprobante[i].cabecera.informacion_comprobante.condicion_de_pago;
                //cIBK.cabecera.informacion_comprobante.condicion_de_pagoSpecified = lc.comprobante[i].cabecera.informacion_comprobante.condicion_de_pagoSpecified;
                cIBK.cabecera.informacion_comprobante.es_detalle_encriptado = lc.comprobante[i].cabecera.informacion_comprobante.es_detalle_encriptado;
                cIBK.cabecera.informacion_comprobante.fecha_emision = lc.comprobante[i].cabecera.informacion_comprobante.fecha_emision;
                cIBK.cabecera.informacion_comprobante.fecha_obtencion_cae = lc.comprobante[i].cabecera.informacion_comprobante.fecha_obtencion_cae;
                cIBK.cabecera.informacion_comprobante.fecha_serv_desde = lc.comprobante[i].cabecera.informacion_comprobante.fecha_serv_desde;
                cIBK.cabecera.informacion_comprobante.fecha_serv_hasta = lc.comprobante[i].cabecera.informacion_comprobante.fecha_serv_hasta;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento = lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento;
                cIBK.cabecera.informacion_comprobante.fecha_vencimiento_cae = lc.comprobante[i].cabecera.informacion_comprobante.fecha_vencimiento_cae;
                cIBK.cabecera.informacion_comprobante.iva_computable = lc.comprobante[i].cabecera.informacion_comprobante.iva_computable;
                cIBK.cabecera.informacion_comprobante.motivo = lc.comprobante[i].cabecera.informacion_comprobante.motivo;
                cIBK.cabecera.informacion_comprobante.numero_comprobante = lc.comprobante[i].cabecera.informacion_comprobante.numero_comprobante;
                cIBK.cabecera.informacion_comprobante.punto_de_venta = lc.comprobante[i].cabecera.informacion_comprobante.punto_de_venta;
                cIBK.cabecera.informacion_comprobante.resultado = lc.comprobante[i].cabecera.informacion_comprobante.resultado;
                cIBK.cabecera.informacion_comprobante.tipo_de_comprobante = lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;
                cIBK.cabecera.informacion_comprobante.codigo_concepto = lc.comprobante[i].cabecera.informacion_comprobante.codigo_concepto;
                cIBK.cabecera.informacion_comprobante.codigo_conceptoSpecified = lc.comprobante[i].cabecera.informacion_comprobante.codigo_conceptoSpecified;

                //Info Vendedor
                cIBK.cabecera.informacion_vendedor = new IBK.informacion_vendedor();
                cIBK.cabecera.informacion_vendedor.codigo_interno = lc.comprobante[i].cabecera.informacion_vendedor.codigo_interno;
                if (lc.comprobante[i].cabecera.informacion_vendedor.codigo_interno != null)
                {
                    cIBK.cabecera.informacion_vendedor.codigo_interno = lc.comprobante[i].cabecera.informacion_vendedor.codigo_interno.Trim();
                }
                cIBK.cabecera.informacion_vendedor.razon_social = lc.comprobante[i].cabecera.informacion_vendedor.razon_social;
                if (lc.comprobante[i].cabecera.informacion_vendedor.razon_social != null)
                {
                    cIBK.cabecera.informacion_vendedor.razon_social = lc.comprobante[i].cabecera.informacion_vendedor.razon_social.Trim();
                }

                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutos = lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_vendedor.condicion_IVA = lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVA;
                cIBK.cabecera.informacion_vendedor.condicion_IVASpecified = lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVASpecified;
                cIBK.cabecera.informacion_vendedor.contacto = lc.comprobante[i].cabecera.informacion_vendedor.contacto;
                if (lc.comprobante[i].cabecera.informacion_vendedor.contacto != null)
                {
                    cIBK.cabecera.informacion_vendedor.contacto = lc.comprobante[i].cabecera.informacion_vendedor.contacto.Trim();
                }
                cIBK.cabecera.informacion_vendedor.cp = lc.comprobante[i].cabecera.informacion_vendedor.cp;
                if (lc.comprobante[i].cabecera.informacion_vendedor.cp != null)
                {
                    cIBK.cabecera.informacion_vendedor.cp = lc.comprobante[i].cabecera.informacion_vendedor.cp.Trim();
                }
                cIBK.cabecera.informacion_vendedor.cuit = lc.comprobante[i].cabecera.informacion_vendedor.cuit;
                cIBK.cabecera.informacion_vendedor.domicilio_calle = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_calle;
                if (lc.comprobante[i].cabecera.informacion_vendedor.domicilio_calle != null)
                {
                    cIBK.cabecera.informacion_vendedor.domicilio_calle = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_calle.Trim();
                }
                cIBK.cabecera.informacion_vendedor.domicilio_depto = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_depto;
                if (lc.comprobante[i].cabecera.informacion_vendedor.domicilio_depto != null)
                {
                    cIBK.cabecera.informacion_vendedor.domicilio_depto = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_depto.Trim();
                }
                cIBK.cabecera.informacion_vendedor.domicilio_manzana = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana;
                if (lc.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana != null)
                {
                    cIBK.cabecera.informacion_vendedor.domicilio_manzana = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana.Trim();
                }
                cIBK.cabecera.informacion_vendedor.domicilio_numero = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_numero;
                if (lc.comprobante[i].cabecera.informacion_vendedor.domicilio_numero != null)
                {
                    cIBK.cabecera.informacion_vendedor.domicilio_numero = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_numero.Trim();
                }
                cIBK.cabecera.informacion_vendedor.domicilio_piso = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_piso;
                if (lc.comprobante[i].cabecera.informacion_vendedor.domicilio_piso != null)
                {
                    cIBK.cabecera.informacion_vendedor.domicilio_piso = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_piso.Trim();
                }
                cIBK.cabecera.informacion_vendedor.domicilio_sector = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_sector;
                if (lc.comprobante[i].cabecera.informacion_vendedor.domicilio_sector != null)
                {
                    cIBK.cabecera.informacion_vendedor.domicilio_sector = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_sector.Trim();
                }
                cIBK.cabecera.informacion_vendedor.domicilio_torre = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_torre;
                if (lc.comprobante[i].cabecera.informacion_vendedor.domicilio_torre != null)
                {
                    cIBK.cabecera.informacion_vendedor.domicilio_torre = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_torre.Trim();
                }
                cIBK.cabecera.informacion_vendedor.email = lc.comprobante[i].cabecera.informacion_vendedor.email;
                if (lc.comprobante[i].cabecera.informacion_vendedor.email != null)
                {
                    cIBK.cabecera.informacion_vendedor.email = lc.comprobante[i].cabecera.informacion_vendedor.email.Trim();
                }
                cIBK.cabecera.informacion_vendedor.GLN = lc.comprobante[i].cabecera.informacion_vendedor.GLN;
                cIBK.cabecera.informacion_vendedor.GLNSpecified = lc.comprobante[i].cabecera.informacion_vendedor.GLNSpecified;
                cIBK.cabecera.informacion_vendedor.inicio_de_actividades = lc.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades;
                if (lc.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades != null)
                {
                    cIBK.cabecera.informacion_vendedor.inicio_de_actividades = lc.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades.Trim();
                }
                cIBK.cabecera.informacion_vendedor.localidad = lc.comprobante[i].cabecera.informacion_vendedor.localidad;
                if (lc.comprobante[i].cabecera.informacion_vendedor.localidad != null)
                {
                    cIBK.cabecera.informacion_vendedor.localidad = lc.comprobante[i].cabecera.informacion_vendedor.localidad.Trim();
                }
                cIBK.cabecera.informacion_vendedor.nro_ingresos_brutos = lc.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos;
                if (lc.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos != null)
                {
                    cIBK.cabecera.informacion_vendedor.nro_ingresos_brutos = lc.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos.Trim();
                }
                cIBK.cabecera.informacion_vendedor.provincia = lc.comprobante[i].cabecera.informacion_vendedor.provincia;
                if (lc.comprobante[i].cabecera.informacion_vendedor.provincia != null)
                {
                    cIBK.cabecera.informacion_vendedor.provincia = lc.comprobante[i].cabecera.informacion_vendedor.provincia.Trim();
                }
                cIBK.cabecera.informacion_vendedor.telefono = lc.comprobante[i].cabecera.informacion_vendedor.telefono;
                if (lc.comprobante[i].cabecera.informacion_vendedor.telefono != null)
                {
                    cIBK.cabecera.informacion_vendedor.telefono = lc.comprobante[i].cabecera.informacion_vendedor.telefono.Trim();
                }
                
                //Info Comprobantes de Referencia
                if (lc.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    cIBK.cabecera.informacion_comprobante.referencias = new IBK.informacion_comprobanteReferencias[lc.comprobante[i].cabecera.informacion_comprobante.referencias.Length];
                    for (int j = 0; j < lc.comprobante[i].cabecera.informacion_comprobante.referencias.Length; j++)
                    {
                        if (lc.comprobante[i].cabecera.informacion_comprobante.referencias[j] != null)
                        {
                            cIBK.cabecera.informacion_comprobante.referencias[j] = new RN.IBK.informacion_comprobanteReferencias();
                            if (lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip != null)
                            {
                                if (lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip.Trim().ToUpper() == "S")
                                {
                                    cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip = RN.IBK.informacion_comprobanteReferenciasTipo_comprobante_afip.S;
                                    cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afipSpecified = true;
                                }
                                else if (lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip.Trim().ToUpper() == "N")
                                {
                                    cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip = RN.IBK.informacion_comprobanteReferenciasTipo_comprobante_afip.N;
                                    cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afipSpecified = true;
                                }
                                else
                                {
                                    cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afipSpecified = false;
                                }
                            }
                            else
                            {
                                cIBK.cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afipSpecified = false;
                            }
                            cIBK.cabecera.informacion_comprobante.referencias[j].codigo_de_referencia = lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].codigo_de_referencia;
                            cIBK.cabecera.informacion_comprobante.referencias[j].dato_de_referencia = lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].dato_de_referencia.Trim();
                        }
                    }
                }

                //Info Informacion Adicional Comprobante
                if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante = new IBK.informacion_comprobanteInformacion_adicional_comprobante[lc.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante.Length];

                    for (int j = 0; j < lc.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante.Length; j++)
                    {
                        if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j] != null)
                        {
                            cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j] = new IBK.informacion_comprobanteInformacion_adicional_comprobante();
                            cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j].tipo = lc.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j].tipo;
                            cIBK.cabecera.informacion_comprobante.informacion_adicional_comprobante[j].valor = lc.comprobante[i].cabecera.informacion_comprobante.informacion_adicional_comprobante[j].valor;
                        }
                    }
                }

                //Info Exportación
                if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion != null)
                {
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion = new IBK.informacion_comprobanteInformacion_exportacion();
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion;
                    cIBK.cabecera.informacion_comprobante.informacion_exportacion.id_impositivo = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.id_impositivo;
                    if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms != null && lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms != "")
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.incoterms = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.incoterms;
                    }
                    if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms != null && lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms != "")
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms;
                    }
                    if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != null)
                    {
                        if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente != "")
                        {
                            cIBK.cabecera.informacion_comprobante.informacion_exportacion.permiso_existente = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente.Trim();
                        }
                        else
                        {
                            cIBK.cabecera.informacion_comprobante.informacion_exportacion.permiso_existente = null;
                        }
                    }
                    if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos != null)
                    {
                        cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos = new IBK.informacion_comprobanteInformacion_exportacionPermisos[lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length];
                        for (int j = 0; j < lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length; j++)
                        {
                            if (lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j] != null)
                            {
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j] = new RN.IBK.informacion_comprobanteInformacion_exportacionPermisos();
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].id_permiso;
                                cIBK.cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia = lc.comprobante[i].cabecera.informacion_comprobante.informacion_exportacion.permisos[j].destino_mercaderia;
                            }
                        }
                    }
                }

                //Detalle y Lineas
                IBK.detalle d = new IBK.detalle();
                d.linea = new IBK.linea[lc.comprobante[i].detalle.linea.Length];
                d.comentarios = lc.comprobante[i].detalle.comentarios;
                for (int j = 0; j < lc.comprobante[i].detalle.linea.Length; j++)
                {
                    if (lc.comprobante[i].detalle.linea[j] != null)
                    {
                        d.linea[j] = new IBK.linea();
                        d.linea[j].alicuota_iva = lc.comprobante[i].detalle.linea[j].alicuota_iva;
                        d.linea[j].alicuota_ivaSpecified = lc.comprobante[i].detalle.linea[j].alicuota_ivaSpecified;
                        d.linea[j].cantidad = lc.comprobante[i].detalle.linea[j].cantidad;
                        d.linea[j].cantidadSpecified = lc.comprobante[i].detalle.linea[j].cantidadSpecified;
                        d.linea[j].codigo_producto_comprador = lc.comprobante[i].detalle.linea[j].codigo_producto_comprador;
                        d.linea[j].codigo_producto_vendedor = lc.comprobante[i].detalle.linea[j].codigo_producto_vendedor;
                        if (lc.comprobante[i].detalle.linea[j].descripcion != "" && lc.comprobante[i].detalle.linea[j].descripcion.Substring(0, 1) != "%")
                        {
                            string aux = RN.Funciones.ConvertToHex(lc.comprobante[i].detalle.linea[j].descripcion);
                            d.linea[j].descripcion = aux;
                        }
                        else
                        {
                            d.linea[j].descripcion = lc.comprobante[i].detalle.linea[j].descripcion;
                        }

                        d.linea[j].GTIN = lc.comprobante[i].detalle.linea[j].GTIN;
                        d.linea[j].GTINSpecified = lc.comprobante[i].detalle.linea[j].GTINSpecified;
                        d.linea[j].importe_iva = lc.comprobante[i].detalle.linea[j].importe_iva;
                        d.linea[j].importe_ivaSpecified = lc.comprobante[i].detalle.linea[j].importe_ivaSpecified;
                        d.linea[j].importe_total_articulo = lc.comprobante[i].detalle.linea[j].importe_total_articulo;
                        d.linea[j].importe_total_descuentos = lc.comprobante[i].detalle.linea[j].importe_total_descuentos;
                        d.linea[j].importe_total_descuentosSpecified = lc.comprobante[i].detalle.linea[j].importe_total_descuentosSpecified;
                        d.linea[j].importe_total_impuestos = lc.comprobante[i].detalle.linea[j].importe_total_impuestos;
                        d.linea[j].importe_total_impuestosSpecified = lc.comprobante[i].detalle.linea[j].importe_total_impuestosSpecified;
                        
                        if (lc.comprobante[i].detalle.linea[j].importes_moneda_origen != null)
                        {
                            d.linea[j].importes_moneda_origen = new IBK.lineaImportes_moneda_origen();
                            d.linea[j].importes_moneda_origen.importe_iva = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_iva;
                            d.linea[j].importes_moneda_origen.importe_ivaSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_ivaSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_articulo = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_articulo;
                            d.linea[j].importes_moneda_origen.importe_total_articuloSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_articuloSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_descuentos = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_descuentos;
                            d.linea[j].importes_moneda_origen.importe_total_descuentosSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_descuentosSpecified;
                            d.linea[j].importes_moneda_origen.importe_total_impuestos = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_impuestos;
                            d.linea[j].importes_moneda_origen.importe_total_impuestosSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.importe_total_impuestosSpecified;
                            d.linea[j].importes_moneda_origen.precio_unitario = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.precio_unitario;
                            d.linea[j].importes_moneda_origen.precio_unitarioSpecified = lc.comprobante[i].detalle.linea[j].importes_moneda_origen.precio_unitarioSpecified;
                        }

                        if (lc.comprobante[i].detalle.linea[j].impuestos != null)
                        {
                            d.linea[j].impuestos = new IBK.lineaImpuestos[lc.comprobante[i].detalle.linea[j].impuestos.Length];
                            for (int k = 0; k < d.linea[j].impuestos.Length; k++)
                            {
                                d.linea[j].impuestos[k] = new IBK.lineaImpuestos();
                                d.linea[j].impuestos[k].codigo_impuesto = lc.comprobante[i].detalle.linea[j].impuestos[k].codigo_impuesto;
                                d.linea[j].impuestos[k].descripcion_impuesto = lc.comprobante[i].detalle.linea[j].impuestos[k].descripcion_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto = lc.comprobante[i].detalle.linea[j].impuestos[k].importe_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origen = lc.comprobante[i].detalle.linea[j].impuestos[k].importe_impuesto_moneda_origen;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified = lc.comprobante[i].detalle.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified;
                                d.linea[j].impuestos[k].porcentaje_impuesto = lc.comprobante[i].detalle.linea[j].impuestos[k].porcentaje_impuesto;
                                d.linea[j].impuestos[k].porcentaje_impuestoSpecified = lc.comprobante[i].detalle.linea[j].impuestos[k].porcentaje_impuestoSpecified;
                            }
                        }
                        if (lc.comprobante[i].detalle.linea[j].lineaDescuentos != null)
                        {
                            d.linea[j].descuentos = new IBK.lineaDescuentos[lc.comprobante[i].detalle.linea[j].lineaDescuentos.Length];
                            for (int k = 0; k < d.linea[j].descuentos.Length; k++)
                            {
                                if (lc.comprobante[i].detalle.linea[j].lineaDescuentos[k] != null)
                                {
                                    d.linea[j].descuentos[k] = new IBK.lineaDescuentos();
                                    d.linea[j].descuentos[k].descripcion_descuento = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].descripcion_descuento;
                                    d.linea[j].descuentos[k].importe_descuento = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].importe_descuento;
                                    d.linea[j].descuentos[k].importe_descuento_moneda_origen = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].importe_descuento_moneda_origen;
                                    d.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].importe_descuento_moneda_origenSpecified;
                                    d.linea[j].descuentos[k].porcentaje_descuento = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].porcentaje_descuento;
                                    d.linea[j].descuentos[k].porcentaje_descuentoSpecified = lc.comprobante[i].detalle.linea[j].lineaDescuentos[k].porcentaje_descuentoSpecified;
                                }
                            }
                        }
                        if (lc.comprobante[i].detalle.linea[j].informacion_adicional != null)
                        {
                            d.linea[j].informacion_adicional = new IBK.lineaInformacion_adicional[lc.comprobante[i].detalle.linea[j].informacion_adicional.Length];
                            for (int k = 0; k < d.linea[j].informacion_adicional.Length; k++)
                            {
                                if (lc.comprobante[i].detalle.linea[j].informacion_adicional[k] != null)
                                {
                                    d.linea[j].informacion_adicional[k] = new IBK.lineaInformacion_adicional();
                                    d.linea[j].informacion_adicional[k].tipo = lc.comprobante[i].detalle.linea[j].informacion_adicional[k].tipo;
                                    d.linea[j].informacion_adicional[k].valor = lc.comprobante[i].detalle.linea[j].informacion_adicional[k].valor;
                                }
                            }
                        }
                        d.linea[j].indicacion_exento_gravado = lc.comprobante[i].detalle.linea[j].indicacion_exento_gravado;
                        d.linea[j].numeroLinea = lc.comprobante[i].detalle.linea[j].numeroLinea;
                        d.linea[j].precio_unitario = lc.comprobante[i].detalle.linea[j].precio_unitario;
                        d.linea[j].precio_unitarioSpecified = lc.comprobante[i].detalle.linea[j].precio_unitarioSpecified;
                        d.linea[j].unidad = lc.comprobante[i].detalle.linea[j].unidad;
                    }
                    else
                    {
                        break;
                    }
                }
                cIBK.Item = d;
                
                //Info Extensiones
                if (lc.comprobante[i].extensiones != null)
                {
                    cIBK.extensiones = new IBK.extensiones();
                    if (lc.comprobante[i].extensiones.extensiones_camara_facturas != null)
                    {
                        cIBK.extensiones.extensiones_camara_facturas = new IBK.extensionesExtensiones_camara_facturas();
                        if (lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion != null)
                        {
                            cIBK.extensiones.extensiones_camara_facturas.clave_de_vinculacion = lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion.Trim();
                        }
                        if (lc.comprobante[i].extensiones.extensiones_camara_facturas.id_idioma != null)
                        {
                            cIBK.extensiones.extensiones_camara_facturas.id_idioma = lc.comprobante[i].extensiones.extensiones_camara_facturas.id_idioma.Trim();
                        }
                        if (lc.comprobante[i].extensiones.extensiones_camara_facturas.id_template != null)
                        {
                            cIBK.extensiones.extensiones_camara_facturas.id_template = lc.comprobante[i].extensiones.extensiones_camara_facturas.id_template.Trim();
                        }
                    }
                    if (lc.comprobante[i].extensiones.extensiones_datos_comerciales != null && lc.comprobante[i].extensiones.extensiones_datos_comerciales != "")
                    {
                        if (lc.comprobante[i].extensiones.extensiones_datos_comerciales.Substring(0, 1) != "%")
                        {
                            string aux = RN.Funciones.ConvertToHex(lc.comprobante[i].extensiones.extensiones_datos_comerciales.ToString());
                            cIBK.extensiones.extensiones_datos_comerciales = aux;
                        }
                        else
                        {
                            cIBK.extensiones.extensiones_datos_comerciales = lc.comprobante[i].extensiones.extensiones_datos_comerciales;
                        }
                    }
                    if (lc.comprobante[i].extensiones.extensiones_datos_marketing != null && lc.comprobante[i].extensiones.extensiones_datos_marketing != "")
                    {
                        if (lc.comprobante[i].extensiones.extensiones_datos_marketing.Substring(0, 1) != "%")
                        {
                            string aux = RN.Funciones.ConvertToHex(lc.comprobante[i].extensiones.extensiones_datos_marketing.ToString());
                            cIBK.extensiones.extensiones_datos_marketing = aux;
                        }
                        else
                        {
                            cIBK.extensiones.extensiones_datos_marketing = lc.comprobante[i].extensiones.extensiones_datos_marketing;
                        }
                    }
                    if (lc.comprobante[i].extensiones.extensiones_signatures != null && lc.comprobante[i].extensiones.extensiones_signatures != "")
                    {
                        cIBK.extensiones.extensiones_signatures = lc.comprobante[i].extensiones.extensiones_signatures;
                    }
                    if (lc.comprobante[i].extensiones.extensiones_destinatarios != null && lc.comprobante[i].extensiones.extensiones_destinatarios.email != "")
                    {
                        cIBK.extensiones.extensiones_destinatarios = new IBK.extensionesExtensiones_destinatarios();
                        cIBK.extensiones.extensiones_destinatarios.email = lc.comprobante[i].extensiones.extensiones_destinatarios.email.Trim();
                        //if (lc.comprobante[i].extensiones.extensiones_destinatarios.destinatario != null)
                        //{
                        //    for (int j = 0; j < lc.comprobante[i].extensiones.extensiones_destinatarios.destinatario.Length; j++)
                        //    {
                        //        cIBK.extensiones.extensiones_destinatarios.destinatario[j] = new CedWebRN.IBK.extensionesExtensiones_destinatariosDestinatario();
                        //        cIBK.extensiones.extensiones_destinatarios.destinatario[j].cuit = lc.comprobante[i].extensiones.extensiones_destinatarios.destinatario[j].cuit;
                        //    }
                        //}
                    }
                }

                cIBK.resumen = new IBK.resumen();
                cIBK.resumen.cant_alicuotas_iva = lc.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lc.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lc.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.descuentos = new IBK.resumenDescuentos[0];

                cIBK.resumen.cant_alicuotas_iva = lc.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lc.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lc.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.importe_operaciones_exentas = lc.comprobante[i].resumen.importe_operaciones_exentas;
                cIBK.resumen.importe_total_concepto_no_gravado = lc.comprobante[i].resumen.importe_total_concepto_no_gravado;
                cIBK.resumen.importe_total_factura = lc.comprobante[i].resumen.importe_total_factura;
                cIBK.resumen.importe_total_impuestos_internos = lc.comprobante[i].resumen.importe_total_impuestos_internos;
                cIBK.resumen.importe_total_impuestos_internosSpecified = lc.comprobante[i].resumen.importe_total_impuestos_internosSpecified;
                cIBK.resumen.importe_total_impuestos_municipales = lc.comprobante[i].resumen.importe_total_impuestos_municipales;
                cIBK.resumen.importe_total_impuestos_municipalesSpecified = lc.comprobante[i].resumen.importe_total_impuestos_municipalesSpecified;
                cIBK.resumen.importe_total_impuestos_nacionales = lc.comprobante[i].resumen.importe_total_impuestos_nacionales;
                cIBK.resumen.importe_total_impuestos_nacionalesSpecified = lc.comprobante[i].resumen.importe_total_impuestos_nacionalesSpecified;
                cIBK.resumen.importe_total_ingresos_brutos = lc.comprobante[i].resumen.importe_total_ingresos_brutos;
                cIBK.resumen.importe_total_ingresos_brutosSpecified = lc.comprobante[i].resumen.importe_total_ingresos_brutosSpecified;
                cIBK.resumen.importe_total_neto_gravado = lc.comprobante[i].resumen.importe_total_neto_gravado;

                if (lc.comprobante[i].resumen.importes_moneda_origen != null)
                {
                    cIBK.resumen.importes_moneda_origen = new IBK.resumenImportes_moneda_origen();
                    cIBK.resumen.importes_moneda_origen.importe_operaciones_exentas = lc.comprobante[i].resumen.importes_moneda_origen.importe_operaciones_exentas;
                    cIBK.resumen.importes_moneda_origen.importe_total_concepto_no_gravado = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;
                    cIBK.resumen.importes_moneda_origen.importe_total_factura = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_factura;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internos = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internos;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_internosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipales = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_municipalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionales = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionales;
                    cIBK.resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_impuestos_nacionalesSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutos = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutos;
                    cIBK.resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_ingresos_brutosSpecified;
                    cIBK.resumen.importes_moneda_origen.importe_total_neto_gravado = lc.comprobante[i].resumen.importes_moneda_origen.importe_total_neto_gravado;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq = lc.comprobante[i].resumen.importes_moneda_origen.impuesto_liq;
                    cIBK.resumen.importes_moneda_origen.impuesto_liq_rni = lc.comprobante[i].resumen.importes_moneda_origen.impuesto_liq_rni;
                }

                cIBK.resumen.impuesto_liq = lc.comprobante[i].resumen.impuesto_liq;
                cIBK.resumen.impuesto_liq_rni = lc.comprobante[i].resumen.impuesto_liq_rni;

                if (lc.comprobante[i].resumen.descuentos != null)
                {
                    cIBK.resumen.descuentos = new IBK.resumenDescuentos[lc.comprobante[i].resumen.descuentos.Length];
                    for (int l = 0; l < lc.comprobante[i].resumen.descuentos.Length; l++)
                    {
                        if (lc.comprobante[i].resumen.descuentos[l] != null)
                        {
                            cIBK.resumen.descuentos[l] = new IBK.resumenDescuentos();
                            cIBK.resumen.descuentos[l].alicuota_iva_descuento = lc.comprobante[i].resumen.descuentos[l].alicuota_iva_descuento;
                            cIBK.resumen.descuentos[l].alicuota_iva_descuentoSpecified = lc.comprobante[i].resumen.descuentos[l].alicuota_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].descripcion_descuento = lc.comprobante[i].resumen.descuentos[l].descripcion_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento = lc.comprobante[i].resumen.descuentos[l].importe_descuento;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origen = lc.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_descuento_moneda_origenSpecified = lc.comprobante[i].resumen.descuentos[l].importe_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuento = lc.comprobante[i].resumen.descuentos[l].importe_iva_descuento;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origen = lc.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origen;
                            cIBK.resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified = lc.comprobante[i].resumen.descuentos[l].importe_iva_descuento_moneda_origenSpecified;
                            cIBK.resumen.descuentos[l].importe_iva_descuentoSpecified = lc.comprobante[i].resumen.descuentos[l].importe_iva_descuentoSpecified;
                            cIBK.resumen.descuentos[l].porcentaje_descuento = lc.comprobante[i].resumen.descuentos[l].porcentaje_descuento;
                            cIBK.resumen.descuentos[l].porcentaje_descuentoSpecified = lc.comprobante[i].resumen.descuentos[l].porcentaje_descuentoSpecified;
                            cIBK.resumen.descuentos[l].indicacion_exento_gravado_descuento = lc.comprobante[i].resumen.descuentos[l].indicacion_exento_gravado_descuento;
                        }
                    }
                }

                if (lc.comprobante[i].resumen.impuestos != null)
                {
                    cIBK.resumen.impuestos = new IBK.resumenImpuestos[lc.comprobante[i].resumen.impuestos.Length];
                    for (int l = 0; l < lc.comprobante[i].resumen.impuestos.Length; l++)
                    {
                        if (lc.comprobante[i].resumen.impuestos[l] != null)
                        {
                            cIBK.resumen.impuestos[l] = new IBK.resumenImpuestos();
                            cIBK.resumen.impuestos[l].codigo_impuesto = lc.comprobante[i].resumen.impuestos[l].codigo_impuesto;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccion = lc.comprobante[i].resumen.impuestos[l].codigo_jurisdiccion;
                            cIBK.resumen.impuestos[l].codigo_jurisdiccionSpecified = lc.comprobante[i].resumen.impuestos[l].codigo_jurisdiccionSpecified;
                            cIBK.resumen.impuestos[l].descripcion = lc.comprobante[i].resumen.impuestos[l].descripcion;
                            cIBK.resumen.impuestos[l].importe_impuesto = lc.comprobante[i].resumen.impuestos[l].importe_impuesto;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origen = lc.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origen;
                            cIBK.resumen.impuestos[l].importe_impuesto_moneda_origenSpecified = lc.comprobante[i].resumen.impuestos[l].importe_impuesto_moneda_origenSpecified;
                            cIBK.resumen.impuestos[l].jurisdiccion_municipal = lc.comprobante[i].resumen.impuestos[l].jurisdiccion_municipal;
                            cIBK.resumen.impuestos[l].porcentaje_impuesto = lc.comprobante[i].resumen.impuestos[l].porcentaje_impuesto;
                            cIBK.resumen.impuestos[l].porcentaje_impuestoSpecified = lc.comprobante[i].resumen.impuestos[l].porcentaje_impuestoSpecified;
                        }
                    }
                }
                cIBK.resumen.observaciones = lc.comprobante[i].resumen.observaciones;
                cIBK.resumen.tipo_de_cambio = lc.comprobante[i].resumen.tipo_de_cambio;

                lcIBK.comprobante[i] = cIBK;
            }
            return lcIBK;
        }
        public static List<Entidades.Comprobante> ListaGlobalFiltrada(bool SoloVigentes, bool EsFechaAlta, string FechaDesde, string FechaHasta, Entidades.Persona Persona, string CUIT, string CUITRazonSocial, string NroComprobante, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            return db.ListaGlobalFiltrada(SoloVigentes, EsFechaAlta, FechaDesde, FechaHasta, Persona, CUIT, CUITRazonSocial, NroComprobante);
        }
        public static string ValidarIBK(string lc, string certificado)
        {
            RN.IBKValidate.ValidaFacturaWebService objIBK = new RN.IBKValidate.ValidaFacturaWebService();
            objIBK.Url = System.Configuration.ConfigurationManager.AppSettings["URLinterfacturasValidate"];
            if (System.Configuration.ConfigurationManager.AppSettings["Proxy"] != null && System.Configuration.ConfigurationManager.AppSettings["Proxy"] != "")
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
                string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
                string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
                string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];

                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
            X509Store store;
            if (storeLocation == "CurrentUser")
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, certificado, true);
            
            FeaEntidades.InterFacturas.Validar.lote_response lr = new FeaEntidades.InterFacturas.Validar.lote_response();
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                System.Threading.Thread.Sleep(1000);
                
                string resultado = string.Empty;
                resultado = objIBK.validateFacturas(lc);

                resultado = resultado.Replace("\n", "");
                resultado = resultado.Replace("<lote_comprobantes_response xmlns=\"http://lote.schemas.cfe.ib.com.ar/\">", "");
                resultado = resultado.Replace("</lote_comprobantes_response>", "");

                string xml = resultado;
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(FeaEntidades.InterFacturas.Validar.lote_response));
                using (TextReader reader = new StringReader(xml))
                {
                    lr = (FeaEntidades.InterFacturas.Validar.lote_response)serializer.Deserialize(reader);
                }

                resultado = "";
                if (!(lr.estado.Equals("OK")))
                {
                    resultado += "Lote Nro.: " + lr.id_lote + "  Estado: " + lr.estado + "\\n";
                    if (lr.errores_lote != null)
                    {
                        if (lr.errores_lote[0] != null)
                        {
                            foreach (FeaEntidades.InterFacturas.Validar.error error in lr.errores_lote)
                            {

                                resultado += error.codigo_error + " - " + error.descripcion_error + "\\n";
                            }
                        }
                    }
                    resultado += "\\n";
                    if (lr.comprobante_response != null)
                    {
                        if (lr.comprobante_response[0] != null)
                        {
                            foreach (FeaEntidades.InterFacturas.Validar.comprobante_response c in lr.comprobante_response)
                            {
                                resultado += "Comprobante Nro.: " + c.numero_comprobante + "  Estado: " + c.estado + "\\n";
                                foreach (FeaEntidades.InterFacturas.Validar.error errorc in c.errores_comprobante)
                                {
                                    resultado += errorc.codigo_error + " - " + errorc.descripcion_error + "\\n";
                                }
                                resultado += "\\n";
                            }
                        }
                    }
                }
                else
                {
                    resultado = "Comprobante validado satisfactoriamente en Interfacturas.";
                }
                return resultado;
            }
            else
            {
                throw new Exception("Su certificado no está disponible en nuestro repositorio");
            }
        }
        public static string ComprobantesListadoIBK(FeaEntidades.InterFacturas.Listado.consulta_emisor_comprobante_listado cecl, string certificado)
        {
            GrabarLogTexto("Listar.txt", "Paso1");
            RN.IBKComprobantesListado.ReporteFacturaWebService objIBK = new RN.IBKComprobantesListado.ReporteFacturaWebService();
            objIBK.Url = System.Configuration.ConfigurationManager.AppSettings["URLinterfacturasListado"];
            if (System.Configuration.ConfigurationManager.AppSettings["Proxy"] != null && System.Configuration.ConfigurationManager.AppSettings["Proxy"] != "")
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
                string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
                string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
                string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];

                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
            X509Store store;
            
            if (storeLocation == "CurrentUser")
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);

            GrabarLogTexto("Listar.txt", "Paso2");
            //Serializar ( pasar de FeaEntidades.InterFacturas.consulta_emisor_comprobante_listado a String XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(cecl.GetType());
            x.Serialize(writer, cecl);
            ms = (MemoryStream)writer.BaseStream;
            string InputTexto = ByteArrayToString(ms.ToArray());
            ms.Close();
            ms = null;

            GrabarLogTexto("Listar.txt", "Paso3");
            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, certificado, true);
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                System.Threading.Thread.Sleep(1000);
                string resultado = string.Empty;
                resultado = objIBK.getComprobantesListado(InputTexto);
                
                GrabarLogTexto("Listar.txt", "Paso4");
                resultado = resultado.Replace("\n", "");
                resultado = resultado.Replace("<consulta_emisor_comprobante_listado_response xmlns=\"http://lote.schemas.cfe.ib.com.ar/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">", "");
                resultado = resultado.Replace("</consulta_emisor_comprobante_listado_response>", "");
                resultado = resultado.Replace(" xsi:nil=\"true\"", "");
                //Deserializar
                FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response lr = new FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response();
                string xml = resultado;
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response));
                using (TextReader reader = new StringReader(xml))
                {
                    lr = (FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response)serializer.Deserialize(reader);
                }


                //if (lcr.Item.GetType() == typeof(IBK.lote_comprobantes_responseErrores_response))
                //{
                //    resultado = ((IBK.lote_comprobantes_responseErrores_response)lcr.Item).error[0].descripcion_error;
                //}
                //else if (!((IBK.lote_response)(lcr.Item)).estado.Equals("OK"))
                //{
                //    if (((IBK.lote_response)lcr.Item).errores_lote != null)
                //    {
                //        resultado = ((IBK.lote_response)lcr.Item).errores_lote[0].descripcion_error;
                //    }
                //    else
                //    {
                //        resultado = ((IBK.lote_response)lcr.Item).comprobante_response[0].errores_comprobante[0].descripcion_error;
                //    }
                //    throw new Exception(resultado);
                //}
                //else
                //{
                //    resultado = "Comprobante enviado satisfactoriamente a Interfacturas.";
                //}
                return resultado;
            }
            else
            {
                throw new Exception("Su certificado no está disponible en nuestro repositorio");
            }
        }
        public static string ComprobanteDetalleIBK(FeaEntidades.InterFacturas.Detalle.consulta_emisor_comprobante_detalle cecd, string certificado)
        {
            RN.IBKComprobantesListado.ReporteFacturaWebService objIBK = new RN.IBKComprobantesListado.ReporteFacturaWebService();
            objIBK.Url = System.Configuration.ConfigurationManager.AppSettings["URLinterfacturasListado"];
            if (System.Configuration.ConfigurationManager.AppSettings["Proxy"] != null && System.Configuration.ConfigurationManager.AppSettings["Proxy"] != "")
            {
                System.Net.WebProxy wp = new System.Net.WebProxy(System.Configuration.ConfigurationManager.AppSettings["Proxy"], false);
                string usuarioProxy = System.Configuration.ConfigurationManager.AppSettings["UsuarioProxy"];
                string claveProxy = System.Configuration.ConfigurationManager.AppSettings["ClaveProxy"];
                string dominioProxy = System.Configuration.ConfigurationManager.AppSettings["DominioProxy"];

                System.Net.NetworkCredential networkCredential = new System.Net.NetworkCredential(usuarioProxy, claveProxy, dominioProxy);
                wp.Credentials = networkCredential;
                objIBK.Proxy = wp;
            }
            string storeLocation = System.Configuration.ConfigurationManager.AppSettings["StoreLocation"];
            X509Store store;

            if (storeLocation == "CurrentUser")
            {
                store = new X509Store(StoreLocation.CurrentUser);
            }
            else
            {
                store = new X509Store(StoreLocation.LocalMachine);
            }
            store.Open(OpenFlags.ReadOnly);

            //Serializar ( pasar de FeaEntidades.InterFacturas.consulta_emisor_comprobante_listado a String XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(cecd.GetType());
            x.Serialize(writer, cecd);
            ms = (MemoryStream)writer.BaseStream;
            string InputTexto = ByteArrayToString(ms.ToArray());
            ms.Close();
            ms = null;

            X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindBySerialNumber, certificado, true);
            if (col.Count.Equals(1))
            {
                objIBK.ClientCertificates.Add(col[0]);
                System.Threading.Thread.Sleep(1000);
                string resultado = string.Empty;
                resultado = objIBK.getComprobanteDetalle(InputTexto);

                
                //XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                resultado = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" + resultado;
                //resultado = resultado.Replace("\n", "");
                resultado = resultado.Replace("<consulta_emisor_comprobante_detalle_response xmlns=\"http://lote.schemas.cfe.ib.com.ar/\">", "");
                resultado = resultado.Replace("</consulta_emisor_comprobante_detalle_response>", "");
                resultado = resultado.Replace("<consulta_emisor_detalle_response>", "");
                resultado = resultado.Replace("</consulta_emisor_detalle_response>", "");

                resultado = resultado.Replace("<comprobante>", "<comprobante xmlns=\"http://lote.schemas.cfe.ib.com.ar/\">");
                resultado = resultado.Replace(" xsi:nil=\"true\"", "");
                resultado = resultado.Replace("https://qacfe.interbanking.com.ar/cfeWeb/LogoService?idlogo=", "https://srv1.interfacturas.com.ar/cfeWeb/LogoService?idlogo=");
                
                ////Deserializar
                //FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response lr = new FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response();
                //string xml = resultado;
                //var serializer = new System.Xml.Serialization.XmlSerializer(typeof(FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response));
                //using (TextReader reader = new StringReader(xml))
                //{
                //    lr = (FeaEntidades.InterFacturas.Listado.consulta_emisor_listado_response)serializer.Deserialize(reader);
                //}


                //if (lcr.Item.GetType() == typeof(IBK.lote_comprobantes_responseErrores_response))
                //{
                //    resultado = ((IBK.lote_comprobantes_responseErrores_response)lcr.Item).error[0].descripcion_error;
                //}
                //else if (!((IBK.lote_response)(lcr.Item)).estado.Equals("OK"))
                //{
                //    if (((IBK.lote_response)lcr.Item).errores_lote != null)
                //    {
                //        resultado = ((IBK.lote_response)lcr.Item).errores_lote[0].descripcion_error;
                //    }
                //    else
                //    {
                //        resultado = ((IBK.lote_response)lcr.Item).comprobante_response[0].errores_comprobante[0].descripcion_error;
                //    }
                //    throw new Exception(resultado);
                //}
                //else
                //{
                //    resultado = "Comprobante enviado satisfactoriamente a Interfacturas.";
                //}
                return resultado;
            }
            else
            {
                throw new Exception("Su certificado no está disponible en nuestro repositorio");
            }
        }
        private static void GrabarLogTexto(string archivo, string mensaje)
        {
            try
            {
                using (FileStream fs = File.Open(System.Web.HttpContext.Current.Server.MapPath(@"~\" + archivo), FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine(DateTime.Now.ToString("yyyyMMdd hh:mm:ss") + "  " + mensaje);
                    }
                }
            }
            catch
            {
            }
        }
        public static string ByteArrayToString(byte[] characters)
        {
            System.Text.Encoding e = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String constructedString = e.GetString(characters);
            return (constructedString);
        }
        public static void Actualizar(CedServicios.Entidades.Comprobante Comprobante, Entidades.Sesion sesion)
        {
            DB.Comprobante db = new DB.Comprobante(sesion);
            db.Actualizar(Comprobante);
        }
        public static void SerializarLc(out string LoteXML, FeaEntidades.InterFacturas.lote_comprobantes Lc)
        {
            //Serializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
            x.Serialize(writer, Lc);
            ms = (MemoryStream)writer.BaseStream;
            LoteXML = ByteArrayToString(ms.ToArray());
            ms.Close();
            ms = null;
        }
        public static void SerializarC(out string LoteXML, FeaEntidades.InterFacturas.comprobante Lc)
        {
            //Serializar ( pasar de FeaEntidades.InterFacturas.lote_comprobantes a string XML )
            MemoryStream ms = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(ms, System.Text.Encoding.GetEncoding("ISO-8859-1"));
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Lc.GetType());
            x.Serialize(writer, Lc);
            ms = (MemoryStream)writer.BaseStream;
            LoteXML = ByteArrayToString(ms.ToArray());
            ms.Close();
            ms = null;
        }
        public static string GenerarPDF(string CuitVendedor, int NroPuntoVta, int TipoComprobante, long NroComprobante, string IdDestinoComprobante, string ArchivoXML)
        {
            try           
            {
                string comprobanteXML = ArchivoXML;
                System.Text.StringBuilder sbXMLData = new System.Text.StringBuilder();
                sbXMLData.AppendLine(comprobanteXML);

                //Crear nombre de archivo default sin extensión
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(CuitVendedor);
                sb.Append("-");
                sb.Append(NroPuntoVta.ToString("0000"));
                sb.Append("-");
                sb.Append(TipoComprobante.ToString("00"));
                sb.Append("-");
                sb.Append(NroComprobante.ToString("00000000"));

                //Crear nombre de archivo PDF
                System.Text.StringBuilder sbPDF = new System.Text.StringBuilder();
                sbPDF.Append(sb.ToString() + ".pdf");
                System.Text.StringBuilder sbXML = new System.Text.StringBuilder();
                sbXML.Append(sb.ToString() + ".xml");


                string dirTemp = "";
                if (IdDestinoComprobante == "ITF")
                {
                    dirTemp = @"~/TempRender/";
                }
                else
                {
                    dirTemp = @"~/TempRenderAFIP/";
                }

                //Crear archivo comprobante XML
                System.IO.MemoryStream m = new System.IO.MemoryStream();
                System.IO.FileStream fs = new System.IO.FileStream(System.Web.HttpContext.Current.Server.MapPath(dirTemp + sbXML.ToString()), System.IO.FileMode.Create);
                m.WriteTo(fs);
                fs.Close();

                //Grabar información comprobante XML
                using (StreamWriter outfile = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(dirTemp + sbXML.ToString())))
                {
                    outfile.Write(sbXMLData.ToString());
                }

                RN.Sesion.GrabarLogTexto(System.Web.HttpContext.Current.Server.MapPath(@"~/Detallar.txt"), "Inicia ExecuteCommand");
                string Mensaje = ExecuteCommand(sbXML.ToString(), sbPDF.ToString(), IdDestinoComprobante);
                RN.Sesion.GrabarLogTexto(System.Web.HttpContext.Current.Server.MapPath(@"~/Detallar.txt"), "Finaliza ExecuteCommand");

                string url = "";
                if (IdDestinoComprobante == "ITF")
                {
                    url = System.Configuration.ConfigurationManager.AppSettings["URLGenerarPDF"]; 
                }
                else
                {
                    url = System.Configuration.ConfigurationManager.AppSettings["URLGenerarPDFAFIP"]; 
                }
                return url + sbPDF.ToString();
            }
            catch (Exception ex)
            {
                string script = "Problemas para generar el PDF.\\n" + ex.Message;
                script += ex.StackTrace;
                if (ex.InnerException != null)
                {
                    script = ex.InnerException.Message;
                }
                RN.Sesion.GrabarLogTexto(System.Web.HttpContext.Current.Server.MapPath(@"~/Detallar.txt"), script);
                return script;
            }
        }
        public static string ExecuteCommand(string NombreArchivosbXML, string NombreArchivosbPDF, string IdDestinoComprobante)
        {
            int exitcode;

            string command = "";
            ProcessStartInfo procStartInfo;
            if (IdDestinoComprobante == "ITF")
            {
                command = string.Format("GenerarPDF.bat {0} {1} {2}", System.Web.HttpContext.Current.Server.MapPath("~/TempRender/" + "cfe-factura-render-2.57-ejecutable.jar"), System.Web.HttpContext.Current.Server.MapPath("~/TempRender/" + NombreArchivosbXML), System.Web.HttpContext.Current.Server.MapPath("~/TempRender/" + NombreArchivosbPDF));
                procStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                procStartInfo.WorkingDirectory = System.Web.HttpContext.Current.Server.MapPath("~/TempRender/");
            }
            else
            {
                command = string.Format("GenerarPDF2.bat {0} {1} {2}", System.Web.HttpContext.Current.Server.MapPath("~/TempRenderAFIP/" + "cfe-factura-render-AFIP.jar"), System.Web.HttpContext.Current.Server.MapPath("~/TempRenderAFIP/" + NombreArchivosbXML), System.Web.HttpContext.Current.Server.MapPath("~/TempRenderAFIP/" + NombreArchivosbPDF));
                procStartInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
                procStartInfo.WorkingDirectory = System.Web.HttpContext.Current.Server.MapPath("~/TempRenderAFIP/");
            }
            procStartInfo.RedirectStandardError = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            // Now we create a process, assign its ProcessStartInfo and start it
            Process process = new Process();
            process.StartInfo = procStartInfo;
            process.Start();
            process.WaitForExit();

            //Reading output and error
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitcode = process.ExitCode;
            string Mensaje = "";
            //Exit code '0' denotes success and '1' denotes failure
            if (exitcode != 0)
            {
                Mensaje+= "Exit Code:" + exitcode + "  ";
            }
            if (error != "")
            {
                Mensaje += "Error:" + error + "  ";
            }
            if (output != "")
            {
                Mensaje += output + " ";
            }
            RN.Sesion.GrabarLogTexto(System.Web.HttpContext.Current.Server.MapPath("~/Detallar.txt"), "Process Info: " + Mensaje);
            process.Close();
            return Mensaje;
        }
        public static void AjustarLoteParaImprimirPDF(FeaEntidades.InterFacturas.lote_comprobantes lcFea)
        {
            if (lcFea.comprobante[0].cabecera.informacion_comprobante.cae == null || lcFea.comprobante[0].cabecera.informacion_comprobante.cae.Equals(string.Empty))
            {
                lcFea.comprobante[0].cabecera.informacion_comprobante.cae = " ";
            }
            lcFea.comprobante[0].cabecera.informacion_comprobante.caeSpecified = true;
            lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento_caeSpecified = true;
            foreach (FeaEntidades.InterFacturas.linea l in lcFea.comprobante[0].detalle.linea)
            {
                if (l != null)
                {
                    l.descripcion = RN.Funciones.HexToString(l.descripcion).Replace("<br>", System.Environment.NewLine);
                }
                else
                {
                    break;
                }
            }
            if (lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento == null)
            {
                lcFea.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento = string.Empty;
            }
            if (lcFea.cabecera_lote.presta_servSpecified == false)
            {
                lcFea.cabecera_lote.presta_serv = 0;
                lcFea.cabecera_lote.presta_servSpecified = true;
            }
            if (lcFea.comprobante[0].extensiones != null && lcFea.comprobante[0].extensiones.extensiones_datos_comerciales != null && !lcFea.comprobante[0].extensiones.extensiones_datos_comerciales.Equals(string.Empty))
            {
                string dc = RN.Funciones.HexToString(lcFea.comprobante[0].extensiones.extensiones_datos_comerciales);
                lcFea.comprobante[0].extensiones.extensiones_datos_comerciales = dc.Replace("<br>", System.Environment.NewLine);
            }
            else
            {
                lcFea.comprobante[0].extensiones = new FeaEntidades.InterFacturas.extensiones();
            }
            if (lcFea.comprobante[0].resumen.impuestos != null)
            {
                foreach (FeaEntidades.InterFacturas.resumenImpuestos imp in lcFea.comprobante[0].resumen.impuestos)
                {
                    if (imp != null)
                    {
                        imp.codigo_jurisdiccionSpecified = true;
                        imp.porcentaje_impuestoSpecified = true;
                        imp.importe_impuesto_moneda_origenSpecified = true;
                    }
                }
            }
        }
        public static void LeerUltimoEmitido(Entidades.Comprobante Comprobante, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            db.LeerUltimoEmitido(Comprobante);
        }
        public static void LeerDestinatarioFrecuente(Entidades.Persona Persona, Entidades.Comprobante Contrato, Entidades.Sesion Sesion)
        {
            DB.Comprobante db = new DB.Comprobante(Sesion);
            db.LeerDestinatarioFrecuente(Persona, Contrato);
        }
    }
}
