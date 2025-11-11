public class Menu
{
    public void MostrarMenu()
    {
        Lista listaEstudiantes = new Lista();
        int opcion = 0;

        do
        {
            Console.Clear();
            Console.WriteLine("Menu de Opciones:");
            Console.WriteLine("1. Agregar Estudiante");
            Console.WriteLine("2. Mostrar Estudiantes del Curso");
            Console.WriteLine("3. Salir");
            opcion = Numero.getNumero("Seleccione una opción: ");

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el nombre del estudiante: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese la nota del estudiante: ");
                    float nota = float.Parse(Console.ReadLine());
                    listaEstudiantes.AgregarEstudiante(nombre, nota);
                    break;
                case 2:
                    listaEstudiantes.PrintEstudiantes();
                    listaEstudiantes.promedioGeneralCurso();
                    break;
                case 3:
                    Console.WriteLine("Saliendo del programa...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opcion no valida. Intente de nuevo.");
                    break;
            }

        } while (opcion != 3);
    }
}