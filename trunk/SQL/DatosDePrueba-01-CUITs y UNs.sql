declare @idWF varchar(256)
declare @accionTipo varchar(15)
declare @accionNro varchar(256)
set @accionTipo='AltaCUIT'
update Configuracion set @accionNro=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoAccionNro'

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[Cuit]
           ([Cuit]
           ,[RazonSocial]
           ,[Calle]
           ,[Nro]
           ,[Piso]
           ,[Depto]
           ,[Sector]
           ,[Torre]
           ,[Manzana]
           ,[Localidad]
           ,[IdProvincia]
           ,[DescrProvincia]
           ,[CodPost]
           ,[NombreContacto]
           ,[EmailContacto]
           ,[TelefonoContacto]
           ,[IdCondIVA]
           ,[DescrCondIVA]
           ,[NroIngBrutos]
           ,[IdCondIngBrutos]
           ,[DescrCondIngBrutos]
           ,[GLN]
           ,[FechaInicioActividades]
           ,[CodigoInterno]
           ,[IdMedio]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('30710015062'
           ,'Cedeira Software Factory S.R.L.'
           ,'Arenales'
           ,'3457'
           ,'3'
           ,'A'
           ,''
           ,''
           ,''
           ,'C.A.B.A.'
           ,'1'
           ,'Capital Federal'
           ,'1425'
           ,'Claudio A. Cedeira'
           ,'claudio.cedeira@gmail.com'
           ,'4824-7428'
           ,1
           ,'IVA Responsable inscripto'
           ,'1171649-05'
           ,1
           ,'Contribuyente Local'
           ,0
           ,'20070307'
           ,''
           ,'Conocido'
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Cuit', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[Permiso]
           ([IdUsuario]
           ,[Cuit]
           ,[IdUN]
           ,[IdTipoPermiso]
           ,[FechaFinVigencia]
           ,[IdUsuarioSolicitante]
           ,[AccionTipo]
           ,[AccionNro]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('claudio.cedeira'
           ,'30710015062'
           ,''
           ,'AdminCUIT'
           ,'20621231'
           ,''
           ,@accionTipo
           ,@accionNro
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Permiso', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[UN]
           ([Cuit]
           ,[IdUN]
           ,[DescrUN]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('30710015062'
           ,1
           ,'Sucursal Buenos Aires'
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'UN', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[Permiso]
           ([IdUsuario]
           ,[Cuit]
           ,[IdUN]
           ,[IdTipoPermiso]
           ,[FechaFinVigencia]
           ,[IdUsuarioSolicitante]
           ,[AccionTipo]
           ,[AccionNro]
           ,[IdWF]
           ,[Estado])
     VALUES
           (''
           ,'30710015062'
           ,1
           ,'UsoCUITxUN'
           ,'20621231'
           ,''
           ,@accionTipo
           ,@accionNro
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Permiso', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[Permiso]
           ([IdUsuario]
           ,[Cuit]
           ,[IdUN]
           ,[IdTipoPermiso]
           ,[FechaFinVigencia]
           ,[IdUsuarioSolicitante]
           ,[AccionTipo]
           ,[AccionNro]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('claudio.cedeira'
           ,'30710015062'
           ,1
           ,'AdminUN'
           ,'20621231'
           ,''
           ,@accionTipo
           ,@accionNro
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Permiso', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[Permiso]
           ([IdUsuario]
           ,[Cuit]
           ,[IdUN]
           ,[IdTipoPermiso]
           ,[FechaFinVigencia]
           ,[IdUsuarioSolicitante]
           ,[AccionTipo]
           ,[AccionNro]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('claudio.cedeira'
           ,'30710015062'
           ,1
           ,'eFact'
           ,'20621231'
           ,''
           ,@accionTipo
           ,@accionNro
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Permiso', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 
set @accionTipo='AltaUN'
update Configuracion set @accionNro=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoAccionNro'

INSERT INTO [CedeiraSERVICIOS].[dbo].[UN]
           ([Cuit]
           ,[IdUN]
           ,[DescrUN]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('30710015062'
           ,2
           ,'Sucursal Mar del Plata'
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'UN', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[Permiso]
           ([IdUsuario]
           ,[Cuit]
           ,[IdUN]
           ,[IdTipoPermiso]
           ,[FechaFinVigencia]
           ,[IdUsuarioSolicitante]
           ,[AccionTipo]
           ,[AccionNro]
           ,[IdWF]
           ,[Estado])
     VALUES
           (''
           ,'30710015062'
           ,2
           ,'UsoCUITxUN'
           ,'20621231'
           ,''
           ,@accionTipo
           ,@accionNro
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Permiso', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[Permiso]
           ([IdUsuario]
           ,[Cuit]
           ,[IdUN]
           ,[IdTipoPermiso]
           ,[FechaFinVigencia]
           ,[IdUsuarioSolicitante]
           ,[AccionTipo]
           ,[AccionNro]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('claudio.cedeira'
           ,'30710015062'
           ,2
           ,'AdminUN'
           ,'20621231'
           ,''
           ,@accionTipo
           ,@accionNro
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Permiso', 'Alta', 'Vigente', 'Alta x script')

update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF' 

INSERT INTO [CedeiraSERVICIOS].[dbo].[Permiso]
           ([IdUsuario]
           ,[Cuit]
           ,[IdUN]
           ,[IdTipoPermiso]
           ,[FechaFinVigencia]
           ,[IdUsuarioSolicitante]
           ,[AccionTipo]
           ,[AccionNro]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('claudio.cedeira'
           ,'30710015062'
           ,2
           ,'eFact'
           ,'20621231'
           ,''
           ,@accionTipo
           ,@accionNro
           ,@idWF
           ,'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Permiso', 'Alta', 'Vigente', 'Alta x script')
