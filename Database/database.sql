

--CREATE DATABASE BCO_Tarjeta;
--GO
USE BCO_Tarjeta;
GO


CREATE TABLE Cliente(
idCliente UNIQUEIDENTIFIER primary key DEFAULT NEWID() not null,
nombres varchar(50) not null,
apellidos varchar(50) not null,
dui varchar(10) not null,
direccion varchar(200) null,
correo varchar(100) not null,
telefono varchar(8) null
);
GO

CREATE TABLE Marca(
idMarca int primary key identity(1,1) not null,
nombre varchar(50),
descripcion varchar(100)
);

CREATE TABLE Tarjeta(
idTarjeta UNIQUEIDENTIFIER primary key DEFAULT NEWID() not null,
idCliente UNIQUEIDENTIFIER not null,
idMarca int not null,
noCuenta varchar(50) not null,
noTarjeta varchar(16) not null,
fEmi varchar(4) not null,
fVen varchar(4) not null,
code varchar(3) not null,
Limite numeric(15,2) not null default 0,
Saldo numeric(15,2) not null default 0,
intMensual numeric(2) not null default 1,
saldoMin numeric(2) not null default 1,
CONSTRAINT FK_Tarjeta_Cliente FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente),
CONSTRAINT FK_Tarjeta_Marca FOREIGN KEY (idMarca) REFERENCES Marca(idMarca)
);

CREATE TABLE Transaccion(
idTransaccion int primary key identity(1,1) not null,
idTarjeta UNIQUEIDENTIFIER not null,
cargo numeric(15,2) not null default 0,
abono numeric(15,2) not null default 0,
fecha datetime not null default CURRENT_TIMESTAMP,
descripcion varchar(100) not null,
CONSTRAINT FK_Transaccion_Tarjeta FOREIGN KEY (idTarjeta) REFERENCES Tarjeta(idTarjeta),
);

--Insertando informacion

INSERT INTO [dbo].[Marca]
           ([nombre]
           ,[descripcion])
     VALUES
           ('VISA','Marca VISA'),
		   ('MASTERCARD','Marca MASTERCARD'),
		   ('AMERICAN EXPRESS','Marca AMERICAN EXPRESS')
GO


INSERT INTO [dbo].[Cliente]
           ([idCliente]
           ,[nombres]
           ,[apellidos]
           ,[dui]
           ,[direccion]
           ,[correo]
           ,[telefono])
     VALUES
           ('2CD3266D-6DFF-45AD-A9E9-B93BCFEA552C'
           ,'Eduardo Rafael'
           ,'Lopez Arias'
           ,'01234567-9'
           ,'San Salvador, El Salvador'
           ,'correo@correo.com'
           ,'70707070')
GO

INSERT INTO [dbo].[Tarjeta]
           ([idTarjeta]
           ,[idCliente]
           ,[idMarca]
           ,[noCuenta]
           ,[noTarjeta]
           ,[fEmi]
           ,[fVen]
           ,[code]
           ,[Limite]
           ,[Saldo]
           ,[intMensual]
           ,[saldoMin])
     VALUES
           ('B7EF2D66-DCD5-42DC-9A98-938327AEFF5C'
           ,'2CD3266D-6DFF-45AD-A9E9-B93BCFEA552C'
           ,1
           ,'000-999-12621202-01'
           ,'0102020304050506'
           ,'0924'
           ,'0929'
           ,'125'
           ,1500.00
           ,0
           ,25
           ,5)
GO
INSERT INTO [dbo].[Tarjeta]
           ([idTarjeta]
           ,[idCliente]
           ,[idMarca]
           ,[noCuenta]
           ,[noTarjeta]
           ,[fEmi]
           ,[fVen]
           ,[code]
           ,[Limite]
           ,[Saldo]
           ,[intMensual]
           ,[saldoMin])
     VALUES
           ('8E6F1B07-89CC-4480-9D34-4D6B48F5FE54'
           ,'2CD3266D-6DFF-45AD-A9E9-B93BCFEA552C'
           ,1
           ,'000-999-12621202-01'
           ,'0102020304052697'
           ,'0924'
           ,'1029'
           ,'725'
           ,2500.00
           ,0
           ,10
           ,5)
GO

--CLIENTE ID: 2CD3266D-6DFF-45AD-A9E9-B93BCFEA552C
--TARJETA ID: B7EF2D66-DCD5-42DC-9A98-938327AEFF5C
--NoTarjeta: 0102020304050506

CREATE FUNCTION getTarjetaId 
(@numeroTarjeta varchar(16))
RETURNS varchar(50)
AS BEGIN
Declare @idTarjeta varchar(50);
(SELECT @idTarjeta = idTarjeta 
FROM BCO_Tarjeta.dbo.Tarjeta td
WHERE td.noTarjeta = @numeroTarjeta);
Return @idTarjeta;
END;
GO

CREATE FUNCTION verificarTransaccion 
(@idTarjeta varchar(50),
@monto numeric(15,2))
RETURNS Bit
AS BEGIN
Declare @Saldo numeric(15,2);
Declare @Limite numeric(15,2);
Declare @Valido Bit = 0;
(SELECT @Saldo = Saldo, @Limite = Limite 
FROM BCO_Tarjeta.dbo.Tarjeta td WHERE td.idTarjeta = @idTarjeta);
IF (@Limite >= (@Saldo + @monto))
BEGIN
 Select @Valido = 1;
END
Return @Valido;
END;
GO

