// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;

namespace Grasland
{
    class Program
    {
        static int Runde = 0;
        static char EckOL = '\u250f'; // Eck links oben
        static char EckOR = '\u2513'; // Eck rechts oben
        static char EckUL = '\u2517'; // Eck unten links
        static char EckUR = '\u251B'; // Eck unten rechts
        static char Horz = '\u2501'; // Horizontale Linie
        static char Vert = '\u2503'; // Vertikale Linie
        //static int Neurichtung = 0;

        static void Main()
        {
            int[,] Gras = { { 1, 0, 0, 0, 0 }, { 0, 1, 0, 0, 0 }, { 0, 0, 1, 0, 0 }, { 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 1 } };
            int[,] GrasNew = new int[5,5];
            int[,] Fauna = { { 0, 0, 0, 0, 0 }, {0, 0, 0, 0, 0 }, { 0, 0, 0, 1, 0 }, { 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0 } };
            Array.Copy(Gras, GrasNew, 25);

            Random Zufall = new Random();

            Write_Menu();
            Drawit(Gras);
            Drawit(GrasNew);
            //Drawit(Fauna);
            Gras_check(Gras);

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    if (key == ConsoleKey.N)
                    {
                        Runde++;
                        Drawit(Gras);
                        Drawit(GrasNew);
                        //Drawit(Fauna); 
                        Gras_check(Gras); // This parts checks the single gras fields.
                        //Fauna_check(Fauna); // This parts checks the single Fauna fields.
                    }
                    else if (key == ConsoleKey.C)
                    {
                        Write_Menu();
                    }
                    else if (key == ConsoleKey.Z)
                    {
                        int randomInt = Zufall.Next(1,5);
                        Console.WriteLine("ZZZ:" + randomInt);
                    }
                    else if (key == ConsoleKey.X)
                    {
                        Console.WriteLine("EXITUS!");
                        break;
                    }
                }
            } // Hauptschleife der Simulation

            static void Gras_check(int[,] Zelle) // This parts checks the single gras fields.
            {
                for (int zeile = 0; zeile < 5; zeile++)
                {
                    for (int spalte = 0; spalte < 5; spalte++)
                    {
                        int hot_value = (Zelle[zeile, spalte]);
                        hot_value++;
                        if (hot_value > 9)
                        {
                            hot_value = 9;
                        }
                        Zelle[zeile,spalte] = hot_value;
                    }
                }
            }

            static void Fauna_check(int[,] Zelle) // This parts checks the single Fauna fields.
            {
                for (int zeile = 0; zeile < 5; zeile++)
                {
                    for (int spalte = 0; spalte < 5; spalte++)
                    {
                        int fauna_value = (Zelle[zeile, spalte]);
                        if (fauna_value == 1) 
                        {   
                            Console.Write(zeile + " ");
                            Console.WriteLine(spalte);
                            //int neue_Richtung = Richtungswechsel();
                        }
                        
                        //if (hot_value > 9)
                        //{
                        //    hot_value = 9;
                        //}
                        //Zelle[zeile, spalte] = hot_value;
                    }
                }
            }

            static void Richtungswechsel() 
            {

            }

            static void Write_Menu()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------  Welcome to GRASLAND ! -----");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Press ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("C ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("for Clear Screen, ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("N ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("for Next and ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("to Exit");
            }

            static void Drawit(int[,] meineZahlen)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8; //Default Encoding

                Console.Write($"{EckOL}");
                for (int i = 0; i < 11; i++)
                {
                    Console.Write($"{Horz}");
                }
                Console.WriteLine($"{EckOR}");

                for (int zeile = 0; zeile < 5; zeile++)
                {
                    Console.Write($"{Vert}");
                    for (int spalte = 0; spalte < 5; spalte++)
                    {
                        Console.Write(" " + meineZahlen[zeile, spalte]);
                    }
                    Console.WriteLine(" " + $"{Vert}");
                }
                Console.Write($"{EckUL}");
                for (int i = 0; i < 11; i++)
                {
                    Console.Write($"{Horz}");
                }
                Console.Write($"{EckUR}");
                Console.WriteLine(" Round (" + Runde + ")");
            }
        }
    }
}