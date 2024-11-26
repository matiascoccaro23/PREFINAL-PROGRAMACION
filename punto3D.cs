using System;

public class Punto3D
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public string Color { get; set; }

    public Punto3D(int x, int y, int z, string color)
    {
        X = x;
        Y = y;
        Z = z;
        Color = color;
    }

    public double DistanciaAlOrigen()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public override string ToString()
    {
        return $"Punto3D(X: {X}, Y: {Y}, Z: {Z}, Color: {Color})";
    }
}
