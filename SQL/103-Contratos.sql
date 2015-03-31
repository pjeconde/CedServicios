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
