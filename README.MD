# 🧾 Sistema de Inventario

Sistema de gestión de inventario desarrollado en **C# con .NET 8.0** y **MySQL**. Diseñado para mantener el control de productos, ventas, compras, clientes, empleados y movimientos de caja en una interfaz de consola estructurada y modular.

---

## 📌 Índice

- [🧾 Sistema de Inventario](#-sistema-de-inventario)
- [📁 Estructura del Proyecto](#-estructura-del-proyecto)
- [🧱 Arquitectura en Capas](#-arquitectura-en-capas)
- [📦 Modelo de Dominio](#-modelo-de-dominio)
- [🔄 Flujo de la Aplicación](#-flujo-de-la-aplicación)
- [🗄️ Configuración de la Base de Datos](#️-configuración-de-la-base-de-datos)
- [🚀 Cómo Comenzar](#-cómo-comenzar)
- [📤 Despliegue](#-despliegue)
- [✅ Pruebas](#-pruebas)
- [🧩 Stack Tecnológico](#-stack-tecnológico)
- [📚 Créditos](#-créditos)

---

## 📁 Estructura del Proyecto

El proyecto tiene una estructura organizada en capas. Su punto de entrada está en el archivo `Program.cs`, que ejecuta el menú principal (`MenuPrincipal`).

### Detalles del archivo `.csproj`:

- **Framework**: net8.0
- **Tipo**: Exe (aplicación de consola)
- **Dependencias**: `MySql.Data v9.3.0`
- **Nullable**: `enable`
- **ImplicitUsings**: `enable`

---

## 🧱 Arquitectura en Capas

### 1. **Presentación (UI)**  

Menú de consola amigable y estructurado que guía al usuario por las diferentes operaciones del sistema.

### 2. **Lógica de Negocio**  

Coordinación de las operaciones de inventario a través de clases específicas para cada módulo.

### 3. **Acceso a Datos**  

Implementación del patrón Repository, que permite encapsular el acceso a la base de datos.

### 4. **Modelo de Dominio**  

Representación de entidades como `Producto`, `Venta`, `Compra`, `Empleado`, `Cliente`, entre otras.

---

## 📦 Modelo de Dominio

- `Producto`: Código, nombre, precio, stock.
- `Venta`: Cliente, empleado, total, fecha.
- `Compra`: Proveedor, productos comprados, fecha.
- `MovimientoCaja`: Ingresos o egresos de dinero.
- `Plan`: Promociones o combos de productos.
- `Cliente` y `Empleado`: Heredan de `Tercero`, que contiene nombre, documento, dirección, etc.

---

## 🔄 Flujo de la Aplicación

1. **Inicio**: El usuario ejecuta la app desde consola.
2. **Menú Principal**: Interfaz que permite elegir operaciones (ventas, productos, compras...).
3. **Gestión**: Clases especializadas manejan operaciones específicas.
4. **Persistencia**: Las acciones se guardan en MySQL por medio de repositorios.

---

## 🗄️ Configuración de la Base de Datos

Antes de comenzar a usar la aplicación, es necesario configurar la base de datos MySQL:

1. **Crear la Base de Datos**:
   - Abre MySQL Workbench o tu cliente MySQL preferido
   - Ejecuta el script `db/ddl.sql` para crear la estructura de la base de datos
   - Este script creará todas las tablas necesarias para el funcionamiento del sistema

2. **Insertar Datos Iniciales**:
   - Ejecuta el script `db/dml.sql` para insertar los datos de prueba
   - Este script incluye datos de ejemplo para todas las tablas

3. **Configurar la Conexión**:
   - Abre el archivo `app/config/AppSettings.cs`
   - Actualiza la cadena de conexión con tus credenciales:
   ```csharp
   public static string ConnectionString = "Server=localhost;Database=sgi_campus;Uid=tu_usuario;Pwd=tu_contraseña;";
   ```

4. **Verificar la Conexión**:
   - Asegúrate de que el servidor MySQL esté en ejecución
   - La base de datos `sgi_campus` debe estar creada y accesible
   - Las credenciales en `AppSettings.cs` deben coincidir con tu configuración de MySQL

---

## 🚀 Cómo Comenzar

### 1. Clonar el proyecto

```bash
git clone https://github.com/Omarjr33/inventario.git
cd inventario
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Compilar el proyecto

```bash
dotnet build
```

### 4. Ejecutar

```bash
dotnet run
```

---

## 📤 Despliegue

### Requisitos del sistema:

- .NET 8.0 SDK instalado
- MySQL Server configurado con acceso local
- Editor recomendado: Visual Studio 2022 o Visual Studio Code

### Variables de conexión:

Configura tu cadena de conexión en el archivo correspondiente del repositorio (puede ser en `appsettings.json` o directamente en la clase de conexión).

---

## ✅ Pruebas

Actualmente, el proyecto no tiene pruebas automatizadas, pero se recomienda:

- Usar **xUnit** o **NUnit** para pruebas unitarias.
- Probar los módulos por separado (por ejemplo: gestión de productos, módulo de ventas).
- Añadir pruebas de integración para validar la conexión con MySQL.

---

## 🧩 Stack Tecnológico

El proyecto utiliza una combinación de tecnologías modernas para su funcionamiento e integración eficiente.
mas info en [deepwiki/omarjr/inventario](https://deepwiki.com/Omarjr33/inventario).
---

## 📚 Créditos

- Desarrollado por [Omar Cardona](https://www.linkedin.com/in/omar-cardona33).
- Desarrollado por [Raul Puyo](https://github.com/Designedby-Radol)