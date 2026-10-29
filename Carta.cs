using System;
using System.Collections.Generic;

public class Carta
{
    public string Nombre;
    public int CosteManaGenerico;
    public List<string> Colores;
    public string Tipo;
    public string Supertipo;
    public string TextoHabilidades;
    public string TextoSabor;
    public bool EsCriatura;
    public int Fuerza;
    public int Resistencia;
    public string[] ArteASCII;
    public void Dibujar()
    {
        ConfigurarColor();

        string emojisMana = "";
        foreach (string color in Colores)
        {
            emojisMana += color switch
            {
                "W" => "☀️",
                "U" => "💧",
                "B" => "💀",
                "R" => "🔥",
                "G" => "🌳",
            };
        }

        string lineaTipo = string.IsNullOrWhiteSpace(Supertipo) ? Tipo : $"{Supertipo} {Tipo}";
        int ancho = 36;
        string separador = new string('-', ancho);
        string relleno = new string(' ', ancho);

        Console.WriteLine($"+{separador}+");
        
        string Costes = $"{CosteManaGenerico}{emojisMana}";
        string lineaSuperior = Nombre + Costes.PadLeft(ancho - Nombre.Length);
        Console.WriteLine($"|{lineaSuperior}|");
        Console.WriteLine($"|{separador}|");
        
        foreach (string lineaArte in ArteASCII)
        {
            Console.WriteLine($"|{lineaArte.PadRight(ancho)}|"); 
        }
        Console.WriteLine($"|{separador}|");
        
        Console.WriteLine($"| {lineaTipo.PadRight(ancho - 2)} |");
        Console.WriteLine($"|{separador}|");

        foreach (string linea in PartirTexto(TextoHabilidades, ancho - 2))
        {
            Console.WriteLine($"| {linea.PadRight(ancho - 2)} |");
        }
        
        Console.WriteLine($"|{relleno}|");

        foreach (string linea in PartirTexto($"\"{TextoSabor}\"", ancho - 2))
        {
            Console.WriteLine($"| {linea.PadRight(ancho - 2)} |");
        }

        if (EsCriatura)
        {
            string stats = $"{Fuerza}/{Resistencia}";
            Console.WriteLine($"|{stats.PadLeft(ancho)}|");
        }
        else
        {
            Console.WriteLine($"|{relleno}|");
        }

        Console.WriteLine($"+{separador}+");
        Console.ResetColor();
    }

    private void ConfigurarColor()
    {
        if (Colores.Count > 1)
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
        }
        else if (Colores.Count == 1)
        {
            Console.BackgroundColor = Colores[0] switch
            {
                "R" => ConsoleColor.Red,
                "G" => ConsoleColor.Green,
                "W" => ConsoleColor.White,
                "U" => ConsoleColor.Blue,
                "B" => ConsoleColor.DarkGray,
                _   => ConsoleColor.Black
            };
        }
    }

    private List<string> PartirTexto(string texto, int limite)
    {
        if (string.IsNullOrEmpty(texto)) return new List<string>();

        string[] palabras = texto.Split(' ');
        List<string> lineas = new List<string>();
        string lineaActual = "";

        foreach (string palabra in palabras)
        {
            if ((lineaActual + " " + palabra).Trim().Length <= limite)
            {
                lineaActual = (lineaActual + " " + palabra).Trim();
            }
            else
            {
                lineas.Add(lineaActual);
                lineaActual = palabra;
            }
        }
        if (!string.IsNullOrWhiteSpace(lineaActual)) lineas.Add(lineaActual);
        
        return lineas;
    }
}