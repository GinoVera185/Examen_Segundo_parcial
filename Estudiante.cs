public class Estudiante
{
    public string Nombre;
    public float nota;

    public Estudiante siguiente;

    public Estudiante()
    {
        Nombre = "";
        nota = 0;
        siguiente = null;
    }

    public Estudiante(string nom, float not)
    {
        Nombre = nom;
        nota = not;
        siguiente = null;
    }

}