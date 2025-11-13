public class Menu
{
    private Lista listaEstudiantes = new Lista();
    public void MenuOpciones()
    {
        Console.WriteLine("1. Agregar Estudiante");
        Console.WriteLine("2. Mostrar Estudiantes del Curso");
        Console.WriteLine("3. Salir");
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
                Console.Clear();
                Console.Write("Ingrese el nombre del estudiante: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese la nota del estudiante: ");
                float nota = float.Parse(Console.ReadLine());
                listaEstudiantes.AgregarEstudiante(nombre, nota);
                Console.ReadKey();
                MostrarMenu();
                break;
            case 2:
                Console.Clear();
                listaEstudiantes.PrintEstudiantes();
                listaEstudiantes.promedioGeneralCurso();
                Console.ReadKey();
                MostrarMenu();
                break;
            case 3:
                Console.WriteLine("Saliendo del programa...");
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