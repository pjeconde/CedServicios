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
           ,32000
           ,'Vigente')
GO
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
           ,'AltaCUIT'
           ,15000
           ,32001
           ,'Vigente')
GO
INSERT INTO [CedeiraSERVICIOS].[dbo].[UN]
           ([Cuit]
           ,[IdUN]
           ,[DescrUN]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('30710015062'
           ,'BUE'
           ,'Sucursal Buenos Aires'
           ,32002
           ,'Vigente')
GO
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
           ,'BUE'
           ,'AdminUN'
           ,'20621231'
           ,''
           ,'AltaUN'
           ,15001
           ,32003
           ,'Vigente')
GO
INSERT INTO [CedeiraSERVICIOS].[dbo].[UN]
           ([Cuit]
           ,[IdUN]
           ,[DescrUN]
           ,[IdWF]
           ,[Estado])
     VALUES
           ('30710015062'
           ,'MDQ'
           ,'Sucursal Mar del Plata'
           ,32004
           ,'Vigente')
GO
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
           ,'MDQ'
           ,'AdminUN'
           ,'20621231'
           ,''
           ,'AltaUN'
           ,15002
           ,32005
           ,'Vigente')
GO
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
           ,'MDQ'
           ,'eFact'
           ,'20621231'
           ,''
           ,'Solic'
           ,15003
           ,32006
           ,'Vigente')
GO
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
           ,'BUE'
           ,'eFact'
           ,'20621231'
           ,''
           ,'Solic'
           ,15004
           ,32007
           ,'Vigente')
GO