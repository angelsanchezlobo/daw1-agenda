
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Agenda_ACastillo
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcioS = "", usuari; int numero1, numero2, aux;
            bool trobat = false;
            char respostaS = ' ';
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
                    RetornCincSegons();
                    BorrarConsola();
                }
                else
                {
                    aux = Convert.ToInt32(opcioS);
                    switch (aux)
                    {
                        //Veure llistat de persones de l'agenda
                        case 1:
                            BorrarConsola();
                            Capcalera1();
                            MostrarOrdenats();
                            RetornCincSegons();
                            BorrarConsola();
                            break;
                        //Afegir contactes a l'agenda
                        case 2:
                            Capcalera2();
                            RecollidaDades();
                            RetornTresSegons();
                            BorrarConsola();
                            break;
                        //Esborrar contactes
                        case 3:
                            Capcalera3();
                            Console.Write("Indica el usuari que vols esborrar: ");
                            usuari = Convert.ToString(Console.ReadLine());
                            usuari = CorregirNoms(usuari);
                            trobat = false;
                            if (TrobarUsuari(usuari) == "")
                            {
                                while (TrobarUsuari(usuari) == "")
                                {
                                    usuari = UsuariNoTrobat();
                                }
                            }
                            string linea = TrobarUsuari(usuari);
                            UsuariEliminar(linea);
                            RetornCincSegons();
                            BorrarConsola();
                            break;
                        //Modificar usuari
                        case 4:
                            BorrarConsola();
                            Capcalera4();
                            Console.Write("Indica el usuari que vols modificar: ");
                            usuari = Convert.ToString(Console.ReadLine());
                            usuari = CorregirNoms(usuari);
                            trobat = false;
                            if (TrobarUsuari(usuari) == "")
                            {
                                while (TrobarUsuari(usuari) == "")
                                {
                                    usuari = UsuariNoTrobat();
                                }
                            }
                            linea = TrobarUsuari(usuari);
                            BorrarConsola();
                            string lineaNova = ModificarUsuaris(linea);
                            UsuariModificat(linea, lineaNova);
                            while (respostaS != 'N')
                            {
                                Console.WriteLine("Vols tornar a modificar un altre dada?: (S/N)");
                                respostaS = Convert.ToChar(Console.ReadLine());
                                BorrarConsola();
                                lineaNova = ModificarUsuaris(linea);
                            }
                            RetornCincSegons();
                            BorrarConsola();
                            break;
                        case 5:
                            BorrarConsola();
                            Capcalera5();
                            Console.Write("Indica el nom d'usuari: ");
                            usuari = Convert.ToString(Console.ReadLine());
                            usuari = CorregirNoms(usuari);
                            trobat = false;
                            if (TrobarUsuari(usuari) == "")
                            {
                                while (TrobarUsuari(usuari) == "")
                                {
                                    usuari = UsuariNoTrobat();
                                }
                            }
                            else
                            {
                                linea = TrobarUsuari(usuari);
                                DividirLineaAgradable(linea);
                            }
                            RetornCincSegons();
                            BorrarConsola();
                            break;
                        case 6:
                            BorrarConsola();
                            Capcalera6();
                            OrdenarFitxer();
                            RetornCincSegons();
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
            if ("654321".Contains(opcioS))
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
        static void RetornCincSegons()
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
        static void RetornTresSegons()
        {
            int contador = 3;
            while (contador >= 0)
            {
                Console.Write("\r");
                Console.Write($"Tornant al menù principal en {contador} segons...");
                Thread.Sleep(1000);
                contador--;
            }
            return;
        }
        static void BorrarConsola() 
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
                   "║                  4 - MODIFICAR CONTACTES              ║\n" +
                   "║                  5 - ENSENYAR CONTACTE                ║\n" +
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
            Console.WriteLine("                    MODIFICAR CONTACTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void Capcalera5()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    ENSENYAR CONTACTE                            ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void Capcalera6()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    ORDENAR FITXER                                ");
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
            File.Delete("agenda.txt");
            File.Move("agendatmp.txt", "agenda.txt");
        }
        static void MostrarOrdenats()
        {
            StreamReader SR = new StreamReader("agenda.txt");
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
                Console.WriteLine(fraseSegonMenor);//Hauriem de crear un metode per dividir el nom i el telefon i mostrarlo de una forma adecuada.
            }
            SR.Close();
        }
        static void RecollidaDades() //Metode per recollir les dades.
        {
            string dades = "", nom = "", cognom1 = "", cognom2 = "", dni = "", telefon = "", data = "", correu = "";
            char resposta = ' ';
            BorrarConsola();
            Console.WriteLine("Indica el teu nom: ");
            nom = Convert.ToString(Console.ReadLine());
            nom = CorregirNoms(nom);
            dades += nom + " "; //Aixo es repetirà durant tot el metodé ja que el que fem es anar formant la linea.
            BorrarConsola();
            Console.Write("Tens mes d'un cognom? (S/N): "); //Mirarem els cognoms, depenent la resposta es demana 1 o 2 dades.
            resposta = Convert.ToChar(Console.ReadLine());
            resposta = char.ToUpper(resposta);
            if (resposta == 'S')
            {
                BorrarConsola();
                Console.Write("Indica el primer cognom: ");
                cognom1 = Convert.ToString(Console.ReadLine());
                cognom1 = CorregirNoms(cognom1);
                BorrarConsola();
                Console.Write("Indica el segon cognom: ");
                cognom2 = Convert.ToString(Console.ReadLine());
                cognom2 = CorregirNoms(cognom2);
                dades += cognom1 + " " + cognom2 + " ";
            }
            else
            {
                BorrarConsola();
                Console.Write("Indica el cognom: ");
                cognom1 = Convert.ToString(Console.ReadLine());
                cognom1 = CorregirNoms(cognom1);
                dades += cognom1 + " ";
            }
            BorrarConsola();
            Console.Write("Indica el teu dni: ");
            dni = Convert.ToString(Console.ReadLine());
            dades += dni + " ";
            while (!ValidacioDNI(dni)) //Cridem al metode per verificar el DNI.
            {
                Console.Write("DNI erroni, introdueix un DNI valid: ");
                dni = Convert.ToString(Console.ReadLine());
            }
            BorrarConsola();
            Console.Write("Indica el teu telefon: ");
            telefon = Convert.ToString(Console.ReadLine());
            while (!VerificarNumeros(telefon)) //Cridem al metode per verificar el telefon.
            {
                Console.Write("Telefon erroni, introdueix un telefon valid: ");
                telefon = Convert.ToString(Console.ReadLine());
            }
            dades += telefon + " ";
            BorrarConsola();
            Console.Write("Indica el teu data de naixement: "); //!He de crear el metode per verificar la data de naixement! <--
            data = Convert.ToString(Console.ReadLine());
            dades += data + " ";
            BorrarConsola();
            Console.Write("Indica el teu correu electronic: ");
            correu = Convert.ToString(Console.ReadLine());
            data += correu;
            DadesAddCSV(ref dades); //Cridem al metode per posar els ";" pertinents.
            dades = CorregirPuntIComaFinal(dades); //Treurem el ";" final.
            Console.WriteLine($"Nom: {nom}, Cognom: {cognom1} {cognom2}, DNI: {dni} \n " +
                              $"Telefon: {telefon}, Data Naixement: {data}, Correu Electronic: {correu}");
            AgendaWriter(dades); //Cridem al metode per esciure en el fitxer agenda.
        }
        static string DadesAddCSV(ref string dades) //Me pone un ; doble al final, puede que haya un espacio final
        {
            string caracter = ";"; //Declarem el caracter que posarem cada vegada que hi hagi un espai.
            for (int i = 0; i < dades.Length; i++) //Un bucle que arribara fins al final de tota la linea, que el contador farem servir com index.
            {
                if (dades[i] == ' ') //Si trobem un espai en el index el treurem.
                    dades = dades.Substring(0, i) + caracter + dades.Substring(i + 1); //Agafem des del principi fins el espai, posem un ";" i des del espai + 1 fins al final.
            }
            dades = dades.Substring(0, dades.Length) + caracter; //Aqui es simplement per posar un ; final (podria ser la causa del ; doble final).
            return dades;
        }
        static string CorregirNoms(string text) //Aquest metode es simplement per posar la primera lletra del nom, cognom o lo que sigui en majuscula.
        {
            string lletraMajuscula = char.ToUpper(text[0]).ToString();
            string resta = text.Substring(1);
            return lletraMajuscula + resta;
        }
        static string NoLletres(string text) //Metode per treure tot el que no sigui una lletra.
        {
            string modificat = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                    modificat += text[i];
            }
            return modificat;
        }
        static bool ValidacioDNI(string dni) //Metode per verificar un DNI mitjançant operacions.
        {
            bool validacio = true; //Entenem que es valid des del principi per fer les validacions i en tot cas retornar un false unic.
            string digits = "0123456789";
            if (dni.Length != 9) //Mirem si te 9 digits com un DNI valid.
                validacio = false;
            string numerosString = dni.Substring(0, 8); //Agafem tots els numeros.
            string lletra = dni.Substring(8, 1); //Agafem la lletra de control.
            for (int i = 0; i < numerosString.Length && validacio; i++) //Aixo es un bucle per mirar si nomes son numeros recorrent tots els numeros del DNI.
            {
                if (!digits.Contains(numerosString[i]))
                    validacio = false;
            }
            int numeros = int.Parse(numerosString); //Pasem els numeros en String --> Int
            char lletraCalcul = LletraControl(numeros); //Enviem els numeros al metode per calcular la lletra de control.
            if (lletraCalcul != char.ToUpper(lletra[0])) //Mirem si la lletra de control es diferent.
                validacio = false;
            return validacio;
        }
        static char LletraControl(int numero) //Aquest metode fa la operacio per calcular la lletra de control.
        {
            string caracters = "TRWAGMYFPDXBNJZSQVHLCKE";
            int i = numero % caracters.Length;
            return caracters[i];
        }
        static bool VerificarNumeros(string telefon) //En aquest metode comrpovem si tots els caracters del telefon son numeros.
        {
            bool validacio = true;
            string digits = "0123456789";

            for (int i = 0; i < telefon.Length; i++)
            {
                if (!digits.Contains(telefon[i]))
                    validacio = false;
            }
            return validacio;
        }
        static bool VerificacionData(string data) //Aquest es el metode que falta per fer de la data de naixement.
        {
            Console.Write("hola");
            return true;
        }
        static void AgendaWriter(string linea) //Metode per escirure la linea en el fitxer agenda.
        {
            StreamWriter agendaW;
            if (File.Exists("agenda.txt")) //Fent aquest if comprovem que el fitxer existeix per no sobreescriure el fitxer i esborrar les que teniem.
            {
                agendaW = new StreamWriter("agenda.txt", true); //El "true" per el que he cercat es per esciure la linea en el fitxer sense fer un altre fitxer.
            }
            else
            {
                agendaW = new StreamWriter("agenda.txt");
            }
            agendaW.WriteLine(linea);
            agendaW.Close();
        }
        static string TrobarUsuari(string usuari) //En aquest metode agafarem la linea del usuari.
        {
            StreamReader agendaR = new StreamReader("agenda.txt");
            bool trobat = false;
            string linea = agendaR.ReadLine(), aux = "", nom = "";
            while (!trobat && !agendaR.EndOfStream) //Bucle per llegir linea per linea on si trovem la linea modificarem un bool --> true per parar el bucle o fins llegir tot el fitxer.
            {
                linea = agendaR.ReadLine();
                aux = linea;
                nom = linea.Substring(0, linea.IndexOf(';'));
                if (usuari == nom)
                    trobat = true;
            }
            if (!trobat)
                aux = ""; //Si trobat es false modificarem aquesta linea per donar a entendre que no s'ha trobat i fer-ho servir en un altre if per donar a entendre que es un false.
            agendaR.Close();
            return aux;
        }
        static string ModificarUsuaris(string usuari) //En aquest metode s'agafa la linea, es tallen totes les dades i al final la modificació del usuari
        {                                             //canvia el contingut de la variable tallada. Al final es forma tota la linea.
            string linea = TrobarUsuari(usuari);
            string aux = linea, lineaNova = "";
            int i = 0, posicioDada = 0;
            string nom = "", cognom1 = "", cognom2 = "", dni = "", telefon = "", data = "", correu = "";
            Console.WriteLine(linea);
            while (aux.IndexOf(';') != -1)
            {
                i++;
                aux = aux.Substring(0, aux.IndexOf(';') + 1);
            }
            if (i == 7)
            {
                string menu;
                menu = "╔═══════════════════════════════════════════════════════╗\n" +
                       "║                    DADES A MODIFICAR                  ║\n" +
                       "╠═══════════════════════════════════════════════════════╣\n" +
                       "║                                                       ║\n" +
                       "║                1 - Nom                                ║\n" +
                       "║                2 - Cognom 1                           ║\n" +
                       "║                3 - Cognom 2                           ║\n" +
                       "║                4 - DNI                                ║\n" +
                       "║                5 - Telefon                            ║\n" +
                       "║                6 - Data Naixement                     ║\n" +
                       "║                7 - Correu Electronic                  ║\n" +
                       "║                                                       ║\n" +
                       "╚═══════════════════════════════════════════════════════╝";

                Console.WriteLine(menu);
                Console.Write("Indica quina dada vols modificar: ");
                posicioDada = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                string menu;
                menu = "╔═══════════════════════════════════════════════════════╗\n" +
                       "║                    DADES A MODIFICAR                  ║\n" +
                       "╠═══════════════════════════════════════════════════════╣\n" +
                       "║                                                       ║\n" +
                       "║                1 - Nom                                ║\n" +
                       "║                2 - Cognom 1                           ║\n" +
                       "║                3 - DNI                                ║\n" +
                       "║                4 - Telefon                            ║\n" +
                       "║                5 - Data Naixement                     ║\n" +
                       "║                6 - Correu Electronic                  ║\n" +
                       "║                                                       ║\n" +
                       "╚═══════════════════════════════════════════════════════╝";

                Console.WriteLine(menu);
                Console.Write("Indica quina dada vols modificar: ");
                posicioDada = Convert.ToInt32(Console.ReadLine());
            }
            posicioDada = ArreglarPosicio(ref posicioDada, i);
            nom = AgafarDada(ref linea);
            cognom1 = AgafarDada(ref linea);
            if (i == 7)
            {
                cognom2 = AgafarDada(ref linea);
            }
            dni = AgafarDada(ref linea);
            telefon = AgafarDada(ref linea);
            data = AgafarDada(ref linea);
            correu = AgafarDada(ref linea);
            switch (posicioDada)
            {
                case 1:
                    Console.WriteLine("Escriu un nou nom: ");
                    nom = Convert.ToString(Console.ReadLine());
                    nom = CorregirNoms(nom);
                    break;
                case 2:
                    Console.WriteLine("Escriu un nou primer cognom: ");
                    cognom1 = Convert.ToString(Console.ReadLine());
                    cognom1 = CorregirNoms(cognom1);
                    break;
                case 3:
                    if (i == 7)
                    {
                        Console.WriteLine("Escriu un nou segon cognom: ");
                        cognom2 = Convert.ToString(Console.ReadLine());
                        cognom2 = CorregirNoms(cognom2);
                    }
                    else
                    {
                        Console.WriteLine("No hi ha segon cognom a modificar.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Escriu un nou DNI: ");
                    dni = Convert.ToString(Console.ReadLine());
                    while (!ValidacioDNI(dni))
                    {
                        Console.Write("DNI erroni, introdueix un DNI valid: ");
                        dni = Convert.ToString(Console.ReadLine());
                    }
                    break;
                case 5:
                    Console.WriteLine("Escriu un nou telefon: ");
                    telefon = Convert.ToString(Console.ReadLine());
                    while (!VerificarNumeros(telefon))
                    {
                        Console.Write("Telefon erroni, introdueix un telefon valid: ");
                        telefon = Convert.ToString(Console.ReadLine());
                    }
                    break;
                case 6:
                    Console.WriteLine("Escriu una nova data de naixement: ");
                    data = Convert.ToString(Console.ReadLine());
                    break;
                case 7:
                    Console.WriteLine("Escriu un nou correu electronic: ");
                    correu = Convert.ToString(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("");
                    break;
            }
            if (i == 7)
                lineaNova = $"{nom};{cognom1};{cognom2};{dni};{telefon};{data};{correu};";
            else
                lineaNova = $"{nom};{cognom1};{dni};{telefon};{data};{correu};";
            return lineaNova;
        }
        static string CorregirPuntIComaFinal(string linea)
        {
            linea = linea.Substring(0, linea.Length - 1);
            return linea;
        }
        static string AgafarDada(ref string linea)
        {
            string dada = linea.Substring(0, linea.IndexOf(';'));
            linea = linea.Substring(linea.IndexOf(';') + 1);
            return dada;
        }
        static int ArreglarPosicio(ref int posicio, int i) //Aquest metode es per a que si no hi han dos cognoms el switch funcioni correctament al metode de modificar.
        {
            if (i == 6 && posicio >= 3)
                posicio++;
            return posicio;
        }
        static void UsuariModificat(string linea, string lineaNova) //Metode per escriure la nova linea en el fitxer agenda.
        {
            StreamReader sr = new StreamReader("agenda.txt");
            StreamWriter sw = new StreamWriter("agendatmp.txt");
            string aux;
            bool canvi = false;
            while (!sr.EndOfStream)
            {
                aux = sr.ReadLine();
                if (aux == linea && !canvi)
                {
                    sw.WriteLine(lineaNova);
                    canvi = true;
                }
                else
                {
                    sw.WriteLine(aux);
                }
            }
            sr.Close();
            sw.Close();
            File.Delete("agenda.txt");
            File.Move("agendatmp.txt", "agenda.txt");
        }
        static string UsuariNoTrobat() //Metode per en cas que no trobem al usuari fer un bucle, anem preguntant si volem cercar un altre o parar-ho, en tot cas
        {                              //retornarem el nom d'usuari per continuar amb el procediment.
            string usuari = "";
            bool usuaritrobat = false;
            Console.WriteLine("L'usuari no s'ha trobat, vols buscar un altre? (S/N)");
            char resposta = Convert.ToChar(Console.ReadLine());
            while (resposta == 'S' && !usuaritrobat) //Mentres la resposta sigui afirmativa i no s'hagui trobat l'usuari es farà el bucle.
            {
                Console.Write("Indica el nom d'usuari: ");
                usuari = Convert.ToString(Console.ReadLine());
                usuari = CorregirNoms(usuari);
                usuari = TrobarUsuari(usuari);
                if (usuari != "")
                {
                    usuaritrobat = true;
                    usuari = usuari.Substring(0, usuari.IndexOf(';'));
                    usuari = CorregirNoms(usuari);
                }
                else
                {
                    usuari = "";
                    Console.Write("L'usuari no s'ha trobat, vols buscar un altre? (S/N)");
                    resposta = Convert.ToChar(Console.ReadLine());
                }
            }
            return usuari;
        }
        static void UsuariEliminar(string linea) //Metode per eliminar una linea en concret. Es declaren dos fitxers, un temporal que el substituirem pel original.
        {
            StreamReader sr = new StreamReader("agenda.txt");
            StreamWriter sw = new StreamWriter("agendatmp.txt");
            string aux;
            while (!sr.EndOfStream)
            {
                aux = sr.ReadLine();
                if (aux == linea) { }
                else
                {
                    sw.WriteLine(aux);
                }
            }
            sr.Close();
            sw.Close();
            File.Delete("agenda.txt"); //Elimina el fitxer agenda
            File.Move("agendatmp.txt", "agenda.txt"); //Canvia el nom del fitxer a "agenda.txt".
        }
        static void DividirLineaAgradable(string linea)
        {
            string nom = "", cognom1 = "", cognom2 = "", dni = "", telefon = "", data = "", correu = "";
            int i = 0;
            while (linea.IndexOf(';') != -1)
            {
                linea = linea.Substring(linea.IndexOf(";") + 1);
                i++;
            }
            nom = linea.Substring(0, linea.IndexOf(';'));
            linea = linea.Substring(linea.IndexOf(";") + 1);
            cognom1 = linea.Substring(0, linea.IndexOf(';'));
            linea = linea.Substring(linea.IndexOf(";") + 1);
            if (i == 7)
            {
                cognom2 = linea.Substring(0, linea.IndexOf(';'));
                linea = linea.Substring(linea.IndexOf(";") + 1);
            }
            dni = linea.Substring(0, linea.IndexOf(';'));
            linea = linea.Substring(linea.IndexOf(";") + 1);
            telefon = linea.Substring(0, linea.IndexOf(';'));
            linea = linea.Substring(linea.IndexOf(";") + 1);
            data = linea.Substring(0, linea.IndexOf(';'));
            linea = linea.Substring(linea.IndexOf(";") + 1);
            correu = linea.Substring(0, linea.IndexOf(';'));
            linea = linea.Substring(linea.IndexOf(";") + 1);
            Console.WriteLine($"Nom: {nom}, Cognom: {cognom1} {cognom2}, DNI: {dni} \n " +
                              $"Telefon: {telefon}, Data Naixement: {data}, Correu Electronic: {correu}");
        }

    }
}