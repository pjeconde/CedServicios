using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.IO;

namespace CedServicios.RN
{
    public class ComprobanteAFIP
    {
        //static ar.gov.afip.wsw.FEResponse objFEResponse;
        //static LoginTicket ticket;
        //static ar.gov.afip.wsw.Service objWS;
        //static ar.gov.afip.wsfev1.Service objWSFEV1;

        private static void CrearTicket(Entidades.Sesion Sesion, out LoginTicket ticket, out ar.gov.afip.wsw.Service objWS, out ar.gov.afip.wsfev1.Service objWSFEV1)
        {
            string RutaCertificado = "";
            ticket = new LoginTicket();

            DB.Ticket ticketDB = new DB.Ticket(Sesion);
            bool SolicitarTicket = false;
            
            if (Sesion.Ticket == null)
            {
                if (Sesion.Cuit.UsaCertificadoAFIPPropio)
                {
                    Sesion.Ticket = ticketDB.Leer(Sesion.Cuit.Nro, TipoServicios.FacturaE);
                }
                else
                {
                    Sesion.Ticket = ticketDB.Leer("30710015062", TipoServicios.FacturaE);
                }
            }
            else
            {
                if (Sesion.Ticket.Cuit != Sesion.Cuit.Nro || Sesion.Ticket.Service != TipoServicios.FacturaE)
                {
                    if (Sesion.Cuit.UsaCertificadoAFIPPropio)
                    {
                        Sesion.Ticket = ticketDB.Leer(Sesion.Cuit.Nro, TipoServicios.FacturaE);
                    }
                    else
                    {
                        if (Sesion.Ticket.Cuit != "30710015062")
                        {
                            Sesion.Ticket = ticketDB.Leer("30710015062",TipoServicios.FacturaE);
                        }
                    }
                }
            }
            if (Sesion.Ticket.Cuit == null)
            {
                SolicitarTicket = true;
            }
            else if (Convert.ToInt64(Sesion.Ticket.ExpirationTime.ToString("yyyyMMddHHmmss")) <= Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")))
            {
                SolicitarTicket = true;
            }
            else
            {
                ticket.ObjAutorizacionfev1 = new ar.gov.afip.wsfev1.FEAuthRequest();
                ticket.ObjAutorizacionfev1.Cuit = Convert.ToInt64(Sesion.Cuit.Nro);
                ticket.ObjAutorizacionfev1.Sign = Sesion.Ticket.Sign;
                ticket.ObjAutorizacionfev1.Token = Sesion.Ticket.Token;
            }
 
            if (SolicitarTicket)
            {
                ticket = new LoginTicket();
                if (Sesion.Cuit.UsaCertificadoAFIPPropio)
                {
                    RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + Sesion.Cuit.Nro + ".p12");
                }
                else
                {
                    RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + Convert.ToInt64("30710015062") + ".p12");
                }
                ticket.ObtenerTicket(RutaCertificado, Convert.ToInt64(Sesion.Cuit.Nro), "wsfe");

                //Guardar Ticket de AFIP
                Sesion.Ticket = new Entidades.Ticket();
                Sesion.Ticket.Cuit = ticket.ObjAutorizacionfev1.Cuit.ToString().Trim();
                Sesion.Ticket.Service = ticket.Service;
                Sesion.Ticket.UniqueId = ticket.UniqueId.ToString().Trim();
                Sesion.Ticket.GenerationTime = ticket.GenerationTime;
                Sesion.Ticket.ExpirationTime = ticket.ExpirationTime;
                Sesion.Ticket.Sign = ticket.Sign;
                Sesion.Ticket.Token = ticket.Token;
                ticketDB.Modificar(Sesion.Ticket);

                SolicitarTicket = false;
            }
            objWS = new ar.gov.afip.wsw.Service();
            objWS.Url = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsw_Service"];
            objWS.Proxy = ticket.Wp;
            objWSFEV1 = new ar.gov.afip.wsfev1.Service();
            objWSFEV1.Url = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsfev1_Service"];
            objWSFEV1.Proxy = ticket.Wp;
        }
        public static string EnviarAFIP(out string Cae, out string CaeFecVto, FeaEntidades.InterFacturas.lote_comprobantes lc, Entidades.Sesion Sesion)
        {
            try
            {
                Cae = "";
                CaeFecVto = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfev1.Service objWSFEV1;
                CrearTicket(Sesion, out ticket, out objWS, out objWSFEV1);

                ar.gov.afip.wsfev1.FECAERequest objFERequest = new ar.gov.afip.wsfev1.FECAERequest();
                ar.gov.afip.wsfev1.FECAECabRequest objFECabeceraRequest = new ar.gov.afip.wsfev1.FECAECabRequest();
                int CantidadComprobantes = 1;
                objFECabeceraRequest.CantReg = CantidadComprobantes;
                objFECabeceraRequest.CbteTipo = lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;  //Comprobante.Codigo;
                objFECabeceraRequest.PtoVta = lc.cabecera_lote.punto_de_venta;
                objFERequest.FeCabReq = objFECabeceraRequest;

                ///* Obtengo última transacción y sumo 1 */
                //FEArn.ar.gov.afip.wsfev1.fe.FEUltNroResponse objFEUltNroResponse = new FEArn.ar.gov.afip.wsw.FEUltNroResponse();
                //objFEUltNroResponse = objWS.FEUltNroRequest(ticket.ObjAutorizacion);

                //Comprobante.IdTransaccion = objFEUltNroResponse.nro.value + 1;
                //objFECabeceraRequest.id = Comprobante.IdTransaccion;
                //objFECabeceraRequest.presta_serv = Convert.ToInt32(Comprobante.Presta_serv);
                //objFERequest.Fecr = objFECabeceraRequest;

                //FEArn.ar.gov.afip.wsw.FEDetalleRequest[] arrayFEDetalleRequest = new FEArn.ar.gov.afip.wsw.FEDetalleRequest[CantidadComprobantes];
                ar.gov.afip.wsfev1.FECAEDetRequest[] arrayFEDetalleRequest = new ar.gov.afip.wsfev1.FECAEDetRequest[CantidadComprobantes];
                //FEArn.ar.gov.afip.wsw.FEDetalleRequest objFEDetalleRequest = new FEArn.ar.gov.afip.wsw.FEDetalleRequest();
                ar.gov.afip.wsfev1.FECAEDetRequest objFEDetalleRequest = new ar.gov.afip.wsfev1.FECAEDetRequest();

                ///* Obtengo último comprobante*/
                //FEArn.ar.gov.afip.wsw.FERecuperaLastCMPResponse objFERecuperaLastCMPResponse = new FEArn.ar.gov.afip.wsw.FERecuperaLastCMPResponse();
                ar.gov.afip.wsfev1.FERecuperaLastCbteResponse UltNro = new ar.gov.afip.wsfev1.FERecuperaLastCbteResponse();
                UltNro = objWSFEV1.FECompUltimoAutorizado(ticket.ObjAutorizacionfev1, lc.cabecera_lote.punto_de_venta, lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante);
                //UltNro.CbteNro;

                ar.gov.afip.wsfev1.FETributoResponse arrayFETributoResponse = new ar.gov.afip.wsfev1.FETributoResponse();
                arrayFETributoResponse = objWSFEV1.FEParamGetTiposTributos(ticket.ObjAutorizacionfev1);

                //FEArn.ar.gov.afip.wsw.FELastCMPtype tipoComprobante = new FEArn.ar.gov.afip.wsw.FELastCMPtype();
                //tipoComprobante.PtoVta = Comprobante.PuntoVenta;
                //tipoComprobante.TipoCbte = Comprobante.Codigo;
                //objFERecuperaLastCMPResponse = objWS.FERecuperaLastCMPRequest(ticket.ObjAutorizacion, tipoComprobante);
                //Comprobante.IdComprobante = objFERecuperaLastCMPResponse.cbte_nro;

                objFEDetalleRequest.Concepto = lc.comprobante[0].cabecera.informacion_comprobante.codigo_concepto; //1-Productos  2-Servicios  3-Productos y Servicios
                objFEDetalleRequest.CbteFch = lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision;             // Comprobante.Fecha_cbte.ToString("yyyyMMdd");
                if (lc.comprobante[0].cabecera.informacion_comprobante.codigo_concepto != 1)
                {
                    objFEDetalleRequest.FchServDesde = lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_desde;     // Comprobante.Fecha_serv_desde.ToString("yyyyMMdd");
                    objFEDetalleRequest.FchServHasta = lc.comprobante[0].cabecera.informacion_comprobante.fecha_serv_hasta;     // Comprobante.Fecha_serv_hasta.ToString("yyyyMMdd");
                    objFEDetalleRequest.FchVtoPago = lc.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento;      // Comprobante.Fecha_venc_pago.ToString("yyyyMMdd");
                }
                if (lc.comprobante[0].resumen.codigo_moneda == "PES")
                {
                    objFEDetalleRequest.ImpNeto = lc.comprobante[0].resumen.importe_total_neto_gravado;                         // Comprobante.Imp_neto;
                    objFEDetalleRequest.ImpOpEx = lc.comprobante[0].resumen.importe_operaciones_exentas;                        // Comprobante.Imp_op_ex;
                    objFEDetalleRequest.ImpTotConc = lc.comprobante[0].resumen.importe_total_concepto_no_gravado;               // Comprobante.Imp_tot_conc;
                    objFEDetalleRequest.ImpTotal = lc.comprobante[0].resumen.importe_total_factura;                             // Comprobante.Imp_total;
                    objFEDetalleRequest.ImpIVA = lc.comprobante[0].resumen.impuesto_liq;                                        // Comprobante.Impto_liq;
                    objFEDetalleRequest.impto_liq_rni = lc.comprobante[0].resumen.impuesto_liq_rni;
                }
                else if (lc.comprobante[0].resumen.codigo_moneda == "DOL")
                {
                    objFEDetalleRequest.ImpNeto = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_neto_gravado;                         // Comprobante.Imp_neto;
                    objFEDetalleRequest.ImpOpEx = lc.comprobante[0].resumen.importes_moneda_origen.importe_operaciones_exentas;                        // Comprobante.Imp_op_ex;
                    objFEDetalleRequest.ImpTotConc = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_concepto_no_gravado;               // Comprobante.Imp_tot_conc;
                    objFEDetalleRequest.ImpTotal = lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura;                             // Comprobante.Imp_total;
                    objFEDetalleRequest.ImpIVA = lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq;                                        // Comprobante.Impto_liq;
                    objFEDetalleRequest.impto_liq_rni = lc.comprobante[0].resumen.importes_moneda_origen.impuesto_liq_rni;
                }
                else
                {
                    throw new Exception("Moneda no permitida: " + lc.comprobante[0].resumen.codigo_moneda.ToString());
                }
                
                objFEDetalleRequest.DocNro = lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio;      // Comprobante.Nro_doc;
                //objFEDetalleRequest.punto_vta = Comprobante.PuntoVenta;
                //objFEDetalleRequest.tipo_cbte = Comprobante.Codigo;
                objFEDetalleRequest.DocTipo = lc.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio;  // Comprobante.TipoDoc;
                objFEDetalleRequest.MonId = lc.comprobante[0].resumen.codigo_moneda;
                objFEDetalleRequest.MonCotiz = lc.comprobante[0].resumen.tipo_de_cambio;
                string TipoComp = lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante.ToString();

                //Referencias
                if (lc.comprobante[0].cabecera.informacion_comprobante.referencias != null)
                {
                    if (lc.comprobante[0].cabecera.informacion_comprobante.referencias.Length > 0)
                    {
                        int CantReferenciasAFIP = 0;
                        for (int j = 0; j < lc.comprobante[0].cabecera.informacion_comprobante.referencias.Length; j++)
                        {
                            if (lc.comprobante[0].cabecera.informacion_comprobante.referencias[j] == null)
                            {
                                break;
                            }
                            if (lc.comprobante[0].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip == "S")
                            {
                                CantReferenciasAFIP += 1;
                            }
                            
                        }
                        if (CantReferenciasAFIP != 0)
                        {
                            objFEDetalleRequest.CbtesAsoc = new ar.gov.afip.wsfev1.CbteAsoc[CantReferenciasAFIP];
                        }
                        CantReferenciasAFIP = 0;

                        for (int j = 0; j < lc.comprobante[0].cabecera.informacion_comprobante.referencias.Length; j++)
                        {
                            if (lc.comprobante[0].cabecera.informacion_comprobante.referencias[j] == null)
                            {
                                break;
                            }
                            if (lc.comprobante[0].cabecera.informacion_comprobante.referencias[j].tipo_comprobante_afip == "S")
                            {
                                objFEDetalleRequest.CbtesAsoc[CantReferenciasAFIP] = new ar.gov.afip.wsfev1.CbteAsoc();
                                objFEDetalleRequest.CbtesAsoc[CantReferenciasAFIP].Tipo = lc.comprobante[0].cabecera.informacion_comprobante.referencias[j].codigo_de_referencia;
                                objFEDetalleRequest.CbtesAsoc[CantReferenciasAFIP].PtoVta = Convert.ToInt32(lc.comprobante[0].cabecera.informacion_comprobante.referencias[j].dato_de_referencia.Substring(0, 4));
                                objFEDetalleRequest.CbtesAsoc[CantReferenciasAFIP].Nro = Convert.ToInt32(lc.comprobante[0].cabecera.informacion_comprobante.referencias[j].dato_de_referencia.Substring(5, 8));
                                CantReferenciasAFIP += 1;
                            }
                        }
                    }
                }

                //Impuestos
                double impTrib = 0;
                if (lc.comprobante[0].resumen.impuestos.Length > 0)
                {
                    if (lc.comprobante[0].resumen.impuestos[0] != null)
                    {
                        int CantTrib = 0;
                        int CantAlicIVA = 0;
                        for (int j = 0; j < lc.comprobante[0].resumen.impuestos.Length; j++)
                        {
                            if (lc.comprobante[0].resumen.impuestos[j].codigo_impuesto != 1)
                            {
                                CantTrib += 1;
                            }
                            else
                            {
                                CantAlicIVA += 1;
                            }
                        }
                        if (CantTrib != 0)
                        {
                            objFEDetalleRequest.Tributos = new ar.gov.afip.wsfev1.Tributo[CantTrib];
                        }
                        CantTrib = 0;
                        
                        ar.gov.afip.wsfev1.AlicIva[] ivas = new ar.gov.afip.wsfev1.AlicIva[CantAlicIVA];
                        CantAlicIVA = 0;
                        for (int j = 0; j < lc.comprobante[0].resumen.impuestos.Length; j++)
                        {

                            switch (lc.comprobante[0].resumen.impuestos[j].codigo_impuesto)
                            {
                                case 1:
                                    double baseImponible = 0;
                                    ivas[CantAlicIVA] = new ar.gov.afip.wsfev1.AlicIva();
                                    //No funciona por el redondeo.
                                    //"PES"
                                    //baseImponible += Math.Round((lc.comprobante[0].resumen.impuestos[j].importe_impuesto * 100) / lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto, 2);
                                    //"DOL"
                                    //baseImponible += Math.Round((lc.comprobante[0].resumen.impuestos[j].importe_impuesto_moneda_origen * 100) / lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto, 2);

                                    //Obtener o Calcular la base imponible
                                    if (lc.comprobante[0].resumen.codigo_moneda == "PES")
                                    {
                                        baseImponible = lc.comprobante[0].resumen.impuestos[j].base_imponible;
                                    }
                                    else
                                    {
                                        baseImponible = lc.comprobante[0].resumen.impuestos[j].base_imponible_moneda_origen;
                                    }
                                    if (baseImponible == 0)
                                    {
                                        baseImponible = CalcularBaseImponible(lc, lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto);
                                    }
                                    //Informar la base imponible y el código de impuesto según la alícuota.
                                    if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 0)
                                    {
                                        ivas[CantAlicIVA].BaseImp = baseImponible;
                                        ivas[CantAlicIVA].Id = 3;
                                    }
                                    if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 10.5)
                                    {
                                        ivas[CantAlicIVA].BaseImp = baseImponible;
                                        ivas[CantAlicIVA].Id = 4;
                                    }
                                    else if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 21)
                                    {
                                        ivas[CantAlicIVA].BaseImp = baseImponible;
                                        ivas[CantAlicIVA].Id = 5;
                                    }
                                    else if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 27)
                                    {
                                        ivas[CantAlicIVA].BaseImp = baseImponible;
                                        ivas[CantAlicIVA].Id = 6;
                                    }
                                    else if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 5)
                                    {
                                        ivas[CantAlicIVA].BaseImp = baseImponible;
                                        ivas[CantAlicIVA].Id = 8;
                                    }
                                    else if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 2.5)
                                    {
                                        
                                        ivas[CantAlicIVA].BaseImp = baseImponible;
                                        ivas[CantAlicIVA].Id = 9;
                                    }
                                    else
                                    {
                                        throw new Exception("Problemas para encontrar el código de la alícuota cuyo porcentaje es: " + lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto.ToString());
                                    }

