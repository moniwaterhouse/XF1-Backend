# XF1-Backend

Para correr el backend se debe  tener instalado .NET

También se debe asegurar de tener la base de datos corriendo en la computadora. Para esto se debe ir a la aplicación de Microsoft SQL Server Management Studio y correr el script de creación ubicado en `database-scripts`

Luego correr lo siguente en la dirección de `server/XF1-Backend`.

`dotnet build`

`dotnet run`

Una vez el server esté activo los requests a utilizar tendrán la siguiente base de URL:

`https://localhost:5001`

## Requests CAMPEONATO (CAM)

### CAM-1

Tipo: GET

Descripción: Este request da como resultado los datos de todos los campeonatos, filtrados por fecha donde el de mayor fecha se acomoda primero.

Url: `/api/Campeonato`

Json: El resultado tiene este formato

```Json
[
  {
    "id": "23F6SH",
    "nombre": "Campeonato 2023",
    "presupuesto": 4,
    "fechaInicio": "2023-02-15T00:00:00",
    "horaInicio": "13:00",
    "fechaFin": "2023-05-11T00:00:00",
    "horaFin": "14:30",
    "reglasPuntuacion": null
  },
  {
    "id": "KL9HY6",
    "nombre": "Campeonato 2022",
    "presupuesto": 2,
    "fechaInicio": "2022-06-15T00:00:00",
    "horaInicio": "13:00",
    "fechaFin": "2022-10-23T00:00:00",
    "horaFin": "14:30",
    "reglasPuntuacion": "Se va a considerar que los primeros 100 lugares ganaran (100-pos) puntos."
  }
]
```

Observaciones: La información viene ordenada de la mayor a la menor fecha.

### CAM-2

Tipo: GET

Descripción: Este request da como resultado cada uno de los rangos de fechas que componen los campeonatos actuales. La idea es usarlas para restringir esas fechas en la creación de un campeonato.

Url: `/api/Campeonato/Fechas`

Json: El resultado tiene este formato

```Json
[
  {
    "fechaInicio": "2023-02-15T00:00:00",
    "fechaFin": "2023-05-11T00:00:00"
  },
  {
    "fechaInicio": "2022-06-15T00:00:00",
    "fechaFin": "2022-10-23T00:00:00"
  }
]
```

Observaciones: Note que el formato con el que se retornan las fechas es YYYY-MM-DD

### CAM-3

Tipo: POST

Descripción: Este request sirve para postear un nuevo campeonato

Url: `/api/Campeonato`

Json: El resultado a postear necesita el siguiente formato

```Json
{
  "nombre": "nombre",
  "presupuesto": 10,
  "fechaInicio": "2022-05-07",
  "horaInicio": "1:11",
  "fechaFin": "2022-10-27",
  "horaFin": "13:25",
  "reglasPuntuacion": "estas son las reglas de puntuacion"
}
```

Observaciones: Note que el formato con el que se asignan las fechas es YYYY-MM-DD. Las horas tienen que se dadas en en base a 24 horas (es decir en vez de decir 1:00 pm se dice solo 13:00) y tambien no hace falta completar ningun dato de id porque la llave única se genera en el backend.

### CAM-4

Tipo: GET

Descripción: Este request da como resultado cada uno de los nombres del campeonato. También da la llave porque se va a necesitar en otros requests.

Url: `/api/Campeonato/Nombres`

Json: El resultado tiene este formato

```Json
[
  {
    "id" : "ASDFG4",
    "nombre": "Campeonato 2022" 
  },
  {
    "id" : "43GH6E",
    "nombre": "Campeonato 2023"
  },
  {
    "id" : "43GH6E",
    "nombre": "Campeonato 2026"
  }
]
```

Observaciones: -

## CAM-5

Tipo: GET

Descripción: Este request da como resultado el presupuesto de la temporada actual, la idea es que no se tenga que especificar la temporada, solamente sea capaz de reconocerla por el año actual.

Url: `/api/Campeonato/Presupuesto`

Json: El resultado tiene este formato

```Json
{
  "presupuesto": 270
}
```

Observaciones: -

## Requests CARRERA (CAR)

### CAR-1

Tipo: GET

Descripción: Este request da como resultado los datos de todas las carreras.

Url: `/api/Carrera`

Json: El resultado tiene este formato

```Json
[
  {
    "id": 0,
    "idCampeonato": "XCV5TG",
    "nombre": "Carrera mayo CR",
    "nombrePais": "Costa Rica",
    "nombrePista": "Pista San Jose",
    "fechaClasificacion": "2022-05-07",
    "horaClasificacion": "14:00",
    "fechaCarrera": "2022-05-10",
    "horaCarrera": "13:00",
    "estado": "Pendiente"
  },
  {
    "id": 0,
    "idCampeonato": "XCV5TG",
    "nombre": "Carrera mayo CR",
    "nombrePais": "Costa Rica",
    "nombrePista": "Pista San Jose",
    "fechaInicio": "2022-05-07",
    "horaInicio": "14:00",
    "fechaFin": "2022-05-10",
    "horaFin": "13:00",
    "estado": "Pendiente"
  }
]
```

Observaciones: La información viene ordenada de la mayor a la menor fecha.


### CAR-2

Tipo: GET

Descripción: Este request da como resultado cada uno de los rangos de fechas que componen las carreras correspondientes al campeonato escogido. La idea es usarlas para restringir esas fechas en la creación de un campeonato.

Url: `/api/Carreras/Fechas/{idCampeonato}` donde idCampeonato corresponde a la llave única del campeonato.

Json: El resultado tiene este formato

