ALTER TABLE EsquemaContable DROP CONSTRAINT PK_EsquemaContable
go

alter table dbo.EsquemaContable alter column IdTipoComprobante decimal(3,0) not null
go

ALTER TABLE EsquemaContable ADD  CONSTRAINT PK_EsquemaContable PRIMARY KEY CLUSTERED 
(
	IdTipoComprobante ASC,
	IdNaturalezaComprobante ASC,
	Concepto ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
go



insert EsquemaContable values (195, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'A', 'Gan-Ventas', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'D', 'Gan-Ventas', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-21', 'Pas-Db-I-Iva21', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-3', 'Pas-Db-I-Otros', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-5', 'Pas-Db-I-IngBrut', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-2', 'Pas-Db-I-ImpInt', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-6', 'Pas-Db-I-ImpMun', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-4', 'Pas-Db-I-PercINac', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'R', 'Pas-Db-I-Iva21', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=195

insert EsquemaContable values (196, 'Venta', 'T', 'Act-Cr-DsxVtas', 1)
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'A', 'Gan-Ventas', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'D', 'Gan-Ventas', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-21', 'Pas-Db-I-Iva21', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-3', 'Pas-Db-I-Otros', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-5', 'Pas-Db-I-IngBrut', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-2', 'Pas-Db-I-ImpInt', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-6', 'Pas-Db-I-ImpMun', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-4', 'Pas-Db-I-PercINac', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'R', 'Pas-Db-I-Iva21', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=196

insert EsquemaContable values (197, 'Venta', 'T', 'Act-Cr-DsxVtas', -1)
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'A', 'Gan-Ventas', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'D', 'Gan-Ventas', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-1-21', 'Pas-Db-I-Iva21', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-3', 'Pas-Db-I-Otros', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-5', 'Pas-Db-I-IngBrut', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-2', 'Pas-Db-I-ImpInt', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-6', 'Pas-Db-I-ImpMun', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'I-4', 'Pas-Db-I-PercINac', Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197
insert EsquemaContable select IdTipoComprobante, IdNaturalezaComprobante, 'R', 'Pas-Db-I-Iva21', -Signo from EsquemaContable where IdNaturalezaComprobante like 'Venta%' and Concepto='T' and IdTipoComprobante=197



ALTER TABLE Comprobante DROP CONSTRAINT PK_Table_Comprobante
go

alter table Comprobante alter column IdTipoComprobante decimal(3,0) not null
go

ALTER TABLE Comprobante ADD CONSTRAINT PK_Table_Comprobante PRIMARY KEY CLUSTERED 
(
	Cuit ASC,
	IdNaturalezaComprobante ASC,
	IdTipoComprobante ASC,
	NroPuntoVta ASC,
	NroComprobante ASC,
	IdTipoDoc ASC,
	NroDoc ASC,
	IdPersona ASC,
	DesambiguacionCuitPais ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

