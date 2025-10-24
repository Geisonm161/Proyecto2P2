namespace Proyecto2P2.Models
{
   // Clase que representa una tarea pendiente con su descripción
   public class Tarea
   {
       // Propiedad que guarda la descripción de la tarea
       // Se inicializa con una cadena vacía para evitar advertencias de valores nulos
       public string Descripcion { get; set; } = "";
      
     
       public Tarea(string descripcion)  // inicializa una nueva tarea con su descripción
       {
           Descripcion = descripcion;
       }
      
       //Modifica la forma en que aparece la tarea al mostrarla
       public override string ToString() => $"Tarea: {Descripcion}";
   }
}