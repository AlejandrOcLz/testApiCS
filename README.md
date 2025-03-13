# testApiCS

API desarrollada en .NET 8.0 para la gestión de usuarios, utilizando autenticación JWT y conexión a una base de datos Azure SQL.

🚀 Tecnologías Utilizadas

.NET Core 8.0.407

Entity Framework Core (EF Core) para la gestión de la base de datos

Azure SQL como base de datos

JWT (JSON Web Token) para autenticación segura

ASP.NET Core Web API para la creación de servicios RESTful

📦 Dependencias y Librerías

Instalar las siguientes dependencias antes de ejecutar el proyecto:

# Entity Framework Core para SQL Server
 dotnet add package Microsoft.EntityFrameworkCore.SqlServer

# Entity Framework Core Tools (migraciones)
 dotnet add package Microsoft.EntityFrameworkCore.Tools

# Autenticación JWT
 dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

# ASP.NET Core Controllers
 dotnet add package Microsoft.AspNetCore.Mvc.Core

🔧 Configuración del Proyecto

Configurar la conexión a la base de datos

# Editar appsettings.json y agregar la cadena de conexión a Azure SQL:
 "ConnectionStrings": {
  "DefaultConnection": "Server=<TU_SERVIDOR>;Database=<TU_BASE_DE_DATOS>;User Id=<USUARIO>;Password=<CONTRASEÑA>;"
}

#  Ejecutar la aplicación
dotnet run

🔑 Autenticación

La API utiliza JWT para la autenticación. Para acceder a los endpoints protegidos, se debe incluir el token en la cabecera de las solicitudes:

Authorization: Bearer <TOKEN>

📌 Endpoints Disponibles

📝 Usuarios
--------------------------
POST

/usuarios

Crea un nuevo usuario
---------------------------
GET

/usuarios/{id}

Obtiene un usuario por ID
--------------------------
PUT

/usuarios/{id}

Actualiza un usuario (nombre, email o edad)
--------------------------
DELETE

/usuarios/{id}

Elimina un usuario
--------------------------
GET

/usuarios

Obtiene la lista de usuarios (requiere autenticación)
--------------------------

🔐 Autenticación
--------------------------
POST

/login

Iniciar sesión y obtener un token JWT
 
