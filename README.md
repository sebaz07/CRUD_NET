# CRUD Simple en .NET 9

Este proyecto es un ejemplo básico de una API RESTful para gestionar blogs utilizando .NET 9. Permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar) sobre una lista en memoria.

## Requisitos
- .NET 9 SDK
- Editor de código como Visual Studio, Visual Studio Code o similar

## Estructura del Proyecto
- `Program.cs`: Contiene toda la lógica de la API y la definición de la clase `Blog`.
- `request.http`: Archivo con ejemplos de peticiones para probar la API usando REST Client (extensión de VS Code).
- `appsettings.json` y `appsettings.Development.json`: Configuración de la aplicación.
- `CRUD.csproj`: Archivo de proyecto de .NET.

## Cómo ejecutar el proyecto

1. Abre una terminal en la carpeta `CRUD`.
2. Ejecuta el siguiente comando:
   ```bash
   dotnet run
   ```
3. La API estará disponible en `http://localhost:5286` (según la configuración por defecto).

## Endpoints disponibles

### 1. Obtener mensaje raíz
- **GET /**
- **Respuesta:** `"I am root!"`

### 2. Listar todos los blogs
- **GET /blogs**
- **Respuesta:** Lista de todos los blogs existentes.

### 3. Obtener un blog por ID
- **GET /blogs/{id}**
- **Parámetros:**
  - `id` (int): Índice del blog en la lista (comienza en 0).
- **Respuesta:**
  - 200 OK: Objeto `Blog` si existe.
  - 404 Not Found: Si el ID no existe.

### 4. Crear un nuevo blog
- **POST /blogs**
- **Body:** (JSON)
  ```json
  {
    "title": "Título del blog",
    "body": "Contenido del blog"
  }
  ```
- **Respuesta:**
  - 201 Created: Blog creado.

### 5. Actualizar un blog existente
- **PUT /blogs/{id}**
- **Parámetros:**
  - `id` (int): Índice del blog a actualizar.
- **Body:** (JSON)
  ```json
  {
    "title": "Nuevo título",
    "body": "Nuevo contenido"
  }
  ```
- **Respuesta:**
  - 200 OK: Blog actualizado.
  - 404 Not Found: Si el ID no existe.

### 6. Eliminar un blog
- **DELETE /blogs/{id}**
- **Parámetros:**
  - `id` (int): Índice del blog a eliminar.
- **Respuesta:**
  - 204 No Content: Eliminado correctamente.
  - 404 Not Found: Si el ID no existe.

## Ejemplos de uso con REST Client
Puedes usar el archivo `request.http` para probar los endpoints desde VS Code con la extensión REST Client. Ejemplo de petición para crear un blog:

```
POST http://localhost:5286/blogs
Content-type: application/json

{
    "title": "Mi nuevo blog",
    "body": "Este es el contenido de mi nuevo blog"
}
```

## Explicación del código principal

- **Lista de blogs:**
  ```csharp
  var blogs = new List<Blog>
  {
      new Blog {Title = "My firts Post", Body = "This is my firts post" },
      new Blog {Title = "My second Post", Body = "This is my second post"}
  };
  ```
  Se inicializa una lista en memoria con dos blogs de ejemplo.

- **Clase Blog:**
  ```csharp
  public class Blog
  {
      public required string Title { get; set; }
      public required string Body { get; set; }
  }
  ```
  Define la estructura de un blog con dos propiedades: `Title` y `Body`.

- **Endpoints:**
  - **GET /blogs:** Devuelve la lista completa de blogs.
  - **GET /blogs/{id}:** Devuelve un blog por su índice. Si el índice no existe, responde 404.
  - **POST /blogs:** Recibe un objeto Blog en el body y lo agrega a la lista.
  - **PUT /blogs/{id}:** Reemplaza el blog en la posición indicada por el nuevo objeto recibido.
  - **DELETE /blogs/{id}:** Elimina el blog en la posición indicada.

## Notas
- Los datos se almacenan solo en memoria, por lo que se pierden al reiniciar la aplicación.
- El campo `id` corresponde al índice en la lista interna.
- El proyecto está configurado para ejecutarse en modo desarrollo por defecto.

---
Trying pipelines