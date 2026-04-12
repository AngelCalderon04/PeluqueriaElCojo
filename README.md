# Peluquería El Cojo - Sistema de Gestión

## Información del Estudiante
- **Nombre:** Ángel Luis Calderón  
- **Matrícula:** 2024-0380  
- **Asignatura:** ISW-123 Programación Media  
- **Profesor:** Ing. Ivan Zorrilla  

---

## Descripción
Sistema de gestión desarrollado en C# con Windows Forms para la administración de la Peluquería "El Cojo".  
Permite gestionar clientes, empleados, productos, citas y facturación en un entorno organizado y funcional, simulando un flujo real de negocio.

El sistema está orientado a mejorar el control de las operaciones diarias, facilitando el registro de servicios, el cálculo de facturas y la organización de citas.

---

## Funcionalidades Principales
- Gestión de clientes (registro, visualización y selección)
- Gestión de empleados (barberos)
- Gestión de productos (control de inventario básico)
- Registro de citas con cliente, barbero, fecha y hora
- Sistema de facturación con:
  - Servicios
  - Productos
  - Descuento por tipo de cliente
  - Cálculo de ITBIS
- Generación de recibo en formato visual
- Selección de barbero responsable del servicio

---

## Conceptos Implementados
- Encapsulación (uso de propiedades privadas con validaciones)
- Herencia (clases derivadas de Servicio)
- Polimorfismo (uso de métodos como CalcularPrecio en diferentes servicios)
- Abstracción (uso de interfaces como IFacturable)
- Listas genéricas (List<T>)
- Programación orientada a objetos
- Manejo de eventos en Windows Forms
- Separación de responsabilidades (Modelos, Datos, UI)

---

## Estructura del Proyecto
El proyecto está organizado en las siguientes capas:

- **Modelos:** Clases principales como Cliente, Empleado, Producto, Servicio y Cita  
- **Datos:** Repositorios para manejo de información  
- **Formularios:** Interfaces gráficas (Clientes, Empleados, Productos, Citas, Facturación, Principal)  
- **Utilidades:** Validaciones y generación de reportes  

---

## Tecnologías Utilizadas
- Lenguaje: C#  
- Framework: .NET (Windows Forms)  
- IDE: Visual Studio  

---

## Instrucciones de Uso
1. Ejecutar el proyecto desde Visual Studio  
2. Utilizar el menú principal para acceder a cada módulo  
3. Registrar clientes, empleados y productos  
4. Crear citas asignando cliente y barbero  
5. Realizar facturación seleccionando servicios y productos  
6. Visualizar el total y el recibo generado 
