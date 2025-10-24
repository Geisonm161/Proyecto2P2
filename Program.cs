using System;
using System.Runtime.CompilerServices;
using Proyecto2.Models;

namespace Proyecto2
{
  // Clase principal del programa
  internal class Program
  {
    // Instancia global del manejador de estudiantes (permite agregar, listar y eliminar)
    static ClassStudent managerStudent = new ClassStudent();

    static void Main()
    {
      bool nextBucle = false; // Controla si el menú principal continúa o se cierra

      // Bucle principal del programa
      while (!nextBucle)
      {
        // Muestra el menú principal con las opciones
        Console.Clear();
        Console.WriteLine("<================ Segundo Proyecto ================>");
        Console.WriteLine("1. Estudiantes");
        Console.WriteLine("2. Clientes");
        Console.WriteLine("3. Tareas");
        Console.WriteLine("4. Salir");
        Console.Write("Digite seleccion aqui => ");
        string? option = Console.ReadLine(); // Captura la opción escrita por el usuario

        // Ejecuta la acción correspondiente según la opción elegida
        switch (option)
        {
          case "1":
            Students(); // Submenú de estudiantes
            break;

          case "2":
                        Console.Clear();
                        var manejadorClientes = new Proyecto2P2.Models.ManejadorClientes();
                        manejadorClientes.EjecutarSubMenu();
                        break;


          case "3":
             var manejadorTareas = new Proyecto2P2.Models.ManejadorTareas();
             manejadorTareas.EjecutarSubMenu();
            break;

          case "4":
            nextBucle = true; // Sale del bucle principal y finaliza el programa
            break;

          default:
            // Opción no válida
            Console.WriteLine("Seleccion Invalida. Para volver al menu Presione Enter...");
            Console.ReadLine();
            break;
        }
      }
    }

    // Submenú que gestiona las operaciones relacionadas con estudiantes
    static void Students()
    {
      Console.Clear();

      bool nextBucle = true; // Controla la salida del submenú

      while (nextBucle)
      {
        Console.Clear();
        Console.WriteLine("<==== Menú de Estudiantes ====>");
        Console.WriteLine("1. Agregar estudiante");
        Console.WriteLine("2. Eliminar estudiante");
        Console.WriteLine("3. Listar estudiantes");
        Console.WriteLine("4. Volver");
        Console.Write("Digite seleccion aqui => ");

        string? option = Console.ReadLine(); // Lee la opción del usuario dentro del submenú

        switch (option)
        {
          case "1":
            AddStudent(); // Agregar un nuevo estudiante
            break;
          case "2":
            RemoveStudent(); // Eliminar un estudiante por nombre
            break;
          case "3":
            ListStudents(); // Mostrar lista completa de estudiantes
            break;
          case "4":
            nextBucle = false; // Salir del submenú y volver al menú principal
            break;
          default:
            Console.WriteLine("Selección inválida. Presiona Enter para continuar...");
            Console.ReadLine();
            break;
        }
      }
    }

    // Método para agregar un nuevo estudiante
    static void AddStudent()
    {
      string? name = ""; // Variable para almacenar el nombre

      while (true)
      {
        Console.Clear();

        // Verifica que el nombre no esté vacío
        if (string.IsNullOrEmpty(name))
        {

          Console.Write("Ingresar Nombre de estudiante aqui => ");

          name = Console.ReadLine();

          bool exists = managerStudent.All().Find(item => item.Name.ToLower() == name.ToLower()) != null;

          if (exists)
          {
            name = "";
            Console.WriteLine();
            Console.WriteLine("Este usuario ya existe. Para continuar presione Enter");
            Console.ReadLine();
            continue;
          }
          Console.WriteLine();

          if (string.IsNullOrEmpty(name))
          {
            // Si el usuario no escribe nada, muestra mensaje de error
            Console.WriteLine("Ingreso de Nombre es Obligatorio!!!");
            Console.WriteLine();
            Console.WriteLine("Para continuar presione Enter...");
            Console.ReadLine();
          }

          continue; // Repite el bucle si no hay nombre válido
        }

        // Solicita la calificación del estudiante
        Console.Write("Ingresar Calificacion de estudiante aqui => ");

        // Intenta convertir el texto ingresado en un número (double)
        if (double.TryParse(Console.ReadLine(), out double calification))
        {
          // Si la conversión es válida, agrega el estudiante
          managerStudent.Add(name, calification);

          Console.WriteLine();
          Console.WriteLine("Estudiante agregado de manera exitosa. Para continuar presione Enter...");
          Console.ReadLine();
        }
        else
        {
          // Si no se pudo convertir, muestra mensaje de error
          Console.WriteLine("Ingreso de Calificacion es Obligatorio. Asegurese de agregar un valor valido!!!!");
          Console.WriteLine();
          Console.WriteLine("Para continuar presione Enter...");
          Console.ReadLine();
          continue;
        }

        break; // Sale del bucle cuando se agrega correctamente
      }
    }

    // Método para eliminar un estudiante por nombre
    static void RemoveStudent()
    {
      while (true)
      {
        Console.Clear();

        // Muestra todos los estudiantes actuales antes de eliminar
        PrintStudents("Lista de Estudiantes", managerStudent.All());

        Console.Write("Coloque el nombre del estudiante que desea eliminar aqui => ");
        string? nameStudent = Console.ReadLine();

        if (!string.IsNullOrEmpty(nameStudent))
        {
          // Intenta eliminar el estudiante
          if (managerStudent.Remove(nameStudent))
          {

            Console.WriteLine();

            Console.WriteLine("Estudiante eliminado de manera exitosa. Para continuar presione Enter...");

            Console.ReadLine();

            break; // Sale si se elimina correctamente
          }

          // Si no se encontró el estudiante
          Console.WriteLine();

          Console.WriteLine("Fallo la eliminacion del estudiante. El nombre digitado no se encontro en la lista");

          Console.WriteLine("Para volver a intentarlo presione Enter...");

          Console.ReadLine();

          continue;
        }

        // Si el nombre digitado es inválido
        Console.WriteLine("Nombre digitado es invalido. Para volver a intentarlo presione Enter...");
        Console.ReadLine();
      }
    }

    // Método que muestra la lista de estudiantes actuales
    static void ListStudents()
    {
      Console.Clear();

      // Muestra los estudiantes registrados
      PrintStudents("Lista de Estudiantes", managerStudent.All());

      // Si la lista está vacía, muestra un mensaje
      if (managerStudent.All().Count == 0)
      {
        Console.WriteLine("La lista de estudiantes esta Vacia...");
      }

      Console.WriteLine();
      Console.WriteLine("Para continuar presione Enter...");
      Console.ReadLine();
    }

    // Método auxiliar para imprimir una lista de estudiantes con un título
    static void PrintStudents(string title, List<Student> list)
    {
      Console.WriteLine($"\n== {title} ==");
      Console.WriteLine();

      // Recorre la lista e imprime cada estudiante usando su método ToString()
      foreach (var item in list)
        Console.WriteLine(item);

      Console.WriteLine();
    }
  }
}
