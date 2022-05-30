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

ALTER TABLE USUARIO
DROP CONSTRAINT IF EXISTS FK_USUARIO_EQUIPO_1;

ALTER TABLE USUARIO
DROP CONSTRAINT IF EXISTS FK_USUARIO_EQUIPO_2;

ALTER TABLE EQUIPO
DROP CONSTRAINT IF EXISTS FK_EQUIPO_ESCUDERIA;

ALTER TABLE EQUIPO
DROP CONSTRAINT IF EXISTS FK_EQUIPO_PILOTO_1;

ALTER TABLE EQUIPO
DROP CONSTRAINT IF EXISTS FK_EQUIPO_PILOTO_2;

ALTER TABLE EQUIPO
DROP CONSTRAINT IF EXISTS FK_EQUIPO_PILOTO_3;

ALTER TABLE EQUIPO
DROP CONSTRAINT IF EXISTS FK_EQUIPO_PILOTO_4;

ALTER TABLE EQUIPO
DROP CONSTRAINT IF EXISTS FK_EQUIPO_PILOTO_5;



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
	IdLiga			VARCHAR(20),
	IdCampeonato	VARCHAR(6),
	Tipo			VARCHAR(10),
	Activa			INT,
	
	PRIMARY KEY(IdLiga)
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
	IdLiga		VARCHAR(20),

	PRIMARY KEY(CorreoUsuario, IdLiga)
);

