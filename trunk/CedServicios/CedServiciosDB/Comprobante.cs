﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Comprobante : db
    {
        public Comprobante(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public void Leer(Entidades.Comprobante Comprobante)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("Comprobante.Cuit, Comprobante.IdTipoComprobante, Comprobante.DescrTipoComprobante, Comprobante.NroPuntoVta, Comprobante.NroComprobante, Comprobante.NroLote, Comprobante.IdTipoDoc, Comprobante.NroDoc, Comprobante.IdCliente, Comprobante.DesambiguacionCuitPais, Comprobante.RazonSocial, Comprobante.Detalle, Comprobante.Fecha, Comprobante.FechaVto, Comprobante.Moneda, Comprobante.ImporteMoneda, Comprobante.TipoCambio, Comprobante.Importe, Comprobante.Request, Comprobante.Response, Comprobante.IdDestinoComprobante, Comprobante.IdWF, Comprobante.Estado, Comprobante.UltActualiz ");
            a.Append("from Comprobante ");
            a.Append("where Comprobante.Cuit='" + sesion.Cuit.Nro + "' and Comprobante.IdTipoComprobante=" + Comprobante.TipoComprobante.Id.ToString() + " and Comprobante.NroPuntoVta=" + Comprobante.NroPuntoVta.ToString() + "and Comprobante.NroComprobante=" + Comprobante.Nro.ToString() + " ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], Comprobante);
            }
        }
        private void Copiar(DataRow Desde, Entidades.Comprobante Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.TipoComprobante.Id = Convert.ToInt32(Desde["IdTipoComprobante"]);
            Hasta.TipoComprobante.Descr = Convert.ToString(Desde["DescrTipoComprobante"]);
            Hasta.NroPuntoVta = Convert.ToInt32(Desde["NroPuntoVta"]);
            Hasta.Nro = Convert.ToInt64(Desde["NroComprobante"]);
            Hasta.NroLote = Convert.ToInt64(Desde["NroLote"]);
            Hasta.Documento.Tipo.Id = Convert.ToString(Desde["IdTipoDoc"]);
			FeaEntidades.Documentos.Documento tipoDocumento = FeaEntidades.Documentos.Documento.Lista().Find(delegate(FeaEntidades.Documentos.Documento d)
			{
				return Hasta.Documento.Tipo.Id == d.Codigo.ToString();
			});
			if (tipoDocumento != null)
			{
                Hasta.Documento.Tipo.Descr = tipoDocumento.Descr;
            }
            else
            {
                Hasta.Documento.Tipo.Descr = "Desconocido";
            }
            Hasta.Documento.Nro = Convert.ToInt64(Desde["NroDoc"]);
            Hasta.IdCliente = Convert.ToString(Desde["IdCliente"]);
            Hasta.DesambiguacionCuitPais = Convert.ToInt32(Desde["DesambiguacionCuitPais"]);
            Hasta.RazonSocial = Convert.ToString(Desde["RazonSocial"]);
            Hasta.Detalle = Convert.ToString(Desde["Detalle"]);
            Hasta.Fecha = Convert.ToDateTime(Desde["Fecha"]);
            Hasta.FechaVto = Convert.ToDateTime(Desde["FechaVto"]);
            Hasta.Moneda = Convert.ToString(Desde["Moneda"]);
            Hasta.ImporteMoneda = Convert.ToDouble(Desde["ImporteMoneda"]);
            Hasta.TipoCambio = Convert.ToDouble(Desde["TipoCambio"]);
            Hasta.Importe = Convert.ToDouble(Desde["Importe"]);
            Hasta.Request = Convert.ToString(Desde["Request"]);
            Hasta.Response = Convert.ToString(Desde["Response"]);
            Hasta.IdDestinoComprobante = Convert.ToString(Desde["IdDestinoComprobante"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
        }
        public void Crear(Entidades.Comprobante Comprobante)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert Comprobante (Comprobante.Cuit, Comprobante.IdTipoComprobante, Comprobante.DescrTipoComprobante, Comprobante.NroPuntoVta, Comprobante.NroComprobante, Comprobante.NroLote, Comprobante.IdTipoDoc, Comprobante.NroDoc, Comprobante.IdCliente, Comprobante.DesambiguacionCuitPais, Comprobante.RazonSocial, Comprobante.Detalle, Comprobante.Fecha, Comprobante.FechaVto, Comprobante.Moneda, Comprobante.ImporteMoneda, Comprobante.TipoCambio, Comprobante.Importe, Comprobante.Request, Comprobante.Response, Comprobante.IdDestinoComprobante, Comprobante.IdWF, Comprobante.Estado) values (");
            a.Append("'" + Comprobante.Cuit + "', ");
            a.Append(Comprobante.TipoComprobante.Id.ToString() + ", ");
            a.Append("'" + Comprobante.TipoComprobante.Descr + "', ");
            a.Append(Comprobante.NroPuntoVta.ToString() + ", ");
            a.Append(Comprobante.Nro.ToString() + "', ");
            a.Append(Comprobante.NroLote.ToString() + ", ");
            a.Append("'" + Comprobante.Documento.Tipo.Id + "', ");
            a.Append(Comprobante.Documento.Nro.ToString() + ", ");
            a.Append("'" + Comprobante.IdCliente + "', ");
            a.Append(Comprobante.DesambiguacionCuitPais.ToString() + ", ");
            a.Append("'" + Comprobante.RazonSocial + "', ");
            a.Append("'" + Comprobante.Detalle + "', ");
            a.Append("'" + Comprobante.Fecha.ToString("yyyyMMdd") + "', ");
            a.Append("'" + Comprobante.FechaVto.ToString("yyyyMMdd") + "', ");
            a.Append("'" + Comprobante.Moneda + "', ");
            a.Append("'" + Comprobante.ImporteMoneda.ToString("0000000000000.00") + "', ");
            a.Append("'" + Comprobante.TipoCambio.ToString("0000.000000") + "', ");
            a.Append("'" + Comprobante.Importe.ToString("0000000000000.00") + "', ");
            a.Append("'" + Comprobante.Request + "', ");
            a.Append("'" + Comprobante.Response + "', ");
            a.Append("'" + Comprobante.IdDestinoComprobante + "', ");
            a.Append("@idWF, ");
            a.Append("'" + Comprobante.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Comprobante', 'Alta', '" + Comprobante.WF.Estado + "', '') ");
            a.AppendLine();
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Crear(FeaEntidades.InterFacturas.lote_comprobantes Lote, Object Response, string IdDestinoComprobante)
        {
            Entidades.Comprobante comprobante = new Entidades.Comprobante();
            comprobante.Cuit = Lote.cabecera_lote.cuit_vendedor.ToString();
            comprobante.TipoComprobante.Id = Lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
            FeaEntidades.TiposDeComprobantes.TipoComprobante tipoComprobante = FeaEntidades.TiposDeComprobantes.TipoComprobante.Lista().Find(delegate(FeaEntidades.TiposDeComprobantes.TipoComprobante d) { return comprobante.TipoComprobante.Id.ToString() == d.Codigo.ToString(); });
            if (tipoComprobante != null)
            {
                comprobante.TipoComprobante.Descr = tipoComprobante.Descr;
            }
            else
            {
                comprobante.TipoComprobante.Descr = "Desconocido";
            }
            comprobante.NroPuntoVta = Lote.comprobante[0].cabecera.informacion_comprobante.punto_de_venta;
            comprobante.Nro = Lote.comprobante[0].cabecera.informacion_comprobante.numero_comprobante;
            comprobante.NroLote = Lote.cabecera_lote.id_lote;
            comprobante.Documento.Tipo.Id = Lote.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString();
            FeaEntidades.Documentos.Documento tipoDocumento = FeaEntidades.Documentos.Documento.Lista().Find(delegate(FeaEntidades.Documentos.Documento d) {return comprobante.Documento.Tipo.Id == d.Codigo.ToString();});
            if (tipoDocumento != null)
            {
                comprobante.Documento.Tipo.Descr = tipoDocumento.Descr;
            }
            else
            {
                comprobante.Documento.Tipo.Descr = "Desconocido";
            }
            comprobante.Documento.Nro = Lote.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio;
            //comprobante.IdCliente
            //comprobante.DesambiguacionCuitPais
            comprobante.RazonSocial = Lote.comprobante[0].cabecera.informacion_comprador.denominacion;
            //comprobante.Detalle
            comprobante.Fecha = Funciones.ConvertirFechaStringAAAAMMDDaDatetime(Lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
            comprobante.FechaVto = Funciones.ConvertirFechaStringAAAAMMDDaDatetime(Lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);
            comprobante.Moneda = Lote.comprobante[0].resumen.codigo_moneda;
            comprobante.ImporteMoneda = Lote.comprobante[0].resumen.importes_moneda_origen.importe_total_factura;
            comprobante.TipoCambio = Lote.comprobante[0].resumen.tipo_de_cambio;
            comprobante.Importe = Lote.comprobante[0].resumen.importe_total_factura;
            comprobante.Request = Funciones.ObjetoSerializado(Lote);
            comprobante.Response = Funciones.ObjetoSerializado(Response);
            comprobante.IdDestinoComprobante = IdDestinoComprobante;
            Crear(comprobante);
        }
    }
}