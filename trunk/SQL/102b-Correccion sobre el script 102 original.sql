update NaturalezaComprobante set DescrNaturalezaComprobante='Venta (electrónica)' where IdNaturalezaComprobante='Venta'
go
delete NaturalezaComprobante where IdNaturalezaComprobante='VentaOO'
go
insert NaturalezaComprobante values ('VentaM', 'Venta (manual)')
go
