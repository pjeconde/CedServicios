using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedServicios.RN
{
    public class ComprobanteAFIP
    {
        static Entidades.Sesion sesion;
        static ar.gov.afip.wsw.FEResponse objFEResponse;
        static LoginTicket ticket;
        static ar.gov.afip.wsw.Service objWS;
        static ar.gov.afip.wsfev1.Service objWSFEV1;
        
        private static void CrearTicket()
        {
            ticket = new LoginTicket();
            string RutaCertificado = System.Web.HttpContext.Current.Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["RutaCertificadoAFIP"] + sesion.Cuit.Nro + ".p12");
            ticket.ObtenerTicket(RutaCertificado, Convert.ToInt64(sesion.Cuit.Nro));
            objWS = new ar.gov.afip.wsw.Service();
            objWS.Url = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsw_Service"];
            objWS.Proxy = ticket.Wp;
            objWSFEV1 = new ar.gov.afip.wsfev1.Service();
            objWSFEV1.Url = System.Configuration.ConfigurationManager.AppSettings["ar_gov_afip_wsfev1_Service"];
            objWSFEV1.Proxy = ticket.Wp;
        }
        public static string EnviarAFIP(FeaEntidades.InterFacturas.lote_comprobantes lc, Entidades.Sesion Sesion)
        {
            try
            {
                sesion = Sesion;
                CrearTicket();
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

                objFEDetalleRequest.ImpNeto = lc.comprobante[0].resumen.importe_total_neto_gravado;                         // Comprobante.Imp_neto;
                objFEDetalleRequest.ImpOpEx = lc.comprobante[0].resumen.importe_operaciones_exentas;                        // Comprobante.Imp_op_ex;
                objFEDetalleRequest.ImpTotConc = lc.comprobante[0].resumen.importe_total_concepto_no_gravado;               // Comprobante.Imp_tot_conc;
                objFEDetalleRequest.ImpTotal = lc.comprobante[0].resumen.importe_total_factura;                             // Comprobante.Imp_total;
                objFEDetalleRequest.ImpIVA = lc.comprobante[0].resumen.impuesto_liq;                                        // Comprobante.Impto_liq;
                objFEDetalleRequest.impto_liq_rni = lc.comprobante[0].resumen.impuesto_liq_rni;                             // Comprobante.Impto_liq_rni;
                
                objFEDetalleRequest.ImpTrib = 0; //Total de tributos;
                objFEDetalleRequest.DocNro = lc.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio;      // Comprobante.Nro_doc;
                //objFEDetalleRequest.punto_vta = Comprobante.PuntoVenta;
                //objFEDetalleRequest.tipo_cbte = Comprobante.Codigo;
                objFEDetalleRequest.DocTipo = lc.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio;  // Comprobante.TipoDoc;
                objFEDetalleRequest.MonId = lc.comprobante[0].resumen.codigo_moneda;
                objFEDetalleRequest.MonCotiz = lc.comprobante[0].resumen.tipo_de_cambio;

                if (lc.comprobante[0].resumen.impuestos.Length > 0)
                {
                    ar.gov.afip.wsfev1.AlicIva[] ivas = new ar.gov.afip.wsfev1.AlicIva[lc.comprobante[0].resumen.impuestos.Length];
                    for (int j = 0; j < lc.comprobante[0].resumen.impuestos.Length; j++)
                    {
                        if (lc.comprobante[0].resumen.impuestos[j].codigo_impuesto == 1)
                        {
                            double baseImponible = 0;
                            ivas[j] = new ar.gov.afip.wsfev1.AlicIva();
                            ivas[j].BaseImp = lc.comprobante[0].resumen.impuestos[j].base_imponible;
                            if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 10.5)
                            {
                                if (ivas[j].BaseImp == 0)
                                {
                                    for (int k = 0; k < lc.comprobante[0].detalle.linea.Length; k++)
                                    {
                                        if (lc.comprobante[0].detalle.linea[k] == null) { break; }
                                        if (lc.comprobante[0].detalle.linea[k].alicuota_iva == 10.5)
                                        {
                                            baseImponible +=  Math.Round(lc.comprobante[0].detalle.linea[k].precio_unitario * lc.comprobante[0].detalle.linea[k].cantidad, 2); 
                                        }
                                        if (Math.Round(lc.comprobante[0].detalle.linea[k].precio_unitario * lc.comprobante[0].detalle.linea[k].cantidad, 2) == 0)
                                        {
                                            baseImponible += lc.comprobante[0].detalle.linea[k].importe_total_articulo;
                                        }
                                    }
                                }
                                ivas[j].BaseImp = baseImponible;
                                ivas[j].Id = 4;
                            }
                            else if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 21)
                            {
                                if (ivas[j].BaseImp == 0)
                                {
                                    for (int k = 0; k < lc.comprobante[0].detalle.linea.Length; k++)
                                    {
                                        if (lc.comprobante[0].detalle.linea[k] == null) { break; }
                                        if (lc.comprobante[0].detalle.linea[k].alicuota_iva == 21)
                                        {
                                            baseImponible += Math.Round(lc.comprobante[0].detalle.linea[k].precio_unitario * lc.comprobante[0].detalle.linea[k].cantidad, 2);
                                        }
                                        if (Math.Round(lc.comprobante[0].detalle.linea[k].precio_unitario * lc.comprobante[0].detalle.linea[k].cantidad, 2) == 0)
                                        {
                                            baseImponible += lc.comprobante[0].detalle.linea[k].importe_total_articulo;
                                        }
                                    }
                                }
                                ivas[j].BaseImp = baseImponible;
                                ivas[j].Id = 5;
                            }
                            else if (lc.comprobante[0].resumen.impuestos[j].porcentaje_impuesto == 27)
                            {
                                if (ivas[j].BaseImp == 0)
                                {
                                    for (int k = 0; k < lc.comprobante[0].detalle.linea.Length; k++)
                                    {
                                        if (lc.comprobante[0].detalle.linea[k] == null) { break; }
                                        if (lc.comprobante[0].detalle.linea[k].alicuota_iva == 27)
                                        {
                                            baseImponible += Math.Round(lc.comprobante[0].detalle.linea[k].precio_unitario * lc.comprobante[0].detalle.linea[k].cantidad, 2);
                                        }
                                        if (Math.Round(lc.comprobante[0].detalle.linea[k].precio_unitario * lc.comprobante[0].detalle.linea[k].cantidad, 2) == 0)
                                        {
                                            baseImponible += lc.comprobante[0].detalle.linea[k].importe_total_articulo;
                                        }
                                    }
                                }
                                ivas[j].BaseImp = baseImponible;
                                ivas[j].Id = 6;
                            }
                            ivas[j].Importe = lc.comprobante[0].resumen.impuestos[j].importe_impuesto;
                        }
                    }
                    if (ivas != null && ivas.Length > 0)
                    {
                        objFEDetalleRequest.Iva = ivas;
                    }
                }

                arrayFEDetalleRequest[0] = objFEDetalleRequest;
                //for (int c = 0; c < CantidadComprobantes; c++)
                //{
                    //Comprobante.IdComprobante = Comprobante.IdComprobante + 1;
                    objFEDetalleRequest.CbteDesde = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;  //Comprobante.IdComprobante;
                    objFEDetalleRequest.CbteHasta = lc.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;  //Comprobante.IdComprobante;
                    arrayFEDetalleRequest[0] = objFEDetalleRequest;
                //}
                objFERequest.FeDetReq = arrayFEDetalleRequest;

                ar.gov.afip.wsfev1.FECAEResponse objFEResponse = new ar.gov.afip.wsfev1.FECAEResponse();
                objFEResponse = objWSFEV1.FECAESolicitar(ticket.ObjAutorizacionfev1, objFERequest);

                string respuesta = "";
                if (objFEResponse.Errors == null)
                {
                    if (objFEResponse.FeCabResp.Resultado == "A")
                    {
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
                        }
                    }
                    else if (objFEResponse.FeCabResp.Resultado == "R")
                    {
                        for (int i = 0; i < objFEResponse.FeDetResp.Length; i++)
                        {
                            respuesta += "Resultado: " + objFEResponse.FeDetResp[i].Resultado + "\\n";
                            for (int j = 0; j < objFEResponse.FeDetResp[i].Observaciones.Length; j++)
                            {
                                respuesta += objFEResponse.FeDetResp[i].Observaciones[j].Code.ToString() + "-" + objFEResponse.FeDetResp[i].Observaciones[j].Msg + "\\n";
                            }
                            respuesta += "CAE: " + objFEResponse.FeDetResp[i].CAE;
                        }
                    }
                    else
                    {
                        respuesta += "No se pudo obtener el mensaje de respuesta del método (FECAESolicitar).";
                    }
                }
                else
                {
                    for (int i = 0; i < objFEResponse.Errors.Length; i++)
                    {
                        respuesta += objFEResponse.Errors[i].Code + "-" + objFEResponse.Errors[i].Msg + ". ";
                    }
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
                sesion = Sesion;
                CrearTicket();
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
                sesion = Sesion;
                CrearTicket();
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
                    respuesta += DB.Funciones.ObjetoSerializado(objFECompConsultaResponse.Errors);
                }
                else
                {
                    respuesta += DB.Funciones.ObjetoSerializado(objFECompConsultaResponse.ResultGet);
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
