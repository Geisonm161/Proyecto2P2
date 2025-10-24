using Proyecto2.Models;
using Proyecto2P2.Models;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto2P2.Models
{
    public class ManejadorClientes
    {
        // Cola para manejar los clientes (primero en entrar, primero en salir)
        private Queue<Cliente> colaClientes = new Queue<Cliente>();

        // Agrega un cliente a la cola
        public void AgregarCliente()
        {
            Console.Write("Ingrese el nombre del cliente: ");
            string nombre = Console.ReadLine() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                colaClientes.Enqueue(new Cliente(nombre));
                Console.WriteLine($"✓ Cliente '{nombre}' agregado a la cola.");
            }
            else
            {
                Console.WriteLine("✗ El nombre no puede estar vacío.");
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        // Atiende (o elimina) al primer cliente en la cola
        public void AtenderCliente()
        {
            if (colaClientes.Count > 0)
            {
                Cliente clienteAtendido = colaClientes.Dequeue();
                Console.WriteLine($"Atendiendo al cliente: {clienteAtendido.Nombre}");
            }
            else
            {
                Console.WriteLine("✗ No hay clientes en la cola.");
                Console.Write("¿Desea agregar un nuevo cliente? (s/n): ");
                string respuesta = Console.ReadLine() ?? string.Empty;

                if (respuesta.ToLower() == "s" || respuesta.ToLower() == "si")
                {
                    AgregarCliente();
                }
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }

        // Muestra la lista completa de clientes en espera
        public void MostrarClientes()
        {
            Console.Clear();
            if (colaClientes.Count == 0)
            {
                Console.WriteLine("No hay clientes en espera.");
                Console.Write("¿Desea agregar un nuevo cliente? (s/n): ");
                string respuesta = Console.ReadLine() ?? string.Empty;

                if (respuesta.ToLower() == "s" || respuesta.ToLower() == "si")
                {
                    AgregarCliente();
                }
            }
            else
            {
                Console.WriteLine("=== CLIENTES EN ESPERA (Primero en la fila primero) ===");
                int posicion = 1;
                foreach (var cliente in colaClientes)
                {
                    Console.WriteLine($"{posicion}. {cliente.Nombre}");
                    posicion++;
                }
            }

            Console.WriteLine("\nPresione Enter para continuar...");
            Console.ReadLine();
        }

        // Submenú principal de la cola de clientes
        public void EjecutarSubMenu()
        {
            bool volver = false;

            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== GESTIÓN DE COLA DE CLIENTES ===");
                Console.WriteLine("1. Agregar cliente a la cola");
                Console.WriteLine("2. Atender cliente");
                Console.WriteLine("3. Mostrar cola de clientes");
                Console.WriteLine("4. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine() ?? string.Empty;

                switch (opcion)
                {
                    case "1":
                        AgregarCliente();
                        break;
                    case "2":
                        AtenderCliente();
                        break;
                    case "3":
                        MostrarClientes();
                        break;
                    case "4":
                        volver = true;
                        Console.WriteLine("Volviendo al menú principal...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}

