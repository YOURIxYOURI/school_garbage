using _20042023;

Vet v = new("Jan Kowalski", "jk@wp.pl", 111222333, "A", 5000);
Client c =  new("Tomasz Polak", "tp@wp.pl", 444555666);
Animal a = new("C", "D", DateTime.Now, "OPIS", "BRAK PROBLEMÓW ZDROWOTNYCH");

c.Add(a);
Clinic cl = new("ADADADA", "ADAs3/2");

cl.Add(v);

Console.WriteLine(cl.vets.ShowAll());


Visits vt = new(a, v, DateTime.Now, "PROSTY ZABIEG", cl);
Visits vvt = new(a, v, DateTime.Now, "TRUDNY ZABIEG", cl);

Console.WriteLine(cl.visits.ShowAll());

Animal aa = new("F", "R", DateTime.Now, "opis", "NiE SZCZEPIONY");

c.Add(aa);

Console.WriteLine(c.ToString());


