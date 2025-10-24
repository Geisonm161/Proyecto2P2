using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto2P2.Models;

namespace Proyecto2P2.Models
{
   public class ManejadorTareas
   {
       // Aquí guardamos todas las tareas en una pila (última en entrar, primera en salir)
       private Stack<Tarea> pilaTareas = new Stack<Tarea>();
      
       // Método para agregar una nueva tarea a la pila
       public void AgregarTarea()
       {
           Console.Write("Ingrese la descripción de la tarea: ");
           string descripcion = Console.ReadLine() ?? string.Empty;

           // Verificar que no esté vacía la descripción
           if (!string.IsNullOrWhiteSpace(descripcion))
           {
               pilaTareas.Push(new Tarea(descripcion));
               Console.WriteLine("✓ Tarea agregada correctamente.");
           }
           else
           {
               Console.WriteLine("✗ La descripción no puede estar vacía.");
           }
           Console.WriteLine();
       }
      
       // Método para completar la última tarea agregada
       public void CompletarTarea()
       {
           // Verificar si hay tareas en la pila
           if (pilaTareas.Count > 0)
           {
               Tarea tareaCompletada = pilaTareas.Pop();
               Console.WriteLine($"✓ Tarea completada: {tareaCompletada.Descripcion}");
           }
           else
           {
               // Si no hay tareas, mostrar mensaje y preguntar
               Console.WriteLine("✗ No hay tareas pendientes para completar.");
               Console.Write("Desea agregar una nueva tarea? (s/n): ");
               string respuesta = Console.ReadLine() ?? string.Empty;
              
               if (respuesta.ToLower() == "s" || respuesta.ToLower() == "si")
               {
                   AgregarTarea(); // Llama al método para agregar tarea
               }
               else
               {
                   Console.WriteLine("Volviendo al menú de tareas...");
               }
           }
           Console.WriteLine();
       }
      
       // Método para mostrar todas las tareas pendientes
       public void MostrarTareas()
       {
           if (pilaTareas.Count == 0)
           {
               Console.WriteLine("No hay tareas pendientes.");
               Console.Write("Desea agregar una nueva tarea? (s/n): ");
               string respuesta = Console.ReadLine() ?? string.Empty;
              
               if (respuesta.ToLower() == "s" || respuesta.ToLower() == "si")
               {
                   AgregarTarea();
               }
           }
           else
           {
               Console.WriteLine("=== TAREAS PENDIENTES (Última primero) ===");
               int numero = 1;
               // Mostrar las tareas (la última agregada primero)
               foreach (var tarea in pilaTareas.Reverse())
               {
                   Console.WriteLine($"{numero}. {tarea.Descripcion}");
                   numero++;
               }
           }
           Console.WriteLine();
       }
      
       // Menú principal de tareas
       public void EjecutarSubMenu()
       {
           bool volverAlMenuPrincipal = false;

           // Mantener el menú abierto hasta que el usuario elija salir
           while (!volverAlMenuPrincipal)
           {
               Console.WriteLine("=== GESTIÓN DE TAREAS PENDIENTES ===");
               Console.WriteLine("1. Agregar nueva tarea");
               Console.WriteLine("2. Completar última tarea");
               Console.WriteLine("3. Mostrar tareas pendientes");
               Console.WriteLine("4. Volver al menú principal");
               Console.Write("Seleccione una opción: ");
              
               string opcion = Console.ReadLine() ?? string.Empty;
              
               // Ejecutar la opción seleccionada
               switch (opcion)
               {
                   case "1":
                       AgregarTarea();
                       break;
                   case "2":
                       CompletarTarea();
                       break;
                   case "3":
                       MostrarTareas();
                       break;
                   case "4":
                       volverAlMenuPrincipal = true;
                       Console.WriteLine("Volviendo al menú principal...\n");
                       break;
                   default:
                       Console.WriteLine("Opción no válida. Intente nuevamente.\n");
                       break;
               }
           }
       }
   }
}
