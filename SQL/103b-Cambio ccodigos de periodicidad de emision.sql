update Comprobante set PeriodicidadEmision='Mensual-A' where PeriodicidadEmision='Mensual'
go
update Comprobante set PeriodicidadEmision='Trimestral-A' where PeriodicidadEmision='Trimestral'
go
update Comprobante set PeriodicidadEmision='Anual-A' where PeriodicidadEmision='Anual'
go
