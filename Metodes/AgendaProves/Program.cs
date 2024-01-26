RecollidaDades("");
static void RecollidaDades(string dades)
{
    string nom = "", cognom1 = "", cognom2 = "", dni = "", telefon = "", data = "", correu = "";
    char resposta = ' ';
    Console.WriteLine("Indica el teu nom: ");
    nom = Convert.ToString(Console.ReadLine());
    nom = CorregirNoms(nom);
    dades += nom + " ";
    Console.WriteLine("Tens mes d'un cognom? (S/N): ");
    resposta = Convert.ToChar(Console.ReadLine());
    resposta = char.ToUpper(resposta);
    if (resposta == 'S')
    {
        Console.WriteLine("Indica el primer cognom: ");
        cognom1 = Convert.ToString(Console.ReadLine());
        cognom1 = CorregirNoms(cognom1);
        Console.WriteLine("Indica el primer cognom: ");
        cognom2 = Convert.ToString(Console.ReadLine());
        cognom2 = CorregirNoms(cognom2);
        dades += cognom1 + " " + cognom2 + " ";
    }
    else
    {
        Console.WriteLine("Indica el cognom: ");
        cognom1 = Convert.ToString(Console.ReadLine());
        cognom1 = CorregirNoms(cognom1);
        dades += cognom1 + " ";
    }
    Console.WriteLine("Indica el teu dni: ");
    dni = Convert.ToString(Console.ReadLine());
    dades += dni + " ";
    while (!ValidacioDNI(dni))
    {
        Console.WriteLine("DNI erroni, introdueix un DNI valid: ");
        dni = Convert.ToString(Console.ReadLine());
    }
    Console.WriteLine("Indica el teu telefon: ");
    telefon = Convert.ToString(Console.ReadLine());
    while (!VerificarNumeros(telefon))
    {
        Console.WriteLine("DNI erroni, introdueix un DNI valid: ");
        telefon = Convert.ToString(Console.ReadLine());
    }
    dades += telefon + " ";
    Console.WriteLine("Indica el teu data de naixement: ");
    data = Convert.ToString(Console.ReadLine());
    dades += data + " ";
    Console.WriteLine("Indica el teu correu electronic: ");
    correu = Convert.ToString(Console.ReadLine());
    data += correu;
    dades = DadesAddCSV(ref dades);
    AgendaWriter(dades);
}
static string DadesAddCSV(ref string dades)
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
    Console.WriteLine("hola");
    return true;
}
static void AgendaWriter(string linea)
{
    StreamWriter agendaW = new StreamWriter("agenda.txt");
    agendaW.WriteLine(linea);
    agendaW.Close();
}
