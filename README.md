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

### USU-4

Tipo: GET

Descipcion: Este request retorna toda la información del perfil de un usuario

Url: `/api/Usuario/Perfil/{correo}` donde el `correo` corresponde al correo del usuario y este tiene que venir encerrado en apóstrofes. 

```Json
[
  {
    "nombreUsuario": "NachoNavarro",
    "pais": "Costa Rica",
    "nombreEscuderia": "RayoF1",
    "marcaEscuderia": "FERRARI",
    "nombreEquipo": "Campeones",
    "nombrePiloto1": "Esteban Ocoon",
    "nombrePiloto2": "Lance Stroll",
    "nombrePiloto3": "Daniel Ricciardo",
    "nombrePiloto4": "Mick Shumacher",
    "nombrePiloto5": "Lewis Hamilton"
  },
  {
    "nombreUsuario": "NachoNavarro",
    "pais": "Costa Rica",
    "nombreEscuderia": "RayoF1",
    "marcaEscuderia": "ASTON MARTIN",
    "nombreEquipo": "VivaF1",
    "nombrePiloto1": "Charles Leclerc",
    "nombrePiloto2": "Lewis Hamilton",
    "nombrePiloto3": "Yuki Tsunoda",
    "nombrePiloto4": "Sebastian Vettel",
    "nombrePiloto5": "Lance Stroll"
  }
]
```

Observaciones: Note que el correo en la url del request debe venir encerrado por apóstrofes, si no se hace así entonces no funciona.

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

## Requests LIGAS (LIG)

### LIG-1

Tipo: GET

Descripción: Este request da como resultado los datos de la tabla de resultados de la liga pública, todos acomodados por puntajes, tal y como se definió en el mockup

Url: `/api/Liga/PuntajesPublica`

Json: El resultado tiene este formato

```Json
[
  {
    "posicion": 1,
    "jugador": "NachoNavarro",
    "escuderia": "RayoF1",
    "equipo": "VivaF1",
    "puntos": 160,
    "correo": "juan@gmail.com"
  },
  {
    "posicion": 2,
    "jugador": "NachoNavarro",
    "escuderia": "RayoF1",
    "equipo": "Campeones",
    "puntos": 150,
    "correo": "juan@gmail.com"
  },
  {
    "posicion": 3,
    "jugador": "MoniWaterhouse",
    "escuderia": "ganadoresCR",
    "equipo": "GOAT",
    "puntos": 110,
    "correo": "juan@gmail.com"
  }
]
```

Observaciones: Note que también se da el dato del correo, este no se va a mostrar pero es util para el routing que permite ver el perfil de los jugadores.

### LIG-2

Tipo: GET

Descripción: Este request da como resultado los datos de la tabla de la liga pública pero solo para los equipos de un usuario en específico (la idea es tomar los del usuario logueado)

Url: `/api/Liga/PuntajesPublica/{correo}` donde el correo es el correo del usuario a consultar. Es importante que se debe escribir el correo con apóstrofes entre el nombre por ejemplo, en vez de escribir steven@gmail.com se escribe 'steven@gmail.com' 

Json: El resultado tiene este formato

```Json
[
  {
    "posicion": 2,
    "jugador": "NachoNavarro",
    "escuderia": "RayoF1",
    "equipo": "Campeones",
    "puntos": 150,
    "correo": "juan@gmail.com"
  },
  {
    "posicion": 3,
    "jugador": "MoniWaterhouse",
    "escuderia": "ganadoresCR",
    "equipo": "GOAT",
    "puntos": 110,
    "correo": "juan@gmail.com"
  }
]
```

Observaciones: Note que la posición dada coincide con la posición de la tabla general (del request LIG-1) y no necesariamente con el de este request, esto es para dar ese dato como se definió en el mockup.


### LIG-3


Tipo: GET

Descripción: Este request da como resultado los datos de la tabla de la liga privada a la que pertenece un jugador (un jugador solamente puede pertenecer a una liga privada)

Url: `/api/Liga/PuntajesPrivada/{correo}` donde el correo es el correo del usuario que se encuentra logueado, un usuario solamente puede estar en una liga privada a la vez es por esto que no hay conflicto. Es importante que se debe escribir el correo con apóstrofes entre el nombre por ejemplo, en vez de escribir steven@gmail.com se escribe 'steven@gmail.com'  

Json: El resultado tiene este formato

