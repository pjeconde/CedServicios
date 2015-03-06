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
