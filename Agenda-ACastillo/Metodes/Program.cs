Console.Write("Que vols fer: ");
int aux = Convert.ToInt32(Console.ReadLine());
switch (aux)
{
    //Introducir dades (1)
    case 1:
        RecollidaDades("");
        break;
    //Recuperar usuari (2)
    case 2:
        Console.Write("Indica el nom d'usuari: ");
        string usuari = Convert.ToString(Console.ReadLine());
        usuari = CorregirNoms(usuari);
        bool trobat = false;
        if (TrobarUsuari(usuari) == "")
        {
            while (!trobat)
            {
                trobat = UsuariNoTrobat();
            }
        }
        else Console.WriteLine(TrobarUsuari(usuari));
        break;
    case 3:
        Console.WriteLine("Indica el usuari que vols modificar: ");
        string usuari = Convert.ToString(Console.ReadLine());
        usuari = CorregirNoms(usuari);
        bool trobat = false;
        if (TrobarUsuari(usuari) == "")
        {
            while (!trobat)
            {
                trobat = UsuariNoTrobat();
            }
        }
        break;
    default:
        Console.WriteLine("hola");
        break;
}
static void RecollidaDades(string dades) //Metode per recollir les dades.
{
    string nom = "", cognom1 = "", cognom2 = "", dni = "", telefon = "", data = "", correu = "";
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
    dades = DadesAddCSV(ref dades); //Cridem al metode per posar els ";" pertinents.
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
    int numeros = int.Parse(numerosString); //
    char lletraCalcul = LletraControl(numeros);
    if (lletraCalcul != char.ToUpper(lletra[0]))
        validacio = false;
    return validacio;
}
static char LletraControl(int numero) //Aquest metode fa la operacio per calcular la lletra de control.
{
    string caracters = "TRWAGMYFPDXBNJZSQVHLCKE";
    int i = numero % caracters.Length;
    return caracters[i];
}
static bool VerificarNumeros(string telefon)
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
static bool VerificacionData(string data)
{
    Console.Write("hola");
    return true;
}
static void AgendaWriter(string linea)
{
    StreamWriter agendaW;
    if (File.Exists("agenda.txt"))
    {
        agendaW = new StreamWriter("agenda.txt", true);
    }
    else
    {
        agendaW = new StreamWriter("agenda.txt");
    }
    agendaW.WriteLine(linea);
    agendaW.Close();
}
static string TrobarUsuari(string usuari)
{
    StreamReader agendaR = new StreamReader("agenda.txt");
    bool trobat = false;
    string linea = agendaR.ReadLine(), aux = "", nom = "";
    while (!trobat && !agendaR.EndOfStream)
    {
        linea = agendaR.ReadLine();
        aux = linea;
        nom = linea.Substring(0, linea.IndexOf(';'));
        if (usuari == nom)
            trobat = true;
    }
    if (!trobat)
        aux = "";
    agendaR.Close();
    return aux;
}
static void BorrarConsola()
{
    Console.Clear();
    return;
}
static string ModificarUsuaris(string usuari)
{
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
static int ArreglarPosicio(ref int posicio, int i)
{
    if (i == 6 && posicio >= 3)
        i++;
}
static void UsuariModificat(string linea, string lineaNova)
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
static bool UsuariNoTrobat()
{
    string usuari = "";
    bool usuaritrobat = false;
    Console.WriteLine("L'usuari no s'ha trobat, vols buscar un altre? (S/N)");
    char resposta = Convert.ToChar(Console.ReadLine());
    while (resposta == 'S' && !usuaritrobat)
    {
        Console.Write("Indica el nom d'usuari: ");
        string usuari = Convert.ToString(Console.ReadLine());
        usuari = CorregirNoms(usuari);
        usuari = TrobarUsuari(usuari);
        if (usuari != "")
        {
            usuaritrobat = true;
        }
        else
        {
            Console.WriteLine("L'usuari no s'ha trobat, vols buscar un altre? (S/N)");
            resposta = Convert.ToChar(Console.ReadLine());
        }
    }
    return usuaritrobat;
}
static void UsuariEliminar(string linea) //Metode per eliminar una linea en concret.
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
    File.Delete("agenda.txt");
    File.Move("agendatmp.txt", "agenda.txt");
}
        }
    }
}