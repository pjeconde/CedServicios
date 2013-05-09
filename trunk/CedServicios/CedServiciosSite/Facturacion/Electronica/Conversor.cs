using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedServicios.Site.Facturacion.Electronica
{
    public class Conversor
    {
        static internal org.dyndns.cedweb.envio.lc Entidad2IBK(FeaEntidades.InterFacturas.lote_comprobantes lc)
        {
            org.dyndns.cedweb.envio.lc lcWS = new global::CedServicios.Site.org.dyndns.cedweb.envio.lc();

            lcWS.cabecera_lote = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcCabecera_lote();
            lcWS.cabecera_lote.cantidad_reg = lc.cabecera_lote.cantidad_reg;
            lcWS.cabecera_lote.cod_interno_canal = lc.cabecera_lote.cod_interno_canal;
            lcWS.cabecera_lote.cuit_canal = lc.cabecera_lote.cuit_canal;
            lcWS.cabecera_lote.cuit_vendedor = lc.cabecera_lote.cuit_vendedor;
            lcWS.cabecera_lote.fecha_envio_lote = lc.cabecera_lote.fecha_envio_lote;
            lcWS.cabecera_lote.id_lote = lc.cabecera_lote.id_lote;
            lcWS.cabecera_lote.motivo = lc.cabecera_lote.motivo;
            lcWS.cabecera_lote.presta_serv = lc.cabecera_lote.presta_serv;
            lcWS.cabecera_lote.presta_servSpecified = lc.cabecera_lote.presta_servSpecified;
            lcWS.cabecera_lote.punto_de_venta = lc.cabecera_lote.punto_de_venta;
            lcWS.cabecera_lote.resultado = lc.cabecera_lote.resultado;

            lcWS.comprobante = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobante[lc.comprobante.Length];

            for (int i = 0; i < lc.comprobante.Length; i++)
            {
                if (lc.comprobante[i] == null)
                {
                    break;
                }
                org.dyndns.cedweb.envio.lcComprobante cIBK = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobante();

                cIBK.cabecera = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteCabecera();

                cIBK.cabecera.informacion_comprador = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteCabeceraInformacion_comprador();
                cIBK.cabecera.informacion_comprador.codigo_doc_identificatorio = lc.comprobante[i].cabecera.informacion_comprador.codigo_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.codigo_interno = lc.comprobante[i].cabecera.informacion_comprador.codigo_interno;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutos = lc.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.condicion_ingresos_brutosSpecified = lc.comprobante[i].cabecera.informacion_comprador.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_comprador.condicion_IVA = lc.comprobante[i].cabecera.informacion_comprador.condicion_IVA;
                cIBK.cabecera.informacion_comprador.condicion_IVASpecified = lc.comprobante[i].cabecera.informacion_comprador.condicion_IVASpecified;
                cIBK.cabecera.informacion_comprador.contacto = lc.comprobante[i].cabecera.informacion_comprador.contacto;
                cIBK.cabecera.informacion_comprador.cp = lc.comprobante[i].cabecera.informacion_comprador.cp;
                cIBK.cabecera.informacion_comprador.denominacion = lc.comprobante[i].cabecera.informacion_comprador.denominacion;
                cIBK.cabecera.informacion_comprador.domicilio_calle = lc.comprobante[i].cabecera.informacion_comprador.domicilio_calle;
                cIBK.cabecera.informacion_comprador.domicilio_depto = lc.comprobante[i].cabecera.informacion_comprador.domicilio_depto;
                cIBK.cabecera.informacion_comprador.domicilio_manzana = lc.comprobante[i].cabecera.informacion_comprador.domicilio_manzana;
                cIBK.cabecera.informacion_comprador.domicilio_numero = lc.comprobante[i].cabecera.informacion_comprador.domicilio_numero;
                cIBK.cabecera.informacion_comprador.domicilio_piso = lc.comprobante[i].cabecera.informacion_comprador.domicilio_piso;
                cIBK.cabecera.informacion_comprador.domicilio_sector = lc.comprobante[i].cabecera.informacion_comprador.domicilio_sector;
                cIBK.cabecera.informacion_comprador.domicilio_torre = lc.comprobante[i].cabecera.informacion_comprador.domicilio_torre;
                cIBK.cabecera.informacion_comprador.email = lc.comprobante[i].cabecera.informacion_comprador.email;
                cIBK.cabecera.informacion_comprador.GLN = lc.comprobante[i].cabecera.informacion_comprador.GLN;
                cIBK.cabecera.informacion_comprador.GLNSpecified = lc.comprobante[i].cabecera.informacion_comprador.GLNSpecified;
                cIBK.cabecera.informacion_comprador.inicio_de_actividades = lc.comprobante[i].cabecera.informacion_comprador.inicio_de_actividades;
                cIBK.cabecera.informacion_comprador.localidad = lc.comprobante[i].cabecera.informacion_comprador.localidad;
                cIBK.cabecera.informacion_comprador.nro_doc_identificatorio = lc.comprobante[i].cabecera.informacion_comprador.nro_doc_identificatorio;
                cIBK.cabecera.informacion_comprador.nro_ingresos_brutos = lc.comprobante[i].cabecera.informacion_comprador.nro_ingresos_brutos;
                cIBK.cabecera.informacion_comprador.provincia = lc.comprobante[i].cabecera.informacion_comprador.provincia;
                cIBK.cabecera.informacion_comprador.telefono = lc.comprobante[i].cabecera.informacion_comprador.telefono;

                cIBK.cabecera.informacion_comprobante = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteCabeceraInformacion_comprobante();
                cIBK.cabecera.informacion_comprobante.cae = lc.comprobante[i].cabecera.informacion_comprobante.cae;
                cIBK.cabecera.informacion_comprobante.codigo_operacion = lc.comprobante[i].cabecera.informacion_comprobante.codigo_operacion;
                cIBK.cabecera.informacion_comprobante.condicion_de_pago = lc.comprobante[i].cabecera.informacion_comprobante.condicion_de_pago;
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

                if (lc.comprobante[i].cabecera.informacion_comprobante.referencias != null)
                {
                    cIBK.cabecera.informacion_comprobante.referencias = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteCabeceraInformacion_comprobanteReferencias[lc.comprobante[i].cabecera.informacion_comprobante.referencias.Length];

                    for (int j = 0; j < lc.comprobante[i].cabecera.informacion_comprobante.referencias.Length; j++)
                    {
                        if (lc.comprobante[i].cabecera.informacion_comprobante.referencias[j] != null)
                        {
                            cIBK.cabecera.informacion_comprobante.referencias[j] = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteCabeceraInformacion_comprobanteReferencias();
                            cIBK.cabecera.informacion_comprobante.referencias[j].codigo_de_referencia = lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].codigo_de_referencia;
                            cIBK.cabecera.informacion_comprobante.referencias[j].dato_de_referencia = lc.comprobante[i].cabecera.informacion_comprobante.referencias[j].dato_de_referencia;
                        }
                    }
                }

                cIBK.cabecera.informacion_comprobante.resultado = lc.comprobante[i].cabecera.informacion_comprobante.resultado;
                cIBK.cabecera.informacion_comprobante.tipo_de_comprobante = lc.comprobante[i].cabecera.informacion_comprobante.tipo_de_comprobante;

                cIBK.cabecera.informacion_vendedor = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteCabeceraInformacion_vendedor();
                cIBK.cabecera.informacion_vendedor.codigo_interno = lc.comprobante[i].cabecera.informacion_vendedor.codigo_interno;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutos = lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified = lc.comprobante[i].cabecera.informacion_vendedor.condicion_ingresos_brutosSpecified;
                cIBK.cabecera.informacion_vendedor.condicion_IVA = lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVA;
                cIBK.cabecera.informacion_vendedor.condicion_IVASpecified = lc.comprobante[i].cabecera.informacion_vendedor.condicion_IVASpecified;
                cIBK.cabecera.informacion_vendedor.contacto = lc.comprobante[i].cabecera.informacion_vendedor.contacto;
                cIBK.cabecera.informacion_vendedor.cp = lc.comprobante[i].cabecera.informacion_vendedor.cp;
                cIBK.cabecera.informacion_vendedor.cuit = lc.comprobante[i].cabecera.informacion_vendedor.cuit;
                cIBK.cabecera.informacion_vendedor.domicilio_calle = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_calle;
                cIBK.cabecera.informacion_vendedor.domicilio_depto = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_depto;
                cIBK.cabecera.informacion_vendedor.domicilio_manzana = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_manzana;
                cIBK.cabecera.informacion_vendedor.domicilio_numero = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_numero;
                cIBK.cabecera.informacion_vendedor.domicilio_piso = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_piso;
                cIBK.cabecera.informacion_vendedor.domicilio_sector = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_sector;
                cIBK.cabecera.informacion_vendedor.domicilio_torre = lc.comprobante[i].cabecera.informacion_vendedor.domicilio_torre;
                cIBK.cabecera.informacion_vendedor.email = lc.comprobante[i].cabecera.informacion_vendedor.email;
                cIBK.cabecera.informacion_vendedor.GLN = lc.comprobante[i].cabecera.informacion_vendedor.GLN;
                cIBK.cabecera.informacion_vendedor.GLNSpecified = lc.comprobante[i].cabecera.informacion_vendedor.GLNSpecified;
                cIBK.cabecera.informacion_vendedor.inicio_de_actividades = lc.comprobante[i].cabecera.informacion_vendedor.inicio_de_actividades;
                cIBK.cabecera.informacion_vendedor.localidad = lc.comprobante[i].cabecera.informacion_vendedor.localidad;
                cIBK.cabecera.informacion_vendedor.nro_ingresos_brutos = lc.comprobante[i].cabecera.informacion_vendedor.nro_ingresos_brutos;
                cIBK.cabecera.informacion_vendedor.provincia = lc.comprobante[i].cabecera.informacion_vendedor.provincia;
                cIBK.cabecera.informacion_vendedor.telefono = lc.comprobante[i].cabecera.informacion_vendedor.telefono;

                org.dyndns.cedweb.envio.lcComprobanteDetalle d = new org.dyndns.cedweb.envio.lcComprobanteDetalle();
                FeaEntidades.InterFacturas.detalle detalle = lc.comprobante[i].detalle;
                d.linea = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteDetalleLinea[detalle.linea.Length];
                d.comentarios = detalle.comentarios;
                for (int j = 0; j < detalle.linea.Length; j++)
                {
                    if (detalle.linea[j] != null)
                    {
                        d.linea[j] = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteDetalleLinea();
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
                            d.linea[j].importes_moneda_origen = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteDetalleLineaImportes_moneda_origen();
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
                            d.linea[j].impuestos = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteDetalleLineaImpuestos[detalle.linea[j].impuestos.Length];
                            for (int k = 0; k < d.linea[j].impuestos.Length; k++)
                            {
                                d.linea[j].impuestos[k] = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteDetalleLineaImpuestos();
                                d.linea[j].impuestos[k].codigo_impuesto = detalle.linea[j].impuestos[k].codigo_impuesto;
                                d.linea[j].impuestos[k].descripcion_impuesto = detalle.linea[j].impuestos[k].descripcion_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto = detalle.linea[j].impuestos[k].importe_impuesto;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origen = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origen;
                                d.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified = detalle.linea[j].impuestos[k].importe_impuesto_moneda_origenSpecified;
                                d.linea[j].impuestos[k].porcentaje_impuesto = detalle.linea[j].impuestos[k].porcentaje_impuesto;
                                d.linea[j].impuestos[k].porcentaje_impuestoSpecified = detalle.linea[j].impuestos[k].porcentaje_impuestoSpecified;
                            }
                        }
                        if (detalle.linea[j].lineaDescuentos != null)
                        {
                            d.linea[j].descuentos = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteDetalleLineaDescuentos[detalle.linea[j].lineaDescuentos.Length];
                            for (int k = 0; k < d.linea[j].descuentos.Length; k++)
                            {
								if (d.linea[j].descuentos[k] != null)
								{
									d.linea[j].descuentos[k] = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteDetalleLineaDescuentos();
									d.linea[j].descuentos[k].descripcion_descuento = detalle.linea[j].lineaDescuentos[k].descripcion_descuento;
                                    d.linea[j].descuentos[k].importe_descuento = detalle.linea[j].lineaDescuentos[k].importe_descuento;
                                    d.linea[j].descuentos[k].importe_descuento_moneda_origen = detalle.linea[j].lineaDescuentos[k].importe_descuento_moneda_origen;
                                    d.linea[j].descuentos[k].importe_descuento_moneda_origenSpecified = detalle.linea[j].lineaDescuentos[k].importe_descuento_moneda_origenSpecified;
                                    d.linea[j].descuentos[k].porcentaje_descuento = detalle.linea[j].lineaDescuentos[k].porcentaje_descuento;
                                    d.linea[j].descuentos[k].porcentaje_descuentoSpecified = detalle.linea[j].lineaDescuentos[k].porcentaje_descuentoSpecified;
								}
								else
								{
									break;
								}
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
                if (lc.comprobante[i].extensiones != null)
                {
                    cIBK.extensiones = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteExtensiones();
                    if (lc.comprobante[i].extensiones.extensiones_camara_facturas != null)
                    {
                        cIBK.extensiones.extensiones_camara_facturas = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteExtensionesExtensiones_camara_facturas();
                        if (lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion != null)
                        {
                            cIBK.extensiones.extensiones_camara_facturas.clave_de_vinculacion = lc.comprobante[i].extensiones.extensiones_camara_facturas.clave_de_vinculacion.Trim();
                        }
                        cIBK.extensiones.extensiones_camara_facturas.id_idioma = lc.comprobante[i].extensiones.extensiones_camara_facturas.id_idioma.Trim();
                        if (lc.comprobante[i].extensiones.extensiones_camara_facturas.id_template != null)
                        {
                            cIBK.extensiones.extensiones_camara_facturas.id_template = lc.comprobante[i].extensiones.extensiones_camara_facturas.id_template.Trim();
                        }
                    }
                    if (lc.comprobante[i].extensiones.extensiones_datos_comerciales != null && lc.comprobante[i].extensiones.extensiones_datos_comerciales != "")
                    {
                        cIBK.extensiones.extensiones_datos_comerciales = lc.comprobante[i].extensiones.extensiones_datos_comerciales;
                    }
                    if (lc.comprobante[i].extensiones.extensiones_datos_marketing != null && lc.comprobante[i].extensiones.extensiones_datos_marketing != "")
                    {
                        cIBK.extensiones.extensiones_datos_marketing = lc.comprobante[i].extensiones.extensiones_datos_marketing;
                    }
                    if (lc.comprobante[i].extensiones.extensiones_signatures != null && lc.comprobante[i].extensiones.extensiones_signatures != "")
                    {
                        cIBK.extensiones.extensiones_signatures = lc.comprobante[i].extensiones.extensiones_signatures;
                    }
                    if (lc.comprobante[i].extensiones.extensiones_destinatarios != null && lc.comprobante[i].extensiones.extensiones_destinatarios.email != "")
                    {
                        cIBK.extensiones.extensiones_destinatarios = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteExtensionesExtensiones_destinatarios();
                        cIBK.extensiones.extensiones_destinatarios.email = lc.comprobante[i].extensiones.extensiones_destinatarios.email.Trim();
                    }
                }

                cIBK.resumen = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteResumen();
                cIBK.resumen.cant_alicuotas_iva = lc.comprobante[i].resumen.cant_alicuotas_iva;
                cIBK.resumen.cant_alicuotas_ivaSpecified = lc.comprobante[i].resumen.cant_alicuotas_ivaSpecified;
                cIBK.resumen.codigo_moneda = lc.comprobante[i].resumen.codigo_moneda;

                cIBK.resumen.descuentos = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteResumenDescuentos[0];

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
                    cIBK.resumen.importes_moneda_origen = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteResumenImportes_moneda_origen();
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
                    cIBK.resumen.descuentos = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteResumenDescuentos[lc.comprobante[i].resumen.descuentos.Length];
                    for (int l = 0; l < lc.comprobante[i].resumen.descuentos.Length; l++)
                    {
                        if (lc.comprobante[i].resumen.descuentos[l] != null)
                        {
                            cIBK.resumen.descuentos[l] = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteResumenDescuentos();
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
                        }
                    }
                }

                if (lc.comprobante[i].resumen.impuestos != null)
                {
                    cIBK.resumen.impuestos = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteResumenImpuestos[lc.comprobante[i].resumen.impuestos.Length];
                    for (int l = 0; l < lc.comprobante[i].resumen.impuestos.Length; l++)
                    {
                        if (lc.comprobante[i].resumen.impuestos[l] != null)
                        {
                            cIBK.resumen.impuestos[l] = new global::CedServicios.Site.org.dyndns.cedweb.envio.lcComprobanteResumenImpuestos();
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
                lcWS.comprobante[i] = cIBK;
            }
            return lcWS;
        }

        private static string ConvertToHex(string asciiString)
        {
            asciiString = PonerEntityName(asciiString);
            byte[] b = Encoding.ASCII.GetBytes(asciiString);
            string salida = "";
            for (int i = 0; i < b.Length; i++)
            {
                string ascii = b[i].ToString();
                int n = Convert.ToInt32(ascii);
                string r = n.ToString("x");
                salida += "%" + r;
            }
            return salida;
        }
        private static string PonerEntityName(string texto)
        {
            texto = texto.Replace("á", "&aacute;");
            texto = texto.Replace("é", "&eacute;");
            texto = texto.Replace("í", "&iacute;");
            texto = texto.Replace("ó", "&oacute;");
            texto = texto.Replace("ú", "&uacute;");
            texto = texto.Replace("º", "&ordm;");
            texto = texto.Replace("à", "&agrave;");
            texto = texto.Replace("è", "&egrave;");
            texto = texto.Replace("ì", "&igrave;");
            texto = texto.Replace("ò", "&ograve;");
            texto = texto.Replace("ù", "&ugrave;");
            texto = texto.Replace("ñ", "&ntilde;");
            texto = texto.Replace("$", "&#36");
            //Mayúsculas
            texto = texto.Replace("Á", "&Aacute;");
            texto = texto.Replace("É", "&Eacute;");
            texto = texto.Replace("Í", "&Iacute;");
            texto = texto.Replace("Ó", "&Oacute;");
            texto = texto.Replace("Ú", "&Uacute;");
            texto = texto.Replace("À", "&Agrave;");
            texto = texto.Replace("È", "&Egrave;");
            texto = texto.Replace("Ì", "&Igrave;");
            texto = texto.Replace("Ò", "&Ograve;");
            texto = texto.Replace("Ù", "&Ugrave;");
            texto = texto.Replace("Ñ", "&Ntilde;");
            return texto;
        }
        private static string HexToString(string Hex)
        {
            Hex = Hex.Replace("%", "");
            int numberChars = Hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(Hex.Substring(i, 2), 16);
            }
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            string str = enc.GetString(bytes);
            str = SacarEntityName(str);
            return str;
        }
        private static string SacarEntityName(string texto)
        {
            texto = texto.Replace("&aacute;", "á");
            texto = texto.Replace("&eacute;", "é");
            texto = texto.Replace("&iacute;", "í");
            texto = texto.Replace("&oacute;", "ó");
            texto = texto.Replace("&uacute;", "ú");
            texto = texto.Replace("&ordm;", "º");
            texto = texto.Replace("&agrave;", "à");
            texto = texto.Replace("&egrave;", "è");
            texto = texto.Replace("&igrave;", "ì");
            texto = texto.Replace("&ograve;", "ò");
            texto = texto.Replace("&ugrave;", "ù");
            texto = texto.Replace("&ntilde;", "ñ");
            texto = texto.Replace("&#36", "$");
            //Mayúsculas
            texto = texto.Replace("&Aacute;", "Á");
            texto = texto.Replace("&Eacute;", "É");
            texto = texto.Replace("&Iacute;", "Í");
            texto = texto.Replace("&Oacute;", "Ó");
            texto = texto.Replace("&Uacute;", "Ú");
            texto = texto.Replace("&Agrave;", "À");
            texto = texto.Replace("&Egrave;", "È");
            texto = texto.Replace("&Igrave;", "Ì");
            texto = texto.Replace("&Ograve;", "Ò");
            texto = texto.Replace("&Ugrave;", "Ù");
            texto = texto.Replace("&Ntilde;", "Ñ");
            return texto;
        }
    }
}
