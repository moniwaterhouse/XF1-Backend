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
	NombreUsuario		VARCHAR(100),
	Correo				VARCHAR(100),
	Pais				VARCHAR(100),
	Contrasena			VARCHAR(100),
	NombreEscuderia		VARCHAR(100),
	IdEquipo1			INT,
	IdEquipo2			INT,

	PRIMARY KEY(Correo)
);

-- Tabla 5 - UsaurioPorLiga
DROP TABLE IF EXISTS USUARIOXLIGA
CREATE TABLE USUARIOXLIGA
(
	CorreoUsuario	VARCHAR(100),
	IdLiga		INT,

	PRIMARY KEY(CorreoUsuario, IdLiga)
);

-- Tabla 6 - Equipo
DROP TABLE IF EXISTS EQUIPO
CREATE TABLE EQUIPO
(
	Id				INT,
	MarcaEscuderia	VARCHAR(100),
	NombrePiloto1	VARCHAR(100),
	NombrePiloto2	VARCHAR(100),
	NombrePiloto3	VARCHAR(100),
	NombrePiloto4	VARCHAR(100),
	NombrePiloto5	VARCHAR(100),
	PuntajePublica	INT,
	Costo			INT,

	PRIMARY KEY(Id)
);

-- Tabla 7 - Escuderia
DROP TABLE IF EXISTS ESCUDERIA
CREATE TABLE ESCUDERIA
(
	Marca			VARCHAR(100),
	Precio			INT,
	UrlLogo			VARCHAR(500),

	PRIMARY KEY(Marca)
);

-- Tabla 8 - Piloto
DROP TABLE IF EXISTS PILOTO
CREATE TABLE PILOTO
(
	Nombre			VARCHAR(100),
	Pais			VARCHAR(100),
	Precio			INT,
	EquipoReal		VARCHAR(100),
	UrlLogo			VARCHAR(500)

	PRIMARY KEY(Nombre)
);

-- LLAVES FORÁNEAS --

ALTER TABLE CARRERA
ADD CONSTRAINT FK_CARRERA_CAMPEONATO FOREIGN KEY(IdCampeonato)
REFERENCES CAMPEONATO(Id);

ALTER TABLE LIGA
ADD CONSTRAINT FK_LIGA_CAMPEONATO FOREIGN KEY(IdCampeonato)
REFERENCES CAMPEONATO(Id);

ALTER TABLE USUARIOXLIGA
ADD CONSTRAINT FK_USUARIOXLIGA_USUARIO FOREIGN KEY(CorreoUsuario)
REFERENCES USUARIO(Correo);

ALTER TABLE USUARIOXLIGA
ADD CONSTRAINT FK_USUARIOXLIGA_LIGA FOREIGN KEY(IdLiga)
REFERENCES LIGA(Id);

ALTER TABLE USUARIO
ADD CONSTRAINT FK_USUARIO_EQUIPO_1 FOREIGN KEY(IdEquipo1)
REFERENCES EQUIPO(Id);

ALTER TABLE USUARIO
ADD CONSTRAINT FK_USUARIO_EQUIPO_2 FOREIGN KEY(IdEquipo2)
REFERENCES EQUIPO(Id);

ALTER TABLE EQUIPO
ADD CONSTRAINT FK_EQUIPO_ESCUDERIA FOREIGN KEY(MarcaEscuderia)
REFERENCES ESCUDERIA(Marca);

ALTER TABLE EQUIPO
ADD CONSTRAINT FK_EQUIPO_PILOTO_1 FOREIGN KEY(NombrePiloto1)
REFERENCES PILOTO(Nombre);

ALTER TABLE EQUIPO
ADD CONSTRAINT FK_EQUIPO_PILOTO_2 FOREIGN KEY(NombrePiloto2)
REFERENCES PILOTO(Nombre);

ALTER TABLE EQUIPO
ADD CONSTRAINT FK_EQUIPO_PILOTO_3 FOREIGN KEY(NombrePiloto3)
REFERENCES PILOTO(Nombre);

ALTER TABLE EQUIPO
ADD CONSTRAINT FK_EQUIPO_PILOTO_4 FOREIGN KEY(NombrePiloto4)
REFERENCES PILOTO(Nombre);

ALTER TABLE EQUIPO
ADD CONSTRAINT FK_EQUIPO_PILOTO_5 FOREIGN KEY(NombrePiloto5)
REFERENCES PILOTO(Nombre);

-- VIEWS --
DROP VIEW IF EXISTS FECHAS;
GO
CREATE VIEW FECHAS

AS SELECT CAMPEONATO.FechaInicio, CAMPEONATO.FechaFin
FROM CAMPEONATO

GO

DROP VIEW IF EXISTS FECHASCARRERA;
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

	INSERT INTO USUARIOXLIGA (CorreoUsuario, IdLiga)
		SELECT
			Correo AS CorreoUsuario,
			@IdLiga AS IdLiga
		FROM USUARIO;

END
GO

-- nombre: fc_validar_fechas_campeonato
-- descripcion: este sp valida que las fechas 

-- POPULACION DE LAS TABLAS

INSERT INTO CAMPEONATO	(Id, Nombre, Presupuesto, FechaInicio, HoraInicio, FechaFin, HoraFin, ReglasPuntuacion)
			VALUES		('KL9HY6', 'Campeonato 2022', 250, '06-15-2022', '13:00', '10-23-2022', '14:30', 'Se va a considerar que los primeros 100 lugares ganaran (100-pos) puntos.');


