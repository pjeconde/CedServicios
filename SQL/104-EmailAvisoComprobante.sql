SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DestinatarioFrecuente](
	[Cuit] [varchar](11) NOT NULL,
	[IdTipoDoc] [numeric](2, 0) NOT NULL,
	[NroDoc] [numeric](11, 0) NOT NULL,
	[IdPersona] [varchar](50) NOT NULL,
	[DesambiguacionCuitPais] [int] NOT NULL,
	[IdDestinatarioFrecuente] [varchar](15) NOT NULL,
	[Para] [varchar](512) NOT NULL,
	[Cc] [varchar](512) NOT NULL,
 CONSTRAINT [PK_DestinatarioFrecuente] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC,
	[IdTipoDoc] ASC,
	[NroDoc] ASC,
	[IdPersona] ASC,
	[DesambiguacionCuitPais] ASC,
	[IdDestinatarioFrecuente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[DestinatarioFrecuente]  WITH CHECK ADD  CONSTRAINT [FK_DestinatarioFrecuente_Persona] FOREIGN KEY([Cuit], [IdTipoDoc], [NroDoc], [IdPersona], [DesambiguacionCuitPais])
REFERENCES [dbo].[Persona] ([Cuit], [IdTipoDoc], [NroDoc], [IdPersona], [DesambiguacionCuitPais])
GO
ALTER TABLE [dbo].[DestinatarioFrecuente] CHECK CONSTRAINT [FK_DestinatarioFrecuente_Persona]
GO

alter table Persona add EmailAvisoComprobanteActivo bit NULL
go
alter table Persona add EmailAvisoComprobanteDe varchar(512) NULL
go
alter table Persona add EmailAvisoComprobanteCco varchar(512) NULL
go
alter table Persona add EmailAvisoComprobanteAsunto varchar(256) NULL
go
alter table Persona add EmailAvisoComprobanteCuerpo varchar(2048) NULL
go
update Persona set EmailAvisoComprobanteActivo=0, EmailAvisoComprobanteDe='', EmailAvisoComprobanteCco='', EmailAvisoComprobanteAsunto='', EmailAvisoComprobanteCuerpo=''
go
alter table Persona alter column EmailAvisoComprobanteActivo bit NOT NULL
go
alter table Persona alter column EmailAvisoComprobanteDe varchar(512) NOT NULL
go
alter table Persona alter column EmailAvisoComprobanteCco varchar(512) NOT NULL
go
alter table Persona alter column EmailAvisoComprobanteAsunto varchar(256) NOT NULL
go
alter table Persona alter column EmailAvisoComprobanteCuerpo varchar(2048) NOT NULL
go


alter table Comprobante add EmailAvisoComprobanteActivo bit NULL
go
alter table Comprobante add IdDestinatarioFrecuente varchar(15) NULL
go
alter table Comprobante add EmailAvisoComprobanteAsunto varchar(256) NULL
go
alter table Comprobante add EmailAvisoComprobanteCuerpo varchar(2048) NULL
go
update Comprobante set EmailAvisoComprobanteActivo=0, IdDestinatarioFrecuente='', EmailAvisoComprobanteAsunto='', EmailAvisoComprobanteCuerpo=''
go
alter table Comprobante alter column EmailAvisoComprobanteActivo bit NOT NULL
go
alter table Comprobante alter column IdDestinatarioFrecuente varchar(15) NOT NULL
go
alter table Comprobante alter column EmailAvisoComprobanteAsunto varchar(256) NOT NULL
go
alter table Comprobante alter column EmailAvisoComprobanteCuerpo varchar(2048) NOT NULL
go
