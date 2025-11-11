public class Lista
{
    private Estudiante head;

    public Lista()
    {
        head = null;
    }

    public Lista(string nombre, float nota)
    {
        head = new Estudiante(nombre, nota);
    }

    public void AgregarEstudiante(string nombre, float nota)
    {
        Estudiante estudiante = new Estudiante(nombre, nota);
        head = estudiante;
        if (head == null)
        {
            head = estudiante;
        }
        else
        {
            Estudiante aux = head;
            while (aux.siguiente != null)
            {
                aux = aux.siguiente;
            }
            aux.siguiente = estudiante;
        }
    }

    public void promedioGeneralCurso()
    {
        Estudiante aux = head;
        float sumaNotas = 0;
        int contador = 0;

        while (aux != null)
        {
            sumaNotas += aux.nota;
            contador++;
            aux = aux.siguiente;
        }

        if (contador > 0)
        {
            float promedio = sumaNotas / contador;
            Console.WriteLine($"El promedio general del curso es: {promedio}");
        }
        else
        {
            Console.WriteLine("No hay estudiantes en la lista.");
        }
    }

    public void PrintEstudiantes()
    {
        Estudiante aux = head;
        Console.WriteLine("Lista de Estudiantes:");
        while (aux != null)
        {
            Console.WriteLine($"Nombre: {aux.Nombre}, Nota: {aux.nota}");
            aux = aux.siguiente;
        }
    }


}