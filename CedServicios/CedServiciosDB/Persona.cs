using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Persona : db
    {
        public Persona(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.Persona> ListaPorCuit(bool SoloVigentes, CedServicios.Entidades.Enum.TipoPersona TipoPersona)
        {
            return ListaPorCuit(SoloVigentes, false, TipoPersona);
        }
        public List<Entidades.Persona> ListaPorCuit(bool SoloVigentes, bool ParaCombo, CedServicios.Entidades.Enum.TipoPersona TipoPersona)
        {
            List<Entidades.Persona> lista = new List<Entidades.Persona>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Persona.Cuit, Persona.IdTipoDoc, Persona.NroDoc, Persona.IdPersona, Persona.DesambiguacionCuitPais, Persona.RazonSocial, Persona.DescrTipoDoc, Persona.Calle, Persona.Nro, Persona.Piso, Persona.Depto, Persona.Sector, Persona.Torre, Persona.Manzana, Persona.Localidad, Persona.IdProvincia, Persona.DescrProvincia, Persona.CodPost, Persona.NombreContacto, Persona.EmailContacto, Persona.TelefonoContacto, Persona.IdCondIVA, Persona.DescrCondIVA, Persona.NroIngBrutos, Persona.IdCondIngBrutos, Persona.DescrCondIngBrutos, Persona.GLN, Persona.FechaInicioActividades, Persona.CodigoInterno, Persona.EmailAvisoVisualizacion, Persona.PasswordAvisoVisualizacion, Persona.IdWF, Persona.Estado, Persona.UltActualiz, Persona.EsCliente, Persona.EsProveedor, Persona.EmailAvisoComprobanteActivo, Persona.EmailAvisoComprobanteDe, Persona.EmailAvisoComprobanteCco, Persona.EmailAvisoComprobanteAsunto, Persona.EmailAvisoComprobanteCuerpo, Persona.IdListaPrecioVenta, Persona.IdListaPrecioCompra ");
                a.Append("from Persona ");
                a.Append("where Persona.Cuit='" + sesion.Cuit.Nro + "' ");
                if (SoloVigentes)
                {
                    a.Append("and Persona.Estado='Vigente' ");
                }
                switch (TipoPersona.ToString())
                {
                    case "Cliente":
                        a.Append("and Persona.EsCliente=1 ");
                        break;
                    case "Proveedor":
                        a.Append("and Persona.EsProveedor=1 ");
                        break;
                    case "Ambos":
                        break;
                }
                a.Append("order by Persona.RazonSocial ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    if (ParaCombo)
                    {
                        Entidades.Persona todos = new Entidades.Persona();
                        todos.Orden = 0;
                        todos.RazonSocial = "--- Todas ---";
                        lista.Add(todos);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Persona elem = new Entidades.Persona();
                        Copiar(dt.Rows[i], elem);
                        if (ParaCombo) elem.Orden = i + 1;
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.Persona Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Documento.Tipo.Id = Convert.ToString(Desde["IdTipoDoc"]);
            Hasta.Documento.Tipo.Descr = Convert.ToString(Desde["DescrTipoDoc"]);
            Hasta.Documento.Nro = Convert.ToString(Desde["NroDoc"]);
            Hasta.IdPersona = Convert.ToString(Desde["IdPersona"]);
            Hasta.DesambiguacionCuitPais = Convert.ToInt32(Desde["DesambiguacionCuitPais"]);
            Hasta.RazonSocial = Convert.ToString(Desde["RazonSocial"]);
            Hasta.Domicilio.Calle = Convert.ToString(Desde["Calle"]);
            Hasta.Domicilio.Nro = Convert.ToString(Desde["Nro"]);
            Hasta.Domicilio.Piso = Convert.ToString(Desde["Piso"]);
            Hasta.Domicilio.Depto = Convert.ToString(Desde["Depto"]);
            Hasta.Domicilio.Sector = Convert.ToString(Desde["Sector"]);
            Hasta.Domicilio.Torre = Convert.ToString(Desde["Torre"]);
            Hasta.Domicilio.Manzana = Convert.ToString(Desde["Manzana"]);
            Hasta.Domicilio.Localidad = Convert.ToString(Desde["Localidad"]);
            Hasta.Domicilio.Provincia.Id = Convert.ToString(Desde["IdProvincia"]);
            Hasta.Domicilio.Provincia.Descr = Convert.ToString(Desde["DescrProvincia"]);
            Hasta.Domicilio.CodPost = Convert.ToString(Desde["CodPost"]);
            Hasta.Contacto.Nombre = Convert.ToString(Desde["NombreContacto"]);
            Hasta.Contacto.Email = Convert.ToString(Desde["EmailContacto"]);
            Hasta.Contacto.Telefono = Convert.ToString(Desde["TelefonoContacto"]);
            Hasta.DatosImpositivos.IdCondIVA = Convert.ToInt32(Desde["IdCondIVA"]);
            Hasta.DatosImpositivos.DescrCondIVA = Convert.ToString(Desde["DescrCondIVA"]);
            Hasta.DatosImpositivos.NroIngBrutos = Convert.ToString(Desde["NroIngBrutos"]);
            Hasta.DatosImpositivos.IdCondIngBrutos = Convert.ToInt32(Desde["IdCondIngBrutos"]);
            Hasta.DatosImpositivos.DescrCondIngBrutos = Convert.ToString(Desde["DescrCondIngBrutos"]);
            Hasta.DatosImpositivos.FechaInicioActividades = Convert.ToDateTime(Desde["FechaInicioActividades"]);
            Hasta.DatosIdentificatorios.GLN = Convert.ToInt64(Desde["GLN"]);
            Hasta.DatosIdentificatorios.CodigoInterno = Convert.ToString(Desde["CodigoInterno"]);
            Hasta.EmailAvisoVisualizacion = Convert.ToString(Desde["EmailAvisoVisualizacion"]);
            Hasta.PasswordAvisoVisualizacion = Convert.ToString(Desde["PasswordAvisoVisualizacion"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
            Hasta.EsCliente = Convert.ToBoolean(Desde["EsCliente"]);
            Hasta.EsProveedor = Convert.ToBoolean(Desde["EsProveedor"]);
            Hasta.DatosEmailAvisoComprobantePersona.Activo = Convert.ToBoolean(Desde["EmailAvisoComprobanteActivo"]);
            Hasta.DatosEmailAvisoComprobantePersona.De = Convert.ToString(Desde["EmailAvisoComprobanteDe"]);
            Hasta.DatosEmailAvisoComprobantePersona.Cco = Convert.ToString(Desde["EmailAvisoComprobanteCco"]);
            Hasta.DatosEmailAvisoComprobantePersona.Asunto = Convert.ToString(Desde["EmailAvisoComprobanteAsunto"]);
            Hasta.DatosEmailAvisoComprobantePersona.Cuerpo = Convert.ToString(Desde["EmailAvisoComprobanteCuerpo"]);
            Hasta.IdListaPrecioVenta = Convert.ToString(Desde["IdListaPrecioVenta"]);
            Hasta.IdListaPrecioCompra = Convert.ToString(Desde["IdListaPrecioCompra"]);
        }
        public void Leer(Entidades.Persona persona)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("Persona.Cuit, Persona.IdTipoDoc, Persona.NroDoc, Persona.IdPersona, Persona.DesambiguacionCuitPais, Persona.RazonSocial, Persona.DescrTipoDoc, Persona.Calle, Persona.Nro, Persona.Piso, Persona.Depto, Persona.Sector, Persona.Torre, Persona.Manzana, Persona.Localidad, Persona.IdProvincia, Persona.DescrProvincia, Persona.CodPost, Persona.NombreContacto, Persona.EmailContacto, Persona.TelefonoContacto, Persona.IdCondIVA, Persona.DescrCondIVA, Persona.NroIngBrutos, Persona.IdCondIngBrutos, Persona.DescrCondIngBrutos, Persona.GLN, Persona.FechaInicioActividades, Persona.CodigoInterno, Persona.EmailAvisoVisualizacion, Persona.PasswordAvisoVisualizacion, Persona.IdWF, Persona.Estado, Persona.UltActualiz, Persona.EsCliente, Persona.EsProveedor, Persona.EmailAvisoComprobanteActivo, Persona.EmailAvisoComprobanteDe, Persona.EmailAvisoComprobanteCco, Persona.EmailAvisoComprobanteAsunto, Persona.EmailAvisoComprobanteCuerpo, Persona.IdListaPrecioVenta, Persona.IdListaPrecioCompra ");
            a.Append("from Persona ");
            a.Append("where Persona.Cuit='" + sesion.Cuit.Nro + "' and Persona.RazonSocial = '" + persona.RazonSocial + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], persona);
            }
        }
        public void LeerPorClavePrimaria(Entidades.Persona persona)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("Persona.Cuit, Persona.IdTipoDoc, Persona.NroDoc, Persona.IdPersona, Persona.DesambiguacionCuitPais, Persona.RazonSocial, Persona.DescrTipoDoc, Persona.Calle, Persona.Nro, Persona.Piso, Persona.Depto, Persona.Sector, Persona.Torre, Persona.Manzana, Persona.Localidad, Persona.IdProvincia, Persona.DescrProvincia, Persona.CodPost, Persona.NombreContacto, Persona.EmailContacto, Persona.TelefonoContacto, Persona.IdCondIVA, Persona.DescrCondIVA, Persona.NroIngBrutos, Persona.IdCondIngBrutos, Persona.DescrCondIngBrutos, Persona.GLN, Persona.FechaInicioActividades, Persona.CodigoInterno, Persona.EmailAvisoVisualizacion, Persona.PasswordAvisoVisualizacion, Persona.IdWF, Persona.Estado, Persona.UltActualiz, Persona.EsCliente, Persona.EsProveedor, Persona.EmailAvisoComprobanteActivo, Persona.EmailAvisoComprobanteDe, Persona.EmailAvisoComprobanteCco, Persona.EmailAvisoComprobanteAsunto, Persona.EmailAvisoComprobanteCuerpo, Persona.IdListaPrecioVenta, Persona.IdListaPrecioCompra ");
            a.Append("from Persona ");
            a.Append("where Persona.Cuit='" + persona.Cuit + "' ");
            a.Append("and Persona.IdTipoDoc = " + persona.Documento.Tipo.Id + " ");
            a.Append("and Persona.NroDoc = '" + persona.Documento.Nro.ToString() + "' ");
            a.Append("and Persona.IdPersona = '" + persona.IdPersona + "' ");
            a.Append("and Persona.DesambiguacionCuitPais = " + persona.DesambiguacionCuitPais.ToString() + " ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], persona);
            }
        }
        public Entidades.Persona Leer(int IdWF)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("Persona.Cuit, Persona.IdTipoDoc, Persona.NroDoc, Persona.IdPersona, Persona.DesambiguacionCuitPais, Persona.RazonSocial, Persona.DescrTipoDoc, Persona.Calle, Persona.Nro, Persona.Piso, Persona.Depto, Persona.Sector, Persona.Torre, Persona.Manzana, Persona.Localidad, Persona.IdProvincia, Persona.DescrProvincia, Persona.CodPost, Persona.NombreContacto, Persona.EmailContacto, Persona.TelefonoContacto, Persona.IdCondIVA, Persona.DescrCondIVA, Persona.NroIngBrutos, Persona.IdCondIngBrutos, Persona.DescrCondIngBrutos, Persona.GLN, Persona.FechaInicioActividades, Persona.CodigoInterno, Persona.EmailAvisoVisualizacion, Persona.PasswordAvisoVisualizacion, Persona.IdWF, Persona.Estado, Persona.UltActualiz, Persona.EsCliente, Persona.EsProveedor, Persona.EmailAvisoComprobanteActivo, Persona.EmailAvisoComprobanteDe, Persona.EmailAvisoComprobanteCco, Persona.EmailAvisoComprobanteAsunto, Persona.EmailAvisoComprobanteCuerpo, Persona.IdListaPrecioVenta, Persona.IdListaPrecioCompra ");
            a.Append("from Persona ");
            a.Append("where Persona.IdWF = " + IdWF);
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            Entidades.Persona persona = new Entidades.Persona();
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], persona);
            }
            return persona;
        }

        public void Crear(Entidades.Persona Persona)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("declare @desambiguacionCuitPais int ");
            if (Persona.Documento.Tipo.Id.Equals(new FeaEntidades.Documentos.CUITPais().Codigo.ToString()))
            {
                a.Append("select @desambiguacionCuitPais=count(*)+1 from Persona where Cuit='" + Persona.Cuit + "' and IdTipoDoc=" + Persona.Documento.Tipo.Id + " and NroDoc='" + Persona.Documento.Nro.ToString() + "' ");
            }
            else
            {
                a.AppendLine("set @desambiguacionCuitPais=0 ");
            }
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert Persona (Cuit, IdTipoDoc, NroDoc, IdPersona, DesambiguacionCuitPais, RazonSocial, DescrTipoDoc, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, IdCondIVA, DescrCondIVA, NroIngBrutos, IdCondIngBrutos, DescrCondIngBrutos, FechaInicioActividades, GLN, CodigoInterno, EmailAvisoVisualizacion, PasswordAvisoVisualizacion, IdWF, Estado, EsCliente, EsProveedor, EmailAvisoComprobanteActivo, EmailAvisoComprobanteDe, EmailAvisoComprobanteCco, EmailAvisoComprobanteAsunto, EmailAvisoComprobanteCuerpo, IdListaPrecioVenta, IdListaPrecioCompra) ");
            a.Append("values (");
            a.Append("'" + Persona.Cuit + "', ");
            a.Append(Persona.Documento.Tipo.Id + ", ");
            a.Append("'" + Persona.Documento.Nro.ToString() + "', ");
            a.Append("'" + Persona.IdPersona + "', ");
            a.Append("@desambiguacionCuitPais, ");
            a.Append("'" + Persona.RazonSocial + "', ");
            a.Append("'" + Persona.Documento.Tipo.Descr + "', ");
            a.Append("'" + Persona.Domicilio.Calle + "', ");
            a.Append("'" + Persona.Domicilio.Nro + "', ");
            a.Append("'" + Persona.Domicilio.Piso + "', ");
            a.Append("'" + Persona.Domicilio.Depto + "', ");
            a.Append("'" + Persona.Domicilio.Sector + "', ");
            a.Append("'" + Persona.Domicilio.Torre + "', ");
            a.Append("'" + Persona.Domicilio.Manzana + "', ");
            a.Append("'" + Persona.Domicilio.Localidad + "', ");
            a.Append("'" + Persona.Domicilio.Provincia.Id + "', ");
            a.Append("'" + Persona.Domicilio.Provincia.Descr + "', ");
            a.Append("'" + Persona.Domicilio.CodPost + "', ");
            a.Append("'" + Persona.Contacto.Nombre + "', ");
            a.Append("'" + Persona.Contacto.Email + "', ");
            a.Append("'" + Persona.Contacto.Telefono + "', ");
            a.Append("'" + Persona.DatosImpositivos.IdCondIVA + "', ");
            a.Append("'" + Persona.DatosImpositivos.DescrCondIVA + "', ");
            a.Append("'" + Persona.DatosImpositivos.NroIngBrutos + "', ");
            a.Append("'" + Persona.DatosImpositivos.IdCondIngBrutos + "', ");
            a.Append("'" + Persona.DatosImpositivos.DescrCondIngBrutos + "', ");
            a.Append("'" + Persona.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd") + "', ");
            a.Append(Persona.DatosIdentificatorios.GLN.ToString() + ", ");
            a.Append("'" + Persona.DatosIdentificatorios.CodigoInterno + "', ");
            a.Append("'" + Persona.EmailAvisoVisualizacion + "', ");
            a.Append("'" + Persona.PasswordAvisoVisualizacion + "', ");
            a.Append("@idWF, ");
            a.Append("'" + Persona.WF.Estado + "', ");
            int esCliente = Persona.EsCliente ? 1 : 0;
            a.Append(esCliente.ToString() + ", ");
            int esProveedor = Persona.EsProveedor ? 1 : 0;
            a.Append(esProveedor.ToString() + ", ");
            int datosEmailAvisoComprobantePersonaActivo = Persona.DatosEmailAvisoComprobantePersona.Activo ? 1 : 0;
            a.Append(datosEmailAvisoComprobantePersonaActivo.ToString() + ", ");
            a.Append("'" + Persona.DatosEmailAvisoComprobantePersona.De + "', "); 
            a.Append("'" + Persona.DatosEmailAvisoComprobantePersona.Cco + "', ");
            a.Append("'" + Persona.DatosEmailAvisoComprobantePersona.Asunto + "', ");
            a.Append("'" + Persona.DatosEmailAvisoComprobantePersona.Cuerpo + "', ");
            a.Append("'" + Persona.IdListaPrecioVenta + "', ");
            a.Append("'" + Persona.IdListaPrecioCompra + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Persona', 'Alta', '" + Persona.WF.Estado + "', '') ");
            a.Append(AgregarDestinatariosFrecuentesHandler(Persona));
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void DesambiguarPersonaNacional(Entidades.Persona Persona)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("update Persona set IdPersona=Razonsocial where Cuit='" + Persona.Cuit + "' and IdTipoDoc=" + Persona.Documento.Tipo.Id + " and NroDoc='" + Persona.Documento.Nro.ToString() + "' and IdPersona='' ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.Persona Desde, Entidades.Persona Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Persona set ");
            a.Append("IdPersona='" + Hasta.IdPersona + "', ");
            a.Append("RazonSocial='" + Hasta.RazonSocial + "', ");
            a.Append("DescrTipoDoc='" + Hasta.Documento.Tipo.Descr + "', ");
            a.Append("Calle='" + Hasta.Domicilio.Calle + "', ");
            a.Append("Nro='" + Hasta.Domicilio.Nro + "', ");
            a.Append("Piso='" + Hasta.Domicilio.Piso + "', ");
            a.Append("Depto='" + Hasta.Domicilio.Depto + "', ");
            a.Append("Sector='" + Hasta.Domicilio.Sector + "', ");
            a.Append("Torre='" + Hasta.Domicilio.Torre + "', ");
            a.Append("Manzana='" + Hasta.Domicilio.Manzana + "', ");
            a.Append("Localidad='" + Hasta.Domicilio.Localidad + "', ");
            a.Append("IdProvincia='" + Hasta.Domicilio.Provincia.Id + "', ");
            a.Append("DescrProvincia='" + Hasta.Domicilio.Provincia.Descr + "', ");
            a.Append("CodPost='" + Hasta.Domicilio.CodPost + "', ");
            a.Append("NombreContacto='" + Hasta.Contacto.Nombre + "', ");
            a.Append("EmailContacto='" + Hasta.Contacto.Email + "', ");
            a.Append("TelefonoContacto='" + Hasta.Contacto.Telefono + "', ");
            a.Append("IdCondIVA='" + Hasta.DatosImpositivos.IdCondIVA + "', ");
            a.Append("DescrCondIVA='" + Hasta.DatosImpositivos.DescrCondIVA + "', ");
            a.Append("NroIngBrutos='" + Hasta.DatosImpositivos.NroIngBrutos + "', ");
            a.Append("IdCondIngBrutos='" + Hasta.DatosImpositivos.IdCondIngBrutos + "', ");
            a.Append("DescrCondIngBrutos='" + Hasta.DatosImpositivos.DescrCondIngBrutos + "', ");
            a.Append("FechaInicioActividades='" + Hasta.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd") + "', ");
            a.Append("GLN=" + Hasta.DatosIdentificatorios.GLN.ToString() + ", ");
            a.Append("CodigoInterno='" + Hasta.DatosIdentificatorios.CodigoInterno + "', ");
            a.Append("EmailAvisoVisualizacion='" + Hasta.EmailAvisoVisualizacion + "', ");
            a.Append("PasswordAvisoVisualizacion='" + Hasta.PasswordAvisoVisualizacion + "', ");
            int esCliente = Hasta.EsCliente ? 1 : 0;
            a.Append("EsCliente=" + esCliente.ToString() + ", ");
            int esProveedor = Hasta.EsProveedor ? 1 : 0;
            a.Append("EsProveedor=" + esProveedor.ToString() + ", ");
            int datosEmailAvisoComprobantePersonaActivo = Hasta.DatosEmailAvisoComprobantePersona.Activo ? 1 : 0;
            a.Append("EmailAvisoComprobanteActivo=" + datosEmailAvisoComprobantePersonaActivo.ToString() + ", ");
            a.Append("EmailAvisoComprobanteDe='" + Hasta.DatosEmailAvisoComprobantePersona.De + "', ");
            a.Append("EmailAvisoComprobanteCco='" + Hasta.DatosEmailAvisoComprobantePersona.Cco + "', ");
            a.Append("EmailAvisoComprobanteAsunto='" + Hasta.DatosEmailAvisoComprobantePersona.Asunto + "', ");
            a.Append("EmailAvisoComprobanteCuerpo='" + Hasta.DatosEmailAvisoComprobantePersona.Cuerpo + "', ");
            a.Append("IdListaPrecioVenta='" + Hasta.IdListaPrecioVenta + "', ");
            a.Append("IdListaPrecioCompra='" + Hasta.IdListaPrecioCompra + "' ");
            a.AppendLine("where Cuit='" + Hasta.Cuit + "' and IdTipoDoc=" + Hasta.Documento.Tipo.Id + " and NroDoc='" + Hasta.Documento.Nro.ToString() + "' and IdPersona='" + Hasta.IdPersona + "' and DesambiguacionCuitPais=" + Hasta.DesambiguacionCuitPais.ToString() + " ");
            a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Persona', 'Modif', '" + Hasta.WF.Estado + "', '') ");
            a.AppendLine("declare @idLog int ");
            a.AppendLine("select @idLog=@@Identity ");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(Desde) + "')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Hasta) + "')");
            a.AppendLine(EliminarDestinatariosFrecuentesHandler(Hasta));
            a.Append(AgregarDestinatariosFrecuentesHandler(Hasta));
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CambiarEstado(Entidades.Persona Persona, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Persona set ");
            a.Append("Estado='" + Estado + "' ");
            a.AppendLine("where Cuit='" + Persona.Cuit + "' and IdTipoDoc=" + Persona.Documento.Tipo.Id + " and NroDoc='" + Persona.Documento.Nro.ToString() + "' and IdPersona='" + Persona.IdPersona + "' and DesambiguacionCuitPais=" + Persona.DesambiguacionCuitPais.ToString() + " ");
            string evento = (Estado == "DeBaja") ? "Baja" : "AnulBaja";
            a.AppendLine("insert Log values (" + Persona.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Persona', '" + evento + "', '" + Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public List<Entidades.Persona> ListaPorCuityTipoyNroDoc(string Cuit, Entidades.Documento Documento, CedServicios.Entidades.Enum.TipoPersona TipoPersona)
        {
            List<Entidades.Persona> lista = new List<Entidades.Persona>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Persona.Cuit, Persona.IdTipoDoc, Persona.NroDoc, Persona.IdPersona, Persona.DesambiguacionCuitPais, Persona.RazonSocial, Persona.DescrTipoDoc, Persona.Calle, Persona.Nro, Persona.Piso, Persona.Depto, Persona.Sector, Persona.Torre, Persona.Manzana, Persona.Localidad, Persona.IdProvincia, Persona.DescrProvincia, Persona.CodPost, Persona.NombreContacto, Persona.EmailContacto, Persona.TelefonoContacto, Persona.IdCondIVA, Persona.DescrCondIVA, Persona.NroIngBrutos, Persona.IdCondIngBrutos, Persona.DescrCondIngBrutos, Persona.GLN, Persona.FechaInicioActividades, Persona.CodigoInterno, Persona.EmailAvisoVisualizacion, Persona.PasswordAvisoVisualizacion, Persona.IdWF, Persona.Estado, Persona.UltActualiz, Persona.EsCliente, Persona.EsProveedor, Persona.EmailAvisoComprobanteActivo, Persona.EmailAvisoComprobanteDe, Persona.EmailAvisoComprobanteCco, Persona.EmailAvisoComprobanteAsunto, Persona.EmailAvisoComprobanteCuerpo, Persona.IdListaPrecioVenta, Persona.IdListaPrecioCompra ");
                a.Append("from Persona ");
                a.Append("where Persona.Cuit='" + Cuit + "' and Persona.IdTipoDoc=" + Documento.Tipo.Id + " and Persona.NroDoc='" + Documento.Nro.ToString() + "' ");
                switch (TipoPersona.ToString())
                {
                    case "Cliente":
                        a.Append("and Persona.EsCliente=1 ");
                        break;
                    case "Proveedor":
                        a.Append("and Persona.EsProveedor=1 ");
                        break;
                    case "Ambos":
                        break;
                }
                a.Append("order by Persona.RazonSocial ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Persona elem = new Entidades.Persona();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Persona> ListaPorCuityRazonSocial(string Cuit, string RazonSocial, CedServicios.Entidades.Enum.TipoPersona TipoPersona)
        {
            List<Entidades.Persona> lista = new List<Entidades.Persona>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Persona.Cuit, Persona.IdTipoDoc, Persona.NroDoc, Persona.IdPersona, Persona.DesambiguacionCuitPais, Persona.RazonSocial, Persona.DescrTipoDoc, Persona.Calle, Persona.Nro, Persona.Piso, Persona.Depto, Persona.Sector, Persona.Torre, Persona.Manzana, Persona.Localidad, Persona.IdProvincia, Persona.DescrProvincia, Persona.CodPost, Persona.NombreContacto, Persona.EmailContacto, Persona.TelefonoContacto, Persona.IdCondIVA, Persona.DescrCondIVA, Persona.NroIngBrutos, Persona.IdCondIngBrutos, Persona.DescrCondIngBrutos, Persona.GLN, Persona.FechaInicioActividades, Persona.CodigoInterno, Persona.EmailAvisoVisualizacion, Persona.PasswordAvisoVisualizacion, Persona.IdWF, Persona.Estado, Persona.UltActualiz, Persona.EsCliente, Persona.EsProveedor, Persona.EmailAvisoComprobanteActivo, Persona.EmailAvisoComprobanteDe, Persona.EmailAvisoComprobanteCco, Persona.EmailAvisoComprobanteAsunto, Persona.EmailAvisoComprobanteCuerpo, Persona.IdListaPrecioVenta, Persona.IdListaPrecioCompra ");
                a.Append("from Persona ");
                a.Append("where Persona.Cuit='" + Cuit + "' and Persona.RazonSocial like '%" + RazonSocial + "%' ");
                switch (TipoPersona.ToString())
                {
                    case "Cliente":
                        a.Append("and Persona.EsCliente=1 ");
                        break;
                    case "Proveedor":
                        a.Append("and Persona.EsProveedor=1 ");
                        break;
                    case "Ambos":
                        break;
                }
                a.Append("order by Persona.RazonSocial ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Persona elem = new Entidades.Persona();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Persona> ListaPorCuityIdPersona(string Cuit, string IdPersona, CedServicios.Entidades.Enum.TipoPersona TipoPersona)
        {
            List<Entidades.Persona> lista = new List<Entidades.Persona>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Persona.Cuit, Persona.IdTipoDoc, Persona.NroDoc, Persona.IdPersona, Persona.DesambiguacionCuitPais, Persona.RazonSocial, Persona.DescrTipoDoc, Persona.Calle, Persona.Nro, Persona.Piso, Persona.Depto, Persona.Sector, Persona.Torre, Persona.Manzana, Persona.Localidad, Persona.IdProvincia, Persona.DescrProvincia, Persona.CodPost, Persona.NombreContacto, Persona.EmailContacto, Persona.TelefonoContacto, Persona.IdCondIVA, Persona.DescrCondIVA, Persona.NroIngBrutos, Persona.IdCondIngBrutos, Persona.DescrCondIngBrutos, Persona.GLN, Persona.FechaInicioActividades, Persona.CodigoInterno, Persona.EmailAvisoVisualizacion, Persona.PasswordAvisoVisualizacion, Persona.IdWF, Persona.Estado, Persona.UltActualiz, Persona.EsCliente, Persona.EsProveedor, Persona.EmailAvisoComprobanteActivo, Persona.EmailAvisoComprobanteDe, Persona.EmailAvisoComprobanteCco, Persona.EmailAvisoComprobanteAsunto, Persona.EmailAvisoComprobanteCuerpo, Persona.IdListaPrecioVenta, Persona.IdListaPrecioCompra ");
                a.Append("from Persona ");
                a.Append("where Persona.Cuit='" + Cuit + "' and Persona.IdPersona='" + IdPersona + "'");
                switch (TipoPersona.ToString())
                {
                    case "Cliente":
                        a.Append("and Persona.EsCliente=1 ");
                        break;
                    case "Proveedor":
                        a.Append("and Persona.EsProveedor=1 ");
                        break;
                    case "Ambos":
                        break;
                }
                a.Append("order by Persona.RazonSocial ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Persona elem = new Entidades.Persona();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Persona> ListaSegunFiltros(string Cuit, string RazSoc, string NroDoc, string Estado, CedServicios.Entidades.Enum.TipoPersona TipoPersona)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("Select Persona.Cuit, Persona.IdTipoDoc, Persona.NroDoc, Persona.IdPersona, Persona.DesambiguacionCuitPais, Persona.RazonSocial, Persona.DescrTipoDoc, Persona.Calle, Persona.Nro, Persona.Piso, Persona.Depto, Persona.Sector, Persona.Torre, Persona.Manzana, Persona.Localidad, Persona.IdProvincia, Persona.DescrProvincia, Persona.CodPost, Persona.NombreContacto, Persona.EmailContacto, Persona.TelefonoContacto, Persona.IdCondIVA, Persona.DescrCondIVA, Persona.NroIngBrutos, Persona.IdCondIngBrutos, Persona.DescrCondIngBrutos, Persona.GLN, Persona.FechaInicioActividades, Persona.CodigoInterno, Persona.EmailAvisoVisualizacion, Persona.PasswordAvisoVisualizacion, Persona.IdWF, Persona.Estado, Persona.UltActualiz, Persona.EsCliente, Persona.EsProveedor, Persona.EmailAvisoComprobanteActivo, Persona.EmailAvisoComprobanteDe, Persona.EmailAvisoComprobanteCco, Persona.EmailAvisoComprobanteAsunto, Persona.EmailAvisoComprobanteCuerpo, Persona.IdListaPrecioVenta, Persona.IdListaPrecioCompra ");
            a.AppendLine("from Persona where 1=1 ");
            if (Cuit != String.Empty) a.AppendLine("and Cuit like '%" + Cuit + "%' ");
            if (RazSoc != String.Empty) a.AppendLine("and RazonSocial like '%" + RazSoc + "%' ");
            if (NroDoc != String.Empty) a.AppendLine("and NroDoc like '%" + NroDoc + "%' ");
            if (Estado != String.Empty) a.AppendLine("and Estado = '" + Estado + "' ");
            switch (TipoPersona.ToString())
            {
                case "Cliente":
                    a.Append("and Persona.EsCliente=1 ");
                    break;
                case "Proveedor":
                    a.Append("and Persona.EsProveedor=1 ");
                    break;
                case "Ambos":
                    break;
            }
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Persona> lista = new List<Entidades.Persona>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Persona persona = new Entidades.Persona();
                    Copiar(dt.Rows[i], persona);
                    lista.Add(persona);
                }
            }
            return lista;
        }
        public List<Entidades.Persona> ListaPaging(int IndicePagina, string OrderBy, string SessionID, List<Entidades.Persona> PersonaLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #Persona" + SessionID + "( ");
            a.Append("[Cuit] [varchar](11) NOT NULL, ");
            a.Append("[IdTipoDoc] [numeric](2,0) NOT NULL, ");
            a.Append("[NroDoc] [varchar](11) NOT NULL, ");
            a.Append("[IdPersona] [varchar](50) NOT NULL, ");
            a.Append("[DesambiguacionCuitPais] [int] NOT NULL, ");
            a.Append("[RazonSocial] [varchar](50) NOT NULL, ");
            a.Append("[DescrTipoDoc] [varchar](50) NOT NULL, ");
            a.Append("[Calle] [varchar](30) NOT NULL, ");
            a.Append("[Nro] [varchar](6) NOT NULL, ");
            a.Append("[Piso] [varchar](5) NOT NULL, ");
            a.Append("[Depto] [varchar](5) NOT NULL, ");
            a.Append("[Localidad] [varchar](25) NOT NULL, ");
            a.Append("[IdProvincia] [varchar](2) NOT NULL, ");
            a.Append("[DescrProvincia] [varchar](50) NOT NULL, ");
            a.Append("[CodPost] [varchar](8) NOT NULL, ");
            a.Append("[NombreContacto] [varchar](25) NOT NULL, ");
            a.Append("[EmailContacto] [varchar](60) NOT NULL, ");
            a.Append("[TelefonoContacto] [varchar](50) NOT NULL, ");
            a.Append("[IdWF] [int] NOT NULL, ");
            a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[UltActualiz] [varchar](18) NOT NULL, ");
            a.Append("[EsCliente] [bit] NOT NULL, ");
            a.Append("[EsProveedor] [bit] NOT NULL, ");
            a.Append("CONSTRAINT [PK_Persona" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[Cuit] ASC, ");
            a.Append("[IdTipoDoc] ASC, ");
            a.Append("[NroDoc] ASC, ");
            a.Append("[IdPersona] ASC, ");
            a.Append("[DesambiguacionCuitPais] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (Entidades.Persona Persona in PersonaLista)
            {
                a.Append("Insert #Persona" + SessionID + " values ('" + Persona.Cuit + "', '");
                a.Append(Persona.DocumentoIdTipoDoc + "', '");
                a.Append(Persona.DocumentoNro + "', '");
                a.Append(Persona.IdPersona + "', ");
                a.Append(Persona.DesambiguacionCuitPais + ", '");
                a.Append(Persona.RazonSocial + "', '");
                a.Append(Persona.DocumentoTipoDescr + "', '");
                a.Append(Persona.Domicilio.Calle + "', '");
                a.Append(Persona.Domicilio.Nro + "', '");
                a.Append(Persona.Domicilio.Piso + "', '");
                a.Append(Persona.Domicilio.Depto + "', '");
                a.Append(Persona.Domicilio.Localidad + "', '");
                a.Append(Persona.Domicilio.Provincia.Id + "', '");
                a.Append(Persona.Domicilio.Provincia.Descr + "', '");
                a.Append(Persona.Domicilio.CodPost + "', '");
                a.Append(Persona.Contacto.Nombre + "', '");
                a.Append(Persona.Contacto.Email + "', '");
                a.Append(Persona.Contacto.Telefono + "', ");
                a.Append(Persona.WF.Id + ", '");
                a.Append(Persona.Estado + "', ");
                a.Append(Persona.UltActualiz + ",");
                int esCliente = Persona.EsCliente ? 1 : 0;
                a.Append(esCliente.ToString() + ",");
                int esProveedor = Persona.EsProveedor ? 1 : 0;
                a.Append(esProveedor.ToString() + ")");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Cuit, IdTipoDoc, NroDoc, IdPersona, DesambiguacionCuitPais, RazonSocial, DescrTipoDoc, Calle, Nro, Piso, Depto, Localidad, IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, IdWF, Estado, UltActualiz, EsCliente, EsProveedor ");
            a.Append("from #Persona" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #Persona" + SessionID);
            if (OrderBy.Trim().ToUpper() == "CUIT" || OrderBy.Trim().ToUpper() == "CUIT DESC" || OrderBy.Trim().ToUpper() == "CUIT ASC")
            {
                OrderBy = "#Persona" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "DOCUMENTOTIPODESCR" || OrderBy.Trim().ToUpper() == "DOCUMENTOTIPODOC DESC" || OrderBy.Trim().ToUpper() == "DOCUMENTOTIPODOC ASC")
            {
                OrderBy = "#Persona" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "DOCUMENTONRO" || OrderBy.Trim().ToUpper() == "DOCUMENTONRODOC DESC" || OrderBy.Trim().ToUpper() == "DOCUMENTONRODOC ASC")
            {
                OrderBy = "#Persona" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "RAZONSOCIAL" || OrderBy.Trim().ToUpper() == "RAZONSOCIAL DESC" || OrderBy.Trim().ToUpper() == "RAZONSOCIAL ASC")
            {
                OrderBy = "#Persona" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "DOMICILIOCALLE" || OrderBy.Trim().ToUpper() == "DOMICILIOCALLE DESC" || OrderBy.Trim().ToUpper() == "DOMICILIOCALLE ASC")
            {
                OrderBy = "#Persona" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "ESTADO" || OrderBy.Trim().ToUpper() == "ESTADO DESC" || OrderBy.Trim().ToUpper() == "ESTADO ASC")
            {
                OrderBy = "#Persona" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * sesion.Usuario.CantidadFilasXPagina), OrderBy, (IndicePagina * sesion.Usuario.CantidadFilasXPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Persona> lista = new List<Entidades.Persona>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.Persona persona = new Entidades.Persona();
                    persona.Cuit = dt.Rows[i]["Cuit"].ToString();
                    persona.Documento.Tipo.Id = dt.Rows[i]["IdTipoDoc"].ToString();
                    persona.Documento.Nro = Convert.ToString(dt.Rows[i]["NroDoc"].ToString());
                    persona.IdPersona = dt.Rows[i]["IdPersona"].ToString();
                    persona.DesambiguacionCuitPais = Convert.ToInt32(dt.Rows[i]["DesambiguacionCuitPais"].ToString());
                    persona.RazonSocial = dt.Rows[i]["RazonSocial"].ToString();
                    persona.Documento.Tipo.Descr = dt.Rows[i]["DescrTipoDoc"].ToString();
                    persona.Domicilio.Calle = dt.Rows[i]["Calle"].ToString();
                    persona.Domicilio.Nro = dt.Rows[i]["Nro"].ToString();
                    persona.Domicilio.Piso = dt.Rows[i]["Piso"].ToString();
                    persona.Domicilio.Depto = dt.Rows[i]["Depto"].ToString();
                    persona.Domicilio.Localidad = dt.Rows[i]["Localidad"].ToString();
                    persona.Domicilio.CodPost = dt.Rows[i]["CodPost"].ToString();
                    persona.Contacto.Nombre = dt.Rows[i]["NombreContacto"].ToString();
                    persona.Contacto.Email = dt.Rows[i]["EmailContacto"].ToString();
                    persona.Contacto.Telefono = dt.Rows[i]["TelefonoContacto"].ToString();
                    persona.WF.Id = Convert.ToInt32(dt.Rows[i]["IdWF"].ToString());
                    persona.WF.Estado = dt.Rows[i]["Estado"].ToString();
                    persona.UltActualiz = dt.Rows[i]["UltActualiz"].ToString();
                    persona.EsCliente = Convert.ToBoolean(dt.Rows[i]["EsCliente"]);
                    persona.EsProveedor = Convert.ToBoolean(dt.Rows[i]["EsProveedor"]);
                    lista.Add(persona);
                }
            }
            return lista;
        }
        public void LeerDestinatariosFrecuentes(Entidades.Persona persona, bool IncluirVacio)
        {
            persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes.Clear();
            if (IncluirVacio) persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes.Add(new Entidades.DestinatarioFrecuente(string.Empty, string.Empty, string.Empty));
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("DestinatarioFrecuente.IdDestinatarioFrecuente, DestinatarioFrecuente.Para, DestinatarioFrecuente.Cc ");
            a.Append("from DestinatarioFrecuente ");
            string idTipoDocumento = "0";
            if (persona.Documento.Tipo.Id != null) idTipoDocumento = persona.Documento.Tipo.Id;
            a.AppendLine("where Cuit='" + persona.Cuit + "' and IdTipoDoc=" + idTipoDocumento + " and NroDoc='" + persona.Documento.Nro.ToString() + "' and IdPersona='" + persona.IdPersona + "' and DesambiguacionCuitPais=" + persona.DesambiguacionCuitPais.ToString() + " ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    AgregarDestinatarioFrecuente(dt.Rows[i], persona);
                }
            }
        }
        public string EliminarDestinatariosFrecuentesHandler(Entidades.Persona persona)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("delete DestinatarioFrecuente ");
            a.AppendLine("where Cuit='" + persona.Cuit + "' and IdTipoDoc=" + persona.Documento.Tipo.Id + " and NroDoc='" + persona.Documento.Nro.ToString() + "' and IdPersona='" + persona.IdPersona + "' and DesambiguacionCuitPais=" + persona.DesambiguacionCuitPais.ToString() + " ");
            return a.ToString();
        }
        public string AgregarDestinatariosFrecuentesHandler(Entidades.Persona Persona)
        {
            System.Text.StringBuilder a = new StringBuilder();
            for (int i = 0; i < Persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes.Count; i++)
            {
                a.Append("insert DestinatarioFrecuente (Cuit, IdTipoDoc, NroDoc, IdPersona, DesambiguacionCuitPais, IdDestinatarioFrecuente, Para, Cc) values (");
                a.Append("'" + Persona.Cuit + "', ");
                a.Append(Persona.Documento.Tipo.Id + ", ");
                a.Append("'" + Persona.Documento.Nro.ToString() + "', ");
                a.Append("'" + Persona.IdPersona + "', ");
                a.Append(Persona.DesambiguacionCuitPais.ToString() + ", ");
                a.Append("'" + Persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes[i].Id + "', ");
                a.Append("'" + Persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes[i].Para + "', ");
                a.AppendLine("'" + Persona.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes[i].Cc + "') ");
            }
            return a.ToString();
        }
        private void AgregarDestinatarioFrecuente(DataRow Desde, Entidades.Persona Hasta)
        {
            Entidades.DestinatarioFrecuente elem = new Entidades.DestinatarioFrecuente();
            elem.Id = Convert.ToString(Desde["IdDestinatarioFrecuente"]);
            elem.Para = Convert.ToString(Desde["Para"]);
            elem.Cc = Convert.ToString(Desde["Cc"]);
            Hasta.DatosEmailAvisoComprobantePersona.DestinatariosFrecuentes.Add(elem);
        }
    }
}