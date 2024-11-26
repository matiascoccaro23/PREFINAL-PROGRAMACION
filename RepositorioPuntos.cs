using System.Collections.Generic;
using System.Linq;

public class RepositorioPuntos
{
    private List<Punto3D> puntos;

    public RepositorioPuntos()
    {
        puntos = new List<Punto3D>();
    }

    public int Cantidad => puntos.Count;

    public void AgregarPunto(Punto3D punto)
    {
        if (!puntos.Any(p => p.X == punto.X && p.Y == punto.Y && p.Z == punto.Z))
        {
            puntos.Add(punto);
        }
    }

    public void EliminarPunto(Punto3D punto)
    {
        puntos.Remove(punto);
    }

    public void EditarPunto(Punto3D puntoAntiguo, Punto3D puntoNuevo)
    {
        var index = puntos.IndexOf(puntoAntiguo);
        if (index != -1)
        {
            puntos[index] = puntoNuevo;
        }
    }

    public List<Punto3D> ObtenerPuntos()
    {
        return puntos;
    }

    public List<Punto3D> OrdenarPorDistancia(bool ascendente = true)
    {
        return ascendente
            ? puntos.OrderBy(p => p.DistanciaAlOrigen()).ToList()
            : puntos.OrderByDescending(p => p.DistanciaAlOrigen()).ToList();
    }

    public List<Punto3D> FiltrarPorColor(string color)
    {
        return puntos.Where(p => p.Color.Equals(color)).ToList();
    }

    public void GuardarEnArchivo(string rutaArchivo)
    {
        using (var writer = new System.IO.StreamWriter(rutaArchivo))
        {
            foreach (var punto in puntos)
            {
                writer.WriteLine($"{punto.X},{punto.Y},{punto.Z},{punto.Color}");
            }
        }
    }

    public void CargarDesdeArchivo(string rutaArchivo)
    {
        if (System.IO.File.Exists(rutaArchivo))
        {
            using (var reader = new System.IO.StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    var partes = linea.Split(',');
                    int x = int.Parse(partes[0]);
                    int y = int.Parse(partes[1]);
                    int z = int.Parse(partes[2]);
                    string color = partes[3];
                    AgregarPunto(new Punto3D(x, y, z, color));
                }
            }
        }
    }
}
