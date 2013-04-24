SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Email] [varchar](128) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Pregunta] [varchar](256) NOT NULL,
	[Respuesta] [varchar](256) NOT NULL,
	[CantidadEnviosMail] [int] NOT NULL,
	[FechaUltimoReenvioMail] [datetime] NOT NULL,
	[EmailSMS] [varchar](50) NOT NULL,
	[IdWF] [int] NOT NULL,
	[Estado] [varchar](15) NOT NULL,
	[UltActualiz] [timestamp] NOT NULL,
 CONSTRAINT [PK_Table_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
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
CREATE TABLE [dbo].[Medio](
	[IdMedio] [varchar](15) NOT NULL,
	[DescrMedio] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table_Medio] PRIMARY KEY CLUSTERED 
(
	[IdMedio] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert Medio values ('Internet', 'Internet')
insert Medio values ('Interfacturas', 'Recomendado por Interfacturas')
insert Medio values ('Conocido', 'Recomendado por un conocido')
insert Medio values ('Mail', 'Mail')
insert Medio values ('Merc.Libre', 'Mercado Libre')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuit](
	[Cuit] [varchar](11) NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[Calle] [varchar](30) NOT NULL,
	[Nro] [varchar](6) NOT NULL,
	[Piso] [varchar](5) NOT NULL,
	[Depto] [varchar](5) NOT NULL,
	[Sector] [varchar](5) NOT NULL,
	[Torre] [varchar](5) NOT NULL,
	[Manzana] [varchar](5) NOT NULL,
	[Localidad] [varchar](25) NOT NULL,
	[IdProvincia] [varchar](2) NOT NULL,
	[DescrProvincia] [varchar](50) NOT NULL,
	[CodPost] [varchar](8) NOT NULL,
	[NombreContacto] [varchar](25) NOT NULL,
	[EmailContacto] [varchar](60) NOT NULL,
	[TelefonoContacto] [varchar](50) NOT NULL,
	[IdCondIVA] [numeric](2, 0) NOT NULL,
	[DescrCondIVA] [varchar](50) NOT NULL,
	[NroIngBrutos] [varchar](13) NOT NULL,
	[IdCondIngBrutos] [numeric](2, 0) NOT NULL,
	[DescrCondIngBrutos] [varchar](50) NOT NULL,
	[GLN] [numeric](13, 0) NOT NULL,
	[FechaInicioActividades] [datetime] NOT NULL,
	[CodigoInterno] [varchar](20) NOT NULL,
	[IdMedio] [varchar](15) NOT NULL,
	[IdWF] [int] NOT NULL,
	[Estado] [varchar](15) NOT NULL,
	[UltActualiz] [timestamp] NOT NULL,
 CONSTRAINT [PK_Table_Cuit] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cuit]  WITH CHECK ADD  CONSTRAINT [FK_Cuit_Medio]
FOREIGN KEY([IdMedio])
REFERENCES [dbo].[Medio] ([IdMedio])
GO
ALTER TABLE [dbo].[Cuit] CHECK CONSTRAINT [FK_Cuit_Medio]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UN](
	[Cuit] [varchar](11) NOT NULL,
	[IdUN] [int] NOT NULL,
	[DescrUN] [varchar](50) NOT NULL,
	[IdWF] [int] NOT NULL,
	[Estado] [varchar](15) NOT NULL,
	[UltActualiz] [timestamp] NOT NULL,
 CONSTRAINT [PK_Table_UN] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC, 
	[IdUN] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[UN]  WITH CHECK ADD  CONSTRAINT [FK_UN_Cuit] FOREIGN KEY([Cuit])
REFERENCES [dbo].[Cuit] ([Cuit])
GO
ALTER TABLE [dbo].[UN] CHECK CONSTRAINT [FK_UN_Cuit]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPuntoVta](
	[IdTipoPuntoVta] [varchar](15) NOT NULL,
 CONSTRAINT [PK_TipoPuntoVta] PRIMARY KEY CLUSTERED 
(
	[IdTipoPuntoVta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert TipoPuntoVta values ('BonoFiscal')
insert TipoPuntoVta values ('Exportacion')
insert TipoPuntoVta values ('Comun')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MetodoGeneracionNumeracionLote](
	[IdMetodoGeneracionNumeracionLote] [varchar](15) NOT NULL,
 CONSTRAINT [PK_MetodoGeneracionNumeracionLote] PRIMARY KEY CLUSTERED 
(
	[IdMetodoGeneracionNumeracionLote] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert MetodoGeneracionNumeracionLote values ('Ninguno')
insert MetodoGeneracionNumeracionLote values ('Autonumerador')
insert MetodoGeneracionNumeracionLote values ('TimeStamp')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PuntoVta](
	[Cuit] [varchar](11) NOT NULL,
	[NroPuntoVta] [numeric](4) NOT NULL,
	[IdUN] [int] NOT NULL,
	[IdTipoPuntoVta] [varchar](15) NOT NULL,
	[UsaSetPropioDeDatosCuit] [bit] NOT NULL,
	[Calle] [varchar](30) NOT NULL,
	[Nro] [varchar](6) NOT NULL,
	[Piso] [varchar](5) NOT NULL,
	[Depto] [varchar](5) NOT NULL,
	[Sector] [varchar](5) NOT NULL,
	[Torre] [varchar](5) NOT NULL,
	[Manzana] [varchar](5) NOT NULL,
	[Localidad] [varchar](25) NOT NULL,
	[IdProvincia] [varchar](2) NOT NULL,
	[DescrProvincia] [varchar](50) NOT NULL,
	[CodPost] [varchar](8) NOT NULL,
	[NombreContacto] [varchar](25) NOT NULL,
	[EmailContacto] [varchar](60) NOT NULL,
	[TelefonoContacto] [varchar](50) NOT NULL,
	[IdCondIVA] [numeric](2, 0) NOT NULL,
	[DescrCondIVA] [varchar](50) NOT NULL,
	[NroIngBrutos] [varchar](13) NOT NULL,
	[IdCondIngBrutos] [numeric](2, 0) NOT NULL,
	[DescrCondIngBrutos] [varchar](50) NOT NULL,
	[GLN] [numeric](13, 0) NOT NULL,
	[FechaInicioActividades] [datetime] NOT NULL,
	[CodigoInterno] [varchar](20) NOT NULL,
	[IdMetodoGeneracionNumeracionLote] [varchar](15) NOT NULL,
	[UltNroLote] [numeric](14, 0) NOT NULL,
	[IdWF] [int] NOT NULL,
	[Estado] [varchar](15) NOT NULL,
	[UltActualiz] [timestamp] NOT NULL,
 CONSTRAINT [PK_Table_PuntoVta] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC, 
	[NroPuntoVta] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[PuntoVta]  WITH CHECK ADD  CONSTRAINT [FK_PuntoVta_Cuit] FOREIGN KEY([Cuit])
REFERENCES [dbo].[Cuit] ([Cuit])
GO
ALTER TABLE [dbo].[PuntoVta] CHECK CONSTRAINT [FK_PuntoVta_Cuit]
GO
ALTER TABLE [dbo].[PuntoVta]  WITH CHECK ADD  CONSTRAINT [FK_PuntoVta_TipoPuntoVta] FOREIGN KEY([IdTipoPuntoVta])
REFERENCES [dbo].[TipoPuntoVta] ([IdTipoPuntoVta])
GO
ALTER TABLE [dbo].[PuntoVta] CHECK CONSTRAINT [FK_PuntoVta_TipoPuntoVta]
GO
ALTER TABLE [dbo].[PuntoVta]  WITH CHECK ADD  CONSTRAINT [FK_PuntoVta_MetodoGeneracionNumeracionLote] FOREIGN KEY([IdMetodoGeneracionNumeracionLote])
REFERENCES [dbo].[MetodoGeneracionNumeracionLote] ([IdMetodoGeneracionNumeracionLote])
GO
ALTER TABLE [dbo].[PuntoVta] CHECK CONSTRAINT [FK_PuntoVta_MetodoGeneracionNumeracionLote]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPermiso](
	[IdTipoPermiso] [varchar](15) NOT NULL,
	[DescrTipoPermiso] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoPermiso] PRIMARY KEY CLUSTERED 
(
	[IdTipoPermiso] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert TipoPermiso values ('AdminCUIT', 'Administrador del CUIT')
insert TipoPermiso values ('AdminSITE', 'Administrador del site')
insert TipoPermiso values ('AdminUN', 'Administrador de la UN')
insert TipoPermiso values ('UsoCUITxUN', 'Habilitación relación UN-CUIT')
insert TipoPermiso values ('eFact', 'Operador servicio eFact')
insert TipoPermiso values ('eFactArticulos', 'Operador servicio eFactArticulos')
insert TipoPermiso values ('eFactITFonline', 'Operador servicio eFactITFonline')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Permiso](
	[IdUsuario] [varchar](50) NOT NULL,
	[Cuit] [varchar](11) NOT NULL,
	[IdUN] [int] NOT NULL,
	[IdTipoPermiso] [varchar](15) NOT NULL,
	[FechaFinVigencia] [datetime] NOT NULL,
	[IdUsuarioSolicitante] [varchar](50) NOT NULL,
	[AccionTipo] [varchar](15) NOT NULL,
	[AccionNro] [int] NOT NULL,
	[IdWF] [int] NOT NULL,
	[Estado] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_Permiso] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[Cuit] ASC,
	[IdUN] ASC,
	[IdTipoPermiso] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso_TipoPermiso] FOREIGN KEY([IdTipoPermiso])
REFERENCES [dbo].[TipoPermiso] ([IdTipoPermiso])
GO
ALTER TABLE [dbo].[Permiso] CHECK CONSTRAINT [FK_Permiso_TipoPermiso]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Configuracion](
	[IdUsuario] [varchar](50) NOT NULL,
	[Cuit] [varchar](11) NOT NULL,
	[IdUN] [int] NOT NULL,
	[IdTipoPermiso] [varchar](15) NOT NULL,
	[IdItemConfig] [varchar](50) NOT NULL,
	[Valor] [varchar](256) NOT NULL,
 CONSTRAINT [PK_Configuracion] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[Cuit] ASC,
	[IdUN] ASC,
	[IdTipoPermiso] ASC,
	[IdItemConfig] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert Configuracion values ('', '', '', '', 'UltimoIdWF', '0')
insert Configuracion values ('', '', '', '', 'UltimoAccionNro', '0')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Log](
	[IdLog] [int] IDENTITY(1,1) NOT NULL,
	[IdWF] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdUsuario] [varchar](50) NOT NULL,
	[Entidad] [varchar](15) NOT NULL,
	[Evento] [varchar](15) NOT NULL,
	[Estado] [varchar](15) NOT NULL,
	[Comentario] [varchar](256) NOT NULL,
 CONSTRAINT [PK_Table_Log] PRIMARY KEY CLUSTERED 
(
	[IdLog] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
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
CREATE TABLE [dbo].[LogDetalle](
	[IdLogDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdLog] [int] NOT NULL,
	[TipoDetalle] [varchar](50) NOT NULL,
	[Detalle] [text] NOT NULL,
 CONSTRAINT [PK_Table_LogDetalle] PRIMARY KEY CLUSTERED 
(
	[IdLogDetalle] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[LogDetalle]  WITH CHECK ADD  CONSTRAINT [FK_LogDetalle_Log] FOREIGN KEY([IdLog])
REFERENCES [dbo].[Log] ([IdLog])
GO
ALTER TABLE [dbo].[LogDetalle] CHECK CONSTRAINT [FK_LogDetalle_Log]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cliente](
	[Cuit] [varchar](11) NOT NULL,
	[IdTipoDoc] [numeric](2, 0) NOT NULL,
	[NroDoc] [numeric](11, 0) NOT NULL,
	[IdCliente] [varchar](50) NOT NULL,
	[DesambiguacionCuitPais] [int] NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[DescrTipoDoc] [varchar](50) NOT NULL,
	[Calle] [varchar](30) NOT NULL,
	[Nro] [varchar](6) NOT NULL,
	[Piso] [varchar](5) NOT NULL,
	[Depto] [varchar](5) NOT NULL,
	[Sector] [varchar](5) NOT NULL,
	[Torre] [varchar](5) NOT NULL,
	[Manzana] [varchar](5) NOT NULL,
	[Localidad] [varchar](25) NOT NULL,
	[IdProvincia] [varchar](2) NOT NULL,
	[DescrProvincia] [varchar](50) NOT NULL,
	[CodPost] [varchar](8) NOT NULL,
	[NombreContacto] [varchar](25) NOT NULL,
	[EmailContacto] [varchar](60) NOT NULL,
	[TelefonoContacto] [varchar](50) NOT NULL,
	[IdCondIVA] [numeric](2, 0) NOT NULL,
	[DescrCondIVA] [varchar](50) NOT NULL,
	[NroIngBrutos] [varchar](13) NOT NULL,
	[IdCondIngBrutos] [numeric](2, 0) NOT NULL,
	[DescrCondIngBrutos] [varchar](50) NOT NULL,
	[GLN] [numeric](13, 0) NOT NULL,
	[FechaInicioActividades] [datetime] NOT NULL,
	[CodigoInterno] [varchar](20) NOT NULL,
	[EmailAvisoVisualizacion] [varchar](128) NOT NULL,
	[PasswordAvisoVisualizacion] [varchar](50) NOT NULL,
	[IdWF] [int] NOT NULL,
	[Estado] [varchar](15) NOT NULL,
	[UltActualiz] [timestamp] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC, 
	[IdTipoDoc] ASC, 
	[NroDoc] ASC, 
	[IdCliente] ASC,  
	[DesambiguacionCuitPais] ASC 
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Cuit] FOREIGN KEY([Cuit])
REFERENCES [dbo].[Cuit] ([Cuit])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Cuit]
GO
