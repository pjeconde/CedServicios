using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Migracion : db
    {
        public Migracion(Entidades.Sesion Sesion) : base(Sesion)
        {
        }
        public DataTable LeerCuenta(string IdCuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdCuenta, Nombre, Telefono, Email, Password, Pregunta, Respuesta, IdTipoCuenta, IdEstadoCuenta, UltimoNroLote, FechaAlta, CantidadEnviosMail, FechaUltimoReenvioMail, IdMedio, EmailSMS, RecibeAvisoAltaCuenta, CantidadComprobantes, FechaUltimoComprobante, FechaVtoPremium, IdPaginaDefault, NroSerieCertificado, CantidadActivacionesCPs from Cuenta where IdCuenta='" + IdCuenta + "' ");
            return (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataTable LeerVendedor(string IdCuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdCuenta, RazonSocial, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, CUIT, IdCondIVA, DescrCondIVA, NroIngBrutos, IdCondIngBrutos, DescrCondIngBrutos, GLN, CodigoInterno, FechaInicioActividades from Vendedor where IdCuenta='" + IdCuenta + "' ");
            return (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataTable LeerPuntoDeVenta(string IdCuenta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select CUIT, IdPuntoDeVenta, IdTipoPuntoDeVenta, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, IdProvincia, DescrProvincia, CodPost from PuntoDeVenta where CUIT in (select CUIT from Vendedor where IdCuenta='" + IdCuenta + "') ");
            return (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public DataTable ListaCuentasNoMigradas(string ListaIdUsuariosYaMigrados)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select IdCuenta, Nombre, Email, FechaAlta, FechaUltimoComprobante, IdEstadoCuenta from Cuenta where IdEstadoCuenta<>'PteConf' and IdCuenta not in (" + ListaIdUsuariosYaMigrados + ") order by IdEstadoCuenta desc, Nombre asc ");
            return (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
        }
    }
}