SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rubro](
	[IdRubro] [varchar](20) NOT NULL,
	[DescrRubro] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rubro] PRIMARY KEY CLUSTERED 
(
	[IdRubro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert Rubro values ('Act-Cr-DsxVtas', 'Deudores. x Ventas')
insert Rubro values ('Pas-Db-I-Iva21', 'IVA Débito Fiscal x Ventas 21%')
insert Rubro values ('Pas-Db-I-Iva10.5', 'IVA Débito Fiscal x Ventas 10.5%')
insert Rubro values ('Pas-Db-I-Iva27', 'IVA Débito Fiscal x Ventas 27%')
insert Rubro values ('Pas-Db-I-Iva5', 'IVA Débito Fiscal x Ventas 5%')
insert Rubro values ('Pas-Db-I-Iva2.5', 'IVA Débito Fiscal x Ventas 2.5%')
insert Rubro values ('Pas-Db-I-Otros', 'Otros Impuestos')
insert Rubro values ('Pas-Db-I-PercINac', 'Percepiones Imp. Nacionales')
insert Rubro values ('Pas-Db-I-ImpInt', 'Impuestos Internos')
insert Rubro values ('Pas-Db-I-IngBrut', 'Percep. Ing. Brutos')
insert Rubro values ('Pas-Db-I-ImpMun', 'Percep. Imp. Muncipales')
insert Rubro values ('Gan-Ventas', 'Ventas')
insert Rubro values ('Pas-Db-Proveed', 'Proveedores')
insert Rubro values ('Act-Cr-I-Iva21', 'IVA Crédito Fiscal x Compras 21%')
insert Rubro values ('Act-Cr-I-Iva10.5', 'IVA Crédito Fiscal x Compras 10.5%')
insert Rubro values ('Act-Cr-I-Iva27', 'IVA Crédito Fiscal x Compras 27 %')
insert Rubro values ('Act-Cr-I-Iva0', 'IVA Crédito Fiscal x Compras 0 %')
insert Rubro values ('Act-Cr-I-Otros', 'Otros Impuestos')
insert Rubro values ('Act-Cr-I-PercepINac', 'Percepiones Imp. Nacionales')
insert Rubro values ('Act-Cr-I-ImpInt', 'Impuestos Internos')
insert Rubro values ('Act-Cr-I-IngBrut', 'Percep. Ing. Brutos')
insert Rubro values ('Act-Cr-I-ImpMun', 'Percep. Imp. Muncipales')
insert Rubro values ('Gs-Compras', 'Compras')

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EsquemaContable](
	[IdTipoComprobante] [decimal](2,0) NOT NULL,
	[IdNaturalezaComprobante] [varchar](15) NOT NULL,
	[Concepto] [varchar](20) NOT NULL,
	[IdRubro] [varchar](20) NOT NULL,
	[Signo] [int] NOT NULL,
 CONSTRAINT [PK_EsquemaContable] PRIMARY KEY CLUSTERED 
(
	[IdTipoComprobante] ASC,
	[IdNaturalezaComprobante] ASC,
	[Concepto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

insert EsquemaContable values (1, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (2, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (3, 'Venta', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (4, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (5, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (6, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (7, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (8, 'Venta', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (9, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (10, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (11, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (12, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (13, 'Venta', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (15, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (39, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (40, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (41, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (60, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (61, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (63, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (64, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (1, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (2, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (3, 'Compra', 'T', 'Pas-Db-Proveed', 1)
insert EsquemaContable values (4, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (5, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (6, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (7, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (8, 'Compra', 'T', 'Pas-Db-Proveed', 1)
insert EsquemaContable values (9, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (10, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (11, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (12, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (13, 'Compra', 'T', 'Pas-Db-Proveed', 1)
insert EsquemaContable values (15, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (39, 'Compra', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (40, 'Compra', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (41, 'Compra', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (60, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (61, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (63, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (64, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (99, 'Compra', 'T', 'Pas-Db-Proveed', -1)
insert EsquemaContable values (1, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (2, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (3, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (4, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (5, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (6, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (7, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (8, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (9, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (10, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (11, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (12, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (13, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable values (15, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (39, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (40, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (41, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (60, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (61, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (63, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable values (64, 'VentaTradic', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'A', 'Gan-Ventas', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'A', 'Gs-Compras', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Compra%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'D', 'Gan-Ventas', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'D', 'Gs-Compras', Signo from EsquemaContable where IdNaturalezaComprobante like 'Compra%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-21', 'Pas-Db-I-Iva21', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-10.5', 'Pas-Db-I-Iva10.5', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-27', 'Pas-Db-I-Iva27', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-5', 'Pas-Db-I-Iva5', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-2.5', 'Pas-Db-I-Iva2.5', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-3', 'Pas-Db-I-Otros', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-5', 'Pas-Db-I-IngBrut', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-2', 'Pas-Db-I-ImpInt', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-6', 'Pas-Db-I-ImpMun', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-4', 'Pas-Db-I-PercINac', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-21', 'Act-Cr-I-Iva21', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-10.5', 'Act-Cr-I-Iva10.5', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-27', 'Act-Cr-I-Iva27', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-0', 'Act-Cr-I-Iva0', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-3', 'Act-Cr-I-Otros', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-5', 'Act-Cr-I-IngBrut', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-2', 'Act-Cr-I-ImpInt', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-6', 'Act-Cr-I-ImpMun', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-4', 'Act-Cr-I-PercepINac', -Signo from EsquemaContable where IdNaturalezaComprobante = 'Compra' and Concepto='T'

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ComprobanteDetalle](
	[IdWF] [int] NOT NULL,
	[IdTipoItem] [varchar](1) NOT NULL,
	[NroItem] [int] NOT NULL,
	[IdArticulo] [varchar](20) NOT NULL,
	[IdRubro] [varchar](20) NOT NULL,
	[Cantidad] [decimal](15, 2) NOT NULL,
	[PrecioUnitario] [decimal](15, 2) NOT NULL,
	[Importe] [decimal](15, 2) NOT NULL,
	[IdUbicacion] [varchar](20) NOT NULL,
	[IndicadorExentoGravado] [varchar](1) NOT NULL,
	[Detalle] [varchar](128) NOT NULL,
 CONSTRAINT [PK_Table_ComprobanteDetalle] PRIMARY KEY CLUSTERED 
(
	[IdWF] ASC,
	[IdTipoItem] ASC,
	[NroItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ComprobanteDetalle]  WITH CHECK ADD  CONSTRAINT [FK_ComprobanteDetalle_Rubro] FOREIGN KEY([IdRubro])
REFERENCES [dbo].[Rubro] ([IdRubro])
GO
ALTER TABLE [dbo].[ComprobanteDetalle] CHECK CONSTRAINT [FK_ComprobanteDetalle_Rubro]
GO