CREATE PROCEDURE cargoTarjeta 
@numeroTarjeta varchar(16),
@monto numeric(15,2),
@fecha datetime,
@descripcion varchar(100)
AS
BEGIN
Declare @idTarjeta varchar(50);
Declare @valido Bit;
SELECT @idTarjeta = dbo.getTarjetaId (@numeroTarjeta);
	IF @idTarjeta IS NOT NULL
		BEGIN
		 SELECT @valido = dbo.verificarTransaccion(@idTarjeta,@monto);
			 IF @valido = 1
			 BEGIN				
				BEGIN TRY
					BEGIN TRANSACTION
						INSERT INTO [dbo].[Transaccion]([idTarjeta],[cargo],[fecha],[descripcion])
						VALUES	(@idTarjeta,@monto,@fecha,@descripcion);
						UPDATE Tarjeta SET Saldo = ( Saldo + @monto) WHERE idTarjeta = @idTarjeta;
					COMMIT TRANSACTION					
				END	TRY			
				BEGIN CATCH
					DECLARE @ErrorMessage NVARCHAR(4000);
					DECLARE @ErrorSeverity INT;
					DECLARE @ErrorState INT;
					SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
					ROLLBACK TRANSACTION					
					RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);
				END CATCH
			 END
			 ELSE
			 BEGIN
				RAISERROR('Saldo insuficiente',16,-1);
			 END
		END
		ELSE
		BEGIN
			RAISERROR('Tarjeta invalida',16,-1);
		END
END
GO

CREATE PROCEDURE abonoTarjeta 
@numeroTarjeta varchar(16),
@monto numeric(15,2),
@fecha datetime
AS
BEGIN
Declare @idTarjeta varchar(50);
Declare @valido Bit;
SELECT @idTarjeta = dbo.getTarjetaId (@numeroTarjeta);
	IF @idTarjeta IS NOT NULL
		BEGIN	
			BEGIN TRY
				BEGIN TRANSACTION
					INSERT INTO [dbo].[Transaccion]([idTarjeta],[abono],[fecha],[descripcion])
					VALUES	(@idTarjeta,@monto,@fecha,'SU PAGO RECIBIDO GRACIAS');
					UPDATE Tarjeta SET Saldo = ( Saldo - @monto) WHERE idTarjeta = @idTarjeta;
				COMMIT TRANSACTION					
			END	TRY			
			BEGIN CATCH
				DECLARE @ErrorMessage NVARCHAR(4000);
				DECLARE @ErrorSeverity INT;
				DECLARE @ErrorState INT;
				SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();
				ROLLBACK TRANSACTION					
				RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);
			END CATCH
		END
		ELSE
		BEGIN
			RAISERROR('Tarjeta invalida',16,-1);
		END
END
GO

CREATE PROCEDURE infoTarjeta 
@numeroTarjeta varchar(16)
AS
BEGIN
SELECT cli.nombres, cli.apellidos,tdc.noTarjeta, Saldo, Limite, (Limite - Saldo) AS Disponible,
intMensual, ROUND(Saldo*(intMensual/100),2) AS intBonif,
saldoMin, ROUND(Saldo*(SaldoMin/100),2) As Minimo,
Saldo + ROUND(Saldo*(intMensual/100),2) SldInt
FROM Tarjeta tdc
INNER JOIN Cliente cli ON tdc.idCliente = tdc.idCliente
WHERE tdc.noTarjeta = @numeroTarjeta
END
GO

CREATE PROCEDURE transaccionesTarjeta 
@numeroTarjeta varchar(16),
@fechaIni datetime,
@fechaFin datetime
AS
BEGIN
SELECT  RIGHT('A000000000'+CAST(trs.idTransaccion AS VARCHAR(3)),11) As ref, 
trs.fecha,UPPER(trs.descripcion) AS descripcion,ISNULL(trs.cargo,0) AS cargo,ISNULL(trs.abono,0) AS abono  
FROM Transaccion trs
INNER JOIN Tarjeta tdc ON trs.idTarjeta = tdc.idTarjeta
WHERE tdc.noTarjeta = @numeroTarjeta AND fecha between @fechaIni and @fechaFin
ORDER BY fecha DESC;
END
GO

CREATE PROCEDURE totalTranTarjeta 
@numeroTarjeta varchar(16),
@fechaIni datetime,
@fechaFin datetime
AS
BEGIN
SELECT  ISNULL(SUM(trs.cargo),0) AS Cargo, ISNULL(SUM(trs.abono),0) AS Abono, ISNULL(SUM(trs.cargo),0) - ISNULL(SUM(trs.abono),0) AS Saldo
FROM Transaccion trs
INNER JOIN Tarjeta tdc ON trs.idTarjeta = tdc.idTarjeta
WHERE tdc.noTarjeta = @numeroTarjeta AND trs.fecha between @fechaIni and @fechaFin
END
GO

CREATE PROCEDURE tarjetasCliente 
@cliente varchar(50)
AS
BEGIN
SELECT cli.nombres AS nombres, cli.apellidos As apellidos, 
mc.nombre AS marca, td.noTarjeta As noTarjeta 
FROM Tarjeta td
INNER JOIN Cliente cli ON td.idCliente = cli.idCliente
INNER JOIN Marca mc ON td.idMarca = mc.idMarca
WHERE td.idCliente = @cliente
END
GO

CREATE PROCEDURE dataCliente 
@cliente varchar(50)
AS
BEGIN
SELECT cli.idCliente, cli.nombres, cli.apellidos,
cli.dui, cli.direccion, cli.correo, cli.telefono
FROM Cliente cli
WHERE cli.idCliente = @cliente;
END
GO