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
        if (TrobarUsuari(usuari) == "")
            Console.WriteLine("No s'ha trobat cap usuari amb aquest usuari, vols buscar un altre? "); //Yo aqui volveria al menu.
        //resposta = convert.ToString(Console.ReadLine());
        //if resposta es no se que vuelve a pedir el swtich
        //si no da igual y vuelve al menu
        else Console.WriteLine(TrobarUsuari(usuari));
        break;
    default:
        Console.WriteLine("hola");
        break;
}
static void RecollidaDades(string dades) //Angel: Quiero que cada vez
{
    string nom = "", cognom1 = "", cognom2 = "", dni = "", telefon = "", data = "", correu = "";
    char resposta = ' ';
    BorrarConsola();
    Console.WriteLine("Indica el teu nom: ");
    nom = Convert.ToString(Console.ReadLine());
    nom = CorregirNoms(nom);
    dades += nom + " ";
    BorrarConsola();
    Console.Write("Tens mes d'un cognom? (S/N): ");
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
    while (!ValidacioDNI(dni))
    {
        Console.Write("DNI erroni, introdueix un DNI valid: ");
        dni = Convert.ToString(Console.ReadLine());
    }
    BorrarConsola();
    Console.Write("Indica el teu telefon: ");
    telefon = Convert.ToString(Console.ReadLine());
    while (!VerificarNumeros(telefon))
    {
        Console.Write("Telefon erroni, introdueix un telefon valid: ");
        telefon = Convert.ToString(Console.ReadLine());
    }
    dades += telefon + " ";
    BorrarConsola();
    Console.Write("Indica el teu data de naixement: ");
    data = Convert.ToString(Console.ReadLine());
    dades += data + " ";
    BorrarConsola();
    Console.Write("Indica el teu correu electronic: ");
    correu = Convert.ToString(Console.ReadLine());
    data += correu;
    dades = DadesAddCSV(ref dades);
    AgendaWriter(dades);
}
static string DadesAddCSV(ref string dades) //Me pone un ; doble al final, puede que haya un espacio final
{
    string caracter = ";";
    for (int i = 0; i < dades.Length; i++)
    {
        if (dades[i] == ' ')
            dades = dades.Substring(0, i) + caracter + dades.Substring(i + 1);
    }
    dades = dades.Substring(0, dades.Length) + caracter;
    return dades;
}
static string CorregirNoms(string text)
{
    string lletraMajuscula = char.ToUpper(text[0]).ToString();
    string resta = text.Substring(1);
    return lletraMajuscula + resta;
}
static string NoLletres(string text)
{
    string modificat = "";
    for (int i = 0; i < text.Length; i++)
    {
        if (char.IsLetter(text[i]))
            modificat += text[i];
    }
    return modificat;
}
static bool ValidacioDNI(string dni)
{
    bool validacio = true;
    string digits = "0123456789";
    if (dni.Length != 9)
        validacio = false;
    string numerosString = dni.Substring(0, 8);
    string lletra = dni.Substring(8, 1);
    for (int i = 0; i < numerosString.Length && validacio; i++)
    {
        if (!digits.Contains(numerosString[i]))
            validacio = false;
    }
    int numeros = int.Parse(numerosString);
    char lletraCalcul = LletraControl(numeros);
    if (lletraCalcul != char.ToUpper(lletra[0]))
        validacio = false;
    return validacio;
}
static char LletraControl(int numero)
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