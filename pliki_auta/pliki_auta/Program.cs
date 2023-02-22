using pliki_auta;


string[] tmp;
string line;
string path = @"C:\Users\admin\Desktop\qwerty\auta.txt";
List<Samochod> samochody = new(); 
try
{
    if (!File.Exists(path)) 
    {
        Console.WriteLine("SCIEZKA");
    }
    
    using (StreamReader file = new StreamReader(path))
    {
        line = file.ReadLine();
        while (line != null)
        {
            tmp = line.Split(' ');
            samochody.Add(new Samochod(tmp[0], tmp[1], double.Parse(tmp[2], System.Globalization.CultureInfo.InvariantCulture), Convert.ToInt16(tmp[3])));
            line = file.ReadLine();
        }
    }
    foreach (Samochod i in samochody)
        Console.WriteLine(i.ToString());
}
catch (Exception e)
{
    Console.WriteLine("The process failed: {0}", e.ToString());
}


