using System;

public class SistemaDeCombate
{
    public static bool Enfrentar(Carta c1, Carta c2)
    {
        if (!c1.EsCriatura || !c2.EsCriatura)
        {
            Console.WriteLine("\nAmbas cartas deben ser criaturas para iniciar el combate. Intenta de nuevo.");
            return false;
        }

        c1.Dibujar();
        Console.WriteLine("\n                     VS\n");
        c2.Dibujar();

        Console.WriteLine("\n--- INICIO DEL COMBATE ---");

        if (c1.Resistencia <= 0 || c2.Resistencia <= 0)
        {
            Console.WriteLine("¡El combate termina prematuramente porque una criatura fue destruida por un hechizo!");
            MostrarResultado(c1, c1.Resistencia);
            MostrarResultado(c2, c2.Resistencia);
            return true; 
        }

        int dañoC1 = Math.Max(0, c1.Fuerza);
        int dañoC2 = Math.Max(0, c2.Fuerza);

        if (dañoC1 == 0 && dañoC2 == 0)
        {
            Console.WriteLine("Ambas criaturas tienen 0 (o menos) de Fuerza. Ninguna puede hacerse daño. Es un empate pacífico.");
            return true;
        }

        int vidaC1 = c1.Resistencia;
        int vidaC2 = c2.Resistencia;
        int ronda = 1;

        while (vidaC1 > 0 && vidaC2 > 0)
        {
            Console.WriteLine($"\n[ Ronda {ronda} ]");
            
            vidaC1 -= dañoC2;
            vidaC2 -= dañoC1;

            MostrarResultado(c1, vidaC1);
            MostrarResultado(c2, vidaC2);
            
            ronda++;
        }

        return true; 
    }

    private static void MostrarResultado(Carta carta, int resistenciaRestante)
    {
        Console.Write($"{carta.Nombre} recibe daño. Vida restante: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(resistenciaRestante);
        Console.ResetColor();

        if (resistenciaRestante <= 0)
        {
            Console.Write(" ☠️ (Destruida)");
        }
        Console.WriteLine();
    }
}