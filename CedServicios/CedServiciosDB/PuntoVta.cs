using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CedServicios.DB
{
    public class PuntoVta : db
    {
        public PuntoVta(Entidades.Sesion Sesion) : base(Sesion)
        {
        }

        public List<Entidades.PuntoVta> ListaPorUN()
        {
            List<Entidades.PuntoVta> lista = new List<Entidades.PuntoVta>();
            if (sesion.UN.Id != 0)
            {
                System.Text.StringBuilder a = new StringBuilder();
                a.Append("select PuntoVta.Cuit, PuntoVta.NroPuntoVta, PuntoVta.IdUN, PuntoVta.IdTipoPuntoVta, PuntoVta.UsaSetPropioDeDatosCuit, PuntoVta.Calle, PuntoVta.Nro, PuntoVta.Piso, PuntoVta.Depto, PuntoVta.Sector, PuntoVta.Torre, PuntoVta.Manzana, PuntoVta.Localidad, PuntoVta.IdProvincia, PuntoVta.DescrProvincia, PuntoVta.CodPost, PuntoVta.NombreContacto, PuntoVta.EmailContacto, PuntoVta.TelefonoContacto, PuntoVta.IdCondIVA, PuntoVta.DescrCondIVA, PuntoVta.NroIngBrutos, PuntoVta.IdCondIngBrutos, PuntoVta.DescrCondIngBrutos, PuntoVta.GLN, PuntoVta.FechaInicioActividades, PuntoVta.CodigoInterno, PuntoVta.IdMetodoGeneracionNumeracionLote, PuntoVta.UltNroLote, PuntoVta.IdWF, PuntoVta.Estado, PuntoVta.UltActualiz ");
                a.Append("from PuntoVta ");
                a.Append("where PuntoVta.Cuit='" + sesion.Cuit.Nro + "' and PuntoVta.IdUN='" + sesion.UN.Id + "' ");
                a.Append("order by PuntoVta.NroPuntoVta ");
                DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Entidades.PuntoVta elem = new Entidades.PuntoVta();
                        Copiar(dt.Rows[i], elem);
                        lista.Add(elem);
                    }
                }
            }
            return lista;
        }
        private void Copiar(DataRow Desde, Entidades.PuntoVta Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Nro = Convert.ToInt32(Desde["NroPuntoVta"]);
            Hasta.IdUN = Convert.ToInt32(Desde["IdUN"]);
            Hasta.IdTipoPuntoVta = Convert.ToString(Desde["IdTipoPuntoVta"]);
            Hasta.UsaSetPropioDeDatosCuit = Convert.ToBoolean(Desde["UsaSetPropioDeDatosCuit"]);
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
            Hasta.IdMetodoGeneracionNumeracionLote = Convert.ToString(Desde["IdMetodoGeneracionNumeracionLote"]);
            Hasta.UltNroLote = Convert.ToInt64(Desde["UltNroLote"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = ByteArray2TimeStamp((byte[])Desde["UltActualiz"]);
        }
        private void Copiar_ListaPaging(DataRow Desde, Entidades.PuntoVta Hasta)
        {
            Hasta.Cuit = Convert.ToString(Desde["Cuit"]);
            Hasta.Nro = Convert.ToInt32(Desde["NroPuntoVta"]);
            Hasta.IdUN = Convert.ToInt32(Desde["IdUN"]);
            Hasta.IdTipoPuntoVta = Convert.ToString(Desde["IdTipoPuntoVta"]);
            Hasta.UsaSetPropioDeDatosCuit = Convert.ToBoolean(Desde["UsaSetPropioDeDatosCuit"]);
            //Hasta.Domicilio.Calle = Convert.ToString(Desde["Calle"]);
            //Hasta.Domicilio.Nro = Convert.ToString(Desde["Nro"]);
            //Hasta.Domicilio.Piso = Convert.ToString(Desde["Piso"]);
            //Hasta.Domicilio.Depto = Convert.ToString(Desde["Depto"]);
            //Hasta.Domicilio.Sector = Convert.ToString(Desde["Sector"]);
            //Hasta.Domicilio.Torre = Convert.ToString(Desde["Torre"]);
            //Hasta.Domicilio.Manzana = Convert.ToString(Desde["Manzana"]);
            //Hasta.Domicilio.Localidad = Convert.ToString(Desde["Localidad"]);
            //Hasta.Domicilio.Provincia.Id = Convert.ToString(Desde["IdProvincia"]);
            //Hasta.Domicilio.Provincia.Descr = Convert.ToString(Desde["DescrProvincia"]);
            //Hasta.Domicilio.CodPost = Convert.ToString(Desde["CodPost"]);
            //Hasta.Contacto.Nombre = Convert.ToString(Desde["NombreContacto"]);
            //Hasta.Contacto.Email = Convert.ToString(Desde["EmailContacto"]);
            //Hasta.Contacto.Telefono = Convert.ToString(Desde["TelefonoContacto"]);
            //Hasta.DatosImpositivos.IdCondIVA = Convert.ToInt32(Desde["IdCondIVA"]);
            //Hasta.DatosImpositivos.DescrCondIVA = Convert.ToString(Desde["DescrCondIVA"]);
            //Hasta.DatosImpositivos.NroIngBrutos = Convert.ToString(Desde["NroIngBrutos"]);
            //Hasta.DatosImpositivos.IdCondIngBrutos = Convert.ToInt32(Desde["IdCondIngBrutos"]);
            //Hasta.DatosImpositivos.DescrCondIngBrutos = Convert.ToString(Desde["DescrCondIngBrutos"]);
            //Hasta.DatosImpositivos.FechaInicioActividades = Convert.ToDateTime(Desde["FechaInicioActividades"]);
            //Hasta.DatosIdentificatorios.GLN = Convert.ToInt64(Desde["GLN"]);
            //Hasta.DatosIdentificatorios.CodigoInterno = Convert.ToString(Desde["CodigoInterno"]);
            Hasta.IdMetodoGeneracionNumeracionLote = Convert.ToString(Desde["IdMetodoGeneracionNumeracionLote"]);
            Hasta.UltNroLote = Convert.ToInt64(Desde["UltNroLote"]);
            Hasta.WF.Id = Convert.ToInt32(Desde["IdWF"]);
            Hasta.WF.Estado = Convert.ToString(Desde["Estado"]);
            Hasta.UltActualiz = Convert.ToString(Desde["UltActualiz"]);
        }
        
        public void Crear(Entidades.PuntoVta PuntoVta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.AppendLine("declare @idWF varchar(256) ");
            a.AppendLine("update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' ");
            a.Append("Insert PuntoVta (Cuit, NroPuntoVta, IdUN, IdTipoPuntoVta, UsaSetPropioDeDatosCuit, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, IdCondIVA, DescrCondIVA, NroIngBrutos, IdCondIngBrutos, DescrCondIngBrutos, FechaInicioActividades, GLN, CodigoInterno, IdMetodoGeneracionNumeracionLote, UltNroLote, IdWF, Estado) values (");
            a.Append("'" + PuntoVta.Cuit + "', ");
            a.Append("'" + PuntoVta.Nro + "', ");
            a.Append(PuntoVta.IdUN + ", ");
            a.Append("'" + PuntoVta.IdTipoPuntoVta + "', ");
            a.Append(Convert.ToInt32(PuntoVta.UsaSetPropioDeDatosCuit ? 1:0) + ", ");
            a.Append("'" + PuntoVta.Domicilio.Calle + "', ");
            a.Append("'" + PuntoVta.Domicilio.Nro + "', ");
            a.Append("'" + PuntoVta.Domicilio.Piso + "', ");
            a.Append("'" + PuntoVta.Domicilio.Depto + "', ");
            a.Append("'" + PuntoVta.Domicilio.Sector + "', ");
            a.Append("'" + PuntoVta.Domicilio.Torre + "', ");
            a.Append("'" + PuntoVta.Domicilio.Manzana + "', ");
            a.Append("'" + PuntoVta.Domicilio.Localidad + "', ");
            a.Append("'" + PuntoVta.Domicilio.Provincia.Id + "', ");
            a.Append("'" + PuntoVta.Domicilio.Provincia.Descr + "', ");
            a.Append("'" + PuntoVta.Domicilio.CodPost + "', ");
            a.Append("'" + PuntoVta.Contacto.Nombre + "', ");
            a.Append("'" + PuntoVta.Contacto.Email + "', ");
            a.Append("'" + PuntoVta.Contacto.Telefono + "', ");
            a.Append("'" + PuntoVta.DatosImpositivos.IdCondIVA + "', ");
            a.Append("'" + PuntoVta.DatosImpositivos.DescrCondIVA + "', ");
            a.Append("'" + PuntoVta.DatosImpositivos.NroIngBrutos + "', ");
            a.Append("'" + PuntoVta.DatosImpositivos.IdCondIngBrutos + "', ");
            a.Append("'" + PuntoVta.DatosImpositivos.DescrCondIngBrutos + "', ");
            a.Append("'" + PuntoVta.DatosImpositivos.FechaInicioActividades.ToString("yyyyMMdd") + "', ");
            a.Append(PuntoVta.DatosIdentificatorios.GLN.ToString() + ", ");
            a.Append("'" + PuntoVta.DatosIdentificatorios.CodigoInterno + "', ");
            a.Append("'" + PuntoVta.IdMetodoGeneracionNumeracionLote + "', ");
            a.Append(PuntoVta.UltNroLote + ", ");
            a.Append("@idWF, ");
            a.Append("'" + PuntoVta.WF.Estado + "' ");
            a.AppendLine(") ");
            a.AppendLine("insert Log values (@idWF, getdate(), '" + sesion.Usuario.Id + "', 'PuntoVta', 'Alta', '" + PuntoVta.WF.Estado + "', '') ");
            a.AppendLine();
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void Modificar(Entidades.PuntoVta Desde, Entidades.PuntoVta Hasta)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update PuntoVta set ");
            a.Append("IdUN=" + Hasta.IdUN + ", ");
            a.Append("IdTipoPuntoVta='" + Hasta.IdTipoPuntoVta + "', ");
            a.Append("UsaSetPropioDeDatosCuit=" + Convert.ToInt32(Hasta.UsaSetPropioDeDatosCuit ? 1 : 0) + ", ");
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
            a.Append("IdMetodoGeneracionNumeracionLote='" + Hasta.IdMetodoGeneracionNumeracionLote + "', ");
            a.Append("UltNroLote=" + Hasta.UltNroLote + " ");
            a.AppendLine("where Cuit='" + Hasta.Cuit + "' and NroPuntoVta=" + Hasta.Nro + " ");
            a.AppendLine("insert Log values (" + Hasta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'PuntoVta', 'Modif', '" + Hasta.WF.Estado + "', '') ");
            a.AppendLine("declare @idLog int ");
            a.AppendLine("select @idLog=@@Identity ");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Desde', '" + Funciones.ObjetoSerializadoParaSQL(Desde) + "')");
            a.AppendLine("insert LogDetalle (IdLog, TipoDetalle, Detalle) values (@idLog, 'Hasta', '" + Funciones.ObjetoSerializadoParaSQL(Hasta) + "')");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void CambiarEstado(Entidades.PuntoVta PuntoVta, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("update PuntoVta set ");
            a.Append("Estado='" + Estado + "' ");
            a.AppendLine("where Cuit='" + PuntoVta.Cuit + "' and NroPuntoVta=" + PuntoVta.Nro + " ");
            string evento = (Estado == "DeBaja") ? "Baja" : "AnulBaja";
            a.AppendLine("insert Log values (" + PuntoVta.WF.Id.ToString() + ", getdate(), '" + sesion.Usuario.Id + "', 'PuntoVta', '" + evento + "', '" + Estado + "', '') ");
            Ejecutar(a.ToString(), TipoRetorno.None, Transaccion.Usa, sesion.CnnStr);
        }
        public void GenerarNuevoNroLote(Entidades.PuntoVta PuntoVta)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("declare @UltNroLote decimal(14,0) ");
            switch (PuntoVta.IdMetodoGeneracionNumeracionLote)
            {
                case "Autonumerador":
                    a.Append("update PuntoVta set @UltNroLote=UltNroLote=UltNroLote+1 ");
                    break;
                case "TimeStamp1":
                    //se arma de la siguiente manera: "AAAAMMDDHHMMSS"
                    a.Append("update PuntoVta set @UltNroLote=UltNroLote=left(convert(varchar, getdate(), 112) + replace(convert(varchar, getdate(), 114), ':', ''), 14) ");
                    break;
                case "TimeStamp2":
                    //se arma de la siguiente manera: "dias transcurridos desde el 01/01/2013" & "HHMMSSmmm"
                    a.Append("update PuntoVta set @UltNroLote=UltNroLote=convert(numeric(14), convert(varchar, datediff(d, CONVERT(Datetime, '20130101', 112), CONVERT(Datetime, convert(varchar, getdate(), 112), 112))) + replace(convert(varchar, getdate(), 114), ':', '')) ");
                    break;
                default:
                    throw new EX.Validaciones.ValorInvalido("IdMetodoGeneracionNumeracionLote='" + PuntoVta.IdMetodoGeneracionNumeracionLote + "'");
            }
            a.Append("where PuntoVta.Cuit='" + PuntoVta.Cuit + "' and PuntoVta.NroPuntoVta='" + PuntoVta.Nro + "' ");
            a.Append("select @UltNroLote as UltNroLote ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            PuntoVta.UltNroLote = Convert.ToInt64(dt.Rows[0]["UltNroLote"]);
        }
        public List<Entidades.PuntoVta> ListaSegunFiltros(string Cuit, string IdUN, string Nro, string Estado)
        {
            StringBuilder a = new StringBuilder(string.Empty);
            a.Append("select PuntoVta.Cuit, PuntoVta.NroPuntoVta, PuntoVta.IdUN, PuntoVta.IdTipoPuntoVta, PuntoVta.UsaSetPropioDeDatosCuit, PuntoVta.Calle, PuntoVta.Nro, PuntoVta.Piso, PuntoVta.Depto, PuntoVta.Sector, PuntoVta.Torre, PuntoVta.Manzana, PuntoVta.Localidad, PuntoVta.IdProvincia, PuntoVta.DescrProvincia, PuntoVta.CodPost, PuntoVta.NombreContacto, PuntoVta.EmailContacto, PuntoVta.TelefonoContacto, PuntoVta.IdCondIVA, PuntoVta.DescrCondIVA, PuntoVta.NroIngBrutos, PuntoVta.IdCondIngBrutos, PuntoVta.DescrCondIngBrutos, PuntoVta.GLN, PuntoVta.FechaInicioActividades, PuntoVta.CodigoInterno, PuntoVta.IdMetodoGeneracionNumeracionLote, PuntoVta.UltNroLote, PuntoVta.IdWF, PuntoVta.Estado, PuntoVta.UltActualiz ");
            a.AppendLine("from PuntoVta where 1=1 ");
            if (Cuit != String.Empty) a.AppendLine("and Cuit like '%" + Cuit + "%' ");
            if (IdUN != String.Empty) a.AppendLine("and IdUN = '" + IdUN + "' ");
            if (Nro != String.Empty) a.AppendLine("and NroPuntoVta = '" + Nro + "' ");
            if (Estado != String.Empty) a.AppendLine("and Estado = '" + Estado + "' ");
            DataTable dt = (DataTable)Ejecutar(a.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.PuntoVta> lista = new List<Entidades.PuntoVta>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.PuntoVta PuntoVta = new Entidades.PuntoVta();
                    Copiar(dt.Rows[i], PuntoVta);
                    lista.Add(PuntoVta);
                }
            }
            return lista;
        }
        public List<Entidades.PuntoVta> ListaPaging(int IndicePagina, string OrderBy, string SessionID, List<Entidades.PuntoVta> PuntoVtaLista)
        {
            System.Text.StringBuilder a = new StringBuilder();
            a.Append("CREATE TABLE #PuntoVta" + SessionID + "( ");
            a.Append("[Cuit] [varchar](11) NOT NULL, ");
            a.Append("[NroPuntoVta] [numeric](4,0) NOT NULL, ");
            a.Append("[IdUN] [int] NOT NULL, ");
            a.Append("[IdTipoPuntoVta] [varchar](15) NOT NULL, ");
            a.Append("[UsaSetPropioDeDatosCuit] [bit] NOT NULL, ");
            a.Append("[IdMetodoGeneracionNumeracionLote] [varchar](15) NOT NULL, ");
            a.Append("[UltNroLote] [numeric](14, 0) NOT NULL, ");
            a.Append("[IdWF] [int] NOT NULL, ");
            a.Append("[Estado] [varchar](15) NOT NULL, ");
            a.Append("[UltActualiz] [varchar](18) NOT NULL, ");
            a.Append("CONSTRAINT [PK_PuntoVta" + SessionID + "] PRIMARY KEY CLUSTERED ");
            a.Append("( ");
            a.Append("[Cuit] ASC, ");
            a.Append("[NroPuntoVta] ASC ");
            a.Append(")WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY] ");
            a.Append(") ON [PRIMARY] ");
            foreach (Entidades.PuntoVta PuntoVta in PuntoVtaLista)
            {
                a.Append("Insert #PuntoVta" + SessionID + " values ('" + PuntoVta.Cuit + "', ");
                a.Append(PuntoVta.Nro + ", ");
                a.Append(PuntoVta.IdUN + ", '");
                a.Append(PuntoVta.IdTipoPuntoVta + "', '");
                a.Append(PuntoVta.UsaSetPropioDeDatosCuit + "', '");
                a.Append(PuntoVta.IdMetodoGeneracionNumeracionLote + "', ");
                a.Append(PuntoVta.UltNroLote + ", ");
                a.Append(PuntoVta.WF.Id + ", '");
                a.Append(PuntoVta.Estado + "', ");
                a.Append(PuntoVta.UltActualiz + ")");
            }
            a.Append("select * ");
            a.Append("from (select top {0} ROW_NUMBER() OVER (ORDER BY {1}) as ROW_NUM, ");
            a.Append("Cuit, NroPuntoVta, IdUN, IdTipoPuntoVta, UsaSetPropioDeDatosCuit, IdMetodoGeneracionNumeracionLote, UltNroLote, IdWF, Estado, UltActualiz ");
            a.Append("from #PuntoVta" + SessionID + " ");
            a.Append("ORDER BY ROW_NUM) innerSelect WHERE ROW_NUM > {2} ");
            a.Append("DROP TABLE #PuntoVta" + SessionID);
            if (OrderBy.Trim().ToUpper() == "CUIT" || OrderBy.Trim().ToUpper() == "CUIT DESC" || OrderBy.Trim().ToUpper() == "CUIT ASC")
            {
                OrderBy = "#PuntoVta" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "IDUN" || OrderBy.Trim().ToUpper() == "IDUN DESC" || OrderBy.Trim().ToUpper() == "IDUN ASC")
            {
                OrderBy = "#PuntoVta" + SessionID + "." + OrderBy;
            }
            if (OrderBy.Trim().ToUpper() == "NRO" || OrderBy.Trim().ToUpper() == "NRO DESC" || OrderBy.Trim().ToUpper() == "NRO ASC")
            {
                OrderBy = "#PuntoVta" + SessionID + "." + OrderBy.Replace("Nro", "NroPuntoVta");
            }
            if (OrderBy.Trim().ToUpper() == "ESTADO" || OrderBy.Trim().ToUpper() == "ESTADO DESC" || OrderBy.Trim().ToUpper() == "ESTADO ASC")
            {
                OrderBy = "#PuntoVta" + SessionID + "." + OrderBy;
            }
            string commandText = string.Format(a.ToString(), ((IndicePagina + 1) * sesion.Usuario.CantidadFilasXPagina), OrderBy, (IndicePagina * sesion.Usuario.CantidadFilasXPagina));
            DataTable dt = new DataTable();
            dt = (DataTable)Ejecutar(commandText.ToString(), TipoRetorno.TB, Transaccion.NoAcepta, sesion.CnnStr);
            List<Entidades.PuntoVta> lista = new List<Entidades.PuntoVta>();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Entidades.PuntoVta PuntoVta = new Entidades.PuntoVta();
                    Copiar_ListaPaging(dt.Rows[i], PuntoVta);
                    lista.Add(PuntoVta);
                }
            }
            return lista;
        }
    }
}
