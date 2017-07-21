using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace CedServicios.Site
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void CodigoPrueba()
        {
            FeaEntidades.Turismo.comprobante x = new FeaEntidades.Turismo.comprobante();
            //x.cabecera.informacion_comprador.codigo_Pais;
            //x.cabecera.informacion_comprador.id_Impositivo;
            //x.cabecera.informacion_comprador.codigo_Relacion_Receptor_Emisor;
            //x.cabecera.informacion_comprador.nro_doc_identificatorio;
            
            //x.cabecera.informacion_comprobante.codigo_Autotizacion;
            //x.cabecera.informacion_comprobante.tipo_Autorizacion;

            //x.forma_pago[0].codigo;

            //x.detalle.linea[0].codigo_Turismo;

            //x.resumen.importe_Reintegro;
        }
    }
}