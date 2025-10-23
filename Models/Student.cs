namespace Proyecto2.Models
{
  // Clase que representa a un estudiante con sus datos básicos
  public class Student
  {
    // Propiedad que almacena un identificador único para cada estudiante
    public int Id { get; set; }

    // Propiedad que guarda el nombre del estudiante
    // Se inicializa con una cadena vacía para evitar advertencias de valores nulos (CS8618)
    public string Name { get; set; } = "";

    // Propiedad que almacena la calificación del estudiante (rango sugerido: 0 a 100)
    public double Calification { get; set; }

    // Sobrescribe el método ToString para mostrar los datos del estudiante en formato legible
    public override string ToString() => $"[{Id}] {Name} — {Calification}";
  }
}