```Json
[
  {
    "posicion": 1,
    "jugador": "NachoNavarro",
    "escuderia": "RayoF1",
    "equipo": "VivaF1",
    "puntos": 160,
    "correo": "juan@gmail.com"
  },
  {
    "posicion": 2,
    "jugador": "NachoNavarro",
    "escuderia": "RayoF1",
    "equipo": "Campeones",
    "puntos": 150,
    "correo": "juan@gmail.com"
  },
  {
    "posicion": 3,
    "jugador": "MoniWaterhouse",
    "escuderia": "ganadoresCR",
    "equipo": "GOAT",
    "puntos": 110,
    "correo": "monica@gmail.com"
  }
]
```

Observaciones: Se da el correo para ayudar al routing del perfil del usuario

### LIG-4


Tipo: GET

Descripción: Este request da como resultado los nombres de los jugadores de la liga privada en la que se encuentra el jugador actual

Url: `/api/Liga/UsuariosLiga/{correo}` donde el correo es el correo del usuario que se encuentra logueado, un usuario solamente puede estar en una liga privada a la vez es por esto que no hay conflicto. Es importante que se debe escribir el correo con apóstrofes entre el nombre por ejemplo, en vez de escribir steven@gmail.com se escribe 'steven@gmail.com'  

Json: El resultado tiene este formato

```Json
[
  {
    "jugador": "MoniWaterhouse"
  },
  {
    "jugador": "NachoNavarro"
  }
]
```

Observaciones: -

### LIG-5


Tipo: GET

Descripción: Este request da como resultado la información de la liga privada en la que se encuentra el usuario logueado

Url: `/api/Liga/InfoPrivada/{correo}` donde el correo es el correo del usuario que se encuentra logueado, un usuario solamente puede estar en una liga privada a la vez es por esto que no hay conflicto. Es importante que se debe escribir el correo con apóstrofes entre el nombre por ejemplo, en vez de escribir steven@gmail.com se escribe 'steven@gmail.com'  

Json: El resultado tiene este formato

```Json
{
  "cantidad": 4,
  "idLiga": "KL9HY6-WEF567",
  "activa": 0
}
```

Observaciones: estos datos son usados como se muestra en el mockup

### LIG-6


Tipo: GET

Descripción: Este request da como resultado la cantidad de jugadores que hay en la liga privada en la que se encuentra un jugador en específico. Si el resultado es 0 este jugador no está en una liga privada.

Url: `/api/Liga/CantidadJugador/{correo}` donde el correo es el correo del usuario que se encuentra logueado, un usuario solamente puede estar en una liga privada a la vez es por esto que no hay conflicto. Es importante que se debe escribir el correo con apóstrofes entre el nombre por ejemplo, en vez de escribir steven@gmail.com se escribe 'steven@gmail.com' 

Json: El resultado tiene este formato

```Json
{
  "cantidad": 4
}
```

Observaciones: -

### LIG-7


Tipo: POST

Descripción: Este request permite crear una liga privada para un usuario que no se encuentra en una.

Url: `/api/Liga` 

Json: El Json que se debe adjuntar necesita el siguiente formato

```Json
{
  "nombre": "grangranliga",
  "correo": "jose@gmail.com"
}
```

Observaciones: -

### LIG-8


Tipo: GET

Descripción: Este request recibe todas las llaves de las ligas privadas. La idea es compararlas con la escrita y si no se encuentra  entonces es porque la llave indicada no existe.

Url: `/api/Liga/IdPrivadas`

Json: El resultado tiene este formato

```Json
[
  {
    "id": "KL9HY6-WEF567"
  }
]
```

Observaciones: -

### LIG-9


Tipo: GET

Descripción: Este request recibe todas las llaves de las ligas privadas. La idea es compararlas con la escrita y si no se encuentra  entonces es porque la llave indicada no existe.

Url: `/api/Liga/CantidadJugadorPorId/{idLiga}` donde el `idLiga` tiene que venir entre apóstrofes.

Json: El resultado tiene este formato

```Json
{
  "cantidad": 6
}
```

Observaciones: si la cantidad es mayor a 38 entonces no se debería permitir que el jugador se una.


### LIG-10


Tipo: PUT

Descripción: Este request permite actualizar la liga añadiendo un nuevo miembro a esta

Url: `/api/Liga` 

Json: El Json que se debe adjuntar necesita el siguiente formato

```Json
{
  "id": "KL9HY6-WEF567",
  "correo": "steven@gmail.com"
}
```

Observaciones: -
