-- inicializacion de la base de datos

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'XF1_DATABASE')
BEGIN
	CREATE DATABASE XF1_DATABASE
END

GO 
    USE XF1_DATABASE
GO

-- creacionde las tablas de la base de datos

-- Tabla 1 - competencias -- 
DROP TABLE IF EXISTS COMPETENCIAS;
CREATE TABLE COMPETENCIAS
(
	Id					INT NOT NULL,
	Nombre				VARCHAR(30) NOT NULL,
	FechaInicio			DATE NOT NULL,
	HoraInicio			TIME NOT NULL,
	FechaFinal			DATE NOT NULL,
	HoraFinal			TIME NOT NULL,
	ReglasPuntuacion	VARCHAR(1000),

	PRIMARY KEY(Id)

);

ALTER TABLE COMPETENCIAS
ADD CONSTRAINT LargoNombre 
CHECK (DATALENGTH(Nombre) > 5 AND DATALENGTH(Nombre) < 30);