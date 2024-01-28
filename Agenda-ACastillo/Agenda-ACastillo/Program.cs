
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Agenda_ACastillo
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcioS = ""; int numero1, numero2, aux;
            while (opcioS != "Q" && opcioS != "q")
            {
                Agenda();
                Console.Write("Quina opció vols escollir? ");
                opcioS = Console.ReadLine();
                if (opcioS == "Q" || opcioS == "q")
                {
                    BorrarConsola();
                    Console.WriteLine("Adeu!");
                }
                else if (!ValidarOpcio(opcioS))
                {
                    Console.WriteLine("No has escollit una opció de les possibles.");
                    retorn();
                    BorrarConsola();
                }
                else
                {
                    aux = Convert.ToInt32(opcioS);
                    switch(aux)
                    {
                        //Veure llistat de persones de l'agenda
                        case 1:
                            BorrarConsola();
                            Capcalera1();
                            //Afegir el codi a partir d'aqui, no borrar retorn
                            retorn();
                            BorrarConsola();
                            break;
                        //Afegir contactes a l'agenda
                        case 2:
                            Capcalera2();
                            //Afegir el codi a partir d'aqui, no borrar retorn
                            retorn();
                            BorrarConsola();
                            break;
                        //Esborrar contactes
                        case 3:
                            Capcalera3();
                            //Afegir el codi a partir d'aqui, no borrar retorn
                            retorn();
                            BorrarConsola();
                            break;
                        //Llistat de contactes esborrats
                        case 4:
                            Capcalera4();
                            //Afegir el codi a partir d'aqui, no borrar retorn
                            OrdenarFitxer();
                            retorn();
                            BorrarConsola();
                            break;
                        default:
                            Console.WriteLine("");
                            break;
                    }
                }
            }
        }
        static void Agenda()
        {
            ConsolaFons();
            Capcalera();
            MenuText();
            return;
        }
        static bool ValidarOpcio(string opcioS) // Aquest validara si la opció que hem escollit esta entre els valors possibles.
        {
            int opcioN = 0;
            bool validacio = false;
            if ("4321".Contains(opcioS))
            {
                opcioN = Convert.ToInt32(opcioS);
                validacio = true;
                if (opcioN > 4 || opcioN < 1)
                {
                    validacio = false;
                }
            }
            else
            {
                validacio = false;
            }
            return validacio;
        }
        static void retorn()
        {
            int contador = 5;
            while (contador >= 0) 
            {
                Console.Write("\r");
                Console.Write($"Tornant al menù principal en {contador} segons...");
                Thread.Sleep(1000);
                contador--;
            }
            return;
        }
        static void BorrarConsola() // Aquest borrara la consola jo vulgui tornant d'aquesta manera al principi
        {
            Console.Clear();
            return;
        }
        static string MenuText() // Aquest es el menu en text
        {
            string text;
            text = "╔═══════════════════════════════════════════════════════╗\n" +
                   "║                        OPCIONS                        ║\n" +
                   "╠═══════════════════════════════════════════════════════╣\n" +
                   "║                                                       ║\n" +
                   "║                  1 - VEURE LLISTAT                    ║\n" +
                   "║                  2 - AFEGIR CONTACTES                 ║\n" +
                   "║                  3 - ESBORRAR CONTACTES               ║\n" +
                   "║                  4 - LLISTAT DE CONTACTES ESBORRADES  ║\n" +
                   "║                  Q - SORTIR                           ║\n" +
                   "║                                                       ║\n" +
                   "╚═══════════════════════════════════════════════════════╝";            
            Console.WriteLine(text);

            return text;
        }
        static void Capcalera()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    AGENDA DE CONTACTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void Capcalera1()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    LLISTA DE CONTACTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void Capcalera2()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    AFEGIR CONTACTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void Capcalera3()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    ESBORRAR CONTACTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void Capcalera4()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    LLISTA DE CONTACTES ESBORRATS              ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void ConsolaFons()
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 100;
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }
        static void OrdenarFitxer()
        {
            //Per a poder provar com funciona, executes el programa i selecciones el 4, despres obre el agendatmp.txt per veure el fitxer ordenat, pero mira tmb el agenda.
            StreamReader SR = new StreamReader("agenda.txt");
            StreamWriter SW = new StreamWriter("agendatmp.txt");
            string frase = "", frase2 = "", fraseMenor = "", fraseSegonMenor = "", nom = "", nom2 = "", nomAnterior = "", menor = "", segonMenor = "";
            while (!SR.EndOfStream)
            {
                frase = SR.ReadLine();
                nom = frase.Substring(0, frase.IndexOf(';'));

                StreamReader SR2 = new StreamReader("agenda.txt");

                menor = "zzzz";

                frase2 = SR2.ReadLine();
                nom2 = frase2.Substring(0, frase2.IndexOf(';'));
                while (!SR2.EndOfStream)
                {
                    if (nom2.CompareTo(menor) < 0 && nom2.CompareTo(segonMenor) > 0)
                    {
                        fraseMenor = frase2;
                        menor = nom2;
                    }
                    frase2 = SR2.ReadLine();
                    nom2 = frase2.Substring(0, frase2.IndexOf(';'));
                }
                SR2.Close();
                segonMenor = menor;
                fraseSegonMenor = fraseMenor;
                SW.WriteLine(fraseSegonMenor);
            }
            SR.Close();
            SW.Close();
        }
    }
}