using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      List<Carta> catalogo = new List<Carta>()
      {
         new Carta()
         {
            Nombre = "Vals Negro 3",
            CosteManaGenerico = 2,
            Colores = new List<string> { "B","R" },
            Tipo = "Criatura",
            Supertipo = "Legendaria - Hechicero",
            TextoHabilidades = "Vuela, toque mortal.\n Siempres que lances un hechizo que no sea criatura, Vals Negro 3 hace 2 puntos de daño a cada oponente.",
            TextoSabor = "¿Esos torpes muñecos, mis compañeros? ¡JA!",
            EsCriatura = true,
            Fuerza = 2,
            Resistencia = 2,
            ArteASCII = new string[]
            {
               @"          /\",
               @"         /  \",
               @"        |    |",
               @"      --:''''+--",
               @"        :'_' :",
               @"        _:  :\___",
               @"  ____.' :::     '._",
               @".*==<<=)            \   :",
               @". '   '-'-'\_      /'._.'",
               @"             \====:_ ",
               @"           .'      \\",
               @"           :       :",
               @"          /   :    \",
               @"          :   .      '.",
               @"  ,. _    :  : :      :",
               @" '-'  ).   :__:-:__.;--'",
               @"(     ' )   '-'   '-'",
               @"( - .00. - _",
               @"(  .' _ )   )",
               @"'- ()_.\,\, -"
            }
         },
      new Carta()
         {
         Nombre = "Ciclope Crepitante",
            CosteManaGenerico = 2,
            Colores = new List<string> { "R" },
            Tipo = "Criatura",
            Supertipo = "Hechicero ciclope",
            TextoHabilidades = "Siempre que lances un hechizo que no sea criatura, esta criatura obtiene +3/+0 hasta el final del turno.",
            TextoSabor = "Para compensar la falta de profundidad de su vision, viene cargado con potencial de sobra.",
            EsCriatura = true,
            Fuerza = 0,
            Resistencia = 4,
            ArteASCII = new string[]
            {
               @"          \   |   /",
               @"           .-'''-.",
               @"        --/  ___  \--",
               @"          | / ()\ |",
               @"        --\ '---' /--",
               @"           '-...-'",
               @"          /   |   \",
               @"         /    |    \"
            }
         },
      new Carta()
         {
            Nombre = "Piromante Viashiano",
            CosteManaGenerico = 1,
            Colores = new List<string> { "R" },
            Tipo = "Criatura",
            Supertipo = "Hechicero viashiano",
            TextoHabilidades = "Cuando el Piromante viashiano entre al campo de batalla, hace 2 puntos de daño al jugador o planeswalker objetivo.",
            TextoSabor = "Me entrenaron los ghitu. Respeto el fuego tanto como ellos.",
            EsCriatura = true,
            Fuerza = 2,
            Resistencia = 1,
            ArteASCII = new string[]
            {
               @"            ^    ^",
               @"           / \  / \",
               @"          /   \/   \",
               @"         (  O    O  )",
               @"          \   \/   /",
               @"          /  -==-  \",
               @"         (   /  \   )",
               @"          \__\__/__/"
            }
         },
         new Carta()
         {
            Nombre = "Espiral de Lava",
            CosteManaGenerico = 1,
            Colores = new List<string> { "R" },
            Tipo = "Conjuro",
            Supertipo = "",
            TextoHabilidades = "La espiral de lava hace 4 puntos de daño a la criatura objetivo. Si esa criatura fuese a morir este turno, en vez de eso, exiliala",
            TextoSabor = "Comandante, descubrimos a la espía dimir y pusimos bajo custodia sus cenizas.\nKramm, guarda de seguridad wojek",
            EsCriatura = false,
            Fuerza = 0,
            Resistencia = 0,
            ArteASCII = new string[]
            {
               @"           .-''''-.",
               @"         .'  _...  '.",
               @"        /  .'    '.  \",
               @"       |  /  .--.  \  |",
               @"       | |  |    |  | |",
               @"       |  \  '--'  /  |",
               @"        \  '....-'   /",
               @"         '.        .'",
               @"           '-....-'"
            }
         },
         new Carta()
         {
            Nombre = "Último Suspiro",
            CosteManaGenerico = 1,
            Colores = new List<string> { "B" },
            Tipo = "Instantaneo",
            Supertipo = "",
            TextoHabilidades = "La criatura objetivo obtiene -3/-3 hasta el final del turno.",
            TextoSabor = "Dame un momento para recuperar tu aliento.",
            EsCriatura = false,
            Fuerza = 0,
            Resistencia = 0,
            ArteASCII = new string[]
            {
               @"            .---.",
               @"          /       \",
               @"         |  O   O  |",
               @"         |    ^    |",
               @"          \ '|||' /",
               @"           '-----'",
               @"          ~ ~ ~ ~ ~",
               @"         ~  ~   ~  ~"
            }
         }
      };

      Console.WriteLine("Bienvenido a la Calculadora de Combate MTG");
      Console.WriteLine("Catálogo de cartas disponibles:");
        
      for (int i = 0; i < catalogo.Count; i++)
      {
         Console.WriteLine($"{i + 1}. {catalogo[i].Nombre} ({catalogo[i].Tipo}) ({catalogo[i].Fuerza}) ({catalogo[i].Resistencia}) ");
      }

      bool combateExitoso = false;

      while (!combateExitoso)
      {
         Console.Write("\nElige el número de la primera criatura: ");
         int eleccion1 = int.Parse(Console.ReadLine()) - 1;

         Console.Write("Elige el número de la segunda criatura: ");
         int eleccion2 = int.Parse(Console.ReadLine()) - 1;

         Carta criatura1 = catalogo[eleccion1];
         Carta criatura2 = catalogo[eleccion2];

         if (!criatura1.EsCriatura || !criatura2.EsCriatura)
         {
            combateExitoso = SistemaDeCombate.Enfrentar(criatura1, criatura2);
            continue; 
         }

         Console.Write("\n¿Deseas lanzar un hechizo (Instantáneo/Conjuro) de tu mano antes del combate? (s/n): ");
         if (Console.ReadLine().ToLower() == "s")
         {
            Console.Write("Digita el número del hechizo del catálogo: ");
            int eleccionHechizo = int.Parse(Console.ReadLine()) - 1;
            Carta hechizo = catalogo[eleccionHechizo];

            if (hechizo.EsCriatura)
            {
               Console.WriteLine("\n[AVISO] Elegiste una criatura. Los hechizos deben ser Instantáneos o Conjuros. Saltando a la fase de combate...");
            }

            else
            {
               Console.Write($"\nHas lanzado {hechizo.Nombre}. ¿A cuál criatura se lo aplicas? (1 para {criatura1.Nombre}, 2 para {criatura2.Nombre}): ");
               int objetivo = int.Parse(Console.ReadLine());
                    
               Carta objetivoCarta = (objetivo == 1) ? criatura1 : criatura2;

               switch (hechizo.Nombre)
               {
                  case "Crecimiento Gigante":
                     objetivoCarta.Fuerza += 3;
                     objetivoCarta.Resistencia += 3;
                     Console.WriteLine($"\n¡{objetivoCarta.Nombre} obtiene +3/+3 y se vuelve gigantesco!");
                     break;
                  case "Último Suspiro":
                     objetivoCarta.Fuerza -= 3;
                     objetivoCarta.Resistencia -= 3;
                     Console.WriteLine($"\n¡{objetivoCarta.Nombre} sufre -3/-3 perdiendo su aliento!");
                     break;
                  case "Espiral de Lava":
                     objetivoCarta.Resistencia -= 4;
                     Console.WriteLine($"\n¡{objetivoCarta.Nombre} recibe 4 puntos de daño letal por la espiral!");
                     break;
                    }
                }
            }
         combateExitoso = SistemaDeCombate.Enfrentar(criatura1, criatura2);
        }
    }
}