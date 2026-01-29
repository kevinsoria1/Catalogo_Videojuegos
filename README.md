# 🎮 GameStore Desktop Manager

![Estado](https://img.shields.io/badge/Estado-Terminado-green) ![Lenguaje](https://img.shields.io/badge/C%23-.NET-blue) ![DB](https://img.shields.io/badge/MySQL-Workbench-orange)

Aplicación de escritorio completa desarrollada en **C# (Windows Forms)** para la gestión, compra y administración de una biblioteca digital de videojuegos. El sistema implementa una arquitectura robusta con base de datos relacional, gestión de roles y seguridad encriptada.

---

## 🚀 Funcionalidades Principales

### 👤 Módulo de Usuario (Cliente)
* **Catálogo Visual:** Interfaz moderna tipo "Grid" con carátulas de juegos.
* **Buscador y Filtros:** Filtrado en tiempo real por nombre y categoría (RPG, Acción, Deportes, etc.).
* **Sistema de Compras Inteligente:**
    * Validación de propiedad: El botón cambia automáticamente de "COMPRAR" (Verde) a "JUGAR" (Amarillo) si ya tienes el juego.
    * **Bloqueo de Duplicados:** Protección tanto en interfaz como en Base de Datos (Constraint SQL) para evitar comprar el mismo juego dos veces.
* **Ficha Técnica:** Ventana modal con detalles, descripción, año y precio.
* **Mi Biblioteca:** Sección exclusiva para ver solo los juegos adquiridos.

### 🛡️ Módulo de Administración (Panel Admin)
* **Gestión de Usuarios (CRUD):**
    * Crear, editar y eliminar usuarios.
    * Asignación de roles (Admin/Nominal) y estados (Activo/Baneado).
    * **Protección SuperAdmin:** Lógica de seguridad que impide borrar o modificar al usuario 'admin' principal.
* **Gestión de Videojuegos (CRUD):**
    * Alta de nuevos juegos con subida de **imágenes (Carátulas)** desde el PC.
    * Las imágenes se guardan directamente en la Base de Datos (BLOB).
    * Control de visibilidad, precios y descripciones.

### 🔒 Seguridad y Arquitectura
* **Login Seguro:** Contraseñas encriptadas con algoritmo **SHA256**.
* **Control de Sesión:** Diferenciación de interfaces según el rol logueado.
* **Base de Datos Relacional:** MySQL con tablas normalizadas (`usuarios`, `videojuegos`, `biblioteca`) y claves foráneas con borrado en cascada.

---

## 🛠️ Tecnologías Utilizadas

* **Lenguaje:** C# (.NET Framework / .NET Core)
* **Interfaz:** Windows Forms (WinForms) con personalización UI (GDI+ para bordes redondeados).
* **Base de Datos:** MySQL 8.0.
* **IDE:** Visual Studio 2022.
* **Herramientas:** MySQL Workbench.

---

## 💾 Instalación y Puesta en Marcha

Sigue estos pasos para probar el proyecto en tu máquina local:

### 1. Clonar el repositorio
```bash
git clone [https://github.com/TU_USUARIO/TU_REPOSITORIO.git](https://github.com/TU_USUARIO/TU_REPOSITORIO.git)
