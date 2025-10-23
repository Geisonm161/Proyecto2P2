using System;
using System.Collections.Generic;

namespace Proyecto2.Models
{
  // Clase que gestiona una lista de estudiantes
  class ClassStudent
  {
    // Lista privada donde se almacenan los objetos Student
    private readonly List<Student> students = new();

    // Campo privado para generar un Id autoincremental
    private int _nextId = 1;

    // Método para agregar un nuevo estudiante
    public Student Add(string name, double calification)
    {
      // Crea un nuevo objeto Student con un Id único, nombre y calificación
      var item = new Student { Id = _nextId++, Name = name, Calification = calification };

      // Agrega el nuevo estudiante a la lista
      students.Add(item);

      // Retorna el objeto agregado (por si se necesita mostrar o usar luego)
      return item;
    }

    // Método para obtener todos los estudiantes registrados
    public List<Student> All() => new List<Student>(students);

    // Método para eliminar uno o varios estudiantes por nombre
    public bool Remove(string nameStudent)
    {
      // Busca todos los estudiantes cuyo nombre coincida (ignorando mayúsculas/minúsculas)
      List<Student> item = students.FindAll(itemDetail =>
           itemDetail.Name != null &&
           itemDetail.Name.ToLower() == nameStudent.ToLower()
         );

      // Si no se encontró ningún estudiante con ese nombre, retorna false
      if (item.Count == 0) return false;

      // Recorre la lista de coincidencias y elimina cada estudiante
      foreach (var itemDetail in item)
      {
        students.Remove(itemDetail);
      }

      // Retorna true indicando que se eliminaron elementos
      return true;
    }
  }
}
