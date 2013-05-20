declare @idWF varchar(256)
declare @accionNro varchar(256)
update Configuracion set @accionNro=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoAccionNro'
update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Usuario (IdUsuario, Nombre, Telefono, Email, Password, Pregunta, Respuesta, CantidadEnviosMail, FechaUltimoReenvioMail, EmailSMS, IdWF, Estado) values ('cedeira.migracion', 'Cedeira - Usuario genérico para migración', '', 'claudio.cedeira@gmail.com', 'cedeira123', 'Cual es la sigla de mi escuela secundaria', 'encjm', 0, getdate(), 'claudio.cedeira@gmail.com', @IdWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'cedeira.migracion', 'Usuario', 'Alta', 'Vigente', 'Alta x script')
update Configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Permiso values ('cedeira.migracion', '', '', 'AdminSITE', '20621231', '', 'AltaAdminSITEs', @accionNro, @idWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'cedeira.migracion', 'Permiso', 'Alta', 'Vigente', 'Alta x script')
