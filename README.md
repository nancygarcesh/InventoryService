
# Inventory Service API

Microservicio de inventario desarrollado en **C# (.NET 10)** con **MySQL** y documentación de API mediante **Swagger**.  
Permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre items de inventario.

---

## Tecnologías utilizadas

- .NET 10 / C#  
- ASP.NET Core Web API  
- Entity Framework Core (EF Core)  
- MySQL  
- Swagger / OpenAPI  
- Visual Studio 2026  

---

## Instalación y configuración

1. Clonar el repositorio:

```bash
Descargar o clonar este repositorio
cd InventoryService/InventoryService


2. Instalar paquetes

```bash
dotnet restore
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Swashbuckle.AspNetCore

3. Crear la base de datos y aplicar migraciones

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update


Ejecutar
```bash
dotnet run

El servicio estará disponible en:

HTTPS: https://localhost:7234

HTTP: http://localhost:5101

Para probar:
https://localhost:7234/swagger
http://localhost:5101/swagger
