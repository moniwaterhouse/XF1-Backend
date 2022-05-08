-- inicializacion de la base de datos

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'XF1_DATABASE')
BEGIN
	CREATE DATABASE XF1_DATABASE
END

GO 
    USE XF1_DATABASE
GO

-- ELIMINAR DEPENDENCIAS --
ALTER TABLE CARRERA
DROP CONSTRAINT IF EXISTS FK_CARRERA_CAMPEONATO;

ALTER TABLE LIGA
DROP CONSTRAINT IF EXISTS FK_LIGA_CAMPEONATO;

ALTER TABLE USUARIOXLIGA
DROP CONSTRAINT IF EXISTS FK_USUARIOXLIGA_LIGA;

ALTER TABLE USUARIOXLIGA
DROP CONSTRAINT IF EXISTS FK_USUARIOXLIGA_USUARIO;

-- TABLAS --

-- Tabla 1 - competencias -- 
DROP TABLE IF EXISTS CAMPEONATO;
CREATE TABLE CAMPEONATO
(
	Id					VARCHAR(6),
	Nombre				VARCHAR(30),
	Presupuesto			INT,
	FechaInicio			DATE,
	HoraInicio			VARCHAR(10),
	FechaFin			DATE,
	HoraFin				VARCHAR(10),
	ReglasPuntuacion	VARCHAR(1000),

	PRIMARY KEY(Id)
);

-- Tabla 2 - carrera --
DROP TABLE IF EXISTS CARRERA
CREATE TABLE CARRERA
(
	Id					INT,
	IdCampeonato		VARCHAR(6),
	Nombre				VARCHAR(30),
	NombrePais			VARCHAR(30),
	NombrePista			VARCHAR(30),
	FechaInicio			DATE,
	HoraInicio			VARCHAR(10),
	FechaFin			DATE,
	HoraFin				VARCHAR(10),
	Estado				VARCHAR(30),

	PRIMARY KEY(Id, IdCampeonato)
);

-- Tabla 3 - Liga
DROP TABLE IF EXISTS LIGA
CREATE TABLE LIGA
(
	Id				INT,
	IdCampeonato	VARCHAR(6),
	Tipo			VARCHAR(10),
	
	PRIMARY KEY(Id)
);

-- Tabla 4 - Jugadores
DROP TABLE IF EXISTS USUARIO
CREATE TABLE USUARIO
(
	Id		INT,

	PRIMARY KEY(Id)
);

-- Tabla 5 - UsaurioPorLiga
DROP TABLE IF EXISTS USUARIOXLIGA
CREATE TABLE USUARIOXLIGA
(
	IdUsuario	INT,
	IdLiga		INT,

	PRIMARY KEY(IdUsuario, IdLiga)
);

-- LLAVES FORÁNEAS --

ALTER TABLE CARRERA
ADD CONSTRAINT FK_CARRERA_CAMPEONATO FOREIGN KEY(IdCampeonato)
REFERENCES CAMPEONATO(Id);

ALTER TABLE LIGA
ADD CONSTRAINT FK_LIGA_CAMPEONATO FOREIGN KEY(IdCampeonato)
REFERENCES CAMPEONATO(Id);

ALTER TABLE USUARIOXLIGA
ADD CONSTRAINT FK_USUARIOXLIGA_USUARIO FOREIGN KEY(IdUsuario)
REFERENCES USUARIO(Id)

ALTER TABLE USUARIOXLIGA
ADD CONSTRAINT FK_USUARIOXLIGA_LIGA FOREIGN KEY(IdLiga)
REFERENCES LIGA(Id);

-- VIEWS --
DROP VIEW IF EXISTS FECHAS;
GO
CREATE VIEW FECHAS

AS SELECT CAMPEONATO.FechaInicio, CAMPEONATO.FechaFin
FROM CAMPEONATO

GO

DROP VIEW IF EXISTS FECHAS;
GO
CREATE VIEW FECHASCARRERA

AS SELECT FechaInicio, FechaFin
FROM CARRERA

GO

-- STORED PROCEDURES -- 

-- nombre: sp_crear_liga
-- descripcion: este sp crea una nueva liga public asociada al campeonato
-- que se ingresa por parametro. La idea es utilizarlo cuando se crea un
-- campeonato. Tambien asocia a todos los jugadoeres activos a la liga.
DROP PROCEDURE IF EXISTS sp_crear_liga
GO
CREATE PROCEDURE sp_crear_liga(
	@IdCampeonato	VARCHAR(6)
)
AS
BEGIN

	DECLARE @IdLiga INT;

	SELECT @IdLiga = MAX(Id)
	FROM LIGA;

	SET @IdLiga = @IdLiga + 1;

	INSERT INTO LIGA (Id, IdCampeonato, Tipo)
			VALUES	 (@IdLiga, @IdCampeonato, 'Pública');

	INSERT INTO USUARIOXLIGA (IdUsuario, IdLiga)
		SELECT
			Id AS IdUsuario,
			@IdLiga AS IdLiga
		FROM USUARIO;

END
GO

-- nombre: fc_validar_fechas_campeonato
-- descripcion: este sp valida que las fechas 

-- POPULACION DE LAS TABLAS

INSERT INTO CAMPEONATO	(Id, Nombre, Presupuesto, FechaInicio, HoraInicio, FechaFin, HoraFin, ReglasPuntuacion)
			VALUES		('KL9HY6', 'Campeonato 2022', 2, '06-15-2022', '13:00', '10-23-2022', '14:30', 'Se va a considerar que los primeros 100 lugares ganaran (100-pos) puntos.'),
						('23F6SH', 'Campeonato 2023', 4, '02-15-2023', '13:00', '5-11-2023', '14:30', NULL);

INSERT INTO CARRERA		(Id, IdCampeonato, Nombre, NombrePais, NombrePista, FechaInicio, HoraInicio, FechaFin, HoraFin, Estado)
			VALUES		(1, 'KL9HY6', 'Carrera marzo CRI', 'Costa Rica', 'Pista San José', '03-03-2022', '1:00', '03-06-2022', '13:00', 'Carrera Completada'),
						(2, 'KL9HY6', 'Carrera mayo ESP', 'España', 'Pista Madrid', '05-03-2022', '14:00', '05-06-2022', '15:00', 'Pendiente');


INSERT INTO LIGA	(Id, IdCampeonato, Tipo)
			VALUES	(1, 'KL9HY6', 'Pública'),
					(2, '23F6SH', 'Pública');

INSERT INTO USUARIO (Id)
			VALUES	(1),
					(2),
					(3);

INSERT INTO USUARIOXLIGA	(IdUsuario, IdLiga)
			VALUES			(1, 1),
							(1, 2),
							(2, 1),
							(2, 2),
							(3, 1),
							(3, 2);
