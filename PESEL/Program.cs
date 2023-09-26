Console.WriteLine("Wybierz Opcje\n1. Wczytaj Dane i Zapisz Plik\n2. Odczytaj dane z pliku");
int choosed = int.Parse(Console.ReadLine());
if(choosed == 1)
{
    Console.WriteLine("Podaj Imię");
    string firstName = Console.ReadLine();
    Console.WriteLine("Podaj Nazwisko");
    string lastName = Console.ReadLine();
    Console.WriteLine("Podaj PESEL");
    string pesel = Console.ReadLine();

    int age = calculateAge(pesel);
    string gender = calculateGender(pesel);

    string data = $"{firstName};{lastName};{pesel};{age};{gender}";
    File.WriteAllText("info.txt", data);

    Console.WriteLine("Pomyślnie zapisano dane");

}
else if(choosed == 2)
{
    string fileData = File.ReadAllText("info.txt");
    Console.WriteLine(fileData);
}
else
{
    Console.WriteLine("zła opcja dialogowa");
}

int calculateAge(string p)
{
    int birthYear = int.Parse(p.Substring(0,2));
    int birthMonth = int.Parse(p.Substring(2,2));
    int birthDay = int.Parse(p.Substring(4, 2));

    int Year = DateTime.Now.Year;
    int Month = DateTime.Now.Month;
    int Day = DateTime.Now.Day;

    if(birthMonth >= 0 && birthMonth <= 31)
    {
        birthYear += 2000;
    }else if(birthMonth >= 32 && birthMonth <= 99)
    {
        birthYear += 1900;                                                                      
    }

    if(birthMonth >Month  ||(birthMonth == Month && birthDay > Day))
    {
        Year--;
    }
    int age = Year - birthYear;
    return age;
}

string calculateGender(string p)
{
    return int.Parse(p.Substring(9,1)) % 2 == 2 ? "Kobieta" : "Mężczyzna" ;
}
