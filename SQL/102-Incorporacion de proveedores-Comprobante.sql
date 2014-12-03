EXEC sp_rename 'Comprobante.IdCliente', 'IdPersona', 'COLUMN';
go
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NaturalezaComprobante](
	[IdNaturalezaComprobante] [varchar](15) NOT NULL,
	[DescrNaturalezaComprobante] [varchar](50) NOT NULL,
 CONSTRAINT [PK_NaturalezaComprobante] PRIMARY KEY CLUSTERED 
(
	[IdNaturalezaComprobante] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert NaturalezaComprobante values ('Venta', 'Venta (eFact)')
go
insert NaturalezaComprobante values ('VentaOO', 'Venta (otros orígenes)')
go
insert NaturalezaComprobante values ('Compra', 'Compra')
go

alter table dbo.Comprobante add IdNaturalezaComprobante varchar(15) NULL
go
update Comprobante set IdNaturalezaComprobante='Venta'
go
alter table dbo.Comprobante alter column IdNaturalezaComprobante varchar(15) NOT NULL
go

ALTER TABLE [dbo].[Comprobante]  WITH CHECK ADD  CONSTRAINT [FK_Comprobante_NaturalezaComprobante] FOREIGN KEY([IdNaturalezaComprobante])
REFERENCES [dbo].[NaturalezaComprobante] ([IdNaturalezaComprobante])
GO
ALTER TABLE [dbo].[Comprobante] CHECK CONSTRAINT [FK_Comprobante_NaturalezaComprobante]
GO