                                    //Importe del impuesto
                                    if (lc.comprobante[0].resumen.codigo_moneda == "PES")
                                    {
                                        ivas[CantAlicIVA].Importe = Math.Round(lc.comprobante[0].resumen.impuestos[j].importe_impuesto, 2);
                                    }
                                    else
                                    {
                                        ivas[CantAlicIVA].Importe = Math.Round(lc.comprobante[0].resumen.impuestos[j].importe_impuesto_moneda_origen, 2);
                                    }
                                    CantAlicIVA += 1;
                                    break;
                                case 2:  //Internos
                                case 3:  //Otros
                                case 4:  //Nacionales
                                case 5:  //IB - Provinciales
                                case 6:  //Municipales
                                    objFEDetalleRequest.Tributos[CantTrib] = new ar.gov.afip.wsfev1.Tributo();
                                    objFEDetalleRequest.Tributos[CantTrib].Alic = lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto;
                                    objFEDetalleRequest.Tributos[CantTrib].BaseImp = 0;  //Math.Round((lc.comprobante[0].resumen.impuestos[j].importe_impuesto * 100) / lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto, 2);
                                    if (lc.comprobante[0].resumen.impuestos[j].codigo_impuesto == 2)
                                    {
                                        objFEDetalleRequest.Tributos[CantTrib].Id = 4;  //"AFIP - Impuestos Internos"
                                    }
                                    else if (lc.comprobante[0].resumen.impuestos[j].codigo_impuesto == 3)
                                    {
                                        objFEDetalleRequest.Tributos[CantTrib].Id = 99; //"AFIP - Otro"
                                    }
                                    else if (lc.comprobante[0].resumen.impuestos[j].codigo_impuesto == 4)
                                    {
                                        objFEDetalleRequest.Tributos[CantTrib].Id = 1;  //"AFIP - Impuestos nacionales"
                                    }
                                    else if (lc.comprobante[0].resumen.impuestos[j].codigo_impuesto == 5)
                                    {
                                        objFEDetalleRequest.Tributos[CantTrib].Id = 2;  //"AFIP - Impuestos provinciales"
                                    }
                                    else if (lc.comprobante[0].resumen.impuestos[j].codigo_impuesto == 6)
                                    {
                                        objFEDetalleRequest.Tributos[CantTrib].Id = 3;  //"AFIP - Impuestos municipales"
                                    }
                                    if (lc.comprobante[0].resumen.codigo_moneda == "PES")
                                    {
                                        objFEDetalleRequest.Tributos[CantTrib].Importe = Math.Round(lc.comprobante[0].resumen.impuestos[j].importe_impuesto, 2);
                                    }
                                    else
                                    {
                                        objFEDetalleRequest.Tributos[CantTrib].Importe = Math.Round(lc.comprobante[0].resumen.impuestos[j].importe_impuesto_moneda_origen, 2);
                                    }
                                    objFEDetalleRequest.Tributos[CantTrib].Desc = lc.comprobante[0].resumen.impuestos[j].descripcion;
                                    if (lc.comprobante[0].resumen.codigo_moneda == "PES")
                                    {
                                        impTrib += Math.Round(lc.comprobante[0].resumen.impuestos[j].importe_impuesto, 2);
                                    }
                                    else
                                    {
                                        impTrib += Math.Round(lc.comprobante[0].resumen.impuestos[j].importe_impuesto_moneda_origen, 2);
                                    }
                                    CantTrib += 1;
                                    break;
                                default:
                                    throw new Exception("Problemas para enviar el comprobante, código de impuesto incorrecto o inexistente. Código: " + lc.comprobante[0].resumen.impuestos[j].codigo_impuesto.ToString());
                            }
                        }
                        if (ivas != null && ivas.Length > 0)
                        {
                            objFEDetalleRequest.Iva = ivas;
                        }
                    }
                }
                objFEDetalleRequest.ImpTrib = impTrib; //Total de tributos;
                
                //objFEDetalleRequest.Tributos

                arrayFEDetalleRequest[0] = objFEDetalleRequest;
                //for (int c = 0; c < CantidadComprobantes; c++)
                //{
                    //Comprobante.IdComprobante = Comprobante.IdComprobante + 1;
                    objFEDetalleRequest.CbteDesde = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;  //Comprobante.IdComprobante;
                    objFEDetalleRequest.CbteHasta = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;  //Comprobante.IdComprobante;
                    arrayFEDetalleRequest[0] = objFEDetalleRequest;
                //}
                objFERequest.FeDetReq = arrayFEDetalleRequest;

                string loteXML = "";
                SerializarC(out loteXML, objFERequest);
                try
                {
                    Funciones.GrabarLogTexto("Consultar.txt", loteXML);
                }
                catch
                { 
                }

                ar.gov.afip.wsfev1.FECAEResponse objFEResponse = new ar.gov.afip.wsfev1.FECAEResponse();
                objFEResponse = objWSFEV1.FECAESolicitar(ticket.ObjAutorizacionfev1, objFERequest);

                string respuesta = "";
                if (objFEResponse.Errors == null)
                {
                    //if (objFEResponse.FeCabResp.Resultado == "A")
                    //{
                    for (int i = 0; i < objFEResponse.FeDetResp.Length; i++)
                    {
                        respuesta += "Resultado: " + objFEResponse.FeDetResp[i].Resultado + "\\n";
                        if (objFEResponse.FeDetResp[i].Observaciones != null)
                        {
                            for (int j = 0; j < objFEResponse.FeDetResp[i].Observaciones.Length; j++)
                            {
                                respuesta += objFEResponse.FeDetResp[i].Observaciones[j].Code.ToString() + "-" + objFEResponse.FeDetResp[i].Observaciones[j].Msg + "\\n";
                            }
                        }
                        respuesta += "CAE: " + objFEResponse.FeDetResp[i].CAE;
                        Cae = objFEResponse.FeDetResp[i].CAE;
                        CaeFecVto = objFEResponse.FeDetResp[i].CAEFchVto;
                    }
                    //}
                }
                else
                {
                    for (int i = 0; i < objFEResponse.Errors.Length; i++)
                    {
                        respuesta += objFEResponse.Errors[i].Code + "-" + objFEResponse.Errors[i].Msg + ".\\n ";
                        if (objFEResponse.Errors[i].Code == 10016)
                        {
                            try
                            {
                                respuesta += "Ultimo nro. de comprobante enviado: " + UltNro.CbteNro + ".\\n";
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private static double CalcularBaseImponible(FeaEntidades.InterFacturas.lote_comprobantes lc, double Alicuota)
        {
            double baseImp = 0;
            for (int k = 0; k < lc.comprobante[0].detalle.linea.Length; k++)
            {
                if (lc.comprobante[0].detalle.linea[k] == null) { break; }
                if (lc.comprobante[0].detalle.linea[k].indicacion_exento_gravado != null && lc.comprobante[0].detalle.linea[k].indicacion_exento_gravado.Trim().ToUpper() == "G" && lc.comprobante[0].detalle.linea[k].alicuota_iva == Alicuota)
                {
                    if (lc.comprobante[0].resumen.codigo_moneda == "PES")
                    {
                        baseImp += lc.comprobante[0].detalle.linea[k].importe_total_articulo;
                    }
                    else
                    {
                        baseImp += lc.comprobante[0].detalle.linea[k].importes_moneda_origen.importe_total_articulo;
                    }
                }
            }
            return Math.Round(baseImp, 2);
        }
        private static void CrearTicketExpo(Entidades.Sesion Sesion, out LoginTicket ticket, out ar.gov.afip.wsw.Service objWS, out ar.gov.afip.wsfexv1.Service objWSFEXV1)
        {
            string RutaCertificado = "";
            ticket = new LoginTicket();

            DB.Ticket ticketDB = new DB.Ticket(Sesion);
            bool SolicitarTicket = false;

            if (Sesion.Ticket == null)
            {
                if (Sesion.Cuit.UsaCertificadoAFIPPropio)
                {
                    Sesion.Ticket = ticketDB.Leer(Sesion.Cuit.Nro, TipoServicios.FacturaEX);
                }
                else
                {
                    Sesion.Ticket = ticketDB.Leer("30710015062", TipoServicios.FacturaEX);
                }
            }
            else
            {
                if (Sesion.Ticket.Cuit != Sesion.Cuit.Nro || Sesion.Ticket.Service != TipoServicios.FacturaEX)
                {
                    if (Sesion.Cuit.UsaCertificadoAFIPPropio)
                    {
                        Sesion.Ticket = ticketDB.Leer(Sesion.Cuit.Nro, TipoServicios.FacturaEX);
                    }
                    else
                    {
                        if (Sesion.Ticket.Cuit != "30710015062")
                        {
                            Sesion.Ticket = ticketDB.Leer("30710015062", TipoServicios.FacturaEX);
                        }
                    }
                }
            }
            if (Sesion.Ticket.Cuit == null)
            {
                SolicitarTicket = true;
            }
            else if (Convert.ToInt64(Sesion.Ticket.ExpirationTime.ToString("yyyyMMddHHmmss")) <= Convert.ToInt64(DateTime.Now.ToString("yyyyMMddHHmmss")))
            {
                SolicitarTicket = true;
            }
            else
            {
                ticket.ObjAutorizacionfexv1 = new ar.gov.afip.wsfexv1.ClsFEXAuthRequest();
                ticket.ObjAutorizacionfexv1.Cuit = Convert.ToInt64(Sesion.Cuit.Nro);
                ticket.ObjAutorizacionfexv1.Sign = Sesion.Ticket.Sign;
                ticket.ObjAutorizacionfexv1.Token = Sesion.Ticket.Token;
            }

            if (SolicitarTicket)
            {
                ticket = new LoginTicket();
                if (Sesion.Cuit.UsaCertificadoAFIPPropio)
                {
                    RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + Sesion.Cuit.Nro + ".p12");
                }
                else
                {
                    RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + Convert.ToInt64("30710015062") + ".p12");
                }
                ticket.ObtenerTicket(RutaCertificado, Convert.ToInt64(Sesion.Cuit.Nro), "wsfex");

                //Guardar Ticket de AFIP
                Sesion.Ticket = new Entidades.Ticket();
                Sesion.Ticket.Cuit = ticket.ObjAutorizacionfev1.Cuit.ToString().Trim();
                Sesion.Ticket.Service = ticket.Service;
                Sesion.Ticket.UniqueId = ticket.UniqueId.ToString().Trim();
                Sesion.Ticket.GenerationTime = ticket.GenerationTime;
                Sesion.Ticket.ExpirationTime = ticket.ExpirationTime;
                Sesion.Ticket.Sign = ticket.Sign;
                Sesion.Ticket.Token = ticket.Token;
                ticketDB.Modificar(Sesion.Ticket);

                SolicitarTicket = false;
            }
            objWS = new ar.gov.afip.wsw.Service();
            objWS.Url = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsw_Service"];
            objWS.Proxy = ticket.Wp;
            objWSFEXV1 = new ar.gov.afip.wsfexv1.Service();
            objWSFEXV1.Url = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsfexv1_Service"];
            objWSFEXV1.Proxy = ticket.Wp;
        }
        public static string EnviarAFIPExpo(out string Cae, out string CaeFecVto, FeaEntidades.InterFacturas.lote_comprobantes lc, Entidades.Sesion Sesion)
        {
            try
            {
                Cae = "";
                CaeFecVto = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;
                CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);
                
                ar.gov.afip.wsfexv1.ClsFEXRequest objFECabeceraRequest = new ar.gov.afip.wsfexv1.ClsFEXRequest();
                objFECabeceraRequest.Id = lc.cabecera_lote.id_lote;
                objFECabeceraRequest.Cbte_Tipo = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante);
                objFECabeceraRequest.Punto_vta = Convert.ToInt16(lc.cabecera_lote.punto_de_venta);
                objFECabeceraRequest.Cbte_nro = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                objFECabeceraRequest.Fecha_cbte = lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision;
                objFECabeceraRequest.Tipo_expo = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.tipo_exportacion);
                objFECabeceraRequest.Dst_cmp = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.destino_comprobante);
                objFECabeceraRequest.Incoterms = lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.incoterms;
                objFECabeceraRequest.Incoterms_Ds = lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.descripcion_incoterms;
                if (lc.comprobante[0].extensiones != null)
                {
                    if (lc.comprobante[0].extensiones.extensiones_camara_facturas != null && lc.comprobante[0].extensiones.extensiones_camara_facturasSpecified == true)
                    {
                        objFECabeceraRequest.Idioma_cbte = Convert.ToInt16(lc.comprobante[0].extensiones.extensiones_camara_facturas.id_idioma);
                    }
                }
                objFECabeceraRequest.Cuit_pais_cliente = lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio;
                objFECabeceraRequest.Cliente = lc.comprobante[0].cabecera.informacion_comprador.denominacion;

                //No es obligatorio si se asigna el Cuit_pais_cliente.
                //objFECabeceraRequest.Id_impositivo = "";

                objFECabeceraRequest.Domicilio_cliente = lc.comprobante[0].cabecera.informacion_comprador.domicilio_calle + " " + lc.comprobante[0].cabecera.informacion_comprador.domicilio_numero;
                
                objFECabeceraRequest.Forma_pago = lc.comprobante[0].cabecera.informacion_comprobante.condicion_de_pago;

                //No son obligatorias. String(c2000)
                //objFECabeceraRequest.Obs_comerciales = ""

                
                //No son obligatorias. String(c1000)
                //objFECabeceraRequest.Obs = "";
                
                //Clave de identificación tributaria del comprador. No es obligatorio si se ingresó valor en el campo Cuit_pais_cliente.
                //objFECabeceraRequest.Id_impositivo = "";

                if (lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente == "S")
                {
                    objFECabeceraRequest.Permiso_existente = lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente;
                    if (lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permisos != null && lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permisos.Length > 0)
                    {
                        int CantidadPermisos = 0;
                        foreach (FeaEntidades.InterFacturas.permisos pe in lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permisos)
                        {
                            if (pe == null)
                            {
                                break;
                            }
                            CantidadPermisos += 1;
                        }
                        if (CantidadPermisos != 0)
                        {
                            ar.gov.afip.wsfexv1.Permiso[] arrayFEPermisosRequest = new ar.gov.afip.wsfexv1.Permiso[CantidadPermisos];
                            for (int i = 0; i < CantidadPermisos; i++)
                            {
                                ar.gov.afip.wsfexv1.Permiso p = new ar.gov.afip.wsfexv1.Permiso();
                                p.Id_permiso = lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permisos[i].id_permiso;
                                p.Dst_merc = lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permisos[i].destino_mercaderia;
                                arrayFEPermisosRequest[i] = p;
                            }
                            objFECabeceraRequest.Permisos = arrayFEPermisosRequest;
                        }
                    }
                }
                else if (lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente == "N")
                {
                    objFECabeceraRequest.Permiso_existente = lc.comprobante[0].cabecera.informacion_comprobante.informacion_exportacion.permiso_existente;
                }
                else
                {
                    objFECabeceraRequest.Permiso_existente = "";
                }

                if (lc.comprobante[0].cabecera.informacion_comprobante.referencias != null && lc.comprobante[0].cabecera.informacion_comprobante.referencias.Length > 0)
                {
                    int CantidadReferencias = 0;
                    foreach (FeaEntidades.InterFacturas.informacion_comprobanteReferencias re in lc.comprobante[0].cabecera.informacion_comprobante.referencias)
                    {
                        if (re == null)
                        {
                            break;
                        }
                        CantidadReferencias += 1;
                    }
                    if (CantidadReferencias != 0)
                    {
                        ar.gov.afip.wsfexv1.Cmp_asoc[] arrayFEReferenciasRequest = new ar.gov.afip.wsfexv1.Cmp_asoc[CantidadReferencias];
                        for (int i = 0; i < CantidadReferencias; i++)
                        {
                            //if (lc.comprobante[0].cabecera.informacion_comprobante.referencias[i].tipo_comprobante_afip == "S")
                            //{
                                ar.gov.afip.wsfexv1.Cmp_asoc r = new ar.gov.afip.wsfexv1.Cmp_asoc();
                                r.Cbte_tipo = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.referencias[i].codigo_de_referencia);
                                r.Cbte_punto_vta = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.referencias[i].dato_de_referencia.Substring(0, 4));
                                r.Cbte_nro = Convert.ToInt32(lc.comprobante[0].cabecera.informacion_comprobante.referencias[i].dato_de_referencia.Substring(5, 8));
                                arrayFEReferenciasRequest[i] = r;
                            //}
                        }
                        objFECabeceraRequest.Cmps_asoc = arrayFEReferenciasRequest;
                    }
                }

                ///* Obtengo último comprobante*/
                //ar.gov.afip.wsfexv1.ClsFEX_LastCMP lastCMP = new ar.gov.afip.wsfexv1.ClsFEX_LastCMP();
                //lastCMP.Cuit =  Convert.ToInt64(Sesion.Cuit.Nro);
                //lastCMP.Sign = ticket.ObjAutorizacionfexv1.Sign;
                //lastCMP.Token = ticket.ObjAutorizacionfexv1.Token;
                //lastCMP.Cbte_Tipo = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante);
                //lastCMP.Pto_venta = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta);
                //ar.gov.afip.wsfexv1.FEXResponseLast_CMP lastcmpResponse = objWSFEXV1.FEXGetLast_CMP(lastCMP);
                //long UltNro = lastcmpResponse.FEXResult_LastCMP.Cbte_nro;
                
                //Consultar comprobante
                //ar.gov.afip.wsfexv1.ClsFEXGetCMP getCMP = new ar.gov.afip.wsfexv1.ClsFEXGetCMP();
                //getCMP.Cbte_tipo = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante);
                //getCMP.Punto_vta = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta);
                //getCMP.Cbte_nro = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                //ar.gov.afip.wsfexv1.FEXGetCMPResponse cmpResponse = objWSFEXV1.FEXGetCMP(ticket.ObjAutorizacionfexv1, getCMP);

                //Código  de moneda. Consultar método FEXGetPARAM_MON para valores permitidos.
                objFECabeceraRequest.Moneda_Id = lc.comprobante[0].resumen.codigo_moneda;
                objFECabeceraRequest.Moneda_ctz = Convert.ToDecimal(Math.Round(lc.comprobante[0].resumen.tipo_de_cambio, 6));

                if (lc.comprobante[0].resumen.codigo_moneda == "PES")
                {
                    objFECabeceraRequest.Imp_total = Convert.ToDecimal(Math.Round(lc.comprobante[0].resumen.importe_total_factura, 3)); 
                }
                else if (lc.comprobante[0].resumen.codigo_moneda == "DOL")
                {
                    objFECabeceraRequest.Imp_total = Convert.ToDecimal(Math.Round(lc.comprobante[0].resumen.importes_moneda_origen.importe_total_factura, 3));
                }
                else
                {
                    throw new Exception("Moneda no permitida: " + lc.comprobante[0].resumen.codigo_moneda.ToString());
                }

                //Renglones
                int CantidadLineas = 0;
                if (lc.comprobante[0].detalle.linea != null)
                {
                    foreach (FeaEntidades.InterFacturas.linea li in lc.comprobante[0].detalle.linea)
                    {
                        if (li == null)
                        {
                            break;
                        }
                        CantidadLineas += 1;
                    }
                    if (CantidadLineas != 0)
                    {
                        ar.gov.afip.wsfexv1.Item[] items = new ar.gov.afip.wsfexv1.Item[CantidadLineas];
                        for (int j = 0; j < CantidadLineas; j++)
                        {
                            ar.gov.afip.wsfexv1.Item item = new ar.gov.afip.wsfexv1.Item();
                            item.Pro_codigo = lc.comprobante[0].detalle.linea[j].codigo_producto_vendedor;
                            if (lc.comprobante[0].detalle.linea[j].descripcion.Substring(0, 1) == "%")
                            {
                                item.Pro_ds = RN.Funciones.HexToString(lc.comprobante[0].detalle.linea[j].descripcion);
                            }
                            else
                            {
                                item.Pro_ds = lc.comprobante[0].detalle.linea[j].descripcion;
                            }
                            if (lc.comprobante[0].detalle.linea[j].cantidadSpecified == true)
                            {
                                item.Pro_qty = Convert.ToDecimal(lc.comprobante[0].detalle.linea[j].cantidad);
                            }
                            item.Pro_umed = Convert.ToInt32(lc.comprobante[0].detalle.linea[j].unidad);
                            if (lc.comprobante[0].resumen.codigo_moneda == "PES")
                            {
                                if (lc.comprobante[0].detalle.linea[j].precio_unitarioSpecified == true)
                                {
                                    item.Pro_precio_uni = Convert.ToDecimal(lc.comprobante[0].detalle.linea[j].precio_unitario);
                                }
                                item.Pro_total_item = Convert.ToDecimal(lc.comprobante[0].detalle.linea[j].importe_total_articulo);
                            }
                            else
                            {
                                if (lc.comprobante[0].detalle.linea[j].importes_moneda_origen.precio_unitarioSpecified == true)
                                {
                                    item.Pro_precio_uni = Convert.ToDecimal(lc.comprobante[0].detalle.linea[j].importes_moneda_origen.precio_unitario);
                                }
                                item.Pro_total_item = Convert.ToDecimal(lc.comprobante[0].detalle.linea[j].importes_moneda_origen.importe_total_articulo);
                            }
                            items[j] = item;
                        }
                        objFECabeceraRequest.Items = items;
                    }
                }

                string loteXML = "";
                SerializarCExpo(out loteXML, objFECabeceraRequest);
                try
                {
                    Funciones.GrabarLogTexto("Consultar.txt", loteXML);
                }
                catch
                {
                }
                
                ar.gov.afip.wsfexv1.FEXResponseAuthorize objFEResponse = new ar.gov.afip.wsfexv1.FEXResponseAuthorize();
                objFEResponse = objWSFEXV1.FEXAuthorize(ticket.ObjAutorizacionfexv1, objFECabeceraRequest);

                string respuesta = "";
                if (objFEResponse.FEXErr == null || objFEResponse.FEXErr.ErrMsg == "OK")
                {
                    respuesta += "Resultado: " + objFEResponse.FEXResultAuth.Resultado + "\\n";
                    if (objFEResponse.FEXResultAuth.Motivos_Obs != null && objFEResponse.FEXResultAuth.Motivos_Obs != "")
                    {
                        respuesta += objFEResponse.FEXResultAuth.Motivos_Obs + "\\n";
                    }
                    respuesta += "CAE: " + objFEResponse.FEXResultAuth.Cae;
                    Cae = objFEResponse.FEXResultAuth.Cae;
                    CaeFecVto = objFEResponse.FEXResultAuth.Fch_venc_Cae;
                }
                else
                {
                    respuesta += objFEResponse.FEXErr.ErrCode + "-" + objFEResponse.FEXErr.ErrMsg + ".\\n ";
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ConsultarAFIP(out string CaeNro, out string CaeFecVto, out string CaeFecPro, FeaEntidades.InterFacturas.lote_comprobantes lc, Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                CaeNro = "";
                CaeFecVto = "";
                CaeFecPro = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfev1.Service objWSFEV1;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;

                List<Entidades.PuntoVta> listaPV = Sesion.UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                {
                    return pv.Nro == lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                });
                if (listaPV.Count != 0)
                {
                    if (listaPV[0].IdTipoPuntoVta == "Comun")
                    {
                        CrearTicket(Sesion, out ticket, out objWS, out objWSFEV1);

                        ar.gov.afip.wsfev1.FECompConsultaReq objFECompConsultaReq = new ar.gov.afip.wsfev1.FECompConsultaReq();
                        objFECompConsultaReq.CbteTipo = lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                        objFECompConsultaReq.CbteNro = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                        objFECompConsultaReq.PtoVta = lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                        ar.gov.afip.wsfev1.FECompConsultaResponse objFECompConsultaResponse = new ar.gov.afip.wsfev1.FECompConsultaResponse();
                        objFECompConsultaResponse = objWSFEV1.FECompConsultar(ticket.ObjAutorizacionfev1, objFECompConsultaReq);
                        System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                        cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                        if (objFECompConsultaResponse.Errors != null)
                        {
                            foreach (ar.gov.afip.wsfev1.Err err in objFECompConsultaResponse.Errors)
                            {
                                respuesta = err.Code + "-" + err.Msg + "\r\n";
                            }
                        }
                        else
                        {
                            //respuesta += DateTime.ParseExact(objFECompConsultaResponse.ResultGet.FchProceso, "yyyyMMddHHmmss", cedeiraCultura);
                            if (objFECompConsultaResponse.ResultGet.Iva != null)
                            {
                            }
                            respuesta += "Resultado: " + objFECompConsultaResponse.ResultGet.Resultado + "\\n";
                            //if (objFECompConsultaResponse.ResultGet.Concepto != 0)
                            //{
                            //    respuesta += "Concepto: " + objFECompConsultaResponse.ResultGet.Concepto.ToString();
                            //}
                            respuesta += "CAE: " + objFECompConsultaResponse.ResultGet.CodAutorizacion;
                            respuesta += "CAE Fec.Vto: " + objFECompConsultaResponse.ResultGet.FchVto;
                            CaeNro = objFECompConsultaResponse.ResultGet.CodAutorizacion;
                            CaeFecVto = objFECompConsultaResponse.ResultGet.FchVto;
                            CaeFecPro = objFECompConsultaResponse.ResultGet.FchProceso;
                        }
                    }
                    else if (listaPV[0].IdTipoPuntoVta == "Exportacion")
                    {
                        CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);
                        ar.gov.afip.wsfexv1.ClsFEXGetCMP getCMP = new ar.gov.afip.wsfexv1.ClsFEXGetCMP();
                        getCMP.Cbte_tipo = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante);
                        getCMP.Punto_vta = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta);
                        getCMP.Cbte_nro = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                        ar.gov.afip.wsfexv1.FEXGetCMPResponse cmpResponse = objWSFEXV1.FEXGetCMP(ticket.ObjAutorizacionfexv1, getCMP);
                        System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                        cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                        if (cmpResponse.FEXErr != null && cmpResponse.FEXErr.ErrMsg != "OK")
                        {
                            respuesta = cmpResponse.FEXErr.ErrCode + "-" + cmpResponse.FEXErr.ErrMsg;
                        }
                        else
                        {
                            respuesta += "Resultado: " + cmpResponse.FEXResultGet.Resultado + "\\n";
                            respuesta += "CAE: " + cmpResponse.FEXResultGet.Cae;
                            respuesta += "CAE Fec.Vto: " + cmpResponse.FEXResultGet.Fch_venc_Cae;
                            CaeNro = cmpResponse.FEXResultGet.Cae;
                            CaeFecVto = cmpResponse.FEXResultGet.Fch_venc_Cae;
                            CaeFecPro = cmpResponse.FEXResultGet.Fecha_cbte_cae;
                        }
                    }
                    else
                    {
                        throw new Exception("Este tipo de punto de venta no está disponible para la consulta On-Line. Punto de venta: " + lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString() + " " + listaPV[0].IdTipoPuntoVta);
                    }
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPSerializer(FeaEntidades.InterFacturas.lote_comprobantes lc, Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfev1.Service objWSFEV1;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;
                
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;

                //Buscar tipo de punto de venta
                //lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta
                List<Entidades.PuntoVta> listaPV = Sesion.UN.PuntosVta.FindAll(delegate(Entidades.PuntoVta pv)
                {
                    return pv.Nro == lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                });
                if (listaPV.Count != 0)
                {
                    if (listaPV[0].IdTipoPuntoVta == "Comun")
                    {
                        CrearTicket(Sesion, out ticket, out objWS, out objWSFEV1);
                        ar.gov.afip.wsfev1.FECompConsultaReq objFECompConsultaReq = new ar.gov.afip.wsfev1.FECompConsultaReq();
                        objFECompConsultaReq.CbteTipo = lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                        objFECompConsultaReq.CbteNro = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                        objFECompConsultaReq.PtoVta = lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                        ar.gov.afip.wsfev1.FECompConsultaResponse objFECompConsultaResponse = new ar.gov.afip.wsfev1.FECompConsultaResponse();
                        objFECompConsultaResponse = objWSFEV1.FECompConsultar(ticket.ObjAutorizacionfev1, objFECompConsultaReq);
                        if (objFECompConsultaResponse.Errors != null)
                        {
                            respuesta += DB.Funciones.ObjetoSerializado(objFECompConsultaResponse.Errors);
                        }
                        else
                        {
                            respuesta += DB.Funciones.ObjetoSerializado(objFECompConsultaResponse.ResultGet);
                        }
                    }
                    else if (listaPV[0].IdTipoPuntoVta == "Exportacion")
                    {

                        CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);
                        ar.gov.afip.wsfexv1.ClsFEXGetCMP getCMP = new ar.gov.afip.wsfexv1.ClsFEXGetCMP();
                        getCMP.Cbte_tipo = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante);
                        getCMP.Punto_vta = Convert.ToInt16(lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta);
                        getCMP.Cbte_nro = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                        ar.gov.afip.wsfexv1.FEXGetCMPResponse cmpResponse = objWSFEXV1.FEXGetCMP(ticket.ObjAutorizacionfexv1, getCMP);
                        if (cmpResponse.FEXErr != null && cmpResponse.FEXErr.ErrMsg != "OK")
                        {
                            respuesta += DB.Funciones.ObjetoSerializado(cmpResponse.FEXErr);
                        }
                        else
                        {
                            respuesta += DB.Funciones.ObjetoSerializado(cmpResponse.FEXResultGet);
                        }
                    }
                    else
                    {
                        throw new Exception("Este tipo de punto de venta no está disponible para la consulta On-Line. Punto de venta: " + lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString() + " " + listaPV[0].IdTipoPuntoVta);
                    }
                }
                else
                {
                    throw new Exception("Problemas para obtener los datos del punto de venta: " + lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta.ToString());
                }
                


                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPUltNroLote(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfev1.Service objWSFEV1;
                CrearTicket(Sesion, out ticket, out objWS, out objWSFEV1);

                ar.gov.afip.wsw.FEUltNroResponse FEUltNroResponse = new ar.gov.afip.wsw.FEUltNroResponse();
                FEUltNroResponse = objWS.FEUltNroRequest(ticket.ObjAutorizacion);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (FEUltNroResponse.RError != null && FEUltNroResponse.RError.perrmsg != "OK")
                {
                    respuesta += DB.Funciones.ObjetoSerializado(FEUltNroResponse.RError);
                }
                else
                {
                    respuesta += "Nro Ult. Lote: " + FEUltNroResponse.nro.value.ToString();
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPTiposDoc(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfev1.Service objWSFEV1;
                CrearTicket(Sesion, out ticket, out objWS, out objWSFEV1);

                ar.gov.afip.wsfev1.DocTipoResponse FEDocTipoResponse = new ar.gov.afip.wsfev1.DocTipoResponse();
                FEDocTipoResponse = objWSFEV1.FEParamGetTiposDoc(ticket.ObjAutorizacionfev1);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (FEDocTipoResponse.Errors != null)
                {
                    respuesta += DB.Funciones.ObjetoSerializado(FEDocTipoResponse.Errors);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(FEDocTipoResponse.ResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPUltNroComprobante(FeaEntidades.InterFacturas.lote_comprobantes lc, Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfev1.Service objWSFEV1;
                CrearTicket(Sesion, out ticket, out objWS, out objWSFEV1);

                ar.gov.afip.wsw.FELastCMPtype FELastCMPtype = new ar.gov.afip.wsw.FELastCMPtype();
                FELastCMPtype.TipoCbte = lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                FELastCMPtype.PtoVta = lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                ar.gov.afip.wsw.FERecuperaLastCMPResponse FERecuperaLastCMPResponse = new ar.gov.afip.wsw.FERecuperaLastCMPResponse();
                FERecuperaLastCMPResponse = objWS.FERecuperaLastCMPRequest(ticket.ObjAutorizacion, FELastCMPtype);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (FERecuperaLastCMPResponse.RError != null && FERecuperaLastCMPResponse.RError.perrmsg != "OK")
                {
                    respuesta += DB.Funciones.ObjetoSerializado(FERecuperaLastCMPResponse.RError);
                }
                else
                {
                    respuesta += "Nro Ult. Comprobante: " + FERecuperaLastCMPResponse.cbte_nro.ToString();
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPTiposComprobantes(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfev1.Service objWSFEV1;
                CrearTicket(Sesion, out ticket, out objWS, out objWSFEV1);

                ar.gov.afip.wsfev1.CbteTipoResponse CbteTipoResponse = new ar.gov.afip.wsfev1.CbteTipoResponse();
                CbteTipoResponse = objWSFEV1.FEParamGetTiposCbte(ticket.ObjAutorizacionfev1);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (CbteTipoResponse.Errors != null)
                {
                    respuesta += DB.Funciones.ObjetoSerializado(CbteTipoResponse.Errors);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(CbteTipoResponse.ResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPTiposComprobantesEXPO(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;
                CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);

                ar.gov.afip.wsfexv1.FEXResponse_Cbte_Tipo arrayFEResponse = new ar.gov.afip.wsfexv1.FEXResponse_Cbte_Tipo();
                arrayFEResponse = objWSFEXV1.FEXGetPARAM_Cbte_Tipo(ticket.ObjAutorizacionfexv1);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (arrayFEResponse.FEXErr != null && arrayFEResponse.FEXErr.ErrMsg != "OK")
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXErr);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPTiposDeEXPO(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;
                CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);

                ar.gov.afip.wsfexv1.FEXResponse_Tex arrayFEResponse = new ar.gov.afip.wsfexv1.FEXResponse_Tex();
                arrayFEResponse = objWSFEXV1.FEXGetPARAM_Tipo_Expo(ticket.ObjAutorizacionfexv1);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (arrayFEResponse.FEXErr != null && arrayFEResponse.FEXErr.ErrMsg != "OK")
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXErr);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPUnidadesDeMedidaEXPO(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;
                CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);

                ar.gov.afip.wsfexv1.FEXResponse_Umed arrayFEResponse = new ar.gov.afip.wsfexv1.FEXResponse_Umed();
                arrayFEResponse = objWSFEXV1.FEXGetPARAM_UMed(ticket.ObjAutorizacionfexv1);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (arrayFEResponse.FEXErr != null && arrayFEResponse.FEXErr.ErrMsg != "OK")
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXErr);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPIncotermsEXPO(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;
                CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);

                ar.gov.afip.wsfexv1.FEXResponse_Inc arrayFEResponse = new ar.gov.afip.wsfexv1.FEXResponse_Inc();
                arrayFEResponse = objWSFEXV1.FEXGetPARAM_Incoterms(ticket.ObjAutorizacionfexv1);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (arrayFEResponse.FEXErr != null && arrayFEResponse.FEXErr.ErrMsg != "OK")
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXErr);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPDST_CuitEXPO(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;
                CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);

                ar.gov.afip.wsfexv1.FEXResponse_DST_cuit arrayFEResponse = new ar.gov.afip.wsfexv1.FEXResponse_DST_cuit();
                arrayFEResponse = objWSFEXV1.FEXGetPARAM_DST_CUIT(ticket.ObjAutorizacionfexv1);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (arrayFEResponse.FEXErr != null && arrayFEResponse.FEXErr.ErrMsg != "OK")
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXErr);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static string ConsultarAFIPDST_PaisEXPO(Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfexv1.Service objWSFEXV1;
                CrearTicketExpo(Sesion, out ticket, out objWS, out objWSFEXV1);

                ar.gov.afip.wsfexv1.FEXResponse_DST_pais arrayFEResponse = new ar.gov.afip.wsfexv1.FEXResponse_DST_pais();
                arrayFEResponse = objWSFEXV1.FEXGetPARAM_DST_pais(ticket.ObjAutorizacionfexv1);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (arrayFEResponse.FEXErr != null && arrayFEResponse.FEXErr.ErrMsg != "OK")
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXErr);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(arrayFEResponse.FEXResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ValidarAFIPNroCae(FeaEntidades.InterFacturas.lote_comprobantes lc, Entidades.Sesion Sesion)
        {
            try
            {
                string respuesta = "";
                LoginTicket ticket;
                ar.gov.afip.wsw.Service objWS;
                ar.gov.afip.wsfev1.Service objWSFEV1;
                CrearTicket(Sesion, out ticket, out objWS, out objWSFEV1);
                
                ar.gov.afip.wsw.FEConsultaCAEReq objFECompConsultaReq = new ar.gov.afip.wsw.FEConsultaCAEReq();
                objFECompConsultaReq.cuit_emisor = lc.comprobante[0].cabecera.informacion_vendedor.cuit;
                objFECompConsultaReq.tipo_cbte = lc.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
                objFECompConsultaReq.cbt_nro= lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
                objFECompConsultaReq.punto_vta = lc.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
                objFECompConsultaReq.cae = lc.comprobante[0].cabecera.informacion_comprobante.cae;
                //objFECompConsultaReq.imp_total = lc.comprobante[0].resumen.importe_total_factura;
                objFECompConsultaReq.fecha_cbte = lc.comprobante[0].cabecera.informacion_comprobante.fecha_emision;     //formato: yyyyMMdd

                ar.gov.afip.wsw.FEConsultaCAEResponse CAEResponse = new ar.gov.afip.wsw.FEConsultaCAEResponse();
                CAEResponse = objWS.FEConsultaCAERequest(ticket.ObjAutorizacion, objFECompConsultaReq);
                System.Globalization.CultureInfo cedeiraCultura = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["Cultura"], false);
                cedeiraCultura.DateTimeFormat = new System.Globalization.CultureInfo(System.Configuration.ConfigurationManager.AppSettings["CulturaDateTimeFormat"], false).DateTimeFormat;
                if (CAEResponse.Resultado != 1)
                {
                    respuesta += "CAE Inválido o alguno de los datos solicitados no fueron ingresados correctamente.";
                    if (CAEResponse.RError != null)
                    {
                        if (CAEResponse.RError.percode != 0)
                        {
                            respuesta += " Cod.: " + CAEResponse.RError.perrmsg + "  ";
                        }
                        if (CAEResponse.RError.perrmsg.ToUpper() != "OK" && CAEResponse.RError.perrmsg != "")
                        {
                            
                            respuesta += " Msg.: " + CAEResponse.RError.perrmsg + "  ";
                        }
                    }
                }
                else
                {
                    respuesta += "CAE Válido";
                }
                return respuesta;
 
                //if (cr.RError.perrmsg == "OK")
                //{
                //    MessageBox.Show("Consulta concluida satisfactoriamente.", "Información", MessageBoxButtons.OK);
                //    resultadoTextBox.Text = "El resultado es: " + cr.Resultado.ToString();
                //    estadoTextBox.Text = cr.RError.percode + " - " + cr.RError.perrmsg;
                //}
                //else
                //{
                //    MessageBox.Show("Consulta concluida con error.", "Información", MessageBoxButtons.OK);
                //    resultadoTextBox.Text = "";
                //    estadoTextBox.Text = cr.RError.percode + " - " + cr.RError.perrmsg;
                //}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static void SerializarC(out string LoteXML, ar.gov.afip.wsfev1.FECAERequest Lc)
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
        public static void SerializarCExpo(out string LoteXML, ar.gov.afip.wsfexv1.ClsFEXRequest Lc)
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
        public static string ByteArrayToString(byte[] characters)
        {
            System.Text.Encoding e = System.Text.Encoding.GetEncoding("ISO-8859-1");
            String constructedString = e.GetString(characters);
            return (constructedString);
        }
    }
}
