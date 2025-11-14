using System;

public class Menu
{
    private ArchivoBinario archivoBinario = new ArchivoBinario("Estudiante.dat");

    public void MenuOpciones()
    {
        Console.WriteLine("1. Agregar Estudiante");
        Console.WriteLine("2. Modificar Estudiante");
        Console.WriteLine("3. Mostrar Archivo de Estudiantes");
        Console.WriteLine("4. Mostrar Promedio General del Curso");
        Console.WriteLine("5. Salir");
    }

    public void MostrarMenu()
    {
        int opcion = 0;

        Console.Clear();
        MenuOpciones();
        opcion = Numero.getNumero("Seleccione una opción: ");

        switch (opcion)
        {
            case 1:
                bool Continuar = true;

                while (Continuar == true)
                {
                    Console.Clear();
                    Console.Write("Ingrese el nombre del estudiante: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la nota del estudiante: ");
                    float nota = float.Parse(Console.ReadLine());
                    archivoBinario.AgregarEstudiante(nombre, nota);

                    Console.Write("Desea seguir agregando datos? (s/n): ");
                    string respuesta = Console.ReadKey(true).KeyChar.ToString().ToLower();

                    if (respuesta != "s")
                    {
                        Continuar = false;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                MostrarMenu();
                break;

            case 2:
                Console.Clear();
                Console.Write("Ingrese el nombre del estudiante a modificar: ");
                string nombreModificar = Console.ReadLine();
                Console.Write("Ingrese la nueva nota: ");
                float nuevaNota = float.Parse(Console.ReadLine());
                archivoBinario.ModificarEstudiante(nombreModificar, nuevaNota);
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                MostrarMenu();
                break;

            case 3:
                Console.Clear();
                archivoBinario.MostrarEstudiantes();
                Console.WriteLine("Presione cualquier boton para continuar...");
                Console.ReadKey();
                MostrarMenu();
                break;

            case 4:
                Console.Clear();
                archivoBinario.MostrarPromedioGeneral();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                MostrarMenu();
                break;

            case 5:
                Console.WriteLine("Saliendo del programa...");
                archivoBinario.Cerrar();
                Environment.Exit(0);
                break;

            default:
                Console.WriteLine("Opcion no valida. Intente de nuevo.");
                Console.ReadKey();
                MostrarMenu();
                break;
        }
    }
}