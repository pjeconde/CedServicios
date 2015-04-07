insert NaturalezaComprobante values ('VentaTradic', 'Venta (tradicional)')
go
update Comprobante set IdNaturalezaComprobante='VentaTradic' where IdNaturalezaComprobante='VentaM'
go
delete NaturalezaComprobante where IdNaturalezaComprobante='VentaM'
go
insert NaturalezaComprobante values ('VentaContrato', 'Venta (contrato)')
go
insert Entidad values ('Contrato', 'Contrato', 90)
go
alter table Comprobante add PeriodicidadEmision varchar(15) NULL
go
alter table Comprobante add FechaProximaEmision datetime NULL
go
alter table Comprobante add CantidadComprobantesAEmitir int NULL
go
alter table Comprobante add CantidadComprobantesEmitidos int NULL
go
alter table Comprobante add CantidadDiasFechaVto int NULL
go
update Comprobante set PeriodicidadEmision='No aplica', FechaProximaEmision='99991231', CantidadComprobantesAEmitir=0, CantidadComprobantesEmitidos=0, CantidadDiasFechaVto=0
go
alter table Comprobante alter column PeriodicidadEmision varchar(15) NOT NULL
go
alter table Comprobante alter column FechaProximaEmision datetime NOT NULL
go
alter table Comprobante alter column CantidadComprobantesAEmitir int NOT NULL
go
alter table Comprobante alter column CantidadComprobantesEmitidos int NOT NULL
go
alter table Comprobante alter column CantidadDiasFechaVto int NOT NULL
go


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ticket](
	[Cuit] [varchar](11) NOT NULL,
	[Service] [varchar](50) NOT NULL,
	[UniqueId] [varchar](15) NOT NULL,
	[GenerationTime] [datetime] NOT NULL,
	[ExpirationTime] [datetime] NOT NULL,
	[Sign] [varchar](250) NOT NULL,
	[Token] [varchar](2000) NOT NULL,
 CONSTRAINT [PK_TicketAFIP] PRIMARY KEY CLUSTERED 
(
	[Cuit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
