using System;

class Osoba
{
    private string imie, nazwisko;
    private int ru;
    
    public string Imie{
        get {return imie;}
        set {imie = value;}
    }
    public string Nazwisko{
        get {return nazwisko;}
        set {nazwisko = value;}
    }
    public int Ru{
        get {return ru;}
        set {ru = value;}
    }
    
    public Osoba() {
        imie = "Jan";
        nazwisko = "Kowalski";
        ru = 1999;
    }
    
    public Osoba(string Imie, string Nazwisko, int Ru) {
        imie = Imie;
        nazwisko = Nazwisko;
        ru = Ru;
    }
    
    public Osoba(Osoba o){
        imie = o.Imie;
        nazwisko = o.Nazwisko;
        ru = o.Ru;
    }
    
    public string toString(){
        string tmp = imie + " " + nazwisko + " " + ru.ToString();
        return tmp;
    }
};

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Osoba o1 = new Osoba();
        Osoba o2 = new Osoba("Bartosz", "Ujma", 2005);
        Console.WriteLine(o1.toString());
        Console.WriteLine(o2.toString());
        o1.Imie = "Michal";
        Osoba o3 = new Osoba(o1);
        Console.WriteLine(o3.toString());
    }
}
