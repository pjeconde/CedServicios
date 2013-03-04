using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CedServicios.Site.Facturacion.Electronica.Mails
{
	internal static class Body
	{
		internal static string AgregarBody()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.AppendLine("ESTE MENSAJE SE HA GENERADO AUTOMÁTICAMENTE.");
			sb.AppendLine("");
			sb.AppendLine("Alguien nos pidió que le enviáramos este archivo.");
			sb.AppendLine("Si no ha iniciado esta petición, por favor ignórela. Si necesita asistencia adicional, por favor visítenos en http://www.cedeira.com.ar o envíenos un correo electrónico a facturaelectronica@cedeira.com.ar");
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendLine("Si es el archivo que está esperando, siga las siguientes instrucciones:");
			sb.AppendLine("");
			sb.AppendLine("El archivo adjunto se encuentra formateado para ser procesado por Interfacturas.");
			sb.AppendLine("");
			sb.AppendLine("Recomendamos guardarlo en su repositorio local de facturas.");
			sb.AppendLine("");
			sb.AppendLine("Se detalla el procedimiento para validarlo en el site de Interfacturas.");
			sb.AppendLine("");
			sb.AppendLine("1) Realizar un Login en Interfacturas");
			sb.AppendLine("2) Seleccionar \"Obtención CAE\"");
			sb.AppendLine("3) \"Validador Lote\"");
			sb.AppendLine("4) Con el botón \"Examinar...\" seleccione el archivo recibido en el respositorio local de archivos XML");
			sb.AppendLine("5) Una vez encontrado, pulsar el botón \"Abrir\"");
			sb.AppendLine("6) Luego el botón \"Enviar\"");
			sb.AppendLine("7) Como respuesta, el site muestra una ventana \"Desea abrir o guardar este archivo\"");
			sb.AppendLine("Seleccionar la opción \"Guardar\" y dejar el resultado en el mismo directorio donde se encuentra el XML.");
			sb.AppendLine("8) Abrir el archivo recibido (el zip y el XML y verificar que la respuesta sea satisfactoria, de la siguiente manera:");
			sb.AppendLine("");
			sb.AppendLine("Abrir el archivo y verificar que el resultado sea OK.");
			sb.AppendLine("Para dar por aceptado el archivo, debe verificar que en el archivo XML de respuesta, se encuentre el texto:<estado>OK</estado>");
			sb.AppendLine("");
			sb.AppendLine("Se adjunta a modo de ejemplo, un archivo XML de respuesta satisfactoria:");
			sb.AppendLine("");
			sb.AppendLine("<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>");
			sb.AppendLine("<lote_comprobantes_response xmlns=\"http://lote.schemas.cfe.ib.com.ar/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
			sb.AppendLine("  <lote_response>");
			sb.AppendLine("    <id_lote>2</id_lote>");
			sb.AppendLine("    <cuit_canal>30690783521</cuit_canal>");
			sb.AppendLine("    <cuit_vendedor>30710015062</cuit_vendedor>");
			sb.AppendLine("    <cantidad_reg>1</cantidad_reg>");
			sb.AppendLine("    <presta_serv>1</presta_serv>");
			sb.AppendLine("    <fecha_envio_lote xsi:nil=\"true\"/>");
			sb.AppendLine("    <punto_de_venta>2</punto_de_venta>");
			sb.AppendLine("    <estado>OK</estado>");
			sb.AppendLine("  </lote_response>");
			sb.AppendLine("</lote_comprobantes_response>");
			sb.AppendLine("");
			sb.AppendLine("");
			sb.AppendLine("En el caso que la respuesta no sea OK, debe analizar el motivo del error y realizar los ajustes necesarios.");
			sb.AppendLine("");
			sb.AppendLine("© 2009 Cedeira Sofware Factory S.R.L. Todos los derechos reservados.");
			sb.AppendLine("Buenos Aires, Argentina");
			return sb.ToString();
		}
	}
}
