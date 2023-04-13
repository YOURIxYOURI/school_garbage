
using _13042023;

IList<Lokomotywa> l = new List<Lokomotywa>{new Lokomotywa(20, 5 , "a")};
IList<Przedzial> p = new List<Przedzial> { new Przedzial(10), new Przedzial(10) };
IList<Wagon> w = new List<Wagon> { new Osobowy(30, 5 ,"aa"), new Osobowy(30, 5, "ab"), new OsobowyPrzedzialy(p, 5, "ac")};

Sklad s = new(l, w);

s.Print();

Console.WriteLine(s.FindWagonBy(wagon => wagon.nazwa == "aa"));
Console.WriteLine(s.FindLokomotywaBy(lok => lok.nazwa == "a"));

s.removeWagon(wagon => wagon.nazwa == "aa");
s.removeLokomotywa(lok => lok.nazwa == "a");

s.Print();

s.addLokomotywa(new Lokomotywa(20, 5, "b"));

s.Print();
