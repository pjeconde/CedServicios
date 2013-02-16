using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace CedServicios.EX
{
    namespace Validaciones
    {
        [Serializable]
        public class BaseApplicationException : CedServicios.EX.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ValorNoInfo : CedServicios.EX.Validaciones.BaseApplicationException
        {
            static string TextoError = "sin informar";
            public ValorNoInfo(string descrProp)
                : base(descrProp + " " + TextoError)
            {
            }
            public ValorNoInfo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ValorNoInfo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ValorInvalido : CedServicios.EX.Validaciones.BaseApplicationException
        {
            static string TextoError = "valor inválido";
            public ValorInvalido(string descrProp)
                : base(descrProp + ": " + TextoError)
            {
            }
            public ValorInvalido(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ValorInvalido(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
		public class ElementoInexistente : CedServicios.EX.Validaciones.BaseApplicationException
		{
			static string TextoError = "Inexistente";
			public ElementoInexistente(IDescrClase Elemento) : base(Elemento._Descripcion + " " + TextoError)
			{
			}
			public ElementoInexistente(IDescrClase Elemento, string Valor) : base(Elemento._Descripcion + " " + Valor + " " + TextoError)
			{
			}
			public ElementoInexistente(string Descripcion) : base(Descripcion + " " + TextoError)
			{
			}
			public ElementoInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ElementoInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
    }
    namespace Usuario
    {
        [Serializable]
        public class BaseApplicationException : CedServicios.EX.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordYConfirmacionNoCoincidente :CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "La Contraseña no coincide con su Confirmación";
            public PasswordYConfirmacionNoCoincidente()
                : base(TextoError)
            {
            }
            public PasswordYConfirmacionNoCoincidente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordYConfirmacionNoCoincidente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordNuevaIgualAActual : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "La Contraseña nueva no debe ser igual a la actual";
            public PasswordNuevaIgualAActual()
                : base(TextoError)
            {
            }
            public PasswordNuevaIgualAActual(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordNuevaIgualAActual(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class IdUsuarioNoDisponible : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "El IdUsuario, que ingresó, ya ha sido usado por otra persona.  Modifiquelo hasta encontrar un valor único.";
            public IdUsuarioNoDisponible()
                : base(TextoError)
            {
            }
            public IdUsuarioNoDisponible(Exception inner)
                : base(TextoError, inner)
            {
            }
            public IdUsuarioNoDisponible(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ParametrosAccionCompradorErroneo : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "Acción inválida sobre Comprador.  Por favor, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            public ParametrosAccionCompradorErroneo()
                : base(TextoError)
            {
            }
            public ParametrosAccionCompradorErroneo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ParametrosAccionCompradorErroneo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ErrorDeConfirmacion : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "El evento de confirmación (de creación de la cuenta eFact) no puede ejecutarse.  Es probable que la confirmación ya haya sido registrada.  Verifique si puede identificarse.  En paso contrario, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            public ErrorDeConfirmacion()
                : base(TextoError)
            {
            }
            public ErrorDeConfirmacion(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ErrorDeConfirmacion(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LoginRechazadoXEstadoCuenta : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "Login inválido (la cuenta está pendiente de confirmación o dada de baja)";
            public LoginRechazadoXEstadoCuenta()
                : base(TextoError)
            {
            }
            public LoginRechazadoXEstadoCuenta(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LoginRechazadoXEstadoCuenta(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class LoginRechazadoXPasswordInvalida : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "Contraseña inválida";
            public LoginRechazadoXPasswordInvalida()
                : base(TextoError)
            {
            }
            public LoginRechazadoXPasswordInvalida(Exception inner)
                : base(TextoError, inner)
            {
            }
            public LoginRechazadoXPasswordInvalida(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class NoHayUsuariosAsociadasAEmail : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "No hay cuentas asociadas a la dirección de correo electrónico especificada";
            public NoHayUsuariosAsociadasAEmail()
                : base(TextoError)
            {
            }
            public NoHayUsuariosAsociadasAEmail(Exception inner)
                : base(TextoError, inner)
            {
            }
            public NoHayUsuariosAsociadasAEmail(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class UsuarioConfFormatoMsgErroneo : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "El mensaje de confirmación (de creación de la cuenta eFact) tiene un formato erróneo.  Por favor, póngase en contacto con Cedeira Software Factory, para solucionar el inconveniente.  Muchas gracias.";
            public UsuarioConfFormatoMsgErroneo()
                : base(TextoError)
            {
            }
            public UsuarioConfFormatoMsgErroneo(Exception inner)
                : base(TextoError, inner)
            {
            }
            public UsuarioConfFormatoMsgErroneo(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class PasswordNoMatch : CedServicios.EX.Usuario.BaseApplicationException
        {
            static string TextoError = "Contraseña incorrecta";
            public PasswordNoMatch()
                : base(TextoError)
            {
            }
            public PasswordNoMatch(Exception inner)
                : base(TextoError, inner)
            {
            }
            public PasswordNoMatch(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
	namespace db
	{
        [Serializable]
        public class BaseApplicationException : CedServicios.EX.BaseApplicationException
        {
            public BaseApplicationException(string TextoError)
                : base(TextoError)
            {
            }
            public BaseApplicationException(string TextoError, Exception inner)
                : base(TextoError, inner)
            {
            }
            public BaseApplicationException(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
		[Serializable]
		public class Conexion : CedServicios.EX.db.BaseApplicationException
		{
			static string TextoError = "Problema de conexión a base de datos";
			public Conexion() : base(TextoError)
			{
			}
			public Conexion(Exception inner) : base(TextoError, inner)
			{
			}
			public Conexion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Ejecucion : CedServicios.EX.db.BaseApplicationException
		{
			static string TextoError = "Problema en ejecución de script de SQL";
			public Ejecucion() : base(TextoError)
			{
			}
			public Ejecucion(Exception inner) : base(TextoError, inner)
			{
			}
			public Ejecucion(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class EjecucionConRollback : CedServicios.EX.db.BaseApplicationException
		{
			static string TextoError = "Problema en ejecución de script de SQL ( Se deshizo la operacion )";
			public EjecucionConRollback() : base(TextoError)
			{
			}
			public EjecucionConRollback(Exception inner) : base(TextoError, inner)
			{
			}
			public EjecucionConRollback(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}
		[Serializable]
		public class Rollback : CedServicios.EX.db.BaseApplicationException
		{
			static string TextoError = "Problema al tratar de deshacer la ejecución de un script de SQL";
			public Rollback() : base(TextoError)
			{
			}
			public Rollback(Exception inner) : base(TextoError, inner)
			{
			}
			public Rollback(SerializationInfo info, StreamingContext context) : base(info, context)
			{
			}
		}

	}
    public static class Funciones
    {
        public static string Detalle(Exception ex)
        {
            System.Text.StringBuilder a = new System.Text.StringBuilder();
            a.Append(ex.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
            if (ex.InnerException != null)
            {
                a.Append(" (");
                a.Append(ex.InnerException.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
                a.Append(")");
            }
            return a.ToString();
        }
    }
}