using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2.Models
{
    // Representa un cliente en la cola de atención
    public class Cliente
    {
        public string Nombre { get; set; } = "";

        public Cliente(string nombre)
        {
            Nombre = nombre;
        }

        // Personaliza cómo se muestra el cliente
        public override string ToString() => $"Cliente: {Nombre}";
    }
}
