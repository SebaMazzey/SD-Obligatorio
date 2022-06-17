# Obligatorio - SISTEMAS DISTRIBUIDOS 😎

## Arquitectura del Sistema 🦾

El sistema de eVoting tiene una arquitectura de microservicios. 

1. Servidor Departamental
    * Servicio de Tokens
    * Hashing de datos
    * Ingreso de votos
    * Autenticación de usuarios
    
2. Servidor Central
    * Escrutinio 
    * Resultados
## Requerimientos🛑

- .NET 5.0
- Docker
- Docker Compose
- IDE, recomendamos Visual Studio

## Como levantar la aplicación 💨

##### Docker
Se deben levantar los contenedores, para hacerlo se debe ejecutar el archivo init.sh incluido en los archivos adjuntos.  

> Nota: Se debe tener la aplicación de Docker abierta.

##### Swagger
Para esta DEMO se podrá interactuar con el sistema a través de swagger, pegandole a los diferentes endpoints de las APIs. 

``ELECTION``
* Create: Crea una nueva elección, se debe proporcionar el nombre, la fecha de inicio y fin y las opciones.
* GetAll: Devuelve todas las elecciones. 
* Results: Devuelve los votos totales de la elección. 

``OPTION``
* VotingOptions: Devuelve la lista de opciones para votar

``USER``
* Verify: Introduciendo una CI, el sistema verificará al usuario y su elegibilidad para votar.
* RemainingVotes: Devuelve la cantidad de personas que aún no votaron.

``VOTE``
* Add: Dado un CI, una opción de voto y un número de circuito, se emite el voto y se preserva en la BD.
* Results: Devuelve los resultados de la votación del departamento.
