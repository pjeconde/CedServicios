/* 001-CreacionTablasyValoresIniciales */

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
	[Confirmado] [bit] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[FechaBaja] [datetime] NOT NULL,
	[CantidadEnviosMail] [int] NOT NULL,
	[FechaUltimoReenvioMail] [datetime] NOT NULL,
	[EmailSMS] [varchar](50) NOT NULL,
	[IdEmpresaPredeterminada] [varchar](50) NOT NULL,
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
CREATE TABLE [dbo].[Empresa](
	[IdEmpresa] [varchar](50) NOT NULL,
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
	[CUIT] [numeric](11, 0) NOT NULL,
	[IdCondIVA] [numeric](2, 0) NOT NULL,
	[DescrCondIVA] [varchar](50) NOT NULL,
	[NroIngBrutos] [varchar](13) NOT NULL,
	[IdCondIngBrutos] [numeric](2, 0) NOT NULL,
	[DescrCondIngBrutos] [varchar](50) NOT NULL,
	[GLN] [numeric](13, 0) NOT NULL,
	[CodigoInterno] [varchar](20) NOT NULL,




	[FechaInicioActividades] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_Empresa] PRIMARY KEY CLUSTERED 
(
	[IdEmpresa] ASC
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
CREATE TABLE [dbo].[TipoUsuario](
	[IdTipoUsuario] [varchar](15) NOT NULL,
	[DescrTipoUsuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoUsuario] PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC
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
CREATE TABLE [dbo].[EstadoUsuario](
	[IdEstadoUsuario] [varchar](15) NOT NULL,
	[DescrEstadoUsuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoUsuario] PRIMARY KEY CLUSTERED 
(
	[IdEstadoUsuario] ASC
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
CREATE TABLE [dbo].[Texto](
	[IdTexto] [varchar](50) NOT NULL,
	[DescrTexto] [text] NOT NULL,
 CONSTRAINT [PK_Texto] PRIMARY KEY CLUSTERED 
(
	[IdTexto] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
insert Texto values ('eFact-TerminosyCondiciones', 'Los siguientes términos y condiciones generales regularán expresamente las relaciones surgidas entre este Portal www.cedeira.com.ar de Cedeira Software Factory S.R.L ( en adelante "NUESTRA EMPRESA" ) y Usted (en adelante el "USUARIO o USUARIOS") en virtud de las cuales NUESTRA EMPRESA le brinda servicios de gratuito de generación de comprobantes electrónicos en un archivo de formato XML, ya sea que se trate de nuevos USUARIOS o aquellos vinculados a través de cualquier acuerdo previo que pudiera existir entre las partes. Este acuerdo sustituye cualquier otra comunicación previa oral o de otro tipo, que haya habido entre las partes.'+char(13)+'La utilización del Portal www.cedeira.com.ar atribuye la condición de USUARIO del Portal, sea persona física o jurídica, e implica la aceptación plena y sin reservas de todas y cada una de las disposiciones incluidas en estos terminos y condiciones que se detallan a contituación.'+char(13)+''+char(13)+'NUESTRA EMPRESA:'+char(13)+''+char(13)+'1.No asume ninguna responsabilidad por la utilización de los presentes modelos de carga de comprobantes, ya que sólo los ofrece en forma gratuita a modo de simplificar las tareas en la carga de la información del comprobante electrónico que solicita InterFacturas.'+char(13)+''+char(13)+'2.No asume responsabilidad alguna sobre los datos de los comprobantes que usted envíe a Interfacturas. La información generada desde este sitio web, puede ser modificada por usted.'+char(13)+''+char(13)+'3.Se reserva el derecho unilateral de suspender temporalmente o de terminar definitivamente la prestación del servicios a través del Portal.'+char(13)+''+char(13)+'4.Se reserva el derecho de modificar unilateralmente y en cualquier momento el sistema de acceso al servicio.'+char(13)+''+char(13)+'5.No garantiza que el sitio web vaya a funcionar en forma constante, fiable y correctamente, sin retrasos o interrupciones, por lo que no se hace responsable de los daños y prejuicios que puedan derivarse de los posibles fallos en disponibilidad y continuidad técnica del sitio web.'+char(13)+''+char(13)+'6.No presenta ninguna garantía, explicita o implícitamente, acerca de la utilización de este servicio gratuito.'+char(13)+''+char(13)+'7.No será responsable por cualquier daño y/o perjuicio y/o beneficio dejado de obtener por el usuario o cualquier otro tercero causados directa o indirectamente por la conexión y/o utilización y/o acceso al sitio web www.cedeira.com.ar o a páginas enlazadas a él.'+char(13)+''+char(13)+'Ley aplicable y jurisdicción competente'+char(13)+'El USUARIO acepta que la legislación aplicable al funcionamiento de este servicio es la Argentina y se somete a la jurisdicción de los juzgados y tribunales de la Ciudad Autónoma de Buenos Aires para la resolución de las devergencias que se deriven de la interpretación o aplicación de este clausulado.')
go
insert TipoUsuario values ('Free', 'Servicio gratuito')
insert TipoUsuario values ('Prem', 'Servicio premium')
insert TipoUsuario values ('Admin', 'Administrador')
go
insert EstadoUsuario values ('PteConf', 'Pendiente de confirmación')
insert EstadoUsuario values ('Vigente', 'Vigente')
insert EstadoUsuario values ('Baja', 'De baja')
insert EstadoUsuario values ('Suspend', 'Suspendida')
go
insert Usuario values ('claudio.cedeira', 'Claudio A. Cedeira', '', 'claudio.cedeira@cedeira.com.ar', 'cedeira123', 'Cual es la sigla de mi escuela secundaria', 'encjm', 'Admin', 'Vigente')
insert Usuario values ('lucas.legaspi', 'Lucas Legaspi', '', 'lucas.legaspi@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Henderson', 'Admin', 'Vigente')
insert Usuario values ('fcedeira', 'Fernando J. Cedeira', '', 'fcedeira@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Cuello', 'Admin', 'Vigente')
insert Usuario values ('marce.cdr', 'Marcela Crespi', '', 'marce.cdr@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Rodriguez', 'Admin', 'Vigente')
insert Usuario values ('pjeconde', 'Pablo J.E.Conde', '', 'pjeconde@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Cedeira', 'Admin', 'Vigente')
go

/* 002-AgregarUltimoNroLoteATablaUsuario */

alter table dbo.Usuario add UltimoNroLote numeric(14) null
go
update Usuario set UltimoNroLote=0
go
alter table dbo.Usuario alter column UltimoNroLote numeric(14) not null
go

/* 003-AgregarTablaComprador */

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comprador](
	[IdUsuario] [varchar](50) NOT NULL,
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
	[IdTipoDoc] [numeric](2, 0) NOT NULL,
	[DescrTipoDoc] [varchar](50) NOT NULL,
	[NroDoc] [numeric](11, 0) NOT NULL,
	[IdCondIVA] [numeric](2, 0) NOT NULL,
	[DescrCondIVA] [varchar](50) NOT NULL,
	[NroIngBrutos] [varchar](13) NOT NULL,
	[IdCondIngBrutos] [numeric](2, 0) NOT NULL,
	[DescrCondIngBrutos] [varchar](50) NOT NULL,
	[GLN] [numeric](13, 0) NOT NULL,
	[CodigoInterno] [varchar](20) NOT NULL,
	[FechaInicioActividades] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_Comprador] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC, 
	[RazonSocial] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Comprador]  WITH CHECK ADD  CONSTRAINT [FK_Comprador_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Comprador] CHECK CONSTRAINT [FK_Comprador_Usuario]
GO

/* 004-AgregarFechaAltaYReenvioMailATablaUsuario */

alter table dbo.Usuario add FechaAlta datetime null
go
alter table dbo.Usuario add CantidadEnviosMail int null
go
alter table dbo.Usuario add datetime null
go
update Usuario set FechaAlta='20090301 12:00:00', CantidadEnviosMail=1, FechaUltimoReenvioMail='20090301 12:00:00' where IdEstadoUsuario<>'PteConf'
go
update Usuario set FechaAlta='20090301 12:00:00', CantidadEnviosMail=2, FechaUltimoReenvioMail=getdate() where IdEstadoUsuario='PteConf'
go
alter table dbo.Usuario alter column FechaAlta datetime not null
go
alter table dbo.Usuario alter column CantidadEnviosMail int not null
go
alter table dbo.Usuario alter column FechaUltimoReenvioMail datetime not null
go

/* 005-AgregarActivCPATablaUsuario */

alter table dbo.Usuario add ActivCP bit null
go
update Usuario set ActivCP=0
go
alter table dbo.Usuario alter column ActivCP bit not null
go

/* 006-AgregarNroSerieDiscoATablaUsuario */

alter table dbo.Usuario add NroSerieDisco varchar(100) null
go
update Usuario set NroSerieDisco=''
go
alter table dbo.Usuario alter column NroSerieDisco varchar(100) not null
go

/* 007-AgregarTablaMedio */

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
go
insert Medio values ('Interfacturas', 'Recomendado por Interfacturas')
go
insert Medio values ('Conocido', 'Recomendado por un conocido')
go
insert Medio values ('Mail', 'Mail')
go
alter table dbo.Usuario add IdMedio varchar(15) null
go
update Usuario set IdMedio='Conocido' where IdTipoUsuario='Admin'
go
update Usuario set IdMedio='Interfacturas' where IdTipoUsuario<>'Admin'
go
alter table dbo.Usuario alter column IdMedio varchar(15) not null
go
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Medio] FOREIGN KEY([IdMedio])
REFERENCES [dbo].[Medio] ([IdMedio])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Medio]
GO

/* 008-AgregarEmailSMSyAvisoAltaUsuarioATablaUsuario */

alter table dbo.Usuario add EmailSMS varchar(50) null
go
alter table dbo.Usuario add RecibeAvisoAltaUsuario bit null
go
update Usuario set EmailSMS=''
go
update Usuario set RecibeAvisoAltaUsuario=0
go
alter table dbo.Usuario alter column EmailSMS varchar(50) not null
go
alter table dbo.Usuario alter column RecibeAvisoAltaUsuario bit not null
go

/* 009-AgregarCantidadComprobantesFechaUltimoComprobanteYFechaVtoPremiumATablaUsuario */

alter table dbo.Usuario add CantidadComprobantes int null
go
alter table dbo.Usuario add FechaUltimoComprobante datetime null
go
alter table dbo.Usuario add FechaVtoPremium datetime null
go
update Usuario set CantidadComprobantes=0
go
update Usuario set CantidadComprobantes=UltimoNroLote where IdTipoUsuario<>'Admin' and IdUsuario<>'Prueba' and UltimoNroLote<>0
go
update Usuario set FechaUltimoComprobante='20000101'
go
update Usuario set FechaVtoPremium='99991231'
go
alter table dbo.Usuario alter column CantidadComprobantes int not null
go
alter table dbo.Usuario alter column FechaUltimoComprobante datetime not null
go
alter table dbo.Usuario alter column FechaVtoPremium datetime not null
go

/* 010-AltaMercadoLibreComoMedio */

insert Medio values ('Merc.Libre', 'Mercado Libre')
go


/* 011-AgregarTablaPaginaDefault */

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PaginaDefault](
	[IdPaginaDefault] [varchar](15) NOT NULL,
	[DescrPaginaDefault] [varchar](50) NOT NULL,
	[URL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Table_PaginaDefault] PRIMARY KEY CLUSTERED 
(
	[IdPaginaDefault] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[PaginaDefaultXTipoUsuario](
	[IdTipoUsuario] [varchar](15) NOT NULL,
	[IdPaginaDefault] [varchar](15) NOT NULL,
	[Predeterminada] bit NOT NULL,
 CONSTRAINT [PK_Table_PaginaDefaultXTipoUsuario] PRIMARY KEY CLUSTERED 
(
	[IdTipoUsuario] ASC, 
	[IdPaginaDefault] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
insert PaginaDefault values ('Inicio', 'Inicio', 'Inicio')
go
insert PaginaDefault values ('eFactWeb', 'Factura Electrónica (servicio web)', 'FacturaElectronica')
go
insert PaginaDefault values ('eFactWeb-Ingr', 'Ingreso de Factura Electrónica', 'FacturaElectronicaXML')
go
insert PaginaDefault values ('Admin', 'Administración', 'Administracion')
go
insert PaginaDefaultXTipoUsuario values ('Admin', 'Inicio', 0)
go
insert PaginaDefaultXTipoUsuario values ('Admin', 'eFactWeb', 0)
go
insert PaginaDefaultXTipoUsuario values ('Admin', 'eFactWeb-Ingr', 0)
go
insert PaginaDefaultXTipoUsuario values ('Admin', 'Admin', 1)
go
insert PaginaDefaultXTipoUsuario values ('Free', 'Inicio', 0)
go
insert PaginaDefaultXTipoUsuario values ('Free', 'eFactWeb', 1)
go
insert PaginaDefaultXTipoUsuario values ('Free', 'eFactWeb-Ingr', 0)
go
insert PaginaDefaultXTipoUsuario values ('Prem', 'Inicio', 0)
go
insert PaginaDefaultXTipoUsuario values ('Prem', 'eFactWeb', 1)
go
insert PaginaDefaultXTipoUsuario values ('Prem', 'eFactWeb-Ingr', 0)
go
alter table dbo.Usuario add IdPaginaDefault varchar(15) null
go
update Usuario set Usuario.IdPaginaDefault=PaginaDefaultXTipoUsuario.IdPaginaDefault from Usuario, PaginaDefaultXTipoUsuario where Usuario.IdTipoUsuario=PaginaDefaultXTipoUsuario.IdTipoUsuario and PaginaDefaultXTipoUsuario.Predeterminada=1
go
alter table dbo.Usuario alter column IdPaginaDefault varchar(15) not null
go
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_PaginaDefault] FOREIGN KEY([IdPaginaDefault]) REFERENCES [dbo].[PaginaDefault] ([IdPaginaDefault])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_PaginaDefault]
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PaginaDefaultXTipoUsuario_PaginaDefault] FOREIGN KEY([IdPaginaDefault]) REFERENCES [dbo].[PaginaDefault] ([IdPaginaDefault])
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoUsuario] CHECK CONSTRAINT [FK_PaginaDefaultXTipoUsuario_PaginaDefault]
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoUsuario]  WITH CHECK ADD  CONSTRAINT [FK_PaginaDefaultXTipoUsuario_TipoUsuario] FOREIGN KEY([IdTipoUsuario]) REFERENCES [dbo].[TipoUsuario] ([IdTipoUsuario])
GO
ALTER TABLE [dbo].[PaginaDefaultXTipoUsuario] CHECK CONSTRAINT [FK_PaginaDefaultXTipoUsuario_TipoUsuario]
GO