-- Tabla 6 - Equipo
DROP TABLE IF EXISTS EQUIPO
CREATE TABLE EQUIPO
(
	Id				INT,
	Nombre			VARCHAR(100),
	MarcaEscuderia	VARCHAR(100),
	NombrePiloto1	VARCHAR(100),
	NombrePiloto2	VARCHAR(100),
	NombrePiloto3	VARCHAR(100),
	NombrePiloto4	VARCHAR(100),
	NombrePiloto5	VARCHAR(100),
	PuntajePublica	INT,
	PuntajePrivada	INT,
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

-- LLAVES FOR�NEAS --

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
REFERENCES LIGA(IdLiga);

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

-- view de puntajes en liga publica
DROP VIEW IF EXISTS PuntajesPublica
GO
CREATE VIEW PuntajesPublica
AS SELECT ROW_NUMBER() OVER(ORDER BY EQU.PuntajePublica DESC) AS Posicion, USU.NombreUsuario AS Jugador, USU.NombreEscuderia AS Escuderia, EQU.Nombre AS Equipo, EQU.PuntajePublica AS Puntos
FROM (((LIGA AS LIG JOIN CAMPEONATO AS CAM ON LIG.IdCampeonato = CAM.Id)
		JOIN USUARIOXLIGA UXL ON LIG.IdLiga = UXL.IdLiga)
		JOIN USUARIO AS USU ON UXL.CorreoUsuario = USU.Correo)
		JOIN EQUIPO AS EQU ON (USU.IdEquipo1 = EQU.Id OR USU.IdEquipo2 = EQU.Id)
WHERE CAM.FechaFin > GETDATE() AND CAM.FechaInicio < GETDATE()

GO

-- view de puntajes en liga privada
DROP VIEW IF EXISTS PuntajesPrivada
GO
CREATE VIEW PuntajesPrivada
AS SELECT ROW_NUMBER() OVER(ORDER BY EQU.PuntajePublica DESC) AS Posicion, USU.NombreUsuario AS Jugador, USU.NombreEscuderia AS Escuderia, EQU.Nombre AS Equipo, EQU.PuntajePublica AS Puntos
FROM (((LIGA AS LIG JOIN CAMPEONATO AS CAM ON LIG.IdCampeonato = CAM.Id)
		JOIN USUARIOXLIGA UXL ON LIG.IdLiga = UXL.IdLiga)
		JOIN USUARIO AS USU ON UXL.CorreoUsuario = USU.Correo)
		JOIN EQUIPO AS EQU ON (USU.IdEquipo1 = EQU.Id OR USU.IdEquipo2 = EQU.Id)
WHERE LIG.Tipo = 'Privada'

GO

-- STORED PROCEDURES -- 

-- nombre: sp_crear_liga
-- descripcion: este sp crea una nueva liga public asociada al campeonato
-- que se ingresa por parametro. La idea es utilizarlo cuando se crea un
-- campeonato. Tambien asocia a todos los jugadoeres activos a la liga.
DROP PROCEDURE IF EXISTS sp_crear_liga_publica
GO
CREATE PROCEDURE sp_crear_liga_publica (
	@IdCampeonato	VARCHAR(6),
	@Activa			INT
)
AS
BEGIN

	INSERT INTO LIGA (IdLiga, IdCampeonato, Tipo, Activa)
			VALUES	 (@IdCampeonato, @IdCampeonato, 'Publica',@Activa);

	INSERT INTO USUARIOXLIGA (CorreoUsuario, IdLiga)
		SELECT
			Correo AS CorreoUsuario,
			@IdCampeonato AS IdLiga
		FROM USUARIO;

END
GO

-- nombre: sp_anadir_usuario_liga
-- descripcion: este sp a�ade al nuevo usuario a todas las ligas publicas que hay
-- solamente indicando el correo de este
DROP PROCEDURE IF EXISTS sp_anadir_usuario_liga
GO
CREATE PROCEDURE sp_anadir_usuario_liga (
	@CorreoUsuario	VARCHAR(100)
)
AS
BEGIN
	INSERT INTO USUARIOXLIGA (CorreoUsuario, IdLiga)
		SELECT
			@CorreoUsuario AS CorreoUsuario,
			IdLiga
		FROM LIGA
		WHERE Tipo = 'Publica'
END
GO

-- nombre: fc_validar_fechas_campeonato
-- descripcion: este sp valida que las fechas 

-- POPULACION DE LAS TABLAS

INSERT INTO CAMPEONATO	(Id, Nombre, Presupuesto, FechaInicio, HoraInicio, FechaFin, HoraFin, ReglasPuntuacion)
			VALUES		('KL9HY6', 'Campeonato 2022', 250, '04-15-2022', '13:00', '10-23-2022', '14:30', 'Se va a considerar que los primeros 100 lugares ganaran (100-pos) puntos.');


INSERT INTO CARRERA		(Id, IdCampeonato, Nombre, NombrePais, NombrePista, FechaInicio, HoraInicio, FechaFin, HoraFin, Estado)
			VALUES		(1, 'KL9HY6', 'Carrera marzo CRI', 'Costa Rica', 'Pista San Jos�', '03-03-2022', '1:00', '03-06-2022', '13:00', 'Carrera Completada'),
						(2, 'KL9HY6', 'Carrera mayo ESP', 'Espa�a', 'Pista Madrid', '05-03-2022', '14:00', '05-06-2022', '15:00', 'Carrera Completada'),
						(3, 'KL9HY6', 'Carrera junio BEL', 'Belgica', 'Pista Bruselas', '06-21-2022', '15:30', '06-25-2022', '9:00', 'Pendiente'),
						(4, 'KL9HY6', 'Carrera agosto FRA', 'Francia', 'Pista Paris', '08-14-2022', '15:00', '08-19-2022', '10:00', 'Pendiente');


INSERT INTO LIGA	(IdLiga, IdCampeonato, Tipo, Activa)
			VALUES	('KL9HY6', 'KL9HY6', 'Publica', 1);

INSERT INTO ESCUDERIA (Marca, Precio, UrlLogo)
			VALUES  ('FERRARI', 55, 'https://i.pinimg.com/originals/3d/8e/eb/3d8eebbdb50c5370e59e031ca161aacd.jpg'),
					('RED BULL', 45, 'https://i.pinimg.com/originals/2e/07/5b/2e075bf5f5570e5ef486455454c037d4.jpg'),
					('MERCEDES', 45, 'https://i.pinimg.com/originals/13/da/b6/13dab6e986c7495f24924cc6f33e3b3b.jpg'),
					('MCLAREN', 35, 'https://i.pinimg.com/originals/e0/44/fa/e044fa6657a80ce064102f8b75031731.jpg'),
					('ALFA ROMEO RACING', 30, 'https://i.pinimg.com/originals/b6/78/f1/b678f12f803bc44f6f818a48e4d4e944.jpg'),
					('ALPINE F1 TEAM', 25, 'https://i.pinimg.com/originals/13/54/7e/13547e6bb857266780c29997a514fa30.jpg'),
					('ALPHATAURI', 20, 'https://i.pinimg.com/originals/e2/85/2f/e2852fe967b6926700d4432febc598f1.jpg'),
					('HAAS F1 TEAM', 15, 'https://i.pinimg.com/originals/06/18/ab/0618ab732238746039468659782f1023.jpg'),
					('ASTON MARTIN', 10, 'https://i.pinimg.com/originals/15/3f/60/153f60fd1240d4175b670bc7c0ed51af.jpg'),
					('WILLIAMS', 10, 'https://i.pinimg.com/originals/11/a1/9a/11a19ae032e2b756994e9cf5d3b524dc.jpg');

INSERT INTO PILOTO	(Nombre, Pais, Precio, EquipoReal, UrlLogo)
			VALUES	('Charles Leclerc', 'Polonia', 30, 'FERRARI', 'https://soymotor.com/sites/default/files/styles/small/public/imagenes/piloto/perfil-charles-leclerc-2022-soymotor.png'),
					('Max Verstappen', 'Holanda', 30, 'RED BULL', 'https://cdn-9.motorsport.com/images/mgl/24vA3r46/s8/max-verstappen-red-bull-racing-1.jpg'),
					('Sergio Perez', 'Mexico', 26, 'RED BULL', 'https://cdn-1.motorsport.com/images/mgl/0a9neZP0/s8/sergio-perez-red-bull-racing-1.jpg'),
					('George Russell', 'Gran Breta�a', 25, 'MERCEDES', 'https://depor.com/resizer/8QK8KXksasI9Zjruij0420_xgzs=/1200x900/smart/filters:format(jpeg):quality(75)/cloudfront-us-east-1.images.arcpublishing.com/elcomercio/NMEIUWUAPZHXNNRPVYBXAFB37A.jpeg'),
					('Carlos Sainz', 'Espa�a', 25, 'FERRARI', 'https://cdn-8.motorsport.com/images/mgl/YXRnk570/s800/carlos-sainz-jr-ferrari-1.jpg'),
					('Lewis Hamilton', 'Gran Breta�a', 25, 'MERCEDES', 'https://cdn-6.motorsport.com/images/mgl/0mb95oa2/s800/lewis-hamilton-mercedes-1.jpg'),
					('Lando Norris', 'Gran Breta�a', 23, 'MCLAREN', 'https://sportsbase.io/images/gpfans/copy_380x388/ce1b523d65a77c79377505f103bd6028ad77f33d.png'),
					('Fernando Alonso', 'Espa�a', 23, 'ALPINE F1 TEAM', 'https://cdn-1.motorsport.com/images/mgl/YBea5Kv2/s800/fernando-alonso-alpine-1.jpg'),
					('Valtteri Bottas', 'Finlandia', 23, 'ALFA ROMEO RACING', 'https://static.motor.es/f1/fichas/contenido/valtteri-bottas/valtteri-bottas2021_1617632013.jpg'),
					('Esteban Ocoon', 'Francia', 22, 'ALPINE F1 TEAM',  'https://static.motor.es/f1/fichas/contenido/esteban-ocon/esteban-ocon2021_1617620557.jpg'),
					('Kevin Magnuussen', 'Dinamarca', 20, 'HAAS F1 TEAM', 'https://soymotor.com/sites/default/files/styles/small/public/imagenes/piloto/perfil-kevin-magnussen-2022-soymotor.png'),
					('Daniel Ricciardo', 'Australia', 18, 'MCLAREN', 'https://cdn-3.motorsport.com/images/mgl/24vA4nA6/s800/daniel-ricciardo-mclaren-1.jpg'),
					('Yuki Tsunoda', 'Japon', 15, 'ALPHATAURI', 'https://cdn-2.motorsport.com/images/mgl/24vA3zN6/s800/yuki-tsunoda-alphatauri-1.jpg'),
					('Sebastian Vettel', 'Alemania', 15, 'ASTON MARTIN', 'https://cdn-1.motorsport.com/images/mgl/2jXZrAb6/s8/sebastian-vettel-aston-martin-1.jpg'),
					('Lance Stroll', 'Canada', 13, 'ASTON MARTIN', 'https://soymotor.com/sites/default/files/styles/small/public/imagenes/piloto/perfil-lance-stroll-2022-soymotor_0.png'),
					('Mick Shumacher', 'Alemania', 13, 'HAAS F1 TEAM', 'https://static.motor.es/f1/fichas/contenido/mick-schumacher/mick-schumacher2021_1617622323.jpg'),
					('Nico Hulkenberg', 'Alemania', 11, 'ASTON MARTIN', 'https://static.motor.es/f1/fichas/contenido/nico-hulkenberg.jpg');

INSERT INTO EQUIPO  (Id, Nombre, MarcaEscuderia,	NombrePiloto1,	NombrePiloto2,	NombrePiloto3,	NombrePiloto4,	NombrePiloto5,	PuntajePublica, PuntajePrivada,	Costo)
		VALUES		(1, 'Campeones', 'FERRARI', 'Esteban Ocoon', 'Lance Stroll', 'Daniel Ricciardo', 'Mick Shumacher', 'Lewis Hamilton', 150, 0, 146),
					(2, 'VivaF1', 'ASTON MARTIN', 'Charles Leclerc', 'Lewis Hamilton', 'Yuki Tsunoda', 'Sebastian Vettel', 'Lance Stroll', 160, 0, 108),
					(3, 'GOAT', 'MCLAREN', 'Nico Hulkenberg', 'Mick Shumacher', 'Kevin Magnuussen', 'Lando Norris', 'Fernando Alonso', 110, 0, 125),
					(4, 'Speed', 'RED BULL', 'Sergio Perez', 'Kevin Magnuussen', 'Yuki Tsunoda', 'Sebastian Vettel', 'Nico Hulkenberg', 65, 0, 132),
					(5, 'EquipoTOP1', 'WILLIAMS', 'Carlos Sainz', 'Nico Hulkenberg', 'Valtteri Bottas', 'Lando Norris', 'Daniel Ricciardo', 155, 0, 100),
					(6, 'DreamTeam', 'MERCEDES', 'Carlos Sainz', 'Kevin Magnuussen', 'Esteban Ocoon', 'Mick Shumacher', 'Lewis Hamilton', 160, 0, 165);

INSERT INTO USUARIO (NombreUsuario, Correo, Pais, Contrasena, NombreEscuderia, IdEquipo1, IdEquipo2)
			VALUES	('NachoNavarro', 'juan@gmail.com', 'Costa Rica', '81dc9bdb52d04dc20036dbd8313ed055', 'RayoF1', 1, 2),
					('MoniWaterhouse', 'monica@gmail.com', 'Costa Rica', '81dc9bdb52d04dc20036dbd8313ed055', 'ganadoresCR', 3, 4),
					('NachoGranados', 'jose@gmail.com', 'Costa Rica', '81dc9bdb52d04dc20036dbd8313ed055', 'EscuderiaTOP', 5, 6);


INSERT INTO USUARIOXLIGA	(CorreoUsuario, IdLiga)
			VALUES			('juan@gmail.com', 'KL9HY6'),
							('monica@gmail.com', 'KL9HY6');

