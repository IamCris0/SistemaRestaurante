# 🍽️ Sistema de Gestión de Restaurante - ASP.NET Core MVC

## 📋 Descripción
Aplicación web completa para gestionar un restaurante usando ASP.NET Core MVC y Entity Framework Core con SQL Server.

## ✨ Características
- ✅ CRUD completo para todas las entidades
- ✅ Entity Framework Core con SQL Server
- ✅ Diseño responsive con Bootstrap 5 e iconos Bootstrap Icons
- ✅ Validaciones del lado cliente y servidor
- ✅ Relaciones entre tablas configuradas
- ✅ Mensajes de confirmación (TempData)
- ✅ Interfaz moderna y profesional

## 🗂️ Módulos del Sistema

### Gestión Básica
- **Cargos**: Gestión de puestos de trabajo (Mesero, Chef, Gerente, etc.)
- **Categorías**: Clasificación de platos (Entradas, Principales, Postres, etc.)
- **Mesas**: Control de mesas del restaurante

### Recursos Humanos
- **Empleados**: Administración del personal del restaurante

### Clientes
- **Clientes**: Registro y gestión de clientes

### Menú
- **Platos**: Gestión del menú con precios y stock

### Operaciones
- **Pedidos**: Registro de pedidos y ventas
- **Reservas**: Sistema de reservaciones

## 🚀 Instalación y Configuración

### Requisitos Previos
- .NET 8.0 SDK o superior
- SQL Server (LocalDB, Express o Full)
- Visual Studio 2022 o VS Code
- SQL Server Management Studio (opcional)

### Paso 1: Crear la Base de Datos
```sql
-- Ejecutar en SQL Server
CREATE DATABASE Restaurante;
GO
```

### Paso 2: Configurar Connection String
Edita `appsettings.json` con tu servidor SQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=TU_SERVIDOR;Initial Catalog=Restaurante;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

**Ejemplos de Connection Strings:**

- **SQL Server Local (Windows Authentication):**
  ```
  Data Source=.;Initial Catalog=Restaurante;Integrated Security=True;TrustServerCertificate=True
  ```

- **SQL Server con nombre de instancia:**
  ```
  Data Source=CRIS;Initial Catalog=Restaurante;Integrated Security=True;TrustServerCertificate=True
  ```

- **SQL Server con usuario y contraseña:**
  ```
  Data Source=localhost;Initial Catalog=Restaurante;User ID=sa;Password=TuPassword;TrustServerCertificate=True
  ```

### Paso 3: Instalar Dependencias
```bash
cd RestauranteMVC_Complete
dotnet restore
```

### Paso 4: Crear las Tablas con Migrations
```bash
# Instalar herramienta EF (si no la tienes)
dotnet tool install --global dotnet-ef

# Crear la migración inicial
dotnet ef migrations add InitialCreate

# Aplicar la migración a la base de datos
dotnet ef database update
```

### Paso 5: Ejecutar la Aplicación
```bash
dotnet build
dotnet run
```

Luego abre en tu navegador:
- https://localhost:5001
- http://localhost:5000

## 📁 Estructura del Proyecto

```
RestauranteMVC/
├── Controllers/          # Controladores MVC
│   ├── CargosController.cs
│   ├── HomeController.cs
│   └── ...
├── Models/              # Modelos y DbContext
│   ├── Cargo.cs
│   ├── Cliente.cs
│   ├── Empleado.cs
│   ├── ApplicationDbContext.cs
│   └── ...
├── Views/               # Vistas Razor
│   ├── Cargos/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│   │   └── Details.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml
│   └── Home/
│       └── Index.cshtml
├── wwwroot/            # Archivos estáticos
│   ├── css/
│   ├── js/
│   └── lib/
├── Program.cs          # Configuración de la app
├── appsettings.json    # Configuración
└── RestauranteMVC.csproj
```

## 🎯 Uso del Sistema

### 1. Configuración Inicial
1. Crear **Cargos** (Mesero, Chef, Gerente, etc.)
2. Crear **Categorías** (Entradas, Platos Principales, Postres, Bebidas)
3. Registrar **Mesas** del restaurante

### 2. Gestión de Personal
1. Registrar **Empleados** asignándoles un cargo

### 3. Gestión del Menú
1. Crear **Platos** con su categoría, precio y stock

### 4. Atención al Cliente
1. Registrar **Clientes**
2. Crear **Reservas** para mesas
3. Tomar **Pedidos** asociados a clientes y empleados

## 🔧 Comandos Útiles

### Entity Framework
```bash
# Crear nueva migración
dotnet ef migrations add NombreMigracion

# Aplicar migraciones
dotnet ef database update

# Eliminar última migración
dotnet ef migrations remove

# Ver script SQL de migración
dotnet ef migrations script
```

### Desarrollo
```bash
# Restaurar paquetes
dotnet restore

# Compilar
dotnet build

# Ejecutar en modo desarrollo
dotnet run

# Ejecutar con hot reload
dotnet watch run

# Limpiar compilación
dotnet clean
```

## 📊 Modelo de Datos

### Relaciones
- **Cargo** 1 → N **Empleado**
- **Categoría** 1 → N **Plato**
- **Cliente** 1 → N **Pedido**
- **Cliente** 1 → N **Reserva**
- **Empleado** 1 → N **Pedido**
- **Mesa** 1 → N **Reserva**
- **Pedido** N → M **Plato** (a través de PedidoPlato)

## 🎨 Personalización

### Cambiar Estilos
Edita `/wwwroot/css/site.css`

### Agregar Nuevos Módulos
1. Crear modelo en `/Models`
2. Agregar DbSet en `ApplicationDbContext.cs`
3. Crear migración: `dotnet ef migrations add NuevoModulo`
4. Aplicar: `dotnet ef database update`
5. Crear controller: `dotnet aspnet-codegenerator controller -name NuevoController -m NuevoModelo -dc ApplicationDbContext --relativeFolderPath Controllers --useDefaultLayout`

## ⚠️ Solución de Problemas

### Error de conexión a SQL Server
- Verifica que SQL Server esté corriendo
- Confirma el nombre del servidor en la connection string
- Asegúrate que el firewall permite la conexión

### Error "Table already exists"
```bash
# Eliminar la base de datos y recrearla
dotnet ef database drop
dotnet ef database update
```

### Cambios en modelos no se reflejan
```bash
dotnet ef migrations add ActualizarModelos
dotnet ef database update
```

## 📝 Próximas Mejoras
- [ ] Sistema de autenticación y autorización
- [ ] Reportes y estadísticas
- [ ] Dashboard con gráficos
- [ ] API REST para integración
- [ ] Sistema de facturación
- [ ] Notificaciones en tiempo real

## 👨‍💻 Autor
Sistema desarrollado con ASP.NET Core MVC + Entity Framework Core

## 📄 Licencia
Este proyecto es de código abierto para fines educativos.

---

**¡Listo para usar! 🚀**
```bash
dotnet run
```
