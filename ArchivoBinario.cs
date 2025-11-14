using System;
using System.IO;
public class ArchivoBinario
{
    private Lista listaEstudiantes;
    private string nombreArchivo;
    private FileStream file;
    private BinaryReader reader;
    private BinaryWriter writer;

    public ArchivoBinario(string nombreArchivo)
    {
        this.nombreArchivo = nombreArchivo;
        file = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        listaEstudiantes = new Lista();

        // Cerrar y reabrir para lectura segura
        file.Close();

        if (File.Exists(nombreArchivo) && new FileInfo(nombreArchivo).Length > 0)
        {
            CargarDelArchivo();
        }

        // Reabrir para lectura/escritura
        file = new FileStream(nombreArchivo, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    }

    public void AgregarEstudiante(string nombre, float nota)
    {
        try
        {
            listaEstudiantes.AgregarEstudiante(nombre, nota);
            GuardarEnArchivo();
            Console.WriteLine("Estudiante agregado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al agregar estudiante: {ex.Message}");
        }
    }

    public void ModificarEstudiante(string nombre, float nuevaNota)
    {
        try
        {
            bool encontrado = false;
            Estudiante aux = listaEstudiantes.ObtenerHead();

            while (aux != null)
            {
                if (aux.Nombre.ToLower() == nombre.ToLower())
                {
                    aux.nota = nuevaNota;
                    encontrado = true;
                    break;
                }
                aux = aux.siguiente;
            }

            if (encontrado)
            {
                GuardarEnArchivo();
                Console.WriteLine("Estudiante modificado correctamente.");
            }
            else
            {
                Console.WriteLine("Estudiante no encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al modificar estudiante: {ex.Message}");
        }
    }

    public void MostrarEstudiantes()
    {
        try
        {
            listaEstudiantes.PrintEstudiantes();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al mostrar estudiantes: {ex.Message}");
        }
    }

    public void MostrarPromedioGeneral()
    {
        try
        {
            Console.WriteLine("Promedio General del Curso: ");
            listaEstudiantes.promedioGeneralCurso();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al calcular promedio: {ex.Message}");
        }
    }

    private void GuardarEnArchivo()
    {
        try
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write)))
            {
                Estudiante aux = listaEstudiantes.ObtenerHead();
                while (aux != null)
                {
                    writer.Write(aux.Nombre);
                    writer.Write(aux.nota);
                    aux = aux.siguiente;
                }
                writer.Flush();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar en archivo: {ex.Message}");
        }
    }

    private void CargarDelArchivo()
    {
        try
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    string nombre = reader.ReadString();
                    float nota = reader.ReadSingle();
                    listaEstudiantes.AgregarEstudiante(nombre, nota);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar del archivo: {ex.Message}");
        }
    }

    public void Cerrar()
    {
        file?.Close();
        file?.Dispose();
    }
}