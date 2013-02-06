declare @idWF varchar(256)

update configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Usuario (IdUsuario, Nombre, Telefono, Email, Password, Pregunta, Respuesta, CantidadEnviosMail, FechaUltimoReenvioMail, EmailSMS, IdWF, Estado) values ('claudio.cedeira', 'Claudio A. Cedeira', '', 'claudio.cedeira@gmail.com', 'ibg3282', 'Cual es la sigla de mi escuela secundaria', 'encjm', 0, getdate(), 'claudio.cedeira@gmail.com', @IdWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'claudio.cedeira', 'Usuario', 'Alta', 'Vigente', 'Alta x script')

update configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Usuario (IdUsuario, Nombre, Telefono, Email, Password, Pregunta, Respuesta, CantidadEnviosMail, FechaUltimoReenvioMail, EmailSMS, IdWF, Estado) values ('lucas.legaspi', 'Lucas Legaspi', '', 'lucas.legaspi@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Henderson', 0, getdate(), 'lucas.legaspi@gmail.com', @IdWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'lucas.legaspi', 'Usuario', 'Alta', 'Vigente', 'Alta x script')

update configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Usuario (IdUsuario, Nombre, Telefono, Email, Password, Pregunta, Respuesta, CantidadEnviosMail, FechaUltimoReenvioMail, EmailSMS, IdWF, Estado) values ('pjeconde', 'Pablo J.E.Conde', '', 'pjeconde@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Cedeira', 0, getdate(), 'pjeconde@gmail.com', @IdWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'pjeconde', 'Usuario', 'Alta', 'Vigente', 'Alta x script')

update configuracion set @idWF=Valor=convert(varchar(256), convert(int, Valor)+1) where IdItemConfig='UltimoIdWF'
insert Usuario (IdUsuario, Nombre, Telefono, Email, Password, Pregunta, Respuesta, CantidadEnviosMail, FechaUltimoReenvioMail, EmailSMS, IdWF, Estado) values ('fcedeira', 'Fernando J. Cedeira', '', 'fcedeira@gmail.com', 'cedeira123', 'Cual es mi apellido materno', 'Cuello', 0, getdate(), 'fcedeira@gmail.com', @IdWF, 'Vigente')
insert Log values (@IdWF, getdate(), 'fcedeira', 'Usuario', 'Alta', 'Vigente', 'Alta x script')
