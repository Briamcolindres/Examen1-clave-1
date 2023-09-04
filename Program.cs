using System;
using System.Collections.Generic;

class Program
{
    struct Zona
    {
        public int Clave;
        public string Nombre;
        public double Precio;
    }

    static List<Zona> zonas = new List<Zona>
    {
        new Zona { Clave = 12, Nombre = "América del norte", Precio = 2 },
        new Zona { Clave = 15, Nombre = "América central", Precio = 2.2 },
        new Zona { Clave = 18, Nombre = "América del sur", Precio = 4.5 },
        new Zona { Clave = 19, Nombre = "Europa", Precio = 3.5 },
        new Zona { Clave = 23, Nombre = "Asia", Precio = 6 }
    };

    struct Libro
    {
        public int Codigo;
        public string Titulo;
        public string ISBN;
        public int Edicion;
        public string Autor;
    }

    static List<Libro> biblioteca = new List<Libro>();

    static void Main(string[] args)
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Calcular costo de llamada telefónica");
            Console.WriteLine("2. Gestionar biblioteca de libros");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CalcularCostoLlamada();
                    break;
                case 2:
                    GestionarBiblioteca();
                    break;
                case 3:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void CalcularCostoLlamada()
    {
        Console.WriteLine("Ingrese la clave de la zona:");
        int clave = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el número de minutos:");
        double minutos = double.Parse(Console.ReadLine());

        Zona zona = zonas.Find(z => z.Clave == clave);

        if (zona.Clave != 0)
        {
            double costo = zona.Precio * minutos;
            Console.WriteLine($"El costo de la llamada a {zona.Nombre} es: ${costo}");
        }
        else
        {
            Console.WriteLine("Clave de zona no válida.");
        }
    }

    static void GestionarBiblioteca()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Gestión de Biblioteca:");
            Console.WriteLine("1. Agregar un libro");
            Console.WriteLine("2. Mostrar listado de libros");
            Console.WriteLine("3. Buscar libro por código");
            Console.WriteLine("4. Editar la información de un libro");
            Console.WriteLine("5. Regresar al menú principal");
            Console.Write("Seleccione una opción: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarLibro();
                    break;
                case 2:
                    MostrarLibros();
                    break;
                case 3:
                    BuscarLibroPorCodigo();
                    break;
                case 4:
                    EditarLibroPorCodigo();
                    break;
                case 5:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void AgregarLibro()
    {
        Console.WriteLine("Ingrese el código del libro:");
        int codigo = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el título del libro:");
        string titulo = Console.ReadLine();
        Console.WriteLine("Ingrese el ISBN del libro:");
        string isbn = Console.ReadLine();
        Console.WriteLine("Ingrese la edición del libro:");
        int edicion = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el autor del libro:");
        string autor = Console.ReadLine();

        Libro libro = new Libro
        {
            Codigo = codigo,
            Titulo = titulo,
            ISBN = isbn,
            Edicion = edicion,
            Autor = autor
        };

        biblioteca.Add(libro);
        Console.WriteLine("Libro agregado exitosamente.");
    }

    static void MostrarLibros()
    {
        Console.WriteLine("Listado de Libros:");
        Console.WriteLine("Código\tTítulo\tISBN\tEdición\tAutor");
        foreach (var libro in biblioteca)
        {
            Console.WriteLine($"{libro.Codigo}\t{libro.Titulo}\t{libro.ISBN}\t{libro.Edicion}\t{libro.Autor}");
        }
    }

    static void BuscarLibroPorCodigo()
    {
        Console.WriteLine("Ingrese el código del libro a buscar:");
        int codigo = int.Parse(Console.ReadLine());

        Libro libro = biblioteca.Find(l => l.Codigo == codigo);

        if (libro.Codigo != 0)
        {
            Console.WriteLine("Información del Libro:");
            Console.WriteLine($"Código: {libro.Codigo}");
            Console.WriteLine($"Título: {libro.Titulo}");
            Console.WriteLine($"ISBN: {libro.ISBN}");
            Console.WriteLine($"Edición: {libro.Edicion}");
            Console.WriteLine($"Autor: {libro.Autor}");
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }

    static void EditarLibroPorCodigo()
    {
        Console.WriteLine("Ingrese el código del libro a editar:");
        int codigo = int.Parse(Console.ReadLine());

        Libro libro = biblioteca.Find(l => l.Codigo == codigo);

        if (libro.Codigo != 0)
        {
            Console.WriteLine("Información Actual del Libro:");
            Console.WriteLine($"Código: {libro.Codigo}");
            Console.WriteLine($"Título: {libro.Titulo}");
            Console.WriteLine($"ISBN: {libro.ISBN}");
            Console.WriteLine($"Edición: {libro.Edicion}");
            Console.WriteLine($"Autor: {libro.Autor}");

            Console.WriteLine("Ingrese la nueva información:");
            Console.WriteLine("Ingrese el título del libro:");
            libro.Titulo = Console.ReadLine();
            Console.WriteLine("Ingrese el ISBN del libro:");
            libro.ISBN = Console.ReadLine();
            Console.WriteLine("Ingrese la edición del libro:");
            libro.Edicion = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el autor del libro:");
            libro.Autor = Console.ReadLine();

            Console.WriteLine("Libro editado exitosamente.");
        }
        else
        {
            Console.WriteLine("Libro no encontrado.");
        }
    }
}