```Json
[
  {
    "fechaInicio": "2023-02-15T00:00:00",
    "fechaFin": "2023-05-11T00:00:00"
  },
  {
    "fechaInicio": "2022-06-15T00:00:00",
    "fechaFin": "2022-10-23T00:00:00"
  }
]
```

Observaciones: Note que el formato con el que se retornan las fechas es YYYY-MM-DD

### CAR-3

Tipo: POST

Descripción: Este request sirve para postear una nueva carrera

Url: `/api/Carrera`

Json: El resultado a postear necesita el siguiente formato

```Json
  {
    "idCampeonato": "XCV5TG",
    "nombre": "Carrera sep CR",
    "nombrePais": "Costa Rica",
    "nombrePista": "Pista San Jose",
    "fechaClasificacion": "2022-09-07",
    "horaClasificacion": "14:00",
    "fechaCarrera": "2022-09-10",
    "horaCarrera": "13:00"
  }
```

Observaciones: No hay necesidad de especificar el id porque el sistema le da uno calculado de forma que no coincida. Tampoco se debe especificar el estado porque este va a ser "pendiente" por default.

Note que la fecha tiene que estar en el formato de YYYY-MM-DD y las horas son un string en formato de 24 horas. Además en el campo del idCampeonato se debe poner la llave y no el nombre de este. 

### CAR-4

Tipo: GET

Descripción: Este request es un get all de las carreras pero en vez de mostrar el id del campeonato muestra el nombre del campeonato.

Url: `/api/Carrera/NombreCampeonato` 

Json: El resultado tiene este formato

```Json
[
  {
    "id": 1,
    "nombreCampeonato": "Campeonato 2022",
    "nombre": "Carrera marzo CRI",
    "nombrePais": "Costa Rica",
    "nombrePista": "Pista San José",
    "fechaInicio": "2022-03-03T00:00:00",
    "horaInicio": "1:00",
    "fechaFin": "2022-03-06T00:00:00",
    "horaFin": "13:00",
    "estado": "Carrera Completada"
  },
  {
    "id": 2,
    "nombreCampeonato": "Campeonato 2022",
    "nombre": "Carrera mayo ESP",
    "nombrePais": "España",
    "nombrePista": "Pista Madrid",
    "fechaInicio": "2022-05-03T00:00:00",
    "horaInicio": "14:00",
    "fechaFin": "2022-05-06T00:00:00",
    "horaFin": "15:00",
    "estado": "Pendiente"
  }
]
```

Observaciones: Note que el formato con el que se retornan las fechas es YYYY-MM-DD

## Requests USUARIO (USU)

### USU-1

Tipo: GET

Descripción: Este request es retorna todos los correos existentes, es solamente para compronbar que el que se va a añadir no coincida con alguno que ya se tenga guardado.

Url: `/api/Usuario/Correos` 

Json: El resultado tiene este formato

```Json
[
  {
    "correo": "juan@gmail.com"
  },
  {
    "correo": "monica@gmail.com"
  },
  {
    "correo": "steven@gmail.com"
  }
]
```

Observaciones: --

### USU-2

Tipo: GET

Descipcion: Este request retorna todo los nombres de las escuderias existentes, es solamente para compronar que la que se va a añadir no existe.

Url: `/api/Usuario/Escuderias`

```Json
[
  {
    "nombreEscuderia": "RayoF1"
  },
  {
    "nombreEscuderia": "ganadoresCR"
  }
]
```

Observaciones: --

### USU-3

Tipo: POST

Descipcion: Este request permite crear un jugador

Url: `/api/Usuario`

```Json
{
  "nombreUsuario": "NachoGranados",
  "correo": "nacho@gmail.com",
  "pais": "Costa Rica",
  "contrasena": "1234",
  "nombreEscuderia": "miEscuderia",
  "idEquipo1": 1,
  "idEquipo2": 3
}
```

Observaciones: se deben asociar los mismo equipos que se crearon justo antes al usuario.

## Requests PILOTOS (PIL)

### PIL-1

Tipo: GET

Descipcion: Este request retorna todos los datos de todas los pilotos

Url: `/api/Piloto`

```Json
[
  {
    "nombre": "Charles Leclerc",
    "pais": "Polonia",
    "precio": 30,
    "equipoReal": "FERRARI",
    "urlLogo": "url"
  },
  {
    "nombre": "Max Verstappen",
    "pais": "Holanda",
    "precio": 30,
    "equipoReal": "RED BULL",
    "urlLogo": "url"
  }
]
```

Observaciones: en la url se colocará el link de la imagen del piloto

## Requests ESCUDERIAS (ESC)

### ESC-1

Tipo: GET

Descipcion: Este request retorna todos los datos de todas las escuderias

Url: `/api/Escuderia`

```Json
[
  {
    "marca": "FERRARI",
    "precio": 55,
    "urlLogo": "url"
  },
  {
    "marca": "MERCEDES",
    "precio": 45,
    "urlLogo": "url"
  },
  {
    "marca": "WILLIAMS",
    "precio": 10,
    "urlLogo": "url"
  }
]
```

Observaciones: en la url se colocará el link de la imagen de la escuderia


## Requests EQUIPOS (EQU)

### EQU-1

Tipo: POST

Descipcion: Este request crea un nuevo equipo y retorna el id de este nuevo creado.

Url: `/api/Equipo`

```Json
{
  "marcaEscuderia": "FERRARI",
  "nombrePiloto1": "Nico Hulkenberg",
  "nombrePiloto2": "Lewis Hamilton",
  "nombrePiloto3": "Kevin Magnuussen",
  "nombrePiloto4": "Sebastian Vettel",
  "nombrePiloto5": "Mick Shumacher",
  "costo": 146
}
```

Observaciones: no hace falta especificar el id porque ese se añade desde el backend.


