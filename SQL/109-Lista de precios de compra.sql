alter table dbo.ListaPrecio add IdTipoListaPrecio varchar(20) null
go
update ListaPrecio set IdTipoListaPrecio='Venta'
go
alter table dbo.ListaPrecio alter column IdTipoListaPrecio varchar(20) not null
go
EXEC sp_rename 'Persona.IdListaPrecio', 'IdListaPrecioVenta', 'COLUMN';
go
alter table dbo.Persona add IdListaPrecioCompra varchar(20) null;
go
update Persona set IdListaPrecioCompra=''
go
alter table dbo.Persona alter column IdListaPrecioCompra varchar(20) not null;
go
