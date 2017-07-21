insert into Persona 
(cuit, IdTipoDoc, NroDoc, IdPersona, DesambiguacionCuitPais, RazonSocial, DescrTipoDoc, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, 
IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, IdCondIVA, DescrCondIVA, NroIngBrutos, IdCondIngBrutos, DescrCondIngBrutos, 
GLN, FechaInicioActividades, CodigoInterno, EmailAvisoVisualizacion, PasswordAvisoVisualizacion, IdWF, Estado, EsCliente, EsProveedor, EmailAvisoComprobanteActivo, 
EmailAvisoComprobanteDe, EmailAvisoComprobanteCco, EmailAvisoComprobanteAsunto, EmailAvisoComprobanteCuerpo, IdListaPrecioVenta, IdListaPrecioCompra) 
select '20149013874', IdTipoDoc, NroDoc, IdPersona, DesambiguacionCuitPais, RazonSocial, DescrTipoDoc, Calle, Nro, Piso, Depto, Sector, Torre, Manzana, Localidad, 
IdProvincia, DescrProvincia, CodPost, NombreContacto, EmailContacto, TelefonoContacto, IdCondIVA, DescrCondIVA, NroIngBrutos, IdCondIngBrutos, DescrCondIngBrutos, 
GLN, FechaInicioActividades, CodigoInterno, EmailAvisoVisualizacion, PasswordAvisoVisualizacion, 0, Estado, EsCliente, EsProveedor, EmailAvisoComprobanteActivo, 
EmailAvisoComprobanteDe, EmailAvisoComprobanteCco, EmailAvisoComprobanteAsunto, EmailAvisoComprobanteCuerpo, IdListaPrecioVenta, IdListaPrecioCompra 
from Persona
where cuit = '27165995703'

declare @IdWF varchar(256)
declare @IdTipoDoc numeric(2,0)
declare @NroDoc numeric(11,0)
declare @IdPersona varchar(50)
declare @DesambiguacionCuitPais int
DECLARE db_cursor CURSOR FOR select IdTipoDoc, NroDoc, IdPersona, DesambiguacionCuitPais from Persona where Cuit='20149013874' order by IdTipoDoc, NroDoc, IdPersona, DesambiguacionCuitPais
OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @IdTipoDoc, @NroDoc, @IdPersona, @DesambiguacionCuitPais
WHILE @@FETCH_STATUS = 0   
BEGIN
	update Configuracion set @IdWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
	update Persona set IdWF=@IdWF where Cuit='20149013874' and IdTipoDoc=@IdTipoDoc and NroDoc=@NroDoc and IdPersona=@IdPersona and DesambiguacionCuitPais=@DesambiguacionCuitPais
	insert Log values (@IdWF, getdate(), 'orellana', 'Persona', 'Alta', 'Vigente', 'AUTOM')
	FETCH NEXT FROM db_cursor INTO @IdTipoDoc, @NroDoc, @IdPersona, @DesambiguacionCuitPais
END   
CLOSE db_cursor   
DEALLOCATE db_cursor
go


insert into Articulo (Cuit, IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, IdWF, Estado) 
select '20149013874', IdArticulo, DescrArticulo, GTIN, IdUnidad, DescrUnidad, IndicacionExentoGravado, AlicuotaIVA, 0, Estado 
from Articulo 
where cuit = '27165995703'

declare @idWF varchar(256)
declare @IdArticulo varchar(20)
DECLARE db_cursor CURSOR FOR select IdArticulo from Articulo where Cuit='20149013874' order by IdArticulo
OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @IdArticulo
WHILE @@FETCH_STATUS = 0   
BEGIN
	update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
	update Articulo set IdWF=@IdWF where Cuit='20149013874' and IdArticulo=@IdArticulo
	insert Log values (@IdWF, getdate(), 'orellana', 'Articulo', 'Alta', 'Vigente', 'AUTOM')
	FETCH NEXT FROM db_cursor INTO @IdArticulo
END   
CLOSE db_cursor   
DEALLOCATE db_cursor
go


insert into ListaPrecio (Cuit, IdListaPrecio, DescrListaPrecio, IdWF, Estado, Orden, IdTipoListaPrecio)
select '20149013874', IdListaPrecio, DescrListaPrecio, 0, Estado, Orden, IdTipoListaPrecio
from ListaPrecio 
where cuit = '27165995703'

declare @idWF varchar(256)
declare @IdListaPrecio varchar(20)
DECLARE db_cursor CURSOR FOR select IdListaPrecio from ListaPrecio where Cuit='20149013874' order by IdListaPrecio
OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @IdListaPrecio
WHILE @@FETCH_STATUS = 0   
BEGIN
	update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
	update ListaPrecio set IdWF=@IdWF where Cuit='20149013874' and IdListaPrecio=@IdListaPrecio
	insert Log values (@IdWF, getdate(), 'orellana', 'ListaPrecio', 'Alta', 'Vigente', 'AUTOM')
	FETCH NEXT FROM db_cursor INTO @IdListaPrecio
END   
CLOSE db_cursor   
DEALLOCATE db_cursor
go