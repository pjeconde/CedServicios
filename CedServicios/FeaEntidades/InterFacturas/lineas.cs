using System;
using System.Collections.Generic;
using System.Text;

namespace FeaEntidades.InterFacturas
{
	[System.ComponentModel.DataObject]
	public partial class lineas
	{
		private List<linea> listadelineas = new List<linea>();

		public lineas()
		{
		}

		[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Fill, true)]
		public List<linea> Listar()
		{
			return listadelineas;
		}

		[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Update, true)]
		public void Actualizar(linea l)
		{
		}

		[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Insert, true)]
		public void Insertar(string descripcion, string importe_total_articulo)
		{
			linea l=new linea();
			l.descripcion = descripcion;
			l.importe_total_articulo = Convert.ToDouble(importe_total_articulo);
			listadelineas.Add(l);
		}

		public void Insertar()
		{
			linea l=new linea();
			listadelineas.Add(l);
		}

		[System.ComponentModel.DataObjectMethod(System.ComponentModel.DataObjectMethodType.Delete, true)]
		public void Borrar(linea l)
		{
			listadelineas.Remove(l);
		}

	}
}
