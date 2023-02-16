using System.Drawing;
using System.Reflection.Metadata.Ecma335;

class Punkt {
    public double x
    {
        get; set;
    }
    public double y
    {
        get; set;
    }
    public Punkt() { }
    public Punkt(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public Punkt(Punkt p)
    {
        this.x = p.x;
        this.y = p.y;
    }
    public double odl(Punkt p)
    {
        return Math.Sqrt((p.x - x) * (p.x - x) + (p.y - y) * (p.y - y));
    }

    public override string ToString()
    {
        return $"{x} {y}";
    }

    public static Punkt operator +(Punkt a, Punkt b) => new Punkt(a.x + b.x, a.y + b.y);
    public static Punkt operator -(Punkt a, Punkt b) => new Punkt(a.x - b.x, a.y - b.y);
    public static Punkt operator -(Punkt a) => new Punkt(-a.x, -a.y);
    public static Punkt operator *(Punkt a, double b) => new Punkt(a.x * b, a.y * b);
    public static Punkt operator *(double b, Punkt a) => new Punkt(a.x * b, a.y * b);
    public static bool operator !=(Punkt a, Punkt b) 
    {
        double o1 = a.odl(new Punkt(0, 0));
        double o2 = b.odl(new Punkt(0, 0));
        if (Math.Abs(o1 - o2) < Math.Pow(10, -10))
        {
            return false;
        }
        else
        {
           return true;
        }
    }
    public static bool operator ==(Punkt a, Punkt b) 
    {
        double o1 = a.odl(new Punkt(0, 0));
        double o2 = b.odl(new Punkt(0, 0));
        if (Math.Abs(o1 - o2) < Math.Pow(10, -10))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    public static bool operator <(Punkt a, Punkt b)
    {
        double o1 = a.odl(new Punkt(0, 0));
        double o2 = b.odl(new Punkt(0, 0));
        if (o1 < o2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator >(Punkt a, Punkt b)
    {
        double o1 = a.odl(new Punkt(0, 0));
        double o2 = b.odl(new Punkt(0, 0));
        if (o1 > o2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}

class Wielobok {


    List<Punkt> punkty = new List<Punkt>();

    public Wielobok()
    {

    }
    public Wielobok(Punkt[] punkty)
    {
        for (int i = 0; i < punkty.Length; i++)
        {
            this.punkty.Add(new Punkt(punkty[i].x, punkty[i].y));
        }
    }
    public Wielobok(Wielobok w)
    {
        for (int i = 0; i < w.punkty.Count; i++)
        {
            this.punkty.Add(new Punkt(w.punkty[i].x, w.punkty[i].y));
        }
    }

    public Wielobok(List<Punkt> punkty)
    {
        this.punkty.AddRange(punkty);
    }
    public void dodaj(double x, double y)
    {
        punkty.Add(new Punkt(x, y));
    }
    public void dodaj(Punkt p)
    {
        punkty.Add(p);
    }
    public void usun(int i)
    {
        punkty.RemoveAt(i);
    }
    public void usun()
    {
        punkty.Clear();
    }
    public double obw()
    {
        double obw = .0;

        for (int i = 0; i < punkty.Count; i++)
        {
            if (i == punkty.Count-1)
            {
                obw += punkty[i].odl(punkty[0]);
            }
            else
                obw += punkty[i].odl(punkty[i+1]);
        }
            
        return obw;
    }
    public override string ToString()
    {
        string tmp = "";
        for (int i = 0; i < punkty.Count; i++) 
        {
            tmp += $"[{punkty[i].x} {punkty[i].y}]";
        }
        tmp += "\n";
        return tmp;
    }
}

public class program
{
    static void Main()
    {
        Punkt p1 = new Punkt(1,2);
        Punkt p2 = new Punkt(2, 2);
        Punkt p3 = new Punkt(2, 1);
        Punkt p4 = new Punkt(1, 1);

        Punkt[] punkty = { p1, p2, p3, p4 };

        Wielobok w = new Wielobok(punkty);
        Console.WriteLine(w.obw());
        Console.WriteLine(w.ToString());
        p3 = p1 + p2;
        p3 *= 3.3;
        p4 = -p2;
        Console.WriteLine("{0}\n{1}\n{2}\n{3}", p1, p2, p3, p4);
        if (p1 == p2)
            Console.WriteLine("równe");
        else
            Console.WriteLine("nie równe");

        if (p4 == p2)
            Console.WriteLine("równe");
        else
            Console.WriteLine("nie równe");

        if (p3 == p2)
            Console.WriteLine("równe");
        else
            Console.WriteLine("nie równe");
        Console.ReadKey();


    }
}
