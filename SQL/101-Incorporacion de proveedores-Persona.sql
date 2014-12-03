EXEC sp_rename 'Cliente', 'Persona';
go
EXEC sp_rename 'Persona.IdCliente', 'IdPersona', 'COLUMN';
go
alter table dbo.Persona add EsCliente bit NULL
go
alter table dbo.Persona add EsProveedor bit NULL
go
update Persona set EsCliente=1, EsProveedor=0
go
alter table dbo.Persona alter column EsCliente bit NOT NULL
go
alter table dbo.Persona alter column EsProveedor bit NOT NULL
go
