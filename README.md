# Parrot Challenge

## Arquitectura

Microservicios utilizando Docker

![alt text](diagram.png)

## Requisitos

* Docker 
* Postman 

## Setup 

1. Clonar este repo
2. En una terminal, navegar al folder del repo
3. Ejecutar `docker-compose build`
4. Ejecutar `docker-compose up`

## Test con Postman

Este repositorio incluye un archivo [postman.json](postman.json) con la colección de Postman para probar los endpoints 

1. Importar el archivo [Postman](postman.json) como colección en postman

### Users => Create
Crea un usuario con email y nombre


### Users => Login
Obtiene un jwt para un email

### Orders => Create
Crea una órden con productos, la estructura del request

```json
{
    "ClientName" :"Name",
    "OrderProducts": [{
        "ProductName": "Product 1",
        "UnitPrice": 120,
        "Quantity": 10
    }, {
        "ProductName": "Product 2",
        "UnitPrice": 140,
        "Quantity": 10
    }]
}
```

### Orders => Report
Obtiene un reporte de ventas por producto. El filtrado es por fecha y se envían por query params

`?startDate=2021-01-01&endDate=2021-12-31`

## Tecnologías
* NodeJs + Mongo para user management
* Net 5 + SQL Server para order management

## Docker containers
* NodeJs app
* Mongo server
* Net 5 app
* SQL Server 