SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BusquedaLaboral](
	[Email] [varchar](128) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[NombreArchCV] [varchar](128) NOT NULL,
	[IdBusquedaPerfil] [varchar](15) NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[Suscribe] [bit] NOT NULL,
	[Comentario] [varchar](256) NOT NULL,
	[Estado] [varchar](15) NOT NULL,
 CONSTRAINT [PK_BusquedaLaboral] PRIMARY KEY CLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BusquedaPerfil](
	[IdBusquedaPerfil] [varchar](15) NOT NULL,
	[DescrBusquedaPerfil] [varchar](128) NOT NULL,
	[Estado] [varchar](15) NOT NULL,
 CONSTRAINT [PK_BusquedaPerfil] PRIMARY KEY CLUSTERED 
(
	[IdBusquedaPerfil] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert BusquedaPerfil values ('DesaJr', 'Desarrollador Jr', 'Vigente')
insert BusquedaPerfil values ('DesaSSr', 'Desarrollador SSr', 'Vigente')
insert BusquedaPerfil values ('DesaSr', 'Desarrollador Sr', 'Vigente')
insert BusquedaPerfil values ('ATecSSr', 'Analista Tecnico SSr', 'Vigente')
insert BusquedaPerfil values ('ATecSr', 'Analista Tecnico Sr', 'Vigente')
insert BusquedaPerfil values ('AFunSSr', 'Analista Funcional SSr', 'DeBaja')
insert BusquedaPerfil values ('AFunSr', 'Analista Funcional Sr', 'DeBaja')
GO
