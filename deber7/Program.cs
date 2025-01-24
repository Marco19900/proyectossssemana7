using System;

class Vehiculo
{
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Anio { get; set; }
    public decimal Precio { get; set; }
    public Vehiculo Siguiente { get; set; }

    public Vehiculo(string placa, string marca, string modelo, int anio, decimal precio)
    {
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Anio = anio;
        Precio = precio;
        Siguiente = null;
    }
}

class ListaVehiculos
{
    private Vehiculo cabeza;

    public void AgregarVehiculo(string placa, string marca, string modelo, int anio, decimal precio)
    {
        Vehiculo nuevo = new Vehiculo(placa, marca, modelo, anio, precio);
        if (cabeza == null)
        {
            cabeza = nuevo;
        }
        else
        {
            Vehiculo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevo;
        }
        Console.WriteLine("Vehículo agregado exitosamente.");
    }

    public void BuscarVehiculoPorPlaca(string placa)
    {
        Vehiculo actual = cabeza;
        while (actual != null)
        {
            if (actual.Placa == placa)
            {
                Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Anio}, Precio: {actual.Precio}");
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine("Vehículo no encontrado.");
    }

    public void VerVehiculosPorAnio(int anio)
    {
        Vehiculo actual = cabeza;
        bool encontrado = false;
        while (actual != null)
        {
            if (actual.Anio == anio)
            {
                Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Anio}, Precio: {actual.Precio}");
                encontrado = true;
            }
            actual = actual.Siguiente;
        }
        if (!encontrado)
        {
            Console.WriteLine("No se encontraron vehículos para el año especificado.");
        }
    }

    public void VerTodosLosVehiculos()
    {
        Vehiculo actual = cabeza;
        if (actual == null)
        {
            Console.WriteLine("No hay vehículos registrados.");
            return;
        }
        while (actual != null)
        {
            Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Anio}, Precio: {actual.Precio}");
            actual = actual.Siguiente;
        }
    }

    public void EliminarVehiculo(string placa)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        if (cabeza.Placa == placa)
        {
            cabeza = cabeza.Siguiente;
            Console.WriteLine("Vehículo eliminado exitosamente.");
            return;
        }

        Vehiculo actual = cabeza;
        while (actual.Siguiente != null && actual.Siguiente.Placa != placa)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente == null)
        {
            Console.WriteLine("Vehículo no encontrado.");
        }
        else
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            Console.WriteLine("Vehículo eliminado exitosamente.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaVehiculos lista = new ListaVehiculos();
        int opcion;

        do
        {
            Console.WriteLine("\nMenú de opciones:");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar vehículo por placa");
            Console.WriteLine("3. Ver vehículos por año");
            Console.WriteLine("4. Ver todos los vehículos registrados");
            Console.WriteLine("5. Eliminar vehículo registrado");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la placa: ");
                    string placa = Console.ReadLine();
                    Console.Write("Ingrese la marca: ");
                    string marca = Console.ReadLine();
                    Console.Write("Ingrese el modelo: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Ingrese el año: ");
                    int anio = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el precio: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    lista.AgregarVehiculo(placa, marca, modelo, anio, precio);
                    break;
                case 2:
                    Console.Write("Ingrese la placa del vehículo a buscar: ");
                    placa = Console.ReadLine();
                    lista.BuscarVehiculoPorPlaca(placa);
                    break;
                case 3:
                    Console.Write("Ingrese el año de los vehículos a buscar: ");
                    anio = int.Parse(Console.ReadLine());
                    lista.VerVehiculosPorAnio(anio);
                    break;
                case 4:
                    lista.VerTodosLosVehiculos();
                    break;
                case 5:
                    Console.Write("Ingrese la placa del vehículo a eliminar: ");
                    placa = Console.ReadLine();
                    lista.EliminarVehiculo(placa);
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }
}
