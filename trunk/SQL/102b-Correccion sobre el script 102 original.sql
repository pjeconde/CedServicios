update NaturalezaComprobante set DescrNaturalezaComprobante='Venta (electr�nica)' where IdNaturalezaComprobante='Venta'
go
delete NaturalezaComprobante where IdNaturalezaComprobante='VentaOO'
go
insert NaturalezaComprobante values ('VentaM', 'Venta (manual)')
go
