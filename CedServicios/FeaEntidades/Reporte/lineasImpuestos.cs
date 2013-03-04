using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.Reporte
{
	[System.ComponentModel.DataObject]
	public partial class lineasImpuestos
	{
		private List<lineaImpuestos> listadelineas;

		public lineasImpuestos()
		{
			listadelineas = new List<lineaImpuestos>();
		}

		[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Fill, true)]
		public List<lineaImpuestos> Listar()
		{
			return listadelineas;
		}

		[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
		public void Actualizar(lineaImpuestos l)
		{
		}

		[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
		public void Insertar(lineaImpuestos l)
		{
			listadelineas.Add(l);
		}

		[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
		public void Borrar(lineaImpuestos l)
		{
			listadelineas.Remove(l);
		}

	}
}
