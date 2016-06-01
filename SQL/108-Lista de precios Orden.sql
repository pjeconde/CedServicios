alter table ListaPrecio add Orden int null
go
update ListaPrecio set Orden=0
go
alter table Listaprecio alter column Orden int not null
go
