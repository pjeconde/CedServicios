using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Cliente : db
    {
        public Cliente(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.Cliente> ListaPorCuit()
        {
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cliente.Cuit, Cliente.IdTipoDoc, Cliente.NroDoc, Cliente.IdCliente, Cliente.RazonSocial, Cliente.DescrTipoDoc, Cliente.Calle, Cliente.Nro, Cliente.Piso, Cliente.Depto, Cliente.Sector, Cliente.Torre, Cliente.Manzana, Cliente.Localidad, Cliente.IdProvincia, Cliente.DescrProvincia, Cliente.CodPost, Cliente.NombreContacto, Cliente.EmailContacto, Cliente.TelefonoContacto, Cliente.IdCondIVA, Cliente.DescrCondIVA, Cliente.NroIngBrutos, Cliente.IdCondIngBrutos, Cliente.DescrCondIngBrutos, Cliente.GLN, Cliente.FechaInicioActividades, Cliente.CodigoInterno, Cliente.EmailAvisoVisualizacion, Cliente.PasswordAvisoVisualizacion, Cliente.IdWF, Cliente.Estado ");
                a.Append("from Cliente ");
                a.Append("where Cliente.Cuit='" + sesion.Cuit.Nro + "' ");
                a.Append("order by Cliente.RazonSocial ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Cliente elem = new Entidades.Cliente();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.Cliente Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Documento.Tipo.Id = Convert.ToString(Desde["IdTipoDoc"]);
            Hasta.Documento.Tipo.Descr = Convert.ToString(Desde["DescrTipoDoc"]);
            Hasta.Documento.Nro = Convert.ToInt64(Desde["NroDoc"]);
            Hasta.IdCliente = Convert.ToString(Desde["IdCliente"]);
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
        }
        public void Leer(Entidades.Cliente cliente)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("select ");
            a.Append("Cliente.Cuit, Cliente.IdTipoDoc, Cliente.NroDoc, Cliente.IdCliente, Cliente.RazonSocial, Cliente.DescrTipoDoc, Cliente.Calle, Cliente.Nro, Cliente.Piso, Cliente.Depto, Cliente.Sector, Cliente.Torre, Cliente.Manzana, Cliente.Localidad, Cliente.IdProvincia, Cliente.DescrProvincia, Cliente.CodPost, Cliente.NombreContacto, Cliente.EmailContacto, Cliente.TelefonoContacto, Cliente.IdCondIVA, Cliente.DescrCondIVA, Cliente.NroIngBrutos, Cliente.IdCondIngBrutos, Cliente.DescrCondIngBrutos, Cliente.GLN, Cliente.FechaInicioActividades, Cliente.CodigoInterno, Cliente.EmailAvisoVisualizacion, Cliente.PasswordAvisoVisualizacion, Cliente.IdWF, Cliente.Estado ");
            a.Append("from Cliente ");
            a.Append("where Cliente.Cuit='" + sesion.Cuit.Nro + "' and Cliente.RazonSocial = '" + cliente.RazonSocial + "'");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count != 0)
            {
                Copiar(dt.Rows[0], cliente);
            }
        }
        public void Crear(Entidades.Cliente Cliente)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert Cliente (Cuit, IdTipoDoc, NroDoc, IdCliente, RazonSocial, DescrTipoDoc, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, IdCondIVA, DescrCondIVA, NroIngBrutos, IdCondIngBrutos, DescrCondIngBrutos, FechaInicioActividades, GLN, CodigoInterno, EmailAvisoVisualizacion, PasswordAvisoVisualizacion, IdWF, Estado) values (");
            a.Append("'" + Cliente.Cuit + "', ");
            a.Append(Cliente.Documento.Tipo.Id + ", ");
            a.Append(Cliente.Documento.Nro.ToString() + ", ");
            a.Append("'" + Cliente.IdCliente + "', ");
            a.Append("'" + Cliente.RazonSocial + "', ");
            a.Append("'" + Cliente.Documento.Tipo.Descr + "', ");
            a.Append("'" + Cliente.Domicilio.Calle + "', ");
            a.Append("'" + Cliente.Domicilio.Nro + "', ");
            a.Append("'" + Cliente.Domicilio.Piso + "', ");
            a.Append("'" + Cliente.Domicilio.Depto + "', ");
            a.Append("'" + Cliente.Domicilio.Sector + "', ");
            a.Append("'" + Cliente.Domicilio.Torre + "', ");
            a.Append("'" + Cliente.Domicilio.Manzana + "', ");
            a.Append("'" + Cliente.Domicilio.Localidad + "', ");
            a.Append("'" + Cliente.Domicilio.Provincia.Id + "', ");
            a.Append("'" + Cliente.Domicilio.Provincia.Descr + "', ");
            a.Append("'" + Cliente.Domicilio.CodPost + "', ");
            a.Append("'" + Cliente.Contacto.Nombre + "', ");
            a.Append("'" + Cliente.Contacto.Email + "', ");
            a.Append("'" + Cliente.Contacto.Telefono + "', ");
            a.Append("'" + Cliente.DatosImpositivos.IdCondIVA + "', ");
            a.Append("'" + Cliente.DatosImpositivos.DescrCondIVA + "', ");
            a.Append("'" + Cliente.DatosImpositivos.NroIngBrutos + "', ");
            a.Append("'" + Cliente.DatosImpositivos.IdCondIngBrutos + "', ");
            a.Append("'" + Cliente.DatosImpositivos.DescrCondIngBrutos + "', ");
            a.Append("'" + Cliente.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd") + "', ");
            a.Append(Cliente.DatosIdentificatorios.GLN.ToString() + ", ");
            a.Append("'" + Cliente.DatosIdentificatorios.CodigoInterno + "', ");
            a.Append("'" + Cliente.EmailAvisoVisualizacion + "', ");
            a.Append("'" + Cliente.PasswordAvisoVisualizacion + "', ");
            a.Append("@idWF, ");
            a.Append("'" + Cliente.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'Cliente', 'Alta', '" + Cliente.WF.Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.Cliente Desde, Entidades.Cliente Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update Cliente set ");
            a.Append("IdCliente='" + Hasta.IdCliente + "', ");
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
            a.Append("PasswordAvisoVisualizacion='" + Hasta.PasswordAvisoVisualizacion + "' ");
            a.AppendLine("where Cuit='" + Hasta.Cuit + "' and IdTipoDoc=" + Hasta.Documento.Tipo.Id + " and NroDoc=" + Hasta.Documento.Nro.ToString() + " ");
            a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'Cliente', 'Modif', '" + Hasta.WF.Estado + "', '') ");
            a.AppendLine("declare @idLog int ");
            a.AppendLine("select @idLog=@@Identity ");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializado(Desde) + "')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializado(Hasta) + "')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public List<Entidades.Cliente> ListaPorCuityTipoyNroDoc(string Cuit, Entidades.Documento Documento)
        {
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cliente.Cuit, Cliente.IdTipoDoc, Cliente.NroDoc, Cliente.IdCliente, Cliente.RazonSocial, Cliente.DescrTipoDoc, Cliente.Calle, Cliente.Nro, Cliente.Piso, Cliente.Depto, Cliente.Sector, Cliente.Torre, Cliente.Manzana, Cliente.Localidad, Cliente.IdProvincia, Cliente.DescrProvincia, Cliente.CodPost, Cliente.NombreContacto, Cliente.EmailContacto, Cliente.TelefonoContacto, Cliente.IdCondIVA, Cliente.DescrCondIVA, Cliente.NroIngBrutos, Cliente.IdCondIngBrutos, Cliente.DescrCondIngBrutos, Cliente.GLN, Cliente.FechaInicioActividades, Cliente.CodigoInterno, Cliente.EmailAvisoVisualizacion, Cliente.PasswordAvisoVisualizacion, Cliente.IdWF, Cliente.Estado ");
                a.Append("from Cliente ");
                a.Append("where Cliente.Cuit='" + Cuit + "' and Cliente.IdTipoDoc=" + Documento.Tipo.Id + " and Cliente.NroDoc=" + Documento.Nro.ToString() + " ");
                a.Append("order by Cliente.RazonSocial ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Cliente elem = new Entidades.Cliente();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Cliente> ListaPorCuityRazonSocial(string Cuit, string RazonSocial)
        {
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cliente.Cuit, Cliente.IdTipoDoc, Cliente.NroDoc, Cliente.IdCliente, Cliente.RazonSocial, Cliente.DescrTipoDoc, Cliente.Calle, Cliente.Nro, Cliente.Piso, Cliente.Depto, Cliente.Sector, Cliente.Torre, Cliente.Manzana, Cliente.Localidad, Cliente.IdProvincia, Cliente.DescrProvincia, Cliente.CodPost, Cliente.NombreContacto, Cliente.EmailContacto, Cliente.TelefonoContacto, Cliente.IdCondIVA, Cliente.DescrCondIVA, Cliente.NroIngBrutos, Cliente.IdCondIngBrutos, Cliente.DescrCondIngBrutos, Cliente.GLN, Cliente.FechaInicioActividades, Cliente.CodigoInterno, Cliente.EmailAvisoVisualizacion, Cliente.PasswordAvisoVisualizacion, Cliente.IdWF, Cliente.Estado ");
                a.Append("from Cliente ");
                a.Append("where Cliente.Cuit='" + Cuit + "' and Cliente.RazonSocial like '%" + RazonSocial + "%' ");
                a.Append("order by Cliente.RazonSocial ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Cliente elem = new Entidades.Cliente();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        public List<Entidades.Cliente> ListaPorCuityIdCliente(string Cuit, string IdCliente)
        {
            List<Entidades.Cliente> lista = new List<Entidades.Cliente>();
            if (sesion.Cuit.Nro != null)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select ");
                a.Append("Cliente.Cuit, Cliente.IdTipoDoc, Cliente.NroDoc, Cliente.IdCliente, Cliente.RazonSocial, Cliente.DescrTipoDoc, Cliente.Calle, Cliente.Nro, Cliente.Piso, Cliente.Depto, Cliente.Sector, Cliente.Torre, Cliente.Manzana, Cliente.Localidad, Cliente.IdProvincia, Cliente.DescrProvincia, Cliente.CodPost, Cliente.NombreContacto, Cliente.EmailContacto, Cliente.TelefonoContacto, Cliente.IdCondIVA, Cliente.DescrCondIVA, Cliente.NroIngBrutos, Cliente.IdCondIngBrutos, Cliente.DescrCondIngBrutos, Cliente.GLN, Cliente.FechaInicioActividades, Cliente.CodigoInterno, Cliente.EmailAvisoVisualizacion, Cliente.PasswordAvisoVisualizacion, Cliente.IdWF, Cliente.Estado ");
                a.Append("from Cliente ");
                a.Append("where Cliente.Cuit='" + Cuit + "' and Cliente.IdCliente='" + IdCliente + "'");
                a.Append("order by Cliente.RazonSocial ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.Cliente elem = new Entidades.Cliente();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
    }
}