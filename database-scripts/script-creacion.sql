-- inicializacion de la base de datos

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'XF1_DATABASE')
BEGIN
	CREATE DATABASE XF1_DATABASE
END

GO 
    USE XF1_DATABASE
GO

-- creacionde las tablas de la base de datos

-- Tabla 1 - carrera --
DROP TABLE IF EXISTS CARRERA
CREATE TABLE CARRERA
(
	Id					INT NOT NULL,
	IdCompetencia		INT,
	Nombre				VARCHAR(30),
	NombrePais			VARCHAR(30),
	NombrePista			VARCHAR(30),
	FechaClasificacion	DATE,
	HoraClasificacion	Time,
	FechaCarrera		DATE,
	HoraCarrera			Time,
	Estado				VARCHAR(30),

	PRIMARY KEY(Id)
);

-- Tabla 2 - competencias -- 
DROP TABLE IF EXISTS COMPETENCIA;
CREATE TABLE COMPETENCIA
(
	Id					INT NOT NULL,
	Nombre				VARCHAR(30),
	FechaInicio			DATE,
	HoraInicio			TIME,
	FechaFinal			DATE,
	HoraFinal			TIME,
	ReglasPuntuacion	VARCHAR(1000),

	PRIMARY KEY(Id)

);

ALTER TABLE COMPETENCIA
ADD CONSTRAINT LargoNombre 
CHECK (DATALENGTH(Nombre) > 5 AND DATALENGTH(Nombre) < 30);


ALTER TABLE CARRERA
ADD CONSTRAINT FK_CARRERA_COMPETENCIA FOREIGN KEY(IdCompetencia)
REFERENCES COMPETENCIA(Id);