INSERT INTO CARRERA		(Id, IdCampeonato, Nombre, NombrePais, NombrePista, FechaInicio, HoraInicio, FechaFin, HoraFin, Estado)
			VALUES		(1, 'KL9HY6', 'Carrera marzo CRI', 'Costa Rica', 'Pista San José', '03-03-2022', '1:00', '03-06-2022', '13:00', 'Carrera Completada'),
						(2, 'KL9HY6', 'Carrera mayo ESP', 'España', 'Pista Madrid', '05-03-2022', '14:00', '05-06-2022', '15:00', 'Carrera Completada'),
						(3, 'KL9HY6', 'Carrera junio BEL', 'Belgica', 'Pista Bruselas', '06-21-2022', '15:30', '06-25-2022', '9:00', 'Pendiente'),
						(4, 'KL9HY6', 'Carrera agosto FRA', 'Francia', 'Pista Paris', '08-14-2022', '15:00', '08-19-2022', '10:00', 'Pendiente');


INSERT INTO LIGA	(Id, IdCampeonato, Tipo)
			VALUES	(1, 'KL9HY6', 'Publica');

INSERT INTO ESCUDERIA (Marca, Precio, UrlLogo)
			VALUES  ('FERRARI', 55, 'url'),
					('RED BULL', 45, 'url'),
					('MERCEDES', 45, 'url'),
					('MCLAREN', 35, 'url'),
					('ALFA ROMEO RACING', 30, 'url'),
					('ALPINE F1 TEAM', 25, 'url'),
					('ALPHATAURI', 20, 'url'),
					('HAAS F1 TEAM', 15, 'url'),
					('ASTON MARTIN', 10, 'url'),
					('WILLIAMS', 10, 'url');

INSERT INTO PILOTO	(Nombre, Pais, Precio, EquipoReal, UrlLogo)
			VALUES	('Charles Leclerc', 'Polonia', 30, 'FERRARI', 'url'),
					('Max Verstappen', 'Holanda', 30, 'RED BULL', 'url'),
					('Sergio Perez', 'Mexico', 26, 'RED BULL', 'url'),
					('George Russell', 'Gran Bretaña', 25, 'MERCEDES', 'url'),
					('Carlos Sainz', 'España', 25, 'FERRARI', 'url'),
					('Lewis Hamilton', 'Gran Bretaña', 25, 'MERCEDES', 'url'),
					('Lando Norris', 'Gran Bretaña', 23, 'MCLAREN', 'url'),
					('Fernando Alonso', 'España', 23, 'ALPINE F1 TEAM', 'url'),
					('Valtteri Bottas', 'Finlandia', 23, 'ALFA ROMEO RACING', 'url'),
					('Esteban Ocoon', 'Francia', 22, 'ALPINE F1 TEAM',  'url'),
					('Kevin Magnuussen', 'Dinamarca', 20, 'HAAS F1 TEAM', 'url'),
					('Daniel Ricciardo', 'Australia', 18, 'MCLAREN', 'url'),
					('Yuki Tsunoda', 'Japon', 15, 'ALPHATAURI', 'url'),
					('Sebastian Vettel', 'Alemania', 15, 'ASTON MARTIN', 'url'),
					('Lance Stroll', 'Canada', 13, 'ASTON MARTIN', 'url'),
					('Mick Shumacher', 'Alemania', 13, 'HAAS F1 TEAM', 'url'),
					('Nico Hulkenberg', 'Alemania', 11, 'ASTON MARTIN', 'url');

INSERT INTO EQUIPO  (Id, MarcaEscuderia,	NombrePiloto1,	NombrePiloto2,	NombrePiloto3,	NombrePiloto4,	NombrePiloto5,	PuntajePublica,	Costo)
		VALUES		(1, 'FERRARI', 'Esteban Ocoon', 'Lance Stroll', 'Daniel Ricciardo', 'Mick Shumacher', 'Lewis Hamilton', 0, 146),
					(2, 'ASTON MARTIN', 'Charles Leclerc', 'Lewis Hamilton', 'Yuki Tsunoda', 'Sebastian Vettel', 'Lance Stroll', 0, 108),
					(3, 'MCLAREN', 'Nico Hulkenberg', 'Mick Shumacher', 'Kevin Magnuussen', 'Lando Norris', 'Fernando Alonso', 0, 125),
					(4, 'RED BULL', 'Sergio Perez', 'Kevin Magnuussen', 'Yuki Tsunoda', 'Sebastian Vettel', 'Nico Hulkenberg', 0, 132);

INSERT INTO USUARIO (NombreUsuario, Correo, Pais, Contrasena, NombreEscuderia, IdEquipo1, IdEquipo2)
			VALUES	('Juan Navarro', 'juan@gmail.com', 'Costa Rica', '81dc9bdb52d04dc20036dbd8313ed055', 'RayoF1', 1, 2),
					('Monica Waterhouse', 'monica@gmail.com', 'Costa Rica', '81dc9bdb52d04dc20036dbd8313ed055', 'ganadoresCR', 3, 4);


INSERT INTO USUARIOXLIGA	(CorreoUsuario, IdLiga)
			VALUES			('juan@gmail.com', 1),
							('monica@gmail.com', 1);

