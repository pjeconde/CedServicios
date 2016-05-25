SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ListaPrecio](
	[Cuit] [varchar](11) NOT NULL,
	[IdListaPrecio] [varchar](20) NOT NULL,
	[DescrListaPrecio] [varchar](100) NOT NULL,
	[IdWF] [int] NOT NULL,
	[Estado] [varchar](15) NOT NULL,
	[UltActualiz] [timestamp] NOT NULL,
 CONSTRAINT [PK_Table_ListaPrecio] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC,
	[IdListaPrecio] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ListaPrecio]  WITH CHECK ADD  CONSTRAINT [FK_ListaPrecio_Cuit] FOREIGN KEY([Cuit])
REFERENCES [dbo].[Cuit] ([Cuit])
GO
ALTER TABLE [dbo].[ListaPrecio] CHECK CONSTRAINT [FK_ListaPrecio_Cuit]
GO

insert Entidad values ('ListaPrecio', 'Lista de Precios', '100')
go

insert TipoPermiso values ('eFactConsulta', 'Consulta servicio eFact')
go

declare @idWF varchar(256)
declare @accionTipo varchar(15)
set @accionTipo='AltaCUIT'
declare @accionNro varchar(256)declare @Cuit varchar(11)
declare @IdUsuarioSolicitante varchar(50)
DECLARE db_cursor CURSOR FOR select Cuit, IdUsuarioSolicitante from Permiso where Cuit<>'' and Permiso.IdUN=0 and Permiso.IdUsuario='' and IdTipoPermiso='eFact'
OPEN db_cursor   
FETCH NEXT FROM db_cursor INTO @Cuit, @IdUsuarioSolicitante
WHILE @@FETCH_STATUS = 0   
BEGIN
	update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
	update Configuracion set @accionNro=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoAccionNro'
	insert Permiso values ('', @Cuit, 0, 'eFactConsulta', '20621231', @IdUsuarioSolicitante, @accionTipo, @accionNro, @idWF, 'Vigente')
	insert Log values (@IdWF, getdate(), @IdUsuarioSolicitante, 'Permiso', 'Alta', 'Vigente', 'AUTOM')
	FETCH NEXT FROM db_cursor INTO @Cuit, @IdUsuarioSolicitante
END   
CLOSE db_cursor   
DEALLOCATE db_cursor
go

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Precio](
	[Cuit] [varchar](11) NOT NULL,
	[IdListaPrecio] [varchar](20) NOT NULL,
	[IdArticulo] [varchar](20) NOT NULL,
	[Valor] [numeric](15, 2) NOT NULL,
 CONSTRAINT [PK_Table_Precio] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC,
	[IdListaPrecio] ASC,
	[IdArticulo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Precio]  WITH CHECK ADD  CONSTRAINT [FK_Precio_Cuit] FOREIGN KEY([Cuit])
REFERENCES [dbo].[Cuit] ([Cuit])
GO
ALTER TABLE [dbo].[Precio] CHECK CONSTRAINT [FK_Precio_Cuit]
GO
ALTER TABLE [dbo].[Precio]  WITH CHECK ADD  CONSTRAINT [FK_Precio_ListaPrecio] FOREIGN KEY([Cuit], [IdListaPrecio])
REFERENCES [dbo].[ListaPrecio] ([Cuit], [IdListaPrecio])
GO
ALTER TABLE [dbo].[Precio] CHECK CONSTRAINT [FK_Precio_ListaPrecio]
GO
ALTER TABLE [dbo].[Precio]  WITH CHECK ADD  CONSTRAINT [FK_Precio_Articulo] FOREIGN KEY([Cuit], [IdArticulo])
REFERENCES [dbo].[Articulo] ([Cuit], [IdArticulo])
GO
ALTER TABLE [dbo].[Precio] CHECK CONSTRAINT [FK_Precio_Articulo]
GO

alter table dbo.Persona add IdListaPrecio varchar(20) null;
go
update Persona set IdListaPrecio=''
go
alter table dbo.Persona alter column IdListaPrecio varchar(20) not null;
go

