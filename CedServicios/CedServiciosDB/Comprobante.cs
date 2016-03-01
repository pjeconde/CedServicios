using System;
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
        public List<Entidades.Comprobante> ListaContratosFiltrada(List<Entidades.Estado> Estados, string FechaEmision, Entidades.Persona Persona, string Moneda)
        {
            List<Entidades.Comprobante> lista = new List<Entidades.Comprobante>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Comprobante.Cuit, Comprobante.IdTipoComprobante, Comprobante.DescrTipoComprobante, Comprobante.NroPuntoVta, Comprobante.NroComprobante, Comprobante.NroLote, Comprobante.IdTipoDoc, Comprobante.NroDoc, Comprobante.IdPersona, Comprobante.DesambiguacionCuitPais, Comprobante.RazonSocial, Comprobante.Detalle, Comprobante.Fecha, Comprobante.FechaVto, Comprobante.Moneda, Comprobante.ImporteMoneda, Comprobante.TipoCambio, Comprobante.Importe, Comprobante.Request, Comprobante.Response, Comprobante.IdDestinoComprobante, Comprobante.IdWF, Comprobante.Estado, Comprobante.UltActualiz, Comprobante.IdNaturalezaComprobante, NaturalezaComprobante.DescrNaturalezaComprobante, Comprobante.PeriodicidadEmision, Comprobante.FechaProximaEmision, Comprobante.CantidadComprobantesAEmitir, Comprobante.CantidadComprobantesEmitidos, Comprobante.CantidadDiasFechaVto, Comprobante.EmailAvisoComprobanteActivo, Comprobante.IdDestinatarioFrecuente, Comprobante.EmailAvisoComprobanteAsunto, Comprobante.EmailAvisoComprobanteCuerpo ");
                a.Append("from Comprobante, NaturalezaComprobante ");
                a.Append("where Comprobante.Cuit='" + sesion.Cuit.Nro + "' ");
                a.Append("and Comprobante.IdNaturalezaComprobante=NaturalezaComprobante.IdNaturalezaComprobante ");
                string estados = String.Empty;
                for (int i = 0; i < Estados.Count; i++)
                {
                    estados += "'" + Estados[i].Id + "'";
                    if (i != (Estados.Count - 1)) estados += ", ";
                }
                if (estados != String.Empty)
                {
                    a.Append("and Comprobante.Estado in (" + estados + ") ");
                }
                if (FechaEmision != String.Empty)
                {
                    a.Append("and Comprobante.FechaProximaEmision<='" + FechaEmision + "' ");
                }
                if (Persona.Orden != 0)
                {
                    a.Append("and Comprobante.IdTipoDoc=" + Persona.Documento.Tipo.Id + " ");
                    a.Append("and Comprobante.NroDoc=" + Persona.Documento.Nro.ToString() + " ");
                    a.Append("and Comprobante.IdPersona='" + Persona.IdPersona + "' ");
                    a.Append("and Comprobante.DesambiguacionCuitPais=" + Persona.DesambiguacionCuitPais.ToString() + " ");
                }
                a.Append("and Comprobante.IdNaturalezaComprobante='VentaContrato' ");
                a.Append("and Comprobante.Moneda='" + Moneda + "' ");
                a.Append("order by Comprobante.DescrTipoComprobante desc, Comprobante.NroPuntoVta desc, Comprobante.NroComprobante desc ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Comprobante elem = new Entidades.Comprobante();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Comprobante> ListaFiltrada(List<Entidades.Estado> Estados, string FechaDesde, string FechaHasta, Entidades.Persona Persona, Entidades.NaturalezaComprobante NaturalezaComprobante, bool IncluirContratos, string Detalle)
        {
            List<Entidades.Comprobante> lista = new List<Entidades.Comprobante>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Comprobante.Cuit, Comprobante.IdTipoComprobante, Comprobante.DescrTipoComprobante, Comprobante.NroPuntoVta, Comprobante.NroComprobante, Comprobante.NroLote, Comprobante.IdTipoDoc, Comprobante.NroDoc, Comprobante.IdPersona, Comprobante.DesambiguacionCuitPais, Comprobante.RazonSocial, Comprobante.Detalle, Comprobante.Fecha, Comprobante.FechaVto, Comprobante.Moneda, Comprobante.ImporteMoneda, Comprobante.TipoCambio, Comprobante.Importe, Comprobante.Request, Comprobante.Response, Comprobante.IdDestinoComprobante, Comprobante.IdWF, Comprobante.Estado, Comprobante.UltActualiz, Comprobante.IdNaturalezaComprobante, NaturalezaComprobante.DescrNaturalezaComprobante, Comprobante.PeriodicidadEmision, Comprobante.FechaProximaEmision, Comprobante.CantidadComprobantesAEmitir, Comprobante.CantidadComprobantesEmitidos, Comprobante.CantidadDiasFechaVto, Comprobante.EmailAvisoComprobanteActivo, Comprobante.IdDestinatarioFrecuente, Comprobante.EmailAvisoComprobanteAsunto, Comprobante.EmailAvisoComprobanteCuerpo ");
                a.Append("from Comprobante, NaturalezaComprobante ");
                a.Append("where Comprobante.Cuit='" + sesion.Cuit.Nro + "' ");
                a.Append("and Comprobante.IdNaturalezaComprobante=NaturalezaComprobante.IdNaturalezaComprobante ");
                string estados = String.Empty;
                for (int i = 0; i < Estados.Count; i++)
                {
                    estados += "'" + Estados[i].Id + "'";
                    if (i != (Estados.Count - 1)) estados += ", ";
                }
                if (estados != String.Empty)
                {
                    a.Append("and Comprobante.Estado in (" + estados + ") ");
                }
                if (FechaDesde != String.Empty)
                {
                    a.Append("and Comprobante.Fecha>='" + FechaDesde + "' ");
                }
                if (FechaHasta != String.Empty)
                {
                    a.Append("and Comprobante.Fecha<='" + FechaHasta + "' ");
                }
                if (Persona.Orden != 0)
                {
                    a.Append("and Comprobante.IdTipoDoc=" + Persona.Documento.Tipo.Id + " ");
                    a.Append("and Comprobante.NroDoc=" + Persona.Documento.Nro.ToString() + " ");
                    a.Append("and Comprobante.IdPersona='" + Persona.IdPersona + "' ");
                    a.Append("and Comprobante.DesambiguacionCuitPais=" + Persona.DesambiguacionCuitPais.ToString() + " ");
                }
                if (NaturalezaComprobante.Id != String.Empty)
                {
                    a.Append("and Comprobante.IdNaturalezaComprobante='" + NaturalezaComprobante.Id + "' ");
                }
                else if (!IncluirContratos)
                {
                    a.Append("and Comprobante.IdNaturalezaComprobante<>'VentaContrato' ");
                }
                if (Detalle != string.Empty)
                {
                    a.Append("and Comprobante.Detalle like '%" + Detalle + "%' ");
                }
                a.Append("order by Comprobante.DescrTipoComprobante desc, Comprobante.NroPuntoVta desc, ABS(Comprobante.NroComprobante) desc ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Comprobante elem = new Entidades.Comprobante();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public void Leer(Entidades.Comprobante Comprobante)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("Comprobante.Cuit, Comprobante.IdTipoComprobante, Comprobante.DescrTipoComprobante, Comprobante.NroPuntoVta, Comprobante.NroComprobante, Comprobante.NroLote, Comprobante.IdTipoDoc, Comprobante.NroDoc, Comprobante.IdPersona, Comprobante.DesambiguacionCuitPais, Comprobante.RazonSocial, Comprobante.Detalle, Comprobante.Fecha, Comprobante.FechaVto, Comprobante.Moneda, Comprobante.ImporteMoneda, Comprobante.TipoCambio, Comprobante.Importe, Comprobante.Request, Comprobante.Response, Comprobante.IdDestinoComprobante, Comprobante.IdWF, Comprobante.Estado, Comprobante.UltActualiz, Comprobante.IdNaturalezaComprobante, NaturalezaComprobante.DescrNaturalezaComprobante, Comprobante.PeriodicidadEmision, Comprobante.FechaProximaEmision, Comprobante.CantidadComprobantesAEmitir, Comprobante.CantidadComprobantesEmitidos, Comprobante.CantidadDiasFechaVto, Comprobante.EmailAvisoComprobanteActivo, Comprobante.IdDestinatarioFrecuente, Comprobante.EmailAvisoComprobanteAsunto, Comprobante.EmailAvisoComprobanteCuerpo ");
            a.Append("from Comprobante, NaturalezaComprobante  ");
            a.Append("where Comprobante.Cuit='" + sesion.Cuit.Nro + "' and Comprobante.IdTipoComprobante=" + Comprobante.TipoComprobante.Id.ToString() + " and Comprobante.NroPuntoVta=" + Comprobante.NroPuntoVta.ToString() + " and Comprobante.NroComprobante=" + (Comprobante.NaturalezaComprobante.Id == "VentaContrato" ? -Comprobante.Nro : Comprobante.Nro).ToString() + " ");
            a.Append("and Comprobante.IdNaturalezaComprobante=NaturalezaComprobante.IdNaturalezaComprobante ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], Comprobante);
            }
        }
        public void Registrar(Entidades.Comprobante Comprobante)
        {
            Entidades.Comprobante comprobanteDesde = new Entidades.Comprobante();
            comprobanteDesde.Cuit = Comprobante.Cuit;
            comprobanteDesde.TipoComprobante = Comprobante.TipoComprobante;
            comprobanteDesde.NroPuntoVta = Comprobante.NroPuntoVta;
            comprobanteDesde.Nro = Comprobante.NaturalezaComprobante.Id == "VentaContrato" ? -Comprobante.Nro : Comprobante.Nro;
            Leer(comprobanteDesde);
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            if (comprobanteDesde.Documento.Tipo.Id == null)
            {
                a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
                a.AppendLine("Insert Comprobante (Comprobante.Cuit, Comprobante.IdTipoComprobante, Comprobante.DescrTipoComprobante, Comprobante.NroPuntoVta, Comprobante.NroComprobante, Comprobante.NroLote, Comprobante.IdTipoDoc, Comprobante.NroDoc, Comprobante.IdPersona, Comprobante.DesambiguacionCuitPais, Comprobante.RazonSocial, Comprobante.Detalle, Comprobante.Fecha, Comprobante.FechaVto, Comprobante.Moneda, Comprobante.ImporteMoneda, Comprobante.TipoCambio, Comprobante.Importe, Comprobante.Request, Comprobante.Response, Comprobante.IdDestinoComprobante, Comprobante.IdWF, Comprobante.Estado, Comprobante.IdNaturalezaComprobante, Comprobante.PeriodicidadEmision, Comprobante.FechaProximaEmision, Comprobante.CantidadComprobantesAEmitir, Comprobante.CantidadComprobantesEmitidos, Comprobante.CantidadDiasFechaVto, Comprobante.EmailAvisoComprobanteActivo, Comprobante.IdDestinatarioFrecuente, Comprobante.EmailAvisoComprobanteAsunto, Comprobante.EmailAvisoComprobanteCuerpo) ");
                a.Append("values (");
                a.Append("'" + Comprobante.Cuit + "', ");
                a.Append(Comprobante.TipoComprobante.Id.ToString() + ", ");
                a.Append("'" + Comprobante.TipoComprobante.Descr + "', ");
                a.Append(Comprobante.NroPuntoVta.ToString() + ", ");
                a.Append((Comprobante.NaturalezaComprobante.Id == "VentaContrato" ? -Comprobante.Nro : Comprobante.Nro).ToString() + ", ");
                a.Append(Comprobante.NroLote.ToString() + ", ");
                a.Append(Comprobante.Documento.Tipo.Id + ", ");
                a.Append(Comprobante.Documento.Nro.ToString() + ", ");
                if (Comprobante.IdPersona == null)
                {
                    a.Append("'', ");
                }
                else
                {
                    a.Append("'" + Comprobante.IdPersona + "', ");
                }
                a.Append(Comprobante.DesambiguacionCuitPais.ToString() + ", ");
                a.Append("'" + Comprobante.RazonSocial + "', ");
                if (Comprobante.Detalle == null)
                {
                    a.Append("'', ");
                }
                else
                {
                    a.Append("'" + Comprobante.Detalle + "', ");
                }
                a.Append("'" + Comprobante.Fecha.ToString("yyyyMMdd") + "', ");
                a.Append("'" + Comprobante.FechaVto.ToString("yyyyMMdd") + "', ");
                a.Append("'" + Comprobante.Moneda + "', ");
                a.Append(Comprobante.ImporteMoneda.ToString("0000000000000.00", System.Globalization.CultureInfo.InvariantCulture) + ", ");
                a.Append(Comprobante.TipoCambio.ToString("0000.000000", System.Globalization.CultureInfo.InvariantCulture) + ", ");
                a.Append(Comprobante.Importe.ToString("0000000000000.00", System.Globalization.CultureInfo.InvariantCulture) + ", ");
                a.Append("'" + Comprobante.Request + "', ");
                if (Comprobante.Response == null)
                {
                    a.Append("'', ");
                }
                else
                {
                    a.Append("'" + Comprobante.Response + "', ");
                }
                a.Append("'" + Comprobante.IdDestinoComprobante + "', ");
                a.Append("@idWF, ");
                a.Append("'" + Comprobante.WF.Estado + "', ");
                a.Append("'" + Comprobante.NaturalezaComprobante.Id + "', ");
                a.Append("'" + Comprobante.PeriodicidadEmision + "', ");
                a.Append("'" + Comprobante.FechaProximaEmision.ToString("yyyyMMdd") + "', ");
                a.Append(Comprobante.CantidadComprobantesAEmitir + ", ");
                a.Append(Comprobante.CantidadComprobantesEmitidos + ", ");
                a.Append(Comprobante.CantidadDiasFechaVto + ", ");
                a.Append(Convert.ToInt32(Comprobante.DatosEmailAvisoComprobanteContrato.Activo).ToString() + ", ");
                a.Append("'" + Comprobante.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Id + "', ");
                a.Append("'" + Comprobante.DatosEmailAvisoComprobanteContrato.Asunto + "', ");
                a.Append("'" + Comprobante.DatosEmailAvisoComprobanteContrato.Cuerpo + "' ");
                a.AppendLine(") ");
                a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Comprobante', 'Alta', '" + Comprobante.WF.Estado + "', '') ");
            }
            else
            {
                a.AppendLine("set @IdWF=" + comprobanteDesde.WF.Id.ToString() + " ");
                a.Append("update Comprobante set ");
                a.Append("Comprobante.DescrTipoComprobante='" + Comprobante.TipoComprobante.Descr + "', ");
                a.Append("Comprobante.NroLote=" + Comprobante.NroLote.ToString() + ", ");
                a.Append("Comprobante.IdTipoDoc=" + Comprobante.Documento.Tipo.Id + ", ");
                a.Append("Comprobante.NroDoc=" + Comprobante.Documento.Nro.ToString() + ", ");
                if (Comprobante.IdPersona == null)
                {
                    a.Append("Comprobante.IdPersona='', ");
                }
                else
                {
                    a.Append("Comprobante.IdPersona='" + Comprobante.IdPersona + "', ");
                }
                a.Append("Comprobante.DesambiguacionCuitPais=" + Comprobante.DesambiguacionCuitPais.ToString() + ", ");
                a.Append("Comprobante.RazonSocial='" + Comprobante.RazonSocial + "', ");
                if (Comprobante.Detalle == null)
                {
                    a.Append("Comprobante.Detalle='', ");
                }
                else
                {
                    a.Append("Comprobante.Detalle='" + Comprobante.Detalle + "', ");
                }    
                a.Append("Comprobante.Fecha='" + Comprobante.Fecha.ToString("yyyyMMdd") + "', ");
                a.Append("Comprobante.FechaVto='" + Comprobante.FechaVto.ToString("yyyyMMdd") + "', ");
                a.Append("Comprobante.Moneda='" + Comprobante.Moneda + "', ");
                a.Append("Comprobante.ImporteMoneda=" + Comprobante.ImporteMoneda.ToString("0000000000000.00", System.Globalization.CultureInfo.InvariantCulture) + ", ");
                a.Append("Comprobante.TipoCambio=" + Comprobante.TipoCambio.ToString("0000.000000", System.Globalization.CultureInfo.InvariantCulture) + ", ");
                a.Append("Comprobante.Importe=" + Comprobante.Importe.ToString("0000000000000.00", System.Globalization.CultureInfo.InvariantCulture) + ", ");
                a.Append("Comprobante.Request='" + Comprobante.Request + "', ");
                if (Comprobante.Response == null)
                {
                    a.Append("Comprobante.Response='', ");
                }
                else
                {
                    a.Append("Comprobante.Response='" + Comprobante.Response + "', ");
                }    
                a.Append("Comprobante.IdDestinoComprobante='" + Comprobante.IdDestinoComprobante + "', ");
                a.Append("Comprobante.Estado='" + Comprobante.WF.Estado + "', ");
                a.Append("Comprobante.IdNaturalezaComprobante='" + Comprobante.NaturalezaComprobante.Id + "', ");
                a.Append("Comprobante.PeriodicidadEmision='" + Comprobante.PeriodicidadEmision + "', ");
                a.Append("Comprobante.FechaProximaEmision='" + Comprobante.FechaProximaEmision.ToString("yyyyMMdd") + "', ");
                a.Append("Comprobante.CantidadComprobantesAEmitir=" + Comprobante.CantidadComprobantesAEmitir + ", ");
                a.Append("Comprobante.CantidadComprobantesEmitidos=" + Comprobante.CantidadComprobantesEmitidos + ", ");
                a.Append("Comprobante.CantidadDiasFechaVto=" + Comprobante.CantidadDiasFechaVto + ", ");
                a.Append("Comprobante.EmailAvisoComprobanteActivo=" + Convert.ToInt32(Comprobante.DatosEmailAvisoComprobanteContrato.Activo).ToString() + ", ");
                a.Append("Comprobante.IdDestinatarioFrecuente='" + Comprobante.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Id + "', ");
                a.Append("Comprobante.EmailAvisoComprobanteAsunto='" + Comprobante.DatosEmailAvisoComprobanteContrato.Asunto + "', ");
                a.Append("Comprobante.EmailAvisoComprobanteCuerpo='" + Comprobante.DatosEmailAvisoComprobanteContrato.Cuerpo + "' ");
                a.AppendLine("where Cuit='" + Comprobante.Cuit + "' and IdTipoComprobante=" + Comprobante.TipoComprobante.Id.ToString() + " and NroPuntoVta=" + Comprobante.NroPuntoVta.ToString() + " and Nrocomprobante=" + (Comprobante.NaturalezaComprobante.Id == "VentaContrato" ? -Comprobante.Nro : Comprobante.Nro).ToString() + " ");
                a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Comprobante', 'Modif', '" + Comprobante.WF.Estado + "', '') ");
                a.AppendLine("declare @idLog int ");
                a.AppendLine("select @idLog=@@Identity ");
                a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(comprobanteDesde) + "')");
                a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Comprobante) + "')");
            }
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Registrar(FeaEntidades.InterFacturas.lote_comprobantes Lote, Object Response, string IdNaturalezaComprobante, string IdDestinoComprobante, string IdEstado, string PeriodicidadEmision, DateTime FechaProximaEmision, int CantidadComprobantesAEmitir, int CantidadComprobantesEmitidos, int CantidadDiasFechaVto, string Detalle, bool EmailAvisoComprobanteActivo, string IdDestinatarioFrecuente, string EmailAvisoComprobanteAsunto, string EmailAvisoComprobanteCuerpo)
        {
            Entidades.Comprobante comprobante = new Entidades.Comprobante();
            if (IdNaturalezaComprobante != "Compra")
            {
                comprobante.Cuit = Lote.cabecera_lote.cuit_vendedor.ToString();
                comprobante.Documento.Tipo.Id = Lote.comprobante[0].cabecera.informacion_comprador.codigo_doc_identificatorio.ToString();
                FeaEntidades.Documentos.Documento tipoDocumento = FeaEntidades.Documentos.Documento.Lista().Find(delegate(FeaEntidades.Documentos.Documento d) { return comprobante.Documento.Tipo.Id == d.Codigo.ToString(); });
                if (tipoDocumento != null)
                {
                    comprobante.Documento.Tipo.Descr = tipoDocumento.Descr;
                }
                else
                {
                    comprobante.Documento.Tipo.Descr = "Desconocido";
                }
                comprobante.Documento.Nro = Lote.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio;
                comprobante.IdPersona = Lote.comprobante[0].cabecera.informacion_comprador.id;
                comprobante.DesambiguacionCuitPais = Lote.comprobante[0].cabecera.informacion_comprador.desambiguacionCuitPais;
                comprobante.RazonSocial = Lote.comprobante[0].cabecera.informacion_comprador.denominacion;
            }
            else
            {
                comprobante.Cuit = Lote.comprobante[0].cabecera.informacion_comprador.nro_doc_identificatorio.ToString();
                comprobante.Documento.Tipo.Id = new FeaEntidades.Documentos.CUIT().Codigo.ToString();
                comprobante.Documento.Nro = Lote.cabecera_lote.cuit_vendedor;
                comprobante.IdPersona = Lote.comprobante[0].cabecera.informacion_vendedor.id;
                comprobante.DesambiguacionCuitPais = Lote.comprobante[0].cabecera.informacion_vendedor.desambiguacionCuitPais;
                comprobante.RazonSocial = Lote.comprobante[0].cabecera.informacion_vendedor.razon_social;
            }
            comprobante.WF.Estado = IdEstado;
            comprobante.TipoComprobante.Id = Lote.comprobante[0].cabecera.informacion_comprobante.tipo_de_comprobante;
            FeaEntidades.TiposDeComprobantes.TipoComprobante tipoComprobante = FeaEntidades.TiposDeComprobantes.TipoComprobante.ListaCompletaAFIP().Find(delegate(FeaEntidades.TiposDeComprobantes.TipoComprobante d) { return comprobante.TipoComprobante.Id.ToString() == d.Codigo.ToString(); });
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
            comprobante.Detalle = Detalle;
            comprobante.Fecha = Funciones.ConvertirFechaStringAAAAMMDDaDatetime(Lote.comprobante[0].cabecera.informacion_comprobante.fecha_emision);
            if (Lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento == null || Lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento == String.Empty)
            {
                comprobante.FechaVto = Convert.ToDateTime("31/12/9999");
            }
            else
            {
                comprobante.FechaVto = Funciones.ConvertirFechaStringAAAAMMDDaDatetime(Lote.comprobante[0].cabecera.informacion_comprobante.fecha_vencimiento);
            }
            comprobante.Moneda = Lote.comprobante[0].resumen.codigo_moneda;
            if (Lote.comprobante[0].resumen.importes_moneda_origen != null)
            {
                comprobante.ImporteMoneda = Lote.comprobante[0].resumen.importes_moneda_origen.importe_total_factura;
            }
            comprobante.TipoCambio = Lote.comprobante[0].resumen.tipo_de_cambio;
            comprobante.Importe = Lote.comprobante[0].resumen.importe_total_factura;
            comprobante.Request = Funciones.ObjetoSerializado(Lote);
            if (Response != null)
            {
                comprobante.Response = Funciones.ObjetoSerializado(Response);
            }
            comprobante.IdDestinoComprobante = IdDestinoComprobante;
            comprobante.NaturalezaComprobante.Id = IdNaturalezaComprobante;
            comprobante.PeriodicidadEmision = PeriodicidadEmision;
            comprobante.FechaProximaEmision = FechaProximaEmision;
            comprobante.CantidadComprobantesAEmitir = CantidadComprobantesAEmitir;
            comprobante.CantidadComprobantesEmitidos = CantidadComprobantesEmitidos;
            comprobante.CantidadDiasFechaVto = CantidadDiasFechaVto;
            comprobante.DatosEmailAvisoComprobanteContrato.Activo = EmailAvisoComprobanteActivo;
            comprobante.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Id = IdDestinatarioFrecuente;
            comprobante.DatosEmailAvisoComprobanteContrato.Asunto = EmailAvisoComprobanteAsunto;
            comprobante.DatosEmailAvisoComprobanteContrato.Cuerpo = EmailAvisoComprobanteCuerpo;
            Registrar(comprobante);
        }
        public void DarDeBaja(Entidades.Comprobante Comprobante)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("set @IdWF=" + Comprobante.WF.Id.ToString() + " ");
            a.Append("update Comprobante set ");
            Comprobante.WF.Estado = "DeBaja";
            a.Append("Comprobante.Estado='" + Comprobante.WF.Estado + "' ");
            a.AppendLine("where Cuit='" + Comprobante.Cuit + "' and IdTipoComprobante=" + Comprobante.TipoComprobante.Id.ToString() + " and NroPuntoVta=" + Comprobante.NroPuntoVta.ToString() + " and Nrocomprobante=" + (Comprobante.NaturalezaComprobante.Id == "VentaContrato" ? -Comprobante.Nro : Comprobante.Nro).ToString() + " ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Comprobante', 'Baja', '" + Comprobante.WF.Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void AnularBaja(Entidades.Comprobante Comprobante)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("set @IdWF=" + Comprobante.WF.Id.ToString() + " ");
            a.AppendLine("declare @EstadoAnterior varchar(15) ");
            a.AppendLine("select top 1 @EstadoAnterior=Estado from Log where IdWF=@IdWF and Estado<>'DeBaja' order by IdLog desc ");
            a.Append("update Comprobante set ");
            a.Append("Comprobante.Estado=@EstadoAnterior ");
            a.AppendLine("where Cuit='" + Comprobante.Cuit + "' and IdTipoComprobante=" + Comprobante.TipoComprobante.Id.ToString() + " and NroPuntoVta=" + Comprobante.NroPuntoVta.ToString() + " and Nrocomprobante=" + (Comprobante.NaturalezaComprobante.Id == "VentaContrato" ? -Comprobante.Nro : Comprobante.Nro).ToString() + " ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Comprobante', 'AnulBaja', @EstadoAnterior, '') ");
            a.AppendLine("select @EstadoAnterior as Estado ");
            DataTable tb = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.Usa, sesion.CnnStr);
            if (tb.Rows.Count == 1)
            {
                Comprobante.WF.Estado = tb.Rows[0]["Estado"].ToString();
            }
        }
        public List<Entidades.Comprobante> ListaGlobalFiltrada(bool SoloVigentes, bool EsFechaAlta, string FechaDesde, string FechaHasta, Entidades.Persona Persona, string CUIT, string CUITRazonSocial, string NroComprobante)
        {
            List<Entidades.Comprobante> lista = new List<Entidades.Comprobante>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Comprobante.Cuit, Cuit.RazonSocial as CUITRazonSocial, convert(datetime, Log.Fecha, 120) as FechaAlta, Comprobante.IdTipoComprobante, Comprobante.DescrTipoComprobante, Comprobante.NroPuntoVta, Comprobante.NroComprobante, Comprobante.NroLote, Comprobante.IdTipoDoc, Comprobante.NroDoc, Comprobante.IdPersona, Comprobante.DesambiguacionCuitPais, Comprobante.RazonSocial, Comprobante.Detalle, Comprobante.Fecha, Comprobante.FechaVto, Comprobante.Moneda, Comprobante.ImporteMoneda, Comprobante.TipoCambio, Comprobante.Importe, Comprobante.Request, Comprobante.Response, Comprobante.IdDestinoComprobante, Comprobante.IdWF, Comprobante.Estado, Comprobante.UltActualiz, Comprobante.IdNaturalezaComprobante, NaturalezaComprobante.DescrNaturalezaComprobante, Comprobante.PeriodicidadEmision, Comprobante.FechaProximaEmision, Comprobante.CantidadComprobantesAEmitir, Comprobante.CantidadComprobantesEmitidos, Comprobante.CantidadDiasFechaVto, Comprobante.EmailAvisoComprobanteActivo, Comprobante.IdDestinatarioFrecuente, Comprobante.EmailAvisoComprobanteAsunto, Comprobante.EmailAvisoComprobanteCuerpo ");
                a.Append("from Comprobante, Cuit, Log, NaturalezaComprobante ");
                a.Append("where Comprobante.Cuit = Cuit.Cuit and Comprobante.IdWF = Log.IdWF and Log.Evento = 'Alta' ");
                a.Append("and Comprobante.IdNaturalezaComprobante=NaturalezaComprobante.IdNaturalezaComprobante ");
                if (SoloVigentes)
                {
                    a.Append("and Comprobante.Estado='Vigente' ");
                }
                if (EsFechaAlta)
                {
                    if (FechaDesde != String.Empty)
                    {
                        a.Append("and Log.Fecha >= '" + Convert.ToDateTime(FechaDesde, new System.Globalization.CultureInfo("es-AR")).ToString("yyyyMMdd") + "' ");
                    }
                    if (FechaHasta != String.Empty)
                    {
                        string FechaAuxHasta = Convert.ToDateTime(FechaHasta, new System.Globalization.CultureInfo("es-AR")).AddDays(1).ToString("yyyyMMdd");
                        a.Append("and Log.Fecha < '" + FechaAuxHasta + "' ");
                    }
                }
                else
                {
                    if (FechaDesde != String.Empty)
                    {
                        a.Append("and Comprobante.Fecha >= '" + Convert.ToDateTime(FechaDesde, new System.Globalization.CultureInfo("es-AR")).ToString("yyyyMMdd") + "' ");
                    }
                    if (FechaHasta != String.Empty)
                    {
                        a.Append("and Comprobante.Fecha <= '" + Convert.ToDateTime(FechaHasta, new System.Globalization.CultureInfo("es-AR")).ToString("yyyyMMdd") + "' ");
                    }
                }
                if (CUIT != String.Empty)
                {
                    a.Append("and Comprobante.Cuit like '%" + CUIT + "%' ");
                }
                if (CUITRazonSocial != String.Empty)
                {
                    a.Append("and Cuit.RazonSocial like '%" + CUITRazonSocial + "%' ");
                }
                if (NroComprobante != String.Empty)
                {
                    a.Append("and Comprobante.NroComprobante = " + NroComprobante + " ");
                }
                //if (Persona.Orden != 0)
                //{
                //    a.Append("and Comprobante.IdTipoDoc=" + Persona.Documento.Tipo.Id + " ");
                //    a.Append("and Comprobante.NroDoc=" + Persona.Documento.Nro.ToString() + " ");
                //    a.Append("and Comprobante.IdPersona='" + Persona.IdPersona + "' ");
                //    a.Append("and Comprobante.DesambiguacionCuitPais=" + Persona.DesambiguacionCuitPais.ToString() + " ");
                //}
                a.Append("order by Comprobante.DescrTipoComprobante desc, Comprobante.NroPuntoVta desc, Comprobante.NroComprobante desc ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Comprobante elem = new Entidades.Comprobante();
                        Copiar(dt.Rows[i], elem);
                        elem.CuitRazonSocial = Convert.ToString(dt.Rows[i]["CUITRazonSocial"]);
                        elem.FechaAlta = Convert.ToDateTime(dt.Rows[i]["FechaAlta"]);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.Comprobante Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.TipoComprobante.Id = Convert.ToInt32(Desde["IdTipoComprobante"]);
            Hasta.TipoComprobante.Descr = Convert.ToString(Desde["DescrTipoComprobante"]);
            Hasta.NroPuntoVta = Convert.ToInt32(Desde["NroPuntoVta"]);
            Hasta.Nro = Math.Abs(Convert.ToInt64(Desde["NroComprobante"]));
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
            Hasta.IdPersona = Convert.ToString(Desde["IdPersona"]);
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
            Hasta.NaturalezaComprobante.Id = Convert.ToString(Desde["IdNaturalezaComprobante"]);
            Hasta.NaturalezaComprobante.Descr = Convert.ToString(Desde["DescrNaturalezaComprobante"]);
            Hasta.PeriodicidadEmision = Convert.ToString(Desde["PeriodicidadEmision"]);
            Hasta.FechaProximaEmision = Convert.ToDateTime(Desde["FechaProximaEmision"]);
            Hasta.CantidadComprobantesAEmitir = Convert.ToInt32(Desde["CantidadComprobantesAEmitir"]);
            Hasta.CantidadComprobantesEmitidos = Convert.ToInt32(Desde["CantidadComprobantesEmitidos"]);
            Hasta.CantidadDiasFechaVto = Convert.ToInt32(Desde["CantidadDiasFechaVto"]);
            Hasta.DatosEmailAvisoComprobanteContrato.Activo = Convert.ToBoolean(Desde["EmailAvisoComprobanteActivo"]);
            Hasta.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Id = Convert.ToString(Desde["IdDestinatarioFrecuente"]);
            Hasta.DatosEmailAvisoComprobanteContrato.Asunto = Convert.ToString(Desde["EmailAvisoComprobanteAsunto"]);
            Hasta.DatosEmailAvisoComprobanteContrato.Cuerpo = Convert.ToString(Desde["EmailAvisoComprobanteCuerpo"]);
        }
        public void Actualizar(Entidades.Comprobante Comprobante)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("insert Log values (" + Comprobante.WF.Id + ", getdate(), '" + sesion.Usuario.Id + "', 'Comprobante', 'CambioEstado', '" + Comprobante.Estado + "', '') ");
            a.Append("update Comprobante set Response = '" + Comprobante.Response + "', Estado = '" + Comprobante.Estado + "', ");
            a.Append("Comprobante.IdTipoDoc='" + Comprobante.Documento.Tipo.Id + "', ");
            a.Append("Comprobante.NroDoc=" + Comprobante.Documento.Nro.ToString() + ", ");
            //a.Append("Comprobante.Fecha='" + Comprobante.Fecha.ToString("yyyyMMdd") + "', ");
            //a.Append("Comprobante.FechaVto='" + Comprobante.FechaVto.ToString("yyyyMMdd") + "', ");
            a.Append("Comprobante.Moneda='" + Comprobante.Moneda + "', ");
            a.Append("Comprobante.ImporteMoneda=" + Comprobante.ImporteMoneda.ToString("0000000000000.00", System.Globalization.CultureInfo.InvariantCulture) + ", ");
            a.Append("Comprobante.TipoCambio=" + Comprobante.TipoCambio.ToString("0000.000000", System.Globalization.CultureInfo.InvariantCulture) + ", ");
            a.Append("Comprobante.Importe=" + Comprobante.Importe.ToString("0000000000000.00", System.Globalization.CultureInfo.InvariantCulture) + " ");
            a.Append("where Comprobante.Cuit='" + sesion.Cuit.Nro + "' and Comprobante.IdTipoComprobante=" + Comprobante.TipoComprobante.Id.ToString() + " and Comprobante.NroPuntoVta=" + Comprobante.NroPuntoVta.ToString() + "and Comprobante.NroComprobante=" + Comprobante.Nro.ToString() + " ");
            int Cantidad = (int)Ejecutar(a.ToString(), TipoRetorno.CantReg, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void LeerDestinatarioFrecuente(Entidades.Persona Persona, Entidades.Comprobante Contrato)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select DestinatarioFrecuente.Para, DestinatarioFrecuente.Cc ");
            a.Append("from DestinatarioFrecuente ");
            a.Append("where DestinatarioFrecuente.Cuit='" + Persona.Cuit + "' and DestinatarioFrecuente.IdTipoDoc = " + Persona.Documento.Tipo.Id + " and DestinatarioFrecuente.NroDoc = " + Persona.Documento.Nro.ToString() + " and DestinatarioFrecuente.IdPersona = '" + Persona.IdPersona + "' and DestinatarioFrecuente.DesambiguacionCuitPais = " + Persona.DesambiguacionCuitPais.ToString() + " and IdDestinatarioFrecuente='" + Contrato.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Id + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Contrato.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Para = dt.Rows[0]["Para"].ToString();
                Contrato.DatosEmailAvisoComprobanteContrato.DestinatarioFrecuente.Cc = dt.Rows[0]["Cc"].ToString();
            }
        }
        public void LeerUltimoEmitido(Entidades.Comprobante Comprobante)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select top 1");
            a.Append("Comprobante.Cuit, Comprobante.IdTipoComprobante, Comprobante.DescrTipoComprobante, Comprobante.NroPuntoVta, Comprobante.NroComprobante, Comprobante.NroLote, Comprobante.IdTipoDoc, Comprobante.NroDoc, Comprobante.IdPersona, Comprobante.DesambiguacionCuitPais, Comprobante.RazonSocial, Comprobante.Detalle, Comprobante.Fecha, Comprobante.FechaVto, Comprobante.Moneda, Comprobante.ImporteMoneda, Comprobante.TipoCambio, Comprobante.Importe, Comprobante.Request, Comprobante.Response, Comprobante.IdDestinoComprobante, Comprobante.IdWF, Comprobante.Estado, Comprobante.UltActualiz, Comprobante.IdNaturalezaComprobante, NaturalezaComprobante.DescrNaturalezaComprobante, Comprobante.PeriodicidadEmision, Comprobante.FechaProximaEmision, Comprobante.CantidadComprobantesAEmitir, Comprobante.CantidadComprobantesEmitidos, Comprobante.CantidadDiasFechaVto, Comprobante.EmailAvisoComprobanteActivo, Comprobante.IdDestinatarioFrecuente, Comprobante.EmailAvisoComprobanteAsunto, Comprobante.EmailAvisoComprobanteCuerpo ");
            a.Append("from Comprobante, NaturalezaComprobante  ");
            a.Append("where Comprobante.Cuit='" + sesion.Cuit.Nro + "' and Comprobante.IdTipoComprobante=" + Comprobante.TipoComprobante.Id.ToString() + " and Comprobante.NroPuntoVta=" + Comprobante.NroPuntoVta.ToString() + " and Comprobante.IdNaturalezaComprobante='" + Comprobante.NaturalezaComprobante.Id + "' ");
            a.Append("and Comprobante.IdNaturalezaComprobante=NaturalezaComprobante.IdNaturalezaComprobante and Comprobante.Estado<>'DeBaja' ");
            a.Append("order by ABS(NroComprobante) desc ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], Comprobante);
            }
        }
        public void ActualizarFechaProximaEmision(Entidades.Comprobante Comprobante)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Comprobante set ");
            a.Append("Comprobante.FechaProximaEmision='" + Comprobante.FechaProximaEmision.ToString("yyyyMMdd") + "' ");
            a.AppendLine("where Cuit='" + Comprobante.Cuit + "' and IdTipoComprobante=" + Comprobante.TipoComprobante.Id.ToString() + " and NroPuntoVta=" + Comprobante.NroPuntoVta.ToString() + " and Nrocomprobante=" + (Comprobante.NaturalezaComprobante.Id == "VentaContrato" ? -Comprobante.Nro : Comprobante.Nro).ToString() + " ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
    }
}