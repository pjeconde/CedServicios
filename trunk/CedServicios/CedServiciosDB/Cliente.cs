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
            Hasta.DatosIdentificatorios.GLN = Convert.ToInt32(Desde["GLN"]);
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
    }
}