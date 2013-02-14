using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class Usuario : db
    {
        public Usuario(Entidades.Sesion Sesion)
            : base(Sesion)
        {
        }

        public void Leer(Entidades.Usuario Usuario)
        {

            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Usuario.IdUsuario, Usuario.Nombre, Usuario.Telefono, Usuario.Email, Usuario.Password, Usuario.Pregunta, Usuario.Respuesta, Usuario.CantidadEnviosMail, Usuario.FechaUltimoReenvioMail, Usuario.EmailSMS, Usuario.IdWF, Usuario.Estado, Usuario.UltActualiz ");
            a.Append("from Usuario ");
            a.Append("where Usuario.IdUsuario='" + Usuario.Id + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (dt.Rows.Count == 0)
            {
                throw new CedServicios.EX.Validaciones.ElementoInexistente("Usuario " + Usuario.Id);
            }
            else
            {
                Copiar(dt.Rows[0], Usuario);
            }
        }
        private void Copiar(DataRow Desde, Entidades.Usuario Hasta)
        {
            Hasta.Id = Convert.ToString(Desde["IdUsuario"]);
            Hasta.Nombre = Convert.ToString(Desde["Nombre"]);
            Hasta.Telefono = Convert.ToString(Desde["Telefono"]);
            Hasta.Email = Convert.ToString(Desde["Email"]);
            Hasta.Password = Convert.ToString(Desde["Password"]);
            Hasta.Pregunta = Convert.ToString(Desde["Pregunta"]);
            Hasta.Respuesta = Convert.ToString(Desde["Respuesta"]);
            Hasta.CantidadEnviosMail = Convert.ToInt32(Desde["CantidadEnviosMail"]);
            Hasta.FechaUltimoReenvioMail = Convert.ToDateTime(Desde["FechaUltimoReenvioMail"]);
            Hasta.EmailSMS = Convert.ToString(Desde["EmailSMS"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
        }
        public void Crear(Entidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("declare @idWF varchar(256) ");
            a.Append("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert Usuario (IdUsuario, Nombre, Telefono, Email, Password, Pregunta, Respuesta, CantidadEnviosMail, FechaUltimoReenvioMail, EmailSMS, IdWF, Estado) values (");
            a.Append("'" + Usuario.Id + "', ");
            a.Append("'" + Usuario.Nombre + "', ");
            a.Append("'" + Usuario.Telefono + "', ");
            a.Append("'" + Usuario.Email + "', ");
            a.Append("'" + Usuario.Password + "', ");
            a.Append("'" + Usuario.Pregunta + "', ");
            a.Append("'" + Usuario.Respuesta + "', ");
            a.Append("1, ");            //CantidadEnviosMail
            a.Append("getdate(), ");    //FechaUltimoReenvioMail
            a.Append("'', ");           //EmailSMS
            a.Append("@idWF, ");        //IdWF
            a.Append("'" + Usuario.WF.Estado + "' ");
            a.Append(")");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.NoAcepta, sesion.CnnStr);
        }
        public void Confirmar(Entidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("declare @idWF varchar(256) ");
            a.Append("declare @cantFilas int ");
            a.Append("select @idWF = IdWF from Usuario where IdUsuario='" + Usuario.Id + "' ");
            a.Append("update Usuario set Estado='Vigente' where IdUsuario='" + Usuario.Id + "' and Estado='PteConfig' ");
            a.Append("set @cantFilas = @@ROWCOUNT ");
            a.Append("if @cantFilas = 1 ");
            a.Append("    insert Log values (@idWF, getdate(), '" + Usuario.Id + "', 'Usuario', 'Confirm', 'Vigente', '') ");
            a.Append("select @cantFilas as CantFilas ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            if (Convert.ToInt32(dt.Rows[0]["CantFilas"]) != 1)
            {
                throw new EX.Usuario.ErrorDeConfirmacion();
            }
        }
        public bool IdUsuarioDisponible(Entidades.Usuario Usuario)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("IF EXISTS(select * from Usuario where IdUsuario='" + Usuario.Id + "') ");
            a.Append("  BEGIN ");
            a.Append("	select convert(bit, 0) as Disponible ");
            a.Append("  END ");
            a.Append("ELSE ");
            a.Append("  BEGIN ");
            a.Append("	select convert(bit, 1) as Disponible ");
            a.Append("  END ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToBoolean(dt.Rows[0]["Disponible"]);
        }
        public List<Entidades.Usuario> DestinatariosAvisoAltaUsuario()
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select Cuenta.IdCuenta, Cuenta.Nombre, Cuenta.Telefono, Cuenta.Email, Cuenta.Password, Cuenta.Pregunta, Cuenta.Respuesta, Cuenta.IdTipoCuenta, TipoCuenta.DescrTipoCuenta, Cuenta.IdEstadoCuenta, EstadoCuenta.DescrEstadoCuenta, Cuenta.UltimoNroLote, Cuenta.FechaAlta, Cuenta.CantidadEnviosMail, Cuenta.FechaUltimoReenvioMail, Cuenta.IdMedio, Medio.DescrMedio, Cuenta.EmailSMS, Cuenta.RecibeAvisoAltaCuenta, Cuenta.CantidadComprobantes, Cuenta.FechaUltimoComprobante, Cuenta.FechaVtoPremium, Cuenta.IdPaginaDefault, Cuenta.NroSerieCertificado, PaginaDefault.DescrPaginaDefault, PaginaDefault.URL, Cuenta.CantidadActivacionesCPs ");
            a.Append("from Cuenta, TipoCuenta, EstadoCuenta, Medio, PaginaDefault ");
            a.Append("where RecibeAvisoAltaCuenta=1 and EmailSMS<>'' ");
            a.Append("and Cuenta.IdTipoCuenta=TipoCuenta.IdTipoCuenta and Cuenta.IdEstadoCuenta=EstadoCuenta.IdEstadoCuenta and Cuenta.IdMedio=Medio.IdMedio and Cuenta.IdPaginaDefault=PaginaDefault.IdPaginaDefault ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.Usuario> lista = new List<Entidades.Usuario>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Entidades.Usuario usuario = new Entidades.Usuario();
                Copiar(dt.Rows[i], usuario);
                lista.Add(usuario);
            }
            return lista;
        }
        public int CantidadDeFilas()
        {
            string commandText = "select count(*) from Usuario ";
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText, TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            return Convert.ToInt32(dt.Rows[0][0]);
        }
    }
}