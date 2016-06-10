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
            public ElementoInexistente(IDescrClase Elemento)
                : base(Elemento._Descripcion + " " + TextoError)
            {
            }
            public ElementoInexistente(IDescrClase Elemento, string Valor)
                : base(Elemento._Descripcion + " " + Valor + " " + TextoError)
            {
            }
            public ElementoInexistente(string Descripcion)
                : base(Descripcion + " " + TextoError)
            {
            }
            public ElementoInexistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ElementoInexistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ElementoYaInexistente : CedServicios.EX.Validaciones.BaseApplicationException
        {
            static string TextoError = "ya existe";
            public ElementoYaInexistente(IDescrClase Elemento)
                : base(Elemento._Descripcion + " " + TextoError)
            {
            }
            public ElementoYaInexistente(IDescrClase Elemento, string Valor)
                : base(Elemento._Descripcion + " " + Valor + " " + TextoError)
            {
            }
            public ElementoYaInexistente(string Descripcion)
                : base(Descripcion + " " + TextoError)
            {
            }
            public ElementoYaInexistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ElementoYaInexistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
		public class ArchivoInexistente : CedServicios.EX.BaseApplicationException
		{
			static string TextoError = "Archivo inexistente";
			public ArchivoInexistente() : base(TextoError)
			{
			}
			public ArchivoInexistente(string NombreArchivo) : base(TextoError + ": " + NombreArchivo)
			{
			}
			public ArchivoInexistente(Exception inner) : base(TextoError, inner)
			{
			}
			public ArchivoInexistente(SerializationInfo info, StreamingContext context) : base(info, context)
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
    namespace Permiso
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
        public class Existente : CedServicios.EX.Permiso.BaseApplicationException
        {
            static string TextoError = "Este permiso ya ha sido solicitado y está en estado ";
            public Existente(string estado)
                : base(TextoError + " '" + estado + "'")
            {
            }
            public Existente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public Existente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    namespace Cuit
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
        public class NingunServicioSeleccionado : CedServicios.EX.Cuit.BaseApplicationException
        {
            static string TextoError = "Servicio no informado (debe elegir al menos uno)";
            public NingunServicioSeleccionado()
                : base(TextoError)
            {
            }
            public NingunServicioSeleccionado(Exception inner)
                : base(TextoError, inner)
            {
            }
            public NingunServicioSeleccionado(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class NingunDestinoComprobanteSeleccionado : CedServicios.EX.Cuit.BaseApplicationException
        {
            static string TextoError = "Destino de Comprobante no informado (debe elegir al menos uno)";
            public NingunDestinoComprobanteSeleccionado()
                : base(TextoError)
            {
            }
            public NingunDestinoComprobanteSeleccionado(Exception inner)
                : base(TextoError, inner)
            {
            }
            public NingunDestinoComprobanteSeleccionado(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
    namespace Lote
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
        public class Existente : CedServicios.EX.Lote.BaseApplicationException
        {
            static string TextoError = "Lote existente.";
            public Existente(string Descr)
                : base(TextoError + "\r\n\r\n" + Descr)
            {
            }
            public Existente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public Existente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class Inexistente : CedServicios.EX.Lote.BaseApplicationException
        {
            static string TextoError = "Lote inexistente.";
            public Inexistente(string Descr)
                : base(TextoError + "\r\n\r\n" + Descr)
            {
            }
            public Inexistente(Exception inner)
                : base(TextoError, inner)
            {
            }
            public Inexistente(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ProblemasEnvio : CedServicios.EX.Lote.BaseApplicationException
        {
            static string TextoError = "Problemas al enviar el lote.";
            public ProblemasEnvio(string Descr)
                : base(TextoError + "\r\n\r\n" + Descr)
            {
            }
            public ProblemasEnvio(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ProblemasEnvio(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ProblemasConsulta : CedServicios.EX.Lote.BaseApplicationException
        {
            static string TextoError = "Problemas al consultar el lote.";
            public ProblemasConsulta(string Descr)
                : base(TextoError + "\r\n\r\n" + Descr)
            {
            }
            public ProblemasConsulta(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ProblemasConsulta(SerializationInfo info, StreamingContext context)
                : base(info, context)
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
        public static string DetalleST(Exception ex)
        {
            System.Text.StringBuilder a = new System.Text.StringBuilder();
            a.Append(ex.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
            if (ex.InnerException != null)
            {
                a.Append(" (");
                a.Append(ex.InnerException.Message.Replace("\r", string.Empty).Replace("\n", string.Empty));
                a.Append(")");
            }
            if (ex.StackTrace != null && ex.StackTrace != "")
            {
                a.Append(" StackTrace: (");
                a.Append(ex.StackTrace.Replace("\r", string.Empty).Replace("\n", string.Empty));
                a.Append(")");
            }
            return a.ToString();
        }
    }
    namespace Precio
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
        public class ArticuloInex : CedServicios.EX.Validaciones.BaseApplicationException
        {
            static string TextoError = "Los precios de la planilla NO FUERON IMPORTADOS porque hay artículos desconocidos.  Corrija esta situación y vuelva a importar los precios.  Artículo(s) inexistente(s):";
            public ArticuloInex(string descrProp)
                : base(TextoError + " " + descrProp + ".")
            {
            }
            public ArticuloInex(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ArticuloInex(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
        [Serializable]
        public class ListaPrecioInex : CedServicios.EX.Validaciones.BaseApplicationException
        {
            static string TextoError = "Los precios de la planilla NO FUERON IMPORTADOS porque hay listas de precios desconocidas.  Corrija esta situación y vuelva a importar los precios.  Lista(s) de Precios inexistente(s):";
            public ListaPrecioInex(string descrProp)
                : base(TextoError + " " + descrProp + ".")
            {
            }
            public ListaPrecioInex(Exception inner)
                : base(TextoError, inner)
            {
            }
            public ListaPrecioInex(SerializationInfo info, StreamingContext context)
                : base(info, context)
            {
            }
        }
    }
}