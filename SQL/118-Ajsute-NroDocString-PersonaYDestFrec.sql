ALTER TABLE [dbo].[DestinatarioFrecuente] DROP CONSTRAINT [FK_DestinatarioFrecuente_Persona] 
GO




ALTER TABLE DestinatarioFrecuente DROP CONSTRAINT PK_DestinatarioFrecuente
go

alter table DestinatarioFrecuente alter column NroDoc [varchar](11) not null
go

ALTER TABLE DestinatarioFrecuente ADD CONSTRAINT PK_DestinatarioFrecuente PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC,
	[IdTipoDoc] ASC,
	[NroDoc] ASC,
	[IdPersona] ASC,
	[DesambiguacionCuitPais] ASC,
	[IdDestinatarioFrecuente] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO




ALTER TABLE Persona DROP CONSTRAINT PK_Cliente
go

alter table Persona alter column NroDoc [varchar](11) not null
go

ALTER TABLE Persona ADD CONSTRAINT PK_Cliente PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC,
	[IdTipoDoc] ASC,
	[NroDoc] ASC,
	[IdPersona] ASC,
	[DesambiguacionCuitPais] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO




ALTER TABLE [dbo].[DestinatarioFrecuente]  WITH CHECK ADD  CONSTRAINT [FK_DestinatarioFrecuente_Persona] FOREIGN KEY([Cuit], [IdTipoDoc], [NroDoc], [IdPersona], [DesambiguacionCuitPais])
REFERENCES [dbo].[Persona] ([Cuit], [IdTipoDoc], [NroDoc], [IdPersona], [DesambiguacionCuitPais])
GO

ALTER TABLE [dbo].[DestinatarioFrecuente] CHECK CONSTRAINT [FK_DestinatarioFrecuente_Persona]
GO