/* 012-AgregarFolletosATablaPaginaDefault */

insert PaginaDefault values ('CedST', 'Folleto CedST', 'CedST')
GO
insert PaginaDefault values ('CedFCI', 'Folleto CedFCI', 'CedFCI')
GO
insert PaginaDefaultXTipoUsuario values ('Admin', 'CedST', 0)
GO
insert PaginaDefaultXTipoUsuario values ('Admin', 'CedFCI', 0)
GO

/* 013-AgregarSolucionesATablaPaginaDefault */

insert PaginaDefault values ('Soluciones', 'Soluciones', 'Soluciones')
GO
insert PaginaDefaultXTipoUsuario values ('Admin', 'Soluciones', 0)
GO

/* 014-DepuracionUsuariosPteConf */

select * into UsuarioPteConfDepurados from Usuario where IdEstadoUsuario='PteConf'
GO
delete Usuario where IdEstadoUsuario='PteConf'
GO

/* 015-DepuracionUsuarios */

sp_rename UsuarioPteConfDepurados, UsuarioDepurada
go

/* 016-DepuracionEmpresayCompradores */

select * into EmpresaDepurado from Empresa where 1=2
go
select * into CompradorDepurado from Comprador where 1=2
go

/* 017-CreaciónTablaFlag */

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flag](
	[IdFlag] [varchar](30) NOT NULL,
	[Valor] [bit] NOT NULL,
 CONSTRAINT [PK_Flag] PRIMARY KEY CLUSTERED 
(
	[IdFlag] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
go
insert Flag values ('ModoDepuracion', 0)
go


/* 018-PremiumSinCostoEnAltaUsuario */

insert Flag values ('PremiumSinCostoEnAltaUsuario', 1)
go
insert Flag values ('CreacionUsuarioHabilitada', 1)
go


/* 019-AgregarTablasContactoAtributoyPublicacion */

CREATE TABLE [dbo].[Contacto](
	[IdContacto] [varchar](60) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Calle] [varchar](30) NOT NULL,
	[Nro] [varchar](6) NOT NULL,
	[Piso] [varchar](5) NOT NULL,
	[Depto] [varchar](5) NOT NULL,
	[Localidad] [varchar](25) NOT NULL,
	[IdProvincia] [varchar](2) NOT NULL,
	[DescrProvincia] [varchar](50) NOT NULL,
	[CodPost] [varchar](8) NOT NULL,
	[Telefono] [varchar](50) NOT NULL,
	[Tratamiento] [varchar](50) NOT NULL,
	[Organizacion] [varchar](50) NOT NULL,
	[Observacion] [varchar](50) NOT NULL,
	[IdEstadoContacto] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_Contacto] PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
CREATE TABLE [dbo].[Atributo](
	[IdAtributo] [varchar](15) NOT NULL,
	[DescrAtributo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Atributo] PRIMARY KEY CLUSTERED 
(
	[IdAtributo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

CREATE TABLE [dbo].[AtributoXContacto](
	[IdContacto] [varchar](60) NOT NULL,
	[IdAtributo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_AtributoXContacto] PRIMARY KEY CLUSTERED 
(
	[IdContacto] ASC,
	[IdAtributo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
ALTER TABLE [dbo].[AtributoXContacto]  WITH CHECK ADD  CONSTRAINT [FK_AtributoXContacto_Contacto] FOREIGN KEY([IdContacto])
REFERENCES [dbo].[Contacto] ([IdContacto])
go
ALTER TABLE [dbo].[AtributoXContacto] CHECK CONSTRAINT [FK_AtributoXContacto_Contacto]
go
ALTER TABLE [dbo].[AtributoXContacto]  WITH CHECK ADD  CONSTRAINT [FK_AtributoXContacto_Atributo] FOREIGN KEY([IdAtributo])
REFERENCES [dbo].[Atributo] ([IdAtributo])
go
ALTER TABLE [dbo].[AtributoXContacto] CHECK CONSTRAINT [FK_AtributoXContacto_Atributo]
go
CREATE TABLE [dbo].[Publicacion](
	[IdPublicacion] [int] IDENTITY(1,1) NOT NULL,
	[DescrPublicacion] [varchar](255) NOT NULL,
	[Asunto] [varchar](255) NOT NULL,
	[URL] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Table_Publicacion] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
CREATE TABLE [dbo].[AtributoXPublicacion](
	[IdPublicacion] [int] NOT NULL,
	[IdAtributo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_Table_AtributoXPublicacion] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC,
	[IdAtributo] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
ALTER TABLE [dbo].[AtributoXPublicacion]  WITH CHECK ADD  CONSTRAINT [FK_AtributoXPublicacion_Publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [dbo].[Publicacion] ([IdPublicacion])
go
ALTER TABLE [dbo].[AtributoXPublicacion] CHECK CONSTRAINT [FK_AtributoXPublicacion_Publicacion]
go
ALTER TABLE [dbo].[AtributoXPublicacion]  WITH CHECK ADD  CONSTRAINT [FK_AtributoXPublicacion_Atributo] FOREIGN KEY([IdAtributo])
REFERENCES [dbo].[Atributo] ([IdAtributo])
go
ALTER TABLE [dbo].[AtributoXPublicacion] CHECK CONSTRAINT [FK_AtributoXPublicacion_Atributo]
go
CREATE TABLE [dbo].[PublicacionLog](
	[IdPublicacion] [int] NOT NULL,
	[IdContacto] [varchar](60) NOT NULL,
	[Fecha] [datetime] NOT NULL,
 CONSTRAINT [PK_Table_PublicacionLog] PRIMARY KEY CLUSTERED 
(
	[IdPublicacion] ASC,
	[IdContacto] ASC,
	[Fecha] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go
ALTER TABLE [dbo].[PublicacionLog]  WITH CHECK ADD  CONSTRAINT [FK_PublicacionLog_Publicacion] FOREIGN KEY([IdPublicacion])
REFERENCES [dbo].[Publicacion] ([IdPublicacion])
go
ALTER TABLE [dbo].[PublicacionLog] CHECK CONSTRAINT [FK_PublicacionLog_Publicacion]
go
ALTER TABLE [dbo].[PublicacionLog]  WITH CHECK ADD  CONSTRAINT [FK_PublicacionLog_Contacto] FOREIGN KEY([IdContacto])
REFERENCES [dbo].[Contacto] ([IdContacto])
go
ALTER TABLE [dbo].[PublicacionLog] CHECK CONSTRAINT [FK_PublicacionLog_Contacto]
go


/* 020-AgregarTablaBonoFiscal */

CREATE TABLE [dbo].[BonoFiscal](
	[CUIT] [numeric](11, 0) NOT NULL,
	[PuntoDeVentaHabilitado] [numeric](4) NOT NULL,
 CONSTRAINT [PK_BonoFiscal] PRIMARY KEY CLUSTERED 
(
	[CUIT] ASC,
	[PuntoDeVentaHabilitado] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

/* 021-DepuracionBonoFiscal */

select * into BonoFiscalDepurado from BonoFiscal
go
delete BonoFiscalDepurado
go

/* 022-NroSerieCertEnCta */

ALTER TABLE dbo.Usuario ADD NroSerieCertificado varchar(50) NULL
GO
UPDATE dbo.Usuario SET NroSerieCertificado=''
GO
ALTER TABLE dbo.Usuario ALTER COLUMN NroSerieCertificado varchar(50) NOT NULL
GO
ALTER TABLE dbo.UsuarioDepurada ADD NroSerieCertificado varchar(50) NULL
GO
UPDATE dbo.UsuarioDepurada SET NroSerieCertificado=''
GO
ALTER TABLE dbo.UsuarioDepurada ALTER COLUMN NroSerieCertificado varchar(50) NOT NULL
GO

/* 023-CambioURLFacturaElectronicaXML */

UPDATE PaginaDefault SET URL='Facturacion/Electronica/lote' WHERE IdPaginaDefault='eFactWeb-Ingr'
GO

/* 024-CambioAdministracion */

UPDATE PaginaDefault SET URL='Admin/Default' WHERE IdPaginaDefault='Admin'
GO

